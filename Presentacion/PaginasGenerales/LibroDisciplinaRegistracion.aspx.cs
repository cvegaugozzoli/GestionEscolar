

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class LibroDisciplinaRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.LibroDisciplina ocnLibroDisciplina = new GESTIONESCOLAR.Negocio.LibroDisciplina();
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Libro de Diciplina - Registracion";
              DateTime fechaActual = DateTime.Today;
                AnioLectivo.Text= fechaActual.Year.ToString();
                insId = Convert.ToInt32(Session["_Institucion"]);
                int aluId = 0;
                if (Request.QueryString["Id"] != null)
                {
                    aluId = Convert.ToInt32(Request.QueryString["Id"]);
                    DataTable dt = new DataTable();
                    TipoSancionId.DataValueField = "Valor"; TipoSancionId.DataTextField = "Texto"; TipoSancionId.DataSource = (new GESTIONESCOLAR.Negocio.TipoSancion()).ObtenerLista("[Seleccionar...]"); TipoSancionId.DataBind();

                    dt = ocnAlumno.ObtenerUno(aluId);
                    if (dt.Rows.Count > 0)
                    {
                        this.Master.TituloDelFormulario = "Libro de Disciplina de " + dt.Rows[0]["Nombre"].ToString();
                        aluNombre.Text = dt.Rows[0]["Nombre"].ToString();
                        aludni.Text = dt.Rows[0]["Doc"].ToString();                       
                        Session.Add("aluId", dt.Rows[0]["aluId"].ToString());                       
                    }
                }
                dt2 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, Convert.ToInt32(AnioLectivo.Text), aluId);
                curNombre.Text = dt2.Rows[0]["Curso"].ToString();
                CurId.Text = dt2.Rows[0]["CursoId"].ToString();
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
            int Id = Convert.ToInt32( Request.QueryString["Id"]);

            Response.Redirect("LibroDisciplinaConsulta.aspx?Id=" + Id);
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
       
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {
            int aluId = Convert.ToInt32(Request.QueryString["Id"]);
            int curId2 = Convert.ToInt32(CurId.Text);
            int tsancion = Convert.ToInt32(TipoSancionId.SelectedValue);
            int Anio = Convert.ToInt32(AnioLectivo.Text);
            int cant = Convert.ToInt32((Cantidad.Text == "" ? "0" : Cantidad.Text));
            String Observ = Observacion.Text;
            String Solicita = Solicitante.Text;
            String CargoSolicitante = txtCargo.Text;
            DateTime FechaSancionD = Convert.ToDateTime(txtFecha.Text);
            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime lddFechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int usuIdUltimaModificacion = this.Master.usuId;


            ocnLibroDisciplina.Insertar(aluId, curId2, tsancion, Anio, cant, Solicita, CargoSolicitante, FechaSancionD, Observ, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, lddFechaHoraUltimaModificacion);
           Response.Redirect("LibroDisciplinaConsulta.aspx?Id=" + aluId + "&Ver=1", false);

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

