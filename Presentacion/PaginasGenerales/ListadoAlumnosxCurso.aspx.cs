using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ListadoAlumnosxCurso : System.Web.UI.Page
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
    GESTIONESCOLAR.Negocio.TipoCarrera ocnTipoCarrera = new GESTIONESCOLAR.Negocio.TipoCarrera();
    GESTIONESCOLAR.Negocio.InstitucionNivel ocnInstitucionNivel = new GESTIONESCOLAR.Negocio.InstitucionNivel();
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
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
                this.Master.TituloDelFormulario = "Listado de Alumnos x Curso";

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "15") || (Session["_perId"].ToString() == "14")) // Si es administrador o Director o Secretaria veo todas las carreras
                {

                    NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                    PanelAdmin.Visible = true;
                    //carId.Enabled = true;
                    //carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                }
                else
                {
                    if ((Session["_perId"].ToString() == "25") || (Session["_perId"].ToString() == "5")) // Si es administrador o Director o Secretaria veo todas las carreras
                    {
                        NivelID.DataValueField = "Valor"; NivelID.DataTextField = "Texto"; NivelID.DataSource = (new GESTIONESCOLAR.Negocio.InstitucionNivel()).ObtenerListaxIns("[Seleccionar...]", insId); NivelID.DataBind();
                        pnlPrimariaSec.Visible = true;
                    }
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["ListadoAlumnosxCurso.PageIndex"] == null)
                {
                    Session.Add("ListadoAlumnosxCurso.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CursoListadoCalifxAlumno.PageIndex"]);
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
            carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]");
            carId.DataBind();
            carId.Enabled = true;

        }
        else// es primario inicial o secundario
        {

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();

            dt3 = ocnCarrera.ObtenerUnoxNivel(Convert.ToInt32(NivelID.SelectedValue));
            if (dt3.Rows.Count > 0)
            {
                car = Convert.ToInt32(dt3.Rows[0]["Id"].ToString());
                carId.SelectedIndex = car;
                carId.DataBind();
                dt4 = ocnPlanEstudio.ObtenerUnoxCarrera(car);
                if (dt4.Rows.Count > 0)
                {
                    plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", car); plaId.DataBind();

                    pla = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                    plaId.SelectedValue = Convert.ToString(pla);
                    plaId.DataBind();
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
        foreach (GridViewRow row in GrillaConFicha.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
            }
        }
        base.Render(writer);
    }

    protected void Exportar_Click(object sender, EventArgs e)
    {
        gridtemp.Columns[1].Visible = true;
        gridtemp.Columns[2].Visible = true;
        gridtemp.Columns[3].Visible = true;
        gridtemp.Columns[4].Visible = true;
        //var grid = new GridView();
        //grid.DataSource = gridtemp;
        //grid.DataBind();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=Listado.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gridtemp.RenderControl(htw);
        string style = @"<style> td { mso-number-format:\@;} </style>";
        Response.Write(style);
        Response.Write(sw.ToString());
        Response.End();
        gridtemp.Columns[1].Visible = false;
        gridtemp.Columns[2].Visible = false;
        gridtemp.Columns[3].Visible = false;
        gridtemp.Columns[4].Visible = false;
        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //using (StringWriter sw = new StringWriter())
        //{
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    //To Export all pages
        //    gridtemp.AllowPaging = false;
        //    //this.BindGrid();

        //    //Grilla.HeaderRow.BackColor = Color.White;
        //    foreach (TableCell cell in gridtemp.HeaderRow.Cells)
        //    {
        //        cell.BackColor = gridtemp.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in gridtemp.Rows)
        //    {
        //        //row.BackColor = Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = gridtemp.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = gridtemp.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //        }
        //    }

        //    gridtemp.RenderControl(hw);

        //    //style to format numbers to string
        //    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
    }




    protected void btnExportarAExcel_Click(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);
        Int32 car = 0;
        Int32 pla = 0;

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
                    alerError.Visible = true;
                    lblError.Text = "Debe ingresar un Plan ";
                    return;
                }
            }
            else
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar una Carrera ";
                return;

            }
        }

        if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
        {
            cur = Convert.ToInt32(curId.SelectedValue.ToString());

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
        dt = new DataTable();


        dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);
        string ArchivoNombre = "CursoListadoAlumnos" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            if (Convert.ToInt32(NivelID.SelectedValue) == 0)
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Nivel ";
                return;
            }
            if (Convert.ToInt32(curId.SelectedValue) == 0)
            {
                alerError.Visible = true;
                lblError.Text = "Debe ingresar un Curso ";
                return;
            }

            Exportar.Visible = false;
            ListadoxCurso.Visible = false;
            Session["ListadoAlumnosxCurso.PageIndex"] = PageIndex;
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 car = 0;
            Int32 pla = 0;

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


            if ((Session["_perId"].ToString() == "25") || (Session["_perId"].ToString() == "5")) // Si es celador o preceptor
            {
                if (Session["_perId"].ToString() == "25")
                {
                    dt = new DataTable();

                    insId = Convert.ToInt32(Session["_Institucion"]);
                    String NomRep;

                    Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
                    Int32 anio = 0;
                    Int32 ParamInt1 = 0;
                    if (AnioCursado.Text.Trim().ToString() != "")
                    {
                        anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
                    }
                    if (Convert.ToInt32(RbtPriSec.SelectedValue) == 1)
                    {
                        NomRep = "ListadoPorCursoAnioPrimaria.rpt";

                        FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&carId=" + Convert.ToInt32(carId.SelectedValue.ToString()) + "&plaId=" + Convert.ToInt32(plaId.SelectedValue.ToString()) + "&curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
                    }
                    else
                    {
                        if (Convert.ToInt32(RbtPriSec.SelectedValue) == 2)
                        {
                            ParamInt1 = 1;
                            NomRep = "ListadoPorCursoAnioPrimariaDNI.rpt";
                            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&carId=" + Convert.ToInt32(carId.SelectedValue.ToString()) + "&plaId=" + Convert.ToInt32(plaId.SelectedValue.ToString()) + "&curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
                        }
                        else
                        {

                            if (Convert.ToInt32(RbtPriSec.SelectedValue) == 3)
                            {
                                ParamInt1 = 1;
                                NomRep = "ListadoPorCursoAnioPrimariaReunion.rpt";
                                FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&carId=" + Convert.ToInt32(carId.SelectedValue.ToString()) + "&plaId=" + Convert.ToInt32(plaId.SelectedValue.ToString()) + "&curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
                            }
                            else
                            {

                                //ParamInt1 = 0;
                                //if (insId == 121)
                                //{
                                //    NomRep = "ListadoPorCursoAnioConfNew.rpt";
                                //}
                                //else
                                //{
                                //    NomRep = "ListadoPorCursoAnioConf.rpt";

                                //}
                                //FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curid=" + curid + "&aniocursado=" + anio + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);

                            }
                        }
                    }
                }

                else
                {
                    if (Session["_perId"].ToString() == "5")
                    {
                        dt = new DataTable();

                        insId = Convert.ToInt32(Session["_Institucion"]);
                        String NomRep;

                        Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
                        Int32 anio = 0;
                        Int32 ParamInt1 = 0;
                        if (AnioCursado.Text.Trim().ToString() != "")
                        {
                            anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
                        }
                        if (Convert.ToInt32(RbtPriSec.SelectedValue) == 1)
                        {
                            NomRep = "ListadoPorCursoAnioSecundaria.rpt";

                            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&carId=" + Convert.ToInt32(carId.SelectedValue.ToString()) + "&plaId=" + Convert.ToInt32(plaId.SelectedValue.ToString()) + "&curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
                        }
                        else
                        {
                            if (Convert.ToInt32(RbtPriSec.SelectedValue) == 2)
                            {
                                ParamInt1 = 1;
                                NomRep = "ListadoPorCursoAnioSecundariaDNI.rpt";
                                FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&carId=" + Convert.ToInt32(carId.SelectedValue.ToString()) + "&plaId=" + Convert.ToInt32(plaId.SelectedValue.ToString()) + "&curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
                            }
                            else
                            {

                                if (Convert.ToInt32(RbtPriSec.SelectedValue) == 3)
                                {
                                    ParamInt1 = 1;
                                    NomRep = "ListadoPorCursoAnioSecundariaReunion.rpt";
                                    FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&carId=" + Convert.ToInt32(carId.SelectedValue.ToString()) + "&plaId=" + Convert.ToInt32(plaId.SelectedValue.ToString()) + "&curId=" + Int32.Parse(curId.SelectedValue.ToString()) + "&anio=" + anio + "&NomRep=" + NomRep);
                                }
                                else
                                {

                                    //ParamInt1 = 0;
                                    //if (insId == 121)
                                    //{
                                    //    NomRep = "ListadoPorCursoAnioConfNew.rpt";
                                    //}
                                    //else
                                    //{
                                    //    NomRep = "ListadoPorCursoAnioConf.rpt";

                                    //}
                                    //FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curid=" + curid + "&aniocursado=" + anio + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);

                                }
                            }
                        }
                    }
                }
            }

            else
            {

                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "15") || (Session["_perId"].ToString() == "14")) // Si es administrador o Director o Secretaria veo todas las carreras
                {
                    dt = new DataTable();
                    if (Convert.ToInt32(RbtSeleccion.SelectedValue) == 1)
                    {
                        dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnio(insId, car, pla, cur, AnioCur);
                    }
                    else
                    {
                        if (Convert.ToInt32(RbtSeleccion.SelectedValue) == 2)
                        {
                            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnioxConf(insId, car, pla, cur, AnioCur, 1);
                        }
                        else
                        {
                            dt = ocnInscripcionCursado.ObtenerporCarporPlaporCurAnioxConf(insId, car, pla, cur, AnioCur, 0);
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(RbtSeleccion.SelectedValue) == 3)
                        {
                            GrillaConFicha.Visible = true;
                            this.GrillaConFicha.DataSource = dt;
                            this.GrillaConFicha.PageIndex = PageIndex;
                            this.GrillaConFicha.DataBind();
                            Grilla.Visible = false;
                            this.Grilla.DataSource = null;
                            this.Grilla.PageIndex = PageIndex;
                            this.Grilla.DataBind();
                            //CanReg.Visible = true;
                            //lblCantidad.Text = Convert.ToString(dt.Rows.Count);
                        }
                        else
                        {
                            Grilla.Visible = true;
                            this.Grilla.DataSource = dt;
                            this.Grilla.PageIndex = PageIndex;
                            this.Grilla.DataBind();
                            GrillaConFicha.Visible = false;
                            this.GrillaConFicha.DataSource = null;
                            this.GrillaConFicha.PageIndex = PageIndex;
                            this.GrillaConFicha.DataBind();
                            //CanReg.Visible = true;
                            //lblCantidadRegistros.Text = Convert.ToString(dt.Rows.Count);
                        }

                        gridtemp.DataSource = dt;
                        gridtemp.DataBind();
                        Exportar.Visible = true;
                        TextTC.Text = dt.Rows[0]["TipoCarrera"].ToString();
                        ListadoxCurso.Visible = true;
                    }
                    else
                    {
                        this.Grilla.DataSource = dt;
                        this.Grilla.PageIndex = PageIndex;
                        this.Grilla.DataBind();

                        alerError.Visible = true;
                        lblError.Text = "No hay registros..";
                        return;
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

                //if (e.CommandName == "Eliminar")
                //{
                //    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                //    ocnCurso = new GESTIONESCOLAR.Negocio.Curso(Convert.ToInt32(IC));
                //    //ocnCurso.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                if (e.CommandName == "Ver")
                {
                    String TC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Controls[1]).Text;
                    if (TC == "4")
                    {
                        Response.Redirect("RegistracionCalificacionesRegistracion.aspx?Id=" + IC + "&Ver=1", false);
                    }
                    else
                    {
                        if (TC == "3")
                        {
                            Response.Redirect("CargaCalificacionesPorAlumnoSec.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                        }
                        else
                        {
                            if (TC == "2")
                            {
                                Response.Redirect("CargaCalificacionesPorAlumnoPri.aspx?Id=" + IC + "&Anio=" + AnioCur + "&Ver=1", false);
                            }
                        }
                    }
                }
                String alu = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Controls[1]).Text;
                int aluId = Convert.ToInt32(alu);
                if (e.CommandName == "Ficha")
                {
                    String NomRep;
                    NomRep = "AlumnoFicha.rpt";
                    FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId + "&NomRep=" + NomRep);
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
    protected void GrillaConFicha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string IC = ((HyperLink)GrillaConFicha.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;
                int aluId = Convert.ToInt32(IC);
                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                if (e.CommandName == "Ver")
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    String NomRep;
                    Int32 curso = Int32.Parse(curId.SelectedValue.ToString());
                    Int32 anio = 0;

                    if (AnioCursado.Text.Trim().ToString() != "")
                    {
                        anio = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
                    }

                    NomRep = "FichaMedica.rpt";
                    FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId + "&curso=" + curso + "&anio=" + anio + "&NomRep=" + NomRep);

                }
                if (e.CommandName == "FichaAlumno")
                {
                    String NomRep;
                    NomRep = "FichaAlumno.rpt";
                    FuncionesUtiles.AbreVentana("Reporte.aspx?aluId=" + aluId + "&NomRep=" + NomRep);
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
    protected void GrillaConFicha_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GrillaConFicha_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        alerError.Visible = false;
        GrillaCargar(Grilla.PageIndex);
    }


    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        carIdCargar();
    }

    private void carIdCargar()
    {
        if (carId.SelectedIndex > 0)
        {
            DataTable dt = new DataTable();
            dt = ocnPlanEstudio.ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                plaId.DataValueField = "Valor";
                plaId.DataTextField = "Texto";
                plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                plaId.DataBind();
                plaId.Enabled = true;
            }
        }
    }



    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        plaIdCargar();
    }
    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError.Visible = false;
        //int usuario = Convert.ToInt32(Session["_usuId"].ToString());
        //dt = ocnUsuarioEspacioCurricular.ObtenerUno(usuario);
        //if (dt.Rows[0]["carTipoCarrera"].ToString() == "3") // Si el Tipo de carrera es igual a 3 === Secundario
        //{

        //    //escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxusuIdyCur("[Seleccionar...]", usuario, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();

        //}
    }

    private void plaIdCargar()
    {
        if (plaId.SelectedIndex > 0)
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


    protected void btnImprimirTotales(object sender, EventArgs e)
    {
        alerError.Visible = false;
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 aniocursado = 0;
            Int32 ParamInt1 = 0;
            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }
            if (Convert.ToInt32(RbtSeleccion.SelectedValue) == 1)
            {
                NomRep = "ListadoAlumnosPorCursoConTotales.rpt";

                FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&aniocursado=" + aniocursado + "&NomRep=" + NomRep);
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


    protected void btnImprimir(object sender, EventArgs e)
    {
        alerError.Visible = false;
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            String NomRep;
            Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
            Int32 aniocursado = 0;
            Int32 ParamInt1 = 0;
            if (AnioCursado.Text.Trim().ToString() != "")
            {
                aniocursado = Convert.ToInt32(AnioCursado.Text.Trim().ToString());
            }
            if (Convert.ToInt32(RbtSeleccion.SelectedValue) == 1)
            {
                NomRep = "ListadoPorCursoAnio.rpt";

                FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curid=" + curid + "&aniocursado=" + aniocursado + "&NomRep=" + NomRep);
            }
            else
            {
                if (Convert.ToInt32(RbtSeleccion.SelectedValue) == 2)
                {
                    ParamInt1 = 1;
                    NomRep = "ListadoPorCursoAnioConf.rpt";
                    FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curid=" + curid + "&aniocursado=" + aniocursado + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);
                }
                else
                {
                    ParamInt1 = 0;
                    if (insId == 121)
                    {
                        NomRep = "ListadoPorCursoAnioConfNew.rpt";
                    }
                    else
                    {
                        NomRep = "ListadoPorCursoAnioConf.rpt";

                    }
                    FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&curid=" + curid + "&aniocursado=" + aniocursado + "&ParamInt1=" + ParamInt1 + "&NomRep=" + NomRep);
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
            if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "5")) // Si es administrador o preceptora

            {
                int Id = 0;
                Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);
                int usuIdCreacion = this.Master.usuId;
                ocnRegistracionNota.EliminarporIC(Id, usuIdCreacion);
                ocnInscripcionCursado.Eliminar(Id, usuIdCreacion);

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

}