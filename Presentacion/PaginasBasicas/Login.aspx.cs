using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PaginasBasicas_Login : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.UsuarioPerfil ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil();
    GESTIONESCOLAR.Negocio.Perfil ocnPerfil = new GESTIONESCOLAR.Negocio.Perfil();

    Int32 insIdTraer = 0;
    DataTable dtUsuario = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int IdPage = 0;
            Page.Title = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
            lblClienteNombre.Text = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
            if (!Page.IsPostBack)
            {
                //ColegioId.DataValueField = "Valor";
                //ColegioId.DataTextField = "Texto";
                //ColegioId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]");
                //ColegioId.DataBind();

                //PerfilId.DataValueField = "Valor";
                //PerfilId.DataTextField = "Texto";
                //PerfilId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]");
                //PerfilId.DataBind();


                this.lblInstitucion.Visible = false;
                IdPage = Convert.ToInt32(Request.QueryString["IdPage"]);

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
            lblErrorInstitucion.Visible = false;
            lblUsuarioNoValido.Visible = false;
            lblInstitucion.Visible = false;
            //int insId = Convert.ToInt32(ColegioId.SelectedValue);
            //dtUsuario = ocnUsuario.ObtenerAutenticar(txtUsuario.Text, txtClave.Text);
            dtUsuario = GESTIONESCOLAR.Negocio.SeguridadAsociacion.Autenticar2(txtUsuario.Text, txtClave.Text);
            //if (Convert.ToInt32(ColegioId.SelectedValue) != 0)
            //{
            if (dtUsuario != null)
            {
                if (dtUsuario.Rows.Count != 0)
                {
                    if (dtUsuario.Rows.Count > 0)
                    {
                        DataTable dtInstPer = new DataTable();
                        dtInstPer = ocnUsuarioPerfil.ObtenerTodoxusuId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString())); // ver si hay varias inst o perfiles
                        if (dtInstPer.Rows.Count == 0) // No tiene perfil
                        {
                            lblUsuarioNoValido.Visible = true;
                            return;
                        }


                        if (dtInstPer.Rows.Count == 1) // si tiene un solo perfil y una sola int
                        {
                            insIdTraer = Convert.ToInt32(dtInstPer.Rows[0]["insId"].ToString());
                            int Perfil = Convert.ToInt32(dtInstPer.Rows[0]["perId"].ToString());

                            DataTable dtPerfil = new DataTable();
                            dtPerfil = ocnPerfil.ObtenerUno(Perfil);
                            //if (dtUsuario.Rows[0]["insId"].ToString() == ColegioId.SelectedValue)
                            //{
                            Session.Add("_Autenticado", true);
                            int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
                            Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                            Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                            Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                            Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                            Session.Add("_perId", dtInstPer.Rows[0]["perId"].ToString());
                            Session.Add("_perNombre", dtPerfil.Rows[0]["perNombre"].ToString());
                            Session.Add("_Institucion", dtInstPer.Rows[0]["insId"].ToString());
                            Session.Add("_InstitucionNombre", dtInstPer.Rows[0]["insNombre"].ToString());
                            Session.Add("_perEsAdministrador", (dtPerfil.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false));
                            Session.Add("_PaginasPermitidas", "");
                            Session.Add("_UsuNivId", dtInstPer.Rows[0]["usuNivId"].ToString());
                            Session.Add("_upeId", dtInstPer.Rows[0]["upeId"].ToString());
                            #region Si Clave es igual a 1, obligo a cambiarla
                            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                            if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                            {
                                Session.Add("_CambiarClave", "1");
                                Response.Redirect("UsuarioCambiarClave.aspx", false);
                            }
                            else
                            {

                                Session.Add("_CambiarClave", "0");
                                Response.Redirect("Sesion.aspx?IdPage=0", false);

                            }
                            #endregion
                        }
                        else
                        {
                            btnIngresar.Enabled = false;

                            if (dtInstPer.Rows.Count > 1) // Mas de una inst o mas de un Perfil
                            {
                                DataTable dtIntListado = new DataTable();
                                dtIntListado = ocnUsuarioPerfil.ObtenerInstxusuId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));

                                if (dtIntListado.Rows.Count == 1) // Tiene un Colegio
                                {
                                    //int InsIdTraer2 = Convert.ToInt32(dtIntListado.Rows[0]["insId"].ToString());
                                    insIdTraer = Convert.ToInt32(dtIntListado.Rows[0]["insId"].ToString());
                                    Session.Add("_Autenticado", true);
                                    int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
                                    Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                                    Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                                    Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                                    Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                                    //Session.Add("_perId", dtInstPer.Rows[0]["perId"].ToString());
                                    //Session.Add("_perNombre", dtInstPer.Rows[0]["perNombre"].ToString());
                                    Session.Add("_Institucion", Convert.ToInt32(dtIntListado.Rows[0]["insId"].ToString()));
                                    Session.Add("_InstitucionNombre", Convert.ToString(dtIntListado.Rows[0]["insNombre"].ToString()));
                                    //ColegioId.SelectedValue = Convert.ToString(dtIntListado.Rows[1]["Valor"].ToString());

                                    //Session.Add("_perEsAdministrador", (dtInstPer.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false));
                                    Session.Add("_PaginasPermitidas", "");
                                    Session.Add("_UsuNivId", dtUsuario.Rows[0]["UsuNivId"].ToString());

                                    DataTable dtUsuarioPerfil2 = new DataTable();
                                    dtUsuarioPerfil2 = ocnUsuarioPerfil.ObtenerPerIdxusuIdxInsId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()), Convert.ToInt32(dtIntListado.Rows[0]["insId"].ToString()));

                                    if (dtUsuarioPerfil2.Rows.Count == 1) // Tiene un Perfil
                                    {
                                        //DataTable dtPerfil = new DataTable();
                                        //dtPerfil = ocnPerfil.ObtenerUno(Convert.ToInt32(dtUsuarioPerfil2.Rows[0]["perId"].ToString()));
                                        Session.Add("_perId", Convert.ToInt32(dtUsuarioPerfil2.Rows[0]["perId"].ToString()));
                                        Session.Add("_perNombre", dtUsuarioPerfil2.Rows[0]["perNombre"].ToString());

                                        Session.Add("_perId", dtUsuarioPerfil2.Rows[0]["perId"].ToString());
                                        Session.Add("_perNombre", dtUsuarioPerfil2.Rows[0]["perNombre"].ToString());
                                        Session.Add("_upeId", dtUsuarioPerfil2.Rows[0]["upeId"].ToString());
                                        #region Si Clave es igual a 1, obligo a cambiarla
                                        ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                                        if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                                        {
                                            Session.Add("_CambiarClave", "1");
                                            Response.Redirect("UsuarioCambiarClave.aspx", false);
                                        }
                                        else
                                        {

                                            Session.Add("_CambiarClave", "0");
                                            Response.Redirect("Sesion.aspx?IdPage=0", false);

                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        if (dtUsuarioPerfil2.Rows.Count >= 2) // mas de un Perfil
                                        {
                                            if (PerfilId.SelectedValue == "")
                                            {
                                                PerfilId.Visible = true;
                                                PerfilId.DataValueField = "Valor";
                                                PerfilId.DataTextField = "Texto";
                                                PerfilId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioPerfil()).ObtenerListaPerIdxusuId("[Seleccionar Perfil...]", Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));
                                                PerfilId.DataBind();
                                                return;
                                            }
                                            else
                                            {
                                                //DataTable dtUsuarioPerfilxPerfil = new DataTable();
                                                //dtUsuarioPerfilxPerfil = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()), Convert.ToInt32(PerfilId.SelectedValue));
                                                //Session.Add("_perId", dtUsuarioPerfilxPerfil.Rows[0]["perId"].ToString());
                                                //Session.Add("_perNombre", dtUsuarioPerfilxPerfil.Rows[0]["perNombre"].ToString());
                                                //Session.Add("_upeId", dtUsuarioPerfilxPerfil.Rows[0]["upeId"].ToString());

                                                //#region Si Clave es igual a 1, obligo a cambiarla
                                                //ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                                                //if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                                                //{
                                                //    Session.Add("_CambiarClave", "1");
                                                //    Response.Redirect("UsuarioCambiarClave.aspx", false);
                                                //}
                                                //else
                                                //{

                                                //    Session.Add("_CambiarClave", "0");
                                                //    Response.Redirect("Sesion.aspx?IdPage=0", false);

                                                //}
                                                //#endregion
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (dtIntListado.Rows.Count >= 2) // mas de un colegio
                                    {
                                        if (ColegioId.SelectedValue == "") // No seleccionó colegio
                                        {
                                            ColegioId.DataValueField = "Valor";
                                            ColegioId.DataTextField = "Texto";
                                            ColegioId.Visible = true;
                                            ColegioId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerListaxusuId("[Seleccionar Institución...]", Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));
                                            ColegioId.DataBind();

                                            return;

                                            //DataTable dtUsuarioPerfil2 = new DataTable();
                                            //dtUsuarioPerfil2 = ocnUsuarioPerfil.ObtenerPerIdxusuId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));

                                            //if (dtUsuarioPerfil2.Rows.Count == 1) // Tiene un Perfil
                                            //{                                             
                                            //    Session.Add("_perId", dtUsuarioPerfil2.Rows[0]["perId"].ToString());
                                            //    Session.Add("_perNombre", dtUsuarioPerfil2.Rows[0]["perNombre"].ToString());
                                            //    Session.Add("_upeId", dtUsuarioPerfil2.Rows[0]["upeId"].ToString());

                                            //}
                                            //else
                                            //{
                                            //    if (dtUsuarioPerfil2.Rows.Count >= 2) // mas de un Perfil
                                            //    {
                                            //        if (PerfilId.SelectedValue == "")
                                            //        {
                                            //            PerfilId.Visible = true;
                                            //            PerfilId.DataValueField = "Valor";
                                            //            PerfilId.DataTextField = "Texto";
                                            //            PerfilId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioPerfil()).ObtenerListaPerIdxusuId("[Seleccionar Perfil...]", Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));
                                            //            PerfilId.DataBind();

                                            //        }
                                            //        else
                                            //        {

                                            //            DataTable dtUsuarioPerfilxPerfil = new DataTable();
                                            //            dtUsuarioPerfilxPerfil = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()), Convert.ToInt32(PerfilId.SelectedValue));
                                            //            Session.Add("_perId", dtUsuarioPerfilxPerfil.Rows[0]["perId"].ToString());
                                            //            Session.Add("_perNombre", dtUsuarioPerfilxPerfil.Rows[0]["perNombre"].ToString());
                                            //            Session.Add("_upeId", dtUsuarioPerfilxPerfil.Rows[0]["upeId"].ToString());

                                            //        }
                                            //    }
                                            //}
                                        }
                                        else
                                        {
                                            Session.Add("_Autenticado", true);
                                            int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
                                            Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                                            Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                                            Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                                            Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                                            Session.Add("_Institucion", Convert.ToInt32(ColegioId.SelectedValue));
                                            Session.Add("_InstitucionNombre", Convert.ToInt32(ColegioId.SelectedItem));
                                            Session.Add("_PaginasPermitidas", "");
                                            Session.Add("_UsuNivId", dtUsuario.Rows[0]["UsuNivId"].ToString());

                                            DataTable dtUsuarioPerfil2 = new DataTable();
                                            dtUsuarioPerfil2 = ocnUsuarioPerfil.ObtenerPerIdxusuId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));

                                            if (dtUsuarioPerfil2.Rows.Count == 1) // Tiene un Perfil
                                            {
                                                Session.Add("_perId", dtUsuarioPerfil2.Rows[0]["perId"].ToString());
                                                Session.Add("_perNombre", dtUsuarioPerfil2.Rows[0]["perNombre"].ToString());
                                                Session.Add("_upeId", dtUsuarioPerfil2.Rows[0]["upeId"].ToString());

                                                #region Si Clave es igual a 1, obligo a cambiarla
                                                ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                                                if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                                                {
                                                    Session.Add("_CambiarClave", "1");
                                                    Response.Redirect("UsuarioCambiarClave.aspx", false);
                                                }
                                                else
                                                {

                                                    Session.Add("_CambiarClave", "0");
                                                    Response.Redirect("Sesion.aspx?IdPage=0", false);

                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                if (dtUsuarioPerfil2.Rows.Count > 2) // mas de un Perfil
                                                {
                                                    if (PerfilId.SelectedValue == "")
                                                    {
                                                        PerfilId.Visible = true;
                                                        PerfilId.DataValueField = "Valor";
                                                        PerfilId.DataTextField = "Texto";
                                                        PerfilId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioPerfil()).ObtenerListaPerIdxusuId("[Seleccionar Perfil...]", Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));
                                                        PerfilId.DataBind();
                                                    }
                                                    else
                                                    {
                                                        DataTable dtUsuarioPerfilxPerfil = new DataTable();
                                                        dtUsuarioPerfilxPerfil = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()), Convert.ToInt32(PerfilId.SelectedValue));
                                                        Session.Add("_perId", dtUsuarioPerfilxPerfil.Rows[0]["perId"].ToString());
                                                        Session.Add("_perNombre", dtUsuarioPerfilxPerfil.Rows[0]["perNombre"].ToString());
                                                        Session.Add("_upeId", dtUsuarioPerfilxPerfil.Rows[0]["upeId"].ToString());

                                                        #region Si Clave es igual a 1, obligo a cambiarla
                                                        ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                                                        if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                                                        {
                                                            Session.Add("_CambiarClave", "1");
                                                            Response.Redirect("UsuarioCambiarClave.aspx", false);
                                                        }
                                                        else
                                                        {

                                                            Session.Add("_CambiarClave", "0");
                                                            Response.Redirect("Sesion.aspx?IdPage=0", false);

                                                        }
                                                        #endregion
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
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
        DataTable dtUsuario = new DataTable();

        dtUsuario = ocnUsuario.ObtenerTodoBuscarxInst(txtUsuario.Text, Convert.ToInt32(ColegioId.SelectedValue));
        insIdTraer = Convert.ToInt32(ColegioId.SelectedValue);

        if (dtUsuario.Rows.Count > 0)
        {
            DataTable dtUsuarioPerfil = new DataTable();
            dtUsuarioPerfil = ocnUsuarioPerfil.ObtenerPerIdxusuIdxInsId(Convert.ToInt32(dtUsuario.Rows[0]["Id"].ToString()), Convert.ToInt32(ColegioId.SelectedValue));
            if (dtUsuarioPerfil.Rows.Count == 1)
            {
                DataTable dtInstPer = new DataTable();
                dtInstPer = ocnUsuarioPerfil.ObtenerTodoxusuId(Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()));
                //insIdTraer = Convert.ToInt32(dtInstPer.Rows[0]["insId"].ToString());
                DataTable dtPerfil = new DataTable();
                dtPerfil = ocnPerfil.ObtenerUno(Convert.ToInt32(dtInstPer.Rows[0]["perId"].ToString()));
                Session.Add("_perId", dtInstPer.Rows[0]["perId"].ToString());

                Session.Add("_Autenticado", true);
                int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
                Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                Session.Add("_perId", dtInstPer.Rows[0]["perId"].ToString());
                Session.Add("_perNombre", dtPerfil.Rows[0]["perNombre"].ToString());
                Session.Add("_Institucion", Convert.ToInt32(ColegioId.SelectedValue));
                Session.Add("_InstitucionNombre", Convert.ToString(ColegioId.SelectedItem));
                Session.Add("_perEsAdministrador", dtPerfil.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false);
                Session.Add("_PaginasPermitidas", "");
                Session.Add("_UsuNivId", dtUsuario.Rows[0]["usuNivId"].ToString());
                Session.Add("_upeId", dtUsuarioPerfil.Rows[0]["upeId"].ToString());
                insIdTraer = Convert.ToInt32(Session["_Institucion"]);
                #region Si Clave es igual a 1, obligo a cambiarla
                ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                {
                    Session.Add("_CambiarClave", "1");
                    Response.Redirect("UsuarioCambiarClave.aspx", false);
                }
                else
                {

                    Session.Add("_CambiarClave", "0");
                    Response.Redirect("Sesion.aspx?IdPage=0", false);

                }
                #endregion
            }
            else // mas de 1 perfil
            {

                Session.Add("_Autenticado", true);
                int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
                Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                Session.Add("_Institucion", Convert.ToInt32(ColegioId.SelectedValue));
                Session.Add("_InstitucionNombre", Convert.ToString(ColegioId.SelectedItem));
                Session.Add("_PaginasPermitidas", "");
                Session.Add("_UsuNivId", dtUsuario.Rows[0]["usuNivId"].ToString());

                insIdTraer = Convert.ToInt32(Session["_Institucion"]);

                PerfilId.Enabled = true;
                PerfilId.Visible = true;
                PerfilId.ClearSelection();
                PerfilId.DataValueField = "Valor";
                PerfilId.DataTextField = "Texto";
                PerfilId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioPerfil()).ObtenerListaPerIdxusuIdxInsId("[Seleccionar Perfil...]", Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString()), Convert.ToInt32(ColegioId.SelectedValue));
                PerfilId.DataBind();
            }
        }
        else
        {
            if (dtUsuario.Rows.Count == 0)
            {
                lblErrorInstitucion.Visible = true;
                PerfilId.Items.Clear();
                return;
            }
        }
    }


    protected void PerfilId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtUsuario = new DataTable();

        insIdTraer = Convert.ToInt32(Session["_Institucion"]);
        int usuIdTraer = Convert.ToInt32(Session["_usuId"]);
        dtUsuario = ocnUsuarioPerfil.ObtenerunoxusuIdxPerIdxinsId(usuIdTraer, Convert.ToInt32(PerfilId.SelectedValue), insIdTraer);
        if (dtUsuario.Rows.Count > 0) // coinciden con usuario pERFIL
        {

            Session.Add("_perId", Convert.ToInt32(PerfilId.SelectedValue));

            Session.Add("_Autenticado", true);
            int usuario = Convert.ToInt32(dtUsuario.Rows[0]["usuId"].ToString());
            Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
            Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
            Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
            Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
            Session.Add("_perId", Convert.ToInt32(PerfilId.SelectedValue));
            Session.Add("_perNombre", Convert.ToString(PerfilId.SelectedItem));
            Session.Add("_Institucion", insIdTraer);
            Session.Add("_InstitucionNombre", dtUsuario.Rows[0]["insNombre"].ToString());
            Session.Add("_perEsAdministrador", dtUsuario.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false);
            Session.Add("_PaginasPermitidas", "");
            Session.Add("_UsuNivId", dtUsuario.Rows[0]["usuNivId"].ToString());
            Session.Add("_upeId", dtUsuario.Rows[0]["upeId"].ToString());
            #region Si Clave es igual a 1, obligo a cambiarla
            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
            if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
            {
                Session.Add("_CambiarClave", "1");
                Response.Redirect("UsuarioCambiarClave.aspx", false);
            }
            else
            {

                Session.Add("_CambiarClave", "0");
                Response.Redirect("Sesion.aspx?IdPage=0", false);

            }
            #endregion
        }

        else
        {
            if (dtUsuario.Rows.Count == 0)
            {
                lblErrorInstitucion.Visible = true;
                PerfilId.Items.Clear();
                return;
            }
        }
    }
}