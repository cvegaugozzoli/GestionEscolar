<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalPadres.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="EstadoCuentaTutor.aspx.cs" Inherits="EstadoCuentaTutor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PrincipalPadres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div class="ibox-content">

        <div class="form-row" style="background-color: #FFFFFF">
            <%-- <div class="form-group col-md-4" style="background-color: #FFFFFF">
                <label>Buscar por:&nbsp;&nbsp;&nbsp; </label>
                <asp:RadioButtonList AutoPostBack="true" CssClass="form-check form-check-inline" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                    <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                    <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>--%>

            <div class="form-group col-md-2">
                <label class="control-label">Año Lectivo</label>
                <asp:TextBox ID="txtAnioLectivo" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
            </div>
            <div class="form-group col-md-2">
                <br />
                <asp:Button ID="btnActualizar" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Actualizar" OnClick="btnActualizar_Click" />
            </div>
            <div class="form-group col-md-2">
                <br />
                <label class="control-label">Solo adeudados</label>
                <asp:CheckBox ID="ckbDeuda" Checked="false" AutoPostBack="true" runat="server" OnCheckedChanged="ckbDeuda_CheckedChanged" />
            </div>


            <div class="form-group col-md-2">
                <br />
                <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
            </div>

            <div class="form-group col-md-2">
                <br />
                <asp:Button ID="BtnLibreDeuda" class="btn btn-w-m btn-danger" runat="server" Text="Libre Deuda" OnClick="btnImprimirClickLD_Click" />
            </div>
        </div>





        <div class="ibox-content" runat="server" visible="false">
            <div class="row" style="background-color: #FFFFFF" runat="server" visible="false">

                <div class="form-group col-md-2">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true" Visible="false"></asp:Label>
                    <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" Visible="false" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group col-md-5">
                    <asp:Label class="control-label" ID="LblApe" runat="server" Text="Nombre: " Visible="false" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" Visible="false" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>

                <%--                <div class="form-group col-md-5">
                    <asp:Label class="control-label" ID="Label1" runat="server" Text="Link Pagos: " Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtLinkPago" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>--%>


                <%--   <div class="form-group col-md-3">
                <asp:Label class="control-label" ID="lblColegio" runat="server" Text="Colegio: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aluColegio" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            </div>--%>
            </div>


        </div>
        <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" runat="server"></asp:TextBox>
        <asp:HiddenField ID="hfNombreAlumno" runat="server" />

        <div class="row">
            <div class="col-sm-12">
                <p style="color: red; margin: 10px 0;">
                    ⚠️ <u>Importante</u>: Toca una fila para ver más detalles.<br />
                </p>
                <div class="ibox-content">
                    <div class="table-responsive">
                        <asp:GridView ID="GrillaHistorial" runat="server"
                            DataKeyNames="icoId,cntId,conId,Dcto,TipoConcepto,Concepto,Importe,ImporteInteres,
                            AnioLectivo,Beca,BecId,BecasInteres,NroCuota,FchInscripcion,FechaVto,ImpPagado,FechaPago,NroCompbte,Curso,Colegio, FP"
                            GridLines="None"
                            CssClass="table table-striped table-hover table-condensed"
                            OnRowDataBound="GrillaHistorial_RowDataBound"
                            AutoGenerateColumns="False"
                            OnRowCommand="GrillaHistorial_RowCommand">

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#CCCCFF" />

                            <EmptyDataTemplate>
                                <div class="alert alert-info" role="alert">
                                    No hay registros disponibles para el año lectivo seleccionado o los filtros aplicados.
                                </div>
                            </EmptyDataTemplate>

                            <Columns>

                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                    </ItemTemplate>

                                    <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                    <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="icoId" HeaderText="icoId" Visible="false" />
                                <asp:BoundField DataField="conId" HeaderText="conId" Visible="false" />
                                <asp:BoundField DataField="cntId" HeaderText="cntId" Visible="false" />
                                <asp:BoundField DataField="TipoConcepto" HeaderText="Tipo Concepto" Visible="false" />

                                <%-- SIEMPRE VISIBLES --%>
                                <asp:BoundField DataField="Concepto" HeaderText="Concepto" ItemStyle-CssClass="col-concept" />


                                <%-- OCULTAS EN CELULARES --%>
                                <asp:BoundField DataField="NroCuota" HeaderText="Cuota"
                                    ItemStyle-CssClass="col-cuota" HeaderStyle-CssClass="col-cuota" />
                                <asp:BoundField DataField="Importe" HeaderText="Importe"
                                    ItemStyle-CssClass="col-importe" HeaderStyle-CssClass="col-importe" />



                                <asp:BoundField DataField="FechaVto" HeaderText="Fecha Vto" DataFormatString="{0:d}"
                                    ItemStyle-CssClass="col-FechaVto" HeaderStyle-CssClass="col-FechaVto" />

                                <asp:BoundField DataField="ImporteInteres" HeaderText="Intereses" DataFormatString="{0:C}"
                                    ItemStyle-CssClass="col-ImporteInteres" HeaderStyle-CssClass="col-ImporteInteres" />

                                <asp:BoundField DataField="Beca" HeaderText="Beca"
                                    ItemStyle-CssClass="col-Beca" HeaderStyle-CssClass="col-Beca" />

                                <asp:BoundField DataField="ImporteTotal" HeaderText="Importe a Pagar" DataFormatString="{0:C}"
                                    ItemStyle-CssClass="col-ImporteTotal" HeaderStyle-CssClass="col-ImporteTotal" />
                                <asp:BoundField DataField="ImpPagado" HeaderText="Imp. Pagado" DataFormatString="{0:C}"
                                    ItemStyle-CssClass="col-ImpPagado" HeaderStyle-CssClass="col-ImpPagado" />
                                <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- CAMPOS OCULTOS --%>
                                <asp:BoundField DataField="FP" HeaderText="Forma de Pago" Visible="false"
                                    ItemStyle-CssClass="col-FP" HeaderStyle-CssClass="col-FP" />
                                <asp:BoundField DataField="AnioLectivo" HeaderText="Año Lectivo" Visible="false" />
                                <asp:BoundField DataField="BecId" HeaderText="BecId" Visible="false" />
                                <asp:BoundField DataField="FchInscripcion" HeaderText="FchInscripcion" Visible="false" />
                                <asp:BoundField DataField="ValorInteres" HeaderText="ValorInteres" Visible="false" />
                                <asp:BoundField DataField="Dcto" HeaderText="Dscto" Visible="false" />
                                <asp:BoundField DataField="Colegio" HeaderText="Colegio" Visible="false" />
                                <asp:BoundField DataField="insId" HeaderText="insId" Visible="false" />
                                <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" ItemStyle-CssClass="FechaPago" Visible="false" />
                                <asp:BoundField DataField="NroCompbte" HeaderText="NroCompbte" ItemStyle-CssClass="NroCompbte" Visible="false" />
                                <asp:BoundField DataField="Curso" HeaderText="Curso" ItemStyle-CssClass="Curso" Visible="false" />




                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
                <asp:Label ID="lblMjerror2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>
        </div>


        <div class="modal fade" id="detalleModal" tabindex="-1" role="dialog" aria-labelledby="detalleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="detalleModalLabel">Detalle del Concepto</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="card">
                            <div class="card-body">

                                <h3><strong><span id="modalAlumnoNombre"></span></strong></h3>

                                <h3 class="card-title fw-bold" id="modalConcepto"></h3>
                                <p class="card-text">
                                    <strong>Colegio:</strong> <span id="modalColegio"></span>
                                    <br />
                                    <strong>Curso:</strong> <span id="modalCurso"></span>
                                    <br />
                                    <strong>Número de Cuota:</strong> <span id="modalNroCuota"></span>
                                    <br />
                                    <strong>Importe Arancel:</strong> <span id="modalImporte"></span>
                                    <br />
                                    <strong>Intereses:</strong> <span id="modalIntereses"></span>
                                    <br />
                                    <strong>Beca:</strong> <span id="modalBeca"></span>
                                    <br />
                                    <strong>Descuento:</strong> <span id="modalDcto"></span>
                                    <br />
                                    <strong>Importe Total:</strong> <span id="modalImporteTotal"></span>
                                    <br />
                                    <strong>Fecha Vencimiento:</strong> <span id="modalFechaVto"></span>
                                    <br />

                                    <strong>Importe Pagado:</strong> <span id="modalImpPagado"></span>
                                    <br />
                                    <strong>Fecha Pago:</strong> <span id="modalFechaPago"></span>
                                    <br />

                                    <strong>Forma de Pagado:</strong> <span id="modalFP"></span>
                                    <br />

                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="ibox-content">
                <div class="form-group col-md-3">
                    <asp:Label ID="lblTot" Visible="false" runat="server" Text="Deuda:" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtTot" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>
                <div class="form-group col-md-2" runat="server" visible="false">
                    <br />
                    <asp:Button ID="btnImprimir2" class="btn btn-w-m btn-warning" runat="server" Text="Imprimir" Visible="false" OnClick="btnImprimirClick" Width="100%" />
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lblCuotas" runat="server" Text="Total Cuotas Vencidas:" Font-Bold="true" Visible="false"></asp:Label>
                    <asp:TextBox ID="TexCuotas" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <asp:Label ID="lblInt" Visible="false" runat="server" Text="Total Intereses:" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtIntereses" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group col-md-2">
                    <asp:Button ID="btnFacturar" class="btn btn-w-m btn-warning" runat="server" Text="Pagar" Visible="true" OnClick="btnFacturarClick" Width="100%" />
                </div>
            </div>

            <%--   <div class="row">
                <div class="form-inline col-md-12">
                    <div class="form-group col-md-4">
                        <asp:TextBox ID="txtcELESTE" BackColor="LightBlue" Text="Pagada" ForeColor="Black" Font-Bold="true" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                    </div>         
                    <div class="form-group col-md-4">
                        <asp:TextBox ID="txtRojo" BackColor="Red" Text="Vencida" ForeColor="White" Font-Bold="true" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                    </div>                
                </div>
            </div>--%>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>

    <script>
        $(document).ready(function () {
            console.log("jQuery ready y script personalizado cargado.");

            var gridviewId = '<%= GrillaHistorial.ClientID %>';
            console.log("ID del GridView en JavaScript: " + gridviewId);

            $('#' + gridviewId).on('click', 'tbody tr', function (event) {
                console.log("Click detectado en fila de GridView.");

                if ($(event.target).is('a, button, input[type="button"], input[type="submit"]')) {
                    console.log("Click en botón o enlace, ignorando.");
                    return;
                }
                var nombreAlumno = $('#<%= hfNombreAlumno.ClientID %>').val();

                var concepto = $(this).data('concepto');
                var importe = $(this).data('importe');
                var intereses = $(this).data('intereses');
                var importeTotal = $(this).data('importetotal');
                var beca = $(this).data('beca');
                var nroCuota = $(this).data('nrocuota');
                var fechaVto = $(this).data('fechavto');
                var dcto = $(this).data('dcto');
                var impPagado = $(this).data('imppagado');
                var fechaPago = $(this).data('fechapago');
                var colegio = $(this).data('colegio');
                var curso = $(this).data('curso');
                var conId = $(this).data('conid');
                //var FP = $(this).data('FP');
                var FP = $(this).data('fp');
                console.log("Datos de la fila: ", { concepto: concepto, importe: importe, conId: conId });

                $('#modalAlumnoNombre').text(nombreAlumno);
                $('#modalConcepto').text(concepto);
                $('#modalImporte').text(importe);
                $('#modalIntereses').text(intereses);
                $('#modalImporteTotal').text(importeTotal);
                $('#modalBeca').text(beca);
                $('#modalNroCuota').text(nroCuota);
                $('#modalFechaVto').text(fechaVto);
                $('#modalDcto').text(dcto);
                $('#modalImpPagado').text(impPagado);
                $('#modalFechaPago').text(fechaPago);
                $('#modalColegio').text(colegio);
                $('#modalCurso').text(curso);
                $('#modalFP').text(FP);
                $('#detalleModal').modal('show');
                console.log("Intentando mostrar el modal.");
            });
        });
    </script>

    <script>
        function ajustarColumnasGridView() {
            var ancho = window.innerWidth;

            if (ancho < 576) { // Tamaño móvil (como xs en Bootstrap)
                document.querySelectorAll(" .col-importe, .col-FechaVto,.col-ImporteInteres,.col-Beca,.col-ImporteTotal,.col-ImpPagado,.col-FP").forEach(el => el.style.display = "none");
            } else {
                document.querySelectorAll(".col-cuota, .col-importe, .col-FechaVto,.col-ImporteInteres,.col-Beca,.col-ImporteTotal,.col-ImpPagado, .col-FP ").forEach(el => el.style.display = "table-cell");
            }
        }

        window.addEventListener("load", ajustarColumnasGridView);
        window.addEventListener("resize", ajustarColumnasGridView);
    </script>
</asp:Content>

