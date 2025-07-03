using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AlumnosDebitoActivacion : System.Web.UI.Page
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
                this.Master.TituloDelFormulario = " Alumnos Débitos - Activación";

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
                //dtNew.Columns.Add("adeFchBaja", typeof(String));
                Session.Add("TablaAlumnos", dtNew);
                dtAlumnosTotal = Session["TablaAlumnos"] as DataTable;
                //DataTable dt = new DataTable();
                //dt = Session["TablaAlumnos"] as DataTable;

                adeFchInicio.Text = "";

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
                        this.adeFchInicio.Text = ""; // Se asigna vacio porque es Activación, se debe colocar la nueva fecha de inicio
                        //this.adeFchBaja.Text = Convert.ToString(ocnAlumnosDebitos.adeFchBaja);
                        this.tcuId.SelectedValue = ocnAlumnosDebitos.tcuId.ToString();
                        this.BancoId.SelectedValue = ocnAlumnosDebitos.banId.ToString();
                        lblaluId.Text = Convert.ToString(ocnAlumnosDebitos.aluId);

                        dt5 = ocnAlumnosDebitos.ObtenerAlumnosxDocparaActivar(ocnAlumnosDebitos.aluId);
                        GrillaAlumnos.DataSource = dt5;
                        //Int32 ppppp = dt5.Rows.Count;
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




    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //        try
        //        {
        //            alerError1.Visible = false;

        //            Response.Redirect("AlumnosDebitoConsulta.aspx", true);
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
                    Id = 0;
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
                    ocnAlumnosDebitos.adeActivo = true;

                    //ocnAlumnosDebitos.adeActivo = true;
                    ocnAlumnosDebitos.banId = Convert.ToInt32(BancoId.SelectedValue);

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
                        lblalerError1.Text = "El alumno ya se encuentra activo para debitar..";
                        btnAceptar1.Enabled = false;
                        return;
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



}