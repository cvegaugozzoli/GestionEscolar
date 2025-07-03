using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Recaudacion : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.ComprobantesDetalle ocnComprobantesDetalle = new GESTIONESCOLAR.Negocio.ComprobantesDetalle();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();



    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    int insId;
    int usuario;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
                //{
                this.Master.TituloDelFormulario = "Recaudación";
            usuario = Convert.ToInt32(Session["_usuId"].ToString());
            dt = ocnUsuario.ObtenerUno(usuario);
            //lblNombreMatricula.Visible = false;
            //lblNombreCuotas.Visible = false;
            //lblNombreTotal.Visible = false;
            //lblMatricula.Visible = false;
            //lblCuotas.Visible = false;
            //lblTotal.Visible = false;
            insId = Convert.ToInt32(Session["_Institucion"]);
            lblInsId.Text = Convert.ToString(Session["_Institucion"]);
            //ddlInstitucion.DataValueField = "Valor"; ddlInstitucion.DataTextField = "Texto"; ddlInstitucion.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); ddlInstitucion.DataBind();
            //ColegioId.DataValueField = "Valor"; ColegioId.DataTextField = "Texto"; ColegioId.DataSource = (new GESTIONESCOLAR.Negocio.Instituciones()).ObtenerLista("[Seleccionar...]"); ColegioId.DataBind();

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

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {

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

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            //CanReg.Visible = false;
            insId = Convert.ToInt32(lblInsId.Text);
            dt = new DataTable();
            dt = ocnComprobantesDetalle.RecaudacionxInsxfecha(insId, Convert.ToDateTime(txtDesde.Text), Convert.ToDateTime(txtHasta.Text));

            //this.Grilla.DataSource = dt;
            //this.Grilla.PageIndex = PageIndex;
            //this.Grilla.DataBind();


            if (dt.Rows.Count > 0)
            {
                //lblNombreMatricula.Visible = true;
                //lblNombreCuotas.Visible = true;
                //lblNombreTotal.Visible = true;
                //lblMatricula.Visible = true;
                //lblCuotas.Visible = true;
                //lblTotal.Visible = true;
                Decimal sumatoriaM = 0;// Saco TOTAL
                Decimal sumatoriaC = 0;// Saco TOTAL
                Decimal sumatoriaT = 0;// Saco TOTAL


                Decimal ImporteBecado = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["ConceptosTipos"].ToString()) == 1)
                    {
                        if (Convert.ToDecimal(row["Importe"].ToString()) != 0)
                        {
                            sumatoriaM += (ImporteBecado) + (Convert.ToDecimal(row["Importe"].ToString()));

                        }
                    }
                    else
                    {

                        if (Convert.ToInt32(row["ConceptosTipos"].ToString()) == 2)
                        {
                            if (Convert.ToDecimal(row["Importe"].ToString()) != 0)
                            {
                                sumatoriaC += (ImporteBecado) + (Convert.ToDecimal(row["Importe"].ToString()));

                            }
                        }
                    }
                }
                sumatoriaT = sumatoriaM + sumatoriaC;

                //lblMatricula.Text = Convert.ToString(sumatoriaM);

                //lblCuotas.Text = Convert.ToString(sumatoriaC);

                //lblTotal.Text = Convert.ToString(sumatoriaT);


            }


            if (dt.Rows.Count > 0)
            {
                //CanReg.Visible = true;

                //lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                btnImprimir.Visible = true;
            }
            else
            {
                //    CanReg.Visible = true;
                //    lblCantidadRegistros.Text = "Cantidad de registros: 0";
                //lblNombreMatricula.Visible = false;
                //lblNombreCuotas.Visible = false;
                //lblNombreTotal.Visible = false;
                //lblMatricula.Visible = false;
                //lblCuotas.Visible = false;
                //lblTotal.Visible = false;
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



    protected void btnAplicar_Click1(object sender, EventArgs e)
    {
        try
        {
            //GrillaCargar(Grilla.PageIndex);

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
            if (Session["Recaudacion.PageIndex"] != null)
            {
                Session["Recaudacion.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("Recaudacion.PageIndex", e.NewPageIndex);
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
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep;
            if (chk_descuentos.Checked == true)
            {
                NomRep = "ListadoDescuento.rpt";
            }
            else
            {
                NomRep = "ListadoRecaudacion.rpt";
            }

            insId = Convert.ToInt32(lblInsId.Text);
            usuario = Convert.ToInt32(Session["_usuId"].ToString());
            DateTime desde = Convert.ToDateTime(txtDesde.Text);
            DateTime hasta = Convert.ToDateTime(txtHasta.Text);
            int RecauxUsu2 = 0;
            int RecauxUsu = Master.usuId;
            DataTable dtRecUsu = ocnInstituciones.ObtenerUno(insId);
            if (dtRecUsu.Rows.Count > 0)
            {
                RecauxUsu2 = Convert.ToInt32(dtRecUsu.Rows[0]["insRecaxUsuario"].ToString());
            }


            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&desde=" + desde + "&hasta=" + hasta + "&NomRep=" + NomRep);

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

    protected void btnResumen_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(lblInsId.Text);
            String NomRep;
            DateTime desde = Convert.ToDateTime(txtDesde.Text);
            DateTime hasta = Convert.ToDateTime(txtHasta.Text);
            NomRep = "ListadoRecaudacionResumen.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?insId=" + insId + "&desde=" + desde + "&hasta=" + hasta + "&NomRep=" + NomRep);

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


    protected void btnCancelar_Click1(object sender, EventArgs e)
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

    protected void chk_descuentos_CheckedChanged(object sender, EventArgs e)
    {
        //chk_descuentos.Checked = false;
        if (chk_descuentos.Checked == true)
        {
            btnResumen.Visible = false;
        }
        else
        {
    btnResumen.Visible = true;
        }


    }
}


