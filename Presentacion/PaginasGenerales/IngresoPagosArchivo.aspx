<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="IngresoPagosArchivo.aspx.cs" Inherits="IngresoPagosArchivo" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="ibox-content">
            <div class="form-group">
                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblColegioId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblLugarPago" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="row">
                <div class="form-group col-md-2">
                    <label class="control-label">Bancos Adheridos</label>
                    <asp:DropDownList ID="BcoAdhId" AutoPostBack="true" class="form-control m-b" runat="server" OnSelectedIndexChanged="BcoAdhId_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1">Caja Municipal</asp:ListItem>
                        <asp:ListItem Value="2">Patagonia</asp:ListItem>
                        <asp:ListItem Value="3">SIRO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="PnlBanco" visible="true" runat="server">
                    <label class="control-label">Buscar Archivo</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>

                <div id="PnlSiro" visible="false" runat="server">

                    <div class="form-group col-md-3">
                        <label class="control-label">Desde:</label>
                        <asp:TextBox ID="txtDesde" type="DateTimePicker" placeholder="dd/mm/aaaa" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label">Hasta:</label>
                        <asp:TextBox ID="txtHasta" type="DateTimePicker" placeholder="dd/mm/aaaa" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnListar" class="btn btn-w-m btn-primary" runat="server" OnClientClick="javascript:ShowProgressBar()" Text="Listar" align="left" OnClick="Listar_Click" Width="100%" />
                    </div>
                    <div id="dvProgressBar" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.5;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="../images/ajax-loader.gif" AlternateText="Cargando ..." ToolTip="Cargando ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Salir" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblColegio" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <br />
                <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <asp:Label ID="Label8" runat="server" Text="" Visible="true"></asp:Label><br />
            <div class="row">
                <div class="ibox-title" id="listado" runat="server" visible="false">
                    <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                </div>

                <div class="table-responsive">

                    <asp:GridView ID="GrillaCaja" runat="server" GridLines="None" DataKeyNames="aluId,icoId,Nombre,NroCuota, Concepto,FechaPago,Importe,NroComprobante,Imputa,Curso,Observaciones"
                        CssClass="table table-striped" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="aluId" HeaderText="aluId" Visible="false" />
                            <asp:BoundField DataField="icoId" HeaderText="icoId" Visible="false" />
                            <asp:BoundField DataField="Nombre" HeaderText="Alumno" />
                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                            <asp:BoundField DataField="NroCuota" HeaderText="NroCuota" />
                            <asp:BoundField DataField="NroComprobante" Visible="false" HeaderText="Nro Banco" />
                            <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                            <asp:BoundField DataField="Imputa" HeaderText="Imputa" />
                            <asp:BoundField DataField="Curso" HeaderText="Curso" />

                            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />

                        </Columns>
                        <HeaderStyle BackColor="#ffcccc" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </div>



                <asp:GridView ID="GridView1" runat="server" GridLines="None" DataKeyNames="aluId,icoId,Nombre,NroCuota, Concepto,FechaPago,Importe,NroComprobante,Imputa,Curso,adeCBU,Observaciones,insid"
                    CssClass="table table-striped" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="aluId" HeaderText="aluId" Visible="false" />
                        <asp:BoundField DataField="icoId" HeaderText="icoId" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Alumno" />
                        <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                        <asp:BoundField DataField="NroCuota" HeaderText="NroCuota" />
                        <asp:BoundField DataField="NroComprobante" Visible="false" HeaderText="Nro Banco" />
                        <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" />
                        <asp:BoundField DataField="Imputa" HeaderText="Imputa" />
                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
                        <asp:BoundField DataField="adeCBU" HeaderText="CBU" />
                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                        <asp:BoundField DataField="insid" HeaderText="insid" Visible="false" />

                    </Columns>
                    <HeaderStyle BackColor="#ffcccc" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>

                <div id="alerMje" visible="false" runat="server" class="alert alert-dismissible  alert-dismissable">
                    <p style="color: red; font-weight: bold; margin: 10px 0;">
                        ⚠️ <u>Importante</u>: Debe imputar los pagos recibidos desde SiroPagos para actualizar las formas de pago y completar el registro en el sistema...
                        <br />
                    </p>
                </div>

                <asp:GridView ID="GrillaSiro" runat="server" OnRowDataBound="GrillaSiro_RowDataBound"
                    DataKeyNames="aluId,cocId,cdeId, icoId,cfpId,Nombre,NroCuota,Anio,Concepto,Observacion,FechaPago,Importe,Curso,inp_IdReferenciaOperacion,CanalCobro
                    ,CodRechazo,Cuotas,Tarjetas,ImpotePagado,FechaAcreditacion,FechaPagoSiro,FormaPago,NroCupon"
                    CssClass="table table-striped" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="aluId" HeaderText="aluId" Visible="false" />
                        <asp:BoundField DataField="cocId" HeaderText="cocId" Visible="false" />
                        <asp:BoundField DataField="cdeId" HeaderText="cdeId" Visible="false" />
                        <asp:BoundField DataField="icoId" HeaderText="icoId" Visible="false" />
                        <asp:BoundField DataField="cfpId" HeaderText="cfpId" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Alumno" />
                        <asp:BoundField DataField="Curso" HeaderText="Curso" /> 
                        <asp:BoundField DataField="Anio" HeaderText="Anio" visible="false"/>
                        <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                        <asp:BoundField DataField="NroCuota" HeaderText="NroCuota" />
                        <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" />
                        <asp:BoundField DataField="inp_IdReferenciaOperacion" HeaderText="inp_IdReferenciaOperacion" Visible="false" />
                        <asp:BoundField DataField="CanalCobro" HeaderText="CanalCobro" Visible="false" />
                        <asp:BoundField DataField="CodRechazo" HeaderText="CodRechazo" Visible="false" />
                        <asp:BoundField DataField="Cuotas" HeaderText="Cuotas" Visible="false" />
                        <asp:BoundField DataField="Tarjetas" HeaderText="Tarjetas" Visible="true" />
                        <asp:BoundField DataField="ImpotePagado" HeaderText="ImpotePagado" Visible="false" />
                        <asp:BoundField DataField="FechaAcreditacion" HeaderText="FechaAcreditacion" Visible="false" />
                        <asp:BoundField DataField="FechaPagoSiro" HeaderText="FechaPago" Visible="false" />
                        <asp:BoundField DataField="FormaPago" HeaderText="Forma de Pago" />
                        <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                       <asp:BoundField DataField="NroCupon" HeaderText="Observación" Visible="false" />
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
                <div class="ibox-content">
                    <div class="row">
                        <div class="form-group">
                            <asp:Button ID="btnImputar" class="btn btn-w-m btn-primary" runat="server" Text="Imputar"
                                OnClick="btnImputar_Click" BackColor="#003366" ForeColor="White" />
                            &nbsp;<asp:Button ID="btnImprimir" class="btn btn-w-m btn-danger" runat="server" Text="Imprimir"
                                OnClick="btnImprimir_Click" Visible="false" />
                           
                       <asp:Button ID="btnImprimirSiro" class="btn btn-w-m btn-danger" runat="server" Text="Imprimir"
            OnClientClick="printGrid(); return false;" Visible="false" />
                        </div>
                    </div>
                    <div class="row">
                        <div id="AlerInfo" visible="false" runat="server" class="alert alert-primary  alert-dismissable" style="color: #000000">
                            <p style="font-size: medium; font-weight: bold;">I = Imputado&nbsp;&nbsp;&nbsp;&nbsp; E= Existente&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NE= No Existente&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DFP= Diferente Forma de Pago</p>
                        </div>
                        <div id="AlerExito" visible="false" runat="server" class="alert alert-info  alert-info">
                            <asp:Label ID="lblAlerExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            <%--<p style="font-size: medium; font-weight: bold;">I = Imputado&nbsp;&nbsp;&nbsp;&nbsp; E= Existente&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NE= No Existente&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DFP= Diferente Forma de Pago</p>--%>
                        </div>
                    </div>
                </div>

                <div class="row" style="background-color: #FFFFFF">
                    <div class="form-group">
                        <asp:Label ID="lblMej" runat="server" Text="" Font-Bold="True" ForeColor="#3333CC" Font-Size="Medium"></asp:Label>
                        &nbsp;
                    </div>
                </div>
            </div>
        </div>
    </div>
