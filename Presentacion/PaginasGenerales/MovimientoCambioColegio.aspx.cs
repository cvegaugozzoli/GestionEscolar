using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MovimientoCambioColegio : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();


    Int32 insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Cambio de Colegio - Alumno";
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                //carId2.DataValueField = "Valor"; carId2.DataTextField = "Texto"; carId2.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId2.DataBind();
                //MovimientoId.DataValueField = "Valor"; MovimientoId.DataTextField = "Texto"; MovimientoId.DataSource = (new GESTIONESCOLAR.Negocio.Movimiento()).ObtenerLista("[Seleccionar...]"); MovimientoId.DataBind();
                insId = Convert.ToInt32(Session["_Institucion"]);
                Session.Add("TablaTemp", dt3);

                //lblCarrera2.Visible = false;
                //lblPlanId2.Visible = false;
                //lblcurso2.Visible = false;
                //lblanio2.Visible = false;
                //carId2.Visible = false;
                //plaId2.Visible = false;
                //curId2.Visible = false;
                //AnioCursado2.Visible = false;
                //lblmovimiento.Visible = false;
                //MovimientoId.Visible = false;
                BtnGrabar.Visible = false;
                //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                #region PageIndex
                int PageIndex = 0;
                if (this.Session["CursoMovimientoAlumnos.PageIndex"] == null)
                {
                    Session.Add("CursoMovimientoAlumnos.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]


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

    protected void plaId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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

            Int32 cur = 0;
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                Session.Add("CursoListadoAlumnos.curId", cur);
            }
            Int32 concId = 0;
            if (ConceptoId.SelectedValue.ToString() != "" & ConceptoId.SelectedValue.ToString() != "0")
            {
                concId = Convert.ToInt32(ConceptoId.SelectedValue.ToString());
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
            Session.Add("GrillaOriginal", dt);
            this.GrillaAlumnos.DataSource = dt;
            this.GrillaAlumnos.PageIndex = PageIndex;
            this.GrillaAlumnos.DataBind();

            if (dt.Rows.Count > 0)
            {
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
                //btnSeleccionarTodo.Visible = true;
                lblCursoD.Visible = true;

            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
                btnSeleccionar.Visible = false;
                BtnGrabar.Visible = false;
                //btnSeleccionarTodo.Visible = false;
            }

            //dt = ocnCurso.ObtenerporCarporPlaporCurAnio(car, pla, cur, AnioCur);
            //this.GrillaAlumnos2.DataSource = dt;
            //this.GrillaAlumnos2.PageIndex = PageIndex;
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


    protected void ConTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
                    lblMensajeError.Text = "No existe Concepto para ese Año Lectivo..";
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
            if (carId.SelectedIndex > 0)
            {
                //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
                DataTable dt = new DataTable();
                //dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    //plaId2.DataValueField = "Valor";
                    //plaId2.DataTextField = "Texto";
                    //plaId2.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                    //plaId2.DataBind();
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

    protected void MovimientoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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

 

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CursoListadoAlumnos.PageIndex"]);

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
        try
        {
            DataTable dt = new DataTable();
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
                CheckBox check = row.FindControl("rbSelector") as CheckBox;
                if ((check.Checked)) // Si esta seleccionado..
                {
                    DataRow row1 = dt.NewRow();
                    int EstadoAlumno = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);

                    if (EstadoAlumno == 1 || EstadoAlumno == 8)
                    {
                        row1["IC"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Id"]);
                        row1["Nombre"] = Convert.ToString(GrillaAlumnos.DataKeys[row.RowIndex].Values["Alumno"]); ;
                        row1["DNI"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Dni"]);
                        row1["aluId"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);
                        row1["Estado"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                        dt.Rows.Add(row1);
                    }
                    else
                    {
                        lblMensajeError2.ForeColor = System.Drawing.Color.Red;
                        lblMensajeError2.Text = "El estado del Alumno debe ser Cursando o pre inscripto.." + "</div>";
                        return;
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
                lblMensajeError.Visible = true;

                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Seleccione un Alumno del Curso Origen." + "</div>";
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

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in GrillaAlumnos2.Rows)
            {
                Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);

                if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                {
                    Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                    Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]); ;
                    DataTable dt2 = new DataTable();
                    DataTable dt1 = new DataTable();
                    Int32 EstadoIns = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                    ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 5);// Actualizo IC ANTERIOR A Estado IGUAL Repite
                    lblMensajeError2.Text = "Se Realizó la Operación Cambio de Colegio para el registro seleccionado..";
                    BtnGrabar.Visible = false;
                    //Session.Add("TablaTemp", dt3);
                    //dt = Session["TablaTemp"] as DataTable;
                    //GrillaAlumnos2.DataSource = dt;
                    //GrillaAlumnos2.DataBind();
                }
            }

            int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
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


    //    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {

    //            if (btnSeleccionarTodo.Text == "Desmarcar todo")
    //            {
    //                foreach (GridViewRow row in GrillaAlumnos.Rows)
    //                {
    //                    CheckBox check = row.FindControl("rbSelector") as CheckBox;

    //                    if (check.Checked == true)
    //                    {
    //                        check.Checked = false;

    //                    }
    //                }
    //                btnSeleccionarTodo.Text = "Seleccionar todo";
    //            }
    //            else
    //            {
    //                foreach (GridViewRow row in GrillaAlumnos.Rows)
    //                {
    //                    CheckBox check = row.FindControl("rbSelector") as CheckBox;

    //                    if (check.Checked == false)
    //                    {
    //                        check.Checked = true;

    //                    }
    //                }
    //                btnSeleccionarTodo.Text = "Desmarcar todo";
    //            }

    //            BtnGrabar.Enabled = true;
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
    //    }
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
            //int Id = 0;
            //Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

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

    protected void rbSelector_CheckedChanged(object sender, System.EventArgs e)
    {
        //Clear the existing selected row 
        foreach (GridViewRow oldrow in GrillaAlumnos.Rows)
        {
            ((RadioButton)oldrow.FindControl("rbSelector")).Checked = false;
        }


        //Set the new selected row
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        ((RadioButton)row.FindControl("rbSelector")).Checked = true;
    }

}
