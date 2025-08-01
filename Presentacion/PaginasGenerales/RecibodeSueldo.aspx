<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalEmpleados.master" AutoEventWireup="true" CodeFile="RecibodeSueldo.aspx.cs" Inherits="RecibodeSueldo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PrincipalEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-2">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-group col-md-4">
                <asp:Label class="control-label" ID="LblApe" runat="server" Text="Apellido y Nombre: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-4">
                    <label class="control-label col-md-4">Liquidación:</label>
                    <asp:DropDownList ID="liqid" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-row" style="background-color: #FFFFFF">

                <div class="form-group col-md-3">
                    <br />
                    <asp:Button ID="btnActualizar" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                        aria-expanded="false" aria-controls="collapseExample" Text="Imprimir" OnClick="btnActualizar_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