<script type="text/javascript">
  function printGrid() {
    var gridData = document.getElementById('<%= GrillaSiro.ClientID %>');
    var windowUrl = 'about:blank';
    var uniqueName = new Date();
    var windowName = 'Print_' + uniqueName.getTime();
    var prtWindow = window.open(windowUrl, windowName, 'left=100,top=100,width=1000,height=800');

    // Clonar el contenido del grid para no modificar el original
    var clonedGrid = gridData.cloneNode(true);

    // Ocultar columnas: Curso (1), Tarjetas (10), Forma de Pago (11)
    var columnsToHide = [1, 10, 11];

    for (var i = 0; i < clonedGrid.rows.length; i++) {
      for (var j = 0; j < columnsToHide.length; j++) {
        var colIndex = columnsToHide[j];
        if (clonedGrid.rows[i].cells[colIndex]) {
          clonedGrid.rows[i].cells[colIndex].style.display = 'none';
        }
      }
    }

    prtWindow.document.write('<html><head><title></title>');
    prtWindow.document.write('<style>');
    prtWindow.document.write('body { font-family: Arial; margin: 20px; }');
    prtWindow.document.write('h2 { text-align: center; margin-bottom: 20px; }');
    prtWindow.document.write('table { width: 100%; border-collapse: collapse; table-layout: auto; }');
    prtWindow.document.write('th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }');
    prtWindow.document.write('@media print { body { margin: 0; } table { page-break-inside: avoid; } th, td { white-space: normal; } }');
    prtWindow.document.write('</style></head><body>');

    prtWindow.document.write('<h2>Imputación del Sistema de Cobro SIRO</h2>');
    prtWindow.document.write(clonedGrid.outerHTML);
    prtWindow.document.write('</body></html>');

    prtWindow.document.close();
    prtWindow.focus();
    prtWindow.print();
    prtWindow.close();
  }
</script>

</asp:Content>
