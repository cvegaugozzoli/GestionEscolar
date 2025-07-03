using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ComprobantesFormasPagoRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.ComprobantesFormasPago ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Comprobantes Formas Pago - Registracion";

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
					fopId.DataValueField = "Valor"; fopId.DataTextField = "Texto"; fopId.DataSource = (new GESTIONESCOLAR.Negocio.FormasPago()).ObtenerLista("[Seleccionar...]"); fopId.DataBind();

					if (Id != 0)
                    {
						ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago(Id);
						this.cfpImporteParcial.Text = FuncionesUtiles.DecimalToString(ocnComprobantesFormasPago.cfpImporteParcial);
						this.cfpActivo.Checked = ocnComprobantesFormasPago.cfpActivo;
						this.cocId.SelectedValue = (ocnComprobantesFormasPago.cdeId == 0 ? "" : ocnComprobantesFormasPago.cdeId.ToString());
						this.fopId.SelectedValue = (ocnComprobantesFormasPago.fopId == 0 ? "" : ocnComprobantesFormasPago.fopId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.cocId.Focus();
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
            Response.Redirect("ComprobantesFormasPagoConsulta.aspx", true);
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
			    ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago(Id);

			    ocnComprobantesFormasPago.cfpImporteParcial = FuncionesUtiles.StringToDecimal(cfpImporteParcial.Text); 
			    ocnComprobantesFormasPago.cfpActivo = cfpActivo.Checked; 

				ocnComprobantesFormasPago.cdeId = Convert.ToInt32((cocId.SelectedValue.Trim() == "" ? "0" : cocId.SelectedValue)); 
				ocnComprobantesFormasPago.fopId = Convert.ToInt32((fopId.SelectedValue.Trim() == "" ? "0" : fopId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnComprobantesFormasPago.cfpFechaHoraCreacion = DateTime.Now;
				ocnComprobantesFormasPago.cfpFechaHoraUltimaModificacion = DateTime.Now;
				ocnComprobantesFormasPago.usuIdCreacion = this.Master.usuId;
				ocnComprobantesFormasPago.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnComprobantesFormasPago.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnComprobantesFormasPago.cfpFechaHoraUltimaModificacion = DateTime.Now;
				        ocnComprobantesFormasPago.usuidUltimaModificacion = this.Master.usuId;
					    ocnComprobantesFormasPago.Actualizar();
				    }
					
				    Response.Redirect("ComprobantesFormasPagoConsulta.aspx", true);
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