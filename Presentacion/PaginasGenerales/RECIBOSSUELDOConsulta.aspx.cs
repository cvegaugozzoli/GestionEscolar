using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class RECIBOSSUELDOConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.RECIBOSSUELDO ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " R E C I B O S S U E L D O - Consulta";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["RECIBOSSUELDOConsulta.PageIndex"] == null)
                {
                    Session.Add("RECIBOSSUELDOConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["RECIBOSSUELDOConsulta.PageIndex"]);
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
	    try
	    {
            Response.Redirect("RECIBOSSUELDORegistracion.aspx?Id=0", false);
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
        dt = new DataTable();
        dt = ocnRECIBOSSUELDO.ObtenerTodo();
        string ArchivoNombre = "RECIBOSSUELDOConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["RECIBOSSUELDOConsulta.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
//[VariablesDeSesionParaFiltros1]
            #endregion

            dt = new DataTable();
            dt = ocnRECIBOSSUELDO.ObtenerTodo();
            this.Grilla.DataSource = dt;
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();

            if(dt.Rows.Count > 0)
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

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
	    try
	    {
		    if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
		    {
			    string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

			    if (e.CommandName == "Eliminar")
			    {
				    //ocnRECIBOSSUELDO.Eliminar(Convert.ToInt32(Id));
				    this.GrillaCargar(this.Grilla.PageIndex);
			    }

			    if (e.CommandName == "Copiar")
			    {
				    ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO(Convert.ToInt32(Id));
				    //ocnRECIBOSSUELDO.Copiar();
				    this.GrillaCargar(this.Grilla.PageIndex);
			    }

			    if (e.CommandName == "Ver")
			    {
				    Response.Redirect("RECIBOSSUELDORegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
            if (Session["RECIBOSSUELDOConsulta.PageIndex"] != null)
            {
                Session["RECIBOSSUELDOConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("RECIBOSSUELDOConsulta.PageIndex", e.NewPageIndex);
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

            ocnRECIBOSSUELDO.Eliminar(Id);

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