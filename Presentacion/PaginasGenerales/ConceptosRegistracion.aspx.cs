using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConceptosRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Conceptos - Registracion";

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
                    int instId = Convert.ToInt32(Session["_Institucion"]);

                    /*INCIALIZADORES*/
                    insId.DataValueField = "Valor"; insId.DataTextField = "Texto"; insId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); insId.DataBind();
                    cntId.DataValueField = "Valor"; cntId.DataTextField = "Texto"; cntId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); cntId.DataBind();
                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", instId); NivelID.DataBind();

                    if (Id != 0)
                    {
                        ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos(Id);
                        this.conNombre.Text = ocnConceptos.conNombre;
                        this.conAnioLectivo.Text = ocnConceptos.conAnioLectivo.ToString();
                        this.conImporte.Text = FuncionesUtiles.DecimalToString(ocnConceptos.conImporte);
                        this.conCantCuotas.Text = ocnConceptos.conCantCuotas.ToString();
                        this.conCantVtos.Text = ocnConceptos.conCantVtos.ToString();
                        this.conMesInicio.Text = ocnConceptos.conMesInicio.ToString();
                        this.rblValor.SelectedValue = ocnConceptos.conValorSeleccionado.ToString();
                        this.conRecargoVtoAbierto.Text = FuncionesUtiles.DecimalToString(ocnConceptos.conRecargoVtoAbierto);
                        this.conTieneVtoAbierto.Checked = ocnConceptos.conTieneVtoAbierto;
                        this.conNotas.Text = ocnConceptos.conNotas;
                        this.conInteresMensual.Text = FuncionesUtiles.DecimalToString(ocnConceptos.conInteresMensual);
                        this.conActivo.Checked = ocnConceptos.conActivo;
                        this.insId.SelectedValue = (ocnConceptos.insId == 0 ? "" : ocnConceptos.insId.ToString());
                        this.cntId.SelectedValue = (ocnConceptos.cntId == 0 ? "" : ocnConceptos.cntId.ToString());
                        this.NivelID.SelectedValue = (ocnConceptos.tcaId == 0 ? "" : ocnConceptos.tcaId.ToString());
                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.conNombre.Focus();
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


    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void insId_SelectedIndexChanged(object sender, EventArgs e)
    {
        int instId = Convert.ToInt32(insId.SelectedValue);
        NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", instId); NivelID.DataBind();
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ConceptosConsulta.aspx", true);
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
                ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos(Id);
                ocnConceptos.insId = Convert.ToInt32(insId.SelectedValue);
                ocnConceptos.conNombre = conNombre.Text;
                ocnConceptos.conAnioLectivo = Convert.ToInt32(conAnioLectivo.Text);
                ocnConceptos.conImporte = FuncionesUtiles.StringToDecimal(conImporte.Text);
                ocnConceptos.conCantCuotas = Convert.ToInt32(conCantCuotas.Text);
                ocnConceptos.conCantVtos = Convert.ToInt32(conCantVtos.Text);
                ocnConceptos.conMesInicio = Convert.ToInt32(conMesInicio.Text);
                ocnConceptos.conValorSeleccionado = Convert.ToInt32(rblValor.SelectedValue);

                ocnConceptos.conRecargoVtoAbierto = FuncionesUtiles.StringToDecimal(conRecargoVtoAbierto.Text);
                ocnConceptos.conTieneVtoAbierto = conTieneVtoAbierto.Checked;
                ocnConceptos.conNotas = conNotas.Text;
                ocnConceptos.conInteresMensual = FuncionesUtiles.StringToDecimal(conInteresMensual.Text);
                ocnConceptos.conActivo = conActivo.Checked;

                ocnConceptos.insId = Convert.ToInt32((insId.SelectedValue.Trim() == "" ? "0" : insId.SelectedValue));
                ocnConceptos.cntId = Convert.ToInt32((cntId.SelectedValue.Trim() == "" ? "0" : cntId.SelectedValue));
                /*....usuId = this.Master.usuId;*/
                ocnConceptos.tcaId = Convert.ToInt32((NivelID.SelectedValue.Trim() == "" ? "0" : NivelID.SelectedValue));

                ocnConceptos.conFechaHoraCreacion = DateTime.Now;
                ocnConceptos.conFechaHoraUltimaModificacion = DateTime.Now;
                ocnConceptos.usuIdCreacion = this.Master.usuId;
                ocnConceptos.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo

                        int conIdNew = ocnConceptos.Insertar();
                        for (int i = 0; i < (Convert.ToInt32(conCantCuotas.Text) * (Convert.ToInt32(conCantVtos.Text))); i++)
                        {
                            int IdCI = 0;
                            ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(IdCI);

                            ocnConceptosIntereses.coiActivo = true;
                            ocnConceptosIntereses.coiFechaVto = DateTime.Now;
                            ocnConceptosIntereses.coiFechaVto = DateTime.Now;
                            ocnConceptosIntereses.conId = conIdNew;
                            /*....usuId = this.Master.usuId;*/
                            ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
                            ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
                            ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
                            ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
                            ocnConceptosIntereses.Insertar();
                        }

                    }
                    else
                    {
                        ////Editar
                        //ocnConceptos.conFechaHoraUltimaModificacion = DateTime.Now;
                        //ocnConceptos.usuidUltimaModificacion = this.Master.usuId;
                        //ocnConceptos.Actualizar();
                    }

                    Response.Redirect("ConceptosConsulta.aspx", true);
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