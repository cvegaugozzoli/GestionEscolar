using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PagosTransferenciaElectronicaRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Pagos Transferencia Electronica - Registracion";

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
						ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica(Id);
						this.pteImporte.Text = FuncionesUtiles.DecimalToString(ocnPagosTransferenciaElectronica.pteImporte);
						this.pteNroCuenta.Text = ocnPagosTransferenciaElectronica.pteNroCuenta;
						this.pteActivo.Checked = ocnPagosTransferenciaElectronica.pteActivo;
						this.cfpId.SelectedValue = (ocnPagosTransferenciaElectronica.cfpId == 0 ? "" : ocnPagosTransferenciaElectronica.cfpId.ToString());
						this.banId.SelectedValue = (ocnPagosTransferenciaElectronica.banId == 0 ? "" : ocnPagosTransferenciaElectronica.banId.ToString());

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
            Response.Redirect("PagosTransferenciaElectronicaConsulta.aspx", true);
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
			    ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica(Id);

			    ocnPagosTransferenciaElectronica.pteImporte = FuncionesUtiles.StringToDecimal(pteImporte.Text); 
			    ocnPagosTransferenciaElectronica.pteNroCuenta = pteNroCuenta.Text; 
			    ocnPagosTransferenciaElectronica.pteActivo = pteActivo.Checked; 

				ocnPagosTransferenciaElectronica.cfpId = Convert.ToInt32((cfpId.SelectedValue.Trim() == "" ? "0" : cfpId.SelectedValue)); 
				ocnPagosTransferenciaElectronica.banId = Convert.ToInt32((banId.SelectedValue.Trim() == "" ? "0" : banId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnPagosTransferenciaElectronica.pteFechaHoraCreacion = DateTime.Now;
				ocnPagosTransferenciaElectronica.pteFechaHoraUltimaModificacion = DateTime.Now;
				ocnPagosTransferenciaElectronica.usuIdCreacion = this.Master.usuId;
				ocnPagosTransferenciaElectronica.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnPagosTransferenciaElectronica.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnPagosTransferenciaElectronica.pteFechaHoraUltimaModificacion = DateTime.Now;
				        ocnPagosTransferenciaElectronica.usuidUltimaModificacion = this.Master.usuId;
					    ocnPagosTransferenciaElectronica.Actualizar();
				    }
					
				    Response.Redirect("PagosTransferenciaElectronicaConsulta.aspx", true);
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