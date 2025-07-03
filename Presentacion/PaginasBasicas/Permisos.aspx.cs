using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Permisos : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.PerfilMenu ocnPerfilMenu = new GESTIONESCOLAR.Negocio.PerfilMenu();
    GESTIONESCOLAR.Negocio.Menu ocnMenu = new GESTIONESCOLAR.Negocio.Menu();
    bool Existe = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Permisos";

                

                perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new GESTIONESCOLAR.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); perId.DataBind();
                perId_SelectedIndexChanged(sender, e);
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

    protected void perId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*CARGAR GRILLA*/
            GrillaPermisoCargar(GrillaPermiso.PageIndex);

            /*CARGAR COMBO DE PERMISOS*/
            int perId1 = 0;
            if (perId.SelectedIndex > 0) perId1 = Convert.ToInt32(perId.SelectedValue);

            menId.DataValueField = "Valor"; menId.DataTextField = "Texto"; menId.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerListaAsociarACustom(perId1); menId.DataBind();
            menId.Focus();
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

    protected void menId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Validar si el item NO existe en la grilla
            Existe = false;

            for (int i = 0; i < this.GrillaPermiso.Rows.Count; i++)
            {
                if (menId.SelectedItem.Text == this.GrillaPermiso.Rows[i].Cells[1].Text)
                {
                    Existe = true;
                    i = this.GrillaPermiso.Rows.Count;
                }
            }

            if (!Existe)
            {
                ocnPerfilMenu = new GESTIONESCOLAR.Negocio.PerfilMenu();
                ocnPerfilMenu.perId = Convert.ToInt32(perId.SelectedValue);
                ocnPerfilMenu.menId = Convert.ToInt32(menId.SelectedValue);
                ocnPerfilMenu.pmeActivo = true;
                ocnPerfilMenu.pmeFechaHoraCreacion = DateTime.Now;
                ocnPerfilMenu.pmeFechaHoraUltimaModificacion = DateTime.Now;
                ocnPerfilMenu.usuIdCreacion = 1;
                ocnPerfilMenu.usuIdUltimaModificacion = 1;

                ocnPerfilMenu.Insertar();

                GrillaPermisoCargar(this.GrillaPermiso.PageIndex);
                this.menId.Focus();
            }

            /*LIMPIAR LOS PADRES QUE NO TENGAN HIJOS PARA ESE PERFIL*/
            ocnPerfilMenu.EliminarPadresSinHijos(Convert.ToInt32(perId.SelectedValue));
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

    protected void GrillaPermiso_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.GrillaPermisoCargar(e.NewPageIndex);
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void GrillaPermiso_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page")
            {
                string Id = this.GrillaPermiso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                if (e.CommandName == "Quitar")
                {
                    ocnPerfilMenu.Eliminar(Convert.ToInt32(Id));
                    this.GrillaPermisoCargar(this.GrillaPermiso.PageIndex);
                    this.menId.Focus();
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void GrillaPermiso_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }

            if (GrillaPermiso.Rows.Count > 0)
            {
                foreach (GridViewRow Fila in GrillaPermiso.Rows)
                {
                    if (Fila.Cells[2].Text == "No") Fila.BackColor = System.Drawing.Color.Pink;
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void GrillaPermisoCargar(int PageIndex)
    {
        try
        {
            this.GrillaPermiso.DataSource = ocnPerfilMenu.ObtenerxperIdCustom(Convert.ToInt32(perId.SelectedValue));
            this.GrillaPermiso.PageIndex = PageIndex;
            this.GrillaPermiso.DataBind();

            menId.DataValueField = "Valor"; 
            menId.DataTextField = "Texto"; 
            menId.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerListaAsociarACustom(Convert.ToInt32(perId.SelectedValue)); 
            menId.DataBind();
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }
}