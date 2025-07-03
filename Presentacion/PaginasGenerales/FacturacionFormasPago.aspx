<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="FacturacionFormasPago.aspx.cs" Inherits="FacturacionFormasPago" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>
    <div class="col-lg-12">
        <div class="panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Ingreso de Datos</h3>
                <%-- <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h3>Ingreso Datos</h3>
                </div>--%>
            </div>
        </div>
    </div>
 
    <div class="col-sm-12">
   <br />
        <div class="form-row">
            <div class="form-group col-md-2">
                <label class="control-label ">Fecha de Pago:</label>

                <tpDatePicker:cuFecha ID="FchPago" runat="server" Enabled="true" AllowType="False" BorderColor="Silver" />
            </div>
            <div class="form-group col-md-3">
                <label class="control-label">Lugar de Pago</label>
                <asp:DropDownList ID="LugarPagoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">

                <label class="control-label">Forma de Pago</label>
                <asp:DropDownList ID="FormaPagoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="FormaPagoId_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="form-group col-md-2">
                <label class="control-label ">Importe a Pagar:</label>
                <asp:Label ID="lblImporteaPagar" runat="server" Font-Size="x-Large" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
            <br />
        </div>

    </div>


    <div class="form-row">
        <div class="form-group col-md-2">
            <asp:Label ID="lblImporte" class="control-label" Visible="false" runat="server">Importe</asp:Label>
            <asp:TextBox ID="txtImporte" type="text" class="form-control" Visible="false" runat="server" BorderColor="Silver"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <asp:Label ID="lbltexto1" class="control-label" runat="server" Visible="false"></asp:Label>
            <asp:DropDownList ID="General1Id" BorderColor="Silver" runat="server" class="form-control m-b" Visible="false" Enabled="true"></asp:DropDownList>
        </div>
        <div class="form-group col-md-2">
            <asp:Label ID="lblPlanes" class="control-label" runat="server" Visible="false"></asp:Label>
            <asp:DropDownList ID="PlanesTarjetaId" BorderColor="Silver" runat="server" class="form-control m-b" Visible="false" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="PlanesTarjetaId_SelectedIndexChanged"></asp:DropDownList>

        </div>

        <div class="form-group col-md-2">
            <asp:Label ID="lblTexto2" class="control-label" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtGeneral2" type="text" class="form-control" runat="server" Visible="false" BorderColor="Silver"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <asp:Label ID="lblTexto3" class="control-label" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtGeneral3" type="text" class="form-control" runat="server" Visible="false" BorderColor="Silver"></asp:TextBox>
        </div>
        <div class="form-group col-md-2">
            <asp:Label ID="lblTexto4" class="control-label" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtGeneral4" type="text" class="form-control" runat="server" Visible="false" BorderColor="Silver"></asp:TextBox>
        </div>

    </div>


    <div class="col-sm-12">

        <div class="form-inline">
            <div class="form-group col-md-2">
                <asp:Button ID="btnAgregar" class="btn btn-w-m btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" Width="100%" Enabled="False" Visible="false" />
            </div>
            <div class="form-group col-md-6">
                <asp:Label class="control-label" ID="lblSaldoTit" runat="server" Visible="false">Saldo a Pagar:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSaldo" Visible="false" runat="server" Font-Size="x-Large" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">

            <div class="ibox-content">
                <div class="table-responsive">

                    <asp:GridView ID="GrillaFormaPgo" runat="server" DataKeyNames="IdLP,IdFP,FormaPago,fchPago,PlanTarj,Importe,ImpInteres,TarjetaId,Tarjeta,BancoId,Banco,NroCta,NroCheque" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:BoundField DataField="IdLP" HeaderText="IdLP" Visible="false" />
                            <asp:BoundField DataField="IdFP" HeaderText="IdFP" Visible="false" />
                            <asp:BoundField DataField="FormaPago" HeaderText="Forma de Pago" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                             <asp:BoundField DataField="fchPago" HeaderText="fchPago" Visible="false" />
                            <asp:BoundField DataField="TarjetaId" HeaderText="Tarjeta" Visible="false" />
                            <asp:BoundField DataField="Tarjeta" HeaderText="Tarjeta" />
                            <asp:BoundField DataField="BancoId" HeaderText="BancoId" Visible="false" />
                            <asp:BoundField DataField="Banco" HeaderText="Banco" />
                            <asp:BoundField DataField="NroCta" HeaderText="NroCta" />
                            <asp:BoundField DataField="Interes" HeaderText="Interes" />
                            <asp:BoundField DataField="ImpInteres" HeaderText="Importe Interes" Visible="false" />
                            <asp:BoundField DataField="NroCheque" HeaderText="Numero Cheque" />
                            <asp:BoundField DataField="PlanTarj" HeaderText="Plan Tarjeta" Visible="false" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                        OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                        OnClick="btnEliminarCancelar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Estado" Visible="false" HeaderText="Estado" />
                        </Columns>
                        <FooterStyle HorizontalAlign="NotSet" />

                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="form-raw">
        <asp:Label ID="LblMjeGridFormaPago" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
        <br />
    </div>

    <div class="col-sm-12">
        <div class="form-inline">
            <div class="form-group">
                <asp:Button ID="btnConfirmar" Visible="false" class="btn btn-w-m btn-primary" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" Width="100%" />
            </div>
            <%--<div class="form-group">
                    <asp:Button ID="btnCancelar" formnovalidate="formnovalidate" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                </div>--%>
        </div>

    </div>
</asp:Content>

