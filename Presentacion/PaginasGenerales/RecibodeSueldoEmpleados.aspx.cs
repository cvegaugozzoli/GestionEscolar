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

public partial class RecibodeSueldoEmpleados : System.Web.UI.Page
{
    private ReportDocument cr = new ReportDocument();

    GESTIONESCOLAR.Negocio.RECIBOSSUELDO ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO();
    DataTable dt = new DataTable();

    int insId;

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

                //DataTable DT = new DataTable();
                //DT = objectLogic.getTraerEmpleadoporDNI(DNIUSUARIO);

                //DataSet DSE = new DataSet();

                //foreach (DataRow row in DT.Rows)
                //    if (DT.Rows.Count > 0)
                //    {
                //        //DataRow resultRow = DSE.Tables[1].NewRow();   //DSI.DataTable1.NewRow();

                //        aluNombre.Text = DT.Columns["EMP_NOMBRE"].ToString();
                //        aluNombre.Enabled = false;
                //        aludni.Text = DNIUSUARIO;
                //        aludni.Enabled = false;

                //    }
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




    private void Cargar()
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

                    //String empCUIT = ""; 
                    foreach (DataRow row in DT1.Rows)
                    {
                        DataRow row1 = dt.NewRow();

                        int Id = 0;
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO(Id);
                        empCUIT = Convert.ToInt64(row["EMP_DNI"]); //row["EMP_DNI"].ToString();

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
                        ocnRECIBOSSUELDO.Insertar();

                        dt.Rows.Add(row1);

                    }
                }
                else
                {
                    empCUIT = Convert.ToInt64(DT_Existe.Rows[0]["EMP_DNI"].ToString());
                }
                string parametrosCUITyLiqId = empCUIT.ToString() + "-" + liq_id.ToString();
                string textoParaQR = "";
                textoParaQR = "https://obramisericordista.com.ar/PaginasBasicas/RSVerificar.aspx?empCUIT=" + parametrosCUITyLiqId;

                // Llamo a rutina q crea la imágen con QR
                string nombreimagen = "codigoQR" + parametrosCUITyLiqId + ".png";
                string rutaLocalImagen = @"C:\Aplicativos\GestionEscolar\Presentacion\PaginasGenerales\" + nombreimagen;
                 
                string rutaQRCode = QRCodeHelper.GenerarQRCode(textoParaQR, rutaLocalImagen);
                //

                String Exporta = "0";
                String NomRep = "ReciboSueldo.rpt";
                FuncionesUtiles.AbreVentana("Reporte.aspx?empCUIT=" + empCUIT + "&liqid=" + liq_id + "&NomRep=" + NomRep + "&Exporta=" + Exporta + "&textoParaQR=" + textoParaQR + "&nombreimagen=" + nombreimagen);
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




    //public class QRCodeHelper
    //{
    //    public static string GenerarQRCode(string texto, string pathimagen)
    //    {
    //        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
    //        {
    //            QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
    //            using (QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData))
    //            {
    //                Bitmap qrCodeImage = qrCode.GetGraphic(20);

    //                // Guardar la imagen temporalmente
    //                //qrCodeImage.Save(pathimagen, System.Drawing.Imaging.ImageFormat.Png);
    //                qrCodeImage.Save(pathimagen, System.Drawing.Imaging.ImageFormat.Jpeg);

    //                return pathimagen; // Devolver la ruta de la imagen
    //            }
    //        }
    //    }
    //}






    //private void Cargar()
    //{
    //    DataSet DS = new DataSet();
    //    Int32 liq_id = Convert.ToInt32(liqid.SelectedValue);

    //    DataTable DT = new DataTable();
    //    if (aludni.Text.Trim() == "")
    //    {
    //        aludni.Text = "0";
    //    }
    //    DT = objectLogic.TraerReciboDT(liq_id, aludni.Text.Trim());

    //    DSInformes DSI = new DSInformes();

    //    foreach (DataRow row in DT.Rows)
    //    {
    //        DataRow resultRow = DSI.Table1.NewRow();
    //        resultRow["ECLC_EMC_ID"] = row["ECLC_EMC_ID"];
    //        resultRow["LUP_DESCRIPCION"] = row["LUP_DESCRIPCION"];
    //        resultRow["LUP_DIRECCION"] = row["LUP_DIRECCION"];
    //        resultRow["LUP_CUIT"] = row["LUP_CUIT"];
    //        resultRow["EMP_APELLIDO"] = row["EMP_APELLIDO"];
    //        resultRow["EMP_NOMBRE"] = row["EMP_NOMBRE"];
    //        resultRow["EMC_FEC_INI"] = row["EMC_FEC_INI"];
    //        resultRow["EMP_DNI"] = row["EMP_DNI"];
    //        resultRow["CON_DESCRIPCION"] = row["CON_DESCRIPCION"];
    //        resultRow["LIQ_MES"] = row["LIQ_MES"];
    //        resultRow["LIQ_ANIO"] = row["LIQ_ANIO"];
    //        resultRow["ECL_IMPORTE"] = row["ECL_IMPORTE"];
    //        resultRow["ECC_UNIDAD"] = row["ECC_UNIDAD"];
    //        resultRow["ECC_VALOR"] = row["ECC_VALOR"];
    //        resultRow["ECL_VALOR"] = row["ECL_VALOR"];
    //        resultRow["CARGO_NOMBRE"] = row["CARGO_NOMBRE"];
    //        resultRow["OBLIG_MENSUALES"] = row["OBLIG_MENSUALES"];
    //        resultRow["DIAS_HS_TRABAJADOS"] = row["DIAS_HS_TRABAJADOS"];
    //        resultRow["ANTIG_REC"] = row["ANTIG_REC"];
    //        resultRow["DESCUENTOS"] = row["DESCUENTOS"];
    //        resultRow["BRUTO"] = row["BRUTO"];
    //        resultRow["LIQUIDO"] = row["LIQUIDO"];
    //        resultRow["NIV_DESCRIPCION"] = row["NIV_DESCRIPCION"];
    //        resultRow["PLA_DESCRIPCION"] = row["PLA_DESCRIPCION"];
    //        resultRow["BONIFICA"] = row["BONIFICA"];
    //        resultRow["DESCTO"] = row["DESCTO"];
    //        resultRow["LIQUIDO2"] = row["LIQUIDO2"];
    //        resultRow["ECL_CANTIDAD"] = row["ECL_CANTIDAD"];
    //        resultRow["ANT_TOTAL"] = row["ANT_TOTAL"];

    //        DSI.Table1.Rows.Add(resultRow);
    //    }

    //    if (aludni.Text.Trim() != "0")
    //    {
    //        //string NomRep = "~/Reportes/CrystalReport.rpt";
    //        //string Ruta = MapPath(NomRep);  //System.Web.UI.Page.Server.MapPath(NomRep);
    //        //NomRep = Ruta;
    //        //ReportDocument reportDocument = new ReportDocument();

    //        //reportDocument.Load(NomRep);

    //        //reportDocument.SetDataSource(DT);

    //        ////// Mostrar el reporte en el ReportViewer
    //        //reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Page.Response, false, NomRep);
    //        //CrystalReportViewer1.ReportSource = reportDocument;
    //        //CrystalReportViewer1.RefreshReport();




    //        // Cargar el informe
    //        string NomRep = "~/Reportes/CrystalReport.rpt";
    //        ReportDocument reportDocument = new ReportDocument();

    //        string ppp = Server.MapPath(NomRep);
    //        reportDocument.Load(Server.MapPath(NomRep));


    //        // Configurar la conexión de la base de datos del informe
    //        ConnectionInfo connectionInfo = new ConnectionInfo
    //        {
    //            ServerName = "localhost",
    //            DatabaseName = "egestion",
    //            UserID = "root",
    //            Password = "mds2013"
    //        };


    //        // Aplica la conexión a cada tabla del informe
    //        foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDocument.Database.Tables)
    //        {
    //            TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
    //            tableLogOnInfo.ConnectionInfo = connectionInfo;
    //            table.ApplyLogOnInfo(tableLogOnInfo);
    //        }

    //        // Asigna el informe al visor
    //        //CrystalReportViewer1.ReportSource = reportDocument;
    //        //CrystalReportViewer1.Refresh();

    //    }
    //}



    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        Cargar();

        //MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionMYSQL"].ConnectionString.ToString());

        //// 1. Conectar a MySQL y llenar un DataSet
        //MySqlConnection connection = cn;
        //connection.Open();

        //string query = "SELECT * FROM your_table";
        //MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
        //DataSet ds = new DataSet();
        //adapter.Fill(ds);
        //connection.Close();

        //// 2. Vincular el DataSet a Crystal Reports
        //ReportDocument reportDoc = new ReportDocument();
        //reportDoc.Load("your_report.rpt");
        //reportDoc.SetDataSource(ds);

        //// 3. Mostrar el reporte (ejemplo para Windows Forms)
        ////crystalReportViewer1.ReportSource = reportDoc;

        //// 4. Exportar el reporte (ejemplo a PDF)
        //reportDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "my_report.pdf");


    }
}


