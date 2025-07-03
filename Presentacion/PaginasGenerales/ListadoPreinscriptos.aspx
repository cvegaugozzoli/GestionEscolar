<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ListadoPreinscriptos.aspx.cs" Inherits="ListadoPreinscriptos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="ibox-content">


        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblInsId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
            <div class="panel panel-success">
                <div class="panel-heading" style="font-size: medium; font-weight: bold">
                    Filtro
                </div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="form-group col-md-2">
                                    <label class="control-label">Nivel</label>
                                    <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-2">
                                    <label class="control-label">Carrera</label>
                                    <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-3">
                                    <label class="control-label ">Plan Estudio</label>
                                    <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-3">
                                    <label class="control-label">Curso</label>
                                    <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-2">
                                    <label class="control-label ">Año de Cursado</label>
                                    <asp:TextBox ID="AnioCursado" type="text" class="form-control" required="" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                        AutoPostBack="false" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                                </div>


                                <%--  <div class="form-group col-md-3" >
                            <label class="control-label">Tipo de Conceptos</label>
                            <asp:DropDownList ID="ConTipoId" runat="server" BorderColor="Silver" class="form-control m-b" AutoPostBack="True" OnSelectedIndexChanged="ConTipoId_SelectedIndexChanged"></asp:DropDownList>
                        </div>--%>
                                <div class="form-group col-md-3">
                                    <label class="control-label">Conceptos</label>
                                    <asp:DropDownList ID="ConceptoId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ConceptoId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-3">
                                    <br />
                                    <asp:CheckBox ID="CheckSoloRinde" Text="&nbsp;Solo Rinde" runat="server" AutoPostBack="true" OnCheckedChanged="CheckSoloRinde_CheckedChanged" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="form-row" style="background-color: #FFFFFF">
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-0">
                                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>




        <div class="row" style="background-color: #FFFFFF">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="NivelID" EventName="SelectedIndexChanged" />
                </Triggers>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="curId" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="form-row">
            <div class="ibox-content">
                <%--   <div class="ibox-title">
                    <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                </div>--%>
                <div class="ibox-content">
                    <div class="table-responsive">
                        <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                            PageSize="20" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="IC" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alumno">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" Text='<%# Eval("Alumno") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" Text='<%# Eval("Dni") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Curso">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Curso") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TipoCarrera" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="TipoCarrera" runat="server" Text='<%# Eval("TipoCarrera") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preinscripción" Visible="true">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="AnioCursado" runat="server" Text='<%# Eval("AnoCursado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relación" Visible="true">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Afiliación" runat="server" Text='<%# Eval("Afiliación") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre" Visible="true">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="NombreAfiliación" runat="server" Text='<%# Eval("NombreAfiliación") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Usuario" Visible="true" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="ApellidoP" runat="server" Text='<%# Eval("ApellidoP") + " " + Eval("NombreP")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:ButtonField ButtonType="Link" CommandName="Add" Text="Ver" HeaderText="Comprobante" />
                                <%--     <asp:ButtonField Visible="false" ButtonType="Link" HeaderText="Calificaciones" CommandName="Ver" Text="Ver" HeaderStyle-Width="100">

                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>--%>


                                <%--  <asp:TemplateField HeaderText=" Eliminar">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                        OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                        OnClick="btnEliminarCancelar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>


                            <FooterStyle HorizontalAlign="NotSet" />


                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#CCCCFF" />
                        </asp:GridView>
                    </div>
                </div>

                <%--      <div class="form-group">
                <div class="form-group">
                    <asp:Label runat="server" ID="LblEC" Text="Espacio Curricular: " class="control-label col-md-2"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="EspCurBuscarId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                        </asp:DropDownList>
                    </div>
                </div>--%>

                <div class="form-group">
                    <asp:Button ID="ListadoxCurso" class="btn btn-w-m btn-warning" runat="server" Text="Imprimir" OnClick="btnImprimir" />
                </div>


                <div class="form-group">
                    <asp:Label ID="lblMensajeError2" runat="server" Text="" Font-Bold="True" ForeColor="#FF3300" Font-Size="Medium"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
