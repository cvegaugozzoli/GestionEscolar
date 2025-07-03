<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ListadoBecados.aspx.cs" Inherits="ListadoBecados" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblInsId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-12" style="background-color: #FFFFFF">

            <div class="ibox-content" style="background-color: #FFFFFF">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-row" style="background-color: #FFFFFF">
                            <div class="form-group col-md-3">
                                    <label class="control-label">Nivel</label>
                                    <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                             <div class="form-group col-md-3">
                                <label runat="server" class="control-label">Nivel/Carrera</label>
                                <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" required="" class="form-control m-b" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Plan Estudio</label>
                                <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver"  class="form-control m-b" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Curso</label>
                                <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="form-row" style="background-color: #FFFFFF">
                            <div class="form-group col-md-4">
                                <label class="control-label">Año de Cursado</label>
                                <asp:TextBox ID="AnioCursado" type="text" class="form-control" required="" BorderColor="Silver" runat="server" AutoPostBack="true" placeholder="Buscar por Año" OnTextChanged="AnioCursado_TextChanged"
                                    ></asp:TextBox>
                            </div>
                            <div class="form-group col-md-4">
                                <label class="control-label">Tipo Concepto</label>
                                <asp:DropDownList ID="ddlTipoConc" runat="server" required="" BorderColor="Silver" class="form-control m-b" AutoPostBack="true" Enabled="true" OnSelectedIndexChanged="ddlTipoConc_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-4">
                                <label class="control-label">Concepto</label>
                                <asp:DropDownList ID="ddlConc" runat="server" required="" BorderColor="Silver" class="form-control m-b" Enabled="true"></asp:DropDownList>
                            </div>
                        </div>
                        <hr class="hr-line-dashed" />


                    </ContentTemplate>
                </asp:UpdatePanel>



                <div class="form-inline">
                    <div class="form-group">                       
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                            <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" formnovalidate="formnovalidate" runat="server" Text="Salir" OnClick="btnCancelar_Click" />
                    </div>
                </div>
                <br />

                  <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title" runat="server" id="CantReg" visible="false">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
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
                             <asp:TemplateField HeaderText="Beca">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Beca" runat="server" Text='<%# Eval("PorcBeca") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle HorizontalAlign="NotSet" />
                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                    </asp:GridView>
                </div>
            </div>
              <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group">
                    <div class="col-md-4 col-md-offset-0">
                        <asp:Button ID="btnImprimir" class="btn btn-w-m btn-info" Visible="false" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" />
                    </div>
                </div>
            </div>
            <div>
                <asp:Label ID="lblMjeTabla" runat="server" Text="" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
