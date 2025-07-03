using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PagosChequesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.PagosCheques ocnPagosCheques = new GESTIONESCOLAR.Negocio.PagosCheques();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Pagos Cheques - Registracion";

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
					banId.DataValueField = "Valor"; banId.DataTextField = "Texto"; banId.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); banId.DataBind();

					if (Id != 0)
                    {
						ocnPagosCheques = new GESTIONESCOLAR.Negocio.PagosCheques(Id);
						this.pchImporte.Text = FuncionesUtiles.DecimalToString(ocnPagosCheques.pchImporte);
						this.pchChequeNro.Text = ocnPagosCheques.pchChequeNro;
						this.pchActivo.Checked = ocnPagosCheques.pchActivo;
						this.cfpId.SelectedValue = (ocnPagosCheques.cfpId == 0 ? "" : ocnPagosCheques.cfpId.ToString());
						this.banId.SelectedValue = (ocnPagosCheques.banId == 0 ? "" : ocnPagosCheques.banId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.cfpId.Focus();
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
            Response.Redirect("PagosChequesConsulta.aspx", true);
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
			    ocnPagosCheques = new GESTIONESCOLAR.Negocio.PagosCheques(Id);

			    ocnPagosCheques.pchImporte = FuncionesUtiles.StringToDecimal(pchImporte.Text); 
			    ocnPagosCheques.pchChequeNro = pchChequeNro.Text; 
			    ocnPagosCheques.pchActivo = pchActivo.Checked; 

				ocnPagosCheques.cfpId = Convert.ToInt32((cfpId.SelectedValue.Trim() == "" ? "0" : cfpId.SelectedValue)); 
				ocnPagosCheques.banId = Convert.ToInt32((banId.SelectedValue.Trim() == "" ? "0" : banId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnPagosCheques.pchFechaHoraCreacion = DateTime.Now;
				ocnPagosCheques.pchFechaHoraUltimaModificacion = DateTime.Now;
				ocnPagosCheques.usuIdCreacion = this.Master.usuId;
				ocnPagosCheques.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnPagosCheques.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnPagosCheques.pchFechaHoraUltimaModificacion = DateTime.Now;
				        ocnPagosCheques.usuidUltimaModificacion = this.Master.usuId;
					    ocnPagosCheques.Actualizar();
				    }
					
				    Response.Redirect("PagosChequesConsulta.aspx", true);
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