<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CondicionParametrosConsulta.aspx.cs" Inherits="CondicionParametrosConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
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
                    <asp:Button ID="btnListar" class="btn btn-w-m btn-info" runat="server" Text="Listar"
                        OnClick="btnListar_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>
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
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="fodId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="fodId" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("fodId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Forma Dictado">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="fodNombre" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("fodNombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() + "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asistencia">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpmAsistencia" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("cpmAsistencia") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Asistencia Recursa">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpmAsistenciaRec" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("cpmAsistenciaRec") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Practicas Aprobobadas">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpmPracticasAprob" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("cpmPracticasAprob") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nota para Aprobar >=">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpmNota" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("cpmNota") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nota para Coloquio >=">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cpmNotaColoquio" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("cpmNotaColoquio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "CondicionParametrosRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&fodId="+  DataBinder.Eval(Container.DataItem,"fodId").ToString() %>' Text='<%# Eval("cpmActivo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
