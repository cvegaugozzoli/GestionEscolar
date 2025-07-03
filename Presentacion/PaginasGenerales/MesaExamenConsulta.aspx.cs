using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MesaExamenConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();

    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.MesaExamen ocnMesaExamen = new GESTIONESCOLAR.Negocio.MesaExamen();
    GESTIONESCOLAR.Negocio.TurnoExamen ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
                this.Master.TituloDelFormulario = " Mesa Examen -Consulta";
                insId = Convert.ToInt32(Session["_Institucion"]);
                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                //TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxDate("[Seleccionar...]", DateTime.Now); TurnoId.DataBind();
                TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();

                int niv = 4; // Terciario

                carId.Enabled = true;
                DataTable dt2 = new DataTable();

                dt2 = ocnCarrera.ObtenerUnoxNivel(niv);

                if (dt2.Rows.Count > 0)
                {
                    carId.DataValueField = "Valor";
                    carId.DataTextField = "Texto";
                    carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", niv);
                    carId.DataBind();                   
                }




                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                //camId.DataValueField = "Valor";
                //camId.DataTextField = "Texto";
                //camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]");
                //camId.DataBind();
                NivelID.SelectedValue = "0";
                carId.SelectedValue = "0";
                plaId.SelectedValue = "0";
                curId.SelectedValue = "0";
                escId.SelectedValue = "0";


                #region PageIndex
                int PageIndex = 0;
                if (this.Session["MesaExamenConsulta.PageIndex"] == null)
                {
                    Session.Add("MesaExamenConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["MesaExamenConsulta.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion

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



    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex != 0)
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
                //GrillaCargar(Grilla.PageIndex);
            }
        }
    }




    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        curIdCargar();
    }


    private void curIdCargar()
    {
        if (curId.SelectedIndex > 0)
        {

            insId = Convert.ToInt32(Session["_Institucion"]);
            if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
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
    }

    //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    Grilla.EditIndex = e.NewEditIndex;
    //    int PageIndex = 0;
    //    PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
    //    GrillaCargar(PageIndex);
    //    Grilla.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
    //    Grilla.Columns[7].Visible = true;
    //    Grilla.Columns[8].Visible = true;

    //}

    //protected void OnCancel(object sender, EventArgs e)
    //{
    //    Grilla.EditIndex = -1;
    //    int PageIndex = 0;
    //    PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
    //    GrillaCargar(PageIndex);

    //}

    //    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    //    {
    //        try
    //        {
    //            insId = Convert.ToInt32(Session["_Institucion"]);
    //            GridViewRow row = Grilla.Rows[e.RowIndex];
    //            int Id = Convert.ToInt32(Grilla.DataKeys[e.RowIndex].Values[0]);

    //            TextBox NroOrden = (TextBox)Grilla.Rows[e.RowIndex].FindControl("txtOrden");
    //            Int32 NroOrden2 = Convert.ToInt32(NroOrden.Text);

    //            ocnEspacioCurricular.ActualizarOrden(insId, Id, NroOrden2);
    //            Grilla.EditIndex = -1;
    //            int PageIndex = 0;
    //            PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);

    //            GrillaCargar(PageIndex);
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //    "</div>";
    //        }
    //    }

    //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grilla, "Edit$" + e.Row.RowIndex);

    //        e.Row.Attributes["style"] = "cursor:pointer";

    //        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
    //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
    //    }
    //}


    private void GrillaCargar(int PageIndex)
    {
        try
        {
            //Session["EspacioCurricularConsulta.PageIndex"] = PageIndex;
            //Session["EspacioCurricularConsulta.carId"] = carId.SelectedValue;
            //Session["EspacioCurricularConsulta.plaId"] = plaId.SelectedValue;
            //Session["EspacioCurricularConsulta.curId"] = curId.SelectedValue;
            ////Session["EspacioCurricularConsulta.camId"] = camId.SelectedValue;
            //Session["EspacioCurricularConsulta.Nombre"] = Nombre.Text.Trim();
            insId = Convert.ToInt32(Session["_Institucion"]);
            alerError.Visible = false;
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 tue = 0;
            if (TurnoId.SelectedValue.ToString() != "" & TurnoId.SelectedValue.ToString() != "0")
            {
                tue = Convert.ToInt32(TurnoId.SelectedValue.ToString());
            }
            Int32 niv = 0;
            if (NivelID.SelectedValue.ToString() != "" & NivelID.SelectedValue.ToString() != "0")
            {
                niv = Convert.ToInt32(NivelID.SelectedValue.ToString());
            }
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
            Int32 cur = 0;
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            Int32 escId2 = 0;
            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                escId2 = Convert.ToInt32(escId.SelectedValue.ToString());
            }

            dt = new DataTable();
            dt = ocnMesaExamen.ObtenerNivxCarxPlanxrCurxEC(tue, car, pla, cur, escId2, chekFch.Checked, txtFchInicio.CalendarDate);


            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                btnGuardarFcha.Visible = true;
btnPrint.Visible = true;
                //btnAgregarMesa.Visible = true;

            }
            else
            {
                this.Grilla.DataSource = null;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                alerError.Visible = true;
                btnGuardarFcha.Visible = false;
                btnPrint.Visible = false;
                lblalerError.Text = "No hay registro para ese filtro";
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
    //    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {

    //            if (btnSeleccionarTodo.Text == "Desmarcar todo")
    //            {
    //                foreach (GridViewRow row in Grilla.Rows)
    //                {
    //                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

    //                    if (check.Checked == true)
    //                    {
    //                        check.Checked = false;
    //                    }
    //                }
    //                btnSeleccionarTodo.Text = "Seleccionar todo";
    //            }
    //            else
    //            {
    //                foreach (GridViewRow row in Grilla.Rows)
    //                {
    //                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

    //                    if (check.Checked == false)
    //                    {
    //                        check.Checked = true;
    //                    }
    //                }
    //                btnSeleccionarTodo.Text = "Desmarcar todo";
    //            }
    //            //BtnGrabar.Enabled = true;
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //    "</div>";
    //        }
    //    }
    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                //if (e.CommandName == "Eliminar")
                //{
                //    //ocnEspacioCurricular.Eliminar(Convert.ToInt32(Id));
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                //    ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(Convert.ToInt32(Id), insId);
                //    //ocnEspacioCurricular.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Ver")
                //{
                //    Response.Redirect("EspacioCurricularRegistracionCustom.aspx?Id=" + Id + "&Ver=1", false);
                //}
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
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["EspacioCurricularConsulta.PageIndex"] != null)
            {
                Session["EspacioCurricularConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("EspacioCurricularConsulta.PageIndex", e.NewPageIndex);
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

            ocnMesaExamen.EliminarxActivo(Id, this.Master.usuId, DateTime.Now  );

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

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }


    protected void btnCorrelativas_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CorrelativaConsulta.aspx", true);

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
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
        int carIdO = 0;
        int plaIdO = 0;
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
            {
                carId.Enabled = true;
                DataTable dt2 = new DataTable();
                int nivel = Convert.ToInt32(NivelID.SelectedValue);
                dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

                if (dt2.Rows.Count > 0)
                {
                    carId.DataValueField = "Valor";
                    carId.DataTextField = "Texto";
                    carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
                    carId.DataBind();

                }
            }
            else// es primario inicial o secundario
            {

                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
                carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
                plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());



                curId.DataValueField = "Valor";
                curId.DataTextField = "Texto";
                curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", plaIdO);
                curId.DataBind();
                carId.Enabled = false;
                plaId.Enabled = false;
                carId.SelectedValue = "0";
                plaId.SelectedValue = "0";
            }
        }
        else
        {
            //alerError.Visible = true;
            //lblError.Text = "No existen registros para ese filtro";
        }
    }

    protected void btnAgregarMesa_Click(object sender, EventArgs e)
    {
        alerError.Visible = false;
        alerError2.Visible = false;

        int Ban = 0;
        foreach (GridViewRow row in Grilla.Rows) //chequeo si al menos seleccionó un esp curr uno para inscribir
        {
            CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;
            if ((check.Checked)) // Si esta seleccionado..
            {
                Ban = 1;
            }
        }

        if (Ban == 1) // sE SELECCIONO AL MENOS UNO
        {
            foreach (GridViewRow row3 in Grilla.Rows)
            {
                CheckBox check3 = row3.FindControl("chkSeleccion2") as CheckBox;
                //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                if ((check3.Checked)) // Si esta seleccionado..
                {
                    DataTable dt = new DataTable();
                    dt = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(Grilla.DataKeys[row3.RowIndex].Values["Id"]));

                    if (dt.Rows.Count == 0)
                    {
                        int Id = 0;
                        ocnMesaExamen = new GESTIONESCOLAR.Negocio.MesaExamen(Id);
                        ocnMesaExamen.meeAnio = DateTime.Now.Year;

                        ocnMesaExamen.meeFecha = txtFchInicio.CalendarDate;
                        ocnMesaExamen.meehora = txtFchInicio.CalendarDate;
                        ocnMesaExamen.tueId = Convert.ToInt32(TurnoId.SelectedValue);
                        ocnMesaExamen.carId = Convert.ToInt32(Grilla.DataKeys[row3.RowIndex].Values["carId"]);
                        ocnMesaExamen.plaId = Convert.ToInt32(Grilla.DataKeys[row3.RowIndex].Values["plaId"]);
                        ocnMesaExamen.escId = Convert.ToInt32(Grilla.DataKeys[row3.RowIndex].Values["Id"]);
                        ocnMesaExamen.curId = Convert.ToInt32(Grilla.DataKeys[row3.RowIndex].Values["curId"]);
                        ocnMesaExamen.meeCantInsc = 0;
                        ocnMesaExamen.meeActivo = true;


                        ocnMesaExamen.meeFechaHoraCreacion = DateTime.Now;
                        ocnMesaExamen.meeFechaHoraUltimaModificacion = DateTime.Now;
                        ocnMesaExamen.usuIdCreacion = this.Master.usuId;
                        ocnMesaExamen.usuIdUltimaModificacion = this.Master.usuId;

                        ocnMesaExamen.Insertar();

                        ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen(Convert.ToInt32(TurnoId.SelectedValue));
                        ocnTurnoExamen.tueCantMesas = ocnTurnoExamen.tueCantMesas + 1;
                        ocnTurnoExamen.Actualizar();
                        alerExito.Visible = true;
                        lblalerExito.Text = "Se crearon las mesas para espacios curriculares seleccionados ..";
                        return;

                    }
                    else
                    {
                        alerError2.Visible = true;
                        lblalerError2.Text = "Hay Espacios Curriculares que ya fueron incorporados ..";
                        return;
                    }

                }

            }
        }
        else
        {
            alerError.Visible = true;
            lblalerError.Text = "No seleccionó ningún registro..";
            return;
        }
    }

    protected void TurnoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TurnoId.SelectedValue == "0")
        {
            alerError.Visible = true;
            lblalerError.Text = "No seleccionó Turno Exámen..";
            return;
        }
        else
        {
            DataTable dt = new DataTable();
            dt = ocnTurnoExamen.ObtenerUno(Convert.ToInt32(TurnoId.SelectedValue));
            txtFchInicio.CalendarDate = Convert.ToDateTime(dt.Rows[0]["tueFchInicio"]);
        }
    }

    protected void chekFch_CheckedChanged(object sender, EventArgs e)
    {
        if (chekFch.Checked == true)
        {
            txtFchInicio.Enabled = true;
        }
        else
        {
            txtFchInicio.Enabled = false;
        }

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("MesaExamenRegistracion.aspx?Id=0", false);
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

    protected void btnGuardarFcha_Click(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        foreach (GridViewRow row in Grilla.Rows)
        {

            int Id = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["Id"]);
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;

            TextBox p = row.FindControl("Fecha1") as TextBox;
            DateTime FecNew = Convert.ToDateTime(p.Text);          

            ocnMesaExamen.ActualizarFch(Id, FecNew,usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

            alerExito.Visible = true;
            lblalerExito.Text = "Datos actualizados..";

            }


        GrillaCargar(Grilla.PageIndex);
    }

    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();

    }
}
