﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CerrarSesionEmpleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("_PaginasPermitidas");
        Session.Remove("_Autenticado");
        Session.Clear();
        Session.Abandon();

        Response.Redirect("../PaginasBasicas/LoginEmpleados.aspx", false);
    }
}