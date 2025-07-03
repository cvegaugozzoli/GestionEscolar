using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;



public partial class AlumnosDebitoConsulta : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.AlumnosDebitos ocnAlumnosDebitos = new GESTIONESCOLAR.Negocio.AlumnosDebitos();

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
                this.Master.TituloDelFormulario = " Alumnos Débito - Consulta";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["AlumnosDebitoConsulta.PageIndex"] == null)
                {
                    Session.Add("AlumnosDebitoConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["AlumnosDebitoConsulta.PageIndex"]);
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
            Response.Redirect("AlumnosDebitoRegistracion.aspx?Id=0", false);
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


    protected void btnActivar_Click(object sender, EventArgs e)
    {
        try
        {

            //Id = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["adeId"]);
            //ocnAlumnosDebitos = new GESTIONESCOLAR.Negocio.AlumnosDebitos(Id);
            //ocnAlumnosDebitos.adeDNITitular = adeDNITitular.Text;
            //ocnAlumnosDebitos.adeApeNom = adeApeNom.Text;
            //ocnAlumnosDebitos.adeCBU = adeCBU.Text;
            //ocnAlumnosDebitos.adeFchProbCobro = 1;
            //ocnAlumnosDebitos.adeLugarTrabajo = adeLugarTrabajo.Text;
            //ocnAlumnosDebitos.adeMail = adeMail.Text;
            //ocnAlumnosDebitos.adeCelular = adeCelular.Text;
            //ocnAlumnosDebitos.adeFchInicio = Convert.ToDateTime(this.adeFchInicio.Text);
            //ocnAlumnosDebitos.adeFchBaja = Convert.ToDateTime((adeFchBaja.Text == "" ? "01/01/0001" : adeFchBaja.Text));
            //ocnAlumnosDebitos.tcuId = Convert.ToInt32(tcuId.SelectedValue);
            //ocnAlumnosDebitos.aluId = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);

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


    //protected void btnExportarAExcel_Click(object sender, EventArgs e)
    //{
    //    dt = new DataTable();
    //    dt = ocnAlumnosDebitos.ObtenerTodo();
    //    string ArchivoNombre = "DocentesConsulta_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
    //    FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    //}

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["AlumnosDebitoConsulta.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion

            dt = new DataTable();
            dt = ocnAlumnosDebitos.ObtenerUnoxNombrexBajas(Nombre.Text.Trim(), chkBajas.Checked );
            this.Grilla.DataSource = dt;
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();

            gridtemp.DataSource = dt;
            gridtemp.DataBind();

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

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //ocnDocentes.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                //if (e.CommandName == "Copiar")
                //{
                //    ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes(Convert.ToInt32(Id));
                //    //ocnDocentes.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Ver")
                //{
                //    Response.Redirect("DocentesRegistracion.aspx?Id=" + Id + "&Ver=1", false);
                //}
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
            // Añadir atributo onclick para gestionar la selección
            e.Row.Attributes.Add("onclick", "SelectRow(this);");

            // Obtener un valor de la fila actual para pasarlo como parámetro (por ejemplo, un ID)
            string id = DataBinder.Eval(e.Row.DataItem, "adeId").ToString();

            if (chkBajas.Checked)
            {
                if (chkActivar.Checked)
                {
                    // Agregar atributo onclick para redirigir
                    e.Row.Attributes.Add("onclick", string.Format("window.location='AlumnosDebitoActivacion.aspx?id={0}';", id));
                } else
                {
                    // Agregar atributo onclick para redirigir
                    e.Row.Attributes.Add("onclick", string.Format("window.location='AlumnosDebitoRegistracion.aspx?id={0}';", id));
                }
            } else
            {
                // Agregar atributo onclick para redirigir
                e.Row.Attributes.Add("onclick", string.Format("window.location='AlumnosDebitoRegistracion.aspx?id={0}';", id));
            }
                


        }
    }

    //if (e.Row.RowType == DataControlRowType.DataRow)
    //{
    //    // Obtener un valor de la fila actual para pasarlo como parámetro (por ejemplo, un ID)
    //    string id = DataBinder.Eval(e.Row.DataItem, "ID").ToString();

    //// Agregar atributo onclick para redirigir
    //e.Row.Attributes.Add("onclick", $"window.location='NuevaPagina.aspx?id={id}';");
    //}


//protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
//{
//    if (e.Row.RowType == DataControlRowType.DataRow)
//    {
//        e.Row.Attributes.Add("onclick", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");

//    }
//}

//e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
//e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["AlumnosDebitoConsulta.PageIndex"] != null)
            {
                Session["AlumnosDebitoConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("AlumnosDebitoConsulta.PageIndex", e.NewPageIndex);
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

            //ocnAlumnosDebitos.Eliminar(Id);

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
    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
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



    protected void chkChange(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }


    protected void btnImprimir(object sender, EventArgs e)
    {
        //alerError.Visible = false;
        try
        {
            //insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 ParamInt1 = 1;
            if (chkBajas.Checked )
            {
                ParamInt1 = 0;
            }
            NomRep = "InformeAlumnosDebitos.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);

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


    protected void Exportar_Click(object sender, EventArgs e)
    {
        gridtemp.Columns[0].Visible = true;
        gridtemp.Columns[1].Visible = true;
        gridtemp.Columns[2].Visible = true;
        gridtemp.Columns[3].Visible = true;
        gridtemp.Columns[4].Visible = true;
        gridtemp.Columns[5].Visible = true;
        gridtemp.Columns[6].Visible = true;
        gridtemp.Columns[7].Visible = true;
        gridtemp.Columns[8].Visible = true;
        
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
        gridtemp.Columns[0].Visible = false;
        gridtemp.Columns[1].Visible = false;
        gridtemp.Columns[2].Visible = false;
        gridtemp.Columns[3].Visible = false;
        gridtemp.Columns[4].Visible = false;
        gridtemp.Columns[5].Visible = false;
        gridtemp.Columns[6].Visible = false;
        gridtemp.Columns[7].Visible = false;
        gridtemp.Columns[8].Visible = false;

    }

}