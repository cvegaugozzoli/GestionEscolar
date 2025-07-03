using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AlumnosDebitoRegistracion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.AlumnosDebitos ocnAlumnosDebitos = new GESTIONESCOLAR.Negocio.AlumnosDebitos();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Bancos ocnBancos = new GESTIONESCOLAR.Negocio.Bancos();

    DataTable dt = new DataTable();
    DataTable dtAlumnosTotal = new DataTable();
    int insId;
    DataTable dt5 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Alumnos Débitos - Registracion";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {

                    btnAceptar1.Visible = false;
                }
                BancoId.DataValueField = "Valor"; BancoId.DataTextField = "Texto"; BancoId.DataSource = (new GESTIONESCOLAR.Negocio.Bancos()).ObtenerLista("[Seleccionar...]"); BancoId.DataBind();

                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("adeId", typeof(int));
                dtNew.Columns.Add("aluId", typeof(int));
                dtNew.Columns.Add("aluNombre", typeof(String));
                dtNew.Columns.Add("aluDNI", typeof(String));
                dtNew.Columns.Add("adeFchBaja", typeof(String));
                Session.Add("TablaAlumnos", dtNew);
                dtAlumnosTotal = Session["TablaAlumnos"] as DataTable;
                //DataTable dt = new DataTable();
                //dt = Session["TablaAlumnos"] as DataTable;

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {

                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/

                    if (Id != 0)
                    {
                        ocnAlumnosDebitos = new GESTIONESCOLAR.Negocio.AlumnosDebitos(Id);
                        this.adeDNITitular.Text = ocnAlumnosDebitos.adeDNITitular;
                        this.adeApeNom.Text = ocnAlumnosDebitos.adeApeNom;
                        this.adeCBU.Text = ocnAlumnosDebitos.adeCBU;
                        this.adeFchProbCobro.Text = Convert.ToString(ocnAlumnosDebitos.adeFchProbCobro);
                        this.adeLugarTrabajo.Text = ocnAlumnosDebitos.adeLugarTrabajo;
                        this.adeMail.Text = ocnAlumnosDebitos.adeMail;
                        this.adeCelular.Text = ocnAlumnosDebitos.adeCelular;
                        this.adeCelular.Text = ocnAlumnosDebitos.adeCelular;
                        this.adeFchInicio.Text = Convert.ToString(ocnAlumnosDebitos.adeFchInicio);
                        //this.adeFchBaja.Text = Convert.ToString(ocnAlumnosDebitos.adeFchBaja);
                        this.tcuId.SelectedValue = ocnAlumnosDebitos.tcuId.ToString();
                        this.BancoId.SelectedValue = ocnAlumnosDebitos.banId.ToString();
                        lblaluId.Text = Convert.ToString(ocnAlumnosDebitos.aluId);

                        dt5 = ocnAlumnosDebitos.ObtenerAlumnosxDoc(ocnAlumnosDebitos.adeDNITitular);
                        GrillaAlumnos.DataSource = dt5;
                        Int32 ppppp = dt5.Rows.Count;
                        //this.GrillaAlumnos.PageIndex = PageIndex;
                        this.GrillaAlumnos.DataBind();
                        Session["TablaAlumnos"] = dt5;
                        //aluNombre.Text = Convert.ToString(dt5.Rows[0]["Nombre"]);
                        //aluNombre.Enabled = false;
                        //aludni.Text = Convert.ToString(dt5.Rows[0]["Doc"]); ;
                        //aludni.Enabled = false;
                    }
                    else
                    {
                        /*Nuevo Habilitado*/
                        /*cLoadNuevoCustom*/
                    }
                    //this.doc_doc.Focus();
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
    protected void OnCancel(object sender, EventArgs e)
    {
        alerError1.Visible = false;
        GrillaAlumnos.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["AlumnosDebitoRegistracion.PageIndex"]);
        dt5 = ocnAlumnosDebitos.ObtenerAlumnosxDoc(ocnAlumnosDebitos.adeDNITitular);
        GrillaAlumnos.DataSource = dt5;
        //this.GrillaAlumnos.PageIndex = PageIndex;
        this.GrillaAlumnos.DataBind();
        Session["TablaAlumnos"] = dt5;

    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrillaAlumnos, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }
    protected void GrillaAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            alerError1.Visible = false;

            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            lblMensajeError.Text = "";

            dt.Columns.Add("aluId", typeof(int));
            dt.Columns.Add("aluNombre", typeof(String));
            dt.Columns.Add("aludni", typeof(String));


            //dt = Session["TablaMatConf"] as DataTable;
            //if (Session["InscripcionCursadoRegistracion.PageIndex"] != null)
            //{
            //    Session["InscripcionCursadoRegistracion.PageIndex"] = e.NewPageIndex;
            //}
            //else
            //{
            //    Session.Add("InscripcionCursadoRegistracion.PageIndex", e.NewPageIndex);
            //}


            //int PageIndex = 0;
            //PageIndex = Convert.ToInt32(Session["InscripcionCursadoRegistracion.PageIndex"]);
            //GrillaMateriaConfirmar.DataSource = dt;
            //this.GrillaMateriaConfirmar.PageIndex = PageIndex;
            //this.GrillaMateriaConfirmar.DataBind();

            //GrillaMateriaConfirmar.DataSource = dtTraeEspCur;
            //this.Grilla.PageIndex = Convert.ToInt32(Session["InscripcionCursadoRegistracion.PageIndex"]);
            //GrillaMateriaConfirmar.DataBind();              

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
            alerError1.Visible = false;

            Response.Redirect("AlumnosDebitoConsulta.aspx", true);
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            alerError1.Visible = false;

            if (adeDNITitular.Text == "")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar DNI del Titular..";
                return;
            }

            if (adeApeNom.Text == "")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar Nombre del Titular..";
                return;
            }
            if (BancoId.SelectedValue == "" || BancoId.SelectedValue == "0")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar Banco Adherido..";
                return;
            }
            if (adeCBU.Text == "")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar CBU del Titular..";
                return;
            }
            //if (adeLugarTrabajo.Text == "")
            //{
            //    alerError1.Visible = true;
            //    lblalerError1.Text = "Debe ingresar Lugar de Trabajo del Titular..";
            //    return;
            //}
            if (adeMail.Text == "")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar e-mail del Titular..";
                return;
            }
            if (tcuId.SelectedValue == "" || tcuId.SelectedValue == "")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar Tipo de Cuenta del Titular..";
                return;
            }

            if (adeFchInicio.Text == "")
            {
                alerError1.Visible = true;
                lblalerError1.Text = "Debe ingresar Fecha de Inicio..";
                return;
            }
            int Id = 0;
            //insId = Convert.ToInt32(Session["_Institucion"]);

            if (GrillaAlumnos.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrillaAlumnos.Rows)
                {
                    if (Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["adeId"]) == 0)
                    {
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        ocnAlumnosDebitos = new GESTIONESCOLAR.Negocio.AlumnosDebitos(Id);
                        ocnAlumnosDebitos.adeDNITitular = adeDNITitular.Text;
                        ocnAlumnosDebitos.adeApeNom = adeApeNom.Text;
                        ocnAlumnosDebitos.adeCBU = adeCBU.Text;
                        ocnAlumnosDebitos.adeFchProbCobro = 1;
                        ocnAlumnosDebitos.adeLugarTrabajo = adeLugarTrabajo.Text;
                        ocnAlumnosDebitos.adeMail = adeMail.Text;
                        ocnAlumnosDebitos.adeCelular = adeCelular.Text;
                        ocnAlumnosDebitos.adeFchInicio = Convert.ToDateTime(this.adeFchInicio.Text);
                        ocnAlumnosDebitos.adeFchBaja = Convert.ToDateTime((adeFchBaja.Text == "" ? "01/01/0001" : adeFchBaja.Text));
                        ocnAlumnosDebitos.tcuId = Convert.ToInt32(tcuId.SelectedValue);
                        ocnAlumnosDebitos.aluId = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);

                        if (adeFchBaja.Text == "")
                        {
                            ocnAlumnosDebitos.adeActivo = true;
                        }
                        else
                        {
                            ocnAlumnosDebitos.adeActivo = false;

                        }

                        //ocnAlumnosDebitos.adeActivo = true;
                        ocnAlumnosDebitos.banId = Convert.ToInt32(BancoId.SelectedValue);


                        /*Validaciones*/
                        string MensajeValidacion = "";

                        if (MensajeValidacion.Trim().Length == 0)
                        {
                            if (Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["adeId"]) == 0)
                            {
                                dt5 = ocnAlumnosDebitos.ObtenerUnoxaluId(Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]));
                                if (dt5.Rows.Count == 0)//
                                {
                                    ocnAlumnosDebitos.adeFechaHoraCreacion = DateTime.Now;
                                    ocnAlumnosDebitos.adeFechaHoraUltimaModificacion = DateTime.Now;
                                    ocnAlumnosDebitos.usuidCreacion = this.Master.usuId;
                                    ocnAlumnosDebitos.usuidUltimaModificacion = this.Master.usuId;
                                    ocnAlumnosDebitos.Insertar();
                                }
                                else
                                {
                                    alerError1.Visible = true;
                                    lblalerError1.Text = "El alumno ya se registró para debitar..";
                                    return;
                                }
                            }
                            else
                            {

                                ocnAlumnosDebitos.adeId = Convert.ToInt32(Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["adeId"]));
                                //ocnAlumnosDebitos.adeFechaHoraCreacion = DateTime.Now;
                                ocnAlumnosDebitos.adeFechaHoraUltimaModificacion = DateTime.Now;
                                //ocnAlumnosDebitos.usuidCreacion = this.Master.usuId;
                                ocnAlumnosDebitos.usuidUltimaModificacion = this.Master.usuId;
                                ////Editar
                                ocnAlumnosDebitos.Actualizar();
                            }

                        }
                        else
                        {
                            Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                            lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
                        }
                    }
                    else
                    {

                        Id = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["adeId"]);
                        ocnAlumnosDebitos = new GESTIONESCOLAR.Negocio.AlumnosDebitos(Id);
                        ocnAlumnosDebitos.adeDNITitular = adeDNITitular.Text;
                        ocnAlumnosDebitos.adeApeNom = adeApeNom.Text;
                        ocnAlumnosDebitos.adeCBU = adeCBU.Text;
                        ocnAlumnosDebitos.adeFchProbCobro = 1;
                        ocnAlumnosDebitos.adeLugarTrabajo = adeLugarTrabajo.Text;
                        ocnAlumnosDebitos.adeMail = adeMail.Text;
                        ocnAlumnosDebitos.adeCelular = adeCelular.Text;
                        ocnAlumnosDebitos.adeFchInicio = Convert.ToDateTime(this.adeFchInicio.Text);
                        ocnAlumnosDebitos.adeFchBaja = Convert.ToDateTime((adeFchBaja.Text == "" ? "01/01/0001" : adeFchBaja.Text));
                        ocnAlumnosDebitos.tcuId = Convert.ToInt32(tcuId.SelectedValue);
                        ocnAlumnosDebitos.aluId = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["aluId"]);

                        //if (adeFchBaja.Text == "")
                        //{
                        //    ocnAlumnosDebitos.adeActivo = true;
                        //}
                        //else
                        //{
                        //    ocnAlumnosDebitos.adeActivo = false;
                        //}

                        //ocnAlumnosDebitos.adeActivo = true;
                        ocnAlumnosDebitos.banId = Convert.ToInt32(BancoId.SelectedValue);


                        /*Validaciones*/
                        string MensajeValidacion = "";

                        if (MensajeValidacion.Trim().Length == 0)
                        {
                            ocnAlumnosDebitos.adeId = Convert.ToInt32(Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["adeId"]));
                            //ocnAlumnosDebitos.adeFechaHoraCreacion = DateTime.Now;
                            ocnAlumnosDebitos.adeFechaHoraUltimaModificacion = DateTime.Now;
                            //ocnAlumnosDebitos.usuidCreacion = this.Master.usuId;
                            ocnAlumnosDebitos.usuidUltimaModificacion = this.Master.usuId;
                            ////Editar
                            ocnAlumnosDebitos.Actualizar();
                        }
                    }
                }

                Response.Redirect("AlumnosDebitoConsulta.aspx", true);

            }
            else
            {
                alerError1.Visible = true;
                lblalerError1.Text = "No seleccionó alumnos..";
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
        alerError1.Visible = false;

        //dt = new DataTable();
        //this.Grilla.DataSource = dt;
        //this.Grilla.DataBind();
        GrillaBuscarCargar(GrillaBuscar.PageIndex);
    }
    protected void GrillaBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GrillaBuscar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.background = '#CCCCFF'; this.style.cursor = 'pointer'";
                row.Attributes["onmouseout"] = "this.style.background='#ffffff'";
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GrillaBuscar, "Select$" + row.RowIndex, true);
            }
        }

        base.Render(writer);
    }


    protected void btnCancelarAlumno_Click(object sender, EventArgs e)
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

    private void GrillaBuscarCargar(int PageIndex)
    {
        try
        {
            alerError1.Visible = false;

            alerError.Visible = false;
            alerExito.Visible = false;
            canRg.Visible = false;
            Session["CuentaCorriente.PageIndex"] = PageIndex;

            dt = new DataTable();

            if (Convert.ToInt32(Session["Bandera"]) == 0)
            {
                dt = ocnAlumno.ObtenerTodoBuscarxNombre(TextBuscar.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    canRg.Visible = true;
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.GrillaBuscar.DataSource = dt;
                    this.GrillaBuscar.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();

                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra Alumno con esa descripción o DNI";
                }
            }
            else
            {
                dt = ocnAlumno.ObtenerUnoporDoc(TextBuscar.Text.Trim());
                canRg.Visible = true;
                if (dt.Rows.Count > 0)
                {
                    lblCantidadRegistros2.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    this.GrillaBuscar.DataSource = dt;
                    this.GrillaBuscar.PageIndex = PageIndex;
                    this.GrillaBuscar.DataBind();

                }
                else
                {
                    alerError.Visible = true;
                    lblError.Text = "No se encuentra Alumno con esa descripción o DNI";
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

    protected void GrillaBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
//        try
//        {
//            if (Session["CuentaCorriente.PageIndex"] != null)
//            {
//                Session["CuentaCorriente.PageIndex"] = e.NewPageIndex;
//            }
//            else
//            {
//                Session.Add("CuentaCorriente.PageIndex", e.NewPageIndex);
//            }

//            this.GrillaBuscarCargar(e.NewPageIndex);
//        }
//        catch (Exception oError)
//        {
//            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
//<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
//<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
//Se ha producido el siguiente error:<br/>
//MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
//    "</div>";
//        }
    }



    protected void GrillaBuscar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            alerError1.Visible = false;

            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                String Id = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[1]).Text;

                if (e.CommandName == "Select")
                {
                    aluNombre.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                    aluNombre.Enabled = false;
                    aludni.Text = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                    aludni.Enabled = false;
                    lblaluId.Text = Id;
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);

                    DataTable dtNew = Session["TablaAlumnos"] as DataTable;

                    DataRow row1 = dtNew.NewRow();

                    int adeId = 0;
                    if (Request.QueryString["Id"] != null)
                    {
                        adeId = Convert.ToInt32(Request.QueryString["Id"]);
                        //if (adeId == 0)
                        //{
                        row1["adeId"] = 0;
                        row1["aluId"] = Id;
                        row1["aluNombre"] = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Controls[1]).Text;
                        row1["aluDNI"] = ((HyperLink)GrillaBuscar.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Controls[1]).Text;
                        dtNew.Rows.Add(row1);

                        Session.Add("TablaAlumnos", dtNew);
                        dtAlumnosTotal = Session["TablaAlumnos"] as DataTable;
                        GrillaBuscar.DataSource = null;
                        GrillaBuscar.DataBind();

                        GrillaAlumnos.DataSource = dtAlumnosTotal;
                        GrillaAlumnos.DataBind();
                        //}
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

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            alerError1.Visible = false;

            GridViewRow row = GrillaAlumnos.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GrillaAlumnos.DataKeys[e.RowIndex].Values[0]);

            TextBox txtBaja = (TextBox)GrillaAlumnos.Rows[e.RowIndex].FindControl("txtadeFchBaja");

            String txtFchBaja = txtBaja.Text;

            DateTime adeFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdBaja = this.Master.usuId;
            ocnAlumnosDebitos.Eliminar(Id, usuIdBaja, Convert.ToDateTime(txtFchBaja));

            GrillaAlumnos.EditIndex = -1;
            dt5 = ocnAlumnosDebitos.ObtenerAlumnosxDoc(adeDNITitular.Text);
            GrillaAlumnos.DataSource = dt5;
            this.GrillaAlumnos.DataBind();
            Session["TablaAlumnos"] = dt5;
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

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        alerError1.Visible = false;

        GrillaAlumnos.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCPri.PageIndex"]);
        dt5 = ocnAlumnosDebitos.ObtenerAlumnosxDoc(adeDNITitular.Text);
        GrillaAlumnos.DataSource = dt5;
        //this.GrillaAlumnos.PageIndex = PageIndex;
        this.GrillaAlumnos.DataBind();
        Session["TablaAlumnos"] = dt5;

        //GrillaAlumnos(PageIndex);
        GrillaAlumnos.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
        GrillaAlumnos.Columns[6].Visible = true;
        GrillaAlumnos.Columns[7].Visible = true;

    }

    protected void RbtBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerError1.Visible = false;

        //alerError2.Visible = false;
        alerError.Visible = false;
        alerExito.Visible = false;
        int ban;
        if (RbtBuscar.SelectedIndex == 1) //la busqueda será por dni
        {
            ban = 1;

        }
        else
        {
            ban = 0;// la busqueda será por nombre
        }

        Session["Bandera"] = ban;
        aludni.Text = "";
        aluNombre.Text = "";
        TextBuscar.Text = "";
    }



    protected void btnEliminarAceptarIns_Click(object sender, EventArgs e)
    {
        int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;


        DataTable dt1 = Session["TablaAlumnos"] as DataTable;
        if (Convert.ToInt32(dt1.Rows[RowId]["adeId"]) == 0)//es nuevo
        {
            dt1.Rows[RowId].Delete();
            Session["TablaAlumnos"] = dt1;
            GrillaAlumnos.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["AlumnosDebitoRegistracion.PageIndex"]);

            this.GrillaAlumnos.DataSource = dt1;
            this.GrillaAlumnos.DataBind();
            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;
        }
        else
        {
            int adeId = Convert.ToInt32(dt1.Rows[RowId]["adeId"]);
            int UsuBaja = this.Master.usuId;
            DateTime FchBaja = Convert.ToDateTime(dt1.Rows[RowId]["adeFchBaja"]);

            ocnAlumnosDebitos.Eliminar(adeId, UsuBaja, FchBaja);
            GrillaAlumnos.EditIndex = -1;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["AlumnosDebitoRegistracion.PageIndex"]);

            DataTable dt7 = new DataTable();
            dt7 = ocnAlumnosDebitos.ObtenerAlumnosxDoc(adeDNITitular.Text);
            Session["TablaAlumnos"] = dt7;
            this.GrillaAlumnos.DataSource = dt7;
            //this.GrillaCheque.PageIndex = PageIndex;
            this.GrillaAlumnos.DataBind();

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            //int index = e.RowIndex;
        }
    }


    protected void btnEliminarCancelarIns_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
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

    //protected void txtAnioLectivo_TextChanged(object sender, EventArgs e)
    //{
    //    int Id;
    //    lblMjerror2.Text = "";
    //    int PageIndex = 0;
    //    if (txtAnioLectivo.Text != "")
    //    {

    //        if (lblaluId.Text == "0")
    //        {
    //            lblMjerror2.Text = "Debe buscar y seleccionar un alumno";
    //            return;

    //        }
    //        else
    //        {

    //            Id = Convert.ToInt32(lblaluId.Text);

    //            PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);
    //            //GrillaCargar(PageIndex);
    //            GrillaBuscar.DataSource = null;
    //            GrillaBuscar.DataBind();
    //        }
    //    }

    //    else
    //    {
    //        Id = Convert.ToInt32(lblaluId.Text);
    //        PageIndex = Convert.ToInt32(Session["CuentaCorriente.PageIndex"]);
    //        //GrillaCargar(PageIndex);
    //        GrillaBuscar.DataSource = null;
    //        GrillaBuscar.DataBind();
    //    }
    //}

}