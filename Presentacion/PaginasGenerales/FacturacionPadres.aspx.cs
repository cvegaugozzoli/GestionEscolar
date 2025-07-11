using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Net;


public partial class FacturacionPadres : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.Docentes ocnDocentes = new GESTIONESCOLAR.Negocio.Docentes();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();
    GESTIONESCOLAR.Negocio.ComprobantesPtosVta ocnComprobantesPtosVta = new GESTIONESCOLAR.Negocio.ComprobantesPtosVta();
    GESTIONESCOLAR.Negocio.ComprobantesFormasPago ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago();
    GESTIONESCOLAR.Negocio.Tarjetas ocnTarjetas = new GESTIONESCOLAR.Negocio.Tarjetas();
    GESTIONESCOLAR.Negocio.LugaresPago ocnLugaresPago = new GESTIONESCOLAR.Negocio.LugaresPago();
    GESTIONESCOLAR.Negocio.Bancos ocnBancos = new GESTIONESCOLAR.Negocio.Bancos();
    GESTIONESCOLAR.Negocio.FormasPago ocnFormasPago = new GESTIONESCOLAR.Negocio.FormasPago();
    GESTIONESCOLAR.Negocio.TarjetasPlanes ocnTarjetasPlanes = new GESTIONESCOLAR.Negocio.TarjetasPlanes();
    GESTIONESCOLAR.Negocio.PagosTarjetas ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas();
    GESTIONESCOLAR.Negocio.PagosCheques ocnPagosCheques = new GESTIONESCOLAR.Negocio.PagosCheques();
    GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.IntencionPagos ocnIntencionPagos = new GESTIONESCOLAR.Negocio.IntencionPagos();


    int cfoIdNuevo;
    DataTable dt9 = new DataTable();
    int valor;
    int cantCuotasPlan;
    int insId;
    private static bool isActive;
    string bearerToken = "";
    string IdReferenciaOperacion = "";
    string IdResultado = "";
    string hash = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                ///
                IdReferenciaOperacion = Request.QueryString["IdReferenciaOperacion"];
                IdResultado = Request.QueryString["IdResultado"];
                //string token = bearerToken; // Reemplazar con tu token real

                if (!string.IsNullOrEmpty(IdReferenciaOperacion) && !string.IsNullOrEmpty(IdResultado))
                {
                    //Label4.Text = "IdReferenciaOperacion: " + IdReferenciaOperacion + " Fin";
                    //Label5.Text = "IdResultado: " + IdResultado + " Fin";

                    string hash_ = "";
                    string bearerToken_ = "";


                    string idRO_aluid = IdReferenciaOperacion.Substring(50, 50);
                    // Quitamos los ceros a la izquierda de la segunda parte
                    idRO_aluid = idRO_aluid.TrimStart('0');

                    //Label7.Text = " Hash devuelto: ";

                    dt = new DataTable();
                    dt = ocnIntencionPagos.ObtenerTodoBuscarxVarios(IdReferenciaOperacion, Convert.ToInt32(idRO_aluid));
                    if (dt.Rows.Count > 0)
                    {
                        hash_ = dt.Rows[0]["inp_hash"].ToString();
                        //Label7.Text = " Luego de buscar y encontrar.. ";
                        //Label8.Text = "bearerToken_ " + dt.Rows[0]["inp_bearerToken"].ToString();
                        bearerToken_ = dt.Rows[0]["inp_bearerToken"].ToString();
                        CargarDatosAlumnoyPago(Convert.ToInt32(dt.Rows[0]["aluid"].ToString()));
                        GrillaCargar(Convert.ToInt32(dt.Rows[0]["aluid"].ToString()));                   
                    }
                    string json = ConsultarEstadoPago(hash_, IdResultado, bearerToken_);
                    if (json != "")
                    {
                        // Deserializar JSON a diccionario
                        var serializer = new JavaScriptSerializer();
                        var datos = serializer.Deserialize<Dictionary<string, object>>(json);

                        // Acceder a cada campo
                        bool pagoExitoso = Convert.ToBoolean(datos["PagoExitoso"]);
                        string estado = datos["Estado"].ToString();
                        string mensaje = "";
                        string fecha = "";
                        string idOperacion = "";
                        string refOperacion = "";
                        if (estado == "PROCESADA")
                        {
                            lblTotal.Text = lblSubTotal.Text;
                            mensaje = datos["MensajeResultado"].ToString();
                            fecha = datos["FechaOperacion"].ToString();
                            idOperacion = datos["IdOperacion"].ToString();
                            refOperacion = datos["idReferenciaOperacion"].ToString();
                            estado = "La operación fue " + estado + " correctamente!";
                            btnGrabar();
                            btnPagar.Enabled = false;
                        }
                        else
                        {
                            if (estado == "CANCELADA")
                            {
                                estado = "La operación fue " + estado + " por el Usuario!";
                            }
                            else
                            {
                                if (estado == "ERROR")
                                {
                                    estado = "Se produjo un " + estado + " al intentar realizar la operación! Reintente!";
                                }
                                else
                                {
                                    if (estado == "RECHAZADA")
                                    {
                                        estado = "La operación fue " + estado + " al intentar realizar la operación! Reintente!";
                                    }
                                    else
                                    {
                                        if (estado == "REGISTRADA")
                                        {
                                            estado = "La operación fue " + estado + " pero no se completó completamente!";
                                        }
                                    }
                                }
                            }
                        }
                        // Mostrar en pantalla
                        Label8.Text = "<b>Resultado del Pago:</b><br/>" +
                                          //"Pago Exitoso: " + pagoExitoso + "<br/>" +
                                          "Mensaje: " + mensaje + "<br/>" +
                                          //"Fecha: " + fecha + "<br/>" +
                                          "Estado: " + estado + "<br/>";
                                          //"Id Operación: " + idOperacion + "<br/>" +
                                          //"Referencia: " + refOperacion;
                    }

                }
                else
                {

                    this.ViewState["paginaorigen"] = Request.UrlReferrer.ToString();
                    lblicuId.Text = Convert.ToString(Request.QueryString["Id"]);
                    if (lblicuId.Text.Trim() != "")
                    {
                        CargarDatosAlumnoyPago(Convert.ToInt32(lblicuId.Text.Trim().ToString()));
                        GrillaCargar(Convert.ToInt32(lblicuId.Text.Trim().ToString()));
                    }
                }

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["FacturacionPadres.PageIndex"] == null)
                {
                    Session.Add("FacturacionPadres.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["FacturacionPadres.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]
                #endregion

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

    private void CargarDatosAlumnoyPago(int IC)
    {
        this.ViewState["paginaorigen"] = Request.UrlReferrer.ToString();
        this.Master.TituloDelFormulario = " Pago de Aranceles";
        lblSubTotal.Text = "0";
        lblTotal.Text = "0";
        lblcocId.Text = "";
        lblinst.Text = "";
        //int IC = Convert.ToInt32(Request.QueryString["Id"]);
        //lblicuId.Text = Convert.ToString(Request.QueryString["Id"]);
        DataTable dt2 = new DataTable();

        dt2 = ocnInscripcionCursado.ObtenerUno(IC);
        if (dt2.Rows.Count > 0)
        {
            //lblInstitucion.Text = dt2.Rows[0]["InstNombre"].ToString();
            lblNombre.Text = dt2.Rows[0]["Alumno"].ToString();
            lblDni.Text = dt2.Rows[0]["DNI"].ToString();
            lblaluid.Text = dt2.Rows[0]["AluId"].ToString();
            lblinst.Text = dt2.Rows[0]["Inst"].ToString();
            insId = Convert.ToInt32(lblinst.Text);
            //lblDireccion.Text = dt.Rows[0]["Domicilio"].ToString();
            DateTime fechaActual = DateTime.Today;
            /*txtAnioLectivo.Text = fechaActual.Year.ToString()*/

            //lblCurso.Text = dt2.Rows[0]["Curso"].ToString();
            //lblanioLectivo.Text = dt2.Rows[0]["AnoCursado"].ToString();
            //lblTutor.Text = dt2.Rows[0]["TutorApe"].ToString() + "  " + "" + dt2.Rows[0]["TutorNombre"].ToString();
        }
        CompTipoId.DataValueField = "Valor"; CompTipoId.DataTextField = "Texto"; CompTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesTipos()).ObtenerListaxInst("[Seleccionar...]", insId); CompTipoId.DataBind();
        CompTipoId.SelectedValue = "1";
        //TarjetaId.DataValueField = "Valor"; TarjetaId.DataTextField = "Texto"; TarjetaId.DataSource = (new GESTIONESCOLAR.Negocio.Tarjetas()).ObtenerLista("[Seleccionar...]"); TarjetaId.DataBind();
        //BancoId.DataValueField = "Valor"; BancoId.DataTextField = "Texto"; BancoId.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); BancoId.DataBind();

        //Banco2Id.DataValueField = "Valor"; Banco2Id.DataTextField = "Texto"; Banco2Id.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); Banco2Id.DataBind();

        DestinoId.DataValueField = "Valor"; DestinoId.DataTextField = "Texto"; DestinoId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesDestinos()).ObtenerLista("[Seleccionar...]"); DestinoId.DataBind();
        DestinoId.SelectedValue = "1";
        //LugarPagoId.DataValueField = "Valor"; LugarPagoId.DataTextField = "Texto"; LugarPagoId.DataSource = (new GESTIONESCOLAR.Negocio.LugaresPago()).ObtenerLista("[Seleccionar...]"); LugarPagoId.DataBind();
        //LugarPagoId.SelectedValue = "1";
        //FchPago.Text = DateTime.Today;
        DataTable dt = new DataTable();
        dt.Columns.Add("IdLP", typeof(Int32));
        dt.Columns.Add("IdFP", typeof(Int32));
        dt.Columns.Add("FormaPago", typeof(String));
        dt.Columns.Add("Importe", typeof(Decimal));
        dt.Columns.Add("FchPago", typeof(DateTime));
        dt.Columns.Add("TarjetaId", typeof(Int32));
        dt.Columns.Add("Tarjeta", typeof(String));
        dt.Columns.Add("NroCuota", typeof(Int32));
        dt.Columns.Add("NroCupon", typeof(String));
        dt.Columns.Add("ImporteCuota", typeof(Decimal));
        dt.Columns.Add("PlanTarj", typeof(String));
        dt.Columns.Add("Interes", typeof(String));
        dt.Columns.Add("TotalTarj", typeof(Decimal));
        dt.Columns.Add("IdPlanTarj", typeof(int));
        dt.Columns.Add("BancoId", typeof(Int32));
        dt.Columns.Add("Banco", typeof(String));
        dt.Columns.Add("NroCta", typeof(String));
        dt.Columns.Add("NroCheque", typeof(String));
        dt.Columns.Add("TotalFinal", typeof(Decimal));

        Session["Facturar"] = dt;

        dt9 = ocnComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest(insId, Convert.ToInt32(CompTipoId.SelectedValue), Convert.ToInt32(DestinoId.SelectedValue));
        lblCompTipo.Text = dt9.Rows[0]["ComprobantesTipos"].ToString();
        lblNroPtoVta.Text = dt9.Rows[0]["PtoVta"].ToString();
        lblcpvId.Text = dt9.Rows[0]["Id"].ToString();
        valor = Convert.ToInt32(dt9.Rows[0]["UltimoNro"].ToString());
        int NroCompr = valor + 1;
        lblUltimoNro.Text = string.Format("{0:00000000}", NroCompr);

        DateTime fecha = DateTime.Now;
        txtFechaPago.Text = fecha.ToShortDateString();

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



    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

 

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            if (GridConcepto.Rows.Count == 0)
            {
                Decimal txtInt = 0;
                insId = Convert.ToInt32(lblinst.Text);
                DataTable dt = new DataTable();
                dt.Columns.Add("icoId", typeof(int));
                dt.Columns.Add("conId", typeof(Int32));
                dt.Columns.Add("cntId", typeof(Int32));
                dt.Columns.Add("TipoConcepto", typeof(String));
                dt.Columns.Add("Concepto", typeof(String));
                dt.Columns.Add("Importe", typeof(Decimal));

                dt.Columns.Add("InteresCuota", typeof(Decimal));
                dt.Columns.Add("RecargoAbierto", typeof(Decimal));
                dt.Columns.Add("InteresMensual", typeof(Decimal));
                dt.Columns.Add("AnioLectivo", typeof(Decimal));
                dt.Columns.Add("Beca", typeof(String));
                dt.Columns.Add("BecId", typeof(Int32));
                dt.Columns.Add("NroCuota", typeof(Int32));
                dt.Columns.Add("FchInscripcion", typeof(String));
                dt.Columns.Add("FechaVto", typeof(String));
                dt.Columns.Add("Dcto", typeof(Decimal));
                dt.Columns.Add("InteresTotal", typeof(Decimal));
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();

                dt2 = Session["TablaPagar"] as DataTable;
                String FchaInscripcionCon;
                DateTime FechaPago;
                string dateString = Convert.ToString(txtFechaPago.Text);
                int NroCuotaCon;
                int bcaIdCon;
                FechaPago = DateTime.Parse(dateString);
                int Bandera = 0;
                decimal InteresCuotaAsignar = 0;
                decimal InteresMensualAsignar = 0;
                Decimal ValorInteres = 0;
                string AplicaInteres;
                decimal RecargoAbiertoAsignar = 0;
                decimal InteresTotal = 0;
                DateTime fchVtoAsignar = DateTime.Now;
                LblMjeGridConcepto.Text = "";

                foreach (DataRow row in dt2.Rows)
                {
                    int ValorSeleccionado;
                    //obtengo incripcionConepto 
                    dt9 = ocnInscripcionConcepto.ObtenerUno(Convert.ToInt32(row["icoId"].ToString()));
                    int conId = Convert.ToInt32(row["conId"].ToString());
                    dt3 = ocnConceptos.ObtenerUno(Convert.ToInt32(row["conId"].ToString()));
                    DateTime UltVto;
                    if (dt9.Rows.Count > 0) //Inscripcion Concepto Existe
                    {
                        FchaInscripcionCon = Convert.ToString(dt9.Rows[0]["FechaInscripcion"].ToString());
                        NroCuotaCon = Convert.ToInt32(dt9.Rows[0]["NroCuota"].ToString());

                        String BecaCon = Convert.ToString(dt9.Rows[0]["Becas"].ToString());

                        //Busco si hay Vencimiento
                        dt4 = ocnConceptosIntereses.ObtenerListaxconIdxNroCuota(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())), (Convert.ToInt32(row["NroCuota"].ToString())));

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
                                                ValorInteresCI = Math.Round((Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row4["ValorInteres"].ToString()) / 100
                                                    * Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) / 100), 2);
                                            }
                                            else
                                            {
                                                ValorInteresCI = Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row4["ValorInteres"].ToString()) / 100;
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

                            DataTable dt12 = ocnConceptosIntereses.ObtenerUltimoVencimiento(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())), (Convert.ToInt32(row["NroCuota"].ToString())));
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
                                                InteresMensualIM = ((Convert.ToDecimal(dt3.Rows[0]["InteresMensual"]) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;

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
                                                InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString()) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
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
                                                //InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString()) + ValorInteresCI) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100; ;

                                                InteresMensualIM = (Convert.ToDecimal(dt3.Rows[0]["conImporte"].ToString()) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
                                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);


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
                                                //InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString()) + ValorInteresCI) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100; ;

                                                InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString())) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100;

                                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);
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

                                            InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
                                            fchVtoAsignar = Convert.ToDateTime(UltVto);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    DataRow row1 = dt.NewRow();
                    row1["icoId"] = Convert.ToInt32(row["icoId"].ToString());
                    row1["conId"] = Convert.ToInt32(row["conId"].ToString());
                    row1["cntId"] = Convert.ToInt32(row["cntId"].ToString());
                    row1["TipoConcepto"] = Convert.ToString(row["TipoConcepto"].ToString());
                    row1["Concepto"] = Convert.ToString(row["Concepto"].ToString());
                    row1["Importe"] = Convert.ToDecimal(row["Importe"].ToString());
                    row1["InteresCuota"] = InteresCuotaAsignar;
                    row1["RecargoAbierto"] = RecargoAbiertoAsignar;
                    row1["InteresMensual"] = InteresMensualAsignar;
                    row1["AnioLectivo"] = Convert.ToInt32(row["AnioLectivo"].ToString());
                    row1["Beca"] = Convert.ToString(row["Beca"].ToString());
                    row1["BecId"] = Convert.ToInt32(row["BecId"].ToString());
                    row1["FchInscripcion"] = Convert.ToString(row["FchInscripcion"].ToString());
                    row1["FechaVto"] = Convert.ToString(fchVtoAsignar);
                    row1["NroCuota"] = Convert.ToInt32(row["NroCuota"].ToString());
                    row1["Dcto"] = 0;
                    row1["InteresTotal"] = InteresTotal;
                    dt.Rows.Add(row1);
                    Bandera = 1;

                    txtInt = txtInt + InteresMensualAsignar;
                }

                GridConcepto.DataSource = dt;
                GridConcepto.DataBind();
                Session["GrillaFinal"] = dt;


                if (dt.Rows.Count > 0)
                {
                    Decimal sumatoria = 0;// Saco TOTAL
                                          //Decimal ImporteBecado = 0;
                    Int32 BanderaBeca = 0;
                    foreach (DataRow row in dt.Rows)
                    {

                        sumatoria += (Convert.ToDecimal(row["Importe"].ToString())) + (Convert.ToDecimal(row["InteresTotal"].ToString()));

                    }

                    lblSubTotal.Text = Convert.ToString(sumatoria);
                    //lblSaldo.Text = Convert.ToString(sumatoria);
                }
            }
            else // aplica Dcto
            {

                if (isActive == true)
                {


                    DataTable dt = new DataTable();
                    dt.Columns.Add("icoId", typeof(Int32));
                    dt.Columns.Add("cntId", typeof(Int32));
                    dt.Columns.Add("conId", typeof(Int32));
                    dt.Columns.Add("TipoConcepto", typeof(String));
                    dt.Columns.Add("Concepto", typeof(String));
                    dt.Columns.Add("NroCuota", typeof(Int32));
                    dt.Columns.Add("Importe", typeof(Decimal));
                    dt.Columns.Add("FechaVto", typeof(String));
                    dt.Columns.Add("InteresCuota", typeof(Decimal));
                    dt.Columns.Add("RecargoAbierto", typeof(Decimal));
                    dt.Columns.Add("InteresMensual", typeof(Decimal));
                    dt.Columns.Add("Dcto", typeof(String));
                    dt.Columns.Add("InteresTotal", typeof(Decimal));
                    dt.Columns.Add("Beca", typeof(String));
                    dt.Columns.Add("BecId", typeof(Int32));

                    foreach (GridViewRow row in GridConcepto.Rows)
                    {
                        CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                        if ((check.Checked)) // Si esta seleccionado..
                        {
                            DataRow row1 = dt.NewRow();
                            row1["icoId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["icoId"]);
                            row1["cntId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["cntId"]);
                            row1["conId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["conId"]);
                            row1["TipoConcepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                            row1["Concepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["Concepto"]);
                            row1["NroCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["NroCuota"]);
                            row1["Beca"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["Beca"]);
                            row1["BecId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["BecId"]);
                            row1["Importe"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]);
                            row1["FechaVto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["FechaVto"]);
                            row1["InteresCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresCuota"]);
                            row1["RecargoAbierto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["RecargoAbierto"]);
                            row1["InteresMensual"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresMensual"]);
                            row1["Dcto"] = 0;
                            row1["InteresTotal"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresTotal"]); ;
                            dt.Rows.Add(row1);
                            //txtInt = txtInt + InteresMensualAsignar;
                        }
                        else
                        {
                            DataRow row1 = dt.NewRow();
                            row1["icoId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["icoId"]);
                            row1["cntId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["cntId"]);
                            row1["conId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["conId"]);
                            row1["TipoConcepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                            row1["Concepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["Concepto"]);
                            row1["NroCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["NroCuota"]);
                            row1["Importe"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]);
                            row1["FechaVto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["FechaVto"]);
                            row1["InteresCuota"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["InteresCuota"]);
                            row1["RecargoAbierto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["RecargoAbierto"]);
                            row1["InteresMensual"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresMensual"]);
                            row1["Dcto"] = 0;
                            row1["InteresTotal"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresTotal"]);
                            dt.Rows.Add(row1);
                        }
                    }

                    GridConcepto.DataSource = dt;
                    GridConcepto.DataBind();
                    Session["GrillaFinal"] = dt;


                    if (dt.Rows.Count > 0)
                    {
                        Decimal sumatoria = 0;// Saco TOTAL                                        
                        Int32 BanderaBeca = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            sumatoria += (Convert.ToDecimal(row["Importe"].ToString())) + (Convert.ToDecimal(row["InteresTotal"].ToString()));
                        }
                        lblSubTotal.Text = Convert.ToString(sumatoria);
                        //lblSaldo.Text = Convert.ToString(sumatoria);

                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("icoId", typeof(Int32));
                    dt.Columns.Add("cntId", typeof(Int32));
                    dt.Columns.Add("conId", typeof(Int32));
                    dt.Columns.Add("TipoConcepto", typeof(String));
                    dt.Columns.Add("Concepto", typeof(String));
                    dt.Columns.Add("NroCuota", typeof(Int32));
                    dt.Columns.Add("Importe", typeof(Decimal));
                    dt.Columns.Add("FechaVto", typeof(String));
                    dt.Columns.Add("InteresCuota", typeof(Decimal));
                    dt.Columns.Add("RecargoAbierto", typeof(Decimal));
                    dt.Columns.Add("InteresMensual", typeof(Decimal));
                    dt.Columns.Add("Dcto", typeof(String));
                    dt.Columns.Add("InteresTotal", typeof(Decimal));
                    dt.Columns.Add("Beca", typeof(String));
                    dt.Columns.Add("BecId", typeof(Int32));

                    foreach (GridViewRow row in GridConcepto.Rows)
                    {
                        CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                        if ((check.Checked)) // Si esta seleccionado..
                        {
                            DataRow row1 = dt.NewRow();
                            row1["icoId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["icoId"]);
                            row1["cntId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["cntId"]);
                            row1["conId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["conId"]);
                            row1["TipoConcepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                            row1["Concepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["Concepto"]);
                            row1["NroCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["NroCuota"]);
                            row1["Beca"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["Beca"]);
                            row1["BecId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["BecId"]);
                            row1["Importe"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]);
                            row1["FechaVto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["FechaVto"]);
                            row1["InteresCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresCuota"]);
                            row1["RecargoAbierto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["RecargoAbierto"]);
                            row1["InteresMensual"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresMensual"]);
                            row1["Dcto"] = 0;
                            row1["InteresTotal"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresTotal"]);
                            dt.Rows.Add(row1);
                            //txtInt = txtInt + InteresMensualAsignar;
                        }
                        else
                        {
                            DataRow row1 = dt.NewRow();
                            row1["icoId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["icoId"]);
                            row1["cntId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["cntId"]);
                            row1["conId"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["conId"]);
                            row1["TipoConcepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["TipoConcepto"]);
                            row1["Concepto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["Concepto"]);
                            row1["NroCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["NroCuota"]);
                            row1["Importe"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]);
                            row1["FechaVto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["FechaVto"]);
                            row1["InteresCuota"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["InteresCuota"]);
                            row1["RecargoAbierto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["RecargoAbierto"]);
                            row1["InteresMensual"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresMensual"]);
                            row1["Dcto"] = 0;
                            row1["InteresTotal"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresTotal"]);
                            dt.Rows.Add(row1);
                        }
                    }

                    GridConcepto.DataSource = dt;
                    GridConcepto.DataBind();
                    Session["GrillaFinal"] = dt;


                    if (dt.Rows.Count > 0)
                    {
                        Decimal sumatoria = 0;// Saco TOTAL                                        
                        Int32 BanderaBeca = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            sumatoria += (Convert.ToDecimal(row["Importe"].ToString())) + (Convert.ToDecimal(row["InteresTotal"].ToString()));
                        }
                        lblSubTotal.Text = Convert.ToString(sumatoria);
                        //lblSaldo.Text = Convert.ToString(sumatoria);

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


    protected void GridConcepto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)GridConcepto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //ocnBecas.Eliminar(Convert.ToInt32(Id));

                    GrillaCargar(this.GridConcepto.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {

                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("Facturacion.aspx?Id=" + Id + "&Ver=1", false);
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

    protected void GridConcepto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void GridConcepto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["Facturacion.PageIndex"] != null)
            {
                Session["Facturacion.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("Facturacion.PageIndex", e.NewPageIndex);
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    //protected void Grabar_Click(object sender, EventArgs e)
    //{
    //    btnGrabar();
    //}

    protected void btnGrabar()
    {
        try
        {
            DataTable dtGrillaFinal = Session["GrillaFinal"] as DataTable;

            if (dtGrillaFinal.Rows.Count == 1 & Convert.ToInt32(dtGrillaFinal.Rows[0]["Dcto"].ToString()) == 100 & Convert.ToDecimal(dtGrillaFinal.Rows[0]["InteresTotal"].ToString()) == 0)
            {
                int icoId_Actualizar = Convert.ToInt32(dtGrillaFinal.Rows[0]["icoId"].ToString());
                int DctO_Actualizar = Convert.ToInt32(dtGrillaFinal.Rows[0]["Dcto"].ToString());
                DateTime FechaHoraUltimaModificacion = DateTime.Now;
                int usuIdUltimaModificacion = this.Master.usuId;

                ocnInscripcionConcepto.ActualizarDcto(icoId_Actualizar, DctO_Actualizar, usuIdUltimaModificacion, FechaHoraUltimaModificacion);
            }
            else
            {
                insId = Convert.ToInt32(lblinst.Text);
                dt9 = ocnComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest(insId, Convert.ToInt32(CompTipoId.SelectedValue), Convert.ToInt32(DestinoId.SelectedValue));
                lblCompTipo.Text = dt9.Rows[0]["ComprobantesTipos"].ToString();
                //DataTable dt5 = new DataTable();
                //dt5 = Session["Facturar"] as DataTable;
                //dt5 = Session["GrillaFinal"] as DataTable;
                int LugPago = 4;
                Decimal ImportePagar2 = Convert.ToDecimal(lblTotal.Text.ToString());

              
                DateTime FechaHoraCreacion = DateTime.Now;
                DateTime FechaHoraUltimaModificacion = DateTime.Now;
                DateTime patFechaHoraCreacion = DateTime.Now;
                DateTime patFechaHoraUltimaModificacion = DateTime.Now;
                int usuIdCreacion = this.Master.usuId;
                int usuIdUltimaModificacion = this.Master.usuId;
                DataTable dt8 = new DataTable();
                dt8 = ocnComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest(Convert.ToInt32(insId), Convert.ToInt32(CompTipoId.SelectedValue), Convert.ToInt32(DestinoId.SelectedValue));
                valor = Convert.ToInt32(dt9.Rows[0]["UltimoNro"].ToString());
                int NroCompr = valor + 1;
                //lblUltimoNro.Text = string.Format("{0:00000000}", NroCompr);
                lblUltimoNro.Text = Convert.ToString(NroCompr);
                int compPtoVta = Convert.ToInt32(lblcpvId.Text);
                int cpvid = Convert.ToInt32(dt9.Rows[0]["Id"].ToString());

                //Insertar y Actualizar Tablas
                //Comprobante Cabecera
                //int cocIdNuevo = ocnComprobantesCabecera.InsertarTraerId(Convert.ToInt32(CompTipoId.SelectedValue), lblNroPtoVta.Text, lblUltimoNro.Text, Convert.ToDateTime(dt5.Rows[0]["FchPago"].ToString()), ImportePagar2, LugPago, "", true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                int cocIdNuevo = ocnComprobantesCabecera.InsertarTraerId(Convert.ToInt32(CompTipoId.SelectedValue), lblNroPtoVta.Text, lblUltimoNro.Text, Convert.ToDateTime(txtFechaPago.Text.ToString()), ImportePagar2, LugPago, "", true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                lblcocId.Text = Convert.ToString(cocIdNuevo);

                ocnComprobantesPtosVta.ActualizarUltimoNro(cpvid, NroCompr, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);

                //Comprobante Detalle
                DataTable dt4 = new DataTable();
                dt4 = Session["GrillaFinal"] as DataTable;

                foreach (DataRow row in dt4.Rows)
                {
                    if (Convert.ToDecimal(row["Dcto"].ToString()) == 100)
                    {
                        int icoId_Actualizar2 = Convert.ToInt32(row["icoId"].ToString());
                        int DctO_Actualizar2 = Convert.ToInt32(row["Dcto"].ToString());
                        DateTime FechaHoraUltimaModificacion2 = DateTime.Now;
                        int usuIdUltimaModificacion2 = this.Master.usuId;
                        ocnInscripcionConcepto.ActualizarDcto(icoId_Actualizar2, DctO_Actualizar2, usuIdUltimaModificacion2, FechaHoraUltimaModificacion2);
                    }
                    else
                    {
                        if (Convert.ToDecimal(row["Dcto"].ToString()) != 0)
                        {
                            int icoId_Actualizar3 = Convert.ToInt32(row["icoId"].ToString());
                            int DctO_Actualizar3 = Convert.ToInt32(row["Dcto"].ToString());
                            DateTime FechaHoraUltimaModificacion3 = DateTime.Now;
                            int usuIdUltimaModificacion3 = this.Master.usuId;
                            ocnInscripcionConcepto.ActualizarDcto(icoId_Actualizar3, DctO_Actualizar3, usuIdUltimaModificacion3, FechaHoraUltimaModificacion3);
                        }
                        int cdeIdNew = 0;
                        Decimal sumatoria = 0;
                        sumatoria = (Convert.ToDecimal(row["Importe"].ToString()) + (Convert.ToDecimal(row["InteresTotal"].ToString())));
                        cdeIdNew = ocnComprobantesDetalle.InsertarTraeId(cocIdNuevo, Convert.ToInt32(row["icoId"].ToString()), sumatoria, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);

                        //Forma Pago
                        //if (dt5.Rows.Count > 0)
                        //{
                        //    int FormPagoIn;
                        //    decimal ImpParcial;
                        //    foreach (DataRow row2 in dt5.Rows)
                        //    {
                        //        FormPagoIn = Convert.ToInt32(row2["IdFP"].ToString());

                        //        if (FormPagoIn == 1)
                        //        {
                        //            ImpParcial = sumatoria * porCont / 100;
                        //            cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        //        }
                        //        if (FormPagoIn == 2)
                        //        {
                        //            decimal ImpParcial2 = (sumatoria * porTarj / 100) / varTarj;
                        //            ImpParcial = ImpParcial2 + IntCuota;
                        //            cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        //            ocnPagosTarjetas.Insertar(cfoIdNuevo, Convert.ToInt32(row2["TarjetaId"].ToString()), Convert.ToInt32(row2["IdPlanTarj"].ToString()), Convert.ToDecimal(row2["Interes"].ToString()), Convert.ToDecimal(row2["ImporteCuota"].ToString()), Convert.ToInt32(row2["NroCuota"].ToString()), Convert.ToString(row2["NroCupon"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, patFechaHoraCreacion, patFechaHoraUltimaModificacion);
                        //        }
                        //        if (FormPagoIn == 3)
                        //        {
                        //            ImpParcial = (sumatoria * porcheque / 100) / conCheq;
                        //            cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        //            ocnPagosCheques.Insertar(cfoIdNuevo, ImpParcial, Convert.ToString(row2["NroCheque"].ToString()), Convert.ToInt32(row2["BancoId"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        //        }
                        //        if (FormPagoIn == 4)
                        //        {
                        //            ImpParcial = sumatoria * porTranf / 100;
                        //            cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        //            ocnPagosTransferenciaElectronica.Insertar(cfoIdNuevo, Convert.ToInt32(row2["Importe"].ToString()), Convert.ToString(row2["NroCta"].ToString()), Convert.ToInt32(row2["BancoId"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        //        }
                        //    }
                        //}
                    }
                }
                btnImprimir.Visible = true;
                btnImprimir.Enabled = true;
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






    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep;
            Int32 icuId = Int32.Parse(lblicuId.Text);
            Int32 cocId = Int32.Parse(lblcocId.Text);
            Int32 cocId2 = Int32.Parse(lblcocId.Text);
            Int32 cocId3 = Int32.Parse(lblcocId.Text);
            int InstId = Convert.ToInt32(this.Session["_Institucion"]);

            NomRep = "InformeFactura.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?icuId=" + icuId + "&cocId=" + cocId + "&cocId2=" + cocId2 + "&cocId3=" + cocId3 + "&NomRep=" + NomRep);
            //FuncionesUtiles.AbreVentana("Reporte.aspx?icuId=" + icuId + "&cocId=" + cocId + "&NomRep=" + NomRep);

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



    protected void btnGestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://obramisericordista.com.ar/PaginasGenerales/EstadoCuentaPadres.aspx", false);

    }

    protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
    {
        alerError2.Visible = false;
    }

    protected void btnPagar_Click(object sender, EventArgs e)
    {
        bearerToken = InicioSesion();
        if (!string.IsNullOrEmpty(bearerToken))
        {
            string resultado_Pago = RealizarPago(bearerToken);
            if (!string.IsNullOrEmpty(resultado_Pago))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var data = serializer.Deserialize<Dictionary<string, string>>(resultado_Pago);
                string urlPago = data["Url"];
                string hash = data["Hash"];
                //Label7.Text = hash;
                //Label6.Text = bearerToken;

                // Guardar en Session usando el IdReferenciaOperacion como clave
                //Session["Hash_" + payload.IdReferenciaOperacion] = hash;
                //Session["Hash__"] = hash;
                //Session["bearerToken__"] = bearerToken;

                int Id = 0;
                ocnIntencionPagos = new GESTIONESCOLAR.Negocio.IntencionPagos(Id);
                ocnIntencionPagos.Actualizar(Convert.ToInt32(lblicuId.Text.Trim().ToString()), bearerToken, hash, resultado_Pago);

                Response.Redirect(urlPago, false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }
        else
        {
            Response.Write("Error en el pago.");
        }
    }


    private string InicioSesion()
    {
        // Datos de prueba o reales del pago a generar
        string referencia = "5150058293"; // Identificador único del pago
        string cuit = "20233953270";             // CUIT del pagador o de la entidad que cobra

        // URL de prueba de ReqRes (no es SIRO)
        string baseUrl = "https://apisesionh.bancoroela.com.ar/auth/Sesion";

        string usuario = "UsuarioTestApi";       // Usuario de API (lo provee SIRO)
        string pass = "Hola123";             // Contraseña de API

        // Se arma el string de autenticación en formato Base64
        string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(usuario + ":" + pass));
        // Resultado típico: "Basic dXN1YXJpbzpwYXNzd29yZA=="

        // Se prepara el objeto con los datos a enviar a SIRO
        var payload = new
        {
            Usuario = usuario,       // reemplazá por tu usuario real
            Password = pass,     // reemplazá por tu contraseña real
            referencia = referencia,
            cuit = cuit
        };


        // Se convierte el objeto en un string JSON usando JavaScriptSerializer
        var jsonSerializer = new JavaScriptSerializer();
        string jsonPayload = jsonSerializer.Serialize(payload);

        // Se crea el objeto de solicitud HTTP hacia el endpoint de SIRO
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);
        request.Method = "POST";                        // Tipo de solicitud: POST
        request.ContentType = "application/json";       // Indica que el cuerpo será JSON
        request.Headers[HttpRequestHeader.Authorization] = "Basic " + auth; // Agrega autenticación

        // Se convierte el JSON a un arreglo de bytes para enviarlo
        byte[] data = Encoding.UTF8.GetBytes(jsonPayload);
        request.ContentLength = data.Length;

        // Se escribe el contenido JSON en el cuerpo de la solicitud
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(data, 0, data.Length);
        }

        try
        {
            // Se envía la solicitud y se obtiene la respuesta del servidor SIRO
            using (WebResponse response = request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();// Se lee todo el contenido de la respuesta

                // Se convierte el JSON de respuesta en un diccionario dinámico
                dynamic jsonResponse = jsonSerializer.Deserialize<dynamic>(responseText);

                // Si el JSON contiene la clave \"url_pago\", la retornamos
                if (jsonResponse.ContainsKey("access_token"))    //
                {
                    return jsonResponse["access_token"]; // URL del botón de pago para redirigir al usuario
                }
            }
        }
        catch (WebException ex)
        {
            // Si ocurre un error al hacer la solicitud (por ejemplo: credenciales incorrectas)
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                string error = reader.ReadToEnd();  // Leer el detalle del error devuelto por SIRO
                                                    // Podés loguearlo si querés: System.Diagnostics.Debug.WriteLine(error);
            }
        }
        return null;

    }


    private string RealizarPago(string bearerTokenOrigen)
    {
        string url = "https://siropagosh.bancoroela.com.ar/api/Pago";

        // Este token debe ser el que te entrega SIRO
        string bearerToken = bearerTokenOrigen;  //"Bearer " +
        Decimal ImporteTotal = Convert.ToDecimal(lblSubTotal.Text.Trim());

        DateTime ahora = DateTime.Now;
        string fechaHora = ahora.ToString("yyyyMMddHHmmss");
        long numero = long.Parse(fechaHora);

        String ReferenciaOperacion = ""; // numero.ToString();
        //String NroComprobante = "0000000" + lblNroPtoVta.Text + lblUltimoNro.Text;

        String NroComprobante = ahora.ToString("yyMMddHHmmss");       
        NroComprobante = long.Parse(NroComprobante).ToString();
        NroComprobante = NroComprobante + lblaluid.Text.Trim().ToString();
        NroComprobante = NroComprobante.PadLeft(20, '0');

        ReferenciaOperacion = long.Parse(ahora.ToString("yyyyMMddHHmmss")).ToString();
        ReferenciaOperacion = ReferenciaOperacion.PadLeft(50, '0');
        String aluid = lblaluid.Text.Trim().ToString().PadLeft(50, '0');
        ReferenciaOperacion = ReferenciaOperacion + aluid;

        DateTime FechaExp = DateTime.Now.AddHours(1);
        var payload = new
        {
            Concepto = "BOTON DE PAGOS",
            Detalle = new[]
            {
            new { Descripcion = "Aranceles", Importe = Convert.ToDecimal(lblSubTotal.Text.Trim()) }
        },
            FechaExpiracion = FechaExp,
            Importe = Convert.ToDecimal(lblSubTotal.Text.Trim()),
            URL_OK = "https://obramisericordista.com.ar/PaginasGenerales/FacturacionPadres.aspx",
            nro_comprobante = NroComprobante,
            URL_ERROR = "https://obramisericordista.com.ar/PaginasGenerales/FacturacionPadresNoExitoso.aspx",
            IdReferenciaOperacion = ReferenciaOperacion,
            nro_cliente_empresa = "0428544445150058293" // "0428544445150058298" 

        };

        int Id = 0;
        ocnIntencionPagos = new GESTIONESCOLAR.Negocio.IntencionPagos(Id);
        ocnIntencionPagos.inp_IdReferenciaOperacion = ReferenciaOperacion;
        ocnIntencionPagos.inp_Hash = "";
        ocnIntencionPagos.inp_FechaCreacion = DateTime.Now;
        ocnIntencionPagos.inp_Estado = "GENERADA";
        ocnIntencionPagos.inp_Monto = ImporteTotal;
        ocnIntencionPagos.usuIdCreacion = this.Master.usuId;
        ocnIntencionPagos.inp_comprobantenro = NroComprobante;
        ocnIntencionPagos.aluid = Convert.ToInt32(lblicuId.Text.Trim().ToString());
        ocnIntencionPagos.inp_FechaExpiracion = FechaExp;
        ocnIntencionPagos.inp_bearerToken = bearerToken;
        //Nuevo
        Id = ocnIntencionPagos.Insertar();

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            // Añadir token Bearer
            request.Headers.Add("Authorization", "Bearer " + bearerToken);

            // Serializar JSON
            var serializer = new JavaScriptSerializer();
            string jsonData = serializer.Serialize(payload);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonData);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string result = "";

            // Leer respuesta
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
                Response.Write("<pre>" + result + "</pre>");
            }
            return result;

        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string error = reader.ReadToEnd();
                    Response.Write("<pre>ERROR: " + error + "</pre>");
                }
            }
            else
            {
                Response.Write("<pre>ERROR: " + ex.Message + "</pre>");
            }
        }
        return null;
    }



    private string ConsultarEstadoPago(string hash, string idResultado, string bearerToken)
    {

        string url = "https://siropagosh.bancoroela.com.ar/api/Pago/" + hash + "/" + idResultado;
        //Label9.Text = "URL: " + url + " Final..";

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer " + bearerToken);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string error = reader.ReadToEnd();
                    return "ERROR: " + error;
                }
            }
            else
            {
                return "ERROR: " + ex.Message;
            }
        }

    }



    private List<string> ObtenerListadoPagosSIRO(string tokenBearer, DateTime desde, DateTime hasta, string cuitadministrador, string nroempresa)
    {
        string url = "https://apisiroh.bancoroela.com.ar/siro/Listados/Proceso"; // homologación

        var payload = new
        {
            fecha_desde = desde.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
            fecha_hasta = hasta.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
            cuit_administrador = cuitadministrador,
            nro_empresa = nroempresa
        };

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer " + tokenBearer);

            var serializer = new JavaScriptSerializer();
            string jsonData = serializer.Serialize(payload);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonData);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();

                // La respuesta es un array de strings plano
                List<string> pagos = serializer.Deserialize<List<string>>(json);
                return pagos;
            }
        }
        catch (WebException ex)
        {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                string error = reader.ReadToEnd();
                throw new Exception("Error al consultar SIRO: " + error);
            }
        }
    }



    protected void btnRecibirListadoClick(object sender, EventArgs e)
    {
        //bearerToken = InicioSesion();
        //string token = bearerToken;
        //DateTime desde = new DateTime(2020, 11, 01);
        //DateTime hasta = new DateTime(2020, 11, 30);
        //string cuitadministrador = "20233953270";
        //string nroempresa = "5150058293"; // "0428544445150058293";

        //var lineas = ObtenerListadoPagosSIRO(token, desde, hasta, cuitadministrador, nroempresa);

        //foreach (var linea in lineas)
        //{
        //    var pago = ParsearLineaUnificada(linea);
        //    if (pago != null)
        //    {
        //        Response.Write("<b>" + pago.FechaPago + "</b> - " + pago.IdReferenciaOperacion + " - $" + pago.Importe.ToString("N2") + " - " + pago.CanalCobro + "<br/>");
        //    }
        //}


        string ruta = Server.MapPath("~/SIRO/SiroCobranzas.txt"); // o ruta absoluta
        var lineas = LeerArchivoLocal(ruta);

        foreach (string linea in lineas)
        {
            var pago = ParsearLineaUnificada(linea);
            if (pago != null)
            {
                //Response.Write(string.Format(
                //    "<b>{0}</b> - {1} - ${2} - Canal: {3}<br/>",
                //    pago.FechaPago,
                //    pago.IdReferenciaOperacion,
                //    pago.Importe.ToString("N2"),
                //    pago.CanalCobro
                //));
                Label8.Text = Label8.Text + " || " + pago.idUsuario + " - " + pago.idComprobante + " - " + pago.FechaPago + " - " + pago.IdReferenciaOperacion + " - " + pago.ImportePagado.ToString("N2") + " - " + pago.CanalCobro + " <br/>";
            }
        }

    }



    private PagoUnificadoSIRO ParsearLineaUnificada(string linea)
    {
        try
        {
            return new PagoUnificadoSIRO
            {
                FechaPago = FormatearFecha(linea.Substring(0, 8)), // AAAAMMDD
                fechaacreditacion = FormatearFecha(linea.Substring(8, 8)),
                idUsuario = linea.Substring(35, 8).Trim(),
                ImportePagado = Decimal.Parse(linea.Substring(24, 11)) /100m,
                idComprobante = linea.Substring(103, 20).Trim(),
                CanalCobro = linea.Substring(123, 3).Trim(),
                CodigoRechazo = linea.Substring(126, 3).Trim(),
                DescripcionRechazo = linea.Substring(129, 20).Trim(),
                Cuotas = linea.Substring(149, 2).Trim(),
                Tarjetas = linea.Substring(151, 15).Trim(),
                IdPago = linea.Substring(226, 10).Trim(),
                IdResultado = linea.Substring(236, 36).Trim(),
                IdReferenciaOperacion = linea.Substring(272, 100).Trim()

            };
        }
        catch
        {
            return null;
        }
    }

    public class PagoUnificadoSIRO
    {
        public string FechaPago { get; set; }
        public string fechaacreditacion { get; set; }
        public string idUsuario { get; set; }
        public decimal ImportePagado { get; set; }
        public string idComprobante { get; set; }
        public string CanalCobro { get; set; }
        public string CodigoRechazo { get; set; }
        public string DescripcionRechazo { get; set; }
        public string IdResultado { get; set; }
        public string IdReferenciaOperacion { get; set; }
        public string IdPago { get; set; }
        public string Cuotas { get; set; }
        public string Tarjetas { get; set; }
        public string idPagosSiro { get; set; }
        public string idResultadoPago { get; set; }
    }


    private string FormatearFecha(string aaaammdd)
    {
        if (aaaammdd.Length == 8)
            return aaaammdd.Substring(6, 2) + "/" + aaaammdd.Substring(4, 2) + "/" + aaaammdd.Substring(0, 4);
        return aaaammdd;
    }





    private List<string> LeerArchivoLocal(string ruta)
    {
        if (!File.Exists(ruta))
            throw new FileNotFoundException("No se encontró el archivo de SIRO", ruta);

        return new List<string>(File.ReadAllLines(ruta));
    }



    //protected void btnLeerLocal_Click(object sender, EventArgs e)
    //{
    //    string ruta = Server.MapPath("~/SIRO/SiroCobranzas.txt"); // o ruta absoluta
    //    var lineas = LeerArchivoLocal(ruta);

    //    foreach (string linea in lineas)
    //    {
    //        var pago = ParsearLineaUnificada(linea);
    //        if (pago != null)
    //        {
    //            Response.Write(string.Format(
    //                "<b>{0}</b> - {1} - ${2} - Canal: {3}<br/>",
    //                pago.FechaPago,
    //                pago.IdReferenciaOperacion,
    //                pago.Importe.ToString("N2"),
    //                pago.CanalCobro
    //            ));
    //        }
    //    }
    //}



}
