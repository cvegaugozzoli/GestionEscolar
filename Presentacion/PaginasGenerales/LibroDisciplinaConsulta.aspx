<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="LibroDisciplinaConsulta.aspx.cs" Inherits="LibroDisciplinaConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <asp:TextBox ID="TextIdAlu" BorderColor="Silver" type="string" class="form-control" runat="server" Visible="false"></asp:TextBox>
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>

    <label class="control-label col-md-10">Sección Busqueda</label>
    <hr class="pg2-titl-bdr-btm" width="100%" />


    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="col-sm-10">
                <div class="form-inline">
                    <br />
                    <label class="control-label col-md-2">
                        Buscar por:<br />
                    </label>
                    <div class="col-md-6">
                        <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info radio-inline" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                            <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                            <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="col-sm-8">
            <div class="form-inline">
                <div class="col-md-4">
                    <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="col-md-8">
                    <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                        aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                    <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
                    <asp:Button ID="btnRegistrar" class="btn btn-w-m btn-primary" runat="server" Text="Nueva Sanción" OnClick="btnRegistrar_Click" />

                    <br />
                    <br />

                </div>
            </div>
        </div>
    </div>


    <div class="form-group">

        <asp:Label ID="lblMensajeBuscar" Style="background-color: #FFFFFF; color: #FF3300; font-weight: bold;" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox collapsed">
            <%--   <div class="collapse" id="collapseExample">--%>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>


                    <div class="ibox-title">
                        <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros2" runat="server" Text=""></asp:Label></h5>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="GrillaBuscar" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="GrillaBuscar_RowDataBound" OnRowCommand="GrillaBuscar_RowCommand"
                            PageSize="5" AllowPaging="True" OnPageIndexChanging="GrillaBuscar_PageIndexChanging">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Select" />
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Nombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Doc" runat="server" Text='<%# Eval("Doc") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Legajo">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Legajo" runat="server" Text='<%# Eval("LegajoNumero") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Activo">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Left" />

                            <PagerSettings Position="Top" />
                            <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                        </asp:GridView>

                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="GrillaBuscar" />
                </Triggers>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                </Triggers>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <%--  </div>--%>



    <div class="col-sm-12">
        <br />
        <label class="control-label col-md-10">Alumno Seleccionado</label>
        <hr class="pg2-titl-bdr-btm" width="100%" />
    </div>

    <div class="row" style="background-color: #FFFFFF">
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <asp:Label class="control-label col-md-1" ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Label class="control-label col-md-1" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                        <br />
                    </div>

                    <%-- <asp:Label class="control-label col-md-1" ID="LblLegajo" runat="server" Text="Legajo Nro: " Font-Bold="true"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="aluLegajoNumero" BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>--%>
                    <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
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

                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="DNI" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("DNI") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Sancion">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="TipoSancion" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("TipoSancionDesc") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Fecha" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Fecha") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Curso">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Curso") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Solicitante">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Solicitante" runat="server" NavigateUrl='<%# "LibroDisciplinaRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Solicitante") %>' />
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

                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

