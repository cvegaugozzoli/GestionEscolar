using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class TurnoExamenRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.TurnoExamen ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen();
    GESTIONESCOLAR.Negocio.LlamadosExamen ocnLlamadosExamen = new GESTIONESCOLAR.Negocio.LlamadosExamen();

    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Turno Examen - Registracion";
                LlamadoId.DataValueField = "Valor"; LlamadoId.DataTextField = "Texto"; LlamadoId.DataSource = (new GESTIONESCOLAR.Negocio.LlamadosExamen()).ObtenerLista("[Seleccionar...]"); LlamadoId.DataBind();

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

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
                        ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen(Id);
                        this.tueAnio.Text = Convert.ToString(ocnTurnoExamen.tueAnio);
                        this.tueNombre.Text = Convert.ToString(ocnTurnoExamen.tueNombre);
                        //DataTable dt = new DataTable();
                        //dt = ocnLlamadosExamen.ObtenerUno(ocnTurnoExamen.llaId);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    this.tueLLamado.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                        //}
                        DateTime.Now.ToString("hh");
                        LlamadoId.SelectedValue = Convert.ToString(ocnTurnoExamen.llaId);

                        this.tueFchInicio.CalendarDate = ocnTurnoExamen.tueFchInicio;
                        this.tueFchFin.CalendarDate = ocnTurnoExamen.tueFchFin;
                        this.tueActivo.Checked = ocnTurnoExamen.tueActivo;

                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.tueNombre.Focus();
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
            Response.Redirect("BancosConsulta.aspx", true);
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
                ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen(Id);
                ocnTurnoExamen.tueNombre = tueNombre.Text;
                ocnTurnoExamen.tueAnio = Convert.ToInt32(tueAnio.Text);
                ocnTurnoExamen.llaId = Convert.ToInt32(LlamadoId.SelectedValue);
                ocnTurnoExamen.tueFchInicio = tueFchInicio.CalendarDate;
                ocnTurnoExamen.tueFchFin = tueFchFin.CalendarDate;
                ocnTurnoExamen.tueActivo = tueActivo.Checked;

                /*....usuId = this.Master.usuId;*/


                ocnTurnoExamen.tueFechaHoraCreacion = DateTime.Now;
                ocnTurnoExamen.tueFechaHoraUltimaModificacion = DateTime.Now;
                ocnTurnoExamen.usuIdCreacion = this.Master.usuId;
                ocnTurnoExamen.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo
                        ocnTurnoExamen.Insertar();
                    }
                    else
                    {
                        //Editar
                        ocnTurnoExamen.tueFechaHoraUltimaModificacion = DateTime.Now;
                        ocnTurnoExamen.usuIdUltimaModificacion = this.Master.usuId;
                        ocnTurnoExamen.Actualizar();
                    }

                    Response.Redirect("TurnoExamenConsulta.aspx", true);
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