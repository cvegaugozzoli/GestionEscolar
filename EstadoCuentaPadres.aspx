<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalPadres.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="EstadoCuentaPadres.aspx.cs" Inherits="EstadoCuentaPadres" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PrincipalPadres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="ibox-content">

        <div class="form-row" style="background-color: #FFFFFF">
            <div class="form-group col-md-2 col-sm-6 col-xs-6" id="divAnioLectivo">
                <label class="control-label label-anio-lectivo" for="txtAnioLectivo" style="display: block;">Año Lectivo</label>
                <asp:TextBox ID="txtAnioLectivo" type="text" class="form-control" runat="server" BorderColor="Silver" placeholder="Año Lectivo"></asp:TextBox>
            </div>

            <div class="form-group col-md-2 col-sm-6 col-xs-6" style="padding-top: 5px;">
                <asp:CheckBox ID="ckbDeuda" Checked="false" AutoPostBack="true" runat="server" OnCheckedChanged="ckbDeuda_CheckedChanged" />
                <label for="ckbDeuda" class="control-label">Solo Adeudados</label>
            </div>

            <div class="form-group col-md-2 col-sm-6 col-xs-6">
                <asp:Button ID="btnActualizar" class="btn btn-w-m btn-primary btn-block" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Actualizar" OnClick="btnActualizar_Click" />
            </div>

            <div class="form-group col-md-2 col-sm-6 col-xs-6">
                <asp:Button ID="BtnLibreDeuda" class="btn btn-w-m btn-danger btn-block" runat="server" Text="Libre Deuda" OnClick="btnImprimirClickLD_Click" />
            </div>

            <div class="form-group col-md-2" style="display: none;">
                <br />
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
            </div>
        </div>
        <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" runat="server"></asp:TextBox>
        <asp:HiddenField ID="hfNombreAlumno" runat="server" />

        <div class="row">
            <div class="col-sm-12">
                <p style="color: red; margin: 10px 0;">
                    ⚠️ <b>Toca una fila para ver más detalles.</b><br />
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
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-chk">
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

                                <asp:BoundField DataField="Concepto" HeaderText="Concepto" ItemStyle-CssClass="col-concept" />
                                <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- OCULTAS EN CELULARES, VISIBLES EN DESKTOP --%>
                                <asp:BoundField DataField="NroCuota" HeaderText="Cuota" ItemStyle-CssClass="col-cuota" HeaderStyle-CssClass="col-cuota" />
                                <asp:BoundField DataField="Importe" HeaderText="Importe" ItemStyle-CssClass="col-importe" HeaderStyle-CssClass="col-importe" />
                                <asp:BoundField DataField="FechaVto" HeaderText="Fecha Vto" DataFormatString="{0:d}" ItemStyle-CssClass="col-FechaVto" HeaderStyle-CssClass="col-FechaVto" />
                                <asp:BoundField DataField="ImporteInteres" HeaderText="Intereses" DataFormatString="{0:C}" ItemStyle-CssClass="col-ImporteInteres" HeaderStyle-CssClass="col-ImporteInteres" />
                                <asp:BoundField DataField="Beca" HeaderText="Beca" ItemStyle-CssClass="col-Beca" HeaderStyle-CssClass="col-Beca" />
                                <asp:BoundField DataField="ImporteTotal" HeaderText="Importe a Pagar" DataFormatString="{0:C}" ItemStyle-CssClass="col-ImporteTotal" HeaderStyle-CssClass="col-ImporteTotal" />
                                <asp:BoundField DataField="ImpPagado" HeaderText="Imp. Pagado" DataFormatString="{0:C}" ItemStyle-CssClass="col-ImpPagado" HeaderStyle-CssClass="col-ImpPagado" />

                                <%-- CAMPOS OCULTOS SIEMPRE O POR DEFECTO --%>
                                <asp:BoundField DataField="FP" HeaderText="Forma de Pago" Visible="false" ItemStyle-CssClass="col-FP" HeaderStyle-CssClass="col-FP" />
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

        <div class="modal fade" id="modalDetalle" tabindex="-1" role="dialog" aria-labelledby="modalDetalleLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalDetalleLabel">Detalle del Concepto</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p><strong>Concepto:</strong> <span id="lblModalConcepto"></span></p>
                        <p><strong>Importe:</strong> <span id="lblModalImporte"></span></p>
                        <p><strong>Intereses:</strong> <span id="lblModalIntereses"></span></p>
                        <p><strong>Importe Total:</strong> <span id="lblModalImporteTotal"></span></p>
                        <p><strong>Beca:</strong> <span id="lblModalBeca"></span></p>
                        <p><strong>Nro Cuota:</strong> <span id="lblModalNroCuota"></span></p>
                        <p><strong>Fecha Vencimiento:</strong> <span id="lblModalFechaVto"></span></p>
                        <p><strong>Descuento:</strong> <span id="lblModalDcto"></span></p>
                        <p><strong>Importe Pagado:</strong> <span id="lblModalImpPagado"></span></p>
                        <p><strong>Fecha Pago:</strong> <span id="lblModalFechaPago"></span></p>
                        <p><strong>Colegio:</strong> <span id="lblModalColegio"></span></p>
                        <p><strong>Curso:</strong> <span id="lblModalCurso"></span></p>
                        <%--<p><strong>ConID:</strong> <span id="lblModalConId"></span></p>--%>
                        <p><strong>Forma de Pago:</strong> <span id="lblModalFP"></span></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

        <%--        <div class="modal fade" id="detalleModal" tabindex="-1" role="dialog" aria-labelledby="detalleModalLabel" aria-hidden="true">
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
                                    <strong>Colegio:</strong> <span id="modalColegio"></span><br />
                                    <strong>Curso:</strong> <span id="modalCurso"></span><br />
                                    <strong>Número de Cuota:</strong> <span id="modalNroCuota"></span><br />
                                    <strong>Importe Arancel:</strong> <span id="modalImporte"></span><br />
                                    <strong>Intereses:</strong> <span id="modalIntereses"></span><br />
                                    <strong>Beca:</strong> <span id="modalBeca"></span><br />
                                    <strong>Descuento:</strong> <span id="modalDcto"></span><br />
                                    <strong>Importe Total:</strong> <span id="modalImporteTotal"></span><br />
                                    <strong>Fecha Vencimiento:</strong> <span id="modalFechaVto"></span><br />
                                    <strong>Importe Pagado:</strong> <span id="modalImpPagado"></span><br />
                                    <strong>Fecha Pago:</strong> <span id="modalFechaPago"></span><br />
                                    <strong>Forma de Pagado:</strong> <span id="modalFP"></span><br />
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>--%>

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
                    <br />
                    <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnFacturar" class="btn btn-w-m btn-warning" runat="server" Text="Pagar" Visible="false" OnClick="btnFacturarClick" Width="100%" />
                </div>
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>

    <script>
        $(document).ready(function () { [cite: 182]
            console.log("jQuery ready y script personalizado cargado."); [cite: 183]

            var gridviewId = '<%= GrillaHistorial.ClientID %>'; [cite: 184]
            console.log("ID del GridView en JavaScript: " + gridviewId); [cite: 185]
            $('#' + gridviewId).on('click', 'tbody tr', function (event) { [cite: 185]
                console.log("Click detectado en fila de GridView."); [cite: 185]

                if ($(event.target).is('a, button, input[type="button"], input[type="submit"], input[type="checkbox"]')) { [cite: 185]
                    console.log("Click en botón, enlace o checkbox, ignorando."); [cite: 185]
                    return; [cite: 186]
                }

                var nombreAlumno = $('#<%= hfNombreAlumno.ClientID %>').val(); [cite: 186]
                var concepto = $(this).data('concepto'); [cite: 186]
                var importe = $(this).data('importe'); [cite: 186]
                var intereses = $(this).data('intereses'); [cite: 187]
                var importeTotal = $(this).data('importetotal'); [cite: 187]
                var beca = $(this).data('beca'); [cite: 187]
                var nroCuota = $(this).data('nrocuota'); [cite: 187]
                var fechaVto = $(this).data('fechavto'); [cite: 188]
                var dcto = $(this).data('dcto'); [cite: 188]
                var impPagado = $(this).data('imppagado'); [cite: 189]
                var fechaPago = $(this).data('fechapago'); [cite: 190]
                var colegio = $(this).data('colegio'); [cite: 191]
                var curso = $(this).data('curso'); [cite: 192]
                var conId = $(this).data('conid'); [cite: 193]
                var FP = $(this).data('fp'); [cite: 194]
                console.log("Datos de la fila: ", { concepto: concepto, importe: importe, conId: conId }); [cite: 195]

                $('#modalAlumnoNombre').text(nombreAlumno); [cite: 196]
                $('#modalConcepto').text(concepto); [cite: 197]
                $('#modalImporte').text(importe); [cite: 198]
                $('#modalIntereses').text(intereses); [cite: 199]
                $('#modalImporteTotal').text(importeTotal); [cite: 200]
                $('#modalBeca').text(beca); [cite: 201]
                $('#modalNroCuota').text(nroCuota); [cite: 202]
                $('#modalFechaVto').text(fechaVto); [cite: 203]
                $('#modalDcto').text(dcto); [cite: 204]
                $('#modalImpPagado').text(impPagado); [cite: 205]
                $('#modalFechaPago').text(fechaPago); [cite: 206]
                $('#modalColegio').text(colegio); [cite: 207]
                $('#modalCurso').text(curso); [cite: 208]
                $('#modalFP').text(FP); [cite: 209]
                $('#detalleModal').modal('show'); [cite: 210]
                console.log("Intentando mostrar el modal."); [cite: 211]
            });
        }); [cite: 213]
    </script>

    <style type="text/css">
        /* Estilos generales para el formulario de filtros */
        .form-row {
            display: flex; /* [cite: 214] */
            flex-wrap: wrap; /* Permite que los elementos se envuelvan a la siguiente línea [cite: 214] */
            justify-content: flex-start; /* Alinea los elementos al inicio [cite: 215] */
            align-items: flex-end; /* Alinea los elementos al final de su línea [cite: 216] */
        }

        /* Ajuste para el label "Año Lectivo" - siempre visible */
        .label-anio-lectivo {
            display: block !important; /* Asegura que el label sea visible siempre */
        }

        /* Ajuste para el checkbox "Solo Adeudados" */
        .form-group.col-md-2.col-sm-6.col-xs-6[style*="padding-top"] {
            /* Elimina el padding-top si se puso inline */
            padding-top: 5px !important; /* Ajustado para que el label no quede tan alto */
            display: flex; /* Para alinear el checkbox con el input */
            align-items: center; /* Centra el checkbox verticalmente */
        }

        /* Organizar en 2 filas para móvil */
        @media (max-width: 767px) {
            .form-row > .form-group {
                flex: 0 0 50%; /* Cada elemento ocupa el 50% del ancho [cite: 218] */
                max-width: 50%; /* Asegura que no se exceda [cite: 219] */
                padding-left: 5px; /* Ajusta el padding para espaciado [cite: 220] */
                padding-right: 5px; /* Ajusta el padding para espaciado [cite: 221] */
                margin-bottom: 10px; /* Espacio entre filas [cite: 222] */
            }

            .form-row .btn-block {
                width: 100%; /* [cite: 226] */
            }

            #txtAnioLectivo {
                text-align: center; /* [cite: 227] */
            }
        }

        /* Estilos para la grilla */
        /* Las columnas que se ocultan en móvil se manejan en el script de JavaScript */
        .col-chk {
            width: 50px; /* Ancho fijo para el checkbox */
            text-align: center;
            vertical-align: middle;
        }

        .col-concept {
            white-space: normal; /* Permite que el texto se envuelva [cite: 228] */
            width: 60%; /* Más espacio para concepto en móvil */
        }

        .col-estado {
            text-align: center; /* [cite: 229] */
            vertical-align: middle;
            width: 40%; /* Espacio para estado en móvil */
        }

        /* Asegurarse de que .col-estado NO se oculte */
    </style>

    <script>
        function ajustarColumnasGridView() {
            var ancho = window.innerWidth; [cite: 230]

            // Columnas que se OCULTAN en móvil (ancho < 576px)
            var columnasAOcultar = [
                ".col-cuota", ".col-importe", ".col-FechaVto", ".col-ImporteInteres",
                ".col-Beca", ".col-ImporteTotal", ".col-ImpPagado", ".col-FP"
            ]; [cite: 231]

            if (ancho < 576) { // Tamaño móvil (como xs en Bootstrap) 
                columnasAOcultar.forEach(selector => {
                    document.querySelectorAll(selector).forEach(el => el.style.display = "none"); [cite: 232]
                });
                // Asegurarse de que Concepto, Estado y el checkbox siempre estén visibles
                document.querySelectorAll(".col-chk, .col-concept, .col-estado").forEach(el => el.style.display = "table-cell"); [cite: 233]
                document.querySelectorAll("#<%= GrillaHistorial.ClientID %> th.col-chk, #<%= GrillaHistorial.ClientID %> th.col-concept, #<%= GrillaHistorial.ClientID %> th.col-estado").forEach(el => el.style.display = "table-cell");

            } else {
                // Columnas que se MUESTRAN en desktop 
                var columnasAMostrar = [
                    ".col-cuota", ".col-importe", ".col-FechaVto",
                    ".col-ImporteInteres", ".col-Beca", ".col-ImporteTotal",
                    ".col-ImpPagado", ".col-FP", ".col-concept", ".col-estado", ".col-chk"
                ]; [cite: 234]
                columnasAMostrar.forEach(selector => {
                    document.querySelectorAll(selector).forEach(el => el.style.display = "table-cell"); [cite: 235]
                });
                document.querySelectorAll("#<%= GrillaHistorial.ClientID %> th").forEach(el => el.style.display = "table-cell"); // Asegura que todos los headers vuelvan a ser visibles [cite: 235]
            }
        }
        window.addEventListener("load", ajustarColumnasGridView); [cite: 237]
        window.addEventListener("resize", ajustarColumnasGridView); [cite: 237]
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            // Asigna el evento click a las filas de la tabla de la grilla
            // La ID de la grilla es "GrillaHistorial"
            $('#<%= GrillaHistorial.ClientID %>').on('click', 'tbody tr', function () {
            // Obtener los datos de los atributos data-* de la fila clicada
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
            var fp = $(this).data('fp');

            // Llenar el modal con los datos
            $('#lblModalConcepto').text(concepto);
            $('#lblModalImporte').text(importe);
            $('#lblModalIntereses').text(intereses);
            $('#lblModalImporteTotal').text(importeTotal);
            $('#lblModalBeca').text(beca);
            $('#lblModalNroCuota').text(nroCuota);
            $('#lblModalFechaVto').text(fechaVto);
            $('#lblModalDcto').text(dcto);
            $('#lblModalImpPagado').text(impPagado);
            $('#lblModalFechaPago').text(fechaPago);
            $('#lblModalColegio').text(colegio);
            $('#lblModalCurso').text(curso);
            $('#lblModalConId').text(conId);
            $('#lblModalFP').text(fp);

            // Mostrar el modal
            $('#modalDetalle').modal('show');
        });
    });
    </script>

</asp:Content>
