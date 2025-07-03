using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ConceptosYCI : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    DataTable dt = new DataTable();
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
                    //btnAceptar.Visible = false;
                    btnAceptar1.Visible = false;
                }

                int Id = 0;
                

                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/
                    insId.DataValueField = "Valor"; insId.DataTextField = "Texto"; insId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); insId.DataBind();
                    cntId.DataValueField = "Valor"; cntId.DataTextField = "Texto"; cntId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); cntId.DataBind();

                    // int instId = Convert.ToInt32(insId.SelectedValue);
                    int instId = Convert.ToInt32(Session["_Institucion"]);
                    NivelID.DataValueField = "Valor";
                    NivelID.DataTextField = "Texto";
                    NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", instId);
                    NivelID.DataBind();

                    if (Id != 0)
                    {
                        lblConId.Text = Convert.ToString(Id);
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
                        #region PageIndex
                        int PageIndex = 0;
                        if (this.Session["ConceptosYCI.PageIndex"] == null)
                        {
                            Session.Add("ConceptosYCI.PageIndex", 0);
                        }
                        else
                        {
                            PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
                        }
                        #endregion



                        GrillaCargar(PageIndex);
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




    private void GrillaCargar(int PageIndex)
    {
        try
        {

            int insId = Convert.ToInt32(Session["_Institucion"]);
            if (lblConId.Text != "")
            {
                dt = new DataTable();
                dt = ocnConceptosIntereses.ObtenerInteresxconId(Convert.ToInt32(lblConId.Text));

                this.GrillaCI.DataSource = dt;
                this.GrillaCI.PageIndex = PageIndex;
                this.GrillaCI.DataBind();
            }
            else
            {
                DataTable dtFunding = new DataTable();
                dtFunding.Rows.Add(dtFunding.NewRow());
                GrillaCI.DataSource = dtFunding;
                dtFunding.Rows.Add(dtFunding.NewRow());
                GrillaCI.DataSource = dtFunding;
                GrillaCI.DataBind(); GrillaCI.Rows[0].Visible = false;

                //Las dos siguientes líneas tienen que ir descomentadas en caso que querramos mostrar solo la cabecera de la grilla.
                //GrillaCI.Rows[0].Visible = true;
                //GrillaCI.Rows[0].Controls.Clear();
            }
            //GrillaCI.DataSource = dt;

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
    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["ConceptosYCI.PageIndex"] != null)
            {
                Session["ConceptosYCI.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ConceptosYCI.PageIndex", e.NewPageIndex);
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

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GrillaCI.EditIndex = e.NewEditIndex;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
            GrillaCargar(PageIndex);

            GrillaCI.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
            GrillaCI.Columns[6].Visible = true;
            GrillaCI.Columns[7].Visible = true;
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

    protected void OnCancel(object sender, EventArgs e)
    {
        try
        {
            GrillaCI.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
            GrillaCargar(PageIndex);
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
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrillaCI, "Edit$" + e.Row.RowIndex);
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrillaCI, "Edit$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
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
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = GrillaCI.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GrillaCI.DataKeys[e.RowIndex].Values[0]);

            TextBox NroCuota = (TextBox)GrillaCI.Rows[e.RowIndex].FindControl("NroCuota");
            TextBox FechaVto = (TextBox)GrillaCI.Rows[e.RowIndex].FindControl("FechaVto");
            TextBox ValorInteres = (TextBox)GrillaCI.Rows[e.RowIndex].FindControl("ValorInteres");
            CheckBox check = row.FindControl("coiAplicaBeca") as CheckBox;
            CheckBox check2 = row.FindControl("coiAplicaInteresAbierto") as CheckBox;


            ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(Convert.ToInt32(GrillaCI.DataKeys[row.RowIndex].Values["Id"]));
            ocnConceptosIntereses.coiAplicaBeca = check.Checked;
            ocnConceptosIntereses.coiNroCuota = Convert.ToInt32(NroCuota.Text);
            ocnConceptosIntereses.coiFechaVto = Convert.ToDateTime(FechaVto.Text);
            ocnConceptosIntereses.coiValorInteres = Convert.ToDecimal(ValorInteres.Text);
            ocnConceptosIntereses.coiAplicaInteresAbierto = check2.Checked;
            ocnConceptosIntereses.coiActivo = true;

            ocnConceptosIntereses.coiActivo = true;

            ocnConceptosIntereses.conId = Convert.ToInt32(lblConId.Text);
            /*....usuId = this.Master.usuId;*/



            ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;

            ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;

            ocnConceptosIntereses.Actualizar();

            GrillaCI.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
            GrillaCargar(PageIndex);
            //ocnRegistracionNota.ActualizarPrimaria(Id, PTrim2, STrim2, TTrim2, PAnual2, NotaDic2, NotaMar2, renCalfDef2, RenFechaHoraCreacion, RenFechaHoraUltimaModificacion, usuIdCreacion, usuIdUltimaModificacion);
            //GridView1.EditIndex = -1;
            //int PageIndex = 0;
            //PageIndex = Convert.ToInt32(Session["CargaCalifxEspCPri.PageIndex"]);
            //GrillaCargar(PageIndex);
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

                //ocnConceptos.conFechaHoraCreacion = DateTime.Now;
                //ocnConceptos.conFechaHoraUltimaModificacion = DateTime.Now;
                //ocnConceptos.usuIdCreacion = this.Master.usuId;
                //ocnConceptos.usuidUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //int conIdNew = ocnConceptosIntereses.Insertar();
                        //foreach (GridViewRow row in GrillaCI.Rows)
                        //{
                        //    ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(Id);
                        //    ocnConceptosIntereses.coiNroCuota = Convert.ToInt32(GrillaCI.DataKeys[row.RowIndex].Values["NroCuota"]);
                        //    ocnConceptosIntereses.coiFechaVto = Convert.ToDateTime(GrillaCI.DataKeys[row.RowIndex].Values["FechaVto"]);
                        //    ocnConceptosIntereses.coiValorInteres = Convert.ToDecimal(GrillaCI.DataKeys[row.RowIndex].Values["ValorInteres"]);
                        //    ocnConceptosIntereses.coiAplicaBeca = coiAplicaBeca.Checked;
                        //    ocnConceptosIntereses.coiAplicaInteresAbierto = coiAplicaInteresAbierto.Checked;
                        //    ocnConceptosIntereses.coiActivo = true;

                        //    ocnConceptosIntereses.conId = conIdNew;
                        //    /*....usuId = this.Master.usuId;*/
                        //    ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
                        //    ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
                        //    ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
                        //    ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
                        //    ocnConceptosIntereses.Insertar();
                        //}
                    }
                    else
                    {
                        //Editar
                        ocnConceptos.conFechaHoraUltimaModificacion = DateTime.Now;
                        ocnConceptos.usuidUltimaModificacion = this.Master.usuId;
                        ocnConceptos.Actualizar();


                        foreach (GridViewRow row in GrillaCI.Rows)
                        {

                            ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(Convert.ToInt32(GrillaCI.DataKeys[row.RowIndex].Values["Id"]));

                            ocnConceptosIntereses.coiNroCuota = Convert.ToInt32(GrillaCI.DataKeys[row.RowIndex].Values["NroCuota"]);
                            ocnConceptosIntereses.coiFechaVto = Convert.ToDateTime((GrillaCI.DataKeys[row.RowIndex].Values["FechaVto"]));
                            ocnConceptosIntereses.coiValorInteres = Convert.ToDecimal(GrillaCI.DataKeys[row.RowIndex].Values["ValorInteres"]);
                            ocnConceptosIntereses.coiAplicaInteresAbierto = Convert.ToBoolean(GrillaCI.DataKeys[row.RowIndex].Values["coiAplicaInteresAbierto"]);
                            ocnConceptosIntereses.coiAplicaBeca = Convert.ToBoolean(GrillaCI.DataKeys[row.RowIndex].Values["coiAplicaBeca"]);

                            ocnConceptosIntereses.coiActivo = true;

                            ocnConceptosIntereses.coiActivo = true;

                            ocnConceptosIntereses.conId = Convert.ToInt32(lblConId.Text);
                            /*....usuId = this.Master.usuId;*/



                            ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;

                            ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;

                            ocnConceptosIntereses.Actualizar();

                        }

                        GrillaCI.EditIndex = -1;
                        int PageIndex = 0;
                        PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
                        GrillaCargar(PageIndex);
                        alerExito.Visible = true;
                        lblExito.Text = "Se grabaron con exito los datos..";
                    }

                    //Response.Redirect("ConceptosConsulta.aspx", true);
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
            Id = Convert.ToInt32(((Label)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            ocnConceptosIntereses.Eliminar(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(GrillaCI.PageIndex);
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
        //((Button)sender).Parent.Controls[1].Visible = true;
        //((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[8].Visible = false;
    }


    protected void conCantCuotas_TextChanged(object sender, EventArgs e)
    {
        //DataTable dt2 = new DataTable();
        //if (GrillaCI.Rows.Count == 0)
        //{
        //    //Crear un DataTable con las Columnas del DataGriview
        //    //DataTable datatable = new DataTable();
        //    //datatable = GrillaCI.DataSource as DataTable;

        //    //Agregar las Filas al DataRow           
        //    for (int i = 0; i < (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)); i++)
        //    {
        //        int IdCI = 0;
        //        ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(IdCI);

        //        ocnConceptosIntereses.coiActivo = true;

        //        ocnConceptosIntereses.conId = Convert.ToInt32(lblConId.Text);
        //        /*....usuId = this.Master.usuId;*/
        //        ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
        //        ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
        //        ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
        //        ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
        //        ocnConceptosIntereses.Insertar();
        //    }
        //}
        //else
        //{
        //    if (GrillaCI.Rows.Count > (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)))
        //    {
        //        for (int i = GrillaCI.Rows.Count; i >= (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)); i--)
        //        {
        //            int Id = 0;
        //            Id = Convert.ToInt32(GrillaCI.DataKeys[i].Values["Id"]); ;
        //            ocnConceptosIntereses.Eliminar(Id);
        //        }
        //    }
        //    else
        //    {
        //        if (GrillaCI.Rows.Count < (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)))
        //        {
        //            for (int i = GrillaCI.Rows.Count; i < (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)); i++)
        //            {
        //                int IdCI = 0;
        //                ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(IdCI);

        //                ocnConceptosIntereses.coiActivo = true;

        //                ocnConceptosIntereses.conId = Convert.ToInt32(lblConId.Text);
        //                /*....usuId = this.Master.usuId;*/
        //                ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
        //                ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
        //                ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
        //                ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
        //                ocnConceptosIntereses.Insertar();
        //            }
        //        }
        //    }
        //}

        //dt = ocnConceptosIntereses.ObtenerInteresxconId(Convert.ToInt32(lblConId.Text));

        //this.GrillaCI.DataSource = dt;
        //int PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
        //this.GrillaCI.PageIndex = PageIndex;
        //this.GrillaCI.DataBind();
    }


    protected void conCantVtos_TextChanged(object sender, EventArgs e)
    {
        //    DataTable dt2 = new DataTable();
        //    if (GrillaCI.Rows.Count == 0)
        //    {
        //        //Crear un DataTable con las Columnas del DataGriview
        //        //DataTable datatable = new DataTable();
        //        //datatable = GrillaCI.DataSource as DataTable;

        //        //Agregar las Filas al DataRow           
        //        for (int i = 0; i < (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)); i++)
        //        {
        //            int IdCI = 0;
        //            ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(IdCI);

        //            ocnConceptosIntereses.coiActivo = true;

        //            ocnConceptosIntereses.conId = Convert.ToInt32(lblConId.Text);
        //            /*....usuId = this.Master.usuId;*/
        //            ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
        //            ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
        //            ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
        //            ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
        //            ocnConceptosIntereses.Insertar();
        //        }
        //    }
        //    else
        //    {
        //        if (GrillaCI.Rows.Count > (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)))
        //        {
        //            for (int i = GrillaCI.Rows.Count; i >= (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)); i--)
        //            {
        //                int Id = 0;
        //                Id = Convert.ToInt32(GrillaCI.DataKeys[i].Values["Id"]); ;
        //                ocnConceptosIntereses.Eliminar(Id);
        //            }
        //        }
        //        else
        //        {
        //            if (GrillaCI.Rows.Count < (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)))
        //            {
        //                for (int i = GrillaCI.Rows.Count; i < (Convert.ToInt32(conCantCuotas.Text) * Convert.ToInt32(conCantVtos.Text)); i++)
        //                {
        //                    int IdCI = 0;
        //                    ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses(IdCI);

        //                    ocnConceptosIntereses.coiActivo = true;

        //                    ocnConceptosIntereses.conId = Convert.ToInt32(lblConId.Text);
        //                    /*....usuId = this.Master.usuId;*/
        //                    ocnConceptosIntereses.coiFechaHoraCreacion = DateTime.Now;
        //                    ocnConceptosIntereses.coiFechaHoraUltimaModificacion = DateTime.Now;
        //                    ocnConceptosIntereses.usuIdCreacion = this.Master.usuId;
        //                    ocnConceptosIntereses.usuidUltimaModificacion = this.Master.usuId;
        //                    ocnConceptosIntereses.Insertar();
        //                }
        //            }
        //        }
        //    }

        //    dt = ocnConceptosIntereses.ObtenerInteresxconId(Convert.ToInt32(lblConId.Text));

        //    this.GrillaCI.DataSource = dt;
        //    int PageIndex = Convert.ToInt32(Session["ConceptosYCI.PageIndex"]);
        //    this.GrillaCI.PageIndex = PageIndex;
        //    this.GrillaCI.DataBind();
        //}
    }
}