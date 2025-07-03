using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class InscripcionConceptoRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Inscripcion Concepto - Registracion";
                insId = Convert.ToInt32(Session["_Institucion"]);
                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false; 
                    btnAceptar1.Visible = false;
                }
            
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

					/*INCIALIZADORES*/
					conId.DataValueField = "Valor"; conId.DataTextField = "Texto"; conId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerLista("[Seleccionar...]", insId); conId.DataBind();
					becId.DataValueField = "Valor"; becId.DataTextField = "Texto"; becId.DataSource = (new GESTIONESCOLAR.Negocio.Becas()).ObtenerLista("[Seleccionar...]"); becId.DataBind();

					if (Id != 0)
                    {
						ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto(Id);
						this.icoImporte.Text = FuncionesUtiles.DecimalToString(ocnInscripcionConcepto.icoImporte);
						this.icoFechaInscripcion.Text = ocnInscripcionConcepto.icoFechaInscripcion;
						this.icoNroCuota.Text = ocnInscripcionConcepto.icoNroCuota.ToString();
						this.icoActivo.Checked = ocnInscripcionConcepto.icoActivo;
						this.icuId.SelectedValue = (ocnInscripcionConcepto.icuId == 0 ? "" : ocnInscripcionConcepto.icuId.ToString());
						this.conId.SelectedValue = (ocnInscripcionConcepto.conId == 0 ? "" : ocnInscripcionConcepto.conId.ToString());
						this.becId.SelectedValue = (ocnInscripcionConcepto.becId == 0 ? "" : ocnInscripcionConcepto.becId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {
                        icoFechaInscripcion.Text = DateTime.Now;


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.icuId.Focus();
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
		
	protected void btnCancelar_Click(object sender, EventArgs e)
	{
        try
        {
            Response.Redirect("InscripcionConceptoConsulta.aspx", true);
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
		    int Id = 0;
		    if (Request.QueryString["Id"] != null)
		    {
			    Id = Convert.ToInt32(Request.QueryString["Id"]);
			    ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto(Id);

			    ocnInscripcionConcepto.icoImporte = FuncionesUtiles.StringToDecimal(icoImporte.Text); 
			    ocnInscripcionConcepto.icoFechaInscripcion = Convert.ToDateTime(icoFechaInscripcion.Text); 
			    ocnInscripcionConcepto.icoNroCuota = Convert.ToInt32(icoNroCuota.Text); 
			    ocnInscripcionConcepto.icoActivo = icoActivo.Checked; 

				ocnInscripcionConcepto.icuId = Convert.ToInt32((icuId.SelectedValue.Trim() == "" ? "0" : icuId.SelectedValue)); 
				ocnInscripcionConcepto.conId = Convert.ToInt32((conId.SelectedValue.Trim() == "" ? "0" : conId.SelectedValue)); 
				ocnInscripcionConcepto.becId = Convert.ToInt32((becId.SelectedValue.Trim() == "" ? "0" : becId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnInscripcionConcepto.icoFechaHoraCreacion = DateTime.Now;
				ocnInscripcionConcepto.icoFechaHoraUltimaModificacion = DateTime.Now;
				ocnInscripcionConcepto.usuIdCreacion = this.Master.usuId;
				ocnInscripcionConcepto.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnInscripcionConcepto.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnInscripcionConcepto.icoFechaHoraUltimaModificacion = DateTime.Now;
				        ocnInscripcionConcepto.usuidUltimaModificacion = this.Master.usuId;
					    ocnInscripcionConcepto.Actualizar();
				    }
					
				    Response.Redirect("InscripcionConceptoConsulta.aspx", true);
			    }
			    else
			    {
				    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
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