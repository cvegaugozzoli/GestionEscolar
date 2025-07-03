

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class FacturacionFormasPago : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Tarjetas ocnTarjetas = new GESTIONESCOLAR.Negocio.Tarjetas();
    GESTIONESCOLAR.Negocio.LugaresPago ocnLugaresPago = new GESTIONESCOLAR.Negocio.LugaresPago();
    GESTIONESCOLAR.Negocio.Bancos ocnBancos = new GESTIONESCOLAR.Negocio.Bancos();
    GESTIONESCOLAR.Negocio.FormasPago ocnFormasPago = new GESTIONESCOLAR.Negocio.FormasPago();
    GESTIONESCOLAR.Negocio.TarjetasPlanes ocnTarjetasPlanes = new GESTIONESCOLAR.Negocio.TarjetasPlanes();


    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Forma de Pago";
                Decimal ImporteaP = 0;
                if (Request.QueryString["Importe"] != null)
                {
                    ImporteaP = Convert.ToDecimal(Request.QueryString["Importe"]);
                    lblImporteaPagar.Text = Convert.ToString(ImporteaP);
                    lblSaldo.Text = lblImporteaPagar.Text;
                }
                LugarPagoId.DataValueField = "Valor"; LugarPagoId.DataTextField = "Texto"; LugarPagoId.DataSource = (new GESTIONESCOLAR.Negocio.LugaresPago()).ObtenerLista("[Seleccionar...]"); LugarPagoId.DataBind();
                FormaPagoId.DataValueField = "Valor"; FormaPagoId.DataTextField = "Texto"; FormaPagoId.DataSource = (new GESTIONESCOLAR.Negocio.FormasPago()).ObtenerLista("[Seleccionar...]"); FormaPagoId.DataBind();
                //BancoId.DataValueField = "Valor"; BancoId.DataTextField = "Texto"; BancoId.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); BancoId.DataBind();
                FchPago.Text = DateTime.Today;
                DataTable dt = new DataTable();
                dt.Columns.Add("IdLP", typeof(Int32));
                dt.Columns.Add("IdFP", typeof(Int32));
                dt.Columns.Add("FormaPago", typeof(String));
                dt.Columns.Add("Importe", typeof(Decimal));
                dt.Columns.Add("FchPago", typeof(DateTime));
                dt.Columns.Add("TarjetaId", typeof(Int32));
                dt.Columns.Add("Tarjeta", typeof(String));
                dt.Columns.Add("BancoId", typeof(Int32));
                dt.Columns.Add("Banco", typeof(String));
                dt.Columns.Add("Interes", typeof(String));
                dt.Columns.Add("ImpInteres", typeof(String));
                dt.Columns.Add("NroCta", typeof(String));
                dt.Columns.Add("NroCheque", typeof(String));
                dt.Columns.Add("PlanTarj", typeof(Int32));
                GrillaFormaPgo.DataSource = dt;
                GrillaFormaPgo.DataBind();
                Session["Facturar"] = dt;
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            Response.Redirect("FacturacionFormasPago.aspx?Id=" + Id);
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
        try
        {
            lblSaldo.Visible = true;
            lblSaldoTit.Visible = true;
            LblMjeGridFormaPago.Text = "";
            DataTable dt1 = ocnLugaresPago.ObtenerUno(Convert.ToInt32(LugarPagoId.SelectedValue));
            DataTable dt4 = ocnFormasPago.ObtenerUno(Convert.ToInt32(FormaPagoId.SelectedValue));
            DataTable dt8 = new DataTable();
            DataTable dt = new DataTable();
            dt = Session["Facturar"] as DataTable;


            if (LugarPagoId.SelectedValue != "0")
            {

                if (lblImporte.Text != "")
                {
                    if (FormaPagoId.SelectedValue != "0")
                    {
                        lblSaldo.Text = Convert.ToString((Convert.ToDouble(lblSaldo.Text) - (Convert.ToDouble(txtImporte.Text))));

                        btnConfirmar.Visible = true;
                        if (FormaPagoId.SelectedValue == "1")
                        {
                            DataRow row1 = dt.NewRow();

                            row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                            row1["IdFP"] = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                            row1["FormaPago"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                            row1["Importe"] = txtImporte.Text;
                            row1["FchPago"] = FchPago.Text;
                            row1["TarjetaId"] = 0;
                            row1["Tarjeta"] = "";
                            row1["BancoId"] = 0;
                            row1["Banco"] = "";
                            row1["Interes"] = "";
                            row1["ImpInteres"] = "";
                            row1["NroCta"] = "";
                            row1["NroCheque"] = "";
                            row1["PlanTarj"] = 0;
                            dt.Rows.Add(row1);
                        }
                        else
                        {
                            if (FormaPagoId.SelectedValue == "2")
                            {
                                DataTable dt2 = ocnTarjetas.ObtenerUno(Convert.ToInt32(General1Id.SelectedValue));
                                DataTable dt5 = ocnTarjetasPlanes.ObtenerUno(Convert.ToInt32(PlanesTarjetaId.SelectedValue));
                                DataRow row1 = dt.NewRow();


                                row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                                row1["IdFP"] = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                                row1["FormaPago"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                row1["Importe"] = txtImporte.Text;
                                row1["FchPago"] = FchPago.Text;
                                row1["TarjetaId"] = Convert.ToInt32(dt2.Rows[0]["Id"].ToString());
                                row1["Tarjeta"] = Convert.ToString(dt2.Rows[0]["Nombre"].ToString());
                                row1["BancoId"] = 0;
                                row1["Interes"] = txtGeneral2.Text;
                                row1["ImpInteres"] = txtGeneral3.Text;
                                row1["NroCheque"] = "";
                                row1["PlanTarj"] = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                                dt.Rows.Add(row1);
                            }
                            else
                            {
                                if (FormaPagoId.SelectedValue == "3")
                                {
                                    DataTable dt3 = ocnBancos.ObtenerUno(Convert.ToInt32(General1Id.SelectedValue));

                                    DataRow row1 = dt.NewRow();

                                    row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                                    row1["IdFP"] = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                                    row1["FormaPago"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                    row1["Importe"] = txtImporte.Text;
                                    row1["TarjetaId"] = 0;
                                    row1["Tarjeta"] = "";
                                    row1["FchPago"] = FchPago.Text;
                                    row1["BancoId"] = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                    row1["Banco"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                    row1["Interes"] = "";
                                    row1["ImpInteres"] = "";
                                    row1["NroCheque"] = txtGeneral2.Text;
                                    row1["PlanTarj"] = 0;

                                    dt.Rows.Add(row1);

                                }
                                if (FormaPagoId.SelectedValue == "4")
                                {
                                    DataTable dt3 = ocnBancos.ObtenerUno(Convert.ToInt32(General1Id.SelectedValue));

                                    DataRow row1 = dt.NewRow();
                                    row1["IdLP"] = Convert.ToInt32(dt1.Rows[0]["Id"].ToString());
                                    row1["IdFP"] = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                                    row1["FormaPago"] = Convert.ToString(dt4.Rows[0]["Nombre"].ToString());
                                    row1["Importe"] = txtImporte.Text;
                                    row1["FchPago"] = FchPago.Text;
                                    row1["TarjetaId"] = 0;
                                    row1["Tarjeta"] = "";
                                    row1["BancoId"] = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                    row1["Banco"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                    row1["Interes"] = "";
                                    row1["NroCta"] = txtGeneral2.Text;
                                    row1["NroCheque"] = "";
                                    row1["ImpInteres"] = "";
                                    row1["PlanTarj"] = 0;
                                    dt.Rows.Add(row1);

                                }
                            }
                        }
                        Session.Add("Facturar", dt);
                        dt8 = Session["Facturar"] as DataTable;
                        GrillaFormaPgo.DataSource = dt8;
                        GrillaFormaPgo.DataBind();

                    }
                    else
                    {
                        LblMjeGridFormaPago.Text = "Debe seleccionar Forma de Pago..";
                        FormaPagoId.Focus();
                    }
                }
                else
                {
                    LblMjeGridFormaPago.Text = "Debe ingresar Importe..";
                    lblImporte.Focus();
                }
            }
            else
            {
                LblMjeGridFormaPago.Text = "Debe ingresar Lugar de Pago..";
                lblImporte.Focus();
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

    protected void FormaPagoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtImporte.Text = "";
            txtGeneral2.Text = "";
            txtGeneral3.Text = "";
            btnAgregar.Enabled = true;
            btnAgregar.Visible = true;
            if (FormaPagoId.SelectedValue == "1")
            {
                lblImporte.Visible = true;
                txtImporte.Visible = true;
                General1Id.Visible = false;
                lbltexto1.Visible = false;
                lblTexto2.Visible = false;
                txtGeneral2.Visible = false;
                lblTexto3.Visible = false;
                txtGeneral3.Visible = false;
                lblTexto4.Visible = false;
                txtGeneral4.Visible = false;
                lblPlanes.Visible = false;
                PlanesTarjetaId.Visible = false;

            }
            if (FormaPagoId.SelectedValue == "2")
            {
                General1Id.DataValueField = "Valor"; General1Id.DataTextField = "Texto"; General1Id.DataSource = (new GESTIONESCOLAR.Negocio.Tarjetas()).ObtenerLista("[Seleccionar...]"); General1Id.DataBind();
                PlanesTarjetaId.DataValueField = "Valor"; PlanesTarjetaId.DataTextField = "Texto"; PlanesTarjetaId.DataSource = (new GESTIONESCOLAR.Negocio.TarjetasPlanes()).ObtenerLista("[Seleccionar...]"); PlanesTarjetaId.DataBind();

                lbltexto1.Text = "Tarjeta";
                lblTexto2.Text = "Interes %";
                lblTexto3.Text = "Importe Interés $";
                lblPlanes.Text = "Planes";
                lblPlanes.Visible = true;
                PlanesTarjetaId.Visible = true;
                General1Id.Visible = true;
                lbltexto1.Visible = true;
                lblTexto2.Visible = true;
                txtGeneral2.Visible = true;
                lblTexto3.Visible = true;
                txtGeneral3.Visible = true;
                lblTexto4.Visible = false;
                txtGeneral4.Visible = false;

            }
            else
            {
                if (FormaPagoId.SelectedValue == "3")
                {
                    General1Id.DataValueField = "Valor"; General1Id.DataTextField = "Texto"; General1Id.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); General1Id.DataBind();
                    lblImporte.Visible = true;
                    txtImporte.Visible = true;
                    lbltexto1.Text = "Banco";
                    lblTexto2.Text = "Número de Cheque";
                    General1Id.Visible = true;
                    lbltexto1.Visible = true;
                    lblTexto2.Visible = true;
                    txtGeneral2.Visible = true;
                    lblTexto3.Visible = false;
                    txtGeneral3.Visible = false;
                    lblTexto4.Visible = false;
                    txtGeneral4.Visible = false;
                    lblPlanes.Visible = false;
                    PlanesTarjetaId.Visible = false;
                }
                if (FormaPagoId.SelectedValue == "4")
                {
                    General1Id.DataValueField = "Valor"; General1Id.DataTextField = "Texto"; General1Id.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); General1Id.DataBind();
                    lblImporte.Visible = true;
                    txtImporte.Visible = true;
                    lbltexto1.Text = "Banco";
                    lblTexto2.Text = "Número de Cuenta";
                    General1Id.Visible = true;
                    lbltexto1.Visible = true;
                    lblTexto2.Visible = true;
                    txtGeneral2.Visible = true;
                    lblTexto3.Visible = false;
                    txtGeneral3.Visible = false;
                    lblTexto4.Visible = false;
                    txtGeneral4.Visible = false;
                    lblPlanes.Visible = false;
                    PlanesTarjetaId.Visible = false;
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

            int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;
            //int index = e.RowIndex;

            //int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["Facturar"] as DataTable;
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

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Facturacion.aspx", false);

    }

    protected void PlanesTarjetaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt5 = ocnTarjetasPlanes.ObtenerUnoxTarjeta(Convert.ToInt32(General1Id.SelectedValue));
        txtGeneral2.Text = Convert.ToString(dt5.Rows[0]["Interes"].ToString());
        txtGeneral3.Text = (Convert.ToString(Convert.ToDecimal(txtImporte.Text) + ((Convert.ToDecimal(txtImporte.Text) * (Convert.ToDecimal(txtGeneral2.Text)) / 100))));
    }
}

