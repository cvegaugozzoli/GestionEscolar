<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="MovimientoPromocionarSuperior.aspx.cs" Inherits="MovimientoPromocionarSuperior" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:Label ID="lblInsId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblInsId2" runat="server" Visible="false"></asp:Label>

        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Curso Origen" Font-Bold="True" Font-Size="Medium"> </asp:Label>
            </div>         
        </div>
        <div class="col-md-6">
            <div class="form-group col-md-4">
                <asp:Label runat="server" ID="lblCursoD" Visible="false" Text="Curso Destino" Font-Bold="True" Font-Size="Medium"> </asp:Label>
            </div>         
        </div>
    </div>


    <div class="row">
        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form-row">

                        <div class="form-group col-md-4">
                            <label runat="server" class="control-label">Carrera</label>
                            <asp:DropDownList ID="carId" placeholder="Carrera" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" class="control-label">Plan</label>
                            <asp:DropDownList ID="plaId" placeholder="Plan" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" class="control-label">Curso</label>
                            <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label runat="server" class="control-label">Año</label>
                            <asp:TextBox ID="AnioCursado" type="text" class="form-control" BorderColor="Silver" runat="server" placeholder="" AutoPostBack="true" OnTextChanged="AnioCursado_TextChanged"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" class="control-label">Tipo Conc.</label>
                            <asp:DropDownList ID="ConTipoId" runat="server" BorderColor="Silver" class="form-control m-b" AutoPostBack="True" OnSelectedIndexChanged="ConTipoId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" class="control-label">Conceptos</label>
                            <asp:DropDownList ID="ConceptoId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="True" AutoPostBack="True"></asp:DropDownList>
                        </div>  
                         <div class="form-group col-md-12">
                         <div id="alerErrorP1" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="LBLalerErrorP1" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>   </div>
                    </div>
                    
                  
                    <hr class="hr-line-dashed" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label runat="server" id="lblNivel" class="control-label">Carrera</label>
                            <asp:DropDownList ID="carId2" placeholder="Nivel" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId2_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" id="lblPlan" class="control-label">Plan</label>
                            <asp:DropDownList ID="plaId2" placeholder="Plan" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId2_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" id="lblCurso" class="control-label">Curso</label>
                            <asp:DropDownList ID="curId2" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label runat="server" id="lblAnio2" class="control-label">Año</label>
                            <asp:TextBox ID="AnioCursado2" type="text" class="form-control" BorderColor="Silver" runat="server" placeholder="" AutoPostBack="true" OnTextChanged="AnioCursado2_TextChanged"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" id="lblTipoConcepto2" class="control-label">Tipo Conc.</label>
                            <asp:DropDownList ID="ConTipoId2" runat="server" BorderColor="Silver" class="form-control m-b" AutoPostBack="True" OnSelectedIndexChanged="ConTipoId2_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label runat="server" id="lblConcepto2" class="control-label">Conceptos</label>
                            <asp:DropDownList ID="ConceptoId2" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="True" AutoPostBack="True"></asp:DropDownList>
                        </div>

                         <div class="form-group col-md-12">
                         <div id="alerErrorP2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="LBLalerErrorP2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>   </div>
                    </div>
                     
                     
                    <hr class="hr-line-dashed" />

                     
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-warning" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-inline">
                <div class="form-group">
                    &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="BtnGrabar" class="btn btn-w-m btn-warning" runat="server" Text="Grabar" OnClick="btnGrabar_Click" UseSubmitBehavior="False" />
                </div>
            </div>
        </div>
    </div>
    <div id="alerPromociona" visible="false" runat="server" class="alert alert-info  alert-dismissable">
        <h5 style="font-weight: bold; font-size: medium">"Se registró con exito la acción.."</h5>
    </div>
    <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>
    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>


    <div class="row">
        <div class="col-md-5">
            <asp:Label ID="lblListado" runat="server" Visible="False" Text="Listado | "></asp:Label>
            <asp:Label ID="lblCantidadRegistros" runat="server" Text="" Visible="False"></asp:Label>
        </div>

        <div class="col-sm-1" style="vertical-align: middle" align="center">
        </div>
        <div class="col-md-5">
            <asp:Label ID="lblListado2" runat="server" Visible="False" Text="Listado | "></asp:Label>
            <asp:Label ID="lblCantidadRegistros2" Visible="False" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5">
            <asp:GridView ID="GrillaAlumnos" runat="server" GridLines="None" CssClass="table table-striped"
                AutoGenerateColumns="False" DataKeyNames="Id,Alumno,Dni,aluId,Estado,icuid">
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
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="aluId" runat="server" Visible="false" Text='<%# Eval("aluId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="EstadoId" runat="server" Visible="false" Text='<%# Eval("Estado") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Estado" runat="server" Visible="true" Text='<%# Eval("EstadoDesc") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <FooterStyle HorizontalAlign="NotSet" />

                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CCCCFF" />
            </asp:GridView>
            &nbsp;                  
        </div>

        <div class="col-sm-1" style="vertical-align: middle" align="center">
            <br />
            <br />
            <asp:Button ID="btnSeleccionar" runat="server" Text=">>"
                OnClick="btnSeleccionar_Click" />
            <br />
            <br />
        </div>

        <div class="col-md-5">

            <asp:GridView ID="GrillaAlumnos2" runat="server" DataKeyNames="IC,Nombre,DNI,aluId,Estado" GridLines="None" CssClass="table table-striped"
                AutoGenerateColumns="False">
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <Columns>
                    <asp:BoundField DataField="IC" HeaderText="IC" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI" />

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                            <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                OnClick="btnEliminarAceptar_Click" />
                            <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                OnClick="btnEliminarCancelar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="aluId" runat="server" Visible="false" Text='<%# Eval("aluId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Estado" Visible="false" HeaderText="Estado" />
                </Columns>
                <FooterStyle HorizontalAlign="NotSet" />

                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CCCCFF" />
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Button ID="btnSeleccionarTodo" class="btn btn-w-m btn-warning" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo_Click" />
            </div>
        </div>

        <%-- <div class="col-md-6">
            <div class="form-inline">
                <div class="form-group">
                    &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="BtnGrabar" class="btn btn-w-m btn-warning" runat="server" Text="Grabar" OnClick="btnGrabar_Click" UseSubmitBehavior="False" />
                </div>
            </div>
        </div>--%>
    </div>

    <asp:Label ID="lblMensajeError2" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></asp:Label>
</asp:Content>
