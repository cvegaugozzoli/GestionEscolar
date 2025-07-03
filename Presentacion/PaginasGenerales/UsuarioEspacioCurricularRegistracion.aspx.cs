using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioEspacioCurricularRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.Docentes ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.UsuarioPerfil ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil();

    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    int insId;
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Asignar Espacio Curricular";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                Session["Bandera"] = 0;
                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/
                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.TipoCarrera()).ObtenerLista("[Seleccionar...]"); NivelID.DataBind();
                    SituacionId.DataValueField = "Valor"; SituacionId.DataTextField = "Texto"; SituacionId.DataSource = (new GESTIONESCOLAR.Negocio.SituacionPersonal()).ObtenerLista("[Seleccionar...]"); SituacionId.DataBind();


                    //usuId.DataValueField = "Valor"; usuId.DataTextField = "Texto"; usuId.DataSource = (new GESTIONESCOLAR.Negocio.Usuario()).ObtenerLista("[Seleccionar...]"); usuId.DataBind();
                    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                    curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                    ////camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                    escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerLista("[Seleccionar...]", insId); escId.DataBind();


                    if (Id != 0)
                    {
                        ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular(Id);
                        this.uscFchInicio.Text = Convert.ToString((ocnUsuarioEspacioCurricular.uscFchFin.ToString() == null ? "" : ocnUsuarioEspacioCurricular.uscFchFin.ToString()));
                        this.uscFchInicio.Text = Convert.ToString((ocnUsuarioEspacioCurricular.uscFchInicio.ToString() == null ? "" : ocnUsuarioEspacioCurricular.uscFchInicio.ToString()));
                        this.SituacionId.SelectedValue = Convert.ToString(ocnUsuarioEspacioCurricular.sitId);
                        perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); perId.DataBind();

                        this.uscActivo.Checked = ocnUsuarioEspacioCurricular.uscActivo;
                        int upeIdBuscar = ocnUsuarioEspacioCurricular.upeId;
                        dt1 = ocnUsuarioPerfil.ObtenerUno(upeIdBuscar);
                        if (dt1.Rows.Count > 0)
                        {
                            txtUsuId.Text = Convert.ToString(dt1.Rows[0]["usuId"]);
                            dt = ocnUsuario.ObtenerUno(Convert.ToInt32(dt1.Rows[0]["usuId"]));
                            if (Convert.ToInt32(dt.Rows.Count) > 0)
                            {
                                DataTable dtDoc = new DataTable();
                                dtDoc = ocnUsuario.ObtenerUno(Convert.ToInt32(txtUsuId.Text));
                                if (dtDoc.Rows.Count > 0)
                                {
                                    this.ApellidoB.Text = Convert.ToString(dtDoc.Rows[0]["Apellido"]);
                                    this.NombreB.Text = Convert.ToString(dtDoc.Rows[0]["Nombre"]);
                                    this.upeId.Text = Convert.ToString(upeIdBuscar);
                                    perId.SelectedValue = Convert.ToString(dt1.Rows[0]["perId"]);
                                }
                            }

                        }
                        else
                        {
                            //lblCantidadRegistros.Text = "Cantidad de registros: 0";
                        }
                        this.NivelID.SelectedValue = (ocnUsuarioEspacioCurricular.tcaId == 0 ? "" : ocnUsuarioEspacioCurricular.tcaId.ToString());
                        this.carId.SelectedValue = (ocnUsuarioEspacioCurricular.carId == 0 ? "" : ocnUsuarioEspacioCurricular.carId.ToString());
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", Convert.ToInt32(NivelID.SelectedValue)); carId.DataBind();
                        this.plaId.SelectedValue = (ocnUsuarioEspacioCurricular.plaId == 0 ? "" : ocnUsuarioEspacioCurricular.plaId.ToString());
                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue)); plaId.DataBind();

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();

                        this.curId.SelectedValue = (ocnUsuarioEspacioCurricular.curId == 0 ? "" : ocnUsuarioEspacioCurricular.curId.ToString());
                        escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();


                        //this.usuId.SelectedValue = (ocnUsuarioEspacioCurricular.usuId == 0 ? "" : ocnUsuarioEspacioCurricular.usuId.ToString());

                        this.carId.SelectedValue = (ocnUsuarioEspacioCurricular.carId == 0 ? "" : ocnUsuarioEspacioCurricular.carId.ToString());
                        this.plaId.SelectedValue = (ocnUsuarioEspacioCurricular.plaId == 0 ? "" : ocnUsuarioEspacioCurricular.plaId.ToString());
                        this.curId.SelectedValue = (ocnUsuarioEspacioCurricular.curId == 0 ? "" : ocnUsuarioEspacioCurricular.curId.ToString());
                        //this.camId.SelectedValue = (ocnUsuarioEspacioCurricular.camId == 0 ? "" : ocnUsuarioEspacioCurricular.camId.ToString());
                        escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(this.curId.SelectedValue), insId); escId.DataBind();

                        this.escId.SelectedValue = (ocnUsuarioEspacioCurricular.escId == 0 ? "" : ocnUsuarioEspacioCurricular.escId.ToString());

                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    //this.usuId.Focus();
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
                    carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", nivel);
                    carId.DataBind();

                }
            }
            else// es primario inicial o secundario
            {

                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
                if (dt3.Rows.Count > 0)
                {
                    carIdO = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    carId.SelectedValue = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                }


                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(carIdO);
                if (dt4.Rows.Count > 0)
                {
                    plaIdO = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                    plaId.SelectedValue = Convert.ToString(dt4.Rows[0]["Id"].ToString());
                }

                curId.DataValueField = "Valor";
                curId.DataTextField = "Texto";
                curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", carIdO);
                curId.DataBind();
                carId.Enabled = false;
                plaId.Enabled = false;
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

    private void GrillaBuscarCargar()
    {
        try
        {
            //Session["AlumnoConsulta.PageIndex"] = PageIndex;
            insId = Convert.ToInt32(Session["_Institucion"]);
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnUsuario.ObtenerTodoBuscarxNombrexPerTerc(TextBuscar.Text.Trim(), insId);
                this.GrillaBuscar.DataSource = dt;
                //this.Grilla.PageIndex = PageIndex;
                this.GrillaBuscar.DataBind();
            }
            else
            {
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "15"))// Si es administrador o Director o AdminSj veo todas las carreras
                {
                    dt = ocnUsuario.ObtenerUnoxDNI(TextBuscar.Text.Trim());
                    this.GrillaBuscar.DataSource = dt;
                    //this.Grilla.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();
                }
                else
                {
                    if (Session["_perId"].ToString() == "18" || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es del Nivel Superior
                    {
                        dt = ocnUsuario.ObtenerUnoxDNIxPerTerc(TextBuscar.Text.Trim());
                        this.GrillaBuscar.DataSource = dt;
                        //this.Grilla.PageIndex = PageIndex;
                        this.GrillaBuscar.DataBind();
                    }
                }
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
        base.Render(writer);
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
                    //upeId.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;
                    //perId.SelectedValue = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Controls[1]).Text;
                    //DocId.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    perId.DataValueField = "Valor"; perId.DataTextField = "Texto";
                    perId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioPerfil()).ObtenerListaxusuId("[Seleccionar...]", Convert.ToInt32(usuId));
                    perId.DataBind();

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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        GrillaBuscarCargar();
    }

    protected void GrillaBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
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
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            int upeIdC = Convert.ToInt32(upeId.Text);
            int tcaIdC = Convert.ToInt32((NivelID.SelectedValue.Trim() == "" ? "0" : NivelID.SelectedValue));
            int carIdC = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
            int plaIdC = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
            int curIdC = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
            int escIdC = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue));
            DataTable dt3 = new DataTable();

            dt3 = ocnUsuarioEspacioCurricular.ObtenerUnoControlExiste(upeIdC, carIdC, plaIdC, curIdC, escIdC);
            if (dt3.Rows.Count == 0)// Si no hay docente titular en ese espacio Asisgno
            {

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular(Id);

                    ocnUsuarioEspacioCurricular.upeId = Convert.ToInt32(upeId.Text);

                    ocnUsuarioEspacioCurricular.uscFchFin = Convert.ToDateTime(uscFchFin.Text == "" ? null : uscFchFin.Text);
                    ocnUsuarioEspacioCurricular.uscFchInicio = Convert.ToDateTime(uscFchInicio.Text);
                    ocnUsuarioEspacioCurricular.uscActivo = uscActivo.Checked;
                    ocnUsuarioEspacioCurricular.tcaId = Convert.ToInt32((NivelID.SelectedValue.Trim() == "" ? "0" : NivelID.SelectedValue));
                    ocnUsuarioEspacioCurricular.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
                    ocnUsuarioEspacioCurricular.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                    ocnUsuarioEspacioCurricular.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
                    ocnUsuarioEspacioCurricular.sitId = Convert.ToInt32((SituacionId.SelectedValue.Trim() == "" ? "0" : SituacionId.SelectedValue));
                    ocnUsuarioEspacioCurricular.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue));
                    /*....usuId = this.Master.usuId;*/


                    ocnUsuarioEspacioCurricular.uscFechaHoraCreacion = DateTime.Now;
                    ocnUsuarioEspacioCurricular.uscFechaHoraUltimaModificacion = DateTime.Now;
                    ocnUsuarioEspacioCurricular.usuIdCreacion = this.Master.usuId;
                    ocnUsuarioEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;

                    /*Validaciones*/
                    string MensajeValidacion = "";

                    if (MensajeValidacion.Trim().Length == 0)
                    {
                        if (Id == 0)
                        {
                            if ((Convert.ToInt32(perId.SelectedValue) != 1) || (Convert.ToInt32(perId.SelectedValue) != 6) || (Convert.ToInt32(perId.SelectedValue) != 9))// Distinto a Admin Directora o Secretaria
                            {
                                if (curId.SelectedValue.Trim() != "")
                                {
                                    if ((Convert.ToInt32(perId.SelectedValue) != 2) || (Convert.ToInt32(perId.SelectedValue)) != 5)
                                    {
                                        if (escId.SelectedValue.Trim() != "")
                                        {
                                            //Nuevo
                                            ocnUsuarioEspacioCurricular.Insertar();
                                        }
                                        else
                                        {
                                            Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                                            lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Carga</a><br/>
       Debe ingresar un Espacio Curricular<br/>";
                                        }
                                    }
                                    else
                                    {
                                        ocnUsuarioEspacioCurricular.Insertar();
                                    }
                                }
                                else
                                {
                                    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Carga</a><br/>
       Debe ingresar un Curso<br/>";
                                }
                            }

                            else
                            {
                                ocnUsuarioEspacioCurricular.Insertar();
                            }
                            Response.Redirect("UsuarioEspacioCurricularConsulta.aspx", true);

                        }
                        else
                        {
                            //Editar
                            ocnUsuarioEspacioCurricular.uscFechaHoraUltimaModificacion = DateTime.Now;
                            ocnUsuarioEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;
                            ocnUsuarioEspacioCurricular.Actualizar();


                            Response.Redirect("UsuarioEspacioCurricularConsulta.aspx", true);
                        }
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

                else
                {
                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Carga</a><br/>
       El docente ya fue asignado a ese espacio Curricular o curso..o<br/>";

                }

            }
            else
            {

                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (Id == 0)
                {
                    alerError.Visible = true;
                    lblError.Text = "Ya existe docente en ese espacio..";
                }
                else
                {
                    ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular(Id);

                    ocnUsuarioEspacioCurricular.upeId = Convert.ToInt32(upeId.Text);

                    ocnUsuarioEspacioCurricular.uscFchFin = Convert.ToDateTime(uscFchFin.Text == "" ? null : uscFchFin.Text);
                    ocnUsuarioEspacioCurricular.uscFchInicio = Convert.ToDateTime(uscFchInicio.Text);
                    ocnUsuarioEspacioCurricular.uscActivo = uscActivo.Checked;
                    ocnUsuarioEspacioCurricular.tcaId = Convert.ToInt32((NivelID.SelectedValue.Trim() == "" ? "0" : NivelID.SelectedValue));
                    ocnUsuarioEspacioCurricular.carId = Convert.ToInt32((carId.SelectedValue.Trim() == "" ? "0" : carId.SelectedValue));
                    ocnUsuarioEspacioCurricular.plaId = Convert.ToInt32((plaId.SelectedValue.Trim() == "" ? "0" : plaId.SelectedValue));
                    ocnUsuarioEspacioCurricular.curId = Convert.ToInt32((curId.SelectedValue.Trim() == "" ? "0" : curId.SelectedValue));
                    ocnUsuarioEspacioCurricular.sitId = Convert.ToInt32((SituacionId.SelectedValue.Trim() == "" ? "0" : SituacionId.SelectedValue));
                    ocnUsuarioEspacioCurricular.escId = Convert.ToInt32((escId.SelectedValue.Trim() == "" ? "0" : escId.SelectedValue));
                    /*....usuId = this.Master.usuId;*/
                    ocnUsuarioEspacioCurricular.uscFechaHoraUltimaModificacion = DateTime.Now;
                    ocnUsuarioEspacioCurricular.usuIdUltimaModificacion = this.Master.usuId;
                    ocnUsuarioEspacioCurricular.Actualizar();
                    Response.Redirect("UsuarioEspacioCurricularConsulta.aspx", true);
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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
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
            if (Convert.ToInt32(dt.Rows[1]["TipoCarrera"]) != 4)
            {
                //camId.Enabled = false;
                //escId.Enabled = false;
            }
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


    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        escId.Enabled = true;
        insId = Convert.ToInt32(Session["_Institucion"]);
        if (perId.SelectedValue == "1" || perId.SelectedValue == "6" || perId.SelectedValue == "18" || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
        }
        else
        {
            if ((perId.SelectedValue == "2")) // Docente grado o preceptora
            {
                escId.Enabled = false;
            }
            else // elige espacio curricular
            {
                int usuarioIni = Convert.ToInt32(txtUsuId.Text);
                DataTable dt2 = new DataTable();
                dt2 = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(usuarioIni, Convert.ToInt32(perId.SelectedValue));

                if (dt2.Rows.Count > 0)
                {
                    //    dt = ocnUsuarioEspacioCurricular.ObtenerxUpeId(Convert.ToInt32(dt2.Rows[0]["Id"]));
                    //}

                    if (perId.SelectedValue == "4" || perId.SelectedValue == "11" || perId.SelectedValue == "18" || perId.SelectedValue == "5" || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "22" || Session["_perId"].ToString() == "24")
                    {
                        escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();

                        //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", Convert.ToInt32(dt2.Rows[0]["Id"]), Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
                    }
                }
            }

        }
    }

    protected void perId_SelectedIndexChanged(object sender, EventArgs e)
    {
        int usuIdSelec = Convert.ToInt32(txtUsuId.Text);
        dt = ocnUsuarioPerfil.ObtenerTodoxusuIdxPerId(usuIdSelec, Convert.ToInt32(perId.SelectedValue));
        if (dt.Rows.Count > 0)
        {
            upeId.Text = Convert.ToString(dt.Rows[0]["Id"]);
        }

    }
}








