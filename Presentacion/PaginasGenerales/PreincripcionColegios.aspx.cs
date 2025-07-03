using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class PreincripcionColegios : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();

    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.CupoCursos ocnCupoCursos = new GESTIONESCOLAR.Negocio.CupoCursos();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Departamento ocnDepartamento = new GESTIONESCOLAR.Negocio.Departamento();
    GESTIONESCOLAR.Negocio.Empleado ocnEmpleado = new GESTIONESCOLAR.Negocio.Empleado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.TemporalPreinscripcion ocnTemporalPreinscripcion = new GESTIONESCOLAR.Negocio.TemporalPreinscripcion();
    GESTIONESCOLAR.Datos.Gestor ocdGestor = new GESTIONESCOLAR.Datos.Gestor();
    GESTIONESCOLAR.Negocio.Parametro ocnParametro = new GESTIONESCOLAR.Negocio.Parametro();
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    int CupoValidar = 0;
    int aluId2 = 0;
    int Bandera = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                aletColegio.Visible = false;
                this.Master.TituloDelFormulario = "Pre-Inscripción" + ":   " + + (DateTime.Today.Year+1) ;
                //Nombre.Attributes.Add("Nombre", "onkeypress");
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                Session.Add("_band", 0);
            }
        }
        catch (Exception oError)
        {
//            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
//<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
//<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
//Se ha producido el siguiente error:<br/>
//MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
//"</div>";
        }
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
       
        if (Convert.ToInt32(Session["_band"]) == 1)
        {
        Response.Redirect("../PaginasGenerales/Preinscripcion.aspx");
        }
        else
        {
            aletColegio.Visible = true;
        }
    }

    protected void rbSelector_CheckedChanged(object sender, System.EventArgs e)
     {
        RadioButton1.Checked = true;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;
        Session.Add("_band", 1);
        Session.Add("_Institucion", 1);
        aletColegio.Visible = false;
    }
    protected void rbSelector2_CheckedChanged(object sender, System.EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = true;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;
        Session.Add("_band", 1);
        Session.Add("_Institucion", 2);
        aletColegio.Visible = false;
    }
    protected void rbSelector3_CheckedChanged(object sender, System.EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = true;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;
        Session.Add("_band", 1);
        Session.Add("_Institucion", 5);
        aletColegio.Visible = false;
    }
    protected void rbSelector4_CheckedChanged(object sender, System.EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = true;
        RadioButton5.Checked = false;
        Session.Add("_band", 1);
        Session.Add("_Institucion", 4);
        aletColegio.Visible = false;
    }
    protected void rbSelector5_CheckedChanged(object sender, System.EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = true;
        Session.Add("_band", 1);
        Session.Add("_Institucion", 3);
        aletColegio.Visible = false;

    }
}

