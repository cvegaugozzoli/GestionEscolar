using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


public partial class Preinscripcion : System.Web.UI.Page
{
    ReportDocument cryRpt;
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();

    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstitucion = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();

    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.CupoCursos ocnCupoCursos = new GESTIONESCOLAR.Negocio.CupoCursos();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    GESTIONESCOLAR.Negocio.Departamento ocnDepartamento = new GESTIONESCOLAR.Negocio.Departamento();
    GESTIONESCOLAR.Negocio.Empleado ocnEmpleado = new GESTIONESCOLAR.Negocio.Empleado();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.TemporalPreinscripcion ocnTemporalPreinscripcion = new GESTIONESCOLAR.Negocio.TemporalPreinscripcion();
    GESTIONESCOLAR.Datos.Gestor ocdGestor = new GESTIONESCOLAR.Datos.Gestor();
    GESTIONESCOLAR.Negocio.UsuarioPerfil ocnUsuarioPerfil = new GESTIONESCOLAR.Negocio.UsuarioPerfil();

    GESTIONESCOLAR.Negocio.Parametro ocnParametro = new GESTIONESCOLAR.Negocio.Parametro();
    DataTable dt = new DataTable();

    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable dt7 = new DataTable();

    DataTable dt8 = new DataTable();
    int CupoValidar = 0;
    int aluId2 = 0;
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                dt8 = ocnInstitucion.ObtenerUno(insId);
                int Anio = 0;
                String NombreColegio = Convert.ToString(dt8.Rows[0]["Nombre"].ToString());
                if (Convert.ToInt32(DateTime.Today.Month) < 6)
                {
                    Anio = DateTime.Today.Year;
                }
                else
                {
                    Anio = DateTime.Today.Year + 1;
                }
                txtaniolectivo.Text = Anio.ToString();
                this.Master.TituloDelFormulario = "Preinscripción";  // + " " + Anio;


                DepartamentoId.DataValueField = "Valor"; DepartamentoId.DataTextField = "Texto"; DepartamentoId.DataSource = (new GESTIONESCOLAR.Negocio.Departamento()).ObtenerLista("[Seleccionar...]"); DepartamentoId.DataBind();
                sexId.DataValueField = "Valor"; sexId.DataTextField = "Texto"; sexId.DataSource = (new GESTIONESCOLAR.Negocio.Sexo()).ObtenerLista("[Seleccionar...]"); sexId.DataBind();
                alert.Visible = false;
                alertExito.Visible = false;
                Session["Bandera"] = 0;
                lblAfiliacion.Text = "Hermano";
                lblAfiliacion.Visible = false;
                lblMensajeError.Text = "";
                Panel1.Visible = false; // or false
                btnPreincribir.Enabled = true;
                btnFinalizar.Visible = false;
                //btnVolver.Visible = false;
                alerDNI.Visible = false;
                aletRepite.Visible = false;
                alerSnJose.Visible = false;
                alerMisericordia.Visible = false;
                alerJardin.Visible = false;
                alerSanVicente.Visible = false;
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

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            insId = Convert.ToInt32(Session["_Institucion"]);

            if (rblCurso.Items.Count == 1)
            {
                rblCurso.Items.Insert(1, "Salita 3");
                rblCurso.Items.Insert(2, "Salita 4");
                rblCurso.Items.Insert(3, "Salita 5");
            }

