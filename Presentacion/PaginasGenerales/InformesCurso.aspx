<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformesCurso.aspx.cs" Inherits="InformesCurso" %>

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

            <div class="ibox-title">
                <h5><a class="collapse-link">Buscar por Curso:  | </a>
                    <asp:Label ID="lblCurso" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label></h5>
                <asp:Label ID="lblTC" runat="server" Visible="false" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>
                <div class="ibox-tools">
                    <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                </div>
            </div>

            <div class="ibox-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card-body">
                            <div class="form-row">
                                <div class="form-group col-md-2">
                                    <label class="control-label">Carrera</label>
                                    <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-2">
                                    <label class="control-label ">Plan Estudio</label>
                                    <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-3">
                                    <label class="control-label">Curso</label>
                                    <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-3">
                                    <label class="control-label">
                                        Año de Cursado</label>
                                    <asp:TextBox ID="AnioCursado" BorderColor="Silver" type="text" class="form-control" runat="server" placeholder="Buscar por Año"
                                        AutoPostBack="false" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr class="hr-line-dashed" />

                    </ContentTemplate>
                </asp:UpdatePanel>

                <fieldset class="form-horizontal">
                    <div class="text-end">
                        <div>
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                        </div>
                        <div>
                            <asp:Button ID="btnNuevo" Visible="false" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo Curso" OnClick="btnNuevo_Click" />
                            <%--<asp:Button ID="btnNuevo" Visible="false" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo Curso" OnClick="btnNuevo_Click" />--%>
                        </div>
                        <%--  <div>
                        <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" />
                    </div>--%>
                    </div>
                </fieldset>
            </div>
        </div>

        <div class="col-sm-12">
            <div class="ibox-title">
                <asp:Label ID="lblCantReg" runat="server" Text="Listado |"></asp:Label>

                <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped" DataKeyNames="Id,aluId,TipoCarrera,Curso"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>

                            <asp:TemplateField HeaderText="Seleccionar" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IC" Visible="False">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AluId" Visible="False">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="aluId" runat="server" Text='<%# Eval("aluId") %>' />
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

                        </Columns>


                        <FooterStyle HorizontalAlign="NotSet" />


                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#CCCCFF" />
                    </asp:GridView>
                </div>
            </div>
        </div>


        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnSeleccionarTodo" class="btn btn-w-m btn-warning" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo_Click" />

                    </div>
                </div>
                <br />



                <div class="form-inline">
                    <div class="form-group">

                        <asp:Label ID="lblTipoInforme" runat="server" Text="" ForeColor="Black" Font-Bold="True">Tipo:</asp:Label>
                        &nbsp;&nbsp;                 
                        <asp:DropDownList ID="TipoInformeId" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="TipoInformeId_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccionar..</asp:ListItem>
                            <asp:ListItem Value="1">Portada</asp:ListItem>
                            <asp:ListItem Value="2">Informes</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label ID="lblPeriodo" runat="server" Text="" ForeColor="Black" Font-Bold="True">Periodo:</asp:Label>
                        &nbsp;&nbsp;                 
                        <asp:DropDownList ID="PeriodoId" runat="server" Enabled="false" BorderColor="Silver" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="PeriodoId_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccionar..</asp:ListItem>
                            <asp:ListItem Value="1">1° Informe</asp:ListItem>
                            <asp:ListItem Value="2">2° Informe</asp:ListItem>
                            <asp:ListItem Value="3">3° Informe</asp:ListItem>



                        </asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="BtnImprimir" Enabled="false" class="btn btn-w-m btn-warning" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" />

                    </div>
                    <asp:Label ID="lblMensajeError3" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
