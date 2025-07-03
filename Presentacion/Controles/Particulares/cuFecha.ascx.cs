using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles_Particulares_cuFecha : System.Web.UI.UserControl
{
    public DateTime Value
    {
        get
        {
            try
            {
                return Convert.ToDateTime(this.txt.Text);
            }
            catch (Exception oError)
            {
                return DateTime.Now;
            }
        }
        set
        {
            this.txt.Text = value.ToString("yyyy-MM-dd");
            this.lbl.Text = value.ToString("yyyy-MM-dd");
        }
    }

    public DateTime CalendarDate
    {
        get
        {
            return Value;
        }
        set
        {
            this.Value = value;
        }
    }

    public DateTime Text
    {
        get
        {
            return Value;
        }
        set
        {
            this.Value = value;
        }
    }

    public bool Enabled
    {
        get
        {
            return txt.Enabled;
        }
        set
        {
            this.txt.Enabled = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (lbl.Text.Trim().Length != 0)
        {
            txt.Text = lbl.Text;
        }*/
    }
}