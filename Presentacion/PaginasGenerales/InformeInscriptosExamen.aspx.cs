using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InformeInscriptosExamen : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.InscripcionExamen ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    int insId;
    //GESTIONESCOLAR.Negocio.InscripcionExamenTipo ocnInscripcionExamenTipo = new GESTIONESCOLAR.Negocio.InscripcionExamenTipo();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Informe de Inscripciones en Examenes";
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]",insId); escId.DataBind();
                //itpId.DataValueField = "Valor"; itpId.DataTextField = "Texto"; itpId.DataSource = (new GESTIONESCOLAR.Negocio.InscripcionExamenTipo()).ObtenerLista("[Seleccionar...]"); itpId.DataBind();

                //DateTime? FechaExamen;
                //FechaExamen = null;
                //ixaFechaExamen.Text = FechaExamen;
                //if (ixaFechaExamen.Text.ToString() != "")
                //{
                //    FechaExamen = Convert.ToDateTime(ixaFechaExamen.Text); // Convert.ToDateTime(dt.Rows[0]["ixaFechaExamen"].ToString());
                //}

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

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
	    {
            String NomRep;
            Int32 carid = Int32.Parse(carId.SelectedValue.ToString());
            Int32 plaid = Int32.Parse(plaId.SelectedValue.ToString());
            Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
            Int32 camid = Int32.Parse(camId.SelectedValue.ToString());
            Int32 escid = Int32.Parse(escId.SelectedValue.ToString());
              Int32 nroacta = 0;
            if (ixaNumeroActa.Text.Trim().ToString() != "") {
                nroacta = Convert.ToInt32(ixaNumeroActa.Text.Trim().ToString());
            }
            DateTime? FechaExamen;
            FechaExamen = null;
            if (ixaFechaExamen.Text.ToString() != "")
            {
                FechaExamen = Convert.ToDateTime(ixaFechaExamen.Text); // Convert.ToDateTime(dt.Rows[0]["ixaFechaExamen"].ToString());
            }
            
            NomRep = "InformeInscriptosExamen.rpt";
            Int32 aplicaFecha = 0;
            if (aplicafiltrofecha.Checked)
            {
                aplicaFecha = 1;
            }

            FuncionesUtiles.AbreVentana("Reporte.aspx?carId=" + carid + "&plaId=" + plaid + "&curId=" + curid + "&camId=" + camid + "&escId=" + escid + "&ixaNumeroActa=" + nroacta + "&ixaFechaExamen=" + FechaExamen.ToString() + "&aplicafiltrofecha=" + aplicaFecha + "&NomRep=" + NomRep);
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

    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        Int32 carid = Int32.Parse(carId.SelectedValue.ToString());
        Int32 plaid = Int32.Parse(plaId.SelectedValue.ToString());
        Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
        Int32 camid = Int32.Parse(camId.SelectedValue.ToString());
        Int32 escid = Int32.Parse(escId.SelectedValue.ToString());
        
        Int32 ixanumeroacta = 0;
        if (ixaNumeroActa.Text.Trim().ToString() != "")
        {
            ixanumeroacta = Convert.ToInt32(ixaNumeroActa.Text.Trim().ToString());
        }
        Int32 aplicaFecha = 0;
        if (aplicafiltrofecha.Checked)
        {
            aplicaFecha = 1;
        }
        dt = ocnInscripcionExamen.InformeInscripcionesExamen(carid, plaid, curid, camid, escid, ixanumeroacta, ixaFechaExamen.Text, aplicaFecha);
        // dt = ocnInscripcionCursado.InformeInscripcionCursado(carid, plaid, curid, camid, escid, aniocursado);
        string ArchivoNombre = "InscripcionExamen_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
        
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        carId.SelectedIndex = 0;
        plaId.SelectedIndex = 0;
        curId.SelectedIndex = 0;
        camId.SelectedIndex = 0;
        escId.SelectedIndex = 0;
        ixaNumeroActa.Text = "";
        
        carId.Focus();
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

    protected void aplicaplicafiltrofecha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (aplicafiltrofecha.Checked)
        {
            ixaFechaExamen.Enabled = true;
        } else
        {
            ixaFechaExamen.Enabled = false;
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