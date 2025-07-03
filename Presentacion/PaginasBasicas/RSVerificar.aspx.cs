using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;



public partial class RSVerificar : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.RECIBOSSUELDO ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["empCUIT"] != null)
        {
            //Int64 empCUIT = Convert.ToInt32(Request.QueryString["empCUIT"]);
            string parametrosCUITyLiqId = Request.QueryString["empCUIT"].ToString();

            Int64 empCUIT = Convert.ToInt64(parametrosCUITyLiqId.Substring(0, 11));
            Int32 liqid = Convert.ToInt32(parametrosCUITyLiqId.Substring(12));

            //string textoParaQR = "https://obramisericordista.com.ar/PaginasBasicas/RSVerificar.aspx?empCUIT=" + empCUIT.ToString() + "&liqid=" + liqid.ToString();

            txtCUIL.Text = empCUIT.ToString();
            txtliquidacion.Text = liqid.ToString();

            string dni = txtCUIL.Text.Substring(2, 8);
            DataTable DTListar = new DataTable();
            DTListar = ocnRECIBOSSUELDO.ControlarSiExiste(liqid, dni);
            if (DTListar.Rows.Count > 0)
            {
                txtNombre.Text = DTListar.Rows[0]["APELLIDOYNOMBRE"].ToString();
                txtliquidacion.Text = DTListar.Rows[0]["LIQ_DESCRIPCION"].ToString();
            } 

            txtEstado.Text = "VALIDO";
        }
        else
        {
            txtEstado.Text = "NO VALIDO";
            //alerExito.Visible = false;
            //alerError.Visible = true;
            //lblError.Text = "No tiene Recibo de Sueldo";
        }

    }

}