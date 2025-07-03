using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class MenuRegistracionCustom : System.Web.UI.Page
{
    private GESTIONESCOLAR.Negocio.PerfilMenu ocnPerfilMenu = new GESTIONESCOLAR.Negocio.PerfilMenu();
    private bool Existe = false;

    GESTIONESCOLAR.Negocio.Menu ocnMenu = new GESTIONESCOLAR.Negocio.Menu();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Menu";

                if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                /*INCIALIZADORES*/
                MenuRaizLista.DataValueField = "Valor"; MenuRaizLista.DataTextField = "Texto"; MenuRaizLista.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerListaRaiz("[Nuevo...]"); MenuRaizLista.DataBind();

                this.MenuRaizLista.Focus();
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            int menIdPadre = -1;
            if (MenuRaizLista.SelectedIndex != 0) menIdPadre = Convert.ToInt32(MenuRaizLista.SelectedValue);

            this.Grilla.DataSource = ocnMenu.ObtenerMenuSecundario(menIdPadre);
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmenIdSecundario.Text = "";
        txtTituloMenuSecundario.Text = "";
        txtURLMenuSecundario.Text = "";

        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page")
            {
                string Id = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                if (e.CommandName == "Quitar")
                {
                    ocnMenu.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Seleccionar")
                {
                    lblmenIdSecundario.Text = Id;
                    ocnMenu = new GESTIONESCOLAR.Negocio.Menu(Convert.ToInt32(Id));
                    this.txtTituloMenuSecundario.Text = ocnMenu.menNombre;
                    this.txtURLMenuSecundario.Text = ocnMenu.menUrl;
                    this.txtTituloMenuSecundario.Focus();
                }

                if (e.CommandName == "ActivarInactivar")
                {
                    ocnMenu.ActivarInactivar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
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
                if (Fila.Cells[3].Text == "No") Fila.BackColor = System.Drawing.Color.Pink;
            }
        }
    }

    protected void MenuRaizLista_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int menId = 0;
            menId = Convert.ToInt32(MenuRaizLista.SelectedValue);

            ocnMenu = new GESTIONESCOLAR.Negocio.Menu(menId);

            txtTituloMenuRaiz.Text = ocnMenu.menNombre;
            txtOrdenMenuRaiz.Text = ocnMenu.menOrden.ToString();
            txtTituloMenuRaiz.Focus();

            GrillaCargar(Grilla.PageIndex);

            txtTituloMenuSecundario.Text = "";
            txtURLMenuSecundario.Text = "";
            lblmenIdSecundario.Text = "";
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnEliminarMenuRaiz_Click(object sender, EventArgs e)
    {
        try
        {
            if (MenuRaizLista.SelectedIndex != 0)
            {
                int menId = 0;
                menId = Convert.ToInt32(MenuRaizLista.SelectedValue);
                ocnMenu = new GESTIONESCOLAR.Negocio.Menu();
                ocnMenu.EliminarCustom(menId);

                MenuRaizLista.DataValueField = "Valor"; MenuRaizLista.DataTextField = "Texto"; MenuRaizLista.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerListaRaiz("[Nuevo...]"); MenuRaizLista.DataBind();

                GrillaCargar(Grilla.PageIndex);

                txtTituloMenuRaiz.Text = "";
                txtOrdenMenuRaiz.Text = "";

                MenuRaizLista.Focus();
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnAceptarMenuRaiz_Click(object sender, EventArgs e)
    {
        try
        {
            int menId = 0;
            menId = Convert.ToInt32(MenuRaizLista.SelectedValue);
            ocnMenu = new GESTIONESCOLAR.Negocio.Menu(menId);

            ocnMenu.menNombre = txtTituloMenuRaiz.Text.Trim();
            ocnMenu.menOrden = Convert.ToInt32(txtOrdenMenuRaiz.Text);
            ocnMenu.menActivo = true;
            ocnMenu.menUrl = "";
            ocnMenu.menEsMenu = true;
            ocnMenu.menIcono = "";
            ocnMenu.menEsMenu = true;
            ocnMenu.usuIdCreacion = 1;
            ocnMenu.usuIdUltimaModificacion = 1;
            ocnMenu.menFechaHoraCreacion = DateTime.Now;
            ocnMenu.menFechaHoraUltimaModificacion = DateTime.Now;

            int Indice = MenuRaizLista.SelectedIndex;

            if (menId == 0)
            {
                ocnMenu.Insertar();
            }
            else
            {
                ocnMenu.Actualizar();
            }

            MenuRaizLista.DataValueField = "Valor"; MenuRaizLista.DataTextField = "Texto"; MenuRaizLista.DataSource = (new GESTIONESCOLAR.Negocio.Menu()).ObtenerListaRaiz("[Nuevo...]"); MenuRaizLista.DataBind();

            MenuRaizLista.SelectedIndex = Indice;

            GrillaCargar(Grilla.PageIndex);
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnNuevoMenuSecundario_Click(object sender, EventArgs e)
    {
        try
        {
            if (MenuRaizLista.SelectedIndex != 0)
            {
                int menIdPadre = 0;
                menIdPadre = Convert.ToInt32(MenuRaizLista.SelectedValue);

                ocnMenu = new GESTIONESCOLAR.Negocio.Menu();
                ocnMenu.menIdPadre = menIdPadre;
                ocnMenu.menNombre = txtTituloMenuSecundario.Text;
                ocnMenu.menUrl = txtURLMenuSecundario.Text;
                ocnMenu.menOrden = 0;
                ocnMenu.menActivo = true;
                ocnMenu.menEsMenu = true;
                ocnMenu.menIcono = "";
                ocnMenu.usuIdCreacion = 1;
                ocnMenu.usuIdUltimaModificacion = 1;
                ocnMenu.menFechaHoraCreacion = DateTime.Now;
                ocnMenu.menFechaHoraUltimaModificacion = DateTime.Now;

                ocnMenu.Insertar();

                GrillaCargar(Grilla.PageIndex);

                txtTituloMenuSecundario.Text = "";
                txtURLMenuSecundario.Text = "";
                lblmenIdSecundario.Text = "";

                txtTituloMenuSecundario.Focus();
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnAceptarMenuSecundario_Click(object sender, EventArgs e)
    {
        try
        {
            if (MenuRaizLista.SelectedIndex != 0)
            {
                if (lblmenIdSecundario.Text.Trim().Length != 0)
                {
                    int menId = 0;
                    menId = Convert.ToInt32(lblmenIdSecundario.Text);
                    ocnMenu = new GESTIONESCOLAR.Negocio.Menu(menId);

                    ocnMenu.menNombre = txtTituloMenuSecundario.Text.Trim();
                    ocnMenu.menOrden = 0;
                    ocnMenu.menUrl = txtURLMenuSecundario.Text;
                    ocnMenu.menIcono = "";
                    ocnMenu.menEsMenu = true;
                    ocnMenu.menActivo = true;
                    ocnMenu.usuIdCreacion = 1;
                    ocnMenu.usuIdUltimaModificacion = 1;
                    ocnMenu.menFechaHoraCreacion = DateTime.Now;
                    ocnMenu.menFechaHoraUltimaModificacion = DateTime.Now;

                    ocnMenu.Actualizar();

                    lblmenIdSecundario.Text = "";
                    txtTituloMenuSecundario.Text = "";
                    txtURLMenuSecundario.Text = "";

                    GrillaCargar(Grilla.PageIndex);
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }
}