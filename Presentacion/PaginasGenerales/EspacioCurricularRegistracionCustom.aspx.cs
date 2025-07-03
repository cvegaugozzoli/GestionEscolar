using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class EspacioCurricularRegistracionCustom : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.CondicionParametrosFijos ocnCondicionParametrosFijos = new GESTIONESCOLAR.Negocio.CondicionParametrosFijos();
    GESTIONESCOLAR.Negocio.EspCurrEvaluacion ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion();


    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Espacio Curricular - Registracion";
                insId = Convert.ToInt32(Session["_Institucion"]);
                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/
                    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                    //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                    camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                    fodId.DataValueField = "Valor"; fodId.DataTextField = "Texto"; fodId.DataSource = (new GESTIONESCOLAR.Negocio.FormatoDictado()).ObtenerLista("[Seleccionar...]"); fodId.DataBind();
                    regId.DataValueField = "Valor"; regId.DataTextField = "Texto"; regId.DataSource = (new GESTIONESCOLAR.Negocio.Regimen()).ObtenerLista("[Seleccionar...]"); regId.DataBind();
                    //cdnId.DataValueField = "Valor"; cdnId.DataTextField = "Texto"; cdnId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerLista("[Seleccionar...]"); cdnId.DataBind();

                    if (Id != 0)
                    {

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                        camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                        carId.Enabled = false; NivelID.Enabled = false;
                        plaId.Enabled = false;
                        curId.Enabled = false;
                        camId.Enabled = false;
                        ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(Id, insId);
                        this.escNombre.Text = ocnEspacioCurricular.escNombre;
                        this.escHorasSemanalesReloj.Text = ocnEspacioCurricular.escHorasSemanalesReloj.ToString();
                        this.escHorasSemanalesCatedra.Text = ocnEspacioCurricular.escHorasSemanalesCatedra.ToString();
                        this.escPromociona.Checked = ocnEspacioCurricular.escPromociona;

                        this.escActivo.Checked = ocnEspacioCurricular.escActivo;
                        this.NivelID.SelectedValue = (ocnEspacioCurricular.tcaId == 0 ? "" : ocnEspacioCurricular.tcaId.ToString());
                        this.carId.SelectedValue = (ocnEspacioCurricular.carId == 0 ? "" : ocnEspacioCurricular.carId.ToString());
                        this.plaId.SelectedValue = (ocnEspacioCurricular.plaId == 0 ? "" : ocnEspacioCurricular.plaId.ToString());
                        this.curId.SelectedValue = (ocnEspacioCurricular.curId == 0 ? "" : ocnEspacioCurricular.curId.ToString());
                        this.camId.SelectedValue = (ocnEspacioCurricular.camId == 0 ? "" : ocnEspacioCurricular.camId.ToString());
                        this.fodId.SelectedValue = (ocnEspacioCurricular.fodId == 0 ? "" : ocnEspacioCurricular.fodId.ToString());
                        this.regId.SelectedValue = (ocnEspacioCurricular.regId == 0 ? "" : ocnEspacioCurricular.regId.ToString());


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


                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.NivelID.Focus();
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            int carrera = Convert.ToInt32(carId.SelectedValue);
            int curso = Convert.ToInt32(curId.SelectedValue);
            int plan = Convert.ToInt32(plaId.SelectedValue);



            Response.Redirect("EspacioCurricularConsulta.aspx?carrera=" + carrera + "&plan=" + plan + "&curso=" + curso, true);
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
            if (carId.SelectedValue.ToString() == "0")
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


            if (Request.QueryString["Id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                int espc = Id;
                ocnEspCurrEvaluacion.EliminarxEspCurr(Id);


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
                        ocnEspacioCurricular.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
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
                        ocnEspacioCurricular.Insertar();
                    }
                    else
                    {
                        //Editar
                        ocnEspacioCurricular.escFechaHoraUltimaModificacion = DateTime.Now;
                        ocnEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;
                        ocnEspacioCurricular.Actualizar();

                        DataTable dt6 = new DataTable();
                        DataTable dt5 = new DataTable();
                        String Nombre = "";

                        dt5 = ocnEspacioCurricular.ObtenerUno(Id, insId);

                        if (dt5.Rows.Count > 0)
                        {
                            dt6 = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]), Convert.ToInt32(DateTime.Now.Year));
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
                                        //Nombre = ("Rec P" + ' ' + Convert.ToString(i));

                                        Nombre = ("Rec P");

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
                                        Nombre = ("Rec Asist");
                                        //Nombre = ("Rec Asist" + ' ' + Convert.ToString(i));

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

                                int PageIndex = 0;
                                if (this.Session["EspacioCurricularConsulta.PageIndex"] == null)
                                {
                                    Session.Add("EspacioCurricularConsulta.PageIndex", 0);
                                }
                                else
                                {
                                    PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
                                }

                            }
                        }

                        int carrera = Convert.ToInt32(carId.SelectedValue);
                        int curso = Convert.ToInt32(curId.SelectedValue);
                        int plan = Convert.ToInt32(plaId.SelectedValue);



                        Response.Redirect("EspacioCurricularConsulta.aspx?carrera=" + carrera + "&plan=" + plan + "&curso=" + curso, true);


                    }
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
<a class=""alert-link"" href=""#"">Error:</a><br/><br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" +  //  + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite 
"</div>";
        }

    }


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carId.SelectedIndex != 0)
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


    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (plaId.SelectedIndex != 0)
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

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (curId.SelectedIndex != 0)
        {

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
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

            if (dt2.Rows.Count > 0)
            {
                carId.DataValueField = "Valor";
                carId.DataTextField = "Texto";
                carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", Convert.ToInt32(NivelID.SelectedValue));
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

    protected void fodId_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
