<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AsignarBecasAlumnos.aspx.cs" Inherits="AsignarBecasAlumnos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row" style="background-color: #FFFFFF">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblInsId" Visible="false" runat="server" Text=""></asp:Label>
             <asp:Label ID="lblIcuId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="ibox-content" style="background-color: #FFFFFF">

            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-4">
                    <label class="control-label">Nivel</label>
                    <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label class="control-label">Carrera</label>
                    <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label class="control-label ">Plan Estudio</label>
                    <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-4">
                    <label class="control-label ">Curso</label>
                    <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Año de Cursado</label>
                    <asp:TextBox ID="AnioCursado" type="text" class="form-control" required="" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                        AutoPostBack="false" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                </div>

            </div>
            <hr class="hr-line-dashed" />
        </div>
    </div>
    <div class="form-row" style="background-color: #FFFFFF">
        <div class="form-group">
            <asp:Button ID="btnListar" class="btn btn-w-m btn-primary" runat="server" Text="Listar" OnClick="btnListar_Click" />
            <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" formnovalidate="formnovalidate" runat="server" Text="Salir" OnClick="btnCancelar_Click" />
        </div>

        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>

    </div>

    <div class="row">

        <div class="ibox-title" visible="false" runat="server" id="CanReg">
            <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
        </div>
        <div class="ibox-content">
            <div class="table-responsive">
                <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                    AutoGenerateColumns="False" DataKeyNames="Id,aluId, curId" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                    PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                            </ItemTemplate>

                            <FooterStyle HorizontalAlign="Center"></FooterStyle>

                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IC" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CurId" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CurId" runat="server" Text='<%# Eval("CurId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aluId" Visible="false">
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
                      <%--  <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Estado" runat="server" Text='<%# Eval("EstadoDesc") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="TipoCarrera" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="TipoCarrera" runat="server" Text='<%# Eval("TipoCarrera") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                     <%--    <asp:TemplateField HeaderText="Beca">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Beca" runat="server" Text='<%# Eval("PorcBeca") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        <asp:ButtonField ButtonType="Link" Visible="false" HeaderText="Calificaciones" CommandName="Ver" Text="Ver" HeaderStyle-Width="100">



                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>


                        <asp:TemplateField Visible="false" HeaderText=" Eliminar">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                    OnClick="btnEliminarAceptar_Click" />
                                <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                    OnClick="btnEliminarCancelar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle HorizontalAlign="NotSet" />
                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#CCCCFF" />
                </asp:GridView>
            </div>
        </div>

        <div class="ibox-title" runat="server" visible="false" id="Titulo">
            <h3>Aplicar Beca</h3>
        </div>
        <div class="ibox-content">
            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label ID="lblBecas" runat="server" class="control-label" Visible="false">
                Becas:<br />
                    </asp:Label>
                    <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info radio-inline" Visible="false" RepeatLayout="Flow" ID="rbtAgregarQuitar" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Font-Italic="False">
                        <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="1">Asignar </asp:ListItem>
                        <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="0"> Quitar </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group col-md-2">
                    <asp:Label ID="lblProcentaje" runat="server" Visible="false" class="control-label">Beca</asp:Label>
                    <asp:DropDownList ID="BecaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                </div>
          
                <div class="form-group col-md-2">
                    <asp:Label ID="lblTconc" runat="server" Visible="false" class="control-label">Tipo de Conceptos</asp:Label>
                    <asp:DropDownList ID="ConTipoId" runat="server" Visible="false" BorderColor="Silver" class="form-control m-b" AutoPostBack="True" OnSelectedIndexChanged="ConTipoId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <asp:Label runat="server" Visible="false" ID="lblConcepto" class="control-label">Conceptos</asp:Label>
                    <asp:DropDownList ID="ConceptoId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ConceptoId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-2">


                    <asp:Label runat="server" class="control-label"  id="lblCuota" visible="false">Cuota</asp:Label>
                    <asp:DropDownList BorderColor="Silver" ID="CuotaId" Visible="false" runat="server" class="form-control m-b" Enabled="false">
                        <asp:ListItem Value="0">Todas</asp:ListItem>
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
            <div class="row">
              <div class="alert alert-info" visible="false" runat="server" role="alert" id="alerExito" style="font-weight: bold; font-size: medium">
                <strong>Listo!</strong> Se asigno Beca a los registros seleccionados..
            </div>
                  <div class="alert alert-info" visible="false" runat="server" role="alert" id="alerExito2" style="font-weight: bold; font-size: medium">
                <strong>Listo!</strong> Se quitó Beca a los registros seleccionados..
            </div>
            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
 </div>
            <div class="row">
                <div class="form-group">
                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar"
                        OnClick="btnAplicar_Click" Visible="false" />
                    &nbsp;<asp:Button ID="btnCancela" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
                        OnClick="btnCancelar_Click" Visible="false" />
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblMej" runat="server" Text="" Font-Bold="True" ForeColor="#3333CC" Font-Size="Medium"></asp:Label>
                    &nbsp;
                </div>
            </div>
        </div>
        <div class="ibox-content">
            <div class="table-responsive">
                <asp:GridView ID="gridtemp" runat="server" GridLines="None" CssClass="table table-striped"
                    AutoGenerateColumns="False">

                    <Columns>
                        <asp:TemplateField HeaderText="IC" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" Text='<%# Eval("Alumno") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" Text='<%# Eval("Dni") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Curso" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Curso") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Estado" runat="server" Text='<%# Eval("EstadoDesc") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TipoCarrera" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="TipoCarrera" runat="server" Text='<%# Eval("TipoCarrera") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Link" Visible="false" HeaderText="Calificaciones" CommandName="Ver" Text="Ver" HeaderStyle-Width="100">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                    </Columns>
                    <FooterStyle HorizontalAlign="NotSet" />
                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#CCCCFF" />
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
