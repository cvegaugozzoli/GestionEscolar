using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class EspacioCurricularConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();

    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.CondicionParametrosFijos ocnCondicionParametrosFijos = new GESTIONESCOLAR.Negocio.CondicionParametrosFijos();
    GESTIONESCOLAR.Negocio.EspCurrEvaluacion ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion();
    GESTIONESCOLAR.Negocio.Correlativa ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa();

    int insId;
    int PageIndex;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                UpdatePanel2.Visible = false;
                this.Master.TituloDelFormulario = " Espacio Curricular - Consulta";
                insId = Convert.ToInt32(Session["_Institucion"]);
                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

                if ((Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // terciario
                {
                    NivelID.SelectedValue = "4";
                    NivelID.Enabled = false;
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
                    int carIdO = 0;
                    int plaIdO = 0;
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
                        {
                            carId1.Enabled = true;
                            DataTable dt2 = new DataTable();
                            int nivel = Convert.ToInt32(NivelID.SelectedValue);
                            dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

                            if (dt2.Rows.Count > 0)
                            {
                                carId1.DataValueField = "Valor";
                                carId1.DataTextField = "Texto";
                                carId1.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                                carId1.DataBind();

                                if (Request.QueryString["carrera"] != null)
                                {
                                    carId1.SelectedValue = Convert.ToString(Request.QueryString["carrera"]);
                                    plaId.DataValueField = "Valor";
                                    plaId.DataTextField = "Texto";
                                    plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId1.SelectedValue));
                                    plaId.DataBind();

                                    plaId.SelectedValue = Convert.ToString(Request.QueryString["plan"]);

                                    curId.DataValueField = "Valor";
                                    curId.DataTextField = "Texto";
                                    curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                                    curId.DataBind();

                                    curId.SelectedValue = Convert.ToString(Request.QueryString["curso"]);

                                    int PageIndex2 = 0;
                                    if (this.Session["EspacioCurricularConsulta.PageIndex"] == null)
                                    {
                                        Session.Add("EspacioCurricularConsulta.PageIndex", 0);
                                    }
                                    else
                                    {
                                        PageIndex2 = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
                                    }
                                    GrillaCargar(PageIndex2);
                                }
                            }
                            else// es primario inicial o secundario
                            {

                                //DataTable dt3 = new DataTable();
                                //DataTable dt4 = new DataTable();
                                //dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
                                //carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                //dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
                                //plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());



                                //curId.DataValueField = "Valor";
                                //curId.DataTextField = "Texto";
                                //curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", plaIdO);
                                //curId.DataBind();
                                //carId.Enabled = false;
                                //plaId.Enabled = false;
                                //carId.SelectedValue = "0";
                                //plaId.SelectedValue = "0";
                            }
                        }
                        else
                        {
                            //alerError.Visible = true;
                            //lblError.Text = "No existen registros para ese filtro";
                        }
                    }
                    else
                    {
                        NivelID.SelectedValue = "0";
                        NivelID.Enabled = true;
                    }
                    //carId.SelectedValue = "0";
                    //plaId.SelectedValue = "0";
                    //curId.SelectedValue = "0";
                    Nombre.Text = "";
                    camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                    fodId.DataValueField = "Valor"; fodId.DataTextField = "Texto"; fodId.DataSource = (new GESTIONESCOLAR.Negocio.FormatoDictado()).ObtenerLista("[Seleccionar...]"); fodId.DataBind();
                    regId.DataValueField = "Valor"; regId.DataTextField = "Texto"; regId.DataSource = (new GESTIONESCOLAR.Negocio.Regimen()).ObtenerLista("[Seleccionar...]"); regId.DataBind();

                    #region PageIndex
                    int PageIndex = 0;
                    if (this.Session["EspacioCurricularConsulta.PageIndex"] == null)
                    {
                        Session.Add("EspacioCurricularConsulta.PageIndex", 0);
                    }
                    else
                    {
                        PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
                    }
                    #endregion

                    #region Variables de sesion para filtros


                    #endregion

                    //GrillaCargar(PageIndex);
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("EspacioCurricularRegistracionCustom.aspx?Id=0", false);
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

    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = new DataTable();
        dt = ocnEspacioCurricular.ObtenerTodoBuscarxNombre(Nombre.Text.Trim(), insId);
        string ArchivoNombre = "EspacioCurricularConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId1.SelectedIndex != 0)
        {
            this.Grilla.DataSource = null;
            this.Grilla.DataBind();
            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId1.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId1.SelectedValue));
                plaId.DataBind();
                plaId.Enabled = true;
                this.Grilla.DataSource = null;
                this.Grilla.DataBind();
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
            this.Grilla.DataSource = null;
            this.Grilla.DataBind();
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



    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        curIdCargar();
    }


    private void curIdCargar()
    {
        if (curId.SelectedIndex > 0)
        {
            this.Grilla.DataSource = null;
            this.Grilla.DataBind();
            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            //DataTable dt = new DataTable();
            //dt = ocnCampo.ObtenerListaPorUnCurso("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue));
            //if (dt.Rows.Count > 0)
            //{
            //    camId.DataValueField = "Valor";
            //    camId.DataTextField = "Texto";
            //    camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerListaPorUnCurso("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue));
            //    camId.DataBind();
            //}
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        Grilla.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
        GrillaCargar(PageIndex);
        Grilla.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
        Grilla.Columns[7].Visible = true;
        Grilla.Columns[8].Visible = true;

    }

    protected void OnCancel(object sender, EventArgs e)
    {
        Grilla.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
        GrillaCargar(PageIndex);

    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            GridViewRow row = Grilla.Rows[e.RowIndex];
            int Id = Convert.ToInt32(Grilla.DataKeys[e.RowIndex].Values[0]);

            TextBox NroOrden = (TextBox)Grilla.Rows[e.RowIndex].FindControl("txtOrden");
            Int32 NroOrden2 = Convert.ToInt32(NroOrden.Text);

            ocnEspacioCurricular.ActualizarOrden(insId, Id, NroOrden2);
            Grilla.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);

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

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grilla, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";

            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }



    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 niv = 0;
            if (NivelID.SelectedValue.ToString() != "" & NivelID.SelectedValue.ToString() != "0")
            {
                niv = Convert.ToInt32(NivelID.SelectedValue.ToString());
            }
            Int32 car = 0;
            if (carId1.SelectedValue.ToString() != "" & carId1.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId1.SelectedValue.ToString());
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
            Int32 cam = 0;

            dt = new DataTable();
            dt = ocnEspacioCurricular.ObtenerNivxCarxPlanxrCurxEC(niv, car, pla, cur, cam, Nombre.Text.Trim(), insId);


            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                UpdatePanel2.Visible = true;
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    this.Grilla.DataSource = null;

                    this.Grilla.DataBind();
                    alerError.Visible = true;
                    lblError.Text = "No hay registros";
                    UpdatePanel2.Visible = true;
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            string MensajeValidacion = "";
            int Id = 0;

            if (NivelID.SelectedValue.ToString() == "" & NivelID.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nivel..";
                return;
            }
            Int32 car = 0;
            if (carId1.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una carrera..";
                return;
            }
            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Plan..";
                return;
            }
            Int32 cur = 0;
            if (curId.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso..";
                return;
            }

            if (escHorasSemanalesReloj.Text.Trim() == "")
            {
                escHorasSemanalesReloj.Text = "0";
            }
            if (escHorasSemanalesCatedra.Text.Trim() == "")
            {
                escHorasSemanalesCatedra.Text = "0";
            }
            if (fodId.SelectedValue != "7")
            {
                if (camId.SelectedValue == "0")
                {
                    alerError.Visible = true;
                    lblError.Text = "Debe ingresar un Campo del Espacio Curricular..";
                    return;
                }
            }
            if (escNombre.Text.Trim() == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nombre de Espacio Curricular..";
                return;
            }

            if (fodId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una forma de Dictado del Espacio Curricular..";
                return;
            }

            if (fodId.SelectedValue != "7")
            {
                if (regId.SelectedValue == "0")
                {
                    alerError.Visible = true;
                    lblError.Text = "Debe ingresar una Regimen del Espacio Curricular..";
                    return;
                }
            }

            String Nombre = "";

            Id = 0;
            ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(Id, insId);

            ocnEspacioCurricular.escNombre = escNombre.Text.Trim();
            ocnEspacioCurricular.escHorasSemanalesReloj = Convert.ToInt32(escHorasSemanalesReloj.Text.Trim());
            ocnEspacioCurricular.escHorasSemanalesCatedra = Convert.ToInt32(escHorasSemanalesCatedra.Text);

            ocnEspacioCurricular.escActivo = escActivo.Checked;
            ocnEspacioCurricular.escPromociona = escPromociona.Checked;

            if (NivelID.SelectedValue == "2")
            {
                ocnEspacioCurricular.carId = 2;
                ocnEspacioCurricular.plaId = 2;
                ocnEspacioCurricular.tcaId = 2;
            }
            else
            {
                if (NivelID.SelectedValue == "3")
                {
                    ocnEspacioCurricular.carId = 3;
                    ocnEspacioCurricular.plaId = 3;
                    ocnEspacioCurricular.tcaId = 3;
                }
                else
                {
                    ocnEspacioCurricular.carId = Convert.ToInt32((carId1.SelectedValue.Trim() == "" ? "0" : carId1.SelectedValue));
                    ocnEspacioCurricular.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                    ocnEspacioCurricular.tcaId = Convert.ToInt32((NivelID.SelectedValue.Trim() == "" ? "0" : NivelID.SelectedValue));
                }
            }

            ocnEspacioCurricular.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
            ocnEspacioCurricular.camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
            ocnEspacioCurricular.fodId = Convert.ToInt32((fodId.SelectedValue.Trim() == "" ? "0" : fodId.SelectedValue));
            ocnEspacioCurricular.regId = Convert.ToInt32((regId.SelectedValue.Trim() == "" ? "0" : regId.SelectedValue));

            /*....usuId = this.Master.usuId;*/


            ocnEspacioCurricular.insId = insId;
            ocnEspacioCurricular.escFechaHoraCreacion = DateTime.Now;
            ocnEspacioCurricular.escFechaHoraUltimaModificacion = DateTime.Now;
            ocnEspacioCurricular.usuIdCreacion = this.Master.usuId;
            ocnEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;

            /*Validaciones*/


            if (MensajeValidacion.Trim().Length == 0)
            {
                if (Id == 0)
                {
                    //Nuevo
                    int espc = ocnEspacioCurricular.Insertar();
                    //
                    //Insertar eb 

                    int AniaCursado = Convert.ToInt32(DateTime.Now.Year);
                    DataTable dt6 = new DataTable();
                    DataTable dt5 = new DataTable();

                    dt5 = ocnEspacioCurricular.ObtenerUno(espc, insId);

                    if (dt5.Rows.Count > 0)
                    {
                        dt6 = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]), AniaCursado);
                    }
                    else
                    {

                    }


                    if (fodId.SelectedValue == "7")
                    {
                        Nombre = ("Taller Inicial");

                        Id = 0;

                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                        ocnEspCurrEvaluacion.eceDescripcion = "";
                        ocnEspCurrEvaluacion.escId = espc;
                        ocnEspCurrEvaluacion.treId = 9;
                        ocnEspCurrEvaluacion.eceActivo = true;

                        /*....usuId = this.Master.usuId;*/


                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                        /*Validaciones*/

                        //Nuevo
                        ocnEspCurrEvaluacion.Insertar();
                    }
                    else
                    {




                        Nombre = ("Asistencia");

                        Id = 0;

                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                        ocnEspCurrEvaluacion.eceDescripcion = "";
                        ocnEspCurrEvaluacion.escId = espc;
                        ocnEspCurrEvaluacion.treId = 5;
                        ocnEspCurrEvaluacion.eceActivo = true;

                        /*....usuId = this.Master.usuId;*/


                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                        /*Validaciones*/

                        //Nuevo
                        ocnEspCurrEvaluacion.Insertar();



                        if (dt6.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt6.Rows[0]["cpfCantParciales"]) >= 0)
                            {
                                for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantParciales"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                {
                                    Nombre = ("P" + ' ' + Convert.ToString(i));

                                    Id = 0;

                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                    ocnEspCurrEvaluacion.eceNombre = Nombre;
                                    ocnEspCurrEvaluacion.eceDescripcion = "";
                                    ocnEspCurrEvaluacion.escId = espc;
                                    ocnEspCurrEvaluacion.treId = 1;
                                    ocnEspCurrEvaluacion.eceActivo = true;

                                    /*....usuId = this.Master.usuId;*/


                                    ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                    ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                    /*Validaciones*/

                                    //Nuevo
                                    ocnEspCurrEvaluacion.Insertar();
                                }
                            }


                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 3)
                            {
                                if (Convert.ToInt32(dt6.Rows[0]["cpfCantTP"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {
                                        Nombre = ("TP" + ' ' + Convert.ToString(i));

                                        Id = 0;

                                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                                        ocnEspCurrEvaluacion.eceDescripcion = "";
                                        ocnEspCurrEvaluacion.escId = espc;
                                        ocnEspCurrEvaluacion.treId = 2;
                                        ocnEspCurrEvaluacion.eceActivo = true;

                                        /*....usuId = this.Master.usuId;*/


                                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                        /*Validaciones*/

                                        //Nuevo
                                        ocnEspCurrEvaluacion.Insertar();
                                    }
                                }

                                if (Convert.ToInt32(dt6.Rows[0]["cpfCantRTP"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantRTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {
                                        Nombre = ("Rec TP" + ' ' + Convert.ToString(i));

                                        Id = 0;

                                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                                        ocnEspCurrEvaluacion.eceDescripcion = "";
                                        ocnEspCurrEvaluacion.escId = espc;
                                        ocnEspCurrEvaluacion.treId = 4;
                                        ocnEspCurrEvaluacion.eceActivo = true;

                                        /*....usuId = this.Master.usuId;*/


                                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                        /*Validaciones*/

                                        //Nuevo
                                        ocnEspCurrEvaluacion.Insertar();
                                    }
                                }
                            }

                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 1 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 2 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 6)
                            {
                                if (Convert.ToInt32(dt6.Rows[0]["cpfCantTP"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {
                                        Nombre = ("PA" + ' ' + Convert.ToString(i));

                                        Id = 0;

                                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                                        ocnEspCurrEvaluacion.eceDescripcion = "";
                                        ocnEspCurrEvaluacion.escId = espc;
                                        ocnEspCurrEvaluacion.treId = 2;
                                        ocnEspCurrEvaluacion.eceActivo = true;

                                        /*....usuId = this.Master.usuId;*/


                                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                        /*Validaciones*/

                                        //Nuevo
                                        ocnEspCurrEvaluacion.Insertar();
                                    }
                                }

                                if (Convert.ToInt32(dt6.Rows[0]["cpfCantRTP"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantRTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {
                                        Nombre = ("Rec Int" + ' ' + Convert.ToString(i));

                                        Id = 0;

                                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                                        ocnEspCurrEvaluacion.eceDescripcion = "";
                                        ocnEspCurrEvaluacion.escId = espc;
                                        ocnEspCurrEvaluacion.treId = 4;
                                        ocnEspCurrEvaluacion.eceActivo = true;

                                        /*....usuId = this.Master.usuId;*/


                                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                        /*Validaciones*/

                                        //Nuevo
                                        ocnEspCurrEvaluacion.Insertar();
                                    }
                                }
                            }

                            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 4 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 8 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 9
                                 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 10 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 11 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 12
                                  || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 13 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 14 || Convert.ToInt32(dt5.Rows[0]["fodId"]) == 15)
                            {
                                if (Convert.ToInt32(dt6.Rows[0]["cpfCantTP"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {
                                        Nombre = ("ACT" + ' ' + Convert.ToString(i));

                                        Id = 0;

                                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                                        ocnEspCurrEvaluacion.eceDescripcion = "";
                                        ocnEspCurrEvaluacion.escId = espc;
                                        ocnEspCurrEvaluacion.treId = 2;
                                        ocnEspCurrEvaluacion.eceActivo = true;

                                        /*....usuId = this.Master.usuId;*/


                                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                        /*Validaciones*/

                                        //Nuevo
                                        ocnEspCurrEvaluacion.Insertar();
                                    }
                                }

                                if (Convert.ToInt32(dt6.Rows[0]["cpfCantRTP"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantRTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {
                                        Nombre = ("Rec ACT" + ' ' + Convert.ToString(i));

                                        Id = 0;

                                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                                        ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                        ocnEspCurrEvaluacion.eceNombre = Nombre;
                                        ocnEspCurrEvaluacion.eceDescripcion = "";
                                        ocnEspCurrEvaluacion.escId = espc;
                                        ocnEspCurrEvaluacion.treId = 4;
                                        ocnEspCurrEvaluacion.eceActivo = true;

                                        /*....usuId = this.Master.usuId;*/


                                        ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                        ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                        ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                        /*Validaciones*/

                                        //Nuevo
                                        ocnEspCurrEvaluacion.Insertar();
                                    }
                                }
                            }

                            if (Convert.ToInt32(dt6.Rows[0]["cpfCantRecParciales"]) >= 0)
                            {
                                for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantRecParciales"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                {
                                    Nombre = ("Rec P" + ' ' + Convert.ToString(i));

                                    Id = 0;

                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                    ocnEspCurrEvaluacion.eceNombre = Nombre;
                                    ocnEspCurrEvaluacion.eceDescripcion = "";
                                    ocnEspCurrEvaluacion.escId = espc;
                                    ocnEspCurrEvaluacion.treId = 3;
                                    ocnEspCurrEvaluacion.eceActivo = true;

                                    /*....usuId = this.Master.usuId;*/


                                    ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                    ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                    /*Validaciones*/

                                    //Nuevo
                                    ocnEspCurrEvaluacion.Insertar();
                                }
                            }


                            if (Convert.ToInt32(dt6.Rows[0]["cpfRecAsistencia"]) >= 0)
                            {
                                for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfRecAsistencia"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                {
                                    Nombre = ("Rec Asist" + ' ' + Convert.ToString(i));

                                    Id = 0;

                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                    ocnEspCurrEvaluacion.eceNombre = Nombre;
                                    ocnEspCurrEvaluacion.eceDescripcion = "";
                                    ocnEspCurrEvaluacion.escId = espc;
                                    ocnEspCurrEvaluacion.treId = 7;
                                    ocnEspCurrEvaluacion.eceActivo = true;

                                    /*....usuId = this.Master.usuId;*/


                                    ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                    ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                    /*Validaciones*/

                                    //Nuevo
                                    ocnEspCurrEvaluacion.Insertar();
                                }
                            }

                            if (Convert.ToInt32(dt6.Rows[0]["cpfCantColoquio"]) >= 0)
                            {
                                for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantColoquio"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                {
                                    Nombre = ("Coloquio");

                                    Id = 0;

                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                    ocnEspCurrEvaluacion.eceNombre = Nombre;
                                    ocnEspCurrEvaluacion.eceDescripcion = "";
                                    ocnEspCurrEvaluacion.escId = espc;
                                    ocnEspCurrEvaluacion.treId = 8;
                                    ocnEspCurrEvaluacion.eceActivo = true;

                                    /*....usuId = this.Master.usuId;*/


                                    ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                    ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                    /*Validaciones*/

                                    //Nuevo
                                    ocnEspCurrEvaluacion.Insertar();
                                }
                            }

                            if (Convert.ToInt32(dt6.Rows[0]["cpfCantRecColoquio"]) >= 0)
                            {
                                for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantRecColoquio"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                {
                                    Nombre = ("Rec Coloquio");

                                    Id = 0;

                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion(Id);

                                    ocnEspCurrEvaluacion.eceNombre = Nombre;
                                    ocnEspCurrEvaluacion.eceDescripcion = "";
                                    ocnEspCurrEvaluacion.escId = espc;
                                    ocnEspCurrEvaluacion.treId = 13;
                                    ocnEspCurrEvaluacion.eceActivo = true;

                                    /*....usuId = this.Master.usuId;*/


                                    ocnEspCurrEvaluacion.eceFechaHoraCreacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.eceFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnEspCurrEvaluacion.usuIdCreacion = this.Master.usuId;
                                    ocnEspCurrEvaluacion.usuIdUltimaModificacion = this.Master.usuId;

                                    /*Validaciones*/

                                    //Nuevo
                                    ocnEspCurrEvaluacion.Insertar();
                                }
                            }


                        }
                    }
                    int PageIndex = 0;
                    if (this.Session["EspacioCurricularConsulta.PageIndex"] == null)
                    {
                        Session.Add("EspacioCurricularConsulta.PageIndex", 0);
                    }
                    else
                    {
                        PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
                    }
                    GrillaCargar(PageIndex);


                    escNombre.Text = "";
                    escHorasSemanalesReloj.Text = "";
                    escHorasSemanalesCatedra.Text = "";
                    camId.SelectedValue = "0";
                    fodId.SelectedValue = "0";
                    regId.SelectedValue = "0";
                }
            }


            //Response.Redirect("EspacioCurricularConsulta.aspx", true);

            else
            {
                Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
            }

        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error:</a><br/><br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" +  //  + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite 
"</div>";
        }

    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //ocnEspacioCurricular.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(Convert.ToInt32(Id), insId);
                    //ocnEspacioCurricular.Copiar();
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("EspacioCurricularRegistracionCustom.aspx?Id=" + Id + "&Ver=1", true);
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
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["EspacioCurricularConsulta.PageIndex"] != null)
            {
                Session["EspacioCurricularConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("EspacioCurricularConsulta.PageIndex", e.NewPageIndex);
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

            DateTime FECHA = DateTime.Now;

            Int32 usuario = this.Master.usuId;

            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
            ocnEspCurrEvaluacion.EliminarxEspCurr(Id);
            ocnEspacioCurricular.Eliminar(Id);
            ocnCorrelativa.EliminarxescCorr(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(Grilla.PageIndex);
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

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }


    protected void btnCorrelativas_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CorrelativaConsulta.aspx", true);

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
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
            {
                carId1.Enabled = true;
                DataTable dt2 = new DataTable();
                int nivel = Convert.ToInt32(NivelID.SelectedValue);
                dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

                if (dt2.Rows.Count > 0)
                {
                    carId1.DataValueField = "Valor";
                    carId1.DataTextField = "Texto";
                    carId1.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                    carId1.DataBind();

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
                carId1.Enabled = false;
                plaId.Enabled = false;
                carId1.DataValueField = "Valor";
                carId1.DataTextField = "Texto";
                carId1.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", Convert.ToInt32(NivelID.SelectedValue));
                carId1.DataBind();
                carId1.SelectedValue = Convert.ToString(carIdO);

                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", carIdO);
                plaId.DataBind();
                plaId.SelectedValue = Convert.ToString(plaIdO);
            }
        }
        else
        {
            //alerError.Visible = true;
            //lblError.Text = "No existen registros para ese filtro";
        }
    }

    protected void fodId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fodId.SelectedValue == "7")
        {
            regId.Enabled = false;
            camId.Enabled = false;
        }
        else
        {
            regId.Enabled = true;
            camId.Enabled = true;
        }
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {

            alerError.Visible = false;
            if (carId1.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una carrera..";
                return;
            }


            int carId = Convert.ToInt32(carId1.SelectedValue);

            String NomRep = "";

            NomRep = "Correlativas.rpt";

            FuncionesUtiles.AbreVentana("../PaginasGenerales/Reporte.aspx?carId=" + carId + "&NomRep=" + NomRep);
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

    protected void btnMaterias_Click(object sender, EventArgs e)
    {
        try
        {

            alerError.Visible = false;
            if (carId1.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una carrera..";
                return;
            }


            int carId = Convert.ToInt32(carId1.SelectedValue);

            String NomRep = "";

            NomRep = "ImprimirMaterias.rpt";

            FuncionesUtiles.AbreVentana("../PaginasGenerales/Reporte.aspx?carId=" + carId + "&NomRep=" + NomRep);
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