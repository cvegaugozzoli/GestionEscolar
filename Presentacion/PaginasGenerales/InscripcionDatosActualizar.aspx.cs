using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InscripcionDatosActualizar : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Tarjetas ocnTarjetas = new GESTIONESCOLAR.Negocio.Tarjetas();
    GESTIONESCOLAR.Negocio.InscripcionAnio ocnInscripcionAnio = new GESTIONESCOLAR.Negocio.InscripcionAnio();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Datos Inscripción Actualizar";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    //btnAceptar.Visible = false; 
                    btnAceptar1.Visible = false;
                }

                //           int Id = 0;
                //           if (Request.QueryString["Id"] != null)
                //           {
                //               Id = Convert.ToInt32(Request.QueryString["Id"]);

                ///*INCIALIZADORES*/

                //if (Id != 0)
                //               {
                //                   ocnInscripcionAnio = new GESTIONESCOLAR.Negocio.i(Id);
                //	this.tarNombre.Text = ocnTarjetas.tarNombre;
                //	this.tarActivo.Checked = ocnTarjetas.tarActivo;

                //                   /*Editar Habilitado*/
                //}
                //               else
                //               {


                //                   /*Nuevo Habilitado*/

                //                   /*cLoadNuevoCustom*/
                //               }

                //               this.tarNombre.Focus();
            }
            //}
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
            Response.Redirect("inicio.aspx", true);
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAnio.Text == "")
            {
                alerError2.Visible = true;
                lblError2.Text = "Debe ingresar el año de Inscripción..";
                return;
            }
            if (txtCantCuotas.Text == "")
            {
                alerError2.Visible = true;
                lblError2.Text = "Debe completar todos campos..";
                return;
            }
            if (txtCantAnteriores.Text == "")
            {
                alerError2.Visible = true;
                lblError2.Text = "Debe completar todos campos..";
                return;
            }

            alerExito.Visible = false;

            ocnInscripcionAnio.ActualizarEstados();
            ocnInscripcionAnio.Insertar(Convert.ToInt32(txtAnio.Text), Convert.ToInt32(txtCantCuotas.Text), Convert.ToInt32(txtCantAnteriores.Text),1,DateTime.Today);
            //Response.Redirect("inicio.aspx", true);
            alerExito.Visible = true;
            lblExito.Text = "Los datos fueron guardados correctamente..";
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