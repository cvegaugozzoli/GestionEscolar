using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;
public partial class Facturacion : System.Web.UI.Page
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


    int cfoIdNuevo;
    DataTable dt9 = new DataTable();
    int valor;
    int cantCuotasPlan;
    int insId;
    private static bool isActive;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                TextDescuento.Text = "0";
                if (Request.QueryString["Id"] != null)
                {

                    // Cadena de conexión
                    //String Servidor = "PC\\SQL2012";
                    //string connectionString = "Server=" + Servidor + ";Database=GESTIONESCOLAR;User Id=sa;Password=mds2013;";
                    string connectionString = "Server=localhost;Database=GESTIONESCOLAR;User Id=sa;Password=ms2014;";

                    // ID que deseas verificar
                    int polId = 1; // Cambia esto según el ID que necesites consultar

                    // Consulta SQL
                    string query = "SELECT polActivo FROM Politicas WHERE polId = @polId";

                    // Conexión y comando
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@polId", polId);

                        try
                        {
                            // Abrir la conexión
                            connection.Open();

                            // Ejecutar la consulta
                            object result = command.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                isActive = Convert.ToBoolean(result);
                                Console.WriteLine(isActive ? "El registro está activo." : "El registro no está activo.");
                            }
                            else
                            {
                                Console.WriteLine("El registro no existe.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }


                    if (isActive == true)
                    {
                        alerInfo.Visible = true;
                        lblalerInfo.Text = "El descuento se aplicará al Importe y al Interés Total del concepto seleccionado";
                    }
                    else
                    {
                        alerInfo.Visible = true;
                        lblalerInfo.Text = "El descuento solo se aplicará al Importe del concepto seleccionado";
                    }


                    this.ViewState["paginaorigen"] = Request.UrlReferrer.ToString();
                    this.Master.TituloDelFormulario = " Facturación";
                    lblSubTotal.Text = "0";
                    lblTotal.Text = "0";
                    lblcocId.Text = "";
                    lblicuId.Text = "";
                    lblinst.Text = "";
                    int IC = Convert.ToInt32(Request.QueryString["Id"]);
                    lblicuId.Text = Convert.ToString(Request.QueryString["Id"]);
                    DataTable dt2 = new DataTable();
                    dt2 = ocnInscripcionCursado.ObtenerUno(IC);
                    if (dt2.Rows.Count > 0)
                    {
                        lblInstitucion.Text = dt2.Rows[0]["InstNombre"].ToString();
                        lblNombre.Text = dt2.Rows[0]["Alumno"].ToString();
                        lblDni.Text = dt2.Rows[0]["DNI"].ToString();
                        lblinst.Text = dt2.Rows[0]["Inst"].ToString();
                        insId = Convert.ToInt32(lblinst.Text);
                        //lblDireccion.Text = dt.Rows[0]["Domicilio"].ToString();
                        DateTime fechaActual = DateTime.Today;
                        /*txtAnioLectivo.Text = fechaActual.Year.ToString()*/

                        lblCurso.Text = dt2.Rows[0]["Curso"].ToString();
                        lblanioLectivo.Text = dt2.Rows[0]["AnoCursado"].ToString();
                        lblTutor.Text = dt2.Rows[0]["TutorApe"].ToString() + "  " + "" + dt2.Rows[0]["TutorNombre"].ToString();
                    }
                    CompTipoId.DataValueField = "Valor"; CompTipoId.DataTextField = "Texto"; CompTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesTipos()).ObtenerListaxInst("[Seleccionar...]", insId); CompTipoId.DataBind();
                    CompTipoId.SelectedValue = "1";
                    TarjetaId.DataValueField = "Valor"; TarjetaId.DataTextField = "Texto"; TarjetaId.DataSource = (new GESTIONESCOLAR.Negocio.Tarjetas()).ObtenerLista("[Seleccionar...]"); TarjetaId.DataBind();
                    BancoId.DataValueField = "Valor"; BancoId.DataTextField = "Texto"; BancoId.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); BancoId.DataBind();

                    Banco2Id.DataValueField = "Valor"; Banco2Id.DataTextField = "Texto"; Banco2Id.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); Banco2Id.DataBind();

                    DestinoId.DataValueField = "Valor"; DestinoId.DataTextField = "Texto"; DestinoId.DataSource = (new GESTIONESCOLAR.Negocio.ComprobantesDestinos()).ObtenerLista("[Seleccionar...]"); DestinoId.DataBind();
                    DestinoId.SelectedValue = "1";
                    LugarPagoId.DataValueField = "Valor"; LugarPagoId.DataTextField = "Texto"; LugarPagoId.DataSource = (new GESTIONESCOLAR.Negocio.LugaresPago()).ObtenerLista("[Seleccionar...]"); LugarPagoId.DataBind();
                    LugarPagoId.SelectedValue = "1";
                    FchPago.Text = DateTime.Today;
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

                    GrillaFormaPgo.DataSource = dt;
                    GrillaFormaPgo.DataBind();
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

                    btnGrabar.Enabled = false;

                    //lblicuId.Text = Convert.ToString(Request.QueryString["Id"]);

                }

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["Facturacion.PageIndex"] == null)
                {
                    Session.Add("Facturacion.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["Facturacion.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //[VariablesDeSesionParaFiltros]
                #endregion
                GrillaCargar(PageIndex);

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
    protected void PlanesTarjetaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (txtImpTarj.Text != "")
        {

            DataTable dt5 = ocnTarjetasPlanes.ObtenerUnoxtarIdxtapId(Convert.ToInt32(TarjetaId.SelectedValue), Convert.ToInt32(PlanesTarjetaId.SelectedValue));
            txtInteresT.Text = Convert.ToString(dt5.Rows[0]["Interes"].ToString());
            txtNroCuotas.Text = Convert.ToString(dt5.Rows[0]["CantCuotasPlanes"].ToString());
            txtTotalTarj.Text = (Convert.ToString(Convert.ToDecimal(txtImpTarj.Text) + ((Convert.ToDecimal(txtImpTarj.Text) * (Convert.ToDecimal(txtInteresT.Text)) / 100))));
            if (txtNroCuotas.Text.Trim() == "0" || txtNroCuotas.Text.Trim() == "")
            {
                txtNroCuotas.Text = "1";
            }
            double resultadoInteres = (Convert.ToDouble(txtTotalTarj.Text)) / (Convert.ToDouble(txtNroCuotas.Text));
            txtImpCuota.Text = resultadoInteres.ToString("n");
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "   Debe ingresar el monto a pagar con tarjeta..";
        }
    }
    protected void txtImpTarj_TextChanged(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (txtInteresT.Text != "")
        {
            txtTotalTarj.Text = (Convert.ToString(Convert.ToDecimal(txtImpTarj.Text) + ((Convert.ToDecimal(txtImpTarj.Text) * (Convert.ToDecimal(txtInteresT.Text)) / 100))));
            if (txtNroCuotas.Text.Trim() == "0" || txtNroCuotas.Text.Trim() == "")
            {
                txtNroCuotas.Text = "1";
            }
            double resultadoInteres = (Convert.ToDouble(txtTotalTarj.Text)) / (Convert.ToDouble(txtNroCuotas.Text));
            txtImpCuota.Text = resultadoInteres.ToString("n");
        }
        else
        {
            //int tarjIdSelec = Convert.ToInt32(TarjetaId.SelectedValue);
            //PlanesTarjetaId.Items.Clear();
            txtInteresT.Text = "0";
            txtNroCuotas.Text = "1";
            txtTotalTarj.Text = (Convert.ToString(Convert.ToDecimal(txtImpTarj.Text) + ((Convert.ToDecimal(txtImpTarj.Text) * (Convert.ToDecimal(txtInteresT.Text)) / 100))));
            if (txtNroCuotas.Text.Trim() == "0" || txtNroCuotas.Text.Trim() == "")
            {
                txtNroCuotas.Text = "1";
            }
            double resultadoInteres = (Convert.ToDouble(txtTotalTarj.Text)) / (Convert.ToDouble(txtNroCuotas.Text));
            txtImpCuota.Text = resultadoInteres.ToString("n");
            PlanesTarjetaId.DataValueField = "Valor"; PlanesTarjetaId.DataTextField = "Texto"; PlanesTarjetaId.DataSource = (new GESTIONESCOLAR.Negocio.TarjetasPlanes()).ObtenerListaxTarjId("Seleccionar..", Convert.ToInt32(TarjetaId.SelectedValue)); PlanesTarjetaId.DataBind();

        }
    }
    protected void txtInteresT_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(txtInteresT.Text).Trim() == "")
        {
            txtInteresT.Text = "0";
        }

        txtTotalTarj.Text = (Convert.ToString(Convert.ToDecimal(txtImpTarj.Text) + ((Convert.ToDecimal(txtImpTarj.Text) * (Convert.ToDecimal(txtInteresT.Text)) / 100))));
        if (Convert.ToString(txtNroCuotas.Text).Trim() == "" || Convert.ToString(txtNroCuotas.Text).Trim() == "0")
        {
            txtNroCuotas.Text = "1";
        }
        txtImpCuota.Text = Convert.ToString((Convert.ToDecimal(txtTotalTarj.Text)) / (Convert.ToDecimal(txtNroCuotas.Text)));
        txtImpCuota.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtImpCuota.Text), 2));
    }

    protected void txtNroCuotas_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(txtTotalTarj.Text).Trim() == "")
        {
            txtTotalTarj.Text = "0";
        }
        if (Convert.ToString(txtNroCuotas.Text).Trim() == "")
        {
            txtNroCuotas.Text = "1";
        }
        if (Convert.ToInt32(txtNroCuotas.Text) > 0 && Convert.ToDecimal(txtTotalTarj.Text) > 0)
        {
            txtImpCuota.Text = Convert.ToString((Convert.ToDecimal(txtTotalTarj.Text)) / (Convert.ToDecimal(txtNroCuotas.Text)));
            txtImpCuota.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtImpCuota.Text), 2));
        }
    }

    protected void TarjetaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            if (txtImpTarj.Text != "")
            {
                int tarjIdSelec = Convert.ToInt32(TarjetaId.SelectedValue);
                PlanesTarjetaId.Items.Clear();
                txtInteresT.Text = "0";
                txtNroCuotas.Text = "1";
                txtTotalTarj.Text = (Convert.ToString(Convert.ToDecimal(txtImpTarj.Text) + ((Convert.ToDecimal(txtImpTarj.Text) * (Convert.ToDecimal(txtInteresT.Text)) / 100))));
                double resultadoInteres = (Convert.ToDouble(txtTotalTarj.Text)) / (Convert.ToDouble(txtNroCuotas.Text));
                txtImpCuota.Text = resultadoInteres.ToString("n");
                PlanesTarjetaId.DataValueField = "Valor"; PlanesTarjetaId.DataTextField = "Texto"; PlanesTarjetaId.DataSource = (new GESTIONESCOLAR.Negocio.TarjetasPlanes()).ObtenerListaxTarjId("Seleccionar..", Convert.ToInt32(TarjetaId.SelectedValue)); PlanesTarjetaId.DataBind();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "   Debe ingresar el monto a pagar con tarjeta..";
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

            int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;
            //int index = e.RowIndex;

            //int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["Facturar"] as DataTable;
            lblSaldo.Text = Convert.ToString((Convert.ToDouble(lblSaldo.Text)) + (Convert.ToDouble(dt1.Rows[RowId]["Importe"].ToString())));
            lblTotal.Text = Convert.ToString((Convert.ToDouble(lblTotal.Text)) - (Convert.ToDouble(dt1.Rows[RowId]["TotalFinal"].ToString())));

            dt1.Rows[RowId].Delete();
            Session["Facturar"] = dt1;

            GrillaFormaPgo.DataSource = dt1;
            GrillaFormaPgo.DataBind();

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

    private void GrillaCargar2(int PageIndex)
    {
        CheckDctoSacar.Checked = false;
        alerError2.Visible = false;
        Decimal txtInt = 0;
        insId = Convert.ToInt32(lblinst.Text);
        TextDescuento.Text = "";
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
            lblSaldo.Text = Convert.ToString(sumatoria);
        }

}


    //    private void GrillaCargar(int PageIndex)
    //    {
    //        try
    //        {
    //            insId = Convert.ToInt32(lblinst.Text);
    //            DataTable dt = new DataTable();
    //            dt.Columns.Add("icoId", typeof(int));
    //            dt.Columns.Add("conId", typeof(Int32));
    //            dt.Columns.Add("cntId", typeof(Int32));
    //            dt.Columns.Add("TipoConcepto", typeof(String));
    //            dt.Columns.Add("Concepto", typeof(String));
    //            dt.Columns.Add("Importe", typeof(Decimal));

        //            dt.Columns.Add("InteresCuota", typeof(Decimal));
        //            dt.Columns.Add("RecargoAbierto", typeof(Decimal));
        //            dt.Columns.Add("InteresMensual", typeof(Decimal));
        //            dt.Columns.Add("AnioLectivo", typeof(Decimal));
        //            dt.Columns.Add("Beca", typeof(String));
        //            dt.Columns.Add("BecId", typeof(Int32));
        //            dt.Columns.Add("NroCuota", typeof(Int32));
        //            dt.Columns.Add("FchInscripcion", typeof(String));
        //            dt.Columns.Add("FechaVto", typeof(String));
        //            dt.Columns.Add("InteresTotal", typeof(Decimal));
        //            DataTable dt4 = new DataTable();
        //            DataTable dt5 = new DataTable();
        //            DataTable dt3 = new DataTable();
        //            DataTable dt2 = new DataTable();
        //            DataTable dt1 = new DataTable();
        //            DataTable dt6 = new DataTable();
        //            DataTable dt7 = new DataTable();
        //            dt2 = Session["TablaPagar"] as DataTable;
        //            String FchaInscripcionCon;
        //            DateTime FechaPago;
        //            string dateString = Convert.ToString(txtFechaPago.Text);
        //            int NroCuotaCon;
        //            int bcaIdCon;
        //            FechaPago = DateTime.Parse(dateString);
        //            int Bandera = 0;
        //            decimal InteresCuotaAsignar = 0;
        //            decimal InteresMensualAsignar = 0;
        //            Decimal ValorInteres = 0;
        //            string AplicaInteres;
        //            decimal RecargoAbiertoAsignar = 0;
        //            decimal InteresTotal = 0;
        //            DateTime fchVtoAsignar = DateTime.Now;
        //            LblMjeGridConcepto.Text = "";

        //            foreach (DataRow row in dt2.Rows)
        //            {
        //                int ValorSeleccionado;
        //                //obtengo incripcionConepto 
        //                dt9 = ocnInscripcionConcepto.ObtenerUno(Convert.ToInt32(row["icoId"].ToString()));
        //                int conId = Convert.ToInt32(row["conId"].ToString());
        //                dt3 = ocnConceptos.ObtenerUno(Convert.ToInt32(row["conId"].ToString()));
        //                DateTime UltVto;
        //                if (dt9.Rows.Count > 0) //Inscripcion Concepto Existe
        //                {
        //                    FchaInscripcionCon = Convert.ToString(dt9.Rows[0]["FechaInscripcion"].ToString());
        //                    NroCuotaCon = Convert.ToInt32(dt9.Rows[0]["NroCuota"].ToString());

        //                    String BecaCon = Convert.ToString(dt9.Rows[0]["Becas"].ToString());

        //                    //Busco si hay Vencimiento
        //                    dt4 = ocnConceptosIntereses.ObtenerListaxconIdxNroCuota(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())), (Convert.ToInt32(row["NroCuota"].ToString())));

        //                    Decimal ValorInteresCI = 0;
        //                    DateTime FchaVtofila;
        //                    int BanderaVto = 0;
        //                    if (dt4.Rows.Count > 0)//Existe en la Tabla ConceptoIneres
        //                    {

        //                        String pFecha = "";
        //                        pFecha = dt4.Rows[0]["FechaVto"].ToString();


        //                        FchaVtofila = Convert.ToDateTime(dt4.Rows[0]["FechaVto"].ToString());//1° Vto

        //                        if (FechaPago <= FchaVtofila) // Veo 1° Vencimiento asi no paga Interes
        //                        {
        //                            InteresCuotaAsignar = 0;
        //                            RecargoAbiertoAsignar = 0;
        //                            InteresMensualAsignar = 0;
        //                            InteresTotal = 0;
        //                            fchVtoAsignar = FchaVtofila;

        //                        }
        //                        else // Está atrasado, paga interés..
        //                        {
        //                            foreach (DataRow row4 in dt4.Rows)// Cant de vtos. para cada fila con fecha de vtos
        //                            {
        //                                FchaVtofila = Convert.ToDateTime(row4["FechaVto"].ToString());
        //                                if (FechaPago < FchaVtofila)
        //                                {
        //                                    fchVtoAsignar = Convert.ToDateTime(row4["FechaVto"].ToString());
        //                                    AplicaInteres = Convert.ToString(row4["AplicaInteres"].ToString());
        //                                    ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());

        //                                    if (Convert.ToDecimal(row4["ValorInteres"].ToString()) > 0)
        //                                    //if (AplicaInteres == "Si")// Se Cobra Interes
        //                                    {
        //                                        ValorInteresCI = Convert.ToDecimal(row4["ValorInteres"].ToString());
        //                                    }
        //                                    else
        //                                    {
        //                                        ValorInteresCI = 0;
        //                                    }
        //                                }
        //                                {
        //                                    fchVtoAsignar = Convert.ToDateTime(row4["FechaVto"].ToString());
        //                                    AplicaInteres = Convert.ToString(row4["AplicaInteres"].ToString());
        //                                    ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());

        //                                    if (Convert.ToDecimal(row4["ValorInteres"].ToString()) > 0)
        //                                    //if (AplicaInteres == "Si")// Se Cobra Interes
        //                                    {
        //                                        ValorInteresCI = Convert.ToDecimal(row4["ValorInteres"].ToString());
        //                                    }
        //                                    else
        //                                    {
        //                                        ValorInteresCI = 0;
        //                                    }
        //                                }


        //                            }
        //                            InteresCuotaAsignar = ValorInteresCI;
        //                            RecargoAbiertoAsignar = 0;
        //                            InteresMensualAsignar = 0;
        //                            InteresTotal = ValorInteresCI;
        //                            fchVtoAsignar = Convert.ToDateTime(FchaVtofila);
        //                            BanderaVto = 1;

        //                            DataTable dt12 = ocnConceptosIntereses.ObtenerUltimoVencimiento(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())), (Convert.ToInt32(row["NroCuota"].ToString())));
        //                            if (dt12.Rows.Count > 0)
        //                            {
        //                                UltVto = Convert.ToDateTime(dt12.Rows[0]["FechaVto"].ToString());

        //                                if (FechaPago > UltVto)
        //                                {
        //                                    Decimal InteresMensualIM;
        //                                    Decimal InteresAplicar = 0;
        //                                    Decimal ValorInteresRA = 0;
        //                                    ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());
        //                                    if (Convert.ToString(dt3.Rows[0]["TieneVtoAbierto"]) == "Si")
        //                                    {

        //                                        if (ValorSeleccionado == 0)// Interés con Monto Fijo
        //                                        {
        //                                            ValorInteresRA = Convert.ToDecimal(dt3.Rows[0]["RecargoVtoAbierto"].ToString());

        //                                            if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
        //                                            {
        //                                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

        //                                                InteresMensualIM = Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) * Convert.ToDecimal(diff);
        //                                                InteresAplicar = InteresMensualIM;

        //                                                InteresCuotaAsignar = ValorInteresCI;
        //                                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                                InteresMensualAsignar = InteresAplicar;
        //                                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                                            }
        //                                            else
        //                                            {
        //                                                InteresCuotaAsignar = ValorInteresCI;
        //                                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                                InteresMensualAsignar = InteresAplicar;
        //                                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                                            }
        //                                        }
        //                                        else// Porcentaje
        //                                        {
        //                                            ValorInteresRA = (Convert.ToDecimal(dt3.Rows[0]["Importe"].ToString()) * Convert.ToDecimal(dt3.Rows[0]["RecargoVtoAbierto"].ToString())) / 100;

        //                                            if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
        //                                            {
        //                                                //DateTime MesSiguienteVto = UltVto.AddDays(30);
        //                                                //return Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
        //                                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
        //                                                //Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));

        //                                                InteresMensualIM = (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100;
        //                                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

        //                                                InteresCuotaAsignar = ValorInteresCI;
        //                                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                                InteresMensualAsignar = InteresAplicar;
        //                                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                                            }
        //                                            else
        //                                            {
        //                                                InteresCuotaAsignar = ValorInteresCI;
        //                                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                                InteresMensualAsignar = InteresAplicar;
        //                                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                                            }
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
        //                                        {
        //                                            if (ValorSeleccionado == 0)// Interés con Monto Fijo
        //                                            {
        //                                                //DateTime MesSiguienteVto = UltVto.AddDays(30);

        //                                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

        //                                                //Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));

        //                                                InteresMensualIM = Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) * Convert.ToDecimal(diff);
        //                                                InteresAplicar = InteresMensualIM;

        //                                                InteresCuotaAsignar = ValorInteresCI;
        //                                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                                InteresMensualAsignar = InteresAplicar;
        //                                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                                fchVtoAsignar = Convert.ToDateTime(UltVto);

        //                                            }
        //                                            else
        //                                            {
        //                                                //DateTime MesSiguienteVto = UltVto.AddDays(30);
        //                                                //Decimal diff = Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));
        //                                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

        //                                                InteresMensualIM = (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100;
        //                                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

        //                                                InteresCuotaAsignar = ValorInteresCI;
        //                                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                                InteresMensualAsignar = InteresAplicar;
        //                                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            InteresCuotaAsignar = ValorInteresCI;
        //                                            RecargoAbiertoAsignar = ValorInteresRA;
        //                                            InteresMensualAsignar = 0;
        //                                            InteresTotal = ValorInteresCI + ValorInteresRA;
        //                                            fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                DataRow row1 = dt.NewRow();
        //                row1["icoId"] = Convert.ToInt32(row["icoId"].ToString());
        //                row1["conId"] = Convert.ToInt32(row["conId"].ToString());
        //                row1["TipoConcepto"] = Convert.ToInt32(row["cntId"].ToString());
        //                row1["Concepto"] = Convert.ToString(row["Concepto"].ToString());
        //                row1["Importe"] = Convert.ToDecimal(row["Importe"].ToString());
        //                row1["InteresCuota"] = InteresCuotaAsignar;
        //                row1["RecargoAbierto"] = RecargoAbiertoAsignar;
        //                row1["InteresMensual"] = InteresMensualAsignar;
        //                row1["AnioLectivo"] = Convert.ToInt32(row["AnioLectivo"].ToString());
        //                row1["Beca"] = Convert.ToString(row["Beca"].ToString());
        //                row1["BecId"] = Convert.ToInt32(row["BecId"].ToString());
        //                row1["FchInscripcion"] = Convert.ToString(row["FchInscripcion"].ToString());
        //                row1["FechaVto"] = Convert.ToString(fchVtoAsignar);
        //                row1["NroCuota"] = Convert.ToInt32(row["NroCuota"].ToString());
        //                row1["InteresTotal"] = InteresTotal;
        //                dt.Rows.Add(row1);
        //                Bandera = 1;
        //            }

        //            GridConcepto.DataSource = dt;
        //            GridConcepto.DataBind();
        //            Session["GrillaFinal"] = dt;


        //            if (dt.Rows.Count > 0)
        //            {
        //                Decimal sumatoria = 0;// Saco TOTAL
        //                                      //Decimal ImporteBecado = 0;
        //                Int32 BanderaBeca = 0;
        //                foreach (DataRow row in dt.Rows)
        //                {

        //                    sumatoria += (Convert.ToDecimal(row["Importe"].ToString())) + (Convert.ToDecimal(row["InteresTotal"].ToString()));

        //                }

        //                lblSubTotal.Text = Convert.ToString(sumatoria);
        //                lblSaldo.Text = Convert.ToString(sumatoria);
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

    private void GrillaCargar(int PageIndex)
    {
        try
        {

            if (isActive == true)
            {
                alerInfo.Visible = true;
                lblalerInfo.Text = "El descuento se aplicará al Importe y al Interés Total del concepto seleccionado";
            }
            else
            {
                alerInfo.Visible = true;
                lblalerInfo.Text = "El descuento solo se aplicará al Importe del concepto seleccionado";
            }
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
                    lblSaldo.Text = Convert.ToString(sumatoria);
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
                            row1["Importe"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]) - (Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]) * Convert.ToDecimal(TextDescuento.Text)) / 100;
                            row1["FechaVto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["FechaVto"]);
                            row1["InteresCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresCuota"]);
                            row1["RecargoAbierto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["RecargoAbierto"]);
                            row1["InteresMensual"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresMensual"]);
                            row1["Dcto"] = Convert.ToDecimal(TextDescuento.Text);
                            row1["InteresTotal"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresTotal"]) - (Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresTotal"]) * Convert.ToDecimal(TextDescuento.Text)) / 100; ;
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
                            row1["Dcto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["Dcto"]);
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
                        lblSaldo.Text = Convert.ToString(sumatoria);

                        if (dt.Rows.Count == 1 & sumatoria == 0)
                        {
                            btnGrabar.Enabled = true;
                        }
                        else
                        {
                            btnGrabar.Enabled = false;
                        }
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
                            row1["Importe"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]) - (Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["Importe"]) * Convert.ToDecimal(TextDescuento.Text)) / 100;
                            row1["FechaVto"] = Convert.ToString(GridConcepto.DataKeys[row.RowIndex].Values["FechaVto"]);
                            row1["InteresCuota"] = Convert.ToDecimal(GridConcepto.DataKeys[row.RowIndex].Values["InteresCuota"]);
                            row1["RecargoAbierto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["RecargoAbierto"]);
                            row1["InteresMensual"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["InteresMensual"]);
                            row1["Dcto"] = Convert.ToDecimal(TextDescuento.Text);
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
                            row1["Dcto"] = Convert.ToInt32(GridConcepto.DataKeys[row.RowIndex].Values["Dcto"]);
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
                        lblSaldo.Text = Convert.ToString(sumatoria);

                        if (dt.Rows.Count == 1 & sumatoria == 0)
                        {
                            btnGrabar.Enabled = true;
                        }
                        else
                        {
                            btnGrabar.Enabled = false;
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



    protected void btnGrabar_Click(object sender, EventArgs e)
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
                btnGrabar.Enabled = false;
                btnFormaPago.Enabled = false;
            }
            else
            {
                insId = Convert.ToInt32(lblinst.Text);
                dt9 = ocnComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest(insId, Convert.ToInt32(CompTipoId.SelectedValue), Convert.ToInt32(DestinoId.SelectedValue));
                lblCompTipo.Text = dt9.Rows[0]["ComprobantesTipos"].ToString();
                DataTable dt5 = new DataTable();
                dt5 = Session["Facturar"] as DataTable;
                //dt5 = Session["GrillaFinal"] as DataTable;

                Decimal ImportePagar2 = 0;

                Decimal porCont = 100; Decimal porTarj = 100; Decimal porTranf = 100; Decimal porcheque = 100;
                Decimal IntCuota = 0; int ConConc = 0;
                int varTarj = 0; int conCheq = 0;
                if (dt5.Rows.Count > 0)
                {
                    Decimal sumatoria = 0; Decimal sumatoriaConcepto = 0;// Saco TOTAL
                    foreach (DataRow row in dt5.Rows)
                    {
                        if (Convert.ToDecimal(row["Importe"].ToString()) != 0)
                        {
                            sumatoriaConcepto += (Convert.ToDecimal(row["Importe"].ToString()));
                            sumatoria += (Convert.ToDecimal(row["TotalFinal"].ToString()));
                        }
                        else
                        {

                        }
                    }
                    ImportePagar2 = sumatoria;
                    Decimal Intereses = sumatoria - sumatoriaConcepto;
                    int conTarj = 0;
                    int b = 0; int b2 = 0; Decimal TotTarj = 0; Decimal TotCheq = 0;
                    foreach (DataRow row in dt5.Rows)
                    {
                        int FormPago = Convert.ToInt32(row["IdFP"].ToString());
                        if (FormPago == 1)
                        {
                            porCont = Convert.ToDecimal(row["Importe"].ToString()) * 100 / sumatoriaConcepto;
                        }
                        else
                        {
                            if (FormPago == 2)
                            {
                                TotTarj = TotTarj + Convert.ToDecimal(row["Importe"].ToString());
                                conTarj = conTarj + 1;
                            }
                            else
                            {
                                if (FormPago == 3)
                                {
                                    TotCheq = TotCheq + Convert.ToDecimal(row["Importe"].ToString());
                                    conCheq = conCheq + 1;
                                }

                                else
                                {
                                    if (FormPago == 4)
                                    {
                                        porTranf = Convert.ToDecimal(row["Importe"].ToString()) * 100 / sumatoriaConcepto;
                                    }
                                }
                            }
                        }
                    }
                    DataTable dtGF = Session["GrillaFinal"] as DataTable;

                    if (sumatoriaConcepto != 0)
                    {
                        porTarj = TotTarj * 100 / sumatoriaConcepto;
                        porcheque = TotCheq * 100 / sumatoriaConcepto;
                    }
                    varTarj = conTarj;
                    if (conTarj != 0)
                    {
                        if (Convert.ToInt32(dtGF.Rows.Count) != 0)
                        {
                            IntCuota = Intereses / (Convert.ToInt32(dtGF.Rows.Count) * conTarj);
                        }
                    }
                }

                int LugPago = Convert.ToInt32(dt5.Rows[0]["IdLP"].ToString());
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
                        if (dt5.Rows.Count > 0)
                        {
                            int FormPagoIn;
                            decimal ImpParcial;
                            foreach (DataRow row2 in dt5.Rows)
                            {
                                FormPagoIn = Convert.ToInt32(row2["IdFP"].ToString());

                                if (FormPagoIn == 1)
                                {
                                    ImpParcial = sumatoria * porCont / 100;
                                    cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                }
                                if (FormPagoIn == 2)
                                {
                                    decimal ImpParcial2 = (sumatoria * porTarj / 100) / varTarj;
                                    ImpParcial = ImpParcial2 + IntCuota;
                                    cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                    ocnPagosTarjetas.Insertar(cfoIdNuevo, Convert.ToInt32(row2["TarjetaId"].ToString()), Convert.ToInt32(row2["IdPlanTarj"].ToString()), Convert.ToDecimal(row2["Interes"].ToString()), Convert.ToDecimal(row2["ImporteCuota"].ToString()), Convert.ToInt32(row2["NroCuota"].ToString()), Convert.ToString(row2["NroCupon"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, patFechaHoraCreacion, patFechaHoraUltimaModificacion);
                                }
                                if (FormPagoIn == 3)
                                {
                                    ImpParcial = (sumatoria * porcheque / 100) / conCheq;
                                    cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                    ocnPagosCheques.Insertar(cfoIdNuevo, ImpParcial, Convert.ToString(row2["NroCheque"].ToString()), Convert.ToInt32(row2["BancoId"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                }
                                if (FormPagoIn == 4)
                                {
                                    ImpParcial = sumatoria * porTranf / 100;
                                    cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeIdNew, FormPagoIn, ImpParcial, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                    ocnPagosTransferenciaElectronica.Insertar(cfoIdNuevo, Convert.ToInt32(row2["Importe"].ToString()), Convert.ToString(row2["NroCta"].ToString()), Convert.ToInt32(row2["BancoId"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                }
                            }
                        }
                    }
                }
                btnGrabar.Enabled = false;
                btnCancelarFP.Enabled = false;
                btnFormaPago.Enabled = false;
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

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (LugarPagoId.SelectedValue != "0")
        {
            lblSaldo.Visible = true;
            lblSaldoTit.Visible = true;
            LblMjeGridFormaPago.Text = "";
            DataTable dt1 = ocnLugaresPago.ObtenerUno(Convert.ToInt32(LugarPagoId.SelectedValue));
            //DataTable dt4 = ocnFormasPago.ObtenerUno(Convert.ToInt32(FormaPagoId.SelectedValue));
            DataTable dt8 = new DataTable();
            DataTable dt = new DataTable();
            dt = Session["Facturar"] as DataTable;
            lblMjeError.Text = "";

            if (txtImporteContado.Text != "")
            {
                //cONTROLO SI HAY INTERES
                if (Convert.ToDecimal((lblSaldo.Text)) - Convert.ToDecimal((txtImporteContado.Text)) >= 0)
                {
                    DataRow row1 = dt.NewRow();
                    row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                    row1["IdFP"] = 1;
                    row1["FormaPago"] = "Contado";
                    row1["Importe"] = txtImporteContado.Text;
                    row1["FchPago"] = FchPago.Text;
                    row1["TarjetaId"] = 0;
                    row1["Tarjeta"] = "";
                    row1["NroCuota"] = 0;
                    row1["NroCupon"] = "";
                    row1["ImporteCuota"] = 0;
                    row1["BancoId"] = 0;
                    row1["Banco"] = "";
                    row1["Interes"] = "";
                    row1["TotalTarj"] = 0;
                    row1["NroCta"] = "";
                    row1["NroCheque"] = "";
                    row1["PlanTarj"] = "";
                    row1["IdPlanTarj"] = 0;
                    row1["TotalFinal"] = txtImporteContado.Text;
                    dt.Rows.Add(row1);
                    lblSaldo.Text = Convert.ToString((Convert.ToDouble(lblSaldo.Text) - (Convert.ToDouble(txtImporteContado.Text))));
                    lblTotal.Text = Convert.ToString((Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(txtImporteContado.Text))));
                    txtImporteContado.Text = "";
                }
                else
                {
                    lblMjeError.Text = "El Importe Ingresado supera el saldo a pagar";
                }
            }
            else
            {
                if (txtImpTarj.Text != "")
                {
                    if (Convert.ToDecimal((lblSaldo.Text)) - Convert.ToDecimal((txtImpTarj.Text)) >= 0)
                    {

                        DataTable dt3 = ocnTarjetas.ObtenerUno(Convert.ToInt32(TarjetaId.SelectedValue));
                        DataTable dt5 = ocnTarjetasPlanes.ObtenerUnoxTarjeta(Convert.ToInt32(TarjetaId.SelectedValue));
                        DataRow row1 = dt.NewRow();

                        String NombreTarj;
                        Int32 TarjetaIDc;

                        if (dt5.Rows.Count == 0)
                        {
                            NombreTarj = "";
                            TarjetaIDc = 0;
                        }
                        else
                        {
                            NombreTarj = Convert.ToString(dt5.Rows[0]["Nombre"].ToString());
                            TarjetaIDc = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                        }

                        row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                        row1["IdFP"] = 2;
                        row1["FormaPago"] = "Tarjeta";
                        row1["Importe"] = txtImpTarj.Text;
                        row1["FchPago"] = FchPago.Text;
                        row1["TarjetaId"] = Convert.ToInt32(TarjetaId.SelectedValue);
                        row1["Tarjeta"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                        row1["NroCuota"] = Convert.ToInt32(txtNroCuotas.Text);
                        row1["NroCupon"] = Convert.ToString(txtNroCupon.Text);
                        row1["ImporteCuota"] = Convert.ToDecimal(txtImpCuota.Text);
                        row1["BancoId"] = 0;
                        row1["Interes"] = txtInteresT.Text;
                        row1["TotalTarj"] = txtTotalTarj.Text;
                        row1["NroCheque"] = "";
                        row1["PlanTarj"] = NombreTarj;
                        row1["IdPlanTarj"] = Convert.ToInt32(PlanesTarjetaId.SelectedValue);
                        row1["TotalFinal"] = txtTotalTarj.Text;
                        lblSaldo.Text = Convert.ToString((Convert.ToDouble(lblSaldo.Text) - (Convert.ToDouble(txtImpTarj.Text))));
                        lblTotal.Text = Convert.ToString((Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(txtTotalTarj.Text))));
                        dt.Rows.Add(row1);
                        txtImpTarj.Text = "";
                        txtNroCuotas.Text = "0";
                        txtNroCupon.Text = "";
                        txtTotalTarj.Text = "";
                        txtInteresT.Text = "";
                        txtNroCuotas.Text = "";
                        txtImpCuota.Text = "";
                    }
                    else
                    {
                        lblMjeError.Text = "El Importe Ingresado supera el saldo a pagar";
                    }
                }
                else
                {
                    if (txtImpCheque.Text != "")
                    {
                        if (Convert.ToDecimal((lblSaldo.Text)) - Convert.ToDecimal((txtImpCheque.Text)) >= 0)
                        {
                            //cONTROLO SI HAY INTERES
                            String importeInteres = txtImpCheque.Text;
                            DataTable dt3 = ocnBancos.ObtenerUno(Convert.ToInt32(BancoId.SelectedValue));
                            DataRow row1 = dt.NewRow();

                            row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                            row1["IdFP"] = 3;
                            row1["FormaPago"] = "Cheque";
                            row1["Importe"] = txtImpCheque.Text;
                            row1["TarjetaId"] = 0;
                            row1["Tarjeta"] = "";
                            row1["NroCuota"] = 0;
                            row1["NroCupon"] = "";
                            row1["ImporteCuota"] = 0;
                            row1["FchPago"] = FchPago.Text;
                            row1["BancoId"] = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                            row1["Banco"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                            row1["Interes"] = "";
                            row1["TotalTarj"] = 0;
                            row1["NroCheque"] = txtNroCheque.Text;
                            row1["PlanTarj"] = "";
                            row1["IdPlanTarj"] = 0;
                            row1["TotalFinal"] = txtImpCheque.Text;

                            dt.Rows.Add(row1);
                            lblSaldo.Text = Convert.ToString((Convert.ToDouble(lblSaldo.Text) - (Convert.ToDouble(txtImpCheque.Text))));

                            lblTotal.Text = Convert.ToString((Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(txtImpCheque.Text))));
                            txtImpCheque.Text = "";
                        }
                        else
                        {
                            lblMjeError.Text = "El Importe Ingresado supera el saldo a pagar";
                        }
                    }
                    else
                    {
                        //cONTROLO SI HAY INTERES
                        //String importeInteres = txtImpTrans.Text;
                        //if (txtImpTrans.Text != "")
                        //{
                        if (txtImpTrans.Text != "")
                        {
                            if (Convert.ToDecimal((lblSaldo.Text)) - Convert.ToDecimal((txtImpTrans.Text)) >= 0)
                            {

                                DataTable dt3 = ocnBancos.ObtenerUno(Convert.ToInt32(Banco2Id.SelectedValue));

                                DataRow row1 = dt.NewRow();
                                row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                                row1["IdFP"] = 4;
                                row1["FormaPago"] = "Tranferencia";
                                row1["Importe"] = txtImpTrans.Text;
                                row1["FchPago"] = FchPago.Text;
                                row1["TarjetaId"] = 0;
                                row1["Tarjeta"] = "";
                                row1["NroCuota"] = 0;
                                row1["NroCupon"] = "";
                                row1["ImporteCuota"] = 0;
                                row1["BancoId"] = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                row1["Banco"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                row1["Interes"] = "";
                                row1["NroCta"] = txtNroCta.Text;
                                row1["NroCheque"] = "";
                                row1["TotalTarj"] = 0;
                                row1["PlanTarj"] = "";
                                row1["IdPlanTarj"] = 0;
                                row1["TotalFinal"] = txtImpTrans.Text;
                                dt.Rows.Add(row1);

                                lblSaldo.Text = Convert.ToString((Convert.ToDouble(lblSaldo.Text) - (Convert.ToDouble(txtImpTrans.Text))));
                                lblTotal.Text = Convert.ToString((Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(txtImpTrans.Text))));
                                txtImpTrans.Text = "";
                            }
                            else
                            {
                                lblMjeError.Text = "El Importe Ingresado supera el saldo a pagar";
                            }
                        }
                    }
                }
            }

            Session.Add("Facturar", dt);
            dt8 = Session["Facturar"] as DataTable;
            GrillaFormaPgo.DataSource = dt8;
            //this.GrillaFormaPgo.PageIndex = PageIndex;
            GrillaFormaPgo.DataBind();

            if (Convert.ToDecimal(lblSaldo.Text) == 0)
            {
                btnGrabar.Visible = true;
                btnGrabar.Enabled = true;
                btnCancelarFP.Visible = true;
                btnCancelarFP.Enabled = true;
                //UpdFormaPago.Visible = false;
                btnFormaPago.Enabled = false;
                btnAgregar.Enabled = false;
                btnAgregar2.Enabled = false;
                btnAgregar3.Enabled = false;
                btnAgregar4.Enabled = false;
                LugarPagoId.Enabled = false;
            }
        }
        else
        {
            lblMjeError.Text = "Debe seleccionar Lugar de Pago..";
            LugarPagoId.Focus();
        }
    }



    protected void btnFormaPago_Click(object sender, EventArgs e)
    {
        UpdFormaPago.Visible = true;
    }

    protected void btnCancelarFP_Click(object sender, EventArgs e)
    {
        //btnGrabar.Visible = false;
        btnGrabar.Enabled = false;
        btnCancelarFP.Visible = false;
        btnCancelarFP.Enabled = false;
        //UpdFormaPago.Visible = false;
        btnFormaPago.Enabled = true;
        btnAgregar.Enabled = true;
        btnAgregar2.Enabled = true;
        btnAgregar3.Enabled = true;
        btnAgregar4.Enabled = true;
        LugarPagoId.Enabled = true;
        lblSaldo.Text = lblSubTotal.Text;
        lblTotal.Text = "0";
        lblSaldo.Text = "0";
        DataTable dt = new DataTable();
        dt.Columns.Add("IdLP", typeof(Int32));
        dt.Columns.Add("IdFP", typeof(Int32));
        dt.Columns.Add("FormaPago", typeof(String));
        dt.Columns.Add("Importe", typeof(Decimal));
        dt.Columns.Add("FchPago", typeof(DateTime));
        dt.Columns.Add("TarjetaId", typeof(Int32));
        dt.Columns.Add("TotalFinal", typeof(Decimal));
        dt.Columns.Add("Tarjeta", typeof(String));
        dt.Columns.Add("BancoId", typeof(Int32));
        dt.Columns.Add("Banco", typeof(String));
        dt.Columns.Add("Interes", typeof(String));
      
        dt.Columns.Add("NroCta", typeof(String));
        dt.Columns.Add("NroCheque", typeof(String));
        dt.Columns.Add("PlanTarj", typeof(String));
        dt.Columns.Add("IdPlanTarj", typeof(int));
        GrillaFormaPgo.DataSource = dt;
        GrillaFormaPgo.DataBind();
        Session["Facturar"] = dt;
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


    protected void chkDesc_CheckedChanged(object sender, EventArgs e)
    {
        alerError2.Visible = false;
        //TextDescuento.Text = "";


        if ((chkDesc.Checked)) // & (EstIC == 1)
        {

            if (Convert.ToDecimal(TextDescuento.Text) <= 100 & Convert.ToDecimal(TextDescuento.Text) >= 0)
            {
                if (isActive == true)
                {
                    alerInfo.Visible = true;
                    lblalerInfo.Text = "El descuento se aplicará al Importe y al Interés Total del concepto seleccionado";
                }
                else
                {
                    alerInfo.Visible = true;
                    lblalerInfo.Text = "El descuento solo se aplicará al Importe del concepto seleccionado";
                }

                alerInfo.Visible = true;
                lblalerInfo.Text = "";
                int BanChk2 = 0;
                foreach (GridViewRow row in GridConcepto.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                    if ((check.Checked)) // Si esta seleccionado..
                    {
                        BanChk2 = 1;
                    }
                }
                if (BanChk2 == 1)
                {

                    Int32 PageIndex = Convert.ToInt32(Session["Facturacion.PageIndex"]);
                    chkDesc.Checked = false;
                    GrillaCargar(PageIndex);
                }
                else
                {
                    chqFchPago.Checked = false;
                    alerError2.Visible = true;
                    lblError2.Text = "Debe seleccionar un items para aplicar Descuento";

                }
            }
            else
            {
                alerError2.Visible = true;
                lblError2.Text = "El descuento ingresado debe ser un número entre 0 y 100 ";
                return;
            }
        }
    }

    protected void chqFchPago_CheckedChanged(object sender, EventArgs e)
    {

        if ((chqFchPago.Checked)) // & (EstIC == 1)
        {
            Int32 PageIndex = Convert.ToInt32(Session["Facturacion.PageIndex"]);
            chqFchPago.Checked = false;
            GrillaCargar2(PageIndex);
        }
    }

    protected void btnGestion_Click(object sender, EventArgs e)
    {
        Response.Redirect((string)this.ViewState["paginaorigen"]);

    }

    protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
    {
        chkDesc.Checked = false;
        alerError2.Visible = false;
    }

    protected void CheckDctoSacar_CheckedChanged(object sender, EventArgs e)
    {
        if (isActive == true)
        {
            alerInfo.Visible = true;
            lblalerInfo.Text = "El descuento se aplicará al Importe y al Interés Total del concepto seleccionado";
        }
        else
        {
            alerInfo.Visible = true;
            lblalerInfo.Text = "El descuento solo se aplicará al Importe del concepto seleccionado";
        }
        Int32 PageIndex = Convert.ToInt32(Session["Facturacion.PageIndex"]);
        GrillaCargar2(PageIndex);

        //CheckDctoSacar.Checked = false;
        //alerError2.Visible = false;
        //Decimal txtInt = 0;
        //insId = Convert.ToInt32(lblinst.Text);
        //TextDescuento.Text = "";
        //DataTable dt = new DataTable();
        //dt.Columns.Add("icoId", typeof(int));
        //dt.Columns.Add("conId", typeof(Int32));
        //dt.Columns.Add("cntId", typeof(Int32));
        //dt.Columns.Add("TipoConcepto", typeof(String));
        //dt.Columns.Add("Concepto", typeof(String));
        //dt.Columns.Add("Importe", typeof(Decimal));

        //dt.Columns.Add("InteresCuota", typeof(Decimal));
        //dt.Columns.Add("RecargoAbierto", typeof(Decimal));
        //dt.Columns.Add("InteresMensual", typeof(Decimal));
        //dt.Columns.Add("AnioLectivo", typeof(Decimal));
        //dt.Columns.Add("Beca", typeof(String));
        //dt.Columns.Add("BecId", typeof(Int32));
        //dt.Columns.Add("NroCuota", typeof(Int32));
        //dt.Columns.Add("FchInscripcion", typeof(String));
        //dt.Columns.Add("FechaVto", typeof(String));
        //dt.Columns.Add("Dcto", typeof(Decimal));
        //dt.Columns.Add("InteresTotal", typeof(Decimal));
        //DataTable dt4 = new DataTable();
        //DataTable dt5 = new DataTable();
        //DataTable dt3 = new DataTable();
        //DataTable dt2 = new DataTable();
        //DataTable dt1 = new DataTable();
        //DataTable dt6 = new DataTable();
        //DataTable dt7 = new DataTable();

        //dt2 = Session["TablaPagar"] as DataTable;
        //String FchaInscripcionCon;
        //DateTime FechaPago;
        //string dateString = Convert.ToString(txtFechaPago.Text);
        //int NroCuotaCon;
        //int bcaIdCon;
        //FechaPago = DateTime.Parse(dateString);
        //int Bandera = 0;
        //decimal InteresCuotaAsignar = 0;
        //decimal InteresMensualAsignar = 0;
        //Decimal ValorInteres = 0;
        //string AplicaInteres;
        //decimal RecargoAbiertoAsignar = 0;
        //decimal InteresTotal = 0;
        //DateTime fchVtoAsignar = DateTime.Now;
        //LblMjeGridConcepto.Text = "";

        //foreach (DataRow row in dt2.Rows)
        //{
        //    int ValorSeleccionado;
        //    //obtengo incripcionConepto 
        //    dt9 = ocnInscripcionConcepto.ObtenerUno(Convert.ToInt32(row["icoId"].ToString()));
        //    int conId = Convert.ToInt32(row["conId"].ToString());
        //    dt3 = ocnConceptos.ObtenerUno(Convert.ToInt32(row["conId"].ToString()));
        //    DateTime UltVto;
        //    if (dt9.Rows.Count > 0) //Inscripcion Concepto Existe
        //    {
        //        FchaInscripcionCon = Convert.ToString(dt9.Rows[0]["FechaInscripcion"].ToString());
        //        NroCuotaCon = Convert.ToInt32(dt9.Rows[0]["NroCuota"].ToString());

        //        String BecaCon = Convert.ToString(dt9.Rows[0]["Becas"].ToString());

        //        //Busco si hay Vencimiento
        //        dt4 = ocnConceptosIntereses.ObtenerListaxconIdxNroCuota(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())), (Convert.ToInt32(row["NroCuota"].ToString())));

        //        Decimal ValorInteresCI = 0;
        //        DateTime FchaVtofila;
        //        int BanderaVto = 0;
        //        if (dt4.Rows.Count > 0)//Existe en la Tabla ConceptoIneres
        //        {
        //            String pFecha = "";
        //            pFecha = dt4.Rows[0]["FechaVto"].ToString();
        //            FchaVtofila = Convert.ToDateTime(dt4.Rows[0]["FechaVto"].ToString());//1° Vto
        //            int Ban = 0;
        //            int i = 0;
        //            while (i < dt4.Rows.Count && Ban == 0)
        //            {
        //                DataRow nextRow = dt4.Rows[i];
        //                DataRow row4 = dt4.Rows[i];
        //                FchaVtofila = Convert.ToDateTime(row4["FechaVto"].ToString());
        //                if (FchaVtofila >= FechaPago)
        //                {
        //                    Ban = 1;
        //                }
        //                fchVtoAsignar = Convert.ToDateTime(row4["FechaVto"].ToString());
        //                AplicaInteres = Convert.ToString(row4["AplicaInteres"].ToString());
        //                ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());

        //                if (ValorSeleccionado == 0) // Monto fijo
        //                {
        //                    if (Convert.ToDecimal(row4["ValorInteres"].ToString()) > 0)
        //                    {
        //                        if (AplicaInteres == "Si")// Se Cobra Interes
        //                        {

        //                            if (Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) > 0)
        //                            {
        //                                //ValorInteresCI = Math.Round((Convert.ToDecimal(row4["ValorInteres"].ToString()) * Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) / 100), 2);
        //                                ValorInteresCI = Math.Round(Convert.ToDecimal(row4["ValorInteres"].ToString()), 2);
        //                            }
        //                            else
        //                            {
        //                                ValorInteresCI = Convert.ToDecimal(row4["ValorInteres"].ToString());
        //                            }
        //                        }
        //                        else
        //                        {
        //                            ValorInteresCI = 0;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ValorInteresCI = 0;
        //                    }
        //                }
        //                else // Porcentaje
        //                {
        //                    if (Convert.ToDecimal(row4["ValorInteres"].ToString()) > 0)
        //                    {
        //                        if (AplicaInteres == "Si")// Se Cobra Interes
        //                        {
        //                            if (Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) > 0)
        //                            {
        //                                ValorInteresCI = Math.Round((Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row4["ValorInteres"].ToString()) / 100
        //                                    * Convert.ToDecimal(dt9.Rows[0]["BecInteres"].ToString()) / 100), 2);
        //                            }
        //                            else
        //                            {
        //                                ValorInteresCI = Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row4["ValorInteres"].ToString()) / 100;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            ValorInteresCI = 0;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ValorInteresCI = 0;
        //                    }
        //                }

        //                i = i + 1;
        //            }


        //            InteresCuotaAsignar = ValorInteresCI;
        //            RecargoAbiertoAsignar = 0;
        //            InteresMensualAsignar = 0;
        //            InteresTotal = ValorInteresCI;
        //            fchVtoAsignar = Convert.ToDateTime(FchaVtofila);
        //            BanderaVto = 1;

        //            DataTable dt12 = ocnConceptosIntereses.ObtenerUltimoVencimiento(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())), (Convert.ToInt32(row["NroCuota"].ToString())));
        //            if (dt12.Rows.Count > 0)
        //            {
        //                UltVto = Convert.ToDateTime(dt12.Rows[0]["FechaVto"].ToString());

        //                if (FechaPago > UltVto)
        //                {
        //                    Decimal InteresMensualIM;
        //                    Decimal InteresAplicar = 0;
        //                    Decimal ValorInteresRA = 0;
        //                    ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());
        //                    if (Convert.ToString(dt3.Rows[0]["TieneVtoAbierto"]) == "Si")
        //                    {

        //                        if (ValorSeleccionado == 0)// Interés con Monto Fijo
        //                        {
        //                            ValorInteresRA = Convert.ToDecimal(dt3.Rows[0]["RecargoVtoAbierto"].ToString());

        //                            if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
        //                            {
        //                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
        //                                InteresMensualIM = ((Convert.ToDecimal(dt3.Rows[0]["InteresMensual"]) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;

        //                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

        //                                InteresCuotaAsignar = ValorInteresCI;
        //                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                InteresMensualAsignar = InteresAplicar;
        //                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                            }
        //                            else
        //                            {
        //                                InteresCuotaAsignar = ValorInteresCI;
        //                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                InteresMensualAsignar = InteresAplicar;
        //                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                            }
        //                        }
        //                        else// Porcentaje
        //                        {
        //                            ValorInteresRA = (Convert.ToDecimal(dt3.Rows[0]["Importe"].ToString()) * Convert.ToDecimal(dt3.Rows[0]["RecargoVtoAbierto"].ToString())) / 100;

        //                            if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
        //                            {
        //                                //DateTime MesSiguienteVto = UltVto.AddDays(30);
        //                                //return Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
        //                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
        //                                //Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));
        //                                InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString()) + ValorInteresCI) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
        //                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

        //                                InteresCuotaAsignar = ValorInteresCI;
        //                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                InteresMensualAsignar = InteresAplicar;
        //                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                            }
        //                            else
        //                            {
        //                                InteresCuotaAsignar = ValorInteresCI;
        //                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                InteresMensualAsignar = InteresAplicar;
        //                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) != 0)
        //                        {
        //                            if (ValorSeleccionado == 0)// Interés con Monto Fijo
        //                            {
        //                                //DateTime MesSiguienteVto = UltVto.AddDays(30);

        //                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));

        //                                //Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));
        //                                //InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString()) + ValorInteresCI) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100; ;

        //                                InteresMensualIM = (Convert.ToDecimal(dt3.Rows[0]["conImporte"].ToString()) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100; ;
        //                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);


        //                                InteresCuotaAsignar = ValorInteresCI;
        //                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                InteresMensualAsignar = InteresAplicar;
        //                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                fchVtoAsignar = Convert.ToDateTime(UltVto);

        //                            }
        //                            else
        //                            {
        //                                //DateTime MesSiguienteVto = UltVto.AddDays(30);
        //                                //Decimal diff = Math.Abs((FechaPago.Month - MesSiguienteVto.Month) + 12 * (FechaPago.Year - MesSiguienteVto.Year));
        //                                Decimal diff = Math.Abs((FechaPago.Month - UltVto.Month) + 12 * (FechaPago.Year - UltVto.Year));
        //                                //InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString()) + ValorInteresCI) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100; ;

        //                                InteresMensualIM = ((Convert.ToDecimal(row["Importe"].ToString())) * Convert.ToDecimal(dt3.Rows[0]["InteresMensual"])) / 100;

        //                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);
        //                                RecargoAbiertoAsignar = ValorInteresRA;
        //                                InteresMensualAsignar = InteresAplicar;
        //                                InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                                fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            InteresCuotaAsignar = ValorInteresCI;
        //                            RecargoAbiertoAsignar = ValorInteresRA;
        //                            InteresMensualAsignar = 0;

        //                            InteresTotal = ValorInteresCI + ValorInteresRA + InteresAplicar;
        //                            fchVtoAsignar = Convert.ToDateTime(UltVto);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    DataRow row1 = dt.NewRow();
        //    row1["icoId"] = Convert.ToInt32(row["icoId"].ToString());
        //    row1["conId"] = Convert.ToInt32(row["conId"].ToString());
        //    row1["cntId"] = Convert.ToInt32(row["cntId"].ToString());
        //    row1["TipoConcepto"] = Convert.ToString(row["TipoConcepto"].ToString());
        //    row1["Concepto"] = Convert.ToString(row["Concepto"].ToString());
        //    row1["Importe"] = Convert.ToDecimal(row["Importe"].ToString());
        //    row1["InteresCuota"] = InteresCuotaAsignar;
        //    row1["RecargoAbierto"] = RecargoAbiertoAsignar;
        //    row1["InteresMensual"] = InteresMensualAsignar;
        //    row1["AnioLectivo"] = Convert.ToInt32(row["AnioLectivo"].ToString());
        //    row1["Beca"] = Convert.ToString(row["Beca"].ToString());
        //    row1["BecId"] = Convert.ToInt32(row["BecId"].ToString());
        //    row1["FchInscripcion"] = Convert.ToString(row["FchInscripcion"].ToString());
        //    row1["FechaVto"] = Convert.ToString(fchVtoAsignar);
        //    row1["NroCuota"] = Convert.ToInt32(row["NroCuota"].ToString());
        //    row1["Dcto"] = 0;
        //    row1["InteresTotal"] = InteresTotal;
        //    dt.Rows.Add(row1);
        //    Bandera = 1;

        //    txtInt = txtInt + InteresMensualAsignar;
        //}

        //GridConcepto.DataSource = dt;
        //GridConcepto.DataBind();
        //Session["GrillaFinal"] = dt;


        //if (dt.Rows.Count > 0)
        //{
        //    Decimal sumatoria = 0;// Saco TOTAL
        //                          //Decimal ImporteBecado = 0;
        //    Int32 BanderaBeca = 0;
        //    foreach (DataRow row in dt.Rows)
        //    {

        //        sumatoria += (Convert.ToDecimal(row["Importe"].ToString())) + (Convert.ToDecimal(row["InteresTotal"].ToString()));

        //    }

        //    lblSubTotal.Text = Convert.ToString(sumatoria);
        //    lblSaldo.Text = Convert.ToString(sumatoria);
        //}
    }



}
