using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InscripcionExamenConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.InscripcionExamen ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();

    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Inscripcion Examen - Consulta";

                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")  // Si es administrador o Director veo todas las carreras
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);

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

                        //lblColegio.Text = "INSTITUTO SUPERIOR SAN JOSÉ";
                    }


                    //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));

                    //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                }
                else
                {

                }

                txtAnio.Text = Convert.ToString(DateTime.Now.Year);

                ixaFechaExamenDesde.Enabled = false;
                ixaFechaExamenHasta.Enabled = false;
                TurnoID.DataValueField = "Valor"; TurnoID.DataTextField = "Texto"; TurnoID.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoID.DataBind();
                extId.DataValueField = "Valor"; extId.DataTextField = "Texto"; extId.DataSource = (new GESTIONESCOLAR.Negocio.InscripcionExamenTipo()).ObtenerLista("[Seleccionar...]"); extId.DataBind();

         txtAnio.Text = Convert.ToString(DateTime.Now.Year);

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["InscripcionExamenConsulta.PageIndex"] == null)
                {
                    Session.Add("InscripcionExamenConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["InscripcionExamenConsulta.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]
                #endregion
                ixaFechaExamenDesde.Text = DateTime.Now.AddDays(-30);  // Convert.ToDateTime(dt.Rows[0]["ixaFechaExamen"].ToString());
                ixaFechaExamenHasta.Text = DateTime.Now;
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("InscripcionExamenRegistracion.aspx?Id=0", false);
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

        int insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
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

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        plaIdCargar();
    }

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        int insId = Convert.ToInt32(Session["_Institucion"]);
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



    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        Int32 aplicarfiltrofecha = 0;
        if (aplicafiltrofecha.Checked)
        {
            aplicarfiltrofecha = 1;
        }
        dt = new DataTable();
        //dt = ocnInscripcionExamen.ObtenerPorAlumnoPorECporPeriodo(alunombre.Text, espaciocurricular.Text, ixaFechaExamenDesde.Text, ixaFechaExamenHasta.Text, aplicarfiltrofecha);
        string ArchivoNombre = "InscripcionExamenConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
         
            Int32 tue = 0;
            if (TurnoID.SelectedValue.ToString() != "" & TurnoID.SelectedValue.ToString() != "0")
            {
                tue = Convert.ToInt32(TurnoID.SelectedValue.ToString());
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



            Int32 aplicarfiltrofecha = 0;
            if (aplicafiltrofecha.Checked)
            {
                aplicarfiltrofecha = 1;
            }

            if (txtAnio.Text == "")
            {
                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
            }




            Session["InscripcionExamenConsulta.PageIndex"] = PageIndex;
            alerError.Visible = false;
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
                   

            int insId = Convert.ToInt32(Session["_Institucion"]);
            //NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

            //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
            int itpId2 = Convert.ToInt32(extId.SelectedValue);
            dt = new DataTable();
            dt = ocnInscripcionExamen.ObtenerxConsultaME(Convert.ToInt32(TurnoID.SelectedValue), Convert.ToInt32(carId.SelectedValue), pla,
               cur, Convert.ToInt32(txtAnio.Text), escId2, ixaFechaExamenDesde.Text, ixaFechaExamenHasta.Text, aplicarfiltrofecha, itpId2);

            if (dt.Rows.Count > 0)
            {
                //lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString(); this.Grilla.DataSource = dt;
                this.Grilla.DataSource = dt;
              
                this.Grilla.PageIndex = PageIndex; 
                this.Grilla.DataBind();
            }
            else
            {
                this.Grilla.DataSource = null;

                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                alerError.Visible = true;
                lblalerError.Text = "No hay registro para ese filtro";
                //lblCantidadRegistros.Text = "Cantidad de registros: 0";
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
        DataTable dt = new DataTable();
        int insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
        int carIdO = 0;
        int plaIdO = 0;
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



    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //ocnInscripcionExamen.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Convert.ToInt32(Id));
                    //ocnInscripcionExamen.Copiar();
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("InscripcionExamenRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
            if (Session["InscripcionExamenConsulta.PageIndex"] != null)
            {
                Session["InscripcionExamenConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("InscripcionExamenConsulta.PageIndex", e.NewPageIndex);
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

            ocnInscripcionExamen.Eliminar(Id);

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

    protected void alunombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void espaciocurricular_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }


    protected void aplicaplicafiltrofecha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (aplicafiltrofecha.Checked)
        {
            ixaFechaExamenDesde.Enabled = true;
            ixaFechaExamenHasta.Enabled = true;
        }
        else
        {
            ixaFechaExamenDesde.Enabled = false;
            ixaFechaExamenHasta.Enabled = false;
        }
    }


    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        TurnoID.DataValueField = "Valor"; TurnoID.DataTextField = "Texto"; TurnoID.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoID.DataBind();

    }
}