using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cuHoraMinuto : System.Web.UI.UserControl
{
    public event EventHandler TextChanged;
    protected virtual void cuHoraMinuto_TextChanged(object sender, EventArgs e) { }

    public int HoraDesde
    {
        get
        {
            try
            {
                if (txtHoraDesde.Text.Trim().Length == 0) txtHoraDesde.Text = "0";
                return Convert.ToInt32(txtHoraDesde.Text);
            }
            catch (Exception oError)
            {
                return 0;
            }
        }
        set
        {
            txtHoraDesde.Text = value.ToString();
        }
    }

    public int MinutoDesde
    {
        get
        {
            try
            {
                if (txtMinutoDesde.Text.Trim().Length == 0) txtMinutoDesde.Text = "0";
                return Convert.ToInt32(txtMinutoDesde.Text);
            }
            catch (Exception oError)
            {
                return 0;
            }
        }
        set
        {
            txtMinutoDesde.Text = value.ToString();
        }
    }

    public int HoraHasta
    {
        get
        {
            try
            {
                if (txtHoraHasta.Text.Trim().Length == 0) txtHoraHasta.Text = "0";
                return Convert.ToInt32(txtHoraHasta.Text);
            }
            catch (Exception oError)
            {
                return 0;
            }
        }
        set
        {
            txtHoraHasta.Text = value.ToString();
        }
    }

    public int MinutoHasta
    {
        get
        {
            try
            {
                if (txtMinutoHasta.Text.Trim().Length == 0) txtMinutoHasta.Text = "0";
                return Convert.ToInt32(txtMinutoHasta.Text);
            }
            catch (Exception oError)
            {
                return 0;
            }
        }
        set
        {
            txtMinutoHasta.Text = value.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception oError)
        {
        }
    }

    public void Focus()
    {
        txtHoraDesde.Focus();
    }

    protected void txtHoraDesde_TextChanged(object sender, EventArgs e)
    {
        this.TextChanged(sender, e);
        txtMinutoDesde.Focus();
    }

    protected void txtMinutoDesde_TextChanged(object sender, EventArgs e)
    {
        this.TextChanged(sender, e);
        txtHoraHasta.Focus();
    }

    protected void txtHoraHasta_TextChanged(object sender, EventArgs e)
    {
        this.TextChanged(sender, e);
        txtMinutoHasta.Focus();
    }

    protected void txtMinutoHasta_TextChanged(object sender, EventArgs e)
    {
        this.TextChanged(sender, e);
    }
}