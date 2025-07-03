using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConceptosGenerados : System.Web.UI.Page
{
    DataTable dt = new DataTable();

    DataTable dt2 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;

    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                alerError.Visible = false;
                lblMjeTabla.Text = "";
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                this.Master.TituloDelFormulario = "Conceptos Generados";
                insId = Convert.ToInt32(Session["_Institucion"]);
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                btnImprimir.Visible = false;

                NivelID.DataValueField = "Valor";
                NivelID.DataTextField = "Texto";
                NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId);
                NivelID.DataBind();
                this.NivelID.Items.Insert(1, new ListItem("Todos", "100"));
                //carId.Enabled = true;
                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                DateTime fechaActual = DateTime.Today;
                AnioCursado.Text = Convert.ToString(fechaActual.Year.ToString());



                #region PageIndex
                int PageIndex = 0;

                //if (this.Session["ListadoCobradoyxCobrar.PageIndex"] == null)
                //{
                //    Session.Add("ListadoCobradoyxCobrar.PageIndex", 0);
                //}
                //else
                //{
                //    PageIndex = Convert.ToInt32(Session["CursoListadoCalifxAlumno.PageIndex"]);
                //}
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

    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            DataTable dt = new DataTable();
            insId = Convert.ToInt32(Session["_Institucion"]);
            dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
            int car = 0;
            int pla = 0;


            if (NivelID.SelectedValue.ToString() != "100")
            {
                curId2.Enabled = true;
                if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
                {
                    carId.Enabled = true;
                    carId.DataValueField = "Valor";
                    carId.DataTextField = "Texto";
                    carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
                    carId.DataBind();
                    carId.Enabled = true;

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
                    curId2.DataValueField = "Valor";
                    curId2.DataTextField = "Texto";
                    curId2.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", pla);
                    curId2.DataBind();
                    carId.Enabled = false;
                    plaId.Enabled = false;
                }
            }
            else
            {


                curId2.SelectedValue = "0";
                curId2.Enabled = false;
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


    private void GrillaCargar2(int PageIndex)
    {
        try
        {
            alerError.Visible = false;
            lblMjeTabla.Text = "";
            Session["ConceptosGenerados.PageIndex"] = PageIndex;
            insId = Convert.ToInt32(Session["_Institucion"]);
            #region Variables de sesion para filtros

            #endregion
            //cur = Convert.ToInt32(curId.SelectedValue);

            Int32 car = 0;
            Int32 pla = 0;
            if (Convert.ToInt32(NivelID.SelectedValue) == 0)
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nivel";
                return;
            }
            car = Convert.ToInt32(NivelID.SelectedValue);
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
            if (AnioCursado.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar Año Lectivo";
                return;
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }

            if (Convert.ToInt32(NivelID.SelectedValue) != 100)
            {
                if (curId2.SelectedValue.ToString() != "" & curId2.SelectedValue.ToString() != "0")
                {
                    cur = Convert.ToInt32(curId2.SelectedValue.ToString());

                }
                //else  // Modificado 03/09/2021
                //{
                //    alerError.Visible = true;
                //    lblError.Text = "Debe ingresar un Curso ";
                //    return;
                //}
                dt = new DataTable();

                dt = ocnInscripcionConcepto.ConceptosGenerados(insId, cur, AnioCur, car);//listado por curso, Estado = cursando

                if (dt.Rows.Count != 0)
                {
                    btnImprimir.Visible = true;
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();

                }
                else
                {
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
                    btnImprimir.Visible = false;
                    alerError.Visible = true;
                    lblError.Text = "No hay registros"; return;
                }
            }
            else
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                String NomRep2;
                //Int32 curId = Int32.Parse(curId2.SelectedValue.ToString());
                Int32 Anio = 0;

                if (AnioCursado.Text.Trim().ToString() != "")
                {
                    Anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
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

                if (e.CommandName == "Eliminar")
                {
                    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar2(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    //ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Convert.ToInt32(IC));
                    ////ocnCurso.Copiar();
                    //this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")

                {
                    String TC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;
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
            if (Session["CursoConsulta.PageIndex"] != null)
            {
                Session["CursoConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CursoConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar2(e.NewPageIndex);
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
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            ocnCurso.Eliminar(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar2(Grilla.PageIndex);
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

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        //GrillaCargar2(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        lblMjeTabla.Text = "";
        alerError.Visible = false;
        GrillaCargar2(Grilla.PageIndex);
    }



    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
        alerError.Visible = false;
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
        {
            int usuario = Convert.ToInt32(Session["_usuId"].ToString());

            if (Session["_perId"].ToString() == "11") // Si es Docente Especial 
            {

                if (carId.SelectedIndex == 2)
                {

                    plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                    curId2.DataValueField = "Valor"; curId2.DataTextField = "Texto"; curId2.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId2.DataBind();

                }
                else
                {

                    if (carId.SelectedIndex == 6)
                    {

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId2.DataValueField = "Valor"; curId2.DataTextField = "Texto"; curId2.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId2.DataBind();

                    }
                }
            }
            else

            {

                DataTable dt = new DataTable();
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId.DataValueField = "Valor";
                    plaId.DataTextField = "Texto";
                    plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind();
                    plaId.Enabled = true;
                }
            }
        }
    }


    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        plaIdCargar();
        alerError.Visible = false;
    }


    private void plaIdCargar()
    {
        if (plaId.SelectedIndex > 0)
        {

            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            DataTable dt = new DataTable();
            dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                curId2.DataValueField = "Valor";
                curId2.DataTextField = "Texto";
                curId2.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                curId2.DataBind();
            }
        }
    }

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 curId = Int32.Parse(curId2.SelectedValue.ToString());
            Int32 Anio = 0;
            int CarId;
            CarId = Convert.ToInt32(NivelID.SelectedValue);
            if (Convert.ToInt32(NivelID.SelectedValue) == 4)
            {
                if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
                {
                    CarId = Convert.ToInt32(carId.SelectedValue.ToString());
                    //if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
                    //{
                    //    pla = Convert.ToInt32(plaId.SelectedValue.ToString());
                    //}
                    //else
                    //{
                    //    alerError.Visible = true;
                    //    lblError.Text = "Debe ingresar un Plan ";
                    //    return;
                    //}
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "Debe ingresar una Carrera ";
                    return;
                }
            }

            if (AnioCursado.Text.Trim().ToString() != "")
            {
                Anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }
            NomRep = "ConceptosGenerados.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curId=" + curId + "&Anio=" + Anio +  "&CarId=" + CarId + "&NomRep=" + NomRep);

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
