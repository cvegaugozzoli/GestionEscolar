<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="Recaudacion.aspx.cs" Inherits="Recaudacion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblInsId" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div class="row" style="background-color: #FFFFFF">
        <div class="ibox-content" style="background-color: #FFFFFF">

            <div class="form-row" style="background-color: #FFFFFF">

                <div class="form-group col-md-3">
                    <label class="control-label">Desde:</label>
                    <asp:TextBox ID="txtDesde" required="" type="DateTimePicker" placeholder="dd/mm/aaaa" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <label class="control-label">Hasta:</label>
                    <asp:TextBox ID="txtHasta" type="DateTimePicker" required="" placeholder="dd/mm/aaaa" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                </div>
                <br />
                  <div class="form-group col-md-3">
                      <asp:CheckBox ID="chk_descuentos" AutoPostBack="true" runat="server" OnCheckedChanged="chk_descuentos_CheckedChanged" />
                      <label class="control-label">Solo pagos con descuentos</label>
                  </div>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="ibox-content">
            <div class="form-group">
                <h5>Listar<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h5>
                <asp:Button ID="btnImprimir" class="btn btn-w-m btn-primary" runat="server" Text="Detalle" Visible="true" OnClick="btnImprimir_Click" />
                &nbsp;
                <asp:Button ID="btnResumen" class="btn btn-w-m btn-primary" runat="server" Text="Resúmen Gral." Visible="true" OnClick="btnResumen_Click" />
                &nbsp;
                <%--                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar" OnClick="btnAplicar_Click1" />
                &nbsp;<asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" formnovalidate="formnovalidate" runat="server" Text="Cancelar" OnClick="btnCancelar_Click1" />--%>
            </div>

        </div>



    </div>
    <%--<asp:CheckBox ID="chqFchPago" class="form-check-input" runat="server"
                        AutoPostBack="true" />
                    <label class="form-check-label">Actualizar</label>--%>


    <%--    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title" runat="server" visible="false" id="CanReg"> 
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
                            <asp:TemplateField HeaderText="Fecha Pago">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="FechaPago" runat="server" NavigateUrl='<% %>' Text='<%# Eval("FechaPago") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Concepto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Concepto" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Concepto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo Concepto" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ConceptosTipos" runat="server" NavigateUrl='<% %>' Text='<%# Eval("ConceptosTipos") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NroCuota">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="NroCuota" runat="server" NavigateUrl='<% %>' Text='<%# Eval("NroCuota") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Importe">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Importe" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Importe") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                      <FooterStyle HorizontalAlign="NotSet" />
                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
            <hr />

    <div class="row" style="background-color: #FFFFFF">
        <div class="form-group col-md-4" align="left">
            <br />
        </div>
        <div class="form-group col-md-4" align="left">
        </div>
        <div class="form-group col-md-4" align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<label class="control-label " runat="server" id="lblNombreMatricula" style="font-weight: bold; font-size: medium; color: #1f2548">Matricula:</label>
            <asp:Label ID="lblMatricula" runat="server" Font-Size="medium" Font-Bold="True" ForeColor="#1f2548"></asp:Label>
        </div>
    </div>
    <div class="row" style="background-color: #FFFFFF">
        <div class="form-group col-md-4" align="left">
        </div>
        <div class="form-group col-md-4" align="left">
        </div>
        <div class="form-group col-md-4" align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " runat="server" id="lblNombreCuotas" style="font-weight: bold; font-size: medium; color: #1f2548;">Cuotas:</label>
            <asp:Label ID="lblCuotas" runat="server" Font-Size="medium" Font-Bold="True" ForeColor="#1f2548"></asp:Label>
        </div>
    </div>
    <div class="row" style="background-color: #FFFFFF">
        <div class="form-group col-md-4" align="left">
        </div>
        <div class="form-group col-md-4" align="left">
        </div>
        <div class="form-group col-md-4" align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " runat="server" id="lblNombreTotal" style="font-weight: bold; font-size: medium; color: #1f2548;">Total:</label>
            <asp:Label ID="lblTotal" runat="server" Font-Size="medium" Font-Bold="True" ForeColor="#1f2548"></asp:Label>
        </div>
    </div>
    <div class="row" style="background-color: #FFFFFF">
        <div class="form-group">
            <asp:Label ID="lblMej" runat="server" Text="" Font-Bold="True" ForeColor="#3333CC" Font-Size="Medium"></asp:Label>
            &nbsp;
        </div>
    </div>--%>
</asp:Content>
