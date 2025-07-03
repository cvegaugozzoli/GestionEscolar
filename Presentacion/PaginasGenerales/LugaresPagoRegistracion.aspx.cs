using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class LugaresPagoRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.LugaresPago ocnLugaresPago = new GESTIONESCOLAR.Negocio.LugaresPago();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Lugares Pago - Registracion";

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
						ocnLugaresPago = new GESTIONESCOLAR.Negocio.LugaresPago(Id);
						this.lupNombre.Text = ocnLugaresPago.lupNombre;
						this.lupDireccion.Text = ocnLugaresPago.lupDireccion;
						this.lupComision.Text = FuncionesUtiles.DecimalToString(ocnLugaresPago.lupComision);
						this.lupActivo.Checked = ocnLugaresPago.lupActivo;

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.lupNombre.Focus();
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
            Response.Redirect("LugaresPagoConsulta.aspx", true);
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
			    ocnLugaresPago = new GESTIONESCOLAR.Negocio.LugaresPago(Id);

			    ocnLugaresPago.lupNombre = lupNombre.Text; 
			    ocnLugaresPago.lupDireccion = lupDireccion.Text; 
			    ocnLugaresPago.lupComision = FuncionesUtiles.StringToDecimal(lupComision.Text); 
			    ocnLugaresPago.lupActivo = lupActivo.Checked; 

                /*....usuId = this.Master.usuId;*/
                

				ocnLugaresPago.lupFechaHoraCreacion = DateTime.Now;
				ocnLugaresPago.lupFechaHoraUltimaModificacion = DateTime.Now;
				ocnLugaresPago.usuIdCreacion = this.Master.usuId;
				ocnLugaresPago.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnLugaresPago.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnLugaresPago.lupFechaHoraUltimaModificacion = DateTime.Now;
				        ocnLugaresPago.usuidUltimaModificacion = this.Master.usuId;
					    ocnLugaresPago.Actualizar();
				    }
					
				    Response.Redirect("LugaresPagoConsulta.aspx", true);
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