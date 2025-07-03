using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Chequeras : System.Web.UI.Page
{
    DataTable dt = new DataTable();

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
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                this.Master.TituloDelFormulario = " Becados - Consulta";
                btnImprimir.Visible = false;
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                insId = Convert.ToInt32(Session["_Institucion"]);
                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "15"))  // Si es administrador o Director veo todas las carreras
                {
                    lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

                    //carId.Enabled = true;
                    //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //ddlTipoConc.DataValueField = "Valor"; ddlTipoConc.DataTextField = "Texto"; ddlTipoConc.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ddlTipoConc.DataBind();

                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["ListadoBecados.PageIndex"] == null)
                {
                    Session.Add("ListadoBecados.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["ListadoBecados.PageIndex"]);
                }
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
        alerError.Visible = false;
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
        int car = 0;
        int pla = 0;
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("InscripcionCursadoRegistracion.aspx?Id=0", false);
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
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "ListadoBecados" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar2(int PageIndex)
    {
        try
        {
            alerError.Visible = false;
            if (Convert.ToInt32(NivelID.SelectedValue) == 0)
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nivel..";
                return;
            }

            CantReg.Visible = true;
            lblMjeTabla.Text = "";
            Session["Chequeras.PageIndex"] = PageIndex;
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

            dt = ocnInscripcionConcepto.ObtenerTodoxCobrado(insId, cur, AnioCur, Convert.ToInt32(ddlDesde.SelectedValue), Convert.ToInt32(ddlHasta.SelectedValue), Convert.ToInt32(ddlConc.SelectedValue), 0, 0);//listado por curso, Estado = cursando

            if (dt.Rows.Count != 0)
            {
                CantReg.Visible = true;
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                //TextTC.Text = dt.Rows[0]["TipoCarrera"].ToString();
                btnImprimir.Visible = true;
                btnSeleccionarTodo.Visible = true;
            }
            else
            {

                Grilla.DataBind();
                alerError.Visible = true;
                lblError.Text = "No hay alumnos para ese curso o concepto";
                btnImprimir.Visible = false;
                btnSeleccionarTodo.Visible = false;
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

    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == true)
                    {
                        check.Checked = false;

                    }
                }
                btnSeleccionarTodo.Text = "Seleccionar todo";
            }
            else
            {
                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == false)
                    {
                        check.Checked = true;

                    }
                }
                btnSeleccionarTodo.Text = "Desmarcar todo";
            }

            //BtnGrabar.Enabled = true;
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
                curId.DataValueField = "Valor";
                curId.DataTextField = "Texto";
                curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                curId.DataBind();
            }
        }
    }




    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int usuario = Convert.ToInt32(Session["_usuId"].ToString());
        //dt = ocnUsuarioEspacioCurricular.ObtenerUno(usuario);
        //if (dt.Rows[0]["carTipoCarrera"].ToString() == "3") // Si el Tipo de carrera es igual a 3 === Secundario
        //{

        //    //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxusuIdyCur("[Seleccionar...]", usuario, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();

        //}
    }

    protected void ddlTipoConc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);

            int TipoConc = Convert.ToInt32(ddlTipoConc.SelectedValue);
            DataTable dt = new DataTable();
            dt = ocnConceptos.ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ddlTipoConc.SelectedValue), Convert.ToInt32(AnioCursado.Text));
            if (dt.Rows.Count > 0)
            {
                ddlConc.DataValueField = "Valor";
                ddlConc.DataTextField = "Texto";
                ddlConc.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, Convert.ToInt32(ddlTipoConc.SelectedValue), Convert.ToInt32(AnioCursado.Text));
                ddlConc.DataBind();
            }
            else
            {
                //LblMjeGridConcepto.Text = "No existe Concepto para ese Año Lectivo..";
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
    protected void btnImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 curso = Int32.Parse(curId.SelectedValue);
            Int32 anio = 0;
            int Concepto = Int32.Parse(ddlConc.SelectedValue.ToString());

            if (AnioCursado.Text.Trim().ToString() != "")
            {
                anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }





            foreach (GridViewRow row in Grilla.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                if ((check.Checked)) // Si esta seleccionado..
                {
                    DataTable dt1 = new DataTable();
                    dt2 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, Convert.ToInt32(AnioCursado.Text), Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]));
                    dt1 = ocnInscripcionConcepto.TraerxIcuId(Convert.ToInt32(dt2.Rows[0]["Id"].ToString()));
                    if (dt2.Rows.Count > 0)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow row5 in dt1.Rows)// por cada concepto..
                            {
                                int tipoConcepto = Convert.ToInt32(row5["cntId"].ToString());
                                if (tipoConcepto == Convert.ToInt32(ddlTipoConc.SelectedValue))
                                {
                                    int icoId = Convert.ToInt32(row5["Id"].ToString());
                                    //ocnInscripcionConcepto.ActualizarBeca(icoId, BecaId, true, usuIdCreacion, IdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                }
                            }
                        }
                        else
                        {
                            //lblMej.Text = "Tabla Incripción Cursado Vacía";
                        }
                    }
                    else
                    {
                        //lblMej.Text = "Tabla Incripción Concepto Vacía";
                    }
                }
            }

            NomRep = "InformeListadoBecados.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curso=" + curso + "&anio=" + anio + "&Concepto=" + Concepto + "&NomRep=" + NomRep);
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

    protected void AnioCursado_TextChanged(object sender, EventArgs e)
    {
        ddlTipoConc.DataValueField = "Valor"; ddlTipoConc.DataTextField = "Texto"; ddlTipoConc.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ddlTipoConc.DataBind();
        ddlConc.ClearSelection();

    }
}
