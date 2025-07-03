<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AlumnosDebitoRegistracion.aspx.cs" Inherits="AlumnosDebitoRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row" style="background-color: #FFFFFF">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
        </div>

        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="ibox-content">
                <div class="form-inline">
                    <label>Buscar Alumnos por: </label>
                    <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                        <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                        <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                </div>
            </div>
        </div>


        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="form-inline">
                <div class="form-group col-md-2">
                    <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="Button1" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                    &nbsp;<asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
                </div>
                <%--  <div class="form-group col-md-6">
                <label class="control-label">Año Lectivo:</label>
                <asp:TextBox ID="txtAnioLectivo" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true" OnTextChanged="txtAnioLectivo_TextChanged"></asp:TextBox>
            </div>--%>
            </div>
        </div>

        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="ibox collapsed">
                <%--   <div class="collapse" id="collapseExample">--%>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                    </Triggers>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <ContentTemplate>
                        <br />
                        <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="ibox-title" runat="server" visible="false" id="canRg">
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

                            <br />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="GrillaBuscar" />
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Label ID="lblMjerror2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>

                <%--  </div>--%>

                <div class="col-sm-12">
                    <label class="control-label col-md-12">Alumnos a Cargo</label>
                </div>
                <div class="col-sm-12">
                    <hr class="pg2-titl-bdr-btm" align="left" />
                </div>
            </div>
        </div>
        <div class="ibox-content" runat="server" visible="false">
            <div class="row" style="background-color: #FFFFFF">

                <div class="form-group col-md-3">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>



                </div>

                <div class="form-group col-md-4">
                    <asp:Label class="control-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>

                <%--   <div class="form-group col-md-3">
                <asp:Label class="control-label" ID="lblColegio" runat="server" Text="Colegio: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aluColegio" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            </div>--%>
            </div>
        </div>
        <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>

        <div class="col-sm-8" style="background-color: #FFFFFF">
            <div class="ibox collapsed">
                <div class="form-row">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="table-responsive">
                                <asp:GridView ID="GrillaAlumnos" runat="server" GridLines="None" CssClass="table table-striped" OnRowUpdating="OnRowUpdating"
                                    AutoGenerateColumns="False" DataKeyNames="adeId,aluId,aluNombre,aludni" OnRowEditing="OnRowEditing"
                                    PageSize="10" OnPageIndexChanging="GrillaAlumnos_PageIndexChanging" AllowPaging="FALSE" Width="100%">
                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Fila">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Fila" runat="server" Text='<%# Container.DataItemIndex + 1%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="adeId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" CommandName="Select" ID="adeId" runat="server" Text='<%# Eval("adeId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="aluId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" CommandName="Select" ID="aluId" runat="server" Text='<%# Eval("aluId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="aluNombre" runat="server" OnClick="redirectToFB()" Text='<%# Eval("aluNombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dni">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" CommandName="Select" ID="aludni" runat="server" Text='<%# Eval("aludni") %>' />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Baja" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="adeFchBaja" runat="server" Text='<%# Eval("adeFchBaja") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtadeFchBaja" runat="server" Text='<%# Eval("adeFchBaja") %>' Width="90"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowCancelButton="false"
                                            ItemStyle-Width="150" />

                                        <asp:TemplateField Visible="false">
                                            <EditItemTemplate>
                                                <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                                            </EditItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>

                                        <%--   <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbuEliminarIns" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                            <asp:Button ID="btnEliminarAceptarIns" runat="server" Text="Si" Visible="False"
                                                OnClick="btnEliminarAceptarIns_Click" />
                                            <asp:Button ID="btnEliminarCancelarIns" runat="server" Text="No" Visible="False"
                                                OnClick="btnEliminarCancelarIns_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    </Columns>
                                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#CCCCFF" />
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />

                                    <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                                </asp:GridView>

                            </div>

                        </ContentTemplate>

                        <Triggers>

                            <asp:PostBackTrigger ControlID="GrillaBuscar" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div class="col-sm-12">
            <label class="control-label col-md-12">Titular del Banco</label>
        </div>
        <div class="col-sm-12">
            <hr class="pg2-titl-bdr-btm" align="left" />
        </div>


        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="row" style="background-color: #FFFFFF">

                <div class="form-group col-md-2">
                    <label class="control-label">DNI</label>
                    <asp:TextBox ID="adeDNITitular" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" BackColor="Transparent"
                        BorderColor="Red" ControlToValidate="adeDNITitular" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                        Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Nombre</label>
                    <asp:TextBox ID="adeApeNom" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <label class="control-label" runat="server">Banco</label>
                    <asp:DropDownList ID="BancoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">CBU</label>
                    <asp:TextBox ID="adeCBU" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" BackColor="Transparent"
                        BorderColor="Red" ControlToValidate="adeCBU" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                        Font-Size="Small" ValidationExpression="[0-9]{22,22}" Width="90px"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Celular</label>
                    <asp:TextBox ID="adeCelular" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="background-color: #FFFFFF">



                <div class="form-group col-md-2">
                    <label class="control-label">Lugar de Trabajo</label>
                    <asp:TextBox ID="adeLugarTrabajo" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group col-md-2">
                    <label class="control-label">Mail</label>
                    <asp:TextBox ID="adeMail" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Tipo Cuenta</label>
                    <asp:DropDownList BorderColor="Silver" ID="tcuId" runat="server" class="form-control m-b" Enabled="true">
                        <asp:ListItem Value="1" Selected="True">Cuenta Corriente</asp:ListItem>
                        <asp:ListItem Value="2">Caja de Ahorro</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Fecha de Inicio</label>
                    <asp:TextBox ID="adeFchInicio" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-2" runat="server" visible="false">
                    <label class="control-label">Fecha de Baja</label>
                    <asp:TextBox ID="adeFchBaja" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-2" runat="server" visible="false">
                    <label class="control-label">Fecha de Cobro</label>
                    <asp:TextBox ID="adeFchProbCobro" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div id="alerError1" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblalerError1" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

        </div>

        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar1" formnovalidate="formnovalidate " class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
