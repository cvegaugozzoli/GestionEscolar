using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CursoConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
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
                this.Master.TituloDelFormulario = " Curso - Consulta";
                insId = Convert.ToInt32(Session["_Institucion"]);
                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

                if ((Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // terciario
                {
                    NivelID.SelectedValue = "4";
                    NivelID.Enabled = false;
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
                                carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                                carId.DataBind();

                            }
                        }
                        else// es primario inicial o secundario
                        {

                            //DataTable dt3 = new DataTable();
                            //DataTable dt4 = new DataTable();
                            //dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
                            //carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                            //dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
                            //plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());



                            //curId.DataValueField = "Valor";
                            //curId.DataTextField = "Texto";
                            //curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", plaIdO);
                            //curId.DataBind();
                            //carId.Enabled = false;
                            //plaId.Enabled = false;
                            //carId.SelectedValue = "0";
                            //plaId.SelectedValue = "0";
                        }
                    }
                    else
                    {
                        //alerError.Visible = true;
                        //lblError.Text = "No existen registros para ese filtro";
                    }
                }
                else
                {
                    NivelID.SelectedValue = "0";
                    NivelID.Enabled = true;
                }

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["CursoConsulta.PageIndex"] == null)
                {
                    Session.Add("CursoConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CursoConsulta.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //if (Session["CursoConsulta.Nombre"] != null) { Curso.Text = Session["CursoConsulta.Nombre"].ToString(); } else { Session.Add("CursoConsulta.Nombre", Nombre.Text.Trim()); }
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
        int PageIndex = 0;
        if (this.Session["CursoConsulta.PageIndex"] == null)
        {
            Session.Add("CursoConsulta.PageIndex", 0);
        } 
        else
        {
            PageIndex = Convert.ToInt32(Session["CursoConsulta.PageIndex"]);
        }
        this.Grilla.DataSource = null;
        this.Grilla.PageIndex = PageIndex;
        this.Grilla.DataBind();
        DataTable dt = new DataTable();
        lblCantidadRegistros.Text = "Cantidad de registros: " + "0";
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
        int carIdO = 0;
        int plaIdO = 0;
        int nivel = Convert.ToInt32(NivelID.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
            {
                carId.Enabled = true;
                plaId.Enabled = true;
                DataTable dt2 = new DataTable();
              
                dt2 = ocnCarrera.ObtenerUnoxNivel(nivel);

                if (dt2.Rows.Count > 0)
                {
                    carId.DataValueField = "Valor";
                    carId.DataTextField = "Texto";
                    carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
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
                carId.Enabled = false;
                plaId.Enabled = false;
                carId.DataValueField = "Valor";
                carId.DataTextField = "Texto";
                carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                carId.DataBind();
              

                if (NivelID.SelectedValue == "1")
                {
                   
                    carId.SelectedValue = "1";
                    plaId.DataValueField = "Valor";
                    plaId.DataTextField = "Texto";
                    plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind();
                    plaId.SelectedValue = "1";
                }
                else
                {
                    if (NivelID.SelectedValue == "2")
                    {
                        carId.SelectedValue = "2";
                        plaId.DataValueField = "Valor";
                        plaId.DataTextField = "Texto";
                        plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind();
                        plaId.SelectedValue = "2";
                    }
                    else
                    {
                        if (NivelID.SelectedValue == "3")
                        {
                            carId.SelectedValue = "3";
                            plaId.DataValueField = "Valor";
                            plaId.DataTextField = "Texto";
                            plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                            plaId.DataBind();
                            plaId.SelectedValue = "3";
                        }
                    }
                }
              
            }
        }
        else
        {
            //alerError.Visible = true;
            //lblError.Text = "No existen registros para ese filtro";
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
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CursoRegistracion.aspx?Id=0", false);
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
        dt = ocnCurso.ObtenerTodoBuscarxNombre(Nombre.Text.Trim());
        string ArchivoNombre = "CursoConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["CursoConsulta.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion

            dt = new DataTable();
            dt = ocnCurso.ObtenerTodoBuscarxNombrexPlaId(Nombre.Text.Trim(), Convert.ToInt32(plaId.SelectedValue));

            if (dt.Rows.Count > 0)

            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                UpdatePanel3.Visible = true;
            }
            else
            {
                this.Grilla.DataSource = null;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                UpdatePanel3.Visible = true;
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
                    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Convert.ToInt32(Id));
                    //ocnCurso.Copiar();
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("CursoRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
          
                ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Id);

                ocnCurso.curNombre = curNombre.Text;
                ocnCurso.curActivo = curActivo.Checked;
                ocnCurso.curSeccion = txtSeccion.Text;

                ocnCurso.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                /*....usuId = this.Master.usuId;*/


                ocnCurso.curFechaHoraCreacion = DateTime.Now;
                ocnCurso.curFechaHoraUltimaModificacion = DateTime.Now;
                ocnCurso.usuIdCreacion = this.Master.usuId;
                ocnCurso.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo
                        ocnCurso.Insertar();
                    }
                    else
                    {
                        //Editar
                        ocnCurso.curFechaHoraUltimaModificacion = DateTime.Now;
                        ocnCurso.usuIdUltimaModificacion = this.Master.usuId;
                        ocnCurso.Actualizar();
                    }

                    GrillaCargar(Grilla.PageIndex);
                curNombre.Text = "";
                txtSeccion.Text = "";
                }
                else
                {
                    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
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


}