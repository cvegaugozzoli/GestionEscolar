using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MesaExamenRegistracion : System.Web.UI.Page
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
    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
                this.Master.TituloDelFormulario = "Generar Mesa Examen";
                insId = Convert.ToInt32(Session["_Institucion"]);
                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();
                NivelID.SelectedValue = "4";
                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();

                carId.Enabled = true;
                DataTable dt2 = new DataTable();
                int nivel = Convert.ToInt32(NivelID.SelectedValue);
                dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

                if (dt2.Rows.Count > 0)
                {
                    carId.DataValueField = "Valor";
                    carId.DataTextField = "Texto";
                    carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                    carId.DataBind();

                }


                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                //camId.DataValueField = "Valor";
                //camId.DataTextField = "Texto";
                //camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]");
                //camId.DataBind();
                //NivelID.SelectedValue = "0";
                //carId.SelectedValue = "0";
                //plaId.SelectedValue = "0";
                //curId.SelectedValue = "0";
                Nombre.Text = "";

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["EspacioCurricularConsulta.PageIndex"] == null)
                {
                    Session.Add("EspacioCurricularConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                if (Session["EspacioCurricularConsulta.carId"] != null)
                {
                    carId.SelectedValue = Convert.ToString(Session["EspacioCurricularConsulta.carId"]);
                    carIdCargar();
                }
                else
                {
                    Session.Add("EspacioCurricularConsulta.carId", "");
                }
                if (Session["EspacioCurricularConsulta.plaId"] != null)
                {
                    plaId.SelectedValue = Convert.ToString(Session["EspacioCurricularConsulta.plaId"]);
                    plaIdCargar();
                }
                else
                {
                    Session.Add("EspacioCurricularConsulta.plaId", "");
                }
                if (Session["EspacioCurricularConsulta.curId"] != null)
                {
                    curId.SelectedValue = Convert.ToString(Session["EspacioCurricularConsulta.curId"]);
                    curIdCargar();
                }
                else
                {
                    Session.Add("EspacioCurricularConsulta.curId", "");
                }
                //if (Session["EspacioCurricularConsulta.camId"] != null)
                //{
                //    camId.SelectedValue = Convert.ToString(Session["EspacioCurricularConsulta.camId"]);
                //}
                //else
                //{
                //    Session.Add("EspacioCurricularConsulta.camId", "");
                //}
                if (Session["EspacioCurricularConsulta.Nombre"] != null)
                {
                    Nombre.Text = Convert.ToString(Session["EspacioCurricularConsulta.Nombre"]);
                }
                else
                {
                    Session.Add("EspacioCurricular.Nombre", "");
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



    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        alerError.Visible = false;
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

                this.Grilla.DataSource = null;              
                this.Grilla.DataBind();
                btnSeleccionarTodo.Visible = false;
                btnAgregarMesa.Visible = false;
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
            alerError.Visible = false;
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
                this.Grilla.DataSource = null;
                this.Grilla.DataBind();
                btnSeleccionarTodo.Visible = false;
                btnAgregarMesa.Visible = false;
            }
        }
    }




    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        curIdCargar();
        this.Grilla.DataSource = null;
        this.Grilla.DataBind();
        btnSeleccionarTodo.Visible = false;
        btnAgregarMesa.Visible = false;
    }


    private void curIdCargar()
    {
        if (curId.SelectedIndex > 0)
        {
            alerError.Visible = false;
            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            //DataTable dt = new DataTable();
            //dt = ocnCampo.ObtenerListaPorUnCurso("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue));
            //if (dt.Rows.Count > 0)
            //{
            //    camId.DataValueField = "Valor";
            //    camId.DataTextField = "Texto";
            //    camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerListaPorUnCurso("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue));
            //    camId.DataBind();
            //}
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

    protected void OnCancel(object sender, EventArgs e)
    {
        Grilla.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["EspacioCurricularConsulta.PageIndex"]);
        GrillaCargar(PageIndex);

    }

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

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grilla, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";

            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }


    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerError.Visible = false;
            //Session["EspacioCurricularConsulta.PageIndex"] = PageIndex;
            //Session["EspacioCurricularConsulta.carId"] = carId.SelectedValue;
            //Session["EspacioCurricularConsulta.plaId"] = plaId.SelectedValue;
            //Session["EspacioCurricularConsulta.curId"] = curId.SelectedValue;
            ////Session["EspacioCurricularConsulta.camId"] = camId.SelectedValue;
            //Session["EspacioCurricularConsulta.Nombre"] = Nombre.Text.Trim();
            insId = Convert.ToInt32(Session["_Institucion"]);

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            insId = Convert.ToInt32(Session["_Institucion"]); Int32 tueId2 = 0;
            if (TurnoId.SelectedValue.ToString() != "" & TurnoId.SelectedValue.ToString() != "0")
            {
                tueId2 = Convert.ToInt32(TurnoId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblalerError.Text = "Debe seleccionar un Turno..";
                return;
            }
            Int32 niv = 0;
            if (NivelID.SelectedValue.ToString() != "" & NivelID.SelectedValue.ToString() != "0")
            {
                niv = Convert.ToInt32(NivelID.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblalerError.Text = " Debe ingresar un Nivel";
                return;
            }
            Int32 car = 0;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblalerError.Text = " Debe ingresar una carrera";
                return;
            }

            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblalerError.Text = " Debe ingresar un plan";
                return;
            }

            Int32 cur = 0;
            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblalerError.Text = " Debe ingresar un curso";
                return;
            }
            Int32 cam = 0;

            dt = new DataTable();
            dt = ocnEspacioCurricular.ObtenerNivxCarxPlanxrCurxECxME(niv, car, pla, cur, Nombre.Text.Trim(), tueId2, insId);


            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                btnSeleccionarTodo.Visible = true;
                btnAgregarMesa.Visible = true;

            }
            else
            {
                this.Grilla.DataSource = null;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                alerExito.Visible = true;
                lblalerExito.Text = "Se agregaron todas las mesas para ese curso seleccionado..";
                btnSeleccionarTodo.Visible = false;
                btnAgregarMesa.Visible = false;
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
                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

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
                    CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;

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
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //ocnEspacioCurricular.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular(Convert.ToInt32(Id), insId);
                    //ocnEspacioCurricular.Copiar();
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("EspacioCurricularRegistracionCustom.aspx?Id=" + Id + "&Ver=1", false);
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

            ocnEspacioCurricular.Eliminar(Id);

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
        alerError.Visible = false;
        alerError2.Visible = false;
        alerExito.Visible = false;


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

        DataTable dtFchTur = new DataTable();
        dtFchTur = ocnTurnoExamen.ObtenerUno(Convert.ToInt32(TurnoId.SelectedValue));
        DateTime fechaTurnoInicio = Convert.ToDateTime(dtFchTur.Rows[0]["tueFchInicio"]);
        DateTime fechaTurnoFin = Convert.ToDateTime(dtFchTur.Rows[0]["tueFchFin"]);

        if (txtFchInicio.CalendarDate >= fechaTurnoInicio & txtFchInicio.CalendarDate <= fechaTurnoFin)
        {
            if (Ban == 1) // sE SELECCIONO AL MENOS UNO
            {
                foreach (GridViewRow row3 in Grilla.Rows)
                {
                    CheckBox check3 = row3.FindControl("chkSeleccion2") as CheckBox;
                    //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                    if ((check3.Checked)) // Si esta seleccionado..
                    {
                        dt = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(Grilla.DataKeys[row3.RowIndex].Values["Id"]));

                        if (dt.Rows.Count == 0)
                        {
                            int Id = 0;
                            ocnMesaExamen = new GESTIONESCOLAR.Negocio.MesaExamen(Id);
                            ocnMesaExamen.meeAnio = txtFchInicio.CalendarDate.Year;

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
        else
        {
            alerError.Visible = true;
            lblalerError.Text = "La fecha de Mesa no se encuentra entre las fechas de Turno..";
            return;
        }
        GrillaCargar(Grilla.PageIndex);
    }

    protected void TurnoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = ocnTurnoExamen.ObtenerUno(Convert.ToInt32(TurnoId.SelectedValue));
        txtFchInicio.CalendarDate = Convert.ToDateTime(dt.Rows[0]["tueFchInicio"]);
    }

    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();

    }
}