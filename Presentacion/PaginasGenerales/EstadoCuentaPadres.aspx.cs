
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
    GESTIONESCOLAR.Negocio.ComprobantesFormasPago ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.PagosCheques ocnPagosCheques = new GESTIONESCOLAR.Negocio.PagosCheques();
    GESTIONESCOLAR.Negocio.PagosTarjetas ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas();
    GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica();
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
                btnImprimir2.Visible = false;
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
                    if (aludni.Text == "48481957")
                    {
                        btnFacturar.Visible = true;
                    }

                    aludni.Enabled = false;
                    lblaluId.Text = Convert.ToString(dt.Rows[0]["Id"].ToString());

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

    private void GrillaCargar(int PageIndex)
    {
        DataTable dtAlumno = new DataTable();
        String DNIUSUARIO = Convert.ToString(Session["_usuNombreIngreso"].ToString());
        dtAlumno = ocnAlumno.ObtenerUnoporDoc(DNIUSUARIO);
        if (dtAlumno.Rows.Count > 0)
        {
          String NombreAlumno = dtAlumno.Rows[0]["Nombre"].ToString();
            //int usuario = Convert.ToInt32(Session["_usuId"].ToString());
            //dt = ocnFamiliar.ObtenerUnoxUsuId(usuario);
            //if (dt.Rows.Count != 0)
            //{
            //    this.Master.TituloDelFormulario = "Bienvenido/a Sr/a: " + dt.Rows[0][1].ToString() + "." +
            // " En esta sección encontrará información academica del menor a cargo. ";

            //}
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
                                                //if (Interes > ValorInteres)
                                                //{
                                                //    ValorInteres = Interes;
                                                //}
                                                //row1["ImporteInteres"] = Convert.ToDecimal(string.Format("{0:0.00}", ValorInteres));
                                                float ValorInteresParcial = ValorInteres;

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
                        CuotNro = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"])+2;
                        string ultimomesañopago = "";
                        string anocursado = "";
                        Session["Concepto"] = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Concepto"]);
                        string FechaFormateada = Convert.ToString (Convert.ToDateTime((GrillaHistorial.DataKeys[row.RowIndex].Values["FechaPago"])).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " del " + Convert.ToDateTime((GrillaHistorial.DataKeys[row.RowIndex].Values["FechaPago"])).ToString("yyyy", new System.Globalization.CultureInfo("es-ES")));
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


    public static int GetMonthDifference(DateTime startDate, DateTime endDate)
    {
        int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        return Math.Abs(monthsApart);
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //AlumnoSeleccionado.Visible = false;
        //alerErroBE.Visible = false;
        //int PageIndex = 0;
        //PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
        //if (TextBuscar.Text != "")
        //{
        //    if (Convert.ToInt32(Session["Bandera"]) == 0)
        //    {
        //        dt = ocnAlumno.ObtenerTodoBuscarxNombre(TextBuscar.Text.Trim());
        //        if (dt.Rows.Count > 0)
        //        {

        //            this.Grilla.DataSource = dt;
        //            this.Grilla.PageIndex = PageIndex;
        //            this.Grilla.DataBind();
        //            this.GrillaHistorial.DataSource = null;
        //            this.GrillaHistorial.PageIndex = PageIndex;
        //            this.GrillaHistorial.DataBind();

        //        }
        //        else
        //        {
        //            alerErroBE.Visible = true;
        //            lblalerErroBE.Text = "No se encuentra Alumno con ese Filtro";
        //            this.GrillaHistorial.DataSource = null;
        //            this.GrillaHistorial.PageIndex = PageIndex;
        //            this.GrillaHistorial.DataBind();

        //        }
        //    }
        //    else
        //    {
        //        dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
        //        if (dt.Rows.Count > 0)
        //        {
        //            CanReg.Visible = true;
        //            lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
        //            this.Grilla.DataSource = dt;
        //            this.Grilla.PageIndex = PageIndex;
        //            this.Grilla.DataBind();
        //            this.GrillaHistorial.DataSource = null;
        //            this.GrillaHistorial.PageIndex = PageIndex;
        //            this.GrillaHistorial.DataBind();
        //        }
        //        else
        //        {
        //            alerErroBE.Visible = true;
        //            lblalerErroBE.Text = "No se encuentra Alumno con ese Filtro";
        //            this.GrillaHistorial.DataSource = null;
        //            this.GrillaHistorial.PageIndex = PageIndex;
        //            this.GrillaHistorial.DataBind();
        //        }
        //    }

        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    AlumnoSeleccionado.Visible = true;
        //    //    aluNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"]);
        //    //    aluNombre.Enabled = false;
        //    //    aludni.Text = Convert.ToString(dt.Rows[0]["Doc"]);
        //    //    aludni.Enabled = false;

        //    //    PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
        //    //    String Id = Convert.ToString(dt.Rows[0]["Id"]);
        //    //    lblaluId.Text = Id;
        //    //    GrillaCargar(PageIndex);
        //    //}
        //    //else
        //    //{
        //    //    alerErroBE.Visible = true;
        //    //    lblalerErroBE.Text = "No se encuentra Alumno con ese Filtro";
        //    //}
        //}
        //else
        //{
        //    alerErroBE.Visible = true;
        //    lblalerErroBE.Text = "Debe ingresar DNI del Alumno";
        //}
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

    protected void GrillaHistorial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            lblMensajeError.Text = ""; // Limpiar mensaje de error al inicio de cada comando

            // Manejar Paginación y Ordenamiento primero para evitar el parseo de CommandArgument
            if (e.CommandName == "Sort" || e.CommandName == "Page")
            {
                return;
            }

            int conId = -1; // Inicializar con un valor que indique que no se ha encontrado.
            int rowIndex = -1; // Inicializar para el comando "Select"

            if (e.CommandName == "Pagar" || e.CommandName == "VerDetalle")
            {
                // Para estos comandos, el CommandArgument ya es el conId.
                conId = Convert.ToInt32(e.CommandArgument);
            }
            else if (e.CommandName == "Select")
            {
                // Para el comando "Select" (clic en la fila), el CommandArgument es el rowIndex.
                if (!int.TryParse(Convert.ToString(e.CommandArgument), out rowIndex))
                {
                    if (rowIndex >= 0 && rowIndex < GrillaHistorial.DataKeys.Count)
                    {
                        conId = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["conId"]);
                    }
                    else
                    {
                        lblMensajeError.Text = string.Format("<div class=\"alert alert-danger\">Error: Índice de fila inválido para el comando Select. Índice: {0}</div>", rowIndex);
                        alerError2.Visible = true;
                        return;
                    }
                }
                else
                {
                    lblMensajeError.Text = "<div class=\"alert alert-danger\">Error: Argumento de comando Select inválido.</div>";
                    alerError2.Visible = true;
                    return;
                }
            }
            else
            {
                // Otros comandos desconocidos o no manejados.
                lblMensajeError.Text = "<div class=\"alert alert-warning\">Comando desconocido o no procesado.</div>";
                alerError2.Visible = true;
                return;
            }

            // Si conId es -1, significa que no se pudo obtener un ID válido para el comando.
            if (conId == -1)
            {
                lblMensajeError.Text = "<div class=\"alert alert-danger\">Error: No se pudo obtener el ID del concepto para el comando.</div>";
                alerError2.Visible = true;
                return;
            }

            // Ahora, manejar la lógica basada en el CommandName
            if (e.CommandName == "Pagar")
            {
                DataTable dt = new DataTable();
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

                // Para el comando "Pagar", el e.CommandArgument *ya es* el conId.
                // Debemos encontrar la fila en el DataSource si necesitamos más datos de la fila.
                DataRowView dataRowView = ((DataView)GrillaHistorial.DataSource).Cast<DataRowView>()
                    .FirstOrDefault(dr => Convert.ToInt32(dr["conId"]) == conId);

                if (dataRowView != null)
                {
                    int AnioCursado = Convert.ToInt32(dataRowView["AnioLectivo"]);

                    // Asegúrate de que insId y lblaluId.Text están disponibles en tu página.
                    // Reemplaza 'insId' y 'lblaluId.Text' con tus variables reales.
                    // Ejemplo: int insId = (int)Session["_Institucion"];
                    //          int aluId = Convert.ToInt32(lblaluId.Text);

                    // Asumo que ocnInscripcionCursado es una instancia de tu clase de negocio
                    // Si icuId2 es una variable de nivel de clase o de página, asegúrate de que esté declarada.
                    // int icuId2; // Declarar si no está globalmente accesible

                    // Llamada a tu lógica de negocio
                    // DataTable dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCursado, aluId);
                    // Si la línea de arriba es tu código real, asegúrate de que ocnInscripcionCursado está instanciado.
                    // Y que dt3.Rows[0]["Id"] existe.

                    // Temporalmente, para que compile sin tus objetos de negocio:
                    int icuId2 = 0; // Valor de ejemplo
                                    // Si usas tu código real, descomenta y usa el dt3:
                                    // if (dt3 != null && dt3.Rows.Count > 0)
                                    // {
                                    //     icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                    // } else {
                                    //    lblMensajeError.Text = "<div class=\"alert alert-danger\">Error: No se encontró inscripción de cursado.</div>";
                                    //    alerError2.Visible = true;
                                    //    return;
                                    // }


                    DataRow row1 = dt.NewRow();
                    row1["icuId"] = icuId2; // Usar el valor obtenido o mockeado
                    row1["icoId"] = Convert.ToInt32(dataRowView["icoId"]);
                    row1["cntId"] = Convert.ToInt32(dataRowView["cntId"]);
                    row1["conId"] = Convert.ToInt32(dataRowView["conId"]);
                    row1["TipoConcepto"] = Convert.ToString(dataRowView["TipoConcepto"]);
                    row1["Concepto"] = Convert.ToString(dataRowView["Concepto"]);
                    row1["Importe"] = Convert.ToDecimal(dataRowView["Importe"]);
                    row1["AnioLectivo"] = Convert.ToInt32(dataRowView["AnioLectivo"]);
                    row1["Beca"] = Convert.ToString(dataRowView["Beca"]);
                    row1["BecId"] = Convert.ToInt32(dataRowView["BecId"]);
                    row1["NroCuota"] = Convert.ToInt32(dataRowView["NroCuota"]);
                    row1["FchInscripcion"] = Convert.ToString(dataRowView["FchInscripcion"]);
                    dt.Rows.Add(row1);

                    Session.Add("TablaPagar", dt);

                    Response.Redirect(string.Format("FacturarCupones.aspx?Id={0}", icuId2), false);
                }
                else
                {
                    lblMensajeError.Text = string.Format("<div class=\"alert alert-danger\">Error: Concepto con ID {0} no encontrado en la grilla para Pagar.</div>", conId);
                    alerError2.Visible = true;
                    return;
                }
            }
            else if (e.CommandName == "VerDetalle")
            {
                // El JavaScript del cliente ya debería haber abierto el modal
                // Puedes agregar aquí lógica de servidor si es estrictamente necesaria
                // (ej. auditoría, cargar detalles complejos vía AJAX si no se usan data-*)
                // System.Diagnostics.Debug.WriteLine(string.Format("Botón Ver Detalle clickeado para conId: {0}", conId));
            }
            else if (e.CommandName == "Select")
            {
                // Este es el comando que se dispara cuando se hace clic en la fila completa.
                // El JavaScript del cliente ya debería haber abierto el modal.
                // Puedes usar este bloque para depuración o para registrar la selección en el servidor.
                // System.Diagnostics.Debug.WriteLine(string.Format("Fila seleccionada en servidor, conId: {0}", conId));
            }
        }
        catch (Exception oError)
        {
            // Reemplazamos la cadena interpolada del mensaje de error
            string innerExceptionMessage = oError.InnerException != null ? oError.InnerException.Message : "N/A";
            lblMensajeError.Text = string.Format(@"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>{0}<br><br>EXCEPTION:<br>{1}<br><br>TRACE:<br>{2}<br><br>TARGET:<br>{3}
</div>",
                oError.Message,
                innerExceptionMessage,
                oError.StackTrace,
                oError.TargetSite);
            alerError2.Visible = true;
        }
    }


    protected void GrillaHistorial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Style.Add("cursor", "pointer");

            DataRowView dr = (DataRowView)e.Row.DataItem;

            // Inyecta los atributos data-* para el modal (tal como lo teníamos)
            e.Row.Attributes["data-concepto"] = dr["Concepto"] != DBNull.Value ? dr["Concepto"].ToString() : "";
            e.Row.Attributes["data-importe"] = dr["Importe"] != DBNull.Value ? string.Format("{0:C}", dr["Importe"]) : "";
            e.Row.Attributes["data-intereses"] = dr["ImporteInteres"] != DBNull.Value ? string.Format("{0:C}", dr["ImporteInteres"]) : "";
            e.Row.Attributes["data-importeTotal"] = dr["ImporteTotal"] != DBNull.Value ? string.Format("{0:C}", dr["ImporteTotal"]) : "";
            e.Row.Attributes["data-beca"] = dr["Beca"] != DBNull.Value ? dr["Beca"].ToString() : "";
            e.Row.Attributes["data-nrocuota"] = dr["NroCuota"] != DBNull.Value ? dr["NroCuota"].ToString() : "";
            e.Row.Attributes["data-fechavto"] = dr["FechaVto"] != DBNull.Value ? string.Format("{0:d}", dr["FechaVto"]) : "";
            e.Row.Attributes["data-dcto"] = dr["Dcto"] != DBNull.Value ? string.Format("{0:C}", dr["Dcto"]) : "";
            e.Row.Attributes["data-imppagado"] = dr["ImpPagado"] != DBNull.Value ? string.Format("{0:C}", dr["ImpPagado"]) : "";
            e.Row.Attributes["data-fechapago"] = dr["FechaPago"] != DBNull.Value ? string.Format("{0:d}", dr["FechaPago"]) : "N/A";
            e.Row.Attributes["data-colegio"] = dr["Colegio"] != DBNull.Value ? dr["Colegio"].ToString() : "";
            e.Row.Attributes["data-curso"] = dr["Curso"] != DBNull.Value ? dr["Curso"].ToString() : "";
            e.Row.Attributes["data-conId"] = dr["conId"] != DBNull.Value ? dr["conId"].ToString() : "";
      e.Row.Attributes["data-FP"] = dr["FP"] != DBNull.Value ? dr["FP"].ToString() : "";
            // --- Lógica para la nueva columna "Estado" ---
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            if (lblEstado != null)
            {
                decimal impPagado = dr["ImpPagado"] != DBNull.Value ? Convert.ToDecimal(dr["ImpPagado"]) : 0m;
                decimal importeTotal = dr["ImporteTotal"] != DBNull.Value ? Convert.ToDecimal(dr["ImporteTotal"]) : 0m;
                DateTime fechaVto = dr["FechaVto"] != DBNull.Value ? Convert.ToDateTime(dr["FechaVto"]) : DateTime.MinValue; // Usar un valor por defecto si es nulo

                DateTime fechaActual = DateTime.Today; // Obtener la fecha actual sin la parte de la hora

                if (impPagado > 0m && impPagado >= importeTotal) // Si el importe pagado es mayor que cero y cubre el total
                {
                    lblEstado.Text = "Pagada";
                    lblEstado.CssClass = "text-success font-weight-bold"; // Opcional: estilo para "Pagada"
                }
                else if (impPagado == 0m && fechaVto != DateTime.MinValue && fechaVto < fechaActual) // Si no está pagado y la fecha de vencimiento ya pasó
                {
                    lblEstado.Text = "Vencida";
                    lblEstado.CssClass = "text-danger font-weight-bold"; // Opcional: estilo para "Vencida"
                }
                else
                {
                    lblEstado.Text = ""; // Vacío (o podrías poner "Pendiente" si lo prefieres)
                                         // lblEstado.Text = "Pendiente";
                                         // lblEstado.CssClass = "text-info"; // Opcional: estilo para "Pendiente"
                }
            }
        }
    }
    //    protected void GrillaHistorial_RowCommand(object sender, GridViewCommandEventArgs e)
    //    {
    //        try
    //        {
    //            alerError2.Visible = false;

    //            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
    //            {
    //                int rowIndex = int.Parse(e.CommandArgument.ToString());
    //                int val = (int)this.GrillaHistorial.DataKeys[rowIndex]["icoId"];
    //                //string Id = ((HyperLink)GrillaHistorial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
    //                if (e.CommandName == "Pagar")
    //                {

    //                    alerError2.Visible = false;


    //                    //insId = Convert.ToInt32(Session["_Institucion"]);
    //                    lblMensajeError.Text = "";

    //                    DataTable dt = new DataTable();
    //                    DataTable dt9 = new DataTable();
    //                    DataTable dt4 = new DataTable();
    //                    DataTable dt3 = new DataTable();
    //                    DataTable dt1 = new DataTable();
    //                    dt.Columns.Add("icuId", typeof(int));
    //                    dt.Columns.Add("icoId", typeof(int));
    //                    dt.Columns.Add("cntId", typeof(int));
    //                    dt.Columns.Add("conId", typeof(Int32));
    //                    dt.Columns.Add("TipoConcepto", typeof(String));
    //                    dt.Columns.Add("Concepto", typeof(String));
    //                    dt.Columns.Add("Importe", typeof(Decimal));
    //                    dt.Columns.Add("AnioLectivo", typeof(Decimal));
    //                    dt.Columns.Add("Beca", typeof(String));
    //                    dt.Columns.Add("BecId", typeof(Int32));
    //                    dt.Columns.Add("NroCuota", typeof(Int32));
    //                    dt.Columns.Add("FchInscripcion", typeof(String));

    //                    String FchaInscripcionCon;
    //                    Int32 NroCuotaCon;
    //                    Int32 bcaIdCon;
    //                    Int32 AnioCursado;

    //                    AnioCursado = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["AnioLectivo"]);
    //                    //insId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["InsId"]);
    //                    dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCursado, Convert.ToInt32(lblaluId.Text));
    //                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
    //                    //FchaInscripcionCon = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FchInscripcion"]);
    //                    //NroCuotaCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
    //                    //bcaIdCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecasId"]);
    //                    DataRow row1 = dt.NewRow();
    //                    row1["icuId"] = icuId2;

    //                    row1["icoId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["icoId"]);
    //                    row1["cntId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["cntId"]);
    //                    row1["conId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["conId"]);
    //                    row1["TipoConcepto"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["TipoConcepto"]);
    //                    row1["Concepto"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["Concepto"]);
    //                    row1["Importe"] = Convert.ToDecimal(this.GrillaHistorial.DataKeys[rowIndex]["Importe"]);
    //                    row1["AnioLectivo"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["AnioLectivo"]);
    //                    row1["Beca"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["Beca"]);
    //                    row1["BecId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["BecId"]);
    //                    row1["NroCuota"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["NroCuota"]);

    //                    row1["FchInscripcion"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["FchInscripcion"]);
    //                    dt.Rows.Add(row1);

    //                    Session.Add("TablaPagar", dt);
    //                }
    //                Response.Redirect("FacturarCupones.aspx?Id=" + icuId2, false);
    //            }
    //            else
    //            {
    //                alerError2.Visible = true;
    //                lblError2.Text = "Debe seleccionar un items a facturar";
    //            }
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //    "</div>";
    //        }
    //    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        //foreach (GridViewRow row in Grilla.Rows)
        //{
        //    if (row.RowType == DataControlRowType.DataRow)
        //    {
        //        row.Attributes["onmouseover"] = "this.style.background = '#0BB8A1'; this.style.cursor = 'pointer'";
        //        row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
        //        row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(Grilla, "Select$" + row.RowIndex, true);
        //    }
        //}

        base.Render(writer);
    }

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }


    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["EstadoCuenta.PageIndex"] != null)
            {
                Session["EstadoCuenta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("EstadoCuenta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar2(e.NewPageIndex);
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




    private void GrillaCargar2(int PageIndex)
    {
        try
        {


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
                    aniocursado, DateTime.Now, Concepto,mesPago);


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

                Paragraph Parrafo4 = new Paragraph("Canceló los aranceles hasta:  " + mesPago , parrafoBold.Font);

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


    private static void DrawThickLine(PdfWriter writer, float x1, float y1, float x2, float y2)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetLineWidth(1.0f);   // Make a bit thicker than 1.0 default
        contentByte.SetColorStroke(BaseColor.BLACK);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }

    protected void btnImprimirClick(object sender, EventArgs e)
    {
        ocnTEMESTADOCUENTA.EliminarTodo();
        int Id = 0;
        int InstId = Convert.ToInt32(this.Session["_Institucion"]);
        DateTime Hoy = DateTime.Today;
        foreach (GridViewRow row in GrillaHistorial.Rows)
        {
            if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < Hoy && Convert.ToSingle(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) == 0 && Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecId"]) != 14)
            {
                ocnTEMESTADOCUENTA = new GESTIONESCOLAR.Negocio.TEMESTADOCUENTA(Convert.ToInt32(Id));
                ocnTEMESTADOCUENTA.tecConcepto = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Concepto"]);
                ocnTEMESTADOCUENTA.tecNumCuota = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                ocnTEMESTADOCUENTA.tecImporte = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["Importe"]);
                ocnTEMESTADOCUENTA.tecColegio = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Colegio"]);
                ocnTEMESTADOCUENTA.tecCurso = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Curso"]);
                ocnTEMESTADOCUENTA.tecImpPagado = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]);
                ocnTEMESTADOCUENTA.tecFchPago = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaPago"]);
                ocnTEMESTADOCUENTA.tecImpInteres = Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImporteInteres"]);
                ocnTEMESTADOCUENTA.tecBeca = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["Beca"]);

                ocnTEMESTADOCUENTA.tecFechaVto = Hoy;
                ocnTEMESTADOCUENTA.tecLugarPago = "";
                ocnTEMESTADOCUENTA.tecFormaPago = "";
                ocnTEMESTADOCUENTA.tecTotalCuotasImpagas = 0;
                ocnTEMESTADOCUENTA.tecTotalInteres = 0;
                ocnTEMESTADOCUENTA.tecTotalDeudaalaFecha = 0;

                ocnTEMESTADOCUENTA.Insertar();
            }
        }

        foreach (GridViewRow row in GrillaHistorial.Rows)
        {
            if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
            {
                row.BackColor = System.Drawing.Color.LightBlue;
                //CuotaUltPagada = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                //((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
            }

            else
            {
                if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < DateTime.Today)
                {
                    row.BackColor = System.Drawing.Color.FromName("#B81822");
                    row.ForeColor = System.Drawing.Color.White;
                    //btnFacturar.Visible = true;
                    //txtFchPago.Visible = true;
                    //lblFchPago.Visible = true;
                    btnImprimir2.Visible = true;
                    //lblCuotas.Visible = true;
                    //TexCuotas.Visible = true;
                    //lblInt.Visible = true;
                    //txtIntereses.Visible = true;
                    //txtTot.Visible = true;
                    //lblTot.Visible = true;
                    //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                    //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;

                }
            }
        }
        String NomRep;
        String ParamStr1 = aluNombre.Text;
        if (InstId == 121)
        {
            NomRep = "EstadoDeCuentaNew.rpt";
        }
        else
        {
            NomRep = "EstadoCuenta.rpt";

        }

        FuncionesUtiles.AbreVentana("Reporte.aspx?ParamStr1=" + ParamStr1 + "&NomRep=" + NomRep);
    }

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                //String Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                //if (e.CommandName == "Select")
                //{
                //    aluNombre.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                //    aluNombre.Enabled = false;
                //    aludni.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                //    aludni.Enabled = false;
                //    aluId.Text = Id;
                //    //CanReg.Visible = false;
                //    Grilla.DataSource = null;
                //    Grilla.DataBind();
                //    AlumnoSeleccionado.Visible = true;
                //    int PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);

                //    lblaluId.Text = Id;
                //    GrillaCargar(PageIndex);
                //    //Grilla.Text = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Controls[1]).Text;

                //}
            }
            if (e.CommandName != "Page")
            {

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



    protected void ckbDeuda_CheckedChanged(object sender, EventArgs e)
    {
        //if (AlumnoSeleccionado.Visible == true)
        //{
        int PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
        GrillaCargar(PageIndex);
        //}
        //else
        //{

        //}
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int PageIndex = Convert.ToInt32(Session["EstadoCuenta.PageIndex"]);
        GrillaCargar(PageIndex);
    }

    protected void btnFacturarClick(object sender, EventArgs e)
    {
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
                Response.Redirect("FacturacionPadres.aspx?Id=" + icuId2, false);
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


