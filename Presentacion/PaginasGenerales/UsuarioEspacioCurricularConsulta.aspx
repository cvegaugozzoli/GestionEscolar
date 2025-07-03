<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="UsuarioEspacioCurricularConsulta.aspx.cs" Inherits="UsuarioEspacioCurricularConsulta" %>

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
                    <%--   <div class="form-group">
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="ibox collapsed">
                <div class="ibox-title">
                    <h5><a class="collapse-link">Filtros</a></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="ibox-content">
                    <fieldset class="form-horizontal">
                        <div class="form-group col-md-3">
                            <label class="control-label">
                                Apellido</label>
                            <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-1">
                        </div>
                        <div class="form-group col-md-3">
                            <label class="control-label ">Situación</label>
                            <asp:DropDownList ID="SituacionId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="SituacionId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-1">
                        </div>
                        <div class="form-group col-md-3">
                            <br />
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                OnClick="btnAplicar_Click" />
                        </div>
                    </fieldset>
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
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>

                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Usuario" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Apellido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Situación">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Situacion" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Situacion") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha Inicio">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="AnoCursado" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("uscFchInicio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Carrera">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Carrera") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Perfil">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Perfil" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Perfil") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Curso">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Curso") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Campo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Campo" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Campo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="EspacioCurricular">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="EspacioCurricular" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("EspacioCurricular") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "UsuarioEspacioCurricularRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                        OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                        OnClick="btnEliminarCancelar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
