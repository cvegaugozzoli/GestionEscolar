using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class DocentesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Docentes ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Docentes - Registracion";

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
						ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes(Id);
						this.doc_doc.Text = ocnDocentes.doc_doc;
						this.doc_nombre.Text = ocnDocentes.doc_nombre;
						this.doc_apellido.Text = ocnDocentes.doc_apellido;
						this.doc_domicilio.Text = ocnDocentes.doc_domicilio;
						this.doc_telef.Text = ocnDocentes.doc_telef;
						this.doc_mail.Text = ocnDocentes.doc_mail;
						this.usu_id.Text = ocnDocentes.usu_id.ToString();

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.doc_doc.Focus();
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
            Response.Redirect("DocentesConsulta.aspx", true);
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
			    ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes(Id);

			    ocnDocentes.doc_doc = doc_doc.Text; 
			    ocnDocentes.doc_nombre = doc_nombre.Text; 
			    ocnDocentes.doc_apellido = doc_apellido.Text; 
			    ocnDocentes.doc_domicilio = doc_domicilio.Text; 
			    ocnDocentes.doc_telef = doc_telef.Text; 
			    ocnDocentes.doc_mail = doc_mail.Text; 
			    ocnDocentes.usu_id = Convert.ToInt32(usu_id.Text); 

                /*....usuId = this.Master.usuId;*/
                

				ocnDocentes.docFechaHoraCreacion = DateTime.Now;
				ocnDocentes.docFechaHoraUltimaModificacion = DateTime.Now;
				ocnDocentes.usuidCreacion = this.Master.usuId;
				ocnDocentes.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnDocentes.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnDocentes.docFechaHoraUltimaModificacion = DateTime.Now;
				        ocnDocentes.usuidUltimaModificacion = this.Master.usuId;
					    ocnDocentes.Actualizar();
				    }
					
				    Response.Redirect("DocentesConsulta.aspx", true);
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