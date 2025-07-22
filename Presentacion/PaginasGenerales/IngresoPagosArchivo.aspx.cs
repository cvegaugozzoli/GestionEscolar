using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Data.OleDb;
using System.Linq;



public partial class IngresoPagosArchivo : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.DevPatagoniaImputar ocnDevPatagoniaImputar = new GESTIONESCOLAR.Negocio.DevPatagoniaImputar();

    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();
    GESTIONESCOLAR.Negocio.ComprobantesPtosVta ocnComprobantesPtosVta = new GESTIONESCOLAR.Negocio.ComprobantesPtosVta();
    GESTIONESCOLAR.Negocio.ComprobantesFormasPago ocnComprobantesFormasPago = new GESTIONESCOLAR.Negocio.ComprobantesFormasPago();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.TempImputaPagos ocnTempImputaPagos = new GESTIONESCOLAR.Negocio.TempImputaPagos();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.IntencionPagos ocnIntencionPagos = new GESTIONESCOLAR.Negocio.IntencionPagos();
    GESTIONESCOLAR.Negocio.Tarjetas ocnTarjetas = new GESTIONESCOLAR.Negocio.Tarjetas();
    GESTIONESCOLAR.Negocio.TarjetasPlanes ocnTarjetasPlanes = new GESTIONESCOLAR.Negocio.TarjetasPlanes();
    GESTIONESCOLAR.Negocio.PagosTarjetas ocnPagosTarjetas = new GESTIONESCOLAR.Negocio.PagosTarjetas();
    GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica ocnPagosTransferenciaElectronica = new GESTIONESCOLAR.Negocio.PagosTransferenciaElectronica();


    int insId;
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    string alu_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //insId = Convert.ToInt32(Session["_Institucion"]);
                this.Master.TituloDelFormulario = " Ingreso de Pagos";
                insId = Convert.ToInt32(Session["_Institucion"]);
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                dt = ocnUsuario.ObtenerUno(usuario);
                btnImputar.Visible = false;
                listado.Visible = false;
                int PageIndex = 0;
                if (this.Session["IngresoPagosArchivo.PageIndex"] == null)
                {
                    Session.Add("IngresoPagosArchivo.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["IngresoPagosArchivo.PageIndex"]);
                }
            }

        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        //}
        //catch { }

        try
        {
            int usuIdCreacion = this.Master.usuId;
            Int32 IdNew;
            String Concepto, Nombre, CodAlumno, Imputa, InstNombre, Curso, Observaciones;
            Decimal Importe;
            Int32 NroCuota;
            DateTime FechaPago;

            //Elimina todo el archivo si hubiera anteriormente una impresión
            ocnTempImputaPagos.EliminarTodo();

            if (BcoAdhId.SelectedValue == "1")
            {
                AlerInfo.Visible = true;
                foreach (GridViewRow row1 in GrillaCaja.Rows)
                {
                    CodAlumno = Convert.ToString(GrillaCaja.DataKeys[row1.RowIndex].Values["aluId"]);
                    Nombre = Convert.ToString(GrillaCaja.DataKeys[row1.RowIndex].Values["Nombre"]);
                    Concepto = Convert.ToString(GrillaCaja.DataKeys[row1.RowIndex].Values["Concepto"]);
                    NroCuota = Convert.ToInt32(GrillaCaja.DataKeys[row1.RowIndex].Values["NroCuota"]);
                    Importe = Convert.ToDecimal(GrillaCaja.DataKeys[row1.RowIndex].Values["Importe"]);
                    FechaPago = Convert.ToDateTime(GrillaCaja.DataKeys[row1.RowIndex].Values["FechaPago"]);
                    Imputa = Convert.ToString(GrillaCaja.DataKeys[row1.RowIndex].Values["Imputa"]);
                    Curso = Convert.ToString(GrillaCaja.DataKeys[row1.RowIndex].Values["Curso"]);
                    Observaciones = Convert.ToString(GrillaCaja.DataKeys[row1.RowIndex].Values["Observaciones"]);

                    InstNombre = lblColegio.Text;

                    //Insertar tabla temporal
                    IdNew = ocnTempImputaPagos.Insertar(Nombre, Concepto, Importe, NroCuota, FechaPago, Imputa, InstNombre, Curso, Observaciones);
                }
            }
            else
            {
                if (BcoAdhId.SelectedValue == "2")
                {
                    AlerInfo.Visible = true;
                    foreach (GridViewRow row1 in GridView1.Rows)
                    {
                        CodAlumno = Convert.ToString(GridView1.DataKeys[row1.RowIndex].Values["aluId"]);
                        Nombre = Convert.ToString(GridView1.DataKeys[row1.RowIndex].Values["Nombre"]);
                        Concepto = Convert.ToString(GridView1.DataKeys[row1.RowIndex].Values["Concepto"]);
                        NroCuota = Convert.ToInt32(GridView1.DataKeys[row1.RowIndex].Values["NroCuota"]);
                        Importe = Convert.ToDecimal(GridView1.DataKeys[row1.RowIndex].Values["Importe"]);
                        FechaPago = Convert.ToDateTime(GridView1.DataKeys[row1.RowIndex].Values["FechaPago"]);
                        Imputa = Convert.ToString(GridView1.DataKeys[row1.RowIndex].Values["Imputa"]);
                        Curso = Convert.ToString(GridView1.DataKeys[row1.RowIndex].Values["Curso"]);
                        Observaciones = Convert.ToString(GridView1.DataKeys[row1.RowIndex].Values["Observaciones"]);

                        InstNombre = lblColegio.Text;

                        //Insertar tabla temporal
                        IdNew = ocnTempImputaPagos.Insertar(Nombre, Concepto, Importe, NroCuota, FechaPago, Imputa, InstNombre, Curso, Observaciones);
                    }
                }
                else
                {
                    AlerInfo.Visible = false;
                    foreach (GridViewRow row1 in GrillaSiro.Rows)
                    {

                    }
                }
            }
            String NomRep;
            NomRep = "ListadoPagosArchivo.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?NomRep=" + NomRep);


        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    protected void Listar_Click(object sender, EventArgs e)
    {
        try
        {
            AlerExito.Visible = false;
            btnImprimir.Visible = false;
            btnImprimirSiro.Visible = false;
            DataTable dt1 = new DataTable();
            alerError.Visible = false;

            if (BcoAdhId.SelectedValue == "3")
            {
                Siro();
            }
            else
            {
                if (FileUpload1.HasFile)    //Verificar si el FileUpload con tiene un Archivo
                {
                    alerError.Visible = false;
                    //Colocar el nombre del Archivo en una Variable String
                    string filename = FileUpload1.FileName;

                    //Enviar el Archivo a un Directorio de forma Temporal
                    FileUpload1.SaveAs(Server.MapPath("/Uploads/" + filename));
                    String extArchivo = Path.GetExtension(Server.MapPath("/Uploads/" + filename));

                    if (BcoAdhId.SelectedValue == "1" & (extArchivo == ".xls" || extArchivo == ".xlsx"))
                    {
                        ExportToGrid(Server.MapPath("/Uploads/" + filename), Path.GetExtension(Server.MapPath("/Uploads/" + filename)), filename);
                    }
                    else
                    {
                        if (BcoAdhId.SelectedValue == "2") // & (extArchivo == ".txt")
                        {
                            ExportToGrid(Server.MapPath("/Uploads/" + filename), Path.GetExtension(Server.MapPath("/Uploads/" + filename)), filename);
                        }
                        else
                        {
                            alerError.Visible = true;
                            lblError.Text = "No coincide el Banco con la extenxión del archivo";
                            return;
                        }
                    }
                }

                else
                {
                    alerError.Visible = true;
                    lblError.Text = "Debe seleccionar un archivo..";
                    return;
                }
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    void ExportToGrid(String path, String Extension, String filename)



    {
        lblMensajeError.Text = "";
        listado.Visible = false;
        btnImputar.Visible = false;
        OleDbConnection MiConexion = null;
        DataSet DtSet = null;
        OleDbDataAdapter MiComando = null;

        DataTable dtI = new DataTable();
        string numCta = "";

        if (Extension == ".xls" || Extension == ".xlsx") // Archivo de Caja
        {
            lblLugarPago.Text = "2";
            if (Extension == ".xls")
            {
                //numCta = filename.Substring(0, filename.Length - 4);
                //numCta = filename.Substring(9, 3);
                //Conexion para Formato .xls 2003
                MiConexion = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + path + "';Extended Properties=Excel 8.0;");
            }

            else if (Extension == ".xlsx")
            {
                //numCta = filename.Substring(0, filename.Length - 5);
                //numCta = filename.Substring(9, 3);
                //Conexion para Formato .xlsx 2007 o 2010
                MiConexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0 Xml;");
            }

            // Busco el id de institución
            //dtI = ocnInstituciones.ObtenerUnoPorCodigo(numCta);
            //if (dtI.Rows.Count > 0)
            //{
            //    insId = Convert.ToInt32(dtI.Rows[0]["InsId"].ToString());
            //    lblColegio.Text = "Archivo de: " + Convert.ToString(dtI.Rows[0]["InsNombre"].ToString());


            //Seleccionar el archivo Excel
            MiConexion.Open();
            DataTable Datable = new DataTable();

            //Seleccionar la Hoja que Esta Activa
            Datable = MiConexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            String Nombre_Hoja = Datable.Rows[0]["TABLE_NAME"].ToString();


            MiComando = new System.Data.OleDb.OleDbDataAdapter("select * from [" + Nombre_Hoja + "]", MiConexion);
            DtSet = new System.Data.DataSet();
            //Bindear todo el Contenido del Excel a un Dataset
            MiComando.Fill(DtSet, "[" + Nombre_Hoja + "]");
            dt1 = DtSet.Tables[0];
            MiConexion.Close();
            //Verificar si el Datatable Contiene Valores
            numCta = "";

            if (dt1.Rows.Count > 0)
            {
                string CodBarraI = "";
                CodBarraI = Convert.ToString(dt1.Rows[0]["Cod# Barra"].ToString());  // Convert.ToString(row["Cod# Barra"].ToString());
                numCta = CodBarraI.Substring(1, 3);
                dtI = ocnInstituciones.ObtenerUnoPorCodigo(numCta);
                insId = Convert.ToInt32(dtI.Rows[0]["InsId"].ToString());
                lblColegio.Text = "Archivo de: " + Convert.ToString(dtI.Rows[0]["InsNombre"].ToString());
                lblColegioId.Text = Convert.ToString(dtI.Rows[0]["InsId"].ToString());
                GridView GridView2 = new GridView();
                GridView2.DataSource = dt1;
                GridView2.DataBind();
                Session["ArchivoImputar"] = dt1;
                //GridView1.DataSource = dt1;
                //GridView1.DataBind();
                //lblMensajeError.Text = "Cantidad de Cuentas a Actualizar: <b><font color=red>" + GridView2.Rows.Count.ToString() + "</font></b>";
                //Panel_Modificaciones.Controls.Add(GridView2);
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                dt2.Columns.Add("aluId", typeof(int));
                dt2.Columns.Add("icoId", typeof(Int32));
                dt2.Columns.Add("Nombre", typeof(String));
                dt2.Columns.Add("Concepto", typeof(String));
                dt2.Columns.Add("FechaPago", typeof(DateTime));
                dt2.Columns.Add("NroCuota", typeof(Int32));
                dt2.Columns.Add("Importe", typeof(Decimal));
                dt2.Columns.Add("NroComprobante", typeof(String));
                dt2.Columns.Add("Imputa", typeof(String));
                dt2.Columns.Add("Curso", typeof(String));
                dt2.Columns.Add("Observaciones", typeof(String));

                foreach (DataRow row in dt1.Rows)//para cada fila de excel           
                {
                    string CodBarra = "";
                    //insId = Convert.ToInt32(Session["_Institucion"]);
                    CodBarra = Convert.ToString(row["Cod# Barra"].ToString());

                    //string descripcion = Convert.ToString(row["Descripción"].ToString());
                    //int pos20 = descripcion.LastIndexOf("20");
                    //int Anoacademico = descripcion.Substring(10, 4);

                    String aluId = CodBarra.Substring(7, 5);
                    String nroCuota = CodBarra.Substring(12, 2);

                    string ImporteReal = "";
                    ImporteReal = CodBarra.Substring(18, 8).Trim();

                    //Single ImpReal = Convert.ToSingle(ImporteReal)/100;
                    Single ImpReal = Convert.ToSingle(ImporteReal) / 10; // Cambiar desde el 27/11/2024

                    //Cambiado desde 21-11-2024 para poder leer importes de más de 5 dígitos, eje 150.000
                    //string ImporteReal = CodBarra.Substring(18, 8).Trim();

                    DateTime FechaPago = Convert.ToDateTime(row["Fecha"].ToString());
                    //String Concepto = 
                    //if (aluId == "07909")
                    //{
                    //    String qqq;
                    //    qqq = "1";
                    //}

                    dt4 = ocnInscripcionConcepto.ObtenerUnoxInsxaluxcuotaximporte(insId, Convert.ToInt32(aluId), Convert.ToInt32(nroCuota), Convert.ToInt32(ImpReal));// obtengo inscripcion Cocepto que no exista en comprobante detalle

                    //dt3 = ocnConceptos.ObtenerUno(Convert.ToInt32(dt4.Rows[0]["conId"].ToString()));
                    DataRow row1 = dt2.NewRow();
                    if (dt4.Rows.Count > 0)
                    {
                        dt3 = ocnAlumno.ObtenerUno(Convert.ToInt32(aluId));

                        if (dt3.Rows.Count > 0)
                        {
                            int icoId = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                            row1["aluId"] = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                            row1["icoId"] = Convert.ToInt32(icoId);
                            row1["Nombre"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                            row1["Concepto"] = Convert.ToString(dt4.Rows[0]["Conceptos"].ToString());
                            row1["FechaPago"] = Convert.ToDateTime(row["Fecha"].ToString());
                            row1["NroCuota"] = Int32.Parse(nroCuota);
                            row1["Importe"] = Convert.ToDecimal(row["Importe"].ToString());
                            row1["NroComprobante"] = Convert.ToString(row["Cpbte#N°"].ToString());
                            row1["Imputa"] = "";
                            row1["Observaciones"] = "";
                            String pp;
                            pp = Convert.ToString(dt4.Rows[0]["Curso"].ToString());
                            row1["Curso"] = Convert.ToString(dt4.Rows[0]["Curso"].ToString());
                            dt2.Rows.Add(row1);

                            btnImputar.Enabled = true;
                        }
                    }
                    else
                    {
                        dt6 = ocnInscripcionConcepto.ObtenerUnoxInsxaluxcuotaximporteDetalle(insId, Convert.ToInt32(aluId), Convert.ToInt32(nroCuota), Convert.ToInt32(ImporteReal));// obtengo inscripcion Cocepto que  exista en comprobante detalle
                        dt3 = ocnAlumno.ObtenerUno(Convert.ToInt32(aluId));
                        if (dt6.Rows.Count > 0)
                        {
                            if (dt3.Rows.Count > 0)
                            {
                                int icoId = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());

                                row1["aluId"] = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                                row1["icoId"] = Convert.ToInt32(icoId);
                                row1["Nombre"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Conceptos"].ToString());
                                row1["FechaPago"] = Convert.ToDateTime(row["Fecha"].ToString());
                                row1["NroCuota"] = Int32.Parse(nroCuota);
                                row1["Importe"] = Convert.ToDecimal(row["Importe"].ToString());
                                row1["NroComprobante"] = Convert.ToString(row["Cpbte#N°"].ToString());
                                row1["Imputa"] = "";
                                row1["Observaciones"] = "";
                                String pp;
                                pp = Convert.ToString(dt6.Rows[0]["Curso"].ToString());
                                row1["Curso"] = Convert.ToString(dt6.Rows[0]["Curso"].ToString());
                                dt2.Rows.Add(row1);
                            }
                        }
                        else
                        {
                            //String qqq, ppp;
                            //qqq = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                            row1["aluId"] = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                            row1["icoId"] = 0;
                            row1["Nombre"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                            //row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Conceptos"].ToString());
                            //ppp = Convert.ToString(row["Concepto"].ToString());
                            //row1["Concepto"] = Convert.ToString(row["Concepto"].ToString());
                            row1["Concepto"] = "";
                            row1["FechaPago"] = Convert.ToDateTime(row["Fecha"].ToString());
                            row1["NroCuota"] = Int32.Parse(nroCuota);
                            row1["Importe"] = Convert.ToDecimal(row["Importe"].ToString());
                            row1["NroComprobante"] = Convert.ToString(row["Cpbte#N°"].ToString());
                            row1["Imputa"] = "NE";
                            row1["Observaciones"] = "NE";
                            dt2.Rows.Add(row1);
                        }
                    }
                }

                GrillaCaja.DataSource = dt2;
                GrillaCaja.DataBind();
                lblCantidadRegistros.Text = Convert.ToString(dt2.Rows.Count);
                listado.Visible = true;
                btnImputar.Visible = true;
                btnImprimir.Visible = true;
                GridView1.DataSource = null;
                GridView1.DataBind();
            }


            //Eliminar el Archivo Excel del Directorio Temporal
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            //Vaciar El Dataset y los Datatable
            dt1 = null;
            DtSet = null;
            Datable = null;
            //} else
            //{

            //}
        }
        else //Patagonia o Siro
        {
            if (BcoAdhId.SelectedValue == "2")
            {
                string insid = "0";
                lblLugarPago.Text = "3";
                string FileToRead = @path;
                using (StreamReader ReaderObject = new StreamReader(FileToRead))
                {
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    DataTable dt4 = new DataTable();
                    DataTable dt5 = new DataTable();
                    DataTable dt6 = new DataTable();
                    DataTable dt7 = new DataTable();
                    dt2.Columns.Add("aluId", typeof(int));
                    dt2.Columns.Add("icoId", typeof(Int32));
                    dt2.Columns.Add("Nombre", typeof(String));
                    dt2.Columns.Add("Concepto", typeof(String));
                    dt2.Columns.Add("FechaPago", typeof(DateTime));
                    dt2.Columns.Add("NroCuota", typeof(Int32));
                    dt2.Columns.Add("Importe", typeof(Decimal));
                    dt2.Columns.Add("NroComprobante", typeof(String));
                    dt2.Columns.Add("Imputa", typeof(String));
                    dt2.Columns.Add("Curso", typeof(String));
                    dt2.Columns.Add("adeCBU", typeof(String));
                    dt2.Columns.Add("Observaciones", typeof(String));
                    dt2.Columns.Add("insid", typeof(Int32));
                    string Line;

                    String FechaPago = "";
                    DateTime fecha = DateTime.Now;
                    String FechaPagofinal = "";
                    // ReaderObject reads a single line, stores it in Line string variable and then displays it on
                    // console
                    while ((Line = ReaderObject.ReadLine()) != null)
                    {
                        Char PL = Line[0];

                        if (PL == 'H')
                        {
                            FechaPago = Line.Substring(25, 8);
                            fecha = DateTime.ParseExact(FechaPago, "ddMMyyyy", System.Globalization.CultureInfo.CurrentCulture);
                            FechaPagofinal = fecha.ToString("dd/MM/yyyy");
                        }
                        if (PL == 'D')
                        {
                            String aluIdS = Line.Substring(34, 7);
                            int aluIdNum = Convert.ToInt32(aluIdS.TrimStart(new Char[] { '0' }));
                            if (aluIdNum == 8987)
                            {
                                int wwww = 0;
                            }
                            String numCuotaS = Line.Substring(89, 2);
                            int numCuotaNum = Convert.ToInt32(numCuotaS.TrimEnd(new Char[] { ' ' }));

                            int AnioCursado = DateTime.Now.Year;

                            DataTable dtConcepto = new DataTable();
                            Decimal ImporteReal = 0;
                            dtConcepto = ocnInscripcionConcepto.ObtenerImporteRealPat(aluIdNum, numCuotaNum, 2, AnioCursado); // 2 es el tipo de concepto (CUOTA)
                            if (dtConcepto.Rows.Count > 0)
                            {
                                ImporteReal = Convert.ToDecimal(dtConcepto.Rows[0]["Importe"].ToString());
                            }

                            //dtConcepto = ocnConceptos.ob(aluIdNum, numCuotaNum, Convert.ToDecimal(ImporteRealNum), AnioCursado);// obtengo inscripcion Cocepto que no exista en comprobante detalle


                            string ImporteDebitado = Line.Substring(104, 10);
                            Decimal ImporteRealNum = Convert.ToDecimal(ImporteDebitado.TrimStart(new Char[] { '0' })) / 100;

                            //dt4 = ocnInscripcionConcepto.ObtenerUnoxaluxcuotaximportePat(aluIdNum, numCuotaNum, Convert.ToDecimal(ImporteRealNum), AnioCursado);// obtengo inscripcion Cocepto que no exista en comprobante detalle
                            dt4 = ocnInscripcionConcepto.ObtenerUnoxaluxcuotaximportePat(aluIdNum, numCuotaNum, Convert.ToDecimal(ImporteReal), AnioCursado);// obtengo inscripcion Cocepto que no exista en comprobante detalle

                            //dt3 = ocnConceptos.ObtenerUno(Convert.ToInt32(dt4.Rows[0]["conId"].ToString()));
                            DataRow row1 = dt2.NewRow();
                            if (dt4.Rows.Count > 0)
                            {
                                insid = Convert.ToString(dt4.Rows[0]["insId"].ToString());
                                //lblColegioId.Text = Convert.ToString(dt4.Rows[0]["insId"].ToString());
                                dt3 = ocnAlumno.ObtenerUno(Convert.ToInt32(aluIdNum));

                                if (dt3.Rows.Count > 0)
                                {
                                    int icoId = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                                    row1["aluId"] = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                                    row1["icoId"] = Convert.ToInt32(icoId);
                                    row1["Nombre"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                    row1["Concepto"] = Convert.ToString(dt4.Rows[0]["Conceptos"].ToString());
                                    row1["FechaPago"] = Convert.ToDateTime(FechaPagofinal);
                                    row1["NroCuota"] = numCuotaNum;
                                    row1["Importe"] = ImporteRealNum;
                                    row1["NroComprobante"] = "";
                                    row1["Imputa"] = "";
                                    String pp;
                                    pp = Convert.ToString(dt4.Rows[0]["Curso"].ToString());
                                    row1["Curso"] = Convert.ToString(dt4.Rows[0]["Curso"].ToString());
                                    row1["adeCBU"] = Convert.ToString(dt4.Rows[0]["adeCBU"].ToString());
                                    row1["insid"] = insid;
                                    String Observ = Line.Substring(151, 3);

                                    btnImputar.Enabled = true;
                                    //if (Observ == "")
                                    //{
                                    //    row1["Observaciones"] = "";
                                    //}
                                    //else
                                    //{
                                    //    row1["Observaciones"] = Observ;
                                    //}

                                    if (Observ == "   " || Observ == "")
                                    {
                                        row1["Observaciones"] = Observ;
                                    }
                                    else
                                    {
                                        if (Observ == "R02")
                                        {
                                            row1["Observaciones"] = "Cuenta cerrada";
                                            row1["Importe"] = 0;
                                        }
                                        else
                                        {
                                            if (Observ == "R03")
                                            {
                                                row1["Observaciones"] = "Cuenta inexistente";
                                                row1["Importe"] = 0;
                                            }
                                            else
                                            {
                                                if (Observ == "R04")
                                                {
                                                    row1["Observaciones"] = "Número de cuenta inválido";
                                                    row1["Importe"] = 0;
                                                }
                                                else
                                                {
                                                    if (Observ == "R08")
                                                    {
                                                        row1["Observaciones"] = "Orden de no pagar";
                                                        row1["Importe"] = 0;
                                                    }
                                                    else
                                                    {
                                                        if (Observ == "R10")
                                                        {
                                                            row1["Observaciones"] = "Falta de fondos";
                                                            row1["Importe"] = 0;
                                                        }
                                                        else
                                                        {
                                                            if (Observ == "R14")
                                                            {
                                                                row1["Observaciones"] = "Identificación del cliente en la empresa errónea";
                                                                row1["Importe"] = 0;
                                                            }
                                                            else
                                                            {
                                                                if (Observ == "R15")
                                                                {
                                                                    row1["Observaciones"] = "Baja del servicio";
                                                                    row1["Importe"] = 0;
                                                                }
                                                                else
                                                                {
                                                                    if (Observ == "R17")
                                                                    {
                                                                        row1["Observaciones"] = "Error de formato";
                                                                        row1["Importe"] = 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Observ == "R19")
                                                                        {
                                                                            row1["Observaciones"] = "Importe erróneo";
                                                                            row1["Importe"] = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Observ == "R20")
                                                                            {
                                                                                row1["Observaciones"] = "Moneda distinta a la de la cuenta de débito";
                                                                                row1["Importe"] = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Observ == "R23")
                                                                                {
                                                                                    row1["Observaciones"] = "Sucursal no habilitada";
                                                                                    row1["Importe"] = 0;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Observ == "R24")
                                                                                    {
                                                                                        row1["Observaciones"] = "Transacción duplicada";
                                                                                        row1["Importe"] = 0;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Observ == "R25")
                                                                                        {
                                                                                            row1["Observaciones"] = "Error en registro adicional";
                                                                                            row1["Importe"] = 0;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (Observ == "R26")
                                                                                            {
                                                                                                row1["Observaciones"] = "Error por campo mandatario";
                                                                                                row1["Importe"] = 0;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (Observ == "R28")
                                                                                                {
                                                                                                    row1["Observaciones"] = "Rechazo primer vencimiento";
                                                                                                    row1["Importe"] = 0;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (Observ == "R29")
                                                                                                    {
                                                                                                        row1["Observaciones"] = "Reversión ya efectuada";
                                                                                                        row1["Importe"] = 0;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (Observ == "R79")
                                                                                                        {
                                                                                                            row1["Observaciones"] = "Error en campo 7 Registro Individual ";
                                                                                                            row1["Importe"] = 0;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (Observ == "R80")
                                                                                                            {
                                                                                                                row1["Observaciones"] = "Error en campo 3 Registro Adicional ";
                                                                                                                row1["Importe"] = 0;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (Observ == "R86")
                                                                                                                {
                                                                                                                    row1["Observaciones"] = "Identificación de la empresa errónea";
                                                                                                                    row1["Importe"] = 0;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (Observ == "R90")
                                                                                                                    {
                                                                                                                        row1["Observaciones"] = "TRX no corresponde por no existir TRX original";
                                                                                                                        row1["Importe"] = 0;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (Observ == "R91")
                                                                                                                        {
                                                                                                                            row1["Observaciones"] = "Código banco incompatible con moneda de TRX";
                                                                                                                            row1["Importe"] = 0;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (Observ == "R93")
                                                                                                                            {
                                                                                                                                row1["Observaciones"] = "Día no laborable";
                                                                                                                                row1["Importe"] = 0;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (Observ == "R95")
                                                                                                                                {
                                                                                                                                    row1["Observaciones"] = "Reversión de entidad receptora presentada fuera de término";
                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (Observ == "R13")
                                                                                                                                    {
                                                                                                                                        row1["Observaciones"] = "Entidad destino inexistente";
                                                                                                                                        row1["Importe"] = 0;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (Observ == "R18")
                                                                                                                                        {
                                                                                                                                            row1["Observaciones"] = "Fecha de compensación errónea";
                                                                                                                                            row1["Importe"] = 0;
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (Observ == "R27")
                                                                                                                                            {
                                                                                                                                                row1["Observaciones"] = "Error en contador de registro";
                                                                                                                                                row1["Importe"] = 0;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (Observ == "R31")
                                                                                                                                                {
                                                                                                                                                    row1["Observaciones"] = "Vuelta atrás de Cámara";
                                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (Observ == "R75")
                                                                                                                                                    {
                                                                                                                                                        row1["Observaciones"] = "Fecha inválida";
                                                                                                                                                        row1["Importe"] = 0;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (Observ == "R76")
                                                                                                                                                        {
                                                                                                                                                            row1["Observaciones"] = "Error en campo 11 Cabecera de Lote ";
                                                                                                                                                            row1["Importe"] = 0;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (Observ == "R77")
                                                                                                                                                            {
                                                                                                                                                                row1["Observaciones"] = "Error en campo 4 Registro Individual";
                                                                                                                                                                row1["Importe"] = 0;
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (Observ == "R78")
                                                                                                                                                                {
                                                                                                                                                                    row1["Observaciones"] = "Error en campo 5 Registro Individual";
                                                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (Observ == "R87")
                                                                                                                                                                    {
                                                                                                                                                                        row1["Observaciones"] = "Error en campo 9 Registro Individual 1er byte ";
                                                                                                                                                                        row1["Importe"] = 0;
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (Observ == "R88")
                                                                                                                                                                        {
                                                                                                                                                                            row1["Observaciones"] = "Error en campo 2 Registro Individual";
                                                                                                                                                                            row1["Importe"] = 0;
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (Observ == "R89")
                                                                                                                                                                            {
                                                                                                                                                                                row1["Observaciones"] = "Errores transacciones no monetarias";
                                                                                                                                                                                row1["Importe"] = 0;
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }


                                    dt2.Rows.Add(row1);
                                }
                            }
                            else
                            {
                                dt6 = ocnInscripcionConcepto.ObtenerUnoxaluxcuotaximporteDetallePat(Convert.ToInt32(aluIdNum), numCuotaNum, ImporteReal, AnioCursado);// obtengo inscripcion Cocepto que  exista en comprobante detalle
                                                                                                                                                                      //lblColegioId.Text = Convert.ToString(dt6.Rows[0]["insId"].ToString());  Modificado el 11062024                            
                                dt3 = ocnAlumno.ObtenerUno(Convert.ToInt32(aluIdNum));
                                if (dt6.Rows.Count > 0)
                                {
                                    insid = Convert.ToString(dt6.Rows[0]["insId"].ToString());
                                    if (dt3.Rows.Count > 0)
                                    {
                                        int icoId = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                        DataTable dtComdet = new DataTable();
                                        dtComdet = ocnComprobantesDetalle.ObtenerUnoxicoId(icoId);
                                        int fdp = 0;
                                        if (dtComdet.Rows.Count > 0)
                                        {
                                            DataTable dtComfp = new DataTable();
                                            dtComfp = ocnComprobantesFormasPago.ObtenerTodoxcdeId(Convert.ToInt32(dtComdet.Rows[0]["Id"].ToString()));
                                            if (dtComfp.Rows.Count > 0)
                                            {
                                                fdp = Convert.ToInt32(dtComfp.Rows[0]["fopId"].ToString());
                                            }
                                        }
                                        row1["aluId"] = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                                        row1["icoId"] = Convert.ToInt32(icoId);
                                        row1["Nombre"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                        row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Conceptos"].ToString());
                                        row1["FechaPago"] = Convert.ToDateTime(FechaPagofinal);
                                        row1["NroCuota"] = numCuotaNum;
                                        row1["Importe"] = ImporteRealNum;
                                        row1["NroComprobante"] = "";
                                        row1["insid"] = insid;
                                        if (fdp == 3)
                                        {
                                            row1["Imputa"] = "E";
                                        }
                                        else
                                        {
                                            row1["Imputa"] = "DFP";
                                        }

                                        //row1["Imputa"] = "E";
                                        row1["adeCBU"] = Convert.ToString(dt6.Rows[0]["adeCBU"].ToString());
                                        row1["Observaciones"] = "";
                                        String pp;
                                        pp = Convert.ToString(dt6.Rows[0]["Curso"].ToString());
                                        row1["Curso"] = Convert.ToString(dt6.Rows[0]["Curso"].ToString());
                                        String Observ = Line.Substring(151, 3);

                                        btnImputar.Enabled = false;
                                        //if (Observ == "")
                                        //{
                                        //    row1["Observaciones"] = "";
                                        //}
                                        //else
                                        //{
                                        //    row1["Observaciones"] = Observ;
                                        //}

                                        if (Observ == "   " || Observ == "")
                                        {
                                            row1["Observaciones"] = Observ;
                                        }
                                        else
                                        {
                                            if (Observ == "R02")
                                            {
                                                row1["Observaciones"] = "Cuenta cerrada";
                                                row1["Importe"] = 0;
                                            }
                                            else
                                            {
                                                if (Observ == "R03")
                                                {
                                                    row1["Observaciones"] = "Cuenta inexistente";
                                                    row1["Importe"] = 0;
                                                }
                                                else
                                                {
                                                    if (Observ == "R04")
                                                    {
                                                        row1["Observaciones"] = "Número de cuenta inválido";
                                                        row1["Importe"] = 0;
                                                    }
                                                    else
                                                    {
                                                        if (Observ == "R08")
                                                        {
                                                            row1["Observaciones"] = "Orden de no pagar";
                                                            row1["Importe"] = 0;
                                                        }
                                                        else
                                                        {
                                                            if (Observ == "R10")
                                                            {
                                                                row1["Observaciones"] = "Falta de fondos";
                                                                row1["Importe"] = 0;
                                                            }
                                                            else
                                                            {
                                                                if (Observ == "R14")
                                                                {
                                                                    row1["Observaciones"] = "Identificación del cliente en la empresa errónea";
                                                                    row1["Importe"] = 0;
                                                                }
                                                                else
                                                                {
                                                                    if (Observ == "R15")
                                                                    {
                                                                        row1["Observaciones"] = "Baja del servicio";
                                                                        row1["Importe"] = 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Observ == "R17")
                                                                        {
                                                                            row1["Observaciones"] = "Error de formato";
                                                                            row1["Importe"] = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Observ == "R19")
                                                                            {
                                                                                row1["Observaciones"] = "Importe erróneo";
                                                                                row1["Importe"] = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Observ == "R20")
                                                                                {
                                                                                    row1["Observaciones"] = "Moneda distinta a la de la cuenta de débito";
                                                                                    row1["Importe"] = 0;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Observ == "R23")
                                                                                    {
                                                                                        row1["Observaciones"] = "Sucursal no habilitada";
                                                                                        row1["Importe"] = 0;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Observ == "R24")
                                                                                        {
                                                                                            row1["Observaciones"] = "Transacción duplicada";
                                                                                            row1["Importe"] = 0;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (Observ == "R25")
                                                                                            {
                                                                                                row1["Observaciones"] = "Error en registro adicional";
                                                                                                row1["Importe"] = 0;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (Observ == "R26")
                                                                                                {
                                                                                                    row1["Observaciones"] = "Error por campo mandatario";
                                                                                                    row1["Importe"] = 0;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (Observ == "R28")
                                                                                                    {
                                                                                                        row1["Observaciones"] = "Rechazo primer vencimiento";
                                                                                                        row1["Importe"] = 0;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (Observ == "R29")
                                                                                                        {
                                                                                                            row1["Observaciones"] = "Reversión ya efectuada";
                                                                                                            row1["Importe"] = 0;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (Observ == "R79")
                                                                                                            {
                                                                                                                row1["Observaciones"] = "Error en campo 7 Registro Individual ";
                                                                                                                row1["Importe"] = 0;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (Observ == "R80")
                                                                                                                {
                                                                                                                    row1["Observaciones"] = "Error en campo 3 Registro Adicional ";
                                                                                                                    row1["Importe"] = 0;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (Observ == "R86")
                                                                                                                    {
                                                                                                                        row1["Observaciones"] = "Identificación de la empresa errónea";
                                                                                                                        row1["Importe"] = 0;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (Observ == "R90")
                                                                                                                        {
                                                                                                                            row1["Observaciones"] = "TRX no corresponde por no existir TRX original";
                                                                                                                            row1["Importe"] = 0;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (Observ == "R91")
                                                                                                                            {
                                                                                                                                row1["Observaciones"] = "Código banco incompatible con moneda de TRX";
                                                                                                                                row1["Importe"] = 0;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (Observ == "R93")
                                                                                                                                {
                                                                                                                                    row1["Observaciones"] = "Día no laborable";
                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (Observ == "R95")
                                                                                                                                    {
                                                                                                                                        row1["Observaciones"] = "Reversión de entidad receptora presentada fuera de término";
                                                                                                                                        row1["Importe"] = 0;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (Observ == "R13")
                                                                                                                                        {
                                                                                                                                            row1["Observaciones"] = "Entidad destino inexistente";
                                                                                                                                            row1["Importe"] = 0;
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (Observ == "R18")
                                                                                                                                            {
                                                                                                                                                row1["Observaciones"] = "Fecha de compensación errónea";
                                                                                                                                                row1["Importe"] = 0;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (Observ == "R27")
                                                                                                                                                {
                                                                                                                                                    row1["Observaciones"] = "Error en contador de registro";
                                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (Observ == "R31")
                                                                                                                                                    {
                                                                                                                                                        row1["Observaciones"] = "Vuelta atrás de Cámara";
                                                                                                                                                        row1["Importe"] = 0;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (Observ == "R75")
                                                                                                                                                        {
                                                                                                                                                            row1["Observaciones"] = "Fecha inválida";
                                                                                                                                                            row1["Importe"] = 0;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (Observ == "R76")
                                                                                                                                                            {
                                                                                                                                                                row1["Observaciones"] = "Error en campo 11 Cabecera de Lote ";
                                                                                                                                                                row1["Importe"] = 0;
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (Observ == "R77")
                                                                                                                                                                {
                                                                                                                                                                    row1["Observaciones"] = "Error en campo 4 Registro Individual";
                                                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (Observ == "R78")
                                                                                                                                                                    {
                                                                                                                                                                        row1["Observaciones"] = "Error en campo 5 Registro Individual";
                                                                                                                                                                        row1["Importe"] = 0;
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (Observ == "R87")
                                                                                                                                                                        {
                                                                                                                                                                            row1["Observaciones"] = "Error en campo 9 Registro Individual 1er byte ";
                                                                                                                                                                            row1["Importe"] = 0;
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (Observ == "R88")
                                                                                                                                                                            {
                                                                                                                                                                                row1["Observaciones"] = "Error en campo 2 Registro Individual";
                                                                                                                                                                                row1["Importe"] = 0;
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                if (Observ == "R89")
                                                                                                                                                                                {
                                                                                                                                                                                    row1["Observaciones"] = "Errores transacciones no monetarias";
                                                                                                                                                                                    row1["Importe"] = 0;
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        dt2.Rows.Add(row1);
                                    }
                                }
                                else
                                {
                                    // Aplicar cambios para 2025 cuando ingresamos por esta opción

                                    //String insidN = Convert.ToString(dt3.Rows[0]["insId"].ToString());
                                    String uuu = Convert.ToString(dt3.Rows[0]["Id"].ToString());

                                    //insid = Convert.ToString(dt6.Rows[0]["insId"].ToString());
                                    //String qqq, ppp;
                                    //qqq = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                    row1["aluId"] = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                                    row1["icoId"] = 0;
                                    row1["Nombre"] = Convert.ToString(dt3.Rows[0]["Nombre"].ToString());
                                    //row1["Concepto"] = Convert.ToString(dt6.Rows[0]["Conceptos"].ToString());
                                    //ppp = Convert.ToString(row["Concepto"].ToString());
                                    //row1["Concepto"] = Convert.ToString(row["Concepto"].ToString());
                                    row1["Concepto"] = "";
                                    row1["FechaPago"] = Convert.ToDateTime(FechaPagofinal);
                                    row1["NroCuota"] = numCuotaNum;
                                    row1["Importe"] = "0";
                                    row1["NroComprobante"] = "";
                                    //row1["adeCBU"] = Convert.ToString(dt3.Rows[0]["adeCBU"].ToString());
                                    row1["adeCBU"] = Convert.ToString(dt2.Rows[0]["adeCBU"].ToString());
                                    row1["Imputa"] = "NE";
                                    String Observ = Line.Substring(151, 3);
                                    //if (Observ == "")
                                    //{
                                    //    row1["Observaciones"] = "";
                                    //}
                                    //else
                                    //{
                                    //    row1["Observaciones"] = Observ;
                                    //}
                                    if (Observ == "   " || Observ == "")
                                    {
                                        row1["Observaciones"] = Observ;
                                    }
                                    else
                                    {
                                        if (Observ == "R02")
                                        {
                                            row1["Observaciones"] = "Cuenta cerrada";
                                        }
                                        else
                                        {
                                            if (Observ == "R03")
                                            {
                                                row1["Observaciones"] = "Cuenta inexistente";
                                            }
                                            else
                                            {
                                                if (Observ == "R04")
                                                {
                                                    row1["Observaciones"] = "Número de cuenta inválido";
                                                }
                                                else
                                                {
                                                    if (Observ == "R08")
                                                    {
                                                        row1["Observaciones"] = "Orden de no pagar";
                                                    }
                                                    else
                                                    {
                                                        if (Observ == "R10")
                                                        {
                                                            row1["Observaciones"] = "Falta de fondos";
                                                        }
                                                        else
                                                        {
                                                            if (Observ == "R14")
                                                            {
                                                                row1["Observaciones"] = "Identificación del cliente en la empresa errónea";
                                                            }
                                                            else
                                                            {
                                                                if (Observ == "R15")
                                                                {
                                                                    row1["Observaciones"] = "Baja del servicio";
                                                                }
                                                                else
                                                                {
                                                                    if (Observ == "R17")
                                                                    {
                                                                        row1["Observaciones"] = "Error de formato";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Observ == "R19")
                                                                        {
                                                                            row1["Observaciones"] = "Importe erróneo";
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Observ == "R20")
                                                                            {
                                                                                row1["Observaciones"] = "Moneda distinta a la de la cuenta de débito";
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Observ == "R23")
                                                                                {
                                                                                    row1["Observaciones"] = "Sucursal no habilitada";
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Observ == "R24")
                                                                                    {
                                                                                        row1["Observaciones"] = "Transacción duplicada";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Observ == "R25")
                                                                                        {
                                                                                            row1["Observaciones"] = "Error en registro adicional";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (Observ == "R26")
                                                                                            {
                                                                                                row1["Observaciones"] = "Error por campo mandatario";
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (Observ == "R28")
                                                                                                {
                                                                                                    row1["Observaciones"] = "Rechazo primer vencimiento";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (Observ == "R29")
                                                                                                    {
                                                                                                        row1["Observaciones"] = "Reversión ya efectuada";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (Observ == "R79")
                                                                                                        {
                                                                                                            row1["Observaciones"] = "Error en campo 7 Registro Individual ";
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (Observ == "R80")
                                                                                                            {
                                                                                                                row1["Observaciones"] = "Error en campo 3 Registro Adicional ";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (Observ == "R86")
                                                                                                                {
                                                                                                                    row1["Observaciones"] = "Identificación de la empresa errónea";
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (Observ == "R90")
                                                                                                                    {
                                                                                                                        row1["Observaciones"] = "TRX no corresponde por no existir TRX original";
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (Observ == "R91")
                                                                                                                        {
                                                                                                                            row1["Observaciones"] = "Código banco incompatible con moneda de TRX";
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (Observ == "R93")
                                                                                                                            {
                                                                                                                                row1["Observaciones"] = "Día no laborable";
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (Observ == "R95")
                                                                                                                                {
                                                                                                                                    row1["Observaciones"] = "Reversión de entidad receptora presentada fuera de término";
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (Observ == "R13")
                                                                                                                                    {
                                                                                                                                        row1["Observaciones"] = "Entidad destino inexistente";
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (Observ == "R18")
                                                                                                                                        {
                                                                                                                                            row1["Observaciones"] = "Fecha de compensación errónea";
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (Observ == "R27")
                                                                                                                                            {
                                                                                                                                                row1["Observaciones"] = "Error en contador de registro";
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (Observ == "R31")
                                                                                                                                                {
                                                                                                                                                    row1["Observaciones"] = "Vuelta atrás de Cámara";
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (Observ == "R75")
                                                                                                                                                    {
                                                                                                                                                        row1["Observaciones"] = "Fecha inválida";
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (Observ == "R76")
                                                                                                                                                        {
                                                                                                                                                            row1["Observaciones"] = "Error en campo 11 Cabecera de Lote ";
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (Observ == "R77")
                                                                                                                                                            {
                                                                                                                                                                row1["Observaciones"] = "Error en campo 4 Registro Individual";
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (Observ == "R78")
                                                                                                                                                                {
                                                                                                                                                                    row1["Observaciones"] = "Error en campo 5 Registro Individual";
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (Observ == "R87")
                                                                                                                                                                    {
                                                                                                                                                                        row1["Observaciones"] = "Error en campo 9 Registro Individual 1er byte ";
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (Observ == "R88")
                                                                                                                                                                        {
                                                                                                                                                                            row1["Observaciones"] = "Error en campo 2 Registro Individual";
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (Observ == "R89")
                                                                                                                                                                            {
                                                                                                                                                                                row1["Observaciones"] = "Errores transacciones no monetarias";
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    dt2.Rows.Add(row1);
                                }
                            }
                        }

                        GridView1.DataSource = dt2;
                        GridView1.DataBind();
                        lblCantidadRegistros.Text = Convert.ToString(dt2.Rows.Count);
                        listado.Visible = true;
                        btnImputar.Visible = true;
                        btnImprimir.Visible = true;
                        GrillaCaja.DataSource = null;
                        GrillaCaja.DataBind();
                        AlerInfo.Visible = true;


                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            if (Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Imputa"]) == "DFP")
                            {
                                row.BackColor = System.Drawing.Color.FromName("#B81822");
                                row.ForeColor = System.Drawing.Color.White;                            //((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                            }

                            else
                            {

                            }
                        }
                    }


                    //Eliminar el Archivo Excel del Directorio Temporal
                    //if (System.IO.File.Exists(path))
                    //{
                    //    System.IO.File.Delete(path);
                    //}
                    //Vaciar El Dataset y los Datatable
                    dt1 = null;
                    DtSet = null;
                    //DataTable. = null;

                }
            }
            else // SIRO
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


                //string ruta = Server.MapPath("~/SIRO/SiroCobranzas.txt"); // o ruta absoluta
                //var lineas = LeerArchivoLocal(ruta);

                //foreach (string linea in lineas)
                //{
                //    var pago = ParsearLineaUnificada(linea);
                //    if (pago != null)
                //    {
                //        //Response.Write(string.Format(
                //        //    "<b>{0}</b> - {1} - ${2} - Canal: {3}<br/>",
                //        //    pago.FechaPago,
                //        //    pago.IdReferenciaOperacion,
                //        //    pago.Importe.ToString("N2"),
                //        //    pago.CanalCobro
                //        //));
                //        Label8.Text = Label8.Text + " || " + pago.idUsuario + " - " + pago.idComprobante + " - " + pago.FechaPago + " - " + pago.IdReferenciaOperacion + " - " + pago.ImportePagado.ToString("N2") + " - " + pago.CanalCobro + " <br/>";
                //    }
                //}
            }

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

    private PagoUnificadoSIRO ParsearLineaUnificada(string linea)
    {
        try
        {
            return new PagoUnificadoSIRO
            {
                FechaPago = FormatearFecha(linea.Substring(0, 8)), // AAAAMMDD
                fechaacreditacion = FormatearFecha(linea.Substring(8, 8)),
                idUsuario = linea.Substring(35, 8).Trim(),
                ImportePagado = Decimal.Parse(linea.Substring(24, 11)) / 100m,
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



    protected void btnImputar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMej.Text = "";
            //AlerInfo.Visible = true;
            int destino = 1;//Entrenamiento
            int CompTipo = 1;// factura C
            int LugPago = 0;//BANCO MUNICIPAL o Patagonia
            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime FechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int usuIdUltimaModificacion = this.Master.usuId;
            DataTable dt8 = new DataTable();
            DataTable dt5 = new DataTable();


            if (BcoAdhId.SelectedValue == "1") // Caja
            {
                AlerInfo.Visible = true;
                insId = Convert.ToInt32(lblColegioId.Text);
                LugPago = Convert.ToInt32(lblLugarPago.Text);//BANCO MUNICIPAL o Patagonia
                Caja();
            }

            else  // Patagonia
            {

                if (BcoAdhId.SelectedValue == "2") // Patagonia
                {
                    AlerInfo.Visible = true;
                    LugPago = Convert.ToInt32(lblLugarPago.Text);//BANCO MUNICIPAL o Patagonia
                    Patagonia();
                }
                else
                {
                    AlerInfo.Visible = false;
                    SiroActualizar();
                }
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
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
            Response.Redirect("../PaginasBasicas/Inicio.aspx", true);
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    //    protected void btnImprimir(object sender, EventArgs e)
    //    {

    //        try
    //        {
    //            insId = Convert.ToInt32(Session["_Institucion"]);
    //            String NomRep;

    //            Int32 anio = 0;


    //            NomRep = "ListadoPorCursoAnio.rpt";

    //            //FuncionesUtiles.AbreVentana("Reporte.aspx?curso=" + curso + "&anio=" + anio + "&insId=" + insId + "&NomRep=" + NomRep);
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }

    protected void BcoAdhId_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnImprimirSiro.Visible = false;
        alerMje.Visible = false;
        AlerExito.Visible = false;
        lblMej.Text = "";
        alerError.Visible = false;
        GrillaSiro.DataSource = null;
        GrillaSiro.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        lblCantidadRegistros.Text = Convert.ToString(dt2.Rows.Count);
        listado.Visible = false;
        btnImputar.Visible = false;
        btnImprimir.Visible = false;
        GrillaCaja.DataSource = null;
        GrillaCaja.DataBind();

        if (BcoAdhId.SelectedValue == "3")
        {
            PnlSiro.Visible = true;
            PnlBanco.Visible = false;
        }
        else
        {
            PnlSiro.Visible = false;
            PnlBanco.Visible = true;
        }


    }

    void Siro()
    {
        try
        {
            alerError.Visible = false;
            alerMje.Visible = false;
            if (txtDesde.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una fecha desde..";
                return;
            }
            if (txtHasta.Text == "")
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una fecha hasta..";
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("aluId", typeof(Int32));
            dt.Columns.Add("cocId", typeof(Int32));
            dt.Columns.Add("cdeId", typeof(Int32));
            dt.Columns.Add("icoId", typeof(Int32));
            dt.Columns.Add("cfpId", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("Curso", typeof(String));
            dt.Columns.Add("Concepto", typeof(String));
            dt.Columns.Add("NroCuota", typeof(Int32));
            dt.Columns.Add("FechaPago", typeof(DateTime));
            dt.Columns.Add("Importe", typeof(Decimal));
            dt.Columns.Add("inp_IdReferenciaOperacion", typeof(String));
            dt.Columns.Add("CanalCobro", typeof(String));
            dt.Columns.Add("CodRechazo", typeof(String));
            dt.Columns.Add("Cuotas", typeof(Int32));
            dt.Columns.Add("Tarjetas", typeof(String));
            dt.Columns.Add("ImpotePagado", typeof(Decimal));
            dt.Columns.Add("FechaAcreditacion", typeof(DateTime));
            dt.Columns.Add("FechaPagoSiro", typeof(DateTime));
            dt.Columns.Add("FormaPago", typeof(String));
            dt.Columns.Add("Observacion", typeof(String));
            dt.Columns.Add("NroCupon", typeof(String));
            dt.Columns.Add("Anio", typeof(Int32));
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
            if (lineas != null && lineas.Any())
            {
                foreach (string linea in lineas)
                {
                    var pago = ParsearLineaUnificada(linea);
                    if (pago != null)
                    {
                        String idRefOp = pago.IdReferenciaOperacion;
                        string idRO_aluid = idRefOp.Substring(50, 50);
                        // Quitamos los ceros a la izquierda de la segunda parte
                        idRO_aluid = idRO_aluid.TrimStart('0');
                        DataTable dtCompCab = new DataTable();
                        String NroCuponTraer = "Siro" + pago.IdPago;
                        dtCompCab = ocnComprobantesCabecera.ObtenerUnoxIdOperacion(idRefOp);
                        if (dtCompCab.Rows.Count > 0)
                        {
                            foreach (DataRow compRow in dtCompCab.Rows)
                            {
                                DataRow row1 = dt.NewRow();
                                row1["aluId"] = Convert.ToInt32(idRO_aluid);

                                row1["cocId"] = Convert.ToInt32(compRow["cocId"].ToString());
                                row1["cdeId"] = Convert.ToInt32(compRow["cdeId"].ToString());
                                row1["icoId"] = Convert.ToInt32(compRow["icoId"].ToString());
                                row1["cfpId"] = Convert.ToString(compRow["cfpId"].ToString());
                                row1["Nombre"] = Convert.ToString(compRow["Nombre"].ToString());
                                row1["Curso"] = Convert.ToString(compRow["Curso"].ToString());
                                row1["Concepto"] = Convert.ToString(compRow["Concepto"].ToString());
                                row1["Anio"] = Convert.ToString(compRow["Anio"].ToString());
                                row1["NroCupon"] = NroCuponTraer;

                                // NroCuota
                                string nroCuotaStr = (compRow["NroCuota"] != null) ? compRow["NroCuota"].ToString() : "0";
                                int nroCuota = 0;
                                int.TryParse(nroCuotaStr, out nroCuota);
                                row1["NroCuota"] = nroCuota;

                                // FechaPago (de Comprobante Cabecera)
                                string fechaPagoStr = (compRow["FechaPago"] != null) ? compRow["FechaPago"].ToString() : "";
                                DateTime fechaPagoDt = DateTime.MinValue;
                                DateTime.TryParse(fechaPagoStr, out fechaPagoDt);
                                row1["FechaPago"] = fechaPagoDt;

                                // Importe
                                string importeStr = (compRow["Importe"] != null) ? compRow["Importe"].ToString() : "0";
                                decimal importe = 0;
                                decimal.TryParse(importeStr, out importe);
                                row1["Importe"] = importe;

                                // Referencia de operación
                                row1["inp_IdReferenciaOperacion"] = (idRefOp != null && idRefOp != "") ? idRefOp : "";

                                // Canal de cobro
                                row1["CanalCobro"] = (pago.CanalCobro != null && pago.CanalCobro != "") ? pago.CanalCobro : "";

                                // Código de rechazo
                                row1["CodRechazo"] = (pago.CodigoRechazo != null) ? pago.CodigoRechazo : "";

                                // Cuotas
                                row1["Cuotas"] = (pago.Cuotas != null && pago.Cuotas != "") ? pago.Cuotas : "0";

                                // Tarjetas
                                row1["Tarjetas"] = (pago.Tarjetas != null && pago.Tarjetas != "") ? pago.Tarjetas : "";

                                // Importe pagado
                                row1["ImpotePagado"] = pago.ImportePagado;

                                // Fecha de acreditación
                                DateTime fechaAcred = DateTime.MinValue;
                                if (pago.fechaacreditacion != null)
                                {
                                    DateTime.TryParse(pago.fechaacreditacion, out fechaAcred);
                                }
                                row1["FechaAcreditacion"] = fechaAcred;

                                // Fecha de pago (de objeto pago)
                                DateTime FechaPago1 = DateTime.MinValue;
                                if (pago.FechaPago != null)
                                {
                                    DateTime.TryParse(pago.FechaPago, out FechaPago1);
                                }
                                row1["FechaPagoSiro"] = FechaPago1;

                                // Forma de pago
                                row1["FormaPago"] = Convert.ToString(compRow["NombreFP"].ToString());

                                // Observación
                                row1["Observacion"] = pago.DescripcionRechazo;

                                dt.Rows.Add(row1);
                            }
                        }

                    }
                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "Hay registros en el Archivo SIRO que no fueron contemplados en esta instancia.. Consulte al Administrador.. ";
                    }
                }
                btnImprimirSiro.Visible = true;
                GrillaSiro.DataSource = dt;
                GrillaSiro.DataBind();
                btnImputar.Visible = true;
                alerMje.Visible = true;


                bool hayPagosNoImputados = dt.AsEnumerable().Any(row =>
    row.Field<string>("FormaPago") == "SIRO Pagos" &&
    string.IsNullOrWhiteSpace(row.Field<string>("Observacion")));

                if (hayPagosNoImputados)
                {
                    alerMje.Visible = true;
                    btnImputar.Enabled = true;
                    //lblMje.Text = "⚠️ Atención: Existen pagos de SiroPagos sin imputar. Presione 'Imputar' para completar el registro.";
                }
                else
                {
                    Int32 Ban = 0;
                    DataTable dtTraerCocId = new DataTable();
                    Int32 Activo = 0;
                     Int32 CodRechazo = 0;

                    foreach (GridViewRow row1 in GrillaSiro.Rows)
                    {
                        Int32 cocIdTraer = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["cocId"]);
                        dtTraerCocId = ocnComprobantesCabecera.ObtenerUno(cocIdTraer);
                        Activo = Convert.ToInt32(dtTraerCocId.Rows[0]["cocActivo"].ToString());
                        object codRechazoObj = GrillaSiro.DataKeys[row1.RowIndex].Values["CodRechazo"];
                        int codRechazoParsed;
                        CodRechazo = (codRechazoObj != null && int.TryParse(codRechazoObj.ToString(), out codRechazoParsed)) ? codRechazoParsed : 0;

                        if (Activo == 1 && CodRechazo == 402)
                        {
                            Ban = 1;
                        }
                        else
                        {

                        }
                    }
                    if (Ban == 1)
                    {
                        alerMje.Visible = true;
                        btnImputar.Enabled = true;
                    }
                    else
                    {
                        alerMje.Visible = false;
                        btnImputar.Enabled = false;
                    }

                }
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "No hay registros para imputar..";
                btnImputar.Visible = false;
                btnImprimirSiro.Visible = false;
                btnImprimir.Visible = false;
                return;
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>
        MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }


    void SiroActualizar()
    {
        try
        {
            alerError.Visible = false;
            AlerExito.Visible = false;

            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime FechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdCreacion = this.Master.usuId;
            Int32 usuIdUltimaModificacion = this.Master.usuId;
            Dictionary<string, List<string>> agrupacionPorOperacion = new Dictionary<string, List<string>>();
            foreach (GridViewRow row1 in GrillaSiro.Rows)
            {
                int cfpId = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["cfpId"]);
                int icoId = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["icoId"]);
                int cocId = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["cocId"]);
                int cdeId = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["cdeId"]);
                String idOperacion = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["inp_IdReferenciaOperacion"]);
                String CanalCobro = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["CanalCobro"]);
                String CodRechazo = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["CodRechazo"]);
                String DescRechazo = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["Observacion"]);
                Int32 cuotas = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["Cuotas"]);
                Int32 NroCuota = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["NroCuota"]);
                String Tarjetas = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["Tarjetas"]);
                Decimal ImpotePagado = Convert.ToDecimal(GrillaSiro.DataKeys[row1.RowIndex].Values["ImpotePagado"]);
                DateTime FechaAcreditacion = Convert.ToDateTime(GrillaSiro.DataKeys[row1.RowIndex].Values["FechaAcreditacion"]);
                DateTime FechaPagoSiro = Convert.ToDateTime(GrillaSiro.DataKeys[row1.RowIndex].Values["FechaPagoSiro"]);
                Int32 AnioCursado = Convert.ToInt32(GrillaSiro.DataKeys[row1.RowIndex].Values["Anio"]);
                String NroCupon = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["NroCupon"]);
                String FormaPago = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["FormaPago"]);
                if (CodRechazo == "402")
                {

                    String ConceptoRech = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["Concepto"]);
                    String CuotasRech = Convert.ToString(GrillaSiro.DataKeys[row1.RowIndex].Values["NroCuota"]);
                    String Anio = Convert.ToString(AnioCursado);
                    string conceptoCuota = string.Format("{0} x {1} x {2} ", ConceptoRech, CuotasRech, Anio);

                    if (!agrupacionPorOperacion.ContainsKey(idOperacion))
                    {
                        agrupacionPorOperacion[idOperacion] = new List<string>();
                    }

                    agrupacionPorOperacion[idOperacion].Add(conceptoCuota);
                    ocnComprobantesDetalle.ActualizarActivo(cocId, false, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                    ocnComprobantesCabecera.ActualizarActivo(cocId, usuIdUltimaModificacion, FechaHoraUltimaModificacion);
                    ocnIntencionPagos.ActualizarRegistros(idOperacion, CanalCobro, CodRechazo, DescRechazo, cuotas, Tarjetas, ImpotePagado, FechaAcreditacion, FechaPagoSiro);
                }
                else
                {
                    if (FormaPago == "SIRO Pagos")
                    {
                        int fopReal = 0;
                        if (CanalCobro == "BPC")
                        {
                            fopReal = 2;// Tarjeta
                            int TarId = 0;
                            int PalnTarId = 0;
                            if (Tarjetas == "VISA")
                            {
                                TarId = 6; // VISA
                                PalnTarId = 5; // Otros Visa
                            }
                            else
                            {
                                if (Tarjetas == "MASTER")
                                {
                                    TarId = 4; //MASTER
                                    PalnTarId = 6; // Otros Master
                                }
                                else
                                {
                                    if (Tarjetas == "CABAL")
                                    {
                                        TarId = 3; //CABAL
                                        PalnTarId = 7; // Otros Master
                                    }
                                }
                            }

                            ocnPagosTarjetas.Insertar(cfpId, TarId, PalnTarId, 0, 0, cuotas, NroCupon, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                        }
                        else
                        {
                            if (CanalCobro == "BPD")
                            {
                                fopReal = 3; // Debito
                                ocnPagosTarjetas.Insertar(cfpId, 5, 5, 0, 0, 1, NroCupon, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);

                            }
                            else
                            {
                                if (CanalCobro == "TQR")
                                {
                                    fopReal = 4;// Transferencia
                                    ocnPagosTransferenciaElectronica.Insertar(cfpId, ImpotePagado, NroCupon, 500, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);

                                }
                            }
                        }


                        ocnComprobantesFormasPago.ActualizarFormadePago(cfpId, fopReal, usuIdUltimaModificacion, FechaHoraUltimaModificacion);
                        ocnIntencionPagos.ActualizarRegistros(idOperacion, CanalCobro, CodRechazo, DescRechazo, cuotas, Tarjetas, ImpotePagado, FechaAcreditacion, FechaPagoSiro);
                        ocnIntencionPagos.Actualizarobervacionimputacion(idOperacion, "Imputado");
                    }
                }
            }
            foreach (var kvp in agrupacionPorOperacion)
            {
                string idOperacion = kvp.Key;
                string concatenado = string.Join(", ", kvp.Value);

                // Inserción final
                ocnIntencionPagos.Actualizarobervacionimputacion(idOperacion, concatenado);
            }
            AlerExito.Visible = true;
            lblAlerExito.Text = "Archivos Imputados..";
            Siro();
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>
        MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }


    protected void GrillaSiro_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtener Forma de Pago
            object objFormaDePago = DataBinder.Eval(e.Row.DataItem, "FormaPago");
            string formaDePago = (objFormaDePago != null) ? objFormaDePago.ToString().Trim().ToLower() : string.Empty;

            // Obtener Observación
            object objObservacion = DataBinder.Eval(e.Row.DataItem, "Observacion");
            string observacion = (objObservacion != null) ? objObservacion.ToString() : string.Empty;

            // Índice de la columna Observación (ajustar si cambia la estructura)
            int indiceObservacion = 21;

            // Mostrar "Imputado" si la forma de pago NO es "siro pagos"
            if (!string.Equals(formaDePago, "siro pagos", StringComparison.OrdinalIgnoreCase))
            {
                e.Row.Cells[indiceObservacion].Text = "Imputado";
            }
            else
            {
                //e.Row.Cells[indiceObservacion].Text = "Imputado";
            }

            // Si hay una observación real, colorear la fila
            if (!string.IsNullOrWhiteSpace(observacion))
            {
                e.Row.BackColor = System.Drawing.Color.DarkRed;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
        }
    }


    private int GetColumnIndexByName(string columnName)
    {
        foreach (DataControlField col in GrillaSiro.Columns)
        {
            if (col.HeaderText == columnName)
                return GrillaSiro.Columns.IndexOf(col);
        }
        return -1;
    }
    void Patagonia()
    {
        try
        {
            DataTable dt = new DataTable();
            int cocIdNuevo;
            int cfoIdNuevo;
            dt.Columns.Add("aluId", typeof(int));
            dt.Columns.Add("icoId", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("Concepto", typeof(String));
            dt.Columns.Add("FechaPago", typeof(DateTime));
            dt.Columns.Add("NroCuota", typeof(Int32));
            dt.Columns.Add("Importe", typeof(Decimal));
            dt.Columns.Add("NroComprobante", typeof(Decimal));
            dt.Columns.Add("Curso", typeof(String));
            dt.Columns.Add("Imputa", typeof(String));
            dt.Columns.Add("adeCBU", typeof(String));
            //insId = Convert.ToInt32(Session["_Institucion"]);
            dt.Columns.Add("Observaciones", typeof(String));
            dt.Columns.Add("insid", typeof(Int32));
            lblMej.Text = "";
            //insId = Convert.ToInt32(lblColegioId.Text);





            AlerInfo.Visible = true;
            int destino = 1;//Entrenamiento
            int CompTipo = 1;// factura C
            int LugPago = Convert.ToInt32(lblLugarPago.Text);//BANCO MUNICIPAL o Patagonia
            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime FechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int usuIdUltimaModificacion = this.Master.usuId;
            DataTable dtCaja = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt8 = new DataTable();
            Int32 insId = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Observaciones"]) == "   " || Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Observaciones"]) == "")
                {
                    if (Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Imputa"]) == "")
                    {

                        String CodAlumno = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["aluId"]);
                        Decimal sumatoria = 0;// Saco TOTAL de conceptos
                        int Bandera = 0;
                        int Bandera1 = 0;
                        foreach (GridViewRow row2 in GridView1.Rows)
                        {
                            if (Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Imputa"]) == "")
                            {
                                if (CodAlumno == Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["aluId"]))
                                {
                                    Int32 aluId = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["aluId"]);
                                    Int32 icoId = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["icoId"]);
                                    String Nombre = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Nombre"]);
                                    String Concepto = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Concepto"]);
                                    Int32 NroCuota = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["NroCuota"]);
                                    Decimal Importe = Convert.ToDecimal(GridView1.DataKeys[row2.RowIndex].Values["Importe"]);
                                    String Curso = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Curso"]);
                                    insId = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["insid"]);
                                    foreach (DataRow row4 in dt.Rows) //Veo si ya lo inserté
                                    {
                                        if (icoId == Convert.ToInt32(row4["icoId"].ToString()))
                                        {
                                            Bandera1 = 1;//Ingresado
                                        }
                                    }
                                    if (Bandera1 == 0)
                                    {
                                        dt5 = ocnComprobantesDetalle.ObtenerUnoxicoId(icoId);
                                        DataRow row1 = dt.NewRow();
                                        row1["aluId"] = aluId;
                                        row1["icoId"] = icoId;
                                        row1["Nombre"] = Nombre;
                                        row1["Concepto"] = Concepto;
                                        row1["FechaPago"] = Convert.ToDateTime(GridView1.DataKeys[row2.RowIndex].Values["FechaPago"]);
                                        row1["NroCuota"] = NroCuota;
                                        row1["Importe"] = Importe;
                                        row1["Curso"] = Curso;
                                        row1["Observaciones"] = "";
                                        row1["adeCBU"] = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["adeCBU"]); ;
                                        if (dt5.Rows.Count == 0)
                                        {
                                            row1["Imputa"] = "I";
                                            Bandera = 1;
                                            sumatoria += (Convert.ToDecimal(GridView1.DataKeys[row2.RowIndex].Values["Importe"]));

                                            ocnDevPatagoniaImputar.Insertar(Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["adeCBU"]), Importe,
                                             Convert.ToDateTime(GridView1.DataKeys[row2.RowIndex].Values["FechaPago"]), "", aluId,
                                             NroCuota, Concepto);
                                        }

                                        else
                                        {
                                            if (dt5.Rows.Count > 0)
                                            {
                                                row1["Imputa"] = "E";
                                            }
                                        }

                                        dt.Rows.Add(row1);
                                    }
                                }
                            }
                            else
                            {
                                Int32 aluId = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["aluId"]);
                                //if (aluId == 11171)
                                //{
                                //    Int32 uuu = 1;
                                //}
                                Int32 icoId = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["icoId"]);
                                String Nombre = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Nombre"]);
                                String Concepto = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Concepto"]);
                                Int32 NroCuota = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["NroCuota"]);
                                Decimal Importe = Convert.ToDecimal(GridView1.DataKeys[row2.RowIndex].Values["Importe"]);
                                String Curso = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["Curso"]);
                                insId = Convert.ToInt32(GridView1.DataKeys[row2.RowIndex].Values["insid"]);
                                DataRow row1 = dt.NewRow();
                                row1["aluId"] = aluId;
                                Session["aluid"] = aluId;
                                row1["icoId"] = 0;
                                row1["Nombre"] = Nombre;
                                row1["Concepto"] = Concepto;
                                row1["FechaPago"] = Convert.ToDateTime(GridView1.DataKeys[row2.RowIndex].Values["FechaPago"]);
                                row1["NroCuota"] = NroCuota;
                                row1["Importe"] = Importe;
                                row1["Curso"] = Curso;
                                row1["Imputa"] = "NE";
                                row1["adeCBU"] = Convert.ToString(GridView1.DataKeys[row2.RowIndex].Values["adeCBU"]); ;

                            }
                        }

                        if (dt.Rows.Count > 0)
                        {
                            if (Bandera == 1) // significa que al menos una fila hay que imputar
                            {
                                dt8 = ocnComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest(insId, CompTipo, destino);

                                String compPtoVta = Convert.ToString(dt8.Rows[0]["Id"].ToString());
                                int valor = Convert.ToInt32(dt8.Rows[0]["UltimoNro"].ToString());
                                int NroCompr = valor + 1;
                                String lblUltimoNro = string.Format("{0:00000000}", NroCompr);

                                //Insertar y Actualizar Tablas
                                //Comprobante Cabecera
                                cocIdNuevo = ocnComprobantesCabecera.InsertarTraerId(CompTipo, compPtoVta, lblUltimoNro, Convert.ToDateTime(dt.Rows[0]["FechaPago"].ToString()), sumatoria, LugPago, "", true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                String cocIdNuevo1 = Convert.ToString(cocIdNuevo);
                                //Comprobante Pto Vta
                                ocnComprobantesPtosVta.ActualizarUltimoNro(Convert.ToInt32(compPtoVta), NroCompr, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);

                                //Cambio 17052021
                                int FormPagoIn = 0;
                                if (BcoAdhId.SelectedValue == "1")
                                {
                                    FormPagoIn = 1;
                                }
                                else
                                {
                                    FormPagoIn = 3;
                                }
                                //cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cocIdNuevo, FormPagoIn, sumatoria, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                /////////

                                foreach (DataRow row3 in dt.Rows)
                                {
                                    if (CodAlumno == Convert.ToString(row3["aluId"].ToString()))
                                    {
                                        int cdeId = ocnComprobantesDetalle.InsertarTraeId(cocIdNuevo, Convert.ToInt32(row3["icoId"].ToString()), Convert.ToDecimal(row3["Importe"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                        cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeId, FormPagoIn, Convert.ToDecimal(row3["Importe"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Int32 aluId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["aluId"]);
                        String Concepto = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Concepto"]);
                        Int32 NroCuota = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["NroCuota"]);
                        String Curso = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Curso"]);
                        insId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["insid"]);
                        DataRow row1 = dt.NewRow();
                        row1["aluId"] = aluId;
                        row1["icoId"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["icoId"]);
                        row1["Nombre"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Nombre"]);
                        row1["Concepto"] = Concepto;
                        row1["FechaPago"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["FechaPago"]);
                        row1["NroCuota"] = NroCuota;
                        row1["Importe"] = Convert.ToDecimal(GridView1.DataKeys[row.RowIndex].Values["Importe"]); ;
                        row1["Curso"] = Curso;
                        row1["Observaciones"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Observaciones"]);
                        row1["Imputa"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Imputa"]); ;
                        row1["adeCBU"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["adeCBU"]); ;

                        dt.Rows.Add(row1);
                    }
                }
                else
                {
                    Int32 aluId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["aluId"]);
                    alu_id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["aluId"]).ToString();
                    //if (aluId == 11791)
                    //{
                    //    Int32 ppq = 0;
                    //}
                    // 11791

                    String Concepto = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Concepto"]);
                    Int32 NroCuota = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["NroCuota"]);
                    Decimal Importe = 0;
                    String Curso = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Curso"]);
                    DataRow row1 = dt.NewRow();
                    row1["aluId"] = aluId;
                    row1["icoId"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["icoId"]);
                    row1["Nombre"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Nombre"]);
                    row1["Concepto"] = Concepto;
                    row1["FechaPago"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["FechaPago"]);
                    row1["NroCuota"] = NroCuota;
                    row1["Importe"] = 0;
                    row1["Curso"] = Curso;
                    row1["Observaciones"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Observaciones"]);
                    row1["Imputa"] = "";
                    row1["adeCBU"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["adeCBU"]);
                    row1["insid"] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["insid"]);

                    dt.Rows.Add(row1);
                    //Session.Add[CBU] = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["adeCBU"];
                    //Int32 pppp = Convert.ToInt32(Session["aluid"]);
                    //Session["aluid"] = aluId;

                    //int qqq = 0;
                    //if (Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["adeCBU"]) == "0720000788000040420204") {
                    //    qqq = 1;
                    //}
                    //if (Importe == '0')
                    //{
                    //    qqq = 2;
                    //}
                    //if (Convert.ToDateTime(GridView1.DataKeys[row.RowIndex].Values["FechaPago"]) == null)
                    //{
                    //    qqq = 3;
                    //}
                    //if (aluId == 0)
                    //{
                    //    qqq = 4;
                    //}
                    //if (NroCuota == 0)
                    //{
                    //    qqq = 5;
                    //}
                    //if (Concepto == "")
                    //{
                    //    qqq = 6;
                    //}
                    ocnDevPatagoniaImputar.Insertar(Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["adeCBU"]), Importe,
                                          Convert.ToDateTime(GridView1.DataKeys[row.RowIndex].Values["FechaPago"]), Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Observaciones"]), aluId,
                                          NroCuota, Concepto);


                    lblMej.Text = "Los registros con observaciones no fueron imputados ";
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblCantidadRegistros.Text = Convert.ToString(dt2.Rows.Count);
            listado.Visible = true;
            btnImputar.Visible = true;
            btnImprimir.Visible = true;
            GrillaCaja.DataSource = null;
            GrillaCaja.DataBind();


            foreach (GridViewRow row in GridView1.Rows)
            {
                if (Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["Imputa"]) == "DFP")
                {
                    row.BackColor = System.Drawing.Color.FromName("#B81822");
                    row.ForeColor = System.Drawing.Color.White;                            //((CheckBox)row.FindControl("chkSeleccion")).Enabled = false;
                }

                else
                {

                }
            }

        }

        catch (Exception oError)
        {
            //String qq = Convert.ToString(aluId);
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    Se ha producido el siguiente error:<br/>
    MESSAGE:<br>" + alu_id + " - " + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }

    void Caja()
    {
        try
        {
            int cocIdNuevo;
            int cfoIdNuevo;
            lblMej.Text = "";
            insId = Convert.ToInt32(lblColegioId.Text);
            AlerInfo.Visible = true;
            int destino = 1;//Entrenamiento
            int CompTipo = 1;// factura C
            int LugPago = Convert.ToInt32(lblLugarPago.Text);//BANCO MUNICIPAL o Patagonia
            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime FechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int usuIdUltimaModificacion = this.Master.usuId;
            DataTable dtCaja = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt8 = new DataTable();
            dtCaja.Columns.Add("aluId", typeof(int));
            dtCaja.Columns.Add("icoId", typeof(Int32));
            dtCaja.Columns.Add("Nombre", typeof(String));
            dtCaja.Columns.Add("Concepto", typeof(String));
            dtCaja.Columns.Add("FechaPago", typeof(DateTime));
            dtCaja.Columns.Add("NroCuota", typeof(Int32));
            dtCaja.Columns.Add("Importe", typeof(Decimal));
            dtCaja.Columns.Add("NroComprobante", typeof(Decimal));
            dtCaja.Columns.Add("Curso", typeof(String));
            dtCaja.Columns.Add("Imputa", typeof(String));
            //insId = Convert.ToInt32(Session["_Institucion"]);
            dtCaja.Columns.Add("Observaciones", typeof(String));
            foreach (GridViewRow row in GrillaCaja.Rows)
            {
                if (Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Observaciones"]) == "   " || Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Observaciones"]) == "")
                {
                    if (Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Imputa"]) == "")
                    {

                        String CodAlumno = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["aluId"]);
                        Decimal sumatoria = 0;// Saco TOTAL de conceptos
                        int Bandera = 0;
                        int Bandera1 = 0;
                        foreach (GridViewRow row2 in GrillaCaja.Rows)
                        {
                            if (Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Imputa"]) == "")
                            {
                                if (CodAlumno == Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["aluId"]))
                                {
                                    Int32 aluId = Convert.ToInt32(GrillaCaja.DataKeys[row2.RowIndex].Values["aluId"]);
                                    Int32 icoId = Convert.ToInt32(GrillaCaja.DataKeys[row2.RowIndex].Values["icoId"]);
                                    String Nombre = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Nombre"]);
                                    String Concepto = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Concepto"]);
                                    Int32 NroCuota = Convert.ToInt32(GrillaCaja.DataKeys[row2.RowIndex].Values["NroCuota"]);
                                    Decimal Importe = Convert.ToDecimal(GrillaCaja.DataKeys[row2.RowIndex].Values["Importe"]);
                                    String Curso = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Curso"]);
                                    foreach (DataRow row4 in dtCaja.Rows) //Veo si ya lo inserté
                                    {
                                        if (icoId == Convert.ToInt32(row4["icoId"].ToString()))
                                        {
                                            Bandera1 = 1;//Ingresado
                                        }
                                    }
                                    if (Bandera1 == 0)
                                    {
                                        dt5 = ocnComprobantesDetalle.ObtenerUnoxicoId(icoId);
                                        DataRow row1 = dtCaja.NewRow();
                                        row1["aluId"] = aluId;
                                        row1["icoId"] = icoId;
                                        row1["Nombre"] = Nombre;
                                        row1["Concepto"] = Concepto;
                                        row1["FechaPago"] = Convert.ToDateTime(GrillaCaja.DataKeys[row2.RowIndex].Values["FechaPago"]);
                                        row1["NroCuota"] = NroCuota;
                                        row1["Importe"] = Importe;
                                        row1["Curso"] = Curso;
                                        row1["Observaciones"] = "";
                                        //row1["adeCBU"] = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["adeCBU"]); ;
                                        if (dt5.Rows.Count == 0)
                                        {
                                            row1["Imputa"] = "I";
                                            Bandera = 1;
                                            sumatoria += (Convert.ToDecimal(GrillaCaja.DataKeys[row2.RowIndex].Values["Importe"]));
                                        }

                                        else
                                        {
                                            if (dt5.Rows.Count > 0)
                                            {
                                                row1["Imputa"] = "E";
                                            }
                                        }
                                        dtCaja.Rows.Add(row1);
                                    }
                                }
                            }
                            else
                            {
                                Int32 aluId = Convert.ToInt32(GrillaCaja.DataKeys[row2.RowIndex].Values["aluId"]);
                                Int32 icoId = Convert.ToInt32(GrillaCaja.DataKeys[row2.RowIndex].Values["icoId"]);
                                String Nombre = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Nombre"]);
                                String Concepto = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Concepto"]);
                                Int32 NroCuota = Convert.ToInt32(GrillaCaja.DataKeys[row2.RowIndex].Values["NroCuota"]);
                                Decimal Importe = Convert.ToDecimal(GrillaCaja.DataKeys[row2.RowIndex].Values["Importe"]);
                                String Curso = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["Curso"]);
                                DataRow row1 = dtCaja.NewRow();
                                row1["aluId"] = aluId;
                                row1["icoId"] = 0;
                                row1["Nombre"] = Nombre;
                                row1["Concepto"] = Concepto;
                                row1["FechaPago"] = Convert.ToDateTime(GrillaCaja.DataKeys[row2.RowIndex].Values["FechaPago"]);
                                row1["NroCuota"] = NroCuota;
                                row1["Importe"] = Importe;
                                row1["Curso"] = Curso;
                                row1["Imputa"] = "NE";
                                //row1["adeCBU"] = Convert.ToString(GrillaCaja.DataKeys[row2.RowIndex].Values["adeCBU"]); ;

                            }
                        }

                        if (dtCaja.Rows.Count > 0)
                        {
                            if (Bandera == 1) // significa que al menos una fila hay que imputar
                            {
                                dt8 = ocnComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest(insId, CompTipo, destino);

                                String compPtoVta = Convert.ToString(dt8.Rows[0]["Id"].ToString());
                                int valor = Convert.ToInt32(dt8.Rows[0]["UltimoNro"].ToString());
                                int NroCompr = valor + 1;
                                String lblUltimoNro = string.Format("{0:00000000}", NroCompr);

                                //Insertar y Actualizar Tablas
                                //Comprobante Cabecera
                                cocIdNuevo = ocnComprobantesCabecera.InsertarTraerId(CompTipo, compPtoVta, lblUltimoNro, Convert.ToDateTime(dtCaja.Rows[0]["FechaPago"].ToString()), sumatoria, LugPago, "", true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                String cocIdNuevo1 = Convert.ToString(cocIdNuevo);
                                //Comprobante Pto Vta
                                ocnComprobantesPtosVta.ActualizarUltimoNro(Convert.ToInt32(compPtoVta), NroCompr, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);

                                //Cambio 17052021
                                int FormPagoIn = 0;
                                if (BcoAdhId.SelectedValue == "1")
                                {
                                    FormPagoIn = 1;
                                }
                                else
                                {
                                    FormPagoIn = 3;
                                }
                                //cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cocIdNuevo, FormPagoIn, sumatoria, true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                /////////

                                foreach (DataRow row3 in dtCaja.Rows)
                                {
                                    if (CodAlumno == Convert.ToString(row3["aluId"].ToString()))
                                    {
                                        int cdeId = ocnComprobantesDetalle.InsertarTraeId(cocIdNuevo, Convert.ToInt32(row3["icoId"].ToString()), Convert.ToDecimal(row3["Importe"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                        cfoIdNuevo = ocnComprobantesFormasPago.InsertarTraerId(cdeId, FormPagoIn, Convert.ToDecimal(row3["Importe"].ToString()), true, usuIdCreacion, usuIdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Int32 aluId = Convert.ToInt32(GrillaCaja.DataKeys[row.RowIndex].Values["aluId"]);
                    String Concepto = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Concepto"]);
                    Int32 NroCuota = Convert.ToInt32(GrillaCaja.DataKeys[row.RowIndex].Values["NroCuota"]);
                    Decimal Importe = 0;
                    String Curso = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Curso"]);
                    DataRow row1 = dtCaja.NewRow();
                    row1["aluId"] = aluId;
                    row1["icoId"] = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["icoId"]);
                    row1["Nombre"] = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Nombre"]);
                    row1["Concepto"] = Concepto;
                    row1["FechaPago"] = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["FechaPago"]);
                    row1["NroCuota"] = NroCuota;
                    row1["Importe"] = 0;
                    row1["Curso"] = Curso;
                    row1["Observaciones"] = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["Observaciones"]);
                    row1["Imputa"] = "";
                    //row1["adeCBU"] = Convert.ToString(GrillaCaja.DataKeys[row.RowIndex].Values["adeCBU"]); ;

                    dtCaja.Rows.Add(row1);
                    lblMej.Text = "Los registros con observaciones no fueron imputados ";
                }
            }

            GridView1.DataSource = null;
            GridView1.DataBind();
            lblCantidadRegistros.Text = Convert.ToString(dt2.Rows.Count);
            listado.Visible = true;
            btnImputar.Visible = true;
            btnImprimir.Visible = true;
            GrillaCaja.DataSource = dtCaja;
            GrillaCaja.DataBind();
        }

        catch (Exception oError)
        {
            lblMensajeError.Text = "Aluid: " + Session["aluid"] + @"<div class=""alert alert-danger alert-dismissable"">
    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    Se ha producido el siguiente error:<br/>
    MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }
}
