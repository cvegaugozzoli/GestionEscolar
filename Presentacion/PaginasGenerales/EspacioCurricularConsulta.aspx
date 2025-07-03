<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="EspacioCurricularConsulta.aspx.cs" Inherits="EspacioCurricularConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">
    <div class="ibox-content">

        <div class="row">
            <div class="form-group">
                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            </div>
            <%--      <div class="col-sm-12">
                <div class="ibox-content">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                        </div>

                    </div>
                </div>
            </div>--%>
        </div>

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
                                <label class="control-label ">Nivel</label>
                                <asp:DropDownList ID="NivelID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label ">Carrera</label>
                                <asp:DropDownList ID="carId1" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label ">Plan Estudio</label>
                                <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div class="form-group col-md-3">
                                <label class="control-label">Curso</label>
                                <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <%--  </div>
                            <div class="row" runat="server" visible="false">--%>
                            <div class="form-group col-md-3" runat="server" visible="false">
                                <label class="control-label">
                                    Nombre</label>
                                <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"></asp:TextBox>
                            </div>


                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-0">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                        OnClick="btnAplicar_Click" />
                                </div>
                            </div>
                        </div>
                        <br />
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
                        <div class="table-responsive">
                            <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped" OnRowEditing="OnRowEditing"
                                AutoGenerateColumns="False" DataKeyNames="Id" OnRowDataBound="OnRowDataBound" OnRowCommand="Grilla_RowCommand" OnRowUpdating="OnRowUpdating">
                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Forma Dictado">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="fd" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("FormatoDictado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Carrera">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Carrera") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PlanEstudio">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("PlanEstudio") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Curso">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Curso") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Campo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Campo" runat="server" NavigateUrl='<%# "EspacioCurricularRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Campo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Correlativas">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Red" ID="Correlativas" runat="server" NavigateUrl='<%# "CorrelativaConsultaCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='Ver' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                                        </EditItemTemplate>
                                        <ItemStyle Width="60px" />
                                    </asp:TemplateField>

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
                                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#CCCCFF" />
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />

                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar1" EventName="Click"></asp:AsyncPostBackTrigger>
                 <asp:AsyncPostBackTrigger ControlID="carId1" EventName="SelectedIndexChanged" />
                 <asp:AsyncPostBackTrigger ControlID="plaId" EventName="SelectedIndexChanged" />
                 <asp:AsyncPostBackTrigger ControlID="curId" EventName="SelectedIndexChanged" />

            </Triggers>


        </asp:UpdatePanel>

        <br />
        <br />
        <div class="ibox-title">
            <h5><a class="collapse-link">Agregar Espacio Curricular a ese Año</a></h5>
            <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row">


                    <div class="form-group col-md-4">
                        <label class="control-label">Nombre</label>
                        <asp:TextBox ID="escNombre" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">Formato Dictado</label>
                        <asp:DropDownList ID="fodId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="fodId_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label col-md-2">Campo</label>
                        <asp:DropDownList ID="camId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label">Regimen</label>
                        <asp:DropDownList ID="regId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                    </div>

                    <div class="form-group col-md-2">
                        <label class="control-label ">Horas Semanales Reloj</label>
                        <asp:TextBox ID="escHorasSemanalesReloj" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">Horas Semanales Cat.</label>
                        <asp:TextBox ID="escHorasSemanalesCatedra" class="form-control" runat="server"></asp:TextBox>
                    </div>


                    <div class="form-group col-md-2">
                        <label class="control-label">Promociona</label>
                        <asp:CheckBox ID="escPromociona" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>

                    <%--   <div class="form-group col-md-2">
                        <label class="control-label">Taller Inicial</label>
                        <asp:CheckBox ID="TInicial" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>--%>

                    <div class="form-group col-md-2">
                        <label class="control-label">Activo</label>
                        <asp:CheckBox ID="escActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>


                    <div class="form-group col-md-2">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Agregar Espacio" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                </div>



                <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
                <div class="row">

                    <div class="form-group col-md-2">
                        <asp:Button ID="btnImprimir" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir Coorelativas" OnClick="btnImprimir_Click" Width="100%" />
                    </div>
                      <div class="form-group col-md-2">
                        <asp:Button ID="btnMaterias" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir Materias" OnClick="btnMaterias_Click" Width="100%" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <%-- <asp:PostBackTrigger ControlID="btnAplicar" />--%>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar1" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnImprimir" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>


        </asp:UpdatePanel>


    </div>
</asp:Content>
