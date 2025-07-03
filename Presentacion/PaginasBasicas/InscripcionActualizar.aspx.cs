using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


public partial class InscripcionActualizar : System.Web.UI.Page
{
    ReportDocument cryRpt;
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();

    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstitucion = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    GESTIONESCOLAR.Negocio.ConceptosIntereses ocnConceptosIntereses = new GESTIONESCOLAR.Negocio.ConceptosIntereses();
    GESTIONESCOLAR.Negocio.ComprobantesCabecera ocnComprobantesCabecera = new GESTIONESCOLAR.Negocio.ComprobantesCabecera();
    GESTIONESCOLAR.Negocio.InscripcionAnio ocnInscripcionAnio = new GESTIONESCOLAR.Negocio.InscripcionAnio();

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
    GESTIONESCOLAR.Negocio.Parametro ocnParametro = new GESTIONESCOLAR.Negocio.Parametro();
    DataTable dt = new DataTable();

    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable dt7 = new DataTable();
    DataTable dtInsc = new DataTable();

    DataTable dt8 = new DataTable();
    int CupoValidar = 0;
    int aluId2 = 0;
    int insId;
    int AnioIns;
    int cuotasAnioAnteriores;
    int cuotasAnioAnt;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Request.QueryString["Inst"]);
                btnImprimir.Visible = false;
                dtInsc = ocnInscripcionAnio.ObtenerUno();
                if (dtInsc.Rows.Count > 0)
                {
                    AnioIns = Convert.ToInt32(dtInsc.Rows[0]["Anio"].ToString());
                }
                DepartamentoId.DataValueField = "Valor"; DepartamentoId.DataTextField = "Texto"; DepartamentoId.DataSource = (new GESTIONESCOLAR.Negocio.Departamento()).ObtenerLista("[Seleccionar...]"); DepartamentoId.DataBind();
                GrupoSangId.DataValueField = "Valor"; GrupoSangId.DataTextField = "Texto"; GrupoSangId.DataSource = (new GESTIONESCOLAR.Negocio.GrupoSanguineo()).ObtenerLista("[Seleccionar...]"); GrupoSangId.DataBind();
            
                alertExito.Visible = false;
                Session["Bandera"] = 0;

                lblMensajeError.Text = "";
                Panel1.Visible = false; // or false
                btnPreincribir.Enabled = false;
                btnFinalizar.Visible = false;
                //btnVolver.Visible = false;
                alerDNI.Visible = false;
                alerInscribir2.Visible = false;
                alerInscribir.Visible = false;
                alerMisericordia.Visible = false;
                alerJardin.Visible = false;
                alerSanVicente.Visible = false;
                ParentescoId.DataValueField = "Valor";
                ParentescoId.DataTextField = "Texto";
                ParentescoId.DataSource = (new GESTIONESCOLAR.Negocio.Parentesco()).ObtenerLista("[Seleccionar...]");
                ParentescoId.DataBind();
                ParentescoId.SelectedValue = "[Seleccionar...]";

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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            btnPreincribir.Visible = false;
            btnPreincribir.Enabled = false;
            alerInscribir2.Visible = false;
            btnImprimir.Visible = false;
         
            alertExito3.Visible = false;
            alertExito.Visible = false;
            insId = Convert.ToInt32(Request.QueryString["Inst"]);
            int cant;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dtInsc = ocnInscripcionAnio.ObtenerUno();
            if (dtInsc.Rows.Count > 0)
            {
                AnioIns = Convert.ToInt32(dtInsc.Rows[0]["Anio"].ToString());
            }
            insId = Convert.ToInt32(Request.QueryString["Inst"]);
            lblMensajeError1.Visible = false;
            lblMensajeError2.Visible = false;
            lblMensajeError3.Visible = false;
            lblMensajeError5.Visible = false;
            lblMjeErrorCarrera.Visible = false;
            alerDNI.Visible = false;
            lblMensajeError.Text = "";
            dt = new DataTable();
            dt4 = new DataTable();
            dt5 = new DataTable();
            alerInscribir.Visible = false;
            alerSanVicente.Visible = false;
            alerMisericordia.Visible = false;
            alerJardin.Visible = false;

            Int32 icuId2 = 0;
            int Bandera;
            //Session["CuentaCorriente.PageIndex"] = PageIndex;

            int ins_Id = 0;
            String Colegio = "";
            dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
            if (dt.Rows.Count > 0) //Existe Alumno
            {
                int aluId1 = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                txtNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"].ToString());
                txtDni.Text = Convert.ToString(dt.Rows[0]["Doc"].ToString());
                aluDomicilio.Text = Convert.ToString(dt.Rows[0]["Domicilio"].ToString());
                DepartamentoId.SelectedValue = Convert.ToString(dt.Rows[0]["DeptoId"].ToString());
                txtTelFijo.Text = Convert.ToString(dt.Rows[0]["Telefono"].ToString());
                GrupoSangId.SelectedValue = Convert.ToString(dt.Rows[0]["GS"].ToString());
                txtDomFam.Text = Convert.ToString(dt.Rows[0]["aluDomFliar"].ToString());
                txtTelefUrg.Text = Convert.ToString(dt.Rows[0]["aluTelUrgencias"].ToString());
                TextPreg1.Text = Convert.ToString(dt.Rows[0]["aluPreg1"].ToString());
                TextPreg2.Text = Convert.ToString(dt.Rows[0]["aluPreg2"].ToString());
                TextPreg3.Text = Convert.ToString(dt.Rows[0]["aluPreg3"].ToString());
                TextPreg4.Text = Convert.ToString(dt.Rows[0]["aluPreg4"].ToString());
                TextPreg5.Text = Convert.ToString(dt.Rows[0]["aluPreg5"].ToString());
                TextPreg6.Text = Convert.ToString(dt.Rows[0]["aluPreg6"].ToString());
                TextPreg7.Text = Convert.ToString(dt.Rows[0]["aluPreg7"].ToString());
                txtAclara.Text = Convert.ToString(dt.Rows[0]["aluAclara"].ToString());



                dt5 = ocnAlumnoFamiliar.ObtenerTodoxaluId(aluId1);
                if (dt5.Rows.Count > 0)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        if (Convert.ToInt32(row["Parentesco"].ToString()) == 1)
                        {
                            this.ApePadre.Text = Convert.ToString((row["Apellido"].ToString()));
                            this.NomPadre.Text = Convert.ToString((row["Nombre"].ToString()));
                            this.OcupPadre.Text = Convert.ToString((row["Ocupacion"].ToString()));
                            this.DniPadre.Text = Convert.ToString((row["Doc"].ToString()));
                            this.TelefP.Text = Convert.ToString((row["Telefono"].ToString()));
                            this.txtFijoP.Text = Convert.ToString((row["TelFijo"].ToString()));
                            this.CuitP.Text = Convert.ToString((row["Cuit"].ToString()));
                            this.MailP.Text = Convert.ToString((row["Mail"].ToString()));
                            if (Convert.ToInt32(row["Tutor"].ToString()) == 1)
                            {
                                this.EsTutor.SelectedIndex = 1;
                            }
                            else
                            {
                            }

                        }
                        else
                        {
                            if (Convert.ToInt32(row["Parentesco"].ToString()) == 2)
                            {
                                this.ApeMadre.Text = Convert.ToString((row["Apellido"].ToString()));
                                this.NomMadre.Text = Convert.ToString((row["Nombre"].ToString()));
                                this.OcupMadre.Text = Convert.ToString((row["Ocupacion"].ToString()));
                                this.DniMadre.Text = Convert.ToString((row["Doc"].ToString()));
                                this.TelefM.Text = Convert.ToString((row["Telefono"].ToString()));
                                this.txtFijoM.Text = Convert.ToString((row["TelFijo"].ToString()));
                                this.CuitM.Text = Convert.ToString((row["Cuit"].ToString()));
                                this.MailM.Text = Convert.ToString((row["Mail"].ToString()));

                                if (Convert.ToInt32(row["Tutor"].ToString()) == 1)
                                {
                                    this.EsTutor.SelectedIndex = 0;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(row["Parentesco"].ToString()) == 3)
                                {
                                    this.ApeOtro.Text = Convert.ToString((row["Apellido"].ToString()));
                                    this.NombOtro.Text = Convert.ToString((row["Nombre"].ToString()));
                                    this.OcupOtro.Text = Convert.ToString((row["Ocupacion"].ToString()));
                                    this.DniOtro.Text = Convert.ToString((row["Doc"].ToString()));
                                    this.TelefO.Text = Convert.ToString((row["Telefono"].ToString()));
                                    this.txtFijoO.Text = Convert.ToString((row["TelFijo"].ToString()));
                                    this.CuitO.Text = Convert.ToString((row["Cuit"].ToString()));
                                    this.MailO.Text = Convert.ToString((row["Mail"].ToString()));
                                    this.ParentescoId.SelectedValue = Convert.ToString((row["Parentesco"].ToString()));
                                    if (Convert.ToInt32(row["Tutor"].ToString()) == 1)
                                    {
                                        this.EsTutor.SelectedIndex = 2;
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                //if (insId == 1)//San Jose
                //  
                dtInsc = ocnInscripcionAnio.ObtenerUno();
                if (dtInsc.Rows.Count > 0)
                {
                    AnioIns = Convert.ToInt32(dtInsc.Rows[0]["Anio"].ToString());
                    cuotasAnioAnt = Convert.ToInt32(dtInsc.Rows[0]["CantConcAnt"].ToString());
                    cuotasAnioAnteriores = Convert.ToInt32(dtInsc.Rows[0]["CanConcAtrasados"].ToString());

                }

                dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, AnioIns);
                if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                {
                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    lblicuId.Text = Convert.ToString(dt3.Rows[0]["Id"].ToString());
                    ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                    Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());
                    int Carrera = Convert.ToInt32(dt3.Rows[0]["carId"].ToString());
                    int Conf = Convert.ToInt32(dt3.Rows[0]["InsConfirmar"].ToString());
                    dtInsc = ocnInscripcionAnio.ObtenerUno();

                    if (ins_Id == insId)
                    {
                        if (insId == 1)
                        {
                            if (Carrera != 2)
                            {
                                lblMjeErrorCarrera.Visible = true;
                                txtNombre.Text = "";
                                txtDni.Text = "";
                                Panel1.Visible = false;
                                return;
                            }
                        }
                        if (Conf != 0)
                        {
                            if ((insId == 1) || insId == 2||insId == 4)
                            {
                                int Valor = ocnComprobantesDetalle.HabilitarInscripcion(ins_Id, aluId1, AnioIns, cuotasAnioAnt, cuotasAnioAnteriores);

                                if (Valor == 1)
                                {
                                    Panel1.Visible = true;
                                  
                                    if (insId == 4)
                                    {
                                        PanelDeclaracion.Visible = false;
                                    }
                                    else
                                    {
                                        PanelDeclaracion.Visible = true;
                                    }
                                    alerInscribir.Visible = true;
                                    btnPreincribir.Visible = true;
                                    btnPreincribir.Enabled = true;
                                    aluDomicilio.Enabled = true;
                                    DepartamentoId.Enabled = true;
                                    txtTelFijo.Enabled = true;
                                    ApePadre.Enabled = true;
                                    NomPadre.Enabled = true;
                                    TelefP.Enabled = true;
                                    txtFijoP.Enabled = true;
                                    CuitP.Enabled = true;
                                    OcupPadre.Enabled = true;
                                    MailP.Enabled = true;
                                    DniMadre.Enabled = true;
                                    ApeMadre.Enabled = true;
                                    NomMadre.Enabled = true;
                                    TelefM.Enabled = true;
                                    txtFijoM.Enabled = true;
                                    CuitM.Enabled = true;
                                    OcupMadre.Enabled = true;
                                    MailM.Enabled = true;
                                    ApeOtro.Enabled = true;
                                    NombOtro.Enabled = true;
                                    ParentescoId.Enabled = true;
                                    OcupOtro.Enabled = true;
                                    TelefO.Enabled = true;
                                    txtFijoO.Enabled = true;
                                    CuitO.Enabled = true;
                                    GrupoSangId.Enabled = true;
                                    txtTelefUrg.Enabled = true;
                                    txtDomFam.Enabled = true;
                                    TextPreg1.Enabled = true;
                                    TextPreg2.Enabled = true;
                                    TextPreg3.Enabled = true;
                                    TextPreg4.Enabled = true;
                                    TextPreg5.Enabled = true;
                                    TextPreg6.Enabled = true;
                                    TextPreg7.Enabled = true;
                                    txtAclara.Enabled = true;
                                }
                                else
                                {
                                    lblMensajeError2.Visible = true;
                                    txtNombre.Text = "";
                                    txtDni.Text = "";
                                    Panel1.Visible = false;
                                    PanelDeclaracion.Visible = false;
                                    return;
                                }
                            }
                            else
                            {
                                //Panel1.Visible = true;
                                //alerInscribir.Visible = true;
                                //btnPreincribir.Visible = true;
                                //btnPreincribir.Enabled = true;

                                //aluDomicilio.Enabled = true;
                                //DepartamentoId.Enabled = true;
                                //txtTelFijo.Enabled = true;
                                //ApePadre.Enabled = true;
                                //NomPadre.Enabled = true;
                                //TelefP.Enabled = true;
                                //txtFijoP.Enabled = true;
                                //CuitP.Enabled = true;
                                //OcupPadre.Enabled = true;
                                //MailP.Enabled = true;
                                //DniMadre.Enabled = true;
                                //ApeMadre.Enabled = true;
                                //NomMadre.Enabled = true;
                                //TelefM.Enabled = true;
                                //txtFijoM.Enabled = true;
                                //CuitM.Enabled = true;
                                //OcupMadre.Enabled = true;
                                //MailM.Enabled = true;
                                //ApeOtro.Enabled = true;
                                //NombOtro.Enabled = true;
                                //ParentescoId.Enabled = true;
                                //OcupOtro.Enabled = true;
                                //TelefO.Enabled = true;
                                //txtFijoO.Enabled = true;
                                //CuitO.Enabled = true;
                                //GrupoSangId.Enabled = true;
                                //txtTelefUrg.Enabled = true;
                                //txtDomFam.Enabled = true;
                                //TextPreg1.Enabled = true;
                                //TextPreg2.Enabled = true;
                                //TextPreg3.Enabled = true;
                                //TextPreg4.Enabled = true;
                                //TextPreg5.Enabled = true;
                                //TextPreg6.Enabled = true;
                                //TextPreg7.Enabled = true;
                                //txtAclara.Enabled = true;
                            }
                        }
                        else
                        {
                            Panel1.Visible = true;
                            if (insId == 4)
                            {
                                PanelDeclaracion.Visible = false;
                            }
                            else
                            {
                                PanelDeclaracion.Visible = true;
                            }
                            alerInscribir2.Visible = true;
                            btnPreincribir.Enabled = false;
                            btnPreincribir.Visible = true;
                            btnImprimir.Visible = true;
                            aluDomicilio.Enabled = false;
                            DepartamentoId.Enabled = false;
                            txtTelFijo.Enabled = false;
                            ApePadre.Enabled = false;
                            NomPadre.Enabled = false;
                            TelefP.Enabled = false;
                            txtFijoP.Enabled = false;
                            CuitP.Enabled = false;
                            OcupPadre.Enabled = false;
                            MailP.Enabled = false;
                            DniMadre.Enabled = false;
                            ApeMadre.Enabled = false;
                            NomMadre.Enabled = false;
                            TelefM.Enabled = false;
                            txtFijoM.Enabled = false;
                            CuitM.Enabled = false;
                            OcupMadre.Enabled = false;
                            MailM.Enabled = false;
                            ApeOtro.Enabled = false;
                            NombOtro.Enabled = false;
                            ParentescoId.Enabled = false;
                            OcupOtro.Enabled = false;
                            TelefO.Enabled = false;
                            txtFijoO.Enabled = false;
                            CuitO.Enabled = false;
                            GrupoSangId.Enabled = false;
                            txtTelefUrg.Enabled = false;
                            txtDomFam.Enabled = false;
                            TextPreg1.Enabled = false;
                            TextPreg2.Enabled = false;
                            TextPreg3.Enabled = false;
                            TextPreg4.Enabled = false;
                            TextPreg5.Enabled = false;
                            TextPreg6.Enabled = false;
                            TextPreg7.Enabled = false;
                            txtAclara.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        lblMensajeError5.Visible = true;
                        txtNombre.Text = "";
                        txtDni.Text = "";
                        Panel1.Visible = false;
                        PanelDeclaracion.Visible = false;
                        return;
                    }
                }
                else
                {
                    lblMensajeError3.Visible = true;
                    txtNombre.Text = "";
                    txtDni.Text = "";
                    Panel1.Visible = false; // or false   
                    PanelDeclaracion.Visible = false;

                    return;
                }
            }
            else
            {
                alerDNI.Visible = true;
                txtNombre.Text = "";
                txtDni.Text = "";
                Panel1.Visible = false; // or false  
                PanelDeclaracion.Visible = false;
                return;
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
            insId = Convert.ToInt32(Request.QueryString["Inst"]);

            //if (insId != 5)
            //{
            //rblTurno.Items[0].Selected = false;
            //rblTurno.Items[1].Selected = false;
            //rblTurno.Enabled = true;
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
            //dt4 = ocnAlumno.ObtenerUnoporDoc(Convert.ToString(TXTdni2.Text));
            //if (dt4.Rows.Count > 0)
            //{
            //    this.TXTdni2.Text = dt4.Rows[0]["Doc"].ToString();
            //    this.txtAlu.Text = dt4.Rows[0]["Nombre"].ToString();
            //    this.txtFecha.Text = dt4.Rows[0]["FechaNacimiento"].ToString();
            //    this.aluCuit.Text = dt4.Rows[0]["Cuit"].ToString();
            //    this.aluDomicilio.Text = dt4.Rows[0]["Domicilio"].ToString();
            //    this.DepartamentoId.SelectedValue = dt4.Rows[0]["DeptoId"].ToString();
            //    this.sexId.Text = dt4.Rows[0]["SexoId"].ToString();
            //    int IdAlu = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
            //    //Response.Redirect("AlumnoRegistracion.aspx?Id=" + IdAlu, false);
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


    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../PaginasBasicas/Inicio.aspx");
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Request.QueryString["Inst"]);
            String NomRep = "";
            DataTable dt = new DataTable();
            dt = ocnInscripcionCursado.ObtenerUno(Convert.ToInt32(lblicuId.Text));
            Int32 aluId = Convert.ToInt32(dt.Rows[0]["aluId"].ToString());
            Int32 curso = Convert.ToInt32(dt.Rows[0]["curId"].ToString());
            Int32 anio = Convert.ToInt32(dt.Rows[0]["AnoCursado"].ToString());

            NomRep = "InformeConstanciaInscripcionGral.rpt";

            FuncionesUtiles.AbreVentana("../PaginasGenerales/Reporte.aspx?aluId=" + aluId + "&curso=" + curso + "&anio=" + anio + "&NomRep=" + NomRep);
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
            alerInscribir2.Visible = false;
           
            alertExito3.Visible = false;
            alertExito.Visible = false;
            btnImprimir.Visible = false;
           
            btnPreincribir.Enabled = true;
            insId = Convert.ToInt32(Request.QueryString["Inst"]);
            //if (GrupoSangId.SelectedValue=="0")
            //{

            //}
            //////////////////////////////////////////////////////////////////////
            //Actualizo Alumno
            dt5 = new DataTable();
            dt5 = ocnAlumno.ObtenerUnoporDoc(txtDni.Text.Trim());
            if (dt5.Rows.Count > 0) // Verifico que existe en Alumno
            {
                //Editar
                aluId2 = Convert.ToInt32(dt5.Rows[0]["Id"].ToString());
                ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno(aluId2);
                ocnAlumno.aluDomicilio = aluDomicilio.Text.Trim();
                ocnAlumno.aluDepto = Convert.ToInt32(DepartamentoId.SelectedValue);
                ocnAlumno.aluActivo = true;
                ocnAlumno.aluTelefono = txtTelFijo.Text.Trim();
                ocnAlumno.gsaId = Convert.ToInt32(GrupoSangId.SelectedValue);
                ocnAlumno.aluTelUrgencias = txtTelefUrg.Text;
                ocnAlumno.aluDomFliar = txtDomFam.Text;
                ocnAlumno.aluPreg1 = TextPreg1.Text;
                ocnAlumno.aluPreg2 = TextPreg2.Text;
                ocnAlumno.aluPreg3 = TextPreg3.Text;
                ocnAlumno.aluPreg4 = TextPreg4.Text;
                ocnAlumno.aluPreg5 = TextPreg5.Text;
                ocnAlumno.aluPreg6 = TextPreg6.Text;
                ocnAlumno.aluPreg7 = TextPreg7.Text;
                ocnAlumno.aluAclara = txtAclara.Text;
                ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
                //ocnAlumno.usuIdUltimaModificacion = this.Master.usuId;
                ocnAlumno.Actualizar(); //Actualizo Alumno 
            }
            else
            {
                lblMje3.Text = "El aumno no se encuentra en el sistema";
                return;
            }
            //int usuIdCreacion1 = this.Master.usuId;
            //int usuIdUltimaModificacion1 = this.Master.usuId;


            int TutorM = 0;
            int TutorP = 0;
            int TutorO = 0;

            if (EsTutor.SelectedIndex == 0) //tutor Madre
            {
                if (DniMadre.Text.Trim() == "")
                {
                    lblMje3.Text = "Ud. seleccionó a la Mamá como tutor. Complete el DNI de la Mamá..";
                    return;
                }
                else
                {
                    if (ApeMadre.Text.Trim() == "")
                    {
                        lblMje3.Text = "Ud. seleccionó a la Mamá como tutor. Complete el Apellido de la Mamá..";
                        return;
                    }
                    else
                    {
                        if (NomMadre.Text.Trim() == "")
                        {
                            lblMje3.Text = "Ud. seleccionó a la Mamá como tutor. Complete el Nombre de la Mamá..";
                            return;
                        }
                        else
                        {
                            if (CuitM.Text.Trim() == "")
                            {
                                lblMje3.Text = "Ud. seleccionó a la Mamá como tutor. Complete el CUIL de la Mamá..";
                                return;
                            }
                            else
                            {
                                if (TelefM.Text.Trim() == "" & txtFijoM.Text.Trim() == "")
                                {
                                    lblMje3.Text = "Ud. seleccionó a la Mamá como tutor. Complete al menos un telefono de la Mamá..";
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
                if (EsTutor.SelectedIndex == 1) //tutor Papá
                {
                    if (DniPadre.Text.Trim() == "")
                    {
                        lblMje3.Text = "Ud. seleccionó al Papá como tutor. Complete el DNI del Papá..";
                        return;
                    }
                    else
                    {
                        if (ApePadre.Text.Trim() == "")
                        {
                            lblMje3.Text = "Ud. seleccionó al Papá como tutor. Complete el Apellido del Papá..";
                            return;
                        }
                        else
                        {
                            if (NomPadre.Text.Trim() == "")
                            {
                                lblMje3.Text = "Ud. seleccionó al Papá como tutor. Complete el Nombre del Papá..";
                                return;
                            }
                            else
                            {
                                if (CuitP.Text.Trim() == "")
                                {
                                    lblMje3.Text = "Ud. seleccionó al Papá como tutor. Complete el CUIL del Papá..";
                                    return;
                                }
                                else
                                {
                                    if (TelefP.Text.Trim() == "" & txtFijoP.Text.Trim() == "")
                                    {
                                        lblMje3.Text = "Ud. seleccionó al Papá como tutor. Complete al menos un telefono del Papá..";
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

                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(FamIdPadre);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApePadre.Text.Trim();
                    ocnFamiliar.famNombre = NomPadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupPadre.Text.Trim();
                    ocnFamiliar.famDni = DniPadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefP.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoP.Text.Trim();
                    ocnFamiliar.famCuit = CuitP.Text.Trim();
                    ocnFamiliar.famMail = MailP.Text.Trim();
                    //ocnFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                    //ocnFamiliar.usuId = usuIdP;

                    ocnFamiliar.Actualizar();

                    //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                    //String ClaveP = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";

                    if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar);
                        //ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                        ocnAlumnoFamiliar.Actualizar();
                    }
                    else
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = FamIdPadre;
                        ocnAlumnoFamiliar.patId = 1;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.Insertar();
                    }
                }
                else // Inserto Padre en Familiar y en AlumnoFamiliar
                {

                    String ClaveP = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    //Int32 UsuIdNuevoP = ocnUsuario.InsertarTraerId(insId, ApePadre.Text.Trim(), NomPadre.Text.Trim(), DniPadre.Text.Trim(), ClaveP, "", false, MailP.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);
                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(0);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApePadre.Text.Trim();
                    ocnFamiliar.famNombre = NomPadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupPadre.Text.Trim();
                    ocnFamiliar.famDni = DniPadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefP.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoP.Text.Trim();
                    ocnFamiliar.famCuit = CuitP.Text.Trim();
                    ocnFamiliar.famMail = MailP.Text.Trim();
                    //ocnFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraCreacion = DateTime.Today;
                    ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                    //ocnFamiliar.usuId = usuIdP;
                    int famIdP = ocnFamiliar.Insertar();

                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                    ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                    ocnAlumnoFamiliar.aluId = aluId2;
                    ocnAlumnoFamiliar.famId = famIdP;
                    ocnAlumnoFamiliar.patId = 1;
                    //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                    ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                    ocnAlumnoFamiliar.Insertar();
                    //ocnAlumnoFamiliar.Insertar(aluId2, famIdP, 1, TutorP, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today);
                }
            }

            if (DniMadre.Text.Trim() != "")
            {
                dt = new DataTable();
                dt = ocnFamiliar.ObtenerUnoPorDoc(DniMadre.Text.Trim());

                if (dt.Rows.Count > 0)//existe Madre en Familiar
                {
                    int FamIdMadre = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniMadre.Text.Trim());

                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(FamIdMadre);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApeMadre.Text.Trim();
                    ocnFamiliar.famNombre = NomMadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupMadre.Text.Trim();
                    ocnFamiliar.famDni = DniMadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefM.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoM.Text.Trim();
                    ocnFamiliar.famCuit = CuitM.Text.Trim();
                    ocnFamiliar.famMail = MailM.Text.Trim();
                    //ocnFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                    //ocnFamiliar.usuId = usuIdP;

                    ocnFamiliar.Actualizar();

                    //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                    //String claveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    //Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), claveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);

                    if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar);
                        //ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                        ocnAlumnoFamiliar.Actualizar();
                    }
                    else
                    {
                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = FamIdMadre;
                        ocnAlumnoFamiliar.patId = 2;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.Insertar();
                    }
                }
                else // Inserto Madre en Familiar y en AlumnoFamiliar
                {
                    String claveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                    //Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), claveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);
                    ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(0);
                    //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                    ocnFamiliar.famApellido = ApeMadre.Text.Trim();
                    ocnFamiliar.famNombre = NomMadre.Text.Trim();
                    ocnFamiliar.famOcupacion = OcupMadre.Text.Trim();
                    ocnFamiliar.famDni = DniMadre.Text.Trim();
                    ocnFamiliar.famTelefonoCel = TelefM.Text.Trim();
                    ocnFamiliar.famTelefonoFijo = txtFijoM.Text.Trim();
                    ocnFamiliar.famCuit = CuitM.Text.Trim();
                    ocnFamiliar.famMail = MailM.Text.Trim();
                    //ocnFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnFamiliar.famFechaHoraCreacion = DateTime.Today;
                    ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                    //ocnFamiliar.usuId = UsuIdNuevoM;
                    int famIdP = ocnFamiliar.Insertar();

                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                    ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                    ocnAlumnoFamiliar.aluId = aluId2;
                    ocnAlumnoFamiliar.famId = famIdP;
                    ocnAlumnoFamiliar.patId = 2;
                    //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                    ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                    ocnAlumnoFamiliar.Insertar();
                }
            }

            if (DniOtro.Text.Trim() != "")
            {
                dt = new DataTable();
                dt = ocnFamiliar.ObtenerUnoPorDoc(DniOtro.Text.Trim());
                int ParentescoOtro2 = Convert.ToInt32((ParentescoId.SelectedValue.Trim() == "" ? "0" : ParentescoId.SelectedValue));

                if (Convert.ToInt32(ParentescoId.SelectedValue) != 0) //Si no selecciono parentezco..
                {
                    if (dt.Rows.Count > 0) //existe Otro en Familiar
                    {
                        int FamIdOtro = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                        int FamIdAlumnoFamiliar = ocnAlumnoFamiliar.ObtenerUnoIdFam(aluId2, DniOtro.Text.Trim());

                        ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(FamIdOtro);
                        //int usuIdO = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                        ocnFamiliar.famApellido = ApeOtro.Text.Trim();
                        ocnFamiliar.famNombre = NombOtro.Text.Trim();
                        ocnFamiliar.famOcupacion = OcupOtro.Text.Trim();
                        ocnFamiliar.famDni = DniOtro.Text.Trim();
                        ocnFamiliar.famTelefonoCel = TelefO.Text.Trim();
                        ocnFamiliar.famTelefonoFijo = txtFijoO.Text.Trim();
                        ocnFamiliar.famCuit = CuitO.Text.Trim();
                        ocnFamiliar.famMail = MailO.Text.Trim();
                        //ocnFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                        ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                        //ocnFamiliar.usuId = usuIdO;

                        ocnFamiliar.Actualizar();

                        //dt2 = ocnUsuario.ObtenerUno(usuIdP);
                        //String claveM = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                        //Int32 UsuIdNuevoM = ocnUsuario.InsertarTraerId(insId, ApeMadre.Text.Trim(), NomMadre.Text.Trim(), DniMadre.Text.Trim(), claveM, "", false, MailM.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);

                        if (FamIdAlumnoFamiliar != 0) //Esta asignado para el alumno? Ese familiar esta asignado en alumnoFamiliar
                        {
                            ////ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar); ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
                            ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                            ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                            ocnAlumnoFamiliar.Actualizar();
                        }
                        else
                        {
                            ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                            ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                            ocnAlumnoFamiliar.aluId = aluId2;
                            ocnAlumnoFamiliar.famId = FamIdOtro;
                            ocnAlumnoFamiliar.patId = 3;
                            //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                            ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                            ocnAlumnoFamiliar.Insertar();
                        }
                    }
                    else //NO existe Otro en Familiar
                    {
                        String claveO = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                        //Int32 UsuIdNuevoO = ocnUsuario.InsertarTraerId(insId, ApeOtro.Text.Trim(), NombOtro.Text.Trim(), DniOtro.Text.Trim(), claveO, "", false, MailO.Text.Trim(), 10, usuIdCreacion1, usuIdUltimaModificacion1, DateTime.Today, DateTime.Today, true);
                        ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar(0);
                        //int usuIdP = Convert.ToInt32(dt.Rows[0]["UsuId"].ToString());
                        ocnFamiliar.famApellido = ApeOtro.Text.Trim();
                        ocnFamiliar.famNombre = NombOtro.Text.Trim();
                        ocnFamiliar.famOcupacion = OcupOtro.Text.Trim();
                        ocnFamiliar.famDni = DniOtro.Text.Trim();
                        ocnFamiliar.famTelefonoCel = TelefO.Text.Trim();
                        ocnFamiliar.famTelefonoFijo = txtFijoO.Text.Trim();
                        ocnFamiliar.famCuit = CuitO.Text.Trim();
                        ocnFamiliar.famMail = MailO.Text.Trim();
                        //ocnFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnFamiliar.famFechaHoraCreacion = DateTime.Today;
                        ocnFamiliar.famFechaHoraUltimaModificacion = DateTime.Today;
                        //ocnFamiliar.usuId = UsuIdNuevoO;
                        int famIdo = ocnFamiliar.Insertar();

                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = famIdo;
                        ocnAlumnoFamiliar.patId = 3;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
                        ocnAlumnoFamiliar.afaFechaHoraUltimaModificacion = DateTime.Today;
                        ocnAlumnoFamiliar.Insertar();
                    }
                }
                else
                {
                    lblMje3.Text = "Debe seleccionar Parentezco";
                    lblMensajeError.Text = "Debe seleccionar Parentezco";
                    return;
                }
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Inscribir Colegio Curso Turno
            int icuIdAct = Convert.ToInt32(lblicuId.Text);
            ocnInscripcionCursado.ActualizarEstadoInscConf(icuIdAct, 0);
            alertExito.Visible = true;
            btnImprimir.Visible = true;
            btnPreincribir.Enabled = false;


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