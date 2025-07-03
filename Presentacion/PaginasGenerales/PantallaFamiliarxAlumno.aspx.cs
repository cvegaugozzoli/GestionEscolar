using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PantallaFamiliarxAlumno : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    int insId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                dt = ocnFamiliar.ObtenerUnoxUsuId(usuario);
                if (dt.Rows.Count != 0)
                {
                    int famId = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    lblMensajeError.Text = "";

                    this.Master.TituloDelFormulario = "Sr/a : " + dt.Rows[0][1].ToString() +
                 " seleccione menor a cargo y año académico";

                    insId = Convert.ToInt32(Session["_Institucion"]);

                    HijosId.DataValueField = "Valor"; HijosId.DataTextField = "Texto"; HijosId.DataSource = (new GESTIONESCOLAR.Negocio.AlumnoFamiliar()).ObtenerListaHijos("[Seleccionar...]", famId); HijosId.DataBind();
                    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();

                    if (HijosId.Items.Count == 2)//Asigno al combo el nombre del unico hijo
                    {
                        HijosId.SelectedIndex = 1;
                        HijosId.Enabled = false;
                        String aluId2 = HijosId.SelectedValue;
                        AluId.Text = aluId2;
                    }


                    lblTituloTabla.Visible = false;
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["PantallaFamiliarxAlumno.PageIndex"] == null)
                {
                    Session.Add("PantallaFamiliarxAlumno.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["PantallaFamiliarxAlumno.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros


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

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaHijos.Rows)
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
            if (Convert.ToInt32(HijosId.SelectedValue) != 0)
            {

                lblTituloTabla.Visible = true;
                AnioCur = Convert.ToInt32(AnioCursado.Text);

                dt = new DataTable();
                dt = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCur, Convert.ToInt32(AluId.Text));
                this.GrillaHijos.DataSource = dt;
                this.GrillaHijos.PageIndex = PageIndex;
                this.GrillaHijos.DataBind();
            }
            else
            {
                lblMensajeError.Text = "Debe seleccionar un valor del combo Alumno..";

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


    protected void GrillaHijos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string IC = ((HyperLink)GrillaHijos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                AnioCur = Convert.ToInt32(AnioCursado.Text);


                if (e.CommandName == "Ver")

                {
                    String TC = ((HyperLink)GrillaHijos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;
                    if (TC == "4")
                    {
                        Response.Redirect("RegistracionCalificacionesRegistracion.aspx?Id=" + IC + "&Ver=1", false);
                    }
                    else
                    {
                        if (TC == "3")
                        {
                            Response.Redirect("CargaCalificacionesPorAlumnoSec.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                        }
                        else
                        {
                            if (TC == "2")
                            {
                                Response.Redirect("CargaCalificacionesPorAlumnoPri.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                            }
                            else

                           if (TC == "1")
                            {
                                lblMjeError2.Text = "El alumno seleccionado es del Nivel Inicial; no se muestra informe..";
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

    protected void GrillaHijos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#CCCCFF';");
        //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        //}
    }

    protected void GrillaHijos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //if (Session["CursoConsulta.PageIndex"] != null)
            //{
            //    Session["CursoConsulta.PageIndex"] = e.NewPageIndex;
            //}
            //else
            //{
            //    Session.Add("CursoConsulta.PageIndex", e.NewPageIndex);
            //}

            //this.GrillaCargar(e.NewPageIndex);
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
        lblMjeError2.Text = "";
        GrillaCargar(GrillaHijos.PageIndex);
    }

    protected void HijosId_SelectedIndexChanged(object sender, EventArgs e)
    {

        String aluId2 = HijosId.SelectedValue;
        AluId.Text = aluId2;
    }
}
