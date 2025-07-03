<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="Permisos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="upaObs" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Perfil</label><div class="col-md-6">
                                        <asp:DropDownList ID="perId" runat="server" class="form-control m-b"
                                            Enabled="true" AutoPostBack="True"
                                            OnSelectedIndexChanged="perId_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Menu</label><div class="col-md-6">
                                        <asp:DropDownList ID="menId" runat="server" class="form-control m-b"
                                            Enabled="true" AutoPostBack="True"
                                            OnSelectedIndexChanged="menId_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                            </div>
                    </div>
                    <div class="table-responsive">




                        <asp:GridView ID="GrillaPermiso" runat="server" AutoGenerateColumns="False" OnRowDataBound="GrillaPermiso_RowDataBound"
                            OnRowCommand="GrillaPermiso_RowCommand"  GridLines="None"  AllowPaging="True" OnPageIndexChanging="GrillaPermiso_PageIndexChanging"
                            class="table table-striped" data-page-size="200" data-filter="#filter"
                            PageSize="12">

                                 <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="Menu" HeaderText="Menu" />
                                <asp:BoundField DataField="Activo" HeaderText="Activo" />
                                <asp:ButtonField CommandName="Quitar" HeaderText="Quitar" Text="Quitar" />
                            </Columns>
                                     <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#CCCCFF" />
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                            <PagerSettings Position="Top" />
                        </asp:GridView>
                    </div>
                    </fieldset>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
