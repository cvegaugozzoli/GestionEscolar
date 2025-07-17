<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="RegistroAnual.aspx.cs" Inherits="RegistroAnual" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">


    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
                 <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
              <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
 <asp:Label ID="lblTipoCarrera" runat="server" Visible="false" Text=""></asp:Label>
 <asp:Label ID="lblCursoId" runat="server" Visible="false" Text=""></asp:Label>

        </div>

        <div class="col-sm-12">

            <div class="ibox-title">
                <asp:CheckBox ID="CheckCurso" Checked="true" runat="server" AutoPostBack="true" Text="  &nbsp;&nbsp;Registro por Curso " OnCheckedChanged="CheckCurso_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckAlumno" AutoPostBack="true" Text="  &nbsp;&nbsp;Registro por Alumno " Checked="false" runat="server" OnCheckedChanged="CheckAlumno_CheckedChanged" />
                <asp:Label ID="lblCurso" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>
                <asp:Label ID="lblTC" runat="server" Visible="false" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>
                <div class="ibox-tools">
                    <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                </div>
            </div>
            <div class="ibox-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="miPanelCurso" visible="true" runat="server">
                            <div class="panel panel-success">
                                <div class="panel-heading" style="font-size: medium; font-weight: bold">
                                    Curso 
                                </div>
                                <div class="panel-body">
                                    <div class="form-row">
                                        <div class="form-group col-md-2">
                                            <label class="control-label">Carrera</label>
                                            <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                        <div class="form-group col-md-2">
                                            <label class="control-label ">Plan Estudio</label>
                                            <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                        <div class="form-group col-md-3">
                                            <label class="control-label">Curso</label>
                                            <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="control-label">
                                                Año de Cursado</label>
                                            <asp:TextBox ID="AnioCursado" BorderColor="Silver" type="text" class="form-control" runat="server" placeholder="Buscar por Año"
                                                AutoPostBack="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>


                <div id="miPanelAlumno" visible="false" runat="server">

                    <div class="panel panel-success">
                        <div class="panel-heading" style="font-size: medium; font-weight: bold">
                            Alumno 
                        </div>
                        <div class="panel-body">
                            <%--<div class="row mb-12">--%>
                            <div class="col-md-2">
                                <label for="txtAnioLectivo" class="form-label">Año Lectivo:</label>
                                <asp:TextBox ID="anioCur" runat="server" CssClass="form-control" />
                                <div class="form-check mt-2">
                                    <asp:CheckBox ID="chkAplicarAnio" runat="server" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="chkAplicarAnio_CheckedChanged" />
                                    <label class="form-check-label" for="chkAplicarAnio">Aplicar Año</label>
                                </div>
                            </div>
                            <div class="col-md-1"></div>

                            <div class="col-md-2">
                                <label class="form-label">Buscar por:</label>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rbNombre" AutoPostBack="true" Checked="true" runat="server" GroupName="BuscarPor" CssClass="form-check-input" OnCheckedChanged="rbNombre_CheckedChanged" />
                                    <label class="form-check-label" for="rbNombre">Nombre</label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rbDni" AutoPostBack="true" runat="server" GroupName="BuscarPor" CssClass="form-check-input" OnCheckedChanged="rbDni_CheckedChanged" />
                                    <label class="form-check-label" for="rbDNI">DNI</label>
                                </div>
                            </div>
                            <%--  <div class="col-md-2">
                                <label>Buscar:</label>
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" />
                            </div>--%>
                            <div class="col-md-3">
                                <label >Buscar:</label>
                               
                                    <asp:TextBox ID="txtBusqueda" AutoPostBack="true" runat="server" CssClass="form-control" />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success me-2" OnClick="btnBuscarAlumnos_Click" />
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarAlumno_Click" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-12" style="background-color: #FFFFFF">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="GrillaBuscar" />
                        <asp:PostBackTrigger ControlID="btnCancelar"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <ContentTemplate>

                        <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>


                        <div id="pnelAlumnoSeleccionado" visible="false" runat="server">
                            <div class="ibox-content">
                                <div class="row" style="background-color: #FFFFFF">
                                    <label class="control-label col-md-12">Alumno Seleccionado</label>
                                    <div class="form-group col-md-2">
                                        <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <asp:Label class="control-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <asp:Label ID="Label1" runat="server" Text="Curso:" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtCurso" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                    <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="table-responsive">
                            <asp:GridView ID="GrillaBuscar" runat="server" CssClass="table table-striped"
                                AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="GrillaBuscar_RowDataBound" OnRowCommand="GrillaBuscar_RowCommand"
                                PageSize="5" AllowPaging="True" OnPageIndexChanging="GrillaBuscar_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <PagerStyle HorizontalAlign="Left" CssClass="GridPager" BackColor="White" ForeColor="#000066" />
                                <Columns>

                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Select" />
                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Alumno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DNI">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Doc" runat="server" Text='<%# Eval("Dni") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Curso">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Curso" runat="server" Text='<%# Eval("Curso") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Año">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="AnoCursado" runat="server" Text='<%# Eval("AnoCursado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Activo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#006699" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" ForeColor="White" />
                                <FooterStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />

                                <PagerSettings Position="Top" />
                                <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>

                            <br />

                        </div>
                        <asp:Label ID="lblMjerror2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancelar" />
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:PostBackTrigger ControlID="GrillaBuscar"></asp:PostBackTrigger>
                        <asp:PostBackTrigger ControlID="btnCancelar"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>

                </asp:UpdatePanel>


                <fieldset class="form-horizontal">
                    <div class="text-end">
                        <div>
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" />
                        </div>
                        <asp:Label ID="lblMensajeError3" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </div>
                </fieldset>
            </div>
        </div>

      
    </div>

</asp:Content>
