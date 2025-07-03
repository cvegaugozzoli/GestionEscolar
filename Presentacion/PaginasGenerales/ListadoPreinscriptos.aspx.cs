using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ListadoPreinscriptos : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    int insId;
    DataTable dt2 = new DataTable();
    GESTIONESCOLAR.Negocio.Curso ocnCurso = new GESTIONESCOLAR.Negocio.Curso();
    int Id = 0;
    int cur;
    int AnioCur;
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.EspacioCurricular ocnEspacioCurricular = new GESTIONESCOLAR.Negocio.EspacioCurricular();
    GESTIONESCOLAR.Negocio.PlanEstudio ocnPlanEstudio = new GESTIONESCOLAR.Negocio.PlanEstudio();
    GESTIONESCOLAR.Negocio.Campo ocnCampo = new GESTIONESCOLAR.Negocio.Campo();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.RegistracionNota ocnRegistracionNota = new GESTIONESCOLAR.Negocio.RegistracionNota();
    GESTIONESCOLAR.Negocio.Conceptos ocnConceptos = new GESTIONESCOLAR.Negocio.Conceptos();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.TemporalPreinscripcion ocnTemporalPreinscripcion = new GESTIONESCOLAR.Negocio.TemporalPreinscripcion();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();

    DataTable dt3 = new DataTable();
    DataTable dt8 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);
                ListadoxCurso.Visible = false;
                lblInsId.Text = Convert.ToString(Session["_Institucion"]);
                insId = Convert.ToInt32(Session["_Institucion"]);
                dt8 = ocnInstituciones.ObtenerUno(insId);
                lblMensajeError2.Text = "";
                String NombreColegio = Convert.ToString(dt8.Rows[0]["Nombre"].ToString());
                int anioPreins = DateTime.Today.Year + 1;
                this.Master.TituloDelFormulario = "Preinscripción: " + " " + anioPreins + " " + " Institución:  " + NombreColegio;
                AnioCursado.Text = Convert.ToString(DateTime.Today.Year);
                int perfil = Convert.ToInt32(Session["_perId"].ToString());
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "21") || (Session["_perId"].ToString() == "15") || (Session["_perId"].ToString() == "14") || (Session["_perId"].ToString() == "22") || (Session["_perId"].ToString() == "21") || (Session["_perId"].ToString() == "24")) // Si es administrador o Director o Secretaria o preinscripcion veo todas las carreras
                {

                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();

                    int TipoConc = 4;
                    DataTable dt = new DataTable();
                    dt = ocnConceptos.ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, TipoConc, Convert.ToInt32(AnioCursado.Text));
                    if (dt.Rows.Count > 1)
                    {
                        ConceptoId.DataValueField = "Valor";
                        ConceptoId.DataTextField = "Texto";
                        ConceptoId.DataSource = (new GESTIONESCOLAR.Negocio.Conceptos()).ObtenerListaPorUnTipoConcepto("[Seleccionar...]", insId, TipoConc, Convert.ToInt32(AnioCursado.Text));
                        ConceptoId.DataBind();
                    }
                    else
                    {
                        //alerErrorConcepto.Visible = true;
                    }

                    //ConTipoId.DataValueField = "Valor";
                    //ConTipoId.DataTextField = "Texto";
                    //ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerListaAlgunos("[Seleccionar...]", 4);
                    //ConTipoId.DataBind();
                    //carId.Enabled = true;
                    //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    ////EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                }
                //}



                #region PageIndex
                int PageIndex = 0;

                if (this.Session["ListadoPreinscriptos.PageIndex"] == null)
                {
                    Session.Add("ListadoPreinscriptos.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["ListadoPreinscriptos.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion

                //GrillaCargar(PageIndex);
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

    protected void ConceptoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ConceptoId.SelectedIndex != 0)
            {
                int ConceptoVer = Convert.ToInt32(ConceptoId.SelectedValue);
                //DataTable dt = new DataTable();
                //dt = ocnBecas.ObtenerLista("[Seleccionar...]");
                //if (dt.Rows.Count > 0)
                //{
                //    BecaId.DataValueField = "Valor";
                //    BecaId.DataTextField = "Texto";
                //    BecaId.DataSource = (new GESTIONESCOLAR.Negocio.Becas()).ObtenerLista("[Seleccionar...]");
                //    BecaId.DataBind();
                //}
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
    //protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    insId = Convert.ToInt32(Session["_Institucion"]);
    //    dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
    //    int car = 0;
    //    int pla = 0;
    //    if (Convert.ToInt32(NivelID.SelectedValue) == 4)//TIENE CARRERA Y PLAN? 0=SUPERIOR
    //    {
    //        lblMensajeError2.Text = "El nivel Superior no tiene preinscriptos..";
    //        return;

    //    }
    //    DataTable dt3 = new DataTable();
    //    DataTable dt4 = new DataTable();

    //    dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
    //    if (dt3.Rows.Count > 0)
    //    {
    //        car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
    //        dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
    //        if (dt4.Rows.Count > 0)
    //        {
    //            pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
    //        }
    //    }
    //    curId.DataValueField = "Valor";
    //    curId.DataTextField = "Texto";
    //    curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", pla);
    //    curId.DataBind();
    //}

    protected void NivelID_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
        dt = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
        int car = 0;
        int pla = 0;
        if (Convert.ToInt32(dt.Rows[0]["SinPC"].ToString()) == 0)//TIENE CARRERA Y PLAN? 0=SUPERIOR
        {
            carId.Enabled = true;
            carId.DataValueField = "Valor";
            carId.DataTextField = "Texto";
            carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", Convert.ToInt32(NivelID.SelectedValue));
            carId.DataBind();
            carId.Enabled = true;

        }
        else// es primario inicial o secundario
        {

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
            if (dt3.Rows.Count > 0)
            {
                car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
                if (dt4.Rows.Count > 0)
                {
                    pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                }
            }
            curId.DataValueField = "Valor";
            curId.DataTextField = "Texto";
            curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", pla);
            curId.DataBind();
            carId.Enabled = false;
            plaId.Enabled = false;
            carId.SelectedValue = "0";
            plaId.SelectedValue = "0";
        }
    }


    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in Grilla.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }



    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ocnCurso.ObtenerListadoxCurso(Id, Convert.ToString(AnioCur));
        string ArchivoNombre = "CursoListadoAlumnos" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["ListadoPreinscriptos.PageIndex"] = PageIndex;
            lblMensajeError2.Text = "";
            #region Variables de sesion para filtros

            #endregion
            cur = 0;
            if (curId.Text != "")
            {
                cur = Convert.ToInt32(curId.SelectedValue);
            }

            insId = Convert.ToInt32(Session["_Institucion"]);
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            int car = 0;
            int pla = 0;

            if (Convert.ToInt32(NivelID.SelectedValue) == 4)
            {
                if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
                {
                    car = Convert.ToInt32(carId.SelectedValue.ToString());
                    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
                    {
                        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
                    }
                    else
                    {
                        alerError.Visible = false;
                        lblError.Text = "Debe ingresar un Plan ";
                        return;
                    }
                }
                else
                {
                    alerError.Visible = false;
                    lblError.Text = "Debe ingresar una Carrera ";
                    return;

                }
            }
            else
            {
                dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
                if (dt3.Rows.Count > 0)
                {
                    car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                    dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
                    if (dt4.Rows.Count > 0)
                    {
                        pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                    }
                }
            }

            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }
            else
            {
                alerError.Visible = false;
                lblError.Text = "Debe ingresar un Curso";
                return;
            }


            if (AnioCursado.Text == "")
            {
                DateTime fechaActual = DateTime.Today;
                AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
            }
            else
            {
                AnioCur = Convert.ToInt32(AnioCursado.Text);
            }
            int concId = 0;

            //dt3 = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, 4, AnioCur);
            //if (dt3.Rows.Count > 0)
            //{


            if (ConceptoId.SelectedValue.ToString() == "" || ConceptoId.SelectedValue.ToString() == "0")
            {
                if (CheckSoloRinde.Checked)
                {
                    int TipoConc = 5;
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    DataTable dtConceptos = new DataTable();
                    dtConceptos = ocnConceptos.ObtenerUnoxInsxcntIdxAnio(insId, TipoConc, AnioCur);
                    if (dtConceptos.Rows.Count > 0)
                    {
                        concId = Convert.ToInt32(dtConceptos.Rows[0]["Id"].ToString());
                    }
                }
                else
                {
                    alerError.Visible = false;
                    lblError.Text = "Debe ingresar un Concepto";
                    return;
                }
            }
            else
            {
                concId = Convert.ToInt32(ConceptoId.SelectedValue.ToString());
            }
            

            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurxAnioxConId(insId, car, pla, cur, AnioCur, concId);

            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
            }
            else
            {
                dt = new DataTable();

                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                ListadoxCurso.Visible = false;
                lblMensajeError2.Text = "No existe preinscripción para ese año";
                return;
            }

            //Int32 Estado =8;

            //dt = new DataTable();
            //dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurxAnioxConId(insId, car, pla, cur, AnioCur, concId);
            //ListadoxCurso.Visible = true;
            //this.Grilla.DataSource = dt;
            //this.Grilla.PageIndex = PageIndex;
            //this.Grilla.DataBind();


            //if (dt.Rows.Count > 0)
            //{
            //    TextTC.Text = dt.Rows[0]["TipoCarrera"].ToString();
            //    ListadoxCurso.Visible = true;
            //}
            //else
            //{

            //    ListadoxCurso.Visible = false;
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


    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }


                if (e.CommandName == "Add")
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    String NomRep = "";
                    DataTable dt = new DataTable();
                    dt = ocnInscripcionCursado.ObtenerUno(Convert.ToInt32(IC));
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
                                    NomRep = "InformeConstanciaPreinscripcionJardinMisericordia.rpt";
                                }
                                else
                                {
                                    if (insId == 5) //Si es Jardin Padre Victor
                                    {
                                        NomRep = "InformeConstanciaPreinscripcionPadreVictor.rpt";

                                    }
                                }
                            }
                        }
                    }

                    FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId + "&curso=" + curso + "&anio=" + anio + "&NomRep=" + NomRep);
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

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#CCCCFF';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["ListadoAlumnosxCurso.PageIndex"] != null)
            {
                Session["ListadoAlumnosxCurso.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ListadoAlumnosxCurso.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex);
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

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnImprimir(object sender, EventArgs e)
    {

        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
            Int32 aniocursado = 0;
            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }

            NomRep = "ListadoPorCursoAnioPreInscriptos.rpt";

            //FuncionesUtiles.AbreVentana("Reporte.aspx?curso=" + curid + "&anio=" + aniocursado + "&insId=" + insId + "&NomRep=" + NomRep);
            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curid= " + curid + "&aniocursado=" + aniocursado + "&NomRep=" + NomRep);

            //@insId int,
            //@curid int,
            //@aniocursado int

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
            if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "15") || (Session["_perId"].ToString() == "14")) // Si es administrador (Marcela o Mariana) o preinscriptoI

            {
                DataTable dt3 = new DataTable();
                int Id = 0;
                Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
                dt3 = ocnInscripcionCursado.ObtenerUno(Id);

                if (dt3.Rows.Count > 0)
                {
                    int aluIdP = Convert.ToInt32(dt3.Rows[0]["aluId"].ToString());
                    ocnTemporalPreinscripcion.EliminarxAluId(aluIdP);
                }
                int usuIdCreacion = this.Master.usuId;
                ocnInscripcionCursado.Eliminar(Id, usuIdCreacion);
                ocnInscripcionConcepto.EliminarTodoxIcuId(Id, usuIdCreacion);

                ((Button)sender).Parent.Controls[1].Visible = true;
                ((Button)sender).Parent.Controls[3].Visible = false;
                ((Button)sender).Parent.Controls[5].Visible = false;

                GrillaCargar(Grilla.PageIndex);
            }

            else
            {
                lblMensajeError2.Text = "Su perfil no permite realizar esta operación";
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

    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }



    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        carIdCargar();
    }

    private void carIdCargar()
    {
        int upeId = Convert.ToInt32(Session["_upeId"].ToString());
        if (carId.SelectedIndex > 0)
        {
            DataTable dt = new DataTable();
            if (Session["_perId"].ToString() == "4") // Profesor
            {
                plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaPlanxusuId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); plaId.DataBind();
                plaId.Enabled = true;
            }
            else
            {
                dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    plaId.DataValueField = "Valor";
                    plaId.DataTextField = "Texto";
                    plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    plaId.DataBind();
                    plaId.Enabled = true;
                    this.Grilla.DataSource = null;

                    this.Grilla.DataBind();
                    ListadoxCurso.Visible = false;
                }
            }
        }
    }



    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        plaIdCargar();
    }


    private void plaIdCargar()
    {
        this.Grilla.DataSource = null;

        this.Grilla.DataBind();
        ListadoxCurso.Visible = false;
        int upeId = Convert.ToInt32(Session["_upeId"].ToString());
        if (plaId.SelectedIndex > 0)
        {
            if (Session["_perId"].ToString() == "4") // Profesor
            {
                curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
            }
            else
            {

                //ClubB.Negocio.Evento ocnEvento = new ClubB.Negocio.Evento();
                DataTable dt = new DataTable();
                dt = ocnCurso.ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    curId.DataValueField = "Valor";
                    curId.DataTextField = "Texto";
                    curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue));
                    curId.DataBind();
                }
            }
        }
    }


    protected void CheckSoloRinde_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckSoloRinde.Checked)
        {
            ConceptoId.SelectedValue = "0";
            ConceptoId.Enabled = false;
        }
        else
        {
            ConceptoId.Enabled = true;

        }
    }
}