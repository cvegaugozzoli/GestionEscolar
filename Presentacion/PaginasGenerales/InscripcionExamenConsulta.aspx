<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InscripcionExamenConsulta.aspx.cs" Inherits="InscripcionExamenConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="ibox-content">
        <div class="row">
            <div class="form-group">
                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            </div> 
            <div class="col-sm-12"> 
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                </div>


                <div class="row">
                    <div class="col-sm-12">
                        <%--<div class="ibox collapsed">--%>
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
                                            <label class="control-label col-md-2">Turno</label>
                                            <asp:DropDownList ID="TurnoID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                      
                                        <div class="form-group col-md-3" runat="server" visible="false">
                                            <label class="control-label col-md-2">Nivel</label>
                                            <asp:DropDownList ID="NivelID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>

                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="control-label ">Carrera</label>
                                            <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>

                                        </div>


                                        <div class="form-group col-md-3">
                                            <label class="control-label">Plan Estudio</label>
                                            <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>

                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="control-label ">Curso</label>
                                            <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="control-label ">Espacio Curricular</label>
                                            <asp:DropDownList ID="escId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="control-label ">Tipo Examen</label>
                                            <asp:DropDownList ID="extId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-3">
                                            <label class="control-label ">
                                                Aplica filtro fecha</label>
                                            <asp:CheckBox ID="aplicafiltrofecha" runat="server" AutoPostBack="true" OnCheckedChanged="aplicaplicafiltrofecha_SelectedIndexChanged" Checked="False" Enabled="true"></asp:CheckBox>
                                        </div>

                                        <div class="form-group col-md-3">

                                            <label class="control-label ">Fecha Desde</label>

                                            <tpDatePicker:cuFecha ID="ixaFechaExamenDesde" runat="server" Enabled="false" AllowType="False" />
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="control-label">Fecha Hasta</label>

                                            <tpDatePicker:cuFecha ID="ixaFechaExamenHasta" runat="server" Enabled="false" AllowType="False" />
                                        </div>
                                        <%-- <div class="form-group">
                                        <label class="control-label col-md-2">
                                            Nombre</label><div class="col-md-6">
                                                <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"
                                                    AutoPostBack="True" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                                            </div>
                                    </div>--%>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-0">
                                    <asp:Button ID="Button1" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                        OnClick="btnAplicar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--  </div>--%>







        <div class="row">
            <div class="col-sm-12">
                <%--  <div class="ibox-title">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>--%>
                <div class="ibox-content">
                    <div class="table-responsive">
                        <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                            PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
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
                                <asp:TemplateField HeaderText="Turno Examen">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="tueNombre" runat="server" Text='<%# Eval("tueNombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carrera">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" Text='<%# Eval("Carrera") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PlanEstudio">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" Text='<%# Eval("PlanEstudio") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Curso">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" Text='<%# Eval("Curso") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EspacioCurricular">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="EspacioCurricular" runat="server" Text='<%# Eval("EspacioCurricular") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="ExamenTipo">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="ExamenTipo" runat="server" NavigateUrl='<%# "InscripcionExamenRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("ExamenTipo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="FechaExamen">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="FechaExamen" runat="server" Text='<%# Eval("FechaExamen") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Calificacion">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Calificacion" runat="server" Text='<%# Eval("Calificacion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="NumeroActa">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="NumeroActa" runat="server" NavigateUrl='<%# "InscripcionExamenRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("NumeroActa") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Activo">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
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
                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#CCCCFF" />
                            <FooterStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <PagerSettings Position="Top" />
                            <PagerStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblalerError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
