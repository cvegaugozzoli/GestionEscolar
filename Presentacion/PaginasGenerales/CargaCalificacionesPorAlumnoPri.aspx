<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CargaCalificacionesPorAlumnoPri.aspx.cs" Inherits="CargaCalificacionesPorAlumnoPri" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="form-group">
                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
                <asp:TextBox ID="ICtext" BorderColor="Silver" class="form-control" Visible="false" runat="server"></asp:TextBox>

                <div id="miPanel" visible="false" runat="server">

                    <div class="panel panel-success">
                        <div class="panel-heading" style="font-size: medium; font-weight: bold">
                            Filtro 
                        </div>
                        <div class="panel-body">
                            <%--<div class="row mb-12">--%>
                            <div class="col-md-2">
                                <label for="txtAnioLectivo" class="form-label">Año Lectivo:</label>
                                <asp:TextBox ID="anioCur" runat="server" CssClass="form-control" />
                                <div class="form-check mt-2">
                                    <asp:CheckBox ID="chkAplicarAnio" runat="server" CssClass="form-check-input" />
                                    <label class="form-check-label" for="chkAplicarAnio">Aplicar Año</label>
                                </div>
                            </div>
                            <div class="col-md-1"></div>

                            <div class="col-md-2">
                                <label class="form-label">Buscar por:</label>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rbNombre" Checked="true" runat="server" GroupName="BuscarPor" CssClass="form-check-input" />
                                    <label class="form-check-label" for="rbNombre">Nombre</label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rbDni" runat="server" GroupName="BuscarPor" CssClass="form-check-input" />
                                    <label class="form-check-label" for="rbDNI">DNI</label>
                                </div>
                            </div>
                            <%--  <div class="col-md-2">
                                <label>Buscar:</label>
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" />
                            </div>--%>
                            <div class="col-md-3">
                                <label for="txtBuscar" class="form-label">Buscar:</label>
                                <div class="d-flex align-items-end">
                                    <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control me-2" />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success me-2" OnClientClick="return validarBusqueda();" OnClick="btnBuscarAlumnos_Click" />
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarAlumno_Click" />
                                </div>
                            </div>


                        </div>

                        <%-- <fieldset class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-0">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                                </div>
                              

                            </div>
                        </fieldset>--%>
                    </div>
                </div>
            </div>


            <div class="col-sm-12" style="background-color: #FFFFFF">

                <%--   <div class="collapse" id="collapseExample">--%>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="GrillaBuscar" />
                        <asp:PostBackTrigger ControlID="btnCancelar"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <ContentTemplate>

                        <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>


                        <div id="pnelAlumnoSeleccionado" visible="false" runat="server">
                            <div class="ibox-content">
                                <div class="row" style="background-color: #FFFFFF">
                                    <label class="control-label col-md-12">Alumno Seleccionado</label>
                                    <div class="form-group col-md-2">
                                        <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <asp:Label class="control-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <asp:Label ID="lblCurso" runat="server" Text="Curso:" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtCurso" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                    <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="GrillaBuscar" runat="server" CssClass="table table-striped"
                                AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="GrillaBuscar_RowDataBound" OnRowCommand="GrillaBuscar_RowCommand"
                                PageSize="5" AllowPaging="True" OnPageIndexChanging="GrillaBuscar_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <PagerStyle HorizontalAlign="Left" CssClass="GridPager" BackColor="White" ForeColor="#000066" />
                                <Columns>

                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Select" />
                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Alumno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DNI">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Doc" runat="server" Text='<%# Eval("Dni") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Curso">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Curso" runat="server" Text='<%# Eval("Curso") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
 <asp:TemplateField HeaderText="Año">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="AnoCursado" runat="server" Text='<%# Eval("AnoCursado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Activo" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#006699" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" ForeColor="White" />
                                <FooterStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />

                                <PagerSettings Position="Top" />
                                <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>

                            <br />

                        </div>
                        <asp:Label ID="lblMjerror2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancelar" />
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:PostBackTrigger ControlID="GrillaBuscar"></asp:PostBackTrigger>
                        <asp:PostBackTrigger ControlID="btnCancelar"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>

                </asp:UpdatePanel>
                <%-- <div class="row"  >--%>


                <panel id="panelCalif" class="col-sm-12" runat="server" visible="false">
                <div class="ibox-title">
                    <h5><a class="collapse-link">Calificaciones:</a></h5>
                </div>
                    <p style="color: red; font-weight: bold; margin: 10px 0;">
    ⚠️ <u>Importante</u>:  Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas<br /> </p>
                      <%--<div id="alerMje" visible="true" runat="server" class="alert alert-dismissible  alert-dismissable">--%>
                               <%-- <asp:Label ID="lblMje" runat="server" Font-Bold="True" Font-Size="Medium" Text="Atención: Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas"></asp:Label>
                            </div>  --%>
            
            <div class="col-md-2">
                                <br/>
                    <asp:Button ID="btnGuardar1" class="btn btn-w-m btn-primary" runat="server" Text="Guardar Notas" OnClick="btnGuardar_Click" /></div>
           <div class="form-group col-md-2">
                                <label id="Label1" runat="server" class="control-label col-md-1">Periodo:</label>
                                <asp:DropDownList ID="PeriodoId2" requeried="" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" BorderColor="Silver" OnSelectedIndexChanged="PeriodoId_SelectedIndexChanged2">
                                     <asp:ListItem Value="1">1° Trimestre.</asp:ListItem>
                                    <asp:ListItem Value="2">2° Trimestre.</asp:ListItem>
                                    <asp:ListItem Value="3">3° Trimestre.</asp:ListItem>
                                    <asp:ListItem Value="4">Calificación Final</asp:ListItem>
                                    <asp:ListItem Value="5">Taller Dic.</asp:ListItem>
                                    <asp:ListItem Value="6">Taller Mar.</asp:ListItem>
                                    <asp:ListItem Value="7">Eval. Definitiva</asp:ListItem>
                                </asp:DropDownList>
                            </div>
            </panel>
            </div>
            <%--</div>--%>

            <div class="ibox-content">

                <div class="row">
                    <div class="col-sm-12">
                        <div id="dvGrid" style="padding: 10px">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlContents" runat="server">
                                        <asp:GridView ID="GrillaNota" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowDataBound="GrillaNota_RowDataBound"
                                            Width="100%" DataKeyNames="Id,FDictado,Asignatura" PageSize="50" AllowPaging="True" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating"
                                            BorderColor="#CCCCCC" HorizontalAlign="Center" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Id" ItemStyle-Width="100px" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Asignatura" ItemStyle-Width="250px" ItemStyle-VerticalAlign="Bottom">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsignatura" runat="server" Text='<%# Eval("Asignatura") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="True" Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="1° Trim" ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPTrim" runat="server" Text='<%# Eval("PTrim") %>' Width="100"></asp:TextBox>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="2° Trim" ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSTrim" runat="server" Text='<%# Eval("STrim") %>' Width="90"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="3° Trim" ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtTTrim" runat="server" Text='<%# Eval("TTrim") %>' Width="90"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Calif. Final" ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPAnual" runat="server" Text='<%# Eval("PAnual") %>' Width="90"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Taller Dic." ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtDiciembre" runat="server" Text='<%# Eval("NotaDic") %>' Width="90"></asp:TextBox>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Taller Mar." ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMarzo" runat="server" Text='<%# Eval("NotaMar") %>' Width="90"></asp:TextBox>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Eval. Definitiva" ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtrenCalfDef" runat="server" Text='<%# Eval("renCalfDef") %>' Width="90"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="FDictado" ItemStyle-Width="150" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFDictadoId" runat="server" Text='<%# Eval("FDictado") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="150px" />
                                                </asp:TemplateField>

                                                <%--   <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowCancelButton="false" CausesValidation="False"
                                                    ItemStyle-Width="150">

                                                    <ItemStyle Width="150px" />
                                                </asp:CommandField>

                                                <asp:TemplateField Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                    </asp:Panel>
                                    <div id="ErrorIngreso" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                        <asp:Label ID="lblErrorIngreo" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </div>
                                    <asp:Label ID="lblMsjeErrorAsignar" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    <br />

                                    <!-- Panel para Asignar Nota -->
                                    <asp:Panel ID="pnlAsignarNota" runat="server" Visible="false" CssClass="card p-3 mb-3">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:Button ID="btnGuardar" class="btn btn-w-m btn-primary" runat="server" Text="Guardar Notas" OnClick="btnGuardar_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="panel panel-success">
                                            <div class="panel-heading" style="font-size: medium; font-weight: bold">
                                                Asignar por Lote
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="form-group col-md-8">

                                                        <%--   <div class="form-group col-md-3">
                                                            <label runat="server" id="LblPeriodo" class="control-label">Periodo:</label>

                                                            <asp:DropDownList ID="PeriodoId" runat="server" class="form-control" AutoPostBack="true" Enabled="true" BorderColor="Silver" OnSelectedIndexChanged="PeriodoId_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">Primer Trim.</asp:ListItem>
                                                                <asp:ListItem Value="2">Segundo Trim.</asp:ListItem>
                                                                <asp:ListItem Value="3">Tercer Trim.</asp:ListItem>
                                                                <asp:ListItem Value="4">Prom. Anual</asp:ListItem>
                                                                <asp:ListItem Value="5">Nota Dic.</asp:ListItem>
                                                                <asp:ListItem Value="6">Nota Mar.</asp:ListItem>
                                                                <asp:ListItem Value="7">Calif. Definitiva</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="0">Seleccionar..</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>--%>
                                                        <div class="form-group col-md-2">
                                                            <asp:Label ID="lblNota" runat="server" CssClass="control-label">Nota x Periodo:</asp:Label>
                                                            <asp:TextBox ID="TextNotaAsignar" runat="server" CssClass="form-control" />
                                                        </div>
                                                        <br />
                                                        <div class="form-group col-md-2 d-flex align-items-end">
                                                            <asp:Button ID="ButtonAsignar" runat="server" Text="Asignar" OnClick="ButtonAsignar_Click" CssClass="btn btn-primary" />
                                                        </div>
                                                        <div class="form-group col-md-2 d-flex align-items-end">
                                                            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir tabla" Visible="false" OnClientClick="imprimirTabla(); return false;" CssClass="btn btn-danger" />
                                                        </div>

                                                    </div>
                                    </asp:Panel>
                                    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <asp:Label ID="LblMensajeErrorGrilla" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>


                <div class="row">
                    <div style="padding: 10px; width: 950px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="ibox-title">
                                    <%--<h5><a class="collapse-link" style="color: red; font-weight: bold;">Cantidad de Previas:  </a>--%>
                                    <asp:Label Font-Bold="true" ForeColor="Red" ID="lblCantidadPrevias" runat="server" Text=""></asp:Label></h5>
                                </div>
                                <asp:GridView ID="GrillaPrevia" runat="server" GridLines="None" CssClass="table table-striped"
                                    AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound2" OnRowUpdating="OnRowUpdating2"
                                    DataKeyNames="Id,RegNotaId,icuId,Asignatura,Curso,Calificacion,Anio" PageSize="50" AllowPaging="True"
                                    OnRowEditing="OnRowEditing2" OnRowCancelingEdit="OnCancel2" BorderColor="#3399FF"
                                    HorizontalAlign="Center" OnRowCommand="GridView2_RowCommand">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Id" ItemStyle-Width="80px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdRegNPrev" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RegNota" ItemStyle-Width="80px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdRegN" runat="server" Text='<%# Eval("RegNotaId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="icuId" ItemStyle-Width="80px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblicuId" runat="server" Text='<%# Eval("icuId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asignatura" ItemStyle-Width="150" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAsignatura" runat="server" Text='<%# Eval("Asignatura") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Curso" ItemStyle-Width="80px" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCurso" runat="server" Text='<%# Eval("Curso") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Año" ItemStyle-Width="80px" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAnio" runat="server" Text='<%# Eval("Anio") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Calificación" ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCalPrev" runat="server" Text='<%# Eval("Calificacion") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCalPrev" runat="server" Text='<%# Eval("Calificacion") %>' Width="80"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha" ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFecha" runat="server" Text='<%# Eval("Fecha") %>' Width="80"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Link" ShowEditButton="TRUE" ShowCancelButton="false"
                                            ItemStyle-Width="100" HeaderText="Edición" EditText="Modificar" />

                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel2" />
                                            </EditItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Link" ShowInsertButton="TRUE" HeaderText="Inscripción" NewText="Rendirla Nuevamente" ItemStyle-Width="200" />

                                        <asp:TemplateField>
                                            <ItemTemplate>

                                                <asp:ImageButton ID="imbDelete" runat="server" ToolTip="Eliminar"
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar"
                                                    ImageUrl="~/img/delete-309165_960_720.png" Width="20px" />

                                            </ItemTemplate>
                                            <ItemStyle Width="13%" />
                                        </asp:TemplateField>



                                    </Columns>
                                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#CCCCFF" />
                                </asp:GridView>


                            </ContentTemplate>

                        </asp:UpdatePanel>



                    </div>
                </div>
            </div>

        </div>
    </div>

