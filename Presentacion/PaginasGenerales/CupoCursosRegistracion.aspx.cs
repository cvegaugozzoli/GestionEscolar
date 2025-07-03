using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CupoCursosRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.CupoCursos ocnCupoCursos = new GESTIONESCOLAR.Negocio.CupoCursos();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Cupo Cursos - Registracion";

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
					plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
					curid.DataValueField = "Valor"; curid.DataTextField = "Texto"; curid.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curid.DataBind();
					turId.DataValueField = "Valor"; turId.DataTextField = "Texto"; turId.DataSource = (new GESTIONESCOLAR.Negocio.Turnos()).ObtenerLista("[Seleccionar...]"); turId.DataBind();

					if (Id != 0)
                    {
						ocnCupoCursos = new GESTIONESCOLAR.Negocio.CupoCursos(Id);
						this.cupAnioInsc.Text = ocnCupoCursos.cupAnioInsc.ToString();
						this.cupCantidad.Text = ocnCupoCursos.cupCantidad.ToString();
						this.cupActivo.Checked = ocnCupoCursos.cupActivo;
						this.insId.SelectedValue = (ocnCupoCursos.insId == 0 ? "" : ocnCupoCursos.insId.ToString());
						this.plaId.SelectedValue = (ocnCupoCursos.plaId == 0 ? "" : ocnCupoCursos.plaId.ToString());
						this.curid.SelectedValue = (ocnCupoCursos.curid == 0 ? "" : ocnCupoCursos.curid.ToString());
						this.turId.SelectedValue = (ocnCupoCursos.turId == 0 ? "" : ocnCupoCursos.turId.ToString());

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
            Response.Redirect("CupoCursosConsulta.aspx", true);
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
			    ocnCupoCursos = new GESTIONESCOLAR.Negocio.CupoCursos(Id);

			    ocnCupoCursos.cupAnioInsc = Convert.ToInt32(cupAnioInsc.Text); 
			    ocnCupoCursos.cupCantidad = Convert.ToInt32(cupCantidad.Text); 
			    ocnCupoCursos.cupActivo = cupActivo.Checked; 

				ocnCupoCursos.insId = Convert.ToInt32((insId.SelectedValue.Trim() == "" ? "0" : insId.SelectedValue)); 
				ocnCupoCursos.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue)); 
				ocnCupoCursos.curid = Convert.ToInt32((curid.SelectedValue.Trim() == "" ? "0" : curid.SelectedValue)); 
				ocnCupoCursos.turId = Convert.ToInt32((turId.SelectedValue.Trim() == "" ? "0" : turId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnCupoCursos.cupFechaHoraCreacion = DateTime.Now;
				ocnCupoCursos.cupFechaHoraUltimaModificacion = DateTime.Now;
				ocnCupoCursos.usuIdCreacion = this.Master.usuId;
				ocnCupoCursos.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnCupoCursos.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnCupoCursos.cupFechaHoraUltimaModificacion = DateTime.Now;
				        ocnCupoCursos.usuIdUltimaModificacion = this.Master.usuId;
					    ocnCupoCursos.Actualizar();
				    }
					
				    Response.Redirect("CupoCursosConsulta.aspx", true);
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