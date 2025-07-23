using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class InicioPadres : System.Web.UI.Page
{
    GESTIONESCOLAR.Datos.Gestor ocdGestor = new GESTIONESCOLAR.Datos.Gestor();
    GESTIONESCOLAR.Negocio.Parametro ocnParametro = new GESTIONESCOLAR.Negocio.Parametro();
    DataTable dt = new DataTable();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstitucion = new GESTIONESCOLAR.Negocio.Instituciones();
    GESTIONESCOLAR.Negocio.Alumno ocnAlumno = new GESTIONESCOLAR.Negocio.Alumno();

    GESTIONESCOLAR.Negocio.Familiar ocnFamiliar = new GESTIONESCOLAR.Negocio.Familiar();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["_perId"].ToString() == "16")
                {
                    String DNIUSUARIO = Convert.ToString(Session["_usuNombreIngreso"].ToString());
                    dt = ocnAlumno.ObtenerUnoporDoc(DNIUSUARIO);
                    if (dt.Rows.Count > 0)
                    {
                        this.Master.TituloDelFormulario = dt.Rows[0]["Nombre"].ToString();
                        
                        
                        //int usuario = Convert.ToInt32(Session["_usuId"].ToString());
                        //dt = ocnFamiliar.ObtenerUnoxUsuId(usuario);
                        //if (dt.Rows.Count != 0)
                        //{
                        //    this.Master.TituloDelFormulario = "Bienvenido/a Sr/a: " + dt.Rows[0][1].ToString() + "." +
                        // " En esta sección encontrará información academica del menor a cargo. ";

                        //}
                    }
                }
                else
                {
                    //this.Master.TituloDelFormulario = "Menu Inicio";
                }
                if (this.Session["_Autenticado"] == null) Response.Redirect("LoginPadres.aspx", true);
                if (this.Session["_Autenticado"] == null) Response.RedirectToRoute("sitio");

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/

                    if (Id != 0)
                    {
                        ocnInstitucion = new GESTIONESCOLAR.Negocio.Instituciones(Id);
                        Session["_InstitucionNombre"] = ocnInstitucion.insNombre;
                        Session["_Institucion"] = ocnInstitucion.insId;
                                            }
                }

                if (!Page.IsPostBack)
                {
                    if (Session["_CambiarClave"] != null)
                    {
                        if (Session["_CambiarClave"].ToString() == "0")
                        {
                            Inicializar();
                        }
                        else
                        {
                            Response.Redirect("UsuarioCambiarClave.aspx", false);
                        }
                    }
                }
            }
        }
        
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void Inicializar()
{
    if (this.Session["_Autenticado"] == null)
    {
        Response.Redirect("../PaginasBasicas/LoginPadres.aspx", true);
        //Response.RedirectToRoute("sitio");
    }
    else
    {
        if (Session["_perId"] != null)
        {
            menCargar();
        }
        else
        {
            Response.Redirect("../PaginasBasicas/LoginPadres.aspx", true);
            //Response.RedirectToRoute("sitio");
        }
    }
}

