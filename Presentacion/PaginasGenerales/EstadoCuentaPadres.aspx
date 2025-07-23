<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalPadres.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="EstadoCuentaPadres.aspx.cs" Inherits="EstadoCuentaPadres" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PrincipalPadres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">



    <div class="ibox-content">
        <div class="form-row" style="background-color: #FFFFFF">
            <div class="form-group col-md-3 col-sm-6 col-xs-6" id="divAnioLectivo">
                <label class="control-label label-anio-lectivo" for="txtAnioLectivo" style="display: block;">Año Lectivo</label>
                <asp:TextBox ID="txtAnioLectivo" type="text" class="form-control" runat="server" BorderColor="Silver" placeholder="Año Lectivo"></asp:TextBox>
            </div>

            <div class="form-group col-md-3 col-sm-6 col-xs-6 solo-adeudados-group">
                <label class="control-label solo-adeudados-label" for="ckbDeuda">Solo Adeudados</label>
                <asp:CheckBox ID="ckbDeuda" Checked="false" AutoPostBack="true" runat="server" OnCheckedChanged="ckbDeuda_CheckedChanged" />
            </div>

            <div class="form-group col-md-2 col-sm-6 col-xs-6">
                <asp:Button ID="btnActualizar" class="btn btn-w-m btn-primary btn-block" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Actualizar" OnClick="btnActualizar_Click" />
            </div>

            <div class="form-group col-md-2 col-sm-6 col-xs-6">
                <asp:Button ID="BtnLibreDeuda" class="btn btn-w-m btn-danger btn-block" runat="server" Text="Libre Deuda" OnClick="btnImprimirClickLD_Click" />
            </div>

            <div class="form-group col-md-2 col-sm-12 col-xs-12">
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="alert alert-danger" role="alert" Style="margin-top: 5px;">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </asp:Panel>
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
                                <%-- CHECKBOX COLUMNA --%>
                                <asp:TemplateField HeaderText="" ItemStyle-CssClass="col-chk" HeaderStyle-CssClass="col-chk">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" ToolTip="Seleccionar todo" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccion" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <%-- CONCEPTO COLUMNA --%>
                                <asp:TemplateField HeaderText="Concepto" ItemStyle-CssClass="col-concept" HeaderStyle-CssClass="col-concept">
                                    <ItemTemplate>
                                        <asp:Label ID="lblConcepto" runat="server" Text='<%# Eval("Concepto") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="30%" />
                                </asp:TemplateField>

                                <%-- NRO CUOTA COLUMNA --%>
                                <asp:TemplateField HeaderText="Cuota" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-cuota" HeaderStyle-CssClass="col-cuota">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCuota" runat="server" Text='<%# Eval("NroCuota") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <%-- ESTADO COLUMNA (YA ESTÁ EN SU LUGAR, MANTENER AQUÍ) --%>
                                <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-estado" HeaderStyle-CssClass="col-estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <%-- CAMPOS OCULTOS EN CELULARES, VISIBLES EN DESKTOP --%>
                                <asp:TemplateField HeaderText="Importe" ItemStyle-CssClass="col-importe" HeaderStyle-CssClass="col-importe">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblImporte" runat="server" Text='<%# Eval("Importe", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Fecha Vto." ItemStyle-CssClass="col-FechaVto" HeaderStyle-CssClass="col-FechaVto">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaVto" runat="server" Text='<%# Eval("FechaVto", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Intereses" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="col-ImporteInteres" HeaderStyle-CssClass="col-ImporteInteres">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntereses" runat="server" Text='<%# Eval("ImporteInteres", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>

<%--                                <asp:TemplateField HeaderText="Beca" ItemStyle-CssClass="col-Beca" HeaderStyle-CssClass="col-Beca">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeca" runat="server" Text='<%# Eval("Beca") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="col-ImporteTotal" HeaderStyle-CssClass="col-ImporteTotal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImporteTotal" runat="server" Text='<%# Eval("ImporteTotal", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>

<%--                                <asp:TemplateField HeaderText="Pagado" ItemStyle-CssClass="col-ImpPagado" HeaderStyle-CssClass="col-ImpPagado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImpPagado" runat="server" Text='<%# Eval("ImpPagado", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>--%>

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

                        <strong>Colegio:</strong> <span id="lblModalColegio"></span><br />
                        <strong>Curso:</strong> <span id="lblModalCurso"></span><br />
                        <strong>Número de Cuota:</strong> <span id="lblModalNroCuota"></span><br />
                        <strong>Importe Arancel:</strong> <span id="lblModalImporte"></span><br />
                        <strong>Intereses:</strong> <span id="lblModalIntereses"></span><br />
                        <strong>Beca:</strong> <span id="lblModalBeca"></span><br />
                        <strong>Descuento:</strong> <span id="modalDcto"></span><br />
                        <strong>Importe Total:</strong> <span id="lblModalImporteTotal"></span><br />
                        <strong>Fecha Vencimiento:</strong> <span id="lblModalFechaVto"></span><br />
                        <strong>Importe Pagado:</strong> <span id="lblModalImpPagado"></span><br />
                        <strong>Fecha Pago:</strong> <span id="lblModalFechaPago"></span><br />
                        <strong>Forma de Pagado:</strong> <span id="lblModalFP"></span><br />


