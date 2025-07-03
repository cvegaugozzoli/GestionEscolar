using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioEspacioCurricularRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario Espacio Curricular - Registracion";

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
					usuId.DataValueField = "Valor"; usuId.DataTextField = "Texto"; usuId.DataSource = (new GESTIONESCOLAR.Negocio.Usuario()).ObtenerLista("[Seleccionar...]"); usuId.DataBind();
					carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
					plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
					curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
					camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
					escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]"); escId.DataBind();

					if (Id != 0)
                    {
						ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular(Id);
						this.uscAnoCursado.Text = ocnUsuarioEspacioCurricular.uscAnoCursado.ToString();
						this.uscActivo.Checked = ocnUsuarioEspacioCurricular.uscActivo;
						this.usuId.SelectedValue = (ocnUsuarioEspacioCurricular.usuId == 0 ? "" : ocnUsuarioEspacioCurricular.usuId.ToString());
						this.carId.SelectedValue = (ocnUsuarioEspacioCurricular.carId == 0 ? "" : ocnUsuarioEspacioCurricular.carId.ToString());
						this.plaId.SelectedValue = (ocnUsuarioEspacioCurricular.plaId == 0 ? "" : ocnUsuarioEspacioCurricular.plaId.ToString());
						this.curId.SelectedValue = (ocnUsuarioEspacioCurricular.curId == 0 ? "" : ocnUsuarioEspacioCurricular.curId.ToString());
						this.camId.SelectedValue = (ocnUsuarioEspacioCurricular.camId == 0 ? "" : ocnUsuarioEspacioCurricular.camId.ToString());
						this.escId.SelectedValue = (ocnUsuarioEspacioCurricular.escId == 0 ? "" : ocnUsuarioEspacioCurricular.escId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.usuId.Focus();
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
            Response.Redirect("UsuarioEspacioCurricularConsulta.aspx", true);
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
			    ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular(Id);

			    ocnUsuarioEspacioCurricular.uscAnoCursado = Convert.ToInt32(uscAnoCursado.Text); 
			    ocnUsuarioEspacioCurricular.uscActivo = uscActivo.Checked; 

				ocnUsuarioEspacioCurricular.usuId = Convert.ToInt32((usuId.SelectedValue.Trim() == "" ? "0" : usuId.SelectedValue)); 
				ocnUsuarioEspacioCurricular.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue)); 
				ocnUsuarioEspacioCurricular.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue)); 
				ocnUsuarioEspacioCurricular.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue)); 
				ocnUsuarioEspacioCurricular.camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue)); 
				ocnUsuarioEspacioCurricular.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnUsuarioEspacioCurricular.uscFechaHoraCreacion = DateTime.Now;
				ocnUsuarioEspacioCurricular.uscFechaHoraUltimaModificacion = DateTime.Now;
				ocnUsuarioEspacioCurricular.usuIdCreacion = this.Master.usuId;
				ocnUsuarioEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnUsuarioEspacioCurricular.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnUsuarioEspacioCurricular.uscFechaHoraUltimaModificacion = DateTime.Now;
				        ocnUsuarioEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;
					    ocnUsuarioEspacioCurricular.Actualizar();
				    }
					
				    Response.Redirect("UsuarioEspacioCurricularConsulta.aspx", true);
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