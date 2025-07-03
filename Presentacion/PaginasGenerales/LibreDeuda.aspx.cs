
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class LibreDeuda : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    GESTIONESCOLAR.Negocio.ComprobantesFormasPago ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.PagosCheques ocnPagosCheques = new GESTIONESCOLAR.Negocio.PagosCheques();
    GESTIONESCOLAR.Negocio.PagosTarjetas ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas();
    GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    int BanderaRoja = 0;
    int CuotaUltPagada = 0;

    int insId;

    Int32 icuId2;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["UltimaCuota"] = 0;
                //this.Master.TituloDelFormulario = " Libre Deuda";
                //insId = Convert.ToInt32(Session["_Institucion"]);
                int BanderaRoja = 0;
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                int ban = 0;
                Session["Bandera"] = ban;
                #region PageIndex
                int PageIndex = 0;
                int aluId1 = Convert.ToInt32(Request.QueryString["Id"]);
                txtAnioLectivo.Text = Convert.ToString(DateTime.Today.Year);


                alerError.Visible = false;
                alerExito.Visible = false;

                if (this.Session["LibreDeuda.PageIndex"] == null)
                {
                    Session.Add("LibreDeuda.PageIndex", 0);
                }

                else
                {
                    PageIndex = Convert.ToInt32(Session["LibreDeuda.PageIndex"]);
                }
                #endregion
                lblaluId.Text = "0";
                #region Variables de sesion para filtros
                //if (Session["LibroDisciplina.Nombre"] != null) { LibroDisciplina.Text = Session["LibroDisciplina.Nombre"].ToString(); } else { Session.Add("SexoConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion
                if (aluId1 != 0)
                {
                    lblaluId.Text = Convert.ToString(aluId1);
                    PageIndex = Convert.ToInt32(Session["LibreDeuda.PageIndex"]);
                    GrillaCargar(PageIndex);
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


    private void GrillaBuscarCargar(int PageIndex)
    {
        try
        {
            btnImprimir.Visible = false;
            BanderaRoja = 0;
            alerError.Visible = false;
            alerExito.Visible = false;
            canRg.Visible = false;
            Session["LibreDeuda.PageIndex"] = PageIndex;

            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnAlumno.ObtenerTodoBuscarxNombre(TextBuscar.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    canRg.Visible = true;
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.GrillaBuscar.DataSource = dt;
                    this.GrillaBuscar.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();

                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra Alumno con esa descripción o DNI";
                }
            }
            else
            {
                dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
                canRg.Visible = true;
                if (dt.Rows.Count > 0)
                {
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.GrillaBuscar.DataSource = dt;
                    this.GrillaBuscar.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();

                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra Alumno con esa descripción o DNI";
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


    protected void GrillaBuscar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                String Id = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                if (e.CommandName == "Select")
                {
                    aluNombre.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    aluNombre.Enabled = false;
                    aludni.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    aludni.Enabled = false;
                    lblaluId.Text = Id;
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["LibreDeuda.PageIndex"]);

                    GrillaCargar(PageIndex);
                    GrillaBuscar.DataSource = null;
                    GrillaBuscar.DataBind();
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
            btnImprimir.Visible = false;
            canRg.Visible = false;
            alerError2.Visible = false;
            alerError.Visible = false;
            alerError3.Visible = false;
            alerExito.Visible = false;
            alerExito2.Visible = false;
            lblMjerror2.Text = "";
            BanderaRoja = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("icoId", typeof(int));
            dt.Columns.Add("conId", typeof(Int32));
            dt.Columns.Add("cntId", typeof(Int32));
            dt.Columns.Add("TipoConcepto", typeof(String));
            dt.Columns.Add("Concepto", typeof(String));
            dt.Columns.Add("RA", typeof(Decimal));
            dt.Columns.Add("Importe", typeof(Decimal));
            dt.Columns.Add("ImporteInteres", typeof(Decimal));
            dt.Columns.Add("AnioLectivo", typeof(Decimal));
            dt.Columns.Add("Beca", typeof(String));
            dt.Columns.Add("BecId", typeof(Int32));
            dt.Columns.Add("NroCuota", typeof(Int32));
            dt.Columns.Add("FchInscripcion", typeof(String));
            dt.Columns.Add("FechaVto", typeof(String));
            dt.Columns.Add("ValorInteres", typeof(Decimal));
            dt.Columns.Add("ImpPagado", typeof(Decimal));
            dt.Columns.Add("FechaPago", typeof(String));
            dt.Columns.Add("NroCompbte", typeof(String));
            dt.Columns.Add("Curso", typeof(String));
            dt.Columns.Add("Contado", typeof(String));
            dt.Columns.Add("Tarjeta", typeof(String));
            dt.Columns.Add("Cheque", typeof(String));
            dt.Columns.Add("TranfElec", typeof(String));
            dt.Columns.Add("Colegio", typeof(String));
            dt.Columns.Add("insId", typeof(Int32));
            //dt.Columns.Add("BecInteres", typeof(Decimal));

            DataTable dtConc = new DataTable();

            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();

            // InscripcionCursado.ObtenerTodoporaluIdAnioCursado

            int Bandera;
            Session["CuentaCorriente.PageIndex"] = PageIndex;

            int ins_Id = 0;
            String Colegio = "";

            if (txtAnioLectivo.Text == "") //
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un año..";
                return;
            }
            else //seleccionó Año Lectivo
            {
                dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(Convert.ToInt32(lblaluId.Text), Convert.ToInt32(txtAnioLectivo.Text));
                if (dt3.Rows.Count > 0)
                {
                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                    Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                    dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId_SinBeca100(icuId2);
                    if (dt4.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt4.Rows)
                        {
                            dt2 = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(row["Id"].ToString()));
                            dt5 = ocnConceptosIntereses.ObtenerPrimerVencimiento(Convert.ToInt32(row["conId"].ToString()), Convert.ToInt32(row["NroCuota"].ToString()));
                            if (dt5.Rows.Count > 0)
                            {
                                Bandera = 0;// Para poner importe pagado a uno.. 
                                foreach (DataRow row2 in dt5.Rows)
                                {
                                    Decimal ImporteBecado = 0;
                                    if (Bandera == 0)
                                    {
                                        if (dt2.Rows.Count > 0)
                                        {
                                            dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                            dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            //int eee = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            //decimal yyy = Convert.ToDecimal(row["BecasInteres"].ToString());
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
                                            row1["AnioLectivo"] = Convert.ToInt32(row["AnioLectivo"].ToString());
                                            row1["Beca"] = Convert.ToString((row["Becas"].ToString()));
                                            row1["BecId"] = Convert.ToString((row["BecId"].ToString()));
                                            row1["FchInscripcion"] = Convert.ToString(row["FechaInscripcion"].ToString());
                                            row1["FechaVto"] = Convert.ToString(row2["FechaVto"].ToString());
                                            row1["ValorInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
                                            row1["ImpPagado"] = Convert.ToDecimal(dt2.Rows[0]["Importe"].ToString());
                                            row1["FechaPago"] = Convert.ToString(dt6.Rows[0]["FechaPago"].ToString());
                                            row1["NroCompbte"] = Convert.ToString(dt6.Rows[0]["NroCompbte"].ToString());
                                            row1["Curso"] = Convert.ToString(dt3.Rows[0]["Curso"].ToString());
                                            row1["Colegio"] = Colegio; // Convert.ToString(dt3.Rows[0]["Colegio"].ToString());
                                            //Int32 pp = 0;
                                            // pp = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            row1["insId"] = ins_Id.ToString(); //(Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            //row1["BecInteres"] = Convert.ToDecimal(dt2.Rows[0]["BecInteres"].ToString());
                                            Bandera = 1;
                                            dt.Rows.Add(row1);
                                        }
                                        else
                                        {
                                            dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
                                            row1["AnioLectivo"] = Convert.ToInt32(row["AnioLectivo"].ToString());
                                            row1["Beca"] = Convert.ToString((row["Becas"].ToString()));
                                            row1["BecId"] = Convert.ToString((row["BecId"].ToString()));
                                            row1["FchInscripcion"] = Convert.ToString(row["FechaInscripcion"].ToString());
                                            row1["FechaVto"] = Convert.ToString(row2["FechaVto"].ToString());
                                            row1["ValorInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
                                            row1["ImpPagado"] = 0;
                                            row1["FechaPago"] = "";
                                            row1["NroCompbte"] = "";
                                            row1["Curso"] = Convert.ToString(dt3.Rows[0]["Curso"].ToString());
                                            row1["Colegio"] = Colegio;
                                            //Int32 ppp = 0;
                                            //ppp = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            row1["insId"] = ins_Id.ToString();
                                            //row1["BecInteres"] = Convert.ToDecimal(dt2.Rows[0]["BecInteres"].ToString());
                                            dt.Rows.Add(row1);
                                            Bandera = 1;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else //no hay incripcion para ese alumno ese año
                    {
                        GrillaHistorial.DataSource = null;
                        GrillaHistorial.DataBind();

                        alerError.Visible = true;
                        lblError.Text = "No se encontraron registros en ese año lectivo..";
                        return;
                    }
                }
                else
                {
                    DataTable dt8 = new DataTable();
                    this.GrillaHistorial.DataSource = dt8;
                    this.GrillaHistorial.PageIndex = PageIndex;
                    this.GrillaHistorial.DataBind();

                    if (lblaluId.Text == "")
                    {
                        alerError.Visible = true;
                        lblError.Text = "Debe buscar y seleccionar un alumno";

                    }
                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "No se encontró registro";
                    }
                    return;
                }
            }
            if (dt.Rows.Count != 0)
            {
                this.GrillaHistorial.DataSource = dt;
                this.GrillaHistorial.PageIndex = PageIndex;
                this.GrillaHistorial.DataBind();
                Session["UltimaCuota"] = 0;
                DateTime Hoy = DateTime.Today;

                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
                    {
                        row.BackColor = System.Drawing.Color.LightBlue;
                        Session["UltimaCuota"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                        ((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                    }

                    else
                    {
                        //DateTime ppp = Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]);
                        //Double ppp1 = Convert.ToDouble(GrillaHistorial.DataKeys[row.RowIndex].Values["Importe"]); // Importe Becado


                        if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < Hoy)
                        {
                            row.BackColor = System.Drawing.Color.FromName("#B81822");
                            row.ForeColor = System.Drawing.Color.White;
                            BanderaRoja = 1;
                            //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                            //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;

                        }
                    }
                }
            }
            else
            {
                GrillaHistorial.DataSource = null;
                GrillaHistorial.DataBind();
            }
            if (BanderaRoja == 0)
            {
                btnImprimir.Visible = true;
                alerExito2.Visible = true;
                lblExito2.Text = "El alumno no posee deuda para ese año.. Puede imprimir libre deuda..";
            }
            else
            {
                btnImprimir.Visible = false;
                alerExito2.Visible = false;
                alerError3.Visible = true;
                lblError3.Text = "El alumno posee cuotas impagas.. no puede imprimir Libre Deuda..";
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
                //string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                //if (e.CommandName == "Eliminar")
                //{
                // //ocnSexo.Eliminar(Convert.ToInt32(Id));
                // this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                // ocnSexo = new GESTIONESCOLAR.Negocio.Sexo(Convert.ToInt32(Id));
                // //ocnSexo.Copiar();
                // this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Ver")
                //{
                // Response.Redirect("SexoRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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

    protected void GrillaHistorial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            alerError.Visible = false;
            alerExito.Visible = false;
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                //string Id = ((HyperLink)GrillaHistorial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;
                if (e.CommandName == "Add")
                {
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    String NomRep;
                    Int32 AnioCursado;
                    Int32 icuId;

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GrillaHistorial.Rows[index];

                    AnioCursado = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["AnioLectivo"]);
                    insId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["InsId"]);
                    dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCursado, Convert.ToInt32(lblaluId.Text));
                    icuId = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    Int32 icoId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["icoId"]);

                    dt2 = ocnComprobantesDetalle.ObtenerUnoxicoId(icoId);
                    if (dt2.Rows.Count > 0)
                    {
                        Int32 cocId = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                        NomRep = "InformeResumenPago.rpt";

                        FuncionesUtiles.AbreVentana("Reporte.aspx?icuId=" + icuId + "&cocId=" + cocId + "&NomRep=" + NomRep);
                    }
                    else
                    {
                        lblMjerror2.Text = "Ese concepto no se encuentra Pago";
                    }

                    this.GrillaCargar(this.GrillaHistorial.PageIndex);
                    //popup resumenFormaPago
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //GridViewRow row = GrillaHistorial.Rows[index];
                    //string NroCompbte = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCompbte"]);
                    //String Nombre = aluNombre.Text;
                    //string FchPago = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaPago"]);
                    //string Contado = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Contado"]);
                    //string Tarjeta = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Tarjeta"]);
                    //string Cheque = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Cheque"]);
                    //string TranfElec = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["TranfElec"]);

                    //FuncionesUtiles.AbreVentana("FormaPagoResumen.aspx?Contado=" + Contado + "&Tarjeta=" + Tarjeta + "&Cheque=" + Cheque + "&TranfElec=" + TranfElec + "&NroCompbte=" + NroCompbte + "&FchPago=" + FchPago + "&Nombre=" + Nombre);
                    //this.GrillaCargar(this.GrillaHistorial.PageIndex);

                }

                //if (e.CommandName == "Copiar")
                //{
                // ocnSexo = new GESTIONESCOLAR.Negocio.Sexo(Convert.ToInt32(Id));
                // //ocnSexo.Copiar();
                // this.GrillaCargar(this.Grilla.PageIndex);
                //}

                if (e.CommandName == "Ver")
                {
                    //Response.Redirect("SexoRegistracion.aspx?Id=" +  "&Ver=1", false);
                }
                if (e.CommandName == "Eliminar")
                {
                    //ocnAlumno.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.GrillaHistorial.PageIndex);
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

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError2.Visible = false;
        alerError.Visible = false;
        alerExito.Visible = false;
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
        aludni.Text = "";
        aluNombre.Text = "";
        TextBuscar.Text = "";
    }



    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }


    protected void GrillaBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["CuentaCorriente.PageIndex"] != null)
            {
                Session["CuentaCorriente.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CuentaCorriente.PageIndex", e.NewPageIndex);
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

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["CuentaCorriente.PageIndex"] != null)
            {
                Session["CuentaCorriente.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CuentaCorriente.PageIndex", e.NewPageIndex);
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
            DateTime Hoy = DateTime.Today;
            foreach (GridViewRow row in GrillaHistorial.Rows)
            {
                if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
                {
                    row.BackColor = System.Drawing.Color.LightBlue;
                    ((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                }

                else
                {
                    if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < Hoy)
                    {
                        row.BackColor = System.Drawing.Color.FromName("#E60026");
                        row.ForeColor = System.Drawing.Color.White;


                        //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                        //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;

                    }
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

    protected void btnEliminarAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            alerError.Visible = false;
            alerExito.Visible = false;
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            int icoId = 0;
            DateTime cocFechaHoraCreacion = DateTime.Now;
            DateTime cocFechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int usuIdUltimaModificacion = this.Master.usuId;

            int row2 = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;

            icoId = Convert.ToInt32(GrillaHistorial.DataKeys[row2].Values["icoId"]);


            //icoId = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
            dt2 = ocnComprobantesDetalle.ObtenerUnoxicoId(icoId);
            if (dt2.Rows.Count > 0)//existe comprobante
            {
                Int32 cocId = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                Int32 cdeId = Convert.ToInt32(dt2.Rows[0]["Id"].ToString());
                ocnComprobantesCabecera.ActualizarObservacion(cocId, "Anulado", usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);

                ocnComprobantesDetalle.ActualizarActivo(cocId, false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);

                //ocnComprobantesDetalle.EliminarxcocId(cocId);
                dt3 = ocnComprobantesFormasPago.ObtenerTodoxcdeId(cdeId);
                if (dt3.Rows.Count > 0)//existe forma de Pago
                {
                    foreach (DataRow row in dt3.Rows)
                    {

                        if (Convert.ToInt32(dt3.Rows[0]["fopId"].ToString()) == 2)
                        {
                            ocnPagosTarjetas.ActualizarActivoxcfp(Convert.ToInt32(dt2.Rows[0]["cfpId"].ToString()), false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
                        }
                        else
                        {
                            if (Convert.ToInt32(dt3.Rows[0]["fopId"].ToString()) == 3)
                            {
                                ocnPagosCheques.ActualizarActivoxcfp(Convert.ToInt32(dt2.Rows[0]["cfpId"].ToString()), false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
                            }
                            else
                            {
                                if (Convert.ToInt32(dt3.Rows[0]["fopId"].ToString()) == 4)
                                {
                                    ocnPagosTransferenciaElectronica.ActualizarActivoxcfp(Convert.ToInt32(dt2.Rows[0]["cfpId"].ToString()), false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
                                }
                            }
                        }
                    }
                    ocnComprobantesFormasPago.ActualizarActivoxcdeId(cdeId, false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
                    ((Button)sender).Parent.Controls[1].Visible = true;
                    ((Button)sender).Parent.Controls[3].Visible = false;
                    ((Button)sender).Parent.Controls[5].Visible = false;

                    GrillaCargar(GrillaHistorial.PageIndex);
                }
            }
            else // pide eliminar concepto mal cargado
            {
                ocnInscripcionConcepto.EliminarporIcoIdporAnio(icoId, usuIdCreacion);
                GrillaCargar(GrillaHistorial.PageIndex);
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


    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
        GrillaCargar(GrillaHistorial.PageIndex);

    }

    protected void txtAnioLectivo_TextChanged(object sender, EventArgs e)
    {
        int Id;
        lblMjerror2.Text = "";
        int PageIndex = 0;
        if (txtAnioLectivo.Text != "")
        {

            if (lblaluId.Text == "0")
            {
                lblMjerror2.Text = "Debe buscar y seleccionar un alumno";
                return;

            }
            else
            {

                Id = Convert.ToInt32(lblaluId.Text);

                PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);
                GrillaCargar(PageIndex);
                GrillaBuscar.DataSource = null;
                GrillaBuscar.DataBind();
            }
        }

        else
        {
            Id = Convert.ToInt32(lblaluId.Text);
            PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);
            GrillaCargar(PageIndex);
            GrillaBuscar.DataSource = null;
            GrillaBuscar.DataBind();
        }
    }

    protected void btnImprimirClick(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            int aniocursado = Convert.ToInt32(txtAnioLectivo.Text);
            int aluId = Convert.ToInt32(lblaluId.Text);
            int mes = Convert.ToInt32(Session["UltimaCuota"]) + 2;
            int InstId = Convert.ToInt32(this.Session["_Institucion"]);
            int UsuId = Convert.ToInt32(this.Session["_usuId"]);

            if (UsuId >= 2503 && UsuId <=2507 )
            {
                NomRep = "LibreDeudaMarcela.rpt";
            } else
            {
                NomRep = "LibreDeuda.rpt";
            }
            
       
           FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId +  "&aniocursado=" + aniocursado +  "&aluId=" + aluId + "&mes=" + mes + "&NomRep=" + NomRep);
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

