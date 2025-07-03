<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="NotaExamenFinalTerc.aspx.cs" Inherits="NotaExamenFinalTerc" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="ibox-content">
        <div class="row">
            <div class="form-group">
                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            </div>
            <%--<div class="col-sm-12">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                    <%-- <div class="form-group" >
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                </div>--%>


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
                                    <div class="form-group col-md-2">
                                        <label class="control-label ">Año</label>
                                        <asp:TextBox ID="txtAnio" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-2">
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
                                    <div class="form-group col-md-2">
                                        <label class="control-label ">Curso</label>
                                        <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label class="control-label ">Espacio Curricular</label>
                                        <asp:DropDownList ID="escId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label class="control-label ">Tipo Examen</label>
                                        <asp:DropDownList ID="extId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>
                                    </div>


                                    <div class="form-group col-md-2">
                                        <br>
                                        <label class="control-label ">Aplica filtro fecha</label>
                                        <asp:CheckBox ID="aplicafiltrofecha" runat="server" AutoPostBack="true" Checked="False" Enabled="true" OnCheckedChanged="aplicaplicafiltrofecha_SelectedIndexChanged" />

                                    </div>

                                    <div class="form-group col-md-2">

                                        <label class="control-label ">Fecha Desde</label>

                                        <tpDatePicker:cuFecha ID="ixaFechaExamenDesde" runat="server" Enabled="true" AllowType="False" />
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label class="control-label">Fecha Hasta</label>

                                        <tpDatePicker:cuFecha ID="ixaFechaExamenHasta" runat="server" Enabled="true" AllowType="False" />
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

                      
                            <div class="ibox-content">
                                <div class="form-inline">
                                    <div class="form-group ">
                                        <asp:Button ID="Button1" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                            OnClick="btnAplicar_Click" Width="100%" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnNuevoEC" class="btn btn-w-m btn-primary" runat="server" Text="Limpiar Materia" OnClick="btnNuevoEC_Click" Width="100%" />
                                    </div>
                                    <div class="form-group ">
                                        <asp:Button ID="btnNuevoCarrera" class="btn btn-w-m btn-primary" runat="server" Text="Limpiar Carrera" OnClick="btnNuevoCarrera_Click" Width="100%" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
               

                <%--</div>--%>
            </div>



    <div class="row">
        <div class="col-sm-12">
            <%--  <div class="ibox-title">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>--%>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" CssClass="table table-striped" DataKeyNames="Id,ictId"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="White" ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ictId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ictId" runat="server" Text='<%# Eval("ictId") %>' />
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
                                    <asp:TextBox ID="txtCalificacion" runat="server" Text='<%# Eval("Calificacion") %>' Width="90px" MaxLength="3" />
                                </ItemTemplate>
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Obsevación">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtObserv" runat="server" Text='<%# Eval("ixaObservacion") %>' Width="190px" />
                                </ItemTemplate>
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>





                            <asp:TemplateField HeaderText="Condición">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Condicion" runat="server" Text='<%# Eval("Condicion") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#006699" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" ForeColor="White" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <FooterStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="PanelActaLibro" Visible="false" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
            <asp:PostBackTrigger ControlID="btnActualizar" />
        </Triggers>
        <ContentTemplate>

               <p style="color: red; font-weight: bold; margin-top: 10px;">
    ⚠️ ¡IMPORTANTE! Luego de ingresar la calificación, haga clic en "Guardar Nota" para guardar los cambios.
</p>
            <div class="ibox-content">
                <div class="row">
                    <div class="form-group col-md-2">
                        <label class="control-label ">Nº Acta</label>
                        <asp:TextBox ID="txtActa" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">Nº Libro</label>
                        <asp:TextBox ID="txtLibro" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <br />
                        <div class="col-md-3 col-md-offset-0">
                            <asp:Button ID="btnActualizar" class="btn btn-w-m btn-info" Visible="false" runat="server" Text="Guardar Nota"
                                OnClick="btnActualizar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>




    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
        <ContentTemplate>
            <div class="ibox-content">
                <div class="row">

                    <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblalerError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
