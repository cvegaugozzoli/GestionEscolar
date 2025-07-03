using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LoginEmpleados : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();


    DataTable dtUsuario = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int IdPage = 0;
            Page.Title = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
            //lblClienteNombre.Text = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
            if (!Page.IsPostBack)
            {
                //ColegioId.DataValueField = "Valor";
                //ColegioId.DataTextField = "Texto";
                //ColegioId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]");
                //ColegioId.DataBind();

                this.lblInstitucion.Visible = false;
                IdPage = Convert.ToInt32(Request.QueryString["IdPage"]);
                if (IdPage == 1)
                {
                    ima.ImageUrl = "../images/LogoNuevoAso.jpg";
                    LinkPage.Href = "../images/LogoNuevoAso.jpg";

                }
                else
                {
                    //ColegioId.SelectedIndex = 1;
                    //ColegioId.Enabled = true;
                    ima.ImageUrl = "../images/LogoNuevoAso.jpg";
                    LinkPage.Href = "../images/LogoNuevoAso.jpg";

                }
                if (Session["_Autenticado"] != null) Session.Remove("_Autenticado");
                if (Session["_usuNombreIngreso"] != null) Session.Remove("_usuNombreIngreso");
                if (Session["_usuApellido"] != null) Session.Remove("_usuApellido");
                if (Session["_usuNombre"] != null) Session.Remove("_usuNombre");
                if (Session["_usuId"] != null) Session.Remove("_usuId");
                if (Session["_perId"] != null) Session.Remove("_perId");
                if (Session["_perNombre"] != null) Session.Remove("_perNombre");
                if (Session["_perEsAdministrador"] != null) Session.Remove("_perEsAdministrador");
                if (Session["_PaginasPermitidas"] != null) Session.Remove("_PaginasPermitidas");
                if (Session["_CambiarClave"] != null) Session.Remove("_CambiarClave");
                if (Session["_Institucion"] != null) Session.Remove("_Institucion");

                #region Alto y Ancho de Logo
                GESTIONESCOLAR.Negocio.Parametro ocnParametro = new GESTIONESCOLAR.Negocio.Parametro();
                //string Logo_Alto = "150";
                //string Logo_Ancho = "300";
                //Logo_Alto = ocnParametro.ObtenerValor("Logo_Alto");
                //Logo_Ancho = ocnParametro.ObtenerValor("Logo_Ancho");
                //ima.Height = Unit.Pixel(Convert.ToInt32(Logo_Alto));
                //ima.Width = Unit.Pixel(Convert.ToInt32(Logo_Ancho));
                #endregion

                this.btnIngresar.Focus();
            }

            this.txtUsuario.Focus();
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            this.lblUsuarioNoAlumno.Visible = false;
            this.lblUsuarioNoValido.Visible = false;

            //DataTable dtInscCurs = new DataTable();

            //dtInscCurs = ocnInscripcionCursado.ObtenerUnoxDnixAnio(txtUsuario.Text, DateTime.Now.Year);
            //int insId = 0;
            //String InstNombre = "";
            //if (dtInscCurs.Rows.Count > 0)
            //{
            //    insId = Convert.ToInt32(dtInscCurs.Rows[0]["insId"].ToString());
            //    InstNombre = Convert.ToString(dtInscCurs.Rows[0]["insNombre"].ToString());
            //}

            dtUsuario = GESTIONESCOLAR.Negocio.SeguridadAsociacion.AutenticarEmpleadosSueldos(txtUsuario.Text, txtClave.Text);
            if (dtUsuario.Rows.Count > 0)
            {
                if (dtUsuario.Rows[0]["usuRecibo"].ToString() == "1")
                {

                    Session.Add("_Autenticado", true);
                    int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
                    Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                    Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                    Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                    Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                    //Session.Add("_perId", dtUsuario.Rows[0]["perId"].ToString());
                    Session.Add("_perId", "0");
                    //Session.Add("_perNombre", dtUsuario.Rows[0]["perNombre"].ToString());
                    Session.Add("_perNombre", "Sin Perfil");
                    //Session.Add("_Institucion", Convert.ToString(insId));
                    //Session.Add("_InstitucionNombre", InstNombre);
                    Session.Add("_Institucion", Convert.ToString(0));
                    Session.Add("_InstitucionNombre", "Obra Misericordista");
                    //Session.Add("_perEsAdministrador", (dtUsuario.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false));
                    Session.Add("_perEsAdministrador", false);
                    Session.Add("_PaginasPermitidas", "");

                    #region Si Clave es igual a 1, obligo a cambiarla
                    ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                    if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                    {
                        Session.Add("_CambiarClave", "1");
                        Response.Redirect("UsuarioCambiarClaveEmpleados.aspx", false);
                    }
                    else
                    {

                        Session.Add("_CambiarClave", "0");
                        Response.Redirect("SesionEmpleados.aspx", false);

                    }
                    #endregion       
                }
                else
                {
                    UsuarioNoValido();
                }
            }
            else
            {
                UsuarioNoValido();
            }


        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void UsuarioNoAlumno()
    {
        try
        {
            this.lblUsuarioNoAlumno.Visible = true;

            this.txtUsuario.Text = "";
            this.txtClave.Text = "";
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void UsuarioNoValido()
    {
        try
        {
            this.lblUsuarioNoValido.Visible = true;

            this.txtUsuario.Text = "";
            this.txtClave.Text = "";
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void ColegioId_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}