<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" EnableEventValidation="true" AutoEventWireup="true" CodeFile="MesaExamenModificar.aspx.cs" Inherits="MesaExamenModificar" %>

<%@ Register Src="../Controles/Particulares/cuFechaHora.ascx" TagName="cuFechaHora" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <%-- <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>

                </div>
            </div>
        </div>--%>


        <div class="row">
            <div class="col-sm-12">
                <%--  <div class="ibox collapsed">               --%>
                <div class="ibox-content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="form-group col-md-1">
                                    <label class="control-label ">Año</label>
                                    <asp:TextBox ID="txtAnio" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-2">
                                    <label class="control-label ">Turno</label>
                                    <asp:DropDownList ID="TurnoId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="TurnoId_SelectedIndexChanged"></asp:DropDownList>

                                </div>

                                <div class="form-group col-md-3">
                                    <label class="control-label ">Fecha Incio Turno</label>
                                    <br />
                                    <tpDatePicker:cuFechaHora ID="txtFchInicio" runat="server" Enabled="true" BorderColor="Silver" />
                                </div>

                                <div class="form-group col-md-3" runat="server" visible="false">
                                    <label class="control-label ">Nivel</label>
                                    <asp:DropDownList ID="NivelID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>

                                </div>

                                <div class="form-group col-md-3">
                                    <label class="control-label ">Carrera</label>
                                    <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>

                                </div>

                                <div class="form-group col-md-3">
                                    <label class="control-label ">Plan Estudio</label>
                                    <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="form-group col-md-3">
                                    <label class="control-label">Curso</label>
                                    <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                </div>


                                <div class="form-group col-md-3">
                                    <label class="control-label">
                                        Esp. Curric.</label>
                                    <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true"></asp:DropDownList>

                                    <%--<asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>--%>
                                </div>

                                <div class="form-group col-md-2">
                                    <label class="control-label ">Activo</label>
                                    <asp:CheckBox ID="meeActivo" runat="server" Checked="True" Enabled="true" BorderColor="Silver"></asp:CheckBox>
                                </div>
                            </div>


                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Modificar"
                                        OnClick="btnAplicar_Click" />
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-w-m btn-danger" runat="server" Text="Salir" OnClick="btnCancelar_Click" Width="100%" />
                                </div>
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnAplicar"></asp:PostBackTrigger>

                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>



        <div class="row">
            <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblalerError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblalerError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

            <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                <asp:Label ID="lblalerExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>


        <div class="ibox-content">

            <label class="control-label col-md-12">Tribunal</label>
            <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />


            <div class="row">
                <div class="form-inline">
                    <br />
                    <div class="col-md-3">
                        <label class="control-label ">
                            Buscar Profesor por:<br />
                        </label>
                    </div>
                    <div class="col-md-4">
                        <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info radio-inline" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                            <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="1">Apellido </asp:ListItem>
                            <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="0"> DNI </asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <br />
                    </div>
                </div>

                <div class="col-sm-8" style="background-color: #FFFFFF">
                    <div class="form-inline">
                        <div class="col-md-4">
                            <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-8">
                            <asp:Button ID="Button2" formnovalidate class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                                aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                            <%--                        <asp:Button ID="btnNuevoAlumno" class="btn btn-w-m btn-primary" runat="server" Text="Nuevo" OnClick="btnNuevoAlumno_Click" />--%>
                            <asp:Button ID="btnCancelarAlumno" formnovalidate class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar2_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-12" style="background-color: #FFFFFF">
                <div class="ibox collapsed">
                    <div class="collapse" id="collapseExample">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="ibox-title">
                                    <h5>Listado |
                                         <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                                </div>
                                <div class="table-responsive">
                                    <asp:GridView ID="GrillaBuscar" runat="server" GridLines="None" CssClass="table table-striped"
                                        AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="GrillaBuscar_RowDataBound" OnRowCommand="GrillaBuscar_RowCommand"
                                        PageSize="10" AllowPaging="True">
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                        <Columns>

                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Select" Visible="false" />
                                            <asp:TemplateField HeaderText="usuId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="usuId" runat="server" Text='<%# Eval("usuId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Apellido">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="Apellido" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Apellido") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Nombre" runat="server" Text='<%# Eval("Nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DNI">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="dni" runat="server" Text='<%# Eval("NombreIngreso") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="perId">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="perId" runat="server" Text='<%# Eval("perId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--   <asp:TemplateField HeaderText="upeId">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="upeId" runat="server" Text='<%# Eval("upeId") %>' />
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
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                            </Triggers>

                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%--<hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />--%>


            <div class="row">

                <%--<asp:TextBox ID="upeId" class="form-control" runat="server" Visible="False" Font-Bold="True"></asp:TextBox>--%>
                <%--<asp:TextBox ID="DocId" class="form-control" runat="server" Visible="False" Font-Bold="True"></asp:TextBox>--%>
                <asp:TextBox ID="txtUsuId" class="form-control" runat="server" Visible="False" Font-Bold="True"></asp:TextBox>

                <div class="form-group col-md-2">
                    <label class="control-label ">Apellido</label>
                    <asp:TextBox ID="ApellidoB" class="form-control" runat="server" Enabled="False" Font-Bold="True"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <label class="control-label ">Nombre</label>
                    <asp:TextBox ID="NombreB" Font-Bold="True" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label ">DNI</label>
                    <asp:TextBox ID="DNIB" Font-Bold="True" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>


                <div class="form-group col-md-2 ">
                    <br />
                    <asp:Button ID="btnAplicarTibunal" class="btn btn-w-m btn-primary" runat="server" Text="Agregar al Tribunal" OnClick="btnAplicarTibunal_Click" />
                </div>
            </div>
 
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <div id="alerExito2" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <asp:Label ID="lblalerExito2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div id="alerError3" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblalerError3" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                  
                        </ContentTemplate>
                     <Triggers>
                                <asp:PostBackTrigger ControlID="GrillaBuscar" />
                            </Triggers>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAplicarTibunal" EventName="Click"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
 </div>

        <div class="ibox-content">
            <div class="row">
                <div class="col-sm-6" style="background-color: #FFFFFF">


                    <asp:UpdatePanel ID="UpdatePaneProf" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <%-- <div class="ibox-title">
                                <h5>Listado |
                                         <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h5>
                            </div>--%>
                            <div class="table-responsive">
                                <asp:GridView ID="GrillaProfTrib" runat="server" GridLines="None" CssClass="table table-striped"
                                    AutoGenerateColumns="False" DataKeyName="Id" PageSize="10" AllowPaging="True">
                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="usuId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" CommandName="Select" ID="usuId" runat="server" Text='<%# Eval("usuId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Apellido">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Apellido" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Apellido") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Nombre" runat="server" Text='<%# Eval("Nombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DNI">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" CommandName="Select" ID="dni" runat="server" Text='<%# Eval("Dni") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado" Width="90">X</asp:LinkButton>
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
                                    <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                                </asp:GridView>

                            </div>

                        </ContentTemplate>
                        <%-- <Triggers>
                            <asp:PostBackTrigger ControlID="GrillaBuscar" />
                        </Triggers>--%>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                        </Triggers>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAplicarTibunal" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>


            </div>
        </div>
    </div>

</asp:Content>