<script type="text/javascript">
    function imprimirTabla() {
        var panel = document.getElementById("<%=pnlContents.ClientID %>");
        var panelClone = panel.cloneNode(true);

        // Obtener información del alumno
        var studentName = document.getElementById("<%=aluNombre.ClientID %>").value;
        var studentDNI = document.getElementById("<%=aludni.ClientID %>").value;
        var studentCourse = document.getElementById("<%=txtCurso.ClientID %>").value;

        var prtwin = window.open('', 'panel', 'left=50,top=300,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');

        prtwin.document.write('<html><head><title>Impresión</title>');
        prtwin.document.write('<style>');
        prtwin.document.write('@media print { @page { size: A4 landscape; margin: 1cm; }');
        prtwin.document.write('table { border-collapse: collapse; width: 100%; }');
        prtwin.document.write('th, td { border: 1px solid black; padding: 4px; text-align: left; }');
        prtwin.document.write('}');
        prtwin.document.write('</style>');
        prtwin.document.write('</head><body>');
        prtwin.document.write('<p style="font-size: large; font-weight: bold; text-align: center; text-decoration: underline">Calificaciones por Alumno</p>');

        // Añadir información del alumno a la impresión
        prtwin.document.write('<div style="margin-bottom: 20px;">');
        prtwin.document.write('<p><strong>Alumno:</strong> ' + studentName + '</p>');
        prtwin.document.write('<p><strong>DNI:</strong> ' + studentDNI + '</p>');
        prtwin.document.write('<p><strong>Curso:</strong> ' + studentCourse + '</p>');
        prtwin.document.write('</div>');

        prtwin.document.write(panelClone.outerHTML);
        prtwin.document.write('</body></html>');

        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
    }
</script>



</asp:Content>
