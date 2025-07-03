
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Net;       // No olvidar.
using System.Net.Mail;

public partial class ComunicadoaDocente : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Docentes ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Comunicado a Docentes";
                Session["Bandera"] = 0;
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


    private void GrillaBuscarCargar(int PageIndex)
    {
        try
        {
            Session["Comunicado.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnDocentes.ObtenerUnoxNombre(TextBuscar.Text.Trim());
                this.GrillaBuscar.DataSource = dt;
                this.GrillaBuscar.PageIndex = PageIndex;
                this.GrillaBuscar.DataBind();
            }
            else
            {
                dt = ocnDocentes.ObtenerUnoxDoc(TextBuscar.Text.Trim());
                this.GrillaBuscar.DataSource = dt;
                this.GrillaBuscar.PageIndex = PageIndex;
                this.GrillaBuscar.DataBind();
            }

            if (dt.Rows.Count > 0)
            {
                lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
            }
            else
            {
                lblCantidadRegistros2.Text = "No se encuentra Alumno con esa descripción o DNI";
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


    protected void btnEnviar_Click(object sender, EventArgs e)
    {


        try
        {
            dt = new DataTable();
            dt = ocnDocentes.ObtenerTodo();


            GESTIONESCOLAR.Negocio.Email Cr = new GESTIONESCOLAR.Negocio.Email();
            MailMessage mnsj = new MailMessage();
            mnsj.Subject = Asuntotxt.Text;
            mnsj.From = new MailAddress("misericordistasgo@gmail.com");
            mnsj.Body = Mje.Text;
            /* Enviar */


            if (chkTodos.Checked == true)
            {

                if (dt.Rows.Count > 0)
                {
                    // Por Cada familiarenviar mail
                    foreach (DataRow row in dt.Rows)
                    {
                        string Mail1 = dt.Rows[0]["Mail"].ToString();
                        mnsj.To.Add(Mail1);

                        Cr.MandarCorreo(mnsj);
                    }
                }

                /* Limpiar y Mensaje confirmación */
                famApellido.Text = "";
                Asuntotxt.Text = "";
                //Asunto.Text = "";
                Mail.Text = "";
                Mje.Text = "";
                lblCorreo.Text = ("El Mail se ha Enviado Correctamente a todos los familiares, Listo!!");
            }

            else
            {
                mnsj.To.Add(new MailAddress(Mail.Text));
                string Mail1 = Mail.Text;
                mnsj.To.Add(new MailAddress(Mail.Text));
                Cr.MandarCorreo(mnsj);
                famApellido.Text = "";
                Asuntotxt.Text = "";
                //Asunto.Text = "";
                Mail.Text = "";
                Mje.Text = "";
                lblCorreo.Text = ("El Mail se ha Enviado Correctamente, Listo!!");
            }
        }
        catch (Exception oError)
        {

            lblCorreo.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }

    }

    protected void GrillaBuscar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                String Id = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                if (e.CommandName == "Select")
                {
                    famApellido.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    famApellido.Enabled = false;            
                    Mail.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Controls[1]).Text;
                    Mail.Enabled = false;

                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["Comunicado.PageIndex"]);


                    GrillaBuscar.DataSource = null;
                    GrillaBuscar.DataBind();

                    //aluLegajoNumero.Text= ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;

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
        //dt = new DataTable();
        //this.Grilla.DataSource = dt;
        //this.Grilla.DataBind();
        GrillaBuscarCargar(GrillaBuscar.PageIndex);
    }

    protected void GrillaBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaBuscar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaBuscar, "Select$" + row.RowIndex, true);
            }
        }

        base.Render(writer);
    }


    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
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
        Asuntotxt.Text = "";
        famApellido.Text = "";
        TextBuscar.Text = "";
        Mail.Text = "";
    }

    protected void GrillaBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["Comunicado.PageIndex"] != null)
            {
                Session["Comunicado.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("Comunicado.PageIndex", e.NewPageIndex);
            }

            this.GrillaBuscarCargar(e.NewPageIndex);
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

