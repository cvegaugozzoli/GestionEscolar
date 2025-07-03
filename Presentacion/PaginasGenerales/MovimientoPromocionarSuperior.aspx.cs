using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MovimientoPromocionarSuperior : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable AlumnosSleccionados = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                alerError.Visible = false;
                this.Master.TituloDelFormulario = " Promocionar - Curso";
                alerPromociona.Visible = false;
                insId = Convert.ToInt32(Session["_Institucion"]);
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);

                //NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                //NivelID2.DataValueField = "Valor"; NivelID2.DataTextField = "Texto"; NivelID2.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID2.DataBind();

                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                carId2.DataValueField = "Valor"; carId2.DataTextField = "Texto"; carId2.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId2.DataBind();
                //MovimientoId.DataValueField = "Valor"; MovimientoId.DataTextField = "Texto"; MovimientoId.DataSource = (new GESTIONESCOLAR.Negocio.Movimiento()).ObtenerLista("[Seleccionar...]"); MovimientoId.DataBind();
                insId = Convert.ToInt32(Session["_Institucion"]);
                Session.Add("TablaTemp", dt3);
                carId2.Visible = false;
                plaId2.Visible = false;
                curId2.Visible = false;
                AnioCursado2.Visible = false;
                lblNivel.Visible = false;
                lblCurso.Visible = false;
                lblPlan.Visible = false;
                lblAnio2.Visible = false;
                lblTipoConcepto2.Visible = false;
                lblConcepto2.Visible = false;
                ConTipoId2.Visible = false;
                ConceptoId2.Visible = false;
                //NivelID2.Visible = false;
                lblCursoD.Visible = false;
                btnSeleccionarTodo.Visible = false;
                btnSeleccionar.Visible = false;

                //lblmovimiento.Visible = false;
                //MovimientoId.Visible = false;
                BtnGrabar.Visible = false;
                ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
                ConTipoId2.DataValueField = "Valor"; ConTipoId2.DataTextField = "Texto"; ConTipoId2.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId2.DataBind();


                DataTable dt = new DataTable();

                dt.Columns.Add("conId", typeof(Int32));
                dt.Columns.Add("cntId", typeof(Int32));
                dt.Columns.Add("Importe", typeof(Decimal));
                dt.Columns.Add("NroCuota", typeof(Int32));
                dt.Columns.Add("AnioLectivo", typeof(Int32));
                dt.Columns.Add("FchInscripcion", typeof(string));
                Session["Datos"] = dt;
                //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();


                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]


                #endregion
                #region PageIndex
                int PageIndex = 0;
                if (this.Session["InscripcionCursadoRegistracion.PageIndex"] == null)
                {
                    Session.Add("InscripcionCursadoRegistracion.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["InscripcionCursadoRegistracion.PageIndex"]);
                }
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

    //protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    insId = Convert.ToInt32(Session["_Institucion"]);
    //    //dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
    //    int car = 0;
    //    int pla = 0;
    //    if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
    //    {
    //        carId.Enabled = true;
    //        carId.DataValueField = "Valor";
    //        carId.DataTextField = "Texto";
    //        carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
    //        carId.DataBind();
    //        carId.Enabled = true;

    //    }
    //    else// es primario inicial o secundario
    //    {
    //        DataTable dt3 = new DataTable();
    //        DataTable dt4 = new DataTable();

    //        dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
    //        if (dt3.Rows.Count > 0)
    //        {
    //            car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
    //            dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
    //            if (dt4.Rows.Count > 0)
    //            {
    //                pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
    //            }
    //        }

    //        curId.DataValueField = "Valor";
    //        curId.DataTextField = "Texto";
    //        curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", pla);
    //        curId.DataBind();
    //        carId.Enabled = false;
    //        plaId.Enabled = false;
    //        carId.SelectedValue = "0";
    //        plaId.SelectedValue = "0";
    //    }
    //}



    //protected void NivelID2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    DataTable dt2 = new DataTable();
    //    insId = Convert.ToInt32(Session["_Institucion"]);
    //    dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID2.SelectedValue));
    //    int carIdD = 0;
    //    int plaIdD = 0;

    //    if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
    //    {
    //        carId2.Enabled = true;
    //        carId2.DataValueField = "Valor";
    //        carId2.DataTextField = "Texto";
    //        carId2.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
    //        carId2.DataBind();
    //        carId2.Enabled = true;
    //    }
    //    else// es primario inicial o secundario
    //    {
    //        DataTable dt3 = new DataTable();
    //        DataTable dt4 = new DataTable();
    //        dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID2.SelectedValue));
    //        carIdD = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
    //        dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdD);
    //        plaIdD = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());

    //        curId2.DataValueField = "Valor";
    //        curId2.DataTextField = "Texto";
    //        curId2.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", plaIdD);
    //        curId2.DataBind();
    //        carId2.Enabled = false;
    //        plaId2.Enabled = false;
    //        carId.SelectedValue = "0";
    //        plaId.SelectedValue = "0";
    //    }
    //}

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaAlumnos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }


    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["CursoListadoAlumnos.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros

            #endregion
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 car = 0;
            Int32 pla = 0;
            //if (Convert.ToInt32(NivelID.SelectedValue) == 0)
            //{
            //    alerError.Visible = true;
            //    lblError.Text = "Complete todos los campos del Curso Origen..";
            //    return;

            //}
            //if (Convert.ToInt32(NivelID.SelectedValue) == 4)
            //{
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
                if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
                {
                    pla = Convert.ToInt32(plaId.SelectedValue.ToString());
                }
                else
                {
                    alerErrorP1.Visible = true;
                    LBLalerErrorP1.Text = "Debe seleccionar un Plan";
                    return;
                    //Session.Add("CursoListadoAlumnos.curId", cur);
                }
            }

            else
            {
                alerErrorP1.Visible = true;
                LBLalerErrorP1.Text = "Debe seleccionar una Carrera";
                return;
                //Session.Add("CursoListadoAlumnos.curId", cur);
            }

            Int32 cur = 0;
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerErrorP1.Visible = true;
                LBLalerErrorP1.Text = "Debe seleccionar un Curso";
                return;
                //Session.Add("CursoListadoAlumnos.curId", cur);
            }
            if (AnioCursado.Text == "")
            {
                alerErrorP1.Visible = true;
                LBLalerErrorP1.Text = "Debe ingresar un Año";
                return;
                //int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                //DateTime fechaActual = DateTime.Today;
                //AnioCur = Anio;
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }
            Int32 concId = 0;
            if (ConceptoId.SelectedValue.ToString() != "" & ConceptoId.SelectedValue.ToString() != "0")
            {
                concId = Convert.ToInt32(ConceptoId.SelectedValue.ToString());
            }
            else
            {
                alerErrorP1.Visible = true;
                LBLalerErrorP1.Text = "Debe seleccionar un Concepto";
                return;
            }

         

            dt = new DataTable();
            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurxAnioxConId(insId, car, pla, cur, AnioCur, concId);

            Session.Add("GrillaOriginal", dt);


            if (dt.Rows.Count > 0)
            {
                this.GrillaAlumnos.DataSource = dt;
                this.GrillaAlumnos.PageIndex = PageIndex;
                this.GrillaAlumnos.DataBind();
               
                lblCursoD.Visible = true;
               
               
                carId2.Visible = true;
                plaId2.Visible = true;
                curId2.Visible = true;
                AnioCursado2.Visible = true;
                lblNivel.Visible = true;
                lblCurso.Visible = true;
                lblAnio2.Visible = true;
                lblTipoConcepto2.Visible = true;
                lblConcepto2.Visible = true;
                lblPlan.Visible = true;
                ConTipoId2.Visible = true;
                ConceptoId2.Visible = true;
                lblCantidadRegistros2.Text = "";
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                btnSeleccionar.Visible = true;
                btnSeleccionarTodo.Visible = true;
                lblCursoD.Visible = true;
                lblListado2.Visible = false;
                lblCantidadRegistros2.Text = "";

            }
            else
            {
                lblListado2.Visible = false;
                lblCantidadRegistros2.Text = "";
                this.GrillaAlumnos.DataSource = dt;
                this.GrillaAlumnos.PageIndex = PageIndex;
                this.GrillaAlumnos.DataBind();
                carId2.Visible = false;
                plaId2.Visible = false;
                curId2.Visible = false;
                AnioCursado2.Visible = false;
                lblNivel.Visible = false;
                lblCurso.Visible = false;
                lblPlan.Visible = false;
                lblAnio2.Visible = false;
                lblTipoConcepto2.Visible = false;
                lblConcepto2.Visible = false;
                ConTipoId2.Visible = false;
                ConceptoId2.Visible = false;
              
                lblCursoD.Visible = false;
                btnSeleccionarTodo.Visible = false;
                btnSeleccionar.Visible = false;
                lblNivel.Visible = false;
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
                btnSeleccionar.Visible = false;
                BtnGrabar.Visible = false;
                btnSeleccionarTodo.Visible = false;
            }
            this.GrillaAlumnos2.DataBind();
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

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#CCCCFF';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            carIdCargar();
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
    protected void carId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            carId2Cargar();
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
    private void carIdCargar()
    {
        try
        {
            if (carId.SelectedIndex > 0)
            {
                alerExito.Visible = false;
                alerError.Visible = false;
                alerPromociona.Visible = false;

                //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
                DataTable dt = new DataTable();
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId.DataValueField = "Valor";
                    plaId.DataTextField = "Texto";
                    plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind();
                    plaId.Enabled = true;
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
    private void carId2Cargar()
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            if (carId.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId2.DataValueField = "Valor";
                    plaId2.DataTextField = "Texto";
                    plaId2.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                    plaId2.DataBind();
                    plaId2.Enabled = true;
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

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            plaIdCargar();
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

    protected void plaId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorP1.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            plaId2Cargar();
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

    private void plaIdCargar()
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            if (plaId.SelectedIndex > 0)
            {
                alerExito.Visible = false;
                alerError.Visible = false;
                alerPromociona.Visible = false;
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

    private void plaId2Cargar()
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            if (plaId.SelectedIndex > 0)
            {

                //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
                DataTable dt = new DataTable();
                dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId2.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    curId2.DataValueField = "Valor";
                    curId2.DataTextField = "Texto";
                    curId2.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId2.SelectedValue));
                    curId2.DataBind();
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

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CursoListadoAlumnos.PageIndex"]);
            alerPromociona.Visible = false;
            carId2.Visible = false;
            plaId2.Visible = false;
            curId2.Visible = false;
            AnioCursado2.Visible = false;
            GrillaCargar(PageIndex);
            lblCantidadRegistros.Visible = true;
            lblListado.Visible = true;
            BtnGrabar.Enabled = false;
            //MovimientoId.SelectedIndex = 0;
            lblCantidadRegistros2.Text = "";
            lblMensajeError2.Text = "";
            lblMensajeError2.ForeColor = System.Drawing.Color.Blue;
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


    protected void btnSeleccionar_Click(object sender, EventArgs e)
    {

        if (ConTipoId2.SelectedValue.ToString() != "")
        {
            try
            {
                alerErrorP1.Visible = false;
                alerErrorP2.Visible = false;
                alerExito.Visible = false;
                alerError.Visible = false;
                alerPromociona.Visible = false;
                //int BanderaEstado = 0;
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                lblMensajeError2.Text = "";
                lblMensajeError.Text = "";
                lblMensajeError2.ForeColor = System.Drawing.Color.Blue;
                dt.Columns.Add("IC", typeof(int));
                dt.Columns.Add("Nombre", typeof(String));
                dt.Columns.Add("DNI", typeof(int));
                dt.Columns.Add("aluId", typeof(int));
                dt.Columns.Add("Estado", typeof(int));
                foreach (GridViewRow row in GrillaAlumnos.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                    //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                    if ((check.Checked)) // Si esta seleccionado..
                    {
                        DataRow row1 = dt.NewRow();
                        int EstadoAlumno = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                        int cntid = Convert.ToInt32(ConceptoId2.SelectedValue.ToString());
                        int icuid = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["icuid"]);

                        // 29-11-2023 Aquí debería controlar si ya tiene el concepto seleccionado del lado derecho, si lo tiene no lo paso.
                        DataTable dtControl = ocnInscripcionConcepto.ObtenerUnoxicuIdxconId(icuid, Convert.ToInt32(ConceptoId2.SelectedValue.ToString()));
                        if (dtControl.Rows.Count == 0)
                        {
                            row1["IC"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Id"]);
                            row1["Nombre"] = Convert.ToString(GrillaAlumnos.DataKeys[row.RowIndex].Values["Alumno"]); ;
                            row1["DNI"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Dni"]);
                            row1["aluId"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);
                            row1["Estado"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                            dt.Rows.Add(row1);
                        }


                    }
                }
                GrillaAlumnos2.DataSource = dt;
                Session.Add("TablaTemp", dt);
                lblCantidadRegistros2.Visible = true;
                lblListado2.Visible = true;
                GrillaAlumnos2.DataBind();
                if (dt.Rows.Count > 0)
                {
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    //lblmovimiento.Visible = true;
                    //MovimientoId.Visible = true;
                    BtnGrabar.Visible = true;
                    BtnGrabar.Enabled = true;
                }
                else
                {
                    lblCantidadRegistros2.Text = "Cantidad de registros: 0";
                    alerError.Visible = true;
                    lblError.Text = "No seleccionó alumnos o ya se encuentra asignado el concepto de destino..";

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

        //        try
        //        {
        //            alerExito.Visible = false;
        //            alerError.Visible = false;
        //            alerPromociona.Visible = false;
        //            int BanderaEstado = 0;
        //            DataTable dt = new DataTable();
        //            DataTable dt2 = new DataTable();
        //            lblMensajeError2.Text = "";
        //            lblMensajeError.Text = "";
        //            lblMensajeError2.ForeColor = System.Drawing.Color.Blue;
        //            dt.Columns.Add("IC", typeof(int));
        //            dt.Columns.Add("Nombre", typeof(String));
        //            dt.Columns.Add("DNI", typeof(int));
        //            dt.Columns.Add("aluId", typeof(int));
        //            dt.Columns.Add("Estado", typeof(int));
        //            foreach (GridViewRow row in GrillaAlumnos.Rows)
        //            {
        //                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
        //                //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
        //                if ((check.Checked)) // Si esta seleccionado..
        //                {
        //                    DataRow row1 = dt.NewRow();
        //                    int EstadoAlumno = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);

        //                    if (EstadoAlumno == 1 || EstadoAlumno == 8)//Cursando o preinscripcion
        //                    {
        //                        row1["IC"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Id"]);
        //                        row1["Nombre"] = Convert.ToString(GrillaAlumnos.DataKeys[row.RowIndex].Values["Alumno"]); ;
        //                        row1["DNI"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Dni"]);
        //                        row1["aluId"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);
        //                        row1["Estado"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
        //                        dt.Rows.Add(row1);
        //                    }
        //                    else
        //                    {
        //                        alerError.Visible = true;
        //                        lblError.Text = "Atención: Seleccionó Alumnos con un estado distinto a cursando. No fueron incorporados a la Tabla destino.";
        //                    }
        //                }
        //            }
        //            GrillaAlumnos2.DataSource = dt;
        //            Session.Add("TablaTemp", dt);
        //            lblCantidadRegistros2.Visible = true;
        //            lblListado2.Visible = true;
        //            GrillaAlumnos2.DataBind();
        //            if (dt.Rows.Count > 0)
        //            {
        //                lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
        //                //lblmovimiento.Visible = true;
        //                //MovimientoId.Visible = true;
        //                BtnGrabar.Visible = true;
        //                BtnGrabar.Enabled = true;
        //            }
        //            else
        //            {
        //                lblCantidadRegistros2.Text = "Cantidad de registros: 0";
        //                alerError.Visible = true;
        //                lblError.Text = "Seleccione Alumnos del Curso a Modificar..";

        //                return;
        //            }
        //        }

        //        catch (Exception oError)
        //        {
        //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
        //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        //Se ha producido el siguiente error:<br/>
        //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
        //    "</div>";
        //        }
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {           
            btnSeleccionarTodo.Text = "Seleccionar todo";
            alerExito.Visible = false;
            alerError.Visible = false;
            alerPromociona.Visible = false;
            lblMensajeError.Text = "";
            if (lblCantidadRegistros2.Text != "")
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                dt4 = Session["TablaTemp"] as DataTable;

                if (dt4.Rows.Count > 0)
                {
                    string MensajeValidacion = "";
                    lblMensajeError.Text = "";
                   
                        if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                        {
                        alerErrorP2.Visible = true;
                            LBLalerErrorP2.Text = "Seleccione una Carrera en Curso Destino..";

                            return;
                        }
                        else
                        {
                            if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                            {
                            alerErrorP2.Visible = true;
                                LBLalerErrorP2.Text = "Seleccione un Plan de Estudio en Curso Destino..";
                                return;
                            }
                        }
                   
                    if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                    {
                        alerErrorP2.Visible = true;
                        LBLalerErrorP2.Text = "Seleccione un Curso en en Curso Destino..";
                        return;
                    }

                    if (AnioCursado2.Text.Trim() == "")
                    {
                        alerErrorP2.Visible = true;
                        LBLalerErrorP2.Text = "Seleccione Año de cursado en Curso Destino..";
                        return;
                    }
                    if (ConTipoId2.Text.Trim() == "")
                    {
                        alerErrorP2.Visible = true;
                        LBLalerErrorP2.Text = "Seleccione Tipo de Concepto en Curso Destino..";
                        return;
                    }
                    if (ConceptoId2.Text.Trim() == "")
                    {
                        alerErrorP2.Visible = true;
                        LBLalerErrorP2.Text = "Seleccione Concepto en Curso Destino..";
                        return;
                    }
                    //Mov = Convert.ToInt32(MovimientoId.SelectedValue);


                    //if (Mov == 2) // Promociona
                    //{
                    dt = Session["Datos"] as DataTable;
                    //int proxanio = Convert.ToInt32(AnioCursado.Text) + 1;
                    int Bandera = 0;

                    foreach (GridViewRow row in GrillaAlumnos2.Rows)
                    {
                        Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                        if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                        {
                            int proxanio = Convert.ToInt32(AnioCursado.Text) + 1;

                            if (AnioCursado2.Text == Convert.ToString(proxanio))
                            {
                                Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;

                                Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]);
                                Int32 EstadoIns = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);

                                ///Controlo que el alumno no se encuentre inscripto en ese curso en ese año
                                DataTable dt2 = new DataTable();
                                DataTable dt1 = new DataTable();

                                dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                if (dt2.Rows.Count == 0)
                                {
                                    String AnioNuevo = AnioCursado2.Text;
                                    DateTime FechaInscripcion = DateTime.Now;
                                    int carIdD = 0;
                                    int plaIdD = 0;
                                  
                                        carIdD = Convert.ToInt32((carId2.SelectedValue.Trim() == "" ? "0" : carId2.SelectedValue));
                                        plaIdD = Convert.ToInt32((plaId2.SelectedValue.Trim() == "" ? "0" : plaId2.SelectedValue));
                                   
                                    int curIdD = Convert.ToInt32((curId2.SelectedValue.Trim() == "" ? "0" : curId2.SelectedValue));
                                    //int camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                                    /*....usuId = this.Master.usuId;*/
                                    DateTime icuFechaHoraCreacion = DateTime.Now;
                                    DateTime icuFechaHoraUltimaModificacion = DateTime.Now;
                                    int usuIdCreacion = this.Master.usuId;
                                    int UsuIdUltimaModificacion = this.Master.usuId;
                                    int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                    ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 2);

                                    /////////////////////Activo=0?????????
                                    //////////////////////////////////////////////////////
                                    DataTable dt6 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId2.SelectedValue));
                                    DataTable dt7 = ocnConceptosTipos.ObtenerUno(Convert.ToInt32(ConTipoId2.SelectedValue));

                                    DataTable dt5 = new DataTable();
                                    dt = Session["Datos"] as DataTable;
                                    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);

                                    if (ConTipoId2.SelectedValue == "1")//Matricula
                                    {
                                        //if (Convert.ToInt32(NivelID2.SelectedValue) == 2 || Convert.ToInt32(NivelID2.SelectedValue) == 3)// Si es primario o secundario asigno materias
                                        //{
                                        //    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                        //    if (dt5.Rows.Count > 0)
                                        //    {
                                        //        // Por Cada Materia inserto un registro Nota para ese alumno.
                                        //        foreach (DataRow row2 in dt5.Rows)
                                        //        {
                                        //            int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                        //            ocnRegistracionNota.Insertar(icuId2, escId2, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                        //        }
                                        //    }
                                        //}
                                        DataRow row1 = dt.NewRow();
                                        int cuota = 1;
                                        ocnInscripcionConcepto.Insertar(icuId2, Convert.ToInt32(dt6.Rows[0]["Id"].ToString()), Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString()), DateTime.Now, cuota, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                        Bandera = 3;
                                    }
                                    else
                                    {
                                        if (ConTipoId2.SelectedValue == "2")//Cuota
                                        {
                                            int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());
                                            int cuota = 0;
                                            // Busco el primer Nro de Cuota    
                                            DataTable dtNroCuo = ocnConceptosIntereses.ObtenerPrimerNroCuotaporConid(Convert.ToInt32(ConceptoId2.SelectedValue));
                                            cuota = Convert.ToInt32(dtNroCuo.Rows[0]["PrimerNroCuota"].ToString()) - 1;
                                            //  
                                            for (int i = 0; i < cantCuotas; i++) //Para cada cuota
                                            {
                                                cuota = cuota + 1;
                                                DataRow row1 = dt.NewRow();
                                                row1["conId"] = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                                row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                                row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                                row1["FchInscripcion"] = Convert.ToString(DateTime.Now);
                                                row1["NroCuota"] = cuota;
                                                dt.Rows.Add(row1);
                                            }



                                            Session.Add("Datos", dt);
                                            dt4 = Session["Datos"] as DataTable;
                                            if (dt4.Rows.Count > 0)
                                            {
                                                foreach (DataRow row2 in dt4.Rows)
                                                {
                                                    int conId = Convert.ToInt32(row2["conId"].ToString());
                                                    Decimal Importe = Convert.ToDecimal(row2["Importe"].ToString());
                                                    DateTime FchaInscripcion = Convert.ToDateTime(row2["FchInscripcion"].ToString());
                                                    Int32 NroCuota = Convert.ToInt32(row2["NroCuota"].ToString());
                                                    Int32 bcaId = 1;
                                                    ocnInscripcionConcepto.Insertar(icuId2, conId, Importe, FchaInscripcion, NroCuota, bcaId, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                    Bandera = 4;
                                                }
                                                dt.Clear();
                                                Session.Add("Datos", dt);
                                            }
                                        }
                                    }
                                }
                                else //Esta en el curso
                                {
                                    alerError.Visible = true;
                                    lblError.Text = "El alumno ya se encuentra en el curso seleccionado";
                                    return;
                                }
                            }
                            else //mismo Año Lectivo.. no promociona
                            {
                                Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]);
                                DataTable dt6 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId2.SelectedValue));
                                Int32 conIdVer = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                DataTable dt7 = ocnConceptosTipos.ObtenerUno(Convert.ToInt32(ConTipoId2.SelectedValue));
                                Int32 TconIdVer = Convert.ToInt32(dt7.Rows[0]["Id"].ToString());

                                DataTable dt3 = new DataTable();
                                DataTable dt5 = new DataTable();
                                if (dt6.Rows.Count > 0)
                                {
                                    dt3 = ocnInscripcionConcepto.ObtenerUnoxicuIdxconId(icuId, Convert.ToInt32(dt6.Rows[0]["Id"].ToString()));

                                    if (dt3.Rows.Count == 0)//Se repite ese concepto??
                                    {
                                        if (ConTipoId2.SelectedValue == "1")//Matricula
                                        {

                                            DataRow row1 = dt.NewRow();
                                            int cuota = 1;
                                            ocnInscripcionConcepto.Insertar(icuId, Convert.ToInt32(dt6.Rows[0]["Id"].ToString()), Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString()), DateTime.Now, cuota, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            Bandera = 3;
                                        }
                                        else
                                        {
                                            if (ConTipoId2.SelectedValue == "2")//Cuota
                                            {
                                                int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());
                                                int cuota = 0;
                                                // Busco el primer Nro de Cuota    
                                                DataTable dtNroCuo = ocnConceptosIntereses.ObtenerPrimerNroCuotaporConid(Convert.ToInt32(ConceptoId2.SelectedValue));
                                                cuota = Convert.ToInt32(dtNroCuo.Rows[0]["PrimerNroCuota"].ToString()) - 1;
                                                //  
                                                for (int i = 0; i < cantCuotas; i++) //Para cada cuota
                                                {
                                                    cuota = cuota + 1;
                                                    DataRow row1 = dt.NewRow();
                                                    row1["conId"] = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                    row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                                    row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                                    row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                                    row1["FchInscripcion"] = Convert.ToString(DateTime.Now);
                                                    row1["NroCuota"] = cuota;
                                                    dt.Rows.Add(row1);
                                                }
                                            }

                                            Session.Add("Datos", dt);
                                            dt4 = Session["Datos"] as DataTable;
                                            if (dt4.Rows.Count > 0)
                                            {
                                                foreach (DataRow row2 in dt4.Rows)
                                                {
                                                    int conId = Convert.ToInt32(row2["conId"].ToString());
                                                    Decimal Importe = Convert.ToDecimal(row2["Importe"].ToString());
                                                    DateTime FchaInscripcion = Convert.ToDateTime(row2["FchInscripcion"].ToString());
                                                    Int32 NroCuota = Convert.ToInt32(row2["NroCuota"].ToString());
                                                    Int32 bcaId = 1;
                                                    ocnInscripcionConcepto.Insertar(icuId, conId, Importe, FchaInscripcion, NroCuota, bcaId, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                    Bandera = 4;
                                                }
                                                dt.Clear();
                                                Session.Add("Datos", dt);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        alerError.Visible = true;
                                        lblError.Text = "Ese Concepto ya esta registrado";
                                        //return;
                                    }
                                }
                                else
                                {
                                    alerError.Visible = true;
                                    lblError.Text = "No existe Concepto para el tipo de Concepto seleccionado";
                                    return;
                                }
                            }
                        }                      
                        

                    }
                    if (Bandera == 1)
                    {
                        alerExito.Visible = true;
                        lblExito.Text = "Se inscribió el Concepto Matricula a los alumnos seleccionados";
                        BtnGrabar.Enabled = false;
                        return;

                    }
                    else
                    {
                        if (Bandera == 2)
                        {
                            alerExito.Visible = true;
                            lblExito.Text = "Se inscribió el Concepto Cuota a los alumnos seleccionados";
                            BtnGrabar.Enabled = false;
                            return;
                        }
                        else
                        {
                            if (Bandera == 3 || Bandera == 4)
                            {
                                BtnGrabar.Enabled = false;
                                alerPromociona.Visible = true;
                            }
                        }
                    }
                    //BtnGrabar.Visible = true;
                    //BtnGrabar.Enabled = true;
                    int PageIndex = Convert.ToInt32(Session["MovimientoPromocionar.PageIndex"]);
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

    protected void ConTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorP2.Visible = false;
            alerErrorP1.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (ConTipoId.SelectedIndex != 0)
            {
                int TipoConc = Convert.ToInt32(ConTipoId.SelectedValue);
                DataTable dt = new DataTable();
                dt = ocnConceptos.ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
                if (dt.Rows.Count > 0)
                {
                    ConceptoId.DataValueField = "Valor";
                    ConceptoId.DataTextField = "Texto";
                    ConceptoId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
                    ConceptoId.DataBind();
                }
                else
                {
                    //LblMjeGridConcepto.Text = "No existe Concepto para ese Año Lectivo..";
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

    protected void ConTipoId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorP1.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (ConTipoId2.SelectedIndex != 0)
            {

                int TipoConc = Convert.ToInt32(ConTipoId2.SelectedValue);
                DataTable dt = new DataTable();
                dt = ocnConceptos.ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text));
                if (dt.Rows.Count > 0)
                {
                    ConceptoId2.DataValueField = "Valor";
                    ConceptoId2.DataTextField = "Texto";
                    ConceptoId2.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text));
                    ConceptoId2.DataBind();
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No existe Concepto para ese Año Lectivo..";
                    return;

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

    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in GrillaAlumnos.Rows)
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
                foreach (GridViewRow row in GrillaAlumnos.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == false)
                    {
                        check.Checked = true;
                    }
                }
                btnSeleccionarTodo.Text = "Desmarcar todo";
            }
            BtnGrabar.Enabled = true;
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


            int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;
            //int index = e.RowIndex;

            //int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["TablaTemp"] as DataTable;
            dt1.Rows[RowId].Delete();
            Session["TablaTemp"] = dt1;

            GrillaAlumnos2.DataSource = dt1;
            GrillaAlumnos2.DataBind();
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

    protected void AnioCursado_TextChanged(object sender, EventArgs e)
    {
        alerErrorP1.Visible = false;

        ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
        ConceptoId.ClearSelection();
    }

    protected void AnioCursado2_TextChanged(object sender, EventArgs e)
    {
        alerErrorP2.Visible = false;
        ConTipoId2.DataValueField = "Valor"; ConTipoId2.DataTextField = "Texto"; ConTipoId2.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId2.DataBind();
        ConceptoId2.ClearSelection();
    }

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerErrorP2.Visible = false;
        alerErrorP1.Visible = false;
    }

    protected void curId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerErrorP2.Visible = false;
        alerErrorP1.Visible = false;
    }
}