protected void menCargar()
{
    try
    {
        dt = new DataTable();

        string Sql = "";

        if (this.Master.perId == 23 || this.Master.perId == 24)
        {
            #region Sql
            Sql = @"
declare @perId int
select @perId = " + this.Master.perId.ToString() + @"

set dateformat dmy

declare @Cadena varchar(max), @menId int, @menNombre varchar(1000), @menUrl varchar(1000)

select @Cadena = ''

declare cMenuPadre cursor for 
select men.menId, men.menNombre, men.menUrl
from Menu men, PerfilMenu pme
where 1 = 1
and men.menActivo = 1
and men.menId = pme.menId 
and pme.perId = @perId
and men.menIdPadre = 0
and men.menId in
(
select men1.menIdPadre
from PerfilMenu pme1, Menu men1
where 1 = 1
and men1.menActivo = 1
and men1.menId = pme1.menId
and pme1.perId = @perId
and men1.menIdPadre > 0
and men.menEsMenu = 1
)
order by menOrden

open cMenuPadre
fetch next from cMenuPadre into @menId, @menNombre, @menUrl
while @@FETCH_STATUS = 0
begin
	--Recorro los menu padres
	select @Cadena = @Cadena + '
	
<h3><p style=""color: #333333"">' + @menNombre + '</p></h3>
	<ol class=""breadcrumb"">'

    select @Cadena = @Cadena + '
		<a href=""' + Menu.menUrl + '"">' + Menu.menNombre + '</a><br>'
    from Menu, PerfilMenu  
    where Menu.menIdPadre = @menId 
    and Menu.menActivo = 1
    and Menu.menId = PerfilMenu.menId
    and PerfilMenu.perId = @perId
    order by Menu.menNombre
   
	select @Cadena = @Cadena + '
	</ol><br />'
   
    fetch next from cMenuPadre into @menId, @menNombre, @menUrl
end
close cMenuPadre
deallocate cMenuPadre

select @Cadena as Cadena";
            #endregion
        }
        else
        {
            #region Sql
            Sql = @"
declare @perId int
select @perId = " + this.Master.perId.ToString() + @"

set dateformat dmy

declare @Cadena varchar(max), @menId int, @menNombre varchar(1000), @menUrl varchar(1000)

select @Cadena = ''

declare cMenuPadre cursor for 
select men.menId, men.menNombre, men.menUrl
from Menu men, PerfilMenu pme
where 1 = 1
and men.menActivo = 1
and men.menId = pme.menId 
and pme.perId = @perId
and men.menIdPadre = 0
and men.menId in
(
select men1.menIdPadre
from PerfilMenu pme1, Menu men1
where 1 = 1
and men1.menActivo = 1
and men1.menId = pme1.menId
and pme1.perId = @perId
and men1.menIdPadre > 0
and men.menEsMenu = 1
)
order by menOrden

open cMenuPadre
fetch next from cMenuPadre into @menId, @menNombre, @menUrl
while @@FETCH_STATUS = 0
begin
	--Recorro los menu padres
	select @Cadena = @Cadena + '
	
<h3><p style=""color: #333333"">' + @menNombre + '</p></h3>
	<ol class=""breadcrumb"">'

    select @Cadena = @Cadena + '
		<li><a href=""' + Menu.menUrl + '"">' + Menu.menNombre + '</a> </li>'
    from Menu, PerfilMenu  
    where Menu.menIdPadre = @menId 
    and Menu.menActivo = 1
    and Menu.menId = PerfilMenu.menId
    and PerfilMenu.perId = @perId
    order by Menu.menNombre
   
	select @Cadena = @Cadena + '
	</ol><br />'
   
    fetch next from cMenuPadre into @menId, @menNombre, @menUrl
end
close cMenuPadre
deallocate cMenuPadre

select @Cadena as Cadena";
            #endregion
        }

        dt = ocdGestor.EjecutarReaderSql(Sql);

        if (dt != null)
        {
            if (lblMenu.Text.Trim().Length != 0)
            {
                lblMenu.Text += @"<hr class=""hr-line-dashed"" />";
            }

            lblMenu.Text += dt.Rows[0]["Cadena"].ToString().Trim();
        }
    }
    catch (Exception oError)
    {
        Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
    }
}

private string ObtenerTodoPadre(string perId)
{
    string Sql = "";

    Sql = @"
select men.menId, men.menNombre, men.menUrl 
from Menu men, PerfilMenu pme
where men.menIdPadre = 0
and men.menActivo = 1
and men.menId = pme.menId
and pme.perId = " + perId + @"
and men.menEsMenu = 1 
and men.menId in
(
select men1.menIdPadre
from PerfilMenu pme1, Menu men1
where 1 = 1
and men1.menActivo = 1
and men1.menId = pme1.menId
and pme1.perId = @perId
and men1.menIdPadre > 0
and men.menEsMenu = 1
)
order by men.menOrden";

    return Sql;
}

private string ObtenerTodoHijo(string perId, string menId)
{
    return @"
select men.menId, men.menNombre, men.menUrl 
from Menu men, PerfilMenu pme
where men.menIdPadre = " + menId + @" 
and men.menActivo = 1
and men.menId = pme.menId
and pme.perId = " + perId + @"
and men.menEsMenu = 1 
order by men.menNombre";
}
}