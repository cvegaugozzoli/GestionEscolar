<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InscripcionCursadoRegistracionTerc.aspx.cs" Inherits="InscripcionCursadoRegistracionTerc" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=GridView1] input[type=checkbox]").click(function () {
                if ($(this).is(":checked")) {
                    $("[id*=GridView1] input[type=checkbox]").removeAttr("checked");
                    $(this).attr("checked", "checked");
                }
            });
        });
    </script>


    <asp:TextBox ID="TextIdAlu" BorderColor="Silver" type="string" class="form-control" runat="server" Visible="false"></asp:TextBox>
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblInsId" Visible="false" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblicoId" runat="server" Visible="false" Text=""></asp:Label>
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
                <asp:TextBox ID="TextBuscar" OnTextChanged="btnBuscar_Click" BorderColor="Silver" AutoPostBack="true" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-md-8" style="background-color: #FFFFFF">
                <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                &nbsp;<%--<asp:Button ID="btnNuevoAlumno" class="btn btn-w-m btn-primary" runat="server" Text="Nuevo" OnClick="btnNuevoAlumno_Click" />--%>
                &nbsp;<asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar2_Click" />
            </div>
        </div>
        <div class="form-group col-md-3">
            <asp:Label class="col-form-label" ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aludni" BorderColor="Silver" type="string" class="form-control" BackColor="#006699" ForeColor="White" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <asp:Label class="col-form-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aluNombre" BorderColor="Silver" BackColor="#006699" ForeColor="White" type="string" class="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>

        <div class="form-row">
            <div class="ibox collapsed">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                    </Triggers>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="TextBuscar" EventName="TextChanged" />
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
                        <asp:AsyncPostBackTrigger ControlID="TextBuscar" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>


      

            <label class="control-label">Inscripción del Alumno</label>
            <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />

        <div class="form-row">

            <div class="form-row" style="background-color: #FFFFFF">
                <div class=" form-group  col-md-2">
                    <label class="control-label">Año Cursado</label>
                    <asp:TextBox ID="icuAnioCursado" type="number" BorderColor="Silver" step="1" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="icuAnioCursado_TextChanged"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Nivel</label>
                    <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Carrera</label>
                    <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group col-md-3">
                    <label class="control-label">Plan Estudio</label>
                    <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Curso</label>
                    <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group  col-md-2">
                    <label class="control-label ">Fecha Inscripcion</label>
                    <tpDatePicker:cuFecha ID="icuFechaInscripcion" bordercolor="Silver" runat="server" Enabled="true" allowtype="False" />
                </div>

                <div class="form-group col-md-3" runat="server" visible="false" id="CondicionMostrar">
                    <label class="control-label">Condición</label>
                    <asp:DropDownList ID="CondicionId" runat="server" AutoPostBack="true" BorderColor="Silver" class="form-control" Enabled="true"></asp:DropDownList>
                </div>

            </div>
            <div class="col-sm-12" style="background-color: #FFFFFF">

                <div class="row">
                    <div id="alerError3" runat="server" class="alert alert-danger  alert-dismissable" visible="false">
                        <asp:Label ID="lblError3" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
            </div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                <ContentTemplate>
                    <div class="form-row">
                        <div class="ibox collapsed">
                            <asp:Label ID="tituloMateria" runat="server" Visible="false" Font-Bold="True" Font-Size="Medium">Materias de la Carrera</asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">

                                <Triggers>
                                    <asp:PostBackTrigger ControlID="GrillaMaterias" />

                                    <asp:AsyncPostBackTrigger ControlID="btnAgregarMateria" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo" EventName="Click" />--%>
                                    <asp:PostBackTrigger ControlID="GrillaMaterias" />

                                </Triggers>
                                <ContentTemplate>

                                    <div class="table-responsive">
                                        <asp:GridView ID="GrillaMaterias" runat="server" GridLines="None" CssClass="table table-striped"
                                            AutoGenerateColumns="False" DataKeyNames="Id,Nombre,FormatoDictado,Regimen" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
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
                                                <asp:TemplateField HeaderText="Formato Dictado">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="FormatoDictado" runat="server" Text='<%# Eval("FormatoDictado") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Regimen">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Regimen" runat="server" Text='<%# Eval("Regimen") %>' />
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
                                    <br />
                                    <div class="form-inline">
                                        <div class="form-group col-2">
                                            <asp:Button ID="btnSeleccionarTodo" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-info" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo_Click" />
                                        </div>
                                        <div class="form-group col-2">
                                            <asp:Button ID="btnAgregarMateria" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Inscribir" OnClick="btnAgregarMateria_Click" />
                                        </div>
                                    </div>

                                    <div class="ibox-title" runat="server" id="TituloCondición" visible="false">
                                        <h4><a class="collapse-link">Observaciones de Materias donde no se realizó la inscripción</a></h4>
                                    </div>

                                    <div class="table-responsive">
                                        <asp:GridView ID="GridErrores" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="lblAlumno3,lblObservaciones" Width="100%" CellPadding="4" CssClass="table table-responsive table-striped " runat="server" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>

                                                <asp:BoundField DataField="lblAlumno3" HeaderText="Alumno" />
                                                <asp:BoundField DataField="lblObservaciones" HeaderText=" Observaciones o Correlativas que no cumple para actualizar condición " />


                                            </Columns>
                                            <EditRowStyle BorderStyle="Solid" BorderWidth="1" BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                            <HeaderStyle BackColor="#1C5E55" HorizontalAlign="center" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1" Font-Bold="True" ForeColor="White" />
                                            <%-- <FooterStyle HorizontalAlign="Left" />--%>

                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle HorizontalAlign="left" BorderStyle="Solid" BorderWidth="1" BackColor="#E3EAEB" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />


                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />


                                        </asp:GridView>
                                    </div>

                                </ContentTemplate>

                                <Triggers>



                                    <%--<asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                                    <asp:PostBackTrigger ControlID="GrillaMaterias" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo" EventName="Click" />--%>
                                    <asp:PostBackTrigger ControlID="GrillaMaterias" />
                                    <asp:PostBackTrigger ControlID="GrillaMaterias" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <br />

                    <div class="form-row">
                        <div class="ibox collapsed">
                            <asp:Label ID="TituloMaterisIns" runat="server" Visible="false" Font-Bold="True" Font-Size="Medium">Materias Inscriptas </asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAgregarMateria" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:PostBackTrigger ControlID="GrillaMateriaConfirmar" />
                                </Triggers>
                                <ContentTemplate>

                                    <div class="table-responsive">
                                        <asp:GridView ID="GrillaMateriaConfirmar" runat="server" GridLines="None" CssClass="table table-striped"
                                            AutoGenerateColumns="False" DataKeyNames="escId,Nombre,FormatoDictado,Regimen,Id,Condicion,AnoCursado" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                            PageSize="5" OnPageIndexChanging="GrillaMateriaConfirmar_PageIndexChanging" AllowPaging="FALSE" Width="100%">
                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Fila">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ForeColor="Black" ID="Fila" runat="server" Text='<%# Container.DataItemIndex + 1%>' />
                                                    </ItemTemplate>
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
                                                <asp:TemplateField HeaderText="Condición">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Condicion" runat="server" Text='<%# Eval("Condicion") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Año Cursado">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="AnoCursado" runat="server" Text='<%# Eval("AnoCursado") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbuEliminarIns" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                                        <asp:Button ID="btnEliminarAceptarIns" runat="server" Text="Si" Visible="False"
                                                            OnClick="btnEliminarAceptarIns_Click" />
                                                        <asp:Button ID="btnEliminarCancelarIns" runat="server" Text="No" Visible="False"
                                                            OnClick="btnEliminarCancelarIns_Click" />
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
                                    <%--<asp:PostBackTrigger ControlID="GrillaMaterias" />--%>
                                    <asp:AsyncPostBackTrigger ControlID="btnAgregarMateria" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:PostBackTrigger ControlID="GrillaMateriaConfirmar" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-3">
                            <asp:Label class="control-label" ID="lblMateriaInsc" runat="server" Font-Bold="true" Visible="false">Materias por inscribir</asp:Label>
                            <asp:TextBox ID="txtcELESTE" BackColor="LightBlue" ForeColor="LightBlue" BorderColor="Silver" Visible="false" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <%--<label class="control-label col-md-2">Activo</label>--%>
                        <div class="col-md-1">
                            <asp:CheckBox ID="icuActivo" Visible="false" BorderColor="Silver" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAgregarMateria" EventName="Click" />
                    <asp:PostBackTrigger ControlID="GrillaMateriaConfirmar" />
                </Triggers>
                <ContentTemplate>
                    <div class="ibox-content">
                        <div class="row">
                            <div id="alerError2" runat="server" class="alert alert-danger  alert-dismissable" visible="false">
                                <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="ibox collapsed">
                <div class="form-row">


                    <asp:Button ID="btnLimpiar" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Limpar Todo" OnClick="btnLimpiar_Click" />
                    <asp:Button ID="btnSalir" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-primary" runat="server" Text="Salir" OnClick="btnSalir_Click" />
                    <asp:Button ID="btnAlumno" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-info" runat="server" Text="Limpar Alumno" OnClick="btnAlumno_Click" />

                </div>
            </div>
        </div>

        <asp:Panel ID="PanelConcepto" runat="server" Visible="false" ForeColor="#333333">

            <div class="col-sm-12" style="background-color: #FFFFFF">
                <br />
                <label class="control-label ">
                    Conceptos a Pagar</label>
                <%--  <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />--%>
                <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
                <br />
                <div class="form-row" style="background-color: #FFFFFF">
                    <div class="form-group col-md-3">
                        <label class="control-label">
                            Tipo de Conceptos</label>
                        <asp:DropDownList ID="ConTipoId" runat="server" AutoPostBack="True" BorderColor="Silver" class="form-control m-b" OnSelectedIndexChanged="ConTipoId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label">
                            Conceptos</label>
                        <asp:DropDownList ID="ConceptoId" runat="server" AutoPostBack="True" BorderColor="Silver" class="form-control m-b" Enabled="True" OnSelectedIndexChanged="ConceptoId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label">
                            Beca</label>
                        <asp:DropDownList ID="BecaId" runat="server" AutoPostBack="True" BorderColor="Silver" class="form-control m-b" Enabled="true">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label id="lblCuota" runat="server" class="control-label" visible="false">
                            Cuota</label>
                        <asp:DropDownList ID="CuotaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="false" Visible="false">
                            <asp:ListItem Value="0">Todas</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="ibox-content">
                <asp:Button ID="btnAgregar" class="btn btn-w-m btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            </div>
            <div class="row">
                <div class="col-sm-12">

                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:GridView ID="GrillaConcepto" runat="server" DataKeyNames="Id,conId,cntId,TipoConcepto,Concepto,Importe,Beca,BecId,NroCuota,FchInscripcion" GridLines="None" CssClass="table table-striped"
                                AutoGenerateColumns="False">
                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Seleccionar" Visible="false" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                    <asp:BoundField DataField="conId" HeaderText="conId" Visible="false" />
                                    <asp:BoundField DataField="cntId" HeaderText="cntId" Visible="false" />
                                    <asp:BoundField DataField="TipoConcepto" HeaderText="Tipo Concepto" />
                                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                                    <asp:BoundField DataField="NroCuota" HeaderText="Nro Cuota" />
                                    <asp:BoundField DataField="Importe" HeaderText="Importe" />
                                    <asp:BoundField DataField="AnioLectivo" HeaderText="AnioLectivo" />
                                    <asp:BoundField DataField="Beca" HeaderText="Beca" />
                                    <asp:BoundField DataField="BecId" HeaderText="BecaId" Visible="false" />
                                    <asp:BoundField DataField="FchInscripcion" HeaderText="FchInscripcion" Visible="false" />

                                    <%--   <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                        OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                        OnClick="btnEliminarCancelar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                                    <asp:BoundField DataField="Estado" Visible="false" HeaderText="Estado" />
                                </Columns>
                                <FooterStyle HorizontalAlign="NotSet" />

                                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#CCCCFF" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>


            <%--<div class="col-sm-12">
        <div class="form-raw">
            <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Inscribir" OnClick="btnAceptar_Click" />
        </div>
    </div>--%>


            <div class="form-row">
                <asp:Label ID="LblMjeGridConcepto" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#CC0000"></asp:Label>

            </div>
            <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
            <div class="form-group">
                <div id="alerConcepto" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe ingresar al menos un Conceto.."
        ont-size: medium">"Debe seleccionar una carrera"</h5>
                </div>

                <div id="alerCurso" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un curso.."</h5>
                </div>
                <div id="alerAlumno" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"No ingresó ningún alumno"</h5>
                </div>
                <div id="alerNivel" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un nivel"</h5>
                </div>
                <div id="alerPlan" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un Plan"</h5>
                </div>

                <div id="alerCarrera" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar una Carrera"</h5>
                </div>

                <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>




                <div id="alerEspCur" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar seleccionar y agregar Espacios Curriculares"</h5>
                </div>
                <div id="alerAnio" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Debe ingresar Año Lectivo"</h5>

                </div>
                <div id="alerInscripción2" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Se inscribió con exito al alumno en ese curso o Materia.."</h5>
                </div>
                <div id="alerInscripción" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                    <h6 style="font-weight: bold; font-size: small">"Se ingresaron los conceptos de la tabla"</h6>
                </div>
                <div id="alerErrorConcepto" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"No existe Concepto para ese Año Lectivo.."</h5>
                </div>

                <div id="alerErrorInsc" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"El Alumno ya estaba inscripto en ese curso.."</h5>
                </div>
                <div id="alerRepetido" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Concepto ya existente.. Solo se realizó la inscripción de los conceptos que no existían"</h5>
                </div>
                <div id="alerConceptoyaIngresado" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Concepto ya ingresado a la tabla.."</h5>
                </div>
                <div id="alerConceptoyaRegistrado" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Concepto existente para ese Alumno.."</h5>
                </div>
                <div id="alerConceptoyaRegistrado2" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                    <h5 style="font-weight: bold; font-size: medium">"Solo se incorporaron cuotas no cargadas.."</h5>
                </div>
            </div>
            <div class="form-row">
                <div class="col-sm-12">

                    <br />

                    <asp:Button ID="btnInscribir" class="btn btn-w-m btn-primary" runat="server" Text="Inscribir" />
                    <%--      OnClick="btnInscribir_Click"--%>

                    <%--            <asp:Button ID="btnRegistarConcepto" class="btn btn-w-m btn-danger" runat="server" Text="Registrar Conceptos" OnClick="btnRegistrarConcepto_Click" Enabled="False" />--%>
            &nbsp;<asp:Button ID="btnPagar" class="btn btn-w-m btn-danger" runat="server" Text="Pagar" OnClick="btnPagar_Click" Enabled="False" />

                    <div id="alerPagar" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                        <h6 style="font-weight: bold; font-size: small">"Seleccione los items a pagar si desea facturar.. "</h6>
                    </div>
                    <br />
                    <div id="alerItems" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                        <h6 style="font-weight: bold; color: red; font-size: small">"No seleccionó ningún items a facturar.. "</h6>
                    </div>
                    <br />
                </div>
            </div>

        </asp:Panel> </div>
        <br />
        <br />
</asp:Content>
