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


public partial class InscripcionTutor : System.Web.UI.Page
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
    int Anio = DateTime.Today.Year + 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                insId = Convert.ToInt32(Session["_Institucion"]);
                dt8 = ocnInstitucion.ObtenerUno(insId);

                String NombreColegio = Convert.ToString(dt8.Rows[0]["Nombre"].ToString());
                //this.Master.TituloDelFormulario = " Inscripción: " + " " + Anio;

                DepartamentoId.DataValueField = "Valor"; DepartamentoId.DataTextField = "Texto"; DepartamentoId.DataSource = (new GESTIONESCOLAR.Negocio.Departamento()).ObtenerLista("[Seleccionar...]"); DepartamentoId.DataBind();
                //sexId.DataValueField = "Valor"; sexId.DataTextField = "Texto"; sexId.DataSource = (new GESTIONESCOLAR.Negocio.Sexo()).ObtenerLista("[Seleccionar...]"); sexId.DataBind();
                alert.Visible = false;
                alertExito.Visible = false;
                Session["Bandera"] = 0;

                lblMensajeError.Text = "";
                Panel1.Visible = false; // or false
                btnPreincribir.Enabled = true;
                btnFinalizar.Visible = false;
                //btnVolver.Visible = false;
                alerDNI.Visible = false;

                alerInscribir.Visible = false;
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


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            int cant;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            int anio = DateTime.Today.Year + 1;
            insId = Convert.ToInt32(Session["_Institucion"]);
            lblMensajeError1.Visible = false;
            lblMensajeError2.Visible = false;
            lblMensajeError3.Visible = false;
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
                                    this.ParentescoId.SelectedIndex = Convert.ToInt32((row["Parentesco"].ToString()));

                                }
                            }
                        }
                    }
                }
                //if (insId == 1)//San Jose
                //        {
                dt3 = ocnInscripcionCursado.ObtenerTodoxaluIdxAnio(aluId1, Anio);
                if (dt3.Rows.Count > 0)// ESTA REGISTRADO COMO ALUMNO PARA ESE AÑO?
                {
                    icuId2 = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    ins_Id = Convert.ToInt32(dt3.Rows[0]["insId"].ToString());
                    Colegio = Convert.ToString(dt3.Rows[0]["Colegio"].ToString());

                    dt4 = ocnInscripcionConcepto.ObtenerUnoxicuIdxMat(icuId2);
                    if (dt4.Rows.Count > 0)//Esta el concepto Matricula
                    {
                        dt2 = ocnComprobantesDetalle.ObtenerUnoxicoId(Convert.ToInt32(dt4.Rows[0]["Id"].ToString()));
                        if (dt2.Rows.Count > 0)//Esta el concepto Matricula pago?
                        {
                            dt5 = ocnConceptosIntereses.ObtenerInteresxconIdxNroCuota(Convert.ToInt32(dt4.Rows[0]["conId"].ToString()), Convert.ToInt32(dt4.Rows[0]["NroCuota"].ToString()));
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
                                            //DataTable  dtConc = ocnConceptos.ObtenerUno(Convert.ToInt32(Convert.ToInt32(dt4.Rows[0]["conId"].ToString())));
                                            dt6 = ocnComprobantesCabecera.ObtenerUno(Convert.ToInt32(dt2.Rows[0]["cocId"].ToString()));
                                            Bandera = 1;

                                        }
                                    }
                                }
                                if (Bandera == 1)
                                {
                                    Panel1.Visible = true;
                                    alerInscribir.Visible = true;
                                    btnPreincribir.Visible = true;

                                }
                            }
                        }

                        else
                        {
                            lblMensajeError2.Visible = true;
                            return;
                        }
                    }

                    else
                    {
                        lblMensajeError1.Visible = true;
                        Panel1.Visible = false;
                        return;
                    }

                }
                else
                {
                    lblMensajeError3.Visible = true;
                    Panel1.Visible = false; // or false                      

                    return;
                }
            }
            else
            {
                alerDNI.Visible = true;
                Panel1.Visible = false; // or false                      

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
            insId = Convert.ToInt32(Session["_Institucion"]);

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
                                    NomRep = "InformeConstanciaPreinscripcionJardinMisericordiaS4.rpt";
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
                                        NomRep = "InformeConstanciaPreinscripcionPadreVictorS4.rpt";
                                    }

                                    else
                                    {
                                        if (curso == 171 | curso == 172)
                                        {
                                            NomRep = "InformeConstanciaPreinscripcionPadreVictorS5.rpt";
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
                ocnAlumno.aluFechaHoraUltimaModificacion = DateTime.Now;
                //ocnAlumno.usuIdUltimaModificacion = this.Master.usuId;

                //String ClaveM;
                ocnAlumno.Actualizar(); //Actualizo Alumno 
            }
            else
            {
                lblMje3.Text = "El aumno no se encuentra en el sistema";
                return;
            }
            //int usuIdCreacion1 = 10;
            //int usuIdUltimaModificacion1 = 10;


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
                    //ocnFamiliar.usuId = usuIdP;
                    int famIdP = ocnFamiliar.Insertar();

                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                    ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorP);
                    ocnAlumnoFamiliar.aluId = aluId2;
                    ocnAlumnoFamiliar.famId = famIdP;
                    ocnAlumnoFamiliar.patId = 1;
                    //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
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
                    //ocnFamiliar.usuId = UsuIdNuevoM;
                    int famIdP = ocnFamiliar.Insertar();

                    ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                    ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorM);
                    ocnAlumnoFamiliar.aluId = aluId2;
                    ocnAlumnoFamiliar.famId = famIdP;
                    ocnAlumnoFamiliar.patId = 2;
                    //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                    ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
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
                            ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(FamIdAlumnoFamiliar);
                            //ocnAlumnoFamiliar.usuIdUltimaModificacion = this.Master.usuId;
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
                        //ocnFamiliar.usuId = UsuIdNuevoO;
                        int famIdo = ocnFamiliar.Insertar();

                        ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar(0);
                        ocnAlumnoFamiliar.afaEsTutor = Convert.ToBoolean(TutorO);
                        ocnAlumnoFamiliar.aluId = aluId2;
                        ocnAlumnoFamiliar.famId = famIdo;
                        ocnAlumnoFamiliar.patId = 3;
                        //ocnAlumnoFamiliar.usuIdCreacion = this.Master.usuId;
                        ocnAlumnoFamiliar.afaFechaHoraCreacion = DateTime.Today;
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
            int Inscripcion = 0;
            //ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado(Id);
            //int AnioLectivo = Convert.ToInt32(DateTime.Today.Year + 1);
            //ocnInscripcionCursado.icuAnoCursado = Convert.ToInt32(AnioLectivo);
            //ocnInscripcionCursado.icuFechaInscripcion = Convert.ToDateTime(DateTime.Today);
            //ocnInscripcionCursado.icuActivo = true;
            //ocnInscripcionCursado.aluId = aluId2;
            //ocnInscripcionCursado.icuEstado = 8;
            //ocnInscripcionCursado.icuFechaHoraCreacion = DateTime.Now;
            //ocnInscripcionCursado.icuFechaHoraUltimaModificacion = DateTime.Now;
            //ocnInscripcionCursado.usuIdCreacion = this.Master.usuId;
            //ocnInscripcionCursado.usuIdUltimaModificacion = this.Master.usuId;
            int conId1 = 0;
            if (insId == 1 || insId == 3)// San Jose y San Vicente no tienen turno
            { }
            else
            {
                if (insId == 2)// Misericordia
                { }
                else
                {
                    if (insId == 4)// Jardin Misericordia 
                    { }
                    else
                    {
                        if (insId == 5)// Jardin PV
                        { }

                    }
                }
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
