using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MenuRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Menu ocnMenu = new GESTIONESCOLAR.Negocio.Menu();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Menu - Registracion";

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
					menIdPadre.DataValueField = "Valor"; menIdPadre.DataTextField = "Texto"; menIdPadre.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerLista("[Seleccionar...]"); menIdPadre.DataBind();

					if (Id != 0)
                    {
						ocnMenu = new GESTIONESCOLAR.Negocio.Menu(Id);
						this.menNombre.Text = ocnMenu.menNombre;
						this.menOrden.Text = ocnMenu.menOrden.ToString();
						this.menUrl.Text = ocnMenu.menUrl;
						this.menIcono.Text = ocnMenu.menIcono;
						this.menEsMenu.Checked = ocnMenu.menEsMenu;
						this.menActivo.Checked = ocnMenu.menActivo;
						this.menIdPadre.SelectedValue = (ocnMenu.menIdPadre == 0 ? "" : ocnMenu.menIdPadre.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.menNombre.Focus();
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
            Response.Redirect("MenuConsulta.aspx", true);
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
			    ocnMenu = new GESTIONESCOLAR.Negocio.Menu(Id);

			    ocnMenu.menNombre = menNombre.Text; 
			    ocnMenu.menOrden = Convert.ToInt32(menOrden.Text); 
			    ocnMenu.menUrl = menUrl.Text; 
			    ocnMenu.menIcono = menIcono.Text; 
			    ocnMenu.menEsMenu = menEsMenu.Checked; 
			    ocnMenu.menActivo = menActivo.Checked; 

				ocnMenu.menIdPadre = Convert.ToInt32((menIdPadre.SelectedValue.Trim() == "" ? "0" : menIdPadre.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnMenu.menFechaHoraCreacion = DateTime.Now;
				ocnMenu.menFechaHoraUltimaModificacion = DateTime.Now;
				ocnMenu.usuIdCreacion = this.Master.usuId;
				ocnMenu.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnMenu.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnMenu.menFechaHoraUltimaModificacion = DateTime.Now;
				        ocnMenu.usuIdUltimaModificacion = this.Master.usuId;
					    ocnMenu.Actualizar();
				    }
					
				    Response.Redirect("MenuConsulta.aspx", true);
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