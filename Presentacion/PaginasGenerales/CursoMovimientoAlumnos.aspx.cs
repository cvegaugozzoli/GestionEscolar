using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CursoMovimientoAlumnos : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable AlumnosSleccionados = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Corrección - Movimiento";
                insId = Convert.ToInt32(Session["_Institucion"]);
                carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                carId2.DataValueField = "Valor"; carId2.DataTextField = "Texto"; carId2.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId2.DataBind();
                //MovimientoId.DataValueField = "Valor"; MovimientoId.DataTextField = "Texto"; MovimientoId.DataSource = (new GESTIONESCOLAR.Negocio.Movimiento()).ObtenerLista("[Seleccionar...]"); MovimientoId.DataBind();
                Session.Add("TablaTemp", dt3);
                lblCarrera2.Visible = false;
                lblPlanId2.Visible = false;
                lblcurso2.Visible = false;
                lblanio2.Visible = false;
                carId2.Visible = false;
                plaId2.Visible = false;
                curId2.Visible = false;
                AnioCursado2.Visible = false;
                lblmovimiento.Visible = false;
                MovimientoId.Visible = false;
                BtnGrabar.Visible = false;
                MovimientoId.Visible = false;
                //DropDownList1.Visible = false;
                //Label1.Visible= false;
                //Button1.Visible = false;
                //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                #region PageIndex
                int PageIndex = 0;
                if (this.Session["CursoMovimientoAlumnos.PageIndex"] == null)
                {
                    Session.Add("CursoMovimientoAlumnos.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]


                #endregion

                GrillaCargar(PageIndex);
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
        foreach (GridViewRow row in GrillaAlumnos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }


    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["CursoListadoAlumnos.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros

            #endregion
            insId = Convert.ToInt32(Session["_Institucion"]);
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
            else
            {
                Session.Add("CursoListadoAlumnos.curId", cur);
            }


            if (AnioCursado.Text == "")
            {

                int Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                DateTime fechaActual = DateTime.Today;
                AnioCur = Anio;

            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }

            dt = new DataTable();
            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);
            Session.Add("GrillaOriginal", dt);
            this.GrillaAlumnos.DataSource = dt;
            this.GrillaAlumnos.PageIndex = PageIndex;
            this.GrillaAlumnos.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCarrera2.Visible = true;
                lblPlanId2.Visible = true;
                lblcurso2.Visible = true;
                lblanio2.Visible = true;
                carId2.Visible = true;
                plaId2.Visible = true;
                curId2.Visible = true;
                AnioCursado2.Visible = true;
                lblCantidadRegistros2.Text = "";
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                btnSeleccionar.Visible = true;
                lblCursoD.Visible = true;

            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
                btnSeleccionar.Visible = false;
                MovimientoId.Visible = false;
                lblmovimiento.Visible = false;
                BtnGrabar.Visible = false;
                //btnSeleccionarTodo.Visible = false;
            }

            //dt = ocnCurso.ObtenerporCarporPlaporCurAnio(car, pla, cur, AnioCur);
            //this.GrillaAlumnos2.DataSource = dt;
            //this.GrillaAlumnos2.PageIndex = PageIndex;
            this.GrillaAlumnos2.DataBind();

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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            carIdCargar();
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
    protected void carId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            carId2Cargar();
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
    private void carIdCargar()
    {
        try
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



    private void carId2Cargar()
    {
        try
        {
            if (carId.SelectedIndex > 0)
            {

                //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
                DataTable dt = new DataTable();
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId2.DataValueField = "Valor";
                    plaId2.DataTextField = "Texto";
                    plaId2.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId2.SelectedValue));
                    plaId2.DataBind();
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

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            plaIdCargar();
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
        try
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

    protected void plaId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            plaId2Cargar();
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
    private void plaId2Cargar()
    {
        try
        {
            if (plaId.SelectedIndex > 0)
            {

                //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
                DataTable dt = new DataTable();
                dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId2.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    curId2.DataValueField = "Valor";
                    curId2.DataTextField = "Texto";
                    curId2.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId2.SelectedValue));
                    curId2.DataBind();
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
            //int Id = 0;
            //Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;
            //int index = e.RowIndex;

            //int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["TablaTemp"] as DataTable;
            dt1.Rows[RowId].Delete();
            Session["TablaTemp"] = dt1;

            GrillaAlumnos2.DataSource = dt1;
            GrillaAlumnos2.DataBind();
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
    protected void rbSelector_CheckedChanged(object sender, System.EventArgs e)
    {
        //Clear the existing selected row 
        foreach (GridViewRow oldrow in GrillaAlumnos.Rows)
        {
            ((RadioButton)oldrow.FindControl("rbSelector")).Checked = false;
        }


        //Set the new selected row
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        ((RadioButton)row.FindControl("rbSelector")).Checked = true;
    }


    protected void MovimientoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BtnGrabar.Enabled = true;
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


    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
            lblCarrera2.Visible = false;
            lblPlanId2.Visible = false;
            lblcurso2.Visible = false;
            lblanio2.Visible = false;
            carId2.Visible = false;
            plaId2.Visible = false;
            curId2.Visible = false;
            AnioCursado2.Visible = false;
            MovimientoId.Visible = true;
            //DropDownList1.Visible = true;
            //Label1.Visible = true;
            //Button1.Visible = true;
            GrillaCargar(PageIndex);
            lblCantidadRegistros.Visible = true;
            lblListado.Visible = true;
            BtnGrabar.Enabled = false;
            MovimientoId.SelectedIndex = 0;
            lblCantidadRegistros2.Text = "";
            lblMensajeError2.Text = "";
            lblMensajeError2.ForeColor = System.Drawing.Color.Blue;
            MovimientoId.Visible = false;
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


    protected void btnSeleccionar_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            lblMensajeError2.Text = "";
            lblMensajeError.Text = "";
            lblMensajeError2.ForeColor = System.Drawing.Color.Blue;
            dt.Columns.Add("IC", typeof(int));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("DNI", typeof(int));
            dt.Columns.Add("aluId", typeof(int));
            dt.Columns.Add("Estado", typeof(int));
            foreach (GridViewRow row in GrillaAlumnos.Rows)
            {
                RadioButton rdbutton = row.FindControl("rbSelector") as RadioButton;
                //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                if ((rdbutton.Checked)) // & (EstIC == 1)
                {
                    DataRow row1 = dt.NewRow();
                    row1["IC"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Id"]);
                    row1["Nombre"] = Convert.ToString(GrillaAlumnos.DataKeys[row.RowIndex].Values["Alumno"]); ;
                    row1["DNI"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Dni"]);
                    row1["aluId"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);
                    row1["Estado"] = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
                    dt.Rows.Add(row1);
                }
            }
            GrillaAlumnos2.DataSource = dt;
            Session.Add("TablaTemp", dt);
            lblCantidadRegistros2.Visible = true;
            lblListado2.Visible = true;
            GrillaAlumnos2.DataBind();
            if (dt.Rows.Count > 0)
            {
                lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                lblmovimiento.Visible = true;
                MovimientoId.Visible = true;
                BtnGrabar.Visible = true;

            }
            else
            {
                lblCantidadRegistros2.Text = "Cantidad de registros: 0";
                lblMensajeError.Visible = true;
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
                lblMensajeError.Text = "Seleccione un Alumno del Curso a Modificar.." + "</div>";
                return;
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

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (lblCantidadRegistros2.Text != "")
            {
                dt4 = Session["TablaTemp"] as DataTable;
                int Mov = 0;

                if (dt4.Rows.Count > 0)
                {

                    Mov = Convert.ToInt32(MovimientoId.SelectedValue);

                    if (Mov == 1) // Cursando
                    {
                        foreach (GridViewRow row in GrillaAlumnos2.Rows)
                        {
                            Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                            Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]);
                            Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            int icuEliminar;

                            DataTable dt5 = new DataTable();
                            if ((EstadoAnt == 3) | (EstadoAnt == 2))  // Si el estado Anterior es = Repite o promociona
                            {
                                ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 1); // cambio Estado ant a Cursando        
                                int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;
                                dt5 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId); // Busco inscripcion de alumno alumno año siguiente

                                if (dt5.Rows.Count > 0)
                                {
                                    icuEliminar = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());

                                    //ocnInscripcionCursado.Eliminar(icuEliminar); // Elimino Incripcion erronea
                                    //ocnRegistracionNota.EliminarporIC(icuEliminar); // Elimino Registros Nota de  Incripcion erronea
                                    lblMensajeError2.Text = "Se Realizó la Operación Cursando para el registro seleccionado..";
                                    int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                    GrillaCargar(PageIndex);
                                }
                                else
                                {
                                    lblMensajeError2.Text = "Se cambió Estado pero No existe el Alumno en los curso del año siguiente..";
                                }
                            }

                            if (EstadoAnt == 5) // Si el estado Anterior es = Cambio Colegio 
                            {
                                ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 5); // cambio Estado ant a Cambio Colegio
                                lblMensajeError2.Text = "Se Realizó la Operación Cursando para el registro seleccionado..";
                                int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                GrillaCargar(PageIndex);
                            }
                        }
                    }

                    if (Mov == 2) // Promociona
                    {
                        int proxanio = Convert.ToInt32(AnioCursado.Text) + 1;
                        int bandera = 0;

                        foreach (GridViewRow row in GrillaAlumnos2.Rows)
                        {
                            Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                            Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]);
                            Int32 EstadoIns = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            DateTime FechaInscripcion = DateTime.Now;
                            int carIdD = Convert.ToInt32((carId2.SelectedValue.Trim() == "" ? "0" : carId2.SelectedValue));
                            int plaIdD = Convert.ToInt32((plaId2.SelectedValue.Trim() == "" ? "0" : plaId2.SelectedValue));
                            int curIdD = Convert.ToInt32((curId2.SelectedValue.Trim() == "" ? "0" : curId2.SelectedValue));
                            //int camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                            /*....usuId = this.Master.usuId;*/
                            DateTime icuFechaHoraCreacion = DateTime.Now;
                            DateTime icuFechaHoraUltimaModificacion = DateTime.Now;
                            int usuIdCreacion = this.Master.usuId;
                            int UsuIdUltimaModificacion = this.Master.usuId;
                            Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            int PageIndex;

                            if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                            {
                                if (AnioCursado2.Text == Convert.ToString(proxanio))
                                {
                                    ///Controlo que el alumno no se encuentre inscripto en ese curso en ese año
                                    DataTable dt2 = new DataTable();
                                    DataTable dt1 = new DataTable();

                                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                    if (dt2.Rows.Count == 0)
                                    {
                                        String AnioNuevo = AnioCursado2.Text;

                                        int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true,"", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                        ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 2);

                                        //////////////////////////////////////////////////////

                                        DataTable dt5 = new DataTable();

                                        dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                        if (dt5.Rows.Count > 0)
                                        {
                                            // Por Cada Materia inserto un registro Nota para ese alumno.
                                            foreach (DataRow row2 in dt5.Rows)
                                            {
                                                int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                                ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            }
                                        }

                                        lblMensajeError2.Text = "Se Realizó la Operación Promociona para el registro seleccionado..";
                                        PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                        GrillaCargar(PageIndex);
                                    }

                                    lblMensajeError2.Text = "Ya existe una Inscripción de ese Alumno para el Año siguiente..";
                                }
                                else
                                {
                                    lblMensajeError.Text = "El Año de Cursado del Curso Destino debe ser el siguiente al del Curso de Origen";
                                    return;
                                }
                            }

                            if (EstadoAnt == 3) // Si el estado Anterior es = Repite 
                            {
                                if (AnioCursado2.Text == Convert.ToString(proxanio))
                                {
                                    ///Controlo que el alumno no se encuentre inscripto en ese curso en ese año
                                    DataTable dt2 = new DataTable();
                                    DataTable dt1 = new DataTable();
                                    int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;

                                    dt1 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId);

                                    if (dt1.Rows.Count > 0) // Si el Alumno existe en año posterior, elimino esa inscripción
                                    {
                                        int icuEliminar = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                                        //ocnRegistracionNota.EliminarporIC(icuEliminar);
                                        //ocnInscripcionCursado.Eliminar(icuEliminar);
                                    }

                                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                    if (dt2.Rows.Count == 0)  // Si el Alumno no existe en año posterior, para el curso destino.. Inserto
                                    {
                                        String AnioNuevo = AnioCursado2.Text;
                                        int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                        ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 2);

                                        //////////////////////////////////////////////////////

                                        DataTable dt5 = new DataTable();

                                        dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                        if (dt5.Rows.Count > 0)
                                        {
                                            // Por Cada Materia inserto un registro Nota para ese alumno.
                                            foreach (DataRow row2 in dt5.Rows)
                                            {
                                                int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                                ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            }
                                        }


                                        lblMensajeError2.Text = "Se Realizó la Operación Promociona para el registro seleccionado..";
                                        PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                        GrillaCargar(PageIndex);
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "El Año de Cursado del Curso Destino debe ser el siguiente al del Curso de Origen";
                                    return;
                                }
                            }

                            if (EstadoAnt == 5) // Si el estado Anterior es = Cambio Colegio 
                            {

                                dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                if (dt2.Rows.Count == 0)  // Si el Alumno no existe en año posterior, para el curso destino.. Inserto
                                {
                                    String AnioNuevo = AnioCursado2.Text;
                                    int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                    ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 2);

                                    //////////////////////////////////////////////////////

                                    DataTable dt5 = new DataTable();

                                    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                    if (dt5.Rows.Count > 0)
                                    {
                                        // Por Cada Materia inserto un registro Nota para ese alumno.
                                        foreach (DataRow row2 in dt5.Rows)
                                        {
                                            int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                            ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                        }
                                    }

                                    lblMensajeError2.Text = "Se Realizó la Operación PROMOCIONA para el registro seleccionado..";
                                    PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                    GrillaCargar(PageIndex);
                                }
                            }
                        }
                    }
                    if (Mov == 3) //  Repite
                    {
                        int proxanio = Convert.ToInt32(AnioCursado.Text) + 1;
                        int bandera = 0;

                        foreach (GridViewRow row in GrillaAlumnos2.Rows)
                        {
                            Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                            Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]);
                            Int32 EstadoIns = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            DateTime FechaInscripcion = DateTime.Now;
                            int carIdD = Convert.ToInt32((carId2.SelectedValue.Trim() == "" ? "0" : carId2.SelectedValue));
                            int plaIdD = Convert.ToInt32((plaId2.SelectedValue.Trim() == "" ? "0" : plaId2.SelectedValue));
                            int curIdD = Convert.ToInt32((curId2.SelectedValue.Trim() == "" ? "0" : curId2.SelectedValue));
                            //int camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                            /*....usuId = this.Master.usuId;*/
                            DateTime icuFechaHoraCreacion = DateTime.Now;
                            DateTime icuFechaHoraUltimaModificacion = DateTime.Now;
                            int usuIdCreacion = this.Master.usuId;
                            int UsuIdUltimaModificacion = this.Master.usuId;
                            Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            int PageIndex;

                            if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                            {

                                if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione una Carrera en Curso Destino.." + "</div>";
                                    return;
                                }

                                if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Plan de Estudio en Curso Destino" + "</div>";
                                    return;
                                }
                                if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Curso en en Curso Destino!.." + "</div>";
                                    return;
                                }

                                if (AnioCursado2.Text.Trim() == "")
                                {

                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione Año de cursado en Curso Destino.." + "</div>";
                                    return;
                                }
                                if (AnioCursado2.Text == Convert.ToString(proxanio))
                                {
                                    DataTable dt2 = new DataTable();
                                    DataTable dt1 = new DataTable();
                                    ///Controlo que el alumno no se encuentre inscripto en ese curso en ese año
                                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                    if (dt2.Rows.Count == 0)
                                    {

                                        int AnioCursadoD = Convert.ToInt32(AnioCursado2.Text);
                                        int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, AnioCursadoD, FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                        ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 3);// Actualizo IC ANTERIOR A Estado IGUAL Repite

                                        //////////////////////////////////////////////////////

                                        DataTable dt5 = new DataTable();

                                        dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                        if (dt5.Rows.Count > 0)
                                        {
                                            // Por Cada Materia inserto un registro Nota para ese alumno.
                                            foreach (DataRow row2 in dt5.Rows)
                                            {
                                                int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                                ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            }
                                        }
                                    }
                                    lblMensajeError2.Text = "Se Realizó la Operación REPITE para el  registro seleccionado..";
                                    PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                    GrillaCargar(PageIndex);
                                }
                                else
                                {
                                    lblMensajeError.Text = "El Año de Cursado del Curso Destino debe ser el siguiente al del Curso de Origen";
                                    return;
                                }
                            }

                            if ((EstadoAnt == 2))  // Si el estado Anterior promociona
                            {
                                DataTable dt6 = new DataTable();
                                ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 3); // cambio Estado ant a Repite        
                                int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;

                                if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione una Carrera en Curso Destino.." + "</div>";
                                    return;
                                }

                                if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Plan de Estudio en Curso Destino" + "</div>";
                                    return;
                                }
                                if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Curso en en Curso Destino!.." + "</div>";
                                    return;
                                }

                                if (AnioCursado2.Text.Trim() == "")
                                {

                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione Año de cursado en Curso Destino.." + "</div>";
                                    return;
                                }

                                dt6 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId); // Busco inscripcion de alumno alumno año siguiente

                                if (dt6.Rows.Count > 0)
                                {
                                    int icuEliminar = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());

                                    //ocnInscripcionCursado.Eliminar(icuEliminar); // Elimino Incripcion erronea
                                    //ocnRegistracionNota.EliminarporIC(icuEliminar); // Elimino Registros Nota de  Incripcion erronea

                                    String AnioNuevo = AnioCursado2.Text;
                                    dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                    if (dt2.Rows.Count == 0)
                                    {
                                        int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia

                                        //////////////////////////////////////////////////////

                                        DataTable dt5 = new DataTable();

                                        dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                        if (dt5.Rows.Count > 0)
                                        {
                                            // Por Cada Materia inserto un registro Nota para ese alumno.
                                            foreach (DataRow row2 in dt5.Rows)
                                            {
                                                int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                                ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            }
                                        }

                                        lblMensajeError2.Text = "Se Realizó la Operación REPITE para el  registro seleccionado..";
                                        PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                        GrillaCargar(PageIndex);
                                    }


                                }
                                else
                                {
                                    lblMensajeError2.Text = "No existe el Alumno en los curso del año siguiente..";
                                    return;
                                }
                            }

                            if (EstadoAnt == 5) // Si el estado Anterior es = Cambio Colegio 
                            {
                                dt2 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId, Convert.ToInt32(curId2.SelectedValue), Convert.ToInt32(AnioCursado2.Text.Trim().ToString()));
                                if (dt2.Rows.Count == 0)
                                {

                                    int AnioCursadoD = Convert.ToInt32(AnioCursado2.Text);
                                    int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, AnioCursadoD, FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                    ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 3);// Actualizo IC ANTERIOR A Estado IGUAL Repite

                                    //////////////////////////////////////////////////////

                                    DataTable dt5 = new DataTable();

                                    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                    if (dt5.Rows.Count > 0)
                                    {
                                        // Por Cada Materia inserto un registro Nota para ese alumno.
                                        foreach (DataRow row2 in dt5.Rows)
                                        {
                                            int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                            ocnRegistracionNota.Insertar(icuId2, escId2, 1,this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                        }
                                    }
                                }
                                lblMensajeError2.Text = "Se Realizó la Operación REPITE para el  registro seleccionado..";
                                PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                GrillaCargar(PageIndex);
                            }
                        }
                    }


                    if (Mov == 5) //Cambio Colegio
                    {

                        DataTable dt2 = new DataTable();
                        DataTable dt1 = new DataTable();

                        foreach (GridViewRow row in GrillaAlumnos2.Rows)
                        {
                            Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                            Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]); ;
                            Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);

                            if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                            {

                                ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 5);// Actualizo IC ANTERIOR A Estado IGUAL Cambio Colegio
                                lblMensajeError2.Text = "Se Realizó la Operación Cambio de Colegio para el registro seleccionado..";
                                int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                GrillaCargar(PageIndex);

                            }

                            if ((EstadoAnt == 2))  // Si el estado Anterior promociona
                            {
                                DataTable dt6 = new DataTable();
                                ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 5); // cambio Estado ant a Cambio Colegio        
                                int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;
                                dt6 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId); // Busco inscripcion de alumno alumno año siguiente

                                if (dt6.Rows.Count > 0)
                                {
                                    int icuEliminar = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());

                                    //ocnInscripcionCursado.Eliminar(icuEliminar); // Elimino Incripcion erronea
                                    //ocnRegistracionNota.EliminarporIC(icuEliminar); // Elimino Registros Nota de  Incripcion erronea
                                }
                                else
                                {
                                    lblMensajeError2.Text = "Se realizó cambio de Estado pero No existe el Alumno en los curso del año siguiente..";
                                    return;
                                }
                            }

                            if ((EstadoAnt == 3))  // Si el estado Anterior Repite
                            {
                                DataTable dt6 = new DataTable();
                                ocnInscripcionCursado.ActualizarEstado(Convert.ToInt32(icuId), 5); // cambio Estado ant a Cambio Colegio        
                                int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;
                                dt6 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId); // Busco inscripcion de alumno alumno año siguiente

                                if (dt6.Rows.Count > 0)
                                {
                                    int icuEliminar = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());

                                    //    ocnInscripcionCursado.Eliminar(icuEliminar); // Elimino Incripcion erronea
                                    //    ocnRegistracionNota.EliminarporIC(icuEliminar); // Elimino Registros Nota de  Incripcion erronea
                                }
                                else
                                {
                                    lblMensajeError2.Text = "Se realizó cambio de Estado pero No existe el Alumno en los curso del año siguiente..";
                                    return;
                                }
                            }
                        }
                    }

                    if (Mov == 4) //Cambio Curso
                    {
                        foreach (GridViewRow row in GrillaAlumnos2.Rows)
                        {
                            String AnioNuevo = AnioCursado2.Text;
                            DateTime FechaInscripcion = DateTime.Now;
                            int carIdD = Convert.ToInt32((carId2.SelectedValue.Trim() == "" ? "0" : carId2.SelectedValue));
                            int plaIdD = Convert.ToInt32((plaId2.SelectedValue.Trim() == "" ? "0" : plaId2.SelectedValue));
                            int curIdD = Convert.ToInt32((curId2.SelectedValue.Trim() == "" ? "0" : curId2.SelectedValue));
                            //int camId = Convert.ToInt32((camId.SelectedValue.Trim() == "" ? "0" : camId.SelectedValue));
                            /*....usuId = this.Master.usuId;*/
                            DateTime icuFechaHoraCreacion = DateTime.Now;
                            DateTime icuFechaHoraUltimaModificacion = DateTime.Now;
                            int usuIdCreacion = this.Master.usuId;
                            int UsuIdUltimaModificacion = this.Master.usuId;
                            Int32 aluId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["aluId"]); ;
                            Int32 icuId = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["IC"]); ;
                            DataTable dt2 = new DataTable();
                            DataTable dt1 = new DataTable();


                            Int32 EstadoAnt = Convert.ToInt32(GrillaAlumnos2.DataKeys[row.RowIndex].Values["Estado"]);
                            if (EstadoAnt == 1) // Si el estado Anterior es = Cursando 
                            {

                                if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione una Carrera en Curso Destino.." + "</div>";
                                    return;
                                }

                                if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Plan de Estudio en Curso Destino" + "</div>";
                                    return;
                                }
                                if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Curso en en Curso Destino!.." + "</div>";
                                    return;
                                }

                                if (AnioCursado2.Text.Trim() == "")
                                {

                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione Año de cursado en Curso Destino.." + "</div>";
                                    return;
                                }
                                // Elimino inscripcion curso origen..
                                //ocnInscripcionCursado.Eliminar(icuId); // Elimino Incripcion erronea
                                //ocnRegistracionNota.EliminarporIC(icuId); // Elimino Registros Nota de  Incripcion erronea


                                // Inserto nueva inscripción..
                                int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                //////////////////////////////////////////////////////

                                DataTable dt5 = new DataTable();
                                dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                if (dt5.Rows.Count > 0)
                                {
                                    // Por Cada Materia inserto un registro Nota para ese alumno.
                                    foreach (DataRow row2 in dt5.Rows)
                                    {
                                        int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                        ocnRegistracionNota.Insertar(icuId2, escId2, 1,this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                    }
                                }
                                lblMensajeError2.Text = "Se Realizó la Operación Cambio de Curso para el registro seleccionado..";
                                int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                GrillaCargar(PageIndex);
                            }


                            if ((EstadoAnt == 2))  // Si el estado Anterior promociona
                            {
                                DataTable dt6 = new DataTable();

                                if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione una Carrera en Curso Destino.." + "</div>";
                                    return;
                                }

                                if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Plan de Estudio en Curso Destino" + "</div>";
                                    return;
                                }
                                if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Curso en en Curso Destino!.." + "</div>";
                                    return;
                                }

                                if (AnioCursado2.Text.Trim() == "")
                                {

                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione Año de cursado en Curso Destino.." + "</div>";
                                    return;
                                }
                                int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;


                                //Primero elimino inscripción del año siguiente..
                                dt6 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId); // Busco inscripcion de alumno alumno año siguiente

                                if (dt6.Rows.Count > 0)
                                {
                                    int icuEliminar = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                    //ocnInscripcionCursado.Eliminar(icuEliminar); // Elimino Incripcion erronea
                                    //ocnRegistracionNota.EliminarporIC(icuEliminar); // Elimino Registros Nota de  Incripcion erronea
                                }

                                //Segundo elimino inscripción del año actual..
                                //ocnInscripcionCursado.Eliminar(icuId); // Elimino Incripcion erronea
                                //ocnRegistracionNota.EliminarporIC(icuId); // Elimino Registros Nota de  Incripcion erronea


                                // Inserto nueva inscripción..
                                int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                //////////////////////////////////////////////////////

                                DataTable dt5 = new DataTable();
                                dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                if (dt5.Rows.Count > 0)
                                {
                                    // Por Cada Materia inserto un registro Nota para ese alumno.
                                    foreach (DataRow row2 in dt5.Rows)
                                    {
                                        int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                        ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                    }
                                }
                                lblMensajeError2.Text = "Se Realizó la Operación Cambio de Curso para el registro seleccionado..";
                                int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                GrillaCargar(PageIndex);
                            }

                            if ((EstadoAnt == 3))  // Si el estado Anterior Repite
                            {
                                DataTable dt6 = new DataTable();

                                if (Convert.ToInt32(carId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione una Carrera en Curso Destino.." + "</div>";
                                    return;
                                }

                                if (Convert.ToInt32(plaId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Plan de Estudio en Curso Destino" + "</div>";
                                    return;
                                }
                                if (Convert.ToInt32(curId2.SelectedValue) <= 0)
                                {
                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione un Curso en en Curso Destino!.." + "</div>";
                                    return;
                                }

                                if (AnioCursado2.Text.Trim() == "")
                                {

                                    lblMensajeError.Visible = true;
                                    lblMensajeError.ForeColor = System.Drawing.Color.Red;
                                    lblMensajeError.Text = "Seleccione Año de cursado en Curso Destino.." + "</div>";
                                    return;
                                }
                                int anioPosterior = Convert.ToInt32(AnioCursado.Text) + 1;


                                //Primero elimino inscripción del año siguiente..
                                dt6 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, anioPosterior, aluId); // Busco inscripcion de alumno alumno año siguiente

                                if (dt6.Rows.Count > 0)
                                {
                                    int icuEliminar = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                    //    ocnInscripcionCursado.Eliminar(icuEliminar); // Elimino Incripcion erronea
                                    //    ocnRegistracionNota.EliminarporIC(icuEliminar); // Elimino Registros Nota de  Incripcion erronea
                                    //}

                                    //Segundo elimino inscripción del año actual..
                                    //ocnInscripcionCursado.Eliminar(icuId); // Elimino Incripcion erronea
                                    //ocnRegistracionNota.EliminarporIC(icuId); // Elimino Registros Nota de  Incripcion erronea


                                    // Inserto nueva inscripción..
                                    int icuId2 = ocnInscripcionCursado.InsertarTrarId(insId, aluId, carIdD, plaIdD, curIdD, 0, 0, Convert.ToInt32(AnioNuevo), FechaInscripcion, 1, true, "", usuIdCreacion, UsuIdUltimaModificacion, icuFechaHoraCreacion, icuFechaHoraUltimaModificacion,1); //Lo agrego en ese curso o Materia
                                                                                                                                                                                                                                                                                        //////////////////////////////////////////////////////

                                    DataTable dt5 = new DataTable();
                                    dt5 = ocnEspacioCurricular.ObtenerListaPorUnCurso(Convert.ToInt32(curId2.SelectedValue), insId);
                                    if (dt5.Rows.Count > 0)
                                    {
                                        // Por Cada Materia inserto un registro Nota para ese alumno.
                                        foreach (DataRow row2 in dt5.Rows)
                                        {
                                            int escId2 = Convert.ToInt32(row2["Id"].ToString());
                                            ocnRegistracionNota.Insertar(icuId2, escId2,1, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                        }
                                    }
                                    lblMensajeError2.Text = "Se Realizó la Operación Cambio de Colegio para el registro seleccionado..";
                                    int PageIndex = Convert.ToInt32(Session["CursoMovimientoAlumnos.PageIndex"]);
                                    GrillaCargar(PageIndex);
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblMensajeError2.Text = "No seleccionó ningún Alumno..";
                    return;
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
