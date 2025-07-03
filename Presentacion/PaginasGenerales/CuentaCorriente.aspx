<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CuentaCorriente.aspx.cs" Inherits="CuentaCorriente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <br />
        <label class="control-label col-md-12">Sección Busqueda</label>
    </div>
    <div class="ibox-content">
        <div class="form-inline">
            <div class="form-group col-md-3">
                <label>Buscar por: </label>
                <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                    <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                    <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group col-md-2">
                <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                &nbsp;<asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
            </div>
            <div class="form-group col-md-4">
                <label class="control-label  col-md-2">Año:&nbsp;&nbsp; </label>
                <div class="col-md-2">

                    <asp:TextBox ID="txtAnioLectivo" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true" OnTextChanged="txtAnioLectivo_TextChanged"></asp:TextBox>
                </div>
            </div>
            <br />
        </div>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">

        <div class="form-group col-md-4">
            <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aludni"  BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
        </div>

        <div class="form-group col-md-4">
            <asp:Label class="control-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <div class="form-group col-md-4">
            <asp:Label class="control-label" ID="LblEstadao" runat="server" Text="Estado: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aluEstado" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
        </div>

    </div>


    <div class="col-sm-12" style="background-color: #FFFFFF">

        <div class="form-group col-md-10">
            <br />
            <asp:TextBox ID="txtObserv" TextMode="MultiLine" onkeyup="limitarTexto(this, 1000);" onpaste="setTimeout(() => limitarTexto(this, 1000), 0);"
                Rows="2" Visible="false" class="form-control" MaxLength ="1000" runat="server" placeholder="Observación..."></asp:TextBox>
            <asp:Label ID="lblContador" runat="server" Text="0 / 1000" />
        </div>
        <div class="form-group col-md-2">
            <br />
            <asp:Button ID="btnActualizar" class="btn btn-w-m btn-warning" runat="server" Text="Guardar Observación" Visible="false" OnClick="btnActualizarClick" />
            <asp:Label ID="lblMensaje" runat="server" Text="Guardado.." ForeColor="Green" Visible="false" Font-Bold="true"></asp:Label>
        </div>
    </div>

    <div class="ibox-content">
        <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
            <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>
        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </div>
    </div>
    <%--  <div class="ibox-title" runat="server" visible="false" id="canRg">
                        <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros2" runat="server" Text=""></asp:Label></h5>
                    </div>--%>
    <div class="ibox collapsed">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView ID="GrillaBuscar" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="false" DataKeyName="Id" OnRowDataBound="GrillaBuscar_RowDataBound" OnRowCommand="GrillaBuscar_RowCommand"
                        PageSize="5" AllowPaging="True" OnPageIndexChanging="GrillaBuscar_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>

                            <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Select" />
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Doc" runat="server" Text='<%# Eval("Doc") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Legajo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Legajo" runat="server" Text='<%# Eval("LegajoNumero") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" />

                        <PagerSettings Position="Top" />
                        <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                    </asp:GridView>
                    <br />
                </div>
            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="GrillaBuscar" />
                <asp:PostBackTrigger ControlID="btnCancelarAlumno"></asp:PostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>


        </asp:UpdatePanel>
    </div>
    <%--  </div>--%>

    <%--  <div class="col-sm-12">
                <label class="control-label col-md-12">Alumno Seleccionado</label>
                <hr class="pg2-titl-bdr-btm" style="width: 1005px" />
            </div>--%>



    <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>

    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-content">

                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                    </Triggers>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="GrillaHistorial" runat="server" DataKeyNames="icoId,RA,cntId,conId,TipoConcepto,Dcto,Concepto,Importe,ImporteInteres,AnioLectivo,Beca,BecId,NroCuota,FchInscripcion,insId,FechaVto,ImpPagado,FechaPago,NroCompbte,Curso" GridLines="None" CssClass="table table-striped"
                                AutoGenerateColumns="False" OnRowCommand="GrillaHistorial_RowCommand">
                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
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
                                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                                    <asp:BoundField DataField="Importe" HeaderText="Importe Arancel" />
                                    <asp:BoundField DataField="ImporteInteres" HeaderText="Intereses" />
                                    <asp:BoundField DataField="ImporteTotal" HeaderText="Importe a Pagar" />
                                    <asp:BoundField DataField="FechaVto" HeaderText="FechaVto" />
                                    <asp:BoundField DataField="RA" HeaderText="RA" />
                                    <asp:BoundField DataField="AnioLectivo" HeaderText="AnioLectivo" Visible="false" />
                                    <asp:BoundField DataField="Beca" HeaderText="Beca" />
                                    <asp:BoundField DataField="BecId" HeaderText="BecId" Visible="false" />
                                    <asp:BoundField DataField="NroCuota" HeaderText="NroCuota" />
                                    <asp:BoundField DataField="FchInscripcion" HeaderText="FchInscripcion" Visible="false" />
                                    <asp:BoundField DataField="ValorInteres" HeaderText="ValorInteres" Visible="false" />
                                    <asp:BoundField DataField="Dcto" HeaderText="Dscto" Visible="true" />
                                    <asp:BoundField DataField="ImpPagado" HeaderText="ImpPagado" />
                                    <asp:BoundField DataField="Colegio" HeaderText="Colegio" Visible="true" />
                                    <asp:BoundField DataField="insId" HeaderText="insId" Visible="false" />
                                    <asp:BoundField DataField="FechaPago" HeaderText="FechaPago" ItemStyle-CssClass="FechaPago" />
                                    <asp:BoundField DataField="NroCompbte" Visible="false" ItemStyle-CssClass="NroCompbte" HeaderText="NroCompbte" />
                                    <asp:BoundField DataField="Curso" ItemStyle-CssClass="Curso" HeaderText="Curso" />
                                    <asp:BoundField DataField="LP" ItemStyle-CssClass="Curso" HeaderText="LP" />
                                    <asp:BoundField DataField="FP" ItemStyle-CssClass="Curso" HeaderText="FP" />
                                    <asp:ButtonField ButtonType="Link" CommandName="Add" Text="Ver" HeaderText="" />

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina el pago o concepto del registro.." Width="90">X</asp:LinkButton>
                                            <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                                OnClick="btnEliminarAceptar_Click" ForeColor="Black" />
                                            <asp:Button ID="btnEliminarCancelar" ForeColor="Black" runat="server" Text="No" Visible="False"
                                                OnClick="btnEliminarCancelar_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle HorizontalAlign="NotSet" />

                                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#CCCCFF" />
                            </asp:GridView>
                        </div>


                        <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                        <asp:Label ID="lblMjerror2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>

                        <div class="ibox-content">
                            <div class="row">

                                <div class="form-inline">
                                    <div class="form-group col-md-2">
                                        <br />
                                        <asp:Button ID="btnFacturar" class="btn btn-w-m btn-warning" runat="server" Text="Facturar" Visible="false" OnClick="btnFacturarClick" Width="100%" />
                                    </div>
                                </div>

                                <div class="form-group col-md-3">
                                    <asp:Label ID="lblCuotas" runat="server" Text="Total Cuotas Impagas:" Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:TextBox ID="TexCuotas" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Label ID="lblInt" Visible="false" runat="server" Text="Total Intereses:" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txtIntereses" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Label ID="lblTot" Visible="false" runat="server" Text="Total:" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txtTot" Visible="false" BackColor="#cc0000" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="ibox-content">
                                    <div class="form-inline col-md-10">
                                        <div class="form-group col-md-5">
                                            <asp:Label class="control-label" ID="lblVencido" runat="server" Font-Bold="true" Visible="false">Vencido</asp:Label>
                                            <asp:TextBox ID="txtRojo" BackColor="red" ForeColor="red" Visible="false" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-5">
                                            <asp:Label class="control-label" ID="lblPagado" runat="server" Font-Bold="true" Visible="false">Pagado</asp:Label>
                                            <asp:TextBox ID="txtcELESTE" BackColor="LightBlue" ForeColor="LightBlue" BorderColor="Silver" Visible="false" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="GrillaBuscar" />
                        <asp:PostBackTrigger ControlID="GrillaHistorial" />
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Colocás el script al final -->
    <script type="text/javascript">
        function limitarTexto(control, max) {
            var texto = control.value;
            if (texto.length > max) {
                control.value = texto.substring(0, max);
            }

            var label = document.getElementById('<%= lblContador.ClientID %>');
            if (label) {
                label.innerText = control.value.length + " / " + max;
            }
        }
    </script>

</asp:Content>

