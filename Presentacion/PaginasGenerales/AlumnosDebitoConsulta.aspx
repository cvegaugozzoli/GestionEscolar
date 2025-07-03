<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AlumnosDebitoConsulta.aspx.cs" Inherits="AlumnosDebitoConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="ibox-content" style="background-color: #FFFFFF">

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
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Nombre del Alumno</label><div class="col-md-6">
                                        <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>
                                    </div>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkBajas" runat="server" />
                                <label class="control-label col-md-2">
                                    Filtrar solo Bajas</label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkActivar" runat="server" />
                                <label class="control-label col-md-2">
                                    Filtrar para Activar</label>
                            </div>


                            <hr class="hr-line-dashed" />
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-0">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                        OnClick="btnAplicar_Click" />
                                </div>
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
                            <Columns>

                                <%--                            <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeId" runat="server" Text='<%# Eval("adeId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dni">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeDNITitular" runat="server" Text='<%# Eval("adeDNITitular") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Titular Tarjeta">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeApeNom" runat="server" Text='<%# Eval("adeApeNom") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alumno">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="aluNombre" runat="server" Text='<%# Eval("aluNombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CBU">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeCBU" runat="server" Text='<%# Eval("adeCBU") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeCelular" runat="server" Text='<%# Eval("adeCelular") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Fecha Inicio" DataField="adeFchInicio" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                                <asp:TemplateField HeaderText="Fecha Baja">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeFchBaja" runat="server" Text='<%# Eval("adeFchBaja") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usuario Baja">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeUsuarioBaja" runat="server" Text='<%# Eval("Apellido") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeId" runat="server" NavigateUrl='<%# "AlumnosDebitoActivacion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("adeId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dni">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeDNITitular" runat="server" NavigateUrl='<%# "AlumnosDebitoActivacion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("adeDNITitular") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Titular Tarjeta">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeApeNom" runat="server" NavigateUrl='<%# "AlumnosDebitoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("adeApeNom") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alumno">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="aluNombre" runat="server" NavigateUrl='<%# "AlumnosDebitoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("aluNombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CBU">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeCBU" runat="server" NavigateUrl='<%# "AlumnosDebitoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("adeCBU") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeCelular" runat="server" NavigateUrl='<%# "AlumnosDebitoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("adeCelular") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Fecha Inicio" DataField="adeFchInicio" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                                <asp:TemplateField HeaderText="Fecha Baja">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeFchBaja" runat="server" NavigateUrl='<%# "AlumnosDebitoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("adeFchBaja") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usuario Baja">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="adeUsuarioBaja" runat="server" NavigateUrl='<%# "AlumnosDebitoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"adeId").ToString() %>' Text='<%# Eval("Apellido") %>' />
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


        <div class="ibox-content">
            <div class="table-responsive">
                <asp:GridView ID="gridtemp" runat="server" GridLines="None" CssClass="table table-striped"
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeId" runat="server" Text='<%# Eval("adeId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI Titular" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeDNITitular" runat="server" Text='<%# Eval("adeDNITitular") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Titular Tarjeta" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeApeNom" runat="server" Text='<%# Eval("adeApeNom") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Alumno" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="aluNombre" runat="server" Text='<%# Eval("aluNombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CBU" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeCBU" runat="server" Text='<%# Eval("adeCBU") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Celular" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeCelular" runat="server" Text='<%# Eval("adeCelular") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Inicio" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeFchInicio" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" runat="server" Text='<%# Eval("adeFchInicio") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Baja" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeFchBaja" runat="server" Text='<%# Eval("adeFchBaja") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario Baja" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="adeUsuarioBaja" runat="server" Text='<%# Eval("adeUsuarioBaja") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Link" Visible="false" HeaderText="AlumnosDebitos" CommandName="Ver" Text="Ver" HeaderStyle-Width="100">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                    </Columns>
                    <FooterStyle HorizontalAlign="NotSet" />
                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#CCCCFF" />
                </asp:GridView>
            </div>
        </div>


        <br>
        <div class="row">
            <div class="col-sm-12">
                <div class="form-group">
                    <asp:Button ID="ListadoDebito" class="btn btn-w-m btn-warning" runat="server" Text="Imprimir" OnClick="btnImprimir" />

                    <asp:Button ID="Exportar" Style="background-color: firebrick" Visible="true" runat="server" Text="Exportar a Excel" CssClass="btn btn-w-m btn-info" formnovalidate="formnovalidate" OnClick="Exportar_Click" />

                </div>
            </div>
        </div>

    </div>

</asp:Content>
