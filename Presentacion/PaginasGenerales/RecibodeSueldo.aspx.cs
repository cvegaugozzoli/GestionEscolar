using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Threading;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using System.Diagnostics;


public partial class RecibodeSueldo : System.Web.UI.Page
{
    private ReportDocument cr = new ReportDocument();

    GESTIONESCOLAR.Negocio.RECIBOSSUELDO ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO();
    DataTable dt = new DataTable();

    int insId;
    string empCUIL;
    string banconombre = "";
    string lugaryfechapago = "";
    logic objectLogic = new logic();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                liqid.DataValueField = "Valor";
                liqid.DataTextField = "Texto";
                liqid.DataSource = objectLogic.ObtenerLiquidaciones("C");
                liqid.DataBind();

                this.Master.TituloDelFormulario = "Recibos de Sueldos Empleados";
                //String DNIUSUARIO = Convert.ToString(Session["_usuNombreIngreso"].ToString());
                aludni.Text = Convert.ToString(Session["_usuNombreIngreso"].ToString());
                aludni.Enabled = false;
                aluNombre.Text = Convert.ToString(Session["_usuApellido"].ToString()) + ", " + Convert.ToString(Session["_usuNombre"].ToString());
                aluNombre.Enabled = false;

                //GenerarPDF();
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



