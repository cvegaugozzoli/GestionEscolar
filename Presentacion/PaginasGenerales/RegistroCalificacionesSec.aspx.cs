using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;

public partial class RegistroCalificacionesSec : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.RegistracionNotaPrevia ocnRegistracionNotaPrevia = new GESTIONESCOLAR.Negocio.RegistracionNotaPrevia();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());

                alerMje.Visible = false;
                this.Master.TituloDelFormulario = "Registro Calificaciones";
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9"))  // Si es administrador o Director veo todos los cursos
                {
                    carId.Enabled = true;
                    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Primario"));
                    carId.Enabled = false;

                    plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                    curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();

                }

                else
                {
                    if ((Session["_perId"].ToString() == "2") || (Session["_perId"].ToString() == "25"))// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Primario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudioporAlumno("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 0); curId.DataBind();

                    }

                    if ((Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "4")) // Si es Preceptora o Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudioporAlumno("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 1); curId.DataBind();
                    }


                    //if (Session["_perId"].ToString() == "11")   // Si es Docente Area Especia
                    //{
                    //    carId.Enabled = true;
                    //    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //}                   


                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["RegistroCalificaciones.PageIndex"] == null)
                {
                    Session.Add("RegistroCalificaciones.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["RegistroCalificaciones.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion
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
        //foreach (GridViewRow row in GrillaNota.Rows)
        //{
        //    if (row.RowType == DataControlRowType.DataRow)
        //    {
        //        row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
        //        row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
        //    }
        //}
        //if (GrillaNota.Rows.Count > 0)
        //{
        //    btnGuardar.Visible = true;
        //    btnGuardar1.Visible = true;
        //    alerMje.Visible = true;
        //    ButtonImprimir.Visible = true;
        //}
        //else
        //{
        //    btnGuardar.Visible = false;
        //    btnGuardar1.Visible = false;
        //    alerMje.Visible = false;
        //    ButtonImprimir.Visible = false;

        //}

        base.Render(writer);
    }


    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "CargaCalifxEspCPri" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }
    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerExito.Visible = false;
            alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 espc = 0;
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
                alerError.Visible = true;
                lblError.Text = "Debe seleccionar un Curso..";
            }


            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }
            if (PeriodoId.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe seleccionar un Periodo..";
                return;
            }


            int curso = cur;
            int anio = AnioCur;
            insId = Convert.ToInt32(Session["_Institucion"]);
            DataTable dt = new DataTable();
            if (PeriodoId.SelectedValue == "1")
            {
                dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 1);
            }
            else
            {
                if (PeriodoId.SelectedValue == "2")
                {
                    dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 2);
                }
                else
                {
                    if (PeriodoId.SelectedValue == "3")
                    {
                        dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 3);
                    }
                    else
                    {
                        if (PeriodoId.SelectedValue == "4")
                        {
                            dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 4);
                        }
                        else
                        {
                            if (PeriodoId.SelectedValue == "5")
                            {
                                dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 5);
                            }
                            else
                            {
                                if (PeriodoId.SelectedValue == "6")
                                {
                                    dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 6);
                                }
                                else
                                {
                                    if (PeriodoId.SelectedValue == "7")
                                    {
                                        dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 7);
                                    }
                                    else
                                    {
                                        if (PeriodoId.SelectedValue == "8")
                                        {
                                            dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 8);
                                        }
                                        else
                                        {
                                            if (PeriodoId.SelectedValue == "9")
                                            {
                                                dt = ocnInscripcionCursado.InformeCalificacionesPorTrimestre(curso, anio, insId, 9);
                                            }
                                        }
                                    }
                                    }
                                }
                            }
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    gvNotas.DataSource = dt;
                    gvNotas.DataBind();
                    btnImprimir.Visible = true;
                }
                else
                {
                    gvNotas.DataSource = null;
                    gvNotas.DataBind();
                    btnImprimir.Visible = false;
                    alerError.Visible = true;
                    lblError.Text = "No hay registros..";
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


    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                //string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                if (e.CommandName == "Eliminar")
                {
                    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                    //this.GrillaCargar(this.GrillaNota.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                }

                if (e.CommandName == "Ver")
                {

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

    protected void GrillaNota_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }


    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        //lblMsjeErrorAsignar.Text = "";
        alerExito.Visible = false;
        GrillaCargar(gvNotas.PageIndex);
        lblPeriodo.Visible = true;
        PeriodoId.Visible = true;
        //pnlAsignarNota.Visible = true; // MOSTRAR TODO JUNTO
        //btnGuardar.Visible = false;
        //btnGuardar1.Visible = false;
        alerMje.Visible = true;
        //ButtonImprimir.Visible = false;
    }



    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
        {
            int usuario = Convert.ToInt32(Session["_usuId"].ToString());


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
        alerError.Visible = false;
        //pnlAsignarNota.Visible = false;
        //lblMsjeErrorAsignar.Text = "";
        //btnGuardar.Visible = true;
        int periodoSeleccionado = Convert.ToInt32(PeriodoId.SelectedValue);
        ViewState["PeriodoSeleccionado"] = periodoSeleccionado;
        //btnGuardar.Visible = true;
        //this.GrillaNota.DataSource = null;
        //this.GrillaNota.DataBind();
        //btnGuardar1.Visible = false;
        //btnGuardar.Visible = false;
        alerMje.Visible = false;
        //ButtonImprimir.Visible = false;
    }



    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);
        int usuario = Convert.ToInt32(Session["_usuId"].ToString());

        gvNotas.DataSource = null;
        gvNotas.DataBind();
        btnImprimir.Visible = false;

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //int curso = int.Parse(txtCurso.Text);
        //int anio = int.Parse(txtAnio.Text);
        //insId = Convert.ToInt32(Session["_Institucion"]);

        //DataTable dt = new DataTable();
        //dt = ocnInscripcionCursado.InformeObtenerCalificacionesPC(curso, anio, insId);

        //gvNotas.DataSource = dt;
        //gvNotas.DataBind();

    }
    protected void gvNotas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow ||
            e.Row.RowType == DataControlRowType.Header)
        {
            // Oculta las columnas 3 y 4 (índice base 0)
            e.Row.Cells[0].Visible = false; // curNombre
            e.Row.Cells[2].Visible = false; // curNombre
            e.Row.Cells[3].Visible = false; // icuAnoCursado
        }
    }
    protected void ButtonImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            String NomRep;
            //Int32 Materia = Convert.ToInt32(escId.SelectedValue.ToString());
            Int32 curso = Convert.ToInt32(curId.SelectedValue.ToString());
            Int32 anioLectivo = Convert.ToInt32(AnioCursado.Text.Trim().ToString());

            NomRep = "InformeListadoCalificacionesxMateria.rpt";

            //FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + Materia + "&curId=" + curso + "&anio=" + anioLectivo + "&NomRep=" + NomRep);
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


}