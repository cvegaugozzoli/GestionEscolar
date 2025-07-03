using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CargaNotasEvalTerc : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.Correlativa ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.CondicionParametrosFijos ocnCondicionParametrosFijos = new GESTIONESCOLAR.Negocio.CondicionParametrosFijos();
    GESTIONESCOLAR.Negocio.CondicionParametros ocnCondicionParametros = new GESTIONESCOLAR.Negocio.CondicionParametros();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();

    int insId;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                DataTable dtCorrelativas = new DataTable();
                dtCorrelativas.Columns.Add("lblAlumno3", typeof(String));
                dtCorrelativas.Columns.Add("lblObservaciones", typeof(String));
                GridCorrelativas.DataSource = dtCorrelativas;
                GridCorrelativas.DataBind();
                Session["Correlativas"] = dtCorrelativas;
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                this.Master.TituloDelFormulario = " Notas - Consulta / Registración";

                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")  // Si es administrador o Director veo todas las carreras
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);

                    int niv = 4; // Terciario

                    carId.Enabled = true;
                    DataTable dt2 = new DataTable();

                    dt2 = ocnCarrera.ObtenerUnoxNivel(niv);

                    if (dt2.Rows.Count > 0)
                    {
                        carId.DataValueField = "Valor";
                        carId.DataTextField = "Texto";
                        carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", niv);
                        carId.DataBind();

                        lblColegio.Text = "INSTITUTO SUPERIOR SAN JOSÉ";
                    }


                    //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));

                    //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                }

                else
                {
                    if (Session["_perId"].ToString() == "2")// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                    }

                    if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "23"))  // Si es Prof Hs Catedra es Terciaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerCarreraxusuId("[Seleccionar...]", upeId, 4); carId.DataBind();
                        //carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                        //carId.Enabled = false;

                        //plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                    }
                    if (Session["_perId"].ToString() == "5") // Preceptora
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    //if (Session["_perId"].ToString() == "11")   // Si es Docente Area Especia
                    //{
                    //    carId.Enabled = true;
                    //    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //}

                    //}
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["CargaCalifxEspCTerc.PageIndex"] == null)
                {
                    Session.Add("CargaCalifxEspCTerc.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion
            }
            else
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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        pnlContents.Visible = false;
        GrillaNota.DataSource = null;
        GrillaNota.DataBind();
        btnCondicion.Visible = false;
        BtnNota.Visible = false;
        btnPrint.Visible = false;
        btnActa.Visible = false;
        GrillaRecAsist.DataSource = null;
        GrillaRecAsist.DataBind();

        GrillaRecAsist2.DataSource = null;
        GrillaRecAsist2.DataBind();

        curId.SelectedValue = "0";
        escId.SelectedValue = "0";
        ExamenTipoId.SelectedValue = "0";


        int upeId = Convert.ToInt32(Session["_upeId"].ToString());

        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        if (Session["_perId"].ToString() == "23") // Profesor
        {
            plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaPlanxusuId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); plaId.DataBind();
        }
        else
        {
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue)); carId.DataBind();
                plaId.DataBind();
                plaId.Enabled = true;

                lblCarrera.Text = Convert.ToString(carId.SelectedItem);
            }
        }
    }

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaRecAsist.DataSource = null;
        GrillaRecAsist.DataBind();
        GrillaNota.DataSource = null;
        GrillaNota.DataBind();
        GrillaRecAsist2.DataSource = null;
        GrillaRecAsist2.DataBind();
        int upeId = Convert.ToInt32(Session["_upeId"].ToString());

        escId.SelectedValue = "0";
        ExamenTipoId.SelectedValue = "0";
        if (Session["_perId"].ToString() == "23") // Profesor
        {
            curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
        }
        else
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


    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaNota.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        foreach (GridViewRow row in GridCorrelativas.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                //row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaBeneficiarioP, "Select$" + row.RowIndex, true);

            }
        }
        base.Render(writer);
    }

    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "CargaCalifxEspCTerc" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            //alerExito.Visible = false;
            //alerError.Visible = false;
            alerError2.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 espc = 0;
            Int32 car = 0;
            lblAsistRoja.Visible = false;
            txtRojo.Visible = false;

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }

            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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
            GrillaNota.DataSource = null;
            GrillaNota.DataBind();
            GrillaRecAsist.DataSource = null;
            GrillaRecAsist.DataBind();
            lblAsistRoja.Visible = false;
            txtRojo.Visible = false;
            GrillaRecAsist2.DataSource = null;
            GrillaRecAsist2.DataBind();

            BtnNota.Visible = false;
            btnCondicion.Visible = false;
            btnPrint.Visible = false; btnActa.Visible = false;
            dt = new DataTable();
            dt = ocnInscripcionCursadoTerciario.ObtenerTodoxEspCxeceId(insId, espc, AnioCur, Convert.ToInt32(ExamenTipoId.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["treId"]) != 7)
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    GrillaNota.DataSource = dt;
                    GrillaNota.DataBind();


                    foreach (GridViewRow row in GrillaNota.Rows)
                    {
                        TextBox txtType = (TextBox)row.FindControl("txtNota");
                        Int32 cdn = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);



                        if (Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]) != 10) // Si esta regular habilito
                        {
                            txtType.Enabled = true;
                        }
                    }

                    BtnNota.Visible = true;
                    btnCondicion.Visible = true;
                    btnPrint.Visible = false; btnActa.Visible = false;
                    PanelActNotas.Visible = true;
                }
                else

                {
                    dt = ocnInscripcionCursadoTerciario.ObtenerTodoxAsistxRecAsist(insId, espc, AnioCur, Convert.ToInt32(curId.SelectedValue));
                    dt2 = new DataTable();
                    dt2 = ocnInscripcionCursadoTerciario.ObtenerTodoxEspCxeceId(insId, espc, AnioCur, Convert.ToInt32(ExamenTipoId.SelectedValue));

                    if (dt.Rows.Count > 0)
                    {
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                        GrillaNota.DataSource = null;
                        GrillaNota.DataBind();

                        GrillaRecAsist.DataSource = dt;
                        GrillaRecAsist.DataBind();

                        if (dt.Rows.Count == dt2.Rows.Count)
                        {
                            GrillaRecAsist2.DataSource = dt2;
                            GrillaRecAsist2.DataBind();

                            Int32 AsistenciaReg = 0;
                            DataTable dt5 = new DataTable();
                            int Promociona = 0;
                            dt5 = ocnEspacioCurricular.ObtenerUno(espc, insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                            }


                            foreach (GridViewRow row in GrillaRecAsist.Rows)
                            {
                                if (Convert.ToString(GrillaRecAsist.DataKeys[row.RowIndex].Values["Asistencia"]) != "")
                                {
                                    if (Convert.ToInt32(GrillaRecAsist.DataKeys[row.RowIndex].Values["Asistencia"]) < AsistenciaReg)
                                    {
                                        if (Convert.ToString(GrillaRecAsist.DataKeys[row.RowIndex].Values["Rec Asist 1"]) != "")
                                        {
                                            if (Convert.ToInt32(GrillaRecAsist.DataKeys[row.RowIndex].Values["Rec Asist 1"]) < AsistenciaReg)
                                            {
                                                TextBox txtType = (TextBox)GrillaRecAsist2.Rows[row.RowIndex].FindControl("txtNota");
                                                txtType.Enabled = true;
                                                row.BackColor = System.Drawing.Color.FromName("#B81822");
                                                row.ForeColor = System.Drawing.Color.White;
                                                lblAsistRoja.Visible = true;
                                                txtRojo.Visible = true;
                                                //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                                                //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;
                                            }
                                            else
                                            {
                                                TextBox txtType = (TextBox)GrillaRecAsist2.Rows[row.RowIndex].FindControl("txtNota");
                                                txtType.Enabled = true;
                                                row.BackColor = System.Drawing.Color.White;
                                                row.ForeColor = System.Drawing.Color.Black;
                                                //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                                                //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            TextBox txtType = (TextBox)GrillaRecAsist2.Rows[row.RowIndex].FindControl("txtNota");
                                            txtType.Enabled = true;
                                            row.BackColor = System.Drawing.Color.FromName("#B81822");
                                            row.ForeColor = System.Drawing.Color.White;
                                            lblAsistRoja.Visible = true;
                                            txtRojo.Visible = true;
                                            //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                                            //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        row.BackColor = System.Drawing.Color.White;
                                        row.ForeColor = System.Drawing.Color.Black;
                                        //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                                        //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;
                                    }
                                }
                            }
                        }

                        else
                        {
                            alerError2.Visible = true;
                            lblError2.Text = "Ambas Tablas deben tener el mismo número de filas. No coinciden.";
                            return;
                        }


                        BtnNota.Visible = true;
                        btnCondicion.Visible = true;
                        btnPrint.Visible = false; btnActa.Visible = false;
                        PanelActNotas.Visible = true;
                    }
                    else
                    {
                        GrillaNota.DataSource = null;
                        GrillaNota.DataBind();
                        BtnNota.Visible = false;
                        btnCondicion.Visible = false;
                        btnPrint.Visible = false; btnActa.Visible = false;
                        PanelActNotas.Visible = false;
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
                    this.GrillaCargar(this.GrillaNota.PageIndex);
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
            if (Session["CargaCalifxEspCTerc.PageIndex"] != null)
            {
                Session["CargaCalifxEspCTerc.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CargaCalifxEspCTerc.PageIndex", e.NewPageIndex);
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



    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GrillaNota.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }

    protected void TipoReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["Treg"] = 1;
        //Session.Add("datos", GridView1.DataSource);

        ////DefinirColumnasNotas();
        ////GridView1.DataSource = Session["datos"] as DataTable;
        ////GridView1.DataBind();


        //GrillaCargar(GridView1.PageIndex);

        //Session["Editar"] = 2;
        //ButtonAsignar.Enabled = true;
    }

    protected void PeriodoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ButtonAsignar.Enabled = true;

    }


    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        pnlContents.Visible = false;
        GrillaNota.DataSource = null;
        GrillaNota.DataBind();
        GrillaRecAsist.DataSource = null;
        GrillaRecAsist.DataBind();

        GrillaRecAsist2.DataSource = null;
        GrillaRecAsist2.DataBind();
        ExamenTipoId.SelectedValue = "0";
        btnCondicion.Visible = false;
        BtnNota.Visible = false;
        btnPrint.Visible = false; btnActa.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();

            lblCurso.Text = Convert.ToString(curId.SelectedItem);
        }
        else
        {

            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);

            if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "23"))
            {
                //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaEspCxusuId("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
            }
        }
    }


    protected void ButtonAsignar_Click(object sender, EventArgs e)
    {
        //int PageIndex = 0;
        //PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        //Session["Editar"] = 2;

        //String Nota = TextNotaAsignar.Text;
        //Session["datos"] = GridView1.DataSource;
        ////DefinirColumnasNotas();
        ////GridView1.DataSource = Session["datos"] as DataTable;
        ////GridView1.DataBind();

        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    //CheckBox chk = row.FindControl("chkcheck") as CheckBox;
        //    ////Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
        //    //if ((chk.Checked)) // Si esta seleccionado..
        //    //{
        //    Int32 ictId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["Id"]);
        //    DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
        //    Int32 usuIdUltimaModificacion = this.Master.usuId;

        //    int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(ictId, TipoReg.SelectedItem.Text);
        //    ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
        //    //}
        //}

        //GridView1.EditIndex = -1;

        //PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        //Session["Editar"] = 0;
        //Session["Treg"] = 2;
        //GrillaCargar(PageIndex);


    }
    //protected void ButtonAsignar_Click(object sender, EventArgs e)
    //{

    //    Int32 espc = 0;
    //    Int32 car = 0;
    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        car = Convert.ToInt32(carId.SelectedValue.ToString());
    //    }
    //    Int32 pla = 0;
    //    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
    //    {
    //        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
    //    }

    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        cur = Convert.ToInt32(curId.SelectedValue.ToString());
    //    }

    //    if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
    //    {
    //        espc = Convert.ToInt32(escId.SelectedValue.ToString());
    //    }


    //    if (AnioCursado.Text == "")
    //    {
    //        DateTime fechaActual = DateTime.Today;
    //        AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

    //    }
    //    else
    //    {
    //        AnioCur = Convert.ToInt32(AnioCursado.Text);
    //    }

    //    if (TextNotaAsignar.Text != "")
    //    {

    //        if (ExamenTipoId.SelectedValue != "0")
    //        {

    //            dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur);

    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    int RecId = Convert.ToInt32(row["Id"].ToString());
    //                    //ocnRegistracionCalificaciones.AsignarNotaTerc(RecId, Convert.ToInt32(ExamenTipoId.SelectedValue), TextNotaAsignar.Text);

    //                }
    //            }

    //            GridView1.EditIndex = -1;
    //            int PageIndex = 0;
    //            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
    //            GrillaCargar(PageIndex);
    //        }
    //        else
    //        {
    //            LblMensajeErrorGrilla.Text = "Seleccione un Periodo..";
    //            ExamenTipoId.Focus();
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        LblMensajeErrorGrilla.Text = "Asigne una nota..";
    //        TextNotaAsignar.Focus();
    //        return;
    //    }
    //}
    protected void ButtonImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep;
            Int32 Materia = Convert.ToInt32(escId.SelectedValue.ToString());
            Int32 curso = Convert.ToInt32(curId.SelectedValue.ToString());
            Int32 anioLectivo = Convert.ToInt32(AnioCursado.Text.Trim().ToString());

            NomRep = "InformeListadoCalificacionesxMateriaSec.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + Materia + "&curId=" + curso + "&anio=" + anioLectivo + "&NomRep=" + NomRep);
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

    protected void ExamenTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        pnlContents.Visible = false;
        GrillaNota.DataSource = null;
        GrillaNota.DataBind();
        GrillaRecAsist.DataSource = null;
        GrillaRecAsist.DataBind();

        GrillaRecAsist2.DataSource = null;
        GrillaRecAsist2.DataBind();

        btnCondicion.Visible = false;
        BtnNota.Visible = false;
        btnPrint.Visible = false; btnActa.Visible = false;
        String TipoRegDesc = Convert.ToString(ExamenTipoId.SelectedItem);

        if (TipoRegDesc == "Taller Inicial")
        {
            ChkVerTodo.Visible = false;
            btnCondicion.Visible = false;
        }
        else
        {
            ChkVerTodo.Visible = true;
            //btnCondicion.Visible = true;
        }

    }

    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        pnlContents.Visible = false;
        GrillaNota.DataSource = null;
        GrillaNota.DataBind();
        GrillaRecAsist.DataSource = null;
        GrillaRecAsist.DataBind();

        GrillaRecAsist2.DataSource = null;
        GrillaRecAsist2.DataBind();

        ExamenTipoId.SelectedValue = "0";
        btnCondicion.Visible = false;
        BtnNota.Visible = false;
        btnPrint.Visible = false; btnActa.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        ExamenTipoId.DataValueField = "Valor";
        ExamenTipoId.DataTextField = "Texto";
        ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.EspCurrEvaluacion()).ObtenerListaxescId("[Seleccionar...]", Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
        ExamenTipoId.DataBind();
        lblMateria.Text = Convert.ToString(escId.SelectedItem);
    }

    protected void BtnNota_Click(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            lblAsistRoja.Visible = false;
            txtRojo.Visible = false;
            Int32 espc = 0;
            Int32 car = 0;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }

            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            alerExito.Visible = false;

            dt = new DataTable();
            dt = ocnInscripcionCursadoTerciario.ObtenerTodoxEspCxeceId(insId, Convert.ToInt32(escId.SelectedValue), AnioCur, Convert.ToInt32(ExamenTipoId.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["treId"]) != 7)
                {
                    foreach (GridViewRow row in GrillaNota.Rows)
                    {
                        int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                        int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                        int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);
                        DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                        Int32 usuIdUltimaModificacion = this.Master.usuId;

                        TextBox p = row.FindControl("txtNota") as TextBox;

                       string Nota = Convert.ToString(p.Text).Trim();
                        if (Nota != "")
                        {

                            //Decimal porcentaje = ((Convert.ToInt32(cantClases.Text) - Convert.ToInt32(Nota)) * 100) / Convert.ToInt32(cantClases.Text);
                            ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                            alerExito.Visible = true;
                            lblalerExito.Text = "Se actualizaron registros..";
                            String TipoRegDesc = Convert.ToString(ExamenTipoId.SelectedItem);

                            if (TipoRegDesc == "Taller Inicial")
                            {
                                if (Nota == "A" || Nota == "D" || Nota == "d" || Nota == "a") // Nota Letra
                                {

                                    if (Nota == "A")
                                    {
                                        ocnInscripcionCursadoTerciario.ActualizarCondicion(ictId, 8, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// APROBADO
                                        DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                                        if (dtEscCorr.Rows.Count > 0)
                                        {
                                            DataTable dtictUlt = new DataTable();
                                            foreach (DataRow row2 in dtEscCorr.Rows)
                                            {
                                                int ControlFaltaCorrelativa = 1;
                                                DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                                                if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                                {
                                                    // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                                    foreach (DataRow row4 in dt1.Rows)
                                                    {
                                                        if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                                        {
                                                            DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                                            if (dt4.Rows.Count != 0)
                                                            {
                                                                //ControlFaltaCorrelativa = 1;
                                                            }
                                                            else
                                                            {
                                                                ControlFaltaCorrelativa = 0;
                                                            }
                                                        }
                                                    }

                                                    if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                                                    {
                                                        dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                                        if (dtictUlt.Rows.Count > 0)
                                                        {
                                                            int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                                            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                                            if (ocnInscripcionCursadoTerciario.cdnId == 5)
                                                            {
                                                                ocnInscripcionCursadoTerciario.cdnId = 1;
                                                                ocnInscripcionCursadoTerciario.Actualizar();
                                                            }
                                                        }
                                                        //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Nota == "D" || Nota == "d" || Nota == "a")
                                        {
                                            ocnInscripcionCursadoTerciario.ActualizarCondicion(ictId, 9, null, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// 
                                            DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                                            if (dtEscCorr.Rows.Count > 0)
                                            {
                                                DataTable dtictUlt = new DataTable();
                                                foreach (DataRow row2 in dtEscCorr.Rows)
                                                {
                                                    int ControlFaltaCorrelativa = 1;
                                                    DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                                                    if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                                    {
                                                        // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                                        foreach (DataRow row4 in dt1.Rows)
                                                        {
                                                            if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                                            {
                                                                DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                                                if (dt4.Rows.Count != 0)
                                                                {
                                                                    //ControlFaltaCorrelativa = 1;
                                                                }
                                                                else
                                                                {
                                                                    ControlFaltaCorrelativa = 0;
                                                                }
                                                            }
                                                        }

                                                        if (ControlFaltaCorrelativa == 0)  // Si no estan bien las correlativas
                                                        {
                                                            dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                                            if (dtictUlt.Rows.Count > 0)
                                                            {
                                                                int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                                                ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                                                if (ocnInscripcionCursadoTerciario.cdnId == 5)
                                                                {
                                                                    ocnInscripcionCursadoTerciario.cdnId = 3; // Libre
                                                                    ocnInscripcionCursadoTerciario.Actualizar();
                                                                }
                                                            }
                                                            //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(Nota) >= 6)
                                    {
                                        ocnInscripcionCursadoTerciario.ActualizarCondicion(ictId, 8, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// APROBADO
                                        DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                                        if (dtEscCorr.Rows.Count > 0)
                                        {
                                            DataTable dtictUlt = new DataTable();
                                            foreach (DataRow row2 in dtEscCorr.Rows)
                                            {
                                                int ControlFaltaCorrelativa = 1;
                                                DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                                                if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                                {
                                                    // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                                    foreach (DataRow row4 in dt1.Rows)
                                                    {
                                                        if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                                        {
                                                            DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                                            if (dt4.Rows.Count != 0)
                                                            {
                                                                //ControlFaltaCorrelativa = 1;
                                                            }
                                                            else
                                                            {
                                                                ControlFaltaCorrelativa = 0;
                                                            }
                                                        }
                                                    }

                                                    if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                                                    {
                                                        dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                                        if (dtictUlt.Rows.Count > 0)
                                                        {
                                                            int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                                            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                                            if (ocnInscripcionCursadoTerciario.cdnId == 5)
                                                            {
                                                                ocnInscripcionCursadoTerciario.cdnId = 1;
                                                                ocnInscripcionCursadoTerciario.Actualizar();
                                                            }
                                                        }
                                                        //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(Nota) < 6)
                                        {
                                            ocnInscripcionCursadoTerciario.ActualizarCondicion(ictId, 9, null, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// 
                                            DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                                            if (dtEscCorr.Rows.Count > 0)
                                            {
                                                DataTable dtictUlt = new DataTable();
                                                foreach (DataRow row2 in dtEscCorr.Rows)
                                                {
                                                    int ControlFaltaCorrelativa = 1;
                                                    DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                                                    if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                                    {
                                                        // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                                        foreach (DataRow row4 in dt1.Rows)
                                                        {
                                                            if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                                            {
                                                                DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                                                if (dt4.Rows.Count != 0)
                                                                {
                                                                    //ControlFaltaCorrelativa = 1;
                                                                }
                                                                else
                                                                {
                                                                    ControlFaltaCorrelativa = 0;
                                                                }
                                                            }
                                                        }

                                                        if (ControlFaltaCorrelativa == 0)  // Si no estan bien las correlativas
                                                        {
                                                            dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                                            if (dtictUlt.Rows.Count > 0)
                                                            {
                                                                int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                                                ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                                                if (ocnInscripcionCursadoTerciario.cdnId == 5)
                                                                {
                                                                    ocnInscripcionCursadoTerciario.cdnId = 3; // Libre
                                                                    ocnInscripcionCursadoTerciario.Actualizar();
                                                                }
                                                            }
                                                            //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                            alerExito.Visible = true;
                            lblalerExito.Text = "Se actualizaron registros..";
                        }



                    }
                }
                else
                {
                    foreach (GridViewRow row in GrillaRecAsist2.Rows)
                    {
                        int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                        int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                        int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);
                        DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                        Int32 usuIdUltimaModificacion = this.Master.usuId;

                        TextBox p = row.FindControl("txtNota") as TextBox;

                        String Nota = Convert.ToString(p.Text).Trim();
                        if (Nota != "")
                        {

                            //Decimal porcentaje = ((Convert.ToInt32(cantClases.Text) - Convert.ToInt32(Nota)) * 100) / Convert.ToInt32(cantClases.Text);
                            ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                            alerExito.Visible = true;
                            lblalerExito.Text = "Se actualizaron registros..";

                        }
                    }
                }
                GrillaCargar(GrillaNota.PageIndex);
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
        btnCondicion.Visible = false;
        btnPrint.Visible = false; btnActa.Visible = false;
        alerError.Visible = false;
        alerError2.Visible = false;
        pnlContents.Visible = false;
        ChkVerTodo.Checked = false;
        GrillaCargar(GrillaNota.PageIndex);

    }

    protected void ChkVerTodo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            lblAsistRoja.Visible = false;
            txtRojo.Visible = false;
            TituloCondición.Visible = false;
            GridCorrelativas.Visible = false;
            btnCondicion.Visible = false;
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

            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
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


            if (ChkVerTodo.Checked == true)
            {
                DataTable dt = new DataTable();
                dt = ocnRegistracionCalificaciones.ObtenerTodoporEspCurricularAnioTodo(espc, cur, AnioCur, 0);
                GrillaNota.DataSource = null;
                GrillaNota.DataBind();
                GrillaRecAsist.DataSource = null; GrillaRecAsist.DataBind();
                GrillaRecAsist2.DataSource = null; GrillaRecAsist2.DataBind();
                PanelActNotas.Visible = false;
                alerExito.Visible = false;
                pnlContents.Visible = false;
                btnCondicion.Visible = false;
                BtnNota.Visible = false;
                btnPrint.Visible = false; btnActa.Visible = false;

                if (dt.Rows.Count > 0)
                {
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    BtnNota.Visible = false;
                    btnPrint.Visible = true; btnActa.Visible = true;
                    pnlContents.Visible = true;
                    ChkVerTodo.Checked = false;

                }
                else
                {
                    btnPrint.Visible = false; btnActa.Visible = false;
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    pnlContents.Visible = false;

                }
            }
            else
            {
                PanelActNotas.Visible = true;
                btnCondicion.Visible = false;
                GridView3.DataSource = null;
                GridView3.DataBind();
                GrillaCargar(GrillaNota.PageIndex);
                pnlContents.Visible = false;
                btnPrint.Visible = false; btnActa.Visible = false;
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

    protected void ChkCerrarPlanilla_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            TituloCondición.Visible = true;
            GridCorrelativas.Visible = true;
            DataTable dtCorrelativas = new DataTable();
            dtCorrelativas.Columns.Add("lblAlumno3", typeof(String));
            dtCorrelativas.Columns.Add("lblObservaciones", typeof(String));
            GridCorrelativas.DataSource = dtCorrelativas;
            GridCorrelativas.DataBind();
            Session["Correlativas"] = dtCorrelativas;

            insId = Convert.ToInt32(Session["_Institucion"]);
            alerError2.Visible = false;
            Int32 espc = 0;
            Int32 car = 0;

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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
            alerExito.Visible = false;
            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia = Convert.ToString(row2["Asistencia"].ToString());
                    if (Asistencia == "") // Parcial
                    {
                        Band = 1;
                    }
                }

                if (Band == 0)
                {
                    foreach (GridViewRow row in GrillaNota.Rows)
                    {

                        int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                        int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                        int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);
                        DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                        Int32 usuIdUltimaModificacion = this.Master.usuId;

                        DataTable dt5;
                        dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                        DataTable dtParamCondRegProm = new DataTable();

                        //Según Forma de Dictado.. Procesos

                        if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 3) // Materia
                        {
                            Marteria();
                            //btnCondicion.Enabled = false; 
                        }
                        else
                        {
                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 1 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 6 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 2)// Taller Seminario Seminario Taller
                            {
                                TallerSeminario();
                                //btnCondicion.Enabled = false; 
                            }
                            else
                            {
                                if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 15) // Practica I Nivel Inicila - Primaria
                                {
                                    PracticaIInicialPrimaria();
                                }
                                else
                                {
                                    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 14)//Práctica I Eco - Geo - Inglés
                                    {
                                        PracticaIEcoGeoInglés();
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 11) //Práctica II Econo - Geo - Inglés
                                        {
                                            PracticaIIEconoGeoIngles();
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 10 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 12) //Práctica II Inicial - Primaria   Práctica III Inicial - Primaria
                                            {
                                                PracticaIIInicialPrimaria();
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 13) //Práctica III Eco - Geo - Inglés
                                                {
                                                    PracticaIIIEcoGeoIngl();
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 8) //Práctica IV Eco - Geo 
                                                    {
                                                        PracticaIVEconGeog();
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 9) //Práctica IV Ingles
                                                        {
                                                            PracticaIVIngles();
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 4) //Práctica IV Inicial - Primaria
                                                            {
                                                                PracticaIVInicialPrimaria();
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 12) //Práctica III Inicial - Primaria
                                                                {
                                                                    PracticaIIIInicialPrimaria();
                                                                }
                                                                else
                                                                {


                                                                }

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }

                    btnCondicion.Visible = false;
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    dt3 = Session["Correlativas"] as DataTable;
                    dt2 = ocnRegistracionCalificaciones.ObtenerTodoporEspCurricularAnioTodo(espc, cur, AnioCur, 0);
                    GrillaNota.DataSource = null;
                    GrillaNota.DataBind();
                    if (dt2.Rows.Count > 0)
                    {
                        GridView3.DataSource = dt2;
                        GridView3.DataBind();

                        this.GridCorrelativas.DataSource = dt3;
                        this.GridCorrelativas.DataBind();

                        BtnNota.Visible = false;
                        btnPrint.Visible = true; btnActa.Visible = true;
                        pnlContents.Visible = true;

                    }
                    else
                    {
                        btnPrint.Visible = false; btnActa.Visible = false;
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                        pnlContents.Visible = false;
                        ChkVerTodo.Checked = false;
                    }

                    ChkVerTodo.Checked = true;
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "No está completo la planilla de Asistencia para actualizar Condición..";

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
    protected void btnCondicion_Click(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            PanelActNotas.Visible = false;

            lblAsistRoja.Visible = false;
            txtRojo.Visible = false;
            TituloCondición.Visible = true;
            GridCorrelativas.Visible = true;
            DataTable dtCorrelativas = new DataTable();
            dtCorrelativas.Columns.Add("lblAlumno3", typeof(String));
            dtCorrelativas.Columns.Add("lblObservaciones", typeof(String));
            GridCorrelativas.DataSource = dtCorrelativas;
            GridCorrelativas.DataBind();
            Session["Correlativas"] = dtCorrelativas;

            insId = Convert.ToInt32(Session["_Institucion"]);
            alerError2.Visible = false;
            Int32 espc = 0;
            Int32 car = 0;

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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
            alerExito.Visible = false;
            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    //foreach (GridViewRow row in GrillaNota.Rows)
                    //{

                    //    int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                    //    int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                    //    int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);
                    //    DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                    //    Int32 usuIdUltimaModificacion = this.Master.usuId;

                    DataTable dt5;
                    dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                    DataTable dtParamCondRegProm = new DataTable();

                    //Según Forma de Dictado.. Procesos

                    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 3) // Materia
                    {
                        Marteria();
                    }
                    else
                    {
                        if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 1 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 6 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 2)// Taller Seminario Seminario Taller
                        {
                            TallerSeminario();
                        }
                        else
                        {
                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 15) // Practica I Nivel Inicila - Primaria
                            {
                                PracticaIInicialPrimaria();
                            }
                            else
                            {
                                if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 14)//Práctica I Eco - Geo - Inglés
                                {
                                    PracticaIEcoGeoInglés();
                                }
                                else
                                {
                                    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 11) //Práctica II Econo - Geo - Inglés
                                    {
                                        PracticaIIEconoGeoIngles();
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 10 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 12) //Práctica II Inicial - Primaria   Práctica III Inicial - Primaria
                                        {
                                            PracticaIIInicialPrimaria();
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 13) //Práctica III Eco - Geo - Inglés
                                            {
                                                PracticaIIIEcoGeoIngl();
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 8) //Práctica IV Eco - Geo 
                                                {
                                                    PracticaIVEconGeog();
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 9) //Práctica IV Ingles
                                                    {
                                                        PracticaIVIngles();
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 4) //Práctica IV Inicial - Primaria
                                                        {
                                                            PracticaIVInicialPrimaria();
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 12) //Práctica III Inicial - Primaria
                                                            {
                                                                PracticaIIIInicialPrimaria();
                                                            }
                                                            else
                                                            {


                                                            }

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    btnCondicion.Visible = false;
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    dt3 = Session["Correlativas"] as DataTable;
                    dt2 = ocnRegistracionCalificaciones.ObtenerTodoporEspCurricularAnioTodo(espc, cur, AnioCur, 0);
                    GrillaNota.DataSource = null;
                    GrillaNota.DataBind();
                    GrillaRecAsist.DataSource = null;
                    GrillaRecAsist.DataBind();
                    //PanelActNotas.Visible = true;
                    GrillaRecAsist2.DataSource = null;
                    GrillaRecAsist2.DataBind();
                    PanelActNotas.Visible = false;
                    if (dt2.Rows.Count > 0)
                    {
                        GridView3.DataSource = dt2;
                        GridView3.DataBind();

                        this.GridCorrelativas.DataSource = dt3;
                        this.GridCorrelativas.DataBind();

                        BtnNota.Visible = false;
                        btnPrint.Visible = true; btnActa.Visible = true;
                        pnlContents.Visible = true;
                        PanelActNotas.Visible = false;

                    }
                    else
                    {
                        btnPrint.Visible = false; btnActa.Visible = false;
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                        pnlContents.Visible = false;
                        ChkVerTodo.Checked = false;

                    }

                    ChkVerTodo.Checked = true;
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "No está completo la planilla de Asistencia para actualizar Condición..";

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

    void PracticaIInicialPrimaria()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;



            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());


                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString().Trim()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString().Trim()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                    {
                                                        if (CantRECTPAprob == CantRECTP)
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    if (cantRecColoquioProm == cantRecColoquio)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantRecColoquioDES == cantRecColoquio)
                                                                        {
                                                                            RecursaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CantRECTPDesap == CantRECTP)
                                                            {
                                                                RecursaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());


                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        if (cantRecColoquioProm == cantRecColoquio)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantRecColoquioDES == cantRecColoquio)
                                                                            {
                                                                                RecursaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            RecursaId(Id, aluId);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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

    void PracticaIVInicialPrimaria()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;

                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }



                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row2 = dC.NewRow();

                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row2);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row2 = dC.NewRow();

                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row2);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    RecursaId(Id, aluId);
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;

                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }



                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row2 = dC.NewRow();

                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row2);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row2 = dC.NewRow();

                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row2);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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
    void PracticaIVIngles()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;



            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }



                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    RecursaId(Id, aluId);
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }



                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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

    void PracticaIVEconGeog()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {

                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }
                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }
                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }



                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    RecursaId(Id, aluId);
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {

                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }
                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }
                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString().Trim()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }



                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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
    void PracticaIIIEcoGeoIngl()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());



                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }

                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (80 <= PorcPractAprob & PorcPractAprob < 100)
                                                    {
                                                        if (CantRECTPAprob == CantRECTP)
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    if (cantRecColoquioProm == cantRecColoquio)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantRecColoquioDES == cantRecColoquio)
                                                                        {
                                                                            RecursaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CantRECTPDesap == CantRECTP)
                                                            {
                                                                RecursaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());



                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }

                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (80 <= PorcPractAprob & PorcPractAprob < 100)
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        if (cantRecColoquioProm == cantRecColoquio)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantRecColoquioDES == cantRecColoquio)
                                                                            {
                                                                                RecursaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            RecursaId(Id, aluId);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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
    void PracticaIIEconoGeoIngles()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {

                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                    Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString().Trim()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"]).Trim() != "")
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                    {
                                                        if (CantRECTPAprob == CantRECTP)
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    if (cantRecColoquioProm == cantRecColoquio)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantRecColoquioDES == cantRecColoquio)
                                                                        {
                                                                            RecursaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CantRECTPDesap == CantRECTP)
                                                            {
                                                                RecursaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {

                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"]).Trim() != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"]).Trim() == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"]).Trim() == "D" || Convert.ToString(row2["recNota"]).Trim() == "d" ||
                                                        Convert.ToString(row2["recNota"]).Trim() == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        if (cantRecColoquioProm == cantRecColoquio)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantRecColoquioDES == cantRecColoquio)
                                                                            {
                                                                                RecursaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            RecursaId(Id, aluId);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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


    void PracticaIIInicialPrimaria()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {

                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());


                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                    {
                                                        if (CantRECTPAprob == CantRECTP)
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    if (cantRecColoquioProm == cantRecColoquio)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantRecColoquioDES == cantRecColoquio)
                                                                        {
                                                                            RecursaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CantRECTPDesap == CantRECTP)
                                                            {
                                                                RecursaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec ACTIVIDADES)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {

                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());


                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        if (cantRecColoquioProm == cantRecColoquio)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantRecColoquioDES == cantRecColoquio)
                                                                            {
                                                                                RecursaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec ACTIVIDADES)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            RecursaId(Id, aluId);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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


    void PracticaIIIInicialPrimaria()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;



            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());


                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row3 = dC.NewRow();

                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row3);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                    {
                                                        if (CantRECTPAprob == CantRECTP)
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    if (cantRecColoquioProm == cantRecColoquio)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantRecColoquioDES == cantRecColoquio)
                                                                        {
                                                                            RecursaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CantRECTPDesap == CantRECTP)
                                                            {
                                                                RecursaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec ACTIVIDADES)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());


                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row3 = dC.NewRow();

                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row3);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        if (cantRecColoquioProm == cantRecColoquio)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantRecColoquioDES == cantRecColoquio)
                                                                            {
                                                                                RecursaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec ACTIVIDADES)..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            RecursaId(Id, aluId);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Actividades)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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

    void PracticaIEcoGeoInglés()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;



            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;

                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;


                            int cantRecColoquio = 0;
                            int cantRecColoquioProm = 0;
                            int cantRecColoquioDES = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaColoquioProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    //AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    //NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    //TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    //NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNotaColoquio"]);
                                    //AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    //AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    //NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    //TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    //NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;
                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }
                                        if (treId == 8) // Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {

                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantColoquioProm = cantColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }
                                        if (treId == 13) // Recupera Coloquio
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                {
                                                    cantRecColoquioDES = cantRecColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                    {
                                                        cantRecColoquioProm = cantRecColoquioProm + 1;
                                                    }
                                                    else
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                }
                                            }
                                            cantRecColoquio = cantRecColoquio + 1;
                                        }
                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                    }

                                    if (CantTP > 0) // HAY TP??  SI
                                    {
                                        if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                        {
                                            if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                            {
                                                if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                {
                                                    if (cantColoquioProm == cantColoquio)
                                                    {
                                                        PromocionaId(Id, aluId);
                                                    }
                                                    else
                                                    {
                                                        if (cantColoquioDES == cantColoquio)
                                                        {
                                                            if (cantRecColoquioProm == cantRecColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantRecColoquioDES == cantRecColoquio)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row2 = dC.NewRow();

                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                    dC.Rows.Add(row2);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable dtAlumno = new DataTable();
                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                            DataTable dC = new DataTable();
                                                            dC = Session["Correlativas"] as DataTable;
                                                            DataRow row2 = dC.NewRow();

                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                            dC.Rows.Add(row2);
                                                            Session["Correlativas"] = dC;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                    {
                                                        if (CantRECTPAprob == CantRECTP)
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                PromocionaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    if (cantRecColoquioProm == cantRecColoquio)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantRecColoquioDES == cantRecColoquio)
                                                                        {
                                                                            RecursaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row2 = dC.NewRow();

                                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                            dC.Rows.Add(row2);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row2 = dC.NewRow();

                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                    dC.Rows.Add(row2);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CantRECTPDesap == CantRECTP)
                                                            {
                                                                RecursaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row2 = dC.NewRow();

                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                dC.Rows.Add(row2);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        RecursaId(Id, aluId);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row3 = dC.NewRow();

                                                row3["lblAlumno3"] = AlumnoNombre;
                                                row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (ACTIVIDADES)..";
                                                dC.Rows.Add(row3);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                        else
                                        {
                                            RecursaId(Id, aluId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;

                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;


                                int cantRecColoquio = 0;
                                int cantRecColoquioProm = 0;
                                int cantRecColoquioDES = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaColoquioProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        //AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        //NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        //TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        //NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNotaColoquio"]);
                                        //AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        //AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        //NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        //TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        //NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;
                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }
                                            if (treId == 8) // Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {

                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }
                                            if (treId == 13) // Recupera Coloquio
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")
                                                    {
                                                        cantRecColoquioDES = cantRecColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantRecColoquioProm = cantRecColoquioProm + 1;
                                                        }
                                                        else
                                                        {
                                                            cantRecColoquioDES = cantRecColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                                cantRecColoquio = cantRecColoquio + 1;
                                            }
                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                            //if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            //{
                                                            //    Asistencia = 2; //REGULAR
                                                            //}
                                                            //else
                                                            //{
                                                            //    if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            //    {
                                                            //        Asistencia = 3; // Desaprueba Asistencia
                                                            //    }
                                                            //}
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if (Asistencia == 1 || Asistencia == 4) // ASISTENCIA PROMO - 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP 
                                                {
                                                    if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                    {
                                                        if (cantColoquioProm == cantColoquio)
                                                        {
                                                            PromocionaId(Id, aluId);
                                                        }
                                                        else
                                                        {
                                                            if (cantColoquioDES == cantColoquio)
                                                            {
                                                                if (cantRecColoquioProm == cantRecColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantRecColoquioDES == cantRecColoquio)
                                                                    {
                                                                        RecursaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row2 = dC.NewRow();

                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                        dC.Rows.Add(row2);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtAlumno = new DataTable();
                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                DataTable dC = new DataTable();
                                                                dC = Session["Correlativas"] as DataTable;
                                                                DataRow row2 = dC.NewRow();

                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                dC.Rows.Add(row2);
                                                                Session["Correlativas"] = dC;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (50 <= PorcPractAprob & PorcPractAprob <= 74)
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        if (cantRecColoquioProm == cantRecColoquio)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantRecColoquioDES == cantRecColoquio)
                                                                            {
                                                                                RecursaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row2 = dC.NewRow();

                                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Coloquio)..";
                                                                                dC.Rows.Add(row2);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row2 = dC.NewRow();

                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Coloquio)..";
                                                                        dC.Rows.Add(row2);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    RecursaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row2 = dC.NewRow();

                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Actividades)..";
                                                                    dC.Rows.Add(row2);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            RecursaId(Id, aluId);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row3 = dC.NewRow();

                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (ACTIVIDADES)..";
                                                    dC.Rows.Add(row3);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                RecursaId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }


                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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

    void TallerSeminario()
    {
        try
        {
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            int insId = Convert.ToInt32(Session["_Institucion"]);

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;



            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }
                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {
                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantRECTP = 0;

                            int CantTPProm = 0;
                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECTPProm = 0;
                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int cantColoquio = 0;
                            int cantColoquioApro = 0;
                            int cantColoquioProm = 0;
                            int cantColoquioDES = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int NotaColoquioProm = 0;
                            int NotaColoquioReg = 0;
                            int NotaReg = 0;
                            int NotaProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;
                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);

                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmPracticasAprob"]);
                                    NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                    NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNotaColoquio"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;

                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A" || Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" || Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        //CantTPProm = CantTPProm + 1;
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                                Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }
                                                }
                                                else // es numero
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                        {
                                                            CantTPProm = CantTPProm + 1;
                                                            CantTPAprob = CantTPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantTPAprob = CantTPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantTPDesap = CantTPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                        {
                                                            CantTPAprob = CantTPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }
                                                }
                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A" || Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" || Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                             Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }
                                                }
                                                else // numerica
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                        {
                                                            CantRECTPProm = CantRECTPProm + 1;
                                                            CantRECTPAprob = CantRECTPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantRECTPAprob = CantRECTPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantRECTPDesap = CantRECTPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                        {
                                                            CantRECTPAprob = CantRECTPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }
                                                }


                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }

                                        if (treId == 8) // Coloquio
                                        {
                                            String NOTAvER = Convert.ToString(row2["recNota"].ToString());
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a") // ausente
                                                {
                                                    cantColoquioDES = cantColoquioDES + 1;
                                                }
                                                else
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                        {
                                                            cantColoquioProm = cantColoquioProm + 1;
                                                            cantColoquioApro = cantColoquioApro + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioReg)
                                                            {
                                                                cantColoquioApro = cantColoquioApro + 1;
                                                            }
                                                            else
                                                            {
                                                                cantColoquioDES = cantColoquioDES + 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioReg)
                                                        {
                                                            cantColoquioApro = cantColoquioApro + 1;
                                                        }
                                                        else
                                                        {
                                                            cantColoquioDES = cantColoquioDES + 1;
                                                        }
                                                    }
                                                }
                                            }
                                            cantColoquio = cantColoquio + 1;
                                        }

                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            {
                                                                Asistencia = 5; //REGULAR
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                {
                                                                    Asistencia = 6; // Desaprueba Asistencia
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                        {
                                                            Asistencia = 5; //REGULAR
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            {
                                                                Asistencia = 6; // Desaprueba Asistencia
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Asistencia = 6; // Desaprueba Asistencia
                                                }

                                                CantRECAsist = CantRECAsist + 1;
                                            }
                                        }


                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                        {
                                                            Asistencia = 2; //REGULAR
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            {
                                                                Asistencia = 3; // Desaprueba Asistencia
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                    {
                                                        Asistencia = 2; //REGULAR
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                        {
                                                            Asistencia = 3; // Desaprueba Asistencia
                                                        }
                                                    }
                                                }
                                            }
                                        }



                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                        }

                                        if (CantTP > 0) // HAY TP??  SI
                                        {
                                            if ((Asistencia == 1 || Asistencia == 2 || Asistencia == 4 || Asistencia == 5)) // ASISTENCIA PROMO regular- 
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                        {
                                                            if (cantColoquioProm == cantColoquio)
                                                            {
                                                                if (Asistencia == 1 || Asistencia == 4)
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    RegularizaId(Id, aluId);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioApro == cantColoquio)
                                                                {
                                                                    RegularizaId(Id, aluId);
                                                                }
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if ((PorcPractAprob < TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %REGULAR 
                                                            {
                                                                if (CantRECTPProm == CantRECTP)
                                                                {
                                                                    if (cantColoquioProm == cantColoquio)
                                                                    {
                                                                        if (Asistencia == 1 || Asistencia == 4)
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            RegularizaId(Id, aluId);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantColoquioApro == cantColoquio)
                                                                        {
                                                                            RegularizaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantColoquioDES == cantColoquio)
                                                                            {
                                                                                LibreId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Colocar Nota del Coloquio..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (CantRECTPAprob == CantRECTP)
                                                                    {
                                                                        if (cantColoquioProm == cantColoquio)
                                                                        {
                                                                            if (Asistencia == 1 || Asistencia == 4)
                                                                            {
                                                                                PromocionaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantColoquioApro == cantColoquio)
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (cantColoquioDES == cantColoquio)
                                                                                {
                                                                                    LibreId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    DataTable dtAlumno = new DataTable();
                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                    DataTable dC = new DataTable();
                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                    DataRow row3 = dC.NewRow();

                                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                                    row3["lblObservaciones"] = "Colocar Nota del Rec Integrador de Coloquio..";
                                                                                    dC.Rows.Add(row3);
                                                                                    Session["Correlativas"] = dC;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (CantRECTPDesap == CantRECTP)
                                                                        {
                                                                            LibreId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Colocar Nota del Rec Integrador de Rec Integrador..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                LibreId(Id, aluId);
                                                            }
                                                        }
                                                    }
                                                    else // NO se PROMOCIONA
                                                    {
                                                        if ((PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %REGULAR 
                                                        {
                                                            if (cantColoquioApro == cantColoquio)
                                                            {
                                                                RegularizaId(Id, aluId);
                                                            }
                                                            else
                                                            {
                                                                if (cantColoquioDES == cantColoquio)
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Colocar Nota del Coloquio..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                        else // TP MENOS A REGULAR
                                                        {
                                                            if (CantRECTPAprob == CantRECTP)
                                                            {
                                                                if (cantColoquioApro == cantColoquio)
                                                                {
                                                                    RegularizaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Colocar Nota del Coloquio..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (CantRECTPDesap == CantRECTP)
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtAlumno = new DataTable();
                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                    DataTable dC = new DataTable();
                                                                    dC = Session["Correlativas"] as DataTable;
                                                                    DataRow row3 = dC.NewRow();

                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                    row3["lblObservaciones"] = "Colocar Nota del Rec Integrador de PA..";
                                                                    dC.Rows.Add(row3);
                                                                    Session["Correlativas"] = dC;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row3 = dC.NewRow();

                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                    row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (PA)..";
                                                    dC.Rows.Add(row3);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                            else
                                            {
                                                LibreId(Id, aluId);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {
                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantRECTP = 0;

                                int CantTPProm = 0;
                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECTPProm = 0;
                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int cantColoquio = 0;
                                int cantColoquioApro = 0;
                                int cantColoquioProm = 0;
                                int cantColoquioDES = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int NotaColoquioProm = 0;
                                int NotaColoquioReg = 0;
                                int NotaReg = 0;
                                int NotaProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;
                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);

                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmPracticasAprob"]);
                                        NotaColoquioReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNotaColoquio"]);
                                        NotaColoquioProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNotaColoquio"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;

                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..

                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A" || Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" || Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                        {
                                                            //CantTPProm = CantTPProm + 1;
                                                            CantTPAprob = CantTPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                            {
                                                                CantTPDesap = CantTPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                    else // es numero
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                            {
                                                                CantTPProm = CantTPProm + 1;
                                                                CantTPAprob = CantTPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                                {
                                                                    CantTPAprob = CantTPAprob + 1;
                                                                }
                                                                else
                                                                {
                                                                    CantTPDesap = CantTPDesap + 1;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantTPAprob = CantTPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantTPDesap = CantTPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A" || Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" || Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                        {
                                                            CantRECTPAprob = CantRECTPAprob + 1;
                                                            CantRECTPAprob = CantRECTPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                                 Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                            {
                                                                CantRECTPDesap = CantRECTPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                    else // numerica
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                            {
                                                                CantRECTPProm = CantRECTPProm + 1;
                                                                CantRECTPAprob = CantRECTPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                                {
                                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                                }
                                                                else
                                                                {
                                                                    CantRECTPDesap = CantRECTPDesap + 1;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantRECTPAprob = CantRECTPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantRECTPDesap = CantRECTPDesap + 1;
                                                            }
                                                        }
                                                    }


                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }

                                            if (treId == 8) // Coloquio
                                            {
                                                String NOTAvER = Convert.ToString(row2["recNota"].ToString());
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a") // ausente
                                                    {
                                                        cantColoquioDES = cantColoquioDES + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioProm)
                                                            {
                                                                cantColoquioProm = cantColoquioProm + 1;
                                                                cantColoquioApro = cantColoquioApro + 1;
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioReg)
                                                                {
                                                                    cantColoquioApro = cantColoquioApro + 1;
                                                                }
                                                                else
                                                                {
                                                                    cantColoquioDES = cantColoquioDES + 1;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaColoquioReg)
                                                            {
                                                                cantColoquioApro = cantColoquioApro + 1;
                                                            }
                                                            else
                                                            {
                                                                cantColoquioDES = cantColoquioDES + 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                cantColoquio = cantColoquio + 1;
                                            }


                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a") // Nota Letra
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                                {
                                                                    Asistencia = 5; //REGULAR
                                                                }
                                                                else
                                                                {
                                                                    if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                    {
                                                                        Asistencia = 6; // Desaprueba Asistencia
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            {
                                                                Asistencia = 5; //REGULAR
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                {
                                                                    Asistencia = 6; // Desaprueba Asistencia
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Asistencia = 6; // Desaprueba Asistencia
                                                    }

                                                    CantRECAsist = CantRECAsist + 1;
                                                }
                                            }


                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            {
                                                                Asistencia = 2; //REGULAR
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                {
                                                                    Asistencia = 3; // Desaprueba Asistencia
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                        {
                                                            Asistencia = 2; //REGULAR
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            {
                                                                Asistencia = 3; // Desaprueba Asistencia
                                                            }
                                                        }
                                                    }
                                                }
                                            }



                                            //CONTROLO  PorcPractAprob 
                                            Decimal PorcPractAprob = 0;
                                            if (CantTP != 0)
                                            {
                                                PorcPractAprob = (CantTPAprob) * 100 / CantTP;
                                            }

                                            if (CantTP > 0) // HAY TP??  SI
                                            {
                                                if ((Asistencia == 1 || Asistencia == 2 || Asistencia == 4 || Asistencia == 5)) // ASISTENCIA PROMO regular- 
                                                {
                                                    if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                            {
                                                                if (cantColoquioProm == cantColoquio)
                                                                {
                                                                    if (Asistencia == 1 || Asistencia == 4)
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        RegularizaId(Id, aluId);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioApro == cantColoquio)
                                                                    {
                                                                        RegularizaId(Id, aluId);
                                                                    }
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if ((PorcPractAprob < TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %REGULAR 
                                                                {
                                                                    if (CantRECTPProm == CantRECTP)
                                                                    {
                                                                        if (cantColoquioProm == cantColoquio)
                                                                        {
                                                                            if (Asistencia == 1 || Asistencia == 4)
                                                                            {
                                                                                PromocionaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (cantColoquioApro == cantColoquio)
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (cantColoquioDES == cantColoquio)
                                                                                {
                                                                                    LibreId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    DataTable dtAlumno = new DataTable();
                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                    DataTable dC = new DataTable();
                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                    DataRow row3 = dC.NewRow();

                                                                                    row3["lblAlumno3"] = AlumnoNombre;
                                                                                    row3["lblObservaciones"] = "Colocar Nota del Coloquio..";
                                                                                    dC.Rows.Add(row3);
                                                                                    Session["Correlativas"] = dC;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (CantRECTPAprob == CantRECTP)
                                                                        {
                                                                            if (cantColoquioProm == cantColoquio)
                                                                            {
                                                                                if (Asistencia == 1 || Asistencia == 4)
                                                                                {
                                                                                    PromocionaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (cantColoquioApro == cantColoquio)
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (cantColoquioDES == cantColoquio)
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        DataTable dtAlumno = new DataTable();
                                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                        DataTable dC = new DataTable();
                                                                                        dC = Session["Correlativas"] as DataTable;
                                                                                        DataRow row3 = dC.NewRow();

                                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                                        row3["lblObservaciones"] = "Colocar Nota del Rec Integrador de Coloquio..";
                                                                                        dC.Rows.Add(row3);
                                                                                        Session["Correlativas"] = dC;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (CantRECTPDesap == CantRECTP)
                                                                            {
                                                                                LibreId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row3 = dC.NewRow();

                                                                                row3["lblAlumno3"] = AlumnoNombre;
                                                                                row3["lblObservaciones"] = "Colocar Nota del Rec Integrador de Rec Integrador..";
                                                                                dC.Rows.Add(row3);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                            }
                                                        }
                                                        else // NO se PROMOCIONA
                                                        {
                                                            if ((PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %REGULAR 
                                                            {
                                                                if (cantColoquioApro == cantColoquio)
                                                                {
                                                                    RegularizaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if (cantColoquioDES == cantColoquio)
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Colocar Nota del Coloquio..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                            else // TP MENOS A REGULAR
                                                            {
                                                                if (CantRECTPAprob == CantRECTP)
                                                                {
                                                                    if (cantColoquioApro == cantColoquio)
                                                                    {
                                                                        RegularizaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cantColoquioDES == cantColoquio)
                                                                        {
                                                                            LibreId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            DataTable dtAlumno = new DataTable();
                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                            DataTable dC = new DataTable();
                                                                            dC = Session["Correlativas"] as DataTable;
                                                                            DataRow row3 = dC.NewRow();

                                                                            row3["lblAlumno3"] = AlumnoNombre;
                                                                            row3["lblObservaciones"] = "Colocar Nota del Coloquio..";
                                                                            dC.Rows.Add(row3);
                                                                            Session["Correlativas"] = dC;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (CantRECTPDesap == CantRECTP)
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        DataTable dtAlumno = new DataTable();
                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                        DataTable dC = new DataTable();
                                                                        dC = Session["Correlativas"] as DataTable;
                                                                        DataRow row3 = dC.NewRow();

                                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                                        row3["lblObservaciones"] = "Colocar Nota del Rec Integrador de PA..";
                                                                        dC.Rows.Add(row3);
                                                                        Session["Correlativas"] = dC;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DataTable dtAlumno = new DataTable();
                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                        DataTable dC = new DataTable();
                                                        dC = Session["Correlativas"] as DataTable;
                                                        DataRow row3 = dC.NewRow();

                                                        row3["lblAlumno3"] = AlumnoNombre;
                                                        row3["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (PA)..";
                                                        dC.Rows.Add(row3);
                                                        Session["Correlativas"] = dC;
                                                    }
                                                }
                                                else
                                                {
                                                    LibreId(Id, aluId);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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

    void Marteria()
    {
        try
        {
            alerError.Visible = false;
            int insId = Convert.ToInt32(Session["_Institucion"]);

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                Int32 car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera..";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                Int32 espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular..";
                return;
            }
            int extId = 0;
            if (ExamenTipoId.SelectedValue.ToString() != "" & ExamenTipoId.SelectedValue.ToString() != "0")
            {
                extId = Convert.ToInt32(ExamenTipoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Tipo de Evaluación..";
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

            dt = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(Convert.ToInt32(escId.SelectedValue), cur, AnioCur);
            Int32 Band = 0;



            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row2 in dt.Rows) // Reviso asistencia de todos los alumnos de ese curso.. Debe estar completa para actualizar Condición
                {
                    string Asistencia2 = Convert.ToString(row2["Asistencia"].ToString());
                    Int32 Cond = Convert.ToInt32(row2["cdnId"].ToString());
                    if (Asistencia2 == "") // Parcial
                    {
                        if (Cond != 10)
                        {
                            Band = 1;
                        }
                    }
                }

                if (Band == 0)
                {
                    if (GrillaNota.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in GrillaNota.Rows)
                        {

                            int Promociona = 0;
                            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                            Int32 usuIdUltimaModificacion = this.Master.usuId;
                            DataTable dt5 = new DataTable();
                            int CantTP = 0;
                            int CantP = 0;
                            int CantRECP = 0;
                            int CantRECTP = 0;

                            int CantPProm = 0;
                            int CantPAprob = 0;
                            int CantPDesap = 0;

                            int CantTPAprob = 0;
                            int CantTPDesap = 0;

                            int CantRECPProm = 0;
                            int CantRECPAprob = 0;
                            int CantRECPDesap = 0;

                            int CantRECTPAprob = 0;
                            int CantRECTPDesap = 0;

                            int Asistencia = 0;
                            int AsistenciaProm = 0;
                            int AsistenciaReg = 0;

                            int CantRECAsist = 0;
                            int CantRECAsistAprob = 0;
                            int CantRECAsistDesap = 0;

                            int NotaReg = 0;
                            int NotaProm = 0;
                            int TPAprobadosPorcReg = 0;
                            int TPAprobadosPorcProm = 0;

                            int recId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["recId"]);
                            int aluId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["aluId"]);
                            int ictId = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["Id"]);


                            dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                            DataTable dtParamCondRegProm = new DataTable();

                            if (dt5.Rows.Count > 0)
                            {
                                dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                            }

                            if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                            {
                                if (Promociona == 0)
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    //TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);

                                }
                                else
                                {
                                    AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                    NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                    TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                    AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmAsistencia"]);
                                    NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNota"]);
                                    TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmPracticasAprob"]);
                                }
                            }


                            dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                            Id = ictId;

                            int Condicion = Convert.ToInt32(GrillaNota.DataKeys[row.RowIndex].Values["cdnId"]);

                            if (Condicion != 10)
                            {
                                if (dt.Rows.Count > 0)
                                { // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        int treId = Convert.ToInt32(row2["treId"].ToString());
                                        if (treId == 1) // Parcial
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a")//AUSENTE
                                                {
                                                    CantPDesap = CantPDesap + 1;
                                                }
                                                else
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                        {
                                                            CantPProm = CantPProm + 1;
                                                            CantPAprob = CantPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantPAprob = CantPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantPDesap = CantPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                        {
                                                            CantPAprob = CantPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            CantPDesap = CantPDesap + 1;
                                                        }
                                                    }
                                                }

                                            }
                                            CantP = CantP + 1;
                                        }

                                        if (treId == 2) // TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantTPAprob = CantTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantTPDesap = CantTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantTP = CantTP + 1;
                                        }

                                        if (treId == 3) // REC parcial
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "a") //AUSENTE
                                                {
                                                    CantRECPDesap = CantRECPDesap + 1;
                                                }
                                                else
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                        {
                                                            CantRECPProm = CantRECPProm + 1;
                                                            CantRECPAprob = CantRECPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantRECPAprob = CantRECPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantRECPDesap = CantRECPDesap + 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                        {
                                                            CantRECPAprob = CantRECPAprob + 1;
                                                        }
                                                        else
                                                        {
                                                            CantRECPDesap = CantRECPDesap + 1;
                                                        }
                                                    }
                                                }

                                            }
                                            CantRECP = CantRECP + 1;
                                        }

                                        if (treId == 4) // REC TP
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                {
                                                    CantRECTPAprob = CantRECTPAprob + 1;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                    Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                    {
                                                        CantRECTPDesap = CantRECTPDesap + 1;
                                                    }
                                                }

                                            }
                                            CantRECTP = CantRECTP + 1;
                                        }

                                        if (treId == 7) // Rec Asistencia
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "a")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 4; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            {
                                                                Asistencia = 5; //REGULAR
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                {
                                                                    Asistencia = 6; // Desaprueba Asistencia
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                        {
                                                            Asistencia = 5; //REGULAR
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            {
                                                                Asistencia = 6; // Desaprueba Asistencia
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            CantRECAsist = CantRECAsist + 1;
                                        }

                                        if (treId == 5) // ASISTENCIA
                                        {
                                            if (Convert.ToString(row2["recNota"].ToString()) != "")
                                            {
                                                if (Promociona == 1)
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                    {
                                                        Asistencia = 1; //PROMOCION
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                        {
                                                            Asistencia = 2; //REGULAR
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            {
                                                                Asistencia = 3; // Desaprueba Asistencia
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                    {
                                                        Asistencia = 2; //REGULAR
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                        {
                                                            Asistencia = 3; // Desaprueba Asistencia
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //CONTROLO  PorcPractAprob 
                                    Decimal PorcPractAprob = 0;
                                    if (CantTP != 0)
                                    {
                                        PorcPractAprob = (CantTPAprob + CantRECTPAprob) * 100 / CantTP;
                                        //if ((PorcPractAprob < TPAprobadosPorcProm) & (PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %PROMOCION 
                                        //{
                                        //    PorcPractAprob = (CantTPAprob + CantRECTPAprob) * 100 / CantTP;
                                        //}
                                    }

                                    if (CantP > 0) // HAY PARCIALES?? 
                                    {
                                        if ((CantPAprob + CantPDesap == CantP)) // RINDIO TODOS PACIALES
                                        {
                                            if (CantTP > 0) // HAY TP??  SI
                                            {
                                                if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                        {
                                                            if ((CantPProm == CantP)) // PROMOCIONA PARCIALES 
                                                            {
                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                {
                                                                    PromocionaId(Id, aluId);
                                                                }
                                                                else
                                                                {
                                                                    if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                    {
                                                                        RegularizaId(Id, aluId);
                                                                    }
                                                                    else // No cumple Asistencia -- Libre
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                }
                                                            }
                                                            else // No promociona Parciales --- Puede promocionar si Rec > 7
                                                            {
                                                                if (CantPAprob == CantP) // Aprobó todos PARCIALES
                                                                {
                                                                    if (CantPProm != 0) // al menos un Parcial >7
                                                                    {
                                                                        if (CantRECPAprob != 0) // rindio el Rec P para recuperar o promocionar
                                                                        {
                                                                            if (CantRECPProm == CantRECP) // Promociona RecP
                                                                            {
                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                {
                                                                                    PromocionaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else // No cumple Asistencia -- Libre
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (CantRECPAprob == CantRECP)
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO 
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else // No Promociona ni regulariza RecP = LIBRE
                                                                                {
                                                                                    if (CantRECPDesap == CantRECP)
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        DataTable dtAlumno = new DataTable();
                                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                        DataTable dC = new DataTable();
                                                                                        dC = Session["Correlativas"] as DataTable;
                                                                                        DataRow row2 = dC.NewRow();

                                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec de TP)..";
                                                                                        dC.Rows.Add(row2);
                                                                                        Session["Correlativas"] = dC;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            RegularizaId(Id, aluId);
                                                                        }
                                                                    }
                                                                    else // Aprobó los dos pero ninguna > 7 = Regular
                                                                    {
                                                                        RegularizaId(Id, aluId);
                                                                    }
                                                                }
                                                                else // DESAPROBÓ PARCIALES
                                                                {
                                                                    if (CantPDesap != CantP) // DESAPROBÓ AL MENOS UNO
                                                                    {
                                                                        if (CantPProm != 0) // al menos un Parcial >7
                                                                        {
                                                                            if (CantRECPProm == CantRECP) // Promociona RecP
                                                                            {
                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                {
                                                                                    PromocionaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else // No cumple Asistencia -- Libre
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (CantRECPAprob == CantRECP)
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    }// No Promociona ni regulariza RecP = LIBRE
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPDesap == CantRECP)
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        DataTable dtAlumno = new DataTable();
                                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                        DataTable dC = new DataTable();
                                                                                        dC = Session["Correlativas"] as DataTable;
                                                                                        DataRow row2 = dC.NewRow();

                                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                        dC.Rows.Add(row2);
                                                                                        Session["Correlativas"] = dC;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else // SIN PARCIALES CON PROMOCION 
                                                                        {
                                                                            if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                            {
                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else // No cumple Asistencia -- Libre
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (CantRECPAprob == CantRECP)
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    } // No Promociona ni regulariza RecP = LIBRE
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPDesap == CantRECP)
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        DataTable dtAlumno = new DataTable();
                                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                        DataTable dC = new DataTable();
                                                                                        dC = Session["Correlativas"] as DataTable;
                                                                                        DataRow row2 = dC.NewRow();

                                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                        dC.Rows.Add(row2);
                                                                                        Session["Correlativas"] = dC;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (CantPDesap == CantP) // DESAPROBO TODOS VEO REC
                                                                        {
                                                                            if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                            {
                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else // No cumple Asistencia -- Libre
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (CantRECPAprob == CantRECP)
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    } // No Promociona ni regulariza RecP = LIBRE
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPDesap == CantRECP)
                                                                                    {
                                                                                        LibreId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        DataTable dtAlumno = new DataTable();
                                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                        DataTable dC = new DataTable();
                                                                                        dC = Session["Correlativas"] as DataTable;
                                                                                        DataRow row2 = dC.NewRow();

                                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                        dC.Rows.Add(row2);
                                                                                        Session["Correlativas"] = dC;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else // no tiene el porcentaje de TP
                                                        {
                                                            if ((PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %REGULAR 
                                                            {
                                                                if (CantRECTPAprob == CantRECTP)
                                                                {
                                                                    if ((CantPProm == CantP)) // PROMOCIONA PARCIALES 
                                                                    {
                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                        {
                                                                            PromocionaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                            else // No cumple Asistencia -- Libre
                                                                            {
                                                                                LibreId(Id, aluId);
                                                                            }
                                                                        }
                                                                    }
                                                                    else // No promociona Parciales --- Puede promocionar si Rec > 7
                                                                    {
                                                                        if (CantPAprob == CantP) // Aprobó todos PARCIALES
                                                                        {
                                                                            if (CantPProm != 0) // al menos un Parcial >7
                                                                            {
                                                                                if (CantRECPAprob != 0) // rindio el Rec P para recuperar
                                                                                {
                                                                                    if (CantRECPProm == CantRECP) // Promociona RecP
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            PromocionaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPAprob == CantRECP)
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else // No Promociona ni regulariza RecP = LIBRE
                                                                                        {
                                                                                            if (CantRECPDesap == CantRECP)
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    DataTable dtAlumno = new DataTable();
                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                    DataTable dC = new DataTable();
                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                    DataRow row2 = dC.NewRow();

                                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                    dC.Rows.Add(row2);
                                                                                    Session["Correlativas"] = dC;
                                                                                }
                                                                            }
                                                                            else // Aprobó los dos pero ninguna > 7 = Regular
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                        }
                                                                        else // DESAPROBÓ PARCIALES
                                                                        {
                                                                            if (CantPDesap != CantP) // DESAPROBÓ AL MENOS UNO
                                                                            {
                                                                                if (CantPProm != 0) // al menos un Parcial >7
                                                                                {
                                                                                    if (CantRECPProm == CantRECP) // Promociona RecP
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            PromocionaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPAprob == CantRECP)
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }// No Promociona ni regulariza RecP = LIBRE
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPDesap == CantRECP)
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                DataTable dtAlumno = new DataTable();
                                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                                DataTable dC = new DataTable();
                                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                                DataRow row2 = dC.NewRow();

                                                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                                dC.Rows.Add(row2);
                                                                                                Session["Correlativas"] = dC;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else // SIN PARCIALES CON PROMOCION 
                                                                                {
                                                                                    if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPAprob == CantRECP)
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }// No Promociona ni regulariza RecP = LIBRE
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPDesap == CantRECP)
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                DataTable dtAlumno = new DataTable();
                                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                                DataTable dC = new DataTable();
                                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                                DataRow row2 = dC.NewRow();

                                                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                                dC.Rows.Add(row2);
                                                                                                Session["Correlativas"] = dC;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (CantPDesap == CantP) // DESAPROBO TODOS VEO REC
                                                                                {
                                                                                    if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPAprob == CantRECP)
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            } // No Promociona ni regulariza RecP = LIBRE
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPDesap == CantRECP)
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                DataTable dtAlumno = new DataTable();
                                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                                DataTable dC = new DataTable();
                                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                                DataRow row2 = dC.NewRow();

                                                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                                dC.Rows.Add(row2);
                                                                                                Session["Correlativas"] = dC;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else // NO APRUEBA REC TP  
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                            } // PORCENTAJE TP < A REGULAR
                                                            else
                                                            {
                                                                LibreId(Id, aluId);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Promociona == 0) // NO SE PROMOCIONA LA MATERIA
                                                        {
                                                            if ((PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %Regular 
                                                            {
                                                                if ((CantPAprob == CantP)) // REGULAR PARCIALES 
                                                                {
                                                                    if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                    {
                                                                        RegularizaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                }
                                                                else // HAY PARCIALES DESAPROBADOS
                                                                {
                                                                    if ((CantPDesap > 0)) // HAY PARCIALES DESAPROBADOS
                                                                    {
                                                                        if ((CantRECPAprob == CantRECP)) // coincide numero de REC parc APRO con los que se presento a recuperar (APROBÓ)
                                                                        {
                                                                            if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                LibreId(Id, aluId);
                                                                            }
                                                                        } // desaprobo rec
                                                                        else
                                                                        {
                                                                            if (CantRECPDesap == CantRECP)
                                                                            {
                                                                                LibreId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                DataTable dtAlumno = new DataTable();
                                                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                DataTable dC = new DataTable();
                                                                                dC = Session["Correlativas"] as DataTable;
                                                                                DataRow row2 = dC.NewRow();

                                                                                row2["lblAlumno3"] = AlumnoNombre;
                                                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                dC.Rows.Add(row2);
                                                                                Session["Correlativas"] = dC;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else // NO APRUEBA TP  
                                                            {
                                                                LibreId(Id, aluId);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataTable dtAlumno = new DataTable();
                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                    DataTable dC = new DataTable();
                                                    dC = Session["Correlativas"] as DataTable;
                                                    DataRow row2 = dC.NewRow();

                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (TP)..";
                                                    dC.Rows.Add(row2);
                                                    Session["Correlativas"] = dC;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            DataTable dtAlumno = new DataTable();
                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                            DataTable dC = new DataTable();
                                            dC = Session["Correlativas"] as DataTable;
                                            DataRow row2 = dC.NewRow();

                                            row2["lblAlumno3"] = AlumnoNombre;
                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (PARCIALES)..";
                                            dC.Rows.Add(row2);
                                            Session["Correlativas"] = dC;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrillaRecAsist2.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in GrillaRecAsist2.Rows)
                            {

                                int Promociona = 0;
                                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                                Int32 usuIdUltimaModificacion = this.Master.usuId;
                                DataTable dt5 = new DataTable();
                                int CantTP = 0;
                                int CantP = 0;
                                int CantRECP = 0;
                                int CantRECTP = 0;

                                int CantPProm = 0;
                                int CantPAprob = 0;
                                int CantPDesap = 0;

                                int CantTPAprob = 0;
                                int CantTPDesap = 0;

                                int CantRECPProm = 0;
                                int CantRECPAprob = 0;
                                int CantRECPDesap = 0;

                                int CantRECTPAprob = 0;
                                int CantRECTPDesap = 0;

                                int Asistencia = 0;
                                int AsistenciaProm = 0;
                                int AsistenciaReg = 0;

                                int CantRECAsist = 0;
                                int CantRECAsistAprob = 0;
                                int CantRECAsistDesap = 0;

                                int NotaReg = 0;
                                int NotaProm = 0;
                                int TPAprobadosPorcReg = 0;
                                int TPAprobadosPorcProm = 0;

                                int recId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["recId"]);
                                int aluId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["aluId"]);
                                int ictId = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["Id"]);


                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                DataTable dtParamCondRegProm = new DataTable();

                                if (dt5.Rows.Count > 0)
                                {
                                    dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
                                    Promociona = Convert.ToInt32(dt5.Rows[0]["escPromociona"]);
                                    //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
                                }

                                if (dtParamCondRegProm.Rows.Count > 0) // Traigo parametros para Regular y Promocion 
                                {
                                    if (Promociona == 0)
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        //TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);

                                    }
                                    else
                                    {
                                        AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
                                        NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
                                        TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
                                        AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmAsistencia"]);
                                        NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNota"]);
                                        TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmPracticasAprob"]);
                                    }
                                }


                                dt = ocnRegistracionCalificaciones.controlarCondicion(ictId); //traigo todas las notas de ese espacio para ese alumno
                                Id = ictId;

                                int Condicion = Convert.ToInt32(GrillaRecAsist2.DataKeys[row.RowIndex].Values["cdnId"]);

                                if (Condicion != 10)
                                {
                                    if (dt.Rows.Count > 0)
                                    { // Controlo cuantos Parciales, TP, rec TIENE ese espacio Curricular..
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            int treId = Convert.ToInt32(row2["treId"].ToString());
                                            if (treId == 1) // Parcial
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a")//AUSENTE
                                                    {
                                                        CantPDesap = CantPDesap + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                            {
                                                                CantPProm = CantPProm + 1;
                                                                CantPAprob = CantPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                                {
                                                                    CantPAprob = CantPAprob + 1;
                                                                }
                                                                else
                                                                {
                                                                    CantPDesap = CantPDesap + 1;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantPAprob = CantPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantPDesap = CantPDesap + 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                CantP = CantP + 1;
                                            }

                                            if (treId == 2) // TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantTPAprob = CantTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantTPDesap = CantTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantTP = CantTP + 1;
                                            }

                                            if (treId == 3) // REC parcial
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "a") //AUSENTE
                                                    {
                                                        CantRECPDesap = CantRECPDesap + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaProm)
                                                            {
                                                                CantRECPProm = CantRECPProm + 1;
                                                                CantRECPAprob = CantRECPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                                {
                                                                    CantRECPAprob = CantRECPAprob + 1;
                                                                }
                                                                else
                                                                {
                                                                    CantRECPDesap = CantRECPDesap + 1;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(row2["recNota"].ToString().Trim()) >= NotaReg)
                                                            {
                                                                CantRECPAprob = CantRECPAprob + 1;
                                                            }
                                                            else
                                                            {
                                                                CantRECPDesap = CantRECPDesap + 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                CantRECP = CantRECP + 1;
                                            }

                                            if (treId == 4) // REC TP
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) == "A")
                                                    {
                                                        CantRECTPAprob = CantRECTPAprob + 1;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(row2["recNota"].ToString()) == "D" || Convert.ToString(row2["recNota"].ToString()) == "d" ||
                                                        Convert.ToString(row2["recNota"].ToString()) == "a") // Nota Letra
                                                        {
                                                            CantRECTPDesap = CantRECTPDesap + 1;
                                                        }
                                                    }

                                                }
                                                CantRECTP = CantRECTP + 1;
                                            }

                                            if (treId == 7) // Rec Asistencia
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Convert.ToString(row2["recNota"].ToString()) != "a")
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                            {
                                                                Asistencia = 4; //PROMOCION
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                                {
                                                                    Asistencia = 5; //REGULAR
                                                                }
                                                                else
                                                                {
                                                                    if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                    {
                                                                        Asistencia = 6; // Desaprueba Asistencia
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            {
                                                                Asistencia = 5; //REGULAR
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                {
                                                                    Asistencia = 6; // Desaprueba Asistencia
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                CantRECAsist = CantRECAsist + 1;
                                            }

                                            if (treId == 5) // ASISTENCIA
                                            {
                                                if (Convert.ToString(row2["recNota"].ToString()) != "")
                                                {
                                                    if (Promociona == 1)
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaProm)
                                                        {
                                                            Asistencia = 1; //PROMOCION
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                            {
                                                                Asistencia = 2; //REGULAR
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                                {
                                                                    Asistencia = 3; // Desaprueba Asistencia
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(row2["recNota"].ToString()) >= AsistenciaReg)
                                                        {
                                                            Asistencia = 2; //REGULAR
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToInt32(row2["recNota"].ToString()) <= AsistenciaReg)
                                                            {
                                                                Asistencia = 3; // Desaprueba Asistencia
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //CONTROLO  PorcPractAprob 
                                        Decimal PorcPractAprob = 0;
                                        if (CantTP != 0)
                                        {
                                            PorcPractAprob = (CantTPAprob + CantRECTPAprob) * 100 / CantTP;
                                            //if ((PorcPractAprob < TPAprobadosPorcProm) & (PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %PROMOCION 
                                            //{
                                            //    PorcPractAprob = (CantTPAprob + CantRECTPAprob) * 100 / CantTP;
                                            //}
                                        }

                                        if (CantP > 0) // HAY PARCIALES?? 
                                        {
                                            if ((CantPAprob + CantPDesap == CantP)) // RINDIO TODOS PACIALES
                                            {
                                                if (CantTP > 0) // HAY TP??  SI
                                                {
                                                    if ((CantTPAprob + CantTPDesap == CantTP)) // RINDIO TODOS LOS TP
                                                    {
                                                        if (Promociona == 1)
                                                        {
                                                            if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                                                            {
                                                                if ((CantPProm == CantP)) // PROMOCIONA PARCIALES 
                                                                {
                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                    {
                                                                        PromocionaId(Id, aluId);
                                                                    }
                                                                    else
                                                                    {
                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                        {
                                                                            RegularizaId(Id, aluId);
                                                                        }
                                                                        else // No cumple Asistencia -- Libre
                                                                        {
                                                                            LibreId(Id, aluId);
                                                                        }
                                                                    }
                                                                }
                                                                else // No promociona Parciales --- Puede promocionar si Rec > 7
                                                                {
                                                                    if (CantPAprob == CantP) // Aprobó todos PARCIALES
                                                                    {
                                                                        if (CantPProm != 0) // al menos un Parcial >7
                                                                        {
                                                                            if (CantRECPAprob != 0) // rindio el Rec P para recuperar o promocionar
                                                                            {
                                                                                if (CantRECPProm == CantRECP) // Promociona RecP
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        PromocionaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPAprob == CantRECP)
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO 
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else // No Promociona ni regulariza RecP = LIBRE
                                                                                    {
                                                                                        if (CantRECPDesap == CantRECP)
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            DataTable dtAlumno = new DataTable();
                                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                            DataTable dC = new DataTable();
                                                                                            dC = Session["Correlativas"] as DataTable;
                                                                                            DataRow row2 = dC.NewRow();

                                                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec de TP)..";
                                                                                            dC.Rows.Add(row2);
                                                                                            Session["Correlativas"] = dC;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                RegularizaId(Id, aluId);
                                                                            }
                                                                        }
                                                                        else // Aprobó los dos pero ninguna > 7 = Regular
                                                                        {
                                                                            RegularizaId(Id, aluId);
                                                                        }
                                                                    }
                                                                    else // DESAPROBÓ PARCIALES
                                                                    {
                                                                        if (CantPDesap != CantP) // DESAPROBÓ AL MENOS UNO
                                                                        {
                                                                            if (CantPProm != 0) // al menos un Parcial >7
                                                                            {
                                                                                if (CantRECPProm == CantRECP) // Promociona RecP
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        PromocionaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPAprob == CantRECP)
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        }// No Promociona ni regulariza RecP = LIBRE
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPDesap == CantRECP)
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            DataTable dtAlumno = new DataTable();
                                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                            DataTable dC = new DataTable();
                                                                                            dC = Session["Correlativas"] as DataTable;
                                                                                            DataRow row2 = dC.NewRow();

                                                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                            dC.Rows.Add(row2);
                                                                                            Session["Correlativas"] = dC;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else // SIN PARCIALES CON PROMOCION 
                                                                            {
                                                                                if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPAprob == CantRECP)
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        } // No Promociona ni regulariza RecP = LIBRE
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPDesap == CantRECP)
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            DataTable dtAlumno = new DataTable();
                                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                            DataTable dC = new DataTable();
                                                                                            dC = Session["Correlativas"] as DataTable;
                                                                                            DataRow row2 = dC.NewRow();

                                                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                            dC.Rows.Add(row2);
                                                                                            Session["Correlativas"] = dC;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (CantPDesap == CantP) // DESAPROBO TODOS VEO REC
                                                                            {
                                                                                if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                                {
                                                                                    if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                    {
                                                                                        RegularizaId(Id, aluId);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else // No cumple Asistencia -- Libre
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantRECPAprob == CantRECP)
                                                                                    {
                                                                                        if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                        {
                                                                                            RegularizaId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if ((Asistencia == 2 || Asistencia == 5)) // ASISTENCIA REG
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else // No cumple Asistencia -- Libre
                                                                                            {
                                                                                                LibreId(Id, aluId);
                                                                                            }
                                                                                        } // No Promociona ni regulariza RecP = LIBRE
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (CantRECPDesap == CantRECP)
                                                                                        {
                                                                                            LibreId(Id, aluId);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            DataTable dtAlumno = new DataTable();
                                                                                            dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                            String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                            DataTable dC = new DataTable();
                                                                                            dC = Session["Correlativas"] as DataTable;
                                                                                            DataRow row2 = dC.NewRow();

                                                                                            row2["lblAlumno3"] = AlumnoNombre;
                                                                                            row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                            dC.Rows.Add(row2);
                                                                                            Session["Correlativas"] = dC;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else // no tiene el porcentaje de TP
                                                            {
                                                                if ((PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %REGULAR 
                                                                {
                                                                    if (CantRECTPAprob == CantRECTP)
                                                                    {
                                                                        if ((CantPProm == CantP)) // PROMOCIONA PARCIALES 
                                                                        {
                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                            {
                                                                                PromocionaId(Id, aluId);
                                                                            }
                                                                            else
                                                                            {
                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                                else // No cumple Asistencia -- Libre
                                                                                {
                                                                                    LibreId(Id, aluId);
                                                                                }
                                                                            }
                                                                        }
                                                                        else // No promociona Parciales --- Puede promocionar si Rec > 7
                                                                        {
                                                                            if (CantPAprob == CantP) // Aprobó todos PARCIALES
                                                                            {
                                                                                if (CantPProm != 0) // al menos un Parcial >7
                                                                                {
                                                                                    if (CantRECPAprob != 0) // rindio el Rec P para recuperar
                                                                                    {
                                                                                        if (CantRECPProm == CantRECP) // Promociona RecP
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                PromocionaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPAprob == CantRECP)
                                                                                            {
                                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                    {
                                                                                                        RegularizaId(Id, aluId);
                                                                                                    }
                                                                                                    else // No cumple Asistencia -- Libre
                                                                                                    {
                                                                                                        LibreId(Id, aluId);
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            else // No Promociona ni regulariza RecP = LIBRE
                                                                                            {
                                                                                                if (CantRECPDesap == CantRECP)
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        DataTable dtAlumno = new DataTable();
                                                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                        DataTable dC = new DataTable();
                                                                                        dC = Session["Correlativas"] as DataTable;
                                                                                        DataRow row2 = dC.NewRow();

                                                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                        dC.Rows.Add(row2);
                                                                                        Session["Correlativas"] = dC;
                                                                                    }
                                                                                }
                                                                                else // Aprobó los dos pero ninguna > 7 = Regular
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                            }
                                                                            else // DESAPROBÓ PARCIALES
                                                                            {
                                                                                if (CantPDesap != CantP) // DESAPROBÓ AL MENOS UNO
                                                                                {
                                                                                    if (CantPProm != 0) // al menos un Parcial >7
                                                                                    {
                                                                                        if (CantRECPProm == CantRECP) // Promociona RecP
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                PromocionaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPAprob == CantRECP)
                                                                                            {
                                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                    {
                                                                                                        RegularizaId(Id, aluId);
                                                                                                    }
                                                                                                    else // No cumple Asistencia -- Libre
                                                                                                    {
                                                                                                        LibreId(Id, aluId);
                                                                                                    }
                                                                                                }// No Promociona ni regulariza RecP = LIBRE
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (CantRECPDesap == CantRECP)
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    DataTable dtAlumno = new DataTable();
                                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                                    DataTable dC = new DataTable();
                                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                                    DataRow row2 = dC.NewRow();

                                                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                                    dC.Rows.Add(row2);
                                                                                                    Session["Correlativas"] = dC;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else // SIN PARCIALES CON PROMOCION 
                                                                                    {
                                                                                        if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPAprob == CantRECP)
                                                                                            {
                                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                    {
                                                                                                        RegularizaId(Id, aluId);
                                                                                                    }
                                                                                                    else // No cumple Asistencia -- Libre
                                                                                                    {
                                                                                                        LibreId(Id, aluId);
                                                                                                    }
                                                                                                }// No Promociona ni regulariza RecP = LIBRE
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (CantRECPDesap == CantRECP)
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    DataTable dtAlumno = new DataTable();
                                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                                    DataTable dC = new DataTable();
                                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                                    DataRow row2 = dC.NewRow();

                                                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                                    dC.Rows.Add(row2);
                                                                                                    Session["Correlativas"] = dC;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (CantPDesap == CantP) // DESAPROBO TODOS VEO REC
                                                                                    {
                                                                                        if (CantRECPProm == CantRECP) // RecP > 7 IGUAL rEGULAR POR 2 P DESAPROBADOS
                                                                                        {
                                                                                            if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                            {
                                                                                                RegularizaId(Id, aluId);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else // No cumple Asistencia -- Libre
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (CantRECPAprob == CantRECP)
                                                                                            {
                                                                                                if ((Asistencia == 1) || (Asistencia == 4)) // ASISTENCIA PROMO ----- OJO PARA PONER PROMOCION DEBO VER SI TIENE CORRECTAS LAS CORRELATIVAS 
                                                                                                {
                                                                                                    RegularizaId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                                    {
                                                                                                        RegularizaId(Id, aluId);
                                                                                                    }
                                                                                                    else // No cumple Asistencia -- Libre
                                                                                                    {
                                                                                                        LibreId(Id, aluId);
                                                                                                    }
                                                                                                } // No Promociona ni regulariza RecP = LIBRE
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (CantRECPDesap == CantRECP)
                                                                                                {
                                                                                                    LibreId(Id, aluId);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    DataTable dtAlumno = new DataTable();
                                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                                    DataTable dC = new DataTable();
                                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                                    DataRow row2 = dC.NewRow();

                                                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                                    dC.Rows.Add(row2);
                                                                                                    Session["Correlativas"] = dC;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else // NO APRUEBA REC TP  
                                                                    {
                                                                        LibreId(Id, aluId);
                                                                    }
                                                                } // PORCENTAJE TP < A REGULAR
                                                                else
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Promociona == 0) // NO SE PROMOCIONA LA MATERIA
                                                            {
                                                                if ((PorcPractAprob >= TPAprobadosPorcReg)) //PRACTICOS APROBADOS >= %Regular 
                                                                {
                                                                    if ((CantPAprob == CantP)) // REGULAR PARCIALES 
                                                                    {
                                                                        if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                        {
                                                                            RegularizaId(Id, aluId);
                                                                        }
                                                                        else
                                                                        {
                                                                            LibreId(Id, aluId);
                                                                        }
                                                                    }
                                                                    else // HAY PARCIALES DESAPROBADOS
                                                                    {
                                                                        if ((CantPDesap > 0)) // HAY PARCIALES DESAPROBADOS
                                                                        {
                                                                            if ((CantRECPAprob == CantRECP)) // coincide numero de REC parc APRO con los que se presento a recuperar (APROBÓ)
                                                                            {
                                                                                if ((Asistencia == 2) || (Asistencia == 5)) // ASISTENCIA REG
                                                                                {
                                                                                    RegularizaId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    LibreId(Id, aluId);
                                                                                }
                                                                            } // desaprobo rec
                                                                            else
                                                                            {
                                                                                if (CantRECPDesap == CantRECP)
                                                                                {
                                                                                    LibreId(Id, aluId);
                                                                                }
                                                                                else
                                                                                {
                                                                                    DataTable dtAlumno = new DataTable();
                                                                                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                                                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                                                    DataTable dC = new DataTable();
                                                                                    dC = Session["Correlativas"] as DataTable;
                                                                                    DataRow row2 = dC.NewRow();

                                                                                    row2["lblAlumno3"] = AlumnoNombre;
                                                                                    row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (Rec Parcial)..";
                                                                                    dC.Rows.Add(row2);
                                                                                    Session["Correlativas"] = dC;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else // NO APRUEBA TP  
                                                                {
                                                                    LibreId(Id, aluId);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DataTable dtAlumno = new DataTable();
                                                        dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                        String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                        DataTable dC = new DataTable();
                                                        dC = Session["Correlativas"] as DataTable;
                                                        DataRow row2 = dC.NewRow();

                                                        row2["lblAlumno3"] = AlumnoNombre;
                                                        row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (TP)..";
                                                        dC.Rows.Add(row2);
                                                        Session["Correlativas"] = dC;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                DataTable dtAlumno = new DataTable();
                                                dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                                                String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                                                DataTable dC = new DataTable();
                                                dC = Session["Correlativas"] as DataTable;
                                                DataRow row2 = dC.NewRow();

                                                row2["lblAlumno3"] = AlumnoNombre;
                                                row2["lblObservaciones"] = "Para modificar la Condición debe completar las notas faltantes (PARCIALES)..";
                                                dC.Rows.Add(row2);
                                                Session["Correlativas"] = dC;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "La planilla de Asistencia debe estar completa..";
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



    void RegularizaId(Int32 Id, Int32 aluId)
    {
        try
        {
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            Int32 ControlFaltaCorrelativa = 1;
            DataTable dt5 = new DataTable();
            DataTable dtCondicion = new DataTable();
            int Cond = 0;
            dtCondicion = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
            if (dtCondicion.Rows.Count > 0)
            {
                Cond = Convert.ToInt32(dtCondicion.Rows[0]["cdnId"]);
            }

            if (Cond != 8 && Cond != 10 && Cond != 3)
            {

                ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 12, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// REGULAR

                // Controlo si hay espacios condicionales que dependen de esta nota..

                DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                if (dtEscCorr.Rows.Count > 0)
                {
                    DataTable dtictUlt = new DataTable();
                    foreach (DataRow row2 in dtEscCorr.Rows)
                    {
                        ControlFaltaCorrelativa = 1;
                        DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                        if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                        {
                            // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                            foreach (DataRow row4 in dt1.Rows)
                            {
                                if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                {
                                    DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                    if (dt4.Rows.Count != 0)
                                    {
                                        //ControlFaltaCorrelativa = 1;
                                    }
                                    else
                                    {
                                        ControlFaltaCorrelativa = 0;
                                    }
                                }
                            }

                            if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                            {
                                dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                if (dtictUlt.Rows.Count > 0)
                                {
                                    int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                    ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                    if (ocnInscripcionCursadoTerciario.cdnId == 5)
                                    {
                                        ocnInscripcionCursadoTerciario.cdnId = 1;
                                        ocnInscripcionCursadoTerciario.Actualizar();
                                    }
                                }
                                //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                            }
                        }
                    }
                }
            }
            else
            {
                // tiene otra condicion a Regular
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

    void LibreId(Int32 Id, Int32 aluId)
    {
        try
        {
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            Int32 ControlFaltaCorrelativa = 1;
            DataTable dt5 = new DataTable();
            DataTable dtCondicion = new DataTable();
            int Cond = 0;
            dtCondicion = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
            if (dtCondicion.Rows.Count > 0)
            {
                Cond = Convert.ToInt32(dtCondicion.Rows[0]["cdnId"]);
            }

            if (Cond != 8 && Cond != 10 && Cond != 3)
            {
                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// REGULAR
                ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 3, null, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);// Libre
                                                                                                                                         // ver si hay espacios concicionales
                DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                if (dtEscCorr.Rows.Count > 0)
                {
                    DataTable dtictUlt = new DataTable();
                    foreach (DataRow row2 in dtEscCorr.Rows)
                    {
                        ControlFaltaCorrelativa = 1;
                        DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                        if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                        {
                            // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                            foreach (DataRow row4 in dt1.Rows)
                            {
                                if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                {
                                    DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                    if (dt4.Rows.Count != 0)
                                    {
                                        //ControlFaltaCorrelativa = 1;
                                    }
                                    else
                                    {
                                        ControlFaltaCorrelativa = 0;
                                    }
                                }
                            }

                            if (ControlFaltaCorrelativa == 0)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                            {
                                dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                if (dtictUlt.Rows.Count > 0)
                                {
                                    int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                    ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                    if (ocnInscripcionCursadoTerciario.cdnId == 5)
                                    {
                                        ocnInscripcionCursadoTerciario.cdnId = 3;
                                        ocnInscripcionCursadoTerciario.Actualizar();
                                    }
                                }
                                //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                            }
                        }
                    }
                }

                return;
            }
            else
            {
                //otra condición
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

    void PromocionaId(Int32 Id, Int32 aluId)
    {
        try
        {
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            Int32 ControlFaltaCorrelativa = 1;
            DataTable dt5 = new DataTable();
            List<String> CadenaEspacios = new List<String>();
            DataTable dtCorrelativas = new DataTable();
            //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);

            DataTable dtCondicion = new DataTable();
            int Cond = 0;
            dtCondicion = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
            if (dtCondicion.Rows.Count > 0)
            {
                Cond = Convert.ToInt32(dtCondicion.Rows[0]["cdnId"]);
            }

            if (Cond != 8 && Cond != 10 && Cond != 3)
            {

                String EspCurricular = "";
                dtCorrelativas = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(escId.SelectedValue), insId); // Traigo Correlativas  
                if (dtCorrelativas.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                {
                    CadenaEspacios = new List<String>();
                    // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                    foreach (DataRow rowCorrelativa in dtCorrelativas.Rows)
                    {
                        DataTable dtIctIdxCondicion = new DataTable();

                        if (Convert.ToInt32(rowCorrelativa["cotId"].ToString()) == 3) // para rendir o promocionar tiene que estar aprobada
                        {
                            Int32 escIdVer = Convert.ToInt32(rowCorrelativa["escIdCorrel"].ToString());
                            Int32 cotIdVer = Convert.ToInt32(rowCorrelativa["cotId"].ToString());
                            dtIctIdxCondicion = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(rowCorrelativa["escIdCorrel"].ToString()), Convert.ToInt32(rowCorrelativa["cotId"].ToString()));
                            if (dtIctIdxCondicion.Rows.Count != 0)
                            {
                                //ControlFaltaCorrelativa = 1;
                            }
                            else
                            {
                                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(rowCorrelativa["Id"].ToString()), insId);
                                EspCurricular = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                CadenaEspacios.Add(EspCurricular);
                                ControlFaltaCorrelativa = 0;
                            }
                        }
                    }
                }
                else // No hay correlativas
                {
                    //ControlFaltaCorrelativa = 1;
                }

                if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Actualizo Inscripcion Cursado Terciario
                {
                    ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 2, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion); // PROMOCIONA
                }
                else
                {
                    DataTable dtAlumno = new DataTable();
                    dtAlumno = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
                    String AlumnoNombre = Convert.ToString(dtAlumno.Rows[0]["Alumno"]);
                    DataTable dC = new DataTable();
                    dC = Session["Correlativas"] as DataTable;
                    DataRow row2 = dC.NewRow();
                    ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 12, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion); // Regular

                    row2["lblAlumno3"] = AlumnoNombre;
                    row2["lblObservaciones"] = String.Join(", ", CadenaEspacios);
                    dC.Rows.Add(row2);
                    Session["Correlativas"] = dC;
                }

                // Controlo si hay espacios condicionales que dependen de esta nota..

                DataTable dtEscCorr = ocnCorrelativa.ObtenerxcurIdxescIdxcotId(Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue)); // Traigo materia que tienen correlativa a ese espacio  
                if (dtEscCorr.Rows.Count > 0)
                {
                    DataTable dtictUlt = new DataTable();
                    foreach (DataRow row2 in dtEscCorr.Rows)
                    {
                        ControlFaltaCorrelativa = 1;
                        DataTable dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(row2["escIdOriginal"].ToString()), insId); // Traigo Correlativas  
                        if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                        {
                            // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                            foreach (DataRow row4 in dt1.Rows)
                            {
                                if (Convert.ToInt32(row4["cotId"].ToString()) != 3)
                                {
                                    DataTable dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(aluId, Convert.ToInt32(row4["escIdCorrel"].ToString()), Convert.ToInt32(row4["cotId"].ToString()));
                                    if (dt4.Rows.Count != 0)
                                    {
                                        //ControlFaltaCorrelativa = 1;
                                    }
                                    else
                                    {
                                        ControlFaltaCorrelativa = 0;
                                    }
                                }
                            }

                            if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                            {
                                dtictUlt = ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(row2["escIdOriginal"].ToString()));

                                if (dtictUlt.Rows.Count > 0)
                                {
                                    int Id2 = Convert.ToInt32(dtictUlt.Rows[0]["Id"]);
                                    ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Id2);
                                    if (ocnInscripcionCursadoTerciario.cdnId == 5) // Condicional
                                    {
                                        ocnInscripcionCursadoTerciario.cdnId = 1; // cursando
                                        ocnInscripcionCursadoTerciario.Actualizar();
                                    }
                                }
                                //ocnInscripcionCursadoTerciario.ObtenerUltxaluIdxcurIdxescId(aluId, Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(escId.SelectedValue));
                            }
                        }
                    }
                }
            }
            else
            {
                //otra condicion
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


    void RecursaId(Int32 Id, Int32 aluId)
    {
        try
        {
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            DataTable dtCondicion = new DataTable();
            int Cond = 0;
            dtCondicion = ocnInscripcionCursadoTerciario.ObtenerUno(Id);
            if (dtCondicion.Rows.Count > 0)
            {
                Cond = Convert.ToInt32(dtCondicion.Rows[0]["cdnId"]);
            }

            if (Cond != 8 && Cond != 10 && Cond != 3)
            {
                ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 11, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion); // PROMOCIONA
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

    protected void btnActa_clik(object sender, EventArgs e)
    {
        alerError.Visible = false;
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 espCId = Int32.Parse(escId.SelectedValue.ToString());
            Int32 aniocursado = 0; Int32 ParamInt1 = 0;

            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }
            //if (cdnId.SelectedValue != "0")
            //{
            //    //ParamInt1 = Convert.ToInt32(cdnId.SelectedValue);
            //}
            else
            {
                //ParamInt1 = 4;
            }


            NomRep = "ActaPromocion.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + espCId + "&aniocursado=" + aniocursado + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);
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


    protected void AnioCursado_TextChanged(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        pnlContents.Visible = false;
        GrillaNota.DataSource = null;
        GrillaNota.DataBind();
        btnCondicion.Visible = false;
        BtnNota.Visible = false;
        btnPrint.Visible = false;
        btnActa.Visible = false;
        GrillaRecAsist.DataSource = null;
        GrillaRecAsist.DataBind();
        GrillaRecAsist2.DataSource = null;
        GrillaRecAsist2.DataBind();

        curId.SelectedValue = "0";
        escId.SelectedValue = "0";
        ExamenTipoId.SelectedValue = "0";
    }
}
