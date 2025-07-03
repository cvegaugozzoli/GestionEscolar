<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="Chequeras.aspx.cs" Inherits="Chequeras" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblInsId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-12" style="background-color: #FFFFFF">

            <div class="ibox-content" style="background-color: #FFFFFF">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-row" style="background-color: #FFFFFF">
                            <div class="form-group col-md-3">
                                <label class="control-label">Nivel</label>
                                <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label runat="server" class="control-label">Nivel/Carrera</label>
                                <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" required="" class="form-control m-b" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Plan Estudio</label>
                                <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Curso</label>
                                <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="form-row" style="background-color: #FFFFFF">
                            <div class="form-group col-md-2">
                                <label class="control-label">Año de Cursado</label>
                                <asp:TextBox ID="AnioCursado" type="text" class="form-control" required="" BorderColor="Silver" runat="server" AutoPostBack="true" placeholder="Buscar por Año" OnTextChanged="AnioCursado_TextChanged"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Tipo Concepto</label>
                                <asp:DropDownList ID="ddlTipoConc" runat="server" required="" BorderColor="Silver" class="form-control m-b" AutoPostBack="true" Enabled="true" OnSelectedIndexChanged="ddlTipoConc_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Concepto</label>
                                <asp:DropDownList ID="ddlConc" runat="server" required="" BorderColor="Silver" class="form-control m-b" Enabled="true"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-2">
                                <label class="control-label">Desde Cuota</label>
                                <asp:DropDownList ID="ddlDesde" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-2">
                                <label class="control-label">Hasta Cuota </label>
                                &nbsp;<asp:DropDownList ID="ddlHasta" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <hr class="hr-line-dashed" />


                    </ContentTemplate>
                </asp:UpdatePanel>



                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" formnovalidate="formnovalidate" runat="server" Text="Salir" OnClick="btnCancelar_Click" />
                    </div>
                </div>
                <br />

                <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
            </div>
        </div>
    </div>
 <div class="ibox-content">
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title" runat="server" id="CantReg" visible="false">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
           
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota1">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink1" runat="server" Text='<%# Eval("1") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota2">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink2" runat="server" Text='<%# Eval("2") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota3">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink3" runat="server" Text='<%# Eval("3") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota4">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink4" runat="server" Text='<%# Eval("4") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota5">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink5" runat="server" Text='<%# Eval("5") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota6">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink6" runat="server" Text='<%# Eval("6") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota7">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink7" runat="server" Text='<%# Eval("7") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota8">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink8" runat="server" Text='<%# Eval("8") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota9">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink9" runat="server" Text='<%# Eval("9") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota10">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="HyperLink10" runat="server" Text='<%# Eval("10") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                        <FooterStyle HorizontalAlign="NotSet" />
                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                    </asp:GridView>
                </div>
                <div class="row">
                    &nbsp;<asp:Button ID="btnSeleccionarTodo" class="btn btn-w-m btn-danger" runat="server" Text="Seleccionar Todo"
                        OnClick="btnSeleccionarTodo_Click" Visible="false" />
                    <br />
                    <br />
                </div>

                <div class="form-row" style="background-color: #FFFFFF">
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-0">
                            <asp:Button ID="btnImprimir" class="btn btn-w-m btn-primary" Visible="false" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" />
                        </div>
                    </div>
                </div>
           
            <div>
                <asp:Label ID="lblMjeTabla" runat="server" Text="" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>
    </div>
 </div>
</asp:Content>
