<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="FamiliarConsulta.aspx.cs" Inherits="FamiliarConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
            <asp:TextBox ID="aluId" Visible="false" type="number" runat="server" class="form-control m-b" Enabled="true"></asp:TextBox>
            <div class="ibox-content">
                <div class="table-responsive">

                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                        <Columns>

                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="famId">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="famId" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("famId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Apellido">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ApellidoFam" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Apellido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="NombreFam" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parentesco">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Parentesco" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Parentesco") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tutor">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Tutor" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Tutor") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Dni">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Dni" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Dni") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Cuit">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Cuit" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Cuit") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telefono">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Telefono" runat="server" NavigateUrl='<%# "FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Telefono") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Red" ID="FamiliarVer" runat="server" NavigateUrl='<%#"FamiliarRegistracion.aspx?IdIC="+aluId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='Ver' />
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
                          <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#CCCCFF" />
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
