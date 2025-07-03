
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;


public partial class CuentaCorriente : System.Web.UI.Page
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

    int insId;
    Int32 icuId2;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Cuenta Corriente";
                //insId = Convert.ToInt32(Session["_Institucion"]);

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                int ban = 0;
                Session["Bandera"] = ban;
                #region PageIndex
                int PageIndex = 0;
                int aluId1 = Convert.ToInt32(Request.QueryString["Id"]);
                txtAnioLectivo.Text = Convert.ToString(DateTime.Today.Year);

                //DataTable dt = new DataTable();
                //dt.Columns.Add("icoId", typeof(Int32));
                //dt.Columns.Add("conId", typeof(Int32));
                //dt.Columns.Add("NroCuota", typeof(String));
                //dt.Columns.Add("Importe", typeof(Decimal));
                //dt.Columns.Add("FchPago", typeof(DateTime));
                //dt.Columns.Add("ImpInteres", typeof(Decimal));

                //GrillaHistorial.DataSource = dt;
                //GrillaHistorial.DataBind();
                //Session["Historial"] = dt;
                alerError.Visible = false;
                alerExito.Visible = false;

                if (this.Session["CuentaCorriente.PageIndex"] == null)
                {
                    Session.Add("CuentaCorriente.PageIndex", 0);
                }

                else
                {
                    PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);
                }
                #endregion
                lblaluId.Text = "0";
                #region Variables de sesion para filtros
                //if (Session["LibroDisciplina.Nombre"] != null) { LibroDisciplina.Text = Session["LibroDisciplina.Nombre"].ToString(); } else { Session.Add("SexoConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion
                if (aluId1 != 0)
                {
                    lblaluId.Text = Convert.ToString(aluId1);
                    PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);
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

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {

    }

    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        //dt = ocnLibroDisciplina.ObtenerTodoBuscarxNombre(Nombre.Text.Trim());
        string ArchivoNombre = "CuentaCorriente" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }



    private void GrillaBuscarCargar(int PageIndex)
    {
        try
        {
            GrillaHistorial.DataSource = null;
            GrillaHistorial.DataBind();
            lblPagado.Visible = false;
            lblVencido.Visible = false;
            txtcELESTE.Visible = false;
            txtObserv.Visible = false;
            lblContador.Visible = false;
            btnActualizar.Visible = false;
            txtRojo.Visible = false;
            lblCuotas.Visible = false;
            TexCuotas.Visible = false;
            lblInt.Visible = false;
            txtTot.Visible = false;
            lblTot.Visible = false;
            txtIntereses.Visible = false;
            btnFacturar.Visible = false;
            alerError.Visible = false;
            alerExito.Visible = false;
            //canRg.Visible = false;
            Session["CuentaCorriente.PageIndex"] = PageIndex;

            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnAlumno.ObtenerTodoBuscarxNombre(TextBuscar.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    //canRg.Visible = true;
                    //lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
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
                //canRg.Visible = true;
                if (dt.Rows.Count > 0)
                {
                    //lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
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
                    string estado = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Controls[1]).Text;
                    if (estado == "Si")
                    {
                        aluEstado.Text = "Activo";
                        aluEstado.BackColor = System.Drawing.ColorTranslator.FromHtml("#006699"); // Azul
                        aluEstado.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        aluEstado.Text = "Inactivo";
                        aluEstado.BackColor = System.Drawing.ColorTranslator.FromHtml("#B81822"); // Colorado
                        aluEstado.ForeColor = System.Drawing.Color.White;
                    }

                    aluEstado.Enabled = false;

                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);

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
        DateTime FechaPago;
        DataTable dt9 = new DataTable();
        string dateString = Convert.ToString(DateTime.Now.ToShortDateString());
        FechaPago = DateTime.Parse(dateString);
        lblMensaje.Visible = false;
        try
        {
            //canRg.Visible = false;
            alerError2.Visible = false;
            alerError.Visible = false;
            alerExito.Visible = false;
            lblMjerror2.Text = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("icoId", typeof(int));
            dt.Columns.Add("conId", typeof(Int32));
            dt.Columns.Add("cntId", typeof(Int32));
            dt.Columns.Add("TipoConcepto", typeof(String));
            dt.Columns.Add("Concepto", typeof(String));
            dt.Columns.Add("RA", typeof(Decimal));
            dt.Columns.Add("Importe", typeof(Decimal));
            dt.Columns.Add("ImporteInteres", typeof(Decimal));
            dt.Columns.Add("ImporteTotal", typeof(Decimal));
            dt.Columns.Add("AnioLectivo", typeof(Decimal));
            dt.Columns.Add("Beca", typeof(String));
            dt.Columns.Add("BecId", typeof(Int32));
            dt.Columns.Add("NroCuota", typeof(Int32));
            dt.Columns.Add("FchInscripcion", typeof(String));
            dt.Columns.Add("FechaVto", typeof(String));
            dt.Columns.Add("ValorInteres", typeof(Decimal));
            dt.Columns.Add("ImpPagado", typeof(Decimal));
            dt.Columns.Add("Dcto", typeof(Decimal));
            dt.Columns.Add("FechaPago", typeof(String));
            dt.Columns.Add("NroCompbte", typeof(String));
            dt.Columns.Add("Curso", typeof(String));
            dt.Columns.Add("Contado", typeof(String));
            dt.Columns.Add("Tarjeta", typeof(String));
            dt.Columns.Add("Cheque", typeof(String));
            dt.Columns.Add("TranfElec", typeof(String));
            dt.Columns.Add("Colegio", typeof(String));
            dt.Columns.Add("LP", typeof(String));
            dt.Columns.Add("FP", typeof(String));
            dt.Columns.Add("insId", typeof(Int32));
            dt.Columns.Add("BecasInteres", typeof(Decimal));
            DataTable dtConc = new DataTable();

            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            Decimal TotAdeuda = 0;
            Decimal txtInt = 0;
            // InscripcionCursado.ObtenerTodoporaluIdAnioCursado
            Decimal ImporteTotal = 0;
            int Bandera;
            Session["CuentaCorriente.PageIndex"] = PageIndex;

            int ins_Id = 0;
            String Colegio = "";

            DateTime Vto = DateTime.Now;

            if (txtAnioLectivo.Text == "") //traigo historial del alumno
            {
                dt3 = ocnInscripcionCursado.ObtenerTodoporaluId(Convert.ToInt32(lblaluId.Text));// obtengo todos los cursos del alumno
                if (dt3.Rows.Count > 0)
                {
                    txtObserv.Visible = false;
                    lblContador.Visible = false;
                    btnActualizar.Visible = false;

                    foreach (DataRow row5 in dt3.Rows)// por cada curso..
                    {
                        icuId2 = Convert.ToInt32(row5["Id"].ToString());

                        ins_Id = Convert.ToInt32(row5["insId"].ToString());
                        Colegio = Convert.ToString(row5["Colegio"].ToString());

                        dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2); //tabla de conceptos para ese curso
                        if (dt4.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt4.Rows)
                            {
                                dt2 = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(row["Id"].ToString())); //Pago concepto?
                                dt5 = ocnConceptosIntereses.ObtenerInteresxconIdxNroCuota(Convert.ToInt32(row["conId"].ToString()), Convert.ToInt32(row["NroCuota"].ToString()));
                                if (dt5.Rows.Count > 0)
                                {
                                    Bandera = 0;// Para poner importe pagado a un solo vto.. 
                                    foreach (DataRow row2 in dt5.Rows)
                                    {
                                        Decimal ImporteBecado = 0;
                                        if (Bandera == 0)
                                        {
                                            if (dt2.Rows.Count > 0)// Es concepto Pagado
                                            {
                                                dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                                dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                DataRow row1 = dt.NewRow();
                                                row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                row1["Dcto"] = (Convert.ToDecimal(row["Dcto"].ToString()));
                                                row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));

                                                row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", 0));
                                                if (Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) == 0)
                                                {
                                                    row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
                                                }


                                                row1["AnioLectivo"] = Convert.ToInt32(row["AnioLectivo"].ToString());
                                                row1["Beca"] = Convert.ToString((row["Becas"].ToString()));
                                                row1["BecId"] = Convert.ToString((row["BecId"].ToString()));
                                                row1["FchInscripcion"] = Convert.ToString(row["FechaInscripcion"].ToString());
                                                row1["FechaVto"] = Convert.ToString(row2["FechaVto"].ToString());
                                                row1["ValorInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
                                                row1["ImpPagado"] = Convert.ToDecimal(dt2.Rows[0]["Importe"].ToString());
                                                row1["FechaPago"] = Convert.ToString(dt6.Rows[0]["FechaPago"].ToString());
                                                row1["NroCompbte"] = Convert.ToString(dt6.Rows[0]["NroCompbte"].ToString());
                                                row1["Curso"] = Convert.ToString(row5["Curso"].ToString());
                                                row1["LP"] = Convert.ToString(dt2.Rows[0]["LP"].ToString());
                                                row1["FP"] = Convert.ToString(dt2.Rows[0]["FP"].ToString());
                                                // int qq = 0;
                                                // qq = ins_Id;
                                                //row1["insId"] = (Convert.ToInt32(dt2.Rows[0]["insId"].ToString()));
                                                row1["insId"] = ins_Id.ToString();
                                                row1["Colegio"] = Colegio;
                                                row1["ImporteTotal"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                Bandera = 1;
                                                dt.Rows.Add(row1);
                                            }

                                            else //Concepto no pagado
                                            {
                                                dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));

                                                DataRow row1 = dt.NewRow();
                                                row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                row1["Dcto"] = (Convert.ToDecimal(row["Dcto"].ToString()));
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
                                                row1["Curso"] = Convert.ToString(row5["Curso"].ToString());
                                                row1["LP"] = "";
                                                //row1["Colegio"] = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());
                                                //int qqq = 0;
                                                //qqq = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                                // row1["insId"] = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                                row1["Colegio"] = Colegio;
                                                row1["insId"] = ins_Id.ToString();

                                                row1["BecasInteres"] = row["BecasInteres"].ToString();
                                                //DateTime Vto;
                                                String AplicaBeca = "";
                                                float ValorInteres = 0;
                                                float Interes = 0;
                                                int Band = 0;
                                                foreach (DataRow rowi5 in dt5.Rows)
                                                {
                                                    if (Band == 0)
                                                    {
                                                        Vto = DateTime.Parse(rowi5["FechaVto"].ToString());
                                                        AplicaBeca = rowi5["coiAplicaBeca"].ToString();
                                                        // Ver el tema Beca
                                                        if (Convert.ToSingle(row["BecasInteres"].ToString()) > 0 && AplicaBeca == "1")
                                                        {
                                                            if (Convert.ToSingle(row["BecasInteres"].ToString()) < 100)
                                                            {
                                                                Interes = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Interes = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                        }

                                                        if (FechaPago <= Vto)
                                                        {
                                                            if (Convert.ToSingle(row["BecasInteres"].ToString()) > 0 && AplicaBeca == "1")
                                                            {
                                                                if (Convert.ToSingle(row["BecasInteres"].ToString()) < 100)
                                                                {
                                                                    ValorInteres = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                                    Band = 1;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                ValorInteres = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                                Band = 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                //if (Interes > ValorInteres)
                                                //{
                                                //    ValorInteres = Interes;
                                                //}
                                                //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));

                                                float ValorInteresParcial = 0;

                                                if (Interes > ValorInteres)
                                                {
                                                    ValorInteresParcial = Interes;
                                                }


                                                int MesesAtrasados = 0;
                                                if (Convert.ToSingle(dtConc.Rows[0]["ConInteresMensual"].ToString()) > 0)
                                                {
                                                    if (Convert.ToDecimal(row["Importe"].ToString()) > 0)  // ImporteConBeca
                                                        if (DateTime.Now.Year > Vto.Year)
                                                        {
                                                            MesesAtrasados = GetMonthDifference(Vto.Date, DateTime.Now.Date); //(DateTime.Now.Date - Vto.Date).Days / (365.25 / 12);
                                                        }
                                                        else
                                                        {
                                                            //MesesAtrasados = MesesAtrasados + DateTime.Now.Date.Month - Convert.ToInt32(dtConc.Rows[0]["ConMesInicio"].ToString());
                                                            MesesAtrasados = MesesAtrasados + (DateTime.Now.Date.Month - (Convert.ToInt32(dtConc.Rows[0]["ConMesInicio"].ToString()) - 1)) - Convert.ToInt32(Convert.ToInt32(row["NroCuota"].ToString()));
                                                        }
                                                }
                                                Single InteresMensualaPagar = (((Convert.ToSingle(dtConc.Rows[0]["ConInteresMensual"].ToString()) * MesesAtrasados) / 100) * (Convert.ToSingle(dtConc.Rows[0]["ConImporte"].ToString()) + ValorInteres));
                                                if (InteresMensualaPagar > 0)
                                                {

                                                    if (Convert.ToDateTime(row2["FechaVto"].ToString()) > DateTime.Now)
                                                    {
                                                        ValorInteres = 0;
                                                    }
                                                    else
                                                    {
                                                        ValorInteres = ValorInteres + InteresMensualaPagar;
                                                    }
                                                }

                                                row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));

                                                ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["ImporteTotal"] = ImporteTotal;



                                                dt.Rows.Add(row1);
                                                Bandera = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            GrillaHistorial.DataSource = null;
                            GrillaHistorial.DataBind();
                            lblPagado.Visible = false;
                            lblVencido.Visible = false;
                            txtcELESTE.Visible = false;
                            txtObserv.Visible = false;
                            lblContador.Visible = false;
                            btnActualizar.Visible = false;
                            txtRojo.Visible = false;
                            lblCuotas.Visible = false;
                            TexCuotas.Visible = false;
                            lblInt.Visible = false;
                            txtTot.Visible = false;
                            lblTot.Visible = false;
                            txtIntereses.Visible = false;
                            btnFacturar.Visible = false;
                            alerError.Visible = true;
                            lblError.Text = "No se encontraron registros en ese año lectivo..";
                            return;
                        }
                    }
                }
                else
                {
                    DataTable dt8 = new DataTable();
                    this.GrillaHistorial.DataSource = dt8;
                    this.GrillaHistorial.PageIndex = PageIndex;
                    this.GrillaHistorial.DataBind();
                    lblPagado.Visible = false;
                    lblVencido.Visible = false;
                    txtcELESTE.Visible = false;
                    txtObserv.Visible = false;
                    lblContador.Visible = false;
                    btnActualizar.Visible = false;
                    txtRojo.Visible = false;
                    btnFacturar.Visible = false;
                    lblCuotas.Visible = false;
                    TexCuotas.Visible = false;
                    lblInt.Visible = false;
                    txtTot.Visible = false;
                    lblTot.Visible = false;
                    txtIntereses.Visible = false;
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
            else //seleccionó Año Lectivo
            {
                dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(Convert.ToInt32(lblaluId.Text), Convert.ToInt32(txtAnioLectivo.Text));


                if (dt3.Rows.Count > 0)
                {
                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    lblicuId.Text = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                    ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                    Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());
                    txtObserv.Text = Convert.ToString(dt3.Rows[0]["icuObserv"].ToString());
                    dt4 = ocnInscripcionConcepto.ObtenerUnoxicuIdsinPre(icuId2);
                    if (dt4.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt4.Rows)
                        {
                            dt2 = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(row["Id"].ToString()));
                            dt5 = ocnConceptosIntereses.ObtenerInteresxconIdxNroCuota(Convert.ToInt32(row["conId"].ToString()), Convert.ToInt32(row["NroCuota"].ToString()));
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
                                            row1["Dcto"] = (Convert.ToDecimal(row["Dcto"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", 0));
                                            if (Convert.ToDecimal(dt2.Rows[0]["Importe"].ToString()) == 0)
                                            {
                                                row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
                                            }
                                            //Decimal qqp = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());

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
                                            row1["LP"] = Convert.ToString(dt2.Rows[0]["LP"].ToString());
                                            row1["FP"] = Convert.ToString(dt2.Rows[0]["FP"].ToString());
                                            //Int32 pp = 0;
                                            // pp = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            row1["insId"] = ins_Id.ToString(); //(Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            row1["ImporteTotal"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            Bandera = 1;
                                            dt.Rows.Add(row1);
                                        }
                                        else
                                        {
                                            dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["Dcto"] = (Convert.ToDecimal(row["Dcto"].ToString()));
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
                                            row1["LP"] = "";
                                            row1["FP"] = "";
                                            //Int32 ppp = 0;
                                            //ppp = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            row1["insId"] = ins_Id.ToString();

                                            row1["BecasInteres"] = row["BecasInteres"].ToString();
                                            //DateTime Vto;
                                            String AplicaBeca = "";
                                            float ValorInteres = 0;
                                            float Interes = 0;
                                            int Band = 0;

                                            int NumCuota = Convert.ToInt32(row["NroCuota"].ToString());

                                            foreach (DataRow rowi5 in dt5.Rows)
                                            {
                                                if (Band == 0)
                                                {
                                                    Vto = DateTime.Parse(rowi5["FechaVto"].ToString());
                                                    AplicaBeca = rowi5["coiAplicaBeca"].ToString();
                                                    // Ver el tema Beca
                                                    if (Convert.ToSingle(row["BecasInteres"].ToString()) > 0 && AplicaBeca == "1")
                                                    {
                                                        if (Convert.ToSingle(row["BecasInteres"].ToString()) < 100)
                                                        {
                                                            //Interes = (Convert.ToSingle(row["BecasInteres"].ToString()) * Convert.ToSingle(rowi5["coiValorInteres"].ToString())) / 100;
                                                            Interes = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Interes = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                    }

                                                    if (FechaPago <= Vto)
                                                    {
                                                        if (Convert.ToSingle(row["BecasInteres"].ToString()) > 0 && AplicaBeca == "1")
                                                        {
                                                            if (Convert.ToSingle(row["BecasInteres"].ToString()) < 100)
                                                            {
                                                                ValorInteres = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                                Band = 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ValorInteres = Convert.ToSingle(rowi5["coiValorInteres"].ToString());
                                                            Band = 1;
                                                        }
                                                    }
                                                }
                                            }
                                            //if (Interes > ValorInteres)
                                            //{
                                            //    ValorInteres = Interes;
                                            //}
                                            //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));

                                            float ValorInteresParcial = 0;

                                            if (Interes > ValorInteres)
                                            {
                                                ValorInteresParcial = Interes;
                                            }


                                            int MesesAtrasados = 0;
                                            if (Convert.ToSingle(dtConc.Rows[0]["ConInteresMensual"].ToString()) > 0)
                                            {
                                                if (Convert.ToDecimal(row["Importe"].ToString()) > 0)  // ImporteConBeca
                                                    if (DateTime.Now.Year > Vto.Year)
                                                    {
                                                        MesesAtrasados = GetMonthDifference(Vto.Date, DateTime.Now.Date); //(DateTime.Now.Date - Vto.Date).Days / (365.25 / 12);
                                                    }
                                                    else
                                                    {
                                                        //MesesAtrasados = MesesAtrasados + DateTime.Now.Date.Month - Convert.ToInt32(dtConc.Rows[0]["ConMesInicio"].ToString());
                                                        MesesAtrasados = MesesAtrasados + (DateTime.Now.Date.Month - (Convert.ToInt32(dtConc.Rows[0]["ConMesInicio"].ToString()) - 1)) - Convert.ToInt32(Convert.ToInt32(row["NroCuota"].ToString()));
                                                    }
                                            }
                                            Single InteresMensualaPagar = (((Convert.ToSingle(dtConc.Rows[0]["ConInteresMensual"].ToString()) * MesesAtrasados) / 100) * (Convert.ToSingle(dtConc.Rows[0]["ConImporte"].ToString()) + ValorInteres));
                                            if (InteresMensualaPagar > 0)
                                            {

                                                if (Convert.ToDateTime(row2["FechaVto"].ToString()) > DateTime.Now)
                                                {
                                                    ValorInteres = 0;
                                                }
                                                else
                                                {
                                                    ValorInteres = ValorInteres + InteresMensualaPagar;
                                                }
                                            }

                                            row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                            row1["BecasInteres"] = row["BecasInteres"].ToString();

                                            ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                            row1["ImporteTotal"] = ImporteTotal;

                                            dt.Rows.Add(row1);
                                            Bandera = 1;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        GrillaHistorial.DataSource = null;
                        GrillaHistorial.DataBind();
                        lblPagado.Visible = false;
                        lblVencido.Visible = false;
                        txtcELESTE.Visible = false;
                        txtObserv.Visible = false;
                        lblContador.Visible = false;
                        btnActualizar.Visible = false;
                        txtRojo.Visible = false;
                        lblCuotas.Visible = false;
                        TexCuotas.Visible = false;
                        lblInt.Visible = false;
                        txtTot.Visible = false;
                        lblTot.Visible = false;
                        txtIntereses.Visible = false;
                        btnFacturar.Visible = false;
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
                    lblPagado.Visible = false;
                    lblVencido.Visible = false;
                    txtcELESTE.Visible = false;
                    txtObserv.Visible = false;
                    lblContador.Visible = false;
                    btnActualizar.Visible = false;
                    txtRojo.Visible = false;
                    btnFacturar.Visible = false;
                    lblCuotas.Visible = false;
                    TexCuotas.Visible = false;
                    lblInt.Visible = false;
                    txtTot.Visible = false;
                    lblTot.Visible = false;
                    txtIntereses.Visible = false;
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
                int CuotaUltPagada = 0;
                DateTime Hoy = DateTime.Today;
                DataTable dtFilaRoja = new DataTable();

                dtFilaRoja.Columns.Add("icuId", typeof(int));
                dtFilaRoja.Columns.Add("icoId", typeof(int));
                dtFilaRoja.Columns.Add("cntId", typeof(int));
                dtFilaRoja.Columns.Add("conId", typeof(Int32));
                dtFilaRoja.Columns.Add("TipoConcepto", typeof(String));
                dtFilaRoja.Columns.Add("Concepto", typeof(String));
                dtFilaRoja.Columns.Add("Importe", typeof(Decimal));
                dtFilaRoja.Columns.Add("AnioLectivo", typeof(Decimal));
                dtFilaRoja.Columns.Add("Beca", typeof(String));
                dtFilaRoja.Columns.Add("BecId", typeof(Int32));
                dtFilaRoja.Columns.Add("NroCuota", typeof(Int32));
                dtFilaRoja.Columns.Add("FchInscripcion", typeof(String));

                String FchaInscripcionCon2;
                Int32 NroCuotaCon2;
                int banFilaRojaAlMenosUna = 0;
                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0 || Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecId"]) == 13 || Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["Dcto"]) != 0)
                    {
                        row.BackColor = System.Drawing.Color.LightBlue;
                        CuotaUltPagada = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                        ((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;

                    }

                    else
                    {

                        if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < Hoy)
                        {
                            row.BackColor = System.Drawing.Color.FromName("#B81822");
                            row.ForeColor = System.Drawing.Color.White;
                            TotAdeuda = TotAdeuda + Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["Importe"]);

                            Int32 bcaIdCon;
                            Int32 AnioCursado;
                            AnioCursado = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["AnioLectivo"]);
                            insId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["insId"]);
                            dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCursado, Convert.ToInt32(lblaluId.Text));
                            icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                            FchaInscripcionCon2 = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FchInscripcion"]);
                            NroCuotaCon2 = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                            bcaIdCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecasId"]);
                            DataRow row1 = dtFilaRoja.NewRow();
                            row1["icuId"] = icuId2;
                            row1["icoId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["icoId"]);
                            row1["cntId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["cntId"]);
                            row1["conId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["conId"]);
                            row1["TipoConcepto"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                            row1["Concepto"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Concepto"]);
                            row1["Importe"] = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["Importe"]);
                            row1["AnioLectivo"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["AnioLectivo"]);
                            row1["Beca"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Beca"]);
                            row1["BecId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecId"]);
                            row1["NroCuota"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);

                            row1["FchInscripcion"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FchInscripcion"]);
                            dtFilaRoja.Rows.Add(row1);
                            banFilaRojaAlMenosUna = 1;
                        }
                        Session.Add("FilaRoja", dtFilaRoja);

                    }
                }


                //////////////////////////////////////////////////////////////////////////////////////////////
                if (banFilaRojaAlMenosUna == 1)
                {
                    dt2 = Session["FilaRoja"] as DataTable;
                    if (dt2.Rows.Count > 0)
                    {

                        FechaPago = DateTime.Parse(dateString);
                        Bandera = 0;
                        decimal InteresCuotaAsignar = 0;
                        decimal InteresMensualAsignar = 0;

                        string AplicaInteres;
                        decimal RecargoAbiertoAsignar = 0;
                        decimal InteresTotal = 0;
                        DateTime fchVtoAsignar = DateTime.Now;
                        //LblMjeGridConcepto.Text = "";
                        String FchaInscripcionCon;
                        Int32 NroCuotaCon;
                        foreach (DataRow row3 in dt2.Rows)
                        {
                            int ValorSeleccionado;
                            //obtengo incripcionConepto 
                            dt9 = ocnInscripcionConcepto.ObtenerUno(Convert.ToInt32(row3["icoId"].ToString()));
                            int conId = Convert.ToInt32(row3["conId"].ToString());
                            dt3 = ocnConceptos.ObtenerUno(Convert.ToInt32(row3["conId"].ToString()));
                            DateTime UltVto;
                            if (dt9.Rows.Count > 0) //Inscripcion Concepto Existe
                            {
                                FchaInscripcionCon = Convert.ToString(dt9.Rows[0]["FechaInscripcion"].ToString());
                                NroCuotaCon = Convert.ToInt32(dt9.Rows[0]["NroCuota"].ToString());

                                String BecaCon = Convert.ToString(dt9.Rows[0]["Becas"].ToString());

                                //Busco si hay Vencimiento
                                dt4 = ocnConceptosIntereses.ObtenerListaxconIdxNroCuota(Convert.ToInt32(Convert.ToInt32(row3["conId"].ToString())), (Convert.ToInt32(row3["NroCuota"].ToString())));

                                Decimal ValorInteresCI = 0;
                                DateTime FchaVtofila;
                                int BanderaVto = 0;
                                if (dt4.Rows.Count > 0)//Existe en la Tabla ConceptoIneres
                                {
                                    String pFecha = "";
                                    pFecha = dt4.Rows[0]["FechaVto"].ToString();
                                    FchaVtofila = Convert.ToDateTime(dt4.Rows[0]["FechaVto"].ToString());//1° Vto
                                    int Ban = 0;
                                    int i = 0;
                                    while (i < dt4.Rows.Count && Ban == 0)
                                    {
                                        DataRow nextRow = dt4.Rows[i];
                                        DataRow row4 = dt4.Rows[i];
                                        FchaVtofila = Convert.ToDateTime(row4["FechaVto"].ToString());
                                        if (FchaVtofila >= FechaPago)
                                        {
                                            Ban = 1;
                                        }
                                        fchVtoAsignar = Convert.ToDateTime(row4["FechaVto"].ToString());
                                        AplicaInteres = Convert.ToString(row4["AplicaInteres"].ToString());
                                        ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());
                                        if (ValorSeleccionado == 0) // Monto fijo
                                        {
                                            if (Convert.ToDecimal(row4["ValorInteres"].ToString()) > 0)
                                            {
                                                if (AplicaInteres == "Si")// Se Cobra Interes
                                                {

                                                    if (Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) > 0)
                                                    {
                                                        //ValorInteresCI = Math.Round((Convert.ToDecimal(row4["ValorInteres"].ToString()) * Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) / 100), 2);
                                                        ValorInteresCI = Math.Round(Convert.ToDecimal(row4["ValorInteres"].ToString()), 2);
                                                    }
                                                    else
                                                    {
                                                        ValorInteresCI = Convert.ToDecimal(row4["ValorInteres"].ToString());
                                                    }
                                                }
                                                else
                                                {
                                                    ValorInteresCI = 0;
                                                }
                                            }
                                            else
                                            {
                                                ValorInteresCI = 0;
                                            }
                                        }
                                        else // Porcentaje
                                        {
                                            if (Convert.ToDecimal(row4["ValorInteres"].ToString()) > 0)
                                            {
                                                if (AplicaInteres == "Si")// Se Cobra Interes
                                                {
                                                    if (Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) > 0)
                                                    {
                                                        ValorInteresCI = Math.Round((Convert.ToDecimal(row3["Importe"].ToString()) * Convert.ToDecimal(row4["ValorInteres"].ToString()) / 100
                                                            * Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) / 100), 2);
                                                    }
                                                    else
                                                    {
                                                        ValorInteresCI = Convert.ToDecimal(row3["Importe"].ToString()) * Convert.ToDecimal(row4["ValorInteres"].ToString()) / 100;
                                                    }
                                                }
                                                else
                                                {
                                                    ValorInteresCI = 0;
                                                }
                                            }
                                            else
                                            {
                                                ValorInteresCI = 0;
                                            }
                                        }

                                        i = i + 1;
                                    }


                                    InteresCuotaAsignar = ValorInteresCI;
                                    RecargoAbiertoAsignar = 0;
                                    InteresMensualAsignar = 0;
                                    InteresTotal = ValorInteresCI;
                                    fchVtoAsignar = Convert.ToDateTime(FchaVtofila);
                                    BanderaVto = 1;

                                    DataTable dt12 = ocnConceptosIntereses.ObtenerUltimoVencimiento(Convert.ToInt32(Convert.ToInt32(row3["conId"].ToString())), (Convert.ToInt32(row3["NroCuota"].ToString())));
                                    if (dt12.Rows.Count > 0)
                                    {
                                        UltVto = Convert.ToDateTime(dt12.Rows[0]["FechaVto"].ToString());

                                        if (FechaPago > UltVto)
                                        {
                                            Decimal InteresMensualIM;
                                            Decimal InteresAplicar = 0;
                                            Decimal ValorInteresRA = 0;
                                            ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());
                                            if (Convert.ToString(dt3.Rows[0]["TieneVtoAbierto"]) == "Si")
                                            {

                                                if (ValorSeleccionado == 0)// Interés con Monto Fijo
                                                {
                                                    ValorInteresRA = Convert.ToDecimal(dt3.Rows[0]["RecargoVtoAbierto"].ToString());

                                                    if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
                                                    {
                                                        Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

                                                        InteresMensualIM = ((Convert.ToDecimal(row3["Importe"].ToString()) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
                                                        InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

                                                        InteresCuotaAsignar = ValorInteresCI;
                                                        RecargoAbiertoAsignar = ValorInteresRA;
                                                        InteresMensualAsignar = InteresAplicar;
                                                        InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                                        fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                    }
                                                    else
                                                    {
                                                        InteresCuotaAsignar = ValorInteresCI;
                                                        RecargoAbiertoAsignar = ValorInteresRA;
                                                        InteresMensualAsignar = InteresAplicar;
                                                        InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                                        fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                    }
                                                }
                                                else// Porcentaje
                                                {
                                                    ValorInteresRA = (Convert.ToDecimal(dt3.Rows[0]["Importe"].ToString()) * Convert.ToDecimal(dt3.Rows[0]["RecargoVtoAbierto"].ToString())) / 100;

                                                    if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
                                                    {
                                                        //DateTime MesSiguienteVto = UltVto.AddDays(30);
                                                        //return Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
                                                        Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
                                                        //Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));

                                                        InteresMensualIM = ((Convert.ToDecimal(row3["Importe"].ToString()) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
                                                        InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

                                                        InteresCuotaAsignar = ValorInteresCI;
                                                        RecargoAbiertoAsignar = ValorInteresRA;
                                                        InteresMensualAsignar = InteresAplicar;
                                                        InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                                        fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                    }
                                                    else
                                                    {
                                                        InteresCuotaAsignar = ValorInteresCI;
                                                        RecargoAbiertoAsignar = ValorInteresRA;
                                                        InteresMensualAsignar = InteresAplicar;
                                                        InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                                        fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
                                                {
                                                    if (ValorSeleccionado == 0)// Interés con Monto Fijo
                                                    {
                                                        //DateTime MesSiguienteVto = UltVto.AddDays(30);

                                                        Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

                                                        //Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));

                                                        //InteresMensualIM = ((Convert.ToDecimal(row3["Importe"].ToString()) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
                                                        InteresMensualIM = (Convert.ToDecimal(dt3.Rows[0]["conImporte"].ToString()) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;

                                                        InteresAplicar = (InteresMensualIM * Convert.ToDecimal(diff));

                                                        InteresCuotaAsignar = ValorInteresCI;
                                                        RecargoAbiertoAsignar = ValorInteresRA;
                                                        InteresMensualAsignar = InteresAplicar;
                                                        InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                                        fchVtoAsignar = Convert.ToDateTime(UltVto);

                                                    }
                                                    else
                                                    {
                                                        //DateTime MesSiguienteVto = UltVto.AddDays(30);
                                                        //Decimal diff = Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));
                                                        Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

                                                        InteresMensualIM = ((Convert.ToDecimal(row3["Importe"].ToString()) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
                                                        InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

                                                        InteresCuotaAsignar = ValorInteresCI;
                                                        RecargoAbiertoAsignar = ValorInteresRA;
                                                        InteresMensualAsignar = InteresAplicar;
                                                        InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                                        fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                    }
                                                }
                                                else
                                                {
                                                    InteresCuotaAsignar = ValorInteresCI;
                                                    RecargoAbiertoAsignar = ValorInteresRA;
                                                    InteresMensualAsignar = 0;
                                                    InteresTotal = ValorInteresCI + ValorInteresRA;
                                                    fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                }
                                            }
                                        }
                                    }
                                }
                            }



                            //DataRow row1 = dt.NewRow();
                            //row1["icoId"] = Convert.ToInt32(row3["icoId"].ToString());
                            //row1["conId"] = Convert.ToInt32(row3["conId"].ToString());
                            //row1["TipoConcepto"] = Convert.ToInt32(row3["cntId"].ToString());
                            //row1["Concepto"] = Convert.ToString(row3["Concepto"].ToString());
                            //row1["Importe"] = Convert.ToDecimal(row3["Importe"].ToString());
                            //row1["InteresCuota"] = InteresCuotaAsignar;
                            //row1["RecargoAbierto"] = RecargoAbiertoAsignar;
                            //row1["InteresMensual"] = InteresMensualAsignar;
                            //row1["AnioLectivo"] = Convert.ToInt32(row3["AnioLectivo"].ToString());
                            //row1["Beca"] = Convert.ToString(row3["Beca"].ToString());
                            //row1["BecId"] = Convert.ToInt32(row3["BecId"].ToString());
                            //row1["FchInscripcion"] = Convert.ToString(row3["FchInscripcion"].ToString());
                            //row1["FechaVto"] = Convert.ToString(fchVtoAsignar);
                            //row1["NroCuota"] = Convert.ToInt32(row3["NroCuota"].ToString());
                            txtInt = txtInt + InteresTotal;


                            //dt.Rows.Add(row1);
                            //Bandera = 1;
                        }
                        Decimal TotGral = TotAdeuda + txtInt;
                        TexCuotas.Text = Convert.ToString(TotAdeuda);
                        txtIntereses.Text = Convert.ToString(txtInt);
                        txtTot.Text = Convert.ToString(TotGral);

                        //////////////////////////////////
                    }
                    else
                    {
                        TexCuotas.Text = "0";
                        txtIntereses.Text = "0";
                        txtTot.Text = "0";
                    }
                }
                else
                {
                    TexCuotas.Text = "0";
                    txtIntereses.Text = "0";
                    txtTot.Text = "0";
                }
            }
            else
            {
                GrillaHistorial.DataSource = null;
                GrillaHistorial.DataBind();

            }
            lblPagado.Visible = true;
            lblVencido.Visible = true;
            txtcELESTE.Visible = true;

            if (txtAnioLectivo.Text == "")
            {
                txtObserv.Visible = false;
                lblContador.Visible = false;
                btnActualizar.Visible = false;
            }
            else
            {
                txtObserv.Visible = true;
                lblContador.Visible = true;
                btnActualizar.Visible = true;
            }
            txtRojo.Visible = true;
            btnFacturar.Visible = true;
            lblCuotas.Visible = true;
            TexCuotas.Visible = true;
            lblInt.Visible = true;
            txtIntereses.Visible = true;
            txtTot.Visible = true;
            lblTot.Visible = true;
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

    public static int GetMonthDifference(DateTime startDate, DateTime endDate)
    {
        int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        return Math.Abs(monthsApart);
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //dt = new DataTable();
        //this.Grilla.DataSource = dt;
        //this.Grilla.DataBind();
        lblicuId.Text = "";
        lblMensaje.Visible = false;
        lblaluId.Text = "";
        aluNombre.Text = "";
        aludni.Text = "";
        GrillaHistorial.DataSource = null;
        GrillaHistorial.DataBind();
        lblPagado.Visible = false;
        lblVencido.Visible = false;
        txtcELESTE.Visible = false;
        txtObserv.Visible = false;
        lblContador.Visible = false;
        btnActualizar.Visible = false;
        txtRojo.Visible = false;
        lblCuotas.Visible = false;
        TexCuotas.Visible = false;
        lblInt.Visible = false;
        txtTot.Visible = false;
        lblTot.Visible = false;
        txtIntereses.Visible = false;
        btnFacturar.Visible = false;
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

    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaBuscar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string eventArg = "Select$" + row.RowIndex;
                ClientScript.RegisterForEventValidation(GrillaBuscar.UniqueID, eventArg);

                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaBuscar, eventArg, true);
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
                        //Int32 cocId = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                        //Int32 cocId2 = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                        //int InstId = Convert.ToInt32(this.Session["_Institucion"]);
                        //NomRep = "InformeResumenPago.rpt";
                        //FuncionesUtiles.AbreVentana("Reporte.aspx?icuId=" + icuId + "&cocId=" + cocId + "&cocId2=" + cocId2 + "&NomRep=" + NomRep);

                        //Int32 icuId = Int32.Parse(lblicuId.Text);
                        Int32 cocId = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                        Int32 cocId2 = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                        Int32 cocId3 = Convert.ToInt32(dt2.Rows[0]["cocId"].ToString());
                        int InstId = Convert.ToInt32(this.Session["_Institucion"]);

                        NomRep = "InformeFactura.rpt";
                        FuncionesUtiles.AbreVentana("Reporte.aspx?icuId=" + icuId + "&cocId=" + cocId + "&cocId2=" + cocId2 + "&cocId3=" + cocId3 + "&NomRep=" + NomRep);

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
        lblMensaje.Visible = false;
        int ban;
        if (RbtBuscar.SelectedIndex == 1) //la busqueda será por dni
        {
            ban = 1;

            GrillaBuscar.DataSource = null;
            GrillaBuscar.DataBind();
            GrillaHistorial.DataSource = null;
            GrillaHistorial.DataBind();
            lblPagado.Visible = false;
            lblVencido.Visible = false;
            txtcELESTE.Visible = false;
            txtObserv.Visible = false;
            lblContador.Visible = false;
            btnActualizar.Visible = false;
            txtRojo.Visible = false;
            lblCuotas.Visible = false;
            TexCuotas.Visible = false;
            lblInt.Visible = false;
            txtTot.Visible = false;
            lblTot.Visible = false;
            txtIntereses.Visible = false;
            btnFacturar.Visible = false;

        }
        else
        {
            ban = 0;// la busqueda será por nombre

            GrillaBuscar.DataSource = null;
            GrillaBuscar.DataBind();
            GrillaHistorial.DataSource = null;
            GrillaHistorial.DataBind();
            lblPagado.Visible = false;
            lblVencido.Visible = false;
            txtcELESTE.Visible = false;
            txtObserv.Visible = false;
            lblContador.Visible = false;
            btnActualizar.Visible = false;
            txtRojo.Visible = false;
            lblCuotas.Visible = false;
            TexCuotas.Visible = false;
            lblInt.Visible = false;
            txtTot.Visible = false;
            lblTot.Visible = false;
            txtIntereses.Visible = false;
            btnFacturar.Visible = false;
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
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["Dcto"]) != 0)
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
                        }
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
                            ocnPagosTarjetas.ActualizarActivoxcfp(Convert.ToInt32(dt3.Rows[0]["cfpId"].ToString()), false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
                        }
                        else
                        {
                            if (Convert.ToInt32(dt3.Rows[0]["fopId"].ToString()) == 3)
                            {
                                ocnPagosCheques.ActualizarActivoxcfp(Convert.ToInt32(dt3.Rows[0]["cfpId"].ToString()), false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
                            }
                            else
                            {
                                if (Convert.ToInt32(dt3.Rows[0]["fopId"].ToString()) == 4)
                                {
                                    ocnPagosTransferenciaElectronica.ActualizarActivoxcfp(Convert.ToInt32(dt3.Rows[0]["cfpId"].ToString()), false, usuIdCreacion, usuIdUltimaModificacion, cocFechaHoraCreacion, cocFechaHoraUltimaModificacion);
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
            else
            {
                if (Convert.ToInt32(GrillaHistorial.DataKeys[row2].Values["Dcto"]) == 0)// pide eliminar concepto mal cargado
                {
                    ocnInscripcionConcepto.EliminarporIcoIdporAnio(icoId, usuIdCreacion);
                    GrillaCargar(GrillaHistorial.PageIndex);
                }
                else
                {
                    ocnInscripcionConcepto.ActualizarDcto(icoId, 0, usuIdUltimaModificacion, cocFechaHoraUltimaModificacion);
                    GrillaCargar(GrillaHistorial.PageIndex);
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


    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
        GrillaCargar(GrillaHistorial.PageIndex);

    }


    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        //GrillaCargar(Grilla.PageIndex);
    }

    protected void btnFacturarClick(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            alerError.Visible = false;
            alerExito.Visible = false;

            //insId = Convert.ToInt32(Session["_Institucion"]);
            lblMensajeError.Text = "";
            int BanChk = 0;
            foreach (GridViewRow row in GrillaHistorial.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                if ((check.Checked)) // Si esta seleccionado..
                {
                    BanChk = 1;
                }
            }
            if (BanChk == 1)
            {
                DataTable dt = new DataTable();
                DataTable dt9 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt1 = new DataTable();
                dt.Columns.Add("icuId", typeof(int));
                dt.Columns.Add("icoId", typeof(int));
                dt.Columns.Add("cntId", typeof(int));
                dt.Columns.Add("conId", typeof(Int32));
                dt.Columns.Add("TipoConcepto", typeof(String));
                dt.Columns.Add("Concepto", typeof(String));
                dt.Columns.Add("Importe", typeof(Decimal));
                dt.Columns.Add("AnioLectivo", typeof(Decimal));
                dt.Columns.Add("Beca", typeof(String));
                dt.Columns.Add("BecId", typeof(Int32));
                dt.Columns.Add("NroCuota", typeof(Int32));
                dt.Columns.Add("FchInscripcion", typeof(String));

                String FchaInscripcionCon;
                Int32 NroCuotaCon;
                Int32 bcaIdCon;
                Int32 AnioCursado;

                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                    //Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);

                    if ((check.Checked)) // Si esta seleccionado..
                    {
                        AnioCursado = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["AnioLectivo"]);
                        insId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["insId"]);
                        dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCursado, Convert.ToInt32(lblaluId.Text));
                        icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                        FchaInscripcionCon = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FchInscripcion"]);
                        NroCuotaCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                        bcaIdCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecasId"]);
                        DataRow row1 = dt.NewRow();
                        row1["icuId"] = icuId2;
                        row1["icoId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["icoId"]);
                        row1["cntId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["cntId"]);
                        row1["conId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["conId"]);
                        row1["TipoConcepto"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                        row1["Concepto"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Concepto"]);
                        row1["Importe"] = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["Importe"]);
                        row1["AnioLectivo"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["AnioLectivo"]);
                        row1["Beca"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Beca"]);
                        row1["BecId"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecId"]);
                        row1["NroCuota"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);

                        row1["FchInscripcion"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FchInscripcion"]);
                        dt.Rows.Add(row1);
                    }
                    Session.Add("TablaPagar", dt);


                }
                Response.Redirect("Facturacion.aspx?Id=" + icuId2, false);
            }
            else
            {
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);

                GrillaCargar(PageIndex);
                GrillaBuscar.DataSource = null;
                GrillaBuscar.DataBind();
                alerError2.Visible = true;
                lblError2.Text = "Debe seleccionar un items a facturar";
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

    protected void txtAnioLectivo_TextChanged(object sender, EventArgs e)
    {
        int Id;
        lblMjerror2.Text = "";
        int PageIndex = 0;
        if (txtAnioLectivo.Text != "")
        {
            if (lblaluId.Text == "0" || lblaluId.Text == "")
            {
                GrillaBuscarCargar(GrillaBuscar.PageIndex);
                //lblMjerror2.Text = "Debe buscar y seleccionar un alumno";
                //return;

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

    protected void btnActualizarClick(object sender, EventArgs e)
    {
        int icuId = Convert.ToInt32(lblicuId.Text);
        ocnInscripcionCursado.ActualizarObserv(icuId, txtObserv.Text);
        lblMensaje.Visible = true;
    }
}

