using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AsistenciaTerciarioxClase : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.AsistenciaMateriaTerciario ocnAsistenciaMateriaTerciario = new GESTIONESCOLAR.Negocio.AsistenciaMateriaTerciario();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();

    int insId;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                gvAsistencia.RowCreated += gvAsistencia_RowCreated;
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                this.Master.TituloDelFormulario = "Registro de Ausencias Terciario";

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "23") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24")  // Si es administrador o Director veo todas las carreras
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    //dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
                    //int carIdO = 0;

                    int niv = 4; // Terciario
                    carId.Enabled = true;


                    if ((Session["_perId"].ToString() == "23"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerCarreraxusuId("[Seleccionar...]", upeId, 4); carId.DataBind();
                    }
                    else
                    {
                        DataTable dt2 = new DataTable();

                        dt2 = ocnCarrera.ObtenerUnoxNivel(niv);

                        if (dt2.Rows.Count > 0)
                        {
                            carId.DataValueField = "Valor";
                            carId.DataTextField = "Texto";
                            carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", niv);
                            carId.DataBind();

                        }
                    }

                    //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    //ExamenTipoId.DataValueField = "Valor"; ExamenTipoId.DataTextField = "Texto"; ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]"); ExamenTipoId.DataBind();

                    //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                }


                else
                {
                    if (Session["_perId"].ToString() == "2")// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                    }



                    if ((Session["_perId"].ToString() == "4"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    if (Session["_perId"].ToString() == "5") // Preceptora
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    //if (Session["_perId"].ToString() == "11")   // Si es Docente Area Especia
                    //{
                    //    carId.Enabled = true;
                    //    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //}

                    //}
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["AsistenciaTerciario.PageIndex"] == null)
                {
                    Session.Add("AsistenciaTerciario.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        if (Session["_perId"].ToString() == "23") // Profesor
        {
            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaPlanxusuId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); plaId.DataBind();
        }
        else
        {
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue)); carId.DataBind();
                plaId.DataBind();
                plaId.Enabled = true;

                //lblCarrera.Text = Convert.ToString(carId.SelectedItem);
            }
        }


    }

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        if (plaId.SelectedIndex != 0)
        {
            DataTable dt = new DataTable();
            if (Session["_perId"].ToString() == "23") // Profesor
            {
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
            }
            else
            {

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
    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gvAlumnos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                //row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                //row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        foreach (GridViewRow row in gvAsistencia.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                //row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                //row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerMje.Visible = false;
            alerError.Visible = false;
            gvAsistencia.DataSource = null;
            gvAsistencia.DataBind(); btnGuardar.Visible = false;
            //alerError.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 espc = 0;
            Int32 car = 0;
            btnGuardar.Visible = false;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una carrera";
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
                lblError.Text = "Debe ingresar un Plan de Estudio..";
                return;
            }

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular";
                return;
            }

            try
            {
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }
            }
            catch (FormatException)
            {
                alerError.Visible = true;
                lblError.Text = "Ingrese un Año";
                return;
            }
            //if (txtFecha.Text == "")
            //{
            //    alerError.Visible = true;
            //    lblError.Text = "Ingrese un Año";
            //    return;
            //}


            if (AnioCur >= 2025)
            {

                DataTable dtRegCal = new DataTable();
                dtRegCal = ocnInscripcionCursadoTerciario.ObtenerTodoxEspCAsist(insId, espc, AnioCur);
                // Aseguramos que la columna "txtObsev" exista en dtRegCal
                if (!dtRegCal.Columns.Contains("txtObsev"))
                {
                    dtRegCal.Columns.Add("txtObsev", typeof(string));
                }
                // Aseguramos que la columna "amtPresente" exista en dtRegCal
                if (!dtRegCal.Columns.Contains("amtPresente"))
                {
                    dtRegCal.Columns.Add("amtPresente", typeof(bool));
                }
                if (!dtRegCal.Columns.Contains("amtId"))
                {
                    dtRegCal.Columns.Add("amtId", typeof(int));
                }
                DateTime fechaSeleccionada = Convert.ToDateTime(txtFecha.Text);
                foreach (DataRow fila in dtRegCal.Rows)
                {
                    int ictId = Convert.ToInt32(fila["ictId"]);

                    // Consultar si existe asistencia para ese alumno y fecha
                    DataTable dtAsistencia = ocnAsistenciaMateriaTerciario.ObtenerPorictIdyFecha(ictId, fechaSeleccionada);

                    if (dtAsistencia.Rows.Count > 0)
                    {
                        DataRow asistencia = dtAsistencia.Rows[0];
                        fila["amtPresente"] = Convert.ToBoolean(asistencia["amtPresente"]);
                        fila["amtId"] = Convert.ToInt32(asistencia["amtId"]);
                        fila["txtObsev"] = asistencia["amtObservaciones"].ToString();
                    }
                    else
                    {
                        fila["amtPresente"] = DBNull.Value; // ⬅️ Dejá nulo, así no marcás nada
                        fila["amtId"] = DBNull.Value;
                        fila["txtObsev"] = DBNull.Value;
                    }
                }


                if (dtRegCal.Rows.Count > 0)
                {
                    this.gvAlumnos.DataSource = dtRegCal;
                    this.gvAlumnos.PageIndex = PageIndex;
                    this.gvAlumnos.DataBind();
                    btnGuardar.Visible = true;
                    btnToggleCheckAll.Visible = true;
                }
                else
                {
                    alerMje.Visible = true;
                    this.gvAlumnos.DataSource = null;
                    this.gvAlumnos.DataBind();
                    lblMje.Text = "No hay registros";
                }
            }
            else {
                alerMje.Visible = true;
                this.gvAlumnos.DataSource = null;
                this.gvAlumnos.DataBind();
                lblMje.Text = "Esta planilla es para el año de cursado 2025 en adelante";
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
    //protected void gvAlumnos_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        // Obtén la fila de datos actual
    //        DataRowView rowView = (DataRowView)e.Row.DataItem;

    //        // Encuentra el CheckBox y el TextBox dentro de la fila
    //        CheckBox chkAsistio = (CheckBox)e.Row.FindControl("chkAsistio");
    //        TextBox txtObsev = (TextBox)e.Row.FindControl("txtObsev");

    //        // Asigna el valor de la columna "amtPresente" al CheckBox
    //        if (chkAsistio != null && rowView["amtPresente"] != DBNull.Value)
    //        {
    //            chkAsistio.Checked = Convert.ToBoolean(rowView["amtPresente"]);
    //        }

    //        // Asigna el valor de la columna de observaciones al TextBox
    //        if (txtObsev != null && rowView["txtObsev"] != DBNull.Value)
    //        {
    //            txtObsev.Text = rowView["txtObsev"].ToString();
    //        }
    //    }
    //}

    protected void gvAlumnos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtén la fila de datos actual
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            // Encuentra el CheckBox y el TextBox dentro de la fila
            CheckBox chkAsistio = (CheckBox)e.Row.FindControl("chkAsistio");
            TextBox txtObsev = (TextBox)e.Row.FindControl("txtObsev");

            // Asigna el valor de la columna "amtPresente" al CheckBox solo si existe un registro
            if (chkAsistio != null)
            {
                if (rowView["amtId"] != DBNull.Value && Convert.ToInt32(rowView["amtId"]) > 0)
                {
                    // Solo marcar si hay asistencia registrada
                    if (rowView["amtPresente"] != DBNull.Value)
                    {
                        chkAsistio.Checked = Convert.ToBoolean(rowView["amtPresente"]);
                    }
                }
                else
                {
                    // No marcar nada, o si querés explícitamente desmarcarlo:
                    chkAsistio.Checked = false;
                }
            }

            // Asigna el valor de la columna de observaciones al TextBox si existe
            if (txtObsev != null && rowView["txtObsev"] != DBNull.Value)
            {
                txtObsev.Text = rowView["txtObsev"].ToString();
            }
        }
    }

    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18") || (Session["_perId"].ToString() == "22") || Session["_perId"].ToString() == "21" || Session["_perId"].ToString() == "24") // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
        }
        else
        {
            if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "23"))
            {
                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();

            }
        }
    }

    protected void BtnCAlcular_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in gvAlumnos.Rows)
            {
                int Id = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["Id"]);
                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                Int32 usuIdUltimaModificacion = this.Master.usuId;

                TextBox p = row.FindControl("txtTAsistencia") as TextBox;

                String Nota = Convert.ToString(p.Text);
                if (Nota != "")
                {
                    //Decimal porcentaje = ((Convert.ToInt32(cantClases.Text) - Convert.ToInt32(Nota)) * 100) / Convert.ToInt32(cantClases.Text);
                    //ocnRegistracionCalificaciones.AsignarNotaTerc(Id, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                }
                //else
                //{
                //    Decimal porcentaje = 0;
                //    ocnRegistracionCalificaciones.AsignarNotaTerc(Id, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                //}
            }
            GrillaCargar(gvAlumnos.PageIndex);

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


    private void CargarDatos()
    {
        // Simulación de datos: deberías reemplazar con datos reales de la base de datos
        DataTable dt = new DataTable();
        dt.Columns.Add("IdAlumno");
        dt.Columns.Add("ApellidoNombre");

        dt.Rows.Add(1, "Juan Pérez");
        dt.Rows.Add(2, "Ana Gómez");
        dt.Rows.Add(3, "Luis García");

        gvAlumnos.DataSource = dt;
        gvAlumnos.DataBind();

        //lblMateria.Text = "Matemática I";
        //lblFecha.Text = "Fecha: " + DateTime.Now.ToShortDateString();
    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        DateTime fechaClase = DateTime.Now; // o usar calendario
        //alerExito.Visible = false;
        foreach (GridViewRow row in gvAlumnos.Rows)
        {
            bool asistio = ((CheckBox)row.FindControl("chkAsistio")).Checked;
            if (row.RowType == DataControlRowType.DataRow)
            {
                // Acceder al TextBox "txtObsev" en cada fila
                TextBox txtObsev = (TextBox)row.FindControl("txtObsev");

                int amtId = 0;
                try
                {
                    amtId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["amtId"]);
                }
                catch
                {
                    amtId = 0; // Valor predeterminado si hay error
                }

                int recId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["Id"]);
                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                Int32 usuIdUltimaModificacion = this.Master.usuId;



                string observacion = "";
                // Verificar que el control txtObsev no sea nulo
                if (txtObsev != null)
                {
                    // Obtener el valor de la observación
                    observacion = txtObsev.Text;
                }
                else
                {
                    observacion = "";
                }

                if (amtId == 0)
                {
                    Id = 0;
                }
                else
                {
                    Id = amtId;
                }
                ocnAsistenciaMateriaTerciario = new GESTIONESCOLAR.Negocio.AsistenciaMateriaTerciario(Id);
                ocnAsistenciaMateriaTerciario.ictId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["ictId"]);
                ocnAsistenciaMateriaTerciario.amtObservaciones = observacion;
                ocnAsistenciaMateriaTerciario.amtPresente = asistio;
                ocnAsistenciaMateriaTerciario.amtFecha = Convert.ToDateTime(txtFecha.Text);
                //int aluId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["aluId"]);
                int ictId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["ictId"]);
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo    

                        ocnAsistenciaMateriaTerciario.usuIdCreacion = this.Master.usuId;
                        ocnAsistenciaMateriaTerciario.amtFechaHoraCreacion = DateTime.Now;
                        ocnAsistenciaMateriaTerciario.amtFechaHoraUltimaModificacion = DateTime.Now;
                        ocnAsistenciaMateriaTerciario.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAsistenciaMateriaTerciario.Insertar();
                        alerExito.Visible = true;
                        lblExito.Text = "Asistencia guardada correctamente.";
                    }
                    else
                    {
                        //Editar
                        ocnAsistenciaMateriaTerciario.amtId = Id;
                        ocnAsistenciaMateriaTerciario.amtFechaHoraUltimaModificacion = DateTime.Now;
                        ocnAsistenciaMateriaTerciario.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAsistenciaMateriaTerciario.Actualizar();
                        alerExito.Visible = true;
                        lblExito.Text = "Asistencia guardada correctamente.";
                    }



                    int total = ocnAsistenciaMateriaTerciario.ObtenerCantidadTotalClases(ictId);
                    int presentes = ocnAsistenciaMateriaTerciario.ObtenerCantidadPresentes(ictId);
                    double porcentaje = total > 0 ? (double)presentes / total * 100 : 0;

                    ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);

                }
            }
        }

        lblamtId.Text = "";
        Int32 PageIndex = Convert.ToInt32(Session["AsistenciaTerciarioxClase.PageIndex"]);
        GrillaCargar(PageIndex);
    }


    protected void btnAplicar_Click(object sender, EventArgs e)
    {

        alerExito.Visible = false;
        alerError.Visible = false;
        gvAsistencia.DataSource = null;
        gvAsistencia.DataBind();
        ckTodo.Checked = false;

        lblamtId.Text = "";

        if (txtFecha.Text != "")
        {
            Int32 PageIndex = Convert.ToInt32(Session["AsistenciaTerciarioxClase.PageIndex"]);

            GrillaCargar(PageIndex);
        }
        else
        {

            alerMje.Visible = false;
            alerExito.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 espc = 0;
            Int32 car = 0;
            btnGuardar.Visible = false;
            btnToggleCheckAll.Visible = false;

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una carrera";
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
                lblError.Text = "Debe ingresar un Plan de Estudio..";
                return;
            }

            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso";
                return;
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Espacio Curricular";
                return;
            }

            try
            {
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }
            }
            catch (FormatException)
            {

                alerError.Visible = true;
                lblError.Text = "Ingrese un Año";
                return;

            }

            if (AnioCur >= 2025)
            {


                DataTable dtAsistencia = new DataTable();
                dtAsistencia = ocnAsistenciaMateriaTerciario.ObtenertodoxEspCurr(Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text));

                dtAsistencia = ocnAsistenciaMateriaTerciario.ObtenertodoxEspCurr(Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
                if (dtAsistencia.Rows.Count > 0)
                {
                    gvAsistencia.DataSource = dtAsistencia;
                    gvAsistencia.DataBind();
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No hay registros..";
                }

                gvAlumnos.DataSource = null;
                gvAlumnos.DataBind();
                ckTodo.Checked = false;
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Solo se permite la carga del Año 2025 en adelante..";
            }
        }
    }

    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        Int32 PageIndex = Convert.ToInt32(Session["AsistenciaTerciario.PageIndex"]);
        //GrillaCargar(PageIndex);
    }

    protected void ckTodo_CheckedChanged(object sender, EventArgs e)
    {
        alerMje.Visible = false;
        alerExito.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        Int32 espc = 0;
        Int32 car = 0;
        btnGuardar.Visible = false;
        btnToggleCheckAll.Visible = false;

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            car = Convert.ToInt32(carId.SelectedValue.ToString());
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar una carrera";
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
            lblError.Text = "Debe ingresar un Plan de Estudio..";
            return;
        }

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar un Curso";
            return;
        }

        if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
        {
            espc = Convert.ToInt32(escId.SelectedValue.ToString());
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar un Espacio Curricular";
            return;
        }

        try
        {
            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }
        }
        catch (FormatException)
        {

            alerError.Visible = true;
            lblError.Text = "Ingrese un Año";
            return;

        }
        DataTable dtAsistencia = new DataTable();
        dtAsistencia = ocnAsistenciaMateriaTerciario.ObtenertodoxEspCurr(Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text));

        dtAsistencia = ocnAsistenciaMateriaTerciario.ObtenertodoxEspCurr(Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
        if (dtAsistencia.Rows.Count > 0)
        {
            gvAsistencia.DataSource = dtAsistencia;
            gvAsistencia.DataBind();
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "No hay registros..";
        }

        gvAlumnos.DataSource = null;
        gvAlumnos.DataBind();
        ckTodo.Checked = false;

    }

    protected void gvAsistencia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int totalAsistencias = 0;

            // Suponiendo que la primera columna es el nombre
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                string cellValue = e.Row.Cells[i].Text.Trim();
                if (cellValue == "1")
                {
                    e.Row.Cells[i].Text = "P";
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Teal;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    totalAsistencias++;
                }
                else if (cellValue == "0")
                {
                    e.Row.Cells[i].Text = "A";
                    e.Row.Cells[i].BackColor = System.Drawing.Color.DarkRed;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                }
                e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;

            }

            // Calcular porcentaje
            int totalColumnasAsistencia = e.Row.Cells.Count - 1; // Excluye la columna nombre
            int porcentaje = (int)Math.Round((double)(totalAsistencias * 100) / totalColumnasAsistencia);

            // Crear celda con el porcentaje
            TableCell cell = new TableCell();
            cell.Text = porcentaje.ToString() + "%";
            cell.BackColor = System.Drawing.Color.SkyBlue;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Font.Size = FontUnit.Small;
            cell.ForeColor = System.Drawing.Color.Black;

            e.Row.Cells.Add(cell);
        }
    }


    protected void gvAsistencia_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            TableCell headerCell = new TableCell();
            headerCell.Text = "Porcentaje";
            headerCell.BackColor = System.Drawing.Color.SkyBlue;
            headerCell.HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells.Add(headerCell);
        }
    }

    protected void ckEliminarFecha_CheckedChanged(object sender, EventArgs e)
    {
        ocnAsistenciaMateriaTerciario.EliminarxFecha(Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text), Convert.ToDateTime(txtFecha.Text));
        alerExito.Visible = false;
        insId = Convert.ToInt32(Session["_Institucion"]);
        Int32 espc = 0;
        Int32 car = 0;
        btnGuardar.Visible = false;
        btnToggleCheckAll.Visible = false;

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            car = Convert.ToInt32(carId.SelectedValue.ToString());
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar una carrera";
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
            lblError.Text = "Debe ingresar un Plan de Estudio..";
            return;
        }

        if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar un Curso";
            return;
        }

        if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
        {
            espc = Convert.ToInt32(escId.SelectedValue.ToString());
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "Debe ingresar un Espacio Curricular";
            return;
        }

        try
        {
            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }
        }
        catch (FormatException)
        {

            alerError.Visible = true;
            lblError.Text = "Ingrese un Año";
            return;

        }


        DataTable dtAsistencia = new DataTable();
        dtAsistencia = ocnAsistenciaMateriaTerciario.ObtenertodoxEspCurr(Convert.ToInt32(escId.SelectedValue), Convert.ToInt32(AnioCursado.Text));
        if (dtAsistencia.Rows.Count > 0)
        {
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            foreach (GridViewRow row in gvAlumnos.Rows)
            {

                int recId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["recId"]);
                int ictId = Convert.ToInt32(gvAlumnos.DataKeys[row.RowIndex].Values["ictId"]);

                int total = ocnAsistenciaMateriaTerciario.ObtenerCantidadTotalClases(ictId);
                int presentes = ocnAsistenciaMateriaTerciario.ObtenerCantidadPresentes(ictId);
                double porcentaje = total > 0 ? (double)presentes / total * 100 : 0;

                ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Convert.ToString(porcentaje), RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
            }

            gvAsistencia.DataSource = dtAsistencia;
            gvAsistencia.DataBind();
            ckEliminarFecha.Checked = false;
            gvAlumnos.DataSource = null;
            gvAlumnos.DataBind();
            ckTodo.Checked = false;
            ckEliminarFecha.Checked = false;
        }
        else
        {
            gvAsistencia.DataSource = null;
            gvAsistencia.DataBind();
            ckTodo.Checked = false;
            ckEliminarFecha.Checked = false;
            alerError.Visible = true;
            lblError.Text = "No hay registros..";
            gvAlumnos.DataSource = null;
            gvAlumnos.DataBind();
            ckTodo.Checked = false;
            ckEliminarFecha.Checked = false;

        }

    }
    protected void btnToggleCheckAll_Click(object sender, EventArgs e)
    {
        bool seleccionar = false;

        // Detecta si al menos un checkbox no está marcado
        foreach (GridViewRow row in gvAlumnos.Rows)
        {
            CheckBox chkAsistio = row.FindControl("chkAsistio") as CheckBox;
            if (chkAsistio != null && !chkAsistio.Checked)
            {
                seleccionar = true;
                break;
            }
        }

        // Marca o desmarca todos según corresponda
        foreach (GridViewRow row in gvAlumnos.Rows)
        {
            CheckBox chkAsistio = row.FindControl("chkAsistio") as CheckBox;
            if (chkAsistio != null)
            {
                chkAsistio.Checked = seleccionar;
            }
        }
    }
}