            if (rblCurso.Items.Count == 2 & insId == 1)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }
            if (rblCurso.Items.Count == 2 & insId == 5)
            {
                rblCurso.Items.Insert(0, "1 Grado");
                rblCurso.Items.Insert(3, "Salita 5");
            }
            if (rblCurso.Items.Count == 3 & insId == 1)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }

            if (rblCurso.Items.Count == 3 & insId == 5)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }
            if (rblCurso.Items.Count == 3 & insId == 4)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }
            if (rblTurno.Items.Count == 1)
            {
                rblTurno.Items.Insert(1, "Tarde");
            }

            if (rblCurso.Items.Count == 2 & insId == 4)
            {
                rblCurso.Items.Insert(0, "1 Grado");
                rblCurso.Items.Insert(3, "Salita 5");
            }

            if (rblCurso.Items.Count == 4 & insId == 4)
            {
                //rblCurso.Items.Insert(0, "1 Grado");
                rblCurso.Items.Insert(3, "Salita 5");
            }

            int ban;
            Panel1.Visible = false;
            txtNombre.Text = "";
            txtDni.Text = "";
            if (RbtBuscar.SelectedIndex == 1) //la busqueda será por Empleado
            {
                if (TextBuscar.Text == "12345678") //la busqueda será por Empleado
                {
                    ban = 1;
                    lblAfiliacion.Text = " ";
                }
                else
                {
                    ban = 1;
                    lblAfiliacion.Text = "Empleado";
                }
            }
            else
            {
                ban = 0;// la busqueda será por Alumno
                lblAfiliacion.Text = "Hermano";
            }
            Session["Bandera"] = ban;
            TextBuscar.Text = "";
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
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);

            DataTable dtGE = new DataTable();
            dtGE.Columns.Add("icoId", typeof(int));
            dtGE.Columns.Add("conId", typeof(Int32));
            dtGE.Columns.Add("cntId", typeof(Int32));
            dtGE.Columns.Add("TipoConcepto", typeof(String));
            dtGE.Columns.Add("Concepto", typeof(String));
            dtGE.Columns.Add("RA", typeof(Decimal));
            dtGE.Columns.Add("Importe", typeof(Decimal));
            dtGE.Columns.Add("ImporteInteres", typeof(Decimal));
            dtGE.Columns.Add("AnioLectivo", typeof(Decimal));
            dtGE.Columns.Add("Beca", typeof(String));
            dtGE.Columns.Add("BecId", typeof(Int32));
            dtGE.Columns.Add("NroCuota", typeof(Int32));
            dtGE.Columns.Add("FchInscripcion", typeof(String));
            dtGE.Columns.Add("FechaVto", typeof(String));
            dtGE.Columns.Add("ValorInteres", typeof(Decimal));
            dtGE.Columns.Add("ImpPagado", typeof(Decimal));
            dtGE.Columns.Add("FechaPago", typeof(String));
            dtGE.Columns.Add("NroCompbte", typeof(String));
            dtGE.Columns.Add("Curso", typeof(String));
            dtGE.Columns.Add("Contado", typeof(String));
            dtGE.Columns.Add("Tarjeta", typeof(String));
            dtGE.Columns.Add("Cheque", typeof(String));
            dtGE.Columns.Add("TranfElec", typeof(String));
            dtGE.Columns.Add("Colegio", typeof(String));
            dtGE.Columns.Add("insId", typeof(Int32));
            DataTable dtConc = new DataTable();

            if (rblCurso.Items.Count == 1)
            {
                rblCurso.Items.Insert(1, "Salita 3");
                rblCurso.Items.Insert(2, "Salita 4");
                rblCurso.Items.Insert(3, "Salita 5");
            }

            if (rblCurso.Items.Count == 2 & insId == 1)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }
            if (rblCurso.Items.Count == 2 & insId == 5)
            {
                rblCurso.Items.Insert(0, "1 Grado");
                rblCurso.Items.Insert(3, "Salita 5");
            }
            if (rblCurso.Items.Count == 3 & insId == 1)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }

            if (rblCurso.Items.Count == 3 & insId == 5)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }
            if (rblCurso.Items.Count == 3 & insId == 4)
            {
                rblCurso.Items.Insert(0, "1 Grado");

            }
            if (rblTurno.Items.Count == 1)
            {
                rblCurso.Items.Insert(1, "Tarde");
            }

            if (rblCurso.Items.Count == 2 & insId == 4)
            {
                rblCurso.Items.Insert(0, "1 Grado");
                rblCurso.Items.Insert(3, "Salita 5");
            }


            int cant;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            int anio = DateTime.Today.Year + 1;
            insId = Convert.ToInt32(Session["_Institucion"]);
            aletRepite.Visible = false;
            alerDNI.Visible = false;
            lblMensajeError.Text = "";
            dt = new DataTable();
            dt4 = new DataTable();
            dt5 = new DataTable();
            alerSnJose.Visible = false;
            alerSanVicente.Visible = false;
            alerMisericordia.Visible = false;
            alerJardin.Visible = false;
            rblTurno.Visible = false;
            lblCurso.Visible = false;
            lblTurno.Visible = false;
            Int32 icuId2 = 0;
            int Bandera;
            //Session["CuentaCorriente.PageIndex"] = PageIndex;

            int ins_Id = 0;
            String Colegio = "";
            if (Convert.ToInt32(Session["Bandera"]) == 0)////busco x hermano
            {
                dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
                if (dt.Rows.Count > 0)//Existe hermano
                {
                    int aluId1 = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    txtNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                    txtDni.Text = Convert.ToString(dt.Rows[0]["Doc"].ToString());
                    dt4 = ocnTemporalPreinscripcion.ObtenerUnoxDoc(TextBuscar.Text.Trim());
                    if (dt4.Rows.Count == 0)//no se repitió busqueda x ese dni
                    {
                        //dt = new DataTable();
                        //dt = ocnAlumnoFamiliar.ObtenerListaFamiliar(aluId1);//Obtengo una tabla con los familiares asociado al alumno

                        alert.Visible = false;
                        Panel1.Visible = true; // or false                      
                        btnPreincribir.Enabled = true;
                        alerDNI.Visible = false;
                        aletRepite.Visible = false;

                        if (insId == 1)//San Jose
                        {

                            dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, DateTime.Today.Year);
                            if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                            {
                                icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                                Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                                dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2);
                                if (dt4.Rows.Count > 0)//ESTA REGISTRADO PARA PAGAR?
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
                                                        dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                        dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                                        DataRow row1 = dtGE.NewRow();
                                                        row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                        row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                        row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                        row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                        row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                        row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                        row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                        row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                        ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                        row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                        row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                        dtGE.Rows.Add(row1);
                                                    }
                                                    else
                                                    {
                                                        dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                        DataRow row1 = dtGE.NewRow();
                                                        row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                        row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                        row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                        row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                        row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                        row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                        row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                        ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                        row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                        row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                        dtGE.Rows.Add(row1);
                                                        Bandera = 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            int conMatricula = 0;
                            int conCuota = 0;
                            if (dtGE.Rows.Count != 0)
                            {
                                DateTime Hoy = DateTime.Today;
                                foreach (DataRow row in dtGE.Rows)
                                {
                                    if (Convert.ToDecimal(row["ImpPagado"].ToString()) != 0)
                                    {
                                        if (Convert.ToInt32(row["cntId"].ToString()) == 1)
                                        {
                                            conMatricula = conMatricula + 1;
                                        }
                                        else
                                        {
                                            conCuota = conCuota + 1;
                                        }
                                    }
                                }
                            }

                            if (conMatricula != 0)
                            {
                                if (conCuota > 4)
                                {
                                    anio = DateTime.Today.Year + 1;
                                    alerCupo.Visible = false;
                                    dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 2, 2, 68, anio, 8);
                                    dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 68, 2);
                                    if (dt.Rows.Count > 0)
                                    {
                                        cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                        if (dt2.Rows.Count < cant)
                                        {
                                            CupoValidar = 0;
                                            btnPreincribir.Enabled = true;
                                            btnFinalizar.Visible = false;
                                            //btnVolver.Visible = false;
                                            alerSnJose.Visible = true;
                                            rblCurso.Items[0].Selected = true;
                                            rblCurso.Visible = false;
                                            rblTurno.Visible = false;
                                        }
                                        else
                                        {
                                            alerCupo.Visible = true;
                                            CupoValidar = 1;
                                            btnPreincribir.Enabled = false;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                        }
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "El alumno no abonó 5 cuotas..";
                                    Panel1.Visible = false; // or false                      
                                    btnPreincribir.Enabled = false;
                                    return;
                                }
                            }
                            else
                            {
                                lblMensajeError.Text = "El alumno no abonó matricula";
                                Panel1.Visible = false; // or false                      
                                btnPreincribir.Enabled = false;
                                return;
                            }
                        }
                        else
                        {
                            if (insId == 2)//Misericordia
                            {
                                dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, DateTime.Today.Year);
                                if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                                {
                                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                    ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                                    Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                                    dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2);
                                    if (dt4.Rows.Count > 0)//ESTA REGISTRADO PARA PAGAR?
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
                                                            dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                            dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                                            DataRow row1 = dtGE.NewRow();
                                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                            row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                            row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                            dtGE.Rows.Add(row1);
                                                        }
                                                        else
                                                        {
                                                            dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                            DataRow row1 = dtGE.NewRow();
                                                            row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                            row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                            row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                            row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                            row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                            row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                            row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                            ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                            row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                            row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                            dtGE.Rows.Add(row1);
                                                            Bandera = 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                int conMatricula = 0;
                                int conCuota = 0;
                                if (dtGE.Rows.Count != 0)
                                {
                                    DateTime Hoy = DateTime.Today;
                                    foreach (DataRow row in dtGE.Rows)
                                    {
                                        if (Convert.ToDecimal(row["ImpPagado"].ToString()) != 0)
                                        {
                                            if (Convert.ToInt32(row["cntId"].ToString()) == 1)
                                            {
                                                conMatricula = conMatricula + 1;
                                            }
                                            else
                                            {
                                                conCuota = conCuota + 1;
                                            }
                                        }
                                    }
                                }

                                if (conMatricula != 0)
                                {
                                    if (conCuota > 4)
                                    {
                                        alerMisericordia.Visible = true;
                                        lblCurso.Visible = true;
                                        rblCurso.Visible = true;
                                        rblCurso.Visible = true;
                                        rblCurso.Items.RemoveAt(3);
                                        rblCurso.Items.RemoveAt(2);
                                        rblCurso.Items.RemoveAt(1);

                                        rblCurso.Items[0].Selected = true;
                                        rblCurso.Items[0].Enabled = false;

                                        lblTurno.Visible = true;
                                        rblTurno.Visible = true;
                                        rblTurno.Items[1].Selected = false;
                                        rblTurno.Items[0].Selected = false;
                                        rblTurno.Items[1].Enabled = true;
                                        rblTurno.Items[0].Enabled = true;
                                    }
                                    else
                                    {
                                        lblMensajeError.Text = "El alumno no abonó 5 cuotas..";
                                        Panel1.Visible = false; // or false                      
                                        btnPreincribir.Enabled = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "El alumno no abonó matricula";
                                    Panel1.Visible = false; // or false                      
                                    btnPreincribir.Enabled = false;
                                    return;
                                }
                            }
                            else
                            {
                                if (insId == 5)//Jardin PV
                                {
                                    dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, DateTime.Today.Year);
                                    if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                                    {
                                        icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                        ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                                        Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                                        dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2);
                                        if (dt4.Rows.Count > 0)//ESTA REGISTRADO PARA PAGAR?
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
                                                                dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                                dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                                                DataRow row1 = dtGE.NewRow();
                                                                row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                                row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                                row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                                row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                                row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                                row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                                ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                                row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                                row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                                dtGE.Rows.Add(row1);
                                                            }
                                                            else
                                                            {
                                                                dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                                DataRow row1 = dtGE.NewRow();
                                                                row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                                row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                                row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                                row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                                row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                                row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                                ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                                row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                                row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                                dtGE.Rows.Add(row1);
                                                                Bandera = 1;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    int conMatricula = 0;
                                    int conCuota = 0;
                                    if (dtGE.Rows.Count != 0)
                                    {
                                        DateTime Hoy = DateTime.Today;
                                        foreach (DataRow row in dtGE.Rows)
                                        {
                                            if (Convert.ToDecimal(row["ImpPagado"].ToString()) != 0)
                                            {
                                                if (Convert.ToInt32(row["cntId"].ToString()) == 1)
                                                {
                                                    conMatricula = conMatricula + 1;
                                                }
                                                else
                                                {
                                                    conCuota = conCuota + 1;
                                                }
                                            }
                                        }
                                    }

                                    if (conMatricula != 0)
                                    {
                                        if (conCuota > 4)
                                        {
                                            lblTurno.Visible = true;
                                            lblCurso.Visible = true;
                                            alerJardin.Visible = true;
                                            rblCurso.Visible = true;
                                            rblTurno.Visible = true;
                                            rblTurno.Enabled = true;
                                            rblCurso.Items.RemoveAt(0);

                                            rblCurso.Items[0].Enabled = true;
                                            rblCurso.Items[1].Enabled = true;
                                            rblCurso.Items[2].Enabled = true;
                                            rblCurso.Items[0].Selected = false;
                                            rblCurso.Items[1].Selected = false;
                                            rblCurso.Items[2].Selected = false;
                                            rblTurno.Items[0].Selected = false;
                                            rblTurno.Items[1].Selected = false;
                                        }
                                        else
                                        {
                                            lblMensajeError.Text = "El alumno no abonó 5 cuotas..";
                                            Panel1.Visible = false; // or false                      
                                            btnPreincribir.Enabled = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        lblMensajeError.Text = "El alumno no abonó matricula";
                                        Panel1.Visible = false; // or false                      
                                        btnPreincribir.Enabled = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (insId == 4)//Jardin misericordia
                                    {
                                        dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, DateTime.Today.Year);
                                        if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                                        {
                                            icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                            ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                                            Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                                            dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2);
                                            if (dt4.Rows.Count > 0)//ESTA REGISTRADO PARA PAGAR?
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
                                                                    dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                                    dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                                                    DataRow row1 = dtGE.NewRow();
                                                                    row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                                    row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                                    row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                                    row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                    row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                                    row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                                    row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                    row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                                    ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                                    row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                                    row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                                    dtGE.Rows.Add(row1);
                                                                }
                                                                else
                                                                {
                                                                    dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                                    DataRow row1 = dtGE.NewRow();
                                                                    row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                                    row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                                    row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                                    row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                                    row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                    row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                                    row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                                    ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                                    row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                                    row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                                    dtGE.Rows.Add(row1);
                                                                    Bandera = 1;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        int conMatricula = 0;
                                        int conCuota = 0;
                                        if (dtGE.Rows.Count != 0)
                                        {
                                            DateTime Hoy = DateTime.Today;
                                            foreach (DataRow row in dtGE.Rows)
                                            {
                                                if (Convert.ToDecimal(row["ImpPagado"].ToString()) != 0)
                                                {
                                                    if (Convert.ToInt32(row["cntId"].ToString()) == 1)
                                                    {
                                                        conMatricula = conMatricula + 1;
                                                    }
                                                    else
                                                    {
                                                        conCuota = conCuota + 1;
                                                    }
                                                }
                                            }
                                        }

                                        if (conMatricula != 0)
                                        {
                                            if (conCuota >= 4)
                                            {
                                                lblTurno.Visible = true;
                                                lblCurso.Visible = true;
                                                alerJardin.Visible = true;
                                                rblCurso.Visible = true;
                                                rblTurno.Visible = true;
                                                rblTurno.Enabled = true;
                                                rblCurso.Items.RemoveAt(0);
                                                //rblCurso.Items.RemoveAt(2);
                                                rblCurso.Items[0].Enabled = true;
                                                rblCurso.Items[1].Enabled = true;
                                                rblCurso.Items[2].Enabled = true;

                                                rblCurso.Items[0].Selected = false;
                                                rblCurso.Items[1].Selected = false;
                                                rblCurso.Items[2].Selected = false;
                                            }
                                            else
                                            {
                                                lblMensajeError.Text = "El alumno no abonó 4 cuotas..";
                                                Panel1.Visible = false; // or false                      
                                                btnPreincribir.Enabled = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            lblMensajeError.Text = "El alumno no abonó matricula";
                                            Panel1.Visible = false; // or false                      
                                            btnPreincribir.Enabled = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (insId == 3)//Escuela San Vicente
                                        {
                                            dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, DateTime.Today.Year);
                                            if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                                            {
                                                icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                                ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                                                Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                                                dt4 = ocnInscripcionConcepto.ObtenerUnoxicuId(icuId2);
                                                if (dt4.Rows.Count > 0)//ESTA REGISTRADO PARA PAGAR?
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
                                                                        dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                                        dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                                                        DataRow row1 = dtGE.NewRow();
                                                                        row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                                        row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                                        row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                                        row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                        row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                                        row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                                        row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                        row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                                        ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                                        row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                                        row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                                        dtGE.Rows.Add(row1);
                                                                    }
                                                                    else
                                                                    {
                                                                        dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(row["conId"].ToString())));
                                                                        DataRow row1 = dtGE.NewRow();
                                                                        row1["icoId"] = (Convert.ToInt32(row["Id"].ToString()));
                                                                        row1["conId"] = (Convert.ToInt32(row["conId"].ToString()));
                                                                        row1["cntId"] = (Convert.ToInt32(row2["cntId"].ToString()));
                                                                        row1["TipoConcepto"] = Convert.ToString((row2["TipoConcepto"].ToString()));
                                                                        row1["Concepto"] = Convert.ToString((row["Conceptos"].ToString()));
                                                                        row1["RA"] = Convert.ToString((row["RA"].ToString()));
                                                                        row1["NroCuota"] = (Convert.ToInt32(row["NroCuota"].ToString()));
                                                                        ImporteBecado += (Convert.ToDecimal(row["Importe"].ToString()) - (Convert.ToDecimal(row["Importe"].ToString()) * Convert.ToDecimal(row["BecasInteres"].ToString()) / 100));
                                                                        row1["Importe"] = Convert.ToDecimal(string.Format("{0:0.00}", ImporteBecado));
                                                                        row1["ImporteInteres"] = Convert.ToDecimal(dtConc.Rows[0]["InteresMensual"].ToString());
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
                                                                        dtGE.Rows.Add(row1);
                                                                        Bandera = 1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            int conMatricula = 0;
                                            int conCuota = 0;
                                            if (dtGE.Rows.Count != 0)
                                            {
                                                DateTime Hoy = DateTime.Today;
                                                foreach (DataRow row in dtGE.Rows)
                                                {
                                                    if (Convert.ToDecimal(row["ImpPagado"].ToString()) != 0)
                                                    {
                                                        if (Convert.ToInt32(row["cntId"].ToString()) == 1)
                                                        {
                                                            conMatricula = conMatricula + 1;
                                                        }
                                                        else
                                                        {
                                                            conCuota = conCuota + 1;
                                                        }
                                                    }
                                                }
                                            }

                                            if (conMatricula != 0)
                                            {
                                                if (conCuota >= 4)
                                                {
                                                    anio = DateTime.Today.Year + 1;
                                                    alerCupo.Visible = false;
                                                    dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 2, 2, 68, anio, 8);
                                                    dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 68, 2);
                                                    if (dt.Rows.Count > 0)
                                                    {
                                                        cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                                        if (dt2.Rows.Count < cant)
                                                        {
                                                            CupoValidar = 0;
                                                            btnPreincribir.Enabled = true;
                                                            btnFinalizar.Visible = false;
                                                            //btnVolver.Visible = false;
                                                            alerSanVicente.Visible = true;
                                                            rblCurso.Visible = false;
                                                            rblTurno.Visible = false;
                                                            rblCurso.Items[0].Selected = true;
                                                        }
                                                        else
                                                        {
                                                            alerCupo.Visible = true;
                                                            CupoValidar = 1;
                                                            btnPreincribir.Enabled = false;
                                                            btnFinalizar.Visible = true;
                                                            //btnVolver.Visible = true;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    lblMensajeError.Text = "El alumno no abonó 4 cuotas..";
                                                    Panel1.Visible = false; // or false                      
                                                    btnPreincribir.Enabled = false;
                                                    return;
                                                }

                                            }
                                            else
                                            {
                                                lblMensajeError.Text = "No abonó matricula";
                                                Panel1.Visible = false; // or false                      
                                                btnPreincribir.Enabled = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        aletRepite.Visible = true;
                        alerDNI.Visible = false;
                        Panel1.Visible = false;
                        txtNombre.Text = "";
                        txtDni.Text = "";
                    }
                }
                else
                {
                    alerDNI.Visible = true;
                    aletRepite.Visible = false;
                    Panel1.Visible = false;
                    txtNombre.Text = "";
                    txtDni.Text = "";
                }
            }

            else //busqueda por empleado
            {
                dt = new DataTable();
                dt = ocnEmpleado.ObtenerUnoporDoc(TextBuscar.Text.Trim());
                dt4 = ocnTemporalPreinscripcion.ObtenerUnoxDoc(TextBuscar.Text.Trim());
                if (dt.Rows.Count > 0)//busqueda x empleado o generico
                {
                    if (dt4.Rows.Count == 0 || TextBuscar.Text == "12345678")//repitió busqueda?
                    {
                        if (TextBuscar.Text == "12345678") //la busqueda será por Empleado
                        {
                            lblAfiliacion.Text = " ";
                        }
                        else
                        {
                            lblAfiliacion.Text = "Empleado";
                        }


                        txtNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                        txtDni.Text = Convert.ToString(dt.Rows[0]["Doc"].ToString());
                        alert.Visible = false;
                        Panel1.Visible = true; // or false
                        btnPreincribir.Enabled = true;
                        alerDNI.Visible = false;
                        aletRepite.Visible = false;

                        if (insId == 1)//San Jose
                        {
                            anio = DateTime.Today.Year + 1;
                            alerCupo.Visible = false;
                            dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 2, 2, 68, anio, 8);
                            dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 68, 2);
                            if (dt.Rows.Count > 0)
                            {
                                cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                if (dt2.Rows.Count < cant)
                                {
                                    CupoValidar = 0;
                                    btnPreincribir.Enabled = true;
                                    btnFinalizar.Visible = false;
                                    //btnVolver.Visible = false;
                                    alerSnJose.Visible = true;
                                    rblCurso.Items[0].Selected = true;
                                    rblCurso.Visible = false;
                                    rblTurno.Visible = false;
                                }

                                else
                                {
                                    alerCupo.Visible = true;
                                    CupoValidar = 1;
                                    btnPreincribir.Enabled = false;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                }
                            }
                            else
                            {
                                lblMensajeError.Text = "No existe Tabla Cupo";
                            }
                        }
                        else
                        {
                            if (insId == 2)//Misericordia
                            {
                                alerMisericordia.Visible = true;
                                lblCurso.Visible = true;
                                rblCurso.Visible = true;
                                rblCurso.Visible = true;
                                rblCurso.Items.RemoveAt(3);
                                rblCurso.Items.RemoveAt(2);
                                rblCurso.Items.RemoveAt(1);
                                rblCurso.Items[0].Selected = true;
                                rblCurso.Items[0].Enabled = false;
                                lblTurno.Visible = true;
                                rblTurno.Visible = true;
                                rblTurno.Items[1].Selected = false;
                                rblTurno.Items[0].Selected = false;
                                rblTurno.Items[1].Enabled = true;
                                rblTurno.Items[0].Enabled = true;
                            }
                            else
                            {
                                if (insId == 4)//Jardin misericordia 

                                {
                                    lblTurno.Visible = true;
                                    lblCurso.Visible = true;
                                    alerJardin.Visible = true;
                                    rblCurso.Visible = true;
                                    rblTurno.Visible = true;
                                    rblTurno.Enabled = true;
                                    rblCurso.Items.RemoveAt(0);
                                    rblCurso.Items.RemoveAt(2);
                                    rblCurso.Items[0].Enabled = true;
                                    rblCurso.Items[1].Enabled = true;
                                   // rblCurso.Items[2].Enabled = true;

                                    rblCurso.Items[0].Selected = false;
                                    rblCurso.Items[1].Selected = false;

                                }
                                else
                                {

                                    if (insId == 5)//Jardin PV

                                    {
                                        lblTurno.Visible = true;
                                        lblCurso.Visible = true;
                                        alerJardin.Visible = true;
                                        rblCurso.Visible = true;
                                        rblTurno.Visible = true;
                                        rblTurno.Enabled = true;
                                        rblCurso.Items.RemoveAt(0);
                                        //rblTurno.Items.RemoveAt(1);
                                        rblCurso.Items[0].Enabled = true;
                                        rblCurso.Items[1].Enabled = true;
                                        rblCurso.Items[2].Enabled = true;
                                        rblCurso.Items[0].Selected = false;
                                        rblCurso.Items[1].Selected = false;
                                        rblCurso.Items[2].Selected = false;
                                        rblTurno.Items[0].Selected = false;
                                        rblTurno.Items[1].Selected = false;
                                    }

                                    if (insId == 3)
                                    {
                                        anio = DateTime.Today.Year + 1;
                                        alerCupo.Visible = false;
                                        dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 2, 2, 68, anio, 8);
                                        dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 68, 2);
                                        if (dt.Rows.Count > 0)
                                        {
                                            cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                            if (dt2.Rows.Count < cant)
                                            {
                                                CupoValidar = 0;
                                                btnPreincribir.Enabled = true;
                                                btnFinalizar.Visible = false;
                                                //btnVolver.Visible = false;
                                                alerSanVicente.Visible = true;
                                                rblCurso.Visible = false;
                                                rblTurno.Visible = false;
                                                rblCurso.Items[0].Selected = true;
                                            }
                                            else
                                            {
                                                alerCupo.Visible = true;
                                                CupoValidar = 1;
                                                btnPreincribir.Enabled = false;
                                                btnFinalizar.Visible = true;
                                                //  btnVolver.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            lblMensajeError.Text = "No existe Tabla Cupo";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        aletRepite.Visible = true;
                        alerDNI.Visible = false;
                        Panel1.Visible = false;
                        txtNombre.Text = "";
                        txtDni.Text = "";
                    }
                }
                else
                {
                    alerDNI.Visible = true;
                    aletRepite.Visible = false;
                    Panel1.Visible = false;
                    txtNombre.Text = "";
                    txtDni.Text = "";
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

    protected void rblCurso_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);

            //if (insId != 5)
            //{
            rblTurno.Items[0].Selected = false;
            rblTurno.Items[1].Selected = false;
            rblTurno.Enabled = true;
            alerCupo.Visible = false;
            btnPreincribir.Enabled = true;
            btnFinalizar.Visible = false;
            //btnVolver.Visible = false;
            //}

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



    protected void TXTdni2_textChanged(object sender, EventArgs e)
    {
        try
        {
            dt4 = ocnAlumno.ObtenerUnoporDoc(Convert.ToString(TXTdni2.Text));
            if (dt4.Rows.Count > 0)
            {
                this.TXTdni2.Text = dt4.Rows[0]["Doc"].ToString();
                this.txtAlu.Text = dt4.Rows[0]["Nombre"].ToString();
                this.txtFecha.Text = dt4.Rows[0]["FechaNacimiento"].ToString();
                this.aluCuit.Text = dt4.Rows[0]["Cuit"].ToString();
                this.aluDomicilio.Text = dt4.Rows[0]["Domicilio"].ToString();
                this.DepartamentoId.SelectedValue = dt4.Rows[0]["DeptoId"].ToString();
                this.sexId.Text = dt4.Rows[0]["SexoId"].ToString();
                int IdAlu = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                //Response.Redirect("AlumnoRegistracion.aspx?Id=" + IdAlu, false);
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

    protected void rblTurno_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            int cant;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            int anio = DateTime.Today.Year + 1;
            CupoValidar = 0;
            alerCupo.Visible = false;
            alert.Visible = false;
            lblMensajeError.Text = "";

            if (insId == 2)//misericordia
            {
                if (Convert.ToInt32(rblCurso.SelectedValue) == 1)// 1 grado
                {
                    if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//  Mañana
                    {

                        dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 2, 2, 68, anio, 8);//traigo preinscriptos est=8
                        dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 68, 1);
                        if (dt.Rows.Count > 0)
                        {
                            cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                            if (dt2.Rows.Count < cant)
                            {
                                CupoValidar = 0;
                                btnPreincribir.Enabled = true;
                                btnFinalizar.Visible = false;
                                //btnVolver.Visible = false;
                            }
                            else
                            {
                                alerCupo.Visible = true;
                                CupoValidar = 1;
                                btnPreincribir.Enabled = false;
                                btnFinalizar.Visible = true;
                                //btnVolver.Visible = true;
                            }
                        }
                        else
                        {
                            lblMensajeError.Text = "No existe Tabla Cupo";
                        }
                    }
                    else //1 grado tarde
                    {
                        dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 2, 2, 77, anio, 8);//traigo preinscriptos est=8
                        dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 77, 2);
                        if (dt.Rows.Count > 0)
                        {
                            cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                            if (dt2.Rows.Count < cant)
                            {
                                CupoValidar = 0;
                                btnPreincribir.Enabled = true;
                                btnFinalizar.Visible = false;
                                //btnVolver.Visible = false;
                            }
                            else
                            {
                                alerCupo.Visible = true;
                                CupoValidar = 1;
                                btnPreincribir.Enabled = false;
                                btnFinalizar.Visible = true;
                                //btnVolver.Visible = true;
                            }
                        }
                        else
                        {
                            lblMensajeError.Text = "No existe Tabla Cupo";

                        }
                    }
                }
            }

            else
            {
                if (insId == 4)//jardin misericordia
                {
                    if (Convert.ToInt32(rblCurso.SelectedValue) == 2) // Salita 3
                    {
                        if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//  Mañana
                        {
                            dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 1, 1, 56, anio, 8);
                            dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 56, 1);
                            if (dt.Rows.Count > 0)
                            {
                                cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                if (dt2.Rows.Count < cant)
                                {
                                    CupoValidar = 0;
                                    btnPreincribir.Enabled = true;
                                    btnFinalizar.Visible = false;
                                    //btnVolver.Visible = false;
                                }
                                else
                                {
                                    alerCupo.Visible = true;
                                    CupoValidar = 1;
                                    btnPreincribir.Enabled = false;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                }
                            }
                            else
                            {
                                lblMensajeError.Text = "No existe Tabla Cupo";
                            }
                        }
                        else //salita 3 Tarde
                        {
                            dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 1, 1, 57, anio, 8);
                            dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 57, 2);
                            if (dt.Rows.Count > 0)
                            {
                                cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                if (dt2.Rows.Count < cant)
                                {
                                    CupoValidar = 0;
                                    btnPreincribir.Enabled = true;
                                    btnFinalizar.Visible = false;
                                    //  btnVolver.Visible = false;
                                }
                                else
                                {
                                    alerCupo.Visible = true;
                                    CupoValidar = 1;
                                    btnPreincribir.Enabled = false;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;

                                }
                            }
                            else
                            {
                                lblMensajeError.Text = "No existe Tabla Cupo";
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(rblCurso.SelectedValue) == 3) //Salita 4
                        {
                            if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//  Mañana
                            {
                                dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, 1, 1, 60, anio);
                                dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 60, 1);
                                if (dt.Rows.Count > 0)
                                {
                                    cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                    if (dt2.Rows.Count < cant)
                                    {
                                        CupoValidar = 0;
                                        btnPreincribir.Enabled = true;
                                        btnFinalizar.Visible = false;
                                        //  btnVolver.Visible = false;
                                    }
                                    else
                                    {
                                        alerCupo.Visible = true;
                                        CupoValidar = 1;
                                        btnPreincribir.Enabled = false;
                                        btnFinalizar.Visible = true;
                                        //btnVolver.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "No existe Tabla Cupo";

                                }
                            }
                            else //Salita 4 Tarde
                            {

                                dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, 1, 1, 61, anio);
                                dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 61, 2);
                                if (dt.Rows.Count > 0)
                                {
                                    cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                    if (dt2.Rows.Count < cant)
                                    {
                                        CupoValidar = 0;
                                        btnPreincribir.Enabled = true;
                                        btnFinalizar.Visible = false;
                                        //      btnVolver.Visible = false;
                                    }
                                    else
                                    {
                                        alerCupo.Visible = true;
                                        CupoValidar = 1;
                                        btnPreincribir.Enabled = false;
                                        btnFinalizar.Visible = true;
                                        //btnVolver.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "No existe Tabla Cupo";

                                }
                            }
                        }
                    }
                }
                if (insId == 5)//jardin PV
                {
                    if (Convert.ToInt32(rblCurso.SelectedValue) == 2) // Salita 3
                    {
                        if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//  Mañana
                        {
                            dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 1, 1, 56, anio, 8);
                            dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 56, 1);
                            if (dt.Rows.Count > 0)
                            {
                                cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                if (dt2.Rows.Count < cant)
                                {
                                    CupoValidar = 0;
                                    btnPreincribir.Enabled = true;
                                    btnFinalizar.Visible = false;
                                    //          btnVolver.Visible = false;
                                }
                                else
                                {
                                    alerCupo.Visible = true;
                                    CupoValidar = 1;
                                    btnPreincribir.Enabled = false;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                }
                            }
                            else
                            {
                                lblMensajeError.Text = "No existe Tabla Cupo";
                            }
                        }
                        else //Salita 3 Tarde
                        {
                            dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurxEstxAnio(insId, 1, 1, 57, anio, 8);
                            dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 57, 2);
                            if (dt.Rows.Count > 0)
                            {
                                cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                if (dt2.Rows.Count < cant)
                                {
                                    CupoValidar = 0;
                                    btnPreincribir.Enabled = true;
                                    btnFinalizar.Visible = false;
                                    //       btnVolver.Visible = false;
                                }
                                else
                                {
                                    alerCupo.Visible = true;
                                    CupoValidar = 1;
                                    btnPreincribir.Enabled = false;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                }
                            }
                            else
                            {
                                lblMensajeError.Text = "No existe Tabla Cupo";
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(rblCurso.SelectedValue) == 3) //Salita 4
                        {
                            if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//  Mañana
                            {
                                dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, 1, 1, 60, anio);
                                dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 60, 1);
                                if (dt.Rows.Count > 0)
                                {
                                    cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                    if (dt2.Rows.Count < cant)
                                    {
                                        CupoValidar = 0;
                                        btnPreincribir.Enabled = true;
                                        btnFinalizar.Visible = false;
                                        //               btnVolver.Visible = false;
                                    }
                                    else
                                    {
                                        alerCupo.Visible = true;
                                        CupoValidar = 1;
                                        btnPreincribir.Enabled = false;
                                        btnFinalizar.Visible = true;
                                        //btnVolver.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "No existe Tabla Cupo";
                                }
                            }

                            else //Salita 4 Tarde
                            {
                                dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, 1, 1, 61, anio);
                                dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 61, 2);
                                if (dt.Rows.Count > 0)
                                {
                                    cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                    if (dt2.Rows.Count < cant)
                                    {
                                        CupoValidar = 0;
                                        btnPreincribir.Enabled = true;
                                        btnFinalizar.Visible = false;
                                        //               btnVolver.Visible = false;
                                    }
                                    else
                                    {
                                        alerCupo.Visible = true;
                                        CupoValidar = 1;
                                        btnPreincribir.Enabled = false;
                                        btnFinalizar.Visible = true;
                                        //btnVolver.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblMensajeError.Text = "No existe Tabla Cupo";
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(rblCurso.SelectedValue) == 4) //Salita 5
                            {
                                if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//  Mañana
                                {
                                    dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, 1, 1, 171, anio);
                                    dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 171, 1);
                                    if (dt.Rows.Count > 0)
                                    {
                                        cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                        if (dt2.Rows.Count < cant)
                                        {
                                            CupoValidar = 0;
                                            btnPreincribir.Enabled = true;
                                            btnFinalizar.Visible = false;
                                            //           btnVolver.Visible = false;
                                        }
                                        else
                                        {
                                            alerCupo.Visible = true;
                                            CupoValidar = 1;
                                            btnPreincribir.Enabled = false;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        lblMensajeError.Text = "No existe Tabla Cupo";

                                    }
                                }
                                else
                                {
                                    dt2 = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, 1, 1, 172, anio);
                                    dt = ocnCupoCursos.ObtenerUnoxinsxCurIdxTurno(insId, 171, 2);
                                    if (dt.Rows.Count > 0)
                                    {
                                        cant = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                                        if (dt2.Rows.Count < cant)
                                        {
                                            CupoValidar = 0;
                                            btnPreincribir.Enabled = true;
                                            btnFinalizar.Visible = false;
                                            //btnVolver.Visible = false;
                                        }
                                        else
                                        {
                                            alerCupo.Visible = true;
                                            CupoValidar = 1;
                                            btnPreincribir.Enabled = false;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        lblMensajeError.Text = "No existe Tabla Cupo";

                                    }
                                }
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

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../PaginasBasicas/Inicio.aspx");
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep = "";
            DataTable dt = new DataTable();
            dt = ocnInscripcionCursado.ObtenerUno(Convert.ToInt32(lblicuId.Text));
            Int32 aluId = Convert.ToInt32(dt.Rows[0]["aluId"].ToString());
            Int32 curso = Convert.ToInt32(dt.Rows[0]["curId"].ToString());
            Int32 anio = Convert.ToInt32(dt.Rows[0]["AnoCursado"].ToString());

            if (insId == 1) //Si es San José
            {
                NomRep = "InformeConstanciaPreinscripcionSanJose.rpt";
            }
            else
            {
                if (insId == 2) //Si es Misericordia
                {
                    NomRep = "InformeConstanciaPreinscripcionMisericordia.rpt";
                }
                else
                {
                    if (insId == 3) //Si es San Vicente
                    {
                        NomRep = "InformeConstanciaPreinscripcionSanVicente.rpt";
                    }
                    else
                    {
                        if (insId == 4) //Si es Jardin Misericordia
                        {
                            if (curso == 56 | curso == 57)
                            {

                                NomRep = "InformeConstanciaPreinscripcionJardinMisericordia.rpt";
                            }
                            else
                            {
                                if (curso == 60 | curso == 61)
                                {
                                    NomRep = "InformeConstanciaPreinscripcionJardinMisericordia.rpt";
                                } else
                                {
                                    if (curso == 171 | curso == 172 | curso == 173 | curso == 174)
                                    {
                                        NomRep = "InformeConstanciaPreinscripcionJardinMisericordia.rpt";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (insId == 5) //Si es Jardin Padre Victor
                            {
                                if (curso == 56 | curso == 57)
                                {

                                    NomRep = "InformeConstanciaPreinscripcionPadreVictor.rpt";
                                }
                                else
                                {
                                    if (curso == 60 | curso == 61)
                                    {
                                        NomRep = "InformeConstanciaPreinscripcionPadreVictor.rpt";
                                    }

                                    else
                                    {
                                        if (curso == 171 | curso == 172)
                                        {
                                            NomRep = "InformeConstanciaPreinscripcionPadreVictor.rpt";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId + "&curso=" + curso + "&anio=" + anio + "&NomRep=" + NomRep);
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
    protected void btnPreinscribir_Click(object sender, EventArgs e)
    {
        try
        {
            lblMje3.Text = "";
            int aluId2;
            insId = Convert.ToInt32(Session["_Institucion"]);
            alerCupo.Visible = false;
            alerEdad.Visible = false;
            alert.Visible = false;
            alertExito.Visible = false;
            if (CupoValidar == 0)
            {
                DateTime FechaHoraCreacion1 = DateTime.Now;
                DateTime FechaHoraUltimaModificacion1 = DateTime.Now;
                Int32 usuIdCreacion1 = this.Master.usuId;
                Int32 usuIdUltimaModificacion1 = this.Master.usuId; ;

                if (insId == 4 || insId == 5 || insId == 2) //Si es distinto a san jose, misericordia o San Vicente
                {
                    if (rblCurso.SelectedIndex == -1)
                    {
                        lblMje3.Text = "Debe seleccionar un Curso..";
                        //  rblCurso.Focus();
                        return;
                    }
                    if (rblTurno.SelectedIndex == -1)
                    {
                        // rblTurno.Focus();
                        lblMje3.Text = "Debe seleccionar un Turno..";
                        return;
                    }
                }

                if (DniPadre.Text == "" & DniMadre.Text == "" & DniOtro.Text == "")
                {
                    lblMje3.Text = "Debe completar los datos de al menos un Familiar..";
                    return;
                }


                int Bandera = 1;

                ///////////// Calculo edad  ///////////////////////
                DateTime limite = new DateTime(DateTime.Today.Year + 1, 06, 30); //fecha Limite 
                DateTime nacimiento = Convert.ToDateTime(txtFecha.Text); //Fecha de nacimiento
                int edad = limite.AddTicks(-nacimiento.Ticks).Year - 1;
                int Id = 0;
                if (Convert.ToInt32(rblCurso.SelectedValue) == 1) //1 grado
                {
                    if (edad >= 6 & edad <= 7)
                    {
                        Bandera = 0;
                    }
                }
                else
                {
                    if (Convert.ToInt32(rblCurso.SelectedValue) == 2) //Salita de 3
                    {
                        if (edad >= 3 & edad <= 4)
                        {
                            Bandera = 0;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(rblCurso.SelectedValue) == 3)// Salita de 4
                        {
                            if (edad >= 4 & edad <= 5)
                            {
                                Bandera = 0;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(rblCurso.SelectedValue) == 4)// Salita de 5
                            {
                                if (edad >= 5 & edad <= 6)
                                {
                                    Bandera = 0;
                                }
                            }
                        }
                    }
                }

                //////////////////////////////////////////////////////////////////////
                //Inserto o actualizo Alumno

                if (Bandera == 0)// dentro de la edad segun curso..
                {
                    Id = 0;
                    ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno(Id);
                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();

                    int TutorM = 0;
                    int TutorP = 0;
                    int TutorO = 0;

                    if (EsTutor.SelectedIndex == 0) //tutor Madre
                    {
                        if (DniMadre.Text.Trim() == "")
                        {
                            lblMje3.Text = "Ud. seleccionó a la Madre como tutor. Complete el DNI de la madre..";
                            return;
                        }
                        else
                        {
                            if (ApeMadre.Text.Trim() == "")
                            {
                                lblMje3.Text = "Ud. seleccionó a la Madre como tutor. Complete el Apellido de la madre..";
                                return;
                            }
                            else
                            {
                                if (NomMadre.Text.Trim() == "")
                                {
                                    lblMje3.Text = "Ud. seleccionó a la Madre como tutor. Complete el Nombre de la madre..";
                                    return;
                                }
                                else
                                {
                                    if (CuitM.Text.Trim() == "")
                                    {
                                        lblMje3.Text = "Ud. seleccionó a la Madre como tutor. Complete el CUIL de la madre..";
                                        return;
                                    }
                                    else
                                    {
                                        if (TelefM.Text.Trim() == "" & txtFijoM.Text.Trim() == "")
                                        {
                                            lblMje3.Text = "Ud. seleccionó a la Madre como tutor. Complete al menos un telefono de la madre..";
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        TutorM = 1;
                    }
                    else
                    {
                        if (EsTutor.SelectedIndex == 1) //tutor Padre
                        {
                            if (DniPadre.Text.Trim() == "")
                            {
                                lblMje3.Text = "Ud. seleccionó al Padre como tutor. Complete el DNI del Padre..";
                                return;
                            }
                            else
                            {
                                if (ApePadre.Text.Trim() == "")
                                {
                                    lblMje3.Text = "Ud. seleccionó al Padre como tutor. Complete el Apellido del Padre..";
                                    return;
                                }
                                else
                                {
                                    if (NomPadre.Text.Trim() == "")
                                    {
                                        lblMje3.Text = "Ud. seleccionó al Padre como tutor. Complete el Nombre del Padre..";
                                        return;
                                    }
                                    else
                                    {
                                        if (CuitP.Text.Trim() == "")
                                        {
                                            lblMje3.Text = "Ud. seleccionó al Padre como tutor. Complete el CUIL del Padre..";
                                            return;
                                        }
                                        else
                                        {
                                            if (TelefP.Text.Trim() == "" & txtFijoP.Text.Trim() == "")
                                            {
                                                lblMje3.Text = "Ud. seleccionó al Padre como tutor. Complete al menos un telefono del Padre..";
                                                return;
                                            }
                                        }
                                    }
                                }
                            }

                            TutorP = 1;
                        }
                        else
                        {
                            if (EsTutor.SelectedIndex == 2) //tutor Otro
                            {
                                if (DniOtro.Text.Trim() == "")
                                {
                                    lblMje3.Text = "Ud. seleccionó a Otro como tutor. Complete el DNI del Otro Familiar ..";
                                    return;
                                }
                                else
                                {
                                    if (ApeOtro.Text.Trim() == "")
                                    {
                                        lblMje3.Text = "Ud. seleccionó a Otro como tutor. Complete el Apellido del Otro Familiar..";
                                        return;
                                    }
                                    else
                                    {
                                        if (NombOtro.Text.Trim() == "")
                                        {
                                            lblMje3.Text = "Ud. seleccionó a Otro como tutor. Complete el Nombre del Otro Familiar..";
                                            return;
                                        }
                                        else
                                        {
                                            if (CuitO.Text.Trim() == "")
                                            {
                                                lblMje3.Text = "Ud. seleccionó a Otro como tutor. Complete el CUIL del Otro Familiar..";
                                                return;
                                            }
                                            else
                                            {
                                                if (TelefO.Text.Trim() == "" & txtFijoO.Text.Trim() == "")
                                                {
                                                    lblMje3.Text = "Ud. seleccionó a Otro como tutor. Complete al menos un telefono del Otro Familiar..";
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }

                                TutorO = 1;
                            }
                        }
                    }


                    dt5 = new DataTable();
                    dt5 = ocnAlumno.ObtenerUnoporDoc(TXTdni2.Text.Trim());
                    if (dt5.Rows.Count == 0) // Verifico que no existe en Alumno
                    {
                        ocnAlumno.aluDoc = TXTdni2.Text.Trim();
                        ocnAlumno.aluNombre = txtAlu.Text.Trim();
                        ocnAlumno.aluLegajoNumero = "";
                        ocnAlumno.aluCuit = aluCuit.Text.Trim();
                        ocnAlumno.aluProvNac = 0;
                        ocnAlumno.aluDeptoNac = 0;
                        ocnAlumno.aluLocNac = 0;
                        ocnAlumno.aluMail = "";
                        ocnAlumno.aluDomicilio = aluDomicilio.Text.Trim();
                        ocnAlumno.aluDepto = Convert.ToInt32(DepartamentoId.SelectedValue);
                        ocnAlumno.aluTelefonoCel = "";
                        ocnAlumno.aluFechaNacimiento = Convert.ToDateTime(txtFecha.Text.Trim());
                        ocnAlumno.aluActivo = true;
                        ocnAlumno.aluTelefono = txtTelFijo.Text.Trim();
                        ocnAlumno.sexId = Convert.ToInt32((sexId.SelectedValue.Trim() == "" ? "0" : sexId.SelectedValue));
                        ocnAlumno.aluFechaHoraCreacion = DateTime.Now;
                        ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
                        ocnAlumno.usuIdCreacion = this.Master.usuId; ;
                        ocnAlumno.usuIdUltimaModificacion = this.Master.usuId;
                        int ParentescoOtro = Convert.ToInt32(ParentescoId.SelectedValue);
                        ocnAlumno.gsaId = 0;
                        ocnAlumno.aluTelUrgencias = "";
                        ocnAlumno.aluDomFliar = "";
                        ocnAlumno.aluPreg1 = "";
                        ocnAlumno.aluPreg2 = "";
                        ocnAlumno.aluPreg3 = "";
                        ocnAlumno.aluPreg4 = "";
                        ocnAlumno.aluPreg5 = "";
                        ocnAlumno.aluPreg6 = "";
                        ocnAlumno.aluPreg7 = "";
                        ocnAlumno.aluAclara = "";

                        // int gsaId, String aluTelUrgencias, String aluDomFliar, String aluPreg1, String aluPreg2, String aluPreg3, String aluPreg4, String aluPreg5, String aluPreg6, String aluPreg7, String aluAclara

                        aluId2 = ocnAlumno.Insertar(); //Inserto Alumno y traigo aluId

                    }
                    else
                    {
                        //Editar
                        aluId2 = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                        ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno(aluId2);
                        ocnAlumno.aluDoc = TXTdni2.Text.Trim();
                        ocnAlumno.aluNombre = txtAlu.Text.Trim();
                        ocnAlumno.aluCuit = aluCuit.Text.Trim();
                        ocnAlumno.aluDomicilio = aluDomicilio.Text.Trim();
                        ocnAlumno.aluDepto = Convert.ToInt32(DepartamentoId.SelectedValue);
                        ocnAlumno.aluFechaNacimiento = Convert.ToDateTime(txtFecha.Text.Trim());
                        ocnAlumno.aluActivo = true;
                        ocnAlumno.aluTelefono = txtTelFijo.Text.Trim();
                        ocnAlumno.sexId = Convert.ToInt32((sexId.SelectedValue.Trim() == "" ? "0" : sexId.SelectedValue));
                        ocnAlumno.aluFechaHoraCreacion = DateTime.Now;
                        ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
                        ocnAlumno.usuIdCreacion = this.Master.usuId;
                        ocnAlumno.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAlumno.gsaId = 0;
                        ocnAlumno.aluTelUrgencias = "";
                        ocnAlumno.aluDomFliar = "";
                        ocnAlumno.aluPreg1 = "";
                        ocnAlumno.aluPreg2 = "";
                        ocnAlumno.aluPreg3 = "";
                        ocnAlumno.aluPreg4 = "";
                        ocnAlumno.aluPreg5 = "";
                        ocnAlumno.aluPreg6 = "";
                        ocnAlumno.aluPreg7 = "";
                        ocnAlumno.aluAclara = "";

                        //String ClaveM;
                        ocnAlumno.Actualizar(); //Actualizo Alumno 
                    }

                    //////////////////////////////////////////////////////////////////////
                    //Inserto o actualizo Familiar


                    if (DniPadre.Text != "") // Verifico si existe en Familiar y luego asigno en AlumnoFamiliar
                    {
                        dt = new DataTable();
                        dt = ocnFamiliar.ObtenerUnoPorDoc(DniPadre.Text.Trim());

                        if (dt.Rows.Count > 0)//existe Padre en Familiar
                        {
                            int FamIdPadre = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                            int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniPadre.Text.Trim());
                            int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                            ocnFamiliar.Actualizar(FamIdPadre, ApePadre.Text.Trim(), NomPadre.Text.Trim(), OcupPadre.Text.Trim(), DniPadre.Text.Trim(), TelefP.Text.Trim(), txtFijoP.Text.Trim(), CuitP.Text.Trim(), MailP.Text.Trim(), usuIdP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);

                            //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                            String ClaveP = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";

                            if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                            {
                                //ocnUsuario.Actualizar(usuIdP, ApePadre.Text, NomPadre.Text, UsuarioP.Text, ClaveP, "", false, MailP.Text, 10, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1, true);
                                ocnAlumnoFamiliar.Actualizar(aluId2, FamIdPadre, 1, TutorP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                            else
                            {
                                //int usuIdNuevo = ocnUsuario.InsertarFamiliar();
                                ocnAlumnoFamiliar.Insertar(aluId2, FamIdPadre, 1, TutorP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                        }
                        else // Inserto Padre en Familiar y en AlumnoFamiliar
                        {
                            dt5 = ocnFamiliar.ObtenerUnoPorDoc(DniPadre.Text);
                            if (dt5.Rows.Count == 0)//No existe Padre en Usuario
                            {
                                String ClaveP = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                                Int32 UsuIdNuevoP = ocnUsuario.InsertarTraerId(ApePadre.Text.Trim(), NomPadre.Text.Trim(), DniPadre.Text.Trim(), ClaveP, "", false, MailP.Text.Trim(), usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1, true,0, "", DniPadre.Text.Trim(), CuitP.Text.Trim(), TelefP.Text.Trim(), 0);
                                ocnUsuarioPerfil.Insertar(UsuIdNuevoP, 10, insId, true, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);

                                int famIdP = ocnFamiliar.Insertar(ApePadre.Text.Trim(), NomPadre.Text.Trim(), OcupPadre.Text.Trim(), DniPadre.Text.Trim(), TelefP.Text.Trim(), txtFijoP.Text.Trim(), CuitP.Text.Trim(), MailP.Text.Trim(), UsuIdNuevoP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                ocnAlumnoFamiliar.Insertar(aluId2, famIdP, 1, TutorP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                            else
                            {
                                Int32 UsuIdP = Convert.ToInt32(dt5.Rows[0]["UsuId"].ToString());
                                int famIdP = ocnFamiliar.Insertar(ApePadre.Text.Trim(), NomPadre.Text.Trim(), OcupPadre.Text.Trim(), DniPadre.Text.Trim(), TelefP.Text.Trim(), txtFijoP.Text.Trim(), CuitP.Text.Trim(), MailP.Text.Trim(), UsuIdP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                ocnAlumnoFamiliar.Insertar(aluId2, famIdP, 1, TutorP, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                        }
                    }

                    if (DniMadre.Text.Trim() != "")
                    {
                        dt2 = new DataTable();
                        dt2 = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text.Trim());

                        if (dt2.Rows.Count > 0)//existe Madre en Familiar
                        {
                            int FamIdMadre = Convert.ToInt32(dt2.Rows[0]["Id"].ToString());
                            int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniMadre.Text.Trim());
                            int usuIdM = Convert.ToInt32(dt2.Rows[0]["UsuId"].ToString());
                            ocnFamiliar.Actualizar(FamIdMadre, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), OcupMadre.Text.Trim(), DniMadre.Text.Trim(), TelefM.Text.Trim(), txtFijoM.Text.Trim(), CuitM.Text.Trim(), MailM.Text.Trim(), usuIdM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            //dt3 = ocnUsuario.ObtenerUno(usuIdM);
                            String ClaveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                            if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                            {
                                //ocnUsuario.Actualizar(usuIdM, insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), UsuarioM.Text.Trim(), ClaveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1, true);
                                ocnAlumnoFamiliar.Actualizar(aluId2, FamIdMadre, 2, TutorM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                            else //Ese familiar no esta asignado en alumnoFamiliar
                            {
                                ocnAlumnoFamiliar.Insertar(aluId2, FamIdMadre, 2, TutorM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                        }
                        else // Inserto Madre en Familiar y en AlumnoFamiliar
                        {
                            dt5 = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text.Trim());
                            if (dt5.Rows.Count == 0)//No existe Padre en Usuario
                            {
                                String ClaveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                                Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), ClaveM, "", false, MailM.Text.Trim(), usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1, true, 0, "", DniMadre.Text.Trim(), CuitM.Text.Trim(), TelefM.Text.Trim(), 0);
                                ocnUsuarioPerfil.Insertar(UsuIdNuevoM, 10, insId, true, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);

                                int famIdM = ocnFamiliar.Insertar(ApeMadre.Text.Trim(), NomMadre.Text.Trim(), OcupMadre.Text.Trim(), DniMadre.Text.Trim(), txtFijoM.Text.Trim(), TelefM.Text.Trim(), CuitM.Text.Trim(), MailM.Text.Trim(), UsuIdNuevoM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                ocnAlumnoFamiliar.Insertar(aluId2, famIdM, 2, TutorM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                            else
                            {
                                Int32 UsuIdM = Convert.ToInt32(dt5.Rows[0]["UsuId"].ToString());
                                int famIdM = ocnFamiliar.Insertar(ApeMadre.Text.Trim(), NomMadre.Text.Trim(), OcupMadre.Text.Trim(), DniMadre.Text.Trim(), TelefM.Text.Trim(), txtFijoM.Text.Trim(), CuitM.Text.Trim(), MailM.Text.Trim(), UsuIdM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                ocnAlumnoFamiliar.Insertar(aluId2, famIdM, 2, TutorM, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                            }
                        }
                    }

                    if (DniOtro.Text.Trim() != "")
                    {
                        dt3 = new DataTable();
                        dt3 = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text.Trim());
                        int ParentescoOtro2 = Convert.ToInt32((ParentescoId.SelectedValue.Trim() == "" ? "0" : ParentescoId.SelectedValue));

                        if (Convert.ToInt32(ParentescoId.SelectedValue) != 0) //Si no selecciono parentezco..
                        {
                            if (dt3.Rows.Count > 0) //existe Otro en Familiar
                            {
                                int FamIdOtro = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                                int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniOtro.Text.Trim());
                                int usuIdO = Convert.ToInt32(dt3.Rows[0]["UsuId"].ToString());
                                ocnFamiliar.Actualizar(FamIdOtro, ApeOtro.Text.Trim(), NombOtro.Text.Trim(), OcupOtro.Text.Trim(), DniOtro.Text.Trim(), TelefO.Text.Trim(), txtFijoO.Text.Trim(), CuitO.Text.Trim(), MailO.Text.Trim(), usuIdO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);

                                //dt4 = ocnUsuario.ObtenerUno(usuIdO);
                                //String ClaveO = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                                if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                                {
                                    //ocnUsuario.Actualizar(usuIdO, insId, ApeOtro.Text.Trim(), NombOtro.Text.Trim(), UsuarioO.Text.Trim(), ClaveO, "", false, MailO.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1, true);
                                    ocnAlumnoFamiliar.Actualizar(aluId2, FamIdOtro, ParentescoOtro2, TutorO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                }
                                else //Ese familiar no esta asignado en alumnoFamiliar
                                {
                                    ocnAlumnoFamiliar.Insertar(aluId2, FamIdOtro, ParentescoOtro2, TutorO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                }
                            }
                            else //existe Otro en Familiar
                            {
                                dt5 = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text.Trim());
                                if (dt5.Rows.Count == 0)//No existe otro en Usuario
                                {
                                    String ClaveO = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                                    Int32 UsuIdNuevoO = ocnUsuario.InsertarTraerId(ApeOtro.Text.Trim(), NombOtro.Text.Trim(), DniOtro.Text.Trim(), ClaveO, "", false, MailO.Text.Trim(), usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1,true,0,"", DniOtro.Text.Trim(), CuitO.Text.Trim(), TelefO.Text.Trim(), 0);
                                    ocnUsuarioPerfil.Insertar(UsuIdNuevoO,10,insId,true, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                    int famIdO = ocnFamiliar.Insertar(ApeOtro.Text.Trim(), NombOtro.Text.Trim(), OcupOtro.Text.Trim(), DniOtro.Text.Trim(), TelefO.Text.Trim(), txtFijoO.Text.Trim(), CuitO.Text.Trim(), MailO.Text.Trim(), UsuIdNuevoO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                    ocnAlumnoFamiliar.Insertar(aluId2, famIdO, ParentescoOtro2, TutorO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                }
                                else
                                {
                                    Int32 UsuIdO = Convert.ToInt32(dt5.Rows[0]["UsuId"].ToString());
                                    int famIdO = ocnFamiliar.Insertar(ApeOtro.Text.Trim(), NombOtro.Text.Trim(), OcupOtro.Text.Trim(), DniOtro.Text.Trim(), TelefO.Text.Trim(), txtFijoO.Text.Trim(), CuitO.Text.Trim(), MailO.Text.Trim(), UsuIdO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                    ocnAlumnoFamiliar.Insertar(aluId2, famIdO, ParentescoOtro2, TutorO, usuIdCreacion1, usuIdUltimaModificacion1, FechaHoraCreacion1, FechaHoraUltimaModificacion1);
                                }
                            }
                        }
                        else
                        {
                            lblMje3.Text = "Debe seleccionar Parentezco";
                            lblMensajeError.Text = "Debe seleccionar Parentezco";
                        }
                    }

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Inscribir Colegio Curso Turno
                    int Inscripcion = 0;
                    ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
                    int AnioLectivo = Convert.ToInt32(txtaniolectivo.Text.Trim()); //  Convert.ToInt32(DateTime.Today.Year + 1);
                    ocnInscripcionCursado.icuAnoCursado = Convert.ToInt32(AnioLectivo);
                    ocnInscripcionCursado.icuFechaInscripcion = Convert.ToDateTime(DateTime.Today);
                    ocnInscripcionCursado.icuActivo = true;
                    ocnInscripcionCursado.aluId = aluId2;
                    ocnInscripcionCursado.icuEstado = 8;
                    ocnInscripcionCursado.icuFechaHoraCreacion = DateTime.Now;
                    ocnInscripcionCursado.icuFechaHoraUltimaModificacion = DateTime.Now;
                    ocnInscripcionCursado.usuIdCreacion = this.Master.usuId;
                    ocnInscripcionCursado.usuIdUltimaModificacion = this.Master.usuId;
                    int conId1 = 0;
                    if (insId == 1 || insId == 3)// San Jose y San Vicente no tienen turno
                    {
                        ocnInscripcionCursado.insId = insId;
                        dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 68, AnioLectivo);
                        if (dt4.Rows.Count == 0)
                        {
                            ocnInscripcionCursado.carId = 2;
                            ocnInscripcionCursado.plaId = 2;
                            ocnInscripcionCursado.curId = 68;
                            ocnInscripcionCursado.camId = 0;
                            ocnInscripcionCursado.escId = 0;
                            ocnInscripcionCursado.icuObserv = "";
                            int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                            Inscripcion = 1;
                            DataTable dt6 = new DataTable();
                            dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                            if (dt6.Rows.Count > 0)
                            {
                                conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                            }
                            else
                            {
                                lblMensajeError.Text = "No existe concepto Preinscripción..";
                                return;

                            }
                            ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                            ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);
                            btnImprimir.Visible = true;
                            lblicuId.Text = Convert.ToString(icuId2);
                            alertExito.Visible = true;
                            btnFinalizar.Visible = true;
                            //btnVolver.Visible = true;
                            btnPreincribir.Enabled = false;
                        }
                        else
                        {
                            alert.Visible = true;
                            btnFinalizar.Visible = true;
                            //btnVolver.Visible = true;
                            btnPreincribir.Enabled = false;
                            return;
                        }
                    }

                    else
                    {
                        if (insId == 2)// Misericordia
                        {
                            ocnInscripcionCursado.insId = insId;

                            if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                            {
                                dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 68, AnioLectivo);
                                if (dt4.Rows.Count == 0)
                                {
                                    ocnInscripcionCursado.carId = 2;
                                    ocnInscripcionCursado.plaId = 2;
                                    ocnInscripcionCursado.curId = 68;
                                    ocnInscripcionCursado.camId = 0;
                                    ocnInscripcionCursado.escId = 0;
                                    ocnInscripcionCursado.icuObserv = "";
                                    int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                    Inscripcion = 1;
                                    DataTable dt6 = new DataTable();
                                    dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                    if (dt6.Rows.Count > 0)
                                    {
                                        conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                    }
                                    else
                                    {
                                        lblMensajeError.Text = "No existe concepto Preinscripción..";
                                        return;
                                    }
                                    ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                    ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                    btnImprimir.Visible = true;
                                    lblicuId.Text = Convert.ToString(icuId2);
                                    alertExito.Visible = true;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                    btnPreincribir.Enabled = false;
                                }
                                else
                                {
                                    alert.Visible = true;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                    btnPreincribir.Enabled = false;
                                    return;
                                }
                            }

                            else //Tarde
                            {

                                dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 77, AnioLectivo);
                                if (dt4.Rows.Count == 0)
                                {
                                    ocnInscripcionCursado.carId = 2;
                                    ocnInscripcionCursado.plaId = 2;
                                    ocnInscripcionCursado.curId = 77;
                                    ocnInscripcionCursado.camId = 0;
                                    ocnInscripcionCursado.escId = 0;
                                    ocnInscripcionCursado.icuObserv = "";
                                    int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                    lblicuId.Text = Convert.ToString(icuId2);
                                    Inscripcion = 1;

                                    DataTable dt6 = new DataTable();
                                    dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                    if (dt6.Rows.Count > 0)
                                    {
                                        conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                    }
                                    else
                                    {
                                        lblMensajeError.Text = "No existe concepto Preinscripción..";
                                        return;
                                    }
                                    ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                    ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                    btnImprimir.Visible = true;
                                    alertExito.Visible = true;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                    btnPreincribir.Enabled = false;
                                }
                                else
                                {
                                    alert.Visible = true;
                                    btnFinalizar.Visible = true;
                                    //btnVolver.Visible = true;
                                    btnPreincribir.Enabled = false;
                                    return;
                                }
                            }
                        }

                        else
                        {
                            if (insId == 4)// Jardin Misericordia 
                            {
                                ocnInscripcionCursado.insId = insId;
                                if (Convert.ToInt32(rblCurso.SelectedValue) == 2) //Sailta 3
                                {
                                    if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                                    {
                                        dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 56, AnioLectivo);
                                        if (dt4.Rows.Count == 0)
                                        {
                                            ocnInscripcionCursado.carId = 1;
                                            ocnInscripcionCursado.plaId = 1;
                                            ocnInscripcionCursado.curId = 56;
                                            ocnInscripcionCursado.camId = 0;
                                            ocnInscripcionCursado.escId = 0;
                                            ocnInscripcionCursado.icuObserv = "";
                                            int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                            lblicuId.Text = Convert.ToString(icuId2);
                                            Inscripcion = 1;
                                            DataTable dt6 = new DataTable();
                                            dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                            if (dt6.Rows.Count > 0)
                                            {
                                                conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                            }
                                            else
                                            {
                                                lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                return;
                                            }
                                            ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                            btnImprimir.Visible = true;
                                            alertExito.Visible = true;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                            btnPreincribir.Enabled = false;
                                        }
                                        else
                                        {
                                            alert.Visible = true;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                            btnPreincribir.Enabled = false;
                                            return;
                                        }
                                    }
                                    else //Salita 3 Tarde
                                    {
                                        dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 57, AnioLectivo);
                                        if (dt4.Rows.Count == 0)
                                        {
                                            ocnInscripcionCursado.carId = 1;
                                            ocnInscripcionCursado.plaId = 1;
                                            ocnInscripcionCursado.curId = 57;
                                            ocnInscripcionCursado.camId = 0;
                                            ocnInscripcionCursado.escId = 0;
                                            ocnInscripcionCursado.icuObserv = "";
                                            int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso
                                            Inscripcion = 1;
                                            DataTable dt6 = new DataTable();
                                            dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                            if (dt6.Rows.Count > 0)
                                            {
                                                conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                            }
                                            else
                                            {
                                                lblMensajeError.Text = "No existe concepto Preinscripción..";
                                            }
                                            ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                            ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                            btnImprimir.Visible = true;
                                            lblicuId.Text = Convert.ToString(icuId2);
                                            alertExito.Visible = true;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                            btnPreincribir.Enabled = false;
                                        }
                                        else
                                        {
                                            alert.Visible = true;
                                            btnFinalizar.Visible = true;
                                            //btnVolver.Visible = true;
                                            btnPreincribir.Enabled = false;
                                            return;
                                        }
                                    }
                                }
                                else
                                {

                                    if (Convert.ToInt32(rblCurso.SelectedValue) == 3) //Sailta 4
                                    {
                                        if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                                        {
                                            dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 60, AnioLectivo);
                                            if (dt4.Rows.Count == 0)
                                            {
                                                ocnInscripcionCursado.carId = 1;
                                                ocnInscripcionCursado.plaId = 1;
                                                ocnInscripcionCursado.curId = 60;
                                                ocnInscripcionCursado.camId = 0;
                                                ocnInscripcionCursado.escId = 0;
                                                ocnInscripcionCursado.icuObserv = "";
                                                int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                Inscripcion = 1;
                                                lblicuId.Text = Convert.ToString(icuId2);
                                                DataTable dt6 = new DataTable();
                                                dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                if (dt6.Rows.Count > 0)
                                                {
                                                    conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                }
                                                else
                                                {
                                                    lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                }
                                                ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim().Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                btnImprimir.Visible = true;
                                                alertExito.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                            }
                                            else
                                            {
                                                alert.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                                return;
                                            }
                                        }
                                        else //Salita 4 Tarde
                                        {
                                            dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 61, AnioLectivo);
                                            if (dt4.Rows.Count == 0)
                                            {
                                                ocnInscripcionCursado.carId = 1;
                                                ocnInscripcionCursado.plaId = 1;
                                                ocnInscripcionCursado.curId = 61;
                                                ocnInscripcionCursado.camId = 0;
                                                ocnInscripcionCursado.escId = 0;
                                                ocnInscripcionCursado.icuObserv = "";
                                                int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                Inscripcion = 1;
                                                lblicuId.Text = Convert.ToString(icuId2);
                                                DataTable dt6 = new DataTable();
                                                dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                if (dt6.Rows.Count > 0)
                                                {
                                                    conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                }
                                                else
                                                {
                                                    lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                }
                                                ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                btnImprimir.Visible = true;
                                                alertExito.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                            }
                                            else
                                            {
                                                alert.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(rblCurso.SelectedValue) == 4) //Sailta 5
                                        {
                                            if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                                            {
                                                dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 171, AnioLectivo);
                                                if (dt4.Rows.Count == 0)
                                                {
                                                    ocnInscripcionCursado.carId = 1;
                                                    ocnInscripcionCursado.plaId = 1;
                                                    ocnInscripcionCursado.curId = 171;
                                                    ocnInscripcionCursado.camId = 0;
                                                    ocnInscripcionCursado.escId = 0;
                                                    ocnInscripcionCursado.icuObserv = "";
                                                    int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                    lblicuId.Text = Convert.ToString(icuId2);
                                                    Inscripcion = 1;
                                                    DataTable dt6 = new DataTable();
                                                    dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                    if (dt6.Rows.Count > 0)
                                                    {
                                                        conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                    }
                                                    else
                                                    {
                                                        lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                        return;
                                                    }
                                                    ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                    ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                    btnImprimir.Visible = true;
                                                    alertExito.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                }
                                                else
                                                {
                                                    alert.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                    return;
                                                }
                                            }
                                            else //Salita 5 Tarde
                                            {
                                                dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 172, AnioLectivo);
                                                if (dt4.Rows.Count == 0)
                                                {
                                                    ocnInscripcionCursado.carId = 1;
                                                    ocnInscripcionCursado.plaId = 1;
                                                    ocnInscripcionCursado.curId = 172;
                                                    ocnInscripcionCursado.camId = 0;
                                                    ocnInscripcionCursado.escId = 0;
                                                    ocnInscripcionCursado.icuObserv = "";
                                                    int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso
                                                    Inscripcion = 1;
                                                    DataTable dt6 = new DataTable();
                                                    dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                    if (dt6.Rows.Count > 0)
                                                    {
                                                        conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                    }
                                                    else
                                                    {
                                                        lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                    }
                                                    ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                    ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                    btnImprimir.Visible = true;
                                                    lblicuId.Text = Convert.ToString(icuId2);
                                                    alertExito.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    ////btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                }
                                                else
                                                {
                                                    alert.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (insId == 5)// Jardin PV
                                {
                                    ocnInscripcionCursado.insId = insId;
                                    if (Convert.ToInt32(rblCurso.SelectedValue) == 2) //Sailta 3
                                    {
                                        if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                                        {
                                            dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 56, AnioLectivo);
                                            if (dt4.Rows.Count == 0)
                                            {
                                                ocnInscripcionCursado.carId = 1;
                                                ocnInscripcionCursado.plaId = 1;
                                                ocnInscripcionCursado.curId = 56;
                                                ocnInscripcionCursado.camId = 0;
                                                ocnInscripcionCursado.escId = 0;
                                                ocnInscripcionCursado.icuObserv = "";
                                                int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                lblicuId.Text = Convert.ToString(icuId2);
                                                Inscripcion = 1;
                                                DataTable dt6 = new DataTable();
                                                dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                if (dt6.Rows.Count > 0)
                                                {
                                                    conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                }
                                                else
                                                {
                                                    lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                    return;
                                                }
                                                ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                btnImprimir.Visible = true;
                                                alertExito.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                            }
                                            else
                                            {
                                                alert.Visible = true;
                                                btnFinalizar.Visible = true;
                                                ////btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                                return;
                                            }
                                        }
                                        else //S3 Tarde
                                        {
                                            dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 57, AnioLectivo);
                                            if (dt4.Rows.Count == 0)
                                            {
                                                ocnInscripcionCursado.carId = 1;
                                                ocnInscripcionCursado.plaId = 1;
                                                ocnInscripcionCursado.curId = 57;
                                                ocnInscripcionCursado.camId = 0;
                                                ocnInscripcionCursado.escId = 0;
                                                ocnInscripcionCursado.icuObserv = "";
                                                int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                lblicuId.Text = Convert.ToString(icuId2);
                                                Inscripcion = 1;
                                                DataTable dt6 = new DataTable();
                                                dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                if (dt6.Rows.Count > 0)
                                                {
                                                    conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                }
                                                else
                                                {
                                                    lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                    return;
                                                }
                                                ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                btnImprimir.Visible = true;
                                                alertExito.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //    btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                            }
                                            else
                                            {
                                                alert.Visible = true;
                                                btnFinalizar.Visible = true;
                                                //btnVolver.Visible = true;
                                                btnPreincribir.Enabled = false;
                                                return;
                                            }
                                        }
                                    }

                                    else
                                    {
                                        if (Convert.ToInt32(rblCurso.SelectedValue) == 3) //Sailta 4
                                        {
                                            if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                                            {
                                                dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 60, AnioLectivo);
                                                if (dt4.Rows.Count == 0)
                                                {
                                                    ocnInscripcionCursado.carId = 1;
                                                    ocnInscripcionCursado.plaId = 1;
                                                    ocnInscripcionCursado.curId = 60;
                                                    ocnInscripcionCursado.camId = 0;
                                                    ocnInscripcionCursado.escId = 0;
                                                    ocnInscripcionCursado.icuObserv = "";
                                                    int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                    Inscripcion = 1;
                                                    lblicuId.Text = Convert.ToString(icuId2);
                                                    DataTable dt6 = new DataTable();
                                                    dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                    if (dt6.Rows.Count > 0)
                                                    {
                                                        conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                    }
                                                    else
                                                    {
                                                        lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                    }
                                                    ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                    ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                    btnImprimir.Visible = true;
                                                    alertExito.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                }
                                                else
                                                {
                                                    alert.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                    return;
                                                }
                                            }
                                            else //S4 TURNO tARDE
                                            {

                                                dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 61, AnioLectivo);
                                                if (dt4.Rows.Count == 0)
                                                {
                                                    ocnInscripcionCursado.carId = 1;
                                                    ocnInscripcionCursado.plaId = 1;
                                                    ocnInscripcionCursado.curId = 61;
                                                    ocnInscripcionCursado.camId = 0;
                                                    ocnInscripcionCursado.escId = 0;
                                                    ocnInscripcionCursado.icuObserv = "";
                                                    int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                    Inscripcion = 1;
                                                    lblicuId.Text = Convert.ToString(icuId2);
                                                    DataTable dt6 = new DataTable();
                                                    dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                    if (dt6.Rows.Count > 0)
                                                    {
                                                        conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                    }
                                                    else
                                                    {
                                                        lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                    }
                                                    ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                    ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                    btnImprimir.Visible = true;
                                                    alertExito.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                }
                                                else
                                                {
                                                    alert.Visible = true;
                                                    btnFinalizar.Visible = true;
                                                    //btnVolver.Visible = true;
                                                    btnPreincribir.Enabled = false;
                                                    return;
                                                }
                                            }
                                        }

                                        else
                                        {
                                            if (Convert.ToInt32(rblCurso.SelectedValue) == 4) //Sailta 5
                                            {
                                                if (Convert.ToInt32(rblTurno.SelectedValue) == 1)//Mañana
                                                {
                                                    dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 171, AnioLectivo);
                                                    if (dt4.Rows.Count == 0)
                                                    {
                                                        ocnInscripcionCursado.carId = 1;
                                                        ocnInscripcionCursado.plaId = 1;
                                                        ocnInscripcionCursado.curId = 171;
                                                        ocnInscripcionCursado.camId = 0;
                                                        ocnInscripcionCursado.escId = 0;
                                                        ocnInscripcionCursado.icuObserv = "";
                                                        int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                        lblicuId.Text = Convert.ToString(icuId2);
                                                        Inscripcion = 1;
                                                        DataTable dt6 = new DataTable();
                                                        dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                        if (dt6.Rows.Count > 0)
                                                        {
                                                            conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                        }
                                                        else
                                                        {
                                                            lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                            return;
                                                        }
                                                        ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                        ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                        btnImprimir.Visible = true;
                                                        alertExito.Visible = true;
                                                        btnFinalizar.Visible = true;
                                                        //btnVolver.Visible = true;
                                                        btnPreincribir.Enabled = false;
                                                    }
                                                    else
                                                    {
                                                        alert.Visible = true;
                                                        btnFinalizar.Visible = true;
                                                        //btnVolver.Visible = true;
                                                        btnPreincribir.Enabled = false;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    dt4 = ocnInscripcionCursado.ObtenerUnoControlExisteNoTerciario(insId, aluId2, 172, AnioLectivo);
                                                    if (dt4.Rows.Count == 0)
                                                    {
                                                        ocnInscripcionCursado.carId = 1;
                                                        ocnInscripcionCursado.plaId = 1;
                                                        ocnInscripcionCursado.curId = 172;
                                                        ocnInscripcionCursado.camId = 0;
                                                        ocnInscripcionCursado.escId = 0;
                                                        ocnInscripcionCursado.icuObserv = "";
                                                        int icuId2 = ocnInscripcionCursado.Insertar(); //Lo agrego en ese curso 
                                                        lblicuId.Text = Convert.ToString(icuId2);
                                                        Inscripcion = 1;
                                                        DataTable dt6 = new DataTable();
                                                        dt6 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioLectivo);//traigo concepto preinscrpcion

                                                        if (dt6.Rows.Count > 0)
                                                        {
                                                            conId1 = Convert.ToInt32(dt6.Rows[0]["Id"].ToString());
                                                        }
                                                        else
                                                        {
                                                            lblMensajeError.Text = "No existe concepto Preinscripción..";
                                                            return;
                                                        }
                                                        ocnInscripcionConcepto.Insertar(icuId2, conId1, 0, DateTime.Today, 0, 1, 0, true, this.Master.usuId, this.Master.usuId, DateTime.Now, DateTime.Now);
                                                        ocnTemporalPreinscripcion.Insertar(TextBuscar.Text.Trim(), aluId2, true, lblAfiliacion.Text.Trim(), txtNombre.Text.Trim(), this.Master.usuId);

                                                        btnImprimir.Visible = true;
                                                        alertExito.Visible = true;
                                                        btnFinalizar.Visible = true;
                                                        //btnVolver.Visible = true;
                                                        btnPreincribir.Enabled = false;
                                                    }
                                                    else
                                                    {
                                                        alert.Visible = true;
                                                        btnFinalizar.Visible = true;
                                                        //btnVolver.Visible = true;
                                                        btnPreincribir.Enabled = false;
                                                        return;
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
                else
                {
                    alerEdad.Visible = true;
                }
            }
            else
            {
                alerCupo.Visible = true;
            }
        }

        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br>/
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    "</div>";
        }
    }


    protected void DniPadre_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (DniPadre.Text.Trim() != "")
            {
                dt5 = ocnFamiliar.ObtenerUnoPorDoc(DniPadre.Text.Trim());

                if (dt5.Rows.Count > 0)
                {
                    this.ApePadre.Text = dt5.Rows[0]["Apellido"].ToString();
                    this.NomPadre.Text = dt5.Rows[0]["Nombre"].ToString();
                    this.OcupPadre.Text = dt5.Rows[0]["Ocupacion"].ToString();
                    this.DniPadre.Text = dt5.Rows[0]["Doc"].ToString().Trim();
                    this.TelefP.Text = dt5.Rows[0]["Telefono"].ToString();
                    this.txtFijoP.Text = dt5.Rows[0]["TelefonoFijo"].ToString();
                    this.CuitP.Text = dt5.Rows[0]["Cuit"].ToString();
                    this.MailP.Text = dt5.Rows[0]["Mail"].ToString();
                }
                //this.ApePadre.Focus();
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

    protected void DniMadre_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (DniMadre.Text.Trim() != "")
            {
                dt6 = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text.Trim());
                if (dt6.Rows.Count > 0)
                {
                    this.ApeMadre.Text = dt6.Rows[0]["Apellido"].ToString();
                    this.NomMadre.Text = dt6.Rows[0]["Nombre"].ToString();
                    this.OcupMadre.Text = dt6.Rows[0]["Ocupacion"].ToString();
                    this.DniMadre.Text = dt6.Rows[0]["Doc"].ToString().Trim();
                    this.TelefM.Text = dt6.Rows[0]["Telefono"].ToString();
                    this.txtFijoM.Text = dt6.Rows[0]["TelefonoFijo"].ToString();
                    this.CuitM.Text = dt6.Rows[0]["Cuit"].ToString();
                    this.MailM.Text = dt6.Rows[0]["Mail"].ToString();
                }
                // this.ApeMadre.Focus();
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

    protected void DniOtro_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (DniOtro.Text.Trim() != "")
            {
                dt7 = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text.Trim());
                if (dt7.Rows.Count > 0)
                {
                    this.ApeOtro.Text = dt7.Rows[0]["Apellido"].ToString();
                    this.NombOtro.Text = dt7.Rows[0]["Nombre"].ToString();
                    this.OcupOtro.Text = dt7.Rows[0]["Ocupacion"].ToString();
                    this.DniOtro.Text = dt7.Rows[0]["Doc"].ToString().Trim();
                    this.TelefO.Text = dt7.Rows[0]["Telefono"].ToString();
                    this.txtFijoO.Text = dt7.Rows[0]["TelefonoFijo"].ToString();
                    this.CuitO.Text = dt7.Rows[0]["Cuit"].ToString();
                    this.MailO.Text = dt7.Rows[0]["Mail"].ToString();
                }
                // this.ApeOtro.Focus();
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

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Preinscipcion.aspx");
    }
}
