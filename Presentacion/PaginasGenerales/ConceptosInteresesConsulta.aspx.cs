using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConceptosInteresesConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Conceptos Intereses - Consulta";
                insId = Convert.ToInt32(Session["_Institucion"]);
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["ConceptosInteresesConsulta.PageIndex"] == null)
                {
                    Session.Add("ConceptosInteresesConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["ConceptosInteresesConsulta.PageIndex"]);
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
    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
	    try
	    {
            Response.Redirect("ConceptosInteresesRegistracion.aspx?Id=0", false);
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
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = new DataTable();
        dt = ocnConceptosIntereses.ObtenerTodoxinsId(insId);
        string ArchivoNombre = "ConceptosInteresesConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["ConceptosInteresesConsulta.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion

            insId = Convert.ToInt32(Session["_Institucion"]);
            if ((txtAnio.Text != "") || (Nombre.Text != ""))
            {
                dt = new DataTable();
                dt = ocnConceptosIntereses.ObtenerTodoxinsIdxAnio(insId,Nombre.Text, txtAnio.Text);
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
            }
            else
            {
                if ((txtAnio.Text == "") & (Nombre.Text == ""))
                {
                    dt = new DataTable();
                    //dt = ocnConceptos.ObtenerTodoBuscarxNombrexAnio(Nombre.Text.Trim(), insId, txtAnio.Text);
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
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
			    string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

			    if (e.CommandName == "Eliminar")
			    {
				    //ocnConceptosIntereses.Eliminar(Convert.ToInt32(Id));
				    this.GrillaCargar(this.Grilla.PageIndex);
			    }

			    if (e.CommandName == "Copiar")
			    {
				    ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(Convert.ToInt32(Id));
				    //ocnConceptosIntereses.Copiar();
				    this.GrillaCargar(this.Grilla.PageIndex);
			    }

			    if (e.CommandName == "Ver")
			    {
				    Response.Redirect("ConceptosInteresesRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
            if (Session["ConceptosInteresesConsulta.PageIndex"] != null)
            {
                Session["ConceptosInteresesConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ConceptosInteresesConsulta.PageIndex", e.NewPageIndex);
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

            ocnConceptosIntereses.Eliminar(Id);

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


}