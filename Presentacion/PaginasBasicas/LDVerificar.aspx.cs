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



public partial class LDVerificar : System.Web.UI.Page
{
    GESTIONESCOLAR.Negocio.LibreDeudaQR ocnLibreDeudaQR = new GESTIONESCOLAR.Negocio.LibreDeudaQR();
    GESTIONESCOLAR.Negocio.Instituciones ocnInstituciones = new GESTIONESCOLAR.Negocio.Instituciones();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (Request.QueryString["insId"] != null)
        {
            Int32 insId = Convert.ToInt32(Request.QueryString["insId"]);
            DataTable dtInst = new DataTable();
            dtInst = ocnInstituciones.ObtenerUno(insId);
            String InstDesc = Convert.ToString(dtInst.Rows[0]["Nombre"].ToString());
            Int32 aniocursado = Convert.ToInt32(Request.QueryString["aniocursado"]);
            Int32 aluId = Convert.ToInt32(Request.QueryString["aluId"]);
            Int32 mes = Convert.ToInt32(Request.QueryString["mes"]);
            String Concepto = Convert.ToString(Request.QueryString["Concepto"]);
            String MesPago = Convert.ToString(Request.QueryString["mesPago"]);

            DataTable dt = new DataTable();
            dt = ocnLibreDeudaQR.VerificarQR(InstDesc, aluId, mes, aniocursado, Concepto,MesPago);

            if (dt.Rows.Count > 0)
            {
                txtNombre.Text = Convert.ToString(dt.Rows[0]["ldpNombre"].ToString());
                txtCurso.Text = Convert.ToString(dt.Rows[0]["ldpCurso"].ToString());
                txtMes.Text = Convert.ToString(dt.Rows[0]["ldpMesPago"].ToString());
                txtConcepto.Text = Convert.ToString(dt.Rows[0]["ldpConcepto"].ToString());
                alerExito.Visible = true;
                lblExito.Text = "Libre Deuda para el mes especificado..";
            }
            else
            {
                alerExito.Visible = false;
                alerError.Visible = true;
                lblError.Text = "No tiene Libre Deuda";
            }

            /*INCIALIZADORES*/

        }
    }

}