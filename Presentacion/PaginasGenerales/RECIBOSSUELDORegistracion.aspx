<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="RECIBOSSUELDORegistracion.aspx.cs" Inherits="RECIBOSSUELDORegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

	    <div class="col-sm-12">
		    <div class="ibox-content">
			    <fieldset class="form-horizontal">				   
                    
                        <div class="form-group"><label class="control-label col-md-2"> C _ E M C _ I D</label><div class="col-md-6">
                        <asp:TextBox ID="ECLC_EMC_ID" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ D E S C R I P C I O N</label><div class="col-md-6">
                        <asp:TextBox ID="LUP_DESCRIPCION" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ D I R E C C I O N</label><div class="col-md-6">
                        <asp:TextBox ID="LUP_DIRECCION" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ C U I T</label><div class="col-md-6">
                        <asp:TextBox ID="LUP_CUIT" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ A P E L L I D O</label><div class="col-md-6">
                        <asp:TextBox ID="EMP_APELLIDO" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ N O M B R E</label><div class="col-md-6">
                        <asp:TextBox ID="EMP_NOMBRE" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ F E C _ I N I</label><div class="col-md-6">
                        <tpDatePicker:cuFecha ID="EMC_FEC_INI" runat="server" Enabled="true" AllowType="False" /></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ D N I</label><div class="col-md-6">
                        <asp:TextBox ID="EMP_DNI" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ D E S C R I P C I O N</label><div class="col-md-6">
                        <asp:TextBox ID="CON_DESCRIPCION" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ M E S</label><div class="col-md-6">
                        <asp:TextBox ID="LIQ_MES" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ A N I O</label><div class="col-md-6">
                        <asp:TextBox ID="LIQ_ANIO" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ I M P O R T E</label><div class="col-md-6">
                        <asp:TextBox ID="ECL_IMPORTE" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ U N I D A D</label><div class="col-md-6">
                        <asp:TextBox ID="ECC_UNIDAD" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ V A L O R</label><div class="col-md-6">
                        <asp:TextBox ID="ECC_VALOR" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ V A L O R</label><div class="col-md-6">
                        <asp:TextBox ID="ECL_VALOR" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> G O _ N O M B R E</label><div class="col-md-6">
                        <asp:TextBox ID="CARGO_NOMBRE" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> I G _ M E N S U A L E S</label><div class="col-md-6">
                        <asp:TextBox ID="OBLIG_MENSUALES" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> S _ H S _ T R A B A J A D O S</label><div class="col-md-6">
                        <asp:TextBox ID="DIAS_HS_TRABAJADOS" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> I G _ R E C</label><div class="col-md-6">
                        <asp:TextBox ID="ANTIG_REC" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> C U E N T O S</label><div class="col-md-6">
                        <asp:TextBox ID="DESCUENTOS" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> T O</label><div class="col-md-6">
                        <asp:TextBox ID="BRUTO" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> U I D O</label><div class="col-md-6">
                        <asp:TextBox ID="LIQUIDO" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ D E S C R I P C I O N</label><div class="col-md-6">
                        <asp:TextBox ID="NIV_DESCRIPCION" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ D E S C R I P C I O N</label><div class="col-md-6">
                        <asp:TextBox ID="PLA_DESCRIPCION" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> I F I C A</label><div class="col-md-6">
                        <asp:TextBox ID="BONIFICA" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> C T O</label><div class="col-md-6">
                        <asp:TextBox ID="DESCTO" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> U I D O 2</label><div class="col-md-6">
                        <asp:TextBox ID="LIQUIDO2" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ C A N T I D A D</label><div class="col-md-6">
                        <asp:TextBox ID="ECL_CANTIDAD" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> _ T O T A L</label><div class="col-md-6">
                        <asp:TextBox ID="ANT_TOTAL" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                    <hr class="hr-line-dashed" />
                </fieldset>
            </div>
        </div>

        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>