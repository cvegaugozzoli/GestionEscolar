using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ComprobantesCabeceraRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Comprobantes Cabecera - Registracion";

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
					ctiId.DataValueField = "Valor"; ctiId.DataTextField = "Texto"; ctiId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesTipos()).ObtenerLista("[Seleccionar...]"); ctiId.DataBind();

					if (Id != 0)
                    {
						ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera(Id);
						this.cocNroPtoVta.Text = ocnComprobantesCabecera.cocNroPtoVta;
						this.cocNroCompbte.Text = ocnComprobantesCabecera.cocNroCompbte;
						this.cocFechaPago.Text = ocnComprobantesCabecera.cocFechaPago;
						this.cocImporteRendido.Text = FuncionesUtiles.DecimalToString(ocnComprobantesCabecera.cocImporteRendido);
						this.cocObs.Text = ocnComprobantesCabecera.cocObs;
						this.cocActivo.Checked = ocnComprobantesCabecera.cocActivo;
						this.ctiId.SelectedValue = (ocnComprobantesCabecera.ctiId == 0 ? "" : ocnComprobantesCabecera.ctiId.ToString());
						this.lupId.SelectedValue = (ocnComprobantesCabecera.lupId == 0 ? "" : ocnComprobantesCabecera.lupId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {
                        cocFechaPago.Text = DateTime.Now;


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.ctiId.Focus();
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
            Response.Redirect("ComprobantesCabeceraConsulta.aspx", true);
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
			    ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera(Id);

			    ocnComprobantesCabecera.cocNroPtoVta = cocNroPtoVta.Text; 
			    ocnComprobantesCabecera.cocNroCompbte = cocNroCompbte.Text; 
			    ocnComprobantesCabecera.cocFechaPago = Convert.ToDateTime(cocFechaPago.Text); 
			    ocnComprobantesCabecera.cocImporteRendido = FuncionesUtiles.StringToDecimal(cocImporteRendido.Text); 
			    ocnComprobantesCabecera.cocObs = cocObs.Text; 
			    ocnComprobantesCabecera.cocActivo = cocActivo.Checked; 

				ocnComprobantesCabecera.ctiId = Convert.ToInt32((ctiId.SelectedValue.Trim() == "" ? "0" : ctiId.SelectedValue)); 
				ocnComprobantesCabecera.lupId = Convert.ToInt32((lupId.SelectedValue.Trim() == "" ? "0" : lupId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnComprobantesCabecera.cocFechaHoraCreacion = DateTime.Now;
				ocnComprobantesCabecera.cocFechaHoraUltimaModificacion = DateTime.Now;
				ocnComprobantesCabecera.usuIdCreacion = this.Master.usuId;
				ocnComprobantesCabecera.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnComprobantesCabecera.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnComprobantesCabecera.cocFechaHoraUltimaModificacion = DateTime.Now;
				        ocnComprobantesCabecera.usuidUltimaModificacion = this.Master.usuId;
					    ocnComprobantesCabecera.Actualizar();
				    }
					
				    Response.Redirect("ComprobantesCabeceraConsulta.aspx", true);
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