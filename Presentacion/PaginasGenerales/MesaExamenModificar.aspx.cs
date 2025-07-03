using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MesaExamenModificar : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.UsuarioPerfil ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil();
    GESTIONESCOLAR.Negocio.MesaExamenDocente ocnMesaExamenDocente = new GESTIONESCOLAR.Negocio.MesaExamenDocente();

    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["Bandera"] = 0;
                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
                this.Master.TituloDelFormulario = " Mesa Examen - Modificar";
                insId = Convert.ToInt32(Session["_Institucion"]);
                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();
                NivelID.SelectedValue = "4";

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
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    if (Id != 0)
                    {
                        btnAplicar.Text = "Modificar";
                        TurnoId.Enabled = false;
                        txtFchInicio.Enabled = true;
                        NivelID.Enabled = false;
                        carId.Enabled = false;
                        plaId.Enabled = false;
                        curId.Enabled = false;
                        txtAnio.Enabled = false;
                        DataTable dt = new DataTable();
                        //dt = ocnEspacioCurricular.ObtenerUno(ocnMesaExamen.escId, insId);
                        //Nombre.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                        escId.Enabled = false;
                        meeActivo.Enabled = false;


                        ocnMesaExamen = new GESTIONESCOLAR.Negocio.MesaExamen(Id);

                        TurnoId.SelectedValue = Convert.ToString(ocnMesaExamen.tueId);
                        txtFchInicio.CalendarDate = ocnMesaExamen.meeFecha;
                        NivelID.SelectedValue = Convert.ToString(4);
                        carId.SelectedValue = Convert.ToString(ocnMesaExamen.carId);
                        plaId.SelectedValue = Convert.ToString(ocnMesaExamen.plaId);
                        curId.SelectedValue = Convert.ToString(ocnMesaExamen.curId);
                        txtAnio.Text = Convert.ToString(ocnMesaExamen.meeAnio);
                        //DataTable dt = new DataTable();
                        //dt = ocnEspacioCurricular.ObtenerUno(ocnMesaExamen.escId, insId);
                        //Nombre.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                        escId.SelectedValue = Convert.ToString(ocnMesaExamen.escId);
                        meeActivo.Checked = ocnMesaExamen.meeActivo;
                    }
                    else
                    {
                        btnAplicar.Text = "Agregar Mesa";
                        //NivelID.SelectedValue = "0";
                        //TurnoId.SelectedValue = "0";
                        //carId.SelectedValue = "=0";
                        //plaId.SelectedValue = "0";
                        //curId.SelectedValue = "0";
                        //escId.SelectedValue = "0";
                        NivelID.Enabled = true;
                        plaId.Enabled = false;
                        carId.Enabled = true;
                        curId.Enabled = false;
                        escId.Enabled = false;
                    }



                    #region PageIndex
                    int PageIndex = 0;
                    if (this.Session["MesaExamenModificar.PageIndex"] == null)
                    {
                        Session.Add("MesaExamenModificar.PageIndex", 0);
                    }
                    else
                    {
                        PageIndex = Convert.ToInt32(Session["MesaExamenModificar.PageIndex"]);
                    }
                    #endregion

                    #region Variables de sesion para filtros


                    #endregion
                    GrillaProfTribCargar(PageIndex);
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
            Int32 usuEliminar = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
            int meeIdTraer = Convert.ToInt32(Request.QueryString["Id"]);
            ocnMesaExamenDocente.EliminarxActivo(meeIdTraer, usuEliminar, this.Master.usuId, DateTime.Now);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaProfTribCargar(GrillaProfTrib.PageIndex);
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


    private void GrillaProfTribCargar(int PageIndex)
    {
        try
        {

            alerExito2.Visible = false;
            alerError3.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerError2.Visible = false;
            Session["MesaExamenModificar.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            int meeIdTraer = Convert.ToInt32(Request.QueryString["Id"]);
            dt = new DataTable();
            dt = ocnMesaExamenDocente.ObtenerTodoBuscarxmeeId(meeIdTraer);
            this.GrillaProfTrib.DataSource = dt;
            this.GrillaProfTrib.PageIndex = PageIndex;
            this.GrillaProfTrib.DataBind();

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




    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        GrillaBuscarCargar();
    }
    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("UsuarioEspacioCurricularConsulta.aspx", true);
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

    protected void GrillaBuscar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                String usuId = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;
                //String usuId = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                txtUsuId.Text = usuId;
                if (e.CommandName == "Select")
                {
                    ApellidoB.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    NombreB.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    DNIB.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;
                    //perId.SelectedValue = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Controls[1]).Text;
                    //DocId.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    //perId.DataValueField = "Valor"; perId.DataTextField = "Texto";
                    //perId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioPerfil()).ObtenerListaxusuId("[Seleccionar...]", Convert.ToInt32(usuId));
                    //perId.DataBind();

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
    protected void GrillaBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }
    private void GrillaBuscarCargar()
    {
        try
        {
            alerExito2.Visible = false;
            alerError3.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerError2.Visible = false;
            //Session["AlumnoConsulta.PageIndex"] = PageIndex;
            insId = Convert.ToInt32(Session["_Institucion"]);
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnUsuario.ObtenerTodoBuscarxNombrexPerSoloProfTerc(TextBuscar.Text.Trim(), insId);
                this.GrillaBuscar.DataSource = dt;
                //this.Grilla.PageIndex = PageIndex;
                this.GrillaBuscar.DataBind();
            }
            else
            {
                dt = ocnUsuario.ObtenerUnoxDNIxPerSoloProfTerc(TextBuscar.Text.Trim());
                this.GrillaBuscar.DataSource = dt;
                //this.Grilla.PageIndex = PageIndex;
                this.GrillaBuscar.DataBind();
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
                plaId.Enabled = true;
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
                curId.Enabled = true;
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
                escId.Enabled = true;
            }
            else
            {

                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                dt = ocnUsuarioEspacioCurricular.ObtenerxUpeId(upeId);

                if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11") || (Session["_perId"].ToString() == "18") || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")
                {
                    escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
                    escId.Enabled = true;
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



    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
            alerExito2.Visible = false;
            alerError3.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerError2.Visible = false;
            int Id = 0;

            if (txtAnio.Text == "")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Año";
                return;
            }
            if (TurnoId.SelectedValue == "0")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Turno";
                return;
            }

            if (NivelID.SelectedValue == "0")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Nivel";
                return;
            }
            if (carId.SelectedValue == "0")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Caerrera";
                return;
            }

            if (plaId.SelectedValue == "0")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Plan";
                return;
            }
            if (curId.SelectedValue == "0")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Curso";
                return;
            }
            if (escId.SelectedValue == "0")
            {
                alerError2.Visible = true;
                lblalerError2.Text = "Debe ingresar un Espacio Curricular";
                return;
            }

            if (Request.QueryString["Id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                ocnMesaExamen = new GESTIONESCOLAR.Negocio.MesaExamen(Id);
                ocnMesaExamen.meeAnio = DateTime.Now.Year;

                ocnMesaExamen.meeFecha = txtFchInicio.CalendarDate;
                ocnMesaExamen.meehora = txtFchInicio.CalendarDate;
                ocnMesaExamen.tueId = Convert.ToInt32(TurnoId.SelectedValue);
                ocnMesaExamen.carId = Convert.ToInt32(carId.SelectedValue);
                ocnMesaExamen.plaId = Convert.ToInt32(plaId.SelectedValue);
                ocnMesaExamen.escId = Convert.ToInt32(escId.SelectedValue);
                ocnMesaExamen.curId = Convert.ToInt32(curId.SelectedValue);
                ocnMesaExamen.meeActivo = true;
                ocnMesaExamen.meeFechaHoraCreacion = DateTime.Now;
                ocnMesaExamen.meeFechaHoraUltimaModificacion = DateTime.Now;
                ocnMesaExamen.usuIdCreacion = this.Master.usuId;
                ocnMesaExamen.usuIdUltimaModificacion = this.Master.usuId;

                if (Id == 0)
                {
                    DataTable dt = new DataTable();
                    dt = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(escId.SelectedValue));

                    if (dt.Rows.Count == 0)
                    {
                        ocnMesaExamen.meeCantInsc = 0;
                        ocnMesaExamen.Insertar();
                        ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen(Convert.ToInt32(TurnoId.SelectedValue));
                        ocnTurnoExamen.tueCantMesas = ocnTurnoExamen.tueCantMesas + 1;
                        ocnTurnoExamen.Actualizar();
                        alerExito.Visible = true;
                        lblalerExito.Text = "La mesa fue agregada exitosamente..";
                        //Response.Redirect("MesaExamenConsulta.aspx", true);
                    }
                    else
                    {
                        alerError2.Visible = true;
                        lblalerError2.Text = "Ese Espacio Curricular ya fue incorporado en ese Turno..";
                        return;
                    }
                }
                else
                {
                    ocnMesaExamen.Actualizar();
                    //Response.Redirect("MesaExamenConsulta.aspx", true);
                    alerExito.Visible = true;
                    lblalerExito.Text = "La mesa fue actualizada..";
                }
            }
            //else
            //{
            //    alerError2.Visible = true;
            //    lblalerError2.Text = "Ese Espacio Curricular que ya fue incorporado ..";
            //    return;
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

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaBuscar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaBuscar, "Select$" + row.DataItemIndex, true);
            }
        }

        foreach (GridViewRow row in GrillaProfTrib.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaProfTrib, "Select$" + row.DataItemIndex, true);
            }
        }
        base.Render(writer);
    }

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ban;
        if (RbtBuscar.SelectedIndex == 1) //la busqueda será por dni
        {
            ban = 1;

        }
        else
        {
            ban = 0;// la busqueda será por nombre
        }

        Session["Bandera"] = ban;
        //aludni.Text = "";
        //aluNombre.Text = "";
        TextBuscar.Text = "";
    }

    protected void btnAplicarTibunal_Click(object sender, EventArgs e)
    {
        try
        {
            alerExito2.Visible = false;
            alerError3.Visible = false;
            alerExito.Visible = false;
            alerError.Visible = false;
            alerError2.Visible = false;
            int meeIdT = Convert.ToInt32(Request.QueryString["Id"]);
            // Ver si esta profesor en esa mesa

            DataTable dtProfMesa = new DataTable();
            dtProfMesa = ocnMesaExamenDocente.ObtenerUnoxDNIxmeeId(DNIB.Text,meeIdT);

            if (dtProfMesa.Rows.Count > 0)
            {
                alerError3.Visible = true;
                lblalerError3.Text = "Profesor ya forma parte del Tribunal";
            }
            else
            {
                int Id = 0;

              int  meeIdTraer = Convert.ToInt32(Request.QueryString["Id"]);
                ocnMesaExamenDocente = new GESTIONESCOLAR.Negocio.MesaExamenDocente(Id);
                ocnMesaExamenDocente.meeId = meeIdTraer;
                   
                    ocnMesaExamenDocente.usuId = Convert.ToInt32(txtUsuId.Text);

                ocnMesaExamenDocente.mxdActivo = true;

                    /*....usuId = this.Master.usuId;*/


                    ocnMesaExamenDocente.mxdFechaHoraCreacion = DateTime.Now;
                    ocnMesaExamenDocente.mxdFechaHoraUltimaModificacion = DateTime.Now;
                    ocnMesaExamenDocente.usuIdCreacion = this.Master.usuId;
                    ocnMesaExamenDocente.usuIdUltimaModificacion = this.Master.usuId;

                    /*Validaciones*/
                    string MensajeValidacion = "";

                    if (MensajeValidacion.Trim().Length == 0)
                    {
                        if (Id == 0)
                        {
                            //Nuevo
                            ocnMesaExamenDocente.Insertar();
                            alerExito2.Visible = true;
                            lblalerExito2.Text = "Profesor agregado a Tribunal";
                        }
                        else
                        {
                            //Editar
                            ocnMesaExamenDocente.mxdFechaHoraUltimaModificacion = DateTime.Now;
                            ocnMesaExamenDocente.usuIdUltimaModificacion = this.Master.usuId;
                            ocnMesaExamenDocente.Actualizar();
                            alerExito2.Visible = true;
                            lblalerExito2.Text = "Datos Actualizados";
                        }

                    int PageIndex = 0;
                    if (this.Session["MesaExamenModificar.PageIndex"] == null)
                    {
                        Session.Add("MesaExamenModificar.PageIndex", 0);
                    }
                    else
                    {
                        PageIndex = Convert.ToInt32(Session["MesaExamenModificar.PageIndex"]);
                    }
                    GrillaProfTribCargar(PageIndex);
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