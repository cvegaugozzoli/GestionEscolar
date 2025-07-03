<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CursoListadoCalifxAlumno.aspx.cs" Inherits="CursoListadoCalifxAlumno" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-12">

            <div class="ibox-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset class="form-horizontal">
                            <div class="form-group">
                                <label class="control-label col-md-1">Carrera</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                </div>


                                <label class="control-label col-md-2">Plan Estudio</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <%-- <label class="control-label col-md-1">Campo</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="camId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                                    </div>--%>
                                <label class="control-label col-md-1">Curso</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                </div>



                                <label class="control-label col-md-2">
                                    Año de Cursado</label><div class="col-md-2">
                                        <asp:TextBox ID="AnioCursado" type="text" class="form-control" required="" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                            AutoPostBack="false" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                                    </div>
                            </div>
                            <div class="form-group">
                            <%--    <label class="control-label col-md-2">Espacio Curricular</label>--%>
                             <%--   <div class="col-md-6">
                                    <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true"></asp:DropDownList>
                                </div>--%>
                            </div>
                            <hr class="hr-line-dashed" />

                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <fieldset class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-0">
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                        </div>
                    </div>
                </fieldset>
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
                        PageSize="50" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id"  runat="server" Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
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
                            <asp:ButtonField ButtonType="Link" HeaderText="Calificaciones" CommandName="Ver" Text="Ver" HeaderStyle-Width="100" />


                            <%--  <asp:TemplateField HeaderText="">
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

            <%--  <div class="form-group">
                <div class="form-group">
                    <asp:Label runat="server" ID="LblEC" Text="Espacio Curricular: " class="control-label col-md-2"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="EspCurBuscarId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnNotaxCurso" class="btn btn-w-m btn-warning" runat="server" Text="Notas x Curso" OnClick="btnNotaxCurso_Click" />
                </div>
            </div>--%>
        </div>
    </div>
</asp:Content>
