<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="FacturarCupones.aspx.cs" Inherits="FacturarCupones" %>

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

   
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="GridConcepto" runat="server" GridLines="None" CssClass="table table-striped" BackColor="#154F77"
                        AutoGenerateColumns="False" OnRowDataBound="GridConcepto_RowDataBound" OnRowCommand="GridConcepto_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="GridConcepto_PageIndexChanging">

                        <Columns>
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

                            <asp:TemplateField HeaderText="Fecha Vencimiento">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="FechaVto" runat="server" Text='<%# Eval("FechaVto") %>' />
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
                                    <asp:HyperLink ForeColor="Black" ID="ImporteInteres" runat="server" Text='<%# Eval("RecargoAbierto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interes Mensual">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresMensual" runat="server" Text='<%# Eval("InteresMensual") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interes Total">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresTotal" runat="server" Text='<%# Eval("InteresTotal") %>' />
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
            <div class="form-group col-sm-10 " align="right" >
                &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " style="font-weight: bold; font-size: x-large; color: #1f2548">Importe a pagar:</label>
                <asp:Label ID="lblSubTotal" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#1f2548"></asp:Label>
            </div>
        </div>


    
        <div class="panel-body">
            <div class="form-group col-md-6">
                <label class="control-label"></label>              
                <asp:Label ID="lblMjeError" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
            </div>         

            <div class="col-sm-12">
                <div class="form-group">

                    <div class="ibox-title">
                        <h5>Forma de Pago </h5>
                        <p>&nbsp;</p>
                    </div>
                    <div class="form-group">

                        <div class="panel-group" id="accordion">

                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Banco Municipal</a>
                                    </h4>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse">
                                    <div class="panel-body">

                                        <div class="form-group col-md-4">
                                            <asp:Label ID="Label3" class="control-label" runat="server"></asp:Label><br />
                                            <asp:Button ID="btnDescargar" class="btn btn-w-m btn-primary" runat="server" Text="Descargar Cupón de Pago" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Transferencia</a>
                                    </h4>
                                </div>
                                <div id="collapse2" class="panel-collapse collapse">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                                        <ContentTemplate>
                                            <div class="panel-body">

                                                <h5>1.- Los datos que necesita para realizar una transferencia son los que se detallan a continuación. </h5>

                                                <div class="form-group col-md-12">
                                                    <asp:Label ID="Label1" class="control-label" runat="server"></asp:Label><br />
                                                    <asp:Label ID="Label2" class="control-label" runat="server" Font-Bold="True">CBU: 000222333655455554555545</asp:Label><br />
                                                    <asp:Label ID="Label4" class="control-label" runat="server" Font-Bold="True">Cuenta: 225- 3565258 </asp:Label><br />
                                                    <asp:Label ID="Label5" class="control-label" runat="server" Font-Bold="True">CUIT:30-222555555-2 </asp:Label><br />

                                                </div>
                                                <h5>2.- Una vez realizada la transferencia complete:</h5>
                                                <div class="row">
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="lblBanco" class="control-label" runat="server">1.- Banco de Origen</asp:Label>
                                                        <asp:DropDownList ID="BancoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="lbl" class="control-label" runat="server">N° de Comprobante:</asp:Label>
                                                        <asp:TextBox ID="txtComprobante" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="lblFchPago" class="control-label" runat="server">Fecha de Pago</asp:Label>
                                                        <asp:TextBox ID="txtFchPago" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="Label7" class="control-label" runat="server">Foto de Comprobante</asp:Label>
                                                        <asp:TextBox ID="txtFoto" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="Label8" class="control-label" runat="server">CBU de la cuenta bancaria de origen</asp:Label>
                                                        <asp:TextBox ID="txtcbuOrigen" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="Label10" class="control-label" runat="server">Cuit del Titular</asp:Label>
                                                        <asp:TextBox ID="TextBox1" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="Label9" class="control-label" runat="server">Titular</asp:Label>
                                                        <asp:TextBox ID="txtTitular" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <asp:Label ID="Label11" class="control-label" runat="server"></asp:Label><br />
                                                        <asp:Button ID="btnEnviarTranf" class="btn btn-w-m btn-primary" runat="server" Text="Enviar" />
                                                    </div>
                                                </div>
                                                <h5 style="color: #FF0000">Podrá verificar el pago a las 72 hs de realizada la transferencia</h5>


                                            </div>

                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Depósito</a>
                                    </h4>
                                </div>
                                <div id="collapse3" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <h5>1.- Realice el depósito con los siguientes datos: </h5>

                                        <div class="form-group col-md-12">
                                            <asp:Label ID="Label6" class="control-label" runat="server"></asp:Label><br />
                                            <asp:Label ID="Label12" class="control-label" runat="server" Font-Bold="True">CBU: 000222333655455554555545</asp:Label><br />
                                            <asp:Label ID="Label13" class="control-label" runat="server" Font-Bold="True">Cuenta: 225- 3565258 </asp:Label><br />
                                            <asp:Label ID="Label14" class="control-label" runat="server" Font-Bold="True">CUIT:30-222555555-2 </asp:Label><br />

                                        </div>

                                        <h5>2.- Una vez realizado el depósito complete:</h5>
                                        <div class="row">

                                            <div class="form-group col-md-3">
                                                <asp:Label ID="Label16" class="control-label" runat="server">N° de Comprobante:</asp:Label>
                                                <asp:TextBox ID="TextBox2" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <asp:Label ID="Label17" class="control-label" runat="server">Fecha de Pago</asp:Label>
                                                <asp:TextBox ID="TextBox3" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <asp:Label ID="Label18" class="control-label" runat="server">Foto del Comprobante</asp:Label>
                                                <asp:TextBox ID="txtfoto2" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-md-3">
                                                <asp:Label ID="Label15" class="control-label" runat="server"></asp:Label><br />
                                                <asp:Button ID="btnEnviarDeposito" class="btn btn-w-m btn-primary" runat="server" Text="Enviar" />
                                            </div>
                                        </div>

                                           <h5 style="color: #FF0000">Podrá verificar el pago a las 72 hs de realizado el depósito</h5>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
           
                <div class="ibox-content">
                    <div class="form-inline">
                        <%--  <div class="form-group">
                    <asp:Button ID="btnFormaPago" Enabled="true" class="btn btn-w-m btn-primary" runat="server" Text="Forma de Pago"
                        OnClick="btnFormaPago_Click" />
                </div>--%>
                        <div class="form-group">
                            <asp:Button ID="btnGestion" formnovalidate="formnovalidate " CssClass="btn btn-secundary" BorderStyle="Solid" Enabled="true"  BorderColor="#333333" ForeColor="Black" runat="server" Text="Volver"
                                OnClick="btnGestion_Click" />
                        </div>
                    </div>
                </div>
           
        </div>
   


</asp:Content>
