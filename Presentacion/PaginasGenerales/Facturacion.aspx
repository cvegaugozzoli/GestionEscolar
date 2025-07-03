<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="Facturacion.aspx.cs" Inherits="Facturacion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblicoId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblcpvId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblcocId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblinst" runat="server" Visible="false" Text=""></asp:Label>
            <div class="form-row">
                <div class="form-group col-md-4">
                    <label class="control-label">Comprobante Tipo</label>
                    <asp:DropDownList ID="CompTipoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4" align="center">
                    <asp:Label ID="lblCompTipo" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699"></asp:Label>
                    </br>
                    <asp:Label ID="lblNroPtoVta" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699">-</asp:Label>
                    <asp:Label ID="lblUltimoNro" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699"></asp:Label>

                </div>

                <div class="form-group col-md-4">
                    <label class="control-label">Comprobante Destino </label>
                    <asp:DropDownList ID="DestinoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>



    <div class="form-group">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Alumno</h3>
            </div>
            <div class="panel-body">

                <div class="form-row">
                    <div class="form-group col-md-5">
                        <label class="control-label ">Nombre del Alumno:</label>
                        <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Text=""></asp:Label>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">DNI:</label>
                        <asp:Label ID="lblDni" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="form-group col-md-5">
                        <label class="control-label ">Dirección:</label>
                        <asp:Label ID="lblDireccion" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label ">Institución:</label>
                        <asp:Label ID="lblInstitucion" runat="server" Font-Bold="True" Text=""></asp:Label>
                    </div>
                    <div class="form-group col-md-6">
                        <label class="control-label ">Curso:</label>
                        <asp:Label ID="lblCurso" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">Año Lectivo:</label>
                        <asp:Label ID="lblanioLectivo" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label ">Tutor:</label>
                        <asp:Label ID="lblTutor" runat="server" Font-Bold="True"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="form-inline">
        <label class="control-label ">Fecha de Pago:</label>
        <asp:TextBox ID="txtFechaPago" type="DateTimePicker" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
        <asp:CheckBox ID="chqFchPago" class="form-check-input" runat="server" OnCheckedChanged="chqFchPago_CheckedChanged"
            AutoPostBack="true" />
        <label class="form-check-label">Cargar nuevamente</label>
    </div>


    <div class="row">
        <div class="col-sm-12">

            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="GridConcepto"  DataKeyNames="icoId,cntId,TipoConcepto,Concepto,NroCuota,Importe,FechaVto,Beca,InteresCuota,RecargoAbierto,InteresMensual,Dcto,InteresTotal"
                         runat="server" GridLines="None" CssClass="table table-striped" BackColor="#154F77"
                        AutoGenerateColumns="False" OnRowDataBound="GridConcepto_RowDataBound" OnRowCommand="GridConcepto_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="GridConcepto_PageIndexChanging">

                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" AutoPostBack="true" OnCheckedChanged="chkSeleccion_CheckedChanged" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="icoId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="icoId" Visible="false" runat="server" Text='<%# Eval("icoId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="cntId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="cntId" runat="server" Text='<%# Eval("cntId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo Concepto" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="TipoConcepto" runat="server" Visible="false" Text='<%# Eval("TipoConcepto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Concepto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Concepto" runat="server" Text='<%# Eval("Concepto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuota">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Cuota" runat="server" Text='<%# Eval("NroCuota") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Importe">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Importe" runat="server" Text='<%# Eval("Importe") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha Vto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="FechaVto" runat="server" Text='<%# DateTime.Parse(Eval("FechaVto").ToString()).ToString("d") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Beca">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Beca" runat="server" Text='<%# Eval("Beca") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Interes Cuota">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresCuota" runat="server" Text='<%# Eval("InteresCuota") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recargo Abierto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ImporteInteres" runat="server" Text='<%# Eval("RecargoAbierto","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interes Mensual">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresMensual" runat="server" Text='<%# Eval("InteresMensual","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dcto%">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Dcto" runat="server" Text='<%# Eval("Dcto","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interes Total">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresTotal" runat="server" Text='<%# Eval("InteresTotal","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>



                            <%-- <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                        OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                        OnClick="btnEliminarCancelar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <FooterStyle BackColor="#154F77" ForeColor="White" />
                        <PagerStyle BackColor="#154F77" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#154F77" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="#333333" />
                        <EditRowStyle BackColor="#2461BF" />
                        <RowStyle BackColor="#EFF3FB" />

                    </asp:GridView>
                </div>

            </div>
            <asp:Label ID="LblMjeGridConcepto" runat="server" Text="" Style="font-size: large; color: #1f2548"></asp:Label>
        </div>
        <div class="row">
            <div class="form-group col-sm-10 " align="right">
                &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " style="font-weight: bold; font-size: x-large; color: #1f2548">Total a Pagar:</label>
                <asp:Label ID="lblSubTotal" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#1f2548"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-sm-10 " align="right">
                &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " style="font-weight: bold; font-size: x-large; color: #FF0000;">Total Pagado:</label>
                <asp:Label ID="lblTotal" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="ibox-content">
            <div class="form-inline">

                <label class="control-label ">Descuento:</label>
                <asp:TextBox ID="TextDescuento" type="DateTimePicker" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                <asp:CheckBox ID="chkDesc" class="form-check-input" runat="server" OnCheckedChanged="chkDesc_CheckedChanged"
                    AutoPostBack="true" />
                <label class="form-check-label">Aplicar Descuento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>


                   &nbsp;<asp:CheckBox ID="CheckDctoSacar" class="form-check-input" runat="server" OnCheckedChanged="CheckDctoSacar_CheckedChanged"
                    AutoPostBack="true" />
                <label class="form-check-label">Sacar Descuentos</label>
            </div>
            <br />
            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
              <div id="alerInfo" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                <asp:Label ID="lblalerInfo" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnFormaPago" Enabled="true" class="btn btn-w-m btn-primary" runat="server" Text="Forma de Pago"
                        OnClick="btnFormaPago_Click" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnGrabar" Enabled="false" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Grabar"
                        OnClick="btnGrabar_Click" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelarFP" Enabled="false" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Cancelar Forma de Pago"
                        OnClick="btnCancelarFP_Click" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnImprimir" formnovalidate="formnovalidate " Enabled="false" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir"
                        OnClick="btnImprimir_Click" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnGestion" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Volver"
                        OnClick="btnGestion_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:UpdatePanel ID="UpdFormaPago" runat="server" UpdateMode="Conditional" Visible="false">

            <ContentTemplate>
                <div id="Panel" class="form-group" visible="false">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <%--<h3 class="panel-title">FORMA DE PAGO</h3>--%>
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="form-group col-md-3">
                                    <label class="control-label ">Fecha:</label>

                                    <tpDatePicker:cuFecha ID="FchPago" runat="server" Enabled="true" AllowType="False" BorderColor="Silver" />
                                </div>
                                <div class="form-group col-md-3">
                                    <label class="control-label">Lugar de Pago</label>
                                    <asp:DropDownList ID="LugarPagoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="control-label"></label>
                                    <br />
                                    <asp:Label ID="lblMjeError" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                                </div>
                                <br />
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div class="col-md-7 ">
                                        <div class="ibox-title">
                                            <h5>Forma de Pago </h5>
                                            <p>&nbsp;</p>
                                        </div>
                                        <div class="form-group">

                                            <div class="panel-group" id="accordion">

                                                <div class="panel panel-info">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title">
                                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Contado</a>
                                                        </h4>
                                                    </div>
                                                    <div id="collapse1" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <div class="form-group col-md-6">
                                                                <asp:Label ID="lblImporteContado" class="control-label" runat="server">Importe</asp:Label>
                                                                <asp:TextBox ID="txtImporteContado" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-6">
                                                                <asp:Label ID="Label2" class="control-label" runat="server"></asp:Label><br />
                                                                <asp:Button ID="btnAgregar" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Agregar"
                                                                    OnClick="btnAgregar_Click" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel panel-info">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title">
                                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Tarjeta</a>
                                                        </h4>
                                                    </div>
                                                    <div id="collapse2" class="panel-collapse collapse">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                                                            <ContentTemplate>
                                                                <div class="panel-body">
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblImpT" class="control-label" runat="server">A pagar</asp:Label>
                                                                        <asp:TextBox ID="txtImpTarj" type="text" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtImpTarj_TextChanged" BorderColor="Silver"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblTarjeta" class="control-label" runat="server">Tarjeta</asp:Label>
                                                                        <asp:DropDownList ID="TarjetaId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="TarjetaId_SelectedIndexChanged"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblPlanes" class="control-label" runat="server">Planes</asp:Label>
                                                                        <asp:DropDownList ID="PlanesTarjetaId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="PlanesTarjetaId_SelectedIndexChanged"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblInteresT" class="control-label" runat="server">Interes</asp:Label>
                                                                        <asp:TextBox ID="txtInteresT" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true" OnTextChanged="txtInteresT_TextChanged"></asp:TextBox>
                                                                    </div>

                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblNroCuotas" class="control-label" runat="server">Nro Cuotas</asp:Label>
                                                                        <asp:TextBox ID="txtNroCuotas" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true" OnTextChanged="txtNroCuotas_TextChanged"></asp:TextBox>
                                                                    </div>

                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblImpCuota" class="control-label" runat="server">Importe C/ Cuota</asp:Label>
                                                                        <asp:TextBox ID="txtImpCuota" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblTotalTarj" Enabled="false" class="control-label" runat="server">Total</asp:Label>
                                                                        <asp:TextBox ID="txtTotalTarj" type="text" Enabled="false" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblNroCupon" class="control-label" runat="server">Nro Cupón</asp:Label>
                                                                        <asp:TextBox ID="txtNroCupon" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group col-md-4">
                                                                        <asp:Label ID="lblError" Visible="false" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red"></asp:Label>

                                                                        <asp:Label ID="Label3" class="control-label" runat="server"></asp:Label><br />
                                                                        <asp:Button ID="btnAgregar2" class="btn btn-w-m btn-primary" runat="server" Text="Agregar"
                                                                            OnClick="btnAgregar_Click" />

                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnAgregar2" />

                                                            </Triggers>

                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <div class="panel panel-info">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title">
                                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Cheque</a>
                                                        </h4>
                                                    </div>
                                                    <div id="collapse3" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <div class="form-group col-md-4">
                                                                <asp:Label ID="lblImpCheque" class="control-label" runat="server">Importe</asp:Label>
                                                                <asp:TextBox ID="txtImpCheque" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <asp:Label ID="lblBanco" class="control-label" runat="server">Banco</asp:Label>
                                                                <asp:DropDownList ID="BancoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <asp:Label ID="lblNroCheque" class="control-label" runat="server">Numero de Cheque</asp:Label>
                                                                <asp:TextBox ID="txtNroCheque" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-4">

                                                                <asp:Button ID="btnAgregar3" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Agregar"
                                                                    OnClick="btnAgregar_Click" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel panel-info">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title">
                                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">Transferencia Electronica</a>
                                                        </h4>
                                                    </div>
                                                    <div id="collapse4" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <div class="form-group col-md-4">
                                                                <asp:Label ID="lblImporteTrans" class="control-label" runat="server">Importe</asp:Label>
                                                                <asp:TextBox ID="txtImpTrans" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <asp:Label ID="lblBanco2" class="control-label" runat="server">Banco</asp:Label>
                                                                <asp:DropDownList ID="Banco2Id" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <asp:Label ID="lblNroCta" class="control-label" runat="server">Numero de Cuenta</asp:Label>
                                                                <asp:TextBox ID="txtNroCta" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-4">

                                                                <asp:Button ID="btnAgregar4" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Agregar"
                                                                    OnClick="btnAgregar_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5">

                                        <div class="ibox-title">
                                            <h5>Detalle </h5>
                                        </div>
                                        <div class="ibox-content">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="conditional">
                                                <ContentTemplate>


                                                    <asp:GridView ID="GrillaFormaPgo" runat="server" DataKeyNames="IdLP,IdFP,TotalFinal,FormaPago,TotalTarj,Importe,fchPago,TarjetaId,Tarjeta,NroCuota,NroCupon,PlanTarj,ImporteCuota,BancoId,Banco,NroCta,NroCheque,IdPlanTarj" GridLines="None" CssClass="table table-striped"
                                                        AutoGenerateColumns="False">
                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                        <Columns>
                                                            <asp:BoundField DataField="IdLP" HeaderText="IdLP" Visible="false" />
                                                            <asp:BoundField DataField="IdFP" HeaderText="IdFP" Visible="false" />
                                                            <asp:BoundField DataField="FormaPago" HeaderText="Forma de Pago" />
                                                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                                                            <asp:BoundField DataField="fchPago" HeaderText="fchPago" Visible="false" />
                                                            <asp:BoundField DataField="TarjetaId" HeaderText="Tarjeta" Visible="false" />
                                                            <asp:BoundField DataField="Tarjeta" HeaderText="Tarjeta" Visible="false" />
                                                            <asp:BoundField DataField="NroCuota" HeaderText="NroCuota" Visible="false" />
                                                            <asp:BoundField DataField="BancoId" HeaderText="BancoId" Visible="false" />
                                                            <asp:BoundField DataField="Banco" HeaderText="Banco" Visible="false" />
                                                            <asp:BoundField DataField="NroCta" HeaderText="NroCta" Visible="false" />
                                                            <asp:BoundField DataField="Interes" HeaderText="Interes" Visible="false" />
                                                            <asp:BoundField DataField="ImporteCuota" HeaderText="ImporteCuota" Visible="false" />
                                                            <asp:BoundField DataField="TotalTarj" HeaderText="TotalTarj" Visible="false" />
                                                            <asp:BoundField DataField="NroCheque" HeaderText="Numero Cheque" Visible="false" />
                                                            <asp:BoundField DataField="PlanTarj" HeaderText="Plan Tarjeta" Visible="false" />
                                                            <asp:BoundField DataField="IdPlanTarj" HeaderText="Plan Tarjeta" Visible="false" />
                                                            <asp:BoundField DataField="TotalFinal" HeaderText="Total" Visible="true" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                                                    <asp:Button ID="btnEliminarAceptar" formnovalidate="formnovalidate " runat="server" Text="Si" Visible="False"
                                                                        OnClick="btnEliminarAceptar_Click" />
                                                                    <asp:Button ID="btnEliminarCancelar" formnovalidate="formnovalidate " runat="server" Text="No" Visible="False"
                                                                        OnClick="btnEliminarCancelar_Click" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="Estado" Visible="false" HeaderText="Estado" />
                                                        </Columns>
                                                        <FooterStyle HorizontalAlign="NotSet" />

                                                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <SelectedRowStyle BackColor="#CCCCFF" />
                                                    </asp:GridView>
                                                    <div class="form-group col-md-6">
                                                        <asp:Label class="control-label" ID="lblSaldoTit" runat="server" Visible="false">Saldo a Pagar:</asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSaldo" Visible="false" runat="server" Font-Size="x-Large" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        <br />
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnAgregar" />
                                                    <asp:PostBackTrigger ControlID="btnAgregar3" />
                                                    <asp:PostBackTrigger ControlID="btnAgregar4" />
                                                    <asp:PostBackTrigger ControlID="GrillaFormaPgo" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <asp:Label ID="LblMjeGridFormaPago" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#CC0000"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>






</asp:Content>
