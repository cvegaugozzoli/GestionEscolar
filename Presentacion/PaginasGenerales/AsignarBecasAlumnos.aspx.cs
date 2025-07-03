using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AsignarBecasAlumnos : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    int insId;
    DataTable dt2 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();

    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();

    DataTable dt1 = new DataTable();

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Asignar Becas x Alumno";
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                dt = ocnUsuario.ObtenerUno(usuario);

                BecaId.DataValueField = "Valor"; BecaId.DataTextField = "Texto"; BecaId.DataSource = (new GESTIONESCOLAR.Negocio.Becas()).ObtenerLista("[Seleccionar...]"); BecaId.DataBind();
                ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
                AnioCursado.Text = Convert.ToString(DateTime.Now.Year);
                insId = Convert.ToInt32(Session["_Institucion"]);
                btnAplicar.Visible = false;
                btnCancelar.Visible = false;
                lblBecas.Visible = false;
                lblProcentaje.Visible = false;
                lblTconc.Visible = false;
                ConTipoId.Visible = false;
                lblConcepto.Visible = false;
                ConceptoId.Visible = false;
                rbtAgregarQuitar.Visible = false;
                BecaId.Visible = false;

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "15")) // Si es administrador o Director o Secretaria veo todas las carreras
                {

                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

                    //carId.Enabled = true;
                    //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["ListadoAlumnosxCurso.PageIndex"] == null)
                {
                    Session.Add("ListadoAlumnosxCurso.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CursoListadoCalifxAlumno.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

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
    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
        int car = 0;
        int pla = 0;
        if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
        {
            carId.Enabled = true;
            carId.DataValueField = "Valor";
            carId.DataTextField = "Texto";
            carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
            carId.DataBind();
            carId.Enabled = true;

        }
        else// es primario inicial o secundario
        {

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
            if (dt3.Rows.Count > 0)
            {
                car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
                if (dt4.Rows.Count > 0)
                {
                    pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                }
            }
            curId.DataValueField = "Valor";
            curId.DataTextField = "Texto";
            curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", pla);
            curId.DataBind();
            carId.Enabled = false;
            plaId.Enabled = false;
            carId.SelectedValue = "0";
            plaId.SelectedValue = "0";
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



    private void GrillaCargar(int PageIndex)
    {
        try
        {
            if (Convert.ToInt32(NivelID.SelectedValue) == 0)
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nivel ";
                return;
            }

            CanReg.Visible = false;
            lblCantidadRegistros.Text = "";

            Session["AsignarBecasAlumnos.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros

            #endregion
            //cur = Convert.ToInt32(curId.SelectedValue);
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 car = 0;
            Int32 pla = 0;

            if (Convert.ToInt32(NivelID.SelectedValue) == 4)
            {
                if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
                {
                    car = Convert.ToInt32(carId.SelectedValue.ToString());
                    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
                    {
                        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
                    }
                    else
                    {
                        alerError.Visible = false;
                        lblError.Text = "Debe ingresar un Plan ";
                        return;
                    }
                }
                else
                {
                    alerError.Visible = false;
                    lblError.Text = "Debe ingresar una Carrera ";
                    return;

                }
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());

            }
            else
            {
                alerError.Visible = false;
                lblError.Text = "Debe ingresar un Curso";
                return;

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

            dt = new DataTable();
            //dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, car, pla, cur, AnioCur, 1);
            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);

            if (dt.Rows.Count > 0)
            {

                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                btnAplicar.Visible = true;
                btnCancelar.Visible = true;
                lblBecas.Visible = true;
                lblProcentaje.Visible = true;
                lblTconc.Visible = true;
                ConTipoId.Visible = true;
                lblConcepto.Visible = true;
                ConceptoId.Visible = true;
                rbtAgregarQuitar.Visible = true;
                BecaId.Visible = true;
                lblMej.Text = "";
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                //GridView gridtemp = new GridView();
                CanReg.Visible = true;
                gridtemp.DataSource = dt;

                gridtemp.DataBind();

                lblCantidadRegistros.Text = Convert.ToString(dt.Rows.Count);
                TextTC.Text = dt.Rows[0]["TipoCarrera"].ToString();

            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
                lblMej.Text = "No exite familia con esa cantidad de hijos";
                btnAplicar.Visible = false;
                btnCancelar.Visible = false;
                lblBecas.Visible = false;
                lblProcentaje.Visible = false;
                lblTconc.Visible = false;
                ConTipoId.Visible = false;
                lblConcepto.Visible = false;
                ConceptoId.Visible = false;
                rbtAgregarQuitar.Visible = false;
                BecaId.Visible = false;
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();

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

    protected void ConTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
                dt = ocnConceptos.ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
                if (dt.Rows.Count > 1)
                {
                    ConceptoId.DataValueField = "Valor";
                    ConceptoId.DataTextField = "Texto";
                    ConceptoId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
                    ConceptoId.DataBind();
                }
                else
                {
                    //alerErrorConcepto.Visible = true;
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
                    //BecaId.DataValueField = "Valor";
                    //BecaId.DataTextField = "Texto";
                    //BecaId.DataSource = (new GESTIONESCOLAR.Negocio.Becas()).ObtenerLista("[Seleccionar...]");
                    //BecaId.DataBind();
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
            insId = Convert.ToInt32(Session["_Institucion"]);
            dt2 = new DataTable();
            dt1 = new DataTable();
            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime FechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int IdUltimaModificacion = this.Master.usuId;

            int BecaId2 = 1;
            int Bandera = 0;
            int Bandera2 = 0;

            if (Convert.ToInt32(ConTipoId.SelectedValue) != 0)
            {
                if (Convert.ToInt32(rbtAgregarQuitar.SelectedValue) == 0)//Quitar
                {
                    BecaId2 = 1;
                    Bandera = 0;
                }
                else
                {
                    if (Convert.ToInt32(rbtAgregarQuitar.SelectedValue) == 1)//Asignar
                    {
                        if (Convert.ToInt32(BecaId.SelectedValue) != 1)
                        {
                            DataTable dt4 = ocnBecas.ObtenerUno(Convert.ToInt32(BecaId.SelectedValue));
                            BecaId2 = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                            Bandera = 1;
                        }
                        else
                        {
                            lblMej.Text = "Debe seleccionar un  Porcentaje de Beca";
                            ConTipoId.Focus();
                            return;
                        }
                    }
                }

                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if ((check.Checked)) // Si esta seleccionado..
                    {
                        dt2 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, Convert.ToInt32(AnioCursado.Text), Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]));

                        dt1 = ocnInscripcionConcepto.TraerxIcuId(Convert.ToInt32(dt2.Rows[0]["Id"].ToString()));
                        if (dt2.Rows.Count > 0)
                        {
                            lblIcuId.Text = dt2.Rows[0]["Id"].ToString();
                            if (dt1.Rows.Count > 0)
                            {
                                if (ConTipoId.SelectedValue == "2")//Cuotas
                                {
                                    if (CuotaId.SelectedValue == "0")// eligio todas cuota
                                    {
                                        foreach (DataRow row5 in dt1.Rows)// por cada concepto..
                                        {
                                            int tipoConcepto = Convert.ToInt32(row5["cntId"].ToString());
                                            if (tipoConcepto == Convert.ToInt32(ConTipoId.SelectedValue))
                                            {
                                                int icoId = Convert.ToInt32(row5["Id"].ToString());
                                                ocnInscripcionConcepto.ActualizarBeca(icoId, BecaId2, true, usuIdCreacion, IdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                                Bandera2 = 1;
                                            }
                                        }
                                    }
                                    else //eligio una cuota
                                    {
                                        DataTable dt7 = new DataTable();
                                        dt7 = ocnInscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota(Convert.ToInt32(lblIcuId.Text), Convert.ToInt32(ConceptoId.SelectedValue), Convert.ToInt32(CuotaId.SelectedValue));
                                        int icoId = Convert.ToInt32(dt7.Rows[0]["Id"].ToString());
                                        ocnInscripcionConcepto.ActualizarBeca(icoId, BecaId2, true, usuIdCreacion, IdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                        Bandera2 = 1;
                                    }
                                }
                                else
                                {
                                    if (ConTipoId.SelectedValue == "1")//Inscripcion
                                    {
                                        foreach (DataRow row5 in dt1.Rows)// por cada concepto..
                                        {
                                            int tipoConcepto = Convert.ToInt32(row5["cntId"].ToString());
                                            if (tipoConcepto == Convert.ToInt32(ConTipoId.SelectedValue))
                                            {
                                                int icoId = Convert.ToInt32(row5["Id"].ToString());
                                                ocnInscripcionConcepto.ActualizarBeca(icoId, BecaId2, true, usuIdCreacion, IdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                                Bandera2 = 1;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                alerError2.Visible = false;
                                lblError2.Text = "Tabla Incripción Cursado Vacía";
                          
                            }
                        }
                        else
                        {
                            alerError2.Visible = false;
                            lblError2.Text = "Tabla Incripción Concepto Vacía";
                        }
                    }
                }
                if (Bandera2 == 1)
                {
                    if (Bandera == 1)
                    {
                        alerExito.Visible = true;
                        GrillaCargar(Grilla.PageIndex);
                    }
                    else
                    {
                        alerExito2.Visible = true;
                        GrillaCargar(Grilla.PageIndex);

                    }
                }
                else
                {
                    lblMej.Text = "No se actualizó Becas.. Seleccionó registros?..";
                }
            }

            else
            {
                lblMej.Text = "Debe seleccionar un Tipo de Concepto";
                ConTipoId.Focus();
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
                string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                //if (e.CommandName == "Eliminar")
                //{
                //    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                //    ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Convert.ToInt32(IC));
                //    //ocnCurso.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                if (e.CommandName == "Ver")
                {
                    String TC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Controls[1]).Text;
                    if (TC == "4")
                    {
                        Response.Redirect("RegistracionCalificacionesRegistracion.aspx?Id=" + IC + "&Ver=1", false);
                    }
                    else
                    {
                        if (TC == "3")
                        {
                            Response.Redirect("CargaCalificacionesPorAlumnoSec.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                        }
                        else
                        {
                            if (TC == "2")
                            {
                                Response.Redirect("CargaCalificacionesPorAlumnoPri.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                            }
                        }
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
            if (Session["ListadoAlumnosxCurso.PageIndex"] != null)
            {
                Session["ListadoAlumnosxCurso.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ListadoAlumnosxCurso.PageIndex", e.NewPageIndex);
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



    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        alerError.Visible = false;
        GrillaCargar(Grilla.PageIndex);
    }


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
        {
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



    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        plaIdCargar();
    }
    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        //int usuario = Convert.ToInt32(Session["_usuId"].ToString());
        //dt = ocnUsuarioEspacioCurricular.ObtenerUno(usuario);
        //if (dt.Rows[0]["carTipoCarrera"].ToString() == "3") // Si el Tipo de carrera es igual a 3 === Secundario
        //{

        //    //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxusuIdyCur("[Seleccionar...]", usuario, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();

        //}
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

    protected void btnImprimir(object sender, EventArgs e)
    {
        alerError.Visible = true;
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 curso = Int32.Parse(curId.SelectedValue.ToString());
            Int32 anio = 0;
            if (AnioCursado.Text.Trim().ToString() != "")
            {
                anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }

            NomRep = "ListadoPorCursoAnioBeca.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?curso=" + curso + "&anio=" + anio + "&insId=" + insId + "&NomRep=" + NomRep);
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
            if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "5")) // Si es administrador o preceptora

            {
                int Id = 0;
                Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
                int usuIdCreacion = this.Master.usuId;
                ocnRegistracionNota.EliminarporIC(Id, usuIdCreacion);
                ocnInscripcionCursado.Eliminar(Id, usuIdCreacion);

                ((Button)sender).Parent.Controls[1].Visible = true;
                ((Button)sender).Parent.Controls[3].Visible = false;
                ((Button)sender).Parent.Controls[5].Visible = false;

                GrillaCargar(Grilla.PageIndex);


            }
            else
            {
                //lblMensajeError2.Text = "Su perfil no permite realizar esta operación";
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

    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

}