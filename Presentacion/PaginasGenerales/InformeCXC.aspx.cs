using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.DataVisualization.Charting;


public partial class InformeCXC : System.Web.UI.Page
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

    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
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

    protected void btnAplicar_Click1(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ConTipoId.SelectedValue) <= 0)
            {
                alerTipoConc.Visible = true;
                return;
            }


            insId = Convert.ToInt32(lblInsId.Text);
            dt = new DataTable();
            dt = ocnComprobantesDetalle.RecaudacionxInsxCuota(Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(CuotaIdD.SelectedValue), Convert.ToInt32(CuotaIdH.SelectedValue), Convert.ToInt32(txtAnioLectivo.Text));

            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.DataBind();
                int i;

                DataTable dt3 = new DataTable();
                dt3 = ocnComprobantesDetalle.RecaudacionxInsxCuotaTotal(Convert.ToInt32(ConTipoId.SelectedValue), Convert.ToInt32(CuotaIdD.SelectedValue), Convert.ToInt32(CuotaIdH.SelectedValue), Convert.ToInt32(txtAnioLectivo.Text));
                for (i = 0; i < Grilla.Rows.Count; i++)
                {
                    Decimal PAGARON = Convert.ToDecimal(Grilla.DataKeys[i].Values["CANTIDAD"]);
                    decimal DeberianHaberPagado = Convert.ToDecimal(dt3.Rows[i]["CANTIDADTOTAL"].ToString());

                    string total = String.Format("{0:#,##0.00}", Convert.ToDecimal(dt.Rows[i]["total"].ToString()));
                    string Porc = String.Format("{0:.##}", ((PAGARON) * 100) / DeberianHaberPagado);

                    string Morosidad = String.Format("{0:.##}", 100 - (((PAGARON) * 100) / DeberianHaberPagado));

                    Grilla.Rows[i].Cells[3].Text = total;
                    Grilla.Rows[i].Cells[4].Text = Porc;                    
                    Grilla.Rows[i].Cells[6].Text = Morosidad;
                    //Grilla.Rows[i].Cells[7].Text = Morosidad;
                }

                this.Chart1.Series.Clear();
                this.Chart1.Titles.Add("Recaudación");

                Series series = this.Chart1.Series.Add("Recaudación");
                series.ChartType = SeriesChartType.Column;
                this.Chart1.Palette = ChartColorPalette.EarthTones;

                for (i = 0; i < Grilla.Rows.Count; i++)
                {
                    string valorcol1 = Convert.ToString(Grilla.DataKeys[i].Values["InstNombre"]);
                    string valorcol2 = Convert.ToString(Grilla.DataKeys[i].Values["NivelNombre"]);

                    string valorcol4 = Grilla.Rows[i].Cells[4].Text;
                    series.Points.AddXY(valorcol1 + " " + valorcol2, Convert.ToDecimal(valorcol4));

                    //string valorcol5 = Grilla.Rows[i].Cells[5].Text;
                    //series.Points.AddXY(valorcol1 + " " + valorcol2, Convert.ToDecimal(valorcol5));

                }

                if (Chart1.Series["Recaudación"].Points.Count >= 8)
                {
                    Chart1.Series["Recaudación"].Points[0].Color = System.Drawing.Color.LightCoral;
                    Chart1.Series["Recaudación"].Points[1].Color = System.Drawing.Color.LightCoral;
                    Chart1.Series["Recaudación"].Points[2].Color = System.Drawing.Color.LightCoral;
                    Chart1.Series["Recaudación"].Points[3].Color = System.Drawing.Color.LightSteelBlue;
                    Chart1.Series["Recaudación"].Points[4].Color = System.Drawing.Color.LightGreen;
                    Chart1.Series["Recaudación"].Points[5].Color = System.Drawing.Color.LightGreen;
                    Chart1.Series["Recaudación"].Points[6].Color = System.Drawing.Color.LightSalmon;
                    Chart1.Series["Recaudación"].Points[7].Color = System.Drawing.Color.LightSkyBlue;
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

    protected void ConTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ConTipoId.SelectedValue) == 1)
        {
            lblCuotaD.Visible = false;
            CuotaIdD.Visible = false;
            lblCuotaH.Visible = false;
            CuotaIdH.Visible = false;
            CuotaIdD.SelectedValue = "1";
            CuotaIdH.SelectedValue = "1";
        }
        else
        {
            if (Convert.ToInt32(ConTipoId.SelectedValue) == 2)
            {
                lblCuotaD.Visible = true;
                CuotaIdD.Visible = true;
                lblCuotaH.Visible = true;
                CuotaIdH.Visible = true;
            }

        }
    }
}

