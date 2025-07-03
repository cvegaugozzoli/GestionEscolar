using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AsistenciaTerciario : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.CondicionParametros ocnCondicionParametros = new GESTIONESCOLAR.Negocio.CondicionParametros();

    int insId;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                this.Master.TituloDelFormulario = "Registro de Ausencias Terciario";

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "23") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")  // Si es administrador o Director veo todas las carreras
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    //dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
                    //int carIdO = 0;

                    int niv = 4; // Terciario
                    carId.Enabled = true;


                    if ((Session["_perId"].ToString() == "23"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerCarreraxusuId("[Seleccionar...]", upeId, 4); carId.DataBind();
                    }
                    else
                    {
                        DataTable dt2 = new DataTable();

                        dt2 = ocnCarrera.ObtenerUnoxNivel(niv);

                        if (dt2.Rows.Count > 0)
                        {
                            carId.DataValueField = "Valor";
                            carId.DataTextField = "Texto";
                            carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", niv);
                            carId.DataBind();

                        }
                    }

                    //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    //ExamenTipoId.DataValueField = "Valor"; ExamenTipoId.DataTextField = "Texto"; ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]"); ExamenTipoId.DataBind();

                    //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                }


                else
                {
                    if (Session["_perId"].ToString() == "2")// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                    }



                    if ((Session["_perId"].ToString() == "4"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    if (Session["_perId"].ToString() == "5") // Preceptora
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
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

                if (this.Session["AsistenciaTerciario.PageIndex"] == null)
                {
                    Session.Add("AsistenciaTerciario.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        BtnCAlcular.Visible = false;
        this.GridView1.DataSource = null;

        this.GridView1.DataBind();
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        if (Session["_perId"].ToString() == "23") // Profesor
        {
            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaPlanxusuId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); plaId.DataBind();
        }
        else
        {
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue)); carId.DataBind();
                plaId.DataBind();
                plaId.Enabled = true;

                //lblCarrera.Text = Convert.ToString(carId.SelectedItem);
            }
        }


    }

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        BtnCAlcular.Visible = false;
        this.GridView1.DataSource = null;

        this.GridView1.DataBind();
        if (plaId.SelectedIndex != 0)
        {
            DataTable dt = new DataTable();
            if (Session["_perId"].ToString() == "23") // Profesor
            {
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
            }
            else
            {

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

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                //row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                //row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }

    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "AsistenciaTerciario" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {

            alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
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

            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                AnioCursado.Text = Convert.ToString(AnioCur);
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);

            }

            if (AnioCur <= 2024)
            {

                DataTable dtRegCal = new DataTable();
                dtRegCal = ocnRegistracionCalificaciones.ObtenerListadoxEspCurrAsist(espc, cur, AnioCur);
                Int32 AsistenciaReg = 0;
                if (dtRegCal.Rows.Count > 0)
                {
                    this.GridView1.DataSource = dtRegCal;
                    this.GridView1.PageIndex = PageIndex;
                    this.GridView1.DataBind();
                    BtnCAlcular.Visible = true;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        TextBox txtType = (TextBox)row.FindControl("txtTAsistencia");
                        Int32 cdn = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["cdnId"]);

                        if (Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["cdnId"]) != 10) // Si esta Apro x equiv
                        {
                            txtType.Enabled = true;
                        }
                        else
                        {
                            txtType.Enabled = false;
                        }

                    }
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No hay registros para ese filtro..";
                    BtnCAlcular.Visible = false;
                    this.GridView1.DataSource = null;

                    this.GridView1.DataBind();
                }
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Esta sección es unicamente patra cargar años anteriores al actual..";
                BtnCAlcular.Visible = false;
                this.GridView1.DataSource = null;

                this.GridView1.DataBind();

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

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView1.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
        GrillaCargar(PageIndex);
        GridView1.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
        GrillaCargar(PageIndex);
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        GridViewRow row = GridView1.Rows[e.RowIndex];
        //DataTable dt5 = new DataTable();


        DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
        Int32 usuIdUltimaModificacion = this.Master.usuId;


        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtT" + "Asistencia");
        String Nota = p.Text;

        if (Nota != "")
        {
            Decimal porcentaje = ((Convert.ToInt32(cantClases.Text) - Convert.ToInt32(Nota)) * 100) / Convert.ToInt32(cantClases.Text);



            int recId = Id;
            ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
            GridView1.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
            GrillaCargar(PageIndex);
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "No ingresó el número total de Ausencias..";
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
            if (Session["AsistenciaTerciario.PageIndex"] != null)
            {
                Session["AsistenciaTerciario.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("AsistenciaTerciario.PageIndex", e.NewPageIndex);
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

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
        {
            GridView1.EditIndex = e.NewEditIndex;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
            Session["Editar"] = 1;
            GrillaCargar(PageIndex);


            //CommandField tempEditar = new CommandField();
            //tempEditar.ShowEditButton = false;
            //tempEditar.ShowCancelButton = true;
            //GridView1.Columns.Add(tempEditar);
            GridView1.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
            //int ultcol = GridView1.Columns.Count;
            //GridView1.Columns[ultcol-2].Visible = true;
            //GridView1.Columns[ultcol-1].Visible = true;
        }
        else
        {
            LblMensajeErrorGrilla.Text = "No puede modificar notas..";
            return;
        }
    }
    protected void OnCancel(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
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
            if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int Id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0]);
                //int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[2]);

                TextBox Parc1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc1");
                TextBox RecParc1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc1");
                TextBox Parc2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc2");
                TextBox RecParc2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc2");
                TextBox Parc3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc3");
                TextBox RecParc3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc3");
                TextBox Parc4 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc4");
                TextBox RecParc4 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc4");


                String NewParc1 = Parc1.Text;
                String NewRecParc1 = RecParc1.Text;
                String NewParc2 = Parc2.Text;
                String NewRecParc2 = RecParc2.Text;
                String NewParc3 = Parc3.Text;
                String NewRecPar3 = RecParc3.Text;
                String NewParc4 = Parc4.Text;
                String NewRecParc4 = RecParc4.Text;

                DateTime RenFechaHoraCreacion = DateTime.Now;
                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                Int32 usuIdCreacion = this.Master.usuId;
                Int32 usuIdUltimaModificacion = this.Master.usuId;

                //ocnRegistracionCalificaciones.ActualizarNotasParcTerc(Id, NewParc1, NewRecParc1, NewParc2, NewRecParc2, NewParc3, NewRecPar3,
                //NewParc4, NewRecParc4, RenFechaHoraCreacion, RenFechaHoraUltimaModificacion, usuIdCreacion, usuIdUltimaModificacion);
                GridView1.EditIndex = -1;
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
                GrillaCargar(PageIndex);
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
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }



    protected void TipoReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Treg"] = 1;
        Session.Add("datos", GridView1.DataSource);

        //DefinirColumnasNotas();
        //GridView1.DataSource = Session["datos"] as DataTable;
        //GridView1.DataBind();


        GrillaCargar(GridView1.PageIndex);

        Session["Editar"] = 2;
        ButtonAsignar.Enabled = true;
    }

    protected void PeriodoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ButtonAsignar.Enabled = true;

    }


    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        BtnCAlcular.Visible = false;
        this.GridView1.DataSource = null;

        this.GridView1.DataBind();
        insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
        }
        else
        {
            if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "23"))
            {
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();

            }
        }
    }


    protected void ButtonAsignar_Click(object sender, EventArgs e)
    {
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
        Session["Editar"] = 2;

        String Nota = TextNotaAsignar.Text;
        Session["datos"] = GridView1.DataSource;
        //DefinirColumnasNotas();
        //GridView1.DataSource = Session["datos"] as DataTable;
        //GridView1.DataBind();

        foreach (GridViewRow row in GridView1.Rows)
        {
            //CheckBox chk = row.FindControl("chkcheck") as CheckBox;
            ////Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
            //if ((chk.Checked)) // Si esta seleccionado..
            //{
            Int32 ictId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["Id"]);
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;

            int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(ictId, TipoReg.SelectedItem.Text);
            ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
            //}
        }

        GridView1.EditIndex = -1;

        PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
        Session["Editar"] = 0;
        Session["Treg"] = 2;
        GrillaCargar(PageIndex);


    }
    //protected void ButtonAsignar_Click(object sender, EventArgs e)
    //{

    //    Int32 espc = 0;
    //    Int32 car = 0;
    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        car = Convert.ToInt32(carId.SelectedValue.ToString());
    //    }
    //    Int32 pla = 0;
    //    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
    //    {
    //        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
    //    }

    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        cur = Convert.ToInt32(curId.SelectedValue.ToString());
    //    }

    //    if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
    //    {
    //        espc = Convert.ToInt32(escId.SelectedValue.ToString());
    //    }


    //    if (AnioCursado.Text == "")
    //    {
    //        DateTime fechaActual = DateTime.Today;
    //        AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

    //    }
    //    else
    //    {
    //        AnioCur = Convert.ToInt32(AnioCursado.Text);
    //    }

    //    if (TextNotaAsignar.Text != "")
    //    {

    //        if (ExamenTipoId.SelectedValue != "0")
    //        {

    //            dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur);

    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    int RecId = Convert.ToInt32(row["Id"].ToString());
    //                    //ocnRegistracionCalificaciones.AsignarNotaTerc(RecId, Convert.ToInt32(ExamenTipoId.SelectedValue), TextNotaAsignar.Text);

    //                }
    //            }

    //            GridView1.EditIndex = -1;
    //            int PageIndex = 0;
    //            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
    //            GrillaCargar(PageIndex);
    //        }
    //        else
    //        {
    //            LblMensajeErrorGrilla.Text = "Seleccione un Periodo..";
    //            ExamenTipoId.Focus();
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        LblMensajeErrorGrilla.Text = "Asigne una nota..";
    //        TextNotaAsignar.Focus();
    //        return;
    //    }
    //}
    protected void ButtonImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            String NomRep;
            Int32 Materia = Convert.ToInt32(escId.SelectedValue.ToString());
            Int32 curso = Convert.ToInt32(curId.SelectedValue.ToString());
            Int32 anioLectivo = Convert.ToInt32(AnioCursado.Text.Trim().ToString());

            NomRep = "InformeListadoCalificacionesxMateriaSec.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + Materia + "&curId=" + curso + "&anio=" + anioLectivo + "&NomRep=" + NomRep);
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

    protected void ExamenTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnCAlcular_Click(object sender, EventArgs e)
    {
        try
        {
            if (cantClases.Text == "")
            {

            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {

                    int Id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["Id"]);
                    DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                    Int32 usuIdUltimaModificacion = this.Master.usuId;

                    TextBox p = row.FindControl("txtTAsistencia") as TextBox;

                    String Nota = Convert.ToString(p.Text);
                    if (Nota != "")
                    {
                        Decimal porcentaje = ((Convert.ToInt32(cantClases.Text) - Convert.ToInt32(Nota)) * 100) / Convert.ToInt32(cantClases.Text);
                        ocnRegistracionCalificaciones.AsignarNotaTerc(Id, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                    }
                    //else
                    //{
                    //    Decimal porcentaje = 0;
                    //    ocnRegistracionCalificaciones.AsignarNotaTerc(Id, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                    //}
                }
                GrillaCargar(GridView1.PageIndex);
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

    //alerError.Visible = true;
    //lblError.Text = "No ingresó el número total de Ausencias..";}

    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        BtnCAlcular.Visible = false;
        this.GridView1.DataSource = null;

        this.GridView1.DataBind();
        Int32 PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
        GrillaCargar(PageIndex);
    }
}