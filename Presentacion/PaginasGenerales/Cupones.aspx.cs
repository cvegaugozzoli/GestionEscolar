
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Cupones : System.Web.UI.Page
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
                alerError2.Visible = false;
                lblMjerror2.Text = "";
                btnFacturar.Visible = false;
                txtFchPago.Visible = false;
                lblFchPago.Visible = false;
                this.Master.TituloDelFormulario = " Conceptos Adeudados";
                //insId = Convert.ToInt32(Session["_Institucion"]);

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);
                int ban = 0;
                Session["Bandera"] = ban;
                #region PageIndex
                int PageIndex = 0;
                int aluId1 = Convert.ToInt32(Request.QueryString["Id"]);
                //txtAnioLectivo.Text = Convert.ToString(DateTime.Today.Year);

                //ddlColegio.DataValueField = "Valor"; ddlColegio.DataTextField = "Texto";
                //ddlColegio.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); ddlColegio.DataBind();

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
                alerError2.Visible = false;

                if (this.Session["Cupones.PageIndex"] == null)
                {
                    Session.Add("Cupones.PageIndex", 0);
                }

                else
                {
                    PageIndex = Convert.ToInt32(Session["Cupones.PageIndex"]);
                }
                #endregion
                lblaluId.Text = "0";
                #region Variables de sesion para filtros
                //if (Session["LibroDisciplina.Nombre"] != null) { LibroDisciplina.Text = Session["LibroDisciplina.Nombre"].ToString(); } else { Session.Add("SexoConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion
                if (aluId1 != 0)
                {
                    lblaluId.Text = Convert.ToString(aluId1);
                    PageIndex = Convert.ToInt32(Session["Cupones.PageIndex"]);
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

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            alerError2.Visible = false;
            lblMjerror2.Text = "";
            btnFacturar.Visible = false;
            txtFchPago.Visible = false;
            lblFchPago.Visible = false;
            DataTable dt = new DataTable();
            dt.Columns.Add("icoId", typeof(int));
            dt.Columns.Add("conId", typeof(Int32));
            dt.Columns.Add("cntId", typeof(Int32));
            dt.Columns.Add("TipoConcepto", typeof(String));
            dt.Columns.Add("Concepto", typeof(String));
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
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
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

                                            int qq = 0;
                                            qq = ins_Id;
                                            //row1["insId"] = (Convert.ToInt32(dt2.Rows[0]["insId"].ToString()));
                                            row1["insId"] = ins_Id.ToString();
                                            row1["Colegio"] = Colegio;

                                            Bandera = 1;
                                            //dt.Rows.Add(row1);
                                        }

                                        else //Concepto no pagado
                                        {
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
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
                                            //row1["Colegio"] = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());
                                            //int qqq = 0;
                                            //qqq = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            // row1["insId"] = (Convert.ToInt32(dt3.Rows[0]["insId"].ToString()));
                                            row1["Colegio"] = Colegio;
                                            row1["insId"] = ins_Id.ToString();
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

                    dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2);
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

                                            dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
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
                                            Bandera = 1;
                                            //dt.Rows.Add(row1);
                                        }
                                        else
                                        {
                                            DataRow row1 = dt.NewRow();
                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                            row1["ImporteInteres"] = Convert.ToDecimal(row2["ValorInteres"].ToString());
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

                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
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
                            btnFacturar.Visible = true;
                            txtFchPago.Visible = true;
                            lblFchPago.Visible = true;
                            //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                            //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;

                        }
                    }
                }
            }
            else
            {
                alerError2.Visible = true;
                lblError2.Text = "No registra deuda para ese año";
                GrillaHistorial.DataSource = null;
                GrillaHistorial.DataBind();
            }
            //lblPagado.Visible = true;
            //lblVencido.Visible = true;
            //txtcELESTE.Visible = true;
            //txtRojo.Visible = true;

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
        AlumnoSeleccionado.Visible = false;
        alerErroBE.Visible = false;
        if (TextBuscar.Text != "")
        {
            if (txtAnioLectivo.Text != "")
            {
                dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    AlumnoSeleccionado.Visible = true;
                    aluNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"]);
                    aluNombre.Enabled = false;
                    aludni.Text = Convert.ToString(dt.Rows[0]["Doc"]);
                    aludni.Enabled = false;
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["Cupones.PageIndex"]);
                    String Id = Convert.ToString(dt.Rows[0]["Id"]);
                    lblaluId.Text = Id;
                    GrillaCargar(PageIndex);
                }
                else
                {
                    alerErroBE.Visible = true;
                    lblalerErroBE.Text = "No se encuentra Alumno con ese DNI";
                }
            }
            else
            {
                alerErroBE.Visible = true;
                lblalerErroBE.Text = "Debe ingresar Año Lectivo";
            }
        }
        else
        {
            alerErroBE.Visible = true;
            lblalerErroBE.Text = "Debe ingresar DNI del Alumno";
        }


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

            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.GrillaHistorial.DataKeys[rowIndex]["icoId"];
                //string Id = ((HyperLink)GrillaHistorial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                if (e.CommandName == "Pagar")
                {

                    alerError2.Visible = false;


                    //insId = Convert.ToInt32(Session["_Institucion"]);
                    lblMensajeError.Text = "";

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

                    AnioCursado = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["AnioLectivo"]);
                    //insId = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["InsId"]);
                    dt3 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, AnioCursado, Convert.ToInt32(lblaluId.Text));
                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    //FchaInscripcionCon = Convert.ToString(GrillaHistorial.DataKeys[row.RowIndex].Values["FchInscripcion"]);
                    //NroCuotaCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                    //bcaIdCon = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["BecasId"]);
                    DataRow row1 = dt.NewRow();
                    row1["icuId"] = icuId2;

                    row1["icoId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["icoId"]);
                    row1["cntId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["cntId"]);
                    row1["conId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["conId"]);
                    row1["TipoConcepto"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["TipoConcepto"]);
                    row1["Concepto"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["Concepto"]);
                    row1["Importe"] = Convert.ToDecimal(this.GrillaHistorial.DataKeys[rowIndex]["Importe"]);
                    row1["AnioLectivo"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["AnioLectivo"]);
                    row1["Beca"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["Beca"]);
                    row1["BecId"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["BecId"]);
                    row1["NroCuota"] = Convert.ToInt32(this.GrillaHistorial.DataKeys[rowIndex]["NroCuota"]);

                    row1["FchInscripcion"] = Convert.ToString(this.GrillaHistorial.DataKeys[rowIndex]["FchInscripcion"]);
                    dt.Rows.Add(row1);

                    Session.Add("TablaPagar", dt);
                }
                Response.Redirect("FacturarCupones.aspx?Id=" + icuId2, false);
            }
            else
            {
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


    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void btnFacturarClick(object sender, EventArgs e)
    {
        try
        {
            alerError2.Visible = false;
            if (txtFchPago.Text == "")
            {
                int CuotaUltPagada = 0;
                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
                    {
                        row.BackColor = System.Drawing.Color.LightBlue;
                        CuotaUltPagada = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                        ((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                    }

                    else
                    {
                        if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < DateTime.Today)
                        {
                            row.BackColor = System.Drawing.Color.FromName("#B81822");
                            row.ForeColor = System.Drawing.Color.White;
                            btnFacturar.Visible = true;
                            txtFchPago.Visible = true;
                            lblFchPago.Visible = true;
                            //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                            //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;

                        }
                    }
                }
                alerError2.Visible = true;
                lblError2.Text = "Debe ingresar una fecha de pago..";
                return;

            }

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
                DateTime FchPago = Convert.ToDateTime(txtFchPago.Text);
                Response.Redirect("FacturarCupones.aspx?Id=" + icuId2 + "&FchPago=" + FchPago, false);
            }
            else
            {
                int CuotaUltPagada = 0;
                foreach (GridViewRow row in GrillaHistorial.Rows)
                {
                    if (Convert.ToDecimal(GrillaHistorial.DataKeys[row.RowIndex].Values["ImpPagado"]) != 0)
                    {
                        row.BackColor = System.Drawing.Color.LightBlue;
                        CuotaUltPagada = Convert.ToInt32(GrillaHistorial.DataKeys[row.RowIndex].Values["NroCuota"]);
                        ((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                    }

                    else
                    {
                        if (Convert.ToDateTime(GrillaHistorial.DataKeys[row.RowIndex].Values["FechaVto"]) < DateTime.Today)
                        {
                            row.BackColor = System.Drawing.Color.FromName("#B81822");
                            row.ForeColor = System.Drawing.Color.White;
                            btnFacturar.Visible = true;
                            txtFchPago.Visible = true;
                            lblFchPago.Visible = true;
                            //CheckBox ck = (CheckBox)row.Cells[1].FindControl("chkSeleccion");
                            //(CheckBox)row.Cells[1].FindControl("chkSeleccion").Visible = false;

                        }
                    }
                }
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

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["Cupones.PageIndex"] != null)
            {
                Session["Cupones.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("Cupones.PageIndex", e.NewPageIndex);
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
}

