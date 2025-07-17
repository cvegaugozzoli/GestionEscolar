using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;

public partial class CargaCalifxEspCSec : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.RegistracionNotaPrevia ocnRegistracionNotaPrevia = new GESTIONESCOLAR.Negocio.RegistracionNotaPrevia();

    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                btnGuardar.Visible = false;
                btnGuardar1.Visible = false;
                alerMje.Visible = false;
                this.Master.TituloDelFormulario = " Calificaciones - Consulta - Registración";
                //if (dt.Rows.Count != 0)

                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9"))  // Si es administrador o Director veo todos los cursos
                {
                    carId.Enabled = true;
                    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Primario"));
                    carId.Enabled = false;

                    plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                    curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();

                }

                else
                {
                    if ((Session["_perId"].ToString() == "2") || (Session["_perId"].ToString() == "25"))// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Primario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudioporAlumno("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 1); curId.DataBind();

                    }

                    if ((Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "4")) // Si es Preceptora o Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudioporAlumno("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 1); curId.DataBind();
                    }


                    //if (Session["_perId"].ToString() == "11")   // Si es Docente Area Especia
                    //{
                    //    carId.Enabled = true;
                    //    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //}                   


                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["CargaCalifxEspCSec.PageIndex"] == null)
                {
                    Session.Add("CargaCalifxEspCSec.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion
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
        foreach (GridViewRow row in GrillaNota.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        if (GrillaNota.Rows.Count > 0)
        {
            btnGuardar.Visible = true;
            btnGuardar1.Visible = true;
            alerMje.Visible = true;
            btnImprimir.Visible = true;
        }
        else
        {
            btnGuardar.Visible = false;
            btnGuardar1.Visible = false;
            alerMje.Visible = false;
            btnImprimir.Visible = false;

        }

        base.Render(writer);
    }


    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "CargaCalifxEspCCargaCalifxEspCSecPri" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }
    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerExito.Visible = false;
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

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }

            dt = new DataTable();
            dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur, insId);
            this.GrillaNota.DataSource = dt;
            rowIndex = 0;
            this.GrillaNota.PageIndex = PageIndex;
            this.GrillaNota.DataBind();
            if ((Session["_perId"].ToString() == "10")) // Si es distinto a familiar puedo modificar
            {
                GrillaNota.Columns[9].Visible = false;
                GrillaNota.Columns[10].Visible = false;
            }
            TextNotaAsignar.Text = "";

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

                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                if (e.CommandName == "Eliminar")
                {
                    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.GrillaNota.PageIndex);
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
    private int rowIndex = 0;
    protected void GrillaNota_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                rowIndex++;
                Label lblOrden = (Label)e.Row.FindControl("lblOrden");
                if (lblOrden != null)
                {
                    lblOrden.Text = rowIndex.ToString();
                }
            }
            int periodoSeleccionado;
            if (int.TryParse(PeriodoId.SelectedValue, out periodoSeleccionado))
            {
                // Manejo de habilitación de campos
                TextBox txtPCuat = (TextBox)e.Row.FindControl("txtPCuat");
                TextBox txtSCuat = (TextBox)e.Row.FindControl("txtSCuat");
                TextBox txtTTrim = (TextBox)e.Row.FindControl("txtTTrim");
                TextBox txtPAnual = (TextBox)e.Row.FindControl("txtPAnual");
                TextBox txtDiciembre = (TextBox)e.Row.FindControl("txtDiciembre");
                TextBox txtMarzo = (TextBox)e.Row.FindControl("txtMarzo");
                TextBox txtAdic = (TextBox)e.Row.FindControl("txtAdic");
                TextBox txtrenCalfDef = (TextBox)e.Row.FindControl("txtrenCalfDef");

                if (txtPCuat != null)
                    txtPCuat.Enabled = (periodoSeleccionado == 1);

                if (txtSCuat != null)
                    txtSCuat.Enabled = (periodoSeleccionado == 2);

                if (txtPAnual != null)
                    txtPAnual.Enabled = (periodoSeleccionado == 4);

                if (txtDiciembre != null)
                    txtDiciembre.Enabled = (periodoSeleccionado == 5);

                if (txtMarzo != null)
                    txtMarzo.Enabled = (periodoSeleccionado == 6);

                if (txtrenCalfDef != null)
                    txtrenCalfDef.Enabled = (periodoSeleccionado == 7);

                if (txtAdic != null)
                    txtAdic.Enabled = (periodoSeleccionado == 8);
            }

            // Seteo del HyperLink del alumno (sin interpolación de cadenas)
            HyperLink lnkAlumno = (HyperLink)e.Row.FindControl("lblAlumno");
            if (lnkAlumno != null)
            {
                object icuIdObj = DataBinder.Eval(e.Row.DataItem, "InscripcionCursado");
                object aluNombreObj = DataBinder.Eval(e.Row.DataItem, "aluNombre");

                if (icuIdObj != null && aluNombreObj != null)
                {
                    string icuId = icuIdObj.ToString();
                    string aluNombre = aluNombreObj.ToString();
                    string anio = AnioCursado.Text.Trim();

                    lnkAlumno.Text = aluNombre;
                    lnkAlumno.NavigateUrl = "CargaCalificacionesPorAlumnoPri.aspx?icuId=" + icuId + "&Anio=" + anio;
                }
            }
        }
    }


    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["CargaCalifxEspCSec.PageIndex"] != null)
            {
                Session["CargaCalifxEspCSec.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CargaCalifxEspCSec.PageIndex", e.NewPageIndex);
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

            ocnCurso.Eliminar(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(GrillaNota.PageIndex);
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
        GrillaCargar(GrillaNota.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        lblMsjeErrorAsignar.Text = "";
        alerExito.Visible = false;
        GrillaCargar(GrillaNota.PageIndex);
        lblPeriodo.Visible = true;
        PeriodoId.Visible = true;
        pnlAsignarNota.Visible = true; // MOSTRAR TODO JUNTO
        btnGuardar.Visible = false;
        btnGuardar1.Visible = false;
        alerMje.Visible = true;
        btnImprimir.Visible = false;
    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GrillaNota.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
        GrillaCargar(PageIndex);
        GrillaNota.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
        GrillaNota.Columns[8].Visible = true;
        GrillaNota.Columns[9].Visible = true;

    }
    protected void OnCancel(object sender, EventArgs e)
    {
        ErrorIngreso.Visible = false;
        GrillaNota.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
        GrillaCargar(PageIndex);

    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrillaNota, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }


    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            alerExito.Visible = false;
            GridViewRow row = GrillaNota.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GrillaNota.DataKeys[e.RowIndex].Values[0]);

            TextBox PTrim = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtPTrim");
            TextBox STrim = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtSTrim");
            TextBox TTrim = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtTTrim");

            TextBox PAnual = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtPAnual");
            TextBox NotaDic = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtDiciembre");
            TextBox NotaMar = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtMarzo");
            TextBox renCalfDef = (TextBox)GrillaNota.Rows[e.RowIndex].FindControl("txtrenCalfDef");
            String PTrim2 = PTrim.Text;
            String STrim2 = STrim.Text;
            String TTrim2 = TTrim.Text;
            String PAnual2 = PAnual.Text;
            String NotaDic2 = NotaDic.Text;
            String NotaMar2 = NotaMar.Text;
            String renCalfDef2 = renCalfDef.Text;
            DateTime RenFechaHoraCreacion = DateTime.Now;
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdCreacion = this.Master.usuId;
            Int32 usuIdUltimaModificacion = this.Master.usuId;

            ocnRegistracionNota.ActualizarPrimaria(Id, PTrim2, STrim2, TTrim2, PAnual2, NotaDic2, NotaMar2, renCalfDef2, RenFechaHoraCreacion, RenFechaHoraUltimaModificacion, usuIdCreacion, usuIdUltimaModificacion);
            GrillaNota.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
            GrillaCargar(PageIndex);
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
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GrillaNota.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ErrorIngreso.Visible = false;
        alerExito.Visible = false;
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

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());
        }

        if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
        {
            espc = Convert.ToInt32(escId.SelectedValue.ToString());
        }

        if (AnioCursado.Text == "")
        {
            DateTime fechaActual = DateTime.Today;
            AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
        }
        else
        {
            AnioCur = Convert.ToInt32(AnioCursado.Text);
        }

        bool hayErrorGeneral = false;
        string mensajeErrorGeneral = "";

        foreach (GridViewRow row in GrillaNota.Rows)
        {
            Label lblId = (Label)row.FindControl("lblrenId");
            int RenId = lblId != null ? Convert.ToInt32(lblId.Text) : 0;

            string lblAsignatura = Convert.ToString(escId.SelectedItem);
            string asignatura = lblAsignatura != null ? lblAsignatura.Trim().ToUpper() : "";
            bool esInasistencia = asignatura == "INASISTENCIAS";
            string[] errores = new string[0];
            string notaProcesada;

            TextBox txtPCuat = (TextBox)row.FindControl("txtPCuat");
            if (txtPCuat != null && txtPCuat.Enabled)
            {
                notaProcesada = ProcesarNota(txtPCuat, "Primer Cuatrimestre", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaSecPC(RenId, notaProcesada);
            }

            TextBox txtSCuat = (TextBox)row.FindControl("txtSCuat");
            if (txtSCuat != null && txtSCuat.Enabled)
            {
                errores = new string[0];
                notaProcesada = ProcesarNota(txtSCuat, "Segundo Cuatrimestr", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaSecSC(RenId, notaProcesada);
            }

            TextBox txtPAnual = (TextBox)row.FindControl("txtPAnual");
            if (txtPAnual != null && txtPAnual.Enabled)
            {
                errores = new string[0];
                notaProcesada = ProcesarNota(txtPAnual, "Promedio Anual", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaPromA(RenId, notaProcesada);
            }

            TextBox txtDiciembre = (TextBox)row.FindControl("txtDiciembre");
            if (txtDiciembre != null && txtDiciembre.Enabled)
            {
                errores = new string[0];
                notaProcesada = ProcesarNota(txtDiciembre, "Diciembre", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaDic(RenId, notaProcesada);
            }

            TextBox txtMarzo = (TextBox)row.FindControl("txtMarzo");
            if (txtMarzo != null && txtMarzo.Enabled)
            {
                errores = new string[0];
                notaProcesada = ProcesarNota(txtMarzo, "Marzo", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaMar(RenId, notaProcesada);
            }

            TextBox txtAdic = (TextBox)row.FindControl("txtAdic");
            if (txtAdic != null && txtAdic.Enabled)
            {
                errores = new string[0];
                notaProcesada = ProcesarNota(txtAdic, "EX. Adicional", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaExamenAdic(RenId, notaProcesada);
            }
            TextBox txtrenCalfDef = (TextBox)row.FindControl("txtrenCalfDef");
            if (txtrenCalfDef != null && txtrenCalfDef.Enabled)
            {
                errores = new string[0];
                notaProcesada = ProcesarNota(txtrenCalfDef, "Calificación Definitiva", ref errores, esInasistencia);
                if (errores.Length > 0) { hayErrorGeneral = true; mensajeErrorGeneral = string.Join("<br/>", errores); MostrarErrorEnGrilla(row, mensajeErrorGeneral); } else ocnRegistracionNota.AsignarNotaCalDef(RenId, notaProcesada);
            }

            if (hayErrorGeneral) // Si hubo un error en alguna nota, detener el proceso
            {
                break;
            }
        }

        if (hayErrorGeneral)
        {
            ErrorIngreso.Visible = true;
            lblErrorIngreo.Text = "Se encontraron errores en algunas notas. Por favor, revise las Notas en la grilla. Valores del 1 al 1o";
        }
        else
        {
          
            PeriodoId.SelectedValue = "0";
            Int32 PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
            GrillaCargar(PageIndex);  alerExito.Visible = true;
            lblExito.Text = "Las notas fueron guardadas con éxito..";
        }
    }

    private void MostrarErrorEnGrilla(GridViewRow row, string mensajeError)
    {
        Label lblError = (Label)row.FindControl("lblErrorNota");
        if (lblError != null)
        {
            lblError.Text = mensajeError;
        }
    }

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
        {
            int usuario = Convert.ToInt32(Session["_usuId"].ToString());


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
        alerExito.Visible = false;
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
            }
        }
    }

    protected void PeriodoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerExito.Visible = false;
        ErrorIngreso.Visible = false;
        pnlAsignarNota.Visible = false;
        lblMsjeErrorAsignar.Text = "";
        //btnGuardar.Visible = true;
        int periodoSeleccionado = Convert.ToInt32(PeriodoId.SelectedValue);
        ViewState["PeriodoSeleccionado"] = periodoSeleccionado;
        //btnGuardar.Visible = true;
        this.GrillaNota.DataSource = null;
        this.GrillaNota.DataBind();
        btnGuardar1.Visible = false;
        btnGuardar.Visible = false;
        alerMje.Visible = false;
        btnImprimir.Visible = false;
    }



    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);
        int usuario = Convert.ToInt32(Session["_usuId"].ToString());
        alerExito.Visible = false;
        //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);

        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "25") || (Session["_perId"].ToString() == "2") || (Session["_perId"].ToString() == "5")) // Si es administrador o Director veo todo
        {
            escId.DataValueField = "Id"; escId.DataTextField = "Nombre"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
            this.GrillaNota.DataSource = null;
            this.GrillaNota.DataBind();
            btnGuardar1.Visible = false;
            btnGuardar.Visible = false;
            alerMje.Visible = false;
            btnImprimir.Visible = false;
            pnlAsignarNota.Visible = false;
        }
        else
        {
            if ((Session["_perId"].ToString() == "11"))
            {
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxusuIdyCur("[Seleccionar...]", usuario, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
            }
        }
    }


    protected void ButtonAsignar_Click(object sender, EventArgs e)
    {
        lblMsjeErrorAsignar.Text = "";
        insId = Convert.ToInt32(Session["_Institucion"]);
        Int32 espc = 0;
        Int32 car = 0;
        ErrorIngreso.Visible = false;
        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            car = Convert.ToInt32(carId.SelectedValue.ToString());
        }
        Int32 pla = 0;
        if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
        {
            pla = Convert.ToInt32(plaId.SelectedValue.ToString());
        }

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());
            //Session.Add("CursoListadoAlumnos.curId", curId.SelectedValue);
        }
        //else
        //{
        //    Session.Add("CursoListadoAlumnos.curId", cur);
        //}


        if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
        {
            espc = Convert.ToInt32(escId.SelectedValue.ToString());
            //Session.Add("CursoListadoAlumnos.curId", curId.SelectedValue);
        }


        if (AnioCursado.Text == "")
        {
            DateTime fechaActual = DateTime.Today;
            AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

        }
        else
        {
            AnioCur = Convert.ToInt32(AnioCursado.Text);
        }

        if (TextNotaAsignar.Text != "")
        {

            string notaAAsignar = TextNotaAsignar.Text.Trim().ToUpper();
            string[] errores = new string[0];
            bool esInasistencia = false;


            if (escId.SelectedItem.Text.Trim().ToUpper() == "INASISTENCIAS")
            {
                esInasistencia = true;
            }

            string notaProcesada = ProcesarNota(TextNotaAsignar, "Nota a Asignar", ref errores, esInasistencia);

            if (errores.Length > 0)
            {
                ErrorIngreso.Visible = true;
                lblErrorIngreo.Text = string.Join("<br/>", errores);
                //lblMsjeErrorAsignar.Text = string.Join("<br/>", errores);
                return;
            }

            if (PeriodoId.SelectedIndex != 0)
            {
                dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur, insId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int RenId = Convert.ToInt32(row["Id"].ToString());
                        //int fDictado = Convert.ToInt32(row["FDictado"].ToString());

                        //if (fDictado != 5) // Evitar modificar registros con FDictado = 5
                        //{
                            switch (PeriodoId.SelectedValue)
                            {
                                case "1":
                                    ocnRegistracionNota.AsignarNotaSecPC(RenId, notaProcesada);
                                    break;
                                case "2":
                                    ocnRegistracionNota.AsignarNotaSecSC(RenId, notaProcesada);
                                    break;
                                case "4":
                                    ocnRegistracionNota.AsignarNotaPromA(RenId, notaProcesada);
                                    break;
                                case "5":
                                    ocnRegistracionNota.AsignarNotaDic(RenId, notaProcesada);
                                    break;
                                case "6":
                                    ocnRegistracionNota.AsignarNotaMar(RenId, notaProcesada);
                                    break;
                                case "7":
                                    ocnRegistracionNota.AsignarNotaCalDef(RenId, notaProcesada);
                                    break;
                                case "8":
                                    ocnRegistracionNota.AsignarNotaExamenAdic(RenId, notaProcesada);
                                    break;
                                default:
                                    ErrorIngreso.Visible = true;
                                    lblErrorIngreo.Text = "Periodo no válido para la asignación.";
                                    //lblMsjeErrorAsignar.Text = "Periodo no válido para la asignación.";
                                    return;
                            //}
                        }
                    }
                    GrillaNota.EditIndex = -1;
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
                    GrillaCargar(PageIndex);
                }
            }
            else
            {
                ErrorIngreso.Visible = true;
                lblErrorIngreo.Text = "Seleccione un Periodo..";
                //lblMsjeErrorAsignar.Text = "Seleccione un Periodo..";
                PeriodoId.Focus();
                return;
            }
        }
        else
        {
            ErrorIngreso.Visible = true;
            lblErrorIngreo.Text = "Asigne una nota..";
            //lblMsjeErrorAsignar.Text = "Asigne una nota..";
            TextNotaAsignar.Focus();
            return;
        }
    }

    private string ProcesarNota(TextBox txtNota, string nombreCampo, ref string[] errores, bool esInasistencia)
    {
        if (txtNota == null)
            return "";

        string texto = txtNota.Text.Trim().ToUpper();

        if (string.IsNullOrEmpty(texto))
        {
            // Si el campo está vacío o solo tiene espacios, se guarda como vacío sin error
            return " ";
        }

        if (esInasistencia)
        {
            // Para INASISTENCIAS, permitimos cualquier valor tal como está
            return texto;
        }

        // Primero intentamos parsear como número decimal (permite 8.5, 9.25, etc.)
        decimal valorDecimal;
        if (decimal.TryParse(texto, out valorDecimal))
        {
            if (valorDecimal >= 1 && valorDecimal <= 10)
            {
                return valorDecimal.ToString("0.##");
            }
            else
            {
                errores = errores.Concat(new[] { "Valor numérico inválido en " + nombreCampo + " (1-10)" }).ToArray();
            }
        }
        else
        {
            // Letras válidas: R, S, MB, B, I
            string[] validos = { "R", "S", "MB", "B", "I" };
            if (validos.Contains(texto))
            {
                return texto;
            }
            else
            {
                errores = errores.Concat(new[] { "Valor inválido en " + nombreCampo + " (solo R, S, MB, B, I o número del 1 al 10)" }).ToArray();
            }
        }

        return "";
    }


    //protected void ButtonAsignar_Click(object sender, EventArgs e)
    //{
    //    lblMsjeErrorAsignar.Text = "";
    //    insId = Convert.ToInt32(Session["_Institucion"]);
    //    Int32 espc = 0;
    //    Int32 car = 0;
    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        car = Convert.ToInt32(carId.SelectedValue.ToString());
    //    }
    //    Int32 pla = 0;
    //    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
    //    {
    //        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
    //    }

    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        cur = Convert.ToInt32(curId.SelectedValue.ToString());
    //        //Session.Add("CursoListadoAlumnos.curId", curId.SelectedValue);
    //    }
    //    //else
    //    //{
    //    //    Session.Add("CursoListadoAlumnos.curId", cur);
    //    //}


    //    if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
    //    {
    //        espc = Convert.ToInt32(escId.SelectedValue.ToString());
    //        //Session.Add("CursoListadoAlumnos.curId", curId.SelectedValue);
    //    }


    //    if (AnioCursado.Text == "")
    //    {
    //        DateTime fechaActual = DateTime.Today;
    //        AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

    //    }
    //    else
    //    {
    //        AnioCur = Convert.ToInt32(AnioCursado.Text);
    //    }

    //    if (TextNotaAsignar.Text != "")
    //    {

    //        if (PeriodoId.SelectedIndex != 0)
    //        {

    //            dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur, insId);

    //            if (PeriodoId.SelectedIndex == 1)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        int RenId = Convert.ToInt32(row["Id"].ToString());
    //                        ocnRegistracionNota.AsignarNotaPriPT(RenId, TextNotaAsignar.Text);
    //                    }
    //                }
    //            }
    //            if (PeriodoId.SelectedIndex == 2)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        int RenId = Convert.ToInt32(row["Id"].ToString());
    //                        ocnRegistracionNota.AsignarNotaPriST(RenId, TextNotaAsignar.Text);
    //                    }
    //                }
    //            }
    //            if (PeriodoId.SelectedIndex == 3)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        int RenId = Convert.ToInt32(row["Id"].ToString());
    //                        ocnRegistracionNota.AsignarNotaPriTT(RenId, TextNotaAsignar.Text);
    //                    }
    //                }
    //            }
    //            if (PeriodoId.SelectedIndex == 4)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
    //                        {
    //                            int RenId = Convert.ToInt32(row["Id"].ToString());
    //                            ocnRegistracionNota.AsignarNotaPromA(RenId, TextNotaAsignar.Text);
    //                        }
    //                    }
    //                }
    //            }
    //            if (PeriodoId.SelectedIndex == 5)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
    //                        {
    //                            int RenId = Convert.ToInt32(row["Id"].ToString());
    //                            ocnRegistracionNota.AsignarNotaDic(RenId, TextNotaAsignar.Text);
    //                        }
    //                    }
    //                }
    //            }

    //            if (PeriodoId.SelectedIndex == 6)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
    //                        {
    //                            int RenId = Convert.ToInt32(row["Id"].ToString());
    //                            ocnRegistracionNota.AsignarNotaMar(RenId, TextNotaAsignar.Text);
    //                        }
    //                    }
    //                }
    //            }
    //            if (PeriodoId.SelectedIndex == 7)
    //            {
    //                if (dt.Rows.Count > 0)
    //                {
    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        if (Convert.ToInt32(row["FDictado"].ToString()) != 5)
    //                        {
    //                            int RenId = Convert.ToInt32(row["Id"].ToString());
    //                            ocnRegistracionNota.AsignarNotaCalDef(RenId, TextNotaAsignar.Text);
    //                        }
    //                    }
    //                }
    //            }
    //            GrillaNota.EditIndex = -1;
    //            int PageIndex = 0;
    //            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
    //            GrillaCargar(PageIndex);
    //        }
    //        else
    //        {
    //            lblMsjeErrorAsignar.Text = "Seleccione un Periodo..";
    //            PeriodoId.Focus();
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        lblMsjeErrorAsignar.Text = "Asigne una nota..";
    //        TextNotaAsignar.Focus();
    //        return;
    //    }
    //}

    protected void ButtonImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            String NomRep;
            Int32 Materia = Convert.ToInt32(escId.SelectedValue.ToString());
            Int32 curso = Convert.ToInt32(curId.SelectedValue.ToString());
            Int32 anioLectivo = Convert.ToInt32(AnioCursado.Text.Trim().ToString());

            NomRep = "InformeListadoCalificacionesxMateria.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + Materia + "&curId=" + curso + "&anio=" + anioLectivo + "&NomRep=" + NomRep);
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
        alerExito.Visible = false;
        pnlAsignarNota.Visible = false;
        lblMsjeErrorAsignar.Text = "";
        //btnGuardar.Visible = true;
        int periodoSeleccionado = Convert.ToInt32(PeriodoId.SelectedValue);
        ViewState["PeriodoSeleccionado"] = periodoSeleccionado;
        //btnGuardar.Visible = true;
        this.GrillaNota.DataSource = null;
        this.GrillaNota.DataBind();
        btnGuardar1.Visible = false;
        btnGuardar.Visible = false;
        alerMje.Visible = false;
        btnImprimir.Visible = false;
    }
}