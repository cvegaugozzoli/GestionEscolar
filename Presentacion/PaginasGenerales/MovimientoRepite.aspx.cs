using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MovimientoRepite : System.Web.UI.Page
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
    int insId;
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


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Repite - Alumno";
                insId = Convert.ToInt32(Session["_Institucion"]);
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                lblInsId2.Text = Convert.ToString(Session["_Institucion"]);

                ListItem i;
                if (lblInsId.Text == "1")
                {
                    i = new ListItem("Seleccionar..", "0");
                    carId.Items.Add(i);

                    i = new ListItem("Primario", "2");
                    carId.Items.Add(i);
                    i = new ListItem("Secundario", "3");
                    carId.Items.Add(i);
                    i = new ListItem("3º CICLO DE LA EGB Y DE LA EDUC.POLIM EN GEOGRAFIA", "16");
                    carId.Items.Add(i);
                    i = new ListItem("1º Y 2º CICLO DE LA EGB", "17");
                    carId.Items.Add(i);
                    i = new ListItem("3º CICLO DE LA EGB Y DE LA EDUC.POLIM. EN ECONOMIA", "18");
                    carId.Items.Add(i);
                    i = new ListItem("INGLES PARA EL 3º CICLO DE LA EGB Y LA EDUC.POLIM.", "19");
                    carId.Items.Add(i);
                    i = new ListItem("EDUCACION INICIAL", "20");
                    carId.Items.Add(i);
                    i = new ListItem("INGLES PARA EDUC.INICIAL Y 1º Y 2º CICLO DE LA EGB", "21");
                    carId.Items.Add(i);
                    i = new ListItem("CIENCIAS NATURALES. BIOLOGIA, SALUD Y AMBIENTE", "22");
                    carId.Items.Add(i);
                    i = new ListItem("CIENCIAS NATURALES. MATEMATICA, FISICA Y DISEÑO", "23");
                    carId.Items.Add(i);
                    i = new ListItem("ECONOMIA Y ADMINISTRACION", "24");
                    carId.Items.Add(i);
                    i = new ListItem("CS. SOCIALES Y HUMANIDADES", "25");
                    carId.Items.Add(i);
                    i = new ListItem("EDUCACION PRIMARIA", "26");
                    carId.Items.Add(i);
                    i = new ListItem(" EDUCACIÓN INICIAL", "27");
                    carId.Items.Add(i); i = new ListItem("INGLES", "28");
                    carId.Items.Add(i);
                    i = new ListItem("EDUCACION SECUNDARIA EN GEOGRAFIA", "29");
                    carId.Items.Add(i); i
                        = new ListItem("EDUCACION SECUNDARIA EN ECONOMIA", "30");
                    carId.Items.Add(i);
                    i = new ListItem("PROFESORADO EN GEOGRAFIA 06", "31");
                    carId.Items.Add(i); i = new ListItem(" PROFESORADO EN GEOGRAFIA 07", "32");
                    carId.Items.Add(i);
                    i = new ListItem("PLANES ESPECIALES", "33");
                    carId.Items.Add(i);
                }
                else
                {
                    if (lblInsId.Text == "2")
                    {
                        i = new ListItem("Seleccionar..", "0");
                        carId.Items.Add(i);
                        i = new ListItem("Primario", "2");
                        carId.Items.Add(i);
                    }
                    else
                    {
                        if (lblInsId.Text == "3")
                        {
                            i = new ListItem("Seleccionar..", "0");
                            carId.Items.Add(i);
                            i = new ListItem("Primario", "2");
                            carId.Items.Add(i);
                        }
                        else
                        {
                            if (lblInsId.Text == "4")
                            {
                                i = new ListItem("Seleccionar..", "0");
                                carId.Items.Add(i);
                                i = new ListItem("Inicial", "1");
                                carId.Items.Add(i);
                            }
                            else
                            {
                                if (lblInsId.Text == "5")
                                {
                                    i = new ListItem("Seleccionar..", "0");
                                    carId.Items.Add(i);
                                    i = new ListItem("Inicial", "1");
                                    carId.Items.Add(i);
                                }
                            }
                        }
                    }
                }

                ListItem i2;
                if (lblInsId2.Text == "1")
                {
                    i2 = new ListItem("Seleccionar..", "0");
                    carId2.Items.Add(i2);

                    i2 = new ListItem("Primario", "2");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("Secundario", "3");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("3º CICLO DE LA EGB Y DE LA EDUC.POLIM EN GEOGRAFIA", "16");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("1º Y 2º CICLO DE LA EGB", "17");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("3º CICLO DE LA EGB Y DE LA EDUC.POLIM. EN ECONOMIA", "18");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("INGLES PARA EL 3º CICLO DE LA EGB Y LA EDUC.POLIM.", "19");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("EDUCACION INICIAL", "20");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("INGLES PARA EDUC.INICIAL Y 1º Y 2º CICLO DE LA EGB", "21");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("CIENCIAS NATURALES. BIOLOGIA, SALUD Y AMBIENTE", "22");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("CIENCIAS NATURALES. MATEMATICA, FISICA Y DISEÑO", "23");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("ECONOMIA Y ADMINISTRACION", "24");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("CS. SOCIALES Y HUMANIDADES", "25");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("EDUCACION PRIMARIA", "26");
                    carId2.Items.Add(i2);
                    i2 = new ListItem(" EDUCACIÓN INICIAL", "27");
                    carId2.Items.Add(i2); i2 = new ListItem("INGLES", "28");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("EDUCACION SECUNDARIA EN GEOGRAFIA", "29");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("EDUCACION SECUNDARIA EN ECONOMIA", "30");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("PROFESORADO EN GEOGRAFIA 06", "31");
                    carId2.Items.Add(i2);
                    i2 = new ListItem(" PROFESORADO EN GEOGRAFIA 07", "32");
                    carId2.Items.Add(i2);
                    i2 = new ListItem("PLANES ESPECIALES", "33");
                    carId2.Items.Add(i2);
                }
                else
                {
                    if (lblInsId2.Text == "2")
                    {
                        i2 = new ListItem("Seleccionar..", "0");
                        carId2.Items.Add(i2);
                        i2 = new ListItem("Primario", "2");
                        carId2.Items.Add(i2);
                    }
                    else
                    {
                        if (lblInsId2.Text == "3")
                        {
                            i2 = new ListItem("Seleccionar..", "0");
                            carId2.Items.Add(i2);
                            i2 = new ListItem("Primario", "2");
                            carId2.Items.Add(i2);
                        }
                        else
                        {
                            if (lblInsId2.Text == "4")
                            {
                                i2 = new ListItem("Seleccionar..", "0");
                                carId2.Items.Add(i2);
                                i2 = new ListItem("Inicial", "1");
                                carId2.Items.Add(i2);
                            }
                            else
                            {
                                if (lblInsId2.Text == "5")
                                {
                                    i2 = new ListItem("Seleccionar..", "0");
                                    carId2.Items.Add(i2);
                                    i2 = new ListItem("Inicial", "1");
                                    carId2.Items.Add(i2);
                                }
                            }
                        }
                    }
                }                        //MovimientoId.DataValueField = "Valor"; MovimientoId.DataTextField = "Texto"; MovimientoId.DataSource = (new GESTIONESCOLAR.Negocio.Movimiento()).ObtenerLista("[Seleccionar...]"); MovimientoId.DataBind();
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
                //lblmovimiento.Visible = false;
                //MovimientoId.Visible = false;
                BtnGrabar.Visible = false;
                ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
                ConTipoId2.DataValueField = "Valor"; ConTipoId2.DataTextField = "Texto"; ConTipoId2.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId2.DataBind();

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


    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["CursoListadoAlumnos.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros

            #endregion
            insId = Convert.ToInt32(Session["_Institucion"]);
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
                //MovimientoId.Visible = false;
                //lblmovimiento.Visible = false;
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
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
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
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
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
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId2.DataValueField = "Valor";
                    plaId2.DataTextField = "Texto";
                    plaId2.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                    plaId2.DataBind();
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
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
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
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
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

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
            alerExito.Visible = false;
            alerError.Visible = false;
            //alerPromociona.Visible = false;
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
            alerExito.Visible = false;
            alerError.Visible = false;
            int BanderaEstado = 0;
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
                //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                if ((check.Checked)) // Si esta seleccionado..
                {
                    DataRow row1 = dt.NewRow();
                    int EstadoAlumno = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);

                    if (EstadoAlumno == 1)
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
                        BanderaEstado = 1;
                    }

                }
            }

            if ((BanderaEstado == 1)) // Si se selecciono estado distintos a cursando no se cargó
            {
              
                alerError.Visible = true;
                lblError.Text = "Solo se copió Alumnos con estado Cursando..";             

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
                lblError.Text = "Seleccione Alumnos del Curso a Modificar..";    
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
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
            lblMensajeError2.Text = "";
            if (lblCantidadRegistros2.Text != "")
            {
                dt4 = Session["TablaTemp"] as DataTable;
                if (dt4.Rows.Count > 0)
                {
                    if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                    {
                        alerError.Visible = true;
                        lblError.Text = "Seleccione una Carrera en Curso Destino..";

                        return;
                    }

                    if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                    {
                        alerError.Visible = true;
                        lblError.Text = "Seleccione un Plan de Estudio en Curso Destino..";
                        return;
                    }
                    if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                    {
                        alerError.Visible = true;
                        lblError.Text = "Seleccione un Curso en en Curso Destino..";
                        return;
                    }

                    if (AnioCursado2.Text.Trim() == "")
                    {
                        alerError.Visible = true;
                        lblError.Text = "Seleccione Año de cursado en Curso Destino..";
                        return;
                    }
                    if (ConTipoId2.Text.Trim() == "")
                    {
                        alerError.Visible = true;
                        lblError.Text = "Seleccione Tipo de Concepto en Curso Destino..";
                        return;
                    }
                    if (ConceptoId2.Text.Trim() == "")
                    {
                        alerError.Visible = true;
                        lblError.Text = "Seleccione Concepto en Curso Destino..";
                        return;
                    }
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    int proxanio = Convert.ToInt32(AnioCursado.Text) + 1;

                    if (AnioCursado2.Text == Convert.ToString(proxanio))
                    {
                        foreach (GridViewRow row in GrillaAlumnos2.Rows)
                        {
                            Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                            {
                                Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                                Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]); ;
                                Int32 EstadoIns = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                                DataTable dt2 = new DataTable();
                                DataTable dt1 = new DataTable();
                                ///Controlo que el alumno no se encuentre inscripto en ese curso en ese año
                                dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                if (dt2.Rows.Count == 0)
                                {
                                    int AnioCursadoD = Convert.ToInt32(AnioCursado2.Text);
                                    DateTime FechaInscripcion = DateTime.Now;
                                    int carId = Convert.ToInt32((carId2.SelectedValue.Trim() == "" ? "0" : carId2.SelectedValue));
                                    int plaId = Convert.ToInt32((plaId2.SelectedValue.Trim() == "" ? "0" : plaId2.SelectedValue));
                                    int curId = Convert.ToInt32((curId2.SelectedValue.Trim() == "" ? "0" : curId2.SelectedValue));
                                    //int camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                                    /*....usuId = this.Master.usuId;*/
                                    DateTime icuFechaHoraCreacion = DateTime.Now;
                                    DateTime icuFechaHoraUltimaModificacion = DateTime.Now;
                                    int usuIdCreacion = this.Master.usuId;
                                    int UsuIdUltimaModificacion = this.Master.usuId;
                                    ocnInscripcionCursado.icuObserv = "";
                                    int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carId, plaId, curId, 0, 0, AnioCursadoD, FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                    ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 3);// Actualizo IC ANTERIOR A Estado IGUAL Repite

                                    //////////////////////////////////////////////////////

                                    DataTable dt5 = new DataTable();

                                    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                    if (dt5.Rows.Count > 0)
                                    {
                                        // Por Cada Materia inserto un registro Nota para ese alumno.
                                        foreach (DataRow row2 in dt5.Rows)
                                        {
                                            int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                            ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                        }
                                    }

                                    DataTable dt6 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId2.SelectedValue));
                                    DataTable dt7 = ocnConceptosTipos.ObtenerUno(Convert.ToInt32(ConTipoId2.SelectedValue));


                                    if (ConTipoId2.SelectedValue == "1")//Matricula
                                    {

                                        int cuota = 1;
                                        ocnInscripcionConcepto.Insertar(icuId2, Convert.ToInt32(dt6.Rows[0]["Id"].ToString()), Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString()), DateTime.Now, cuota, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);

                                    }
                                    else
                                    {
                                        if (ConTipoId2.SelectedValue == "2")//Cuota
                                        {
                                            int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());
                                            int cuota = 0;
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
                                                }
                                                dt.Clear();
                                                Session.Add("Datos", dt);
                                            }
                                        }
                                    }
                                    alerRepiteCurso.Visible = true;

                                    BtnGrabar.Visible = false;
                                    BtnGrabar.Enabled = false;
                                    int PageIndex = Convert.ToInt32(Session["MovimientoRepite.PageIndex"]);
                                    GrillaCargar(PageIndex);
                                }
                            }
                        }

                    }

                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "El Año de Cursado del Curso Destino debe ser el siguiente al del Curso de Origen";
                        return;
                
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

    protected void ConTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
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
            alerExito.Visible = false;
            alerError.Visible = false;
            alerRepiteCurso.Visible = false;
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



    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            //if (btnSeleccionarTodo.Text == "Desmarcar todo")
            //{
            //    foreach (GridViewRow row in GrillaAlumnos.Rows)
            //    {
            //        CheckBox check = row.FindControl("rbSelector") as CheckBox;

            //        if (check.Checked == true)
            //        {
            //            check.Checked = false;

            //        }
            //    }
            //    btnSeleccionarTodo.Text = "Seleccionar todo";
            //}
            //else
            //{
            //    foreach (GridViewRow row in GrillaAlumnos.Rows)
            //    {
            //        CheckBox check = row.FindControl("rbSelector") as CheckBox;

            //        if (check.Checked == false)
            //        {
            //            check.Checked = true;

            //        }
            //    }
            //    btnSeleccionarTodo.Text = "Desmarcar todo";
            //}

            //BtnGrabar.Enabled = true;
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

    //private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    //{
    //    //Check to ensure that the row CheckBox is clicked.
    //    if (e.RowIndex >= 0 && e.ColumnIndex == 0)
    //    {
    //        //Loop and uncheck all other CheckBoxes.
    //        foreach (DataGridViewRow row in dataGridView1.Rows)
    //        {
    //            if (row.Index == e.RowIndex)
    //            {
    //                row.Cells["checkBoxColumn"].Value = !Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue);
    //            }
    //            else
    //            {
    //                row.Cells["checkBoxColumn"].Value = false;
    //            }
    //        }
    //    }
    //}

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
