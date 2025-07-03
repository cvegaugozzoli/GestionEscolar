using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class FamiliarRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.Parentesco ocnParentesco = new GESTIONESCOLAR.Negocio.Parentesco();

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
                this.Master.TituloDelFormulario = " FamiliarRegistracion - Registracion";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                #region PageIndex
                int PageIndex = 0;
                if (this.Session["FamiliarRegistracion.PageIndex"] == null)
                {
                    Session.Add("FamiliarRegistracion.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["FamiliarConsulta.PageIndex"]);
                }
                #endregion
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    ParentescoId.DataValueField = "Valor"; ParentescoId.DataTextField = "Texto"; ParentescoId.DataSource = (new GESTIONESCOLAR.Negocio.Parentesco()).ObtenerLista("[Seleccionar...]");
                    ParentescoId.DataBind(); ParentescoId.SelectedValue = "[Seleccionar...]";

                    aluId.Text = Id.ToString();
                    DataTable dt8 = new DataTable();
                    dt8 = ocnAlumno.ObtenerUno(Id);
                    if (dt8.Rows.Count > 0)
                    {
                        this.Master.TituloDelFormulario = "El Alumno: " + dt8.Rows[0]["Nombre"].ToString() +
                             " tiene los siguientes familiares registrados";
                    }
                }

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                /*INCIALIZADORES*/
                int aluId1 = Convert.ToInt32(Request.QueryString["Id"]);
                DataTable dt = new DataTable();
                ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno(Id);
                dt = ocnAlumnoFamiliar.ObtenerListaFamiliar(Id);
                //ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(Id);
                dt5 = ocnAlumnoFamiliar.ObtenerTodoxaluId(aluId1);
                if (dt5.Rows.Count > 0)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        if (Convert.ToInt32(row["Parentesco"].ToString()) == 1)
                        {
                            this.ApePadre.Text = Convert.ToString((row["Apellido"].ToString()));
                            this.NomPadre.Text = Convert.ToString((row["Nombre"].ToString()));
                            this.OcupPadre.Text = Convert.ToString((row["Ocupacion"].ToString()));
                            this.DniPadre.Text = Convert.ToString((row["Doc"].ToString()));
                            this.TelefP.Text = Convert.ToString((row["Telefono"].ToString()));
                            this.txtFijoP.Text = Convert.ToString((row["TelFijo"].ToString()));
                            this.CuitP.Text = Convert.ToString((row["Cuit"].ToString()));
                            this.MailP.Text = Convert.ToString((row["Mail"].ToString()));
                            if (Convert.ToInt32(row["Tutor"].ToString()) == 1)
                            {
                                EsTutor.SelectedValue = Convert.ToString(1);
                            }

                        }
                        else
                        {
                            if (Convert.ToInt32(row["Parentesco"].ToString()) == 2)
                            {
                                this.ApeMadre.Text = Convert.ToString((row["Apellido"].ToString()));
                                this.NomMadre.Text = Convert.ToString((row["Nombre"].ToString()));
                                this.OcupMadre.Text = Convert.ToString((row["Ocupacion"].ToString()));
                                this.DniMadre.Text = Convert.ToString((row["Doc"].ToString()));
                                this.TelefM.Text = Convert.ToString((row["Telefono"].ToString()));
                                this.txtFijoM.Text = Convert.ToString((row["TelFijo"].ToString()));
                                this.CuitM.Text = Convert.ToString((row["Cuit"].ToString()));
                                this.MailM.Text = Convert.ToString((row["Mail"].ToString()));
                                if (Convert.ToInt32(row["Tutor"].ToString()) == 1)
                                {
                                    EsTutor.SelectedValue = Convert.ToString(0);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(row["Parentesco"].ToString()) == 3)
                                {
                                    this.ApeOtro.Text = Convert.ToString((row["Apellido"].ToString()));
                                    this.NombOtro.Text = Convert.ToString((row["Nombre"].ToString()));
                                    this.OcupOtro.Text = Convert.ToString((row["Ocupacion"].ToString()));
                                    this.DniOtro.Text = Convert.ToString((row["Doc"].ToString()));
                                    this.TelefO.Text = Convert.ToString((row["Telefono"].ToString()));
                                    this.txtFijoO.Text = Convert.ToString((row["TelFijo"].ToString()));
                                    this.CuitO.Text = Convert.ToString((row["Cuit"].ToString()));
                                    this.MailO.Text = Convert.ToString((row["Mail"].ToString()));
                                    this.ParentescoId.SelectedValue = Convert.ToString((row["Parentesco"].ToString()));
                                    if (Convert.ToInt32(row["Tutor"].ToString()) == 1)
                                    {
                                        EsTutor.SelectedValue = Convert.ToString(2);
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
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("FamiliarConsulta.aspx?Id=" + Id);

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
 alerExito.Visible = false;
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            //ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
            //ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
            insId = Convert.ToInt32(Session["_Institucion"]);
         
            dt5 = new DataTable();
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
                    int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(Id, DniPadre.Text.Trim());

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
                        ocnAlumnoFamiliar.aluId = Id;
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
                    ocnAlumnoFamiliar.aluId = Id;
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
                    int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(Id, DniMadre.Text.Trim());

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
                        ocnAlumnoFamiliar.aluId = Id;
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
                    ocnAlumnoFamiliar.aluId = Id;
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
                        int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(Id, DniOtro.Text.Trim());

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
                            ocnAlumnoFamiliar.aluId = Id;
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
                        ocnAlumnoFamiliar.aluId = Id;
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


    protected void DniPadre_TextChanged(object sender, EventArgs e)
    {
        try
        {
            dt5 = ocnFamiliar.ObtenerUnoPorDoc(DniPadre.Text);
            if (dt5.Rows.Count != 0)
            {
                int UsuIdBuscar = Convert.ToInt32(dt5.Rows[0]["UsuId"].ToString());
                dt2 = ocnUsuario.ObtenerUno(UsuIdBuscar);
                this.ApePadre.Text = dt5.Rows[0]["Apellido"].ToString();
                this.NomPadre.Text = dt5.Rows[0]["Nombre"].ToString();
                this.OcupPadre.Text = dt5.Rows[0]["Ocupacion"].ToString();
                this.DniPadre.Text = dt5.Rows[0]["Doc"].ToString();
                this.TelefP.Text = dt5.Rows[0]["Telefono"].ToString();
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
        dt6 = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text);
        if (dt6.Rows.Count != 0)
        {
            int UsuIdBuscar = Convert.ToInt32(dt6.Rows[0]["UsuId"].ToString());
            dt2 = ocnUsuario.ObtenerUno(UsuIdBuscar);
            this.ApeMadre.Text = dt6.Rows[0]["Apellido"].ToString();
            this.NomMadre.Text = dt6.Rows[0]["Nombre"].ToString();
            this.OcupMadre.Text = dt6.Rows[0]["Ocupacion"].ToString();
            this.DniMadre.Text = dt6.Rows[0]["Doc"].ToString();
            this.TelefM.Text = dt6.Rows[0]["Telefono"].ToString();
            this.CuitM.Text = dt6.Rows[0]["Cuit"].ToString();
            this.MailM.Text = dt6.Rows[0]["Mail"].ToString();
            this.UsuarioM.Text = dt2.Rows[0]["NombreIngreso"].ToString();
            //this.ClaveM.Text = dt2.Rows[0]["Clave"].ToString();


        }
        this.ApeMadre.Focus();
    }

    protected void DniOtro_TextChanged(object sender, EventArgs e)
    {
        dt7 = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text);
        if (dt7.Rows.Count != 0)
        {
            int UsuIdBuscar = Convert.ToInt32(dt7.Rows[0]["UsuId"].ToString());
            dt2 = ocnUsuario.ObtenerUno(UsuIdBuscar);
            this.ApeOtro.Text = dt7.Rows[0]["Apellido"].ToString();
            this.NombOtro.Text = dt7.Rows[0]["Nombre"].ToString();
            this.OcupOtro.Text = dt7.Rows[0]["Ocupacion"].ToString();
            this.DniOtro.Text = dt7.Rows[0]["Doc"].ToString();
            this.TelefO.Text = dt7.Rows[0]["Telefono"].ToString();
            this.CuitO.Text = dt7.Rows[0]["Cuit"].ToString();
            this.MailO.Text = dt7.Rows[0]["Mail"].ToString();
            this.ParentescoId.SelectedValue = dt7.Rows[0]["ParentescoId"].ToString();
            this.UsuarioO.Text = dt2.Rows[0]["NombreIngreso"].ToString();
            //this.ClaveO.Text = dt2.Rows[2]["Clave"].ToString();
        }
        this.ApeOtro.Focus();
    }
}
