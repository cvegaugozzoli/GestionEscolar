<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CondicionParametrosFijosConsulta.aspx.cs" Inherits="CondicionParametrosFijosConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="ibox-content">
        <div class="row">
            <div class="col-sm-12">

                <div class="form-group col-md-2">
                    <label class="control-label ">Año Cursado</label>
                    <asp:TextBox ID="cpfAnioCursado" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <div class="col-md-4 col-md-offset-0">
                        </br>
                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                        OnClick="btnAplicar_Click" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>

                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpfId" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("cpfId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="fodId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="fodId" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("fodId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RegId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="regId" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("regId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma Dictado">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="fodNombre" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString() + "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("fodNombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Regimen">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Regimen" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString() + "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("regNombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cant Parciales">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="CantParciales" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()  + "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("cpfCantParciales") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cant Rec Parciales">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="CantRecParciales" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("cpfCantRecParciales") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cant TP">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="CantTP" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("cpfCantTP") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cant Rec TP">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="CantRecTP" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() + "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString()%>' Text='<%# Eval("cpfCantRTP") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cant Rec Asistencia">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpfRecAsistencia" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() + "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString()%>' Text='<%# Eval("cpfRecAsistencia") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Coloquio">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpfCantColoquio" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString()+ "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString() %>' Text='<%# Eval("cpfCantColoquio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cant Rec Coloquio">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpfCantRecColoquio" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() + "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString()%>' Text='<%# Eval("cpfCantRecColoquio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Anio Cursado">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpfCantRecColoquio" runat="server" NavigateUrl='<%# "CondicionParametrosFijosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"cpfId").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() + "&regId="+  DataBinder.Eval(Container.DataItem,"regId").ToString()%>' Text='<%# Eval("cpfCantRecColoquio") %>' />
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
