using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexFra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Add("_Autenticado", true);
     
        //Session.Add("_usuId", 88);
        //Session.Add("_usuNombreIngreso", "Pre-Inscripcion");
        //Session.Add("_usuApellido", "Pre-Inscripcion");
        //Session.Add("_usuNombre", "Pre-Inscripcion");
        //Session.Add("_perId", 13);
        //Session.Add("_perNombre","Pre-Inscripcion");
        //Session.Add("_Institucion","");
        //Session.Add("_perEsAdministrador", false);
        //Session.Add("_PaginasPermitidas", "");

    }
//    protected void btnPreinscripcion_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            Response.Redirect("../ PaginasGenerales / Preinscripcion.aspx" , true);
//        }
//        catch (Exception oError)
//        {
////            LB.Text = @"<div class=""alert alert-danger alert-dismissable"">
////<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
////<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
////Se ha producido el siguiente error:<br/>
////MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
////    "</div>";
//        }
//    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {

    }
}