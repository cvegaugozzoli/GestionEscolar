using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PagosTarjetasRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.PagosTarjetas ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Pagos Tarjetas - Registracion";

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
					tarId.DataValueField = "Valor"; tarId.DataTextField = "Texto"; tarId.DataSource = (new GESTIONESCOLAR.Negocio.Tarjetas()).ObtenerLista("[Seleccionar...]"); tarId.DataBind();
					tapId.DataValueField = "Valor"; tapId.DataTextField = "Texto"; tapId.DataSource = (new GESTIONESCOLAR.Negocio.TarjetasPlanes()).ObtenerLista("[Seleccionar...]"); tapId.DataBind();

					if (Id != 0)
                    {
						ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas(Id);
						this.patInteresPorcMensual.Text = FuncionesUtiles.DecimalToString(ocnPagosTarjetas.patInteresPorcMensual);
						this.patImporteCuota.Text = FuncionesUtiles.DecimalToString(ocnPagosTarjetas.patImporteCuota);
						this.patCantCuotas.Text = ocnPagosTarjetas.patCantCuotas.ToString();
						this.patNroCupon.Text = ocnPagosTarjetas.patNroCupon;
						this.patActivo.Checked = ocnPagosTarjetas.patActivo;
						this.cfpId.SelectedValue = (ocnPagosTarjetas.cfpId == 0 ? "" : ocnPagosTarjetas.cfpId.ToString());
						this.tarId.SelectedValue = (ocnPagosTarjetas.tarId == 0 ? "" : ocnPagosTarjetas.tarId.ToString());
						this.tapId.SelectedValue = (ocnPagosTarjetas.tapId == 0 ? "" : ocnPagosTarjetas.tapId.ToString());

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
            Response.Redirect("PagosTarjetasConsulta.aspx", true);
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
			    ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas(Id);

			    ocnPagosTarjetas.patInteresPorcMensual = FuncionesUtiles.StringToDecimal(patInteresPorcMensual.Text); 
			    ocnPagosTarjetas.patImporteCuota = FuncionesUtiles.StringToDecimal(patImporteCuota.Text); 
			    ocnPagosTarjetas.patCantCuotas = Convert.ToInt32(patCantCuotas.Text); 
			    ocnPagosTarjetas.patNroCupon = patNroCupon.Text; 
			    ocnPagosTarjetas.patActivo = patActivo.Checked; 

				ocnPagosTarjetas.cfpId = Convert.ToInt32((cfpId.SelectedValue.Trim() == "" ? "0" : cfpId.SelectedValue)); 
				ocnPagosTarjetas.tarId = Convert.ToInt32((tarId.SelectedValue.Trim() == "" ? "0" : tarId.SelectedValue)); 
				ocnPagosTarjetas.tapId = Convert.ToInt32((tapId.SelectedValue.Trim() == "" ? "0" : tapId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnPagosTarjetas.patFechaHoraCreacion = DateTime.Now;
				ocnPagosTarjetas.patFechaHoraUltimaModificacion = DateTime.Now;
				ocnPagosTarjetas.usuIdCreacion = this.Master.usuId;
				ocnPagosTarjetas.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnPagosTarjetas.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnPagosTarjetas.patFechaHoraUltimaModificacion = DateTime.Now;
				        ocnPagosTarjetas.usuidUltimaModificacion = this.Master.usuId;
					    ocnPagosTarjetas.Actualizar();
				    }
					
				    Response.Redirect("PagosTarjetasConsulta.aspx", true);
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