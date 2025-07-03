using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PlanillaCalificacioneSec : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);


                this.Master.TituloDelFormulario = " Cursado - Planilla de Calificaciones";

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9"))  // Si es administrador o Director veo todas las carreras
                {
                    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                    carId.Enabled = false;

                    plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                    curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                }

                else
                {
                    if (Session["_perId"].ToString() == "2")// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Primario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                    }

                    if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    if (Session["_perId"].ToString() == "5") // Preceptora
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    //if (Session["_perId"].ToString() == "11")   // Si es Docente Area Especia
                    //{
                    //    carId.Enabled = true;
                    //    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //}

                    //}
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["PlanillaCalificacioneSec.PageIndex"] == null)
                {
                    Session.Add("PlanillaCalificacioneSec.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["PlanillaCalificacioneSec.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion
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
        foreach (GridViewRow row in GridView1.Rows)
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
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "PlanillaCalificacioneSec" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Int32 espc = 0;
            Int32 car = 0;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
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

            if (PeriodoId.SelectedIndex == 0)
            {
                dt = new DataTable();
                dt = ocnCurso.InformeCalificacionesPC(cur, AnioCur);
                this.GridView1.DataSource = dt;

                this.GridView1.PageIndex = PageIndex;
                this.GridView1.DataBind();
            }

            if (PeriodoId.SelectedIndex == 1)
            {
                dt = new DataTable();
                dt = ocnCurso.InformeCalificacionesSC(cur, AnioCur);
                this.GridView1.DataSource = dt;

                this.GridView1.PageIndex = PageIndex;
                this.GridView1.DataBind();
            }
            if (PeriodoId.SelectedIndex == 2)
            {
                dt = new DataTable();
                dt = ocnCurso.InformeCalificacionesPromAnual(cur, AnioCur);
                this.GridView1.DataSource = dt;

                this.GridView1.PageIndex = PageIndex;
                this.GridView1.DataBind();
            }

            if (PeriodoId.SelectedIndex == 3)
            {
                dt = new DataTable();
                dt = ocnCurso.InformeCalificacionesDic(cur, AnioCur);
                this.GridView1.DataSource = dt;

                this.GridView1.PageIndex = PageIndex;
                this.GridView1.DataBind();
            }
            if (PeriodoId.SelectedIndex == 4)
            {
                dt = new DataTable();
                dt = ocnCurso.InformeCalificacionesMar(cur, AnioCur);
                this.GridView1.DataSource = dt;

                this.GridView1.PageIndex = PageIndex;
                this.GridView1.DataBind();
            }
            if (PeriodoId.SelectedIndex == 5)
            {
                dt = new DataTable();
                dt = ocnCurso.InformeCalificacionesCalfDef(cur, AnioCur);
                this.GridView1.DataSource = dt;

                this.GridView1.PageIndex = PageIndex;
                this.GridView1.DataBind();
            }
            //dt = new DataTable();
            //dt = ocnCurso.ObtenerCalificacionesPC(cur, AnioCur);
            //this.GridView1.DataSource = dt;

            //this.GridView1.PageIndex = PageIndex;
            //this.GridView1.DataBind();
            //GridView1.Columns[8].Visible = false;
            //GridView1.Columns[9].Visible = false;
            ////TextNotaAsignar.Text = "";

        }
        catch (Exception oError)
        {
            lblMensajeError2.Text = @"<div class=""alert alert-danger alert-dismissable"">
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
                //string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

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
                    this.GrillaCargar(this.GridView1.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                }

                if (e.CommandName == "Ver")
                {
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
            if (Session["PlanillaCalificacioneSec.PageIndex"] != null)
            {
                Session["PlanillaCalificacioneSec.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("PlanillaCalificacioneSec.PageIndex", e.NewPageIndex);
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

            GrillaCargar(GridView1.PageIndex);
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
        GrillaCargar(GridView1.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(GridView1.PageIndex);
        //lblPeriodo.Visible = true;
        //PeriodoId.Visible = true;
        //lblNota.Visible = true;
        //TextNotaAsignar.Visible = true;
        //ButtonAsignar.Visible = true;
        //btn_Imprimir.Visible = true;
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["PlanillaCalificacioneSec.PageIndex"]);
        GrillaCargar(PageIndex);
        GridView1.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
        GridView1.Columns[8].Visible = true;
        GridView1.Columns[9].Visible = true;

    }
    protected void OnCancel(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["PlanillaCalificacioneSec.PageIndex"]);
        GrillaCargar(PageIndex);

    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }


    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            TextBox PCuatr = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPCuatr");
            TextBox SCuatr = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSCuatr");
            TextBox PAnual = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPAnual");
            TextBox NotaDic = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDiciembre");
            TextBox NotaMar = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMarzo");
            TextBox renCalfDef = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtrenCalfDef");
            String PCuatr2 = PCuatr.Text;
            String SCuatr2 = SCuatr.Text;
            String PAnual2 = PAnual.Text;
            String NotaDic2 = NotaDic.Text;
            String NotaMar2 = NotaMar.Text;
            String renCalfDef2 = renCalfDef.Text;
            DateTime RenFechaHoraCreacion = DateTime.Now;
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdCreacion = this.Master.usuId;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            ocnRegistracionNota.ActualizarSecundaria(Id, PCuatr2, SCuatr2, PAnual2, NotaDic2, NotaMar2, renCalfDef2, RenFechaHoraCreacion, RenFechaHoraUltimaModificacion, usuIdCreacion, usuIdUltimaModificacion);
            GridView1.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["PlanillaCalificacioneSec.PageIndex"]);
            GrillaCargar(PageIndex);
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
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }



    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
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

                    curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                }
                else
                {

                    if (carId.SelectedIndex == 6)
                    {

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxusuId("[Seleccionar...]", usuario, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                    }
                }
            }
            else

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
    }


    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        plaIdCargar();
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

    protected void PeriodoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ButtonAsignar.Enabled = true;

    }


    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {


        //if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5")) // Si es administrador o Director veo todas las carreras
        //{
        //    escId.DataValueField = "Id"; escId.DataTextField = "Nombre"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
        //}
        //else
        //{

        //    int usuario = Convert.ToInt32(Session["_usuId"].ToString());
        //    dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);

        //    if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11"))
        //    {
        //        escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxusuIdyCur("[Seleccionar...]", usuario, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
        //    }
        //}
    }
    protected void ButtonAsignar_Click(object sender, EventArgs e)
    {
        
        Int32 insId = Convert.ToInt32(Session["_Institucion"]);
        Int32 espc = 0;
        Int32 car = 0;
        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            car = Convert.ToInt32(carId.SelectedValue.ToString());
        }
        Int32 pla = 0;
        if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
        {
            pla = Convert.ToInt32(plaId.SelectedValue.ToString());
        }

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());
        }

        //if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
        //{
        //    espc = Convert.ToInt32(escId.SelectedValue.ToString());
        //}


        if (AnioCursado.Text == "")
        {
            DateTime fechaActual = DateTime.Today;
            AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

        }
        else
        {
            AnioCur = Convert.ToInt32(AnioCursado.Text);
        }

        dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur,insId);

        //if (PeriodoId.SelectedIndex == 0)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            int RenId = Convert.ToInt32(row["Id"].ToString());
        //            ocnRegistracionNota.AsignarNotaSecPC(RenId, TextNotaAsignar.Text);
        //        }
        //    }
        //}
        //if (PeriodoId.SelectedIndex == 1)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            int RenId = Convert.ToInt32(row["Id"].ToString());
        //            ocnRegistracionNota.AsignarNotaSecSC(RenId, TextNotaAsignar.Text);
        //        }
        //    }
        //}
        //if (PeriodoId.SelectedIndex == 2)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
        //            {
        //                int RenId = Convert.ToInt32(row["Id"].ToString());
        //                ocnRegistracionNota.AsignarNotaPromA(RenId, TextNotaAsignar.Text);
        //            }
        //        }
        //    }
        //}
        //if (PeriodoId.SelectedIndex == 3)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
        //            {
        //                int RenId = Convert.ToInt32(row["Id"].ToString());
        //                ocnRegistracionNota.AsignarNotaDic(RenId, TextNotaAsignar.Text);
        //            }
        //        }
        //    }
        //}

        //if (PeriodoId.SelectedIndex == 4)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
        //            {
        //                int RenId = Convert.ToInt32(row["Id"].ToString());
        //                ocnRegistracionNota.AsignarNotaMar(RenId, TextNotaAsignar.Text);
        //            }
        //        }
        //    }
        //}
        //if (PeriodoId.SelectedIndex == 5)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
        //            {
        //                int RenId = Convert.ToInt32(row["Id"].ToString());
        //                ocnRegistracionNota.AsignarNotaCalDef(RenId, TextNotaAsignar.Text);
        //            }
        //        }
        //}
        //  }
        GridView1.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["PlanillaCalificacioneSec.PageIndex"]);
        GrillaCargar(PageIndex);
    }


    protected void btnImprimir(object sender, EventArgs e)
    {

        try
        {
            String NomRep;
            Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
            Int32 aniocursado = 0;
            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }


            if (PeriodoId.SelectedIndex == 0)
            {
                NomRep = "PlanillaCalificacionesPC.rpt";
                FuncionesUtiles.AbreVentana("Reporte.aspx?curso=" + curid + "&anio=" + aniocursado + "&NomRep=" + NomRep);

            }

            if (PeriodoId.SelectedIndex == 1)
            {
                NomRep = "PlanillaCalificacionesSC.rpt";
                FuncionesUtiles.AbreVentana("Reporte.aspx?curso=" + curid + "&anio=" + aniocursado + "&NomRep=" + NomRep);

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
}
