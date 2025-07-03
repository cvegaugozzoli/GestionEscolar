<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="UsuarioConsultaCustom.aspx.cs" Inherits="UsuarioConsultaCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-12">
                    <div class="ibox-content m-b-sm border-bottom">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo"
                            OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server"
                            Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" />
                        <asp:Button ID="btnVolver" class="btn btn-w-m btn-danger" runat="server" Text="Volver"
                            OnClick="btnVolver_Click" Visible="false" />
                    </div>
                </div>

                <div class="col-sm-12">
                    <div class="ibox-content">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:TextBox ID="Nombre" type="text" class="form-control m-b" runat="server" AutoPostBack="False" placeholder="Nombre"
                                    OnTextChanged="btnAplicar_Click"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="Apellido" type="text" class="form-control m-b" runat="server" AutoPostBack="False" placeholder="Apellido"
                                    OnTextChanged="btnAplicar_Click"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="Usuario" type="text" class="form-control m-b" runat="server" AutoPostBack="False" placeholder="Usuario"
                                    OnTextChanged="btnAplicar_Click"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="Perfil" runat="server" class="form-control m-b" Enabled="true"
                                    AutoPostBack="False" OnSelectedIndexChanged="btnAplicar_Click">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info m-b" runat="server" Text="Aplicar"
                                    OnClick="btnAplicar_Click" />
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
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:GridView ID="Grilla" CssClass="table table-striped" runat="server" GridLines="None"
                                AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                                     <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId="  + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Apellido" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId=" + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("Apellido") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId="  + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NombreIngreso">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="NombreIngreso" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId=" + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("NombreIngreso") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Email" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId=" + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("Email") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Perfil">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Perfil" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId=" + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("Perfil") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Activo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&perId="  + DataBinder.Eval(Container.DataItem,"perId").ToString() %>'
                                                Text='<%# Eval("Activo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
<%--                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                            <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False" OnClick="btnEliminarAceptar_Click" />
                                            <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False" OnClick="btnEliminarCancelar_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:ButtonField CommandName="BlanquearClave" HeaderText="" Text="BlanquearClave" />--%>
                                    <asp:TemplateField HeaderText="Blanquea Clave">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuBlanquearClave_Click" ToolTip="Blanquea Clave para el registro seleccionado">Blanquear</asp:LinkButton>
                                            <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False" OnClick="btnEliminarAceptarBC_Click" />
                                            <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False" OnClick="btnEliminarCancelarBC_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    
                                 <%--   <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbuEliminarReg" runat="server" OnClick="lbuEliminarReg_Click" ToolTip="Elimina el registro seleccionado">X</asp:LinkButton>
                                            <asp:Button ID="btnEliminarRegAceptar" runat="server" Text="Si" Visible="False" OnClick="btnEliminarRegAceptar_Click" />
                                            <asp:Button ID="btnEliminarRegCancelar" runat="server" Text="No" Visible="False" OnClick="btnEliminarRegCancelar_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
