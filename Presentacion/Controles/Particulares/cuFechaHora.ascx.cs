using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles_Particulares_cuFechaHora : System.Web.UI.UserControl
{
    public DateTime Value
    {
        get
        {
            try
            {
                if (txtHora.Text.Trim().Length == 0) txtHora.Text = "00";
                if (txtHora.Text.Trim().Length == 1) txtHora.Text = "0" + txtHora.Text.Trim();

                if (txtMinuto.Text.Trim().Length == 0) txtMinuto.Text = "00";
                if (txtMinuto.Text.Trim().Length == 1) txtMinuto.Text = "0" + txtMinuto.Text.Trim();

                return Convert.ToDateTime(this.txtFecha.Text + " " + txtHora.Text + ":" + txtMinuto.Text + ":00");
            }
            catch (Exception oError)
            {
                return DateTime.Now;
            }
        }
        set
        {
            this.txtFecha.Text = value.ToString("yyyy-MM-dd");
            this.txtHora.Text = value.Hour.ToString();
            this.txtMinuto.Text = value.Minute.ToString();

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

    public bool Enabled
    {
        get
        {
            return txtFecha.Enabled;
        }
        set
        {
            this.txtFecha.Enabled = value;
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