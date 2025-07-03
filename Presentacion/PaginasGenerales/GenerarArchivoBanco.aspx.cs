using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Net;

public partial class GenerarArchivoBanco : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.ArchivoBanco ocnArchivoBanco = new GESTIONESCOLAR.Negocio.ArchivoBanco();
    GESTIONESCOLAR.Negocio.ArchivoPatagonia ocnArchivoPatagonia = new GESTIONESCOLAR.Negocio.ArchivoPatagonia();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //imgUpdateProgress.Visible = false;
        try
        {
            if (!Page.IsPostBack)
            {
                Mje.Visible = false;
                this.Master.TituloDelFormulario = "Generar archivo Banco";
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                dt = ocnUsuario.ObtenerUno(usuario);
                this.conAnioLectivo.Text = DateTime.Now.ToString("yyyy");
                txtDesde.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtHasta.Text = "31/12/" + DateTime.Now.ToString("yyyy");
                insId = Convert.ToInt32(Session["_Institucion"]);
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                //ddlInstitucion.DataValueField = "Valor"; ddlInstitucion.DataTextField = "Texto"; ddlInstitucion.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); ddlInstitucion.DataBind();
                //ColegioId.DataValueField = "Valor"; ColegioId.DataTextField = "Texto"; ColegioId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); ColegioId.DataBind();
                cntId.DataValueField = "Valor";
                cntId.DataTextField = "Texto";
                cntId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]");
                cntId.DataBind();

                DateTime dateString = Convert.ToDateTime(txtDesde.Text);

                String diaHoy = Convert.ToString(dateString.Day);
                String mesHoy = Convert.ToString(dateString.Month);

                if (BcoAdhId.SelectedValue == "2")
                {
                    if (mesHoy == "2")
                    {
                        if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27)) // SOLO POR EL 2024
                        {
                            ddlDesde.SelectedValue = "1";
                            ddlDisparo.SelectedValue = "1";
                            FchImputar.Text = "01/03/" + DateTime.Now.ToString("yyyy");

                        }
                        else
                        {
                            alerError.Visible = true;
                            lblError.Text = "No se encuentra en fecha para liquidar";
                        }
                    }

                    else
                    {
                        if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27))
                        {
                            ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 2); // 3 es mes de Inicio
                            FchImputar.Text = "01/" + Convert.ToString(Convert.ToInt32(mesHoy) + 1) + "/" + DateTime.Now.ToString("yyyy");
                            ddlDisparo.SelectedValue = "1";
                        }
                        else
                        {
                            if ((Convert.ToInt32(diaHoy) >= 1) & (Convert.ToInt32(diaHoy) <= 13))
                            {
                                ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 1); // 3 es mes de Inicio
                                FchImputar.Text = "16/" + Convert.ToString(Convert.ToInt32(mesHoy)) + "/" + DateTime.Now.ToString("yyyy");

                                ddlDisparo.SelectedValue = "2";
                            }
                            else
                            {
                                alerError.Visible = true;
                                lblError.Text = "No se encuentra en fecha para liquidar";
                            }
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






    protected void btnDescargar_Click(object sender, EventArgs e)
    {
        string _open = "window.open('ftp://obramisericordista.com.ar/public_html/PaginasGenerales/ArchivosCaja/', '_newtab');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        //    // Abrir en una pestaña nueva la página ftp  ftp://obramisericordista.com.ar/public_html/PaginasGenerales/ArchivosCaja/
        //    FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("ftp://obramisericordista.com.ar/");
        //    Request.Method = WebRequestMethods.Ftp.ListDirectory;
        //    //Request.Credentials = new NetworkCredential("cvega", "Papadeoctavio445"); 
        //    Request.Credentials = new NetworkCredential("obram", "MiseColegios445");
        //    FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();
        //    Stream ResponseStream = Response.GetResponseStream();
        //    StreamReader Reader = new StreamReader(ResponseStream);

        //    var ListBox1 = new List<string>();
        //    //ListBox1.Items.Add(Response.WelcomeMessage);
        //    ListBox1.Add(Response.WelcomeMessage);
        //    while (!Reader.EndOfStream)//Read file name   
        //    {
        //        //ListBox1.Items.Add(Reader.ReadLine().ToString());
        //        ListBox1.Add(Reader.ReadLine().ToString());
        //    }
        //    Response.Close();
        //    ResponseStream.Close();
        //    Reader.Close();
    }

    void Patagonia()
    {
        try
        {
            Mje.Visible = false;
            alerError.Visible = false;
            //imgUpdateProgress.Visible = true;
            DataTable dt1 = new DataTable();
            DataTable dtCA = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtTot = new DataTable();
            //Int32 insid, Int32 conId, Int32 conAnioLectivo
            insId = Convert.ToInt32(lblInsId.Text);
            float Recargo = 0;
            String[] Cuotas;
            Cuotas = new String[3];
            String[] Vtos;
            Vtos = new String[3];
            float[] ImpMes;
            ImpMes = new float[3];

            String[] AplicaBeca;
            AplicaBeca = new String[3];
            String[] AplicaInteresAbierto;
            AplicaInteresAbierto = new String[3];

            String ApellidoyNombre;
            String Cuerpo, Detalle, DiasVtoEntreUnoyDos;

            ocnArchivoPatagonia.Eliminar();

            Int32 TotRegistros;

            dt1 = ocnArchivoPatagonia.ObtenerporVariosxDisparos(Convert.ToInt32(cntId.SelectedValue), Convert.ToInt32(conAnioLectivo.Text), Convert.ToInt32(ddlDesde.SelectedValue), Convert.ToInt32(ddlDisparo.SelectedValue));
            if (dt1.Rows.Count > 0)
            {
                DateTime dateString = Convert.ToDateTime(FchImputar.Text);
                // Nombre del Archivo
                String NombreArchivo = "ORI" + dateString.ToString("ddMM") + ".020" + ".txt";

                //Cabecera
                String Cabecera;
                Cabecera = "H" + "30530322617" + "CUOTA".ToString().PadRight(10, ' ') + "020" +
                DateTime.Now.ToString("ddMMyyyy") + "".ToString().PadRight(12, ' ') +
                "A C HNOS MISERIC".ToString().PadRight(35, ' ') + " ".ToString().PadRight(120, ' ')
                ;
                //ocnArchivoPatagonia.arpCabecera = Cabecera;
                ocnArchivoPatagonia.arpDetalle = Cabecera;
                ocnArchivoPatagonia.InsertarDetalle();
                TotRegistros = dt1.Rows.Count;



                foreach (DataRow row in dt1.Rows)
                {

                    //String pok = "0";
                    //String pdni = row["aluDoc"].ToString();
                    //if (pdni == "51152881") // || pdni == "45659869"
                    //{
                    //    pok = "1";
                    //}



                    Decimal ImpConBeca = 0;

                    Decimal ImpReal = 0;
                    dt2 = ocnConceptosIntereses.ObtenerInteresxconIdxNroCuotaPatagonia(Convert.ToInt32(row["conId"].ToString()), (Convert.ToInt32(row["IcoNroCuota"].ToString())));

                    if (dt2.Rows.Count > 0)
                    {
                        DateTime fchVto1 = Convert.ToDateTime(dt2.Rows[0]["FechaVto"].ToString());
                        DateTime fchVto2 = Convert.ToDateTime(dt2.Rows[1]["FechaVto"].ToString());
                        //DateTime fchVto3 = Convert.ToDateTime(dt2.Rows[2]["FechaVto"].ToString());

                        // ver tema beca
                        if (Convert.ToInt32(dt2.Rows[0]["coiAplicaBeca"].ToString()) == 1)
                        {
                            ImpConBeca = Convert.ToDecimal(row["ImpConBeca"].ToString());
                        }
                        else
                        {
                            ImpConBeca = Convert.ToDecimal(row["icoImporte"].ToString());
                        }

                        if (ddlDisparo.SelectedValue == "1")
                        {
                            ImpReal = ImpConBeca;
                        }
                        else
                        {
                            if (ddlDisparo.SelectedValue == "2")
                            {
                                ImpReal = ImpConBeca + Convert.ToDecimal(dt2.Rows[1]["ValorInteres"].ToString());
                            }
                        }
                    }

                    //if (row["aluId"].ToString() == "14477")
                    //{
                    //    string tt = "0";
                    //    tt = row["icoNroCuota"].ToString();
                    //}

                    Detalle = "D" + row["adeDNITitular"].ToString().PadLeft(11, '0') + row["adeCBU"].ToString() + row["aluId"].ToString().PadLeft(7, '0') + " ".ToString().PadRight(15, ' ')
                     + (dateString.ToString("ddMMyyyy")) + "CUOTA".ToString().PadRight(10, ' ')
                     + " ".ToString().PadRight(4, ' ') + "0".ToString().PadRight(11, '0')
                     + row["icoNroCuota"].ToString().PadRight(15, ' ') + (Convert.ToSingle(ImpReal) * 100).ToString().PadLeft(10, '0') + "P" +
                      " ".ToString().PadRight(22, ' ') + "0".ToString().PadRight(14, '0') + " ".ToString().PadRight(6, ' ') +
                    "0".ToString().PadRight(15, '0') + "0".ToString().PadRight(8, '0') + " ".ToString().PadRight(9, ' ') + "30530322617";
                    //"0".ToString().PadRight(23, '0') + " ".ToString().PadRight(9, '0')

                    //ocnArchivoPatagonia.InsertarDetalle();

                    ocnArchivoPatagonia.arpCabecera = Cabecera;
                    ocnArchivoPatagonia.arpDetalle = Detalle;
                    ocnArchivoPatagonia.arpCodAlumno = Convert.ToInt32(row["aluId"].ToString());
                    ocnArchivoPatagonia.arpCole = Convert.ToInt32(row["insId"].ToString());
                    ocnArchivoPatagonia.arpApeyNom = row["aluNombre"].ToString();
                    ocnArchivoPatagonia.arpDni = row["aluDoc"].ToString();
                    ocnArchivoPatagonia.arpImporte = ImpReal;
                    ocnArchivoPatagonia.arpNumCuota = row["icoNroCuota"].ToString();
                    ocnArchivoPatagonia.arpCurso = row["curNombre"].ToString();
                    ocnArchivoPatagonia.arpAnioLectivo = Convert.ToInt32(row["conAniolectivo"].ToString());
                    ocnArchivoPatagonia.arpFinal = "";
                    ocnArchivoPatagonia.Insertar();

                    //ocnArchivoPatagonia.InsertarDetalle();
                }


                Double TotalPrimerVto;
                TotalPrimerVto = 0;
                dtTot = ocnArchivoPatagonia.ObtenerTotales();

                if (dtTot.Rows.Count > 0)
                {
                    TotalPrimerVto = Convert.ToDouble(dtTot.Rows[0]["P"].ToString()) * 100;
                }

                String Pie;
                Pie = "T" + TotRegistros.ToString().PadLeft(7, '0') + TotalPrimerVto.ToString().PadLeft(15, '0') +
                 " ".ToString().PadRight(177, ' ');
                ocnArchivoPatagonia.arpDetalle = Pie;
                ocnArchivoPatagonia.InsertarDetalle();

                //ocnArchivoBanco.InsertarCuerpo();

                String Path;

                Path = "~/PaginasGenerales/ArchivosPatagonia/";
                Path = MapPath(Path);  //System.Web.UI.Page.Server.MapPath(NomRep);
                Mje.Visible = true;
                dtCA = ocnArchivoPatagonia.ObtenerTodo();
                if (dtCA.Rows.Count > 0)
                {
                    FuncionesUtiles.crearArchivoTxt(dtCA, Path, NombreArchivo);
                }
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "No existen registros..";
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


    void Caja()
    {
        try
        {
            Mje.Visible = false;
            //imgUpdateProgress.Visible = true;
            DataTable dt1 = new DataTable();
            DataTable dtCA = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtTot = new DataTable();
            //Int32 insid, Int32 conId, Int32 conAnioLectivo
            insId = Convert.ToInt32(lblInsId.Text);
            float Recargo = 0;
            String[] Cuotas;
            Cuotas = new String[3];
            String[] Vtos;
            Vtos = new String[3];
            float[] ImpMes;
            ImpMes = new float[3];

            String[] AplicaBeca;
            AplicaBeca = new String[3];
            String[] AplicaInteresAbierto;
            AplicaInteresAbierto = new String[3];

            String ApellidoyNombre;
            String Cuerpo, barra, DiasVtoEntreUnoyDos;

            ocnArchivoBanco.Eliminar();

            Int32 TotRegistros;

            dt1 = ocnInscripcionConcepto.ArchivoBancoObtenerporVarios(insId, Convert.ToInt32(cntId.SelectedValue), Convert.ToInt32(conAnioLectivo.Text));
            if (dt1.Rows.Count > 0)
            {

                String NombreArchivo = dt1.Rows[0]["InsCodigo"].ToString().PadLeft(4, '0') + DateTime.Now.ToString("MMyyyy") + ".txt";
                String Cabecera;
                Cabecera = dt1.Rows[0]["InsCodigo"].ToString().PadLeft(4, '0') + DateTime.Now.ToString("ddMMyy");
                ocnArchivoBanco.Cuerpo = Cabecera;
                ocnArchivoBanco.InsertarCuerpo();

                TotRegistros = dt1.Rows.Count + 2;

                Single intMensual = '0';
                //Single ImpConBecaConInteresMensualCalculado = '0';
                //Single interesMensualCalculado = '0';
                Single ImpConBeca = '0';
                int NroCuota = 0;
                int NroCuotaSegunFechaEmision = 0;
                int MultiplicadorCuotas = 0;
                int CantVtos = 0;



                foreach (DataRow row in dt1.Rows)
                {

                    NroCuota = Convert.ToInt32(row["icoNroCuota"].ToString());
                    //NroCuotaSegunFechaEmision = Convert.ToInt32(txtDesde.Text.ToString().Substring(3, 2)) - 3;
                    NroCuotaSegunFechaEmision = Convert.ToInt32(txtDesde.Text.ToString().Substring(3, 2)) - Convert.ToInt32(row["conMesInicio"].ToString());
                    if (NroCuotaSegunFechaEmision <= 0)
                    {
                        NroCuotaSegunFechaEmision = 1;
                    }
                    //MultiplicadorCuotas = (NroCuota +1) - NroCuotaSegunFechaEmision;
                    MultiplicadorCuotas = (NroCuotaSegunFechaEmision + 1) - NroCuota;
                    if (MultiplicadorCuotas  <0)
                    {
                        MultiplicadorCuotas = 1;
                    }

                    //ImpConBecaConInteresMensualCalculado = Convert.ToSingle(row["ImpConBecaConInteresMensualCalculado"].ToString());
                        intMensual = Convert.ToSingle(row["ConInteresMensual"].ToString());
                    //interesMensualCalculado = Convert.ToSingle(row["InteresMensualCalculado"].ToString());
                    ImpConBeca = Convert.ToSingle(row["ImpConBeca"].ToString());
                    CantVtos = Convert.ToInt32(row["conCantVtos"].ToString());




                    //Int32 ooo, rrr, fff, lll;
                    //ooo = Convert.ToInt32(row["aluId"].ToString());
                    //rrr = Convert.ToInt32(dt1.Rows[0]["IcoNroCuota"].ToString());
                    //fff = Convert.ToInt32(dt1.Rows[0]["ConAnioLectivo"].ToString());

                    //if (ooo == 193)
                    //{
                    //    lll = 1;
                    //}


                    Cuotas[0] = row["IcoNroCuota"].ToString();
                    Cuotas[1] = row["conMesInicio"].ToString();
                    Cuotas[2] = String.Format(row["IcoNroCuota"].ToString(), "00");
                    Int32 C = 0;

                    String pok = "0";
                    String pdni = row["aluDoc"].ToString();
                    if (pdni == "57459996") // || pdni == "45659869"
                    {
                        pok = "1";
                    }
                    Session.Add("aluDoc", pdni);

                    AplicaBeca[0] = "";
                    AplicaBeca[1] = "";
                    AplicaBeca[2] = "";
                    AplicaInteresAbierto[0] = "";
                    AplicaInteresAbierto[1] = "";
                    AplicaInteresAbierto[2] = "";
                    Vtos[0] = "";
                    Vtos[1] = "";
                    Vtos[2] = "";
                    ImpMes[0] = 0;
                    ImpMes[1] = 0;
                    ImpMes[2] = 0;


                    int conidp = Convert.ToInt32(row["conId"].ToString());
                    int nrocuotap = Convert.ToInt32(row["IcoNroCuota"].ToString());

                    dt2 = ocnConceptosIntereses.ObtenerListaxconIdxNroCuota(Convert.ToInt32(row["conId"].ToString()), (Convert.ToInt32(row["IcoNroCuota"].ToString())));
                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            AplicaBeca[C] = row2["coiAplicaBeca"].ToString();
                            AplicaInteresAbierto[C] = row2["coiAplicaInteresAbierto"].ToString();

                            Vtos[C] = row2["FechaVto"].ToString();
                            Recargo += Convert.ToSingle(row2["coiValorInteres"].ToString());
                            if (row2["coiAplicaBeca"].ToString() == "1")
                            {
                                ImpMes[C] = Convert.ToSingle(row["ImpConBeca"].ToString()) + Convert.ToSingle(row2["coiValorInteres"].ToString());
                            }
                            else
                            {
                                ImpMes[C] = Convert.ToSingle(row["icoImporte"].ToString()) + Convert.ToSingle(row2["coiValorInteres"].ToString());
                            }
                            C += 1;
                        }
                    } else
                    {
                        // POr aquí ingresa cuando hay problemas con los nros de cuota generados
                        int CCuo = 1;
                    }
                    if (C == 2 && Vtos[2] == "")  // Si solo tiene 2 Vtos definidos pongo como 3 Vto al 2 Vto para evaluar más abajo si aplica interés mensual o no
                    {
                        if (intMensual > 0)
                        {
                            Vtos[2] = Vtos[1];
                        }
                        else
                        {
                            Vtos[2] = txtHasta.Text;
                        }

                    }
                    if (row["conTieneVtoAbierto"].ToString() == "1")
                    {
                        if (AplicaInteresAbierto[C - 1] == "0")
                        {
                            if (AplicaBeca[C - 1] == "1")
                            {
                                Recargo = Convert.ToSingle(row["ImpConBeca"].ToString());
                                ImpMes[C] = Convert.ToSingle(row["ImpConBeca"].ToString());
                            }
                            else
                            {
                                Recargo = Convert.ToSingle(row["icoImporte"].ToString());
                                ImpMes[C] = Convert.ToSingle(row["icoImporte"].ToString());
                            }
                        }
                        else
                        {
                            Recargo = Convert.ToSingle(row["icoImporte"].ToString()) + Convert.ToSingle(row["conRecargoVtoAbierto"].ToString());
                            ImpMes[C] = Convert.ToSingle(row["icoImporte"].ToString()) + Convert.ToSingle(row["conRecargoVtoAbierto"].ToString());
                        }
                    }
                    else
                    {
                        //String eee, ccc, tttt;
                        //eee = row["aluDoc"].ToString();
                        //ccc = row["IcoNroCuota"].ToString();
                        //tttt = row["aluid"].ToString();
                        //if (tttt == "22429")
                        //{
                        //    int ppppp = 1;
                        //}
                        if (C < 3)
                        {
                            ImpMes[C] = ImpMes[C - 1];
                        }

                        //Modificado 08/02/2024
                        // Si tiene interés mensual y la fecha de generación del archivo es mayor que la del último vto, entonces, pongo en el importe
                        // de esa cuota, en el último vto, el importe de la cuota + el interés mensual
                        if (intMensual > 0 && Convert.ToDateTime(txtDesde.Text.ToString()) > Convert.ToDateTime(Vtos[2].ToString()))  //&& CantVtos == 2
                        {
                            //ImpMes[2] = (interesMensualCalculado * MultiplicadorCuotas) + ImpMes[1];
                            //Single pp = (((ImpMes[1] * intMensual) / 100) * MultiplicadorCuotas);
                            //ImpMes[2] = (((ImpMes[0] * intMensual) / 100) * MultiplicadorCuotas) + ImpMes[0];    
                            //VtToString("MM/dd/yyyy");os[2] = txtHasta.Text;

                            Single ImporteConcepto = Convert.ToSingle(dt2.Rows[0]["conImporte"].ToString());
                            ImpMes[2] = (((ImporteConcepto * intMensual) / 100) * MultiplicadorCuotas) + ImpMes[2];


                            //Convert.ToDateTime(txtDesde.Text).
                            DateTime oPrimerDiaDelMes = new DateTime(Convert.ToDateTime(txtDesde.Text).Year, Convert.ToDateTime(txtDesde.Text).Month, 1);
                            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);
                            Vtos[2] = oUltimoDiaDelMes.ToString("dd/MM/yyyy");
                        }

                    }

                    //Cuotas(2) = Format("01/" & (recbusco!MesInicio + (recbusco!CodValor - 1)), "mmmm")

                    int conmesinicioP = Convert.ToInt32(row["ConMesInicio"]);
                    int IcoNroCuotaP = Convert.ToInt32(row["IcoNroCuota"]);

                    int MesArchivo = Convert.ToInt32(row["ConMesInicio"]) + Convert.ToInt32(row["IcoNroCuota"]) - 1;

                    String mesanio = Convert.ToDateTime(MesArchivo.ToString() + "/" + row["icuAnoCursado"]).ToString("MMMM yyyy");

                    ApellidoyNombre = row["aluNombre"].ToString();
                    if (row["cntId"].ToString() == "1")
                    {
                        ApellidoyNombre = "Inscripción " + row["icuAnoCursado"].ToString() + " - " + ApellidoyNombre;
                    }
                    else
                    {
                        ApellidoyNombre = mesanio + " - " + ApellidoyNombre;
                    }

                    if (ApellidoyNombre.Length < 40)
                    {
                        ApellidoyNombre = ApellidoyNombre.PadRight(40);
                    }
                    if (ApellidoyNombre.Length > 40)
                    {
                        ApellidoyNombre = ApellidoyNombre.Substring(0, 40);
                    }

                    //if (Convert.ToInt32(row["conAniolectivo"].ToString()) == 2023)
                    //{
                    //    int lllo = 0;
                    //}


                    //string.Format("{0:000000000000}",  dt1.Rows[0]["aluDoc"].ToString());
                    //myString.PadLeft(myString.Length + 5, '0');
                    Cuerpo = row["aluDoc"].ToString().PadLeft(12, '0');  // Format("000000000000");
                    Cuerpo = Cuerpo + ApellidoyNombre;
                    Cuerpo = Cuerpo + Convert.ToDateTime(Vtos[0]).ToString("ddMMyy");
                    Double ImpMes0 = ImpMes[0] * 100;
                    Cuerpo = Cuerpo + ImpMes0.ToString().PadLeft(10, '0');  //Format(CStr(ImpsMes(1) * 100), "0000000000")
                    Cuerpo = Cuerpo + Convert.ToDateTime(Vtos[1]).ToString("ddMMyy");
                    Double ImpMes1 = ImpMes[1] * 100;
                    Cuerpo = Cuerpo + ImpMes1.ToString().PadLeft(10, '0');
                    Cuerpo = Cuerpo + Convert.ToDateTime(Vtos[2]).ToString("ddMMyy");
                    Double ImpMes2 = ImpMes[2] * 100;
                    Cuerpo = Cuerpo + ImpMes2.ToString().PadLeft(10, '0');

                    barra = "4" + row["insCodigo"].ToString().PadLeft(3, '0');   // string.Format("{0:C3}", dt1.Rows[0]["insCodigo"].ToString());
                    barra = barra + row["insId"].ToString().PadLeft(3, '0');   //string.Format("{0:C3}", dt1.Rows[0]["insId"].ToString());
                    barra = barra + row["aluId"].ToString().PadLeft(5, '0');   //string.Format("{0:C5}", dt1.Rows[0]["aluId"].ToString());
                    barra = barra + Cuotas[2].ToString().PadLeft(2, '0');     //string.Format("{0:C2}", Cuotas[2]);
                                                                              //String pp = (Convert.ToInt32(Convert.ToDateTime(Vtos[0]).ToString("yyyyMMdd")) - Convert.ToInt32(Convert.ToDateTime("1/1/1996").ToString("yyyyMMdd"))).ToString().PadLeft(4, '0');



                    if (Convert.ToInt32((Convert.ToDateTime(Vtos[1]) - Convert.ToDateTime("1/1/2022")).TotalDays.ToString()) <= 9999)
                    //if (Convert.ToInt32(Convert.ToDateTime(Vtos[0]).ToString("yyyyMMdd")) - Convert.ToInt32(Convert.ToDateTime("1/1/1996").ToString("yyyyMMdd")) <= 9999)
                    {
                        String barra1 = (Convert.ToDateTime(Vtos[0]) - Convert.ToDateTime("01/01/2022")).TotalDays.ToString().PadLeft(4, '0');
                        barra = barra + (Convert.ToDateTime(Vtos[0]) - Convert.ToDateTime("01/01/2022")).TotalDays.ToString().PadLeft(4, '0');
                        //barra = barra + (Convert.ToInt32(Convert.ToDateTime(Vtos[0]).ToString("yyyyMMdd")) - Convert.ToInt32(Convert.ToDateTime("01/01/1996").ToString("yyyyMMdd"))).ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        barra = barra + "9999";
                    }


                    //string pppppp = Convert.ToString(row["icuAnoCursado"].ToString());
                    //if (pppppp == "2025")
                    //{
                    //    int qqqqq = 1;
                    //}
                    //if(row["aluDoc"].ToString() == "57441264")
                    //{
                    //    int yyyyyy = 1;
                    //}
                    barra = barra + (ImpMes[0] * 10).ToString().PadLeft(8, '0').ToString();    //string.Format("{0:C6}", (ImpMes[0] * 10).ToString());
                    //barra = barra + (ImpMes[0] * 10).ToString().PadLeft(6, '0');   //string.Format("{0:C6}", (ImpMes[0] * 10).ToString());

                    DiasVtoEntreUnoyDos = "99";
                    if (Convert.ToInt32((Convert.ToDateTime(Vtos[1]) - Convert.ToDateTime(Vtos[0])).TotalDays.ToString()) <= 99)
                    {
                        DiasVtoEntreUnoyDos = (Convert.ToDateTime(Vtos[1]) - Convert.ToDateTime(Vtos[0])).TotalDays.ToString().PadLeft(2, '0');
                        //DiasVtoEntreUnoyDos = (Convert.ToInt32(Convert.ToDateTime(Vtos[1]).ToString("yyyyMMdd")) - Convert.ToInt32(Convert.ToDateTime(Vtos[0]).ToString("yyyyMMdd"))).ToString().PadLeft(2, '0');
                    }
                    barra = barra + DiasVtoEntreUnoyDos;

                    //barra = barra + ((Convert.ToSingle(ImpMes[1]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(4, '0');
                    // 11-02-2024 Aquí está el error porque $2700 *10 = 27000 (5 posiciones y debería mandar 4...
                    barra = barra + ((Convert.ToSingle(ImpMes[1]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(5, '0').Substring(0, 5);
                    String DiferenciaImporte2 = ((Convert.ToSingle(ImpMes[1]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(5, '0');   //.PadLeft(5, '0');
                    if (DiferenciaImporte2.Length > 5)
                    {
                        DiferenciaImporte2 = DiferenciaImporte2.Substring(0, 5);
                    }
                    barra = barra + DiferenciaImporte2;


                    String fechaVto2 = Vtos[2];
                    String fechaVto0 = Vtos[0];


                    if (Convert.ToInt32((Convert.ToDateTime(Vtos[2]) - Convert.ToDateTime(Vtos[0])).TotalDays.ToString()) <= 999)
                    {
                        // barra = barra + (Convert.ToInt32(Convert.ToDateTime(Vtos[2]).ToString("yyyyMMdd")) - Convert.ToInt32(Convert.ToDateTime(Vtos[0]).ToString("yyyyMMdd"))).ToString().PadLeft(3, '0');   //Format(CInt((CDate(Vtos(3)) - CDate(Vtos(1)))), "000")
                        barra = barra + (Convert.ToDateTime(Vtos[2]) - Convert.ToDateTime(Vtos[0])).TotalDays.ToString().PadLeft(3, '0');   //Format(CInt((CDate(Vtos(3)) - CDate(Vtos(1)))), "000")
                    }
                    else
                    {
                        barra = barra + "999";
                    }
                    //barra = barra + ((Convert.ToSingle(ImpMes[1]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(4, '0');
                    //barra = barra + ((Convert.ToSingle(ImpMes[2]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(4, '0');   // Format(((ImpsMes(3) - CSng(ImpsMes(1))) * 10), "0000")


                    // IMPORTANTE !!!!
                    // Tener en cuenta que en el año 2024 si la diferencia en $ es mayor a 9.999 entonces el valor se expresa sin decimales por la multiplicación por 10
                    // Estos datos q viajan en el código de barra no se utilizan en la caja para leer los importes
                    ////////////////

                    // Cambio a 5 dígitos 17/02/2024
                    //barra = barra + ((Convert.ToSingle(ImpMes[1]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(4, '0');
                    String DiferenciaImporte3 = ((Convert.ToSingle(ImpMes[2]) - Convert.ToSingle(ImpMes[0])) * 10).ToString().PadLeft(5, '0');   //.PadLeft(5, '0');
                    if (DiferenciaImporte3.Length > 5)
                    {
                        DiferenciaImporte3 = DiferenciaImporte3.Substring(0, 5);
                    }
                    barra = barra + DiferenciaImporte3;



                    Cuerpo = Cuerpo + barra;

                    ocnArchivoBanco.barra = barra;
                    ocnArchivoBanco.codcole = Convert.ToInt32(row["insId"].ToString());
                    ocnArchivoBanco.codalumno = Convert.ToInt32(row["aluId"].ToString());
                    ocnArchivoBanco.apellidoynombre = row["aluNombre"].ToString();
                    ocnArchivoBanco.telef = row["aluTelefono"].ToString();
                    ocnArchivoBanco.dni = row["aluDoc"].ToString();
                    ocnArchivoBanco.numcuota = row["icoNroCuota"].ToString();
                    ocnArchivoBanco.privto = Convert.ToDateTime(Vtos[0]).ToString("dd/MM/yy"); //string.Format("{0:dd/mm/yy}", Vtos[0]);
                    ocnArchivoBanco.priimporte = Convert.ToDecimal(ImpMes[0]);
                    ocnArchivoBanco.segvto = Convert.ToDateTime(Vtos[1]).ToString("dd/MM/yy");
                    ocnArchivoBanco.segimporte = Convert.ToDecimal(ImpMes[1]);
                    ocnArchivoBanco.tervto = Convert.ToDateTime(Vtos[2]).ToString("dd/MM/yy");
                    ocnArchivoBanco.impabierto = Convert.ToDecimal(ImpMes[2]);
                    ocnArchivoBanco.concepto = row["conNombre"].ToString();
                    ocnArchivoBanco.curso = row["curNombre"].ToString();
                    ocnArchivoBanco.aniolectivo = Convert.ToInt32(row["conAniolectivo"].ToString());
                    ocnArchivoBanco.beca = row["becNombre"].ToString();
                    ocnArchivoBanco.Cuerpo = Cuerpo;
                    ocnArchivoBanco.Insertar();


                }


                Double TotalPrimerVto, TotalSegVto, TotalTerVto;
                TotalPrimerVto = 0;
                TotalSegVto = 0;
                TotalTerVto = 0;
                dtTot = ocnArchivoBanco.ObtenerTotales();



                if (dtTot.Rows.Count > 0)
                {
                    TotalPrimerVto = Convert.ToDouble(dtTot.Rows[0]["P"].ToString());
                    TotalSegVto = Convert.ToDouble(dtTot.Rows[0]["S"].ToString());
                    TotalTerVto = Convert.ToDouble(dtTot.Rows[0]["T"].ToString());
                    TotalPrimerVto = TotalPrimerVto * 100;
                    TotalSegVto = TotalSegVto * 100;
                    TotalTerVto = TotalTerVto * 100;
                }

                String Pie;
                Pie = TotRegistros.ToString().PadLeft(12, '0') + TotalPrimerVto.ToString().PadLeft(18, '0') + TotalSegVto.ToString().PadLeft(18, '0') + TotalTerVto.ToString().PadLeft(18, '0');
                ocnArchivoBanco.Cuerpo = Pie;
                ocnArchivoBanco.InsertarCuerpo();


                String Path;

                Path = "~/PaginasGenerales/ArchivosCaja/";
                Path = MapPath(Path);  //System.Web.UI.Page.Server.MapPath(NomRep);
                Mje.Visible = true;
                dtCA = ocnArchivoBanco.ObtenerTodo();
                if (dtCA.Rows.Count > 0)
                {
                    FuncionesUtiles.crearArchivoTxt(dtCA, Path, NombreArchivo);
                }
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = Session["aluDoc"] + @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
        //imgUpdateProgress.Visible = false;
    }





    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            alerError.Visible = false;
            Mje.Visible = false;
            if (BcoAdhId.SelectedValue == "1")
            {
                Caja();
            }
            else
            {
                DateTime dateString = Convert.ToDateTime(txtDesde.Text);

                String diaHoy = Convert.ToString(dateString.Day);
                String mesHoy = Convert.ToString(dateString.Month);

                if (mesHoy == "2")
                {
                    if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27))
                    {
                        ddlDesde.SelectedValue = "1";
                        ddlDisparo.SelectedValue = "1";
                        //FchImputar.Text = "01/03/" + DateTime.Now.ToString("yyyy");

                    }
                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "No se encuentra en fecha para liquidar";
                        return;
                    }
                }

                else
                {
                    if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27))
                    {
                        ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 2); // 3 es mes de Inicio
                        //FchImputar.Text = "01/" + Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 2) + "/" + DateTime.Now.ToString("yyyy");

                        ddlDisparo.SelectedValue = "1";
                    }
                    else
                    {
                        if ((Convert.ToInt32(diaHoy) >= 1) & (Convert.ToInt32(diaHoy) <= 13))
                        {
                            ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 1);
                            //FchImputar.Text = "01/" + Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 1) + "/" + DateTime.Now.ToString("yyyy");

                            ddlDisparo.SelectedValue = "2";
                        }
                        else
                        {
                            alerError.Visible = true;
                            lblError.Text = "No se encuentra en fecha para liquidar";
                            return;
                        }
                    }
                }


                Patagonia();
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

    protected void BcoAdhId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        Mje.Visible = false;
        if (BcoAdhId.SelectedValue == "2")
        {
            DateTime dateString = Convert.ToDateTime(txtDesde.Text);

            String diaHoy = Convert.ToString(dateString.Day);
            String mesHoy = Convert.ToString(dateString.Month);
            if (mesHoy == "2")
            {
                if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27))
                {
                    ddlDesde.SelectedValue = "1";
                    ddlDisparo.SelectedValue = "1";
                    FchImputar.Text = "01/03/" + DateTime.Now.ToString("yyyy");

                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra en fecha para generar el archivo..";
                }
            }

            else
            {
                if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27))
                {
                    ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 2); // 3 es mes de Inicio
                    FchImputar.Text = "01/" + Convert.ToString(Convert.ToInt32(mesHoy) + 1) + "/" + DateTime.Now.ToString("yyyy");

                    ddlDisparo.SelectedValue = "1";
                }
                else
                {
                    if ((Convert.ToInt32(diaHoy) >= 1) & (Convert.ToInt32(diaHoy) <= 13))
                    {
                        ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 1);
                        FchImputar.Text = "16/" + Convert.ToString(Convert.ToInt32(mesHoy)) + "/" + DateTime.Now.ToString("yyyy");

                        ddlDisparo.SelectedValue = "2";
                    }
                    else
                    {
                        alerError.Visible = true;
                        lblError.Text = "No se encuentra en fecha para generar el archivo..";
                    }
                }
            }
            ddlDisparo.Visible = true;
            //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
            cntId.Enabled = false;
            conAnioLectivo.Enabled = false;
            cntId.SelectedIndex = 1;
            txtDesde.Enabled = true;
            txtHasta.Enabled = false;
            txtDesde.Visible = true;
            txtHasta.Visible = false;
            ddlDesde.Visible = true;
            //ddlDesde.Enabled = false;
            ddlDesde.Enabled = true;
            ddlDisparo.Visible = true;
            lblDisparo.Visible = true;
            //ddlDisparo.Enabled = false;
            ddlDisparo.Enabled = true;
            lblDesde.Visible = true;
            lblFchEmi.Visible = true;
            lblFchAbi.Visible = false;
            LeyendaPatagonia.Visible = true;
            lblFchImputar.Visible = true;
            FchImputar.Visible = true;
        }
        else
        {
            txtDesde.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cntId.Enabled = true;
            conAnioLectivo.Enabled = true;
            txtDesde.Enabled = true;
            txtHasta.Enabled = true;
            txtDesde.Visible = true;
            txtHasta.Visible = true;
            ddlDesde.Visible = false;
            ddlDisparo.Visible = false;
            lblDesde.Visible = false;
            lblDisparo.Visible = false;
            lblFchEmi.Visible = true;
            lblFchAbi.Visible = true;
            LeyendaPatagonia.Visible = false;
            lblFchImputar.Visible = true;
            FchImputar.Visible = true;
            lblFchImputar.Visible = false;
            FchImputar.Visible = false;
        }
    }

    protected void txtDesde_TextChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        Mje.Visible = false;
        DateTime dateString = Convert.ToDateTime(txtDesde.Text);

        String diaHoy = Convert.ToString(dateString.Day);
        String mesHoy = Convert.ToString(dateString.Month);
        if (mesHoy == "2")
        {
            if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27)) // SOLO PARA 2024
            {
                ddlDesde.SelectedValue = "1";
                FchImputar.Text = "01/03/" + DateTime.Now.ToString("yyyy");

                ddlDisparo.SelectedValue = "1";
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "No se encuentra en fecha para liquidar";
            }
        }

        else
        {
            if ((Convert.ToInt32(diaHoy) >= 16) & (Convert.ToInt32(diaHoy) <= 27))
            {
                ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 2); // 3 es mes de Inicio
                FchImputar.Text = "01/" + Convert.ToString(Convert.ToInt32(mesHoy) + 1) + "/" + DateTime.Now.ToString("yyyy");

                ddlDisparo.SelectedValue = "1";
            }
            else
            {
                if ((Convert.ToInt32(diaHoy) >= 1) & (Convert.ToInt32(diaHoy) <= 8))
                {
                    ddlDesde.SelectedValue = Convert.ToString(Convert.ToInt32(mesHoy) - 3 + 1);
                    FchImputar.Text = "16/" + Convert.ToString(Convert.ToInt32(mesHoy)) + "/" + DateTime.Now.ToString("yyyy");

                    ddlDisparo.SelectedValue = "2";
                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra en fecha para liquidar";
                }
            }
        }
    }
}


