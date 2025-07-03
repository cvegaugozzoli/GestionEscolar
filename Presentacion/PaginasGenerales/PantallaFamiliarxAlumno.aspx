<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="PantallaFamiliarxAlumno.aspx.cs" Inherits="PantallaFamiliarxAlumno" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="#CC0000" Font-Bold="True" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="AluId" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-12">

            <div class="ibox-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset class="form-horizontal">
                            <div class="form-group">
                                <label class="control-label col-md-1">Alumno:</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="HijosId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="HijosId_SelectedIndexChanged" ></asp:DropDownList>
                                </div>

                                <label class="control-label col-md-2">
                                    Año de Cursado</label><div class="col-md-2">
                                        <asp:TextBox ID="AnioCursado" type="text" class="form-control" required="" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                            AutoPostBack="false"></asp:TextBox>
                                    </div>
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
                <h4>   <label id="lblTituloTabla" runat="server" class="control-label col-md-2">Datos del Alumno | </label></h4>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="GrillaHijos" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="GrillaHijos_RowDataBound" OnRowCommand="GrillaHijos_RowCommand"
                        PageSize="50" AllowPaging="True" OnPageIndexChanging="GrillaHijos_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" Text='<%# Eval("Alumno") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Dni" runat="server"  Text='<%# Eval("Dni") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Curso">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Curso") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="TipoCarrera" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="TC" Visible="false" runat="server" Text='<%# Eval("TipoCarrera") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Carrera">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" Text='<%# Eval("Carrera") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:ButtonField ButtonType="Link" HeaderText="Calificaciones" CommandName="Ver" Text="Ver" HeaderStyle-Width="100" />

                        </Columns>


                        <FooterStyle HorizontalAlign="NotSet" />


                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                    </asp:GridView>
                </div>
            </div>
                        <asp:Label ID="lblMjeError2" runat="server" Text="" ForeColor="#CC0000" Font-Bold="True" Font-Size="Medium"></asp:Label>

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
