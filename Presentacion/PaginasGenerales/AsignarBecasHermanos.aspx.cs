using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AsignarBecasHermanos : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.Usuario ocnUsuario = new GESTIONESCOLAR.Negocio.Usuario();
    GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular ocnUsuarioEspacioCurricular = new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular();
    GESTIONESCOLAR.Negocio.AlumnoFamiliar ocnAlumnoFamiliar = new GESTIONESCOLAR.Negocio.AlumnoFamiliar();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();
    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();
    GESTIONESCOLAR.Negocio.ConceptosTipos ocnConceptosTipos = new GESTIONESCOLAR.Negocio.ConceptosTipos();
    GESTIONESCOLAR.Negocio.InscripcionConcepto ocnInscripcionConcepto = new GESTIONESCOLAR.Negocio.InscripcionConcepto();
    GESTIONESCOLAR.Negocio.InscripcionCursado ocnInscripcionCursado = new GESTIONESCOLAR.Negocio.InscripcionCursado();
    GESTIONESCOLAR.Negocio.Becas ocnBecas = new GESTIONESCOLAR.Negocio.Becas();



    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    int insId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Asignar Becas x Hermanos";
                int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                dt = ocnUsuario.ObtenerUno(usuario);

                ddlPorcentaje.DataValueField = "Valor"; ddlPorcentaje.DataTextField = "Texto"; ddlPorcentaje.DataSource = (new GESTIONESCOLAR.Negocio.Becas()).ObtenerLista("[Seleccionar...]"); ddlPorcentaje.DataBind();
                ConTipoId.DataValueField = "Valor"; ConTipoId.DataTextField = "Texto"; ConTipoId.DataSource = (new GESTIONESCOLAR.Negocio.ConceptosTipos()).ObtenerLista("[Seleccionar...]"); ConTipoId.DataBind();
                txtAñioLectivo.Text = Convert.ToString(DateTime.Now.Year);
                insId = Convert.ToInt32(Session["_Institucion"]);
                btnAplicar.Visible = false;
                btnCancelar.Visible = false;
                btnSeleccionarTodo.Visible = false;
                lblBecas.Visible = false;
                rbtAgregarQuitar.Visible = false;
                lblPorcentaje.Visible = false;
                ddlPorcentaje.Visible = false;

                int PageIndex = 0;
                if (this.Session["AsignarBecasHermanos.PageIndex"] == null)
                {
                    Session.Add("AsignarBecasHermanos.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["AsignarBecasHermanos.PageIndex"]);
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


    protected void ddlCantHermanos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GrillaCargar(this.Grilla.PageIndex);
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            Session["AsignarBecasHermanos.PageIndex"] = PageIndex;

            dt = new DataTable();
            dt.Columns.Add("aluId", typeof(int));
            dt.Columns.Add("Hijo", typeof(int));
            dt.Columns.Add("aluDni", typeof(String));
            dt.Columns.Add("aluNombre", typeof(String));
            dt.Columns.Add("curId", typeof(Int32));
            dt.Columns.Add("Curso", typeof(String));

            dt1 = new DataTable();
            dt1 = ocnAlumnoFamiliar.ObtenerCantHijos(Convert.ToInt32(txtAñioLectivo.Text));//Cant de hijos por cada tutor
            dt2 = new DataTable();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    if (Convert.ToInt32(row["Hijos"].ToString()) == Convert.ToInt32(ddlCantHermanos.SelectedValue))
                    {
                        DataTable dt3 = new DataTable();
                        dt3.Columns.Add("aluId", typeof(int));
                        dt3.Columns.Add("Hijo", typeof(int));
                        dt3.Columns.Add("aluDni", typeof(String));
                        dt3.Columns.Add("aluNombre", typeof(String));
                        dt3.Columns.Add("curId", typeof(Int32));
                        dt3.Columns.Add("Curso", typeof(String));

                        int pppp = Convert.ToInt32(row["famId"].ToString());
                        if (pppp == 2307)
                        {
                            int uuu = 1;
                        }

                        dt2 = ocnAlumnoFamiliar.ObtenerHijosxfamIdxAnio((Convert.ToInt32(row["famId"].ToString())), Convert.ToInt32(txtAñioLectivo.Text));//veo cuantos tiene en el año seleccionado
                        if (dt2.Rows.Count > 0)//
                        {
                            int hijoNro = 0;
                            foreach (DataRow row2 in dt2.Rows)//Cuento hermanos del Año seleccionado
                            {
                                hijoNro = hijoNro + 1;
                            }

                            if (hijoNro == Convert.ToInt32(ddlCantHermanos.SelectedValue))// Si es = cantidad seleccionada.. cargo grilla
                            {
                                hijoNro = 0;
                                foreach (DataRow row3 in dt2.Rows)//para cada hijo muestro en grilla
                                {

                                    hijoNro = hijoNro + 1;
                                    DataRow row4 = dt.NewRow();
                                    row4["aluId"] = Convert.ToInt32(row3["aluId"].ToString());
                                    row4["Hijo"] = hijoNro;
                                    row4["aluDni"] = Convert.ToString(row3["aluDni"].ToString());
                                    row4["aluNombre"] = Convert.ToString(row3["aluNombre"].ToString());
                                    row4["curId"] = Convert.ToString(row3["curId"].ToString());
                                    row4["Curso"] = Convert.ToString(row3["Curso"].ToString());
                                    dt.Rows.Add(row4);
                                }
                            }
                        }
                    }
                }


                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();




                if (dt.Rows.Count > 0)
                {
                    lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                    btnAplicar.Visible = true;
                    btnCancelar.Visible = true;
                    btnSeleccionarTodo.Visible = true;
                    lblBecas.Visible = true;
                    rbtAgregarQuitar.Visible = true;
                    lblPorcentaje.Visible = true;
                    ddlPorcentaje.Visible = true;
                    lblMej.Text = "";
                }
                else
                {
                    lblCantidadRegistros.Text = "Cantidad de registros: 0";
                    lblMej.Text = "No exite familia con esa cantidad de hijos";
                    btnAplicar.Visible = false;
                    btnCancelar.Visible = false;
                    btnSeleccionarTodo.Visible = false;
                    lblBecas.Visible = false;
                    rbtAgregarQuitar.Visible = false;
                    lblPorcentaje.Visible = false;
                    ddlPorcentaje.Visible = false;
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

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            dt2 = new DataTable();
            dt1 = new DataTable();
            DateTime FechaHoraCreacion = DateTime.Now;
            DateTime FechaHoraUltimaModificacion = DateTime.Now;
            int usuIdCreacion = this.Master.usuId;
            int IdUltimaModificacion = this.Master.usuId;

            int BecaId = 1;
            int Bandera = 0;
            int Bandera2 = 0;

            if (Convert.ToInt32(ConTipoId.SelectedValue) != 0)
            {
                if (Convert.ToInt32(rbtAgregarQuitar.SelectedValue) == 0)//Quitar
                {
                    BecaId = 1;
                    Bandera = 0;
                }
                else
                {
                    if (Convert.ToInt32(rbtAgregarQuitar.SelectedValue) == 1)//Asignar
                    {
                        if (Convert.ToInt32(ddlPorcentaje.SelectedValue) != 1)
                        {
                            DataTable dt4 = ocnBecas.ObtenerUno(Convert.ToInt32(ddlPorcentaje.SelectedValue));
                            BecaId = Convert.ToInt32(dt4.Rows[0]["Id"].ToString());
                            Bandera = 1;
                        }
                        else
                        {
                            lblMej.Text = "Debe seleccionar un  Porcentaje de Beca";
                            ConTipoId.Focus();
                            return;
                        }
                    }
                }

                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if ((check.Checked)) // Si esta seleccionado..
                    {
                        dt2 = ocnInscripcionCursado.ObtenerTodoxInsIdxaluIdxAnioCursado(insId, Convert.ToInt32(txtAñioLectivo.Text), Convert.ToInt32(Grilla.DataKeys[row.RowIndex].Values["aluId"]));
                        dt1 = ocnInscripcionConcepto.TraerxIcuId(Convert.ToInt32(dt2.Rows[0]["Id"].ToString()));
                        if (dt2.Rows.Count > 0)
                        {
                            if (dt1.Rows.Count > 0)
                            {
                                foreach (DataRow row5 in dt1.Rows)// por cada concepto..
                                {
                                    int tipoConcepto = Convert.ToInt32(row5["cntId"].ToString());
                                    if (tipoConcepto == Convert.ToInt32(ConTipoId.SelectedValue))
                                    {
                                        int icoId = Convert.ToInt32(row5["Id"].ToString());
                                        ocnInscripcionConcepto.ActualizarBeca(icoId, BecaId, true, usuIdCreacion, IdUltimaModificacion, FechaHoraCreacion, FechaHoraUltimaModificacion);
                                        Bandera2 = 1;
                                    }
                                }
                            }
                            else
                            {
                                lblMej.Text = "Tabla Incripción Cursado Vacía";
                            }
                        }
                        else
                        {
                            lblMej.Text = "Tabla Incripción Concepto Vacía";
                        }
                    }
                }
                if (Bandera2 == 1)
                {
                    if (Bandera == 1)
                    {
                        lblMej.Text = "Se asigno Beca a los registros seleccionados..";
                    }
                    else
                    {
                        lblMej.Text = "Se quitó Beca a los registros seleccionados..";
                    }
                }
                else
                {
                    lblMej.Text = "No se actualizó Becas.. Seleccionó registros?..";
                }
            }

            else
            {
                lblMej.Text = "Debe seleccionar un Tipo de Concepto";
                ConTipoId.Focus();
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

    protected void btnSeleccionarTodo_Click(object sender, EventArgs e)
    {
        try
        {

            if (btnSeleccionarTodo.Text == "Desmarcar todo")
            {
                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == true)
                    {
                        check.Checked = false;

                    }
                }
                btnSeleccionarTodo.Text = "Seleccionar todo";
            }
            else
            {
                foreach (GridViewRow row in Grilla.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

                    if (check.Checked == false)
                    {
                        check.Checked = true;

                    }
                }
                btnSeleccionarTodo.Text = "Desmarcar todo";
            }

            //BtnGrabar.Enabled = true;
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