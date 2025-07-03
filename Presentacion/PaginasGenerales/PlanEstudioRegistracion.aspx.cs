using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PlanEstudioRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Plan Estudio - Registracion";

				//if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                   
                    btnAceptar1.Visible = false;
                }
            
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

					/*INCIALIZADORES*/
					carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();

					if (Id != 0)
                    {
						ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio(Id);
						this.plaNombre.Text = ocnPlanEstudio.plaNombre;
						this.plaAnoInicioVigencia.Text = ocnPlanEstudio.plaAnoInicioVigencia.ToString();
						this.plaAnoFinVigencia.Text = ocnPlanEstudio.plaAnoFinVigencia.ToString();
						this.plaActivo.Checked = ocnPlanEstudio.plaActivo;
						this.carId.SelectedValue = (ocnPlanEstudio.carId == 0 ? "" : ocnPlanEstudio.carId.ToString());
                        carId.Enabled = false;
                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.plaNombre.Focus();
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
            Response.Redirect("PlanEstudioConsulta.aspx", true);
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
			    ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio(Id);

			    ocnPlanEstudio.plaNombre = plaNombre.Text; 
			    ocnPlanEstudio.plaAnoInicioVigencia = Convert.ToInt32(plaAnoInicioVigencia.Text); 
			    ocnPlanEstudio.plaAnoFinVigencia = Convert.ToInt32(plaAnoFinVigencia.Text); 
			    ocnPlanEstudio.plaActivo = plaActivo.Checked; 

				ocnPlanEstudio.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnPlanEstudio.plaFechaHoraCreacion = DateTime.Now;
				ocnPlanEstudio.plaFechaHoraUltimaModificacion = DateTime.Now;
				ocnPlanEstudio.usuIdCreacion = this.Master.usuId;
				ocnPlanEstudio.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnPlanEstudio.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnPlanEstudio.plaFechaHoraUltimaModificacion = DateTime.Now;
				        ocnPlanEstudio.usuIdUltimaModificacion = this.Master.usuId;
					    ocnPlanEstudio.Actualizar();
				    }
					
				    Response.Redirect("PlanEstudioConsulta.aspx", true);
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