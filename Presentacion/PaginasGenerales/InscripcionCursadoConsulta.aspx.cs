using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InscripcionCursadoConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int insId;

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                CantReg.Visible = false;
                this.Master.TituloDelFormulario = " Inscripcion Cursado - Consulta";
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                insId = Convert.ToInt32(Session["_Institucion"]);
                ListItem i;
                if (lblInsId.Text == "1")
                {
                    i = new ListItem("Seleccionar..", "0");
                    carId.Items.Add(i);

                    i = new ListItem("Primario", "2");
                    carId.Items.Add(i);
                    i = new ListItem("Secundario", "3");
                    carId.Items.Add(i);
                    i = new ListItem("3º CICLO DE LA EGB Y DE LA EDUC.POLIM EN GEOGRAFIA", "16");
                    carId.Items.Add(i);
                    i = new ListItem("1º Y 2º CICLO DE LA EGB", "17");
                    carId.Items.Add(i);
                    i = new ListItem("3º CICLO DE LA EGB Y DE LA EDUC.POLIM. EN ECONOMIA", "18");
                    carId.Items.Add(i);
                    i = new ListItem("INGLES PARA EL 3º CICLO DE LA EGB Y LA EDUC.POLIM.", "19");
                    carId.Items.Add(i);
                    i = new ListItem("EDUCACION INICIAL", "20");
                    carId.Items.Add(i);
                    i = new ListItem("INGLES PARA EDUC.INICIAL Y 1º Y 2º CICLO DE LA EGB", "21");
                    carId.Items.Add(i);
                    i = new ListItem("CIENCIAS NATURALES. BIOLOGIA, SALUD Y AMBIENTE", "22");
                    carId.Items.Add(i);
                    i = new ListItem("CIENCIAS NATURALES. MATEMATICA, FISICA Y DISEÑO", "23");
                    carId.Items.Add(i);
                    i = new ListItem("ECONOMIA Y ADMINISTRACION", "24");
                    carId.Items.Add(i);
                    i = new ListItem("CS. SOCIALES Y HUMANIDADES", "25");
                    carId.Items.Add(i);
                    i = new ListItem("EDUCACION PRIMARIA", "26");
                    carId.Items.Add(i);
                    i = new ListItem(" EDUCACIÓN INICIAL", "27");
                    carId.Items.Add(i); i = new ListItem("INGLES", "28");
                    carId.Items.Add(i);
                    i = new ListItem("EDUCACION SECUNDARIA EN GEOGRAFIA", "29");
                    carId.Items.Add(i); i
                        = new ListItem("EDUCACION SECUNDARIA EN ECONOMIA", "30");
                    carId.Items.Add(i);
                    i = new ListItem("PROFESORADO EN GEOGRAFIA 06", "31");
                    carId.Items.Add(i); i = new ListItem(" PROFESORADO EN GEOGRAFIA 07", "32");
                    carId.Items.Add(i);
                    i = new ListItem("PLANES ESPECIALES", "33");
                    carId.Items.Add(i);
                }
                else
                {
                    if (lblInsId.Text == "2")
                    {
                        i = new ListItem("Seleccionar..", "0");
                        carId.Items.Add(i);
                        i = new ListItem("Primario", "2");
                        carId.Items.Add(i);
                    }
                    else
                    {
                        if (lblInsId.Text == "3")
                        {
                            i = new ListItem("Seleccionar..", "0");
                            carId.Items.Add(i);
                            i = new ListItem("Primario", "2");
                            carId.Items.Add(i);
                        }
                        else
                        {
                            if (lblInsId.Text == "4")
                            {
                                i = new ListItem("Seleccionar..", "0");
                                carId.Items.Add(i);
                                i = new ListItem("Inicial", "1");
                                carId.Items.Add(i);
                            }
                            else
                            {
                                if (lblInsId.Text == "5")
                                {
                                    i = new ListItem("Seleccionar..", "0");
                                    carId.Items.Add(i);
                                    i = new ListItem("Inicial", "1");
                                    carId.Items.Add(i);
                                }
                            }
                        }
                    }
                }


                //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                lblMejeErrOR2.Visible = false;

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["InscripcionCursadoConsulta.PageIndex"] == null)
                {
                    Session.Add("InscripcionCursadoConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["InscripcionCursadoConsulta.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]
                if (Session["InscripcionCursadoConsulta.carId"] != null)
                {
                    carId.SelectedValue = Convert.ToString(Session["InscripcionCursadoConsulta.carId"]);
                    carIdCargar();
                }
                else
                {
                    Session.Add("InscripcionCursadoConsulta.carId", "");
                }
                if (Session["InscripcionCursadoConsulta.plaId"] != null)
                {
                    plaId.SelectedValue = Convert.ToString(Session["InscripcionCursadoConsulta.plaId"]);
                    plaIdCargar();
                }
                else
                {
                    Session.Add("InscripcionCursadoConsulta.plaId", "");
                }
                if (Session["InscripcionCursadoConsulta.curId"] != null)
                {
                    curId.SelectedValue = Convert.ToString(Session["InscripcionCursadoConsulta.curId"]);
                }
                else
                {
                    Session.Add("InscripcionCursadoConsulta.curId", "");
                }

                #endregion

                //GrillaCargar(PageIndex, Alumno.Text);
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
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("InscripcionCursadoRegistracion.aspx?Id=0", false);
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
        gridtemp.Columns[1].Visible = true;
        gridtemp.Columns[2].Visible = true;
        gridtemp.Columns[5].Visible = true;
        gridtemp.Columns[8].Visible = true;
        //gridtemp.Columns[9].Visible = true;
        //var grid = new GridView();
        //grid.DataSource = gridtemp;
        //grid.DataBind();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=Listado.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gridtemp.RenderControl(htw);
        string style = @"<style> td { mso-number-format:\@;} </style>";
        Response.Write(style);
        Response.Write(sw.ToString());
        Response.End();
        gridtemp.Columns[1].Visible = false;
        gridtemp.Columns[2].Visible = false;
        gridtemp.Columns[5].Visible = false;
        gridtemp.Columns[8].Visible = false;
        gridtemp.Columns[9].Visible = false;
    }

    private void GrillaCargar(int PageIndex, String aluNombre)
    {
        try
        {
            Exportar.Visible = false;
            CantReg.Visible = false;
            Session["InscripcionCursadoConsulta.PageIndex"] = PageIndex;
            int insId2 = Convert.ToInt32(lblInsId.Text);
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

            dt = new DataTable();
            dt = ocnInscripcionCursado.ObtenerporInstCarporPlaporCurporAlu(insId2, car, pla, cur, aluNombre);
            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                gridtemp.DataSource = dt;

                gridtemp.DataBind();
                Exportar.Visible = true;
                CantReg.Visible = true;
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
            }
            else
            {
                CantReg.Visible = true;
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
                AnioCur = Convert.ToInt32(((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Controls[1]).Text);

                string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    int usuIdCreacion = this.Master.usuId;
                    ocnInscripcionCursado.Eliminar(Convert.ToInt32(IC), usuIdCreacion);
                    this.GrillaCargar(this.Grilla.PageIndex, Alumno.Text);
                }

                if (e.CommandName == "Ver")
                {
                    String TC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;



                    if (TC == "4")// Terciario
                    {
                        Response.Redirect("RegistracionCalificacionesRegistracion.aspx?Id=" + IC + "&Ver=1", false);
                    }
                    else
                    {
                        if (TC == "3") // Secundario
                        {
                            Response.Redirect("CargaCalificacionesPorAlumnoSec.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                        }
                        else
                        {
                            if (TC == "2") // Primario
                            {
                                Response.Redirect("CargaCalificacionesPorAlumnoPri.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                            }


                            else
                            {
                                if (TC == "1") // Inicial
                                {
                                    lblMejeErrOR2.Visible = true;
                                    lblMejeErrOR2.Text = "Los alumnos del nivel Inicial no posee calificaciones";
                                }

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
          
            if (Session["InscripcionCursadoConsulta.PageIndex"] != null)
            {
                Session["InscripcionCursadoConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("InscripcionCursadoConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex, Alumno.Text);
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
            int usuIdCreacion = this.Master.usuId;
            ocnInscripcionCursado.Eliminar(Id, usuIdCreacion);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(Grilla.PageIndex, Alumno.Text);
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

    protected void Alumno_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex, Alumno.Text);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex, Alumno.Text);
    }


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
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
            }
        }
    }
}