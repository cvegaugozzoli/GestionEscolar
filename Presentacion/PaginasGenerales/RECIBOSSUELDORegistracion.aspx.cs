using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

public partial class RECIBOSSUELDORegistracion : System.Web.UI.Page
{
    
    GESTIONESCOLAR.Negocio.RECIBOSSUELDO ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " R E C I B O S S U E L D O - Registracion";

				//if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false; 
                    btnAceptar1.Visible = false;
                }
            
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

					/*INCIALIZADORES*/

					if (Id != 0)
                    {
						ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO(Id);
						this.ECLC_EMC_ID.Text = ocnRECIBOSSUELDO.ECLC_EMC_ID.ToString();
						this.LUP_DESCRIPCION.Text = ocnRECIBOSSUELDO.LUP_DESCRIPCION;
						this.LUP_DIRECCION.Text = ocnRECIBOSSUELDO.LUP_DIRECCION;
						this.LUP_CUIT.Text = ocnRECIBOSSUELDO.LUP_CUIT;
						this.EMP_APELLIDO.Text = ocnRECIBOSSUELDO.EMP_APELLIDO;
						this.EMP_NOMBRE.Text = ocnRECIBOSSUELDO.EMP_NOMBRE;
						this.EMC_FEC_INI.Text = ocnRECIBOSSUELDO.EMC_FEC_INI;
						this.EMP_DNI.Text = ocnRECIBOSSUELDO.EMP_DNI;
						this.CON_DESCRIPCION.Text = ocnRECIBOSSUELDO.CON_DESCRIPCION;
						this.LIQ_MES.Text = ocnRECIBOSSUELDO.LIQ_MES.ToString();
						this.LIQ_ANIO.Text = ocnRECIBOSSUELDO.LIQ_ANIO.ToString();
						this.ECL_IMPORTE.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.ECL_IMPORTE);
						this.ECC_UNIDAD.Text = ocnRECIBOSSUELDO.ECC_UNIDAD.ToString();
						this.ECC_VALOR.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.ECC_VALOR);
						this.ECL_VALOR.Text = ocnRECIBOSSUELDO.ECL_VALOR.ToString();
						this.CARGO_NOMBRE.Text = ocnRECIBOSSUELDO.CARGO_NOMBRE;
						this.OBLIG_MENSUALES.Text = ocnRECIBOSSUELDO.OBLIG_MENSUALES.ToString();
						this.DIAS_HS_TRABAJADOS.Text = ocnRECIBOSSUELDO.DIAS_HS_TRABAJADOS.ToString();
						this.ANTIG_REC.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.ANTIG_REC);
						this.DESCUENTOS.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.DESCUENTOS);
						this.BRUTO.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.BRUTO);
						this.LIQUIDO.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.LIQUIDO);
						this.NIV_DESCRIPCION.Text = ocnRECIBOSSUELDO.NIV_DESCRIPCION;
						this.PLA_DESCRIPCION.Text = ocnRECIBOSSUELDO.PLA_DESCRIPCION;
						this.BONIFICA.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.BONIFICA);
						this.DESCTO.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.DESCTO);
						this.LIQUIDO2.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.LIQUIDO2);
						this.ECL_CANTIDAD.Text = FuncionesUtiles.DecimalToString(ocnRECIBOSSUELDO.ECL_CANTIDAD);
						this.ANT_TOTAL.Text = ocnRECIBOSSUELDO.ANT_TOTAL;

                        /*Editar Habilitado*/
					}
                    else
                    {
                        EMC_FEC_INI.Text = DateTime.Now;


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.ECLC_EMC_ID.Focus();
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
		
	protected void btnCancelar_Click(object sender, EventArgs e)
	{
        try
        {
            Response.Redirect("RECIBOSSUELDOConsulta.aspx", true);
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
		
	protected void btnAceptar_Click(object sender, EventArgs e)
	{
        try
        {
		    int Id = 0;
		    if (Request.QueryString["Id"] != null)
		    {
			    Id = Convert.ToInt32(Request.QueryString["Id"]);
			    ocnRECIBOSSUELDO = new GESTIONESCOLAR.Negocio.RECIBOSSUELDO(Id);

			    ocnRECIBOSSUELDO.ECLC_EMC_ID = Convert.ToInt32(ECLC_EMC_ID.Text); 
			    ocnRECIBOSSUELDO.LUP_DESCRIPCION = LUP_DESCRIPCION.Text; 
			    ocnRECIBOSSUELDO.LUP_DIRECCION = LUP_DIRECCION.Text; 
			    ocnRECIBOSSUELDO.LUP_CUIT = LUP_CUIT.Text; 
			    ocnRECIBOSSUELDO.EMP_APELLIDO = EMP_APELLIDO.Text; 
			    ocnRECIBOSSUELDO.EMP_NOMBRE = EMP_NOMBRE.Text; 
			    ocnRECIBOSSUELDO.EMC_FEC_INI = Convert.ToDateTime(EMC_FEC_INI.Text); 
			    ocnRECIBOSSUELDO.EMP_DNI = EMP_DNI.Text; 
			    ocnRECIBOSSUELDO.CON_DESCRIPCION = CON_DESCRIPCION.Text; 
			    ocnRECIBOSSUELDO.LIQ_MES = Convert.ToInt32(LIQ_MES.Text); 
			    ocnRECIBOSSUELDO.LIQ_ANIO = Convert.ToInt32(LIQ_ANIO.Text); 
			    ocnRECIBOSSUELDO.ECL_IMPORTE = FuncionesUtiles.StringToDecimal(ECL_IMPORTE.Text); 
			    ocnRECIBOSSUELDO.ECC_UNIDAD = Convert.ToInt32(ECC_UNIDAD.Text); 
			    ocnRECIBOSSUELDO.ECC_VALOR = FuncionesUtiles.StringToDecimal(ECC_VALOR.Text); 
			    ocnRECIBOSSUELDO.ECL_VALOR = Convert.ToInt32(ECL_VALOR.Text); 
			    ocnRECIBOSSUELDO.CARGO_NOMBRE = CARGO_NOMBRE.Text; 
			    ocnRECIBOSSUELDO.OBLIG_MENSUALES = Convert.ToInt32(OBLIG_MENSUALES.Text); 
			    ocnRECIBOSSUELDO.DIAS_HS_TRABAJADOS = Convert.ToInt32(DIAS_HS_TRABAJADOS.Text); 
			    ocnRECIBOSSUELDO.ANTIG_REC = FuncionesUtiles.StringToDecimal(ANTIG_REC.Text); 
			    ocnRECIBOSSUELDO.DESCUENTOS = FuncionesUtiles.StringToDecimal(DESCUENTOS.Text); 
			    ocnRECIBOSSUELDO.BRUTO = FuncionesUtiles.StringToDecimal(BRUTO.Text); 
			    ocnRECIBOSSUELDO.LIQUIDO = FuncionesUtiles.StringToDecimal(LIQUIDO.Text); 
			    ocnRECIBOSSUELDO.NIV_DESCRIPCION = NIV_DESCRIPCION.Text; 
			    ocnRECIBOSSUELDO.PLA_DESCRIPCION = PLA_DESCRIPCION.Text; 
			    ocnRECIBOSSUELDO.BONIFICA = FuncionesUtiles.StringToDecimal(BONIFICA.Text); 
			    ocnRECIBOSSUELDO.DESCTO = FuncionesUtiles.StringToDecimal(DESCTO.Text); 
			    ocnRECIBOSSUELDO.LIQUIDO2 = FuncionesUtiles.StringToDecimal(LIQUIDO2.Text); 
			    ocnRECIBOSSUELDO.ECL_CANTIDAD = FuncionesUtiles.StringToDecimal(ECL_CANTIDAD.Text); 
			    ocnRECIBOSSUELDO.ANT_TOTAL = ANT_TOTAL.Text; 

                /*....usuId = this.Master.usuId;*/
                

				ocnRECIBOSSUELDO.usuIdCreacion = this.Master.usuId;
				ocnRECIBOSSUELDO.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnRECIBOSSUELDO.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnRECIBOSSUELDO.usuIdUltimaModificacion = this.Master.usuId;
					    ocnRECIBOSSUELDO.Actualizar();
				    }
					
				    Response.Redirect("RECIBOSSUELDOConsulta.aspx", true);
			    }
			    else
			    {
				    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
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
}