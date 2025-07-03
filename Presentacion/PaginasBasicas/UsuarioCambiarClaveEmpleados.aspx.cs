using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioCambiarClaveEmpleados : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario - Cambiar Clave";

                if (this.Master.CambiarClave)
                {
                    /*SIGNIFICA QUE LA CLAVE ACTUAL ES 1*/
                    this.ClaveActual.Visible = false;
                    this.ClaveNueva.Focus();
                }
                else
                {
                    this.ClaveActual.Visible = true;
                    this.ClaveActual.Focus();
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
            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(this.Master.usuId);
            string sClaveActual = GESTIONESCOLAR.Datos.Utiles.GetHash(ClaveActual.Text.Trim());

            /*Validaciones*/
            string MensajeValidacion = "";

            if (ClaveActual.Visible)
            {
                if (sClaveActual != ocnUsuario.usuClave)
                {
                    MensajeValidacion += "<br>* Clave Actual. Incorrecta !!!";
                    ClaveActual.Focus();
                }
            }

            if (MensajeValidacion.Trim().Length == 0)
            {
                string sClaveNueva = GESTIONESCOLAR.Negocio.Seguridad.EncriptarClave(RepitaClave.Text.Trim());
                ocnUsuario.CambiarClave(this.Master.usuId, sClaveNueva);

                Response.Redirect("CerrarSesionEmpleados.aspx", true);
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error</a><br/>" + MensajeValidacion + "</div>";
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