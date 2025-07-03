using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InformeInscriptosCursado : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Informe de Inscripciones por Cursado";
                insId = Convert.ToInt32(Session["_Institucion"]);
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]",insId); escId.DataBind();

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
            Int32 aniocursado = 0;
            if (icuAnioCursado.Text.Trim().ToString() != "") {
                aniocursado = Convert.ToInt32(icuAnioCursado.Text.Trim().ToString());
            }
            
            NomRep = "InformeInscriptosCursado.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?carId=" + carid + "&plaId=" + plaid + "&curId=" + curid + "&camId=" + camid + "&escId=" + escid + "&anio=" + aniocursado + "&NomRep=" + NomRep);
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


    protected void btnListar2_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep;
            Int32 carid = Int32.Parse(carId.SelectedValue.ToString());
            Int32 plaid = Int32.Parse(plaId.SelectedValue.ToString());
            Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
            Int32 camid = Int32.Parse(camId.SelectedValue.ToString());
            Int32 escid = Int32.Parse(escId.SelectedValue.ToString());
            Int32 aniocursado = 0;
            if (icuAnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(icuAnioCursado.Text.Trim().ToString());
            }

            NomRep = "InformeInscriptosCursadoPlanilla.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?carId=" + carid + "&plaId=" + plaid + "&curId=" + curid + "&camId=" + camid + "&escId=" + escid + "&anio=" + aniocursado + "&NomRep=" + NomRep);
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
        Int32 aniocursado = 0;
        if (icuAnioCursado.Text.Trim().ToString() != "")
        {
            aniocursado = Convert.ToInt32(icuAnioCursado.Text.Trim().ToString());
        }
        dt = ocnInscripcionCursado.InformeInscripcionCursado(insId, carid, plaid, curid, camid, escid, aniocursado);
        string ArchivoNombre = "InscripcionCursadoConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
        
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        carId.SelectedIndex = 0;
        plaId.SelectedIndex = 0;
        curId.SelectedIndex = 0;
        camId.SelectedIndex = 0;
        escId.SelectedIndex = 0;
        icuAnioCursado.Text = "";
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