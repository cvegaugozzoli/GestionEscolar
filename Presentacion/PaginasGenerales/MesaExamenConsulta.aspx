<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="MesaExamenConsulta.aspx.cs" Inherits="MesaExamenConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">

    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Salir" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-12">
            <div class="ibox collapsed">
                <div class="ibox-title">
                    <h5><a class="collapse-link">Filtros</a></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="ibox-content">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="form-group col-md-3">
                                    <label class="control-label ">Año</label>
                                    <asp:TextBox ID="txtAnio" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <label class="control-label ">Turno</label>
                                    <asp:DropDownList ID="TurnoId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="TurnoId_SelectedIndexChanged"></asp:DropDownList>

                                </div>

                                <div class="form-group col-md-3">
                                    <asp:CheckBox ID="chekFch" runat="server" Text="Buscar por fecha" AutoPostBack="true" OnCheckedChanged="chekFch_CheckedChanged" />
                                    <label class="control-label ">Fecha</label>
                                    <br />
                                    <tpDatePicker:cuFecha ID="txtFchInicio" runat="server" Enabled="false" BorderColor="Silver" />
                                </div>

                                <div class="form-group col-md-2" runat="server" visible="false">
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
                                        Espacio Curricular</label>
                                    <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true"></asp:DropDownList>

                                    <%--<asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>--%>
                                </div>
                            </div>

                            <%--    <hr class="hr-line-dashed" />--%>
                            <div class="form-group">
                                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                    OnClick="btnAplicar_Click" />
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
            <div id="Div1" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

            <div id="Div2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

            <div id="Div3" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>


        <%--
    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>--%>
        <asp:Panel ID="pnlContents" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="col-sm-12">
                   
                        <div class="ibox-content">     <p style="color: red; font-weight: bold; margin: 10px 0;">
                            ⚠️ <u>Importante</u>: Para asignar el Tribunal, primero utilice los <b>Filtros</b> para buscar la mesa correspondiente.<br />
                            Luego, <b>haga clic sobre la mesa</b> para agregar el Tribunal.
                        </p>
                            <div class="table-responsive">
                                <asp:GridView ID="Grilla" runat="server" CssClass="table table-striped"
                                    AutoGenerateColumns="False" DataKeyNames="Id,carId,plaId,curId" OnRowCommand="Grilla_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <PagerStyle HorizontalAlign="Left" CssClass="GridPager" BackColor="White" ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Fecha1" runat="server" Width="90px" Text='<%# Eval("meeFecha") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>

                                        <%--   <asp:TemplateField HeaderText="Fecha">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Fecha" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("meeFecha") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Esp.Curric.">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Turno" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Turno" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("TurnoNombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Llamado">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Llamado" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("LlamadoNombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Carrera">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Carrera") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="carId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="carId" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("carId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PlanEstudio" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("PlanEstudio") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="plaId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="plaId" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("plaId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Curso">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Curso") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="curId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="curId" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("curId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tribunal">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Tribunal" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Profesores") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                                <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                                    OnClick="btnEliminarAceptar_Click" />
                                                <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                                    OnClick="btnEliminarCancelar_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="#006699" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" ForeColor="White" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <FooterStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle HorizontalAlign="Left" />

                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />

                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="Grilla" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnAgregarMesa" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                </Triggers>
            </asp:UpdatePanel>

        </asp:Panel>

        <div class="col-sm-12">

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
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Button ID="btnGuardarFcha" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Visible="false" Text="Guardar Fecha" OnClick="btnGuardarFcha_Click" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnPrint" class="btn btn-w-m btn-info" runat="server" Text="Imprimir" Visible="false" OnClientClick="PrintGridData()" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--   <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Button ID="btnAgregarMesa" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Agregar Mesa" OnClick="btnAgregarMesa_Click" />
            </div>
        </div>
    </div>--%>
    </div>

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=Grilla.ClientID %>');
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var prtwin = window.open('', 'panel', 'left=50,top=300,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');

            prtwin.document.write('<style>@page{size:landscape;}</style><html><head><title ></title></head><body height="100%" width="100%" > <p style="font-size: large; font-weight: bold; text-align: center; text-decoration: underline">Mesas de Exámen</p> </body></html>');
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
