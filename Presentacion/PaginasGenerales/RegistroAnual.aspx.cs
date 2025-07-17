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


public partial class RegistroAnual : System.Web.UI.Page
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
                this.Master.TituloDelFormulario = " Registro Anual";
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaSoloPrimSec("[Seleccionar...]"); carId.DataBind();
                #region PageIndex
                int PageIndex = 0;
                if (this.Session["RegistroAnual.PageIndex"] == null)
                {
                    Session.Add("RegistroAnual.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["RegistroAnual.PageIndex"]);
                }
                #endregion
                Session["Bandera"] = 0;
                #region Variables de sesion para filtros
                //if (Session["CursoConsulta.Nombre"] != null) { Curso.Text = Session["CursoConsulta.Nombre"].ToString(); } else { Session.Add("CursoConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion

                //GrillaCargar(PageIndex);
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

  

    protected void btnAplicar_Click(object sender, EventArgs e)
    {

        //GrillaCargar(Grilla.PageIndex);
        //dt = new DataTable();

        //insId = Convert.ToInt32(Session["_Institucion"]);
        //String NomRep;

        //Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
        //Int32 anio = 0;
        //Int32 ParamInt1 = 0;
        //if (AnioCursado.Text.Trim().ToString() != "")
        //{
        //    anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
        //}

        //NomRep = "RegistroAnual.rpt";

        //FuncionesUtiles.AbreVentana("Reporte.aspx?curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
    }
    //    private void GrillaCargar(int PageIndex)
    //    {
    //        try
    //        {
    //            Session["RegistroAnual.PageIndex"] = PageIndex;
    //            insId = Convert.ToInt32(Session["_Institucion"]);
    //            #region Variables de sesion para filtros
    //            lblMensajeError3.Text = "";
    //            #endregion

    //            Int32 car = 0;
    //            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //            {
    //                car = Convert.ToInt32(carId.SelectedValue.ToString());

    //            }
    //            else
    //            {
    //                lblMensajeError3.Text = "Debe ingresar una Carrera"; return;
    //            }
    //            Int32 pla = 0;
    //            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
    //            {
    //                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
    //            }
    //            else
    //            {
    //                lblMensajeError3.Text = "Debe ingresar un plan"; return;
    //            }

    //            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
    //            {
    //                cur = Convert.ToInt32(curId.SelectedValue.ToString());
    //            }
    //            else
    //            {
    //                lblMensajeError3.Text = "Debe ingresar un Curso"; return;
    //            }


    //            if (AnioCursado.Text == "")
    //            {

    //                int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
    //                DateTime fechaActual = DateTime.Today;
    //                AnioCur = fechaActual.Year;

    //            }
    //            else
    //            {
    //                AnioCur = Convert.ToInt32(AnioCursado.Text);
    //            }
    //            UpdatePanel1.Visible = false;
    //            btnAplicar.Visible = false;
    //            BtnImprimir.Visible = false;
    //            btnSeleccionarTodo.Visible = false;
    //            btnNuevo.Visible = true;
    //            lblMensajeError3.Text = "";
    //            dt = new DataTable();
    //            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);



    //            if (dt.Rows.Count > 0)
    //            {
    //                this.Grilla.DataSource = dt;
    //                this.Grilla.PageIndex = PageIndex;
    //                this.Grilla.DataBind();
    //                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
    //                lblCurso.Text = dt.Rows[0]["Curso"].ToString();
    //                lblTC.Text = dt.Rows[0]["TipoCarrera"].ToString();


    //                lblCantReg.Visible = true;
    //                lblCantidadRegistros.Visible = true;
    //                //btnSeleccionar.Visible = true;
    //                //MovimientoId.Visible = true;
    //                //lblmovimiento.Visible = true;
    //                BtnImprimir.Visible = true;
    //                btnSeleccionarTodo.Visible = true;
    //                BtnImprimir.Enabled = true;
    //                btnSeleccionarTodo.Enabled = true;


    //            }
    //            else
    //            {
    //                this.Grilla.DataSource = dt;
    //                this.Grilla.PageIndex = PageIndex;
    //                this.Grilla.DataBind();
    //                lblCantidadRegistros.Text = "Cantidad de registros: 0";
    //                lblCantReg.Visible = false;
    //                lblCantidadRegistros.Visible = false;
    //                BtnImprimir.Visible = false;
    //                btnSeleccionarTodo.Visible = false;
    //                BtnImprimir.Enabled = false;
    //                //btnSeleccionarTodo.Enabled = false;
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

    //    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {

    //            if (btnSeleccionarTodo.Text == "Desmarcar todo")
    //            {
    //                foreach (GridViewRow row in Grilla.Rows)
    //                {
    //                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

    //                    if (check.Checked == true)
    //                    {
    //                        check.Checked = false;

    //                    }
    //                }
    //                btnSeleccionarTodo.Text = "Seleccionar todo";
    //            }
    //            else
    //            {
    //                foreach (GridViewRow row in Grilla.Rows)
    //                {
    //                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

    //                    if (check.Checked == false)
    //                    {
    //                        check.Checked = true;

    //                    }
    //                }
    //                btnSeleccionarTodo.Text = "Desmarcar todo";
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


    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        int ban = 0;
        lblMensajeError3.Text = "";

        string tempFolder = Server.MapPath("~/Temp/");
        if (!Directory.Exists(tempFolder))
            Directory.CreateDirectory(tempFolder);

        List<Stream> pdfStreams = new List<Stream>();

        if (CheckCurso.Checked == true)
        {
            Int32 car = 0;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                lblMensajeError3.Text = "Debe ingresar una Carrera"; return;
            }
            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                lblMensajeError3.Text = "Debe ingresar un plan"; return;
            }

            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                lblMensajeError3.Text = "Debe ingresar un Curso"; return;
            }


            if (AnioCursado.Text == "")
            {
                int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                DateTime fechaActual = DateTime.Today;
                AnioCur = fechaActual.Year;
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }

            int tipoCarrera = car;
            int curso =cur;
            int anio = Convert.ToInt32(AnioCur);
            //int aluId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]);

            // Cursos excluidos
            int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

            // Asignar el nombre del reporte según condiciones
            string NomRep = (tipoCarrera == 2 && !cursosExcluidos.Contains(curso))
                ? "InformeRegistroAnualPrimaria.rpt"
                : "InformeRegistroAnual.rpt";

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
            //tempDoc.SetParameterValue("@aluId", aluId);
            tempDoc.SetParameterValue("@curso", curso);
            tempDoc.SetParameterValue("@anio", anio);


            // 🔒 Configurar conexión manual a la base de datos
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "DESKTOP-DR5HH6H";
            connectionInfo.DatabaseName = "GESTIONESCOLAR";
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "racing01";

            //ConnectionInfo connectionInfo = new ConnectionInfo();
            //    connectionInfo.ServerName = "localhost";
            //    connectionInfo.DatabaseName = "GestionEscolar";
            //    connectionInfo.UserID = "sa";
            //    connectionInfo.Password = "ms2014";

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
            if (AnioCursado.Text == "")
            {
                int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                DateTime fechaActual = DateTime.Today;
                AnioCur = fechaActual.Year;
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }
            if (CheckAlumno.Checked == true)
            {
                int tipoCarrera = Convert.ToInt32(lblTipoCarrera.Text);
                int curso = Convert.ToInt32(lblCursoId.Text);
                int anio = AnioCur;
                int aluId = Convert.ToInt32(lblaluId.Text);

                // Cursos excluidos
                int[] cursosExcluidos = { 88, 89, 90, 91, 92, 132 };

                // Asignar el nombre del reporte según condiciones
                string NomRep = (tipoCarrera == 2 && !cursosExcluidos.Contains(curso))
                    ? "InformeRegistroAnualPrimariaxAlumno.rpt"
                    : "InformeRegistroAnualxAlumno.rpt";

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
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = "DESKTOP-DR5HH6H";
                connectionInfo.DatabaseName = "GESTIONESCOLAR";
                connectionInfo.UserID = "sa";
                connectionInfo.Password = "racing01";

                //ConnectionInfo connectionInfo = new ConnectionInfo();
                //    connectionInfo.ServerName = "localhost";
                //    connectionInfo.DatabaseName = "GestionEscolar";
                //    connectionInfo.UserID = "sa";
                //    connectionInfo.Password = "ms2014";

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
    

  

    protected void CheckAlumno_CheckedChanged(object sender, EventArgs e)
    {
        CheckCurso.Checked = false;
        miPanelCurso.Visible = false;
        miPanelAlumno.Visible = true;
    }
    protected void GrillaBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["RegistroAnual.PageIndex"] != null)
            {
                Session["RegistroAnual.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("RegistroAnual.PageIndex", e.NewPageIndex);
            }

            this.GrillaBuscarCargar(e.NewPageIndex);
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

    protected void GrillaBuscar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                String Id = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                if (e.CommandName == "Select")
                {

                    aluNombre.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    aluNombre.Enabled = false;
                    aludni.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    aludni.Enabled = false;
                    lblaluId.Text = Id;

                    pnelAlumnoSeleccionado.Visible = true;
                    Session["TextoBuscar"] = txtBusqueda.Text;

                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["RegistroAnual.PageIndex"]);
                    
                    if (anioCur.Text == "" || anioCur.Text == "0")
                    {
                        DateTime fecha = DateTime.Now;
                        AnioCur = fecha.Year;
                        anioCur.Text = Convert.ToString(AnioCur);
                    }
                    else
                    {
                        AnioCur = Convert.ToInt32(anioCur.Text);
                    }
                    DataTable dtCurso = new DataTable();
                    dtCurso = ocnInscripcionCursado.ObtenerUnoxDnixAnio(aludni.Text, AnioCur);
                    int TipoCarrera = 0;
                    int CursoI = 0;
                    if (dtCurso.Rows.Count > 0)
                    {
                        lblicuId.Text = dtCurso.Rows[0]["Id"].ToString();
                        txtCurso.Text = dtCurso.Rows[0]["Curso"].ToString();
                        TipoCarrera = Convert.ToInt32(dtCurso.Rows[0]["TipoCarrera"].ToString());
                        lblTipoCarrera.Text = Convert.ToString(TipoCarrera);
                        CursoI = Convert.ToInt32(dtCurso.Rows[0]["CursoId"].ToString());
                        lblCursoId.Text = Convert.ToString(CursoI);
                        txtCurso.Enabled = false;
                    }
                    else
                    {
                    }

                    List<int> cursosPermitidos = new List<int> { 89, 88, 90, 91, 92, 132 };
                    bool excepcionPermitida = (TipoCarrera == 2 && cursosPermitidos.Contains(CursoI));

                    //if (TipoCarrera != 3 && !excepcionPermitida)
                    //{
                    //    alerError.Visible = true;
                    //    lblError.Text = "Ud. solo puede acceder a la información del Nivel Secundario";
                        this.GrillaBuscar.DataSource = null;
                        this.GrillaBuscar.PageIndex = 0;
                        this.GrillaBuscar.DataBind();
                    //    panelCalif.Visible = false;
                    //    pnelAlumnoSeleccionado.Visible = false;
                    //    pnlAsignarNota.Visible = false;
                    //    this.GrillaNota.DataSource = null;
                    //    this.GrillaNota.PageIndex = PageIndex;
                    //    this.GrillaNota.DataBind();
                    //    this.GrillaPrevia.DataSource = null;
                    //    this.GrillaPrevia.PageIndex = PageIndex;
                    //    this.GrillaPrevia.DataBind();
                    //    lblCantidadPrevias.Text = "";
                    //    return;
                    //}
                    //else
                    //{
                    //    GrillaCargar(PageIndex);
                    //    GrillaBuscar.DataSource = null;
                    //    this.GrillaBuscar.PageIndex = 0;
                    //    GrillaBuscar.DataBind();
                    //}
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

    protected void GrillaBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    private void GrillaBuscarCargar(int PageIndex)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            alerError.Visible = false;
            alerExito.Visible = false;
            Session["RegistroAnual.PageIndex"] = PageIndex;

            if (anioCur.Text == "")
            {
                anioCur.Text = "0";
            }

            dt = new DataTable();

            if (rbNombre.Checked == true)
            {
                dt = ocnInscripcionCursado.ObtenerTodoporAlumnoxAnioxInst(txtBusqueda.Text.Trim(), Convert.ToInt32(anioCur.Text), insId);

                // Filtro específico para carId = 3
                //if (dt != null && dt.Columns.Contains("carId") && dt.Columns.Contains("curId"))
                //{
                //    string filtro = "(carId = 3) OR (carId = 2 AND curId IN (89, 88, 90, 91, 92, 132))";
                //    DataRow[] filasFiltradas = dt.Select(filtro);
                //    if (filasFiltradas.Length > 0)
                //    {
                //        dt = filasFiltradas.CopyToDataTable();
                //    }
                //    else
                //    {
                //        dt.Rows.Clear();
                //    }
                //}

                if (dt.Rows.Count > 0)
                {
                    this.GrillaBuscar.DataSource = dt;
                    this.GrillaBuscar.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();
                    Session["TextoBuscar"] = txtBusqueda.Text;
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra Alumno con esa descripción o DNI";
                    pnelAlumnoSeleccionado.Visible = false;
                    return;
                }
            }
            else
            {
                dt = ocnInscripcionCursado.ObtenerUnoxDnixAnioxInst(txtBusqueda.Text.Trim(), Convert.ToInt32(anioCur.Text), insId);

                // Filtro específico para carId = 3
                //if (dt != null && dt.Columns.Contains("carId") && dt.Columns.Contains("curId"))
                //{
                //    string filtro = "(carId = 3) OR (carId =2 AND curId IN (89, 88, 90, 91, 92, 132))";
                //    DataRow[] filasFiltradas = dt.Select(filtro);
                //    if (filasFiltradas.Length > 0)
                //    {
                //        dt = filasFiltradas.CopyToDataTable();
                //    }
                //    else
                //    {
                //        dt.Rows.Clear();
                //    }
                //}

                if (dt.Rows.Count > 0)
                {
                    this.GrillaBuscar.DataSource = dt;
                    this.GrillaBuscar.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra Alumno con esa descripción o DNI";
                    pnelAlumnoSeleccionado.Visible = false;
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

    protected void btnBuscarAlumnos_Click(object sender, EventArgs e)
    {
        GrillaBuscarCargar(GrillaBuscar.PageIndex);
    }

    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../PaginasBasicas/Inicio.aspx", true);
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

    protected void CheckCurso_CheckedChanged(object sender, EventArgs e)
    {
        CheckCurso.Checked = true;
        miPanelCurso.Visible = true;
        miPanelAlumno.Visible = false;
        CheckAlumno.Checked = false;
    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaBuscar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaBuscar, "Select$" + row.RowIndex, true);
            }
        }

        base.Render(writer);
    }



    protected void rbNombre_CheckedChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        alerExito.Visible = false;
        int ban = rbNombre.Checked ? 1 : 0;
        rbDni.Checked = false;
        Session["Bandera"] = ban;
        aludni.Text = "";
        aluNombre.Text = "";
        txtBusqueda.Text = "";
        pnelAlumnoSeleccionado.Visible = false;
        this.GrillaBuscar.DataSource = null;
     
        this.GrillaBuscar.DataBind();
    }

    protected void rbDni_CheckedChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        alerExito.Visible = false;
        rbNombre.Checked = false;
        aludni.Text = "";
        aluNombre.Text = "";
        txtBusqueda.Text = "";
        txtCurso.Text = "";
        pnelAlumnoSeleccionado.Visible = false;
        this.GrillaBuscar.DataSource = null;
    
        this.GrillaBuscar.DataBind();
    }

    protected void chkAplicarAnio_CheckedChanged(object sender, EventArgs e)
    {
        chkAplicarAnio.Checked = false;
        pnelAlumnoSeleccionado.Visible = false;
        this.GrillaBuscar.DataSource = null;
        this.GrillaBuscar.DataBind();
        GrillaBuscarCargar(GrillaBuscar.PageIndex);
    }
}