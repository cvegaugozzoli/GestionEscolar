using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CrystalDecisions.Shared;
using System.Linq;

public partial class InformesCurso : System.Web.UI.Page
{
    DataTable dt = new DataTable();

    DataTable dt2 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    Int32 insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                this.Master.TituloDelFormulario = " Cursado - Consulta";
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaSoloPrimSec("[Seleccionar...]"); carId.DataBind();
                #region PageIndex
                int PageIndex = 0;
                if (this.Session["InformesCurso.PageIndex"] == null)
                {
                    Session.Add("InformesCurso.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["InformesCurso.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //if (Session["CursoConsulta.Nombre"] != null) { Curso.Text = Session["CursoConsulta.Nombre"].ToString(); } else { Session.Add("CursoConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion

                GrillaCargar(PageIndex);
            }
        }

        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in Grilla.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        int ban = 0;
        lblMensajeError3.Text = "";
        foreach (GridViewRow row in Grilla.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
            if (check != null && check.Checked)
            {
                ban = 1;
            }
        }

        if (ban == 0)
        {
            lblMensajeError3.Text = "Debe seleccionar al menos un Alumno..";
            return;
        }
        else
        {

            if (TipoInformeId.SelectedValue == "2" && PeriodoId.SelectedValue == "1")
            {
                string tempFolder = Server.MapPath("~/Temp/");
                if (!Directory.Exists(tempFolder))
                    Directory.CreateDirectory(tempFolder);

                List<Stream> pdfStreams = new List<Stream>();

                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                    if (check != null && check.Checked)
                    {
                        int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);
                        int curso = Convert.ToInt32(curId.SelectedValue.ToString());
                        int anio = Convert.ToInt32(AnioCursado.Text);
                        int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);

                        // Cursos excluidos
                        int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

                        // Asignar el nombre del reporte según condiciones
                        string NomRep = (tipoCarrera == 2 && !cursosExcluidos.Contains(curso))
                            ? "InformePrimariaPT.rpt"
                            : "InformeSecundaria1C.rpt";

                        ReportDocument tempDoc = new ReportDocument();

                        if (string.IsNullOrEmpty(NomRep))
                        {
                            Response.Write("❌ ERROR: NomRep está vacío o nulo.");
                            return;
                        }

                        string ruta = Server.MapPath(string.Format("~/PaginasGenerales/Reportes/{0}", NomRep));
                        if (!File.Exists(ruta))
                        {
                            Response.Write("❌ ERROR: El archivo no existe en la ruta");
                            return;
                        }

                        tempDoc.Load(ruta);

                        // Parámetros del reporte     
                        tempDoc.SetParameterValue("@aluId", aluId);
                        tempDoc.SetParameterValue("@curso", curso);
                        tempDoc.SetParameterValue("@anio", anio);


                        // 🔒 Configurar conexión manual a la base de datos
                        //ConnectionInfo connectionInfo = new ConnectionInfo();
                        //connectionInfo.ServerName = "DESKTOP-DR5HH6H";
                        //connectionInfo.DatabaseName = "GESTIONESCOLAR";
                        //connectionInfo.UserID = "sa";
                        //connectionInfo.Password = "racing01";

                        ConnectionInfo connectionInfo = new ConnectionInfo();
                        connectionInfo.ServerName = "localhost";
                        connectionInfo.DatabaseName = "GestionEscolar";
                        connectionInfo.UserID = "sa";
                        connectionInfo.Password = "ms2014";

                        foreach (CrystalDecisions.CrystalReports.Engine.Table table in tempDoc.Database.Tables)
                        {
                            TableLogOnInfo logOnInfo = table.LogOnInfo;
                            logOnInfo.ConnectionInfo = connectionInfo;
                            table.ApplyLogOnInfo(logOnInfo);
                        }

                        // Exportar a PDF
                        Stream pdfStream = tempDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                        pdfStreams.Add(pdfStream);

                        tempDoc.Close();
                        tempDoc.Dispose();
                    }
                }

                if (pdfStreams.Count > 0)
                {
                    string combinedPath = Path.Combine(tempFolder, "InformeCombinado.pdf");
                    MergePDFs(pdfStreams, combinedPath);

                    // Guardás la ruta del archivo para abrirlo desde JavaScript
                    string relativePath = ResolveUrl("~/Temp/InformeCombinado.pdf");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenPDF", "window.open('" + relativePath + "', '_blank');", true);
                }
            }
            else
            {
                if (TipoInformeId.SelectedValue == "2" && PeriodoId.SelectedValue == "2")
                {
                    string tempFolder = Server.MapPath("~/Temp/");
                    if (!Directory.Exists(tempFolder))
                        Directory.CreateDirectory(tempFolder);

                    List<Stream> pdfStreams = new List<Stream>();

                    foreach (GridViewRow row in Grilla.Rows)
                    {
                        CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                        if (check != null && check.Checked)
                        {
                            int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);
                            int curso = Convert.ToInt32(curId.SelectedValue.ToString());
                            int anio = Convert.ToInt32(AnioCursado.Text);
                            int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);

                            // Cursos excluidos
                            int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

                            // Asignar el nombre del reporte según condiciones
                            string NomRep = (tipoCarrera == 2 && !cursosExcluidos.Contains(curso))? "InformePrimariaST.rpt" : "InformeSecundaria2C.rpt";
                            ReportDocument tempDoc = new ReportDocument();

                            if (string.IsNullOrEmpty(NomRep))
                            {
                                Response.Write("❌ ERROR: NomRep está vacío o nulo.");
                                return;
                            }

                            string ruta = Server.MapPath(string.Format("~/PaginasGenerales/Reportes/{0}", NomRep));
                            if (!File.Exists(ruta))
                            {
                                Response.Write("❌ ERROR: El archivo no existe en la ruta");
                                return;
                            }

                            tempDoc.Load(ruta);

                            // Parámetros del reporte     
                            tempDoc.SetParameterValue("@aluId", aluId);
                            tempDoc.SetParameterValue("@curso", curso);
                            tempDoc.SetParameterValue("@anio", anio);


                            // 🔒 Configurar conexión manual a la base de datos
                            //ConnectionInfo connectionInfo = new ConnectionInfo();
                            //connectionInfo.ServerName = "DESKTOP-DR5HH6H";
                            //connectionInfo.DatabaseName = "GESTIONESCOLAR";
                            //connectionInfo.UserID = "sa";
                            //connectionInfo.Password = "racing01";

                            ConnectionInfo connectionInfo = new ConnectionInfo();
                            connectionInfo.ServerName = "localhost";
                            connectionInfo.DatabaseName = "GestionEscolar";
                            connectionInfo.UserID = "sa";
                            connectionInfo.Password = "ms2014";

                            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tempDoc.Database.Tables)
                            {
                                TableLogOnInfo logOnInfo = table.LogOnInfo;
                                logOnInfo.ConnectionInfo = connectionInfo;
                                table.ApplyLogOnInfo(logOnInfo);
                            }

                            // Exportar a PDF
                            Stream pdfStream = tempDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                            pdfStreams.Add(pdfStream);

                            tempDoc.Close();
                            tempDoc.Dispose();
                        }
                    }

                    if (pdfStreams.Count > 0)
                    {
                        string combinedPath = Path.Combine(tempFolder, "InformeCombinado.pdf");
                        MergePDFs(pdfStreams, combinedPath);

                        // Guardás la ruta del archivo para abrirlo desde JavaScript
                        string relativePath = ResolveUrl("~/Temp/InformeCombinado.pdf");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenPDF", "window.open('" + relativePath + "', '_blank');", true);
                    }
                }
                else
                {
                    if (TipoInformeId.SelectedValue == "2" && PeriodoId.SelectedValue == "3")
                    {
                        string tempFolder = Server.MapPath("~/Temp/");
                        if (!Directory.Exists(tempFolder))
                            Directory.CreateDirectory(tempFolder);

                        List<Stream> pdfStreams = new List<Stream>();

                        foreach (GridViewRow row in Grilla.Rows)
                        {
                            CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                            if (check != null && check.Checked)
                            {
                                int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);
                                int curso = Convert.ToInt32(curId.SelectedValue.ToString());
                                int anio = Convert.ToInt32(AnioCursado.Text);
                                int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);

                                // Cursos excluidos
                                int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

                                // Asignar el nombre del reporte según condiciones
                                string NomRep = (tipoCarrera == 2 && !cursosExcluidos.Contains(curso)) ? "InformePrimariaTT.rpt" : "";
                                ReportDocument tempDoc = new ReportDocument();

                                if (string.IsNullOrEmpty(NomRep))
                                {
                                    Response.Write("❌ ERROR: NomRep está vacío o nulo.");
                                    return;
                                }

                                string ruta = Server.MapPath(string.Format("~/PaginasGenerales/Reportes/{0}", NomRep));
                                if (!File.Exists(ruta))
                                {
                                    Response.Write("❌ ERROR: El archivo no existe en la ruta");
                                    return;
                                }

                                tempDoc.Load(ruta);

                                // Parámetros del reporte     
                                tempDoc.SetParameterValue("@aluId", aluId);
                                tempDoc.SetParameterValue("@curso", curso);
                                tempDoc.SetParameterValue("@anio", anio);


                                 //🔒 Configurar conexión manual a la base de datos
                                //ConnectionInfo connectionInfo = new ConnectionInfo();
                                //connectionInfo.ServerName = "DESKTOP-DR5HH6H";
                                //connectionInfo.DatabaseName = "GESTIONESCOLAR";
                                //connectionInfo.UserID = "sa";
                                //connectionInfo.Password = "racing01";

                                ConnectionInfo connectionInfo = new ConnectionInfo();
                                connectionInfo.ServerName = "localhost";
                                connectionInfo.DatabaseName = "GestionEscolar";
                                connectionInfo.UserID = "sa";
                                connectionInfo.Password = "ms2014";

                                foreach (CrystalDecisions.CrystalReports.Engine.Table table in tempDoc.Database.Tables)
                                {
                                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                                    logOnInfo.ConnectionInfo = connectionInfo;
                                    table.ApplyLogOnInfo(logOnInfo);
                                }

                                // Exportar a PDF
                                Stream pdfStream = tempDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                                pdfStreams.Add(pdfStream);

                                tempDoc.Close();
                                tempDoc.Dispose();
                            }
                        }

                        if (pdfStreams.Count > 0)
                        {
                            string combinedPath = Path.Combine(tempFolder, "InformeCombinado.pdf");
                            MergePDFs(pdfStreams, combinedPath);

                            // Guardás la ruta del archivo para abrirlo desde JavaScript
                            string relativePath = ResolveUrl("~/Temp/InformeCombinado.pdf");
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenPDF", "window.open('" + relativePath + "', '_blank');", true);
                        }
                    }
                    else
                    {
                        if (TipoInformeId.SelectedValue == "1")
                        {
                            string tempFolder = Server.MapPath("~/Temp/");
                            if (!Directory.Exists(tempFolder))
                                Directory.CreateDirectory(tempFolder);

                            List<Stream> pdfStreams = new List<Stream>();

                            foreach (GridViewRow row in Grilla.Rows)
                            {
                                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                                if (check != null && check.Checked)
                                {
                                    int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);
                                    int curso = Convert.ToInt32(curId.SelectedValue.ToString());
                                    int anio = Convert.ToInt32(AnioCursado.Text);
                                    int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);

                                    // Cursos excluidos
                                    int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

                                    // Asignar el nombre del reporte según condiciones
                                    string NomRep = (tipoCarrera == 2 && !cursosExcluidos.Contains(curso)) ? "InformePortadaPrimaria.rpt" : "InformePortadaSecundaria.rpt";
                                    ReportDocument tempDoc = new ReportDocument();

                                    if (string.IsNullOrEmpty(NomRep))
                                    {
                                        Response.Write("❌ ERROR: NomRep está vacío o nulo.");
                                        return;
                                    }

                                    string ruta = Server.MapPath(string.Format("~/PaginasGenerales/Reportes/{0}", NomRep));
                                    if (!File.Exists(ruta))
                                    {
                                        Response.Write("❌ ERROR: El archivo no existe en la ruta");
                                        return;
                                    }

                                    tempDoc.Load(ruta);

                                    // Parámetros del reporte     
                                    tempDoc.SetParameterValue("@aluId", aluId);
                                    tempDoc.SetParameterValue("@curso", curso);
                                    tempDoc.SetParameterValue("@anio", anio);



                                    //ConnectionInfo connectionInfo = new ConnectionInfo();
                                    //connectionInfo.ServerName = "DESKTOP-DR5HH6H";
                                    //connectionInfo.DatabaseName = "GESTIONESCOLAR";
                                    //connectionInfo.UserID = "sa";
                                    //connectionInfo.Password = "racing01";

                                    ConnectionInfo connectionInfo = new ConnectionInfo();
                                    connectionInfo.ServerName = "localhost";
                                    connectionInfo.DatabaseName = "GestionEscolar";
                                    connectionInfo.UserID = "sa";
                                    connectionInfo.Password = "ms2014";

                                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in tempDoc.Database.Tables)
                                    {
                                        TableLogOnInfo logOnInfo = table.LogOnInfo;
                                        logOnInfo.ConnectionInfo = connectionInfo;
                                        table.ApplyLogOnInfo(logOnInfo);
                                    }

                                    // Exportar a PDF
                                    Stream pdfStream = tempDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                                    pdfStreams.Add(pdfStream);

                                    tempDoc.Close();
                                    tempDoc.Dispose();
                                }
                            }

                            if (pdfStreams.Count > 0)
                            {
                                string combinedPath = Path.Combine(tempFolder, "InformeCombinado.pdf");
                                MergePDFs(pdfStreams, combinedPath);

                                // Guardás la ruta del archivo para abrirlo desde JavaScript
                                string relativePath = ResolveUrl("~/Temp/InformeCombinado.pdf");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenPDF", "window.open('" + relativePath + "', '_blank');", true);
                            }
                        }
                    }
                }
            }
        }
    }

    //protected void BtnImprimir_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblMensajeError3.Text = "";
    //        int ban = 0;

            //        if (TipoInformeId.SelectedValue == "2" && PeriodoId.SelectedValue == "1") // Informe individual
            //        {
            //            ReportDocument reportDoc = new ReportDocument();
            //            ReportDocument tempDoc;

            //            string tempFolder = Server.MapPath("~/Temp/");
            //            string combinedPDFPath = Path.Combine(tempFolder, "InformeCombinado.pdf");

            //            if (!Directory.Exists(tempFolder))
            //                Directory.CreateDirectory(tempFolder);

            //            List<Stream> pdfStreams = new List<Stream>();

            //            foreach (GridViewRow row in Grilla.Rows)
            //            {
            //                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
            //                if (check != null && check.Checked)
            //                {
            //                    int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);       
            //                    int curso = Convert.ToInt32(curId.SelectedValue.ToString());
            //                    int anio = Convert.ToInt32(AnioCursado.Text);
            //                    int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);
            //                    //int ban = 1;

            //                    string NomRep = (tipoCarrera == 2) ? "LibretaPrimaria.rpt" : "InformeSecundariaC.rpt";
            //                    tempDoc = new ReportDocument();

            //                    tempDoc.Load(Server.MapPath(string.Format("~/PaginasGenerales/Reportes/{0}", NomRep)));


            //                    tempDoc.SetParameterValue("aluId", aluId);
            //                    tempDoc.SetParameterValue("curso", curso);
            //                    tempDoc.SetParameterValue("anio", anio);

            //                    Stream pdfStream = tempDoc.ExportToStream(ExportFormatType.PortableDocFormat);
            //                    pdfStreams.Add(pdfStream);

            //                    tempDoc.Close();
            //                    tempDoc.Dispose();
            //                }
            //            }

            //            if (ban == 0)
            //            {
            //                lblMensajeError3.Text = "Debe seleccionar al menos un Alumno..";
            //                return;
            //            }

            //            // Combinar PDFs
            //            MergePDFs(pdfStreams, combinedPdfPath);

            //            // Abrir una sola ventana
            //            string url = ResolveUrl("~/Temp/InformeCombinado.pdf");
            //            ScriptManager.RegisterStartupScript(this, GetType(), "OpenPDF", string.Format("window.open('{0}', '_blank');", url), true);

            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        lblMensajeError.Text = "<div class=\"alert alert-danger alert-dismissable\">" +
            //            "<button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>" +
            //            "<a class=\"alert-link\" href=\"#\">Error de Sistema</a><br/>" +
            //            "Se ha producido el siguiente error:<br/>" +
            //            "MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
            //            "</div>";
            //    }
            //}

    private void MergePDFs(List<Stream> pdfStreams, string outputPath)
    {
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            Document document = new Document();
            PdfCopy pdf = new PdfCopy(document, stream);
            document.Open();

            foreach (Stream ms in pdfStreams)
            {
                PdfReader reader = new PdfReader(ms);
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    pdf.AddPage(pdf.GetImportedPage(reader, i));
                }
                pdf.FreeReader(reader);
                reader.Close();
            }

            document.Close();
        }
    }


    //    protected void BtnImprimir_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            int ban = 0;
    //            lblMensajeError3.Text = "";
    //            if (TipoInformeId.SelectedValue == "2") // Si tipo Informe = Informe
    //            {
    //                if (PeriodoId.SelectedValue == "4") // Si periodo es Todos
    //                {
    //                    int delay = 0;

    //                    foreach (GridViewRow row in Grilla.Rows)
    //                    {
    //                        int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);
    //                        CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

    //                        if (check != null && check.Checked)
    //                        {
    //                            int curid = Convert.ToInt32(curId.SelectedValue.ToString());
    //                            int AnioCur = Convert.ToInt32(AnioCursado.Text);
    //                            int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);
    //                            ban = 1;

    //                            string NomRep = (tipoCarrera == 2) ? "LibretaPrimaria.rpt" : "InformSecundaria1C.rpt";
    //                            //string url = string.Format("Reporte.aspx?aluId={0}&curso={1}&anio={2}&NomRep={3}", aluId, curso, anio, NomRep);
    //                            //string script = string.Format("setTimeout(function() {{ window.open('{0}', '_blank'); }}, {1});", url, delay);
    //                            //ScriptManager.RegisterStartupScript(this, GetType(), "Ventana" + aluId, script, true);
    //                            delay += 500;
    //                        }
    //                    }

    //                    if (ban == 0)
    //                    {
    //                        lblMensajeError3.Text = "Debe seleccionar al menos un Alumno..";
    //                    }
    //                }

    //                if (PeriodoId.SelectedValue == "1") // Si periodo es 1 Informe
    //                {
    //                    int delay = 0;

    //                    foreach (GridViewRow row in Grilla.Rows)
    //                    {
    //                        int tipoCarrera = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["TipoCarrera"]);
    //                        CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

    //                        if (check != null && check.Checked)
    //                        {
    //                            int curso = Convert.ToInt32(curId.SelectedValue.ToString());
    //                            int anio = Convert.ToInt32(AnioCursado.Text);
    //                            int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);
    //                            ban = 1;

    //                            string NomRep = (tipoCarrera == 2) ? "InformePrimariaPT.rpt" : "InformeSecundaria1C.rpt";
    //                            string url = string.Format("Reporte.aspx?aluId={0}&curso={1}&anio={2}&NomRep={3}", aluId, curso, anio, NomRep);
    //                            string script = string.Format("setTimeout(function() {{ window.open('{0}', '_blank'); }}, {1});", url, delay);
    //                            ScriptManager.RegisterStartupScript(this, GetType(), "Ventana" + aluId, script, true);
    //                            delay += 500;
    //                        }
    //                    }

    //                    if (ban == 0)
    //                    {
    //                        lblMensajeError3.Text = "Debe seleccionar al menos un Alumno..";
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }
    //    }

    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "CursoListadoAlumnos" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["CursoListadoAlumnos.PageIndex"] = PageIndex;
            insId = Convert.ToInt32(Session["_Institucion"]);
            #region Variables de sesion para filtros

            #endregion

            Int32 car = 0;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                Session.Add("CursoListadoAlumnos.curId", cur);
            }


            if (AnioCursado.Text == "")
            {

                int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                DateTime fechaActual = DateTime.Today;
                AnioCur = Anio;

            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }

            dt = new DataTable();
            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);

            this.Grilla.DataSource = dt;
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                lblCurso.Text = dt.Rows[0]["Curso"].ToString();
                lblTC.Text = dt.Rows[0]["TipoCarrera"].ToString();
                PeriodoId.Visible = true;
                lblPeriodo.Visible = true;
                lblTipoInforme.Visible = true;
                TipoInformeId.Visible = true;

                lblCantReg.Visible = true;
                lblCantidadRegistros.Visible = true;
                //btnSeleccionar.Visible = true;
                //MovimientoId.Visible = true;
                //lblmovimiento.Visible = true;
                BtnImprimir.Visible = true;
                btnSeleccionarTodo.Visible = true;

            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
                //btnSeleccionar.Visible = false;
                PeriodoId.Visible = false;
                lblPeriodo.Visible = false;
                lblCantReg.Visible = false;
                lblCantidadRegistros.Visible = false;
                lblTipoInforme.Visible = false;
                TipoInformeId.Visible = false;
                BtnImprimir.Visible = false;
                btnSeleccionarTodo.Visible = false;
            }



        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == true)
                    {
                        check.Checked = false;

                    }
                }
                btnSeleccionarTodo.Text = "Seleccionar todo";
            }
            else
            {
                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == false)
                    {
                        check.Checked = true;

                    }
                }
                btnSeleccionarTodo.Text = "Desmarcar todo";
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void TipoInformeId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int curso = Convert.ToInt32(curId.SelectedValue.ToString());
            // Cursos excluidos para TC = 2 (no deben ver el periodo 3)
            int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

            if (Convert.ToInt32(TipoInformeId.SelectedValue) == 1)
            {
                PeriodoId.Enabled = false;
                BtnImprimir.Enabled = true;
            }
            else
            {
                string TC = lblTC.Text;

                if (Convert.ToInt32(TipoInformeId.SelectedValue) == 2)
                {
                    PeriodoId.Enabled = true;
                    BtnImprimir.Enabled = true;

                    if (TC == "2")
                    {
                        // Solo se habilita el periodo 3 si el curso NO está en la lista excluida
                        PeriodoId.Items.FindByValue("3").Enabled = !cursosExcluidos.Contains(curso);
                    }

                    if (TC == "3")
                    {
                        // Siempre se habilita el periodo 3 para TC = 3
                        PeriodoId.Items.FindByValue("3").Enabled = true;
                    }
                }
            }
        }

        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }

    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            //{
            //    string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
            //    if (AnioCursado.Text == "")
            //    {
            //        DateTime fechaActual = DateTime.Today;
            //        AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

            //    }
            //    else
            //    {
            //        AnioCur = Convert.ToInt32(AnioCursado.Text);
            //    }

            //    if (e.CommandName == "Eliminar")
            //    {
            //        //ocnCurso.Eliminar(Convert.ToInt32(Id));
            //        this.GrillaCargar(this.Grilla.PageIndex);
            //    }

            //    if (e.CommandName == "Copiar")
            //    {
            //        ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Convert.ToInt32(IC));
            //        //ocnCurso.Copiar();
            //        this.GrillaCargar(this.Grilla.PageIndex);
            //    }

            //    if (e.CommandName == "Ver")
            //    {
            //        String TC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;
            //        if (TC == "4")
            //        {
            //            Response.Redirect("RegistracionCalificacionesRegistracion.aspx?Id=" + IC + "&Ver=1", false);
            //        }
            //        else
            //        {
            //            if (TC == "3")
            //            {
            //                Response.Redirect("CargaCalificacionesPorAlumnoSec.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
            //            }
            //            else
            //            {
            //                if (TC == "2")
            //                {
            //                    Response.Redirect("CargaCalificacionesPorAlumnoPri.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#CCCCFF';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["CursoConsulta.PageIndex"] != null)
            {
                Session["CursoConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CursoConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex);
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    protected void lbuEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            ((LinkButton)sender).Visible = false;
            ((LinkButton)sender).Parent.Controls[3].Visible = true;
            ((LinkButton)sender).Parent.Controls[5].Visible = true;
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    protected void btnEliminarAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            ocnCurso.Eliminar(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(Grilla.PageIndex);
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        UpdatePanel1.Visible = false;
        btnAplicar.Visible = false;
        btnNuevo.Visible = true;
        lblMensajeError3.Text = "";
        GrillaCargar(Grilla.PageIndex);

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        UpdatePanel1.Visible = true;
        btnAplicar.Visible = true;
        plaId.SelectedValue = "0";
        carId.SelectedValue = "0";
        curId.SelectedValue = "0";
        AnioCursado.Text = "";
        btnNuevo.Visible = false;
        lblCurso.Text = "";
        lblMensajeError3.Text = "";
        TipoInformeId.SelectedValue = "0";
        PeriodoId.SelectedValue = "0";
        PeriodoId.Enabled = false;
        BtnImprimir.Enabled = false;
        GrillaCargar(Grilla.PageIndex);
    }

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
        {

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                plaId.DataBind();
            }
        }

    }


    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        plaIdCargar();
    }


    private void plaIdCargar()
    {
        if (plaId.SelectedIndex > 0)
        {

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                curId.DataValueField = "Valor";
                curId.DataTextField = "Texto";
                curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                curId.DataBind();
            }
        }
    }




    protected void PeriodoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnImprimir.Enabled = true;
    }
}