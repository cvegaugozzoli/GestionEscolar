<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CorrelativaConsulta.aspx.cs" Inherits="CorrelativaConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
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
                    <div class="form-group">
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>--%>
    </div>

    <div class="ibox-content">
        <div class="row">
            <div class="col-sm-12">
                <%--  <div class="ibox collapsed">--%>
                <%-- <div class="ibox-title">
                    <h5><a class="collapse-link">Filtros</a></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>--%>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="row">

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
                                <label class="control-label">Espacio Curricular</label>
                                <asp:DropDownList ID="escId2" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="escId2_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Tipo de Correlativa </label>
                                <asp:DropDownList ID="cotId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                            </div>



                            <%--  </div>
                            <div class="row" runat="server" visible="false">--%>
                            <div class="form-group col-md-3" runat="server" visible="false">
                                <label class="control-label">
                                    Nombre</label>
                                <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>
                            </div>


                            <div class="form-group">
                                <div class="col-md-2 ">
                                    <br />
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar"
                                        OnClick="btnAplicar_Click" />
                                </div>

                                <div class="col-md-2 ">
                                    <br />
                                    <asp:Button ID="btnAgregar" class="btn btn-w-m btn-info" runat="server" Text="Agregar Correlativa"
                                        OnClick="btnAgregar_Click" />
                                </div>

                            </div>
                        </div>
                        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        </div>
        
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAplicar"></asp:PostBackTrigger>
                        <asp:PostBackTrigger ControlID="btnAgregar"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="carId" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="plaId" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="curId" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="escId2" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>

        </div>
    </div>

    <div class="row">
        <asp:Panel ID="pnlContents" runat="server" Visible="false">
            <div class="col-sm-12">
                <div class="ibox-title">
                    <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                </div>
                <div class="ibox-content">
                    <div class="table-responsive">
                        <asp:GridView ID="Grilla" runat="server" CssClass="table table-striped"
                            AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand" DataKeyNames="Id,escIdOriginal"
                            PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <HeaderStyle HorizontalAlign="Left" />

                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Id" runat="server" ForeColor="Black" Text='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EspacioCurricular Original">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="EspacioCurricularO" runat="server" ForeColor="Black" Text='<%# Eval("EspacioCurricular Original") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Régimen">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="regNombre" runat="server" ForeColor="Black" Text='<%# Eval("regNombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo Unidad">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="fodNombre" runat="server" ForeColor="Black" Text='<%# Eval("fodNombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EspacioCurricular Original" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="escIdOriginal" runat="server" ForeColor="Black" Text='<%# Eval("escIdOriginal") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correlativa">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="EspacioCurricular" runat="server" ForeColor="Black" Text='<%# Eval("EspacioCurricular") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CorrelatividadTipo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="CorrelatividadTipo" runat="server" ForeColor="Black" Text='<%# Eval("CorrelatividadTipo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="Correlativas">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Red" ID="Correlativas" runat="server" NavigateUrl='<%# "CorrelativaConsultaCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"escIdOriginal").ToString() %>' Text='Ver' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                        <asp:Button ID="btnEliminarAceptar" runat="server" OnClick="btnEliminarAceptar_Click" Text="Si" Visible="False" />
                                        <asp:Button ID="btnEliminarCancelar" runat="server" OnClick="btnEliminarCancelar_Click" Text="No" Visible="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BorderStyle="Solid" BorderWidth="1px" />
                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle BackColor="White" CssClass="GridPager" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />

                        </asp:GridView>
                    </div>

                </div>
            </div>
        </asp:Panel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div class="col-md-4 col-md-offset-0">
                <asp:Button ID="btnPrint" class="btn btn-w-m btn-info" runat="server" Text="Imprimir" Visible="false" OnClientClick="PrintGridData()" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=Grilla.ClientID %>');
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var prtwin = window.open('', 'panel', 'left=50,top=300,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');

            prtwin.document.write('<style>@page{size:landscape;}</style><html><head><title ></title></head><body height="100%" width="100%" > <p style="font-size: large; font-weight: bold; text-align: center; text-decoration: underline">Libreta de Calificación</p> </body></html>');
            //prtwin.document.write(Materia.outerHTML);
            prtwin.document.write(panel.outerHTML);
            //prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>


</asp:Content>
