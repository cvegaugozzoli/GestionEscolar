using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class DocentesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Docentes ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.Perfil ocnPerfil = new GESTIONESCOLAR.Negocio.Perfil();
    GESTIONESCOLAR.Negocio.UsuarioPerfil ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil();

    int insId;
    DataTable dt5 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Docentes - Perfil";


                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {

                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {

                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerListaDocente("[Seleccionar...]"); perId.DataBind();

                    /*INCIALIZADORES*/

                    if (Id != 0)
                    {
                        ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);
                        this.doc_doc.Text = ocnUsuario.usuDni;
                        this.doc_nombre.Text = ocnUsuario.usuNombre;
                        this.doc_apellido.Text = ocnUsuario.usuApellido;
                        this.doc_domicilio.Text = ocnUsuario.usuDireccion;
                        this.doc_telef.Text = ocnUsuario.usuTelefono;
                        this.doc_mail.Text = ocnUsuario.usuEmail;
                        this.doc_cuit.Text = ocnUsuario.usuCuit;
                        this.perId.SelectedValue = Convert.ToString(Request.QueryString["perId"]); ;
                    }
                    else
                    {
                        /*Nuevo Habilitado*/
                        /*cLoadNuevoCustom*/
                    }
                    //this.doc_doc.Focus();
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
            Response.Redirect("DocentesConsulta.aspx", true);
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
            if (doc_doc.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Dni..";
                return;
            }
            if (doc_apellido.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Apellido..";
                return;
            }
            if (doc_nombre.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nombre..";
                return;
            }           
          
            //if (doc_domicilio.Text == "")
            //{
            //    alerError.Visible = true;
            //    lblError.Text = "Debe ingresar un Domicilio..";
            //    return;
            //}
            //if (doc_telef.Text == "")
            //{
            //    alerError.Visible = true;
            //    lblError.Text = "Debe ingresar un Telefono..";
            //    return;
            //}
        
            if (perId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Perfil..";
                return;
            }

            int Id = 0;

            insId = Convert.ToInt32(Session["_Institucion"]);
            Id = Convert.ToInt32(Request.QueryString["Id"]);
            alerError.Visible = false;
            /*Validaciones*/
            string MensajeValidacion = "";

            if (MensajeValidacion.Trim().Length == 0)
            {
                if (Id == 0)
                {
                    dt5 = ocnUsuario.ObtenerUnoxDNI(doc_doc.Text);

                    if (dt5.Rows.Count == 0)//No existe Docente en  Usuario 
                    {                      
                        alerError.Visible = true;
                        lblError.Text = "El docente debe ser ingresado por Administración para luego asignarle un perfil..";
                        btnAceptar1.Enabled = false;
                        return;
                    }
                    else
                    {
                        // Si existe Docente Tengo que ver si esta con ese perfil
                        
                        DataTable dt = new DataTable();
                        dt = ocnUsuario.ObtenerUnoxDNI(doc_doc.Text);
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                        if (dt.Rows.Count > 0)
                        {
                            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);
                            ocnUsuario.usuApellido = doc_apellido.Text;
                            ocnUsuario.usuNombre = doc_nombre.Text;
                            //ocnUsuario.usuNombreIngreso = doc_doc.Text;
                            ocnUsuario.usuDni = doc_doc.Text;
                            //ocnUsuario.usuClave = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                            ocnUsuario.usuEmail = doc_mail.Text;
                            ocnUsuario.usuClaveProvisoria = "";
                            ocnUsuario.usuCambiarClave = false;
                            ocnUsuario.usuActivo = true;
                            //ocnUsuario.usuRecibo = 0;
                            ocnUsuario.usuDireccion = doc_domicilio.Text;
                            ocnUsuario.usuCuit = doc_cuit.Text;
                            ocnUsuario.usuTelefono = doc_telef.Text;
                            //ocnUsuario.usuNivId = 0;
                            ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                            ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;
                            ocnUsuario.Actualizar();

                            DataTable dt1 = new DataTable();
                            dt1 = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dt.Rows[0]["Id"]), Convert.ToInt32(perId.SelectedValue));

                            if (dt1.Rows.Count > 0)
                            {
                                // ya existe ese docente con ese perfil
                                alerError.Visible = true;
                                lblError.Text = "Ya existe Docente con ese perfil..";
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
                            }

                        }
                    }
                }
                // Existe Docente.. 
                else
                {
                    ////Editar
                    ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);
                    ocnUsuario.usuApellido = doc_apellido.Text;
                    ocnUsuario.usuNombre = doc_nombre.Text;
                    ocnUsuario.usuNombreIngreso = doc_doc.Text;
                    ocnUsuario.usuDni = doc_doc.Text;
                    //ocnUsuario.usuClave = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    ocnUsuario.usuEmail = doc_mail.Text;
                    ocnUsuario.usuClaveProvisoria = "";
                    ocnUsuario.usuCambiarClave = false;
                    ocnUsuario.usuActivo = true;

                    ocnUsuario.usuRecibo = 0;
                    ocnUsuario.usuDireccion = doc_domicilio.Text;
                    ocnUsuario.usuCuit = doc_cuit.Text;
                    ocnUsuario.usuTelefono = doc_telef.Text;
                    ocnUsuario.usuNivId = 0;

                    ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                    ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;
                    ocnUsuario.Actualizar();

                    DataTable dt = new DataTable();
                    dt = ocnUsuario.ObtenerUnoxDNI(doc_doc.Text);
                    //dt = ocnUsuario.ObtenerTodoBuscarxdocId(Convert.ToInt32(Request.QueryString["Id"]));

                    if (dt.Rows.Count > 0)
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dt.Rows[0]["Id"]), Convert.ToInt32(perId.SelectedValue));

                        if (dt1.Rows.Count > 0)
                        {
                            // ya existe ese docente con ese perfil
                            alerError.Visible = true;
                            lblError.Text = "Ya existe Docente con ese perfil..";
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
                        }
                    }
                }

                Response.Redirect("DocentesConsulta.aspx", true);
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



    static string EliminarPuntos(string dni)
    {
        return dni.Replace(".", "");
    }

    protected void doc_doc_TextChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        if (doc_doc.Text == "")
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar un Dni..";          
            return;
        }

        string dniSinPuntos = EliminarPuntos(doc_doc.Text);

        dt5 = ocnUsuario.ObtenerUnoxDNI(dniSinPuntos);

        if (dt5.Rows.Count == 0)//No existe Docente en  Usuario 
        {
            alerError.Visible = true;
            lblError.Text = "El docente debe ser ingresado por Administración para luego asignarle un perfil..";
            btnAceptar1.Enabled = false;
            return;
        }
        else
        {

            Int32 IdUsuario = Convert.ToInt32(dt5.Rows[0]["Id"]);
            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(IdUsuario);
            this.doc_doc.Text = dniSinPuntos;
            this.doc_nombre.Text = ocnUsuario.usuNombre;
            this.doc_apellido.Text = ocnUsuario.usuApellido;
            this.doc_domicilio.Text = ocnUsuario.usuDireccion;
            this.doc_telef.Text = ocnUsuario.usuTelefono;
            this.doc_mail.Text = ocnUsuario.usuEmail;
            this.doc_cuit.Text = ocnUsuario.usuCuit;
            btnAceptar1.Enabled = true;
        }
    }
}