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



public partial class TurnoAdmin : System.Web.UI.Page
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
            //dt = new DataTable();
           
            //this.Grilla.DataSource = dt;
            //this.Grilla.DataBind();
        


          
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index1.aspx", false);
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            //int insId = 1;
            //DataTable dt2 = ocnTurnoAsignado.BuscarxDnixIns(txtDni.Text, insId);

            //if (dt2.Rows.Count > 0)
            //{
            //    btnImprimir.Enabled = true;
            //    txtNombre.Text=Convert.ToString(dt2.Rows[0]["Nombre"].ToString());
            //    txtDia.Text = Convert.ToString(dt2.Rows[0]["Dia"].ToString());
            //    txtHorario.Text = Convert.ToString(dt2.Rows[0]["HorarioDesc"].ToString());
            //}
            //else
            //{
            //    lblMensajeError.Text = "No tiene Turnos";
            //}

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

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
   
        dt = new DataTable();
       
        dt = ocnTurnoAsignado.TurnoAsignadoTraerPorFecha(Convert.ToDateTime(Fecha.Text.Trim()));

        if (dt.Rows.Count>0)
            {    this.Grilla.DataSource = dt;
        //this.Grilla.PageIndex = PageIndex;
        this.Grilla.DataBind();
        }
        else
        {
            lblMensajeError.Text = "No existen turnos asignados para ese día";
        }
    

    }
}
    