using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles_Particulares_cuHora : System.Web.UI.UserControl
{
    public string ValidationGroup
    {
        get
        {
            return this.revHora.ValidationGroup;
        }
        set
        {
            this.revHora.ValidationGroup = value;
            this.revMinuto.ValidationGroup = value;
            this.rvaHora.ValidationGroup = value;
            this.rvaMinuto.ValidationGroup = value;
        }
    }

    public string Text
    {
        get
        {
            try
            {
                if (txtHora.Text.Trim().Length == 0) txtHora.Text = "00";
                if (txtHora.Text.Trim().Length == 1) txtHora.Text = "0" + txtHora.Text.Trim();

                if (txtMinuto.Text.Trim().Length == 0) txtMinuto.Text = "00";
                if (txtMinuto.Text.Trim().Length == 1) txtMinuto.Text = "0" + txtMinuto.Text.Trim();

                if (txtHora.Text.Trim() + ":" + txtMinuto.Text.Trim() == ":")
                {
                    return "";
                }
                else
                {
                    return txtHora.Text + ":" + txtMinuto.Text;
                }
            }
            catch (Exception oError)
            {
                return "";
            }
        }
        set
        {
            if (value.Trim().Length != 0)
            {
                this.txtHora.Text = value.Substring(0, 2);
                this.txtMinuto.Text = value.Substring(3, 2);
            }
        }
    }

    public bool Enabled
    {
        get
        {
            return txtHora.Enabled;
        }
        set
        {
            this.txtHora.Enabled = value;
            this.txtMinuto.Enabled = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}