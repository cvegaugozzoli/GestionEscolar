using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InstitucionesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Instituciones - Registracion";

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
						ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones(Id);
						this.insNombre.Text = ocnInstituciones.insNombre;
						this.insCodigo.Text = ocnInstituciones.insCodigo;
						this.insDireccion.Text = ocnInstituciones.insDireccion;
						this.insTelefono.Text = ocnInstituciones.insTelefono;
						this.insCUIT.Text = ocnInstituciones.insCUIT;
						this.insMail.Text = ocnInstituciones.insMail;
						this.insGrupo.Checked = ocnInstituciones.insGrupo;
						this.insActivo.Checked = ocnInstituciones.insActivo;
						this.txtRecauxUsuario.Text = Convert.ToString(ocnInstituciones.insRecaxUsuario);

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.insNombre.Focus();
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
            Response.Redirect("InstitucionesConsulta.aspx", true);
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
			    ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones(Id);

			    ocnInstituciones.insNombre = insNombre.Text; 
			    ocnInstituciones.insCodigo = insCodigo.Text; 
			    ocnInstituciones.insDireccion = insDireccion.Text; 
			    ocnInstituciones.insTelefono = insTelefono.Text; 
			    ocnInstituciones.insCUIT = insCUIT.Text; 
			    ocnInstituciones.insMail = insMail.Text; 
			    ocnInstituciones.insGrupo = insGrupo.Checked; 
			    ocnInstituciones.insActivo = insActivo.Checked;
                ocnInstituciones.insRecaxUsuario = Convert.ToInt32(txtRecauxUsuario.Text);


                /*....usuId = this.Master.usuId;*/


                ocnInstituciones.insFechaHoraCreacion = DateTime.Now;
				ocnInstituciones.insFechaHoraUltimaModificacion = DateTime.Now;
				ocnInstituciones.usuIdCreacion = this.Master.usuId;
				ocnInstituciones.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnInstituciones.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnInstituciones.insFechaHoraUltimaModificacion = DateTime.Now;
				        ocnInstituciones.usuidUltimaModificacion = this.Master.usuId;
					    ocnInstituciones.Actualizar();
				    }
					
				    Response.Redirect("InstitucionesConsulta.aspx", true);
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