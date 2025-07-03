using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioConsultaCustom : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario - Consulta";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["UsuarioConsultaCustom.PageIndex"] == null)
                {
                    Session.Add("UsuarioConsultaCustom.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["UsuarioConsultaCustom.PageIndex"]);
                }
                #endregion

                #region Inicializadores
                Perfil.DataValueField = "Valor";
                Perfil.DataTextField = "Texto";
                dt = new DataTable();
                GESTIONESCOLAR.Negocio.Perfil ocnPerfil = new GESTIONESCOLAR.Negocio.Perfil();
                dt = ocnPerfil.ObtenerLista("[Perfil...]");
                Perfil.DataSource = dt;
                Perfil.DataBind();
                #endregion

                #region Variables de sesion para filtros
                if (Session["UsuarioConsultaCustom.Nombre"] != null)
                {
                    Nombre.Text = Convert.ToString(Session["UsuarioConsultaCustom.Nombre"]);
                }
                else
                {
                    Session.Add("UsuarioConsultaCustom.Nombre", "");
                }


                if (Session["UsuarioConsultaCustom.Apellido"] != null)
                {
                    Apellido.Text = Convert.ToString(Session["UsuarioConsultaCustom.Apellido"]);
                }
                else
                {
                    Session.Add("UsuarioConsultaCustom.Apellido", "");
                }


                if (Session["UsuarioConsultaCustom.Usuario"] != null)
                {
                    Usuario.Text = Convert.ToString(Session["UsuarioConsultaCustom.Usuario"]);
                }
                else
                {
                    Session.Add("UsuarioConsultaCustom.Usuario", "");
                }


                if (Session["UsuarioConsultaCustom.Perfil"] != null)
                {
                    Perfil.SelectedValue = Convert.ToString(Session["UsuarioConsultaCustom.Perfil"]);
                }
                else
                {
                    Session.Add("UsuarioConsultaCustom.Perfil", 0);
                }

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
            Response.Redirect("UsuarioRegistracionCustom.aspx?Id=0", false);
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
        #region Poner cero en cajas vacias

        #endregion
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = new DataTable();
        dt = ocnUsuario.ObtenerTodoCustom(this.Nombre.Text, this.Apellido.Text, this.Usuario.Text, Convert.ToInt32(this.Perfil.SelectedValue), insId);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Disposition", "attachment;filename=UsuarioConsultaCustom_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = Encoding.Default;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView Grilla1 = new GridView();
        Grilla1.AllowPaging = false;
        Grilla1.DataSource = dt;
        Grilla1.DataBind();
        Grilla1.RenderControl(htw);

        string style = @"<style> .textmode { } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["UsuarioConsultaCustom.PageIndex"] = PageIndex;
            insId = 0;
            //insId = Convert.ToInt32(Session["_Institucion"]);
            #region Variables de sesion para filtros
            Session["UsuarioConsultaCustom.Nombre"] = Nombre.Text.Trim();
            Session["UsuarioConsultaCustom.Apellido"] = Apellido.Text.Trim();
            Session["UsuarioConsultaCustom.Usuario"] = Usuario.Text.Trim();
            Session["UsuarioConsultaCustom.Perfil"] = Perfil.SelectedValue;
            #endregion

            #region Poner cero en cajas vacias

            #endregion

            dt = new DataTable();
            dt = ocnUsuario.ObtenerTodoCustom(this.Nombre.Text, this.Apellido.Text, this.Usuario.Text, Convert.ToInt32(this.Perfil.SelectedValue), insId);
            this.Grilla.DataSource = dt;
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();


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

                if (e.CommandName == "BlanquearClave")
                {
                    ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Id));
                    ocnUsuario.BlanquearClave(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
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

        if (Grilla.Rows.Count > 0)
        {
            foreach (GridViewRow Fila in Grilla.Rows)
            {

            }
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["UsuarioConsultaCustom.PageIndex"] != null)
            {
                Session["UsuarioConsultaCustom.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("UsuarioConsultaCustom.PageIndex", e.NewPageIndex);
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

    //    protected void lbuEliminar_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            ((LinkButton)sender).Visible = false;
    //            ((LinkButton)sender).Parent.Controls[3].Visible = true;
    //            ((LinkButton)sender).Parent.Controls[5].Visible = true;
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }
    //    }

    protected void lbuBlanquearClave_Click(object sender, EventArgs e)
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

  protected void lbuEliminarReg_Click(object sender, EventArgs e)
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
    //    protected void btnEliminarAceptar_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            int Id = 0;
    //            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

    //            ocnUsuario.Eliminar(Id);

    //            ((Button)sender).Parent.Controls[1].Visible = true;
    //            ((Button)sender).Parent.Controls[3].Visible = false;
    //            ((Button)sender).Parent.Controls[5].Visible = false;

    //            GrillaCargar(Grilla.PageIndex);
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }
    //    }


    protected void btnEliminarRegAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            //ocnUsuario.Eliminar(Id);

            //ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Id));
            ocnUsuario.EliminarxActivo(Convert.ToInt32(Id));
            this.GrillaCargar(this.Grilla.PageIndex);


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


    protected void btnEliminarAceptarBC_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            //ocnUsuario.Eliminar(Id);

            ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario(Convert.ToInt32(Id));
            ocnUsuario.BlanquearClave(Convert.ToInt32(Id));
            this.GrillaCargar(this.Grilla.PageIndex);


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



    //protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    //{
    //    ((Button)sender).Parent.Controls[1].Visible = true;
    //    ((Button)sender).Parent.Controls[3].Visible = false;
    //    ((Button)sender).Parent.Controls[5].Visible = false;
    //}

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("", false);
    }

    protected void btnEliminarCancelarBC_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

  protected void btnEliminarRegCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }
}