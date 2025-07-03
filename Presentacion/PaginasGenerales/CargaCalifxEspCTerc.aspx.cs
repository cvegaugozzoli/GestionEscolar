using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class CargaCalifxEspCTerc : System.Web.UI.Page
{
    DataTable dt = new DataTable();

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
    GESTIONESCOLAR.Negocio.Carrera ocnCarrera = new GESTIONESCOLAR.Negocio.Carrera();
    GESTIONESCOLAR.Negocio.RegistracionCalificaciones ocnRegistracionCalificaciones = new GESTIONESCOLAR.Negocio.RegistracionCalificaciones();
    GESTIONESCOLAR.Negocio.CondicionParametrosFijos ocnCondicionParametrosFijos = new GESTIONESCOLAR.Negocio.CondicionParametrosFijos();
    GESTIONESCOLAR.Negocio.CondicionParametros ocnCondicionParametros = new GESTIONESCOLAR.Negocio.CondicionParametros();
    GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario ocnInscripcionCursadoTerciario = new GESTIONESCOLAR.Negocio.InscripcionCursadoTerciario();

    int insId;


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["datos"] == null)
        {
            DefinirColumnasNotas();
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                int upeId = Convert.ToInt32(Session["_upeId"].ToString());
                //dt = ocnUsuarioEspacioCurricular.ObtenerxUsuId(usuario);

                Session["datos"] = null;
                DataBindGrid();

                this.Master.TituloDelFormulario = " Notas - Consulta / Registración";
                Session["Treg"] = 2;

                Session["Editar"] = 2;

                //if (dt.Rows.Count != 0)
                //{
                if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "9") || (Session["_perId"].ToString() == "18"))  // Si es administrador o Director veo todas las carreras
                {
                    insId = Convert.ToInt32(Session["_Institucion"]);
                    //dt = ocnTipoCarrera.ObtenerUno(Convert.ToInt32(NivelID.SelectedValue));
                    //int carIdO = 0;
                    //int plaIdO = 0;

                    int niv = 4; // Terciario
                    carId.Enabled = true;
                    DataTable dt2 = new DataTable();

                    dt2 = ocnCarrera.ObtenerUnoxNivel(niv);

                    if (dt2.Rows.Count > 0)
                    {
                        carId.DataValueField = "Valor";
                        carId.DataTextField = "Texto";
                        carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerListaxtcaId("[Seleccionar...]", niv);
                        carId.DataBind();

                    }


                    //plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                    ExamenTipoId.DataValueField = "Valor"; ExamenTipoId.DataTextField = "Texto"; ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]"); ExamenTipoId.DataBind();

                    //curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.Curso()).ObtenerListaPorUnPlanEstudio("[Seleccionar...]", Convert.ToInt32(plaId.SelectedValue)); curId.DataBind();
                }

                else
                {
                    if (Session["_perId"].ToString() == "2")// Si es Docente de Grado es Primaria
                    {
                        carId.Enabled = true;
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Terciario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Primario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();

                    }

                    if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11"))  // Si es Prof Hs Catedra es Secundaria
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    if (Session["_perId"].ToString() == "5") // Preceptora
                    {
                        carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                        carId.SelectedIndex = carId.Items.IndexOf(carId.Items.FindByText("Secundario"));
                        carId.Enabled = false;

                        plaId.DataValueField = "Valor"; plaId.DataTextField = "Texto"; plaId.DataSource = (new GESTIONESCOLAR.Negocio.PlanEstudio()).ObtenerListaPorUnaCarrera("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue));
                        plaId.DataBind(); plaId.SelectedIndex = plaId.Items.IndexOf(plaId.Items.FindByText("Plan Secundario")); plaId.Enabled = false;

                        curId.DataValueField = "Valor"; curId.DataTextField = "Texto"; curId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaCursoxupeId("[Seleccionar...]", upeId, Convert.ToInt32(carId.SelectedValue)); curId.DataBind();
                    }
                    //if (Session["_perId"].ToString() == "11")   // Si es Docente Area Especia
                    //{
                    //    carId.Enabled = true;
                    //    carId.DataValueField = "Valor"; carId.DataTextField = "Texto"; carId.DataSource = (new GESTIONESCOLAR.Negocio.Carrera()).ObtenerLista("[Seleccionar...]"); carId.DataBind();
                    //    //EspCurBuscarId.DataValueField = "Id"; EspCurBuscarId.DataTextField = "Nombre"; EspCurBuscarId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso(Id); EspCurBuscarId.DataBind();
                    //}

                    //}
                }

                #region PageIndex
                int PageIndex = 0;

                if (this.Session["CargaCalifxEspCTerc.PageIndex"] == null)
                {
                    Session.Add("CargaCalifxEspCTerc.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros

                #endregion
            }
            else
            {
                if (Convert.ToString(Session["Editar"]) == "1")
                {
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
                    Session["Editar"] = 1;
                    GrillaCargar(PageIndex);
                }
                else
                {
                    GridView1.Columns.Clear();
                    DataBindGrid();
                }

                if (Convert.ToString(Session["Treg"]) == "1")
                {
                    int PageIndex = 0;
                    PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
                    Session["Treg"] = 1;
                    GrillaCargar(PageIndex);
                }
                else
                {
                    if (Convert.ToString(Session["Treg"]) == "2")
                    { }
                    else
                    {
                        GridView1.Columns.Clear();
                        DataBindGrid();
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

    protected void carId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        insId = Convert.ToInt32(Session["_Institucion"]);
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

    protected void plaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (plaId.SelectedIndex != 0)
        {
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

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GridView1.Rows)
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
        string ArchivoNombre = "CargaCalifxEspCTerc" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".xls";
        FuncionesUtiles.ExportarAExcel(dt, ArchivoNombre, this);
    }

    public class GridViewHeaderTemplate : ITemplate
    {
        string text;

        public GridViewHeaderTemplate(string text)
        {
            this.text = text;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Literal lc = new Literal();
            lc.Text = text;

            container.Controls.Add(lc);

        }
    }

    public class GridViewEditTemplate : ITemplate
    {
        private string columnName;

        public GridViewEditTemplate(string columnName)
        {
            this.columnName = columnName;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            TextBox tb = new TextBox();
            tb.ID = string.Format("txt{0}", columnName);
            tb.EnableViewState = false;
            tb.DataBinding += new EventHandler(tb_DataBinding);

            container.Controls.Add(tb);
        }

        void tb_DataBinding(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            GridViewRow row = (GridViewRow)t.NamingContainer;

            string RawValue = DataBinder.Eval(row.DataItem, columnName).ToString();

            t.Text = RawValue;
        }
    }

    public class GridViewItemTemplate : ITemplate
    {
        private string columnName;

        public GridViewItemTemplate(string columnName)
        {
            this.columnName = columnName;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Literal lc = new Literal();

            lc.DataBinding += new EventHandler(lc_DataBinding);

            container.Controls.Add(lc);

        }

        void lc_DataBinding(object sender, EventArgs e)
        {
            Literal l = (Literal)sender;

            GridViewRow row = (GridViewRow)l.NamingContainer;

            string RawValue = DataBinder.Eval(row.DataItem, columnName).ToString();

            l.Text = RawValue;
        }
    }


    public class GridViewItemCheckTemplate : ITemplate
    {
        private string columnName;

        public GridViewItemCheckTemplate(string columnName)
        {
            this.columnName = columnName;
        }

        public bool CanEdit { get; set; }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            CheckBox check = new CheckBox();
            check.ID = string.Format("chk{0}", columnName);
            check.Enabled = true;
            check.DataBinding += new EventHandler(check_DataBinding);
            //check.AutoPostBack = true;
            container.Controls.Add(check);

        }

        void check_DataBinding(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            GridViewRow row = (GridViewRow)check.NamingContainer;

            string value = "false";

            //value = "false";


            //value = DataBinder.Eval(row.DataItem, columnName).ToString();

            check.Checked = bool.Parse(value);

        }
    }

    private void DataBindGrid()
    {
        GridView1.DataSource = Session["datos"];
        GridView1.DataBind();
    }




    private void DefinirColumnasNotas()
    {
        Int32 espc = 0;

        if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
        {
            espc = Convert.ToInt32(escId.SelectedValue.ToString());
        }

        GridView1.DataKeyNames = new string[] { "ictId", "Alumno" };

        GridView1.Columns.Clear();

        //TemplateField tempchk = new TemplateField();
        //tempchk.HeaderTemplate = new GridViewHeaderTemplate("check");
        //tempchk.ItemStyle.Width = 50;
        //GridViewItemCheckTemplate check = new GridViewItemCheckTemplate("check");
        //tempchk.ItemTemplate = check;
        //GridViewItemCheckTemplate checkEdit = new GridViewItemCheckTemplate("check");
        //checkEdit.CanEdit = true;
        //tempchk.EditItemTemplate = checkEdit;

        //GridView1.Columns.Add(tempchk);

        TemplateField tempId = new TemplateField();
        tempId.HeaderTemplate = new GridViewHeaderTemplate("ictId");
        tempId.ItemTemplate = new GridViewItemTemplate("ictId");
        tempId.Visible = false;
        //tempDesc.EditItemTemplate = new GridViewEditTemplate("Id");
        GridView1.Columns.Add(tempId);


        TemplateField tempAlumno = new TemplateField();
        tempAlumno.HeaderTemplate = new GridViewHeaderTemplate("Alumno");
        tempAlumno.ItemTemplate = new GridViewItemTemplate("Alumno");
        tempAlumno.ItemStyle.Width = 150;
        //tempPrecio.EditItemTemplate = new GridViewEditTemplate("Alumno");
        GridView1.Columns.Add(tempAlumno);

        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        dt5 = ocnEspacioCurricular.ObtenerUno(espc, insId);

        if (dt5.Rows.Count > 0)
        {
            dt6 = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]), Convert.ToInt32(DateTime.Now.Year));
        }
        else
        {

        }

        if (dt6.Rows.Count > 0)
        {
            if (ExamenTipoId.SelectedValue == "1")
            {
                if (Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {
                        TemplateField tempParcial = new TemplateField();
                        tempParcial.HeaderTemplate = new GridViewHeaderTemplate("Parcial" + ' ' + Convert.ToString(i));
                        tempParcial.ItemTemplate = new GridViewItemTemplate("Parcial" + ' ' + Convert.ToString(i));
                        tempParcial.EditItemTemplate = new GridViewEditTemplate("Parcial" + ' ' + Convert.ToString(i));
                        tempParcial.ItemStyle.Width = 90;
                        GridView1.Columns.Add(tempParcial);

                        //TipoReg.DataValueField = "Valor"; TipoReg.DataTextField = "Texto";
                    }
                }
            }
            else
            {
                if (ExamenTipoId.SelectedValue == "2")
                {

                    if (Convert.ToInt32(dt6.Rows[0]["CantidadTP"]) >= 0)
                    {
                        for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                        {

                            TemplateField tempTP = new TemplateField();
                            tempTP.HeaderTemplate = new GridViewHeaderTemplate("Trab Prac" + ' ' + Convert.ToString(i));
                            tempTP.ItemTemplate = new GridViewItemTemplate("Trab Prac" + ' ' + Convert.ToString(i));
                            tempTP.ItemStyle.Width = 90;
                            tempTP.EditItemTemplate = new GridViewEditTemplate("Trab Prac" + ' ' + Convert.ToString(i));
                            GridView1.Columns.Add(tempTP);
                        }
                    }
                }
                else
                {
                    if (ExamenTipoId.SelectedValue == "3")
                    {

                        if (Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatorios"]) >= 0)
                        {
                            for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatorios"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                            {
                                TemplateField tempRP = new TemplateField();
                                tempRP.HeaderTemplate = new GridViewHeaderTemplate("Rec Parc" + ' ' + Convert.ToString(i));
                                tempRP.ItemTemplate = new GridViewItemTemplate("Rec Parc" + ' ' + Convert.ToString(i));
                                tempRP.EditItemTemplate = new GridViewEditTemplate("Rec Parc" + ' ' + Convert.ToString(i));
                                tempRP.ItemStyle.Width = 90;
                                GridView1.Columns.Add(tempRP);
                            }
                        }
                    }
                    else
                    {
                        if (ExamenTipoId.SelectedValue == "4")
                        {
                            if (Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatoriosTP"]) >= 0)
                            {
                                for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatoriosTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                {
                                    TemplateField tempRTP = new TemplateField();
                                    tempRTP.HeaderTemplate = new GridViewHeaderTemplate("Rec TP" + ' ' + Convert.ToString(i));
                                    tempRTP.ItemTemplate = new GridViewItemTemplate("Rec TP" + ' ' + Convert.ToString(i));
                                    tempRTP.EditItemTemplate = new GridViewEditTemplate("Rec TP" + ' ' + Convert.ToString(i));
                                    tempRTP.ItemStyle.Width = 90;
                                    GridView1.Columns.Add(tempRTP);

                                }
                            }
                        }
                        else
                        {

                            if (ExamenTipoId.SelectedValue == "7")
                            {
                                if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) >= 0)
                                {
                                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                                    {

                                        TemplateField tempRTP = new TemplateField();
                                        tempRTP.HeaderTemplate = new GridViewHeaderTemplate("Rec Asistencia" + ' ' + Convert.ToString(i));
                                        tempRTP.ItemTemplate = new GridViewItemTemplate("Rec Asistencia" + ' ' + Convert.ToString(i));
                                        tempRTP.EditItemTemplate = new GridViewEditTemplate("Rec Asistencia" + ' ' + Convert.ToString(i));
                                        tempRTP.ItemStyle.Width = 90;
                                        GridView1.Columns.Add(tempRTP);

                                    }
                                }

                            }
                        }
                    }
                }
            }
            TemplateField tempCondicion = new TemplateField();
            tempCondicion.HeaderTemplate = new GridViewHeaderTemplate("Condicion");
            tempCondicion.ItemTemplate = new GridViewItemTemplate("Condicion");
            tempCondicion.ItemStyle.Width = 150;
            //tempPrecio.EditItemTemplate = new GridViewEditTemplate("Alumno");
            GridView1.Columns.Add(tempCondicion);

            TemplateField tempAsistencia = new TemplateField();
            tempAsistencia.HeaderTemplate = new GridViewHeaderTemplate("Asistencia");
            tempAsistencia.ItemTemplate = new GridViewItemTemplate("Asistencia");
            //tempAsistencia.EditItemTemplate = new GridViewEditTemplate("Asistencia");
            tempAsistencia.ItemStyle.Width = 90;
            GridView1.Columns.Add(tempAsistencia);

            if (Convert.ToString(Session["Editar"]) == "1")
            {
                CommandField tempEditar = new CommandField();
                tempEditar.ShowEditButton = true;
                tempEditar.ShowCancelButton = true;
                GridView1.Columns.Add(tempEditar);
            }
            else
            {
                CommandField tempEditar = new CommandField();
                tempEditar.ShowEditButton = true;
                tempEditar.ShowCancelButton = false;
                GridView1.Columns.Add(tempEditar);

            }
        }
    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {
            insId = Convert.ToInt32(Session["_Institucion"]);
            Int32 espc = 0;
            Int32 car = 0;
            if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
            {
                car = Convert.ToInt32(carId.SelectedValue.ToString());
            }
            Int32 pla = 0;
            if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
            {
                pla = Convert.ToInt32(plaId.SelectedValue.ToString());
            }

            if (curId.SelectedValue.ToString() != "" & curId.SelectedValue.ToString() != "0")
            {
                cur = Convert.ToInt32(curId.SelectedValue.ToString());
            }

            if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
            {
                espc = Convert.ToInt32(escId.SelectedValue.ToString());
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
            dt = ocnRegistracionCalificaciones.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur, Convert.ToInt32(ExamenTipoId.SelectedValue));

            if (dt.Rows.Count > 0)
            {

                insId = Convert.ToInt32(Session["_Institucion"]);
                DataTable dt5 = new DataTable();
                dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);

                if (dt5.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 7)
                    {
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                        BtnTaller.Visible = true;
                    }
                    else
                    {
                        if (ChkVerTodo.Checked == true)
                        {

                            dt = new DataTable();
                            dt = ocnRegistracionCalificaciones.ObtenerTodoporEspCurricularAnioTodo(espc, cur, AnioCur, 0);
                            dvGrid.Visible = false;
                            Div2.Visible = true;
                            GridView3.DataSource =dt;
                            GridView3.DataBind();
                        }
                        else
                        {
                            dvGrid.Visible = true;
                            Div2.Visible = false;
                            DefinirColumnasNotas();
                            Session["datos"] = dt;
                            DataBindGrid();
                            BtnTaller.Visible = false;
                        }

                    }


                    if (dt.Rows.Count > 0)
                    {
                        //if (Convert.ToString(Session["Treg"]) == "2")
                        //{
                        //    TipoReg.DataValueField = "Valor";
                        //    TipoReg.DataTextField = "Texto";
                        //    TipoReg.DataSource = (new GESTIONESCOLAR.Negocio.RegistracionCalificaciones()).ObtenerTRegxictId("[Seleccionar...]", Convert.ToInt32(ExamenTipoId.SelectedValue), Convert.ToInt32(dt.Rows[0]["Id"])); TipoReg.DataBind();
                        //    TipoReg.Visible = true;
                        //    lblPeriodo.Visible = true;
                        //    lblNota.Visible = true;
                        //    LblRegistro.Visible = true;
                        //    TextNotaAsignar.Visible = true;
                        //    ButtonAsignar.Visible = true;
                        //    //ButtonImprimir.Visible = true;
                        //}
                        //else
                        //{
                        //    //TipoReg.DataBind();
                        //}
                    }
                    else
                    {
                        //TipoReg.DataSource = (new GESTIONESCOLAR.Negocio.RegistracionCalificaciones()).ObtenerTRegxictId("[Seleccionar...]", Convert.ToInt32(ExamenTipoId.SelectedValue), Convert.ToInt32(dt.Rows[0]["Id"])); TipoReg.DataBind();
                        //TipoReg.Visible = false;
                        //lblPeriodo.Visible = false;
                        //lblNota.Visible = false;
                        //LblRegistro.Visible = false;
                        //TextNotaAsignar.Visible = false;
                        //ButtonAsignar.Visible = false;
                        //ButtonImprimir.Visible = false;
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

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView1.EditIndex = e.NewEditIndex;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        Session["Editar"] = 1;
        GrillaCargar(PageIndex);


        //CommandField tempEditar = new CommandField();
        //tempEditar.ShowEditButton = false;
        //tempEditar.ShowCancelButton = true;
        //GridView1.Columns.Add(tempEditar);
        GridView1.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
        //GridView1.EditIndex = e.NewEditIndex;
        //DataBindGrid();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        DataBindGrid();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        alerError.Visible = false;
        int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        GridViewRow row = GridView1.Rows[e.RowIndex];
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
        Int32 usuIdUltimaModificacion = this.Master.usuId;
        dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
        if (dt5.Rows.Count > 0)
        {
            dt6 = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]), Convert.ToInt32(DateTime.Now.Year));
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "No existe ese espacio curricular";
        }


        if (dt6.Rows.Count > 0)
        {
           
            if (ExamenTipoId.SelectedValue == "1")// Parciales
            {
                if (Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {
                        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt" + "Parcial" + ' ' + Convert.ToString(i));
                        String Nota = p.Text;
                        int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(Id, "Parcial" + ' ' + Convert.ToString(i));
                        ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                    }
                }
            }
            if (ExamenTipoId.SelectedValue == "2")// TP
            {

                if (Convert.ToInt32(dt6.Rows[0]["CantidadTP"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {
                        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt" + "Trab Prac" + ' ' + Convert.ToString(i));
                        String Nota = p.Text;
                        int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(Id, "Trab Prac" + ' ' + Convert.ToString(i));
                        ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
                    }
                }
            }

            if (ExamenTipoId.SelectedValue == "3") //rec parciales
            {

                if (Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatorios"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatorios"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {
                        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt" + "Rec Parc" + ' ' + Convert.ToString(i));
                        String Nota = p.Text;
                        int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(Id, "Rec Parc" + ' ' + Convert.ToString(i));
                        ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);

                    }
                }
            }

            if (ExamenTipoId.SelectedValue == "4") //REC TP
            {
                if (Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatoriosTP"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatoriosTP"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {

                        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt" + "Rec TP" + ' ' + Convert.ToString(i));
                        String Nota = p.Text;
                        int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(Id, "Rec TP" + ' ' + Convert.ToString(i));
                        ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);

                    }
                }
            }

            if (ExamenTipoId.SelectedValue == "7") // REC ASISTENCIA
            {
                if (Convert.ToInt32(dt6.Rows[0]["cpfRecAsistencia"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfRecAsistencia"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {

                        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt" + "Rec Asistencia" + ' ' + Convert.ToString(i));
                        String Nota = p.Text;
                        int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(Id, "Rec Asistencia" + ' ' + Convert.ToString(i));
                        ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);

                    }
                }
            }

            if (ExamenTipoId.SelectedValue == "8") // INTEGRAL
            {
                if (Convert.ToInt32(dt6.Rows[0]["cpfCantIntegral"]) >= 0)
                {
                    for (int i = 1; i <= Convert.ToInt32(dt6.Rows[0]["cpfCantIntegral"]); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia)  
                    {

                        TextBox p = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt" + "Integral" + ' ' + Convert.ToString(i));
                        String Nota = p.Text;
                        int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(Id, "Integral" + ' ' + Convert.ToString(i));
                        ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);

                    }
                }
            }
        }
        else
        {
            alerError.Visible = true;
            lblError.Text = "No existe parámetros para ese espacio Curricular";
        }

        //dt6 = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));


        dt = ocnRegistracionCalificaciones.controlarCondicion(Id); //traigo todas las notas de ese espacio para ese alumno
        int cantPractAprob = 0;
        int cantRecAsistencia = 0;
        int cantTPProm = 0; int cantRecAsisReg = 0;
        Int32 cantTPReg = 0;
        int cantTotalTP = 0; int cantTotalRTP = 0;
        int cantTotalParc = 0;
        int cantParProm = 0;
        int cantParReg = 0;
        int cantParDesap = 0;
        int Integral = 0;
        int Asistencia = 0;
        int cantRecParc = 0;
        int RecParReg = 0;
        int CantIntegral = 0;
        int cantParcRen = 0; // cant Parcial Rendidos A O D
        int cantTPRen = 0; // cant TP Rendidos A O D
        int cantRPRen = 0; // cant RP Rendidos A O D
        int cantRTPRen = 0; // cant RTP Rendidos A O D
        int cantIRen = 0; // cant INTEGRAL Rendidos A O D
        int cantRecAsisRen = 0; // cant Rec Asistencia Rendidos A O D


        int AsistenciaReg = 0;
        int AsistenciaProm = 0;
        int AsistenciaRecReg = 0;
        int AsistenciaRecProm = 0;
        int espc = 0;
        int NotaReg = 0;
        int NotaProm = 0;
        int TPAprobadosPorcReg = 0;
        int TPAprobadosPorcProm = 0;
        DateTime RenFechaHoraCreacion = DateTime.Now;
  
        Int32 usuIdCreacion = this.Master.usuId;
      
        dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
        DataTable dtParamCondRegProm = new DataTable();

        if (dt5.Rows.Count > 0)
        {
            dtParamCondRegProm = ocnCondicionParametros.ObtenerunoxFD(Convert.ToInt32(dt5.Rows[0]["fodId"]), AnioCur);
            //dtPARAMFIJO = ocnCondicionParametrosFijos.ObtenerunoxFDxRegimen(Convert.ToInt32(dt5.Rows[0]["fodId"]), Convert.ToInt32(dt5.Rows[0]["regId"]));
        }

        if (dtParamCondRegProm.Rows.Count > 0)
        {
            AsistenciaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistencia"]);
            AsistenciaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmAsistencia"]);
            AsistenciaRecReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmAsistenciaRec"]);
            AsistenciaRecProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmAsistenciaRec"]);
            NotaReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmNota"]);
            NotaProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmNota"]);
            TPAprobadosPorcReg = Convert.ToInt32(dtParamCondRegProm.Rows[0]["cpmPracticasAprob"]);
            TPAprobadosPorcProm = Convert.ToInt32(dtParamCondRegProm.Rows[1]["cpmPracticasAprob"]);

            if (Convert.ToInt32(dt.Rows.Count) >= 0) // Controlo cuantos parciales van aprobados y cant total
            {
                for (int i = 0; i < Convert.ToInt32(dt.Rows.Count); i++) //Para cada Tipo de Registro.. (Parcial, Recuperatorio,Asistencia, etc)  
                {
                    if (Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]) > 0) // HAY PARCIALES??  SI
                    {
                        cantTotalParc = Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]);

                        if (Convert.ToInt32(dt.Rows[i]["treId"]) == 1) // Parciales 
                        {
                            if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaProm)
                                {
                                    cantParProm = cantParProm + 1;
                                    cantParcRen = cantParcRen + 1;
                                    cantParReg = cantParReg + 1;
                                }
                                else
                                {
                                    if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaReg)
                                    {
                                        cantParReg = cantParReg + 1;
                                        cantParcRen = cantParcRen + 1;
                                    }
                                    else
                                    {
                                        cantParDesap = cantParDesap + 1;
                                        cantParcRen = cantParcRen + 1;
                                    }
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(dt6.Rows[0]["CantidadTP"]) > 0) // HAY TP??  SI
                    {
                        cantTotalTP = Convert.ToInt32(dt6.Rows[0]["CantidadTP"]);
                        if (Convert.ToInt32(dt.Rows[i]["treId"]) == 2) // Trabajos Practicos
                        {
                            if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaProm || Convert.ToInt32(dt.Rows[i]["recNota"]) == 'A')
                                {
                                    cantTPRen = cantTPRen + 1;
                                    cantTPProm = cantTPProm + 1;
                                    cantTPReg = cantTPReg + 1;
                                }
                                else
                                {
                                    if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaReg)
                                    {
                                        cantTPRen = cantTPRen + 1;
                                        cantTPReg = cantTPReg + 1;
                                    }
                                    else
                                    {
                                        cantTPRen = cantTPRen + 1;
                                    }
                                }
                            }
                        }
                    }

                    if (Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatorios"]) > 0) // HAY recuperatorios??  SI
                    {
                        cantRecParc = Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatorios"]);
                        if (Convert.ToInt32(dt.Rows[i]["treId"]) == 3)// RP
                        {
                            if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaReg)
                                {
                                    RecParReg = RecParReg + 1;
                                    cantRPRen = cantRPRen + 1;
                                }
                                else
                                {
                                    cantRPRen = cantRPRen + 1;
                                }
                            }
                        }
                    }

                    if (Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatoriosTP"]) > 0) // HAY recuperatorios TP??  SI
                    {
                        cantTotalRTP = Convert.ToInt32(dt6.Rows[0]["CantidadRecuperatoriosTP"]);
                        if (Convert.ToInt32(dt.Rows[i]["treId"]) == 4)// R TP
                        {
                            if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaReg)
                                {
                                    cantRTPRen = cantRTPRen + 1;
                                    RecParReg = RecParReg + 1;
                                }
                                else
                                {
                                    cantRTPRen = cantRTPRen + 1;
                                }
                            }
                        }
                    }


                    if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY recuperatorios Rec Asistencia??  SI
                    {
                        cantRecAsistencia = Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]);
                        if (Convert.ToInt32(dt.Rows[i]["treId"]) == 7)// R asist
                        {
                            if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaReg)
                                {
                                    cantRecAsisReg = cantRecAsisReg + 1;
                                    cantRecAsisRen = cantRecAsisRen + 1;
                                }
                                else
                                {
                                    cantRecAsisRen = cantRecAsisRen + 1;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(dt6.Rows[0]["cpfCantIntegral"]) > 0) // HAY Integral??  SI
                    {
                        CantIntegral = Convert.ToInt32(dt6.Rows[0]["cpfCantIntegral"]);

                        if (Convert.ToInt32(dt.Rows[i]["treId"]) == 8) // INTEGRAL
                        {
                            if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= NotaReg)
                                {
                                    Integral = Integral + 1;
                                    cantIRen = cantIRen + 1;
                                }
                                else
                                {
                                    cantIRen = cantIRen + 1;
                                }
                            }
                        }
                    }

                    if (Convert.ToInt32(dt.Rows[i]["treId"]) == 5) // ASISTENCIA
                    {
                        if (Convert.ToString(dt.Rows[i]["recNota"]) != "")
                        {
                            if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= AsistenciaProm)
                            {
                                Asistencia = 1;
                            }
                            else
                            {
                                if (Convert.ToInt32(dt.Rows[i]["recNota"]) >= AsistenciaReg)
                                {
                                    Asistencia = 2;
                                }
                                else
                                {
                                    if (Convert.ToInt32(dt.Rows[i]["recNota"]) <= AsistenciaRecReg)
                                    {
                                        Asistencia = 3;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Decimal PorcPractAprob = (cantTPReg) * 100 / cantTotalTP;

            if (Convert.ToInt32(dt6.Rows[0]["CantidadParciales"]) > 0) // HAY PARCIALES??  SI
            {
                if ((cantParcRen == cantTotalParc)) // RINDIO TODOS PACIALES
                {
                    if (Convert.ToInt32(dt6.Rows[0]["CantidadTP"]) > 0) // HAY TP??  SI
                    {
                        if ((cantTPRen == cantTotalTP)) // RINDIO TODOS LOS TP
                        {
                            if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                            {
                                if ((cantParProm == cantTotalParc)) // PROMOCIONA PARCIALES 
                                {
                                    if ((Asistencia == 1)) // ASISTENCIA PROMO
                                    {
                                        ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,2, DateTime.Now, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                    }
                                    else
                                    {
                                        if ((Asistencia == 2)) // ASISTENCIA REG
                                        {
                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                            {
                                                if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                {
                                                    if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                    {
                                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                    }
                                                    else
                                                    {
                                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);
                                                    }
                                                }
                                                else
                                                {
                                                    //TODAVIA NO RINDIO
                                                }
                                            }
                                        }
                                    }
                                }
                                else // 
                                {
                                    if ((cantParReg == cantTotalParc)) // REGULAR PARCIALES 
                                    {
                                        if ((Asistencia == 1)) // ASISTENCIA PROMO
                                        {
                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);
                                        }
                                        else
                                        {
                                            if ((Asistencia == 2)) // ASISTENCIA REG
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                                {
                                                    if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                    {
                                                        if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                        else
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //TODAVIA NO RINDIO
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else // HAY PARCIALES DESAPROBADOS
                                    {
                                        if ((cantParDesap == cantRPRen)) // coincide numero de parc desap con los que se presento a recuperar
                                        {
                                            if ((RecParReg == cantParDesap)) //aprobo los recuperatorios
                                            {
                                                if ((Asistencia == 1)) // ASISTENCIA PROMO
                                                {
                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                }
                                                else
                                                {
                                                    if ((Asistencia == 2)) // ASISTENCIA REG
                                                    {
                                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                                        {
                                                            if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                            {
                                                                if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                                {
                                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                                }
                                                                else
                                                                {
                                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                                }
                                                            }
                                                            else
                                                            {
                                                                //TODAVIA NO RINDIO
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else // ver si hay integral
                                            {
                                                if (CantIntegral > 0)
                                                {
                                                    if ((Integral == CantIntegral)) //aprobo los integrales
                                                    {
                                                        if ((Asistencia == 1)) // ASISTENCIA PROMO
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                        else
                                                        {
                                                            if ((Asistencia == 2)) // ASISTENCIA REG
                                                            {
                                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                                                {
                                                                    if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                                    {
                                                                        if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                                        {
                                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                                        }
                                                                        else
                                                                        {
                                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //TODAVIA NO RINDIO
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                }
                                            }
                                        }
                                        else
                                        {
                                            // falta rendir recup parcial
                                        }
                                    }
                                }
                            }
                            else // NOTAS DE PARCIALES PARA REGULAR
                            {
                                if ((cantParReg == cantTotalParc)) // REGULAR PARCIALES 
                                {
                                    if ((Asistencia == 1)) // ASISTENCIA PROMO
                                    {
                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                    }
                                    else
                                    {
                                        if ((Asistencia == 2)) // ASISTENCIA REG
                                        {
                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                            {
                                                if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                {
                                                    if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                    {
                                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                    }
                                                    else
                                                    {
                                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                    }
                                                }
                                                else
                                                {
                                                    //TODAVIA NO RINDIO
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if ((RecParReg == cantRecParc)) // APROBO RP
                                    {
                                        if ((Asistencia == 1)) // ASISTENCIA PROMO
                                        {
                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                        }
                                        else
                                        {
                                            if ((Asistencia == 2)) // ASISTENCIA REG
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                                {
                                                    if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                    {
                                                        if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                        else
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //TODAVIA NO RINDIO
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
                            // NO RINDIO TODOS LOS TP
                        }
                    }
                    else // NO HAY TP
                    {
                        if ((cantParProm == cantTotalParc)) // PROMOCIONA PARCIALES 
                        {
                            if ((Asistencia == 1)) // ASISTENCIA PROMO
                            {
                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 2, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                            }
                            else
                            {
                                if ((Asistencia == 2)) // ASISTENCIA REG
                                {
                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                }
                                else
                                {
                                    if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                    {
                                        if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                        {
                                            if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                            else
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                        }
                                        else
                                        {
                                            //TODAVIA NO RINDIO
                                        }
                                    }
                                }
                            }
                        }
                        else // 
                        {
                            if ((cantParReg == cantTotalParc)) // REGULAR PARCIALES 
                            {
                                if ((Asistencia == 1)) // ASISTENCIA PROMO
                                {
                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                }
                                else
                                {
                                    if ((Asistencia == 2)) // ASISTENCIA REG
                                    {
                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                        {
                                            if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                            {
                                                if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                {
                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                }
                                                else
                                                {
                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                }
                                            }
                                            else
                                            {
                                                //TODAVIA NO RINDIO
                                            }
                                        }
                                    }
                                }
                            }
                            else // HAY PARCIALES DESAPROBADOS
                            {
                                if ((cantParDesap == cantRPRen)) // coincide numero de parc desap con los que se presento a recuperar
                                {
                                    if ((RecParReg == cantParDesap)) //aprobo los recuperatorios
                                    {
                                        if ((Asistencia == 1)) // ASISTENCIA PROMO
                                        {
                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                        }
                                        else
                                        {
                                            if ((Asistencia == 2)) // ASISTENCIA REG
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                                {
                                                    if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                    {
                                                        if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                        else
                                                        {
                                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //TODAVIA NO RINDIO
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else // ver si hay integral
                                    {
                                        if (CantIntegral > 0)
                                        {
                                            if ((Integral == CantIntegral)) //aprobo los integrales
                                            {
                                                if ((Asistencia == 1)) // ASISTENCIA PROMO
                                                {
                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                }
                                                else
                                                {
                                                    if ((Asistencia == 2)) // ASISTENCIA REG
                                                    {
                                                        //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                                        {
                                                            if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                                            {
                                                                if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                                                {
                                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                                }
                                                                else
                                                                {
                                                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                                                }
                                                            }
                                                            else
                                                            {
                                                                //TODAVIA NO RINDIO
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                        }
                                    }
                                }
                                else
                                {
                                    // falta rendir recup parcial
                                }
                            }
                        }
                    }
                }
                else
                {
                    // NO RINDIO TODOS LOS PARCIALES
                }
            }
            else // NO HAY PARCIALES
            {
                if (Convert.ToInt32(dt6.Rows[0]["CantidadTP"]) > 0) // HAY TP??  SI
                {
                    if ((cantTPRen == cantTotalTP)) // RINDIO TODOS LOS TP
                    {
                        if ((PorcPractAprob >= TPAprobadosPorcProm)) //PRACTICOS APROBADOS >= %PROMOCION 
                        {

                            if ((Asistencia == 1)) // ASISTENCIA PROMO
                            {
                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 2, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                            }
                            else
                            {
                                if ((Asistencia == 2)) // ASISTENCIA REG
                                {
                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                }
                                else
                                {
                                    if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                    {
                                        if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                        {
                                            if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                            else
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id,9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                        }
                                        else
                                        {
                                            //TODAVIA NO RINDIO
                                        }
                                    }
                                }
                            }
                        }
                        else // TP MENOR A PORCENTAJE PROM 
                        {
                            if ((Asistencia == 1)) // ASISTENCIA PROMO
                            {
                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                            }
                            else
                            {
                                if ((Asistencia == 2)) // ASISTENCIA REG
                                {
                                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                }
                                else
                                {
                                    if (Convert.ToInt32(dt6.Rows[0]["cantRecAsistencia"]) > 0) // HAY RecAsistencia??  SI
                                    {
                                        if ((cantRecAsisRen == cantRecAsistencia)) // RINDIO TODOS LOS RecAsistencia
                                        {
                                            if ((cantRecAsisReg == cantRecAsistencia)) // RecAsistencia APROBO
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 1, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                            else
                                            {
                                                //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);

                                            }
                                        }
                                        else
                                        {
                                            //TODAVIA NO RINDIO
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // NO HAY RINDIO TODOS LOS RTP
                    }
                }
            }
        }
        Session["Editar"] = 1;
        GridView1.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        GrillaCargar(PageIndex);
    }


    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                //string IC = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (AnioCursado.Text == "")
                {
                    DateTime fechaActual = DateTime.Today;
                    AnioCur = Convert.ToInt32(fechaActual.Year.ToString());
                }
                else
                {
                    AnioCur = Convert.ToInt32(AnioCursado.Text);
                }

                if (e.CommandName == "Eliminar")
                {
                    //ocnCurso.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.GridView1.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                }

                if (e.CommandName == "Ver")
                {
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
            if (Session["CargaCalifxEspCTerc.PageIndex"] != null)
            {
                Session["CargaCalifxEspCTerc.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("CargaCalifxEspCTerc.PageIndex", e.NewPageIndex);
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
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            ocnCurso.Eliminar(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(GridView1.PageIndex);
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

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(GridView1.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(GridView1.PageIndex);

        Session["Editar"] = 2;

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
        {
            GridView1.EditIndex = e.NewEditIndex;
            int PageIndex = 0;
            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
            Session["Editar"] = 1;
            GrillaCargar(PageIndex);


            //CommandField tempEditar = new CommandField();
            //tempEditar.ShowEditButton = false;
            //tempEditar.ShowCancelButton = true;
            //GridView1.Columns.Add(tempEditar);
            GridView1.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
            //int ultcol = GridView1.Columns.Count;
            //GridView1.Columns[ultcol-2].Visible = true;
            //GridView1.Columns[ultcol-1].Visible = true;
        }
        else
        {
            LblMensajeErrorGrilla.Text = "No puede modificar notas..";
            return;
        }
    }
    protected void OnCancel(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        int PageIndex = 0;
        PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        GrillaCargar(PageIndex);

    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Edit$" + e.Row.RowIndex);

            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }


    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if ((Session["_perId"].ToString() != "10") & (Session["_perId"].ToString() != "9")) // Si es distinto a familiar puedo modificar
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int Id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0]);
                //int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[2]);

                TextBox Parc1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc1");
                TextBox RecParc1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc1");
                TextBox Parc2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc2");
                TextBox RecParc2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc2");
                TextBox Parc3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc3");
                TextBox RecParc3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc3");
                TextBox Parc4 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtParc4");
                TextBox RecParc4 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRecParc4");


                String NewParc1 = Parc1.Text;
                String NewRecParc1 = RecParc1.Text;
                String NewParc2 = Parc2.Text;
                String NewRecParc2 = RecParc2.Text;
                String NewParc3 = Parc3.Text;
                String NewRecPar3 = RecParc3.Text;
                String NewParc4 = Parc4.Text;
                String NewRecParc4 = RecParc4.Text;

                DateTime RenFechaHoraCreacion = DateTime.Now;
                DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
                Int32 usuIdCreacion = this.Master.usuId;
                Int32 usuIdUltimaModificacion = this.Master.usuId;

                //ocnRegistracionCalificaciones.ActualizarNotasParcTerc(Id, NewParc1, NewRecParc1, NewParc2, NewRecParc2, NewParc3, NewRecPar3,
                //NewParc4, NewRecParc4, RenFechaHoraCreacion, RenFechaHoraUltimaModificacion, usuIdCreacion, usuIdUltimaModificacion);
                GridView1.EditIndex = -1;
                int PageIndex = 0;
                PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
                GrillaCargar(PageIndex);
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
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }



    protected void TipoReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Treg"] = 1;
        Session.Add("datos", GridView1.DataSource);

        //DefinirColumnasNotas();
        //GridView1.DataSource = Session["datos"] as DataTable;
        //GridView1.DataBind();


        GrillaCargar(GridView1.PageIndex);

        Session["Editar"] = 2;
        //ButtonAsignar.Enabled = true;
    }

    protected void PeriodoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ButtonAsignar.Enabled = true;

    }


    protected void curId_SelectedIndexChanged(object sender, EventArgs e)
    {

        insId = Convert.ToInt32(Session["_Institucion"]);
        if ((Session["_perId"].ToString() == "1") || (Session["_perId"].ToString() == "6") || (Session["_perId"].ToString() == "5") || (Session["_perId"].ToString() == "18")) // Si es administrador o Director veo todas las carreras
        {
            escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.EspacioCurricular()).ObtenerListaPorUnCurso2("[Seleccionar...]", Convert.ToInt32(curId.SelectedValue), insId); escId.DataBind();
        }
        else
        {

            int upeId = Convert.ToInt32(Session["_upeId"].ToString());
            dt = ocnUsuarioEspacioCurricular.ObtenerUno(upeId);

            if ((Session["_perId"].ToString() == "4") || (Session["_perId"].ToString() == "11") || (Session["_perId"].ToString() == "18"))
            {
                escId.DataValueField = "Valor"; escId.DataTextField = "Texto"; escId.DataSource = (new GESTIONESCOLAR.Negocio.UsuarioEspacioCurricular()).ObtenerListaxupeIdyCur("[Seleccionar...]", upeId, Convert.ToInt32(curId.SelectedValue)); escId.DataBind();
            }
        }
    }


    protected void ButtonAsignar_Click(object sender, EventArgs e)
    {
        //int PageIndex = 0;
        //PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        //Session["Editar"] = 2;

        //String Nota = TextNotaAsignar.Text;
        //Session["datos"] = GridView1.DataSource;
        ////DefinirColumnasNotas();
        ////GridView1.DataSource = Session["datos"] as DataTable;
        ////GridView1.DataBind();

        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    //CheckBox chk = row.FindControl("chkcheck") as CheckBox;
        //    ////Int32 EstIC = Convert.ToInt32(GrillaAlumnos.DataKeys[row.RowIndex].Values["Estado"]);
        //    //if ((chk.Checked)) // Si esta seleccionado..
        //    //{
        //    Int32 ictId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["Id"]);
        //    DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
        //    Int32 usuIdUltimaModificacion = this.Master.usuId;

        //    int recId = ocnRegistracionCalificaciones.ObtenerUnoxictIdxDescTreg(ictId, TipoReg.SelectedItem.Text);
        //    ocnRegistracionCalificaciones.AsignarNotaTerc(recId, Nota, RenFechaHoraUltimaModificacion, usuIdUltimaModificacion);
        //    //}
        //}

        //GridView1.EditIndex = -1;

        //PageIndex = Convert.ToInt32(Session["CargaCalifxEspCTerc.PageIndex"]);
        //Session["Editar"] = 0;
        //Session["Treg"] = 2;
        //GrillaCargar(PageIndex);


    }
    //protected void ButtonAsignar_Click(object sender, EventArgs e)
    //{

    //    Int32 espc = 0;
    //    Int32 car = 0;
    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        car = Convert.ToInt32(carId.SelectedValue.ToString());
    //    }
    //    Int32 pla = 0;
    //    if (plaId.SelectedValue.ToString() != "" & plaId.SelectedValue.ToString() != "0")
    //    {
    //        pla = Convert.ToInt32(plaId.SelectedValue.ToString());
    //    }

    //    if (carId.SelectedValue.ToString() != "" & carId.SelectedValue.ToString() != "0")
    //    {
    //        cur = Convert.ToInt32(curId.SelectedValue.ToString());
    //    }

    //    if (escId.SelectedValue.ToString() != "" & escId.SelectedValue.ToString() != "0")
    //    {
    //        espc = Convert.ToInt32(escId.SelectedValue.ToString());
    //    }


    //    if (AnioCursado.Text == "")
    //    {
    //        DateTime fechaActual = DateTime.Today;
    //        AnioCur = Convert.ToInt32(fechaActual.Year.ToString());

    //    }
    //    else
    //    {
    //        AnioCur = Convert.ToInt32(AnioCursado.Text);
    //    }

    //    if (TextNotaAsignar.Text != "")
    //    {

    //        if (ExamenTipoId.SelectedValue != "0")
    //        {

    //            dt = ocnRegistracionNota.ObtenerTodoporEspCurricularAnio(espc, cur, AnioCur);

    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    int RecId = Convert.ToInt32(row["Id"].ToString());
    //                    //ocnRegistracionCalificaciones.AsignarNotaTerc(RecId, Convert.ToInt32(ExamenTipoId.SelectedValue), TextNotaAsignar.Text);

    //                }
    //            }

    //            GridView1.EditIndex = -1;
    //            int PageIndex = 0;
    //            PageIndex = Convert.ToInt32(Session["CargaCalifxEspCSec.PageIndex"]);
    //            GrillaCargar(PageIndex);
    //        }
    //        else
    //        {
    //            LblMensajeErrorGrilla.Text = "Seleccione un Periodo..";
    //            ExamenTipoId.Focus();
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        LblMensajeErrorGrilla.Text = "Asigne una nota..";
    //        TextNotaAsignar.Focus();
    //        return;
    //    }
    //}
    protected void ButtonImprimir_Click(object sender, EventArgs e)
    {

        try
        {
            String NomRep;
            Int32 Materia = Convert.ToInt32(escId.SelectedValue.ToString());
            Int32 curso = Convert.ToInt32(curId.SelectedValue.ToString());
            Int32 anioLectivo = Convert.ToInt32(AnioCursado.Text.Trim().ToString());

            NomRep = "InformeListadoCalificacionesxMateriaSec.rpt";

            FuncionesUtiles.AbreVentana("Reporte.aspx?espCId=" + Materia + "&curId=" + curso + "&anio=" + anioLectivo + "&NomRep=" + NomRep);
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

    protected void ExamenTipoId_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void escId_SelectedIndexChanged(object sender, EventArgs e)
    {
        insId = Convert.ToInt32(Session["_Institucion"]);
        DataTable dt5 = new DataTable();
        dt5 = ocnEspacioCurricular.ObtenerUno(Convert.ToInt32(escId.SelectedValue), insId);
        ExamenTipoId.DataValueField = "Valor"; ExamenTipoId.DataTextField = "Texto"; ExamenTipoId.DataSource = (new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerLista("[Seleccionar...]");
        //(new GESTIONESCOLAR.Negocio.TipoRegistro()).ObtenerListaxCarxPlaxEsc("[Seleccionar...]", Convert.ToInt32(carId.SelectedValue), 
        //Convert.ToInt32(plaId.SelectedValue), Convert.ToInt32(escId.SelectedValue));

        ExamenTipoId.DataBind();

        if (dt5.Rows.Count > 0)
        {

            if (Convert.ToInt32(dt5.Rows[0]["fodId"]) == 7)
            {
                //lblCondicion.Visible = true;
                //CondicionId.Visible = true;
                dvTaller.Visible = true;
                dvGrid.Visible = false;
                ExamenTipoId.Visible = false;
                lblPeriodo.Visible = false;
            }
            else
            {
                dvTaller.Visible = false;
                dvGrid.Visible = true;
                //lblCondicion.Visible = false;
                //CondicionId.Visible = false;
                ExamenTipoId.Visible = true;
                lblPeriodo.Visible = true;
            }
        }
    }



    protected void BtnTaller_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView2.Rows)
        {
            int ictId = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Values["ictId"]);
            DateTime RenFechaHoraUltimaModificacion = DateTime.Now;
            Int32 usuIdUltimaModificacion = this.Master.usuId;

            TextBox p = row.FindControl("txtNota") as TextBox;

            String Nota = Convert.ToString(p.Text);
            if (Nota == "a" || Nota == "A")
            {

                //ocnInscripcionCursadoTerciario.ActualizarCondicion(ictId, 8, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);
            }
            else
            {
                if (Nota == "d" || Nota == "D")
                {
                    //ocnInscripcionCursadoTerciario.ActualizarCondicion(Id, 9, usuIdUltimaModificacion, RenFechaHoraUltimaModificacion);
                }
                else
                {

                }
            }
            GrillaCargar(GridView1.PageIndex);
        }
    }


}