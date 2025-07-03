<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="RECIBOSSUELDOConsulta.aspx.cs" Inherits="RECIBOSSUELDOConsulta" %>

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
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    

    <div class="row">
	    <div class="col-sm-12">
            <div class="ibox-title"><h5>Listado | <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5></div>
		    <div class="ibox-content">
                <div class="table-responsive"><asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
	                AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
	                PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
	                <Columns>
		                
                        <asp:TemplateField HeaderText="_ID">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_ID" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="C_EMC_ID">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="C_EMC_ID" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("C_EMC_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_DESCRIPCION">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_DESCRIPCION" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_DESCRIPCION") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_DIRECCION">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_DIRECCION" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_DIRECCION") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_CUIT">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_CUIT" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_CUIT") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_APELLIDO">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_APELLIDO" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_APELLIDO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_NOMBRE">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_NOMBRE" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_NOMBRE") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_FEC_INI">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_FEC_INI" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_FEC_INI") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_DNI">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_DNI" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_DNI") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_DESCRIPCION">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_DESCRIPCION" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_DESCRIPCION") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_MES">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_MES" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_MES") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_ANIO">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_ANIO" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_ANIO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_IMPORTE">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_IMPORTE" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_IMPORTE") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_UNIDAD">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_UNIDAD" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_UNIDAD") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_VALOR">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_VALOR" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_VALOR") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_VALOR">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_VALOR" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_VALOR") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GO_NOMBRE">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="GO_NOMBRE" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("GO_NOMBRE") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IG_MENSUALES">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="IG_MENSUALES" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("IG_MENSUALES") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="S_HS_TRABAJADOS">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="S_HS_TRABAJADOS" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("S_HS_TRABAJADOS") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IG_REC">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="IG_REC" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("IG_REC") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CUENTOS">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CUENTOS" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CUENTOS") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TO">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="TO" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("TO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UIDO">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="UIDO" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("UIDO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_DESCRIPCION">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_DESCRIPCION" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_DESCRIPCION") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_DESCRIPCION">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_DESCRIPCION" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_DESCRIPCION") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IFICA">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="IFICA" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("IFICA") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CTO">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CTO" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CTO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UIDO2">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="UIDO2" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("UIDO2") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_CANTIDAD">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_CANTIDAD" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_CANTIDAD") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="_TOTAL">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="_TOTAL" runat="server" NavigateUrl='<%# "RECIBOSSUELDORegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("_TOTAL") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
		                <asp:TemplateField HeaderText="">
			                <ItemTemplate>
				                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
				                <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
					                OnClick="btnEliminarAceptar_Click" />
				                <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
					                OnClick="btnEliminarCancelar_Click" />
			                </ItemTemplate>
		                </asp:TemplateField>
	                </Columns>
	                <FooterStyle HorizontalAlign="Left" />
	                <HeaderStyle HorizontalAlign="Left" />
	                <PagerSettings Position="Top" />
	                <PagerStyle HorizontalAlign="Left" />
                </asp:GridView></div>
		    </div>
	    </div>
    </div>
</asp:Content>