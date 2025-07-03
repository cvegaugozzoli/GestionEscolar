using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class NotaExamenFinalTerc : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.InscripcionExamen ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();

    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack) 
            {
                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
                int insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Nota Examen Final";
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



                ixaFechaExamenDesde.Enabled = false;
                ixaFechaExamenHasta.Enabled = false;
                //TurnoID.DataValueField = "Valor"; TurnoID.DataTextField = "Texto"; TurnoID.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxDate("[Seleccionar...]", DateTime.Now); TurnoID.DataBind();
                extId.DataValueField = "Valor"; extId.DataTextField = "Texto"; extId.DataSource = (new GESTIONESCOLAR.Negocio.InscripcionExamenTipo()).ObtenerLista("[Seleccionar...]"); extId.DataBind();
                TurnoID.DataValueField = "Valor"; TurnoID.DataTextField = "Texto"; TurnoID.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoID.DataBind();

                //NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                //NivelID.SelectedValue = "4";
                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();
                //txtAnio.Text = Convert.ToString(DateTime.Now.Year);

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
            PanelActaLibro.Visible = false;
            alerError.Visible = false;
            alerExito.Visible = false;
            Session["NotaExamenFinalTerc.PageIndex"] = PageIndex;
            if (TurnoID.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblalerError.Text = "Debe seleccionar un Turno de Examen..";
                return;
            }
            if (carId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblalerError.Text = "Debe seleccionar una Carrera..";
                return;
            }
            if (plaId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblalerError.Text = "Debe seleccionar un Plan..";
                return;
            }
            if (escId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblalerError.Text = "Debe seleccionar un Espacio Curricular..";
                return;
            }
            if (extId.SelectedValue == "0")
            {
                alerError.Visible = true;
                lblalerError.Text = "Debe seleccionar un tipo de examen..";
                return;
            }

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion

            Int32 aplicarfiltrofecha = 0;
            if (aplicafiltrofecha.Checked)
            {
                aplicarfiltrofecha = 1;
            }

            int itpId2 = Convert.ToInt32(extId.SelectedValue);
            int insId = Convert.ToInt32(Session["_Institucion"]);
            //NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

            //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();

            dt = new DataTable();
            dt = ocnInscripcionExamen.ObtenerxConsultaME(Convert.ToInt32(TurnoID.SelectedValue), Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue),
                Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(txtAnio.Text), Convert.ToInt32(escId.SelectedValue), ixaFechaExamenDesde.Text, ixaFechaExamenHasta.Text, aplicarfiltrofecha, itpId2);

            if (dt.Rows.Count > 0)
            {
                //lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString(); this.Grilla.DataSource = dt;
                this.Grilla.DataSource = dt;

                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                PanelActaLibro.Visible = true;
                btnActualizar.Visible = true;
                txtActa.Text = Convert.ToString(dt.Rows[0]["ixaNumeroActa"].ToString());
                if (Convert.ToString(dt.Rows[0]["ixaNumeroLibro"].ToString()) != "")
                {
                    txtLibro.Text = Convert.ToString(dt.Rows[0]["ixaNumeroLibro"].ToString());
                }
            }
            else
            {
                btnActualizar.Visible = false;
                this.Grilla.DataSource = null;
                PanelActaLibro.Visible = false;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                alerError.Visible = true;
                lblalerError.Text = "No hay registros..";
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
            if (Session["NotaExamenFinalTerc.PageIndex"] != null)
            {
                Session["NotaExamenFinalTerc.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("NotaExamenFinalTerc.PageIndex", e.NewPageIndex);
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

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        //if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
        //{
        Grilla.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["NotaExamenFinalTerc.PageIndex"]);
        GrillaCargar(PageIndex);
        Grilla.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
        Grilla.Columns[10].Visible = true;
        Grilla.Columns[11].Visible = true;
        //}
        //else
        //{
        //    LblMensajeErrorGrilla.Text = "No puede modificar notas..";
        //    return;
        //}
    }
    protected void OnCancel(object sender, EventArgs e)
    {
        Grilla.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["NotaExamenFinalTerc.PageIndex"]);
        GrillaCargar(PageIndex);

    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grilla, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }


    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
            //{
            GridViewRow row = Grilla.Rows[e.RowIndex];
            int Id = Convert.ToInt32(Grilla.DataKeys[e.RowIndex].Values[0]);
            int ictId = Convert.ToInt32(Grilla.DataKeys[e.RowIndex].Values[1]);
            TextBox txtCalificacion2 = (TextBox)Grilla.Rows[e.RowIndex].FindControl("txtCalificacion");
            String Calificacion2 = txtCalificacion2.Text;
            ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Id);
            ocnInscripcionExamen.ixaCalificacion = Convert.ToString(Calificacion2);
            ocnInscripcionExamen.ixaFechaHoraUltimaModificacion = DateTime.Now;
            ocnInscripcionExamen.usuIdUltimaModificacion = this.Master.usuId;
            ocnInscripcionExamen.Actualizar();


            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(ictId);

            if (Convert.ToDecimal(Calificacion2) >= 6)
            {
                ocnInscripcionCursadoTerciario.cdnId = 8;
            }
            else
            {
                ocnInscripcionCursadoTerciario.cdnId = 9;
            }


            ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
            ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
            ocnInscripcionCursadoTerciario.Actualizar();
            Grilla.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["NotaExamenFinalTerc.PageIndex"]);
            GrillaCargar(PageIndex);
            //}
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


    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            alerExito.Visible = false;
            foreach (GridViewRow row in Grilla.Rows)
            {
                int Id = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["Id"]);
                int ictId = Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values[1]);
                TextBox txtObserv2 = (TextBox)Grilla.Rows[row.RowIndex].FindControl("txtObserv");
                String Observ = txtObserv2.Text;


                TextBox txtCalificacion2 = (TextBox)Grilla.Rows[row.RowIndex].FindControl("txtCalificacion");
                String Calificacion2 = txtCalificacion2.Text;

                ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Id);
                ocnInscripcionExamen.ixaCalificacion = Convert.ToString(Calificacion2);
                if (txtActa.Text != "")
                {
                    ocnInscripcionExamen.ixaNumeroActa = Convert.ToInt32(txtActa.Text);
                }
                else
                {
                    ocnInscripcionExamen.ixaNumeroActa = 0;
                }
                //ocnInscripcionExamen.ixaNumeroActa = Convert.ToInt32(txtActa.Text);
                ocnInscripcionExamen.ixaNumeroLibro = txtLibro.Text;
                ocnInscripcionExamen.ixaObservacion = Observ;

                ocnInscripcionExamen.ixaFechaHoraUltimaModificacion = DateTime.Now;
                ocnInscripcionExamen.usuIdUltimaModificacion = this.Master.usuId;

                ocnInscripcionExamen.Actualizar();

                // controlar cuantas veces rindió

                DataTable dtContarDesap = new DataTable();
                dtContarDesap = ocnInscripcionExamen.ContarxictIdxEvaFinal(ictId);

                ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(ictId);

                if (ocnInscripcionCursadoTerciario.cdnId == 12) // si es regularizada
                {
                    if (Calificacion2 != "")
                    {
                        if (Calificacion2 == "a")
                        {
                            if (dtContarDesap.Rows.Count == 3)
                            {
                                ocnInscripcionCursadoTerciario.cdnId = 3;
                                ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                ocnInscripcionCursadoTerciario.Actualizar();
                            }
                        }
                        else
                        {
                            if (Convert.ToDecimal(Calificacion2) >= 6)
                            {
                                ocnInscripcionCursadoTerciario.cdnId = 8;
                                ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                ocnInscripcionCursadoTerciario.Actualizar();
                            }
                            else
                            {
                                if (dtContarDesap.Rows.Count == 3)
                                {
                                    ocnInscripcionCursadoTerciario.cdnId = 3;
                                    ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                    ocnInscripcionCursadoTerciario.Actualizar();
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }

                else // SI ES LIBRE
                {
                    if (ocnInscripcionCursadoTerciario.cdnId == 3) // si es Libre
                    {
                        if (Calificacion2 != "")
                        {
                            if (Calificacion2 == "a")
                            {
                            }
                            else
                            {
                                if (Convert.ToDecimal(Calificacion2) >= 6)
                                {
                                    ocnInscripcionCursadoTerciario.cdnId = 8;
                                    ocnInscripcionCursadoTerciario.ictFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnInscripcionCursadoTerciario.usuIdUltimaModificacion = this.Master.usuId;
                                    ocnInscripcionCursadoTerciario.Actualizar();
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
            }

            Grilla.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["NotaExamenFinalTerc.PageIndex"]);
            GrillaCargar(PageIndex);

            alerExito.Visible = true;
            lblExito.Text = "Se actualizaron los datos..";
            //}

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
    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        TurnoID.DataValueField = "Valor"; TurnoID.DataTextField = "Texto"; TurnoID.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoID.DataBind();

    }

    protected void btnNuevoEC_Click(object sender, EventArgs e)
    {
        Grilla.DataSource = null;
        Grilla.DataBind();
        alerError.Visible = false;
        alerExito.Visible = false;
        txtLibro.Text = "";
        txtActa.Text = "";
        escId.SelectedValue = "0";
        extId.SelectedValue = "0";
        PanelActaLibro.Visible = false;
    }

    protected void btnNuevoCarrera_Click(object sender, EventArgs e)
    {
        Grilla.DataSource = null;
        Grilla.DataBind();
        alerError.Visible = false;
        alerExito.Visible = false;
        txtLibro.Text = "";
        txtActa.Text = "";
        escId.SelectedValue = "0";
        extId.SelectedValue = "0";
        plaId.SelectedValue = "0";
        carId.SelectedValue = "0";
        curId.SelectedValue = "0";
        PanelActaLibro.Visible = false;
    }
}