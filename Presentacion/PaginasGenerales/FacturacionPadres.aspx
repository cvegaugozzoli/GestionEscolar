<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="FacturacionPadres.aspx.cs" Inherits="FacturacionPadres" %>

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
                    <asp:DropDownList ID="CompTipoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" Visible="false"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4" align="center">
                    <asp:Label ID="lblCompTipo" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False"></asp:Label>
                    <asp:Label ID="lblNroPtoVta" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False">-</asp:Label>
                    <asp:Label ID="lblUltimoNro" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False"></asp:Label>

                </div>

                <div class="form-group col-md-4">
                    <asp:DropDownList ID="DestinoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" Visible="false"></asp:DropDownList>
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


<%--                <div class="form-row">
                    <asp:Label ID="Label4" runat="server" Text="hash.." Visible="true"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="idResultado.." Visible="true"><br /><br /></asp:Label><br />
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="json.." Visible="true"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="json.." Visible="true"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="URL" Visible="true"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="" Visible="true"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="" Visible="true"></asp:Label><br />
                    <br />
                </div>--%>

                <div class="form-row">
                    <div class="form-group col-md-5">
                        <label class="control-label ">Apellido y Nombre:</label>
                        <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Text=""></asp:Label>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label ">DNI:</label> <asp:Label ID="lblaluid" Visible ="false" runat="server" Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblDni" runat="server" Font-Bold="True"></asp:Label>
                    </div>
<%--                    <div class="form-group col-md-5">
                        <label class="control-label ">Dirección:</label>
                        <asp:Label ID="lblDireccion" runat="server" Font-Bold="True"></asp:Label>
                    </div>--%>
                </div>

<%--                <div class="form-row">
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
                </div>--%>
            </div>
        </div>
    </div>
    <div class="form-inline">
        <label class="control-label ">Fecha de Pago:</label>
        <asp:TextBox ID="txtFechaPago" type="DateTimePicker" class="form-control" runat="server" BorderColor="Silver" Enabled="false"></asp:TextBox>
    </div>


    <div class="row">
        <div class="col-sm-12">

            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="GridConcepto" DataKeyNames="icoId,cntId,TipoConcepto,Concepto,NroCuota,Importe,FechaVto,Beca,InteresCuota,RecargoAbierto,InteresMensual,Dcto,InteresTotal"
                        runat="server" GridLines="None" CssClass="table table-striped" BackColor="#154F77"
                        AutoGenerateColumns="False" OnRowDataBound="GridConcepto_RowDataBound" OnRowCommand="GridConcepto_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="GridConcepto_PageIndexChanging">

                        <Columns>
                            <%--                            <asp:TemplateField HeaderText="" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" AutoPostBack="true" OnCheckedChanged="chkSeleccion_CheckedChanged" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>--%>
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
<%--                            <asp:TemplateField HeaderText="Fecha Vto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="FechaVto" runat="server" Text='<%# DateTime.Parse(Eval("FechaVto").ToString()).ToString("d") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Beca">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Beca" runat="server" Text='<%# Eval("Beca") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>

<%--                            <asp:TemplateField HeaderText="Interes Cuota">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresCuota" runat="server" Text='<%# Eval("InteresCuota") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
<%--                            <asp:TemplateField HeaderText="Recargo Abierto">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ImporteInteres" runat="server" Text='<%# Eval("RecargoAbierto","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
<%--                            <asp:TemplateField HeaderText="Interes Mensual">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresMensual" runat="server" Text='<%# Eval("InteresMensual","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
<%--                            <asp:TemplateField HeaderText="Dcto%">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Dcto" runat="server" Text='<%# Eval("Dcto","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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

                    <br /><asp:Label ID="Label8" runat="server" Text="" Visible="true"></asp:Label><br />

            </div>
        </div>
    </div>
    <div class="row">
        <div class="ibox-content">
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

<%--                <div class="form-group">
                    <asp:Button ID="Grabar" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Grabar"
                        OnClick="Grabar_Click" />
                </div>--%>
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnImprimir" formnovalidate="formnovalidate " Enabled="false" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir"
                        OnClick="btnImprimir_Click" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnGestion" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Volver"
                        OnClick="btnGestion_Click" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnPagar" formnovalidate="formnovalidate " class="btn btn-w-m btn-primary" runat="server" Text="Pagar"
                        OnClick="btnPagar_Click" />
                </div>

                <div class="form-group col-md-2">
                    <asp:Button ID="btnRecibirListado" class="btn btn-w-m btn-warning" runat="server" Text="Recibir Listado" Visible="true" OnClick="btnRecibirListadoClick" Width="100%" />
                </div>

            </div>
        </div>
    </div>




    






</asp:Content>
