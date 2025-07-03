using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ComprobantesPtosVtaRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.ComprobantesPtosVta ocnComprobantesPtosVta = new GESTIONESCOLAR.Negocio.ComprobantesPtosVta();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Comprobantes Ptos Vta - Registracion";

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
					insId.DataValueField = "Valor"; insId.DataTextField = "Texto"; insId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); insId.DataBind();
					ctiId.DataValueField = "Valor"; ctiId.DataTextField = "Texto"; ctiId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesTipos()).ObtenerLista("[Seleccionar...]"); ctiId.DataBind();
					cdoId.DataValueField = "Valor"; cdoId.DataTextField = "Texto"; cdoId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesDestinos()).ObtenerLista("[Seleccionar...]"); cdoId.DataBind();

					if (Id != 0)
                    {
						ocnComprobantesPtosVta = new GESTIONESCOLAR.Negocio.ComprobantesPtosVta(Id);
						this.cpvPtoVta.Text = ocnComprobantesPtosVta.cpvPtoVta;
						this.cpvUltimoNro.Text = ocnComprobantesPtosVta.cpvUltimoNro.ToString();
						this.cpvActivo.Checked = ocnComprobantesPtosVta.cpvActivo;
						this.insId.SelectedValue = (ocnComprobantesPtosVta.insId == 0 ? "" : ocnComprobantesPtosVta.insId.ToString());
						this.ctiId.SelectedValue = (ocnComprobantesPtosVta.ctiId == 0 ? "" : ocnComprobantesPtosVta.ctiId.ToString());
						this.cdoId.SelectedValue = (ocnComprobantesPtosVta.cdoId == 0 ? "" : ocnComprobantesPtosVta.cdoId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.insId.Focus();
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
            Response.Redirect("ComprobantesPtosVtaConsulta.aspx", true);
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
			    ocnComprobantesPtosVta = new GESTIONESCOLAR.Negocio.ComprobantesPtosVta(Id);

			    ocnComprobantesPtosVta.cpvPtoVta = cpvPtoVta.Text; 
			    ocnComprobantesPtosVta.cpvUltimoNro = Convert.ToInt32(cpvUltimoNro.Text); 
			    ocnComprobantesPtosVta.cpvActivo = cpvActivo.Checked; 

				ocnComprobantesPtosVta.insId = Convert.ToInt32((insId.SelectedValue.Trim() == "" ? "0" : insId.SelectedValue)); 
				ocnComprobantesPtosVta.ctiId = Convert.ToInt32((ctiId.SelectedValue.Trim() == "" ? "0" : ctiId.SelectedValue)); 
				ocnComprobantesPtosVta.cdoId = Convert.ToInt32((cdoId.SelectedValue.Trim() == "" ? "0" : cdoId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnComprobantesPtosVta.cpvFechaHoraCreacion = DateTime.Now;
				ocnComprobantesPtosVta.cpvFechaHoraUltimaModificacion = DateTime.Now;
				ocnComprobantesPtosVta.usuIdCreacion = this.Master.usuId;
				ocnComprobantesPtosVta.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnComprobantesPtosVta.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnComprobantesPtosVta.cpvFechaHoraUltimaModificacion = DateTime.Now;
				        ocnComprobantesPtosVta.usuidUltimaModificacion = this.Master.usuId;
					    ocnComprobantesPtosVta.Actualizar();
				    }
					
				    Response.Redirect("ComprobantesPtosVtaConsulta.aspx", true);
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