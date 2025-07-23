using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using System.Diagnostics;


public partial class EstadoCuentaPadres : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    //GESTIONESCOLAR.Negocio.ComprobantesFormasPago ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.TEMESTADOCUENTA ocnTEMESTADOCUENTA = new GESTIONESCOLAR.Negocio.TEMESTADOCUENTA();
    GESTIONESCOLAR.Negocio.LibreDeudaQR ocnLibreDeudaQR = new GESTIONESCOLAR.Negocio.LibreDeudaQR();

    int insId;

    Int32 icuId2;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                int Anio = DateTime.Now.Year;
                txtAnioLectivo.Text = Convert.ToString(Anio);
                //                lblMensajeError.visible = false;

                alerError2.Visible = false;
                lblMjerror2.Text = "";
 //               btnImprimir2.Visible = false;
                //lblCuotas.Visible = false;
                //TexCuotas.Visible = false;
                //lblInt.Visible = false;
                //txtIntereses.Visible = false;
                //txtTot.Visible = false;
                //lblTot.Visible = false;
                Session["Bandera"] = 0;
                //btnFacturar.Visible = false;
                //txtFchPago.Visible = false;
                //lblFchPago.Visible = false;
                this.Master.TituloDelFormulario = "Estado de Cuenta";
                //insId = Convert.ToInt32(Session["_Institucion"]);
                String DNIUSUARIO = Convert.ToString(Session["_usuNombreIngreso"].ToString());
                Int32 PageIndex = Convert.ToInt32(Session["EstadoCuentaPadres.PageIndex"]);
                //    GrillaCargar(PageIndex);
                dt = ocnAlumno.ObtenerUnoporDoc(DNIUSUARIO);
                if (dt.Rows.Count > 0)
                {
                    aluNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                    aluNombre.Enabled = false;
                    hfNombreAlumno.Value = aluNombre.Text;

                    btnFacturar.Visible = false;
                    aludni.Text = Convert.ToString(dt.Rows[0]["Doc"].ToString());
                    lblaluId.Text = Convert.ToString(dt.Rows[0]["Id"].ToString());
                    if (aludni.Text == "48481957")
                    {
                        btnFacturar.Visible = true;
                    }

                    aludni.Enabled = false;

                    //Grilla.DataSource = null;
                    //Grilla.DataBind();
                    //AlumnoSeleccionado.Visible = true;
                    PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
                    GrillaCargar(PageIndex);
                }
                else
                {

                }
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                int ban = 0;
                Session["Bandera"] = ban;
                #region PageIndex
                PageIndex = 0;
                int aluId1 = Convert.ToInt32(Request.QueryString["Id"]);

                alerError2.Visible = false;

                if (this.Session["EstadoCuenta.PageIndex"] == null)
                {
                    Session.Add("EstadoCuenta.PageIndex", 0);
                }

                else
                {
                    PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
                }
                #endregion
                //lblaluId.Text = "0";
                #region Variables de sesion para filtros
                //if (Session["LibroDisciplina.Nombre"] != null) { LibroDisciplina.Text = Session["LibroDisciplina.Nombre"].ToString(); } else { Session.Add("SexoConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion
                //if (aluId1 != 0)
                //{
                //    lblaluId.Text = Convert.ToString(aluId1);
                //    PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
                //    GrillaCargar(PageIndex);
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

    // *** INICIO DEL CÓDIGO A AGREGAR / VERIFICAR ***
    protected void GrillaHistorial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Se asume que el DataItem es de tipo DataRowView o el tipo de objeto que uses para tus datos
            // Puedes necesitar ajustar esto si tu fuente de datos es un tipo diferente
            DataRowView drv = e.Row.DataItem as DataRowView;

            if (drv != null)
            {
                // Agrega los atributos data-* a la fila (<tr>) que el JavaScript leerá
                // Asegúrate de que los nombres de los atributos (ej. "data-concepto")
                // y los nombres de las columnas en tu DataTable (ej. "Concepto")
                // coincidan con lo que tu JavaScript espera.
                e.Row.Attributes["data-concepto"] = drv["Concepto"].ToString();
                e.Row.Attributes["data-importe"] = string.Format("{0:C}", Convert.ToDecimal(drv["Importe"]));
                e.Row.Attributes["data-intereses"] = string.Format("{0:C}", Convert.ToDecimal(drv["ImporteInteres"]));
                e.Row.Attributes["data-importetotal"] = string.Format("{0:C}", Convert.ToDecimal(drv["ImporteTotal"]));
                e.Row.Attributes["data-beca"] = drv["Beca"].ToString();
                e.Row.Attributes["data-nrocuota"] = drv["NroCuota"].ToString();

                // Conversión segura a DateTime para formatear la fecha
                DateTime fechaVto;
                if (DateTime.TryParse(drv["FechaVto"].ToString(), out fechaVto))
                {
                    e.Row.Attributes["data-fechavto"] = fechaVto.ToShortDateString();
                }
                else
                {
                    e.Row.Attributes["data-fechavto"] = ""; // O un valor predeterminado si la conversión falla
                }

                e.Row.Attributes["data-dcto"] = drv["Dcto"].ToString();
                e.Row.Attributes["data-imppagado"] = string.Format("{0:C}", Convert.ToDecimal(drv["ImpPagado"]));

                DateTime fechaPago;
                if (DateTime.TryParse(drv["FechaPago"].ToString(), out fechaPago))
                {
                    e.Row.Attributes["data-fechapago"] = fechaPago.ToShortDateString();
                }
                else
                {
                    e.Row.Attributes["data-fechapago"] = "";
                }

                e.Row.Attributes["data-colegio"] = drv["Colegio"].ToString();
                e.Row.Attributes["data-curso"] = drv["Curso"].ToString();
                e.Row.Attributes["data-conid"] = drv["conId"].ToString();
                e.Row.Attributes["data-fp"] = drv["FP"].ToString();


                // Lógica para el Label "Estado" (ya presente en tu .aspx y lógica de negocio)
                Label lblEstado = (Label)e.Row.FindControl("lblEstado");
                if (lblEstado != null)
                {
                    // Obtener valores de la fila
                    decimal impPagado = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ImpPagado"));
                    DateTime fechaVtoEstado = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaVto")); // Usar una variable diferente para evitar conflictos

                    if (impPagado > 0)
                    {
                        lblEstado.Text = "Pagado";
                        lblEstado.CssClass = "label label-success"; // Asegúrate de tener estas clases CSS
                    }
                    else if (fechaVtoEstado < DateTime.Today)
                    {
                        lblEstado.Text = "Vencido";
                        lblEstado.CssClass = "label label-danger"; // Asegúrate de tener estas clases CSS
                    }
                    else
                    {
                        lblEstado.Text = "Pendiente";
                        lblEstado.CssClass = "label label-warning"; // Asegúrate de tener estas clases CSS
                    }
                }
            }
        }
    }
    // *** FIN DEL CÓDIGO A AGREGAR / VERIFICAR ***

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.origfinalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }


    private void GrillaCargar(int PageIndex)
    {
        DataTable dtAlumno = new DataTable();
        String DNIUSUARIO = Convert.ToString(Session["_usuNombreIngreso"].ToString());
        dtAlumno = ocnAlumno.ObtenerUnoporDoc(DNIUSUARIO);
        if (dtAlumno.Rows.Count > 0)
        {
            String NombreAlumno = dtAlumno.Rows[0]["Nombre"].ToString();
        }
        DateTime FechaPago;
        DataTable dt9 = new DataTable();
        string dateString = Convert.ToString(DateTime.Now.ToShortDateString());
        FechaPago = DateTime.Parse(dateString);

        try
        {
            //canRg.Visible = false;
            alerError2.Visible = false;

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
            dt.Columns.Add("Dcto", typeof(Decimal));
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
            Decimal ImporteTotal = 0;
            // InscripcionCursado.ObtenerTodoporaluIdAnioCursado

            int Bandera;
            Session["CuentaCorriente.PageIndex"] = PageIndex;
            DateTime Vto = DateTime.Now;

            int ins_Id = 0;
            String Colegio = "";

            if (ckbDeuda.Checked == false)
            {
                if (txtAnioLectivo.Text == "") //traigo historial del alumno
                {
                    dt3 = ocnInscripcionCursado.ObtenerTodoporaluId(Convert.ToInt32(lblaluId.Text));// obtengo todos los cursos del alumno

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
                                                row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                row1["Dcto"] = (Convert.ToDecimal(row["Dcto"].ToString()));
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

                                                float ValorInteresParcial = ValorInteres;
                                                ValorInteresParcial = ValorInteres;  //16/07/2025
                                                if (Interes > ValorInteres)
                                                {
                                                    ValorInteresParcial = Interes;
                                                }


                                                int MesesAtrasados = 0;
                                                if (Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) > 0)
                                                {
                                                    if (Convert.ToDecimal(row["Importe"].ToString()) > 0)  // ImporteConBeca
                                                        if (DateTime.Now.Year > Vto.Year)
                                                        {
                                                            MesesAtrasados = GetMonthDifference(Vto.Date, DateTime.Now.Date); //(DateTime.Now.Date - Vto.Date).Days / (365.25 / 12);
                                                        }
                                                        else
                                                        {
                                                            //MesesAtrasados = MesesAtrasados + DateTime.Now.Date.Month - Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString());
                                                            MesesAtrasados = MesesAtrasados + (DateTime.Now.Date.Month - (Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString()) - 1)) - Convert.ToInt32(Convert.ToInt32(row["NroCuota"].ToString()));
                                                        }
                                                }
                                                Single InteresMensualaPagar = (((Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) * MesesAtrasados) / 100) * (Convert.ToSingle(dt5.Rows[0]["ConImporte"].ToString()) + ValorInteres));

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
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                }
                                                else
                                                {
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                }
                                                //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["BecasInteres"] = row["BecasInteres"].ToString();
                                                //ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["ImporteTotal"] = ImporteTotal;


                                                dt.Rows.Add(row1);
                                                Bandera = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else //seleccionó Año Lectivo
                {
                    dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(Convert.ToInt32(lblaluId.Text), Convert.ToInt32(txtAnioLectivo.Text));
                    if (dt3.Rows.Count > 0)
                    {
                        icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                        ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                        Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

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
                                                ValorInteresParcial = ValorInteres;  //16/07/2025
                                                if (Interes > ValorInteres)
                                                {
                                                    ValorInteresParcial = Interes;
                                                }

                                                int MesesAtrasados = 0;
                                                if (Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) > 0)
                                                {
                                                    if (Convert.ToDecimal(row["Importe"].ToString()) > 0)  // ImporteConBeca
                                                        if (DateTime.Now.Year > Vto.Year)
                                                        {
                                                            MesesAtrasados = GetMonthDifference(Vto.Date, DateTime.Now.Date); //(DateTime.Now.Date - Vto.Date).Days / (365.25 / 12);
                                                        }
                                                        else
                                                        {
                                                            //MesesAtrasados = MesesAtrasados + DateTime.Now.Date.Month - Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString());
                                                            MesesAtrasados = MesesAtrasados + (DateTime.Now.Date.Month - (Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString()) - 1)) - Convert.ToInt32(Convert.ToInt32(row["NroCuota"].ToString()));
                                                        }
                                                }
                                                Single InteresMensualaPagar = (((Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) * MesesAtrasados) / 100) * (Convert.ToSingle(dt5.Rows[0]["ConImporte"].ToString()) + ValorInteres));
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
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                }
                                                else
                                                {
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                }
                                                //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["BecasInteres"] = row["BecasInteres"].ToString();
                                                //ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
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
                            //lblPagado.Visible = false;
                            //lblVencido.Visible = false;
                            //txtcELESTE.Visible = false;
                            //txtRojo.Visible = false;
                            //lblCuotas.Visible = false;
                            //TexCuotas.Visible = false;
                            //lblInt.Visible = false;
                            txtTot.Visible = false;
                            lblTot.Visible = false;
                            txtIntereses.Visible = false;
                            //btnFacturar.Visible = false;
                            alerError2.Visible = true;
                            lblError2.Text = "No se encontraron registros en ese año lectivo..";
                            return;
                        }
                    }
                    else
                    {
                        DataTable dt8 = new DataTable();
                        this.GrillaHistorial.DataSource = dt8;
                        this.GrillaHistorial.PageIndex = PageIndex;
                        this.GrillaHistorial.DataBind();
                        //lblPagado.Visible = false;
                        //lblVencido.Visible = false;
                        //txtcELESTE.Visible = false;
                        //txtRojo.Visible = false;
                        //btnFacturar.Visible = false;
                        //lblCuotas.Visible = false;
                        //TexCuotas.Visible = false;
                        //lblInt.Visible = false;
                        txtTot.Visible = false;
                        lblTot.Visible = false;
                        txtIntereses.Visible = false;
                        if (lblaluId.Text == "")
                        {
                            alerError2.Visible = true;
                            lblError2.Text = "Debe buscar y seleccionar un alumno";

                        }
                        else
                        {
                            alerError2.Visible = true;
                            lblError2.Text = "No se encontró registro";
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
                            //((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;

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


                            //DateTime FechaPago;
                            //DataTable dt9 = new DataTable();
                            //string dateString = Convert.ToString(DateTime.Now);

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
                                                            InteresTotal = ValorInteresRA + InteresAplicar;
                                                            fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                        }
                                                        else
                                                        {
                                                            InteresCuotaAsignar = ValorInteresCI;
                                                            RecargoAbiertoAsignar = ValorInteresRA;
                                                            InteresMensualAsignar = InteresAplicar;
                                                            InteresTotal = ValorInteresCI + ValorInteresRA;
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
                                                            InteresTotal = ValorInteresRA + InteresAplicar;
                                                            fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                        }
                                                        else
                                                        {
                                                            InteresCuotaAsignar = ValorInteresCI;
                                                            RecargoAbiertoAsignar = ValorInteresRA;
                                                            InteresMensualAsignar = InteresAplicar;
                                                            InteresTotal = ValorInteresCI + ValorInteresRA;
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
                                                            InteresTotal = ValorInteresRA + InteresAplicar;
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
                                                            InteresTotal = ValorInteresCI + ValorInteresRA;
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
                //lblPagado.Visible = true;
                //lblVencido.Visible = true;
                //txtcELESTE.Visible = true;
                //txtRojo.Visible = true;
                //btnFacturar.Visible = true;
                //lblCuotas.Visible = true;
                //TexCuotas.Visible = true;
                //lblInt.Visible = true;
                //txtIntereses.Visible = true;
                txtTot.Visible = true;
                lblTot.Visible = true;

            } // cheked en true 
            else
            {
                if (txtAnioLectivo.Text == "") //traigo historial del alumno
                {
                    dt3 = ocnInscripcionCursado.ObtenerTodoporaluId(Convert.ToInt32(lblaluId.Text));// obtengo todos los cursos del alumno

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
                                                //dt.Rows.Add(row1);
                                            }

                                            else //Concepto no pagado
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
                                                ValorInteresParcial = ValorInteres;  //16/07/2025
                                                if (Interes > ValorInteres)
                                                {
                                                    ValorInteresParcial = Interes;
                                                }


                                                int MesesAtrasados = 0;
                                                if (Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) > 0)
                                                {
                                                    if (Convert.ToDecimal(row["Importe"].ToString()) > 0)  // ImporteConBeca
                                                        if (DateTime.Now.Year > Vto.Year)
                                                        {
                                                            MesesAtrasados = GetMonthDifference(Vto.Date, DateTime.Now.Date); //(DateTime.Now.Date - Vto.Date).Days / (365.25 / 12);
                                                        }
                                                        else
                                                        {
                                                            //MesesAtrasados = MesesAtrasados + DateTime.Now.Date.Month - Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString());
                                                            MesesAtrasados = MesesAtrasados + (DateTime.Now.Date.Month - (Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString()) - 1)) - Convert.ToInt32(Convert.ToInt32(row["NroCuota"].ToString()));
                                                        }
                                                }
                                                Single InteresMensualaPagar = (((Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) * MesesAtrasados) / 100) * (Convert.ToSingle(dt5.Rows[0]["ConImporte"].ToString()) + ValorInteres));
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
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                }
                                                else
                                                {
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                }
                                                //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["BecasInteres"] = row["BecasInteres"].ToString();
                                                //ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["ImporteTotal"] = ImporteTotal;

                                                dt.Rows.Add(row1);
                                                Bandera = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else //seleccionó Año Lectivo
                {
                    dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(Convert.ToInt32(lblaluId.Text), Convert.ToInt32(txtAnioLectivo.Text));
                    if (dt3.Rows.Count > 0)
                    {
                        icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                        ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                        Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

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
                                                //dt.Rows.Add(row1);
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

                                                float ValorInteresParcial = 0;
                                                ValorInteresParcial = ValorInteres;  //16/07/2025
                                                if (Interes > ValorInteres)
                                                {
                                                    ValorInteresParcial = Interes;
                                                }


                                                int MesesAtrasados = 0;
                                                if (Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) > 0)
                                                {
                                                    if (Convert.ToDecimal(row["Importe"].ToString()) > 0)  // ImporteConBeca
                                                        if (DateTime.Now.Year > Vto.Year)
                                                        {
                                                            MesesAtrasados = GetMonthDifference(Vto.Date, DateTime.Now.Date); //(DateTime.Now.Date - Vto.Date).Days / (365.25 / 12);
                                                        }
                                                        else
                                                        {
                                                            //MesesAtrasados = MesesAtrasados + DateTime.Now.Date.Month - Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString());
                                                            MesesAtrasados = MesesAtrasados + (DateTime.Now.Date.Month - (Convert.ToInt32(dt5.Rows[0]["ConMesInicio"].ToString()) - 1)) - Convert.ToInt32(Convert.ToInt32(row["NroCuota"].ToString()));
                                                        }
                                                }
                                                Single InteresMensualaPagar = (((Convert.ToSingle(dt5.Rows[0]["ConInteresMensual"].ToString()) * MesesAtrasados) / 100) * (Convert.ToSingle(dt5.Rows[0]["ConImporte"].ToString()) + ValorInteres));

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
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                }
                                                else
                                                {
                                                    row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                    ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial));
                                                }
                                                //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
                                                row1["BecasInteres"] = row["BecasInteres"].ToString();
                                                //ImporteTotal = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado)) + Convert.ToDecimal(string.Format("{0:0.00}", ValorInteresParcial + ValorInteres));
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
                            //lblPagado.Visible = false;
                            //lblVencido.Visible = false;
                            //txtcELESTE.Visible = false;
                            //txtRojo.Visible = false;
                            //lblCuotas.Visible = false;
                            //TexCuotas.Visible = false;
                            //lblInt.Visible = false;
                            txtTot.Visible = false;
                            lblTot.Visible = false;
                            txtIntereses.Visible = false;
                            //btnFacturar.Visible = false;
                            alerError2.Visible = true;
                            lblError2.Text = "No se encontraron registros en ese año lectivo..";
                            return;
                        }
                    }
                    else
                    {
                        DataTable dt8 = new DataTable();
                        this.GrillaHistorial.DataSource = dt8;
                        this.GrillaHistorial.PageIndex = PageIndex;
                        this.GrillaHistorial.DataBind();
                        //lblPagado.Visible = false;
                        //lblVencido.Visible = false;
                        //txtcELESTE.Visible = false;
                        //txtRojo.Visible = false;
                        //btnFacturar.Visible = false;
                        //lblCuotas.Visible = false;
                        //TexCuotas.Visible = false;
                        //lblInt.Visible = false;
                        txtTot.Visible = false;
                        lblTot.Visible = false;
                        txtIntereses.Visible = false;
                        if (lblaluId.Text == "")
                        {
                            alerError2.Visible = true;
                            lblMjerror2.Text = "Debe buscar y seleccionar un alumno";

                        }
                        else
                        {
                            alerError2.Visible = true;
                            lblError2.Text = "No se encontró registro";
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
                        if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0 || Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecId"]) == 13)
                        {
                            row.BackColor = System.Drawing.Color.LightBlue;
                            CuotaUltPagada = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                            //((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;

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


                            //DateTime FechaPago;
                            //DataTable dt9 = new DataTable();
                            //string dateString = Convert.ToString(DateTime.Now);

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
                                                            InteresTotal = ValorInteresRA + InteresAplicar;
                                                            fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                        }
                                                        else
                                                        {
                                                            InteresCuotaAsignar = ValorInteresCI;
                                                            RecargoAbiertoAsignar = ValorInteresRA;
                                                            InteresMensualAsignar = InteresAplicar;
                                                            InteresTotal = ValorInteresCI + ValorInteresRA;
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
                                                            InteresTotal = ValorInteresRA + InteresAplicar;
                                                            fchVtoAsignar = Convert.ToDateTime(UltVto);
                                                        }
                                                        else
                                                        {
                                                            InteresCuotaAsignar = ValorInteresCI;
                                                            RecargoAbiertoAsignar = ValorInteresRA;
                                                            InteresMensualAsignar = InteresAplicar;
                                                            InteresTotal = ValorInteresCI + ValorInteresRA;
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
                                                            InteresTotal = ValorInteresRA + InteresAplicar;
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
                                                            InteresTotal = ValorInteresCI + ValorInteresRA;
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
                //lblPagado.Visible = true;
                //lblVencido.Visible = true;
                //txtcELESTE.Visible = true;
                //txtRojo.Visible = true;
                //btnFacturar.Visible = true;
                //lblCuotas.Visible = true;
                //TexCuotas.Visible = true;
                //lblInt.Visible = true;
                //txtIntereses.Visible = true;
                txtTot.Visible = true;
                lblTot.Visible = true;
            }

            int BanderaRoja = 0;
            if (dt.Rows.Count != 0)
            {
                this.GrillaHistorial.DataSource = dt;
                this.GrillaHistorial.PageIndex = PageIndex;
                this.GrillaHistorial.DataBind();
                Session["UltimaCuota"] = 0;
                Session["Concepto"] = "";
                Session["FechaPago"] = "";

                DateTime Hoy = DateTime.Today;

                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
                    {
                        row.BackColor = System.Drawing.Color.LightBlue;
                        Session["UltimaCuota"] = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                        int CuotNro = 0;
                        CuotNro = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]) + 2;
                        string ultimomesañopago = "";
                        string anocursado = "";
                        Session["Concepto"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Concepto"]);
                        string FechaFormateada = Convert.ToString(Convert.ToDateTime((GrillaHistorial.DataKeys[row.RowIndex].Values["FechaPago"])).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " del " + Convert.ToDateTime((GrillaHistorial.DataKeys[row.RowIndex].Values["FechaPago"])).ToString("yyyy", new System.Globalization.CultureInfo("es-ES")));
                        if (FechaFormateada != "")
                        {
                            anocursado = GrillaHistorial.DataKeys[row.RowIndex].Values["AnioLectivo"].ToString();
                            ultimomesañopago = "01/" + Convert.ToString(CuotNro) + "/" + anocursado;
                            FechaFormateada = Convert.ToString(Convert.ToDateTime((ultimomesañopago)).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " del " + Convert.ToDateTime((ultimomesañopago)).ToString("yyyy", new System.Globalization.CultureInfo("es-ES")));
                        }
                        Session["FechaPago"] = FechaFormateada;

                        ((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                    }

                    else
                    {
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

                BtnLibreDeuda.Visible = true;
                //alerExito2.Visible = true;
                //lblExito2.Text = "El alumno no posee deuda para ese año.. Puede imprimir libre deuda..";
            }
            else
            {
                BtnLibreDeuda.Visible = false;
                //alerExito2.Visible = false;
                //alerError3.Visible = true;
                //lblError3.Text = "El alumno posee cuotas impagas.. no puede imprimir Libre Deuda..";
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

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        GrillaCargar(0);
    }
    //protected void btnImprimirClick(object sender, EventArgs e)
    //{
    //    DataTable dtImprimir = new DataTable();
    //    // Genera la misma tabla de datos que en GrillaCargar para imprimir
    //    // Esto es un ejemplo, deberías reutilizar la lógica de GrillaCargar para obtener dt
    //    dtImprimir = (DataTable)GrillaHistorial.DataSource;
    //    if (dtImprimir == null || dtImprimir.Rows.Count == 0)
    //    {
    //        lblMjerror2.Text = "No hay datos para imprimir.";
    //        alerError2.Visible = true;
    //        return;
    //    }

    //    GenerarPDF(dtImprimir);
    //}

    private void GenerarPDF(DataTable dataSource)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            // Título
            Paragraph title = new Paragraph("Estado de Cuenta - " + aluNombre.Text, new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            document.Add(new Paragraph(" ")); // Espacio

            // Datos del Alumno
            document.Add(new Paragraph("Alumno: " + aluNombre.Text + " (DNI: " + aludni.Text + ")", new Font(Font.FontFamily.HELVETICA, 12)));
            document.Add(new Paragraph("Año Lectivo: " + txtAnioLectivo.Text, new Font(Font.FontFamily.HELVETICA, 12)));
            document.Add(new Paragraph("Fecha de Emisión: " + DateTime.Now.ToShortDateString(), new Font(Font.FontFamily.HELVETICA, 12)));
            document.Add(new Paragraph(" ")); // Espacio

            // Tabla de la grilla
            PdfPTable table = new PdfPTable(4); // Ajusta el número de columnas según las que quieras mostrar en el PDF
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 3f, 1.5f, 1.5f, 1.5f }); // Anchos relativos de las columnas

            // Encabezados de la tabla
            table.AddCell(new PdfPCell(new Phrase("Concepto", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Importe", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Fecha Vto.", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Estado", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });


            foreach (DataRow row in dataSource.Rows)
            {
                table.AddCell(new PdfPCell(new Phrase(row["Concepto"].ToString(), new Font(Font.FontFamily.HELVETICA, 9))) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase(string.Format("{0:C}", Convert.ToDecimal(row["Importe"])), new Font(Font.FontFamily.HELVETICA, 9))) { HorizontalAlignment = Element.ALIGN_RIGHT });

                DateTime fechaVto;
                if (DateTime.TryParse(row["FechaVto"].ToString(), out fechaVto))
                {
                    table.AddCell(new PdfPCell(new Phrase(fechaVto.ToShortDateString(), new Font(Font.FontFamily.HELVETICA, 9))) { HorizontalAlignment = Element.ALIGN_CENTER });
                }
                else
                {
                    table.AddCell(new PdfPCell(new Phrase("", new Font(Font.FontFamily.HELVETICA, 9))) { HorizontalAlignment = Element.ALIGN_CENTER });
                }

                // Lógica para el estado en el PDF (replica la de la grilla si es posible)
                string estado = "";
                decimal impPagado = Convert.ToDecimal(row["ImpPagado"]);
                DateTime fechaVtoRow = Convert.ToDateTime(row["FechaVto"]);

                if (impPagado > 0)
                {
                    estado = "Pagado";
                }
                else if (fechaVtoRow < DateTime.Today)
                {
                    estado = "Vencido";
                }
                else
                {
                    estado = "Pendiente";
                }
                table.AddCell(new PdfPCell(new Phrase(estado, new Font(Font.FontFamily.HELVETICA, 9))) { HorizontalAlignment = Element.ALIGN_CENTER });
            }
            document.Add(table);
            document.Add(new Paragraph(" ")); // Espacio

            // Totales (si los quieres añadir al PDF)
            if (lblTot.Visible && !string.IsNullOrEmpty(txtTot.Text))
            {
                document.Add(new Paragraph("Total Adeudado: " + txtTot.Text, new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
            }
            if (lblCuotas.Visible && !string.IsNullOrEmpty(TexCuotas.Text))
            {
                document.Add(new Paragraph("Total Cuotas Vencidas: " + TexCuotas.Text, new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
            }
            if (lblInt.Visible && !string.IsNullOrEmpty(txtIntereses.Text))
            {
                document.Add(new Paragraph("Total Intereses: " + txtIntereses.Text, new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
            }


            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=EstadoDeCuenta_" + aluNombre.Text.Replace(" ", "_") + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
    }
    protected void btnImprimirClickLD_Click(object sender, EventArgs e)
    {
        try
        {

            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            int aniocursado = Convert.ToInt32(txtAnioLectivo.Text);
            int aluId = Convert.ToInt32(lblaluId.Text);
            int mes = Convert.ToInt32(Session["UltimaCuota"]) + 2;
            String Concepto = Convert.ToString(Session["Concepto"]);
            String mesPago = Convert.ToString(Session["FechaPago"]);

            int InstId = Convert.ToInt32(this.Session["_Institucion"]);
            int UsuId = Convert.ToInt32(this.Session["_usuId"]);
            int IdLDP = 0;
            String DNIUSUARIO = Convert.ToString(Session["_usuNombreIngreso"].ToString());
            dt = ocnLibreDeudaQR.InformeLibreDeudaQR(aluId, mes, InstId);

            if (dt.Rows.Count > 0)
            {
                ocnLibreDeudaQR.InsertarSinoExiste(aluId, aluNombre.Text, aludni.Text, Convert.ToString(dt.Rows[0]["Curso"].ToString()), Convert.ToString(dt.Rows[0]["insNombre"].ToString()), Convert.ToString(dt.Rows[0]["Mes"].ToString()),
                    aniocursado, DateTime.Now, Concepto, mesPago);


                string Imagenes, ImageLogo;
                NomRep = "~/PaginasGenerales/LD/LibreDeuda.pdf";
                string Ruta = MapPath(NomRep);  //System.Web.UI.Page.Server.MapPath(NomRep);
                NomRep = Ruta;
                Document doc = new Document(PageSize.A4, 30f, 10f, 10f, 10f);

                //PdfWriter.GetInstance(documento, new FileStream("Mi_Primer_PDF.pdf", FileMode.OpenOrCreate));
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(NomRep, FileMode.Create));
                Imagenes = "~/images/LogoChico.jpg";
                ImageLogo = MapPath(Imagenes);

                doc.Open();

                //DrawThickLine(writer, 36f, 519f, 806f, 519f);//Horizontal Line
                iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(MapPath(Imagenes));
                image1.ScalePercent(50f);
                image1.ScaleAbsoluteWidth(60);
                image1.ScaleAbsoluteHeight(60);
                doc.Add(image1);

                PdfPTable tblLogo = new PdfPTable(1) { HorizontalAlignment = Element.ALIGN_LEFT };
                tblLogo.SetWidths(new float[] { 3f });
                PdfPTable tblEncabeza = new PdfPTable(6) { HorizontalAlignment = Element.ALIGN_LEFT, WidthPercentage = 100 };
                tblEncabeza.SetWidths(new float[] { 4f, 23f, 4f, 23f, 4f, 42f });  //2603222
                tblEncabeza.DefaultCell.Border = 0;
                image1.Alignment = Element.ALIGN_LEFT;
                PdfPCell imageCell = new PdfPCell(image1);
                imageCell.BorderWidth = 0;
                tblLogo.AddCell(imageCell);
                tblEncabeza.AddCell(tblLogo);
                //Le agregamos un segundo párrafo
                //doc.Add(tblLogo);
                doc.Add(tblEncabeza);
                Paragraph parrafoChi = new Paragraph();
                parrafoChi.Font = FontFactory.GetFont(FontFactory.TIMES, 9f, Font.BOLD);
                doc.Add(new Paragraph("Obra Misericordista", parrafoChi.Font));

                Paragraph title = new Paragraph();
                title.Font = FontFactory.GetFont(FontFactory.TIMES, 14f, Font.BOLD | Font.UNDERLINE);

                title.Add("");
                //title.Alignment(Element.ALIGN_RIGHT);

                Paragraph parrafo = new Paragraph("CERTIFICADO DE LIBRE DEUDA ", title.Font);

                parrafo.Alignment = (Element.ALIGN_CENTER);
                parrafo.Font = FontFactory.GetFont(FontFactory.TIMES, 12f);

                Paragraph parrafoBold = new Paragraph("CERTIFICADO DE LIBRE DEUDA ", title.Font);

                parrafoBold.Alignment = (Element.ALIGN_CENTER);
                parrafoBold.Font = FontFactory.GetFont(FontFactory.TIMES, 12f, Font.BOLD);
                //doc.Add(Chunk.NEWLINE);
                Paragraph Parrafo10 = new Paragraph();
                Parrafo10.Add(" ");
                Paragraph Parrafo51 = new Paragraph();
                Parrafo51.Add(" ");
                Paragraph Parrafo1 = new Paragraph("El alumno/a: " + Convert.ToString(dt.Rows[0]["Alumno"].ToString()), parrafo.Font);
                Paragraph Parrafo101 = new Paragraph("DNI: " + DNIUSUARIO, parrafo.Font);
                Paragraph Parrafo11 = new Paragraph();
                Paragraph Parrafo2 = new Paragraph("Curso:  " + Convert.ToString(dt.Rows[0]["Curso"].ToString()), parrafo.Font);
                Paragraph Parrafo3 = new Paragraph("Institución:  " + Convert.ToString(dt.Rows[0]["insNombre"].ToString()), parrafo.Font);
                Paragraph Parrafo31 = new Paragraph("Concepto:  " + Concepto, parrafo.Font);

                Paragraph Parrafo4 = new Paragraph("Canceló los aranceles hasta:  " + mesPago, parrafoBold.Font);

                Paragraph Parrafo5 = new Paragraph("Se extiende la presente en la ciudad de Santiago del Estero, " + Convert.ToString(DateTime.Now), parrafo.Font);

                doc.Add(parrafo);
                doc.Add(Parrafo10);
                doc.Add(Parrafo1);
                doc.Add(Parrafo101);
                doc.Add(Parrafo11);
                doc.Add(Parrafo2);
                doc.Add(Parrafo3);
                doc.Add(Parrafo31);
                doc.Add(Parrafo4);
                doc.Add(Parrafo5);
                //BarcodeQRCode qrcode = new BarcodeQRCode("https://obramisericordista.com.ar/PaginasGenerales/VerificarLD.aspx?insId="+Convert.ToString(insId)+"&aniocursado="+ txtAnioLectivo.Text + "&aluId=" + Convert.ToString(aluId)+ "&mes=" + Convert.ToString(mes), 1, 1, null);
                //BarcodeQRCode qrcode = new BarcodeQRCode("https://localhost:51680/PaginasBasicas/LDVerificar.aspx?insId=" + insId + "&aniocursado=" + aniocursado + "&aluId=" + aluId + "&mes=" + mes +"&Concepto=" + Concepto +"&MesPago=" + mesPago, 1, 1, null);

                BarcodeQRCode qrcode = new BarcodeQRCode("https://obramisericordista.com.ar/PaginasBasicas/LDVerificar.aspx?insId=" + insId + "&aniocursado=" + aniocursado + "&aluId=" + aluId + "&mes=" + mes + "&Concepto=" + Concepto + "&MesPago=" + mesPago, 1, 1, null);

                iTextSharp.text.Image barCode = qrcode.GetImage();
                //barCode.SetAbsolutePosition(300, 500);
                barCode.ScalePercent(150);
                barCode.Alignment = Element.ALIGN_CENTER;
                doc.Add(barCode);
                //DrawThickLine(writer, 36f, 519f, 556f, 519f);//Horizontal Line
                doc.Close();
                Response.Redirect("../PaginasGenerales/LD/LibreDeuda.pdf", false);



                //if (UsuId >= 2503 && UsuId <= 2507)
                //{
                //    NomRep = "LibreDeudaMarcela.rpt";
                //}
                //else
                //{
                //NomRep = "LibreDeuda.rpt";
                ////}


                //FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&aniocursado=" + aniocursado + "&aluId=" + aluId + "&mes=" + mes + "&NomRep=" + NomRep + barCode);
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

    //private void GenerarLibreDeudaPDF()
    //{
    //    // Verificar que no haya deuda pendiente
    //    DataTable dtDeudaPendiente = ocnTEMESTADOCUENTA.ObtenerTotalesAlumno(Convert.ToInt32(lblaluId.Text), Convert.ToInt32(txtAnioLectivo.Text), "2");
    //    if (dtDeudaPendiente.Rows.Count > 0 && Convert.ToDecimal(dtDeudaPendiente.Rows[0]["TotalAdeudado"]) > 0)
    //    {
    //        lblMjerror2.Text = "No se puede generar el Libre Deuda. El alumno tiene deuda pendiente.";
    //        alerError2.Visible = true;
    //        return;
    //    }

    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        Document document = new Document(PageSize.A4, 50, 50, 50, 50);
    //        PdfWriter writer = PdfWriter.GetInstance(document, ms);
    //        document.Open();

    //        // Título
    //        Paragraph title = new Paragraph("CERTIFICADO DE LIBRE DEUDA", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLUE));
    //        title.Alignment = Element.ALIGN_CENTER;
    //        document.Add(title);
    //        document.Add(new Paragraph("\n")); // Espacio

    //        // Contenido del certificado
    //        string alumnoNombre = aluNombre.Text;
    //        string alumnoDNI = aludni.Text;
    //        string institucion = "Nombre de la Institución"; // Reemplaza con el nombre real de tu institución
    //        string fechaEmision = DateTime.Now.ToLongDateString();

    //        Paragraph content = new Paragraph();
    //        content.Add(new Chunk("Por medio de la presente, la institución ", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Add(new Chunk(institucion, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
    //        content.Add(new Chunk(", certifica que el/la alumno/a ", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Add(new Chunk(alumnoNombre, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
    //        content.Add(new Chunk(", con DNI N° ", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Add(new Chunk(alumnoDNI, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
    //        content.Add(new Chunk(", no registra deudas pendientes de ningún tipo con nuestra institución hasta la fecha de emisión de este certificado (", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Add(new Chunk(fechaEmision, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
    //        content.Add(new Chunk(").\n\n", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Add(new Chunk("Este certificado se extiende a solicitud del interesado para los fines que estime convenientes.\n\n", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Add(new Chunk("Sin otro particular, saludamos a usted atentamente.", new Font(Font.FontFamily.HELVETICA, 12)));
    //        content.Alignment = Element.ALIGN_JUSTIFIED;
    //        document.Add(content);

    //        document.Add(new Paragraph("\n\n")); // Espacio

    //        // Firma
    //        Paragraph signature = new Paragraph("_____________________________\n", new Font(Font.FontFamily.HELVETICA, 12));
    //        signature.Add(new Chunk("Firma y Sello de la Autoridad\n", new Font(Font.FontFamily.HELVETICA, 10)));
    //        signature.Alignment = Element.ALIGN_CENTER;
    //        document.Add(signature);

    //        // Código QR
    //        string qrData = string.Format("Alumno: {0}, DNI: {1}, Estado: Libre de Deuda, Fecha: {2}, Institucion: {3}", alumnoNombre, alumnoDNI, fechaEmision, institucion);
    //        BarcodeQRCode qrcode = new BarcodeQRCode(qrData, 100, 100, null);
    //        Image qrImage = qrcode.GetImage();
    //        qrImage.Alignment = Element.ALIGN_CENTER;
    //        document.Add(qrImage);

    //        document.Close();

    //        Response.ContentType = "application/pdf";
    //        Response.AddHeader("content-disposition", "attachment;filename=LibreDeuda_" + aluNombre.Text.Replace(" ", "_") + ".pdf");
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        Response.BinaryWrite(ms.ToArray());
    //        Response.End();
    //    }
    //}


    protected void ckbDeuda_CheckedChanged(object sender, EventArgs e)
    {
        GrillaCargar(0);
    }

    private int GetMonthDifference(DateTime start, DateTime end)
    {
        return Math.Abs((end.Year - start.Year) * 12 + end.Month - start.Month);
    }
    protected void GrillaHistorial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Este método se activa con los botones dentro de la grilla.
        // No debería interferir con el clic de la fila para abrir el modal.
    }
    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../PaginasBasicas/InicioPadres.aspx", true);
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
    protected void btnFacturarClick(object sender, EventArgs e)
    {
        //    string idsConceptos = "";
        //    decimal totalAPagar = 0;
        //    decimal totalIntereses = 0;
        //    decimal totalImpuestos = 0;
        //    string concepto = "";
        //    int cantidadItems = 0;

        //    foreach (GridViewRow row in GrillaHistorial.Rows)
        //    {
        //        CheckBox chk = (CheckBox)row.FindControl("chkSeleccion");
        //        if (chk != null && chk.Checked)
        //        {
        //            // Solo procesar si el estado no es "Pagado"
        //            Label lblEstado = (Label)row.FindControl("lblEstado");
        //            if (lblEstado != null && lblEstado.Text != "Pagado")
        //            {
        //                int conId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["conId"]);
        //                int icoId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["icoId"]);
        //                decimal importe = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["Importe"]);
        //                decimal interes = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImporteInteres"]);

        //                idsConceptos += string.Format("{0},{1},{2},{3}|", icoId, conId, importe, interes); // Formato: icoId,conId,importe,interes|
        //                totalAPagar += importe;
        //                totalIntereses += interes;
        //                concepto = GrillaHistorial.DataKeys[row.RowIndex].Values["Concepto"].ToString();
        //                cantidadItems++;
        //            }
        //        }
        //    }

        //    if (idsConceptos.Length > 0)
        //    {
        //        idsConceptos = idsConceptos.TrimEnd('|');

        //        // Guarda los datos en la sesión para la página de pago
        //        Session["_idsConceptosAPagar"] = idsConceptos;
        //        Session["_totalAPagar"] = totalAPagar;
        //        Session["_totalIntereses"] = totalIntereses;
        //        Session["_conceptoPago"] = concepto;
        //        Session["_cantidadItemsPago"] = cantidadItems;
        //        Session["_aluIdPago"] = lblaluId.Text; // ID del alumno
        //        Session["_aluNombrePago"] = hfNombreAlumno.Value; // Nombre del alumno

        //        Session.Add("TablaPagar", dt);

        //        Response.Redirect("FacturacionPadres.aspx?Id=" + lblaluId.Text, false);
        //    }
        //    else
        //    {
        //        lblMensajeError.Text = "<div class=\"alert alert-warning\">No se seleccionaron conceptos para pagar o los conceptos seleccionados ya están pagados.</div>";
        //    }

        try
        {
            //alerError2.Visible = false;
            //alerError.Visible = false;
            //alerExito.Visible = false;

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
                //Response.Redirect("Facturacion.aspx?Id=" + icuId2, false);
                Response.Redirect("FacturacionPadres.aspx?Id=" + lblaluId.Text, false);
            }
            else
            {
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);

                GrillaCargar(PageIndex);
                //GrillaBuscar.DataSource = null;
                //GrillaBuscar.DataBind();
                alerError2.Visible = true;
                lblError2.Text = "Debe seleccionar al menos un item a pagar..";
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