using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InscripcionExamenRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.InscripcionExamen ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.FormatoDictado ocnFormatoDictado = new GESTIONESCOLAR.Negocio.FormatoDictado();
    GESTIONESCOLAR.Negocio.InscripcionExamenTipo ocnInscripcionExamenTipo = new GESTIONESCOLAR.Negocio.InscripcionExamenTipo();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.MesaExamen ocnMesaExamen = new GESTIONESCOLAR.Negocio.MesaExamen();
    GESTIONESCOLAR.Negocio.TurnoExamen ocnTurnoExamen = new GESTIONESCOLAR.Negocio.TurnoExamen();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();


    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Inscripcion Examen - Registracion";
                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                btnAceptar1.Visible = false;
                if (Request.QueryString["Ver"] != null)
                {
                    btnNuevoAlumno.Visible = false;
                    btnBorrarTodo.Visible = false;
                    btnAceptar1.Visible = false;
                }
                TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();

                NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                //camId.DataValueField = "Valor"; camId.DataTextField = "Texto"; camId.DataSource = (new GESTIONESCOLAR.Negocio.Campo()).ObtenerLista("[Seleccionar...]"); camId.DataBind();
                NivelID.SelectedValue = "4";
                NivelID.Enabled = false;
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", Convert.ToInt32(NivelID.SelectedValue)); carId.DataBind();
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerLista("[Seleccionar...]"); plaId.DataBind();
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerLista("[Seleccionar...]"); curId.DataBind();
                //fodId.DataValueField = "Valor"; fodId.DataTextField = "Texto"; fodId.DataSource = (new GESTIONESCOLAR.Negocio.FormatoDictado()).ObtenerLista("[Seleccionar...]"); fodId.DataBind();
                //extId.DataValueField = "Valor"; extId.DataTextField = "Texto"; extId.DataSource = (new GESTIONESCOLAR.Negocio.InscripcionExamenTipo()).ObtenerLista("[Seleccionar...]"); extId.DataBind();
                //itpId.DataValueField = "Valor"; itpId.DataTextField = "Texto"; itpId.DataSource = (new GESTIONESCOLAR.Negocio.InscripcionExamenTipo()).ObtenerLista("[Seleccionar...]"); itpId.DataBind();

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    /*INCIALIZADORES*/
                    if (Id != 0)
                    {

                        DataTable dt = new DataTable();
                        dt = ocnInscripcionExamen.ObtenerUnoPorAlumno(Id);
                        if (dt.Rows.Count > 0)
                        {
                            //ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Id);
                            this.ixaFechaExamen.Text = Convert.ToDateTime(dt.Rows[0]["ixaFechaExamen"].ToString()); //   ocnInscripcionExamen.ixaFechaExamen;
                            Decimal calificacion = 0;
                            calificacion = Convert.ToDecimal(dt.Rows[0]["Calificacion"].ToString());   // FuncionesUtiles.StringToDecimal(
                            //this.ixaCalificacion.Text = FuncionesUtiles.DecimalToString(calificacion); // FuncionesUtiles.DecimalToString(ocnInscripcionExamen.ixaCalificacion);
                            //this.ixaNumeroActa.Text = dt.Rows[0]["ixaNumeroActa"].ToString();  // ocnInscripcionExamen.ixaNumeroActa.ToString();
                            //this.ixaNumeroLibro.Text = dt.Rows[0]["ixaNumeroLibro"].ToString();
                            //this.icuActivo.Checked = ocnInscripcionCursado.icuActivo;
                            if (dt.Rows[0]["ixaActivo"].ToString() == "1")
                            {
                                this.ixaActivo.Checked = true;  //  ocnInscripcionExamen.ixaActivo;
                            }
                            else
                            {
                                this.ixaActivo.Checked = false;  //  ocnInscripcionExamen.ixaActivo;
                            }
                            this.carId.SelectedValue = dt.Rows[0]["carId"].ToString();  // (ocnInscripcionExamen.carId == 0 ? "" : ocnInscripcionExamen.carId.ToString());
                            this.plaId.SelectedValue = dt.Rows[0]["plaId"].ToString();  // (ocnInscripcionExamen.plaId == 0 ? "" : ocnInscripcionExamen.plaId.ToString());
                            this.curId.SelectedValue = dt.Rows[0]["curId"].ToString();  //  (ocnInscripcionExamen.curId == 0 ? "" : ocnInscripcionExamen.curId.ToString());
                            //this.camId.SelectedValue = dt.Rows[0]["camId"].ToString();  //  (ocnInscripcionExamen.camId == 0 ? "" : ocnInscripcionExamen.camId.ToString());
                            //this.escId.SelectedValue = dt.Rows[0]["escId"].ToString();  //  (ocnInscripcionExamen.escId == 0 ? "" : ocnInscripcionExamen.escId.ToString());
                            //this.extId.SelectedValue = dt.Rows[0]["extId"].ToString();  // (ocnInscripcionExamen.extId == 0 ? "" : ocnInscripcionExamen.extId.ToString());
                            //this.itpId.SelectedValue = dt.Rows[0]["itpId"].ToString();  // (ocnInscripcionExamen.extId == 0 ? "" : ocnInscripcionExamen.extId.ToString());

                            //this.fodId.SelectedValue = (ocnInscripcionExamen.fodId == 0 ? "" : ocnInscripcionExamen.fodId.ToString());
                            this.aluId.Text = dt.Rows[0]["aluId"].ToString();  //  ocnInscripcionExamen.aluId.ToString();
                            this.aluNombre.Text = dt.Rows[0]["Alumno"].ToString();
                            //this.fodId.SelectedValue = dt.Rows[0]["fodId"].ToString();
                            this.aludni.Text = dt.Rows[0]["AluDNI"].ToString();
                            //this.aluLegajoNumero.Text = dt.Rows[0]["AluLegNro"].ToString();
                            this.carId.Enabled = false;
                            this.plaId.Enabled = false;
                            this.curId.Enabled = false;
                            //this.camId.Enabled = false;
                            //this.escId.Enabled = false;
                            //this.extId.Enabled = false;
                            //this.fodId.Enabled = false;
                            this.aludni.Enabled = false;
                            this.aluNombre.Enabled = false;
                            //this.aluLegajoNumero.Enabled = false;
                            //this.itpId.Enabled = false;

                            //btnBuscar.Enabled = false;
                            btnCancelarAlumno.Enabled = false;
                            //this.ixaCalificacion.Focus();

                        }
                        /*Editar Habilitado*/
                    }
                    else
                    {
                        ixaFechaExamen.Text = DateTime.Now;
                        /*Nuevo Habilitado*/
                        /*cLoadNuevoCustom*/
                        this.aluId.Focus();
                    }
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

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ban;
        if (RbtBuscar.SelectedIndex == 1) //la busqueda será por familiar
        {
            ban = 1;
        }
        else
        {
            ban = 0;// la busqueda será por Hermano
        }
        Session["Bandera"] = ban;
        aludni.Text = "";
        aluNombre.Text = "";
        TextBuscar.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        CanReg.Visible = false;

        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["IncripcionExamenRegistracion.PageIndex"]);
        GrillaCargar(PageIndex);
    }


    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in Grilla.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(Grilla, "Select$" + row.RowIndex, true);
            }
        }
        foreach (GridViewRow row in GrillaMateriasLibre.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                //row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaMateriasLibre, "Select$" + row.RowIndex, true);
            }
        }
        foreach (GridViewRow row in GrillaMateriasReg.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                //row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaMateriasLibre, "Select$" + row.RowIndex, true);
            }
        }
        base.Render(writer);
    }

    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
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

    private void GrillaCargarMaterias(int PageIndex)
    {
        try
        {
            alerError2.Visible = false;
            alerExito.Visible = false;
            alerMAteria.Visible = false;
            alerMatRepe.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            alerError2.Visible = false;
            PanelRegular.Visible = false;
            PanelLibre.Visible = false;
            int ControlFaltaCorrelativa = 1;
            if (aluId.Text.Trim() == "")
            {
                alerError2.Visible = true;
                lblError2.Text = "Debe seleccionar un alumno..";
                return;
            }
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("escId", typeof(int));
            dtNew.Columns.Add("Nombre", typeof(String));
            dtNew.Columns.Add("FormatoDictado", typeof(String));
            dtNew.Columns.Add("Regimen", typeof(String)); dtNew.Columns.Add("Condicion", typeof(String));
            dtNew.Columns.Add("Id", typeof(int));

            DataTable dtNewReg = new DataTable();
            dtNewReg.Columns.Add("escId2", typeof(int));
            dtNewReg.Columns.Add("Nombre2", typeof(String));
            dtNewReg.Columns.Add("FormatoDictado2", typeof(String));
            dtNewReg.Columns.Add("Regimen2", typeof(String)); dtNewReg.Columns.Add("Condicion2", typeof(String));
            dtNewReg.Columns.Add("Id2", typeof(int));

            int Ban = 0;
            //dtNew = Session["TablaMatConf"] as DataTable;
            if (NivelID.SelectedValue == "4")
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                DataTable dt = new DataTable();

                if (curId.SelectedValue != "")
                {
                    DataTable dtTraeEspLibres = new DataTable();
                    if (Convert.ToString(aluId.Text.Trim().ToString()) != "")
                    {
                        dt = ocnInscripcionCursadoTerciario.ObtenerUnoxRegular(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue),
            Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(aluId.Text.Trim().ToString()));
                        dtTraeEspLibres = ocnInscripcionCursadoTerciario.ObtenerxLibre(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue),
                    Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(aluId.Text.Trim().ToString()));
                        if (dtTraeEspLibres.Rows.Count > 0)
                        {
                            foreach (DataRow rowFilaLibre in dtTraeEspLibres.Rows)
                            {
                                //Traer Correlativas para rendir del Espacio Curricular que estoy inscribiendo 
                                DataTable dt1 = new DataTable();
                                DataTable dt4 = new DataTable();
                                DataTable dt5 = new DataTable();
                                //String EspCurricular = "";

                                dt1 = ocnEspacioCurricular.ObtenerCorrelativasxRendir(Convert.ToInt32(rowFilaLibre["escId"].ToString()), insId);
                                if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                {
                                    // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                    foreach (DataRow row in dt1.Rows)
                                    {
                                        dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoxAprobadooProm(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(row["Id"].ToString()));
                                        if (dt4.Rows.Count != 0)
                                        {
                                            //ControlFaltaCorrelativa = 1;
                                        }
                                        else
                                        {
                                            //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]), insId);
                                            //EspCurricular = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                            ControlFaltaCorrelativa = 0;
                                        }
                                    }
                                }
                                else // No hay correlativas
                                {
                                    ControlFaltaCorrelativa = 1;
                                }

                                if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                                {
                                    DataTable dtMesa = new DataTable();
                                    dtMesa = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(rowFilaLibre["escId"].ToString()));
                                    if (dtMesa.Rows.Count > 0)
                                    {
                                        Int32 meeIdMesa = Convert.ToInt32(dtMesa.Rows[0]["meeId"].ToString());

                                        DataTable dtInsEx = new DataTable();
                                        dtInsEx = ocnInscripcionExamen.ObtenerUnoxictIdxmeeId(Convert.ToInt32(rowFilaLibre["Id"].ToString()), meeIdMesa);
                                        if (dtInsEx.Rows.Count == 0)
                                        {
                                            DataRow row1 = dtNew.NewRow();
                                            row1["escId"] = Convert.ToInt32(rowFilaLibre["escId"].ToString());
                                            row1["Nombre"] = Convert.ToString(rowFilaLibre["Nombre"].ToString());
                                            row1["FormatoDictado"] = Convert.ToString(rowFilaLibre["FormatoDictado"].ToString());
                                            row1["Regimen"] = Convert.ToString(rowFilaLibre["Regimen"].ToString());
                                            row1["Condicion"] = Convert.ToString(rowFilaLibre["Condicion"].ToString());
                                            //row1["Condicion"] = Convert.ToString(GrillaMaterias.DataKeys[row.RowIndex].Values["Condicion"]);
                                            row1["Id"] = Convert.ToInt32(rowFilaLibre["Id"].ToString());
                                            dtNew.Rows.Add(row1);
                                        }
                                    }
                                }
                            }

                            if (dtNew.Rows.Count > 0)
                            {
                                GrillaMateriasLibre.DataSource = dtNew;
                                GrillaMateriasLibre.DataBind();
                                PanelLibre.Visible = true;
                                btnSeleccionarTodo2.Visible = true;
                                TituloMaterisLbre.Visible = true;
                                btnAceptar1.Visible = true;
                                //AgregarMateriaLibre.Visible = true;}
                            }
                            else
                            {
                                GrillaMateriasLibre.DataSource = null;
                                GrillaMateriasLibre.DataBind();
                                PanelLibre.Visible = false;
                                btnSeleccionarTodo2.Visible = false;
                            }
                        }

                        else
                        {
                            GrillaMateriasLibre.DataSource = null;
                            GrillaMateriasLibre.DataBind();
                            PanelLibre.Visible = false;
                            btnSeleccionarTodo2.Visible = false;
                        }
                        //Session.Add("TablaMatConf", dtTraeEspLibres);

                        dt = ocnInscripcionCursadoTerciario.ObtenerUnoxRegular(Convert.ToInt32(carId.SelectedValue), Convert.ToInt32(plaId.SelectedValue),
                    Convert.ToInt32(curId.SelectedValue), Convert.ToInt32(aluId.Text.Trim().ToString()));
                        ControlFaltaCorrelativa = 1;
                        if (dt.Rows.Count > 0)
                        {
                            DataTable dt1 = new DataTable();
                            DataTable dt4 = new DataTable();
                            DataTable dt5 = new DataTable();
                            //String EspCurricular = "";

                            foreach (DataRow rowFilaReg in dt.Rows)
                            {
                                int escVer = Convert.ToInt32(rowFilaReg["escId"].ToString());
                                dt1 = ocnEspacioCurricular.ObtenerCorrelativasxRendir(Convert.ToInt32(rowFilaReg["escId"].ToString()), insId);
                                if (dt1.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                {
                                    // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                    foreach (DataRow row in dt1.Rows)
                                    {
                                        dt4 = ocnInscripcionCursadoTerciario.ObtenerUnoxAprobadooProm(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(row["Id"].ToString()));
                                        if (dt4.Rows.Count != 0)
                                        {
                                            ControlFaltaCorrelativa = 1;
                                        }
                                        else
                                        {
                                            //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(GrillaMaterias.DataKeys[row3.RowIndex].Values["Id"]), insId);
                                            //EspCurricular = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                                            ControlFaltaCorrelativa = 0;
                                        }
                                    }
                                }
                                else // No hay correlativas
                                {
                                    ControlFaltaCorrelativa = 1;
                                }

                                if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Inserto Ins. CursadoT
                                {
                                    DataTable dtMesa = new DataTable();
                                    dtMesa = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(rowFilaReg["escId"].ToString()));
                                    if (dtMesa.Rows.Count > 0)
                                    {
                                        Int32 meeIdMesa = Convert.ToInt32(dtMesa.Rows[0]["meeId"].ToString());

                                        DataTable dtInsEx = new DataTable();
                                        dtInsEx = ocnInscripcionExamen.ObtenerUnoxictIdxmeeId(Convert.ToInt32(rowFilaReg["Id"].ToString()), meeIdMesa);
                                        if (dtInsEx.Rows.Count == 0)
                                        {
                                            DataRow row1 = dtNewReg.NewRow();
                                            row1["escId2"] = Convert.ToInt32(rowFilaReg["escId"].ToString());
                                            row1["Nombre2"] = Convert.ToString(rowFilaReg["Nombre"].ToString());
                                            row1["FormatoDictado2"] = Convert.ToString(rowFilaReg["FormatoDictado"].ToString());
                                            row1["Regimen2"] = Convert.ToString(rowFilaReg["Regimen"].ToString());
                                            row1["Condicion2"] = Convert.ToString(rowFilaReg["Condicion"].ToString());
                                            row1["Id2"] = Convert.ToInt32(rowFilaReg["Id"].ToString());
                                            dtNewReg.Rows.Add(row1);
                                        }
                                    }

                                    else
                                    {
                                        alerError2.Visible = true;
                                        lblError2.Text = "No se realizó la asignación de mesas a ese llamado..";
                                        return;
                                    }
                                }
                            }

                            if (dtNewReg.Rows.Count > 0)
                            {
                                btnAceptar1.Visible = true;
                                this.GrillaMateriasReg.DataSource = dtNewReg;
                                this.GrillaMateriasReg.DataBind();
                                PanelRegular.Visible = true;
                                btnSeleccionarTodo.Visible = true;
                                tituloMateria.Visible = true;
                                tituloMateria.Visible = true;
                            }
                            else
                            {
                                this.GrillaMateriasReg.DataSource = null;
                                this.GrillaMateriasReg.DataBind();
                                PanelRegular.Visible = false;
                                btnSeleccionarTodo.Visible = false;
                                tituloMateria.Visible = false;
                            }
                        }
                        else
                        {
                            this.GrillaMateriasReg.DataSource = null;
                            this.GrillaMateriasReg.DataBind();
                            PanelRegular.Visible = false;
                            btnSeleccionarTodo.Visible = false;
                            tituloMateria.Visible = false;

                        }

                        if (GrillaMateriasReg.Rows.Count == 0)
                        {
                            this.GrillaMateriasReg.DataSource = null;
                            this.GrillaMateriasReg.DataBind();
                            PanelRegular.Visible = false;
                            btnSeleccionarTodo.Visible = false;
                            tituloMateria.Visible = false;

                            if (GrillaMateriasLibre.Rows.Count == 0)
                            {
                                this.GrillaMateriasLibre.DataSource = null;
                                this.GrillaMateriasLibre.DataBind();
                                PanelLibre.Visible = false;
                                btnSeleccionarTodo.Visible = false;
                                tituloMateria.Visible = false;
                                alerExito.Visible = true;
                                lblalerExito.Text = "No tiene Materias para rendir o ya se realizó inscripción a ese examen";
                                btnAceptar1.Visible = false;
                            }
                        }
                    }
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


    private void GrillaCargar(int PageIndex)
    {
        try
        {
            CanReg.Visible = false;
            Session["InscripcionCursadoRegistracion.PageIndex"] = PageIndex;
            DataTable dt = new DataTable();
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnAlumno.ObtenerTodoBuscarxNombre(TextBuscar.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
                }
                else
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "No se encuentra Alumno con esa descripción o DNI";
                }
            }
            else
            {
                dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
                }
                else
                {
                    CanReg.Visible = true;
                    lblCantidadRegistros2.Text = "No se encuentra Alumno con esa descripción o DNI";
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

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                String Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                if (e.CommandName == "Select")
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    aluNombre.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    aluNombre.Enabled = false;
                    aludni.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    aludni.Enabled = false;
                    aluId.Text = Id;
                    CanReg.Visible = false;
                    Grilla.DataSource = null;
                    Grilla.DataBind();


                    DataTable dtTraerConcepto = new DataTable();
                    dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 1, Convert.ToInt32(txtAnio.Text));
                    DataTable dtConceptoPago = new DataTable();

                    if (dtTraerConcepto.Rows.Count > 0)
                    {
                        dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                    }
                    else
                    {
                        dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxinstxAluIdxcntIdxAnio(insId, Convert.ToInt32(aluId.Text.Trim().ToString()), 5, Convert.ToInt32(txtAnio.Text));

                        if (dtTraerConcepto.Rows.Count > 0)
                        {
                            dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                        }
                        else
                        {
                            alerError2.Visible = true;
                            lblError2.Text = "El alumno debe registrar el concepto de Matricula o Inscripción a Exámen..";
                            curId.Enabled = false;
                            return;
                        }
               
                    }

                    if (dtConceptoPago.Rows.Count > 0)
                    {
                        Grilla.DataSource = null;
                        Grilla.DataBind();
                        curId.Enabled = true;
                    }
                    else
                    {
                        alerError2.Visible = true;
                        lblError2.Text = "El alumno debe Pagar el concepto de Matricula o Inscripción para Examen..";
                        btnSeleccionarTodo.Visible = false;
                        tituloMateria.Visible = false;
                        curId.Enabled = false;
                        return;
                    }

                    //Grilla.Text= ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;

                }
            }
            if (e.CommandName != "Page")
            {

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

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["InscripcionCursadoRegistracion.PageIndex"] != null)
            {
                Session["InscripcionCursadoRegistracion.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("InscripcionCursadoRegistracion.PageIndex", e.NewPageIndex);
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

    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
    {
        aluNombre.Text = "";
        aluNombre.Enabled = false;
        //aluLegajoNumero.Text = "";
        //aluLegajoNumero.Enabled = false;
        aludni.Text = "";
        //btnBuscar.Enabled = true;
        //carId.SelectedValue = "0";
        //plaId.SelectedValue = "0";
        //curId.SelectedValue = "0";
        //camId.SelectedValue = "0";
        //escId.SelectedValue = "0";
        aludni.Focus();
    }



    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        alerError2.Visible = false;
        lblError2.Text = "";
        alerExito.Visible = false;
        alerMAteria.Visible = false;
        alerMatRepe.Visible = false;
        DataTable dt = new DataTable();
        DataTable dtME = new DataTable();
        DataTable dticuId = new DataTable();
        int Ban = 0; int Ban2 = 0;
        alerError2.Visible = false;
        alerExito.Visible = false;
        try
        {

            foreach (GridViewRow row in GrillaMateriasReg.Rows) //chequeo si al menos seleccionó un esp curr uno para inscribir Examen
            {
                CheckBox check = row.FindControl("chkSeleccion2") as CheckBox;
                if ((check.Checked)) // Si esta seleccionado..
                {
                    Ban = 1;
                }
            }

            foreach (GridViewRow row in GrillaMateriasLibre.Rows) //chequeo si al menos seleccionó un esp curr uno para inscribir Examen
            {
                CheckBox check2 = row.FindControl("chkSeleccion3") as CheckBox;
                if ((check2.Checked)) // Si esta seleccionado..
                {
                    Ban2 = 1;
                }
            }

            if (GrillaMateriasReg.Rows.Count > 0)
            {

                if (Ban == 1) // sE SELECCIONO AL MENOS UNO REGULAR
                {
                    foreach (GridViewRow row3 in GrillaMateriasReg.Rows)
                    {
                        CheckBox check3 = row3.FindControl("chkSeleccion2") as CheckBox;
                        if ((check3.Checked)) // Si esta seleccionado..
                        {
                            int Id = 0;
                            if (Request.QueryString["Id"] != null)
                            {

                                dticuId = ocnInscripcionCursadoTerciario.ObtenerUnoxaluIdxescId(Convert.ToInt32(aluId.Text), Convert.ToInt32(GrillaMateriasReg.DataKeys[row3.RowIndex].Values["escId2"]));
                                if (dticuId.Rows.Count > 0)
                                {
                                    this.icuId.Text = Convert.ToString(dticuId.Rows[0]["icuId"].ToString());
                                    this.AnioInsCursado.Text = Convert.ToString(dticuId.Rows[0]["AnoCursado"].ToString());
                                }

                                dtME = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(GrillaMateriasReg.DataKeys[row3.RowIndex].Values["escId2"]));

                                if (dtME.Rows.Count > 0)
                                {
                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Id);

                                    //ocnInscripcionExamen.ixaFechaExamen = Convert.ToDateTime(ixaFechaExamen.Text);

                                    dt = ocnInscripcionCursadoTerciario.ObtenerxicuIdxescId(Convert.ToInt32(icuId.Text), Convert.ToInt32(GrillaMateriasReg.DataKeys[row3.RowIndex].Values["escId2"]));

                                    if (dt.Rows[0]["ictFechaRegularizaPromociona"].ToString() != null)
                                    {

                                        DateTime fecha1 = Convert.ToDateTime(dt.Rows[0]["ictFechaRegularizaPromociona"].ToString());
                                        DateTime fecha2 = Convert.ToDateTime(fecha1.AddYears(2));
                                        DateTime fecha = DateTime.Now;
                                        int BanRango = 0;

                                        if ((fecha >= fecha1) && (fecha <= fecha2)) // si esta dentro de los dos años para rendir
                                        {
                                            BanRango = 1;
                                        }
                                        else
                                        {
                                            BanRango = 0;
                                        }

                                        if (BanRango == 1)
                                        {

                                            if (dt.Rows.Count > 0)
                                            {
                                                Int32 ControlFaltaCorrelativa = 1;
                                                DataTable dtCorrelativas = new DataTable();
                                                dtCorrelativas = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(GrillaMateriasReg.DataKeys[row3.RowIndex].Values["escId2"]), insId); // Traigo Correlativas  
                                                if (dtCorrelativas.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                                {
                                                    // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                                    foreach (DataRow rowCorrelativa in dtCorrelativas.Rows)
                                                    {
                                                        DataTable dtIctIdxCondicion = new DataTable();

                                                        if (Convert.ToInt32(rowCorrelativa["cotId"].ToString()) == 3)
                                                        {
                                                            dtIctIdxCondicion = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(Convert.ToInt32(aluId.Text), Convert.ToInt32(rowCorrelativa["escIdCorrel"].ToString()), Convert.ToInt32(rowCorrelativa["cotId"].ToString()));


                                                            if (dtIctIdxCondicion.Rows.Count != 0)
                                                            {
                                                                ControlFaltaCorrelativa = 1;
                                                            }
                                                            else
                                                            {
                                                                //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                                                ControlFaltaCorrelativa = 0;
                                                            }
                                                        }
                                                    }
                                                }
                                                else // No hay correlativas
                                                {
                                                    ControlFaltaCorrelativa = 1;
                                                }

                                                if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Actualizo Inscripcion Cursado Terciario
                                                {

                                                    ocnInscripcionExamen.ictId = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                                                    ocnInscripcionExamen.ixaActivo = ixaActivo.Checked;
                                                    ocnInscripcionExamen.itpId = 1;
                                                    ocnInscripcionExamen.ixaCalificacion = "";
                                                    ocnInscripcionExamen.ixaObservacion = "";
                                                    ocnInscripcionExamen.ixaNumeroActa = 0;
                                                    ocnInscripcionExamen.ixaNumeroLibro = "";

                                                    if (dtME.Rows.Count > 0)
                                                    {
                                                        ocnInscripcionExamen.meeId = Convert.ToInt32(dtME.Rows[0]["meeId"].ToString());
                                                    }
                                                    else
                                                    {
                                                        alerError2.Visible = true;
                                                        lblError2.Text = "No se craron mesas para ese espacio curricular..";
                                                        return;
                                                    }
                                                    /*....usuId = this.Master.usuId;*/

                                                    ocnInscripcionExamen.ixaFechaHoraCreacion = DateTime.Now;
                                                    ocnInscripcionExamen.ixaFechaHoraUltimaModificacion = DateTime.Now;
                                                    ocnInscripcionExamen.usuIdCreacion = this.Master.usuId;
                                                    ocnInscripcionExamen.usuIdUltimaModificacion = this.Master.usuId;

                                                    /*Validaciones*/
                                                    string MensajeValidacion = "";
                                                    //Decimal calificacion = 0;
                                                    DataTable dtTraerConcepto = new DataTable();
                                                    if (lblError2.Text.Length == 0)
                                                    {
                                                        if (Id == 0)
                                                        {
                                                            dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxicuIdxcntIdxAnio(Convert.ToInt32(icuId.Text), 1, Convert.ToInt32(AnioInsCursado.Text));
                                                            int PageIndex = 0;
                                                            if (dtTraerConcepto.Rows.Count > 0)
                                                            {       //Nuevo
                                                                DataTable dtConceptoPago = new DataTable();

                                                                if (dtTraerConcepto.Rows.Count > 0)
                                                                {
                                                                    dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                                                                }
                                                                else
                                                                {
                                                                    alerError2.Visible = true;
                                                                    lblError2.Text = "El alumno debe registrar el concepto de Matricula..";
                                                                    return;
                                                                }

                                                                if (dtConceptoPago.Rows.Count > 0)
                                                                {
                                                                    ocnInscripcionExamen.Insertar();
                                                                    alerExito.Visible = true;
                                                                    lblalerExito.Text = "Se incribió con exito en esas Materias..";
                                                                    PageIndex = 0;
                                                                    PageIndex = Convert.ToInt32(Session["IncripcionExamenRegistracion.PageIndex"]);
                                                                    GrillaCargarMaterias(PageIndex);
                                                                }
                                                                else
                                                                {
                                                                    alerError2.Visible = true;
                                                                    lblError2.Text = "El alumno debe pagar el concepto de Matricula o Inscripción a Examen..";
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxicuIdxcntIdxAnio(Convert.ToInt32(icuId.Text), 5, Convert.ToInt32(AnioInsCursado.Text));
                                                                if (dtTraerConcepto.Rows.Count > 0)
                                                                {
                                                                    DataTable dtConceptoPago = new DataTable();
                                                                    if (dtTraerConcepto.Rows.Count > 0)
                                                                    {
                                                                        dtConceptoPago = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dtTraerConcepto.Rows[0]["Id"]));
                                                                    }
                                                                    else
                                                                    {
                                                                        alerError2.Visible = true;
                                                                        lblError2.Text = "El alumno debe registrar el concepto de Matricula o Inscripción a Exámen..";
                                                                        return;
                                                                    }

                                                                    if (dtConceptoPago.Rows.Count > 0)
                                                                    {

                                                                        //Nuevo
                                                                        ocnInscripcionExamen.Insertar();
                                                                        alerExito.Visible = true;

                                                                        lblalerExito.Text = "Se incribió con exito en esas Materias..";
                                                                        PageIndex = 0;
                                                                        PageIndex = Convert.ToInt32(Session["IncripcionExamenRegistracion.PageIndex"]);
                                                                        GrillaCargarMaterias(PageIndex);
                                                                    }
                                                                    else
                                                                    {
                                                                        alerError2.Visible = true;
                                                                        lblError2.Text = "El alumno debe pagar el concepto de Matricula o Inscripción a Examen..";
                                                                        return;

                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    alerError2.Visible = true;
                                                                    lblError2.Text = "No tiene concepto de Matricula o para Iscripción a Exámen..";
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Editar
                                                            ocnInscripcionExamen.ixaFechaHoraUltimaModificacion = DateTime.Now;
                                                            ocnInscripcionExamen.usuIdUltimaModificacion = this.Master.usuId;
                                                            ocnInscripcionExamen.Actualizar();
                                                        }
                                                    }

                                                    //Response.Redirect("InscripcionExamenConsulta.aspx", true);

                                                }
                                                else
                                                {
                                                    alerError2.Visible = true;
                                                    lblError2.Text = "No tiene las correlativas para rendir..";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            alerError2.Visible = true;
                                            lblError2.Text = "Seleccionó Materias fuera de fecha de regularización.. pasaron más de dos años";

                                            ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario(Convert.ToInt32(dt.Rows[0]["Id"].ToString()));
                                            //ocnInscripcionCursadoTerciario.cdnId = 3;
                                            ocnInscripcionCursadoTerciario.ActualizarCondicion(Convert.ToInt32(dt.Rows[0]["Id"].ToString()), 3, null, Master.usuId, DateTime.Now);
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    alerError2.Visible = true;
                                    lblError2.Text = "No se craron mesas para ese espacio curricular..";
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //alerError2.Visible = true;
                            //lblError2.Text = "No selecciono ninguna materia Regular";
                        }
                    }
                }
                else
                {

                }
            }

            if (GrillaMateriasLibre.Rows.Count > 0)
            {
                if (Ban2 == 1) // sE SELECCIONO AL MENOS UNO LIBRE
                {

                    int insId = Convert.ToInt32(Session["_Institucion"]);
                    foreach (GridViewRow row4 in GrillaMateriasLibre.Rows)
                    {
                        DataTable dtFormDictado = new DataTable();
                        dtFormDictado = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(GrillaMateriasLibre.DataKeys[row4.RowIndex].Values["escId"]), insId);

                        if (Convert.ToInt32(dtFormDictado.Rows[0]["fodId"].ToString()) != 1)
                        {
                            CheckBox check3 = row4.FindControl("chkSeleccion3") as CheckBox;
                            if ((check3.Checked)) // Si esta seleccionado..
                            {
                                int Id = 0;
                                if (Request.QueryString["Id"] != null)
                                {
                                    dticuId = ocnInscripcionCursadoTerciario.ObtenerUnoxaluIdxescId(Convert.ToInt32(aluId.Text), Convert.ToInt32(GrillaMateriasLibre.DataKeys[row4.RowIndex].Values["escId"]));
                                    if (dticuId.Rows.Count > 0)
                                    {
                                        this.icuId.Text = Convert.ToString(dticuId.Rows[0]["icuId"].ToString());
                                    }
                                    dtME = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(GrillaMateriasLibre.DataKeys[row4.RowIndex].Values["escId"]));
                                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                                    ocnInscripcionExamen = new GESTIONESCOLAR.Negocio.InscripcionExamen(Id);
                                    //ocnInscripcionExamen.ixaFechaExamen = Convert.ToDateTime(ixaFechaExamen.Text);
                                    int escId = Convert.ToInt32(GrillaMateriasLibre.DataKeys[row4.RowIndex].Values["escId"]);
                                    dt = ocnInscripcionCursadoTerciario.ObtenerxicuIdxescId(Convert.ToInt32(icuId.Text), Convert.ToInt32(GrillaMateriasLibre.DataKeys[row4.RowIndex].Values["escId"]));

                                    if (dt.Rows.Count > 0)
                                    {
                                        Int32 ControlFaltaCorrelativa = 1;
                                        DataTable dtCorrelativas = new DataTable();
                                        dtCorrelativas = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(GrillaMateriasLibre.DataKeys[row4.RowIndex].Values["escId"]), insId); // Traigo Correlativas  
                                        if (dtCorrelativas.Rows.Count > 0) // Hay correlativas, ver si se cumple condicion
                                        {
                                            // Por Cada Correlativa para cursar controlo que exista en InscripcionCursadoTerciario con la cond correspondiente 
                                            foreach (DataRow rowCorrelativa in dtCorrelativas.Rows)
                                            {
                                                DataTable dtIctIdxCondicion = new DataTable();

                                                if (Convert.ToInt32(rowCorrelativa["cotId"].ToString()) == 3)
                                                {
                                                    dtIctIdxCondicion = ocnInscripcionCursadoTerciario.ObtenerUnoporCondicionTipo(Convert.ToInt32(aluId.Text), Convert.ToInt32(rowCorrelativa["escIdCorrel"].ToString()), Convert.ToInt32(rowCorrelativa["cotId"].ToString()));


                                                    if (dtIctIdxCondicion.Rows.Count != 0)
                                                    {
                                                        //ControlFaltaCorrelativa = 1;
                                                    }
                                                    else
                                                    {
                                                        //dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
                                                        ControlFaltaCorrelativa = 0;
                                                    }
                                                }
                                            }
                                        }
                                        else // No hay correlativas
                                        {
                                            //ControlFaltaCorrelativa = 1;
                                        }

                                        if (ControlFaltaCorrelativa == 1)  // Si estan bien las correlativas o no tiene correlativas Actualizo Inscripcion Cursado Terciario
                                        {
                                            DataTable dtInscExamExiste = new DataTable();
                                            dtInscExamExiste = ocnInscripcionExamen.ObtenerUnoxictIdxmeeId(Convert.ToInt32(dt.Rows[0]["Id"].ToString()), Convert.ToInt32(dtME.Rows[0]["meeId"].ToString()));

                                            if (dtInscExamExiste.Rows.Count == 0)
                                            {
                                                ocnInscripcionExamen.ictId = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                                                ocnInscripcionExamen.ixaActivo = ixaActivo.Checked;
                                                ocnInscripcionExamen.itpId = 2;
                                                ocnInscripcionExamen.ixaCalificacion = "";
                                                ocnInscripcionExamen.ixaObservacion = "";
                                                ocnInscripcionExamen.ixaNumeroActa = 0;
                                                ocnInscripcionExamen.ixaNumeroLibro = "";

                                                if (dtME.Rows.Count > 0)
                                                {
                                                    ocnInscripcionExamen.meeId = Convert.ToInt32(dtME.Rows[0]["meeId"].ToString());

                                                }
                                                else
                                                {
                                                    alerError2.Visible = true;
                                                    lblError2.Text = "No se crearon mesas para ese espacio curricular..";
                                                    return;
                                                }
                                                /*....usuId = this.Master.usuId;*/

                                                ocnInscripcionExamen.ixaFechaHoraCreacion = DateTime.Now;
                                                ocnInscripcionExamen.ixaFechaHoraUltimaModificacion = DateTime.Now;
                                                ocnInscripcionExamen.usuIdCreacion = this.Master.usuId;
                                                ocnInscripcionExamen.usuIdUltimaModificacion = this.Master.usuId;

                                                /*Validaciones*/
                                                string MensajeValidacion = "";
                                                //Decimal calificacion = 0;

                                                if (MensajeValidacion.Trim().Length == 0)
                                                {
                                                    if (Id == 0)
                                                    {
                                                        //Nuevo

                                                        DataTable dtTraerConcepto = new DataTable();
                                                        dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxicuIdxcntIdxAnio(Convert.ToInt32(icuId.Text), 1, Convert.ToInt32(AnioInsCursado.Text));

                                                        if (dtTraerConcepto.Rows.Count > 0)
                                                        {

                                                            ocnInscripcionExamen.Insertar();
                                                        }
                                                        else
                                                        {
                                                            dtTraerConcepto = ocnInscripcionConcepto.ObtenerUnoxicuIdxcntIdxAnio(Convert.ToInt32(icuId.Text), 5, Convert.ToInt32(AnioInsCursado.Text));
                                                            if (dtTraerConcepto.Rows.Count > 0)
                                                            {
                                                                ocnInscripcionExamen.Insertar();
                                                            }
                                                            else
                                                            {
                                                                alerError2.Visible = true;
                                                                lblError2.Text = "No tiene concepto de Inscripción Cursado o para Exámen..";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Editar
                                                        ocnInscripcionExamen.ixaFechaHoraUltimaModificacion = DateTime.Now;
                                                        ocnInscripcionExamen.usuIdUltimaModificacion = this.Master.usuId;
                                                        ocnInscripcionExamen.Actualizar();
                                                    }

                                                    Response.Redirect("InscripcionExamenConsulta.aspx", true);
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
                                                alerError2.Visible = true;
                                                lblError2.Text = "Seleccionó Espacios donde ya se encuentra inscripto para exámen.. ";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            alerError2.Visible = true;
                            lblError2.Text = "No debe seleccionar talleres para rendir Libre ";
                        }
                    }
                }
                else
                {
                    alerError2.Visible = true;
                    lblError2.Text = "No selecciono ninguna materia Libre";
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

    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (escId.SelectedIndex != 0)
        //{
        //    insId = Convert.ToInt32(Session["_Institucion"]);
        //    DataTable dt = new DataTable();
        //    DataTable dticuId = new DataTable();
        //    dticuId = ocnInscripcionCursadoTerciario.ObtenerUnoxaluIdxescId(Convert.ToInt32(aluId.Text), Convert.ToInt32(escId.SelectedValue));
        //    if (dticuId.Rows.Count > 0)
        //    {
        //        this.icuId.Text = Convert.ToString(dticuId.Rows[0]["icuId"].ToString());
        //    }

        //    dt = ocnMesaExamen.ObtenerUnoxTurnoxescId(Convert.ToInt32(TurnoId.SelectedValue), Convert.ToInt32(escId.SelectedValue));

        //    //dt = ocnEspacioCurricular.ObtenerUno(insId, Convert.ToInt32(escId.SelectedValue));
        //    if (dt.Rows.Count > 0)
        //    {
        //        //this.icuId.Text = dt.Rows[0]["icuId"].ToString();
        //        //this.fodId.SelectedValue = dt.Rows[0]["fodId"].ToString();
        //        //this.fodId.Enabled = false;

        //        //btnAceptar1.Enabled = true;
        //        //int ControlNoAprobado = 0;
        //        //int ControlExiste = 0;
        //        /////Controlo que el alumno no se encuentre inscripto en el examen de ese espacio curricular en esa fecha de examen
        //        //DataTable dt3 = new DataTable();
        //        //dt3 = ocnInscripcionExamen.ObtenerUnoControlExiste(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(TurnoId.SelectedValue));
        //        //if (dt3.Rows.Count > 0)
        //        //{
        //        //    ControlExiste = 1;
        //        //}

        //        //string MensajeValidacion = "";
        //        ////Controlo Correlaticas
        //        //if (ControlExiste == 0)
        //        //{










        //        //    ////Traer Correlativas para RENDIR del Espacio Curricular que estoy inscribiendo 
        //        //    //DataTable dt1 = new DataTable();
        //        //    //DataTable dt2 = new DataTable();
        //        //    //dt1 = ocnEspacioCurricular.ObtenerCorrelativas(Convert.ToInt32(escId.SelectedValue), insId);
        //        //    //if (dt1.Rows.Count > 0)
        //        //    //{
        //        //    //    // Por Cada Correlativa para RENDIR controlo que exista en InscripcionExamen cargada con el atributo Aprobado.
        //        //    //    foreach (DataRow row in dt1.Rows)
        //        //    //    {
        //        //    //        //dt2 = ocnInscripcionExamen.ObtenerUnoporAprobado(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(dt1.Rows[0]["Id"].ToString()));
        //        //    //        //dt2 = ocnInscripcionCursado.ObtenerUnoporAprobadooPromocionado(Convert.ToInt32(aluId.Text.Trim().ToString()), Convert.ToInt32(dt1.Rows[0]["Id"].ToString()));
        //        //    //        //if (dt2.Rows.Count == 0)
        //        //    //        //{
        //        //    //        //    ControlNoAprobado = 1;
        //        //    //        //}
        //        //    //    }
        //        //    //    if (ControlNoAprobado == 1)
        //        //    //    {
        //        //    //        Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);
        //        //    //        lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        //        //    //        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        //        //    //        <a class=""alert-link"" href=""#"">El alumno no posee las asignaturas correlativas aprobadas necesarias para rendir..<br/>
        //        //    //        Verifique!!</a><br/>" + MensajeValidacion + "</div>";
        //        //    //        btnAceptar1.Enabled = false;
        //        //    //    }
        //        //    //}
        //        //    ////else
        //        //    ////{
        //        //    ////    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);
        //        //    ////    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        //        //    ////    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        //        //    ////    <a class=""alert-link"" href=""#"">El alumno no posee las asignaturas correlativas cargadas o no tiene correlativas..<br/>
        //        //    ////    Verifique!!</a><br/>" + MensajeValidacion + "</div>";
        //        //    ////    btnAceptar1.Enabled = false;
        //        //    ////}

        //        //}
        //        //else
        //        //{
        //        //    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);
        //        //    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        //        //        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        //        //        <a class=""alert-link"" href=""#"">El alumno ya se encuentra inscripto para rendir en la asignatura seleccionada..<br/>
        //        //        Verifique!!</a><br/>" + MensajeValidacion + "</div>";
        //        //    btnAceptar1.Enabled = false;
        //        //}
        //    }
        //}
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
        plaIdCargar();
    }

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["IncripcionExamenRegistracion.PageIndex"]);

        GrillaCargarMaterias(PageIndex);
    }




    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in GrillaMateriasReg.Rows)
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
                foreach (GridViewRow row in GrillaMateriasReg.Rows)
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

    protected void btnSeleccionarTodo2_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo2.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in GrillaMateriasLibre.Rows)
                {
                    CheckBox check2 = row.FindControl("chkSeleccion3") as CheckBox;

                    if (check2.Checked == true)
                    {
                        check2.Checked = false;
                    }
                }
                btnSeleccionarTodo2.Text = "Seleccionar todo";
            }
            else
            {
                foreach (GridViewRow row in GrillaMateriasLibre.Rows)
                {
                    CheckBox check2 = row.FindControl("chkSeleccion3") as CheckBox;

                    if (check2.Checked == false)
                    {
                        check2.Checked = true;
                    }
                }
                btnSeleccionarTodo2.Text = "Desmarcar todo";
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

    protected void TurnoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = ocnTurnoExamen.ObtenerUno(Convert.ToInt32(TurnoId.SelectedValue));
        ixaFechaExamen.CalendarDate = Convert.ToDateTime(dt.Rows[0]["tueFchInicio"]);
    }



    protected void itpId_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajeError.Text = "";
        carId.SelectedValue = "0";
        plaId.SelectedValue = "0";
        curId.SelectedValue = "0";
        //camId.SelectedValue = "0";
        //escId.SelectedValue = "0";
        //fodId.SelectedValue = "0";

    }


    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        TurnoId.DataValueField = "Valor"; TurnoId.DataTextField = "Texto"; TurnoId.DataSource = (new GESTIONESCOLAR.Negocio.TurnoExamen()).ObtenerListaxAnio("[Seleccionar...]", Convert.ToInt32(txtAnio.Text)); TurnoId.DataBind();

    }

    protected void btnNuevoAlumno_Click(object sender, EventArgs e)
    {
        this.GrillaMateriasReg.DataSource = null;
        this.GrillaMateriasReg.DataBind();
        PanelRegular.Visible = false;
        btnSeleccionarTodo.Visible = false;
        tituloMateria.Visible = false;
        btnAceptar1.Visible = false;
        GrillaMateriasLibre.DataSource = null;
        GrillaMateriasLibre.DataBind();
        PanelLibre.Visible = false;
        btnSeleccionarTodo2.Visible = false;

        Grilla.DataSource = null;
        Grilla.DataBind();

        aludni.Text = "";
        aluNombre.Text = "";
        TextBox1.Text = "";
        aluId.Text = "";
        icuId.Text = "";
        TextBuscar.Text = "";
        NivelID.SelectedValue = "4";
        //carId.SelectedValue = "0";
        //plaId.SelectedValue = "0";
        curId.SelectedValue = "0";
        alerError2.Visible = false;
        alerExito.Visible = false;
        alerMAteria.Visible = false;
        alerMatRepe.Visible = false;
    }

    protected void btnBorrarTodo_Click(object sender, EventArgs e)
    {
        this.GrillaMateriasReg.DataSource = null;
        this.GrillaMateriasReg.DataBind();
        PanelRegular.Visible = false;
        btnSeleccionarTodo.Visible = false;
        tituloMateria.Visible = false;
        btnAceptar1.Visible = false;
        GrillaMateriasLibre.DataSource = null;
        GrillaMateriasLibre.DataBind();
        PanelLibre.Visible = false;
        btnSeleccionarTodo2.Visible = false;
        NivelID.SelectedValue = "4";
        carId.SelectedValue = "0";
        plaId.SelectedValue = "0";
        curId.SelectedValue = "0";
        TurnoId.SelectedValue = "0";

        Grilla.DataSource = null;
        Grilla.DataBind();

        aludni.Text = "";
        aluNombre.Text = "";
        TextBox1.Text = "";
        aluId.Text = "";
        icuId.Text = "";
        TextBuscar.Text = "";
        NivelID.SelectedValue = "4";
        carId.SelectedValue = "0";
        plaId.SelectedValue = "0";
        curId.SelectedValue = "0";
        alerError2.Visible = false;
        alerExito.Visible = false;
        alerMAteria.Visible = false;
        alerMatRepe.Visible = false;
    }
}