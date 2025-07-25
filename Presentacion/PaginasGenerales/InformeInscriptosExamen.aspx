<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformeInscriptosExamen.aspx.cs" Inherits="InformeInscriptosExamen" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            
                <div class="ibox-content">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset class="form-horizontal">

                            <div class="form-group">
                                <label class="control-label col-md-2">Numero Acta</label><div class="col-md-6">
                                    <asp:TextBox ID="ixaNumeroActa" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Aplica filtro fecha</label><div class="col-md-6">
                                    <asp:CheckBox ID="aplicafiltrofecha" runat="server" AutoPostBack ="true"  OnCheckedChanged ="aplicaplicafiltrofecha_SelectedIndexChanged"  Checked="False" Enabled="true"></asp:CheckBox></div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Fecha Examen</label><div class="col-md-6">
                                    <tpDatePicker:cuFecha ID="ixaFechaExamen" runat="server" Enabled="false" AllowType="False" />
                                </div>
                            </div>                        
                            <div class="form-group">
                                <label class="control-label col-md-2">Carrera</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Plan Estudio</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Curso</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Campo</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="camId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="camId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Espacio Curricular</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="escId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                                </div>
                            </div>

                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel >
                </div>




            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Listar" OnClick="btnListar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-success" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
