using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CorrelativaRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Correlativa ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Correlativa - Registracion";

				//if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false; 
                    btnAceptar1.Visible = false;
                }

                int IdEC = 0;
                IdEC = Convert.ToInt32(Request.QueryString["IdEC"]);

                int Id = 0;
                Id = Convert.ToInt32(Request.QueryString["Id"]);

                ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa(IdEC);
                ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(IdEC,insId);
                this.Master.TituloDelFormulario = " Correlativa de " + ocnEspacioCurricular.escNombre + " - Registración";
                escIdOriginal.DataValueField = "Valor"; escIdOriginal.DataTextField = "Texto"; escIdOriginal.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]",insId); escIdOriginal.DataBind();
                this.escIdOriginal.SelectedValue = IdEC.ToString();
                escIdOriginal.Enabled = false;

                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                cotId.DataValueField = "Valor"; cotId.DataTextField = "Texto"; cotId.DataSource = (new GESTIONESCOLAR.Negocio.CorrelatividadTipo()).ObtenerLista("[Seleccionar...]"); cotId.DataBind();

                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

					/*INCIALIZADORES*/
					plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
					curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
					camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
					escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]",insId); escId.DataBind();
					

					if (Id != 0)
                    {
						ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa(Id);
						this.corActivo.Checked = ocnCorrelativa.corActivo;
						this.escIdOriginal.SelectedValue = (ocnCorrelativa.escIdOriginal == 0 ? "" : ocnCorrelativa.escIdOriginal.ToString());
						this.carId.SelectedValue = (ocnCorrelativa.carId == 0 ? "" : ocnCorrelativa.carId.ToString());
                        this.carId.Enabled = false;
                        this.plaId.SelectedValue = (ocnCorrelativa.plaId == 0 ? "" : ocnCorrelativa.plaId.ToString());
                        this.plaId.Enabled = false;
                        this.curId.SelectedValue = (ocnCorrelativa.curId == 0 ? "" : ocnCorrelativa.curId.ToString());
                        this.curId.Enabled = false;
                        this.camId.SelectedValue = (ocnCorrelativa.camId == 0 ? "" : ocnCorrelativa.camId.ToString());
                        this.camId.Enabled = false;
                        this.escId.SelectedValue = (ocnCorrelativa.escId == 0 ? "" : ocnCorrelativa.escId.ToString());
                        this.escId.Enabled = false;
                        this.cotId.SelectedValue = (ocnCorrelativa.cotId == 0 ? "" : ocnCorrelativa.cotId.ToString());

                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    DataTable dtC = new DataTable();
                    dtC = ocnEspacioCurricular.ObtenerUno(IdEC,insId);
                    if (dtC.Rows.Count > 0)
                    {
                        carId.SelectedValue = dtC.Rows[0]["carId"].ToString();
                        plaId.SelectedValue = dtC.Rows[0]["plaId"].ToString();
                    }


                    this.escIdOriginal.Focus();
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
            Response.Redirect("CorrelativaConsulta.aspx", true);
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
            int IdEC = 0;
            IdEC = Convert.ToInt32(Request.QueryString["IdEC"]);
            int Id = 0;
		    if (Request.QueryString["Id"] != null)

		    {
			    Id = Convert.ToInt32(Request.QueryString["Id"]);
			    ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa(Id);

			    ocnCorrelativa.corActivo = corActivo.Checked; 

				ocnCorrelativa.escIdOriginal = Convert.ToInt32((escIdOriginal.SelectedValue.Trim() == "" ? "0" : escIdOriginal.SelectedValue)); 
				ocnCorrelativa.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue)); 
				ocnCorrelativa.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue)); 
				ocnCorrelativa.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue)); 
				ocnCorrelativa.camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue)); 
				ocnCorrelativa.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue)); 
				ocnCorrelativa.cotId = Convert.ToInt32((cotId.SelectedValue.Trim() == "" ? "0" : cotId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnCorrelativa.corFechaHoraCreacion = DateTime.Now;
				ocnCorrelativa.corFechaHoraUltimaModificacion = DateTime.Now;
				ocnCorrelativa.usuIdCreacion = this.Master.usuId;
				ocnCorrelativa.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnCorrelativa.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnCorrelativa.corFechaHoraUltimaModificacion = DateTime.Now;
				        ocnCorrelativa.usuIdUltimaModificacion = this.Master.usuId;
					    ocnCorrelativa.Actualizar();
				    }
					
				    Response.Redirect("CorrelativaConsultaCustom.aspx?Id=" + IdEC, true);

                   // Response.Redirect("CorrelativaRegistracion.aspx?IdEC=" + IdEC + "&Id=" + Id, false);
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


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carId.SelectedIndex != 0)
        {

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                plaId.DataBind();
            }
        }
    }


    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (plaId.SelectedIndex != 0)
        {
            
            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                curId.DataValueField = "Valor";
                curId.DataTextField = "Texto";
                curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                curId.DataBind();
            }
        }
    }

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (curId.SelectedIndex != 0)
        {

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnCampo.ObtenerListaPorUnCurso("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                camId.DataValueField = "Valor";
                camId.DataTextField = "Texto";
                camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerListaPorUnCurso("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue));
                camId.DataBind();
            }
        }
    }


    protected void camId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (camId.SelectedIndex != 0)
        {
           
            insId = Convert.ToInt32(Session["_Institucion"]);
            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnEspacioCurricular.ObtenerListaPorUnCampo("[Seleccionar...]", Convert.ToInt32(camId.SelectedValue),insId);
            if (dt.Rows.Count > 0)
            {
                escId.DataValueField = "Valor";
                escId.DataTextField = "Texto";
                escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCampo("[Seleccionar...]", Convert.ToInt32(camId.SelectedValue),insId);
                escId.DataBind();
            }
        }
    }

}