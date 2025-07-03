<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="MesaExamenIscriptos.aspx.cs" Inherits="MesaExamenIscriptos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

    </div>

    <div class="row">  
        <div class="col-sm-12">
            <%-- <div class="ibox collapsed">--%>
            <%-- <div class="ibox-title">
                    <h5><a class="collapse-link">Filtros</a></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>--%>
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

                            <div class="form-group col-md-3" runat="server" visible="false">
                                <label class="control-label ">Nivel</label>
                                <asp:DropDownList ID="NivelID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label ">Carrera</label>
                                <asp:DropDownList ID="carIdDD" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>

                            </div>

                            <div class="form-group col-md-3">
                                <label class="control-label ">Plan Estudio</label>
                                <asp:DropDownList ID="plaIdDD" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Curso</label>
                                <asp:DropDownList ID="curIdDD" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                            </div>


                            <div class="form-group col-md-3">
                                <label class="control-label">
                                    Espacio Curricular</label>
                                <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label ">Tipo Examen</label>
                                <asp:DropDownList ID="extIdDD" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-3">
                                <label class="control-label ">
                                    Aplica filtro fecha</label>
                                <asp:CheckBox ID="aplicafiltrofechaCH" runat="server" AutoPostBack="true" OnCheckedChanged="aplicaplicafiltrofecha_SelectedIndexChanged" Checked="False" Enabled="true"></asp:CheckBox>
                            </div>

                            <div class="form-group col-md-3">

                                <label class="control-label ">Fecha Desde</label>

                                <tpDatePicker:cuFecha ID="ixaFechaExamenDesde" runat="server" Enabled="false" AllowType="False" />
                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Fecha Hasta</label>

                                <tpDatePicker:cuFecha ID="ixaFechaExamenHasta" runat="server" Enabled="false" AllowType="False" />
                            </div>

                        </div>


                        <div class="ibox-content">
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-0">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                        OnClick="btnAplicar_Click" />
                                </div>
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



    <%--
    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>--%>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-12">

                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:GridView ID="Grilla" runat="server" CssClass="table table-striped"
                                AutoGenerateColumns="False" DataKeyNames="Id" OnRowDataBound="OnRowDataBound" OnRowCommand="Grilla_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <PagerStyle HorizontalAlign="Left" CssClass="GridPager" BackColor="White" ForeColor="#000066" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alumno">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Alumno" runat="server" Text='<%# Eval("Alumno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Turno">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Turno" runat="server" Text='<%# Eval("tueNombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Llamado">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Llamado" runat="server" Text='<%# Eval("Llamado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Esp.Curric.">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="EspacioCurricular" runat="server" Text='<%# Eval("EspacioCurricular") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Carrera">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Carrera") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PlanEstudio">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("PlanEstudio") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Curso">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<%# "MesaExamenModificar.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Curso") %>' />
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
            </div>
            <div class="ibox-content">
                <div class="form-group">
                    <div class="col-md-4 col-md-offset-0">
                        <asp:Button ID="BtnImprimir" class="btn btn-w-m btn-info" runat="server" Text="Imprimir" Visible="false"
                            OnClick="BtnImprimir_Click" />
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





    <div class="ibox-content">
        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblalerError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>

        <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblalerError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>

        <div id="alerExito" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblalerExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>
    </div>



    <%--   <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Button ID="btnAgregarMesa" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Agregar Mesa" OnClick="btnAgregarMesa_Click" />
            </div>
        </div>
    </div>--%>
</asp:Content>
