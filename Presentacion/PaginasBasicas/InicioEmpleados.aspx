<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalEmpleados.master" AutoEventWireup="true" CodeFile="InicioEmpleados.aspx.cs" Inherits="InicioEmpleados" %>

<%@ MasterType TypeName="PrincipalEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Label ID="lblNovedades" runat="server" Text=""></asp:Label>
            <div class="ibox-content">
                <fieldset class="form-horizontal">
                    <asp:Label ID="lblMenu" runat="server" Text=""></asp:Label>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
