using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;



public partial class ContactoSanJose : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        alerMail.Visible = false;
    }


    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlNivel.SelectedValue) == -1)
            {
                lblMensajeError.Text = "Debe seleccionar un nivel";
                return;
            }
            
            if (txtNombre.Text == "")
            {
                lblMensajeError.Text = "Debe completar Nombre y Apellido";
                return;
            }
            if (txtMail.Text == "")
            {
                lblMensajeError.Text = "Debe ingresar un mail";
                return;
            }
            if (txtAsunto.Text == "")
            {
                lblMensajeError.Text = "Debe ingresar un Asunto";
                return;
            }
            if (txtMje.Text == "")
            {
                lblMensajeError.Text = "Debe ingresar un Mensaje";
                return;
            }

            GESTIONESCOLAR.Negocio.Email Cr = new GESTIONESCOLAR.Negocio.Email();
            lblMensajeError.Text = "";
            MailMessage mnsj = new MailMessage();
            mnsj.From = new MailAddress(txtMail.Text);
            mnsj.Subject = "Mensaje Web";

            if (Convert.ToInt32(ddlNivel.SelectedValue) == 1)
            {
                mnsj.To.Add(new MailAddress("secretariaprimaria@sanjosesgo.edu.ar"));
            }
            else
            {
                if (Convert.ToInt32(ddlNivel.SelectedValue) == 2)
                {
                    mnsj.To.Add(new MailAddress("secretariasecundaria@sanjosesgo.edu.ar"));
                }
                else
                {
                    if (Convert.ToInt32(ddlNivel.SelectedValue) == 3)
                    {
                        mnsj.To.Add(new MailAddress("secretariasuperior@sanjosesgo.edu.ar"));
                    }
                }
            }


            //mnsj.Attachments.Add(new Attachment(@"..\Boletin\boletindeldia.pdf"));
            mnsj.Body += "Nombre: " + txtNombre.Text + Environment.NewLine;
            mnsj.Body += "Mail: " + txtMail.Text + Environment.NewLine;
            mnsj.Body += "Asunto: " + txtAsunto.Text + Environment.NewLine;
            mnsj.Body += "Mensaje: " + txtMje.Text + Environment.NewLine;


            /* Enviar */
            Cr.MandarCorreo(mnsj);

            /* Limpiar y Mensaje confirmación */
            txtNombre.Text = "";
            txtMje.Text = "";
            txtMail.Text = "";
            txtAsunto.Text = "";
            lblMensajeError.Visible = true;
            alerMail.Visible = true;
        }
        catch (Exception oError)
        {
            lblMensajeError.Visible = true;
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                                   <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                                                                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                                                                Se ha producido el siguiente error:<br/>
                                                                MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
            //lblMensajeError.Text = ("El Boletín no se pudo enviar, revise datos");
        }

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index1.aspx", false);
    }
}