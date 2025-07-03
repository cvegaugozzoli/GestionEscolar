using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class EvaluacionesEspCurricular : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.EspCurrEvaluacion ocnEspCurrEvaluacion = new GESTIONESCOLAR.Negocio.EspCurrEvaluacion();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Cargar Evaluaciones";
                int insId = Convert.ToInt32(Session["_Institucion"]);
                int PageIndex = 0;
                carId.Enabled = true;
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", 4); carId.DataBind();
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                plaId.DataBind();
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();

                int Id = 0;
                int escId2 = 0;
                if (Request.QueryString["escId"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["escId"]);
                    if (Id != 0)
                    {
                        ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(Id, insId);
                        escId.SelectedValue = Convert.ToString(Request.QueryString["escId"]);
                        carId.SelectedValue = Convert.ToString(ocnEspacioCurricular.carId);
                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind();
                        plaId.SelectedValue = Convert.ToString(ocnEspacioCurricular.plaId);
                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();

                        curId.SelectedValue = Convert.ToString(ocnEspacioCurricular.curId);
                        escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(ocnEspacioCurricular.curId), insId); escId.DataBind();
                        eceAnioCursado.Text = Convert.ToString(DateTime.Today.Year);
                        GrillaCargar(PageIndex);
                    }
                }

                #region PageIndex

                if (this.Session["EvaluacionesEspCurricular.PageIndex"] == null)
                {
                    Session.Add("EvaluacionesEspCurricular.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["EvaluacionesEspCurricular.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //if (Session["BancosConsulta.Nombre"] != null) { Bancos.Text = Session["BancosConsulta.Nombre"].ToString(); } else { Session.Add("BancosConsulta.Nombre", Nombre.Text.Trim()); }
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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
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

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (plaId.SelectedIndex != 0)
        {
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
            if (eceAnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                eceAnioCursado.Text = Convert.ToString(DateTime.Today.Year);
            }
            else
            {
                AnioCur = Convert.ToInt32(eceAnioCursado.Text);
            }

            dt = new DataTable();
            dt = ocnEspCurrEvaluacion.ObtenerTodoBuscarxescId(espc, AnioCur);

            if (dt.Rows.Count > 0)
            {
                Grilla.DataSource = dt;
                Grilla.DataBind();
                //BtnTaller.Visible = true;
                //btnAgregarTodas.Visible = false;
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "No hay registros para ese filtro";
                //btnAgregarTodas.Visible = true;
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            int escId2 = 0;

            if (escId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe seleccionar un Espacio Curricular";
                return;
            }
            else
            {
                escId2 = Convert.ToInt32(escId.SelectedValue);
            }

            Response.Redirect("EvaluacionesEspCRegistracion.aspx?Id=0&escId="+escId2+"&Anio="+Convert.ToInt32(eceAnioCursado.Text), false);
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
                //string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                //if (AnioCursado.Text == "")
                //{
                //    DateTime fechaActual = DateTime.Today;
                //    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                //}
                //else
                //{
                //    AnioCur = Convert.ToInt32(AnioCursado.Text);
                //}

                if (e.CommandName == "Eliminar")
                {
                    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
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
            if (Session["EvaluacionesEspCurricular.PageIndex"] != null)
            {
                Session["EvaluacionesEspCurricular.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("EvaluacionesEspCurricular.PageIndex", e.NewPageIndex);
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

            ocnRegistracionCalificaciones.EliminarxEvalEspCurr(Id, this.Master.usuId, DateTime.Now);
            ocnEspCurrEvaluacion.Eliminar(Id, this.Master.usuId, DateTime.Now);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(Grilla.PageIndex);
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

    //protected void Nombre_TextChanged(object sender, EventArgs e)
    //{
    //    GrillaCargar(GridView1.PageIndex);
    //}

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        Grilla.DataSource = null;
        Grilla.DataBind();
        GrillaCargar(Grilla.PageIndex);

    }
  protected void btnAgregarTodas_Click (object sender, EventArgs e)
    {
        //Grilla.DataSource = null;
        //Grilla.DataBind();
        //GrillaCargar(Grilla.PageIndex);

    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        Grilla.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }



    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {

        insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
        }
        else
        {

            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);

            if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")
            {
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
            }
        }
    }


    protected void ButtonImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            //String NomRep;
            //Int32 Materia = Convert.ToInt32(escId.SelectedValue.ToString());
            //Int32 curso = Convert.ToInt32(curId.SelectedValue.ToString());
            //Int32 anioLectivo = Convert.ToInt32(AnioCursado.Text.Trim().ToString());

            //NomRep = "InformeListadoCalificacionesxMateriaSec.rpt";

            //FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + Materia + "&curId=" + curso + "&anio=" + anioLectivo + "&NomRep=" + NomRep);
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

    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //insId = Convert.ToInt32(Session["_Institucion"]);
        //DataTable dt5 = new DataTable();
        //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
        //ExamenTipoId.DataValueField = "Valor"; ExamenTipoId.DataTextField = "Texto"; ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]");
        ////(new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerListaxCarxPlaxEsc("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 
        ////Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(escId.SelectedValue));

        //ExamenTipoId.DataBind();

        //if (dt5.Rows.Count > 0)
        //{

        //    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 7)
        //    {
        //        //lblCondicion.Visible = true;
        //        //CondicionId.Visible = true;
        //        dvTaller.Visible = true;
        //        dvGrid.Visible = false;
        //        ExamenTipoId.Visible = false;
        //        lblPeriodo.Visible = false;
        //    }
        //    else
        //    {
        //        dvTaller.Visible = false;
        //        dvGrid.Visible = true;
        //        //lblCondicion.Visible = false;
        //        //CondicionId.Visible = false;
        //        ExamenTipoId.Visible = true;
        //        lblPeriodo.Visible = true;
        //    }
        //}
    }





}