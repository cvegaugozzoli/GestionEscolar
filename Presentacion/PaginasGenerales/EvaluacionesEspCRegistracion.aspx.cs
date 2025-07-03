using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class EvaluacionesEspCRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Bancos ocnBancos = new GESTIONESCOLAR.Negocio.Bancos();
    GESTIONESCOLAR.Negocio.EspCurrEvaluacion ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Evaluaciones de los Espacios Curriculares - Registracion";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                int PageIndex = 0;
                //carId.Enabled = true;
                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                ////carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                //////carId.Enabled = false;

                //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                //plaId.DataBind();
                ////plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                int escId2 = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    escId2 = Convert.ToInt32(Request.QueryString["escId"]);
                    int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                    /*INCIALIZADORES*/
                    int insId = Convert.ToInt32(Session["_Institucion"]);
                    TipoEvalId.DataValueField = "Valor"; TipoEvalId.DataTextField = "Texto"; TipoEvalId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]"); TipoEvalId.DataBind();
                    escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();
                    if (Id != 0)
                    {
                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                        this.eceNombre.Text = ocnEspCurrEvaluacion.eceNombre;
                        this.eceDescripcion.Text = ocnEspCurrEvaluacion.eceDescripcion;
                        this.eceActivo.Checked = ocnEspCurrEvaluacion.eceActivo;
                        TipoEvalId.SelectedValue = Convert.ToString(ocnEspCurrEvaluacion.treId);
                        escId.SelectedValue = Convert.ToString(ocnEspCurrEvaluacion.escId);
                        btnAceptar1.Text = "Modificar";
                    }
                    else
                    {
                        escId.SelectedValue = Convert.ToString(escId2);
                        btnAceptar1.Text = "Agregar";
                    }

                    this.eceNombre.Focus();
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
    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //insId = Convert.ToInt32(Session["_Institucion"]);
        //DataTable dt5 = new DataTable();
        //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
        //ExamenTipoId.DataValueField = "Valor"; ExamenTipoId.DataTextField = "Texto"; ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]");
        ////(new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerListaxCarxPlaxEsc("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 
        ////Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(escId.SelectedValue));

        //ExamenTipoId.DataBind();

        //if (dt5.Rows.Count > 0)
        //{

        //    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 7)
        //    {
        //        //lblCondicion.Visible = true;
        //        //CondicionId.Visible = true;
        //        dvTaller.Visible = true;
        //        dvGrid.Visible = false;
        //        ExamenTipoId.Visible = false;
        //        lblPeriodo.Visible = false;
        //    }
        //    else
        //    {
        //        dvTaller.Visible = false;
        //        dvGrid.Visible = true;
        //        //lblCondicion.Visible = false;
        //        //CondicionId.Visible = false;
        //        ExamenTipoId.Visible = true;
        //        lblPeriodo.Visible = true;
        //    }
        //}
    }

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {

        int insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();
        }
        else
        {

            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            DataTable dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);

            if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")
            {
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();
            }
        }
    }
    //protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //   int insId = Convert.ToInt32(Session["_Institucion"]);
    //    dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
    //    if (dt.Rows.Count > 0)
    //    {
    //        plaId.DataValueField = "Valor";
    //        plaId.DataTextField = "Texto";
    //        plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
    //        plaId.DataBind();
    //        plaId.Enabled = true;
    //    }
    //}

    //protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (plaId.SelectedIndex != 0)
    //    {
    //        DataTable dt = new DataTable();
    //        dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
    //        if (dt.Rows.Count > 0)
    //        {
    //            curId.DataValueField = "Valor";
    //            curId.DataTextField = "Texto";
    //            curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
    //            curId.DataBind();
    //        }
    //    }
    //}
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("EvaluacionesEspCurricular.aspx", true);
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            if (Request.QueryString["Id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                ocnEspCurrEvaluacion.eceNombre = eceNombre.Text;
                ocnEspCurrEvaluacion.eceDescripcion = eceDescripcion.Text;
                ocnEspCurrEvaluacion.escId = Convert.ToInt32(escId.SelectedValue);
                ocnEspCurrEvaluacion.treId = Convert.ToInt32(TipoEvalId.SelectedValue);
                ocnEspCurrEvaluacion.eceAnioCur = Anio;
                ocnEspCurrEvaluacion.eceActivo = eceActivo.Checked;

                /*....usuId = this.Master.usuId;*/


                ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo
                        Int32 eceIdNew = ocnEspCurrEvaluacion.Insertar();
                        Int32 recId = 0;
                        Int32 escId2 = Convert.ToInt32(Request.QueryString["escId"]);

                        /*INCIALIZADORES*/
                        int insId = Convert.ToInt32(Session["_Institucion"]);
                        DataTable dtAlumnosAnioCur = new DataTable();
                        dtAlumnosAnioCur = ocnInscripcionCursadoTerciario.ObtenerTodoxEspC(insId, escId2, Anio, 0);

                        if (dtAlumnosAnioCur.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtAlumnosAnioCur.Rows)
                            {
                                ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(recId);
                                ocnRegistracionCalificaciones.ictId = Convert.ToInt32(row["Id"].ToString());
                                ocnRegistracionCalificaciones.eceId = eceIdNew;
                                ocnRegistracionCalificaciones.recNota = "";
                                ocnRegistracionCalificaciones.recObservaciones = "";
                                ocnRegistracionCalificaciones.recActivo = true;
                                ocnRegistracionCalificaciones.recFechaHoraCreacion = DateTime.Now;
                                ocnRegistracionCalificaciones.recFechaHoraUltimaModificacion = DateTime.Now;
                                ocnRegistracionCalificaciones.usuIdCreacion = this.Master.usuId;
                                ocnRegistracionCalificaciones.usuIdUltimaModificacion = this.Master.usuId;
                                ocnRegistracionCalificaciones.Insertar();
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        //Editar
                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;
                        ocnEspCurrEvaluacion.Actualizar();
                    }

                    Response.Redirect("EvaluacionesEspCurricular.aspx", true);
                }
                else
                {
                    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
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
}