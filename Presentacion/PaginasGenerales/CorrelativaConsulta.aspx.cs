using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CorrelativaConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.Correlativa ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();

    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Correlativa - Consulta";

                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("Seleccionar..", 4); carId.DataBind();

                cotId.DataValueField = "Valor"; cotId.DataTextField = "Texto"; cotId.DataSource = (new GESTIONESCOLAR.Negocio.CorrelatividadTipo()).ObtenerLista("[Seleccionar...]"); cotId.DataBind();

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["CorrelativaConsulta.PageIndex"] == null)
                {
                    Session.Add("CorrelativaConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CorrelativaConsulta.PageIndex"]);
                }
                #endregion
                 
                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]
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
        alerError.Visible = false;
        int insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18")) // Si es administrador o Director veo todas las carreras
        {
            escId2.DataValueField = "Valor"; escId2.DataTextField = "Texto"; escId2.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId2.DataBind();
        }
        else
        {

            //int usuario = Convert.ToInt32(Session["_usuId"].ToString());
            //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);

            //if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11") || (Session["_perId"].ToString() == "15"))
            //{
            //    escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxusuIdyCur("[Seleccionar...]", usuario, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
            //}
        }
    }
    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }




    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carId.SelectedIndex != 0)
        {
            alerError.Visible = false;
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
            }
        }
    }


    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CorrelativaRegistracion.aspx?Id=0", false);
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
        dt = ocnCorrelativa.ObtenerTodo();
        string ArchivoNombre = "CorrelativaConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            Session["CorrelativaConsulta.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion

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

            int esc = 0;
            if (escId2.SelectedValue.ToString() != "" & escId2.SelectedValue.ToString() != "0")
            {
                esc = Convert.ToInt32(escId2.SelectedValue.ToString());
            }
            int cot = 0;
            if (cotId.SelectedValue.ToString() != "" & cotId.SelectedValue.ToString() != "0")
            {
                cot = Convert.ToInt32(cotId.SelectedValue.ToString());
            }


            dt = new DataTable();
            dt = ocnCorrelativa.ObtenerxcarIdxcurIdxescIdxcotId(car, pla, cur, esc, cot, insId);

            if (dt.Rows.Count > 0)
            {
              
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                btnPrint.Visible = true;
                pnlContents.Visible = true;
            }
            else
            {
                this.Grilla.DataSource = null;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                btnPrint.Visible = false;
                pnlContents.Visible = false;
            }


            if (dt.Rows.Count > 0)
            {
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
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
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //ocnCorrelativa.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    ocnCorrelativa = new GESTIONESCOLAR.Negocio.Correlativa(Convert.ToInt32(Id));
                    //ocnCorrelativa.Copiar();
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("CorrelativaRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
            if (Session["CorrelativaConsulta.PageIndex"] != null)
            {
                Session["CorrelativaConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CorrelativaConsulta.PageIndex", e.NewPageIndex);
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

            ocnCorrelativa.Eliminar(Id);

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



    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            int esc = 0;
            if (escId2.SelectedValue.ToString() == "" || escId2.SelectedValue.ToString() == "0")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular";
                return;
            }
            else
            {
                esc = Convert.ToInt32(escId2.SelectedValue.ToString());
            }

            Response.Redirect("CorrelativaConsultaCustom.aspx?Id="+ esc, false);
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

    protected void escId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;

    }
    
}