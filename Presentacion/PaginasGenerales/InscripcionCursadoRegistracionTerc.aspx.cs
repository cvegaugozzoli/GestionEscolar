using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;


public partial class InscripcionCursadoRegistracionTerc : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.EspCurrEvaluacion ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion();
    GESTIONESCOLAR.Negocio.EtapaEvaluacion ocnEtapaEvaluacion = new GESTIONESCOLAR.Negocio.EtapaEvaluacion();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();

    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.CondicionParametrosFijos ocnCondicionParametrosFijos = new GESTIONESCOLAR.Negocio.CondicionParametrosFijos();

    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    DataTable dt = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dtT = new DataTable();
    int AnioLectivo;
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                GridErrores.Visible = false;
                GrillaMaterias.Visible = false;
                GrillaMateriaConfirmar.Visible = false;
                CondicionMostrar.Visible = false;
                alerPagar.Visible = false;
                CanReg.Visible = false;
                alerAlumno.Visible = false;
                alerCarrera.Visible = false;
                alerCurso.Visible = false;
                alerConcepto.Visible = false;
                alerPlan.Visible = false;
                alerAnio.Visible = false;
                Session["Bandera"] = 0;
                lblicuId.Text = "";
                this.Master.TituloDelFormulario = " Inscripcion Cursado - Registracion";
                insId = Convert.ToInt32(Session["_Institucion"]);

                DataTable dtOBSERVACIONES = new DataTable();
                dtOBSERVACIONES.Columns.Add("lblAlumno3", typeof(String));
                dtOBSERVACIONES.Columns.Add("lblObservaciones", typeof(String));
                GridErrores.DataSource = dtOBSERVACIONES;
                GridErrores.DataBind();
                Session["OBSERVACIONES"] = dtOBSERVACIONES;

                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false; 
                    btnInscribir.Visible = false;
                }
                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("Id", typeof(int));
                dtNew.Columns.Add("Nombre", typeof(String));
                dtNew.Columns.Add("FormatoDictado", typeof(String));
                dtNew.Columns.Add("Regimen", typeof(String));
                //dtNew.Columns.Add("Condicion", typeof(String));
                Session.Add("TablaTemp", dtNew);
                DataTable dtNew2 = new DataTable();
                dtNew2.Columns.Add("escId", typeof(int));
                dtNew2.Columns.Add("Nombre", typeof(String));
                dtNew2.Columns.Add("FormatoDictado", typeof(String));
                dtNew2.Columns.Add("Regimen", typeof(String));
                //dtNew2.Columns.Add("Condicion", typeof(String));
                dtNew2.Columns.Add("Id", typeof(String));
                Session.Add("TablaMatConf", dtNew2);
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(Int32));
                dt.Columns.Add("conId", typeof(Int32));
                dt.Columns.Add("cntId", typeof(Int32));
                dt.Columns.Add("TipoConcepto", typeof(String));
                dt.Columns.Add("Concepto", typeof(String));
                dt.Columns.Add("Importe", typeof(Decimal));
                dt.Columns.Add("Beca", typeof(String));
                dt.Columns.Add("BecId", typeof(Int32));
                dt.Columns.Add("NroCuota", typeof(Int32));
                dt.Columns.Add("AnioLectivo", typeof(Int32));
                dt.Columns.Add("FchInscripcion", typeof(string));
                GrillaConcepto.DataSource = dt;
                GrillaConcepto.DataBind();
                Session["Datos"] = dt;

                int Id = 0;
                plaId.Enabled = false;
                //camId.Enabled = true;
                //escId.Enabled = true;
                //escId.Visible = true;
                Button1.Enabled = true;
                lblicuId.Text = "";
                lblicoId.Text = "";
                btnInscribir.Enabled = true;

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


                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/
                    lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                    insId = Convert.ToInt32(Session["_Institucion"]);

                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                    ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
                    CondicionId.DataValueField = "Valor"; CondicionId.DataTextField = "Texto"; CondicionId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerListaInsc("[Seleccionar...]"); CondicionId.DataBind();
                    if ((Session["_perId"].ToString() == "18" || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24"))  // Si es terciario 
                    {
                        PanelConcepto.Visible = false;
                        CondicionMostrar.Visible = true;
                        //btnNuevoAlumno.Enabled = false;
                        NivelID.SelectedValue = "4";
                        CondicionId.SelectedValue = "1";
                        NivelID.Enabled = false;
                        carId.Enabled = true;
                        DataTable dt2 = new DataTable();
                        int nivel = Convert.ToInt32(NivelID.SelectedValue);
                        dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

                        if (dt2.Rows.Count > 0)
                        {
                            carId.DataValueField = "Valor";
                            carId.DataTextField = "Texto";
                            carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                            carId.DataBind();

                        }

                    }
                    else
                    {
                        PanelConcepto.Visible = true;
                        CondicionMostrar.Visible = false;
                    }
                    if (Id != 0)
                    {

                        ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
                        this.icuAnioCursado.Text = ocnInscripcionCursado.icuAnoCursado.ToString();
                        AnioLectivo = Convert.ToInt32(ocnInscripcionCursado.icuAnoCursado.ToString());
                        this.icuFechaInscripcion.Text = ocnInscripcionCursado.icuFechaInscripcion;

                        this.icuActivo.Checked = ocnInscripcionCursado.icuActivo;
                        //this.aluId.SelectedValue = (ocnInscripcionCursado.aluId == 0 ? "" : ocnInscripcionCursado.aluId.ToString());
                        this.carId.SelectedValue = (ocnInscripcionCursado.carId == 0 ? "" : ocnInscripcionCursado.carId.ToString());
                        this.plaId.SelectedValue = (ocnInscripcionCursado.plaId == 0 ? "" : ocnInscripcionCursado.plaId.ToString());
                        this.curId.SelectedValue = (ocnInscripcionCursado.curId == 0 ? "" : ocnInscripcionCursado.curId.ToString());
                        //this.camId.SelectedValue = (ocnInscripcionCursado.camId == 0 ? "" : ocnInscripcionCursado.camId.ToString());
                        //this.escId.SelectedValue = (ocnInscripcionCursado.escId == 0 ? "" : ocnInscripcionCursado.escId.ToString());
                        if (Request.QueryString["Nombre"] != null)
                        {
                            aluNombre.Text = Request.QueryString["Nombre"];
                            aluNombre.Enabled = false;
                            //    aluLegajoNumero.Text = dt.Rows[0]["aluLegajoNumero"].ToString();
                            //    aluLegajoNumero.Enabled = false;
                            //    aluId.Text = dt.Rows[0]["aluId"].ToString();
                        }
                    }
                    else
                    {
                        icuFechaInscripcion.Text = DateTime.Today;
                        DateTime fechaActual = DateTime.Today;
                        icuAnioCursado.Text = fechaActual.Year.ToString();

                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    //this.aluId.Focus();
                    this.TextBuscar.Focus();
                }
            }

            lblMensajeError.Text = "";
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
            GridErrores.Visible = false;
            GrillaMaterias.Visible = true;
            GrillaMateriaConfirmar.Visible = true;
            CanReg.Visible = false;
            Session["InscripcionCursadoRegistracion.PageIndex"] = PageIndex;
            alerError2.Visible = false;
            alerError3.Visible = false;
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnAlumno.ObtenerTodoBuscarxNombre(TextBuscar.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
                    btnLimpiar.Visible = true;
                    btnSalir.Visible = true;
                    btnAlumno.Visible = true;
                }
                else
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = " Nombre erroneo // O no fue ingresado por administración";
                    btnLimpiar.Visible = false;
                    btnSalir.Visible = false; btnAlumno.Visible = false;
                }
            }
            else
            {
                dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
                    btnLimpiar.Visible = true;
                    btnSalir.Visible = true;
                    btnAlumno.Visible = true;
                }
                else
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = " DNI erroneo // O no fue ingresado por administración";
                    btnLimpiar.Visible = false;
                    btnSalir.Visible = false;
                    btnAlumno.Visible = false;
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
                String Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                if (e.CommandName == "Select")
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    aluNombre.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    aluNombre.Enabled = false;
                    aludni.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    aludni.Enabled = false;
                    aluId.Text = Id;
                    CanReg.Visible = false;
                    Grilla.DataSource = null;
                    Grilla.DataBind();

                    DataTable dtTraerConcepto = new DataTable();
                    dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 1, Convert.ToInt32(icuAnioCursado.Text));
                    DataTable dtConceptoPago = new DataTable();

                    if (dtTraerConcepto.Rows.Count > 0)
                    {
                        dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                    }
                    else // Me fijo si se inscribió para examen con tipo concepto 5
                    {
                        dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 5, Convert.ToInt32(icuAnioCursado.Text));
                        if (dtTraerConcepto.Rows.Count > 0)
                        {
                            dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                        }
                        else
                        {
                            alerError3.Visible = true;
                            lblError3.Text = "El alumno debe registrar el concepto de Matricula o Solo Rinde..";
                            GrillaMateriaConfirmar.DataSource = null;
                            GrillaMateriaConfirmar.DataBind();
                            GrillaMaterias.DataSource = null;
                            GrillaMaterias.DataBind();
                            btnSeleccionarTodo.Visible = false;
                            btnAgregarMateria.Visible = false;
                            tituloMateria.Visible = false;
                            TituloMaterisIns.Visible = false;
                            return;
                        }
                    }

                    if (dtConceptoPago.Rows.Count > 0)
                    {

                        if (curId.SelectedValue == "")
                        {
                            GrillaMaterias.DataSource = null;
                            GrillaMaterias.DataBind();
                            GrillaMateriaConfirmar.DataSource = null;
                            GrillaMateriaConfirmar.DataBind();
                            btnLimpiar.Visible = false;
                            btnSalir.Visible = false;
                            btnAlumno.Visible = false;
                        }
                        else
                        {
                            if (NivelID.SelectedValue == "4")
                            {
                                insId = Convert.ToInt32(Session["_Institucion"]);

                                DataTable dt = new DataTable();
                                if (Convert.ToInt32(carId.SelectedValue) != 0 & plaId.SelectedValue != "" & curId.SelectedValue != "")
                                {
                                    dt = ocnEspacioCurricular.ObtenerPorCarPorPlanporCur(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(curId.SelectedValue));
                                    if (curId.SelectedValue != "")
                                    {
                                        DataTable dtTraeEspCur = new DataTable();
                                        if (Convert.ToString(aluId.Text.Trim().ToString()) != "")
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                dtTraeEspCur = ocnInscripcionCursadoTerciario.ObtenerMateriasInsc(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                                                if (dtTraeEspCur.Rows.Count > 0)
                                                {
                                                    GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
                                                    GrillaMateriaConfirmar.DataBind();

                                                    this.GrillaMaterias.DataSource = dt;
                                                    //this.GrillaMaterias.PageIndex = PageIndex;
                                                    this.GrillaMaterias.DataBind();
                                                    btnSeleccionarTodo.Visible = true;
                                                    btnAgregarMateria.Visible = true;
                                                    tituloMateria.Visible = true;
                                                    TituloMaterisIns.Visible = true;
                                                    btnLimpiar.Visible = true;
                                                    btnSalir.Visible = true;
                                                    btnAlumno.Visible = true;
                                                }
                                                else
                                                {
                                                    GrillaMateriaConfirmar.DataSource = null;
                                                    GrillaMateriaConfirmar.DataBind();

                                                    this.GrillaMaterias.DataSource = dt;
                                                    //this.GrillaMaterias.PageIndex = PageIndex;
                                                    this.GrillaMaterias.DataBind();
                                                    btnSeleccionarTodo.Visible = true;
                                                    btnAgregarMateria.Visible = true;
                                                    tituloMateria.Visible = true;
                                                    TituloMaterisIns.Visible = true;
                                                    btnLimpiar.Visible = true;
                                                    btnSalir.Visible = true;
                                                    btnAlumno.Visible = true;
                                                }
                                                Session.Add("TablaMatConf", dtTraeEspCur);
                                            }
                                            else
                                            {
                                                this.GrillaMaterias.DataSource = null;
                                                //this.GrillaMaterias.PageIndex = PageIndex;
                                                this.GrillaMaterias.DataBind();
                                                btnSeleccionarTodo.Visible = true;
                                                btnAgregarMateria.Visible = false;
                                                tituloMateria.Visible = false;
                                                TituloMaterisIns.Visible = false;
                                                GrillaMateriaConfirmar.DataSource = null;
                                                GrillaMateriaConfirmar.DataBind();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        alerError3.Visible = true;
                        lblError3.Text = "El alumno debe pagar el concepto de Matricula..";
                        GrillaMateriaConfirmar.DataSource = null;
                        GrillaMateriaConfirmar.DataBind();
                        GrillaMaterias.DataSource = null;
                        GrillaMaterias.DataBind();
                        return;
                    }

                }
            }
            if (e.CommandName != "Page")
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


    protected void GrillaMateriaConfirmar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            alerMAteria.Visible = false;
            lblMensajeError.Text = "";
            alerMatRepe.Visible = false;
            dt.Columns.Add("escId", typeof(int));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("FormatoDictado", typeof(String));
            dt.Columns.Add("Regimen", typeof(String));
            dt.Columns.Add("Id", typeof(int));

            dt = Session["TablaMatConf"] as DataTable;
            if (Session["InscripcionCursadoRegistracion.PageIndex"] != null)
            {
                Session["InscripcionCursadoRegistracion.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("InscripcionCursadoRegistracion.PageIndex", e.NewPageIndex);
            }


            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["InscripcionCursadoRegistracion.PageIndex"]);
            GrillaMateriaConfirmar.DataSource = dt;
            this.GrillaMateriaConfirmar.PageIndex = PageIndex;
            this.GrillaMateriaConfirmar.DataBind();

            //GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
            //this.Grilla.PageIndex = Convert.ToInt32(Session["InscripcionCursadoRegistracion.PageIndex"]);
            //GrillaMateriaConfirmar.DataBind();              

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


    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["InscripcionCursadoRegistracion.PageIndex"] != null)
            {
                Session["InscripcionCursadoRegistracion.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("InscripcionCursadoRegistracion.PageIndex", e.NewPageIndex);
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
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        alerErrorConcepto.Visible = false;
        alerError2.Visible = false;
        alerError3.Visible = false;
        lblicuId.Text = "";
        alerPagar.Visible = false;
        alerErrorInsc.Visible = false;
        alerConceptoyaIngresado.Visible = false;
        CanReg.Visible = false;
        alerInscripción2.Visible = false;
        alerInscripción.Visible = false;
        alerAlumno.Visible = false;
        alerCarrera.Visible = false;
        alerCurso.Visible = false;
        alerConcepto.Visible = false;
        alerPlan.Visible = false;
        alerAnio.Visible = false;
        GrillaConcepto.DataSource = null;
        Grilla.DataSource = null;
        Grilla.DataBind();

        GrillaConcepto.DataBind();
        aluNombre.Text = "";
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["IncripcionCursadoConsulta.PageIndex"]);
        GrillaCargar(PageIndex);
        //this.ConceptoId.SelectedValue = "";
        //this.BecaId.SelectedValue = "";

    }

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

        //CheckBox chk = (CheckBox)sender;
        //GridViewRow gv = (GridViewRow)chk.NamingContainer;
        //int rownumber = gv.RowIndex;

        //if (chk.Checked)
        //{
        //    int i;
        //    for (i = 0; i <= GrillaMaterias.Rows.Count - 1; i++)
        //    {
        //        if (i != rownumber)
        //        {
        //            CheckBox chkcheckbox = ((CheckBox)(GrillaMaterias.Rows[i].FindControl("chkSeleccion2")));
        //            chkcheckbox.Checked = false;
        //        }
        //    }
        //}
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in Grilla.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(Grilla, "Select$" + row.RowIndex, true);
            }
        }
        foreach (GridViewRow row in GrillaConcepto.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";

            }
        }

        foreach (GridViewRow row in GridErrores.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";

            }
        }
        foreach (GridViewRow row in GrillaMateriaConfirmar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";

            }
        }
        foreach (GridViewRow row in GrillaMaterias.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";

            }
        }
        base.Render(writer);
    }

    protected void btnCancelar2_Click(object sender, EventArgs e)
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

    //    protected void btnInscribir_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            alerErrorConcepto.Visible = false;
    //            alerConceptoyaRegistrado.Visible = false;
    //            alerConceptoyaRegistrado2.Visible = false;
    //            int ban = 0;
    //            CanReg.Visible = false;
    //            alerConceptoyaIngresado.Visible = false;
    //            alerCarrera.Visible = false;
    //            alerInscripción2.Visible = false;
    //            alerInscripción.Visible = false;
    //            alerRepetido.Visible = false;
    //            alerAlumno.Visible = false;
    //            alerCarrera.Visible = false;
    //            alerCurso.Visible = false;
    //            alerConcepto.Visible = false;
    //            alerPagar.Visible = false;
    //            alerPlan.Visible = false;
    //            alerAnio.Visible = false;
    //            alerErrorInsc.Visible = false;
    //            alerError2.Visible = false;
    //            dt = new DataTable();
    //            insId = Convert.ToInt32(Session["_Institucion"]);
    //            lblMensajeError.Visible = false;
    //            string MensajeValidacion = "";
    //            if (aludni.Text.Trim() == "")
    //            {
    //                alerAlumno.Visible = true;
    //                return;
    //            }
    //            if (Convert.ToInt32(NivelID.SelectedValue) != 0)
    //            {
    //                if (Convert.ToInt32(NivelID.SelectedValue) == 4)
    //                {
    //                    if (Convert.ToInt32(carId.SelectedValue) <= 0)
    //                    {
    //                        alerCarrera.Visible = true;
    //                        return;
    //                    }
    //                    else
    //                    {

    //                        if (Convert.ToInt32(plaId.SelectedValue) <= 0)
    //                        {
    //                            alerPlan.Visible = true;
    //                            return;
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                alerNivel.Visible = true;
    //                return;
    //            }

    //            if (Convert.ToInt32(curId.SelectedValue) <= 0)
    //            {
    //                alerCurso.Visible = true;
    //                return;
    //            }

    //            if (Convert.ToInt32(NivelID.SelectedValue) == 4)

    //            {
    //                if (GrillaMateriaConfirmar.Rows.Count <= 0)
    //                {
    //                    alerEspCur.Visible = true;
    //                    return;
    //                }
    //            }

    //            if (icuAnioCursado.Text.Trim() == "")
    //            {
    //                alerAnio.Visible = true;
    //                return;
    //            }

    //            int ControlFaltaCorrelativa = 0;
    //            int ControlExiste = 0;
    //            int Id = 0;
    //            if (Request.QueryString["Id"] != null)
    //            {
    //                //SI el alumno es nuevo lo doy de alta si no existe en alumno..  leo el aluId.. 
    //                if (aluId.Text.Trim() == "")
    //                {
    //                    DataTable dt2 = new DataTable();
    //                    dt2 = ocnAlumno.ObtenerUnoporDoc(aludni.Text);
    //                    if (dt2.Rows.Count == 0)//Alumno no existe
    //                    {

    //                        // DEBE EXISTIR PARA TENER EL CONCEPTO DE PREINSCRIPCION


    //                        //ocnAlumno.aluDoc = aludni.Text;
    //                        //ocnAlumno.aluNombre = aluNombre.Text;
    //                        //ocnAlumno.aluLegajoNumero = "";
    //                        //ocnAlumno.aluCuit = "";
    //                        //ocnAlumno.aluDomicilio = "";
    //                        //ocnAlumno.aluDepto = 0;
    //                        ////ocnAlumno.aluFechaNacimiento = Convert.ToDateTime("");
    //                        //ocnAlumno.aluPaisNac = 0;
    //                        //ocnAlumno.aluProvNac = 0;
    //                        //ocnAlumno.aluDeptoNac = 0;
    //                        //ocnAlumno.aluLocNac = 0;
    //                        //ocnAlumno.aluMail = "";
    //                        //ocnAlumno.aluTelefono = "";
    //                        //ocnAlumno.aluTelefonoCel = "";
    //                        //ocnAlumno.aluActivo = true;
    //                        //ocnAlumno.sexId = 0;
    //                        ////                this.sexId.SelectedValue = (ocnAlumno.sexId == 0 ? "" : ocnAlumno.sexId.ToString());

    //                        //ocnAlumno.aluFechaHoraCreacion = DateTime.Now;
    //                        //ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
    //                        //ocnAlumno.usuIdCreacion = this.Master.usuId;
    //                        //ocnAlumno.usuIdUltimaModificacion = this.Master.usuId;
    //                        //ocnAlumno.gsaId = 0;
    //                        //ocnAlumno.aluTelUrgencias = "";
    //                        //ocnAlumno.aluDomFliar = "";
    //                        //ocnAlumno.aluPreg1 = "";
    //                        //ocnAlumno.aluPreg2 = "";
    //                        //ocnAlumno.aluPreg3 = "";
    //                        //ocnAlumno.aluPreg4 = "";
    //                        //ocnAlumno.aluPreg5 = "";
    //                        //ocnAlumno.aluPreg6 = "";
    //                        //ocnAlumno.aluPreg7 = "";
    //                        //ocnAlumno.aluAclara = "";
    //                        ////Nuevo
    //                        //int aluId2 = ocnAlumno.Insertar();
    //                        //DataTable dt7 = new DataTable();
    //                        ////dt7 = ocnAlumno.ObtenerUltimoId();
    //                        ////if (dt7.Rows.Count > 0)
    //                        ////{
    //                        //aluId.Text = Convert.ToString(aluId2);
    //                        //}

    //                    alerError

    //                    }
    //                    else //Alumno existe
    //                    {
    //                        this.aluId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
    //                        ban = 1;

    //                    }
    //                }
    //                if (Convert.ToInt32(NivelID.SelectedValue) == 4) //Terciario
    //                {
    //                    int Band = 0;
    //                    DataTable dtDatos2 = new DataTable();
    //                    dtDatos2 = Session["Datos"] as DataTable;
    //                    if (dtDatos2.Rows.Count > 0)
    //                    {
    //                        int icuId = Convert.ToInt32(lblicuId.Text);
    //                        foreach (DataRow row in dtDatos2.Rows)
    //                        {
    //                            int conId = Convert.ToInt32(row["conId"].ToString());
    //                            Decimal Importe = Convert.ToDecimal(row["Importe"].ToString());
    //                            DateTime FchaInscripcion = Convert.ToDateTime(row["FchInscripcion"].ToString());
    //                            Int32 NroCuota = Convert.ToInt32(row["NroCuota"].ToString());
    //                            Int32 bcaId = Convert.ToInt32(row["BecId"].ToString());
    //                            DataTable dt5 = new DataTable();
    //                            dt5 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(icuId, conId, NroCuota);
    //                            if (dt5.Rows.Count == 0)//  No se repite concepto
    //                            {
    //                                ocnInscripcionConcepto.Insertar(icuId, conId, Importe, FchaInscripcion, NroCuota, bcaId, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
    //                                Band = 1;
    //                            }
    //                        }
    //                        if (Band == 1)
    //                        {
    //                            btnAgregar.Enabled = false;
    //                            ConTipoId.Enabled = false;
    //                            ConceptoId.Enabled = false;
    //                            BecaId.Enabled = false;
    //                            btnPagar.Enabled = true;
    //                            btnInscribir.Enabled = false;
    //                            alerInscripción.Visible = true;
    //                            GrillaConcepto.Columns[0].Visible = true;
    //                            alerPagar.Visible = true;

    //                        }
    //                        else
    //                        {
    //                            alerRepetido.Visible = true;
    //                        }

    //                        //Response.Redirect("InscripcionCursadoConsulta.aspx", true);
    //                    }
    //                    else
    //                    {
    //                        if (ControlExiste != 0)
    //                        {
    //                            alerErrorInsc.Visible = true;
    //                        }
    //                    }
    //                }



    //                else  ///Si no es Terciario Controlo que el alumno no se encuentre inscripto en ese curso en ese año
    //                {
    //                    DataTable dt2 = new DataTable();
    //                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text.Trim().ToString()));
    //                    if (dt2.Rows.Count > 0)
    //                    {
    //                        ControlExiste = 1;
    //                        lblicuId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
    //                    }
    //                    if (ControlExiste == 0)// Sino fué cargada anteriormente
    //                    {
    //                        int carIdO = 0;
    //                        int plaIdO = 0;
    //                        Id = Convert.ToInt32(Request.QueryString["Id"]);
    //                        ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
    //                        ocnInscripcionCursado.insId = insId;
    //                        ocnInscripcionCursado.icuAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
    //                        AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
    //                        ocnInscripcionCursado.icuFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
    //                        ocnInscripcionCursado.icuActivo = icuActivo.Checked;
    //                        //String alumnoId = aluId.Text
    //                        ocnInscripcionCursado.aluId = Convert.ToInt32(aluId.Text);
    //                        ocnInscripcionCursado.icuEstado = 1;
    //                        DataTable dt3 = new DataTable();
    //                        DataTable dt4 = new DataTable();
    //                        dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
    //                        carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
    //                        dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
    //                        plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
    //                        ocnInscripcionCursado.carId = carIdO;
    //                        ocnInscripcionCursado.plaId = plaIdO;
    //                        ocnInscripcionCursado.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
    //                        //ocnInscripcionCursado.camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
    //                        //ocnInscripcionCursado.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue));
    //                        /*....usuId = this.Master.usuId;*/
    //                        ocnInscripcionCursado.icuFechaHoraCreacion = DateTime.Now;
    //                        ocnInscripcionCursado.icuFechaHoraUltimaModificacion = DateTime.Now;
    //                        ocnInscripcionCursado.usuIdCreacion = this.Master.usuId;
    //                        ocnInscripcionCursado.usuIdUltimaModificacion = this.Master.usuId;
    //                        ocnInscripcionCursado.icuInsConfirmar = 1;
    //                        int icuId = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
    //                        lblicuId.Text = Convert.ToString(icuId);
    //                        alerInscripción2.Visible = true;
    //                        //////////////////////////////////////////////////////

    //                        //if (((Convert.ToInt32(NivelID.SelectedValue) == 3) || (Convert.ToInt32(NivelID.SelectedValue) == 2)))//Si es Secundario o Primario
    //                        //{
    //                        //    //recorro una tabla d materias para registrar nota por esp cur
    //                        //    DataTable dt5 = new DataTable();
    //                        //    DataTable dt6 = new DataTable();
    //                        //    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId.SelectedValue), insId);
    //                        //    if (dt5.Rows.Count > 0)
    //                        //    {
    //                        //        // Por Cada Materia inserto un registro Nota para ese alumno.
    //                        //        foreach (DataRow row in dt5.Rows)
    //                        //        {
    //                        //            int escId2 = Convert.ToInt32(row["Id"].ToString());
    //                        //            dt6 = ocnEtapaEvaluacion.ObtenerTodoxtcaId(Convert.ToInt32(NivelID.SelectedValue));
    //                        //            if (dt6.Rows.Count > 0)
    //                        //            {
    //                        //                foreach (DataRow row2 in dt6.Rows)
    //                        //                {
    //                        //                    int Id2 = 0;
    //                        //                    ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota(Id2);
    //                        //                    ocnRegistracionNota.icuId = icuId;
    //                        //                    ocnRegistracionNota.escId = escId2;
    //                        //                    ocnRegistracionNota.etaId = Convert.ToInt32(row2["etaId"].ToString());
    //                        //                    ocnRegistracionNota.renNota = "";
    //                        //                    ocnRegistracionNota.renObservaciones = "";
    //                        //                    ocnRegistracionNota.renActivo = true;
    //                        //                    ocnRegistracionNota.usuIdCreacion = this.Master.usuId;
    //                        //                    ocnRegistracionNota.usuIdUltimaModificacion = this.Master.usuId;
    //                        //                    ocnRegistracionNota.renFechaHoraCreacion = DateTime.Now;
    //                        //                    ocnRegistracionNota.renFechaHoraUltimaModificacion = DateTime.Now;
    //                        //                    Int32 renIdNew = ocnRegistracionNota.Insertar();
    //                        //                }
    //                        //            }
    //                        //        }
    //                        //    }

    //                        //    DataTable dtDatos = new DataTable();
    //                        //    dtDatos = Session["Datos"] as DataTable;
    //                        //    if (dtDatos.Rows.Count > 0)
    //                        //    {
    //                        //        foreach (DataRow row in dtDatos.Rows)
    //                        //        {
    //                        //            int conId = Convert.ToInt32(row["conId"].ToString());
    //                        //            Decimal Importe = Convert.ToDecimal(row["Importe"].ToString());
    //                        //            DateTime FchaInscripcion = Convert.ToDateTime(row["FchInscripcion"].ToString());
    //                        //            Int32 NroCuota = Convert.ToInt32(row["NroCuota"].ToString());
    //                        //            Int32 bcaId = Convert.ToInt32(row["BecId"].ToString());

    //                        //            ocnInscripcionConcepto.Insertar(icuId, conId, Importe, FchaInscripcion, NroCuota, bcaId, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
    //                        //        }

    //                        //        btnAgregar.Enabled = false;
    //                        //        ConTipoId.Enabled = false;
    //                        //        ConceptoId.Enabled = false;
    //                        //        BecaId.Enabled = false;
    //                        //        btnPagar.Enabled = true;
    //                        //        btnInscribir.Enabled = false;
    //                        //        GrillaConcepto.Columns[0].Visible = true;
    //                        //        alerPagar.Visible = true;
    //                        //        alerInscripción.Visible = true;
    //                        //    }
    //                        //}
    //                    }
    //                    else //existe Inscripción Cursado
    //                    {
    //                        int Band = 0;
    //                        DataTable dtDatos2 = new DataTable();
    //                        dtDatos2 = Session["Datos"] as DataTable;
    //                        if (dtDatos2.Rows.Count > 0)
    //                        {
    //                            int icuId = Convert.ToInt32(lblicuId.Text);
    //                            foreach (DataRow row in dtDatos2.Rows)
    //                            {
    //                                int conId = Convert.ToInt32(row["conId"].ToString());
    //                                Decimal Importe = Convert.ToDecimal(row["Importe"].ToString());
    //                                DateTime FchaInscripcion = Convert.ToDateTime(row["FchInscripcion"].ToString());
    //                                Int32 NroCuota = Convert.ToInt32(row["NroCuota"].ToString());
    //                                Int32 bcaId = Convert.ToInt32(row["BecId"].ToString());
    //                                DataTable dt5 = new DataTable();
    //                                dt5 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(icuId, conId, NroCuota);
    //                                if (dt5.Rows.Count == 0)//  No se repite concepto
    //                                {
    //                                    ocnInscripcionConcepto.Insertar(icuId, conId, Importe, FchaInscripcion, NroCuota, bcaId, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
    //                                    Band = 1;
    //                                }
    //                            }
    //                            if (Band == 1)
    //                            {
    //                                btnAgregar.Enabled = false;
    //                                ConTipoId.Enabled = false;
    //                                ConceptoId.Enabled = false;
    //                                BecaId.Enabled = false;
    //                                btnPagar.Enabled = true;
    //                                btnInscribir.Enabled = false;
    //                                alerInscripción.Visible = true;
    //                                GrillaConcepto.Columns[0].Visible = true;
    //                                alerPagar.Visible = true;

    //                            }
    //                            else
    //                            {
    //                                alerRepetido.Visible = true;
    //                            }

    //                            //Response.Redirect("InscripcionCursadoConsulta.aspx", true);
    //                        }
    //                        else
    //                        {
    //                            if (ControlExiste != 0)
    //                            {
    //                                alerErrorInsc.Visible = true;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button  aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }
    //    }

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError2.Visible = false;
        if (aluId.Text == "")
        {
            alerError2.Visible = true;
            lblError2.Text = "Debe ingresar un alumno..";
            return;
        }

        DataTable dt = new DataTable(); DataTable dtAlumnCarrera = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dtAlumnCarrera = ocnInscripcionCursado.ObtenexCarIdxAluId(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(aluId.Text));
        dt = ocnPlanEstudio.ObtenerUltxCarId(Convert.ToInt32(carId.SelectedValue));
        if (dt.Rows.Count > 0)
        {
            if (dtAlumnCarrera.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                plaId.DataBind();
                plaId.SelectedValue = Convert.ToString(dt.Rows[0]["Id"]);
                plaId.Enabled = false;

                dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    curId.DataValueField = "Valor";
                    curId.DataTextField = "Texto";
                    curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                    curId.DataBind();
                }

            }
            else
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                plaId.DataBind();
                plaId.SelectedValue = Convert.ToString(dt.Rows[0]["Id"]);
                plaId.Enabled = false;


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
        else
        {
            alerError2.Visible = true;
            lblError2.Text = "No hay planes para esa Carrera";
        }
    }


    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (plaId.SelectedIndex != 0)
        {
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

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridErrores.Visible = false;
        alerError.Visible = false;
        alerError3.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        int icuIdTraer = 0;
        if (NivelID.SelectedValue == "4")
        {
            insId = Convert.ToInt32(Session["_Institucion"]);

            DataTable dt2 = new DataTable();

            //dt2 = ocnInscripcionCursado.ControlCursoExisteTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
            //if (dt2.Rows.Count > 0) // YA SE INSCRIBIO EN ESE CURSO???
            //{
            //    icuIdTraer = Convert.ToInt32(dt2.Rows[0]["Id"]);
            //}
            //else
            //{
            //    alerError3.Visible = true;
            //    lblError3.Text = "El alumno se debe registrar por secretaria para realizar el pago de Matricula..";
            //    return;
            //}

            DataTable dtTraerConcepto = new DataTable();
            dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 1, Convert.ToInt32(icuAnioCursado.Text));
            DataTable dtConceptoPago = new DataTable();

            if (dtTraerConcepto.Rows.Count > 0)
            {
                dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
            }
            else // Me fijo si se inscribió para examen con tipo concepto 5
            {
                dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 5, Convert.ToInt32(icuAnioCursado.Text));
                if (dtTraerConcepto.Rows.Count > 0)
                {
                    dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                    alerError3.Visible = true;
                    lblError3.Text = "Tener en cuenta que el alumno registró el concepto de Solo Rinde..";
                }
                else
                {
                    alerError3.Visible = true;
                    lblError3.Text = "El alumno debe registrar el concepto de Matricula o Solo Rinde..";
                    GrillaMateriaConfirmar.DataSource = null;
                    GrillaMateriaConfirmar.DataBind();
                    GrillaMaterias.DataSource = null;
                    GrillaMaterias.DataBind();
                    btnSeleccionarTodo.Visible = false;
                    btnAgregarMateria.Visible = false;
                    tituloMateria.Visible = false;
                    TituloMaterisIns.Visible = false;
                    return;
                }
            }


            if (dtConceptoPago.Rows.Count > 0)
            {

                DataTable dt = new DataTable();
                if (Convert.ToInt32(carId.SelectedValue) != 0 & plaId.SelectedValue != "" & curId.SelectedValue != "")
                {

                    if (Convert.ToInt32(carId.SelectedValue) == 20)
                    {

                        DataTable dtInsCurTraer = new DataTable();
                        dtInsCurTraer = ocnInscripcionCursado.ControlCursoExisteTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));


                        if (dtInsCurTraer.Rows.Count == 0)
                        {
                            alerError3.Visible = true;
                            lblError3.Text = "No esta registrado en este curso.. Verifique que el alumno no esté en otra división..";

                        }
                        else
                        {

                        }
                    }
                    dt = ocnEspacioCurricular.ObtenerPorCarPorPlanporCur(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(curId.SelectedValue));
                    if (curId.SelectedValue != "")
                    {
                        DataTable dtTraeEspCur = new DataTable();
                        if (Convert.ToString(aluId.Text.Trim().ToString()) != "")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                dtTraeEspCur = ocnInscripcionCursadoTerciario.ObtenerMateriasInsc(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                                if (dtTraeEspCur.Rows.Count > 0)
                                {
                                    GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
                                    GrillaMateriaConfirmar.DataBind();

                                    this.GrillaMaterias.DataSource = dt;
                                    //this.GrillaMaterias.PageIndex = PageIndex;
                                    this.GrillaMaterias.DataBind();
                                    btnSeleccionarTodo.Visible = true;
                                    btnAgregarMateria.Visible = true;
                                    tituloMateria.Visible = true;
                                    TituloMaterisIns.Visible = true;
                                    btnLimpiar.Visible = true;
                                    btnSalir.Visible = true;
                                    btnAlumno.Visible = true;
                                }
                                else
                                {
                                    GrillaMateriaConfirmar.DataSource = null;
                                    GrillaMateriaConfirmar.DataBind();

                                    this.GrillaMaterias.DataSource = dt;
                                    //this.GrillaMaterias.PageIndex = PageIndex;
                                    this.GrillaMaterias.DataBind();
                                    btnSeleccionarTodo.Visible = true;
                                    btnAgregarMateria.Visible = true;
                                    tituloMateria.Visible = true;
                                    TituloMaterisIns.Visible = true;
                                    btnLimpiar.Visible = true;
                                    btnSalir.Visible = true;
                                    btnAlumno.Visible = true;
                                }
                                Session.Add("TablaMatConf", dtTraeEspCur);
                            }
                            else
                            {
                                this.GrillaMaterias.DataSource = null;
                                //this.GrillaMaterias.PageIndex = PageIndex;
                                this.GrillaMaterias.DataBind();
                                btnSeleccionarTodo.Visible = true;
                                btnAgregarMateria.Visible = false;
                                tituloMateria.Visible = false;
                                TituloMaterisIns.Visible = false;
                                btnLimpiar.Visible = false;
                                btnSalir.Visible = false;
                                btnAlumno.Visible = false;

                                GrillaMateriaConfirmar.DataSource = null;
                                GrillaMateriaConfirmar.DataBind();
                            }
                        }
                    }
                }
            }
            else
            {
                alerError3.Visible = true;
                lblError3.Text = "El alumno no pagó el concepto de Matricula..";
                return;
            }
        }
    }


    protected void btnNuevoAlumno_Click(object sender, EventArgs e)
    {
        alerErrorConcepto.Visible = false;

        alerConceptoyaRegistrado.Visible = false;
        lblicuId.Text = "";
        lblicoId.Text = "";
        aluNombre.Text = "";
        aluId.Text = "";
        alerPagar.Visible = false;
        alerErrorInsc.Visible = false;
        btnAgregar.Enabled = true;
        ConTipoId.Enabled = true;
        ConceptoId.Enabled = true;
        NivelID.DataSource = null; NivelID.DataBind();
        carId.Enabled = false;
        plaId.Enabled = false;
        BecaId.Enabled = true;
        btnPagar.Enabled = false;
        btnInscribir.Enabled = true;
        ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
        ConceptoId.DataSource = null; ConceptoId.DataBind();
        BecaId.DataSource = null; BecaId.DataBind();
        CanReg.Visible = false;
        alerInscripción2.Visible = false;
        alerInscripción.Visible = false;
        alerAlumno.Visible = false;
        alerCarrera.Visible = false;
        alerCurso.Visible = false;
        alerConcepto.Visible = false;
        alerPlan.Visible = false;
        alerAnio.Visible = false;
        alerConceptoyaIngresado.Visible = false;
        aluNombre.Text = "";
        aluNombre.Enabled = true;
        //aluLegajoNumero.Text = "";
        //aluLegajoNumero.Enabled = true;
        aluId.Text = "";
        //Button1.Enabled = false;
        aludni.Text = "";
        aludni.Enabled = true;
        carId.SelectedValue = "0";
        NivelID.SelectedValue = "0";
        plaId.SelectedValue = "0";
        curId.SelectedValue = "0";
        //camId.SelectedValue = "0";
        //escId.SelectedValue = "0";
        TextBuscar.Text = "";
        aludni.Focus();
        GrillaConcepto.DataSource = null;
        GrillaConcepto.DataBind();

        ConceptoId.Items.Clear();
        BecaId.Items.Clear();
    }

    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
    {
        alerErrorConcepto.Visible = false;

        aluNombre.Text = "";
        aluNombre.Enabled = false;
        //aluLegajoNumero.Text = "";
        //aluLegajoNumero.Enabled = false;
        aluId.Text = "";
        aludni.Text = "";
        //btnBuscar.Enabled = true;
        //btnNuevoAlumno.Enabled = true;
        Button1.Enabled = true;
        carId.SelectedValue = "0";
        plaId.SelectedValue = "0";
        curId.SelectedValue = "0";
        //camId.SelectedValue = "0";
        //escId.SelectedValue = "0";
        aludni.Focus();
    }

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ban;
        if (RbtBuscar.SelectedIndex == 1) //la busqueda será por familiar
        {
            ban = 1;
        }
        else
        {
            ban = 0;// la busqueda será por Hermano
        }
        Session["Bandera"] = ban;
        aludni.Text = "";
        aluNombre.Text = "";
        TextBuscar.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            alerErrorConcepto.Visible = false;
            alerConceptoyaRegistrado.Visible = false;
            alerConceptoyaIngresado.Visible = false;
            alerAlumno.Visible = false;
            alerErrorInsc.Visible = false;
            alerCarrera.Visible = false;
            alerCurso.Visible = false;
            alerConcepto.Visible = false;
            alerPlan.Visible = false;
            alerAnio.Visible = false;
            alerNivel.Visible = false;
            if (aludni.Text.Trim() == "")
            {
                alerAlumno.Visible = true;
                return;
            }

            if (Convert.ToInt32(NivelID.SelectedValue) != 0)
            {
                if (Convert.ToInt32(NivelID.SelectedValue) == 4)
                {
                    if (Convert.ToInt32(carId.SelectedValue) <= 0)
                    {
                        alerCarrera.Visible = true;
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt32(plaId.SelectedValue) <= 0)
                        {
                            alerPlan.Visible = true;
                            return;
                        }
                    }
                }
            }
            else
            {
                alerNivel.Visible = true;
                return;
            }

            if (Convert.ToInt32(curId.SelectedValue) <= 0)
            {
                alerCurso.Visible = true;
                return;
            }

            if (icuAnioCursado.Text.Trim() == "")
            {
                alerAnio.Visible = true;
                return;
            }
            if (Convert.ToInt32(ConceptoId.SelectedValue) <= 0)
            {
                alerConcepto.Visible = true;
                return;
            }
            DataTable dt = new DataTable();
            dt = Session["Datos"] as DataTable;
            DataTable dt1 = new DataTable();
            DataTable dt3 = new DataTable();

            dt3 = ocnInscripcionCursado.ObtenerUnoxDnixCursxAnio(insId, aludni.Text, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text.Trim()));

            if (dt3.Rows.Count > 0)//El alumno ya esta inscripto en ese curso
            {
                lblicuId.Text = Convert.ToString(dt3.Rows[0]["Id"]);
                if (ConceptoId.SelectedValue != "")
                {
                    DataTable dt7 = new DataTable();
                    if (ConTipoId.SelectedValue == "1")
                    {
                        dt7 = ocnInscripcionConcepto.ObtenerUnoxicuIdxconId(Convert.ToInt32(lblicuId.Text), Convert.ToInt32(ConceptoId.SelectedValue));
                        if (dt7.Rows.Count > 0) //ya existe ese concepto en Inscripción Concepto
                        {
                            alerConceptoyaRegistrado.Visible = true;
                            return;
                        }
                        else//no existe ese concepto en Inscripción Concepto
                        {
                            DataTable dt6 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId.SelectedValue));
                            DataTable dt4 = ocnBecas.ObtenerUno(Convert.ToInt32(BecaId.SelectedValue));
                            DataTable dt5 = ocnConceptosTipos.ObtenerUno(Convert.ToInt32(ConTipoId.SelectedValue));
                            int Estado = 0;
                            //DataTable dt = new DataTable();
                            //dt = Session["Datos"] as DataTable;
                            if (dt.Rows.Count > 0)//chequeo que no haya ingresado ese concepto..
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (Convert.ToInt32(row["Id"].ToString()) == 1)
                                    {
                                        if ((Convert.ToInt32(row["cntId"].ToString()) == 1))
                                        {
                                            Estado = 1;
                                        }
                                    }
                                }
                            }
                            if (Estado == 0)
                            {
                                DataRow row1 = dt.NewRow();
                                int cuota = 1;
                                row1["Id"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                                row1["conId"] = Convert.ToInt32(dt6.Rows[0]["conId"].ToString());
                                row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                row1["TipoConcepto"] = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Nombre"].ToString());
                                row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                row1["BecId"] = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                                row1["Beca"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                row1["FchInscripcion"] = Convert.ToString(icuFechaInscripcion.Text);
                                row1["NroCuota"] = cuota;
                                dt.Rows.Add(row1);
                            }
                            else
                            {
                                alerConceptoyaIngresado.Visible = true;
                            }
                        }
                    }
                    else // !=1
                    {
                        if (ConTipoId.SelectedValue == "2")//Cuotas
                        {
                            if (CuotaId.SelectedValue != "0")// eligio una cuota
                            {
                                dt7 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(Convert.ToInt32(lblicuId.Text), Convert.ToInt32(ConceptoId.SelectedValue), Convert.ToInt32(CuotaId.SelectedValue));
                                if (dt7.Rows.Count > 0) //ya existe ese concepto en Inscripción Concepto
                                {
                                    alerConceptoyaRegistrado.Visible = true;
                                    return;
                                }
                            }
                            else//eligio todas las cuotas
                            {
                                DataTable dt8 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId.SelectedValue));
                                int cantCuotas = Convert.ToInt32(dt8.Rows[0]["CantCuotas"].ToString());
                                int cantCon = 0;
                                for (int i = 1; i <= cantCuotas; i++) //Para cada cuota
                                {
                                    dt7 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(Convert.ToInt32(lblicuId.Text), Convert.ToInt32(ConceptoId.SelectedValue), i);
                                    if (dt7.Rows.Count > 0) //ya existe ese concepto en Inscripción Concepto
                                    {
                                        cantCon = cantCon + 1;
                                    }
                                }
                                if (cantCon == cantCuotas)
                                {
                                    alerConceptoyaRegistrado.Visible = true;
                                    return;
                                }
                                else
                                {
                                    if (cantCon != 0)
                                    {
                                        alerConceptoyaRegistrado2.Visible = true;
                                    }
                                }
                            }


                            DataTable dt6 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId.SelectedValue));
                            DataTable dt4 = ocnBecas.ObtenerUno(Convert.ToInt32(BecaId.SelectedValue));
                            DataTable dt5 = ocnConceptosTipos.ObtenerUno(Convert.ToInt32(ConTipoId.SelectedValue));
                            int Estado = 0;
                            //DataTable dt = new DataTable();
                            //dt = Session["Datos"] as DataTable;

                            if (dt.Rows.Count > 0)//chequeo que no haya ingresado ese concepto en tabla..
                            {
                                if (CuotaId.SelectedValue != "0")
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (Convert.ToInt32(row["NroCuota"].ToString()) == (Convert.ToInt32(CuotaId.SelectedValue)))
                                        {
                                            if ((Convert.ToInt32(row["cntId"].ToString()) == 2))
                                            {
                                                Estado = 1;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        for (int i = 0; i <= cantCuotas; i++) //Para cada cuota
                                        {//ojo matricula tiene cuota 1
                                            if (Convert.ToInt32(row["NroCuota"].ToString()) == i)
                                            {
                                                if ((Convert.ToInt32(row["cntId"].ToString()) == 2))
                                                {
                                                    Estado = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (Estado == 0)//no existe ese concepto en tabla
                            {
                                if (CuotaId.SelectedValue == "0")
                                {
                                    int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());
                                    int cuota = 0;
                                    for (int i = 1; i <= cantCuotas; i++) //Para cada cuota
                                    {
                                        dt7 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(Convert.ToInt32(lblicuId.Text), Convert.ToInt32(ConceptoId.SelectedValue), i);
                                        if (dt7.Rows.Count == 0) //ya existe ese concepto en Inscripción Concepto
                                        {
                                            DataRow row1 = dt.NewRow();
                                            row1["Id"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                                            row1["conId"] = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                            row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                            row1["TipoConcepto"] = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                            row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Nombre"].ToString());
                                            row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                            row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                            row1["BecId"] = Convert.ToDecimal(dt4.Rows[0]["Id"].ToString());
                                            row1["Beca"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                            row1["FchInscripcion"] = Convert.ToString(icuFechaInscripcion.Text);
                                            row1["NroCuota"] = i;
                                            dt.Rows.Add(row1);
                                        }
                                    }
                                }
                                else//eligio cuota
                                {
                                    DataRow row1 = dt.NewRow();
                                    row1["Id"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                                    row1["conId"] = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                    row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                    row1["TipoConcepto"] = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                    row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Nombre"].ToString());
                                    row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                    row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                    row1["BecId"] = Convert.ToDecimal(dt4.Rows[0]["Id"].ToString());
                                    row1["Beca"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                    row1["FchInscripcion"] = Convert.ToString(icuFechaInscripcion.Text);
                                    row1["NroCuota"] = Convert.ToInt32(CuotaId.SelectedValue);
                                    dt.Rows.Add(row1);
                                }
                            }
                            else
                            {
                                alerConceptoyaIngresado.Visible = true;
                            }
                        }
                    }
                    Session.Add("Datos", dt);
                    dt1 = Session["Datos"] as DataTable;
                    GrillaConcepto.DataSource = dt1;
                    lblCantidadRegistros2.Visible = true;
                    GrillaConcepto.DataBind();
                    btnInscribir.Focus();
                }
                else
                {
                    alerConcepto.Visible = true;
                    return;
                }
            }

            else//Alumno Nuevo para ese curso
            {
                if (ConceptoId.SelectedValue != "")
                {
                    DataTable dt6 = ocnConceptos.ObtenerUno(Convert.ToInt32(ConceptoId.SelectedValue));
                    DataTable dt4 = ocnBecas.ObtenerUno(Convert.ToInt32(BecaId.SelectedValue));
                    DataTable dt5 = ocnConceptosTipos.ObtenerUno(Convert.ToInt32(ConTipoId.SelectedValue));
                    int Estado = 0;

                    if (ConTipoId.SelectedValue == "1")
                    {
                        if (dt.Rows.Count > 0)//chequeo que no haya ingresado ese concepto en la tabla..
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (Convert.ToInt32(row["Id"].ToString()) == 1)
                                {
                                    if ((Convert.ToInt32(row["cntId"].ToString()) == 1))
                                    {
                                        Estado = 1;
                                    }
                                }
                            }
                        }
                        if (Estado == 0)
                        {
                            DataRow row1 = dt.NewRow();
                            int cuota = 1;
                            row1["Id"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                            row1["conId"] = Convert.ToInt32(dt6.Rows[0]["conId"].ToString());
                            row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                            row1["TipoConcepto"] = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                            row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Nombre"].ToString());
                            row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                            row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                            row1["BecId"] = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                            row1["Beca"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                            row1["FchInscripcion"] = Convert.ToString(icuFechaInscripcion.Text);
                            row1["NroCuota"] = cuota;
                            dt.Rows.Add(row1);
                        }
                        else
                        {
                            alerConceptoyaIngresado.Visible = true;
                        }
                    }
                    else //!=1
                    {
                        if (ConTipoId.SelectedValue == "2")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (CuotaId.SelectedValue != "0")
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (Convert.ToInt32(row["NroCuota"].ToString()) == (Convert.ToInt32(CuotaId.SelectedValue)))
                                        {
                                            if ((Convert.ToInt32(row["cntId"].ToString()) == 2))
                                            {
                                                Estado = 1;
                                            }
                                        }
                                    }
                                }
                                else//todas las cuotas
                                {
                                    int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        for (int i = 1; i <= cantCuotas; i++) //Para cada cuota
                                        {//ojo matricula tiene cuota 1
                                            if (Convert.ToInt32(row["NroCuota"].ToString()) == i)
                                            {
                                                if ((Convert.ToInt32(row["cntId"].ToString()) == 2))
                                                {
                                                    Estado = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }


                            if (Estado == 0)
                            {
                                if (CuotaId.SelectedValue == "0")
                                {
                                    int cantCuotas = Convert.ToInt32(dt6.Rows[0]["CantCuotas"].ToString());

                                    for (int i = 1; i <= cantCuotas; i++) //Para cada cuota
                                    {
                                        DataRow row1 = dt.NewRow();
                                        row1["Id"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                                        row1["conId"] = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                        row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                        row1["TipoConcepto"] = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                        row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Nombre"].ToString());
                                        row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                        row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                        row1["BecId"] = Convert.ToDecimal(dt4.Rows[0]["Id"].ToString());
                                        row1["Beca"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                        row1["FchInscripcion"] = Convert.ToString(icuFechaInscripcion.Text);
                                        row1["NroCuota"] = i;
                                        dt.Rows.Add(row1);
                                    }
                                }

                                else//eligio cuota
                                {
                                    DataRow row1 = dt.NewRow();
                                    row1["Id"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                                    row1["conId"] = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                    row1["cntId"] = Convert.ToInt32(dt6.Rows[0]["cntId"].ToString());
                                    row1["TipoConcepto"] = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                    row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Nombre"].ToString());
                                    row1["AnioLectivo"] = Convert.ToDecimal(dt6.Rows[0]["AnioLectivo"].ToString());
                                    row1["Importe"] = Convert.ToDecimal(dt6.Rows[0]["Importe"].ToString());
                                    row1["BecId"] = Convert.ToDecimal(dt4.Rows[0]["Id"].ToString());
                                    row1["Beca"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                    row1["FchInscripcion"] = Convert.ToString(icuFechaInscripcion.Text);
                                    row1["NroCuota"] = Convert.ToInt32(CuotaId.SelectedValue);
                                    dt.Rows.Add(row1);
                                }
                            }
                            else
                            {
                                alerConceptoyaIngresado.Visible = true;
                            }
                        }

                    }

                    Session.Add("Datos", dt);
                    dt4 = Session["Datos"] as DataTable;
                    GrillaConcepto.DataSource = dt4;
                    lblCantidadRegistros2.Visible = true;
                    GrillaConcepto.DataBind();
                    btnInscribir.Focus();
                }
                else
                {
                    LblMjeGridConcepto.Text = "Ingrese un Concepto";
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
            alerRepetido.Visible = false;
            int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;
            //int index = e.RowIndex;

            //int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["Datos"] as DataTable;
            dt1.Rows[RowId].Delete();
            Session["Datos"] = dt1;

            GrillaConcepto.DataSource = dt1;
            GrillaConcepto.DataBind();

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

    protected void btnEliminarAceptarIns_Click(object sender, EventArgs e)
    {
        try
        {
            alerRepetido.Visible = false;
            alerError2.Visible = false;
            int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            //int fila = Convert.ToInt32(GrillaMateriaConfirmar.DataKeys[RowId].Values["Fila"]);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[7].Controls[1]).Text);
            insId = Convert.ToInt32(Session["_Institucion"]);
            ocnInscripcionCursadoTerciario.EliminarActivo0(Id, Master.usuId);
            ocnRegistracionCalificaciones.EliminarxictIdAct0(Id, Master.usuId);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            int PageIndex = 0;
            //PageIndex = Convert.ToInt32(Session["EMISIONORDENPAGO.PageIndex"]);

            DataTable dt1 = Session["TablaMatConf"] as DataTable;
            dt1.Rows[RowId].Delete();
            Session["TablaMatConf"] = dt1;
            GrillaMateriaConfirmar.EditIndex = -1;
            this.GrillaMateriaConfirmar.DataSource = dt1;
            this.GrillaMateriaConfirmar.PageIndex = PageIndex;
            this.GrillaMateriaConfirmar.DataBind();




            //GrillaMateriaConfirmar.DataSource = dt1;
            //GrillaMateriaConfirmar.DataBind();


            //DataTable dtTraeEspCur = new DataTable();
            //dtTraeEspCur = ocnInscripcionCursadoTerciario.ObtenerMateriasInsc(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text.Trim().ToString()));
            //if (dtTraeEspCur.Rows.Count > 0)
            //{
            //    GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
            //    GrillaMateriaConfirmar.DataBind();

            //}
            //Session.Add("TablaMatConf", dtTraeEspCur);


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

    protected void btnEliminarCancelarIns_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

    protected void ConTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerErrorConcepto.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (ConTipoId.SelectedIndex != 0)
            {
                if (ConTipoId.SelectedValue == "2")
                {
                    lblCuota.Visible = true;
                    CuotaId.Visible = true;
                    CuotaId.Enabled = true;
                }
                else
                {
                    if (ConTipoId.SelectedValue == "1")
                    {
                        lblCuota.Visible = false;
                        CuotaId.Enabled = false;
                        CuotaId.Visible = false;
                        //CuotaId.SelectedValue = "1";
                    }
                }
                int TipoConc = Convert.ToInt32(ConTipoId.SelectedValue);
                DataTable dt = new DataTable();
                dt = ocnConceptos.ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                if (dt.Rows.Count > 1)
                {
                    ConceptoId.DataValueField = "Valor";
                    ConceptoId.DataTextField = "Texto";
                    ConceptoId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                    ConceptoId.DataBind();
                }
                else
                {
                    alerErrorConcepto.Visible = true;
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


    protected void ConceptoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ConceptoId.SelectedIndex != 0)
            {
                int ConceptoVer = Convert.ToInt32(ConceptoId.SelectedValue);
                DataTable dt = new DataTable();
                dt = ocnBecas.ObtenerLista("[Seleccionar...]");
                if (dt.Rows.Count > 0)
                {
                    BecaId.DataValueField = "Valor";
                    BecaId.DataTextField = "Texto";
                    BecaId.DataSource = (new GESTIONESCOLAR.Negocio.Becas()).ObtenerLista("[Seleccionar...]");
                    BecaId.DataBind();
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

    protected void btnPagar_Click(object sender, EventArgs e)
    {
        try
        {
            alerInscripción.Visible = false;
            alerPagar.Visible = false;
            alerItems.Visible = false;
            int BanChk = 0;
            foreach (GridViewRow row in GrillaConcepto.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                if ((check.Checked)) // Si esta seleccionado..
                {
                    BanChk = 1;
                }
            }
            if (BanChk == 1)
            {
                LblMjeGridConcepto.Text = "";
                lblMensajeError.Text = "";
                DataTable dt = new DataTable();
                DataTable dt9 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt1 = new DataTable();
                dt.Columns.Add("icuId", typeof(int));
                dt.Columns.Add("icoId", typeof(int));
                dt.Columns.Add("cntId", typeof(int));
                dt.Columns.Add("conId", typeof(Int32));
                dt.Columns.Add("TipoConcepto", typeof(String));
                dt.Columns.Add("Concepto", typeof(String));
                dt.Columns.Add("Importe", typeof(Decimal));
                dt.Columns.Add("ImporteInteres", typeof(Decimal));
                dt.Columns.Add("AnioLectivo", typeof(Decimal));
                dt.Columns.Add("Beca", typeof(String));
                dt.Columns.Add("BecId", typeof(Int32));
                dt.Columns.Add("NroCuota", typeof(Int32));
                dt.Columns.Add("FchInscripcion", typeof(String));

                String FchaInscripcionCon;

                DateTime FechaHoy;
                string dateString = Convert.ToString(DateTime.Today);

                FechaHoy = DateTime.Parse(dateString);

                foreach (GridViewRow row in GrillaConcepto.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                    //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);

                    if ((check.Checked)) // Si esta seleccionado..
                    {
                        //obtengo incripcionConepto 
                        dt9 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota((Convert.ToInt32(lblicuId.Text)), (Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["conId"])), Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["NroCuota"]));
                        dt3 = ocnConceptos.ObtenerUno((Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["conId"])));

                        if (dt9.Rows.Count > 0)
                        {
                            FchaInscripcionCon = Convert.ToString(dt9.Rows[0]["FechaInscripcion"].ToString());

                            DataRow row1 = dt.NewRow();
                            row1["icuId"] = (Convert.ToInt32(lblicuId.Text));
                            row1["icoId"] = Convert.ToInt32(Convert.ToInt32(dt9.Rows[0]["Id"].ToString()));
                            row1["conId"] = Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["conId"]);
                            row1["cntId"] = Convert.ToInt32(Convert.ToInt32(dt3.Rows[0]["cntId"].ToString()));
                            row1["TipoConcepto"] = Convert.ToString(GrillaConcepto.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                            row1["Concepto"] = Convert.ToString(GrillaConcepto.DataKeys[row.RowIndex].Values["Concepto"]);
                            row1["Importe"] = Convert.ToDecimal(GrillaConcepto.DataKeys[row.RowIndex].Values["Importe"]);
                            row1["AnioLectivo"] = Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["AnioLectivo"]);
                            row1["Beca"] = Convert.ToString(GrillaConcepto.DataKeys[row.RowIndex].Values["Beca"]);
                            row1["BecId"] = Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["BecId"]);
                            row1["FchInscripcion"] = Convert.ToString(GrillaConcepto.DataKeys[row.RowIndex].Values["FchInscripcion"]);
                            row1["NroCuota"] = Convert.ToInt32(GrillaConcepto.DataKeys[row.RowIndex].Values["NroCuota"]);
                            dt.Rows.Add(row1);
                            Session.Add("TablaPagar", dt);
                        }
                    }
                }
                int icuId = Convert.ToInt32(lblicuId.Text);
                Response.Redirect("Facturacion.aspx?Id=" + icuId, false);
            }
            else
            {
                alerItems.Visible = true;
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

    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
        int carIdO = 0;
        int plaIdO = 0;
        if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
        {
            carId.Enabled = true;
            DataTable dt2 = new DataTable();
            int nivel = Convert.ToInt32(NivelID.SelectedValue);
            dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);
            CondicionMostrar.Visible = true;
            if (dt2.Rows.Count > 0)
            {
                carId.DataValueField = "Valor";
                carId.DataTextField = "Texto";
                carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                carId.DataBind();

            }
        }
        else// es primario inicial o secundario
        {

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
            carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
            dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
            plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
            CondicionMostrar.Visible = false;
            curId.DataValueField = "Valor";
            curId.DataTextField = "Texto";
            curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", plaIdO);
            curId.DataBind();
            carId.Enabled = false;
            plaId.Enabled = false;
            carId.SelectedValue = "0";
            plaId.SelectedValue = "0";
        }
    }

    protected void icuAnioCursado_TextChanged(object sender, EventArgs e)
    {
        alerError3.Visible = false;
        ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
        ConceptoId.ClearSelection();

        if (NivelID.SelectedValue == "4")
        {
            insId = Convert.ToInt32(Session["_Institucion"]);

            if (Convert.ToInt32(carId.SelectedValue) != 0 & plaId.SelectedValue != "" & curId.SelectedValue != "")
            {
                DataTable dt = new DataTable();

                dt = ocnEspacioCurricular.ObtenerPorCarPorPlanporCur(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(curId.SelectedValue));
                if (curId.SelectedValue != "")
                {
                    DataTable dtTraeEspCur = new DataTable();
                    if (Convert.ToString(aluId.Text.Trim().ToString()) != "")
                    {

                        DataTable dtTraerConcepto = new DataTable();
                        dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 1, Convert.ToInt32(icuAnioCursado.Text));
                        DataTable dtConceptoPago = new DataTable();

                        if (dtTraerConcepto.Rows.Count > 0)
                        {
                            dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                        }
                        else
                        {
                            alerError3.Visible = true;
                            lblError3.Text = "El alumno debe registrar el concepto de Matricula..";
                            GrillaMateriaConfirmar.DataSource = null;
                            GrillaMateriaConfirmar.DataBind();
                            GrillaMaterias.DataSource = null;
                            GrillaMaterias.DataBind();
                            btnSeleccionarTodo.Visible = false;
                            btnAgregarMateria.Visible = false;
                            tituloMateria.Visible = false;
                            TituloMaterisIns.Visible = false;
                            return;
                        }

                        if (dtConceptoPago.Rows.Count > 0)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                dtTraeEspCur = ocnInscripcionCursadoTerciario.ObtenerMateriasInsc(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                                if (dtTraeEspCur.Rows.Count > 0)
                                {
                                    GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
                                    GrillaMateriaConfirmar.DataBind();

                                    this.GrillaMaterias.DataSource = dt;
                                    //this.GrillaMaterias.PageIndex = PageIndex;
                                    this.GrillaMaterias.DataBind();
                                    btnSeleccionarTodo.Visible = true;
                                    btnAgregarMateria.Visible = true;
                                    tituloMateria.Visible = true;
                                    TituloMaterisIns.Visible = true;
                                    btnLimpiar.Visible = true;
                                    btnSalir.Visible = true;
                                    btnAlumno.Visible = true;
                                }
                                else
                                {
                                    GrillaMateriaConfirmar.DataSource = null;
                                    GrillaMateriaConfirmar.DataBind();

                                    this.GrillaMaterias.DataSource = dt;
                                    //this.GrillaMaterias.PageIndex = PageIndex;
                                    this.GrillaMaterias.DataBind();
                                    btnSeleccionarTodo.Visible = true;
                                    btnAgregarMateria.Visible = true;
                                    tituloMateria.Visible = true;
                                    TituloMaterisIns.Visible = true;
                                    btnLimpiar.Visible = true;
                                    btnSalir.Visible = true;
                                    btnAlumno.Visible = true;
                                }
                                Session.Add("TablaMatConf", dtTraeEspCur);
                            }
                            else
                            {
                                this.GrillaMaterias.DataSource = null;
                                //this.GrillaMaterias.PageIndex = PageIndex;
                                this.GrillaMaterias.DataBind();
                                btnSeleccionarTodo.Visible = true;
                                btnAgregarMateria.Visible = false;
                                tituloMateria.Visible = false;
                                TituloMaterisIns.Visible = false;
                                btnLimpiar.Visible = false;
                                btnSalir.Visible = false;
                                btnAlumno.Visible = false;

                                GrillaMateriaConfirmar.DataSource = null;
                                GrillaMateriaConfirmar.DataBind();
                            }
                        }
                        else
                        {
                            alerError3.Visible = true;
                            lblError3.Text = "El alumno debe pagar el concepto de Matricula..";
                            GrillaMateriaConfirmar.DataSource = null;
                            GrillaMateriaConfirmar.DataBind();
                            GrillaMaterias.DataSource = null;
                            GrillaMaterias.DataBind();
                            btnSeleccionarTodo.Visible = false;
                            btnAgregarMateria.Visible = false;
                            tituloMateria.Visible = false;
                            TituloMaterisIns.Visible = false;
                            return;
                        }
                    }
                }
            }
        }
    }

    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in GrillaMaterias.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

                    if (check.Checked == true)
                    {
                        check.Checked = false;
                    }
                }
                btnSeleccionarTodo.Text = "Seleccionar todo";
            }
            else
            {
                foreach (GridViewRow row in GrillaMaterias.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

                    if (check.Checked == false)
                    {
                        check.Checked = true;
                    }
                }
                btnSeleccionarTodo.Text = "Desmarcar todo";
            }
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

    protected void btnAgregarMateria_Click(object sender, EventArgs e)
    {
        GridErrores.Visible = false;
        DataTable dtOBSERVACIONES = new DataTable();
        dtOBSERVACIONES.Columns.Add("lblAlumno3", typeof(String));
        dtOBSERVACIONES.Columns.Add("lblObservaciones", typeof(String));
        GridErrores.DataSource = dtOBSERVACIONES;
        GridErrores.DataBind();
        Session["OBSERVACIONES"] = dtOBSERVACIONES;
        insId = Convert.ToInt32(Session["_Institucion"]);
        alerError2.Visible = false;

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        alerMAteria.Visible = false;
        lblMensajeError.Text = "";
        alerMatRepe.Visible = false;


        if (aluId.Text != "")
        {
            int Ban = 0;
            foreach (GridViewRow row2 in GrillaMaterias.Rows) //seleccionó un esp cur para inscribir
            {
                CheckBox check2 = row2.FindControl("chkSeleccion2") as CheckBox;
                if ((check2.Checked)) // Si esta seleccionado..
                {
                    Ban = 1;
                }
            }

            if (Ban == 1) // sE SELECCIONO AL MENOS UNO
            {
                Int32 ControlExiste = 0;
                foreach (GridViewRow row3 in GrillaMaterias.Rows) // Por cada materia del curso
                {
                    int Error = 0;
                    List<String> CadenaEspacios = new List<String>();
                    String EspCurricular = "";
                    String Observaciones = "";
                    CheckBox check3 = row3.FindControl("chkSeleccion2") as CheckBox;

                    if ((check3.Checked)) // Si esta seleccionado..
                    {
                        foreach (GridViewRow row4 in GrillaMateriaConfirmar.Rows) // Veo si esta ya registrada en Materias que esta haciendo o hizo
                        {
                            if (Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]) == Convert.ToInt32(GrillaMateriaConfirmar.DataKeys[row4.RowIndex].Values["escId"]))
                            {
                                if (Convert.ToInt32(GrillaMateriaConfirmar.DataKeys[row4.RowIndex].Values["AnoCursado"]) == Convert.ToInt32(icuAnioCursado.Text))
                                {
                                    // Mismo Año mismo Espacio.. Error
                                    EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                    Observaciones = "El alumno ya se inscribió en este Espacio Curricular para ese año";

                                    DataTable dO = new DataTable();
                                    dO = Session["OBSERVACIONES"] as DataTable;
                                    DataRow row2 = dO.NewRow();

                                    row2["lblAlumno3"] = EspCurricular;
                                    row2["lblObservaciones"] = Observaciones;
                                    dO.Rows.Add(row2);
                                    Session["OBSERVACIONES"] = dO;
                                    Error = 1;
                                }
                                else
                                {
                                }
                            }
                        }
                        if (Error == 0)
                        {
                            //Traer Correlativas para CURSAR del Espacio Curricular que estoy inscribiendo 
                            int ControlFaltaCorrelativa = 1;
                            DataTable dt1 = new DataTable();
                            DataTable dt4 = new DataTable();
                            DataTable dt5 = new DataTable();
                            //String EspCurricular = "";
                            dt1 = ocnEspacioCurricular.ObtenerCorrelativasxCursar(Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]), insId); // Traigo Correlativas  
                            if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                            {
                                CadenaEspacios = new List<String>();
                                // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                foreach (DataRow row in dt1.Rows)
                                {
                                    dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(row["Id"].ToString()), Convert.ToInt32(row["cotId"].ToString()));
                                    if (dt4.Rows.Count != 0)
                                    {
                                        //ControlFaltaCorrelativa = 1;
                                    }
                                    else
                                    {
                                        dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(row["Id"].ToString()), insId);
                                        EspCurricular = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                        CadenaEspacios.Add(EspCurricular);
                                        ControlFaltaCorrelativa = 0;
                                    }
                                }
                            }
                            else // No hay correlativas
                            {
                                //ControlFaltaCorrelativa = 1;
                            }

                            if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                            {
                                dt2 = new DataTable();
                                dt2 = ocnInscripcionCursado.ControlCursoExisteTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                                if (dt2.Rows.Count > 0) // YA SE INSCRIBIO EN ESE CURSO???
                                {
                                    ControlExiste = 1;
                                    lblicuId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
                                }
                                DataTable dtControlIns = new DataTable();
                                if (ControlExiste == 0)// Si no fué cargada anteriormente
                                {
                                    int Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
                                    ocnInscripcionCursado.insId = insId;
                                    ocnInscripcionCursado.icuAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                    AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                    ocnInscripcionCursado.icuFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                    ocnInscripcionCursado.icuActivo = icuActivo.Checked;
                                    //String alumnoId = aluId.Text
                                    ocnInscripcionCursado.aluId = Convert.ToInt32(aluId.Text);
                                    ocnInscripcionCursado.icuEstado = 1;
                                    ocnInscripcionCursado.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
                                    ocnInscripcionCursado.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                                    ocnInscripcionCursado.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
                                    //ocnInscripcionCursado.camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                                    //ocnInscripcionCursado.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue));
                                    /*....usuId = this.Master.usuId;*/
                                    ocnInscripcionCursado.icuFechaHoraCreacion = DateTime.Now;
                                    ocnInscripcionCursado.icuFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnInscripcionCursado.usuIdCreacion = this.Master.usuId;
                                    ocnInscripcionCursado.usuIdUltimaModificacion = this.Master.usuId;
                                    ocnInscripcionCursado.icuInsConfirmar = 1;
                                    ocnInscripcionCursado.icuObserv = "";
                                    int icuId = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                    lblicuId.Text = Convert.ToString(icuId);
                                    alerInscripción2.Visible = true;
                                }

                                Int32 EspCurId = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);

                                // Controlo si el alumno ya hizo esa materia

                                dtControlIns = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), EspCurId);
                                Int32 EspCurIdNew = 0;

                                if (dtControlIns.Rows.Count == 0) // No esta inscripto en ese espacio curricular
                                {
                                    EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);

                                    DataTable dt6 = new DataTable();
                                    dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                    if (dt5.Rows.Count > 0)
                                    {
                                        dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                    }
                                    else
                                    {

                                        EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                        Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                        DataTable dO = new DataTable();
                                        dO = Session["OBSERVACIONES"] as DataTable;
                                        DataRow row2 = dO.NewRow();

                                        row2["lblAlumno3"] = EspCurricular;
                                        row2["lblObservaciones"] = Observaciones;
                                        //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                        dO.Rows.Add(row2);
                                        Session["OBSERVACIONES"] = dO;
                                        Error = 1;
                                    }

                                    if (dt6.Rows.Count > 0)
                                    {
                                        Int32 Id = 0;
                                        ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                        ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                        ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                        //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                        AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                        ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                        ocnInscripcionCursadoTerciario.ictEstado = 1;
                                        ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                        if (CondicionId.SelectedValue == "0" || CondicionId.SelectedValue == "1" || CondicionId.SelectedValue == "5" || CondicionId.SelectedValue == "11")
                                        {
                                            ocnInscripcionCursadoTerciario.cdnId = 1;
                                            ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                        }
                                        else
                                        {
                                            ocnInscripcionCursadoTerciario.cdnId = Convert.ToInt32(CondicionId.SelectedValue);
                                            ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = DateTime.Now;
                                        }

                                        ocnInscripcionCursadoTerciario.ictObservacion = "";
                                        ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                        ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                        ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                        ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                        int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                        alerInscripción2.Visible = true;

                                        if (dt6.Rows.Count > 0)
                                        {
                                            foreach (DataRow row2 in dt6.Rows)
                                            {
                                                int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                int NewId = 0;
                                                ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                ocnRegistracionCalificaciones.ictId = ictId;
                                                ocnRegistracionCalificaciones.eceId = eceId;
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
                                    }
                                }
                                else  // ESTA INSCRIPTO EN ESE ESPACIO pero es de distinto Año.. entonces regular (pero libre anterior) recursa o Libre 
                                {

                                    DataTable dtUltictId = new DataTable();
                                    EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);

                                    // Traigo el ultimo registro en esa Materia
                                    dtUltictId = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(Convert.ToInt32(aluId.Text.Trim()), Convert.ToInt32(curId.SelectedValue), EspCurIdNew);
                                    if (dtUltictId.Rows.Count > 0)
                                    {
                                        if (Convert.ToInt32(dtUltictId.Rows[0]["AnoCursado"]) < Convert.ToInt32(icuAnioCursado.Text))
                                        {
                                            String CondDesc = Convert.ToString(dtUltictId.Rows[0]["Condicion"]);

                                            if (CondicionId.SelectedValue == "5")// Condicional
                                            {
                                                EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                //CadenaEspacios.Add(EspCurricular);
                                                //ControlFaltaCorrelativa = 0;
                                                Observaciones = "Alumno ya inscripto en Años Anteriores..";

                                                DataTable dO = new DataTable();
                                                dO = Session["OBSERVACIONES"] as DataTable;
                                                DataRow row2 = dO.NewRow();

                                                row2["lblAlumno3"] = EspCurricular;
                                                row2["lblObservaciones"] = Observaciones;
                                                //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                dO.Rows.Add(row2);
                                                Session["OBSERVACIONES"] = dO;

                                                Error = 1;

                                            }
                                            else
                                            {
                                                if (CondicionId.SelectedValue == "11" || CondicionId.SelectedValue == "0")//RECURSA
                                                {
                                                    if (Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Libre" || Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Desaprobado")
                                                    {
                                                        DataTable dt6 = new DataTable();
                                                        dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                                        if (dt5.Rows.Count > 0)
                                                        {
                                                            dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                                        }
                                                        else
                                                        {

                                                            EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                            Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                                            DataTable dO = new DataTable();
                                                            dO = Session["OBSERVACIONES"] as DataTable;
                                                            DataRow row2 = dO.NewRow();

                                                            row2["lblAlumno3"] = EspCurricular;
                                                            row2["lblObservaciones"] = Observaciones;
                                                            //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                            dO.Rows.Add(row2);
                                                            Session["OBSERVACIONES"] = dO;
                                                            Error = 1;
                                                        }

                                                        if (dt6.Rows.Count > 0)
                                                        {
                                                            EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);
                                                            int Id = 0;
                                                            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                                            ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                                            ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                                            //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                                            AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                                            ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                                            ocnInscripcionCursadoTerciario.ictEstado = 1;
                                                            ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                                            ocnInscripcionCursadoTerciario.cdnId = 11;
                                                            ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                                            ocnInscripcionCursadoTerciario.ictObservacion = "";
                                                            ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                                            ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                                            ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                                            ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                                            ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                                            int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                                            alerInscripción2.Visible = true;

                                                            if (dt6.Rows.Count > 0)
                                                            {
                                                                foreach (DataRow row2 in dt6.Rows)
                                                                {
                                                                    int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                                    int NewId = 0;
                                                                    ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                                    ocnRegistracionCalificaciones.ictId = ictId;
                                                                    ocnRegistracionCalificaciones.eceId = eceId;
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

                                                        }
                                                    }
                                                    else
                                                    {

                                                        if (Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Regular")
                                                        {
                                                            DataTable dt6 = new DataTable();
                                                            dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                                            if (dt5.Rows.Count > 0)
                                                            {
                                                                dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                                            }
                                                            else
                                                            {

                                                                EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                                Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                                                DataTable dO = new DataTable();
                                                                dO = Session["OBSERVACIONES"] as DataTable;
                                                                DataRow row2 = dO.NewRow();

                                                                row2["lblAlumno3"] = EspCurricular;
                                                                row2["lblObservaciones"] = Observaciones;
                                                                //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                                dO.Rows.Add(row2);
                                                                Session["OBSERVACIONES"] = dO;
                                                                Error = 1;
                                                            }

                                                            if (dt6.Rows.Count > 0)
                                                            {
                                                                EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);
                                                                int Id = 0;
                                                                ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                                                ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                                                ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                                                //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                                                AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                                                ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                                                ocnInscripcionCursadoTerciario.ictEstado = 1;
                                                                ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                                                ocnInscripcionCursadoTerciario.cdnId = 11;
                                                                ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                                                ocnInscripcionCursadoTerciario.ictObservacion = "";
                                                                ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                                                ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                                                ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                                                ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                                                ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                                                int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                                                alerInscripción2.Visible = true;

                                                                if (dt6.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow row2 in dt6.Rows)
                                                                    {
                                                                        int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                                        int NewId = 0;
                                                                        ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                                        ocnRegistracionCalificaciones.ictId = ictId;
                                                                        ocnRegistracionCalificaciones.eceId = eceId;
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

                                                                // Cambio Condición de Recular a Libre

                                                                int IdCambiarCond = Convert.ToInt32(dtUltictId.Rows[0]["Id"]);
                                                                ocnInscripcionCursadoTerciario.ActualizarCondicion(IdCambiarCond, 3, null, this.Master.usuId, DateTime.Now);// Libre
                                                                string Observ = "Libre por Cursar nuevamente en " + icuAnioCursado.Text;
                                                                ocnInscripcionCursadoTerciario.ActualizarObservacion(IdCambiarCond, Observ, this.Master.usuId, DateTime.Now);// Libre

                                                            }
                                                        }

                                                        else
                                                        {
                                                            if (Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Recursa")
                                                            {
                                                                DataTable dt6 = new DataTable();
                                                                dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                                                if (dt5.Rows.Count > 0)
                                                                {
                                                                    dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                                                }
                                                                else
                                                                {

                                                                    EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                                    Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                                                    DataTable dO = new DataTable();
                                                                    dO = Session["OBSERVACIONES"] as DataTable;
                                                                    DataRow row2 = dO.NewRow();

                                                                    row2["lblAlumno3"] = EspCurricular;
                                                                    row2["lblObservaciones"] = Observaciones;
                                                                    //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                                    dO.Rows.Add(row2);
                                                                    Session["OBSERVACIONES"] = dO;
                                                                    Error = 1;
                                                                }

                                                                if (dt6.Rows.Count > 0)
                                                                {
                                                                    EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);
                                                                    int Id = 0;
                                                                    ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                                                    ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                                                    ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                                                    //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                                                    AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                                                    ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                                                    ocnInscripcionCursadoTerciario.ictEstado = 1;
                                                                    ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                                                    ocnInscripcionCursadoTerciario.cdnId = 11;
                                                                    ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                                                    ocnInscripcionCursadoTerciario.ictObservacion = "";
                                                                    ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                                                    ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                                                    ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                                                    ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                                                    ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                                                    int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                                                    alerInscripción2.Visible = true;

                                                                    if (dt6.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow row2 in dt6.Rows)
                                                                        {
                                                                            int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                                            int NewId = 0;
                                                                            ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                                            ocnRegistracionCalificaciones.ictId = ictId;
                                                                            ocnRegistracionCalificaciones.eceId = eceId;
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
                                                                }
                                                            }

                                                        }
                                                    }
                                                }
                                                else
                                                {


                                                    if (CondicionId.SelectedValue == "1")//regular, pero quiere recursar
                                                    {
                                                        if (Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Libre" || Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Desaprobado")
                                                        {
                                                            DataTable dt6 = new DataTable();
                                                            dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                                            if (dt5.Rows.Count > 0)
                                                            {
                                                                dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                                            }
                                                            else
                                                            {

                                                                EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                                Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                                                DataTable dO = new DataTable();
                                                                dO = Session["OBSERVACIONES"] as DataTable;
                                                                DataRow row2 = dO.NewRow();

                                                                row2["lblAlumno3"] = EspCurricular;
                                                                row2["lblObservaciones"] = Observaciones;
                                                                //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                                dO.Rows.Add(row2);
                                                                Session["OBSERVACIONES"] = dO;
                                                                Error = 1;
                                                            }

                                                            if (dt6.Rows.Count > 0)
                                                            {
                                                                EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);
                                                                int Id = 0;
                                                                ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                                                ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                                                ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                                                //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                                                AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                                                ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                                                ocnInscripcionCursadoTerciario.ictEstado = 1;
                                                                ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                                                ocnInscripcionCursadoTerciario.cdnId = 1;
                                                                ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                                                ocnInscripcionCursadoTerciario.ictObservacion = "";
                                                                ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                                                ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                                                ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                                                ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                                                ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                                                int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                                                alerInscripción2.Visible = true;

                                                                if (dt6.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow row2 in dt6.Rows)
                                                                    {
                                                                        int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                                        int NewId = 0;
                                                                        ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                                        ocnRegistracionCalificaciones.ictId = ictId;
                                                                        ocnRegistracionCalificaciones.eceId = eceId;
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

                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Regular" && dtUltictId.Rows[0]["FechaPromociona"] != DBNull.Value)
                                                            {
                                                                DataTable dt6 = new DataTable();
                                                                dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                                                if (dt5.Rows.Count > 0)
                                                                {
                                                                    dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                                                }
                                                                else
                                                                {

                                                                    EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                                    Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                                                    DataTable dO = new DataTable();
                                                                    dO = Session["OBSERVACIONES"] as DataTable;
                                                                    DataRow row2 = dO.NewRow();

                                                                    row2["lblAlumno3"] = EspCurricular;
                                                                    row2["lblObservaciones"] = Observaciones;
                                                                    //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                                    dO.Rows.Add(row2);
                                                                    Session["OBSERVACIONES"] = dO;
                                                                    Error = 1;
                                                                }

                                                                if (dt6.Rows.Count > 0)
                                                                {
                                                                    EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);
                                                                    int Id = 0;
                                                                    ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                                                    ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                                                    ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                                                    //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                                                    AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                                                    ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                                                    ocnInscripcionCursadoTerciario.ictEstado = 1;
                                                                    ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                                                    ocnInscripcionCursadoTerciario.cdnId = 1;
                                                                    ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                                                    ocnInscripcionCursadoTerciario.ictObservacion = "";
                                                                    ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                                                    ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                                                    ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                                                    ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                                                    ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                                                    int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                                                    alerInscripción2.Visible = true;

                                                                    if (dt6.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow row2 in dt6.Rows)
                                                                        {
                                                                            int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                                            int NewId = 0;
                                                                            ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                                            ocnRegistracionCalificaciones.ictId = ictId;
                                                                            ocnRegistracionCalificaciones.eceId = eceId;
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

                                                                    // Cambio Condición de Recular a Libre

                                                                    int IdCambiarCond = Convert.ToInt32(dtUltictId.Rows[0]["Id"]);
                                                                    ocnInscripcionCursadoTerciario.ActualizarCondicion(IdCambiarCond, 3, null, this.Master.usuId, DateTime.Now);// Libre
                                                                    string Observ = "Libre por Cursar nuevamente en " + icuAnioCursado.Text;
                                                                    ocnInscripcionCursadoTerciario.ActualizarObservacion(IdCambiarCond, Observ, this.Master.usuId, DateTime.Now);// Libre

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dtUltictId.Rows[0]["AnoCursado"]) == Convert.ToInt32(icuAnioCursado.Text))
                                            {

                                                EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                //CadenaEspacios.Add(EspCurricular);
                                                //ControlFaltaCorrelativa = 0;
                                                Observaciones = "Esta inscripto en ese Espacio Curricular para el año ingresado ";

                                                DataTable dO = new DataTable();
                                                dO = Session["OBSERVACIONES"] as DataTable;
                                                DataRow row2 = dO.NewRow();

                                                row2["lblAlumno3"] = EspCurricular;
                                                row2["lblObservaciones"] = Observaciones;
                                                //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                dO.Rows.Add(row2);
                                                Session["OBSERVACIONES"] = dO;
                                                Error = 1;

                                                //alerError2.Visible = true;
                                                //lblError2.Text = "Esta inscripto en ese Espacio Curricular para el año ingresado ";
                                                //return;
                                            }
                                        }
                                    }
                                }

                                DataTable dtTraeEspCur2 = new DataTable();
                                if (Convert.ToString(aluId.Text.Trim().ToString()) != "")
                                {
                                    dtTraeEspCur2 = ocnInscripcionCursadoTerciario.ObtenerMateriasInsc(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                                    if (dtTraeEspCur2.Rows.Count > 0)
                                    {
                                        GrillaMateriaConfirmar.DataSource = dtTraeEspCur2;
                                        GrillaMateriaConfirmar.DataBind();

                                    }
                                    //Session.Add("TablaMatConf", dtTraeEspCur);
                                }
                            } // 

                            else // No tiene las Correlativas
                            {
                                Int32 EspCurId = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);

                                DataTable dt6 = new DataTable();
                                dt5 = ocnEspacioCurricular.ObtenerUno(EspCurId, insId);
                                if (dt5.Rows.Count > 0)
                                {
                                    dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurId, Convert.ToInt32(icuAnioCursado.Text));
                                }
                                else
                                {
                                    EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                    Observaciones = "Para ese Espacio no se definieron Evaluaciones para Año Lectivo seleccionado..";
                                    DataTable dO = new DataTable();
                                    dO = Session["OBSERVACIONES"] as DataTable;
                                    DataRow row2 = dO.NewRow();

                                    row2["lblAlumno3"] = EspCurricular;
                                    row2["lblObservaciones"] = Observaciones;
                                    //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                    dO.Rows.Add(row2);
                                    Session["OBSERVACIONES"] = dO;
                                    Error = 1;
                                }



                                if (dt6.Rows.Count > 0)
                                {
                                    if (CondicionId.SelectedValue == "5") // condicional
                                    {
                                        dt2 = new DataTable();
                                        dt2 = ocnInscripcionCursado.ControlCursoExisteTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                                        if (dt2.Rows.Count > 0) // YA SE INSCRIBIO EN ESE CURSO???
                                        {
                                            ControlExiste = 1;
                                            lblicuId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
                                        }
                                        DataTable dtControlIns = new DataTable();
                                        if (ControlExiste == 0)// Si no fué cargada anteriormente
                                        {
                                            int Id = Convert.ToInt32(Request.QueryString["Id"]);
                                            ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
                                            ocnInscripcionCursado.insId = insId;
                                            ocnInscripcionCursado.icuAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                            AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                            ocnInscripcionCursado.icuFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                            ocnInscripcionCursado.icuActivo = icuActivo.Checked;
                                            //String alumnoId = aluId.Text
                                            ocnInscripcionCursado.aluId = Convert.ToInt32(aluId.Text);
                                            ocnInscripcionCursado.icuEstado = 1;
                                            ocnInscripcionCursado.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
                                            ocnInscripcionCursado.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                                            ocnInscripcionCursado.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
                                            //ocnInscripcionCursado.camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                                            //ocnInscripcionCursado.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue));
                                            /*....usuId = this.Master.usuId;*/
                                            ocnInscripcionCursado.icuFechaHoraCreacion = DateTime.Now;
                                            ocnInscripcionCursado.icuFechaHoraUltimaModificacion = DateTime.Now;
                                            ocnInscripcionCursado.usuIdCreacion = this.Master.usuId;
                                            ocnInscripcionCursado.usuIdUltimaModificacion = this.Master.usuId;
                                            ocnInscripcionCursado.icuInsConfirmar = 1;
                                            ocnInscripcionCursado.icuObserv = "";
                                            int icuId = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                            lblicuId.Text = Convert.ToString(icuId);
                                            alerInscripción2.Visible = true;
                                        }

                                        dtControlIns = ocnInscripcionCursadoTerciario.ObtenerUnoControlExiste(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), EspCurId, Convert.ToInt32(icuAnioCursado.Text));
                                        Int32 EspCurIdNew = 0;

                                        if (dtControlIns.Rows.Count == 0) // No esta inscripto en ese espacio curricular
                                        {
                                            EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);

                                            Int32 Id = 0;
                                            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                            ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                            ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                            //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                            AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                            ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                            ocnInscripcionCursadoTerciario.ictEstado = 1;
                                            ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;

                                            ocnInscripcionCursadoTerciario.cdnId = Convert.ToInt32(CondicionId.SelectedValue);
                                            ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                            ocnInscripcionCursadoTerciario.ictObservacion = "";
                                            ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                            ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                            ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                            ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                            ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                            int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                            alerInscripción2.Visible = true;
                                            dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                            if (dt5.Rows.Count > 0)
                                            {
                                                dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                            }
                                            else
                                            {

                                            }
                                            if (dt6.Rows.Count > 0)
                                            {
                                                foreach (DataRow row2 in dt6.Rows)
                                                {
                                                    int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                    int NewId = 0;
                                                    ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                    ocnRegistracionCalificaciones.ictId = ictId;
                                                    ocnRegistracionCalificaciones.eceId = eceId;
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
                                        }
                                        else  // ESTA INSCRIPTO EN ESE ESPACIO pero es de distinto Año.. entonces recursa o si esta Libre cursa de nuevo
                                        {

                                            DataTable dtUltictId = new DataTable();
                                            EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);

                                            dtUltictId = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(Convert.ToInt32(aluId.Text.Trim()), Convert.ToInt32(curId.SelectedValue), EspCurIdNew);
                                            if (dtUltictId.Rows.Count > 0)
                                            {
                                                if (Convert.ToInt32(dtUltictId.Rows[0]["AnoCursado"]) < Convert.ToInt32(icuAnioCursado.Text))
                                                {
                                                    String CondDesc = Convert.ToString(dtUltictId.Rows[0]["Condicion"]);

                                                    if (CondDesc == "Regular" || CondDesc == "Condicional")
                                                    {
                                                        EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                        //CadenaEspacios.Add(EspCurricular);
                                                        //ControlFaltaCorrelativa = 0;
                                                        Observaciones = "La Condición registro anterior no permite actualizarla nuevamente.. "; ;

                                                        DataTable dO = new DataTable();
                                                        dO = Session["OBSERVACIONES"] as DataTable;
                                                        DataRow row2 = dO.NewRow();

                                                        row2["lblAlumno3"] = EspCurricular;
                                                        row2["lblObservaciones"] = Observaciones;
                                                        //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                        dO.Rows.Add(row2);
                                                        Session["OBSERVACIONES"] = dO;
                                                        Error = 1;
                                                    }
                                                    else
                                                    {

                                                        if (Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Libre" || Convert.ToString(dtUltictId.Rows[0]["Condicion"]) == "Desaprobado")
                                                        {
                                                            EspCurIdNew = Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]);
                                                            int Id = 0;
                                                            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id);
                                                            ocnInscripcionCursadoTerciario.icuId = Convert.ToInt32(lblicuId.Text);
                                                            ocnInscripcionCursadoTerciario.escId = EspCurIdNew;
                                                            //ocnInscripcionCursadoTerciario.ictAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                                                            AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                                                            ocnInscripcionCursadoTerciario.ictFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                                                            ocnInscripcionCursadoTerciario.ictEstado = 1;
                                                            ocnInscripcionCursadoTerciario.ictActivo = icuActivo.Checked;
                                                            ocnInscripcionCursadoTerciario.cdnId = 11;
                                                            ocnInscripcionCursadoTerciario.ictFechaRegularizaPromociona = Convert.ToDateTime("01/01/0001");
                                                            ocnInscripcionCursadoTerciario.ictObservacion = "";
                                                            ocnInscripcionCursadoTerciario.ictInsConfirmar = 1;
                                                            ocnInscripcionCursadoTerciario.ictFechaHoraCreacion = DateTime.Now;
                                                            ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                                            ocnInscripcionCursadoTerciario.usuIdCreacion = this.Master.usuId;
                                                            ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                                            int ictId = ocnInscripcionCursadoTerciario.Insertar(); //Lo agrego en ese curso o Materia

                                                            alerInscripción2.Visible = true;

                                                            dt5 = ocnEspacioCurricular.ObtenerUno(EspCurIdNew, insId);
                                                            if (dt5.Rows.Count > 0)
                                                            {
                                                                dt6 = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(EspCurIdNew, Convert.ToInt32(icuAnioCursado.Text));
                                                            }
                                                            else
                                                            {

                                                            }
                                                            if (dt6.Rows.Count > 0)
                                                            {
                                                                foreach (DataRow row2 in dt6.Rows)
                                                                {
                                                                    int eceId = Convert.ToInt32(row2["eceId"].ToString());
                                                                    int NewId = 0;
                                                                    ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(NewId);
                                                                    ocnRegistracionCalificaciones.ictId = ictId;
                                                                    ocnRegistracionCalificaciones.eceId = eceId;
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
                                                        }
                                                        else
                                                        {
                                                            EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());

                                                            Observaciones = "La Condición del año anterior no es Libre o Desaprobado.. Deben cambiar la Condición para inscribirlo como Recursante..";

                                                            DataTable dO = new DataTable();
                                                            dO = Session["OBSERVACIONES"] as DataTable;
                                                            DataRow row2 = dO.NewRow();

                                                            row2["lblAlumno3"] = EspCurricular;
                                                            row2["lblObservaciones"] = Observaciones;
                                                            //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                            dO.Rows.Add(row2);
                                                            Session["OBSERVACIONES"] = dO;
                                                            Error = 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(dtUltictId.Rows[0]["AnoCursado"]) == Convert.ToInt32(icuAnioCursado.Text))
                                                    {
                                                        EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                                        //CadenaEspacios.Add(EspCurricular);
                                                        //ControlFaltaCorrelativa = 0;
                                                        Observaciones = "Esta inscripto en ese Espacio Curricular para el año ingresado ";

                                                        DataTable dO = new DataTable();
                                                        dO = Session["OBSERVACIONES"] as DataTable;
                                                        DataRow row2 = dO.NewRow();

                                                        row2["lblAlumno3"] = EspCurricular;
                                                        row2["lblObservaciones"] = Observaciones;
                                                        //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                                        dO.Rows.Add(row2);
                                                        Session["OBSERVACIONES"] = dO;


                                                        //alerError2.Visible = true;
                                                        //lblError2.Text = "Esta inscripto en ese Espacio Curricular para el año ingresado ";
                                                        //return;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        EspCurricular = Convert.ToString(GrillaMaterias.DataKeys[row3.RowIndex].Values["Nombre"].ToString());
                                        //CadenaEspacios.Add(EspCurricular);
                                        //ControlFaltaCorrelativa = 0;
                                        Observaciones = "No tiene las correlativas correspondientes:  " + String.Join(", ", CadenaEspacios);

                                        DataTable dO = new DataTable();
                                        dO = Session["OBSERVACIONES"] as DataTable;
                                        DataRow row2 = dO.NewRow();

                                        row2["lblAlumno3"] = EspCurricular;
                                        row2["lblObservaciones"] = Observaciones;
                                        //row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                                        dO.Rows.Add(row2);
                                        Session["OBSERVACIONES"] = dO;
                                        //alerError2.Visible = true;
                                        //lblError2.Text = "No tiene las correlativas correspondientes:  " + String.Join(", ", CadenaEspacios);
                                        //Console.WriteLine(String.Join(", ", CadenaEspacios));

                                        Error = 1;

                                    }
                                }
                            }
                        }
                    }
                }

                DataTable dt3 = new DataTable();
                dt3 = Session["OBSERVACIONES"] as DataTable;
                DataTable dtTraeEspCur = new DataTable();

                if (dt3.Rows.Count > 0)
                {
                    TituloCondición.Visible = true;
                    GridErrores.Visible = true;
                    GridErrores.DataSource = dt3;
                    GridErrores.DataBind();
                }
                else
                {
                    TituloCondición.Visible = false;
                    GridErrores.Visible = false;
                    GridErrores.DataSource = dt3;
                    GridErrores.DataBind();
                }
                foreach (GridViewRow row in GrillaMaterias.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

                    if (check.Checked == true)
                    {
                        check.Checked = false;
                    }
                }

                if (Convert.ToString(aluId.Text.Trim().ToString()) != "")
                {
                    dtTraeEspCur = ocnInscripcionCursadoTerciario.ObtenerMateriasInsc(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text));
                    if (dtTraeEspCur.Rows.Count > 0)
                    {
                        GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
                        GrillaMateriaConfirmar.DataBind();

                    }
                    Session.Add("TablaMatConf", dtTraeEspCur);
                }
            }

            else
            {
                alerError2.Visible = true;
                lblError2.Text = "No seleccionó ningún Espacio Curricular";
            }
        }
        else
        {
            alerError2.Visible = true;
            lblError2.Text = "No seleccionó ningún Alumno";
        }
    }
    //GrillaMaterias.DataSource = null;
    //this.GrillaMaterias.DataBind();
    //btnSeleccionarTodo.Visible = false;
    //btnAgregarMateria.Visible = false;



    protected void CondicionId_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //insId = Convert.ToInt32(Session["_Institucion"]);
        //GrillaMaterias.DataSource = null;
        //this.GrillaMaterias.DataBind();
        //GrillaMateriaConfirmar.DataSource = null;
        //this.GrillaMateriaConfirmar.DataBind();
        //btnSeleccionarTodo.Visible = false;
        //btnAgregarMateria.Visible = false;
        //TituloCondición.Visible = false;
        //GridErrores.DataSource = null;
        //GridErrores.DataBind();
        //DataTable dtOBSERVACIONES = new DataTable();
        //dtOBSERVACIONES.Columns.Add("lblAlumno3", typeof(String));
        //dtOBSERVACIONES.Columns.Add("lblObservaciones", typeof(String));
        //GridErrores.DataSource = dtOBSERVACIONES;
        //GridErrores.DataBind();
        //Session["OBSERVACIONES"] = dtOBSERVACIONES;
        //GridErrores.Visible = false;
        //GrillaMaterias.Visible = false;
        //GrillaMateriaConfirmar.Visible = false;
        //DataTable dtNew = new DataTable();
        //dtNew.Columns.Add("Id", typeof(int));
        //dtNew.Columns.Add("Nombre", typeof(String));
        //dtNew.Columns.Add("FormatoDictado", typeof(String));
        //dtNew.Columns.Add("Regimen", typeof(String));
        ////dtNew.Columns.Add("Condicion", typeof(String));
        //Session.Add("TablaTemp", dtNew);
        //DataTable dtNew2 = new DataTable();
        //dtNew2.Columns.Add("escId", typeof(int));
        //dtNew2.Columns.Add("Nombre", typeof(String));
        //dtNew2.Columns.Add("FormatoDictado", typeof(String));
        //dtNew2.Columns.Add("Regimen", typeof(String));
        ////dtNew2.Columns.Add("Condicion", typeof(String));
        //dtNew2.Columns.Add("Id", typeof(String));
        //Session.Add("TablaMatConf", dtNew2);
        //DataTable dt = new DataTable();
        //dt.Columns.Add("Id", typeof(Int32));
        //dt.Columns.Add("conId", typeof(Int32));
        //dt.Columns.Add("cntId", typeof(Int32));
        //dt.Columns.Add("TipoConcepto", typeof(String));
        //dt.Columns.Add("Concepto", typeof(String));
        //dt.Columns.Add("Importe", typeof(Decimal));
        //dt.Columns.Add("Beca", typeof(String));
        //dt.Columns.Add("BecId", typeof(Int32));
        //dt.Columns.Add("NroCuota", typeof(Int32));
        //dt.Columns.Add("AnioLectivo", typeof(Int32));
        //dt.Columns.Add("FchInscripcion", typeof(string));
        //GrillaConcepto.DataSource = dt;
        //GrillaConcepto.DataBind();
        //Session["Datos"] = dt;


        //NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
        //ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
        //CondicionId.DataValueField = "Valor"; CondicionId.DataTextField = "Texto"; CondicionId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerListaInsc("[Seleccionar...]"); CondicionId.DataBind();
        //if ((Session["_perId"].ToString() == "16"))  // Si es terciario 
        //{
        //    PanelConcepto.Visible = false;
        //    CondicionMostrar.Visible = true;
        //    btnNuevoAlumno.Enabled = false;
        //    NivelID.SelectedValue = "4";
        //    CondicionId.SelectedValue = "1";
        //    NivelID.Enabled = false;
        //    carId.Enabled = true;
        //    DataTable dt2 = new DataTable();
        //    int nivel = Convert.ToInt32(NivelID.SelectedValue);
        //    dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

        //    if (dt2.Rows.Count > 0)
        //    {
        //        carId.DataValueField = "Valor";
        //        carId.DataTextField = "Texto";
        //        carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
        //        carId.DataBind();

        //    }
        //    tituloMateria.Visible = false;
        //    TituloMaterisIns.Visible = false;
        //    TextBuscar.Text = "";
        //    aludni.Text = "";
        //    aluNombre.Text = "";
        //    aluId.Text = "";
        //    carId.SelectedValue = "0";
        //    plaId.SelectedValue = "0";
        //    curId.SelectedValue = "0";
        //    btnLimpiar.Visible = false;
        //    btnSalir.Visible = false;
        //    TextBuscar.Focus();
        Response.Redirect("InscripcionCursadoRegistracionTerc.aspx?Id=0", false);
        //}
    }

    protected void btnSalir_Click(object sender, EventArgs e)
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

    protected void btnAlumno_Click(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);

        GrillaMateriaConfirmar.DataSource = null;
        this.GrillaMateriaConfirmar.DataBind();
        btnSeleccionarTodo.Visible = true;
        btnAgregarMateria.Visible = true;
        //TituloCondición.Visible = false;
        GridErrores.DataSource = null;
        GridErrores.DataBind();
        DataTable dtOBSERVACIONES = new DataTable();
        dtOBSERVACIONES.Columns.Add("lblAlumno3", typeof(String));
        dtOBSERVACIONES.Columns.Add("lblObservaciones", typeof(String));
        GridErrores.DataSource = dtOBSERVACIONES;
        GridErrores.DataBind();
        Session["OBSERVACIONES"] = dtOBSERVACIONES;
        //GridErrores.Visible = false;
        //GrillaMaterias.Visible = false;
        //GrillaMateriaConfirmar.Visible = false;
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("Id", typeof(int));
        dtNew.Columns.Add("Nombre", typeof(String));
        dtNew.Columns.Add("FormatoDictado", typeof(String));
        dtNew.Columns.Add("Regimen", typeof(String));
        //dtNew.Columns.Add("Condicion", typeof(String));
        Session.Add("TablaTemp", dtNew);
        DataTable dtNew2 = new DataTable();
        dtNew2.Columns.Add("escId", typeof(int));
        dtNew2.Columns.Add("Nombre", typeof(String));
        dtNew2.Columns.Add("FormatoDictado", typeof(String));
        dtNew2.Columns.Add("Regimen", typeof(String));
        //dtNew2.Columns.Add("Condicion", typeof(String));
        dtNew2.Columns.Add("Id", typeof(String));
        Session.Add("TablaMatConf", dtNew2);
        //DataTable dt = new DataTable();
        //dt.Columns.Add("Id", typeof(Int32));
        //dt.Columns.Add("conId", typeof(Int32));
        //dt.Columns.Add("cntId", typeof(Int32));
        //dt.Columns.Add("TipoConcepto", typeof(String));
        //dt.Columns.Add("Concepto", typeof(String));
        //dt.Columns.Add("Importe", typeof(Decimal));
        //dt.Columns.Add("Beca", typeof(String));
        //dt.Columns.Add("BecId", typeof(Int32));
        //dt.Columns.Add("NroCuota", typeof(Int32));
        //dt.Columns.Add("AnioLectivo", typeof(Int32));
        //dt.Columns.Add("FchInscripcion", typeof(string));
        //GrillaConcepto.DataSource = dt;
        //GrillaConcepto.DataBind();
        //Session["Datos"] = dt;


        ////NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
        ////ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
        ////CondicionId.DataValueField = "Valor"; CondicionId.DataTextField = "Texto"; CondicionId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerListaInsc("[Seleccionar...]"); CondicionId.DataBind();
        if ((Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")  // Si es terciario 
        {
            PanelConcepto.Visible = false;
            //    CondicionMostrar.Visible = true;
            //btnNuevoAlumno.Enabled = false;

            tituloMateria.Visible = true;
            TituloMaterisIns.Visible = false;
            TextBuscar.Text = "";
            aludni.Text = "";
            aluNombre.Text = "";
            aluId.Text = "";
            foreach (GridViewRow row in GrillaMaterias.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

                if (check.Checked == true)
                {
                    check.Checked = false;
                }
            }

            CondicionId.DataValueField = "Valor"; CondicionId.DataTextField = "Texto"; CondicionId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerListaInsc("[Seleccionar...]"); CondicionId.DataBind();

            CondicionId.SelectedValue = "1";

            //Button1.Text.TabIndex(0);
            //this.ActiveControl = textBox1;
            //textBox1.Focus();

            Button1.Focus();



            //    btnLimpiar.Visible = false;
            //    btnSalir.Visible = false;
            //    TextBuscar.Focus();
        }
    }



}






