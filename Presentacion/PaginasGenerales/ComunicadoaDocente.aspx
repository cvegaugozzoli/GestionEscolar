<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ComunicadoaDocente.aspx.cs" Inherits="ComunicadoaDocente" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <asp:TextBox ID="TextIdAlu" BorderColor="Silver" type="string" class="form-control" runat="server" Visible="false"></asp:TextBox>
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>

    <label class="control-label col-md-10">Busqueda del Docente</label>
    <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />


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
                    <asp:Button ID="Button1" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                        aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                    <asp:Button ID="btnCancelarAlumno" formnovalidate="formnovalidate " class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
                    <%--  <asp:Button ID="btnRegistrar" class="btn btn-w-m btn-primary" runat="server" Text="Nueva Sanción" OnClick="btnRegistrar_Click" />--%>


                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                    <asp:CheckBox ID="chkTodos" runat="server" Text="Todos los familiares" Font-Bold="True" Font-Size="Medium" />

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
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("docId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Apellido" runat="server" OnClick="redirectToFB()" Text='<%# Eval("_apellido") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Nombre" runat="server" Text='<%# Eval("_nombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="DNI" runat="server" Text='<%# Eval("_doc") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mail">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Mail" runat="server" Text='<%# Eval("_mail") %>' />
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
    <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>



    <div class="col-sm-12">
        <br />
        <label class="control-label col-md-10">Familiar Seleccionado</label>
        <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>


    <div class="col-sm-12">
        <div class="ibox-content">
            <div class="form-inline">

                <asp:Label class="control-label col-md-1" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="famApellido" BackColor="#ccff99" ForeColor="Black" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>

                <asp:Label class="control-label col-md-1" ID="lblMail" runat="server" Text="Mail: " Font-Bold="true"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="Mail" BorderColor="Silver" BackColor="#ccff99" ForeColor="Black" type="string" class="form-control" runat="server"></asp:TextBox>
                </div>

                <asp:Label class="control-label col-md-1" ID="lblAsunto" runat="server" Text="Asunto:" Font-Bold="true"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="Asuntotxt" required="" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <br />
            <asp:Label class="control-label col-md-1" ID="lblMje" runat="server" Text="Mensaje:" Font-Bold="true"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="Mje" BorderColor="Silver" type="" required="" class="form-control" runat="server" Enabled="true" TextMode="MultiLine" Height="100px"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />


            <br />
            <br />
        </div>
    </div>

    <div class="row" align="right">
        <div class="col-sm-10">

            <asp:Button ID="btnEnviar" class="btn btn-w-m btn-primary" Text="Enviar" runat="server" OnClick="btnEnviar_Click" />
        </div>
    </div>

    <div class="row" align="left">
        <asp:Label ID="lblCorreo" runat="server" Font-Bold="True" ForeColor="#3333FF"></asp:Label>

    </div>


    </div>

</asp:Content>

