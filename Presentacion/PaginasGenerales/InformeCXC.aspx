<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformeCXC.aspx.cs" Inherits="InformeCXC" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblInsId" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="row" style="background-color: #FFFFFF">
        <div class="ibox-content" style="background-color: #FFFFFF">

            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-3">
                    <label class="control-label">Tipo de Conceptos</label>
                    <asp:DropDownList ID="ConTipoId" AutoPostBack="true" runat="server" BorderColor="Silver" class="form-control m-b" OnSelectedIndexChanged="ConTipoId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Año Lectivo:</label>
                    <asp:TextBox ID="txtAnioLectivo" required="" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label" runat="server" visible="false" id="lblCuotaD">Cuota Desde</label>
                    <asp:DropDownList BorderColor="Silver" Visible="false" ID="CuotaIdD" runat="server" class="form-control m-b">

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

                <div class="form-group col-md-3">
                    <label class="control-label" runat="server" visible="false" id="lblCuotaH">Cuota Hasta</label>
                    <asp:DropDownList BorderColor="Silver" ID="CuotaIdH" Visible="false" runat="server" class="form-control m-b">

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
    </div>
    <div class="row">
        <div class="ibox-content">
            <div class="form-group">
                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar" OnClick="btnAplicar_Click1" />
                <%--                &nbsp;<asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" formnovalidate="formnovalidate" runat="server" Text="Cancelar" OnClick="btnCancelar_Click1" />--%>
            </div>
        </div>
    </div>
    <div id="alerTipoConc" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un Tipo de Concepto"</h5>
    </div>

    <div class="ibox-content">
        <div class="table-responsive">
            <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                AutoGenerateColumns="False" PageSize="12" AllowPaging="True" DataKeyNames="total,CANTIDAD,InstNombre,NivelNombre,Deuda">
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />

                <Columns>
                    <asp:TemplateField HeaderText="Instid">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="FechaPago" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Instid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Institución">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="FechaPago" runat="server" NavigateUrl='<% %>' Text='<%# Eval("InstNombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nivel">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<% %>' Text='<%# Eval("NivelNombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recaudación">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Concepto" runat="server" NavigateUrl='<% %>' Text='<%# Eval("total") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--  <asp:BoundField ApplyFormatInEditMode="True" HeaderText="Porcentaje" />--%>
                    <asp:BoundField HeaderText="Porc.Pagado" NullDisplayText="0" />
                    <asp:TemplateField HeaderText="CANTIDAD" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="CANTIDAD" runat="server" NavigateUrl='<% %>' Text='<%# Eval("CANTIDAD") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Porc.Morisidad" NullDisplayText="0" />
                    <asp:TemplateField HeaderText="Deuda" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Deuda" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Deuda") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle HorizontalAlign="NotSet" />
                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CCCCFF" />
            </asp:GridView>
        </div>
    </div>





    <div class="wrapper wrapper-content animated fadeInRight">


        <asp:Chart ID="Chart1" runat="server" Height="500px" Width="800px">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>




    </div>







    <%--  <div class="footer">
        <div class="pull-right">
            10GB of <strong>250GB</strong> Free.
        </div>
        <div>
            <strong>Copyright</strong> Example Company &copy; 2014-2015
        </div>
    </div>--%>
</asp:Content>
