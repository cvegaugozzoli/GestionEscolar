<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="MesaExamenRegistracion.aspx.cs" Inherits="MesaExamenRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFechaHora.ascx" TagName="cuFechaHora" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">
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

                </div>
            </div>
        </div>--%>
    </div>
    <div class="ibox-content">

        <div class="row">
            <div class="col-sm-12">
                <%--  <div class="ibox collapsed">               --%>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="form-group col-md-2">
                                <label class="control-label ">Año</label>
                                <asp:TextBox ID="txtAnio" requiered="" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-2">
                                <label class="control-label ">Turno</label>
                                <asp:DropDownList ID="TurnoId" requiered="" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="TurnoId_SelectedIndexChanged"></asp:DropDownList>

                            </div>

                            <div class="form-group col-md-3">
                                <label class="control-label ">Fecha Incio Mesa</label>
                                <br />
                                <tpDatePicker:cuFechaHora ID="txtFchInicio" runat="server" Enabled="true" BorderColor="Silver" />
                            </div>

                            <div class="form-group col-md-2" runat="server" visible="false">
                                <label class="control-label ">Nivel</label>
                                <asp:DropDownList ID="NivelID" runat="server" requiered="" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>

                            </div>

                            <div class="form-group col-md-2">
                                <label class="control-label ">Carrera</label>
                                <asp:DropDownList ID="carId" runat="server" requiered="" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>

                            </div>

                            <div class="form-group col-md-2">
                                <label class="control-label ">Plan Estudio</label>
                                <asp:DropDownList ID="plaId" runat="server" requiered="" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Curso</label>
                                <asp:DropDownList ID="curId" runat="server" requiered="" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                            </div>


                            <div class="form-group col-md-3">
                                <label class="control-label">
                                    Buscar x Espacio Curricular</label>
                                <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>
                            </div>
                        </div>

                        <hr class="hr-line-dashed" />
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-0">
                                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                    OnClick="btnAplicar_Click" />
                            </div>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAplicar"></asp:PostBackTrigger>

                    </Triggers>
                </asp:UpdatePanel>
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
                                <div class="ibox-title">
                               <h5><a class="collapse-link" style="color: red;"> Solo aparecen Mesas que no fueron incorporadas en ese Turno</a></h5>

                                </div>
                                <asp:GridView ID="Grilla" runat="server" CssClass="table table-striped"
                                    AutoGenerateColumns="False" DataKeyNames="Id,carId,plaId,curId" OnRowDataBound="OnRowDataBound" OnRowCommand="Grilla_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <PagerStyle HorizontalAlign="Left" CssClass="GridPager" BackColor="White" ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSeleccion2" runat="server" Width="50" />
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Carrera">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Carrera") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="carId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="carId" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("carId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PlanEstudio">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("PlanEstudio") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="plaId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="plaId" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("plaId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Curso">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Curso") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="curId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HyperLink ForeColor="Black" ID="curId" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("curId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--  <asp:TemplateField HeaderText="Campo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Campo" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Campo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Button ID="btnSeleccionarTodo" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo_Click" />
                        </div>
                    </div>
                </div>

                    <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Button ID="btnAgregarMesa" Visible="false" AutoPostBack="True" class="btn btn-w-m btn-warning" runat="server" Text="Agregar Mesa" OnClick="btnAgregarMesa_Click" />
                </div>
            </div>
        </div>
            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="Grilla" />
                <asp:AsyncPostBackTrigger ControlID="btnSeleccionarTodo" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="plaId" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="carId" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="curId" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>





        <div class="row">
            <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblalerError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblalerError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

            <div id="alerExito" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                <asp:Label ID="lblalerExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>

    
    </div>
</asp:Content>