    private void CargarITS()
    {
        DataSet DS = new DataSet();
        Int32 liq_id = Convert.ToInt32(liqid.SelectedValue);

        DataTable DT1 = new DataTable();
        if (aludni.Text.Trim() == "")
        {
            aludni.Text = "0";
        }
        DT1 = objectLogic.TraerReciboDT(liq_id, aludni.Text.Trim());
        if (DT1.Rows.Count > 1)
        {
            try
            {
                DataTable dt = new DataTable();
                //ocnRECIBOSSUELDO.Eliminar();

                // Comentado provisoriamente 05/12/2024
                DataTable DT_Existe = new DataTable();
                DT_Existe = ocnRECIBOSSUELDO.ControlarSiExiste(liq_id, aludni.Text.Trim());

                Int64 empCUIT = 0;
                if (DT_Existe.Rows.Count == 0)
                {
                    dt.Columns.Add("ECLC_EMC_ID", typeof(Int32));
                    dt.Columns.Add("LUP_DESCRIPCION", typeof(String));
                    dt.Columns.Add("LUP_DIRECCION", typeof(String));
                    dt.Columns.Add("LUP_CUIT", typeof(String));
                    dt.Columns.Add("EMP_APELLIDO", typeof(String));
                    dt.Columns.Add("EMP_NOMBRE", typeof(String));
                    dt.Columns.Add("EMC_FEC_INI", typeof(DateTime));
                    dt.Columns.Add("EMP_DNI", typeof(String));
                    dt.Columns.Add("CON_DESCRIPCION", typeof(String));
                    dt.Columns.Add("LIQ_MES", typeof(Int32));
                    dt.Columns.Add("LIQ_ANIO", typeof(Int32));
                    dt.Columns.Add("ECL_IMPORTE", typeof(Decimal));
                    dt.Columns.Add("ECC_UNIDAD", typeof(Int32));
                    dt.Columns.Add("ECC_VALOR", typeof(Decimal));
                    dt.Columns.Add("ECL_VALOR", typeof(Int32));
                    dt.Columns.Add("CARGO_NOMBRE", typeof(String));
                    dt.Columns.Add("OBLIG_MENSUALES", typeof(Int32));
                    dt.Columns.Add("DIAS_HS_TRABAJADOS", typeof(Int32));
                    dt.Columns.Add("ANTIG_REC", typeof(Decimal));
                    dt.Columns.Add("DESCUENTOS", typeof(Decimal));
                    dt.Columns.Add("BRUTO", typeof(Decimal));
                    dt.Columns.Add("LIQUIDO", typeof(Decimal));
                    dt.Columns.Add("NIV_DESCRIPCION", typeof(String));
                    dt.Columns.Add("PLA_DESCRIPCION", typeof(String));
                    dt.Columns.Add("BONIFICA", typeof(Decimal));
                    dt.Columns.Add("DESCTO", typeof(Decimal));
                    dt.Columns.Add("LIQUIDO2", typeof(Decimal));
                    dt.Columns.Add("ECL_CANTIDAD", typeof(Decimal));
                    dt.Columns.Add("LIQ_LIT_ID", typeof(Int32));
                    dt.Columns.Add("CON_COC_ID", typeof(Int32));
                    dt.Columns.Add("ANT_TOTAL", typeof(String));
                    dt.Columns.Add("BAN_NOMBRE", typeof(String));
                    dt.Columns.Add("LIQ_FECHA_PAGO", typeof(String));
                    dt.Columns.Add("LIQ_ID", typeof(Int32));
                    dt.Columns.Add("ECLC_ID", typeof(Int32));
                    dt.Columns.Add("LIQ_DESCRIPCION", typeof(String));
                    //String empCUIT = ""; 
                    foreach (DataRow row in DT1.Rows)
                    {
                        DataRow row1 = dt.NewRow();

                        int Id = 0;
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO(Id);

                        empCUIL = row["EMP_DNI"].ToString();
                        //DT_Existe.Rows[0]["EMP_DNI"].ToString(); 
                        //= Convert.ToInt64(row["EMP_DNI"]); //row["EMP_DNI"].ToString();

                        ocnRECIBOSSUELDO.ECLC_EMC_ID = Convert.ToInt32(row["ECLC_EMC_ID"]);
                        ocnRECIBOSSUELDO.LUP_DESCRIPCION = row["LUP_DESCRIPCION"].ToString();
                        ocnRECIBOSSUELDO.LUP_DIRECCION = row["LUP_DIRECCION"].ToString();
                        ocnRECIBOSSUELDO.LUP_CUIT = row["LUP_CUIT"].ToString();
                        ocnRECIBOSSUELDO.EMP_APELLIDO = row["EMP_APELLIDO"].ToString();
                        ocnRECIBOSSUELDO.EMP_NOMBRE = row["EMP_NOMBRE"].ToString();
                        ocnRECIBOSSUELDO.EMC_FEC_INI = Convert.ToDateTime(row["EMC_FEC_INI"]);
                        ocnRECIBOSSUELDO.EMP_DNI = row["EMP_DNI"].ToString();
                        ocnRECIBOSSUELDO.CON_DESCRIPCION = row["CON_DESCRIPCION"].ToString();
                        ocnRECIBOSSUELDO.LIQ_MES = Convert.ToInt32(row["LIQ_MES"]);
                        ocnRECIBOSSUELDO.LIQ_ANIO = Convert.ToInt32(row["LIQ_ANIO"]);
                        ocnRECIBOSSUELDO.ECL_IMPORTE = FuncionesUtiles.StringToDecimal(row["ECL_IMPORTE"].ToString());
                        ocnRECIBOSSUELDO.ECC_UNIDAD = Convert.ToInt32(row["ECC_UNIDAD"]);
                        ocnRECIBOSSUELDO.ECC_VALOR = FuncionesUtiles.StringToDecimal(row["ECC_VALOR"].ToString());
                        ocnRECIBOSSUELDO.ECL_VALOR = Convert.ToInt32(row["ECL_VALOR"]);
                        ocnRECIBOSSUELDO.CARGO_NOMBRE = row["CARGO_NOMBRE"].ToString();
                        ocnRECIBOSSUELDO.OBLIG_MENSUALES = Convert.ToInt32(row["OBLIG_MENSUALES"]);
                        ocnRECIBOSSUELDO.DIAS_HS_TRABAJADOS = Convert.ToInt32(row["DIAS_HS_TRABAJADOS"]);
                        ocnRECIBOSSUELDO.ANTIG_REC = FuncionesUtiles.StringToDecimal(row["ANTIG_REC"].ToString());
                        ocnRECIBOSSUELDO.DESCUENTOS = FuncionesUtiles.StringToDecimal(row["DESCUENTOS"].ToString());
                        ocnRECIBOSSUELDO.BRUTO = FuncionesUtiles.StringToDecimal(row["BRUTO"].ToString());
                        ocnRECIBOSSUELDO.LIQUIDO = FuncionesUtiles.StringToDecimal(row["LIQUIDO"].ToString());
                        ocnRECIBOSSUELDO.NIV_DESCRIPCION = row["NIV_DESCRIPCION"].ToString();
                        ocnRECIBOSSUELDO.PLA_DESCRIPCION = row["PLA_DESCRIPCION"].ToString();
                        ocnRECIBOSSUELDO.BONIFICA = FuncionesUtiles.StringToDecimal(row["BONIFICA"].ToString());
                        ocnRECIBOSSUELDO.DESCTO = FuncionesUtiles.StringToDecimal(row["DESCTO"].ToString());
                        ocnRECIBOSSUELDO.LIQUIDO2 = FuncionesUtiles.StringToDecimal(row["LIQUIDO2"].ToString());
                        ocnRECIBOSSUELDO.ECL_CANTIDAD = FuncionesUtiles.StringToDecimal(row["ECL_CANTIDAD"].ToString());
                        ocnRECIBOSSUELDO.LIQ_LIT_ID = Convert.ToInt32(row["LIQ_LIT_ID"]);
                        ocnRECIBOSSUELDO.CON_COC_ID = Convert.ToInt32(row["CON_COC_ID"]);
                        ocnRECIBOSSUELDO.ANT_TOTAL = row["ANT_TOTAL"].ToString();
                        ocnRECIBOSSUELDO.BAN_NOMBRE = row["BAN_NOMBRE"].ToString();
                        ocnRECIBOSSUELDO.LIQ_FECHA_PAGO = Convert.ToDateTime(row["LIQ_FECHA_PAGO"]);
                        ocnRECIBOSSUELDO.LIQ_ID = Convert.ToInt32(row["LIQ_ID"]);
                        ocnRECIBOSSUELDO.ECLC_ID = Convert.ToInt32(row["ECLC_ID"]);
                        ocnRECIBOSSUELDO.LIQ_DESCRIPCION = row["LIQ_DESCRIPCION"].ToString();
                        ocnRECIBOSSUELDO.Insertar();

                        dt.Rows.Add(row1);

                    }
                }
                else
                {
                    empCUIL = DT_Existe.Rows[0]["EMP_DNI"].ToString();
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
        else
        {
            //No existe recibo de sueldo para ese empleado
        }

    }


    private void GenerarPDF()
    {
        string fileName = "RecibodeSueldo.pdf";  
        string ruta = "~/PaginasGenerales" + fileName;
        string filePath = Server.MapPath(fileName);

        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            // Crear el documento PDF
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();

            Int32 liq_id = Convert.ToInt32(liqid.SelectedValue);
            DataTable DT_ListarporCargo = new DataTable();
            DT_ListarporCargo = ocnRECIBOSSUELDO.MostrarporCargo(liq_id, aludni.Text.Trim());

            if (DT_ListarporCargo.Rows.Count > 0)
            {
                foreach (DataRow row in DT_ListarporCargo.Rows)
                {
                    Int32 ECLC_EMC_ID = Convert.ToInt32(row["ECLC_EMC_ID"].ToString()); // Convert.ToInt32(DT_ListarporCargo.Rows[0]["ECLC_EMC_ID"].ToString());
                    // Agregar contenido en formato de tabla
                    PdfPTable table = CrearTablaGrilla(ECLC_EMC_ID);
                    pdfDoc.Add(table);
                    //Nueva Página por cada cargo
                    pdfDoc.NewPage();
                }
            }
            // Cerrar el documento
            pdfDoc.Close();
        }
        
        // Descargar el archivo PDF
        //Response.ContentType = "application/pdf";
        //Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
        //Response.WriteFile(filePath);
        //Response.Redirect("../PaginasGenerales/RecibodeSueldo.pdf", false);

    }

    //Response.End();
    //string script = string.Format("<script>window.open(" + url + ", '_blank');</script>");
    //Response.Write(script);

    //string url = "https://obramisericordista.com.ar/PaginasGenerales/RecibodeSueldo.pdf"; // Genera tu URL aquí
    //string script = string.Format("<script>window.open(" + url + ", '_blank');</script>");
    //ClientScript.RegisterStartupScript(this.GetType(), "OpenNewTab", script, true);
    //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewTab", script, true);

    //string script = "window.open('https://obramisericordista.com.ar/PaginasGenerales/RecibodeSueldo.pdf', '_blank');";
    //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);




    //private PdfPTable CrearTablaEncabezado()
    //{
    //    PdfPTable tableE = new PdfPTable(3) // 3 columnas
    //    {
    //        WidthPercentage = 100,
    //        SpacingBefore = 5f,
    //        SpacingAfter = 5f
    //    };
    //    tableE.SetWidths(new float[] { 1, 8, 2 }); // Ancho relativo de columnas


    //    // Logo
    //    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/LogoChico.jpg"));
    //    logo.ScaleToFit(90f, 40f);
    //    PdfPCell logoCell = new PdfPCell(logo)
    //    {
    //        //Border = PdfPCell.NO_BORDER,
    //        HorizontalAlignment = Element.ALIGN_CENTER,
    //        VerticalAlignment = Element.ALIGN_MIDDLE,
    //        Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER
    //    };
    //    //header.AddCell(logoCell);

    //    logoCell.Rowspan = 3; // Indica que esta celda ocupará 2 filas
    //    logoCell.VerticalAlignment = Element.ALIGN_CENTER;
    //    logoCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
    //    logoCell.Padding= 5f;
    //    tableE.AddCell(logoCell);

    //    iTextSharp.text.Font dataFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
    //    iTextSharp.text.Font dataFont1 = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);

    //    ///
    //    PdfPCell Empresa = new PdfPCell(new Phrase("ASOCIACIÓN CIVIL DE HERMANOS MISERICORDISTAS", dataFont));
    //    PdfPCell EmpresaCell = new PdfPCell(Empresa)
    //    {
    //        //Border = PdfPCell.NO_BORDER,
    //        HorizontalAlignment = Element.ALIGN_LEFT,
    //        VerticalAlignment = Element.ALIGN_MIDDLE,
    //        Border = iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.TOP_BORDER
    //    };
    //    tableE.AddCell(EmpresaCell);
    //    ///


    //    ///
    //    PdfPCell RC = new PdfPCell(new Phrase("RECIBO DE HABERES", FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD)));
    //    PdfPCell RCCell = new PdfPCell(RC)
    //    {
    //        //Border = PdfPCell.NO_BORDER,
    //        HorizontalAlignment = Element.ALIGN_CENTER,
    //        VerticalAlignment = Element.ALIGN_MIDDLE,
    //    };
    //    RCCell.Rowspan = 3;
    //    tableE.AddCell(RCCell);
    //    ///

    //    ///
    //    PdfPCell Direccion = new PdfPCell(new Phrase("Dirección: Libertad 341", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
    //    PdfPCell DireccionCCell = new PdfPCell(Direccion)
    //    {
    //        Border = PdfPCell.NO_BORDER,
    //        HorizontalAlignment = Element.ALIGN_LEFT,
    //        VerticalAlignment = Element.ALIGN_MIDDLE,
    //        //Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER
    //    };
    //    //DireccionCCell.Rowspan = 3;
    //    tableE.AddCell(DireccionCCell);
    //    ///

    //    ///
    //    PdfPCell CUIT = new PdfPCell(new Phrase("CUIT: 30530322617", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
    //    PdfPCell CUITCCell = new PdfPCell(CUIT)
    //    {
    //        //Border = PdfPCell.NO_BORDER,
    //        HorizontalAlignment = Element.ALIGN_LEFT,
    //        VerticalAlignment = Element.ALIGN_MIDDLE,
    //        //Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER
    //        Border = iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER
    //    };
    //    //DireccionCCell.Rowspan = 3;
    //    tableE.AddCell(CUITCCell);
    //    ///

    //    return tableE;
    //}



    private PdfPTable CrearTablaGrilla(Int32 ECLC_EMC_ID)
    {
        PdfPTable table = new PdfPTable(4) // 3 columnas
        {
            WidthPercentage = 100,
            SpacingBefore = 20f,
            SpacingAfter = 20f
        };
        table.SetWidths(new float[] { 1, 5, 1, 1 }); // Ancho relativo de columnas

        // Estilo de la cabecera
        iTextSharp.text.Font dataFontEnc = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
        iTextSharp.text.Font headerFontEmp = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
        iTextSharp.text.Font headerFontTot = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        iTextSharp.text.Font headerFontTotWhite = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
        PdfPCell headerCell = new PdfPCell
        {
            BackgroundColor = BaseColor.DARK_GRAY,
            HorizontalAlignment = Element.ALIGN_CENTER,
            Padding = 10
        };

        iTextSharp.text.Font dataFont = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.Font dataFontTL = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD);

        Int32 liq_id = Convert.ToInt32(liqid.SelectedValue);
        DataTable DT_Listar = new DataTable();
        DT_Listar = ocnRECIBOSSUELDO.ListarLiquidacionporEmpleadoporCargo(liq_id, aludni.Text.Trim(), ECLC_EMC_ID);


        // Cabecera
        // Logo
        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/LogoChico.jpg"));
        logo.ScaleToFit(90f, 40f);
        PdfPCell logoCell = new PdfPCell(logo)
        {
            //Border = PdfPCell.NO_BORDER,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER
        };
        //header.AddCell(logoCell);

        logoCell.Rowspan = 3; // Indica que esta celda ocupará 2 filas
        logoCell.VerticalAlignment = Element.ALIGN_CENTER;
        logoCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
        logoCell.Padding = 5f;
        table.AddCell(logoCell);

        //iTextSharp.text.Font dataFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font dataFont1 = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);

        ///
        PdfPCell Empresa = new PdfPCell(new Phrase("ASOCIACIÓN CIVIL DE HERMANOS MISERICORDISTAS", dataFontEnc));
        PdfPCell EmpresaCell = new PdfPCell(Empresa)
        {
            //Border = PdfPCell.NO_BORDER,
            HorizontalAlignment = Element.ALIGN_LEFT,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            Border = iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.TOP_BORDER
        };
        table.AddCell(EmpresaCell);
        ///


        ///
        PdfPCell RC = new PdfPCell(new Phrase("RECIBO DE HABERES", FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD)));
        PdfPCell RCCell = new PdfPCell(RC)
        {
            //Border = PdfPCell.NO_BORDER,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE,
        };
        RCCell.Rowspan = 3;
        RCCell.Colspan = 2;
        table.AddCell(RCCell);
        ///

        ///
        PdfPCell Direccion = new PdfPCell(new Phrase("Dirección: Libertad 341 - CUIT: 30530322617", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
        PdfPCell DireccionCCell = new PdfPCell(Direccion)
        {
            Border = PdfPCell.NO_BORDER,
            HorizontalAlignment = Element.ALIGN_LEFT,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            //Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER
        };
        //DireccionCCell.Rowspan = 3;
        table.AddCell(DireccionCCell);
        ///

        ///
        PdfPCell CUIT = new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
        PdfPCell CUITCCell = new PdfPCell(CUIT)
        {
            //Border = PdfPCell.NO_BORDER,
            HorizontalAlignment = Element.ALIGN_LEFT,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            //Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER
            Border = iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER
        };
        //DireccionCCell.Rowspan = 3;
        table.AddCell(CUITCCell);
        /// End Cabecera


        if (DT_Listar.Rows.Count > 0)
        {
            string bonifica = "";
            string descto = "";

            decimal totalbonifica = 0;
            decimal totaldescto = 0;
            decimal Totalgrilla = 0;
            string numaletras = "";


            PdfPCell empCell = new PdfPCell
            {
                BackgroundColor = BaseColor.DARK_GRAY,
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 10,
                Colspan = 2
            };
            empCell.Phrase = new Phrase("EMPLEADO: " + DT_Listar.Rows[0]["APELLIDOYNOMBRE"].ToString(), headerFontEmp);
            empCell.Border = PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.BOTTOM_BORDER;
            table.AddCell(empCell);


            PdfPCell cuitempleadoCell = new PdfPCell
            {
                BackgroundColor = BaseColor.DARK_GRAY,
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 10,
                Colspan = 2
            };
            cuitempleadoCell.Phrase = new Phrase("CUIL: " + DT_Listar.Rows[0]["EMP_DNI"].ToString(), headerFontEmp);
            cuitempleadoCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cuitempleadoCell.Border = PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.BOTTOM_BORDER;
            table.AddCell(cuitempleadoCell);


            PdfPCell BlancoCell = new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            BlancoCell.Colspan = 4;
            BlancoCell.Border = PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER ;
            table.AddCell(BlancoCell);

            string cargo = "Cargo: " + DT_Listar.Rows[0]["CARGO_NOMBRE"].ToString();
            PdfPCell cargoCell = new PdfPCell(new Phrase(cargo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cargoCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER ;
            cargoCell.Colspan = 2;
            table.AddCell(cargoCell);

            ////////////
            string parametrosCUITyLiqId = empCUIL + "-" + liq_id.ToString();
            // Generar y agregar un código QR
            string qrData = "https://obramisericordista.com.ar/PaginasBasicas/RSVerificar.aspx?empCUIT=" + parametrosCUITyLiqId;

            var qrCodeImage = GenerarCodigoQR(qrData);
            iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(qrCodeImage, System.Drawing.Imaging.ImageFormat.Png);
            qrImage.ScaleToFit(110f, 110f);
            qrImage.Alignment = Element.ALIGN_CENTER;

            // Logo
            PdfPCell QRCell = new PdfPCell(qrImage)
            {
                //Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            QRCell.Rowspan = 5; // Indica que esta celda ocupará 5 filas
            QRCell.Colspan = 2;
            //QRCell.PaddingTop = 1f;
            //QRCell.PaddingBottom = 1f;
            QRCell.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
            table.AddCell(QRCell);

            ////////////  

            string periodo = "Periodo: " + DT_Listar.Rows[0]["LIQ_MES"].ToString() + " / " + DT_Listar.Rows[0]["LIQ_ANIO"].ToString();
            PdfPCell periodoCell = new PdfPCell(new Phrase(periodo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            periodoCell.Colspan = 3;
            periodoCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            table.AddCell(periodoCell);

            string ingreso = "Ingreso: " + DT_Listar.Rows[0]["EMC_FEC_INI"].ToString();
            PdfPCell ingresoCell = new PdfPCell(new Phrase(ingreso, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            ingresoCell.Colspan = 3;
            ingresoCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            table.AddCell(ingresoCell);

            string sitrevista = "Situación de Revista: " + DT_Listar.Rows[0]["PLA_DESCRIPCION"].ToString();
            PdfPCell srCell = new PdfPCell(new Phrase(sitrevista, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            srCell.Colspan = 3;
            srCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            table.AddCell(srCell);


            string anttotal = "Antiguedad Total: " + DT_Listar.Rows[0]["ANT_TOTAL"].ToString();
            PdfPCell atCell = new PdfPCell(new Phrase(anttotal, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            atCell.Colspan = 3;
            atCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            table.AddCell(atCell);

            PdfPCell BlancoCell1 = new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            BlancoCell1.Colspan = 4;
            BlancoCell1.Border = PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER ;
            table.AddCell(BlancoCell1);



            // Agregar celdas de cabecera
            headerCell.Phrase = new Phrase("Unidad", headerFont);
            table.AddCell(headerCell);
            headerCell.Phrase = new Phrase("Concepto", headerFont);
            table.AddCell(headerCell);
            headerCell.Phrase = new Phrase("Bonificación", headerFont);
            table.AddCell(headerCell);
            headerCell.Phrase = new Phrase("Descuento", headerFont);
            table.AddCell(headerCell);

            foreach (DataRow row in DT_Listar.Rows)
            {
                banconombre = "Banco Acreditación:" + row["BAN_NOMBRE"].ToString();
                lugaryfechapago = "Lugar y Fecha de Pago: Santiago del Estero, " + Convert.ToDateTime(row["LIQ_FECHA_PAGO"].ToString()).ToString("dd/MM/yyyy"); 
                bonifica = "";
                descto = "";
                if (row["BONIFICA"].ToString() != "0,00") { bonifica = row["BONIFICA"].ToString(); }
                if (row["DESCTO"].ToString() != "0,00") { descto = row["DESCTO"].ToString(); }
                table.AddCell(new PdfPCell(new Phrase(row["UNIDAD"].ToString(), dataFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(row["CON_DESCRIPCION"].ToString(), dataFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase(bonifica, dataFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase(descto, dataFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                //totalbonifica = totalbonifica + Convert.ToSingle(row["BONIFICA"].ToString());
                //totaldescto = totaldescto + Convert.ToSingle(row["DESCTO"].ToString());
                totalbonifica = totalbonifica + Convert.ToDecimal(row["BONIFICA"].ToString());
                totaldescto = totaldescto + Convert.ToDecimal(row["DESCTO"].ToString());
            }
            table.AddCell(new PdfPCell(new Phrase("", dataFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

            PdfPCell cellTotales= new PdfPCell(new Phrase("TOTALES", headerFontTot))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT, // Alineación horizontal    
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            cellTotales.PaddingTop = 5;
            cellTotales.PaddingBottom = 5;
            table.AddCell(cellTotales);

            PdfPCell cellTotBon = new PdfPCell(new Phrase(totalbonifica.ToString("F2"), dataFont))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT, // Alineación horizontal    
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            cellTotBon.PaddingTop = 5;
            cellTotBon.PaddingBottom = 5;
            table.AddCell(cellTotBon);

            PdfPCell cellTotDescto = new PdfPCell(new Phrase(totaldescto.ToString("F2"), dataFont))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT, // Alineación horizontal    
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            cellTotDescto.PaddingTop = 5;
            cellTotDescto.PaddingBottom = 5;
            table.AddCell(cellTotDescto);

            Totalgrilla = totalbonifica - totaldescto;

            Decimal TotalgrillaParteDecimal = (Totalgrilla - Convert.ToDecimal(Convert.ToInt32(Totalgrilla))) ;
            TotalgrillaParteDecimal = Math.Round(TotalgrillaParteDecimal, 2);  //TotalgrillaParteDecimal.ToString("F2");

            numaletras = "TOTAL EN LETRAS: " + NumberToWordsConverter.ConvertToWords(Convert.ToInt32(Totalgrilla)) ;
            string ParteDecimal = TotalgrillaParteDecimal.ToString();
            ParteDecimal = ParteDecimal.Substring(ParteDecimal.Length - 2);
            if (ParteDecimal != "00" )
            {
                numaletras = numaletras + " c/" + ParteDecimal;
            }
            PdfPCell cell = new PdfPCell(new Phrase(numaletras, headerFontTotWhite))
            {
                Colspan = 2, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_LEFT // Alineación horizontal                               
            };
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cell);

            PdfPCell cellNeto = new PdfPCell(new Phrase("Neto a Cobrar", headerFontTotWhite))
            {
                //Colspan = 2, // Combina dos columnas
                Border = PdfPCell.LEFT_BORDER | PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT // Alineación horizontal
            };
            cellNeto.PaddingTop = 5;
            cellNeto.PaddingBottom = 5;
            cellNeto.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cellNeto);

            PdfPCell cellTG = new PdfPCell(new Phrase(Totalgrilla.ToString(), headerFontTotWhite))
            {
                //Colspan = 2, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_RIGHT, // Alineación horizontal
                Border = PdfPCell.RIGHT_BORDER | PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER,
            };
            cellTG.PaddingTop = 5;
            cellTG.PaddingBottom = 5;
            cellTG.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cellTG);

            // Esta parte sería el Pie anterior

            PdfPCell cellEspacio = new PdfPCell(new Phrase(" ", dataFont))
            {
                Border = PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                Colspan = 4, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_LEFT // Alineación horizontal
            };
            table.AddCell(cellEspacio);


            PdfPCell cellBanco = new PdfPCell(new Phrase(banconombre, dataFont))
            {
                //Border = PdfPCell.NO_BORDER,
                Border = PdfPCell.LEFT_BORDER,
                Colspan = 2, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_LEFT // Alineación horizontal
            };
            table.AddCell(cellBanco);

            // Logo
            iTextSharp.text.Image logoFirma = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Imagenes/FirmaApoderadoLegal.jpg"));
            logoFirma.ScaleToFit(120f, 60f);
            PdfPCell logoFirmaCell = new PdfPCell(logoFirma)
            {
                //Border = PdfPCell.NO_BORDER,
                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER,
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            logoFirmaCell.Rowspan = 4; // Indica que esta celda ocupará 4 filas
            logoFirmaCell.VerticalAlignment = Element.ALIGN_CENTER;
            logoFirmaCell.PaddingTop = 5f;
            logoFirmaCell.PaddingBottom = 5f;
            table.AddCell(logoFirmaCell);

            PdfPCell celllugaryfechapago = new PdfPCell(new Phrase(lugaryfechapago, dataFont))
            {
                Border = PdfPCell.LEFT_BORDER,
                Colspan = 2, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_LEFT // Alineación horizontal
            };
            table.AddCell(celllugaryfechapago);

            DateTime fechaActual = DateTime.Now;
            string fechaimpresion = "Fecha de Impresión: " + fechaActual.ToString("dd/MM/yyyy");
            PdfPCell cellfechaimpresion = new PdfPCell(new Phrase(fechaimpresion, dataFont))
            {
                Border = PdfPCell.LEFT_BORDER,
                Colspan = 2, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_LEFT // Alineación horizontal
            };
            table.AddCell(cellfechaimpresion);

            PdfPCell cellLey = new PdfPCell(new Phrase("Recibo Leyes 17.250, 20.744 y 21.297", dataFont))
            {
                Border = PdfPCell.LEFT_BORDER | PdfPCell.BOTTOM_BORDER,
                Colspan = 2, // Combina dos columnas
                HorizontalAlignment = Element.ALIGN_LEFT // Alineación horizontal
            };
            table.AddCell(cellLey);


        }
        /////


        

        //Estilo de las celdas de datos
        //iTextSharp.text.Font dataFont = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL);
        //for (int i = 1; i <= 5; i++) // Ejemplo con 5 filas
        //{
        //    table.AddCell(new PdfPCell(new Phrase(i.ToString(), dataFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
        //    table.AddCell(new PdfPCell(new Phrase(string.Format("Descripción"), dataFont)) { PaddingLeft = 5 });
        //    //table.AddCell(new PdfPCell(new Phrase(string.Format("Descripción {i}"), dataFont)) { PaddingLeft = 5 });
        //    //table.AddCell(new PdfPCell(new Phrase(string.Format("${i * 100}"), dataFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
        //}

        return table;
    }


    //private PdfPTable CrearTablaPie()
    //{
    //    PdfPTable table1 = new PdfPTable(2) // 2 columnas
    //    {
    //        WidthPercentage = 100,
    //        SpacingBefore = 5f,
    //        SpacingAfter = 5f
    //    };

    //    iTextSharp.text.Font dataFont = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);

    //    table1.SetWidths(new float[] { 6, 3 }); // Ancho relativo de columnas
        
    //    table1.AddCell(new PdfPCell(new Phrase(banconombre, dataFont)) { HorizontalAlignment = Element.ALIGN_LEFT });


    //    // Logo
    //    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Imagenes/FirmaApoderadoLegal.jpg"));
    //    logo.ScaleToFit(120f, 60f);
    //    PdfPCell logoCell = new PdfPCell(logo)
    //    {
    //        //Border = PdfPCell.NO_BORDER,
    //        HorizontalAlignment = Element.ALIGN_CENTER,
    //        VerticalAlignment = Element.ALIGN_MIDDLE
    //    };
    //    //header.AddCell(logoCell);

    //    logoCell.Rowspan = 4; // Indica que esta celda ocupará 4 filas
    //    logoCell.VerticalAlignment = Element.ALIGN_CENTER;
    //    logoCell.PaddingTop = 5f;
    //    logoCell.PaddingBottom = 5f;
    //    table1.AddCell(logoCell);

    //    table1.AddCell(new PdfPCell(new Phrase(lugaryfechapago, dataFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
    //    DateTime fechaActual = DateTime.Now;
    //    string fechaimpresion = "Fecha de Impresión: " + fechaActual.ToString("dd/MM/yyyy");
    //    table1.AddCell(new PdfPCell(new Phrase(fechaimpresion, dataFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
    //    table1.AddCell(new PdfPCell(new Phrase("Recibo Leyes 17.250, 20.744 y 21.297", dataFont)) { HorizontalAlignment = Element.ALIGN_LEFT });


    //    // Celda que abarca 2 filas
    //    //PdfPCell cell = new PdfPCell(new Phrase("Fila Unida (Rowspan 2)"));
    //    //cell.Rowspan = 2; // Indica que esta celda ocupará 2 filas
    //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //    //table.AddCell(cell);


    //    return table1;
    //}


    private System.Drawing.Image GenerarCodigoQR(string data)
    {
        // Usar QRCoder para generar el código QR
        using (var qrGenerator = new QRCodeGenerator())
        {
            QRCodeData qrData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            using (var qrCode = new QRCoder.QRCode(qrData))
            {
                return qrCode.GetGraphic(20); // Factor de tamaño
            }
        }
    }


    public class CustomHeaderFooter : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {

            PdfPTable header = new PdfPTable(3)
            {
                WidthPercentage = 100
            };
            
            // Configura el ancho total de la tabla
            header.TotalWidth = document.PageSize.Width - 60; // Ajusta según el diseño
            header.LockedWidth = true; // Bloquea el ancho

            header.SetWidths(new float[] { 1, 6, 2 });

            // Logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/LogoChico.jpg"));
            logo.ScaleToFit(50f, 50f);

            PdfPCell logoCell = new PdfPCell(logo)
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_LEFT
            };
            header.AddCell(logoCell);

            // Título del encabezado
            PdfPCell titleCell = new PdfPCell(new Phrase("Recibo de Haberes" + writer.PageNumber, FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD)))
            {
                //Border = PdfPCell.NO_BORDER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };
            header.AddCell(titleCell);

            // Agregar encabezado al documento
            //float ooooo = document.PageSize.Height;

            ///header.WriteSelectedRows(1, 1, 30, document.PageSize.Height-20, writer.DirectContent);
            header.WriteSelectedRows(0, -1, 30, document.PageSize.Height - 20, writer.DirectContent);

            // Pie de página
            PdfPTable footer = new PdfPTable(1)
            {
                WidthPercentage = 100
            };

            footer.TotalWidth = document.PageSize.Width - 72; // Ajusta según el diseño
            footer.LockedWidth = true; // Bloquea el ancho para que no cambie


            footer.AddCell(new PdfPCell(new Phrase("Generado automáticamente - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.ITALIC)))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            //footer.SetWidths(new float[] { 1, 2 }); // Relación de 1:2 entre las columnas

            footer.WriteSelectedRows(0, -1, 36, 30, writer.DirectContent);
        }
    }


    public class NumberToWordsConverter
    {
        private static readonly string[] Units = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        private static readonly string[] Tens = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static readonly string[] Teens = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        private static readonly string[] Hundreds = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public static string ConvertToWords(int number)
        {
            if (number == 0) return "cero";
            if (number == 100) return "cien";
            if (number < 0) return "menos " + ConvertToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += ConvertToWords(number / 1000000) + " millón" + ((number / 1000000) > 1 ? "es " : " ");
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                if (number / 1000 == 1)
                    words += "mil ";
                else
                    words += ConvertToWords(number / 1000) + " mil ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += Hundreds[number / 100] + " ";
                number %= 100;
            }

            if ((number / 10) > 1)
            {
                words += Tens[number / 10] + " ";
                number %= 10;
            }

            if (number > 0)
            {
                if (words != "" && number < 10)
                    words += "y ";

                if (number < 10)
                    words += Units[number];
                else
                    words += Teens[number - 10];
            }

            return words.Trim();
        }
    }



    public class QRCodeHelper
    {
        public static string GenerarQRCode(string texto, string pathimagen)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                using (QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData))
                {
                    //string rutaLocalImagen = @"C:\Aplicativos\GestionEscolar\Presentacion\PaginasGenerales\codigoQR.png";
                    //string rutaLocalImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PaginasGenerales", "codigoQR.jpeg");

                    Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    // Guardar la imagen temporalmente
                    //qrCodeImage.Save(pathimagen, System.Drawing.Imaging.ImageFormat.Png);

                    using (var bitmap = new Bitmap(qrCodeImage, new Size(300, 300)))
                    {
                        qrCodeImage.Save(pathimagen, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    //Verifica si la imagen está lista
                    while (!File.Exists(pathimagen))
                    {
                        Thread.Sleep(100); // Espera un momento antes de continuar
                    }



                    return pathimagen; // Devolver la ruta de la imagen
                }
            }
        }
    }



    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        CargarITS();

        GenerarPDF();

        //Response.Redirect("../PaginasGenerales/RecibodeSueldo.pdf", false);

        // Generar URL con timestamp para evitar caché
        string url = "../PaginasGenerales/RecibodeSueldo.pdf?ts=" + DateTime.Now.Ticks;

        // Abrir el PDF en una nueva pestaña (más compatible y más limpio)
        string script = string.Format("window.open('{0}', '_blank');", url);
        ScriptManager.RegisterStartupScript(this, GetType(), "AbrirPDF", script, true);

    }
}


