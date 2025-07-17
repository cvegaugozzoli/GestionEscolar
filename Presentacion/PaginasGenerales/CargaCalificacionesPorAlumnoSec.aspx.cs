using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

public partial class CargaCalificacionesPorAlumnoSec : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    int AnioCur;
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.RegistracionNotaPrevia ocnRegistracionNotaPrevia = new GESTIONESCOLAR.Negocio.RegistracionNotaPrevia();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();

    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();

    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["TextoBuscar"] = "";
                this.Master.TituloDelFormulario = " Calificaciones por Alumno";
                insId = Convert.ToInt32(Session["_Institucion"]);
                int IC = 0;
                if (Request.QueryString["icuId"] != null)
                {
                    if (Request.QueryString["icuId"] == "0")
                    {
                        miPanel.Visible = true;
                    }
                    else
                    {
                        miPanel.Visible = false;
                        IC = Convert.ToInt32(Request.QueryString["icuId"]);
                        ICtext.Text = Convert.ToString(IC);
                        DataTable dt = new DataTable();
                        dt = ocnInscripcionCursado.ObtenerUno(IC);
                        if (dt.Rows.Count > 0)
                        {
                            this.Master.TituloDelFormulario = dt.Rows[0]["Curso"].ToString() + " : " + "Calificaciones de " + dt.Rows[0]["Alumno"].ToString() +
                                " para el año " + dt.Rows[0]["AnoCursado"].ToString();
                            lblaluId.Text = Convert.ToString(dt.Rows[0]["aluId"].ToString());
                            Session.Add("aluId", dt.Rows[0]["aluId"].ToString());

                        }



                        String perfil = Session["_perId"].ToString();
                        if ((Session["_perId"].ToString() == "10") | (Session["_perId"].ToString() == "9")) // Si es familiar o Secretaria no muestro para modificar periodo
                        {

                        }

                        #region PageIndex
                        int PageIndex = 0;
                        if (this.Session["CargaCalificacionesPorAlumnoSec.PageIndex"] == null)
                        {
                            Session.Add("CargaCalificacionesPorAlumnoSec.PageIndex", 0);
                        }
                        else
                        {
                            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                        }
                        #endregion

                        #region Variables de sesion para filtros    

                        GrillaCargar(PageIndex);
                    }
                }
            }

            #endregion
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

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9") & (Session["_perId"].ToString() != "4")) // Si es distinto a familiar Secretaria o Prof hs puedo modificar
            {

                GrillaNota.EditIndex = e.NewEditIndex;
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                GrillaCargar(PageIndex);
                GrillaNota.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                GrillaNota.Columns[9].Visible = true;
                GrillaNota.Columns[10].Visible = true;
            }
            else
            {
                LblMensajeErrorGrilla.Text = "No puede modificar notas..";
                return;
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

    protected void OnRowEditing2(object sender, GridViewEditEventArgs e)
    {

        try
        {

            if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9") & (Session["_perId"].ToString() != "4")) // Si es distinto a familiar o Scretaria o prof hs puedo modificar
            {
                GrillaPrevia.EditIndex = e.NewEditIndex;
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                GrillaCargar(PageIndex);
                GrillaPrevia.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                GrillaPrevia.Columns[9].Visible = true;
                GrillaPrevia.Columns[10].Visible = false;
            }
            else
            {
                LblMensajeErrorGrilla.Text = "No puede modificar notas..";
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
    protected void OnCancel(object sender, EventArgs e)
    {
        try
        {
            ErrorIngreso.Visible = false;
            GrillaNota.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
            GrillaCargar(PageIndex);
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



    protected void OnCancel2(object sender, EventArgs e)
    {
        GrillaPrevia.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
        GrillaCargar(PageIndex);

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

        foreach (GridViewRow row in GrillaNota.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }

        foreach (GridViewRow row in GrillaPrevia.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        String perfil3 = Session["_perId"].ToString();
        if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar o Secretaria puedo modificar
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Edit$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }
    }


    protected void OnRowDataBound2(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrillaPrevia, "Edit$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);

            }
        }
    }



    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            ErrorIngreso.Visible = false;
            lblErrorIngreo.Text = "";

            if (!Session["_perId"].ToString().Equals("10") && !Session["_perId"].ToString().Equals("9"))
            {
                int IdIC = 0;
                int aluId = Convert.ToInt32(lblaluId.Text);

                if (string.IsNullOrEmpty(anioCur.Text))
                {
                    if (string.IsNullOrEmpty(Request.QueryString["Anio"]))
                    {
                        AnioCur = DateTime.Today.Year;
                    }
                    else
                    {
                        AnioCur = Convert.ToInt32(Request.QueryString["Anio"]);
                    }
                }
                else
                {
                    AnioCur = Convert.ToInt32(anioCur.Text);
                }

                IdIC = Convert.ToInt32(lblicuId.Text);

                // Obtener el valor de la Asignatura para la fila actual    
                GridViewRow row = GrillaNota.Rows[e.RowIndex];


                Label lblAsignatura = (Label)row.FindControl("lblAsignatura");
                string asignatura = lblAsignatura.Text.Trim().ToUpper();


                bool esInasistencia = asignatura == "INASISTENCIAS";


                int Id = Convert.ToInt32(GrillaNota.DataKeys[e.RowIndex].Values[0]);

                string[] errores = new string[0];

                string PCuat2 = ProcesarNota((TextBox)row.FindControl("txtPCuat"), "Primer Cuatrimestre", ref errores, esInasistencia);
                string SCuat2 = ProcesarNota((TextBox)row.FindControl("txtSCuat"), "Segundo Cuatrimestre", ref errores, esInasistencia);

                string PAnual2 = ProcesarNota((TextBox)row.FindControl("txtPAnual"), "Promedio Anual", ref errores, esInasistencia);
                string NotaDic2 = ProcesarNota((TextBox)row.FindControl("txtDiciembre"), "Diciembre", ref errores, esInasistencia);
                string NotaMar2 = ProcesarNota((TextBox)row.FindControl("txtMarzo"), "Marzo", ref errores, esInasistencia);
                string ExAdic2 = ProcesarNota((TextBox)row.FindControl("txtAdic"), "Ex. Adicional", ref errores, esInasistencia);


                string renCalfDef2 = ProcesarNota((TextBox)row.FindControl("txtrenCalfDef"), "Calificación Definitiva", ref errores, esInasistencia);

                if (errores.Length > 0)
                {
                    ErrorIngreso.Visible = true;
                    lblErrorIngreo.Text = string.Join("<br/>", errores);
                    return;
                }

                DateTime ahora = DateTime.Now;
                Int32 usuId = this.Master.usuId;

                ocnRegistracionNota.ActualizarSecundaria(Id, PCuat2, SCuat2, PAnual2, NotaDic2, NotaMar2, renCalfDef2, ahora, ahora, usuId, usuId);

                GrillaNota.EditIndex = -1;
                int PageIndex2 = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                GrillaNota.DataSource = dt5;
                GrillaNota.PageIndex = PageIndex2;
                GrillaNota.DataBind();
            }

            int PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
            GrillaCargar(PageIndex);
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = string.Format(
                @"<div class=""alert alert-danger alert-dismissable"">
                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                Se ha producido el siguiente error:<br/>
                MESSAGE:<br>{0}<br><br>EXCEPTION:<br>{1}<br><br>TRACE:<br>{2}<br><br>TARGET:<br>{3}
              </div>",
                oError.Message,
                oError.InnerException != null ? oError.InnerException.ToString() : "Sin detalles",
                oError.StackTrace,
                oError.TargetSite
            );
        }
    }
    private string ProcesarNota(TextBox txtNota, string nombreCampo, ref string[] errores, bool esInasistencia)
    {
        if (txtNota == null)
            return "";

        string texto = txtNota.Text.Trim().ToUpper();

        if (string.IsNullOrEmpty(texto))
        {
            // Si el campo está vacío o solo tiene espacios, se guarda como vacío sin error
            return " ";
        }

        if (esInasistencia)
        {
            // Para INASISTENCIAS, permitimos cualquier valor tal como está
            return texto;
        }

        int valor;
        if (int.TryParse(texto, out valor))
        {
            if (valor >= 1 && valor <= 10)
                return texto;
            else
                errores = errores.Concat(new[] { "Valor inválido en " + nombreCampo + " (1-10)" }).ToArray();
        }
        else
        {
            // Letras válidas: R, S, MB, B, I
            string[] validos = { "R", "S", "MB", "B", "I" };
            if (validos.Contains(texto))
            {
                return texto;
            }
            else
            {
                errores = errores.Concat(new[] { "Valor inválido en " + nombreCampo + " (solo R, S, MB, B o I)" }).ToArray();
            }
        }

        return "";
    }



    protected void OnRowUpdating2(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
            {
                GridViewRow row = GrillaPrevia.Rows[e.RowIndex];
                int Id = Convert.ToInt32(GrillaPrevia.DataKeys[e.RowIndex].Values[0]);
                DateTime? Fecha2;
                if (Convert.ToString(GrillaPrevia.DataKeys[e.RowIndex].Values[0]) != "")
                {
                    TextBox txtCalPrev = (TextBox)GrillaPrevia.Rows[e.RowIndex].FindControl("txtCalPrev");
                    TextBox txtFecha = (TextBox)GrillaPrevia.Rows[e.RowIndex].FindControl("txtFecha");

                    String txtCalPrev2 = Convert.ToString((txtCalPrev.Text == "" ? "" : txtCalPrev.Text));

                    if (txtFecha.Text == "")

                    {
                        LblMensajeErrorGrilla.Text = "Debe ingresar una fecha de examen";
                    }
                    else
                    {
                        Fecha2 = Convert.ToDateTime(txtFecha.Text);
                        ocnRegistracionNotaPrevia.Actualizar(Id, txtCalPrev2, Fecha2);
                        GrillaPrevia.EditIndex = -1;
                        int PageIndex = 0;
                        PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                        GrillaCargar(PageIndex);
                    }
                }
            }
            else
            {
                LblMensajeErrorGrilla.Text = "No puede modificar notas..";
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
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



    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                //int anio = Convert.ToInt32(((HyperLink)GridView2.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]).Text);
                //string Id = ((HyperLink)GridView2.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;


                if (e.CommandName == "New")
                {
                    int RegNota = Convert.ToInt32(GrillaPrevia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["RegNotaId"]);
                    //Inserto previa
                    //int RegNota = Convert.ToInt32(((HyperLink)GridView2.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]).Text);
                    string notaS = Convert.ToString(GrillaPrevia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Calificacion"]);
                    //int notaN = Convert.ToInt32(GridView2.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Calificacion"]);

                    if (notaS != "")
                    {
                        ocnRegistracionNotaPrevia.Insertar(RegNota);
                        int PageIndex = 0;
                        PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                        GrillaCargar(PageIndex);

                    }
                    else
                    {
                        LblMensajeErrorGrilla.Text = "El Registro debe tener una calificación para rendirla nuevamente..";
                    }

                }
                if (e.CommandName == "Eliminar")
                {
                    int Id = Convert.ToInt32(GrillaPrevia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"]);
                    ocnRegistracionNotaPrevia.Eliminar(Id);
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                    GrillaCargar(PageIndex);
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

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }
    protected void ButtonAsignar_Click(object sender, EventArgs e)
    {
        try
        {
            ErrorIngreso.Visible = false;
            //int anioCur;
            if (anioCur.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

            }
            else
            {
                AnioCur = Convert.ToInt32(anioCur.Text);
            }

            if (string.IsNullOrEmpty(TextNotaAsignar.Text))
            {
                ErrorIngreso.Visible = true;
                lblErrorIngreo.Text = "Asigne una nota..";
                //LblMensajeErrorGrilla.Text = "Asigne una nota..";
                TextNotaAsignar.Focus();
                return;
            }

            if (PeriodoId2.SelectedValue == "0")
            {
                ErrorIngreso.Visible = true;
                lblErrorIngreo.Text = "Seleccione un Periodo..";
                //LblMensajeErrorGrilla.Text = "Seleccione un Periodo..";
                PeriodoId2.Focus();
                return;
            }

            string notaAAsignar = TextNotaAsignar.Text.Trim();
            string[] errores = new string[0];

            if (GrillaNota.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrillaNota.Rows)
                {
                    Label lblAsignatura = (Label)row.FindControl("lblAsignatura");
                    string asignatura = lblAsignatura.Text.Trim().ToUpper();

                    // Evitar el procesamiento si la asignatura es "INASISTENCIAS"
                    if (asignatura == "INASISTENCIAS")
                    {
                        continue; // Saltar a la siguiente iteración del bucle
                    }


                    var lblFDictado = row.FindControl("lblFDictadoId") as Label;
                    var lblId = row.FindControl("Id") as Label;
                    bool esInasistencia = asignatura == "INASISTENCIAS"; // Esto ahora siempre será falso aquí

                    string notaProcesada = ProcesarNota(TextNotaAsignar, "Nota a Asignar", ref errores, esInasistencia);

                    if (errores.Length > 0)
                    {
                        ErrorIngreso.Visible = true;
                        lblErrorIngreo.Text = string.Join("<br/>", errores);
                        //LblMensajeErrorGrilla.Text = 
                        return;
                    }

                    if (lblFDictado != null && lblId != null)
                    {
                        int fDictadoValue;
                        int renId;

                        if (int.TryParse(lblFDictado.Text, out fDictadoValue) && int.TryParse(lblId.Text, out renId))
                        {
                            if (fDictadoValue != 5) // Suponiendo que 5 es un valor que indica algo que no debe modificarse
                            {
                                switch (PeriodoId2.SelectedValue)
                                {
                                    case "1":
                                        ocnRegistracionNota.AsignarNotaSecPC(renId, notaProcesada);
                                        break;
                                    case "2":
                                        ocnRegistracionNota.AsignarNotaSecSC(renId, notaProcesada);
                                        break;
                                    case "4":
                                        ocnRegistracionNota.AsignarNotaPromA(renId, notaProcesada);
                                        break;
                                    case "5":
                                        ocnRegistracionNota.AsignarNotaDic(renId, notaProcesada);
                                        break;
                                    case "6":
                                        ocnRegistracionNota.AsignarNotaMar(renId, notaProcesada);
                                        break;
                                    case "7":
                                        ocnRegistracionNota.AsignarNotaCalDef(renId, notaProcesada);
                                        break;
                                    case "8":
                                        ocnRegistracionNota.AsignarNotaExamenAdic(renId, notaProcesada);
                                        break;
                                    default:
                                        ErrorIngreso.Visible = true;
                                        lblErrorIngreo.Text = "Periodo no válido para la asignación.";
                                        //LblMensajeErrorGrilla.Text = "Periodo no válido para la asignación.";
                                        return;
                                }
                            }
                        }
                        else
                        {
                            ErrorIngreso.Visible = true;
                            lblErrorIngreo.Text = "Error al obtener los IDs de la grilla.";
                            //LblMensajeErrorGrilla.Text = "Error al obtener los IDs de la grilla.";
                            return;
                        }
                    }
                    else
                    {
                        ErrorIngreso.Visible = true;
                        lblErrorIngreo.Text = "Error al encontrar controles en la grilla.";
                        //LblMensajeErrorGrilla.Text = "Error al encontrar controles en la grilla.";
                        return;
                    }
                }

                GrillaNota.EditIndex = -1;
                int pageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumno.PageIndex"]);
                GrillaCargar(pageIndex);
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "<div class=\"alert alert-danger alert-dismissable\">" +
                                   "<button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>" +
                                   "<a class=\"alert-link\" href=\"#\">Error de Sistema</a><br/>" +
                                   "Se ha producido el siguiente error:<br/>" +
                                   "MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
                                   "</div>";
        }
    }
    protected void btnBuscarAlumnos_Click(object sender, EventArgs e)
    {
        //dt = new DataTable();
        //this.Grilla.DataSource = dt;
        //this.Grilla.DataBind();
        GrillaBuscarCargar(GrillaBuscar.PageIndex);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerExito.Visible = false;
            ErrorIngreso.Visible = false;
            alerError.Visible = false;
            Session["CargaCalificacionesPorAlumnoSec.PageIndex"] = PageIndex;
            insId = Convert.ToInt32(Session["_Institucion"]);
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion

            if (lblaluId.Text != "")
            {
                int aluId = Convert.ToInt32(lblaluId.Text);
                int IdIC = 0;
                LblMensajeErrorGrilla.Text = "";

                if (anioCur.Text == "")
                {
                    if (Request.QueryString["Anio"] == "0")
                    {
                        DateTime fechaActual = DateTime.Today;
                        AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                        anioCur.Text = fechaActual.Year.ToString();

                    }
                    else
                    {
                        AnioCur = Convert.ToInt32(Request.QueryString["Anio"]);
                    }

                    DataTable dtInscCur = new DataTable();
                    dtInscCur = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCur, aluId);

                    if (dtInscCur.Rows.Count > 0)
                    {
                        IdIC = Convert.ToInt32(dtInscCur.Rows[0]["Id"].ToString());
                        lblicuId.Text = Convert.ToString(IdIC);
                    }
                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "No existen registros para ese año";
                        pnlAsignarNota.Visible = false;

                        panelCalif.Visible = false;
                        pnelAlumnoSeleccionado.Visible = false;
                        pnlAsignarNota.Visible = false;

                        this.GrillaNota.DataSource = null;
                        this.GrillaNota.PageIndex = PageIndex;
                        this.GrillaNota.DataBind();
                        this.GrillaPrevia.DataSource = null;
                        this.GrillaPrevia.PageIndex = PageIndex;
                        this.GrillaPrevia.DataBind();
                        lblCantidadPrevias.Text = "";
                        return;
                    }
                }
                else
                {
                    AnioCur = Convert.ToInt32(anioCur.Text);

                    dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCur, aluId);
                    if (dt3.Rows.Count != 0)
                    {
                        IdIC = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    }
                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "No existen registros para ese año";
                        panelCalif.Visible = false;
                        pnelAlumnoSeleccionado.Visible = false;
                        pnlAsignarNota.Visible = false;
                        //PeriodoId.Visible = false;
                        this.GrillaNota.DataSource = null;
                        this.GrillaNota.PageIndex = PageIndex;
                        this.GrillaNota.DataBind();
                        this.GrillaPrevia.DataSource = null;
                        this.GrillaPrevia.PageIndex = PageIndex;
                        this.GrillaPrevia.DataBind();
                        lblCantidadPrevias.Text = "";
                        return;
                    }
                }

                if (Request.QueryString["icuId"] != null)
                {
                    dt = new DataTable();
                    dt = ocnRegistracionNota.ObtenerTodoporInscripcionCursadoAnio(IdIC, AnioCur);

                    if (dt.Rows.Count > 0)
                    {
                        panelCalif.Visible = true;
                        pnlAsignarNota.Visible = true;
                        //PeriodoId.Visible = true;
                        btnImprimir.Visible = true;
                        this.GrillaNota.DataSource = dt;
                        this.GrillaNota.PageIndex = PageIndex;
                        this.GrillaNota.DataBind();
                        if ((Session["_perId"].ToString() == "10") | (Session["_perId"].ToString() == "9") | (Session["_perId"].ToString() == "4")) // Si es igual a familiar oculto edicion
                        {
                            GrillaNota.Columns[8].Visible = false;
                            GrillaNota.Columns[9].Visible = false;
                        }
                        dt4 = ocnRegistracionNotaPrevia.ObtenerSoloPrevias(aluId);

                        this.GrillaPrevia.DataSource = dt4;
                        this.GrillaPrevia.PageIndex = PageIndex;
                        this.GrillaPrevia.DataBind();
                        GrillaPrevia.Columns[10].Visible = true;
                        GrillaPrevia.Columns[11].Visible = true;
                        if ((Session["_perId"].ToString() == "10") | (Session["_perId"].ToString() == "9") | (Session["_perId"].ToString() == "4")) // Si es igual a familiar no modifico
                        {
                            GrillaPrevia.Columns[8].Visible = false;
                            GrillaPrevia.Columns[9].Visible = false;
                            GrillaPrevia.Columns[10].Visible = false;
                            GrillaPrevia.Columns[11].Visible = false;
                        }
                    }
                    else
                    {
                        pnlAsignarNota.Visible = false;
                        //PeriodoId.Visible = false;
                        panelCalif.Visible = false;
                        btnImprimir.Visible = false;
                    }

                    //lblCantidadPrevias.Text = "   " + dt4.Rows.Count.ToString();
                    //BtnMostrar.Visible = true;

                    //if (dt4.Rows.Count == 0)
                    //{

                    //    lblCantidadPrevias.Text = "No Tiene";

                    //}

                    //BtnMostrar.Enabled = true;
                }
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe seleccionar un alumno..";
                return;
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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
            GrillaCargar(PageIndex);
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

    protected void BtnMostrar_Click(object sender, EventArgs e)
    {
        try
        {
            int aluId = Convert.ToInt32(Session["aluId"]);
            dt4 = ocnRegistracionNotaPrevia.ObtenerTodoxaluId(aluId);
            int PageIndex = 0;
            if (dt4.Rows.Count > 0)
            {
                this.GrillaPrevia.DataSource = dt4;
                Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                this.GrillaPrevia.PageIndex = PageIndex;
                this.GrillaPrevia.DataBind();

                GrillaPrevia.Columns[10].Visible = false;
                GrillaPrevia.Columns[9].Visible = false;

                //BtnSoloPrevias.Visible = true;
                //BtnMostrar.Enabled = false;

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

    protected void PeriodoId_SelectedIndexChanged2(object sender, EventArgs e)
    {
        pnlAsignarNota.Visible = false;
        lblMsjeErrorAsignar.Text = "";
        //btnGuardar.Visible = true;
        int periodoSeleccionado = Convert.ToInt32(PeriodoId2.SelectedValue);
        ViewState["PeriodoSeleccionado"] = periodoSeleccionado;
        //btnGuardar.Visible = true;
        this.GrillaNota.DataSource = null;
        this.GrillaNota.DataBind();
        int PageIndex = 0;

        GrillaBuscar.DataSource = null;
        this.GrillaBuscar.PageIndex = 0;
        GrillaBuscar.DataBind();
        GrillaCargar(PageIndex);
        //btnGuardar1.Visible = false;
        //btnGuardar.Visible = false;
        //alerMje.Visible = false;
        btnImprimir.Visible = false;
    }

    private int rowIndex = 0;

    protected void GrillaNota_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                rowIndex++;
                Label lblOrden = (Label)e.Row.FindControl("lblOrden");
                if (lblOrden != null)
                {
                    lblOrden.Text = rowIndex.ToString();
                }
            }
            int periodoSeleccionado;
            if (int.TryParse(PeriodoId2.SelectedValue, out periodoSeleccionado))
            {
                // Manejo de habilitación de campos
                TextBox txtPCuat = (TextBox)e.Row.FindControl("txtPCuat");
                TextBox txtSCuat = (TextBox)e.Row.FindControl("txtSCuat");

                TextBox txtPAnual = (TextBox)e.Row.FindControl("txtPAnual");
                TextBox txtDiciembre = (TextBox)e.Row.FindControl("txtDiciembre");
                TextBox txtMarzo = (TextBox)e.Row.FindControl("txtMarzo");
 TextBox txtAdic = (TextBox)e.Row.FindControl("txtAdic");

                TextBox txtrenCalfDef = (TextBox)e.Row.FindControl("txtrenCalfDef");

                if (txtPCuat != null)
                    txtPCuat.Enabled = (periodoSeleccionado == 1);

                if (txtSCuat != null)
                    txtSCuat.Enabled = (periodoSeleccionado == 2);

                if (txtPAnual != null)
                    txtPAnual.Enabled = (periodoSeleccionado == 4);

                if (txtDiciembre != null)
                    txtDiciembre.Enabled = (periodoSeleccionado == 5);

                if (txtMarzo != null)
                    txtMarzo.Enabled = (periodoSeleccionado == 6);

                if (txtrenCalfDef != null)
                    txtrenCalfDef.Enabled = (periodoSeleccionado == 7);

                if (txtAdic != null)
                    txtAdic.Enabled = (periodoSeleccionado == 8);
            }


        }
    }

    protected void BtnMostrarPrevias_Click(object sender, EventArgs e)
    {
        try
        {
            int aluId = Convert.ToInt32(Session["aluId"]);
            dt4 = ocnRegistracionNotaPrevia.ObtenerSoloPrevias(aluId);
            int PageIndex = 0;
            if (dt4.Rows.Count > 0)
            {
                this.GrillaPrevia.DataSource = dt4;

                Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                this.GrillaPrevia.PageIndex = PageIndex;
                this.GrillaPrevia.DataBind();
                if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
                {   //GridView2.Columns[10].Visible = true;
                    GrillaPrevia.Columns[9].Visible = true;
                    //BtnSoloPrevias.Visible = false;
                    //BtnMostrar.Enabled = true;
                }
            }
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
            GrillaCargar(PageIndex);
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

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        alerExito.Visible = false;
        int ban = rbDni.Checked ? 1 : 0;

        Session["Bandera"] = ban;
        aludni.Text = "";
        aluNombre.Text = "";
        txtBusqueda.Text = "";
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


    protected void txtAnioLectivo_TextChanged(object sender, EventArgs e)
    {
        int Id;
        //lblMjerror2.Text = "";
        int PageIndex = 0;
        if (anioCur.Text != "")
        {

            if (lblaluId.Text == "0")
            {
                lblMjerror2.Text = "Debe buscar y seleccionar un alumno";
                return;

            }
            else
            {

                Id = Convert.ToInt32(lblaluId.Text);

                PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
                GrillaCargar(PageIndex);
                GrillaBuscar.DataSource = null;
                GrillaBuscar.DataBind();
            }
        }

        else
        {
            Id = Convert.ToInt32(lblaluId.Text);
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
            GrillaCargar(PageIndex);
            GrillaBuscar.DataSource = null;
            GrillaBuscar.DataBind();
        }
    }

    protected void GrillaBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["CargaCalificacionesPorAlumnoSec.PageIndex"] != null)
            {
                Session["CargaCalificacionesPorAlumnoSec.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CargaCalificacionesPorAlumnoSec.PageIndex", e.NewPageIndex);
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
                    PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);


                    if (Request.QueryString["Anio"] == "0")
                    {
                        if (anioCur.Text == "" || anioCur.Text == "0")
                        {
                            AnioCur = Convert.ToInt32(((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Controls[1]).Text);
                        }
                        else
                        {
                            AnioCur = Convert.ToInt32(anioCur.Text);
                        }
                    }
                    else
                    {
                        AnioCur = Convert.ToInt32(Request.QueryString["Anio"]);
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
                        CursoI = Convert.ToInt32(dtCurso.Rows[0]["CursoId"].ToString());
                        txtCurso.Enabled = false;
                    }
                    else
                    {
                    }

                    List<int> cursosPermitidos = new List<int> { 89, 88, 90, 91, 92, 132 };
                    bool excepcionPermitida = (TipoCarrera == 2 && cursosPermitidos.Contains(CursoI));

                    if (TipoCarrera != 3 && !excepcionPermitida)
                    {
                        alerError.Visible = true;
                        lblError.Text = "Ud. solo puede acceder a la información del Nivel Secundario";
                        this.GrillaBuscar.DataSource = null;
                        this.GrillaBuscar.PageIndex = 0;
                        this.GrillaBuscar.DataBind();
                        panelCalif.Visible = false;
                        pnelAlumnoSeleccionado.Visible = false;
                        pnlAsignarNota.Visible = false;
                        this.GrillaNota.DataSource = null;
                        this.GrillaNota.PageIndex = PageIndex;
                        this.GrillaNota.DataBind();
                        this.GrillaPrevia.DataSource = null;
                        this.GrillaPrevia.PageIndex = PageIndex;
                        this.GrillaPrevia.DataBind();
                        lblCantidadPrevias.Text = "";
                        return;
                    }
                    else
                    {
                        GrillaCargar(PageIndex);
                        GrillaBuscar.DataSource = null;
                        this.GrillaBuscar.PageIndex = 0;
                        GrillaBuscar.DataBind();
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
            Session["CargaCalificacionesPorAlumnoSec.PageIndex"] = PageIndex;

            if (anioCur.Text == "")
            {
                anioCur.Text = "0";
            }

            dt = new DataTable();

            if (rbNombre.Checked==true)
            {
                dt = ocnInscripcionCursado.ObtenerTodoporAlumnoxAnioxInst(txtBusqueda.Text.Trim(), Convert.ToInt32(anioCur.Text), insId);

                // Filtro específico para carId = 3
                if (dt != null && dt.Columns.Contains("carId") && dt.Columns.Contains("curId"))
                {
                    string filtro = "(carId = 3) OR (carId = 2 AND curId IN (89, 88, 90, 91, 92, 132))";
                    DataRow[] filasFiltradas = dt.Select(filtro);
                    if (filasFiltradas.Length > 0)
                    {
                        dt = filasFiltradas.CopyToDataTable();
                    }
                    else
                    {
                        dt.Rows.Clear();
                    }
                }

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
                if (dt != null && dt.Columns.Contains("carId") && dt.Columns.Contains("curId"))
                {
                    string filtro = "(carId = 3) OR (carId = 2 AND curId IN (89, 88, 90, 91, 92, 132))";
                    DataRow[] filasFiltradas = dt.Select(filtro);
                    if (filasFiltradas.Length > 0)
                    {
                        dt = filasFiltradas.CopyToDataTable();
                    }
                    else
                    {
                        dt.Rows.Clear();
                    }
                }

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

    private void MostrarErrorEnGrilla(GridViewRow row, string mensajeError)
    {
        Label lblError = (Label)row.FindControl("lblErrorNota");
        if (lblError != null)
        {
            lblError.Text = mensajeError;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ErrorIngreso.Visible = false;
        lblErrorIngreo.Text = "";

        if (!Session["_perId"].ToString().Equals("10") && !Session["_perId"].ToString().Equals("9"))
        {
            int IdIC = 0;
            int aluId = Convert.ToInt32(lblaluId.Text);

            if (string.IsNullOrEmpty(anioCur.Text))
            {
                if (string.IsNullOrEmpty(Request.QueryString["Anio"]))
                {
                    AnioCur = DateTime.Today.Year;
                }
                else
                {
                    AnioCur = Convert.ToInt32(Request.QueryString["Anio"]);
                }
            }
            else
            {
                AnioCur = Convert.ToInt32(anioCur.Text);
            }

            IdIC = Convert.ToInt32(lblicuId.Text);

            bool hayErrorGeneral = false;
            string mensajeErrorGeneral = "";

            foreach (GridViewRow row in GrillaNota.Rows)
            {
                Label lblId = (Label)row.FindControl("Id");
                int RenId = Convert.ToInt32(lblId.Text);

                Label lblAsignatura = (Label)row.FindControl("lblAsignatura");
                string asignatura = lblAsignatura != null ? lblAsignatura.Text.Trim().ToUpper() : "";
                bool esInasistencia = asignatura == "INASISTENCIAS";
                string[] errores = new string[0];
                string notaProcesada;

                TextBox txtPCuat = (TextBox)row.FindControl("txtPCuat");
                if (txtPCuat != null && txtPCuat.Enabled)
                {
                    notaProcesada = ProcesarNota(txtPCuat, "1 Cuatrimestre", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaSecPC(RenId, notaProcesada);
                }

                TextBox txtSCuat = (TextBox)row.FindControl("txtSCuat");
                if (txtSCuat != null && txtSCuat.Enabled)
                {
                    errores = new string[0];
                    notaProcesada = ProcesarNota(txtSCuat, "2 Trimestre", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaSecSC(RenId, notaProcesada);
                }

                TextBox txtPAnual = (TextBox)row.FindControl("txtPAnual");
                if (txtPAnual != null && txtPAnual.Enabled)
                {
                    errores = new string[0];
                    notaProcesada = ProcesarNota(txtPAnual, "Eval. Final", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaPromA(RenId, notaProcesada);
                }

                TextBox txtDiciembre = (TextBox)row.FindControl("txtDiciembre");
                if (txtDiciembre != null && txtDiciembre.Enabled)
                {
                    errores = new string[0];
                    notaProcesada = ProcesarNota(txtDiciembre, "Diciembre", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaDic(RenId, notaProcesada);
                }

                TextBox txtMarzo = (TextBox)row.FindControl("txtMarzo");
                if (txtMarzo != null && txtMarzo.Enabled)
                {
                    errores = new string[0];
                    notaProcesada = ProcesarNota(txtMarzo, "Marzo", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaMar(RenId, notaProcesada);
                }

                TextBox txtAdic = (TextBox)row.FindControl("txtAdic");
                if (txtAdic != null && txtAdic.Enabled)
                {
                    errores = new string[0];
                    notaProcesada = ProcesarNota(txtAdic, "Ex. Adicional", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaExamenAdic(RenId, notaProcesada);
                }
                TextBox txtrenCalfDef = (TextBox)row.FindControl("txtrenCalfDef");
                if (txtrenCalfDef != null && txtrenCalfDef.Enabled)
                {
                    errores = new string[0];
                    notaProcesada = ProcesarNota(txtrenCalfDef, "Eval. Definitiva", ref errores, esInasistencia);
                    if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaCalDef(RenId, notaProcesada);
                }

                if (hayErrorGeneral) // Si hubo un error en alguna nota, detener el proceso
                {
                    break;
                }
            }
            if (hayErrorGeneral)
            {
                ErrorIngreso.Visible = true;
                lblErrorIngreo.Text = "Se encontraron errores en algunas notas. Valores del 1 al 1o o Letra S MB B R o I";
            }
            else
            {
                alerExito.Visible = true;
                lblExito.Text = "Las notas fueron guardadas con éxito..";
                PeriodoId2.SelectedValue = "0";
                Int32 PageIndex = Convert.ToInt32(Session["CargaCalifxEspCPri.PageIndex"]);
                GrillaCargar(PageIndex);
            }
        }
    }

    protected void ckAnnioCambiar_CheckedChanged(object sender, EventArgs e)
    {
        #region PageIndex
        int PageIndex = 0;
        if (this.Session["CargaCalificacionesPorAlumnoSec.PageIndex"] == null)
        {
            Session.Add("CargaCalificacionesPorAlumnoSec.PageIndex", 0);
        }
        else
        {
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
        }
        #endregion



        GrillaCargar(PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        #region PageIndex
        int PageIndex = 0;
        if (this.Session["CargaCalificacionesPorAlumnoSec.PageIndex"] == null)
        {
            Session.Add("CargaCalificacionesPorAlumnoSec.PageIndex", 0);
        }
        else
        {
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
        }
        #endregion
        GrillaCargar(PageIndex);
    }

   

   

    protected void chkAplicarAnio_CheckedChanged1(object sender, EventArgs e)
    {
        #region PageIndex
        int PageIndex = 0;
        if (this.Session["CargaCalificacionesPorAlumnoSec.PageIndex"] == null)
        {
            Session.Add("CargaCalificacionesPorAlumnoSec.PageIndex", 0);
        }
        else
        {
            PageIndex = Convert.ToInt32(Session["CargaCalificacionesPorAlumnoSec.PageIndex"]);
        }
        #endregion
        chkAplicarAnio.Checked = false;
        pnelAlumnoSeleccionado.Visible = false;
        this.GrillaBuscar.DataSource = null;
        this.GrillaBuscar.DataBind();
        GrillaCargar(PageIndex);

    }

    protected void rbDni_CheckedChanged1(object sender, EventArgs e)
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
        this.GrillaBuscar.PageIndex = 0;
        this.GrillaBuscar.DataBind();
        panelCalif.Visible = false;
        pnelAlumnoSeleccionado.Visible = false;
        pnlAsignarNota.Visible = false;
        this.GrillaNota.DataSource = null;      
        this.GrillaNota.DataBind();
        this.GrillaPrevia.DataSource = null;    
        this.GrillaPrevia.DataBind();
        lblCantidadPrevias.Text = "";
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
        this.GrillaBuscar.PageIndex = 0;
        this.GrillaBuscar.DataBind();
        panelCalif.Visible = false;
        pnelAlumnoSeleccionado.Visible = false;
        pnlAsignarNota.Visible = false;
        this.GrillaNota.DataSource = null;      
        this.GrillaNota.DataBind();
        this.GrillaPrevia.DataSource = null;    
        this.GrillaPrevia.DataBind();
        lblCantidadPrevias.Text = "";
    }
}

