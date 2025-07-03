using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InformedeTrayectoria : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.InscripcionExamen ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    //GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    //GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    //GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    //GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.FormatoDictado ocnFormatoDictado = new GESTIONESCOLAR.Negocio.FormatoDictado();
    GESTIONESCOLAR.Negocio.InscripcionExamenTipo ocnInscripcionExamenTipo = new GESTIONESCOLAR.Negocio.InscripcionExamenTipo();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Informe de Trayectoria";

				//if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar1.Visible = false; 
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
					/*INCIALIZADORES*/
                    if (Id != 0)
                    {

                        DataTable dt = new DataTable();
                        dt = ocnInscripcionExamen.ObtenerUnoPorAlumno(Id);
                        if (dt.Rows.Count > 0)
                        {
                            //ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Id);
                            //this.icuActivo.Checked = ocnInscripcionCursado.icuActivo;
                            if (dt.Rows[0]["ixaActivo"].ToString() == "1" )
                            {
                                this.ixaActivo.Checked = true;  //  ocnInscripcionExamen.ixaActivo;
                            }
                            else
                            {
                                this.ixaActivo.Checked = false;  //  ocnInscripcionExamen.ixaActivo;
                            }
                            //this.fodId.SelectedValue = (ocnInscripcionExamen.fodId == 0 ? "" : ocnInscripcionExamen.fodId.ToString());
                            this.aluId.Text = dt.Rows[0]["aluId"].ToString();  //  ocnInscripcionExamen.aluId.ToString();
                            this.aluNombre.Text = dt.Rows[0]["Alumno"].ToString();
                            this.aludni.Text = dt.Rows[0]["AluDNI"].ToString();
                            this.aluLegajoNumero.Text = dt.Rows[0]["AluLegNro"].ToString();
                            this.aludni.Enabled = false;
                            this.aluNombre.Enabled = false;
                            this.aluLegajoNumero.Enabled = false;

                            btnBuscar.Enabled = false;
                            btnCancelarAlumno.Enabled = false;

                        }
                        /*Editar Habilitado*/
                    }
                    else
                    {
                        /*Nuevo Habilitado*/
                        /*cLoadNuevoCustom*/
                        this.aluId.Focus();
                    }
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
            Response.Redirect("InscripcionExamenConsulta.aspx", true);
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


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = ocnAlumno.ObtenerUnoporDoc(aludni.Text.Trim().ToString());
        if (dt.Rows.Count > 0)
        {
            aluNombre.Text = dt.Rows[0]["aluNombre"].ToString();
            aluNombre.Enabled = false;
            aluLegajoNumero.Text = dt.Rows[0]["aluLegajoNumero"].ToString();
            aluLegajoNumero.Enabled = false;
            aluId.Text = dt.Rows[0]["aluId"].ToString();
        }
    }


    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
    {
        aluNombre.Text = "";
        aluNombre.Enabled = false;
        aluLegajoNumero.Text = "";
        aluLegajoNumero.Enabled = false;
        aludni.Text = "";
        btnBuscar.Enabled = true;
        aludni.Focus();
    }



    protected void btnAceptar_Click(object sender, EventArgs e)
	{

        try
        {
            String NomRep;
            if (aluId.Text.Trim().ToString() != "")
            {
                
            }

            NomRep = "InformeTrayectoria.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId.Text  + "&NomRep=" + NomRep);
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