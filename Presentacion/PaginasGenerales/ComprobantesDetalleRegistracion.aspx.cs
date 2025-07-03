using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ComprobantesDetalleRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Comprobantes Detalle - Registracion";

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

					if (Id != 0)
                    {
						ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle(Id);
						this.cdeImporte.Text = FuncionesUtiles.DecimalToString(ocnComprobantesDetalle.cdeImporte);
						this.cdeActivo.Checked = ocnComprobantesDetalle.cdeActivo;
						this.cocId.SelectedValue = (ocnComprobantesDetalle.cocId == 0 ? "" : ocnComprobantesDetalle.cocId.ToString());
						this.icoId.SelectedValue = (ocnComprobantesDetalle.icoId == 0 ? "" : ocnComprobantesDetalle.icoId.ToString());

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
            Response.Redirect("ComprobantesDetalleConsulta.aspx", true);
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
			    ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle(Id);

			    ocnComprobantesDetalle.cdeImporte = FuncionesUtiles.StringToDecimal(cdeImporte.Text); 
			    ocnComprobantesDetalle.cdeActivo = cdeActivo.Checked; 

				ocnComprobantesDetalle.cocId = Convert.ToInt32((cocId.SelectedValue.Trim() == "" ? "0" : cocId.SelectedValue)); 
				ocnComprobantesDetalle.icoId = Convert.ToInt32((icoId.SelectedValue.Trim() == "" ? "0" : icoId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnComprobantesDetalle.cdeFechaHoraCreacion = DateTime.Now;
				ocnComprobantesDetalle.cdeFechaHoraUltimaModificacion = DateTime.Now;
				ocnComprobantesDetalle.usuIdCreacion = this.Master.usuId;
				ocnComprobantesDetalle.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnComprobantesDetalle.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnComprobantesDetalle.cdeFechaHoraUltimaModificacion = DateTime.Now;
				        ocnComprobantesDetalle.usuidUltimaModificacion = this.Master.usuId;
					    ocnComprobantesDetalle.Actualizar();
				    }
					
				    Response.Redirect("ComprobantesDetalleConsulta.aspx", true);
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