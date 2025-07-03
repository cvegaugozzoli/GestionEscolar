<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="TurnoExamenRegistracion.aspx.cs" Inherits="TurnoExamenRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFechaHora.ascx" TagName="cuFechaHora" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="row">
                    <div class="form-group col-md-3">
                        <label class="control-label ">Nombre</label>
                        <asp:TextBox ID="tueNombre" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">Año</label>
                        <asp:TextBox ID="tueAnio" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label ">Llamado</label>
                        <asp:DropDownList ID="LlamadoId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label">Inicio</label>
                        <tpDatePicker:cuFechaHora ID="tueFchInicio" runat="server" Enabled="true" BorderColor="Silver" />

                        <%--  <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        <asp:TextBox ID="tueFchInicio" type="datetime" class="form-control" runat="server"></asp:TextBox>--%>
                    </div>

                    <div class="form-group col-md-2">
                        <label class="control-label">Fin</label>
                        <tpDatePicker:cuFechaHora ID="tueFchFin" runat="server" Enabled="true" AllowType="False" BorderColor="Silver" />

                        <%--<asp:TextBox ID="tueFchFin" type="datetime" class="form-control" runat="server"></asp:TextBox>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-2">
                        <label class="control-label">Activo</label><div class="col-md-6">
                            <asp:CheckBox ID="tueActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                        </div>
                    </div>
                </div>
                <hr class="hr-line-dashed" />
            </div>
        </div>
   


    <div class="col-sm-12">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                </div>
            </div>
        </div>
    </div>

    </div>
</asp:Content>