<%--                        <p><strong>Concepto:</strong> <span id="lblModalConcepto"></span></p>
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
                        <p><strong>Forma de Pago:</strong> <span id="lblModalFP"></span></p>--%>
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
<%--                <div class="form-group col-md-9 text-right">
                    <br />
                    <div class="botones-pago-movil">
                        <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
                        <asp:Button ID="btnFacturar" class="btn btn-w-m btn-warning" runat="server" Text="Pagar" Visible="false" OnClick="btnFacturarClick" />
                    </div>
                </div>--%>
            </div>
        </div>

    </div>

    <div class="form-row">
        <br />
        <div class="botones-pago-movil">
            <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
            <asp:Button ID="btnFacturar" class="btn btn-w-m btn-warning" runat="server" Text="Pagar" Visible="false" OnClick="btnFacturarClick" />
        </div>
    </div>


    <div class="row">
        <div class="form-group col-md-3">
            <asp:Label ID="lblCuotas" runat="server" Text="Total Cuotas Vencidas:" Font-Bold="true" Visible="false"></asp:Label>
            <asp:TextBox ID="TexCuotas" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <asp:Label ID="lblInt" Visible="false" runat="server" Text="Total Intereses:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtIntereses" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
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

                if ($(event.target).is('a, button, input[type="button"], input[type="submit"], input[type="checkbox"]')) { 
                    console.log("Click en botón, enlace o checkbox, ignorando."); 
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

        /* Para alinear el encabezado a la derecha en desktop */
        .col-importe.col-importe, 
        .col-ImporteInteres.col-ImporteInteres, 
        .col-ImporteTotal.col-ImporteTotal, 
        .col-ImpPagado.col-ImpPagado {
            text-align: right !important; /* Asegura que el contenido se alinee a la derecha */
        }

        .col-estado,
        .col-cuota,
        .col-FechaVto {
            text-align: center !important;
        }


        /* Organizar en 2 filas para móvil */
        @media (max-width: 767px) {
            /* Reglas para asegurar que el table-responsive y la GridView usen todo el ancho disponible */
            .table-responsive {
                width: 100% !important; /* Fuerza al contenedor responsive a tomar el 8% del ancho */
                overflow-x: auto; /* Asegura que el scroll horizontal funcione si la tabla es más ancha que la pantalla */
                -webkit-overflow-scrolling: touch; /* Mejora el scroll en iOS */
            }

            /* Asegurar que la tabla GridView ocupe el 100% del ancho de su contenedor table-responsive */
                #<%= GrillaHistorial.ClientID %> {
                    width: 100% !important; /* Fuerza a la tabla a ocupar el 100% del ancho */
                    table-layout: fixed; /* Esto ayuda a que los anchos de columna definidos se respeten y la tabla no se expanda por contenido largo */
                    min-width: 280px; /* Opcional: define un ancho mínimo si crees que la tabla se contrae demasiado */
                }

                /* Ajustes de columnas dentro de la GridView para móvil */
                #<%= GrillaHistorial.ClientID %> th, 
                #<%= GrillaHistorial.ClientID %> td {
                    white-space: normal !important; /* Permite que el texto se envuelva en varias líneas */
                    word-wrap: break-word; /* Permite que las palabras largas se rompan */
                    vertical-align: top; /* Alinea el contenido de la celda en la parte superior si hay saltos de línea */
                }

                /* Ajustes de columnas dentro de la GridView para móvil */
                #<%= GrillaHistorial.ClientID %> th, 
                #<%= GrillaHistorial.ClientID %> td {
                    white-space: normal !important; /* Permite que el texto se envuelva en varias líneas */
                    word-wrap: break-word; /* Permite que las palabras largas se rompan */
                    vertical-align: top; /* Alinea el contenido de la celda en la parte superior si hay saltos de línea */
                }

                /* Ajustar anchos específicos de las columnas visibles en móvil */
                #<%= GrillaHistorial.ClientID %> .col-chk {
                    width: 10% !important; /* Un poco más de espacio para el checkbox y que no se corte */
                    padding-left: 5px !important;
                    padding-right: 5px !important;
                    text-align: center !important; /* Centrar el checkbox */
                }

                #<%= GrillaHistorial.ClientID %> .col-concept {
                    width: 45% !important; /* Le damos la mayor parte del espacio al concepto */
                }

                #<%= GrillaHistorial.ClientID %> .col-cuota {
                    width: 15% !important; /* Un poco más de espacio para la cuota */
                    text-align: center !important;
                }

                #<%= GrillaHistorial.ClientID %> .col-estado {
                    width: 25% !important; /* Aseguramos que el estado tenga su espacio */
                    text-align: center !important;
                }

                .form-row > .form-group {
                    flex: 0 0 50%; /* Cada elemento ocupa el 50% del ancho [cite: 218] */
                    max-width: 50%; /* Asegura que no se exceda [cite: 219] */
                    padding-left: 5px; /* Ajusta el padding para espaciado [cite: 220] */
                    padding-right: 5px; /* Ajusta el padding para espaciado [cite: 221] */
                    margin-bottom: 5px; /* Espacio entre filas [cite: 222] */
                }

                .form-row .btn-block {
                    width: 100%; 
                }

                #txtAnioLectivo {
                    text-align: center; 
                }
        }



        /* Asegurarse de que .col-estado NO se oculte */
    </style>







    <script>
        function ajustarColumnasGridView() {
            var ancho = window.innerWidth; 

            // Columnas que se OCULTAN en móvil (ancho < 576px)
            var columnasAOcultar = [
                ".col-importe", ".col-FechaVto", ".col-ImporteInteres",
                ".col-Beca", ".col-ImporteTotal", ".col-ImpPagado", ".col-FP"
            ];

            if (ancho < 768) { // Tamaño móvil (como xs en Bootstrap) 
            columnasAOcultar.forEach(selector => {
                document.querySelectorAll(selector).forEach(el => el.style.display = "none");
            });

            // Asegurarse de que Concepto, Cuota, Estado y el checkbox siempre estén visibles
            // y que tengan el display correcto para celdas de tabla.
            document.querySelectorAll(".col-chk, .col-concept, .col-cuota, .col-estado").forEach(el => {
                el.style.display = "table-cell"; // Asegura que sean visibles
                el.style.width = "auto"; // Permite que el ancho se ajuste automáticamente al contenido
                el.style.whiteSpace = "normal"; // Permite que el texto se ajuste a varias líneas si es largo
            });

            // Para los encabezados, también asegurar visibilidad y ancho automático
            document.querySelectorAll("#<%= GrillaHistorial.ClientID %> th.col-chk, #<%= GrillaHistorial.ClientID %> th.col-concept, #<%= GrillaHistorial.ClientID %> th.col-cuota, #<%= GrillaHistorial.ClientID %> th.col-estado").forEach(el => {
                el.style.display = "table-cell";
                el.style.width = "auto";
                el.style.whiteSpace = "normal";
            });

            // Opcional: ajustar el ancho de la tabla para ocupar el 100% del contenedor en móvil
            grid.style.width = "100%"; 
            // Esto es crucial para que el table-responsive funcione bien en algunos casos
            // y la tabla use todo el ancho disponible.
            grid.style.tableLayout = "fixed"; // Ayuda a que los anchos de columna fijos se respeten mejor
            // Aunque aquí estamos usando auto, puede ser útil.


            } else {
                // Columnas que se MUESTRAN en desktop 
                var columnasAMostrar = [
                    ".col-cuota", ".col-importe", ".col-FechaVto",
                    ".col-ImporteInteres", ".col-Beca", ".col-ImporteTotal",
                    ".col-ImpPagado", ".col-FP", ".col-concept", ".col-estado", ".col-chk"
                ]; 
                columnasAMostrar.forEach(selector => {
                    document.querySelectorAll(selector).forEach(el => el.style.display = "table-cell"); 
                });
                document.querySelectorAll("#<%= GrillaHistorial.ClientID %> th").forEach(el => el.style.display = "table-cell"); // Asegura que todos los headers vuelvan a ser visibles [cite: 235]
            }
        }
        window.addEventListener("load", ajustarColumnasGridView); 
        window.addEventListener("resize", ajustarColumnasGridView); 
    </script>






    <script type="text/javascript">
        $(document).ready(function () {
            // Asigna el evento click a las filas de la tabla de la grilla
            // La ID de la grilla es "GrillaHistorial"
            $('#<%= GrillaHistorial.ClientID %>').on('click', 'tbody tr', function () {

                if ($(event.target).is('a, button, input[type="button"], input[type="submit"], input[type="checkbox"]')) {
                    console.log("Click en botón, enlace o checkbox, ignorando.");
                    return;
                }

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
