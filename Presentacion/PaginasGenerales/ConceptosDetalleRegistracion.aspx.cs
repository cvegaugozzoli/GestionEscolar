using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConceptosDetalleRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.ConceptosDetalle ocnConceptosDetalle = new GESTIONESCOLAR.Negocio.ConceptosDetalle();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Conceptos Detalle - Registracion";
                insId = Convert.ToInt32(Session["_Institucion"]);
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
					conId.DataValueField = "Valor"; conId.DataTextField = "Texto"; conId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerLista("[Seleccionar...]",insId); conId.DataBind();

					if (Id != 0)
                    {
						ocnConceptosDetalle = new GESTIONESCOLAR.Negocio.ConceptosDetalle(Id);
						this.codNombre.Text = ocnConceptosDetalle.codNombre;
						this.conImporte.Text = FuncionesUtiles.DecimalToString(ocnConceptosDetalle.conImporte);
						this.codActivo.Checked = ocnConceptosDetalle.codActivo;
						this.conId.SelectedValue = (ocnConceptosDetalle.conId == 0 ? "" : ocnConceptosDetalle.conId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.codNombre.Focus();
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
            Response.Redirect("ConceptosDetalleConsulta.aspx", true);
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
			    ocnConceptosDetalle = new GESTIONESCOLAR.Negocio.ConceptosDetalle(Id);

			    ocnConceptosDetalle.codNombre = codNombre.Text; 
			    ocnConceptosDetalle.conImporte = FuncionesUtiles.StringToDecimal(conImporte.Text); 
			    ocnConceptosDetalle.codActivo = codActivo.Checked; 

				ocnConceptosDetalle.conId = Convert.ToInt32((conId.SelectedValue.Trim() == "" ? "0" : conId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnConceptosDetalle.codFechaHoraCreacion = DateTime.Now;
				ocnConceptosDetalle.codFechaHoraUltimaModificacion = DateTime.Now;
				ocnConceptosDetalle.usuIdCreacion = this.Master.usuId;
				ocnConceptosDetalle.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnConceptosDetalle.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnConceptosDetalle.codFechaHoraUltimaModificacion = DateTime.Now;
				        ocnConceptosDetalle.usuidUltimaModificacion = this.Master.usuId;
					    ocnConceptosDetalle.Actualizar();
				    }
					
				    Response.Redirect("ConceptosDetalleConsulta.aspx", true);
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