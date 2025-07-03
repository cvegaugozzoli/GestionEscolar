using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ListadoAlumnosxCursoTerciario : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    int insId;
    DataTable dt2 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());

                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                //ListadoxCurso.Visible = false;
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Listado de Alumnos por Espacio Curricular";

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "23") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "15") || (Session["_perId"].ToString() == "14") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director o Secretaria veo todas las carreras
                {

                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                    NivelID.SelectedValue = "4";

                    if ((Session["_perId"].ToString() == "23"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerCarreraxusuId("[Seleccionar...]", upeId, 4); carId.DataBind();
                        NivelID.Enabled = false;
                        cdnId.Enabled = true;
                        cdnId.DataValueField = "Valor"; cdnId.DataTextField = "Texto"; cdnId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerLista("[Seleccionar...]"); cdnId.DataBind();

                    }
                    else
                    {


                        carId.Enabled = true;
                        carId.DataValueField = "Valor";
                        carId.DataTextField = "Texto";
                        carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", Convert.ToInt32(NivelID.SelectedValue));
                        carId.DataBind();
                        carId.Enabled = true;
                        NivelID.Enabled = false;
                        cdnId.Enabled = true;
                        cdnId.DataValueField = "Valor"; cdnId.DataTextField = "Texto"; cdnId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerLista("[Seleccionar...]"); cdnId.DataBind();
                        //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    }
                }
                else
                {
                    if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11"))  // Si es Prof Hs Catedra es Terciaria
                    {
                        NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                        NivelID.SelectedValue = "4";
                        NivelID.Enabled = false;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerCarreraxusuId("[Seleccionar...]", upeId, 4); carId.DataBind();
                        //carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                        //carId.Enabled = false;
                        cdnId.Enabled = true;
                        cdnId.DataValueField = "Valor"; cdnId.DataTextField = "Texto"; cdnId.DataSource = (new GESTIONESCOLAR.Negocio.Condicion()).ObtenerLista("[Seleccionar...]"); cdnId.DataBind();

                        //plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                    }
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["ListadoAlumnosxCurso.PageIndex"] == null)
                {
                    Session.Add("ListadoAlumnosxCurso.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CursoListadoCalifxAlumno.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion

                //GrillaCargar(PageIndex);
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

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnPanilla.Visible = false;
        this.Grilla.DataSource = null;
        this.Grilla.DataBind();
        ListadoxCurso.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId2.DataValueField = "Valor"; escId2.DataTextField = "Texto"; escId2.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId2.DataBind();
        }
        else
        {

            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);

            if ((Session["_perId"].ToString() == "23") || (Session["_perId"].ToString() == "11"))
            {
                //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
                escId2.DataValueField = "Valor"; escId2.DataTextField = "Texto"; escId2.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaEspCxusuId("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId2.DataBind();
            }
        }
    }

    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
        int car = 0;
        int pla = 0;
        if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
        {


        }
        else// es primario inicial o secundario
        {

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
            if (dt3.Rows.Count > 0)
            {
                car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
                if (dt4.Rows.Count > 0)
                {
                    pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                }
            }
            curId.DataValueField = "Valor";
            curId.DataTextField = "Texto";
            curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", pla);
            curId.DataBind();
            carId.Enabled = false;
            plaId.Enabled = false;
            carId.SelectedValue = "0";
            plaId.SelectedValue = "0";
        }
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in Grilla.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }

        base.Render(writer);
    }




    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);
        Int32 car = 0;
        Int32 pla = 0;

        if (Convert.ToInt32(NivelID.SelectedValue) == 4)
        {
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
                if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
                {
                    pla = Convert.ToInt32(plaId.SelectedValue.ToString());
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "Debe ingresar un Plan ";
                    return;
                }
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera ";
                return;

            }
        }

        if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());

        }


        if (AnioCursado.Text == "")
        {
            DateTime fechaActual = DateTime.Today;
            AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

        }
        else
        {
            AnioCur = Convert.ToInt32(AnioCursado.Text);
        }
        dt = new DataTable();


        dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);
        string ArchivoNombre = "CursoListadoAlumnos" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            btnPanilla.Visible = false;
            if (Convert.ToInt32(NivelID.SelectedValue) == 0)
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nivel ";
                return;
            }
            if (curId.SelectedValue == "0" || curId.SelectedValue == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso ";
                return;
            }

            //cur = Convert.ToInt32(curId.SelectedValue);
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 car = 0;
            Int32 pla = 0; Int32 esc = 0; Int32 ParamInt1 = 0;

            if (Convert.ToInt32(NivelID.SelectedValue) == 4)
            {
                if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
                {
                    car = Convert.ToInt32(carId.SelectedValue.ToString());
                    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
                    {
                        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
                    }
                    else
                    {
                        alerError.Visible = false;
                        lblError.Text = "Debe ingresar un Plan ";
                        return;
                    }
                }
                else
                {
                    alerError.Visible = false;
                    lblError.Text = "Debe ingresar una Carrera ";
                    return;

                }
            }
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());

            }
            else
            {
                alerError.Visible = false;
                lblError.Text = "Debe ingresar un Curso";
                return;
            }

            if (escId2.SelectedValue.ToString() != "" & escId2.SelectedValue.ToString() != "0")
            {
                esc = Convert.ToInt32(escId2.SelectedValue.ToString());

            }
            else
            {
                alerError.Visible = false;
                lblError.Text = "Debe ingresar un Espacio Curricular";
                return;
            }
            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }

            if (cdnId.SelectedValue == "0")
            {
                ParamInt1 = 0;
            }
            else
            {
                ParamInt1 = Convert.ToInt32(cdnId.SelectedValue);
            }
            dt = new DataTable();

            dt = ocnInscripcionCursadoTerciario.ObtenerTodoxEspC(insId, esc, AnioCur, ParamInt1);


            if (dt.Rows.Count > 0)
            {
                btnPanilla.Visible = true;
                Grilla.Visible = true;
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                ListadoxCurso.Visible = true;

            }
            else
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                ListadoxCurso.Visible = false;
                btnPanilla.Visible = false;
                alerError.Visible = true;
                lblError.Text = "No hay registros..";
                return;
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


    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                //if (e.CommandName == "Eliminar")
                //{
                //    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                //    ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Convert.ToInt32(IC));
                //    //ocnCurso.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                if (e.CommandName == "Ver")
                {
                    String TC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Controls[1]).Text;
                    if (TC == "4")
                    {
                        Response.Redirect("RegistracionCalificacionesRegistracion.aspx?Id=" + IC + "&Ver=1", false);
                    }
                    else
                    {
                        if (TC == "3")
                        {
                            Response.Redirect("CargaCalificacionesPorAlumnoSec.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                        }
                        else
                        {
                            if (TC == "2")
                            {
                                Response.Redirect("CargaCalificacionesPorAlumnoPri.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                            }
                        }
                    }
                }
                String alu = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Controls[1]).Text;
                int aluId = Convert.ToInt32(alu);
                if (e.CommandName == "Ficha")
                {
                    String NomRep;
                    NomRep = "AlumnoFicha.rpt";
                    FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId + "&NomRep=" + NomRep);
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

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#CCCCFF';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["ListadoAlumnosxCurso.PageIndex"] != null)
            {
                Session["ListadoAlumnosxCurso.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ListadoAlumnosxCurso.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex);
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

    protected void GrillaConFicha_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["ListadoAlumnosxCurso.PageIndex"] != null)
            {
                Session["ListadoAlumnosxCurso.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ListadoAlumnosxCurso.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex);
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

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        alerError.Visible = false;
        GrillaCargar(Grilla.PageIndex);
    }


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        carIdCargar();
    }

    private void carIdCargar()
    {
        int upeId = Convert.ToInt32(Session["_upeId"].ToString());
        if (carId.SelectedIndex > 0)
        {
            DataTable dt = new DataTable();
            if (Session["_perId"].ToString() == "23") // Profesor
            {
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaPlanxusuId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); plaId.DataBind();
                plaId.Enabled = true;
            }
            else
            {
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId.DataValueField = "Valor";
                    plaId.DataTextField = "Texto";
                    plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind();
                    plaId.Enabled = true;
                    this.Grilla.DataSource = null;

                    this.Grilla.DataBind();
                    ListadoxCurso.Visible = false;
                    btnPanilla.Visible = false;
                }
            }
        }
    }



    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        plaIdCargar();
    }


    private void plaIdCargar()
    {
        this.Grilla.DataSource = null;
        btnPanilla.Visible = false;
        this.Grilla.DataBind();
        ListadoxCurso.Visible = false;
        int upeId = Convert.ToInt32(Session["_upeId"].ToString());
        if (plaId.SelectedIndex > 0)
        {
            if (Session["_perId"].ToString() == "23") // Profesor
            {
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
            }
            else
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
    }

    protected void btnImprimir(object sender, EventArgs e)
    {
        alerError.Visible = false;
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 escId = Int32.Parse(escId2.SelectedValue.ToString());
            Int32 aniocursado = 0; Int32 ParamInt1 = 0;

            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }
            if (cdnId.SelectedValue != "0")
            {
                //ParamInt1 = Convert.ToInt32(cdnId.SelectedValue);
            }
            else
            {
                //ParamInt1 = 4;
            }


            NomRep = "ListadoPorCursoAnioTerciario.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?escId=" + escId + "&aniocursado=" + aniocursado + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);
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


    protected void lbuEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            ((LinkButton)sender).Visible = false;
            ((LinkButton)sender).Parent.Controls[3].Visible = true;
            ((LinkButton)sender).Parent.Controls[5].Visible = true;
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

    protected void btnEliminarAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "5")) // Si es administrador o preceptora

            {
                int Id = 0;
                Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
                int usuIdCreacion = this.Master.usuId;
                ocnRegistracionNota.EliminarporIC(Id, usuIdCreacion);
                ocnInscripcionCursado.Eliminar(Id, usuIdCreacion);

                ((Button)sender).Parent.Controls[1].Visible = true;
                ((Button)sender).Parent.Controls[3].Visible = false;
                ((Button)sender).Parent.Controls[5].Visible = false;

                GrillaCargar(Grilla.PageIndex);


            }
            else
            {
                lblMensajeError2.Text = "Su perfil no permite realizar esta operación";
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

    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }


    protected void escId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnPanilla.Visible = false;
        this.Grilla.DataSource = null;
        this.Grilla.DataBind();
        ListadoxCurso.Visible = false;
    }

    protected void btnPanilla_Click(object sender, EventArgs e)
    {
        alerError.Visible = false;
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 escId = Int32.Parse(escId2.SelectedValue.ToString());
            Int32 aniocursado = 0; Int32 ParamInt1 = 0;

            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }
            if (cdnId.SelectedValue != "0")
            {
                //ParamInt1 = Convert.ToInt32(cdnId.SelectedValue);
            }
            else
            {
                //ParamInt1 = 4;
            }

            NomRep = "PlanillaAsistenciaTerciario.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?escId=" + escId + "&aniocursado=" + aniocursado + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);
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