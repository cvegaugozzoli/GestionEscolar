using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PerfilMenuRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.PerfilMenu ocnPerfilMenu = new GESTIONESCOLAR.Negocio.PerfilMenu();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Perfil Menu - Registracion";

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
					perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); perId.DataBind();
					menId.DataValueField = "Valor"; menId.DataTextField = "Texto"; menId.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerLista("[Seleccionar...]"); menId.DataBind();

					if (Id != 0)
                    {
						ocnPerfilMenu = new GESTIONESCOLAR.Negocio.PerfilMenu(Id);
						this.pmeActivo.Checked = ocnPerfilMenu.pmeActivo;
						this.perId.SelectedValue = (ocnPerfilMenu.perId == 0 ? "" : ocnPerfilMenu.perId.ToString());
						this.menId.SelectedValue = (ocnPerfilMenu.menId == 0 ? "" : ocnPerfilMenu.menId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.perId.Focus();
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
            Response.Redirect("PerfilMenuConsulta.aspx", true);
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
			    ocnPerfilMenu = new GESTIONESCOLAR.Negocio.PerfilMenu(Id);

			    ocnPerfilMenu.pmeActivo = pmeActivo.Checked; 

				ocnPerfilMenu.perId = Convert.ToInt32((perId.SelectedValue.Trim() == "" ? "0" : perId.SelectedValue)); 
				ocnPerfilMenu.menId = Convert.ToInt32((menId.SelectedValue.Trim() == "" ? "0" : menId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnPerfilMenu.pmeFechaHoraCreacion = DateTime.Now;
				ocnPerfilMenu.pmeFechaHoraUltimaModificacion = DateTime.Now;
				ocnPerfilMenu.usuIdCreacion = this.Master.usuId;
				ocnPerfilMenu.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnPerfilMenu.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnPerfilMenu.pmeFechaHoraUltimaModificacion = DateTime.Now;
				        ocnPerfilMenu.usuIdUltimaModificacion = this.Master.usuId;
					    ocnPerfilMenu.Actualizar();
				    }
					
				    Response.Redirect("PerfilMenuConsulta.aspx", true);
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