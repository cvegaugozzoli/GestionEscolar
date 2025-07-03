using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PaginasBasicas_Index : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("PaginasBasicas/Index1.aspx", true);
    }

}