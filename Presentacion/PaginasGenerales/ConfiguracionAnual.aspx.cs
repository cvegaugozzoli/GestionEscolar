using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConfiguracionAnual : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.CondicionParametros ocnCondicionParametros = new GESTIONESCOLAR.Negocio.CondicionParametros();
    GESTIONESCOLAR.Negocio.CondicionParametrosFijos ocnCondicionParametrosFijos = new GESTIONESCOLAR.Negocio.CondicionParametrosFijos();
    GESTIONESCOLAR.Negocio.EspCurrEvaluacion ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Configuración Anual ";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["ConfiguracionAnual.PageIndex"] == null)
                {
                    Session.Add("ConfiguracionAnual.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["ConfiguracionAnual.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //if (Session["BancosConsulta.Nombre"] != null) { Bancos.Text = Session["BancosConsulta.Nombre"].ToString(); } else { Session.Add("BancosConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion
                cpfAnioCursado.Text = Convert.ToString(DateTime.Now.Year);
                DataTable dt = new DataTable();
                dt = ocnCondicionParametros.ObtenerTodoBuscarxAnio(Convert.ToInt32(cpfAnioCursado.Text));
                if (dt.Rows.Count > 0)
                {
                    btnActualizar.Visible = false;
                    ElementosConfigurar.Visible = true;
                    ElementosNoActualizados.Visible = false;
                }
                else
                {
                    btnActualizar.Visible = true;
                    ElementosConfigurar.Visible = false;
                    ElementosNoActualizados.Visible = true;

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

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ocnCondicionParametros.ObtenerTodoBuscarxAnio(Convert.ToInt32(cpfAnioCursado.Text));
            if (dt.Rows.Count > 0)
            {
                btnActualizar.Visible = false;
                ElementosConfigurar.Visible = true;
                ElementosNoActualizados.Visible = false;
            }
            else
            {
                btnActualizar.Visible = true;
                ElementosConfigurar.Visible = false;
                ElementosNoActualizados.Visible = true;

            }
            CheckBox1.Checked = false;
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

    //protected void btnExportarAExcel_Click(object sender, EventArgs e)
    //{
    //    dt = new DataTable();
    //    //dt = ocnLlamadosExamen.ObtenerTodoBuscarxNombre(Nombre.Text.Trim());
    //    dt = ocnLlamadosExamen.ObtenerTodo();
    //    string ArchivoNombre = "BancosConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
    //    FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    //}


    //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    //{

    //}

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            dt1 = ocnCondicionParametros.ObtenerTodoBuscarxAnio(Convert.ToInt32(cpfAnioCursado.Text));
            dt2 = ocnCondicionParametrosFijos.ObtenerTodoxAnio(Convert.ToInt32(cpfAnioCursado.Text));
            dt3 = ocnEspCurrEvaluacion.ObtenerTodoxAnio(Convert.ToInt32(cpfAnioCursado.Text));

            if (dt1.Rows.Count == 0)
            {
                ocnCondicionParametros.InsertarNewAnio(Convert.ToInt32(cpfAnioCursado.Text), this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
            }
            if (dt2.Rows.Count == 0)
            {
                ocnCondicionParametrosFijos.InsertarNewAnio(Convert.ToInt32(cpfAnioCursado.Text), this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
            }
            if (dt3.Rows.Count == 0)
            {
                ocnEspCurrEvaluacion.InsertarNewAnio(Convert.ToInt32(cpfAnioCursado.Text), this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
            }
            DataTable dt = new DataTable();
            dt = ocnCondicionParametros.ObtenerTodoBuscarxAnio(Convert.ToInt32(cpfAnioCursado.Text));
            if (dt.Rows.Count > 0)
            {
                btnActualizar.Visible = false;
                ElementosConfigurar.Visible = true;
                ElementosNoActualizados.Visible = false;
            }
            else
            {
                btnActualizar.Visible = true;
                ElementosConfigurar.Visible = false;
                ElementosNoActualizados.Visible = true;

            }
            CheckBox1.Checked = false;


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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("EvaluacionesEspCurricular.aspx", true);
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

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("CondicionParametrosConsulta.aspx", true);
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