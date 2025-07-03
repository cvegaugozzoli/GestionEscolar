using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class EditarInformacion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario - Editar Información";
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                dt = ocnUsuario.ObtenerUno(usuario);


                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

             
                if (dt.Rows.Count != 0)
                {
                

                    /*INCIALIZADORES*/
                    perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); perId.DataBind();

                       ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(usuario);
                        this.usuApellido.Text = ocnUsuario.usuApellido;
                        this.usuNombre.Text = ocnUsuario.usuNombre;
                        this.usuNombreIngreso.Text = ocnUsuario.usuNombreIngreso;
                        this.usuEmail.Text = ocnUsuario.usuEmail;                 
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int usuario = Convert.ToInt32(Session["_usuId"].ToString());
          
                ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(usuario);

                ocnUsuario.usuApellido = usuApellido.Text;
                ocnUsuario.usuNombre = usuNombre.Text;
                ocnUsuario.usuNombreIngreso = usuNombreIngreso.Text;
                ocnUsuario.usuClaveProvisoria = "";
                ocnUsuario.usuCambiarClave = false;
                ocnUsuario.usuEmail = usuEmail.Text;
             

                //ocnUsuario.perId = Convert.ToInt32((perId.SelectedValue.Trim() == "" ? "0" : perId.SelectedValue));
                /*....usuId = this.Master.usuId;*/


                ocnUsuario.usuFechaHoraCreacion = DateTime.Now;
                ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                ocnUsuario.usuIdCreacion = this.Master.usuId;
                ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (usuEmail.Text.Trim().Length == 0)
                {
                    MensajeValidacion += "<br>* Email. Requerido";
                    usuEmail.Focus();
                }

                if (MensajeValidacion.Trim().Length == 0)
                {
                  
                        //Editar
                        ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                        ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;
                        ocnUsuario.Actualizar();
                   

                    //Response.Redirect("EditarInformacion.aspx", true);
                lblMej.Text = "Datos Actualizados";
               }
                else
                {
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
}