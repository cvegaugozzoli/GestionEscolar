<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CargaCalifxEspCSec.aspx.cs" Inherits="CargaCalifxEspCSec" %>

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
            <%-- <div class="ibox collapsed">
                <div class="ibox-title">
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
                                <label class="control-label">Carrera</label>
                                <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-2">
                                <label class="control-label">Plan Estudio</label>
                                <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="form-group col-md-2">
                                <label class="control-label">Curso</label>
                                <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="form-group col-md-2">
                                <label class="control-label">Espacio Curricular</label>
                                <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="form-group col-md-2">
                                <label class="control-label">Año de Cursado</label>
                                <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                    AutoPostBack="false"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-2">
                                <label id="lblPeriodo" runat="server" class="control-label col-md-1">Periodo:</label>
                                <asp:DropDownList ID="PeriodoId" requeried="" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" BorderColor="Silver" OnSelectedIndexChanged="PeriodoId_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar..</asp:ListItem>
                                    <asp:ListItem Value="1">1° Cuatrimestre</asp:ListItem>
                                    <asp:ListItem Value="2">2° Cuatrimestre</asp:ListItem>

                                    <asp:ListItem Value="4">Eval. Final</asp:ListItem>
                                    <asp:ListItem Value="5">Rec. Dic.</asp:ListItem>
                                    <asp:ListItem Value="6">Rec. Mar.</asp:ListItem>
                                    <asp:ListItem Value="7">Eval. Definitiva</asp:ListItem>
                                    <asp:ListItem Value="8">Exámen Adicional</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <fieldset class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-0">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar1" class="btn btn-w-m btn-primary" runat="server" Text="Guardar Notas" OnClick="btnGuardar_Click" />
                                </div>
                            </div>
                        </fieldset>

                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
        </div>
    </div>

    <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium" Text="Atención: Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas"></asp:Label>
    </div>

    <div class="ibox-content">



        <div class="row">
            <div class="col-sm-12">



                <div id="dvGrid">
                    <div class="row">
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div id="alerMje" visible="false" runat="server" class="alert alert-dismissible  alert-dismissable">

                                 <p style="color: red; font-weight: bold; margin: 10px 0;">
    ⚠️ <u>Importante</u>:  Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas<br /> </p>                            </div>

                            <asp:Panel ID="pnlContents" runat="server">
                                <!-- Grilla de notas -->
                                <asp:GridView ID="GrillaNota" runat="server" CssClass="table table-striped"
                                    AutoGenerateColumns="False" OnRowDataBound="GrillaNota_RowDataBound"
                                    DataKeyNames="renId" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating"
                                    Width="100%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <Columns>
                                        <asp:TemplateField HeaderText="N°" ItemStyle-Width="50">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrden" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="renId" ItemStyle-Width="150" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrenId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="aluId" ItemStyle-Width="250" Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="aluId" runat="server" Text='<%# Eval("aluId") %>' Width="250"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="InscripcionCursado" ItemStyle-Width="250" Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="InscripcionCursado" runat="server" Text='<%# Eval("InscripcionCursado") %>' Width="250"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alumno" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lblAlumno" runat="server" NavigateUrl='<%# "CargaCalificacionesPorAlumnoSec.aspx?icuId=" + DataBinder.Eval(Container.DataItem,"InscripcionCursado").ToString() %>' Text='<%# Eval("aluNombre") %>' Width="250"></asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="1° Cuat." ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPCuat" runat="server" Text='<%# Eval("PCuatr") %>' Width="100"></asp:TextBox>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="2° Cuat" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSCuat" runat="server" Text='<%# Eval("SCuatr") %>' Width="90"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Promedio Anual" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPAnual" runat="server" Text='<%# Eval("PAnual") %>' Width="90"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Diciembre" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDiciembre" runat="server" Text='<%# Eval("NotaDic") %>' Width="90"></asp:TextBox>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Marzo" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMarzo" runat="server" Text='<%# Eval("NotaMar") %>' Width="90"></asp:TextBox>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ex. Adicional" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAdic" runat="server" Text='<%# Eval("NotaAdic") %>' Width="90"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Calif. Definitiva" ItemStyle-Width="100">
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
                            <!-- Panel para Asignar Nota -->
                            <asp:Panel ID="pnlAsignarNota" runat="server" Visible="false" CssClass="card p-3 mb-3">
                                <div class="row mt-3">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Notas" OnClick="btnGuardar_Click" CssClass="btn btn-primary w-100" />
                                    </div>
                                    <div class="form-group col-md-2 d-flex align-items-end">
                                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir tabla" Visible="false" OnClientClick="imprimirTabla(); return false;" CssClass="btn btn-danger" />
                                    </div>
                                </div>

                                <br />
                                <div class="panel panel-success">
                                    <div class="panel-heading" style="font-size: medium; font-weight: bold">
                                        Asignar por Lote
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="form-group col-md-4">
                                                <asp:Label ID="lblNota" runat="server" Text="Asignar Nota a Todos:" CssClass="control-label"></asp:Label>
                                                <asp:TextBox ID="TextNotaAsignar" runat="server" CssClass="form-control" />
                                            </div>
                                            <br />
                                            <div class="form-group col-md-2 d-flex align-items-end">
                                                <asp:Button ID="ButtonAsignar" runat="server" Text="Asignar" OnClick="ButtonAsignar_Click" CssClass="btn btn-primary" />
                                            </div>

                                            <asp:Label ID="lblMsjeErrorAsignar" runat="server" Text="" ForeColor="#CC3300" Font-Bold="True"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </asp:Panel>

                            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <br />
                <br />
                <br />
            </div>
        </div>

    </div>

    <asp:Label ID="LblMensajeErrorGrilla" runat="server" Text="" ForeColor="#CC3300" Font-Bold="True"></asp:Label>

    <script type="text/javascript">
        function imprimirTabla() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var panelClone = panel.cloneNode(true); // Clonamos para no modificar el original

            // Eliminar última columna de cada fila
            var filas = panelClone.querySelectorAll("tr");
            filas.forEach(function (fila) {
                if (fila.cells.length > 0) {
                    fila.deleteCell(fila.cells.length - 1);
                }
            });

            var prtwin = window.open('', 'panel', 'left=50,top=300,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');

            prtwin.document.write('<html><head><title>Impresión</title>');
            prtwin.document.write('<style>');
            prtwin.document.write('@media print { @page { size: A4 landscape; margin: 1cm; }');
            prtwin.document.write('table { border-collapse: collapse; width: 100%; }');
            prtwin.document.write('th, td { border: 1px solid black; padding: 4px; text-align: left; }');
            prtwin.document.write('}');
            prtwin.document.write('</style>');
            prtwin.document.write('</head><body>');
            prtwin.document.write('<p style="font-size: large; font-weight: bold; text-align: center; text-decoration: underline">calificaciones x Materia</p>');
            prtwin.document.write(panelClone.outerHTML);
            prtwin.document.write('</body></html>');

            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>


</asp:Content>
