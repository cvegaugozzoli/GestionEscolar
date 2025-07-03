<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InscripcionExamenRegistracion.aspx.cs" Inherits="InscripcionExamenRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">

        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="ibox-content">

            <label class="control-label col-md-12">Sección Busqueda</label>
            <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />

            <br />
            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-12" style="background-color: #FFFFFF">
                    <label>Buscar por:&nbsp;&nbsp;&nbsp; </label>
                    <asp:RadioButtonList AutoPostBack="true" CssClass="form-check form-check-inline" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                        <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                        <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-4" style="background-color: #FFFFFF">
                    <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-8" style="background-color: #FFFFFF">
                    <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                        aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                    <%--    &nbsp;<asp:Button ID="btnNuevoAlumno" class="btn btn-w-m btn-primary" runat="server" Text="Nuevo" OnClick="btnNuevoAlumno_Click" />--%>
                    &nbsp;<asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>


            <div class="form-row">
                <div class="ibox collapsed">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                        </Triggers>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        <ContentTemplate>
                            <div class="ibox-title" runat="server" id="CanReg" visible="false">
                                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros2" runat="server" Text=""></asp:Label></h5>
                            </div>

                            <div class="table-responsive">
                                <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                                    AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                    PageSize="5" OnPageIndexChanging="Grilla_PageIndexChanging" AllowPaging="True" Width="100%">
                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                    <Columns>

                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Ver" />
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
                                    <SelectedRowStyle BackColor="#CCCCFF" />
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />

                                    <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                                </asp:GridView>

                            </div>

                        </ContentTemplate>

                        <Triggers>
                            <asp:PostBackTrigger ControlID="Grilla" />
                            <asp:PostBackTrigger ControlID="btnCancelarAlumno"></asp:PostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>

            <asp:TextBox ID="aluId" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
            <asp:TextBox ID="icuId" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
            <asp:TextBox ID="AnioInsCursado" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>

            <label>Alumno Seleccionado</label>
            <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
            <br />

            <div class="row">
                <div class="form-group col-md-4">
                    <asp:Label class="col-form-label" ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="aludni" BorderColor="Silver" type="string" class="form-control" BackColor="#006699" ForeColor="White" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <asp:Label class="col-form-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="aluNombre" BorderColor="Silver" BackColor="#006699" ForeColor="White" type="string" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:TextBox ID="TextBox1" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
            </div>


            <br />
            <div class="row">
                <label>Datos del Examen</label>
                <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
                <br />
            </div>
            <div class="row">

                <div class="form-group col-md-3">
                    <label class="control-label ">Año</label>
                    <asp:TextBox ID="txtAnio" class="form-control" AutoPostBack="true" runat="server" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label ">Turno</label>
                    <asp:DropDownList ID="TurnoId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="TurnoId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Nivel</label>
                    <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label col-md-2">Carrera</label>
                    <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Plan Estudio</label>
                    <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group  col-md-3">
                    <label class="control-label ">Curso</label>
                    <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <%-- <div class="form-group col-md-3">
                <label class="control-label ">Espacio Curricular</label>
                <asp:DropDownList ID="escId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
            </div>--%>
                <div class="form-group col-md-3 ">
                    <label class="control-label ">Fecha Examen</label>
                    <tpDatePicker:cuFecha ID="ixaFechaExamen" runat="server" Enabled="false" AllowType="False" />

                </div>

                <div class="form-group col-md-2">

                    <asp:CheckBox ID="ixaActivo" Checked="true" Visible="false" runat="server" />

                </div>
            </div>


            <asp:UpdatePanel ID="PanelRegular" runat="server" Visible="false" UpdateMode="Conditional">
                <%-- <Triggers>
                  <asp:PostBackTrigger ControlID="btnSeleccionarTodo"></asp:PostBackTrigger>
                    <asp:PostBackTrigger ControlID="btnAceptar1"></asp:PostBackTrigger>
                </Triggers>--%>


                <ContentTemplate>
                    <div class="row">
                        <asp:Label ID="tituloMateria" runat="server" Visible="false" Font-Bold="True" Font-Size="Medium">Rendir Regulares</asp:Label>
                        <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="GrillaMateriasReg" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" DataKeyNames="escId2,Nombre2,FormatoDictado2,Regimen2,Condicion2,Id2" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                            Width="100%">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccion2" runat="server" Width="50" />
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="escId">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="escId1" runat="server" Text='<%# Eval("escId2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Nombre1" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Nombre2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Formato Dictado">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="FormatoDictado1" runat="server" Text='<%# Eval("FormatoDictado2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Regimen">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Regimen1" runat="server" Text='<%# Eval("Regimen2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Condicion">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Condicion" runat="server" Text='<%# Eval("Condicion2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id2" runat="server" Text='<%# Eval("Id2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#CCCCFF" />
                            <FooterStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />

                            <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                        </asp:GridView>

                    </div>
                    <div id="alerMAteria" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar una Materia o Unidad Curricular"</h5>
                    </div>
                    <div id="alerMatRepe" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <h5 style="font-weight: bold; font-size: medium">"Existen Materias o Unidades Curriculares que ya fueron insertadas en la Tabla Inscripción.. "</h5>
                    </div>
                    <br></br>
                    <div class="row">
                        <div class="form-group">
                            <asp:Button ID="btnSeleccionarTodo" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo_Click" />
                        </div>
                    </div>
                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="GrillaMateriasReg" />
                    <asp:PostBackTrigger ControlID="btnSeleccionarTodo"></asp:PostBackTrigger>
                    <asp:PostBackTrigger ControlID="btnAceptar1"></asp:PostBackTrigger>
                    <%-- <asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo" EventName="Click"></asp:AsyncPostBackTrigger>
                                        <asp:AsyncPostBackTrigger ControlID="btnAceptar1" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                </Triggers>
            </asp:UpdatePanel>


            <br />

            <asp:UpdatePanel ID="PanelLibre" runat="server" Visible="false" UpdateMode="Conditional">
                <%--<Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo2" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="btnAceptar1" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>--%>

                <ContentTemplate>
                    <div class="row">
                        <asp:Label ID="TituloMaterisLbre" runat="server" Visible="false" Font-Bold="True" Font-Size="Medium">Rendir Libre</asp:Label>
                        <%--            <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />--%>
                        <br />
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="GrillaMateriasLibre" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" DataKeyNames="escId,Nombre,FormatoDictado,Regimen,Condicion,Id" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                            PageSize="5" OnPageIndexChanging="Grilla_PageIndexChanging" AllowPaging="True" Width="100%">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccion3" runat="server" Width="50" />
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="escId">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="escId" runat="server" Text='<%# Eval("escId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Nombre2" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Nombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Formato Dictado">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="FormatoDictado2" runat="server" Text='<%# Eval("FormatoDictado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Regimen">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Regimen2" runat="server" Text='<%# Eval("Regimen") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Condicion">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Condicion" runat="server" Text='<%# Eval("Condicion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <%-- <ItemTemplate>
                                            <asp:LinkButton ID="lbuEliminarIns" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                            <asp:Button ID="btnEliminarAceptarIns" runat="server" Text="Si" Visible="False"
                                                OnClick="btnEliminarAceptarIns_Click" />
                                            <asp:Button ID="btnEliminarCancelarIns" runat="server" Text="No" Visible="False"
                                                OnClick="btnEliminarCancelarIns_Click" />
                                        </ItemTemplate>--%>
                                </asp:TemplateField>
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
                    <asp:PostBackTrigger ControlID="btnAceptar1"></asp:PostBackTrigger>
                    <asp:PostBackTrigger ControlID="btnSeleccionarTodo2"></asp:PostBackTrigger>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo2" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="btnAceptar1" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                </Triggers>
            </asp:UpdatePanel>


            <div class="row">
                <div class="form-group">
                    <asp:Button ID="btnSeleccionarTodo2" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo2_Click" />
                </div>
            </div>
        </div>



        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <Triggers>

                <asp:PostBackTrigger ControlID="btnAceptar1"></asp:PostBackTrigger>
                <%--    <asp:AsyncPostBackTrigger ControlID="btnAceptar1" EventName="Click"></asp:AsyncPostBackTrigger>--%>
            </Triggers>
            <ContentTemplate>
                <div id="alerExito" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                    <asp:Label ID="lblalerExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
                <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="ibox-content">
            <div class="col-sm-12">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" AutoPostBack="True" runat="server" Text="Inscribir" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" AutoPostBack="True" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />

                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnNuevoAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Nuevo Alumno" OnClick="btnNuevoAlumno_Click" Width="100%" />

                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnBorrarTodo" class="btn btn-w-m btn-danger" runat="server" Text="Borrar Todo" OnClick="btnBorrarTodo_Click" Width="100%" />

                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
    </div>

</asp:Content>
