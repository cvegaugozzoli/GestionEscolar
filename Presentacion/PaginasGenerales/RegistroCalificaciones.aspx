<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="RegistroCalificaciones.aspx.cs" Inherits="RegistroCalificaciones" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="ibox-content">
            <div class="col-sm-12">


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
                                <label class="control-label">Año de Cursado</label>
                                <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                    AutoPostBack="false"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-2">
                                <label id="lblPeriodo" runat="server" class="control-label col-md-1">Periodo:</label>
                                <asp:DropDownList ID="PeriodoId" requeried="" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" BorderColor="Silver" OnSelectedIndexChanged="PeriodoId_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar..</asp:ListItem>
                                    <asp:ListItem Value="1">1° Trimestre.</asp:ListItem>
                                    <asp:ListItem Value="2">2° Trimestre.</asp:ListItem>
                                    <asp:ListItem Value="3">3° Trimestre.</asp:ListItem>
                                    <asp:ListItem Value="4">Calificación Final</asp:ListItem>
                                    <asp:ListItem Value="5">Taller Dic.</asp:ListItem>
                                    <asp:ListItem Value="6">Taller Mar.</asp:ListItem>
                                    <asp:ListItem Value="7">Eval. Definitiva</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <fieldset class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-0">
                                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                                </div>
                            </div>
                        </fieldset>
                        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        <asp:Panel ID="pnlContents" runat="server">
                            <div class="col-sm-12">
                                <div id="divImprimir">
                                    <div class="table-responsive">

                                        <%--<div style="overflow-x: auto; max-width: 100%;">--%>
                                        <asp:GridView ID="gvNotas" runat="server"
                                            CssClass="table table-bordered table-sm " AutoGenerateColumns="true"
                                            OnRowDataBound="gvNotas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="x-Small" CssClass="wrap-header" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="11px" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                        <%-- </div>--%>
                                    </div>
                                </div>
                        </asp:Panel>
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir tabla" Visible="false" OnClientClick="imprimirTabla(); return false;" CssClass="btn btn-primary" />
                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
        </div>





        <div class="row">
            <div class="col-sm-12">
                <div id="alerMje" visible="false" runat="server" class="alert alert-dismissible  alert-dismissable">
                    <asp:Label ID="lblMje" runat="server" Font-Bold="True" Font-Size="Medium" Text="Atención: Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas"></asp:Label>
                </div>

                <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                    <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium" Text="Atención: Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas"></asp:Label>
                </div>

                <div id="dvGrid">
                    <div class="row">
                    </div>

                    <br />
                    <br />
                    <br />
                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        function imprimirTabla() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
           var prtwin = window.open('', 'panel', 'left=50,top=300,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');

           prtwin.document.write('<html><head><title>Impresión</title>');
           prtwin.document.write('<style>');
           prtwin.document.write('@media print { @page { size: A4 landscape; margin: 1cm; }');
           prtwin.document.write('table { border-collapse: collapse; width: 100%; }');
           prtwin.document.write('th, td { border: 1px solid black; padding: 4px; text-align: left; }');
           prtwin.document.write('}');
           prtwin.document.write('</style>');
           prtwin.document.write('</head><body>');
           prtwin.document.write('<p style="font-size: large; font-weight: bold; text-align: center; text-decoration: underline">Registro de calificaciones</p>');
           prtwin.document.write(panel.outerHTML);
           prtwin.document.write('</body></html>');

           prtwin.document.close();
           prtwin.focus();
           prtwin.print();
           prtwin.close();
       }
       
    </script>

    <%--  <script type="text/javascript">
        function imprimirTabla() {
            var contenido = document.getElementById("divImprimir").innerHTML;
            var ventana = window.open('', '', 'height=700,width=1000');
            ventana.document.write('<html><head><title>Notas</title>');
            ventana.document.write('<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">');
            ventana.document.write('<style>');
            ventana.document.write('@media print {@page { size: landscape; } body * { visibility: hidden; } #divImprimir, #divImprimir * { visibility: visible; } #divImprimir { position: absolute; left: 0; top: 0; width: 100%; } table { font-size: 12px; }}');
            ventana.document.write('</style>');
            ventana.document.write('</head><body>');
            ventana.document.write('<div id="divImprimir">');
            ventana.document.write(contenido);
            ventana.document.write('</div></body></html>');
            ventana.document.close();
            ventana.print();
        }
    </script>--%>


    <asp:Label ID="LblMensajeErrorGrilla" runat="server" Text="" ForeColor="#CC3300" Font-Bold="True"></asp:Label>
</asp:Content>
