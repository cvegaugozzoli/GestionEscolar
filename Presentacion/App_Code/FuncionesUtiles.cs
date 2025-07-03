using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using NPOI.HSSF.Model; // InternalWorkbook
using NPOI.HSSF.UserModel; // HSSFWorkbook, HSSFSheet
using NPOI.SS.UserModel;

using WebNPOI.Code.Repository;
using WebNPOI.Code.Domain;
using WebNPOI.Code.Service;
using System.Text;
using WebNPOI.Code.Crosscutting;


/// <summary>
/// Descripción breve de FuncionesUtiles
/// </summary>
public static class FuncionesUtiles
{
    private static string SeparadorDecimal = "";
    private static string NotSeparadorDecimal = "";

    static FuncionesUtiles()
    {
        SeparadorDecimal = System.Configuration.ConfigurationSettings.AppSettings["SeparadorDecimal"].ToString();

        if (SeparadorDecimal == ",")
        {
            NotSeparadorDecimal = ".";
        }
        else
        {
            NotSeparadorDecimal = ",";
        }
    }

    public static decimal StringToDecimal(string Valor)
    {
        return Convert.ToDecimal(Valor.Replace(NotSeparadorDecimal, SeparadorDecimal));
    }

    public static string DecimalToString(decimal Valor)
    {
        return Valor.ToString().Replace(",", ".");
    }

    /*public static void DataTableToExcel(DataTable dt, string ArchivoNombre)
    {
        HSSFWorkbook oExcel = new HSSFWorkbook();
        NPOI.SS.UserModel.ISheet Hoja;
        MemoryStream memoryStream = new MemoryStream();
        IRow FilaCabecera = Hoja.CreateRow(0);
        
        foreach (DataColumn Columna in dt.Columns)
        {
            FilaCabecera.CreateCell(Columna.Ordinal).SetCellValue(Columna.ColumnName);
        }

        int FilaIndice = 1;

        foreach (DataRow Fila in dt.Rows)
        {
            IRow FilaDato = Hoja.CreateRow(FilaIndice);

            foreach (DataColumn Columna in dt.Columns)
            {
                FilaDato.CreateCell(Columna.Ordinal).SetCellValue(Fila[Columna].ToString());
            }

            FilaIndice++;
        }

        oExcel.Write(memoryStream);
        memoryStream.Flush();

        HttpResponse response = HttpContext.Current.Response;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", ArchivoNombre));
        response.Clear();

        response.BinaryWrite(memoryStream.GetBuffer());
        response.End();
    }*/

    public static void ExportarAExcel(DataTable dt, string ArchivoNombre, Page Pagina)
    {
        try
        {
            WebNpoiService ser = new WebNpoiService();
            byte[] ba = ser.CreateExcel(dt, ArchivoNombre);

            Pagina.Response.Buffer = true;
            Pagina.Response.ContentType = "application/vnd.ms-excel";
            Pagina.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", ArchivoNombre));
            Pagina.Response.Charset = "UTF-8";
            Pagina.Response.ContentEncoding = Encoding.Default;
            Pagina.Response.OutputStream.Write(ba, 0, ba.Length);
            Pagina.Response.End();
        }
        catch (Exception oError)
        {
            throw oError;
        }
    }

    public static bool EsNumero(string s)
    {
        float output;
        return float.TryParse(s, out output);
    }

    public static void AbreVentana(String url)
    {
        //System.Web.UI.Page pagina = new System.Web.UI.Page();
        //pagina = HttpContext.Current.CurrentHandler();
        Page pagina = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterClientScriptBlock(pagina, typeof(string), "scr", "<script>window.open('" + url + "','popupwindow','location=no,toolbar=no,status=yes,menubar=no,scroll=yes,resizable=yes,directories=no');</script>", false); // registro script en scriptmanager (ajax)

    }



    public static void crearArchivoTxt(DataTable dt, String path, String nombreArchivo)
    {

        //DataRow drC;
        StreamWriter objStreamWriter;
        objStreamWriter = new StreamWriter(path + nombreArchivo);
        foreach (DataRow drC1 in dt.Rows)  /*TODO: cambiar el nombre de la variable*/
                                           //foreach (DataRow Fila in dt.Rows)
        {
            int i;
            for (i = 0; i < dt.Columns.Count; i++)
            {
                objStreamWriter.Write(drC1[i].ToString());
                objStreamWriter.Write("");
            }
            objStreamWriter.WriteLine();
        }
        objStreamWriter.Close();

        //Dim dr As Data.DataRow
        //Dim objStreamWriter As StreamWriter
        //objStreamWriter = New StreamWriter(path & nombreArchivo)
        //    For Each dr In dt.Rows
        //        Dim i As Integer
        //        For i = 0 To dt.Columns.Count - 1
        //            objStreamWriter.Write(dr.Item(i).ToString)
        //            objStreamWriter.Write("")
        //        Next
        //        objStreamWriter.WriteLine()
        //    Next
        //    objStreamWriter.Close()

    }


    public static void crearArchivoTxtenUbicacion(DataTable dt, String path, String nombreArchivo)
    {

        //DataRow drC;




        StreamWriter objStreamWriter;
        objStreamWriter = new StreamWriter(path + nombreArchivo);
        foreach (DataRow drC1 in dt.Rows)  /*TODO: cambiar el nombre de la variable*/
                                           //foreach (DataRow Fila in dt.Rows)
        {
            int i;
            for (i = 0; i < dt.Columns.Count; i++)
            {
                objStreamWriter.Write(drC1[i].ToString());
                objStreamWriter.Write("");
            }
            objStreamWriter.WriteLine();
        }
        objStreamWriter.Close();

        //Dim dr As Data.DataRow
        //Dim objStreamWriter As StreamWriter
        //objStreamWriter = New StreamWriter(path & nombreArchivo)
        //    For Each dr In dt.Rows
        //        Dim i As Integer
        //        For i = 0 To dt.Columns.Count - 1
        //            objStreamWriter.Write(dr.Item(i).ToString)
        //            objStreamWriter.Write("")
        //        Next
        //        objStreamWriter.WriteLine()
        //    Next
        //    objStreamWriter.Close()

    }



}