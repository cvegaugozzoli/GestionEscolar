<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalPadres.master" AutoEventWireup="true" CodeFile="InicioPadres.aspx.cs" Inherits="InicioPadres" %>

<%@ MasterType TypeName="PrincipalPadres" %>
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
