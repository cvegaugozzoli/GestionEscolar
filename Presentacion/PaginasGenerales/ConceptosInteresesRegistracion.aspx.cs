using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConceptosInteresesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Conceptos Intereses - Registracion";
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
					conId.DataValueField = "Valor"; conId.DataTextField = "Texto"; conId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerLista("[Seleccionar...]", insId); conId.DataBind();

					if (Id != 0)
                    {
						ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(Id);
						this.coiNroCuota.Text = ocnConceptosIntereses.coiNroCuota.ToString();
						this.coiFechaVto.Text = ocnConceptosIntereses.coiFechaVto;
						this.coiValorInteres.Text = FuncionesUtiles.DecimalToString(ocnConceptosIntereses.coiValorInteres);
                        this.coiAplicaInteresAbierto.Checked = ocnConceptosIntereses.coiAplicaInteresAbierto;
                        this.coiAplicaBeca.Checked = ocnConceptosIntereses.coiAplicaBeca;
						this.coiActivo.Checked = ocnConceptosIntereses.coiActivo;
						this.conId.SelectedValue = (ocnConceptosIntereses.conId == 0 ? "" : ocnConceptosIntereses.conId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {
                        coiFechaVto.Text = DateTime.Now;


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.conId.Focus();
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
            Response.Redirect("ConceptosInteresesConsulta.aspx", true);
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
			    ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(Id);

			    ocnConceptosIntereses.coiNroCuota = Convert.ToInt32(coiNroCuota.Text); 
			    ocnConceptosIntereses.coiFechaVto = Convert.ToDateTime(coiFechaVto.Text); 
			    ocnConceptosIntereses.coiValorInteres = FuncionesUtiles.StringToDecimal(coiValorInteres.Text); 
			    ocnConceptosIntereses.coiAplicaBeca = coiAplicaBeca.Checked;
                 ocnConceptosIntereses.coiAplicaInteresAbierto = coiAplicaInteresAbierto.Checked;
			    ocnConceptosIntereses.coiActivo = coiActivo.Checked; 

				ocnConceptosIntereses.conId = Convert.ToInt32((conId.SelectedValue.Trim() == "" ? "0" : conId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
				ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
				ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
				ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnConceptosIntereses.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
				        ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
					    ocnConceptosIntereses.Actualizar();
				    }
					
				    Response.Redirect("ConceptosInteresesConsulta.aspx", true);
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