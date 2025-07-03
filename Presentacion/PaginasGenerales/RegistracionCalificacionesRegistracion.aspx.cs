using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class RegistracionCalificacionesRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Registracion Calificaciones - Registracion";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                String IdIC = "0";
                IdIC = Convert.ToInt32(Request.QueryString["Id"]).ToString();
                this.icuId.Text = IdIC;
                DataTable dt = new DataTable();
                dt = ocnInscripcionCursado.ObtenerUno(Convert.ToInt32(icuId.Text));
                if (dt.Rows.Count > 0)
                {
                    this.Master.TituloDelFormulario = "Calificaciones de " + dt.Rows[0]["Alumno"].ToString() +
                         " en la asignatura " + dt.Rows[0]["EspacioCurricular"].ToString() + " para el año " + dt.Rows[0]["AnoCursado"].ToString();
                    Session["escId"] = dt.Rows[0]["escId"].ToString();
                    Session["aluId"] = dt.Rows[0]["aluId"].ToString();
                }

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
                    conId.DataValueField = "Valor"; conId.DataTextField = "Texto"; conId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerLista("[Seleccionar...]"); conId.DataBind();

                    if (Id != 0)
                    {
                        //ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(Id);
                        //this.recTrabajoPractico.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recTrabajoPractico);
                        //this.recTrabajoPracticoRecuperatorio.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recTrabajoPracticoRecuperatorio);
                        //this.recAsistencia.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recAsistencia);
                        //this.recCalificacionParcial1.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcial1);
                        //this.recCalificacionParcial2.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcial2);
                        //this.recCalificacionParcial3.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcial3);
                        //this.recCalificacionParcial4.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcial4);
                        //this.recCalificacionParcialRecuperatorio1.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio1);
                        //this.recCalificacionParcialRecuperatorio2.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio2);
                        //this.recCalificacionParcialRecuperatorio3.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio3);
                        //this.recCalificacionParcialRecuperatorio4.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio4);
                        //this.recObservaciones.Text = ocnRegistracionCalificaciones.recObservaciones;
                        //this.recActivo.Checked = ocnRegistracionCalificaciones.recActivo;
                        //this.conId.SelectedValue = (ocnRegistracionCalificaciones.conId == 0 ? "" : ocnRegistracionCalificaciones.conId.ToString());

                        //                  this.recFechaRegularizaPromociona.Text = Convert.ToDateTime(ocnRegistracionCalificaciones.recFechaRegularizaPromociona.ToString());
                        //                  this.recEvaluacionFinal.Text = FuncionesUtiles.DecimalToString(ocnRegistracionCalificaciones.recEvaluacionFinal);
                        //                  /*Editar Habilitado*/
                    }
                    else
                    {
                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.icuId.Focus();
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
            Response.Redirect("RegistracionCalificacionesConsulta.aspx?Id=" + icuId.Text, true);
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

                //ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones(Id);
                //ocnRegistracionCalificaciones.icuId = Convert.ToInt32(icuId.Text.ToString());
                //ocnRegistracionCalificaciones.recTrabajoPractico = FuncionesUtiles.StringToDecimal(recTrabajoPractico.Text == "" ? "0" : recTrabajoPractico.Text);
                //ocnRegistracionCalificaciones.recTrabajoPracticoRecuperatorio = FuncionesUtiles.StringToDecimal(recTrabajoPracticoRecuperatorio.Text == "" ? "0" : recTrabajoPracticoRecuperatorio.Text);
                //ocnRegistracionCalificaciones.recAsistencia = FuncionesUtiles.StringToDecimal(recAsistencia.Text == "" ? "0" : recAsistencia.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcial1 = FuncionesUtiles.StringToDecimal(recCalificacionParcial1.Text == "" ? "0" : recCalificacionParcial1.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcial2 = FuncionesUtiles.StringToDecimal(recCalificacionParcial2.Text == "" ? "0" : recCalificacionParcial2.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcial3 = FuncionesUtiles.StringToDecimal(recCalificacionParcial3.Text == "" ? "0" : recCalificacionParcial3.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcial4 = FuncionesUtiles.StringToDecimal(recCalificacionParcial4.Text == "" ? "0" : recCalificacionParcial4.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio1 = FuncionesUtiles.StringToDecimal(recCalificacionParcialRecuperatorio1.Text == "" ? "0" : recCalificacionParcialRecuperatorio1.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio2 = FuncionesUtiles.StringToDecimal(recCalificacionParcialRecuperatorio2.Text == "" ? "0" : recCalificacionParcialRecuperatorio2.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio3 = FuncionesUtiles.StringToDecimal(recCalificacionParcialRecuperatorio3.Text == "" ? "0" : recCalificacionParcialRecuperatorio3.Text);
                //ocnRegistracionCalificaciones.recCalificacionParcialRecuperatorio4 = FuncionesUtiles.StringToDecimal(recCalificacionParcialRecuperatorio4.Text == "" ? "0" : recCalificacionParcialRecuperatorio4.Text);
                //ocnRegistracionCalificaciones.recObservaciones = recObservaciones.Text;
                //ocnRegistracionCalificaciones.recActivo = recActivo.Checked;
                //ocnRegistracionCalificaciones.conId = Convert.ToInt32((conId.SelectedValue.Trim() == "" ? "0" : conId.SelectedValue));
                ///*....usuId = this.Master.usuId;*/

                //ocnRegistracionCalificaciones.recFechaHoraCreacion = DateTime.Now;
                //ocnRegistracionCalificaciones.recFechaHoraUltimaModificacion = DateTime.Now;
                //ocnRegistracionCalificaciones.usuIdCreacion = this.Master.usuId;
                //ocnRegistracionCalificaciones.usuIdUltimaModificacion = this.Master.usuId;
                //ocnRegistracionCalificaciones.recEvaluacionFinal = FuncionesUtiles.StringToDecimal(recEvaluacionFinal.Text == "" ? "0" : recEvaluacionFinal.Text);
                //ocnRegistracionCalificaciones.recFechaRegularizaPromociona = Convert.ToDateTime(recFechaRegularizaPromociona.Text);

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo
                        ocnRegistracionCalificaciones.Insertar();
                    }
                    else
                    {
                        //Editar
                        ocnRegistracionCalificaciones.recFechaHoraUltimaModificacion = DateTime.Now;
                        ocnRegistracionCalificaciones.usuIdUltimaModificacion = this.Master.usuId;
                        ocnRegistracionCalificaciones.Actualizar();
                    }

                    Response.Redirect("RegistracionCalificacionesConsulta.aspx?Id=" + icuId.Text, true);
                    //Response.Redirect("RegistracionCalificacionesRegistracion.aspx?IdIC="+IdIC + "&Id=0", false);
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