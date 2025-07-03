<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ConceptosConsulta.aspx.cs" Inherits="ConceptosConsulta" %>

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
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="ibox collapsed">
            <div class="ibox-title">
                <h5><a class="collapse-link">Filtros</a></h5>
                <div class="ibox-tools">
                    <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                </div>
            </div>
            <div class="col-sm-12" style="background-color: #FFFFFF">
                <div class="ibox-content">
                    <div class="form-row" style="background-color: #FFFFFF">
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" class="control-label ">Nombre:</asp:Label>
                            <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"
                               ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <asp:Label runat="server" class="control-label ">Año: </asp:Label>
                            <asp:TextBox ID="txtAnio" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"
                               ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 ">
                             <asp:Label runat="server" class="control-label "><br /> </asp:Label>
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                OnClick="btnAplicar_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title">
            <%--    <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>--%>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                         <Columns>

                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Instituciones">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Instituciones" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Instituciones") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ConceptosTipos">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ConceptosTipos" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("ConceptosTipos") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AnioLectivo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="AnioLectivo" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("AnioLectivo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Importe">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Importe" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Importe") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CantCuotas">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="CantCuotas" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CantCuotas") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CantVtos">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="CantVtos" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CantVtos") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MesInicio" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="MesInicio" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("MesInicio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RecargoVtoAbierto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="RecargoVtoAbierto" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("RecargoVtoAbierto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TieneVtoAbierto" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="TieneVtoAbierto" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("TieneVtoAbierto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notas" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Notas" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Notas") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InteresMensual">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresMensual" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("InteresMensual") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activo" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "ConceptosYCI.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
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
                        <PagerStyle HorizontalAlign="center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
