using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class FacturarCupones : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    this.ViewState["paginaorigen"] = Request.UrlReferrer.ToString();
                    this.Master.TituloDelFormulario = " Cupón de Pago";

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


                }

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["FacturarCupones.PageIndex"] == null)
                {
                    Session.Add("FacturarCupones.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["FacturarCupones.PageIndex"]);
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




    private void GrillaCargar(int PageIndex)
    {
        try
        {
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
            string dateString = Convert.ToString(Request.QueryString["FchPago"]);
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
                        FchaVtofila = Convert.ToDateTime(dt4.Rows[0]["FechaVto"].ToString());//1° Vto

                        if (FechaPago <= FchaVtofila) // Veo 1° Vencimiento asi no paga Interes
                        {
                            InteresCuotaAsignar = 0;
                            RecargoAbiertoAsignar = 0;
                            InteresMensualAsignar = 0;
                            InteresTotal = 0;
                            fchVtoAsignar = FchaVtofila;

                        }
                        else // Está atrasado, paga interés..
                        {
                            foreach (DataRow row4 in dt4.Rows)// Cant de vtos. para cada fila con fecha de vtos
                            {
                                FchaVtofila = Convert.ToDateTime(row4["FechaVto"].ToString());
                                if (FechaPago > FchaVtofila)
                                {

                                    fchVtoAsignar = Convert.ToDateTime(row4["FechaVto"].ToString());
                                    AplicaInteres = Convert.ToString(dt4.Rows[0]["AplicaInteres"].ToString());
                                    ValorSeleccionado = Convert.ToInt32(dt3.Rows[0]["ValorSeleccionado"].ToString());

                                    if (AplicaInteres == "Si")// Se Cobra Interes
                                    {
                                        ValorInteresCI = ValorInteresCI + Convert.ToDecimal(row4["ValorInteres"].ToString());
                                    }
                                    else
                                    {
                                        ValorInteresCI = 0;
                                    }

                                }
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

                                                InteresMensualIM = Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) * Convert.ToDecimal(diff);
                                                InteresAplicar = InteresMensualIM;

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

                                                InteresMensualIM = (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100;
                                                InteresAplicar = InteresMensualIM * Convert.ToDecimal(diff);

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

                                                InteresMensualIM = Convert.ToInt32(dt3.Rows[0]["InteresMensual"]) * Convert.ToDecimal(diff);
                                                InteresAplicar = InteresMensualIM;

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

                                                InteresMensualIM = (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToInt32(dt3.Rows[0]["InteresMensual"])) / 100;
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
                }

                DataRow row1 = dt.NewRow();
                row1["icoId"] = Convert.ToInt32(row["icoId"].ToString());
                row1["conId"] = Convert.ToInt32(row["conId"].ToString());
                row1["TipoConcepto"] = Convert.ToInt32(row["cntId"].ToString());
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
                row1["InteresTotal"] = InteresTotal;
                dt.Rows.Add(row1);
                Bandera = 1;
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
            if (Session["FacturarCupones.PageIndex"] != null)
            {
                Session["FacturarCupones.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("FacturarCupones.PageIndex", e.NewPageIndex);
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




    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep;
            Int32 icuId = Int32.Parse(lblicuId.Text);
            Int32 cocId = Int32.Parse(lblcocId.Text);

            NomRep = "InformeFactura.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?icuId=" + icuId + "&cocId=" + cocId + "&NomRep=" + NomRep);
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
        Response.Redirect((string)this.ViewState["paginaorigen"]);

    }
}
