using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class TarjetasPlanesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.TarjetasPlanes ocnTarjetasPlanes = new GESTIONESCOLAR.Negocio.TarjetasPlanes();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Tarjetas Planes - Registracion";

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

					if (Id != 0)
                    {
						ocnTarjetasPlanes = new GESTIONESCOLAR.Negocio.TarjetasPlanes(Id);
						this.tapNombre.Text = ocnTarjetasPlanes.tapNombre;
						this.tapInteres.Text = FuncionesUtiles.DecimalToString(ocnTarjetasPlanes.tapInteres);
						this.tapActivo.Checked = ocnTarjetasPlanes.tapActivo;
						this.tarId.SelectedValue = (ocnTarjetasPlanes.tarId == 0 ? "" : ocnTarjetasPlanes.tarId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.tapNombre.Focus();
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
            Response.Redirect("TarjetasPlanesConsulta.aspx", true);
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
			    ocnTarjetasPlanes = new GESTIONESCOLAR.Negocio.TarjetasPlanes(Id);

			    ocnTarjetasPlanes.tapNombre = tapNombre.Text; 
			    ocnTarjetasPlanes.tapInteres = FuncionesUtiles.StringToDecimal(tapInteres.Text); 
			    ocnTarjetasPlanes.tapActivo = tapActivo.Checked; 

				ocnTarjetasPlanes.tarId = Convert.ToInt32((tarId.SelectedValue.Trim() == "" ? "0" : tarId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnTarjetasPlanes.tapFechaHoraCreacion = DateTime.Now;
				ocnTarjetasPlanes.tapFechaHoraUltimaModificacion = DateTime.Now;
				ocnTarjetasPlanes.usuIdCreacion = this.Master.usuId;
				ocnTarjetasPlanes.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnTarjetasPlanes.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnTarjetasPlanes.tapFechaHoraUltimaModificacion = DateTime.Now;
				        ocnTarjetasPlanes.usuidUltimaModificacion = this.Master.usuId;
					    ocnTarjetasPlanes.Actualizar();
				    }
					
				    Response.Redirect("TarjetasPlanesConsulta.aspx", true);
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