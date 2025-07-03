using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InscripcionCursadoRegistracion : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();

    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
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
                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false; 
                    btnInscribir.Visible = false;
                }

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
                    ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerListaSinUno("[Seleccionar...]", 4); ConTipoId.DataBind();

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
            CanReg.Visible = false;
            Session["InscripcionCursadoRegistracion.PageIndex"] = PageIndex;

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
                }
                else
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "No se encuentra Alumno con esa descripción o DNI";
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
                }
                else
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "No se encuentra Alumno con esa descripción o DNI";
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
                    aluNombre.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    aluNombre.Enabled = false;
                    aludni.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    aludni.Enabled = false;
                    aluId.Text = Id;
                    CanReg.Visible = false;
                    Grilla.DataSource = null;
                    Grilla.DataBind();
                    //Grilla.Text= ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;

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
        GrillaConcepto.DataBind();
        aluNombre.Text = "";
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["IncripcionCursadoConsulta.PageIndex"]);
        GrillaCargar(PageIndex);
        //this.ConceptoId.SelectedValue = "0";
        //this.BecaId.SelectedValue = "0";

    }

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
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
        base.Render(writer);
    }

    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Inicio.aspx", true);
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

    protected void btnInscribir_Click(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            alerErrorConcepto.Visible = false;
            alerConceptoyaRegistrado.Visible = false;
            alerConceptoyaRegistrado2.Visible = false;
            int ban = 0;
            CanReg.Visible = false;
            alerConceptoyaIngresado.Visible = false;
            alerInscripción2.Visible = false;
            alerInscripción.Visible = false;
            alerRepetido.Visible = false;
            alerAlumno.Visible = false;
            alerCarrera.Visible = false;
            alerCurso.Visible = false;
            alerConcepto.Visible = false;
            alerPagar.Visible = false;
            alerPlan.Visible = false;
            alerAnio.Visible = false;
            alerErrorInsc.Visible = false;
            dt = new DataTable();
            insId = Convert.ToInt32(Session["_Institucion"]);
            lblMensajeError.Visible = false;
            string MensajeValidacion = "";
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

            if (Convert.ToInt32(NivelID.SelectedValue) == 4)

            {
                //if (Convert.ToInt32(camId.SelectedValue) <= 0)
                //{
                //    lblMensajeError.Visible = true;
                //    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
                //    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                //    <a class=""alert-link"" href=""#"">No seleccionó un Campo!..<br/> NO SE REALIZÓ LA INSCRIPCIÓN!!</a><br/>" + MensajeValidacion + "</div>";
                //    return;
                //}

                //if (Convert.ToInt32(escId.SelectedValue) <= 0)
                //{
                //    lblMensajeError.Visible = true;
                //    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
                //    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                //    <a class=""alert-link"" href=""#"">No seleccionó un Espacio Curricular!..<br/> NO SE REALIZÓ LA INSCRIPCIÓN!!</a><br/>" + MensajeValidacion + "</div>";
                //    return;
                //}
            }

            if (icuAnioCursado.Text.Trim() == "")
            {
                alerAnio.Visible = true;
                return;
            }

            int ControlFaltaCorrelativa = 0;
            int ControlExiste = 0;
            int Id = 0;
            if (Request.QueryString["Id"] != null)
            {
                //SI el alumno es nuevo lo doy de alta si no existe en alumno..  leo el aluId.. 
                if (aluId.Text.Trim() == "")
                {
                    DataTable dt2 = new DataTable();
                    dt2 = ocnAlumno.ObtenerUnoporDoc(aludni.Text);
                    if (dt2.Rows.Count == 0)//Alumno no existe
                    {
                        ocnAlumno.aluDoc = aludni.Text;
                        ocnAlumno.aluNombre = aluNombre.Text;
                        ocnAlumno.aluLegajoNumero = "";
                        ocnAlumno.aluCuit = "";
                        ocnAlumno.aluDomicilio = "";
                        ocnAlumno.aluDepto = 0;
                        ocnAlumno.aluFechaNacimiento = DateTime.Now;
                        ocnAlumno.aluPaisNac = 0;
                        ocnAlumno.aluProvNac = 0;
                        ocnAlumno.aluDeptoNac = 0;
                        ocnAlumno.aluLocNac = 0;
                        ocnAlumno.aluMail = "";
                        ocnAlumno.aluTelefono = "";
                        ocnAlumno.aluTelefonoCel = "";
                        ocnAlumno.aluActivo = true;
                        ocnAlumno.sexId = 0;
                        //                this.sexId.SelectedValue = (ocnAlumno.sexId == 0 ? "" : ocnAlumno.sexId.ToString());

                        ocnAlumno.aluFechaHoraCreacion = DateTime.Now;
                        ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
                        ocnAlumno.usuIdCreacion = this.Master.usuId;
                        ocnAlumno.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAlumno.gsaId = 0;
                        ocnAlumno.aluTelUrgencias = "";
                        ocnAlumno.aluDomFliar = "";
                        ocnAlumno.aluPreg1 = "";
                        ocnAlumno.aluPreg2 = "";
                        ocnAlumno.aluPreg3 = "";
                        ocnAlumno.aluPreg4 = "";
                        ocnAlumno.aluPreg5 = "";
                        ocnAlumno.aluPreg6 = "";
                        ocnAlumno.aluPreg7 = "";
                        ocnAlumno.aluAclara = "";
                        //Nuevo
                        int aluId2 = ocnAlumno.Insertar();
                        DataTable dt7 = new DataTable();
                        //dt7 = ocnAlumno.ObtenerUltimoId();
                        //if (dt7.Rows.Count > 0)
                        //{
                        aluId.Text = Convert.ToString(aluId2);
                        //}
                    }
                    else //Alumno existe
                    {
                        this.aluId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
                        ban = 1;

                    }
                }

                if (Convert.ToInt32(NivelID.SelectedValue) == 4) //Terciario
                {
                    ///Controlo que el alumno no se encuentre inscripto en esa materia en ese año
                    DataTable dt2 = new DataTable();
                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text.Trim().ToString()));
                    //ObtenerUnoControlExiste(Int32 x, Int32 escId)
                    if (dt2.Rows.Count > 0)
                    {
                        ControlExiste = 1;
                        lblicuId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
                    }
                }
                else  ///Si no es Terciario Controlo que el alumno no se encuentre inscripto en ese curso en ese año
                {
                    DataTable dt2 = new DataTable();
                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(icuAnioCursado.Text.Trim().ToString()));
                    if (dt2.Rows.Count > 0)
                    {
                        ControlExiste = 1;
                        lblicuId.Text = Convert.ToString(dt2.Rows[0]["Id"]);
                    }
                }

                if (ControlExiste == 0)// Sino fué cargada anteriormente
                {
                    DataTable dtMismoAnio = new DataTable();
                    dtMismoAnio = ocnInscripcionCursado.ObtenerUnoControlExisteMismoAño(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(icuAnioCursado.Text.Trim().ToString()));

                    if (dtMismoAnio.Rows.Count > 0) // Está en otro cueso mismo año?
                    {
                        alerError2.Visible = true;
                        lblError2.Text = string.Format("El alumno: {1}  se encuentra inscripto en el curso: {0} para ese mismo año", Convert.ToString(dtMismoAnio.Rows[0]["Curso"]), Convert.ToString(dtMismoAnio.Rows[0]["Alumno"]));
                    }

                    else
                    {
                        if (ControlFaltaCorrelativa == 0)  // Si estan bien las correlativas Inserto Ins. Cursado
                        {
                            int carIdO = 0;
                            int plaIdO = 0;
                            Id = Convert.ToInt32(Request.QueryString["Id"]);
                            ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
                            ocnInscripcionCursado.insId = insId;
                            ocnInscripcionCursado.icuAnoCursado = Convert.ToInt32(icuAnioCursado.Text);
                            AnioLectivo = Convert.ToInt32(icuAnioCursado.Text);
                            ocnInscripcionCursado.icuFechaInscripcion = Convert.ToDateTime(icuFechaInscripcion.Text);
                            ocnInscripcionCursado.icuActivo = icuActivo.Checked;
                            //String alumnoId = aluId.Text
                            ocnInscripcionCursado.aluId = Convert.ToInt32(aluId.Text);
                            ocnInscripcionCursado.icuEstado = 1;
                            if (Convert.ToInt32(NivelID.SelectedValue) == 4)
                            {
                                ocnInscripcionCursado.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
                                ocnInscripcionCursado.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                            }
                            else
                            {
                                DataTable dt3 = new DataTable();
                                DataTable dt4 = new DataTable();
                                dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
                                carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
                                plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                                ocnInscripcionCursado.carId = carIdO;
                                ocnInscripcionCursado.plaId = plaIdO;

                            }
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

                            int icuId = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso o Materia
                            lblicuId.Text = Convert.ToString(icuId);
                            alerInscripción2.Visible = true;
                            //////////////////////////////////////////////////////

                            if (((Convert.ToInt32(NivelID.SelectedValue) == 3) || (Convert.ToInt32(NivelID.SelectedValue) == 2)))//Si es Secundario o Primario
                            {
                                //recorro una tabla d materias para registrar nota por esp cur
                                DataTable dt5 = new DataTable();
                                DataTable dt6 = new DataTable();
                                dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId.SelectedValue), insId);
                                if (dt5.Rows.Count > 0)
                                {
                                    // Por Cada Materia inserto un registro Nota para ese alumno.
                                    foreach (DataRow row in dt5.Rows)
                                    {
                                        int escId2 = Convert.ToInt32(row["Id"].ToString());
                                        ocnRegistracionNota.Insertar(icuId, escId2, 1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                    }
                                }
                            }

                            DataTable dt2 = new DataTable();
                            dt2 = Session["Datos"] as DataTable;
                            if (dt2.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt2.Rows)
                                {
                                    int conId = Convert.ToInt32(row["conId"].ToString());
                                    Decimal Importe = Convert.ToDecimal(row["Importe"].ToString());
                                    DateTime FchaInscripcion = Convert.ToDateTime(row["FchInscripcion"].ToString());
                                    Int32 NroCuota = Convert.ToInt32(row["NroCuota"].ToString());
                                    Int32 bcaId = Convert.ToInt32(row["BecId"].ToString());

                                    ocnInscripcionConcepto.Insertar(icuId, conId, Importe, FchaInscripcion, NroCuota, bcaId, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                }

                                btnAgregar.Enabled = false;
                                ConTipoId.Enabled = false;
                                ConceptoId.Enabled = false;
                                BecaId.Enabled = false;
                                btnPagar.Enabled = true;
                                btnInscribir.Enabled = false;
                                GrillaConcepto.Columns[0].Visible = true;

                                alerPagar.Visible = true;
                                alerInscripción.Visible = true;

                                //Response.Redirect("InscripcionCursadoConsulta.aspx", true);
                            }

                        }                    //    else
                                             //    {
                                             //        lblMensajeError.Visible = true;
                                             //        Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                        //        lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
                        //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        //<a class=""alert-link"" href=""#"">El alumno seleccionado no posee las asignaturas correlativas necesarias para cursar..<br/>
                        //Verifique!!</a><br/>" + MensajeValidacion + "</div>";
                        //    }
                    }
                }
                else //existe Inscripción Cursado
                {
                    int Band = 0;
                    DataTable dt2 = new DataTable();
                    dt2 = Session["Datos"] as DataTable;
                    if (dt2.Rows.Count > 0)
                    {
                        int icuId = Convert.ToInt32(lblicuId.Text);
                        foreach (DataRow row in dt2.Rows)
                        {
                            int conId = Convert.ToInt32(row["conId"].ToString());
                            Decimal Importe = Convert.ToDecimal(row["Importe"].ToString());
                            DateTime FchaInscripcion = Convert.ToDateTime(row["FchInscripcion"].ToString());
                            Int32 NroCuota = Convert.ToInt32(row["NroCuota"].ToString());
                            Int32 bcaId = Convert.ToInt32(row["BecId"].ToString());
                            DataTable dt5 = new DataTable();
                            dt5 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(icuId, conId, NroCuota);
                            if (dt5.Rows.Count == 0)//  No se repite concepto
                            {
                                ocnInscripcionConcepto.Insertar(icuId, conId, Importe, FchaInscripcion, NroCuota, bcaId, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                Band = 1;
                            }
                        }
                        if (Band == 1)
                        {
                            btnAgregar.Enabled = false;
                            ConTipoId.Enabled = false;
                            ConceptoId.Enabled = false;
                            BecaId.Enabled = false;
                            btnPagar.Enabled = true;
                            btnInscribir.Enabled = false;
                            alerInscripción.Visible = true;
                            GrillaConcepto.Columns[0].Visible = true;
                            alerPagar.Visible = true;

                        }
                        else
                        {
                            alerRepetido.Visible = true;
                        }

                        //Response.Redirect("InscripcionCursadoConsulta.aspx", true);
                    }
                    else
                    {
                        if (ControlExiste != 0)
                        {
                            alerErrorInsc.Visible = true;
                        }
                    }
                }
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button  aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
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
        if (curId.SelectedIndex != 0)
        {
            alerError2.Visible = false;

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            insId = Convert.ToInt32(Session["_Institucion"]);
            DataTable dt = new DataTable();
            dt = ocnEspacioCurricular.ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId);

            if (curId.SelectedValue != "")
            {
                if (dt.Rows.Count > 0)
                {
                    //escId.DataValueField = "Valor";
                    //escId.DataTextField = "Texto";
                    //escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId);
                    //escId.DataBind();
                }
            }

        }
    }


    //protected void camId_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    insId = Convert.ToInt32(Session["_Institucion"]);
    //    if (camId.SelectedIndex != 0)
    //    {

    //        //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
    //        DataTable dt = new DataTable();
    //        dt = ocnEspacioCurricular.ObtenerListaPorUnCampo("[Seleccionar...]", Convert.ToInt32(camId.SelectedValue),insId);
    //        if (dt.Rows.Count > 0)
    //        {
    //            escId.DataValueField = "Valor";
    //            escId.DataTextField = "Texto";
    //            escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCampo("[Seleccionar...]", Convert.ToInt32(camId.SelectedValue),insId);
    //            escId.DataBind();
    //        }
    //    }
    //}


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
        btnNuevoAlumno.Enabled = true;
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
                    if (ConTipoId.SelectedValue == "1" || ConTipoId.SelectedValue == "5")
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
                                        if ((Convert.ToInt32(row["cntId"].ToString()) == 1 || Convert.ToInt32(row["cntId"].ToString()) == 5))
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

                    if (ConTipoId.SelectedValue == "1" || ConTipoId.SelectedValue == "5")
                    {
                        if (dt.Rows.Count > 0)//chequeo que no haya ingresado ese concepto en la tabla..
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (Convert.ToInt32(row["Id"].ToString()) == 1)
                                {
                                    if ((Convert.ToInt32(row["cntId"].ToString()) == 1 || Convert.ToInt32(row["cntId"].ToString()) == 5))
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
                    if (ConTipoId.SelectedValue == "1" || ConTipoId.SelectedValue == "5")
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
            dt2 = ocnCarrera.ObtenerLista("[Seleccionar...]");
            Convert.ToInt32(NivelID.SelectedValue);
            if (dt2.Rows.Count > 0)
            {
                carId.DataValueField = "Valor";
                carId.DataTextField = "Texto";
                carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
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
        ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
        ConceptoId.ClearSelection();
    }
}






