using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario - Registracion";

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
                    perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); perId.DataBind();

                    if (Id != 0)
                    {
                        ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);
                        this.usuApellido.Text = ocnUsuario.usuApellido;
                        this.usuNombre.Text = ocnUsuario.usuNombre;
                        this.usuNombreIngreso.Text = ocnUsuario.usuNombreIngreso;
                        this.usuClave.Text = ocnUsuario.usuClave;
                        this.usuClaveProvisoria.Text = ocnUsuario.usuClaveProvisoria;
                        this.usuCambiarClave.Checked = ocnUsuario.usuCambiarClave;
                        this.usuEmail.Text = ocnUsuario.usuEmail;
                        this.usuActivo.Checked = ocnUsuario.usuActivo;
                        //this.perId.SelectedValue = (ocnUsuario.perId == 0 ? "" : ocnUsuario.perId.ToString());

                        /*Editar Habilitado*/
                    }
                    else
                    {
                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.usuApellido.Focus();
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
            Response.Redirect("UsuarioConsulta.aspx", true);
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
            int Id = 0;
            if (Request.QueryString["Id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Id);

                ocnUsuario.usuApellido = usuApellido.Text;
                ocnUsuario.usuNombre = usuNombre.Text;
                ocnUsuario.usuNombreIngreso = usuNombreIngreso.Text;
                ocnUsuario.usuClave = usuClave.Text;
                ocnUsuario.usuClaveProvisoria = usuClaveProvisoria.Text;
                ocnUsuario.usuCambiarClave = usuCambiarClave.Checked;
                ocnUsuario.usuEmail = usuEmail.Text;
                ocnUsuario.usuActivo = usuActivo.Checked;

                //ocnUsuario.perId = Convert.ToInt32((perId.SelectedValue.Trim() == "" ? "0" : perId.SelectedValue));
                /*....usuId = this.Master.usuId;*/


                ocnUsuario.usuFechaHoraCreacion = DateTime.Now;
                ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                ocnUsuario.usuIdCreacion = this.Master.usuId;
                ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (perId.SelectedValue.Trim() != "")
                    {
                        if (Id == 0)
                        {
                            //Nuevo
                            ocnUsuario.Insertar();
                        }
                        else
                        {
                            //Editar
                            ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                            ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;
                            ocnUsuario.Actualizar();
                        }
                        Response.Redirect("UsuarioConsulta.aspx", true);
                    }
                    else
                    {
                        Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                        lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Carga</a><br/>
        Debe seleccionar un Perfil..<br/>" + "</div>";
                        return;
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
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }
}