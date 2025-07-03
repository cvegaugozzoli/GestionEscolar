<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="EditarInformacion.aspx.cs" Inherits="EditarInformacion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>

    <div class="form-row">
        <div class="form-group col-md-4">
            <label class="control-label">Apellido</label>
            <asp:TextBox ID="usuApellido" type="text" class="form-control"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-4">
            <label class="control-label ">Nombre</label>
            <asp:TextBox ID="usuNombre" type="text" class="form-control"
                runat="server"></asp:TextBox>
        </div>

        <div class="form-group col-md-4">
            <label class="control-label">
                Nombre Ingreso</label>
            <asp:TextBox ID="usuNombreIngreso" type="text" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label class="control-label ">
                Email</label>
            <asp:TextBox ID="usuEmail" type="text" class="form-control"
                runat="server"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            <label class="control-label">
                Perfil</label>
            <asp:DropDownList ID="perId" runat="server" class="form-control m-b" Enabled="False">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group">

        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar"
            OnClick="btnAceptar_Click" />
        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
            OnClick="btnCancelar_Click" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblMej" runat="server" Text="" Font-Bold="True" ForeColor="#3333CC" Font-Size="Medium"></asp:Label>
    </div>



</asp:Content>
