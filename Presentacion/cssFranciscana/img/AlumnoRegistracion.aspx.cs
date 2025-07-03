using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AlumnoRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Provincia ocnProvincia = new GESTIONESCOLAR.Negocio.Provincia();
    GESTIONESCOLAR.Negocio.Departamento ocnDepartamento = new GESTIONESCOLAR.Negocio.Departamento();
    GESTIONESCOLAR.Negocio.Localidad ocnLocalidad = new GESTIONESCOLAR.Negocio.Localidad();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();

    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable dt7 = new DataTable();
    int IdAlu;
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Alumno - Registracion";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/
                    sexId.DataValueField = "Valor"; sexId.DataTextField = "Texto"; sexId.DataSource = (new GESTIONESCOLAR.Negocio.Sexo()).ObtenerLista("[Seleccionar...]"); sexId.DataBind();
                    paisId.DataValueField = "Valor"; paisId.DataTextField = "Texto"; paisId.DataSource = (new GESTIONESCOLAR.Negocio.Pais()).ObtenerLista("[Seleccionar...]"); paisId.DataBind();
                    paisId.SelectedValue = "0";
                    provinciaId.DataValueField = "Valor"; provinciaId.DataTextField = "Texto"; provinciaId.DataSource = (new GESTIONESCOLAR.Negocio.Provincia()).ObtenerLista(""); provinciaId.DataBind();
                    DepartamentoId.DataValueField = "Valor"; DepartamentoId.DataTextField = "Texto"; DepartamentoId.DataSource = (new GESTIONESCOLAR.Negocio.Departamento()).ObtenerLista("[Seleccionar...]"); DepartamentoId.DataBind();
                    //LocalidadId.DataValueField = "Valor"; LocalidadId.DataTextField = "Texto"; LocalidadId.DataSource = (new GESTIONESCOLAR.Negocio.Localidad()).ObtenerLista("[Seleccionar...]"); LocalidadId.DataBind();

                    ParentescoId.DataValueField = "Valor";
                    ParentescoId.DataTextField = "Texto";
                    ParentescoId.DataSource = (new GESTIONESCOLAR.Negocio.Parentesco()).ObtenerLista("[Seleccionar...]");
                    ParentescoId.DataBind();
                    ParentescoId.SelectedValue = "[Seleccionar...]";

                    int oo = 0;
                    oo = ParentescoId.Items.Count;


                    dt6 = new DataTable();
                    dt6 = ocnAlumno.ObtenerUno(Id); //Para inicializar combobox
                    if (dt6.Rows.Count > 0)//existe Alumno en Alumno
                    {
                        int Provincia;
                        if (dt6.Rows[0]["aluPaisNac"] != System.DBNull.Value)
                        {
                            paisId.DataValueField = "Valor"; paisId.DataTextField = "Texto"; paisId.DataSource = (new GESTIONESCOLAR.Negocio.Provincia()).ObtenerLista(""); paisId.DataBind();
                            paisId.SelectedValue = Convert.ToString(dt6.Rows[0]["aluPaisNac"]);
                        }

                        if (dt6.Rows[0]["aluProvNac"] != System.DBNull.Value)
                        {
                           int Pais = Convert.ToInt32(dt6.Rows[0]["aluPaisNac"]);
                            provinciaId.DataValueField = "Valor"; provinciaId.DataTextField = "Texto"; provinciaId.DataSource = (new GESTIONESCOLAR.Negocio.Provincia()).ObtenerLista("[Seleccionar...]"); provinciaId.DataBind();
                            provinciaId.SelectedValue = Convert.ToString(dt6.Rows[0]["aluProvNac"]);
                        }
                        if (dt6.Rows[0]["aluDeptoNac"] != System.DBNull.Value)
                        {
                            int prov = Convert.ToInt32(dt6.Rows[0]["aluProvNac"]);
                            //Provincia = Convert.ToInt32(dt6.Rows[0]["aluProvNac"]);
                            DepartamentoNac.DataValueField = "Valor"; DepartamentoNac.DataTextField = "Texto"; DepartamentoNac.DataSource = (new GESTIONESCOLAR.Negocio.Departamento()).ObtenerLista2("[Seleccionar...]", prov); DepartamentoNac.DataBind();
                            DepartamentoNac.SelectedValue = Convert.ToString(dt6.Rows[0]["aluDeptoNac"]);
                        }
                        if (dt6.Rows[0]["aluLocNac"] != System.DBNull.Value)
                        {
                            int Departamento = Convert.ToInt32(dt6.Rows[0]["aluDeptoNac"]);
                            Provincia = Convert.ToInt32(dt6.Rows[0]["aluProvNac"]);
                            LocalidadId.DataValueField = "Valor"; LocalidadId.DataTextField = "Texto"; LocalidadId.DataSource = (new GESTIONESCOLAR.Negocio.Localidad()).LOCALIDADES_TraeporDeptoId_PciaId("[Seleccionar...]",Provincia,Departamento); LocalidadId.DataBind();
                            LocalidadId.SelectedValue = Convert.ToString(dt6.Rows[0]["aluLocNac"]);
                        }
                    }

                    if (Id != 0)
                    {
                        DataTable dt = new DataTable();
                        ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno(Id);
                        this.aluNombre.Text = ocnAlumno.aluNombre;
                        this.aluDoc.Text = ocnAlumno.aluDoc;
                        this.aluCuit.Text = ocnAlumno.aluCuit;
                        this.aluLegajoNumero.Text = ocnAlumno.aluLegajoNumero;
                        this.aluDomicilio.Text = ocnAlumno.aluDomicilio;
                        this.DepartamentoId.SelectedValue = (ocnAlumno.aluDepto == 0 ? "0" : ocnAlumno.aluDepto.ToString());
                        this.aluFechaNacimiento.Text = ocnAlumno.aluFechaNacimiento;
                        this.paisId.SelectedValue = Convert.ToString(ocnAlumno.aluPaisNac.ToString());
                        //this.provinciaId.SelectedValue = Convert.ToString(ocnAlumno.aluProvNac);
                        //this.DepartamentoNac.SelectedValue = Convert.ToString(ocnAlumno.aluDeptoNac);
                        //this.LocalidadId.SelectedValue = Convert.ToString(ocnAlumno.aluLocNac);
                        this.aluMail.Text = ocnAlumno.aluMail;
                        this.aluTelefono.Text = ocnAlumno.aluTelefono;
                        this.aluActivo.Checked = ocnAlumno.aluActivo;
                        this.aluTelCel.Text = ocnAlumno.aluTelefonoCel;

                        this.sexId.SelectedValue = (ocnAlumno.sexId == 0 ? "" : ocnAlumno.sexId.ToString());

                        dt = ocnAlumnoFamiliar.ObtenerListaFamiliar(Id);//Obtengo una tabla con los familiares asociado al alumno
                        if (dt.Rows.Count == 3) //Estan los Tres Registros, Padre Madre, Otros
                        {
                            int UsuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString()); //usiId Padre
                            int UsuIdM = Convert.ToInt32(dt.Rows[1]["UsuId"].ToString());//usiId Madre
                            int UsuIdO = Convert.ToInt32(dt.Rows[2]["UsuId"].ToString());//usiId Otro
                                                                                         // para obtener usuario y clave
                                                                                         //dt2 = ocnUsuario.ObtenerUno(UsuIdP);
                                                                                         //dt3 = ocnUsuario.ObtenerUno(UsuIdM);
                                                                                         //dt4 = ocnUsuario.ObtenerUno(UsuIdO);

                            this.ApePadre.Text = dt.Rows[0]["Apellido"].ToString();
                            this.NomPadre.Text = dt.Rows[0]["Nombre"].ToString();
                            this.OcupPadre.Text = dt.Rows[0]["Ocupacion"].ToString();
                            this.DniPadre.Text = dt.Rows[0]["Dni"].ToString();
                            this.TelefP.Text = dt.Rows[0]["Telefono"].ToString();
                            this.CuitP.Text = dt.Rows[0]["Cuit"].ToString();
                            this.MailP.Text = dt.Rows[0]["Mail"].ToString();
                            this.txtFijoP.Text = dt.Rows[0]["TelefonoFijo"].ToString();

                            this.ApeMadre.Text = dt.Rows[1]["Apellido"].ToString();
                            this.NomMadre.Text = dt.Rows[1]["Nombre"].ToString();
                            this.OcupMadre.Text = dt.Rows[1]["Ocupacion"].ToString();
                            this.DniMadre.Text = dt.Rows[1]["Dni"].ToString();
                            this.TelefM.Text = dt.Rows[1]["Telefono"].ToString();
                            this.CuitM.Text = dt.Rows[1]["Cuit"].ToString();
                            this.MailM.Text = dt.Rows[1]["Mail"].ToString();
                            this.txtFijoM.Text = dt.Rows[1]["TelefonoFijo"].ToString();

                            this.ApeOtro.Text = dt.Rows[2]["Apellido"].ToString();
                            this.NombOtro.Text = dt.Rows[2]["Nombre"].ToString();
                            this.OcupOtro.Text = dt.Rows[2]["Ocupacion"].ToString();
                            this.DniOtro.Text = dt.Rows[2]["Dni"].ToString();
                            this.TelefO.Text = dt.Rows[2]["Telefono"].ToString();
                            this.CuitO.Text = dt.Rows[2]["Cuit"].ToString();
                            this.MailO.Text = dt.Rows[2]["Mail"].ToString();
                            this.txtFijoO.Text = dt.Rows[2]["TelefonoFijo"].ToString();


                            Int32 patid = 0;
                            patid = Convert.ToInt32(dt.Rows[2]["ParentescoId"]);
                            String parentesco = "";
                            parentesco = dt.Rows[2]["Parentesco"].ToString();

                            this.ParentescoId.SelectedValue = dt.Rows[2]["ParentescoId"].ToString();

                            //this.UsuarioP.Text = dt2.Rows[0]["NombreIngreso"].ToString();
                            //this.UsuarioM.Text = dt3.Rows[0]["NombreIngreso"].ToString();
                            //this.UsuarioO.Text = dt4.Rows[0]["NombreIngreso"].ToString();

                            if (Convert.ToInt32(dt.Rows[0]["TutorInt"].ToString()) == 1)
                            {
                                this.EsTutor.SelectedIndex = 1;
                            }
                            else
                            {
                                if (Convert.ToInt32(dt.Rows[1]["TutorInt"].ToString()) == 1)
                                {
                                    this.EsTutor.SelectedIndex = 0;
                                }
                                else
                                 if (Convert.ToInt32(dt.Rows[2]["TutorInt"].ToString()) == 1)
                                {
                                    this.EsTutor.SelectedIndex = 2;
                                }
                            }
                        }
                        else
                        {
                            if (dt.Rows.Count == 2) //Hay dos Registros, Padre Madre o Padre Otro o Madre Otro
                            {
                                int a = Convert.ToInt32(dt.Rows[0]["ParentescoId"].ToString());
                                if (Convert.ToInt32(dt.Rows[0]["ParentescoId"].ToString()) == 1)//Padre
                                {
                                    //int UsuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString()); //usiId Padre
                                    //dt2 = ocnUsuario.ObtenerUno(UsuIdP);
                                    this.ApePadre.Text = dt.Rows[0]["Apellido"].ToString();
                                    this.NomPadre.Text = dt.Rows[0]["Nombre"].ToString();
                                    this.OcupPadre.Text = dt.Rows[0]["Ocupacion"].ToString();
                                    this.DniPadre.Text = dt.Rows[0]["Dni"].ToString();
                                    this.TelefP.Text = dt.Rows[0]["Telefono"].ToString();
                                    this.CuitP.Text = dt.Rows[0]["Cuit"].ToString();
                                    this.MailP.Text = dt.Rows[0]["Mail"].ToString();
                                    //this.UsuarioP.Text = dt2.Rows[0]["NombreIngreso"].ToString();

                                    //this.ClaveP.Text = dt2.Rows[0]["Clave"].ToString();

                                    if (Convert.ToInt32(dt.Rows[1]["ParentescoId"].ToString()) == 2) //Pregunto si el segundo es Madre
                                    {
                                        //int UsuIdM = Convert.ToInt32(dt.Rows[1]["UsuId"].ToString());//usiId Madre
                                        //dt3 = ocnUsuario.ObtenerUno(UsuIdM);
                                        this.ApeMadre.Text = dt.Rows[1]["Apellido"].ToString();
                                        this.NomMadre.Text = dt.Rows[1]["Nombre"].ToString();
                                        this.OcupMadre.Text = dt.Rows[1]["Ocupacion"].ToString();
                                        this.DniMadre.Text = dt.Rows[1]["Dni"].ToString();
                                        this.TelefM.Text = dt.Rows[1]["Telefono"].ToString();
                                        this.CuitM.Text = dt.Rows[1]["Cuit"].ToString();
                                        this.MailM.Text = dt.Rows[1]["Mail"].ToString();
                                        //this.UsuarioM.Text = dt3.Rows[0]["NombreIngreso"].ToString();
                                        //this.ClaveM.Text = dt3.Rows[0]["Clave"].ToString();


                                        if (Convert.ToInt32(dt.Rows[0]["TutorInt"].ToString()) == 1)
                                        {
                                            this.EsTutor.SelectedIndex = 1;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt.Rows[1]["TutorInt"].ToString()) == 1)
                                            {
                                                this.EsTutor.SelectedIndex = 0;
                                            }
                                        }
                                    }
                                    else //el segundo es Otro
                                    {
                                        //int UsuIdO = Convert.ToInt32(dt.Rows[1]["UsuId"].ToString());//usiId Otro
                                        //dt4 = ocnUsuario.ObtenerUno(UsuIdO);

                                        this.ApeOtro.Text = dt.Rows[1]["Apellido"].ToString();
                                        this.NombOtro.Text = dt.Rows[1]["Nombre"].ToString();
                                        this.OcupOtro.Text = dt.Rows[1]["Ocupacion"].ToString();
                                        this.DniOtro.Text = dt.Rows[1]["Dni"].ToString();
                                        this.TelefO.Text = dt.Rows[1]["Telefono"].ToString();
                                        this.CuitO.Text = dt.Rows[1]["Cuit"].ToString();
                                        this.MailO.Text = dt.Rows[1]["Mail"].ToString();
                                        //this.UsuarioO.Text = dt4.Rows[0]["NombreIngreso"].ToString();

                                        if (Convert.ToInt32(dt.Rows[0]["TutorInt"].ToString()) == 1)
                                        {
                                            this.EsTutor.SelectedIndex = 1;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt.Rows[1]["TutorInt"].ToString()) == 1)
                                            {
                                                this.EsTutor.SelectedIndex = 2;
                                            }
                                        }
                                    }
                                }
                                else //Madre Otro
                                {
                                    if (Convert.ToInt32(dt.Rows[0]["ParentescoId"].ToString()) == 2)
                                    {
                                        int UsuIdM = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());//usiId Madre
                                        dt3 = ocnUsuario.ObtenerUno(UsuIdM);
                                        this.ApeMadre.Text = dt.Rows[0]["Apellido"].ToString();
                                        this.NomMadre.Text = dt.Rows[0]["Nombre"].ToString();
                                        this.OcupMadre.Text = dt.Rows[0]["Ocupacion"].ToString();
                                        this.DniMadre.Text = dt.Rows[0]["Dni"].ToString();
                                        this.TelefM.Text = dt.Rows[0]["Telefono"].ToString();
                                        this.CuitM.Text = dt.Rows[0]["Cuit"].ToString();
                                        this.MailM.Text = dt.Rows[0]["Mail"].ToString();
                                        this.UsuarioM.Text = dt3.Rows[0]["NombreIngreso"].ToString();
                                        //this.ClaveM.Text = dt3.Rows[0]["Clave"].ToString();

                                        //int UsuIdO = Convert.ToInt32(dt.Rows[1]["UsuId"].ToString());//usiId Otro
                                        //dt4 = ocnUsuario.ObtenerUno(UsuIdO);
                                        this.ApeOtro.Text = dt.Rows[1]["Apellido"].ToString();
                                        this.NombOtro.Text = dt.Rows[1]["Nombre"].ToString();
                                        this.OcupOtro.Text = dt.Rows[1]["Ocupacion"].ToString();
                                        this.DniOtro.Text = dt.Rows[1]["Dni"].ToString();
                                        this.TelefO.Text = dt.Rows[1]["Telefono"].ToString();
                                        this.CuitO.Text = dt.Rows[1]["Cuit"].ToString();
                                        this.MailO.Text = dt.Rows[1]["Mail"].ToString();
                                        //this.UsuarioO.Text = dt4.Rows[0]["NombreIngreso"].ToString();
                                        if (Convert.ToInt32(dt.Rows[0]["TutorInt"].ToString()) == 1)
                                        {
                                            this.EsTutor.SelectedIndex = 0;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt.Rows[1]["TutorInt"].ToString()) == 1)
                                            {
                                                this.EsTutor.SelectedIndex = 2;
                                            }
                                        }
                                    }
                                }
                            }
                            else //Hay un rgistro.. O padre, o Madre, o Otro
                            {
                                if (dt.Rows.Count == 1)
                                {
                                    if (Convert.ToInt32(dt.Rows[0]["ParentescoId"].ToString()) == 1)
                                    {
                                        //int UsuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString()); //usiId Padre
                                        //dt2 = ocnUsuario.ObtenerUno(UsuIdP);
                                        this.ApePadre.Text = dt.Rows[0]["Apellido"].ToString();
                                        this.NomPadre.Text = dt.Rows[0]["Nombre"].ToString();
                                        this.OcupPadre.Text = dt.Rows[0]["Ocupacion"].ToString();
                                        this.DniPadre.Text = dt.Rows[0]["Dni"].ToString();
                                        this.TelefP.Text = dt.Rows[0]["Telefono"].ToString();
                                        this.CuitP.Text = dt.Rows[0]["Cuit"].ToString();
                                        this.MailP.Text = dt.Rows[0]["Mail"].ToString();
                                        this.EsTutor.SelectedIndex = 1;
                                        //this.UsuarioP.Text = dt2.Rows[0]["NombreIngreso"].ToString();
                                        //this.ClaveP.Text = dt2.Rows[0]["Clave"].ToString();

                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(dt.Rows[0]["ParentescoId"].ToString()) == 2)
                                        {
                                            //int UsuIdM = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());//usiId Madre
                                            //dt3 = ocnUsuario.ObtenerUno(UsuIdM);
                                            this.ApeMadre.Text = dt.Rows[0]["Apellido"].ToString();
                                            this.NomMadre.Text = dt.Rows[0]["Nombre"].ToString();
                                            this.OcupMadre.Text = dt.Rows[0]["Ocupacion"].ToString();
                                            this.DniMadre.Text = dt.Rows[0]["Dni"].ToString();
                                            this.TelefM.Text = dt.Rows[0]["Telefono"].ToString();
                                            this.CuitM.Text = dt.Rows[0]["Cuit"].ToString();
                                            this.MailM.Text = dt.Rows[0]["Mail"].ToString();
                                            this.EsTutor.SelectedIndex = 0;
                                            //this.UsuarioM.Text = dt3.Rows[0]["NombreIngreso"].ToString();
                                            //this.ClaveM.Text = dt3.Rows[0]["Clave"].ToString();

                                        }
                                        else
                                        {
                                            //int UsuIdO = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());//usiId Otro
                                            //dt4 = ocnUsuario.ObtenerUno(UsuIdO);
                                            this.ApeOtro.Text = dt.Rows[0]["Apellido"].ToString();
                                            this.NombOtro.Text = dt.Rows[0]["Nombre"].ToString();
                                            this.OcupOtro.Text = dt.Rows[0]["Ocupacion"].ToString();
                                            this.DniOtro.Text = dt.Rows[0]["Dni"].ToString();
                                            this.TelefO.Text = dt.Rows[0]["Telefono"].ToString();
                                            this.CuitO.Text = dt.Rows[0]["Cuit"].ToString();
                                            this.MailO.Text = dt.Rows[0]["Mail"].ToString();
                                            this.EsTutor.SelectedIndex = 2;
                                            //this.UsuarioO.Text = dt4.Rows[0]["NombreIngreso"].ToString();
                                        }
                                    }
                                }
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AlumnoConsulta.aspx", true);
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
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno(Id);
            //ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
            //ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
            insId = Convert.ToInt32(Session["_Institucion"]);
            int aluId2 = 0;
            dt5 = new DataTable();
            dt5 = ocnAlumno.ObtenerUnoporDoc(aluDoc.Text.Trim());
            if (dt5.Rows.Count > 0) // Verifico que existe en Alumno
            {
                aluId2 = Convert.ToInt32(Request.QueryString["Id"]);
                ocnAlumno.aluNombre = aluNombre.Text.Trim();
                ocnAlumno.aluDoc = aluDoc.Text.Trim();
                ocnAlumno.aluCuit = aluCuit.Text.Trim();
                ocnAlumno.aluLegajoNumero = aluLegajoNumero.Text.Trim();
                ocnAlumno.aluDomicilio = aluDomicilio.Text.Trim();
                ocnAlumno.aluDepto = Convert.ToInt32((DepartamentoId.SelectedValue.Trim() == "" ? "0" : DepartamentoId.SelectedValue));
                ocnAlumno.aluFechaNacimiento = Convert.ToDateTime(aluFechaNacimiento.Text);
                ocnAlumno.aluPaisNac = Convert.ToInt32((paisId.SelectedValue.Trim() == "" ? "0" : paisId.SelectedValue));
                ocnAlumno.aluProvNac = Convert.ToInt32((provinciaId.SelectedValue.Trim() == "" ? "0" : provinciaId.SelectedValue));
                ocnAlumno.aluDeptoNac = Convert.ToInt32((DepartamentoNac.SelectedValue.Trim() == "" ? "0" : DepartamentoNac.SelectedValue));
                ocnAlumno.aluLocNac = Convert.ToInt32((LocalidadId.SelectedValue.Trim() == "" ? "0" : LocalidadId.SelectedValue));
                ocnAlumno.aluMail = aluMail.Text.Trim();
                ocnAlumno.aluTelefono = aluTelefono.Text.Trim();
                ocnAlumno.aluTelefonoCel = aluTelCel.Text.Trim();
                ocnAlumno.aluActivo = aluActivo.Checked;
                ocnAlumno.sexId = Convert.ToInt32((sexId.SelectedValue.Trim() == "" ? "0" : sexId.SelectedValue));
                ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
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
                ocnAlumno.Actualizar(); //Actualizo Alumno 
            }





            else
            {
                ocnAlumno.aluNombre = aluNombre.Text.Trim();
                ocnAlumno.aluDoc = aluDoc.Text.Trim();
                ocnAlumno.aluCuit = aluCuit.Text.Trim();
                ocnAlumno.aluLegajoNumero = aluLegajoNumero.Text.Trim();
                ocnAlumno.aluDomicilio = aluDomicilio.Text.Trim();
                ocnAlumno.aluDepto = Convert.ToInt32((DepartamentoId.SelectedValue.Trim() == "" ? "0" : DepartamentoId.SelectedValue));
                ocnAlumno.aluFechaNacimiento = Convert.ToDateTime(aluFechaNacimiento.Text);
                ocnAlumno.aluPaisNac = Convert.ToInt32((paisId.SelectedValue.Trim() == "" ? "0" : paisId.SelectedValue));
                ocnAlumno.aluProvNac = Convert.ToInt32((provinciaId.SelectedValue.Trim() == "" ? "0" : provinciaId.SelectedValue));
                ocnAlumno.aluDeptoNac = Convert.ToInt32((DepartamentoNac.SelectedValue.Trim() == "" ? "0" : DepartamentoNac.SelectedValue));
                ocnAlumno.aluLocNac = Convert.ToInt32((LocalidadId.SelectedValue.Trim() == "" ? "0" : LocalidadId.SelectedValue));
                ocnAlumno.aluMail = aluMail.Text.Trim();
                ocnAlumno.aluTelefono = aluTelefono.Text.Trim();
                ocnAlumno.aluTelefonoCel = aluTelCel.Text.Trim();
                ocnAlumno.aluActivo = aluActivo.Checked;
                ocnAlumno.sexId = Convert.ToInt32((sexId.SelectedValue.Trim() == "" ? "0" : sexId.SelectedValue));
                ocnAlumno.aluFechaHoraCreacion = DateTime.Now;
                ocnAlumno.usuIdCreacion = this.Master.usuId;
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
                aluId2 = ocnAlumno.Insertar();

            }

            //Inicializo
            int TutorM = 0;
            int TutorP = 0;
            int TutorO = 0;
            DateTime FechaHoraCreacion1 = DateTime.Now;
            DateTime FechaHoraUltimaModificacion1 = DateTime.Now;
            Int32 usuIdCreacion1 = this.Master.usuId;
            Int32 usuIdUltimaModificacion1 = this.Master.usuId;

            if (EsTutor.SelectedIndex == 0) //tutor Madre
            {
                TutorM = 1;
            }
            else
            if (EsTutor.SelectedIndex == 1) //tutor Padre
            {
                TutorP = 1;
            }
            else
                if (EsTutor.SelectedIndex == 2) //tutor Otro
            {
                TutorO = 1;
            }

            //dt5 = new DataTable();
            //dt5 = ocnAlumno.ObtenerUnoporDoc(aluDoc.Text);
            //if (dt5.Rows.Count == 0) // Verifico que no existe en Alumno
            //{
            int ParentescoOtro = Convert.ToInt32(ParentescoId.SelectedValue);

            if (DniPadre.Text != "") // Verifico si existe en Familiar y luego asigno en AlumnoFamiliar
            {
                dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt = ocnFamiliar.ObtenerUnoPorDoc(DniPadre.Text.Trim());
                //dt1 = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniPadre.Text.Trim());

                if (dt.Rows.Count > 0)//existe Padre en Familiar
                {
                    int FamIdPadre = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniPadre.Text.Trim());

                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(FamIdPadre);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApePadre.Text.Trim();
                    ocnFamiliar.famNombre = NomPadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupPadre.Text.Trim();
                    ocnFamiliar.famDni = DniPadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefP.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoP.Text.Trim();
                    ocnFamiliar.famCuit = CuitP.Text.Trim();
                    ocnFamiliar.famMail = MailP.Text.Trim();
                    //ocnFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                    //ocnFamiliar.usuId = usuIdP;

                    ocnFamiliar.Actualizar();

                    //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                    //String ClaveP = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";

                    if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar);
                        //ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                        ocnAlumnoFamiliar.Actualizar();
                    }
                    else
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = FamIdPadre;
                        ocnAlumnoFamiliar.patId = 1;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                        ocnAlumnoFamiliar.Insertar();
                    }
                }
                else // Inserto Padre en Familiar y en AlumnoFamiliar
                {

                    String ClaveP = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    //Int32 UsuIdNuevoP = ocnUsuario.InsertarTraerId(insId, ApePadre.Text.Trim(), NomPadre.Text.Trim(), DniPadre.Text.Trim(), ClaveP, "", false, MailP.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);
                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(0);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApePadre.Text.Trim();
                    ocnFamiliar.famNombre = NomPadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupPadre.Text.Trim();
                    ocnFamiliar.famDni = DniPadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefP.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoP.Text.Trim();
                    ocnFamiliar.famCuit = CuitP.Text.Trim();
                    ocnFamiliar.famMail = MailP.Text.Trim();
                    //ocnFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraCreacion = DateTime.Today;
                    //ocnFamiliar.usuId = usuIdP;
                    int famIdP = ocnFamiliar.Insertar();

                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                    ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                    ocnAlumnoFamiliar.aluId = aluId2;
                    ocnAlumnoFamiliar.famId = famIdP;
                    ocnAlumnoFamiliar.patId = 1;
                    //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                    ocnAlumnoFamiliar.Insertar();
                    //ocnAlumnoFamiliar.Insertar(aluId2, famIdP, 1, TutorP, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today);
                }
            }

            if (DniMadre.Text != "")
            {
                dt = new DataTable();
                dt = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text.Trim());

                if (dt.Rows.Count > 0)//existe Madre en Familiar
                {
                    int FamIdMadre = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniMadre.Text.Trim());

                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(FamIdMadre);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApeMadre.Text.Trim();
                    ocnFamiliar.famNombre = NomMadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupMadre.Text.Trim();
                    ocnFamiliar.famDni = DniMadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefM.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoM.Text.Trim();
                    ocnFamiliar.famCuit = CuitM.Text.Trim();
                    ocnFamiliar.famMail = MailM.Text.Trim();
                    //ocnFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                    //ocnFamiliar.usuId = usuIdP;

                    ocnFamiliar.Actualizar();

                    //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                    //String claveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    //Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), claveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);

                    if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar);
                        //ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                        ocnAlumnoFamiliar.Actualizar();
                    }
                    else
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = FamIdMadre;
                        ocnAlumnoFamiliar.patId = 2;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                        ocnAlumnoFamiliar.Insertar();
                    }
                }
                else // Inserto Madre en Familiar y en AlumnoFamiliar
                {
                    String claveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    //Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), claveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);
                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(0);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApeMadre.Text.Trim();
                    ocnFamiliar.famNombre = NomMadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupMadre.Text.Trim();
                    ocnFamiliar.famDni = DniMadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefM.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoM.Text.Trim();
                    ocnFamiliar.famCuit = CuitM.Text.Trim();
                    ocnFamiliar.famMail = MailM.Text.Trim();
                    //ocnFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraCreacion = DateTime.Today;
                    //ocnFamiliar.usuId = UsuIdNuevoM;
                    int famIdP = ocnFamiliar.Insertar();

                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                    ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                    ocnAlumnoFamiliar.aluId = aluId2;
                    ocnAlumnoFamiliar.famId = famIdP;
                    ocnAlumnoFamiliar.patId = 2;
                    //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                    ocnAlumnoFamiliar.Insertar();
                }
            }

            if (DniOtro.Text.Trim() != "")
            {
                dt = new DataTable();
                dt = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text.Trim());
                int ParentescoOtro2 = Convert.ToInt32((ParentescoId.SelectedValue.Trim() == "" ? "0" : ParentescoId.SelectedValue));

                if (Convert.ToInt32(ParentescoId.SelectedValue) != 0) //Si no selecciono parentezco..
                {
                    if (dt.Rows.Count > 0) //existe Otro en Familiar
                    {
                        int FamIdOtro = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                        int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniOtro.Text.Trim());

                        ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(FamIdOtro);
                        //int usuIdO = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                        ocnFamiliar.famApellido = ApeOtro.Text.Trim();
                        ocnFamiliar.famNombre = NombOtro.Text.Trim();
                        ocnFamiliar.famOcupacion = OcupOtro.Text.Trim();
                        ocnFamiliar.famDni = DniOtro.Text.Trim();
                        ocnFamiliar.famTelefonoCel = TelefO.Text.Trim();
                        ocnFamiliar.famTelefonoFijo = txtFijoO.Text.Trim();
                        ocnFamiliar.famCuit = CuitO.Text.Trim();
                        ocnFamiliar.famMail = MailO.Text.Trim();
                        //ocnFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                        ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                        //ocnFamiliar.usuId = usuIdO;

                        ocnFamiliar.Actualizar();

                        //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                        //String claveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                        //Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), claveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);

                        if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                        {
                            ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar);
                            //ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                            ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                            ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                            ocnAlumnoFamiliar.Actualizar();
                        }
                        else
                        {
                            ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                            ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                            ocnAlumnoFamiliar.aluId = aluId2;
                            ocnAlumnoFamiliar.famId = FamIdOtro;
                            ocnAlumnoFamiliar.patId = 3;
                            //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                            ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                            ocnAlumnoFamiliar.Insertar();
                        }
                    }
                    else //NO existe Otro en Familiar
                    {
                        String claveO = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                        //Int32 UsuIdNuevoO = ocnUsuario.InsertarTraerId(insId, ApeOtro.Text.Trim(), NombOtro.Text.Trim(), DniOtro.Text.Trim(), claveO, "", false, MailO.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);
                        ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(0);
                        //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                        ocnFamiliar.famApellido = ApeOtro.Text.Trim();
                        ocnFamiliar.famNombre = NombOtro.Text.Trim();
                        ocnFamiliar.famOcupacion = OcupOtro.Text.Trim();
                        ocnFamiliar.famDni = DniOtro.Text.Trim();
                        ocnFamiliar.famTelefonoCel = TelefO.Text.Trim();
                        ocnFamiliar.famTelefonoFijo = txtFijoO.Text.Trim();
                        ocnFamiliar.famCuit = CuitO.Text.Trim();
                        ocnFamiliar.famMail = MailO.Text.Trim();
                        //ocnFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnFamiliar.famFechaHoraCreacion = DateTime.Today;
                        //ocnFamiliar.usuId = UsuIdNuevoO;
                        int famIdo = ocnFamiliar.Insertar();

                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = famIdo;
                        ocnAlumnoFamiliar.patId = 3;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                        ocnAlumnoFamiliar.Insertar();
                    }
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "Debe seleccionar Parentezco";
                    return;
                }
            }

            alerExito.Visible = true;
            lblExito.Text = "Se ingresó con exito el alumno..";
            alerExito.Focus();
            //IdAlu = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
            //Response.Redirect("AlumnoRegistracion.aspx?Id=" + Id, false);
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


    protected void paisId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(paisId.SelectedValue) == 1)
            {
                provinciaId.Enabled = true;
                provinciaId.DataValueField = "Valor"; provinciaId.DataTextField = "Texto"; provinciaId.DataSource = (new GESTIONESCOLAR.Negocio.Provincia()).ObtenerLista("[Seleccionar Texto..]"); provinciaId.DataBind();

            }
            else
            {
                provinciaId.Text = "";
                DepartamentoNac.Text = "";
                LocalidadId.Text = "";
                provinciaId.Enabled = false;
                DepartamentoNac.Enabled = false;
                LocalidadId.Enabled = false;
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
    protected void provinciaId_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            int prov = Convert.ToInt32(provinciaId.SelectedIndex);
            int valor = Convert.ToInt32(provinciaId.SelectedValue);
            DepartamentoNac.Enabled = true;
            DepartamentoNac.Items.Clear();
            DepartamentoNac.DataValueField = "Valor"; DepartamentoNac.DataTextField = "Texto"; DepartamentoNac.DataSource = (new GESTIONESCOLAR.Negocio.Departamento()).ObtenerLista2("[Seleccionar Texto..]", valor); DepartamentoNac.DataBind();
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

    protected void DepartamentoNac_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (provinciaId.Text != "")
            {
                int dep = Convert.ToInt32(DepartamentoNac.SelectedValue);
                int prov = Convert.ToInt32(provinciaId.SelectedValue);
                LocalidadId.Enabled = true;
                LocalidadId.Items.Clear();
                LocalidadId.DataValueField = "Valor"; LocalidadId.DataTextField = "Texto"; LocalidadId.DataSource = (new GESTIONESCOLAR.Negocio.Localidad()).LOCALIDADES_TraeporDeptoId_PciaId("[Seleccionar Texto]", prov, dep); LocalidadId.DataBind();
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

    protected void aluDoc_textChanged(object sender, EventArgs e)
    {
        try
        {
            dt4 = ocnAlumno.ObtenerUnoporDoc(Convert.ToString(aluDoc.Text.Trim()));
            if (dt4.Rows.Count != 0)
            {
                IdAlu = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                Response.Redirect("AlumnoRegistracion.aspx?Id=" + IdAlu, false);
            }
            this.aluNombre.Focus();
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

    protected void DniPadre_TextChanged(object sender, EventArgs e)
    {
        try
        {

            dt5 = ocnFamiliar.ObtenerUnoPorDoc(DniPadre.Text.Trim());

            if (dt5.Rows.Count != 0)
            {
                int UsuIdBuscar = Convert.ToInt32(dt5.Rows[0]["UsuId"].ToString());
                dt2 = ocnUsuario.ObtenerUno(UsuIdBuscar);
                this.ApePadre.Text = dt5.Rows[0]["Apellido"].ToString();
                this.NomPadre.Text = dt5.Rows[0]["Nombre"].ToString();
                this.OcupPadre.Text = dt5.Rows[0]["Ocupacion"].ToString();
                this.DniPadre.Text = dt5.Rows[0]["Doc"].ToString();
                this.TelefP.Text = dt5.Rows[0]["Telefono"].ToString();
                this.txtFijoP.Text = dt5.Rows[0]["TelefonoFijo"].ToString();
                this.CuitP.Text = dt5.Rows[0]["Cuit"].ToString();
                this.MailP.Text = dt5.Rows[0]["Mail"].ToString();
                this.UsuarioP.Text = dt2.Rows[0]["NombreIngreso"].ToString();
                //this.ClaveP.Text = dt2.Rows[0]["NombreIngreso"].ToString();

            }
            this.ApePadre.Focus();
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

    protected void DniMadre_TextChanged(object sender, EventArgs e)
    {
        dt6 = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text.Trim());
        if (dt6.Rows.Count != 0)
        {
            int UsuIdBuscar = Convert.ToInt32(dt6.Rows[0]["UsuId"].ToString());
            dt2 = ocnUsuario.ObtenerUno(UsuIdBuscar);
            this.ApeMadre.Text = dt6.Rows[0]["Apellido"].ToString();
            this.NomMadre.Text = dt6.Rows[0]["Nombre"].ToString();
            this.OcupMadre.Text = dt6.Rows[0]["Ocupacion"].ToString();
            this.DniMadre.Text = dt6.Rows[0]["Doc"].ToString();
            this.TelefM.Text = dt6.Rows[0]["Telefono"].ToString();
            this.txtFijoM.Text = dt6.Rows[0]["TelefonoFijo"].ToString();
            this.CuitM.Text = dt6.Rows[0]["Cuit"].ToString();
            this.MailM.Text = dt6.Rows[0]["Mail"].ToString();
            this.UsuarioM.Text = dt2.Rows[0]["NombreIngreso"].ToString();
            //this.ClaveM.Text = dt2.Rows[0]["Clave"].ToString();


        }
        this.ApeMadre.Focus();
    }

    protected void DniOtro_TextChanged(object sender, EventArgs e)
    {
        dt7 = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text.Trim());
        if (dt7.Rows.Count != 0)
        {
            int UsuIdBuscar = Convert.ToInt32(dt7.Rows[0]["UsuId"].ToString());
            dt2 = ocnUsuario.ObtenerUno(UsuIdBuscar);
            this.ApeOtro.Text = dt7.Rows[0]["Apellido"].ToString();
            this.NombOtro.Text = dt7.Rows[0]["Nombre"].ToString();
            this.OcupOtro.Text = dt7.Rows[0]["Ocupacion"].ToString();
            this.DniOtro.Text = dt7.Rows[0]["Doc"].ToString();
            this.TelefO.Text = dt7.Rows[0]["Telefono"].ToString();
            this.txtFijoO.Text = dt7.Rows[0]["TelefonoFijo"].ToString();
            this.CuitO.Text = dt7.Rows[0]["Cuit"].ToString();
            this.MailO.Text = dt7.Rows[0]["Mail"].ToString();
            this.ParentescoId.SelectedValue = dt7.Rows[0]["ParentescoId"].ToString();
            this.UsuarioO.Text = dt2.Rows[0]["NombreIngreso"].ToString();

        }
        this.ApeOtro.Focus();
    }
}