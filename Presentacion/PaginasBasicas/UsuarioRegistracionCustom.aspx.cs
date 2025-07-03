using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioRegistracionCustom : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.UsuarioPerfil ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil();


    Int32 insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Int32 PerfUsuarioIngresante = Convert.ToInt32(Session["_perId"]);

                this.Master.TituloDelFormulario = " Usuario - Registracion";

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    int perIdTraer = Convert.ToInt32(Request.QueryString["perId"]);
                    /*INCIALIZADORES*/
                    perId.DataValueField = "Valor";
                    perId.DataTextField = "Texto";
                    perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]");
                    perId.DataBind();

                    if (perIdTraer != 0)
                    {
                        perId.SelectedValue = Convert.ToString(perIdTraer);
                    }
                    if (Id != 0)
                    {
                        ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);
                        this.usuApellido.Text = ocnUsuario.usuApellido;
                        this.usuNombre.Text = ocnUsuario.usuNombre;
                        this.usuDNI.Text = ocnUsuario.usuNombreIngreso;
                        this.usuDireccion.Text = ocnUsuario.usuDireccion;
                        this.usuCuit.Text = ocnUsuario.usuCuit;
                        this.usuTelefono.Text = ocnUsuario.usuTelefono;
                        this.usuEmail.Text = ocnUsuario.usuEmail;
                        this.usuActivo.Checked = ocnUsuario.usuActivo;
                        this.usuRecibo.Checked = false;
                        if (ocnUsuario.usuRecibo == 1)
                        {
                            this.usuRecibo.Checked = true;
                        }
                        perId.Enabled = false;
                        if (PerfUsuarioIngresante == 1 || PerfUsuarioIngresante == 15)
                        {
                            //perId.SelectedIndex = 0;
                            perId.Enabled = true;
                        }
                        else
                        {
                            //perId.Enabled = true;
                        }



                        //if (usuRecibo.Checked == true)
                        //{
                        //    //perId.SelectedIndex = 0;
                        //    perId.Enabled = false;
                        //}
                        //else
                        //{
                        //    //perId.Enabled = true;
                        //}

                        /*Editar Habilitado*/
                    }
                    else
                    {
                        perId.Enabled = false;
                        if (PerfUsuarioIngresante == 1 || PerfUsuarioIngresante == 15)
                        {
                            //perId.SelectedIndex = 0;
                            perId.Enabled = true;
                        }
                        else
                        {
                            //perId.Enabled = true;
                        }

                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.usuDNI.Focus();
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
            Response.Redirect("UsuarioConsultaCustom.aspx", true);
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
            if (usuDNI.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Dni..";
                return;
            }
            if (usuApellido.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Apellido..";
                return;
            }
            if (usuNombre.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nombre..";
                return;
            }

            int per_id = 0;
            if (perId.SelectedValue == "0")
            {
              
            }
            else
            {
                per_id = Convert.ToInt32(perId.SelectedValue.ToString().ToString());
            }

            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            if (Id == 0)
            {
                DataTable dtUsuarioVer = new DataTable();
                dtUsuarioVer = ocnUsuario.ObtenerUnoxDNI(usuDNI.Text);

                if (dtUsuarioVer.Rows.Count == 0)//No existe Docente en  Usuario 
                {
                    int perfil = Convert.ToInt32(perId.SelectedValue.Trim());


                    ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);

                    ocnUsuario.usuApellido = usuApellido.Text;
                    ocnUsuario.usuNombre = usuNombre.Text;
                    ocnUsuario.usuNombreIngreso = usuDNI.Text;
                    ocnUsuario.usuClaveProvisoria = "";
                    ocnUsuario.usuCambiarClave = false;
                    ocnUsuario.usuEmail = usuEmail.Text;
                    ocnUsuario.usuActivo = true;
                    ocnUsuario.usuNivId = 0;
                    ocnUsuario.usuDireccion = usuDireccion.Text;
                    ocnUsuario.usuDni = usuDNI.Text;
                    ocnUsuario.usuCuit = usuCuit.Text;
                    ocnUsuario.usuTelefono = usuTelefono.Text;
                    ocnUsuario.usuRecibo = (usuRecibo.Checked == true ? 1 : 0);

                    ocnUsuario.usuFechaHoraCreacion = DateTime.Now;
                    ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                    ocnUsuario.usuIdCreacion = this.Master.usuId;
                    ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;
                    ocnUsuario.usuClave = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    int usuIdNew = ocnUsuario.Insertar();

                    Id = 0;
                    if (per_id != 0)
                    {
                        ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil(Id);
                        ocnUsuarioPerfil.perId = perfil;
                        ocnUsuarioPerfil.insId = insId;
                        ocnUsuarioPerfil.upeActivo = true;
                        ocnUsuarioPerfil.usuId = usuIdNew;
                        ocnUsuarioPerfil.upeFechaHoraCreacion = DateTime.Now;
                        ocnUsuarioPerfil.upeFechaHoraUltimaModificacion = DateTime.Now;
                        ocnUsuarioPerfil.usuIdCreacion = this.Master.usuId;
                        ocnUsuarioPerfil.usuIdUltimaModificacion = this.Master.usuId;
                        int upeIdNew = ocnUsuarioPerfil.Insertar();
                    }


                    Response.Redirect("UsuarioConsultaCustom.aspx", true);
                    return;
                }
                else
                {
                    //Editar
                    DataTable dt = new DataTable();
                    dt = ocnUsuario.ObtenerUnoxDNI(usuDNI.Text);

                    Int32 IdTraer = Convert.ToInt32(dt.Rows[0]["Id"]);

                    ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(IdTraer);
                    ocnUsuario.usuApellido = usuApellido.Text;
                    ocnUsuario.usuNombre = usuNombre.Text;
                    ocnUsuario.usuNombreIngreso = usuDNI.Text;
                    ocnUsuario.usuEmail = usuEmail.Text;
                    ocnUsuario.usuActivo = true;

                    ocnUsuario.usuDireccion = usuDireccion.Text;
                    ocnUsuario.usuDni = usuDNI.Text;
                    ocnUsuario.usuCuit = usuCuit.Text;
                    ocnUsuario.usuTelefono = usuTelefono.Text;
                    ocnUsuario.usuRecibo = (usuRecibo.Checked == true ? 1 : 0);
                    ocnUsuario.usuIdCreacion = this.Master.usuId;
                    ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;

                    ocnUsuario.Actualizar();


                    //dt = ocnUsuario.ObtenerTodoBuscarxdocId(Convert.ToInt32(Request.QueryString["Id"]));

                    Int32 PerfUsuarioIngresante = Convert.ToInt32(Session["_perId"]);

                    if (PerfUsuarioIngresante == 1 || PerfUsuarioIngresante == 15)
                    {
                        //perId.SelectedIndex = 0;
                        perId.Enabled = true;
                        if (per_id != 0)
                        {
                            dt = ocnUsuario.ObtenerUnoxDNI(usuDNI.Text);
                            if (dt.Rows.Count > 0)
                            {
                                DataTable dt1 = new DataTable();
                                dt1 = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dt.Rows[0]["Id"]), Convert.ToInt32(perId.SelectedValue));

                                if (dt1.Rows.Count > 0)
                                {
                                    // ya existe ese docente con ese perfil
                                    alerError.Visible = true;
                                    lblError.Text = "El usuario ya existe con ese perfil..";
                                    return;
                                }
                                else
                                {
                                    Id = 0;
                                    ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil(Id);
                                    ocnUsuarioPerfil.perId = Convert.ToInt32(perId.SelectedValue);
                                    ocnUsuarioPerfil.insId = insId;
                                    ocnUsuarioPerfil.upeActivo = true;
                                    ocnUsuarioPerfil.usuId = Convert.ToInt32(dt.Rows[0]["Id"]);
                                    ocnUsuarioPerfil.upeFechaHoraCreacion = DateTime.Now;
                                    ocnUsuarioPerfil.upeFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnUsuarioPerfil.usuIdCreacion = this.Master.usuId;
                                    ocnUsuarioPerfil.usuIdUltimaModificacion = this.Master.usuId;
                                    int upeIdNew = ocnUsuarioPerfil.Insertar();


                                    Response.Redirect("UsuarioConsultaCustom.aspx", true);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ////Editar
                ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);
                ocnUsuario.usuApellido = usuApellido.Text;
                ocnUsuario.usuNombre = usuNombre.Text;
                ocnUsuario.usuNombreIngreso = usuDNI.Text;
                ocnUsuario.usuEmail = usuEmail.Text;
                ocnUsuario.usuActivo = true;

                ocnUsuario.usuDireccion = usuDireccion.Text;
                ocnUsuario.usuDni = usuDNI.Text;
                ocnUsuario.usuCuit = usuCuit.Text;
                ocnUsuario.usuTelefono = usuTelefono.Text;
                ocnUsuario.usuRecibo = (usuRecibo.Checked == true ? 1 : 0);
                ocnUsuario.usuIdCreacion = this.Master.usuId;
                ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;

                ocnUsuario.Actualizar();

                DataTable dt = new DataTable();
                dt = ocnUsuario.ObtenerUnoxDNI(usuDNI.Text);
                //dt = ocnUsuario.ObtenerTodoBuscarxdocId(Convert.ToInt32(Request.QueryString["Id"]));

                if (dt.Rows.Count > 0)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dt.Rows[0]["Id"]), Convert.ToInt32(perId.SelectedValue));

                    if (dt1.Rows.Count > 0)
                    {
                        // ya existe ese docente con ese perfil
                        alerError.Visible = true;
                        lblError.Text = "Ya existe ese Usuario con ese perfil..";
                        return;
                    }
                    else
                    {
                        Id = 0;
                        ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil(Id);
                        ocnUsuarioPerfil.perId = Convert.ToInt32(perId.SelectedValue);
                        ocnUsuarioPerfil.insId = insId;
                        ocnUsuarioPerfil.upeActivo = true;
                        ocnUsuarioPerfil.usuId = Convert.ToInt32(dt.Rows[0]["Id"]);
                        ocnUsuarioPerfil.upeFechaHoraCreacion = DateTime.Now;
                        ocnUsuarioPerfil.upeFechaHoraUltimaModificacion = DateTime.Now;
                        ocnUsuarioPerfil.usuIdCreacion = this.Master.usuId;
                        ocnUsuarioPerfil.usuIdUltimaModificacion = this.Master.usuId;
                        int upeIdNew = ocnUsuarioPerfil.Insertar();

                        Response.Redirect("UsuarioConsultaCustom.aspx", true);
                    }
                }
                else
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


    protected void usuRecibo_CheckedChanged(object sender, EventArgs e)
    {
        if (usuRecibo.Checked == true)
        {
            //perId.SelectedIndex = 0;
            perId.Enabled = false;
        }
        else
        {
            //perId.Enabled = true;
        }
    }

    static string EliminarPuntos(string dni)
    {
        return dni.Replace(".", "");
    }

    protected void usuDNI_TextChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        if (usuDNI.Text == "")
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar un Dni..";
            return;
        }

        string dniSinPuntos = EliminarPuntos(usuDNI.Text);

        DataTable dt5 = ocnUsuario.ObtenerUnoxDNI(dniSinPuntos);

        if (dt5.Rows.Count == 0)//No existe Docente en  Usuario 
        {

        }
        else
        {
            Int32 IdUsuario = Convert.ToInt32(dt5.Rows[0]["Id"]);
            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(IdUsuario);
            this.usuDNI.Text = dniSinPuntos;
            this.usuNombre.Text = ocnUsuario.usuNombre;
            this.usuApellido.Text = ocnUsuario.usuApellido;
            this.usuDireccion.Text = ocnUsuario.usuDireccion;
            this.usuTelefono.Text = ocnUsuario.usuTelefono;
            this.usuEmail.Text = ocnUsuario.usuEmail;
            this.usuCuit.Text = ocnUsuario.usuCuit;
            this.usuActivo.Checked = ocnUsuario.usuActivo;
            if (ocnUsuario.usuRecibo == 1)
            {
                this.usuRecibo.Checked = true;
            }

            btnAceptar1.Enabled = true;
        }
    }
}