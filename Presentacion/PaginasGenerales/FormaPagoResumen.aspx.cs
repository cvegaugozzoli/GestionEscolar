using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class FormaPagoResumen : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                           
                if (Request.QueryString["NroCompbte"] != null)
                {
                    lblNombre.Text = Convert.ToString(Request.QueryString["Nombre"]);
                    lblFchPago.Text = Convert.ToString(Request.QueryString["FchPago"]);
                    lblComprobante.Text = Convert.ToString(Request.QueryString["NroCompbte"]);
                    lblContado.Text = Convert.ToString(Request.QueryString["Contado"]);
                    lblTarjeta.Text = Convert.ToString(Request.QueryString["Tarjeta"]);
                    lblCheque.Text = Convert.ToString(Request.QueryString["Cheque"]);
                    lblTranfElec.Text = Convert.ToString(Request.QueryString["TranfElec"]);
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

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("CuentaCorriente.aspx", true);
    }
}