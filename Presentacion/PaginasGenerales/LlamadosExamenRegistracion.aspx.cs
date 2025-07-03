using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class LlamadosExamenRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.LlamadosExamen ocnLlamadosExamen = new GESTIONESCOLAR.Negocio.LlamadosExamen();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Llamados Examen - Registracion";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                extId.DataValueField = "Valor"; extId.DataTextField = "Texto"; extId.DataSource = (new GESTIONESCOLAR.Negocio.ExamenTipo()).ObtenerLista("[Seleccionar...]"); extId.DataBind();

                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/

                    if (Id != 0)
                    {

                        ocnLlamadosExamen = new GESTIONESCOLAR.Negocio.LlamadosExamen(Id);
                        this.llaNombre.Text = ocnLlamadosExamen.llaNombre;
                        this.llaActivo.Checked = ocnLlamadosExamen.llaActivo;
                        this.extId.SelectedValue = Convert.ToString(ocnLlamadosExamen.extId);

                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.llaNombre.Focus();
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
            Response.Redirect("../PaginasBasicas/Inicio.aspx", true);
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
                ocnLlamadosExamen = new GESTIONESCOLAR.Negocio.LlamadosExamen(Id);

                ocnLlamadosExamen.llaNombre = llaNombre.Text;
                ocnLlamadosExamen.llaActivo = llaActivo.Checked;
                ocnLlamadosExamen.extId = Convert.ToInt32(extId.SelectedValue);
                /*....usuId = this.Master.usuId;*/             

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo
                        ocnLlamadosExamen.llaFechaHoraCreacion = DateTime.Now;
                        ocnLlamadosExamen.llaFechaHoraUltimaModificacion = DateTime.Now;
                        ocnLlamadosExamen.usuIdCreacion = this.Master.usuId;
                        ocnLlamadosExamen.usuIdUltimaModificacion = this.Master.usuId;
                        ocnLlamadosExamen.Insertar();
                    }
                    else
                    {
                        //Editar
                        ocnLlamadosExamen.llaFechaHoraUltimaModificacion = DateTime.Now;
                        ocnLlamadosExamen.usuIdUltimaModificacion = this.Master.usuId;
                        ocnLlamadosExamen.Actualizar();
                    }

                    Response.Redirect("LlamadosExamenConsulta.aspx", true);
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