using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;



public partial class TurnoRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.TurnoAsignado ocnTurnoAsignado = new GESTIONESCOLAR.Negocio.TurnoAsignado();
    GESTIONESCOLAR.Negocio.HorariosTurno ocnHorariosTurno = new GESTIONESCOLAR.Negocio.HorariosTurno();
    GESTIONESCOLAR.Negocio.Tramite ocnTramite = new GESTIONESCOLAR.Negocio.Tramite();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            alerTurno.Visible = false;
            ddlTramite.DataValueField = "Valor"; ddlTramite.DataTextField = "Texto"; ddlTramite.DataSource = (new GESTIONESCOLAR.Negocio.Tramite()).ObtenerLista("[Seleccionar...]"); ddlTramite.DataBind();
            ddlTramite.SelectedValue = "0";

            ddlHorario.Enabled = false;
            //ddlHorario.DataValueField = "Valor"; ddlHorario.DataTextField = "Texto"; ddlHorario.DataSource = (new GESTIONESCOLAR.Negocio.HorariosTurno()).ObtenerLista("[Seleccionar...]"); ddlHorario.DataBind();
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index1.aspx", false);
    }

    protected void btnSolicitar_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt2 = new DataTable();
            DataTable dt4 = new DataTable();
            DateTime fecha = Convert.ToDateTime(Calendar2.SelectedDate);

           int  insId = 1;

            if (ddlTramite.SelectedValue=="0")
            {
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Debe Seleccionar un Trámite";
                return;
            }

            if (txtNombre.Text == "")
            {
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Debe ingresar un Nombre";
                return;
            }


            if (txtDni.Text == "")
            {
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Debe ingresar un DNI";
                return;
            }

            DataTable dt1 = ocnTurnoAsignado.ControlHorarioAsignado(fecha, Convert.ToInt32(ddlHorario.SelectedValue));
            if (dt1.Rows.Count == 0)//
            {

                dt2 = ocnTurnoAsignado.ControlTurnoAsignado(Convert.ToString(txtDni.Text), insId);
                if (dt2.Rows.Count == 0)//
                {

                  int IdTurn  =  ocnTurnoAsignado.Insertar(insId, txtNombre.Text, txtDni.Text, Convert.ToInt32(ddlHorario.SelectedValue), Convert.ToInt32(ddlTramite.SelectedValue), fecha);
                    LblTurno.Text = Convert.ToString(IdTurn);
                    alerTurno.Visible = true;
                    btnImprimir.Enabled = true;



                    ///////Archivo
                    string nombre = String.Format("{0}_{1:yyyyMMdd_hhmm}.{2}", 
                    Path.GetFileNameWithoutExtension(FileUpload2.FileName), txtDni.Text, Path.GetExtension(FileUpload2.FileName));

                    string ruta = Server.MapPath("Archivos");

                    string rutacompleta = Path.Combine(ruta, nombre );

                    //FileUpload2.SavaAs(rutacompleta);
                    FileUpload2.SaveAs(Server.MapPath(".") + "/Archivos/" + nombre);


                }
                else
                {
                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                    lblMensajeError.Text = "Ud. ya tiene un turno asignado.. No puede sacar mas de un turno";
                }
            }
            else
            {
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Ya fue asignado ese horario";
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

    protected void Calendar_DayRender(Object source, DayRenderEventArgs e)
    {
        if (e.Day.IsWeekend)
            e.Day.IsSelectable = false;
        //e.Cell.ForeColor = System.Drawing.Color.Cyan;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar2.SelectedDate > DateTime.Today)
        {
        DateTime fecha = Calendar2.SelectedDate;
        String DiaSeleccionado = fecha.ToShortDateString();
        ddlHorario.Enabled = true;
        lblMensajeError.Text = "";


        ddlHorario.DataValueField = "Valor"; ddlHorario.DataTextField = "Texto"; ddlHorario.DataSource = (new GESTIONESCOLAR.Negocio.HorariosTurno()).ObtenerLista("[Seleccionar...]", fecha); ddlHorario.DataBind();
         }
        else
        {
            lblMensajeError.ForeColor = System.Drawing.Color.Red;
            lblMensajeError.Text = "El día seleccionado debe ser mayor al día actual";
        }



        //if (ddlHorario.)       
        //else
        //{
        //    lblMensajeError.ForeColor = System.Drawing.Color.Red;
        //    lblMensajeError.Text = "No hay disponibilidad horaria para ese día..";
        //}      

    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
      

        try
        {
            btnImprimir.Enabled = true;
            int Id = Convert.ToInt32(LblTurno.Text);
            String NomRep = "InformeComprobanteTurno.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?Id=" + Id + "&NomRep=" + NomRep);
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

    protected void Guardar_Click(object sender, EventArgs e)
    {

        ////FileUpload2.SaveAs(Server.MapPath(".") + "/Archivos/" + FileUpload2.FileName);
     
       
    }
}