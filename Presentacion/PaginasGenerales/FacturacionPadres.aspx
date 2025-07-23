<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalPadres.master" AutoEventWireup="true" CodeFile="FacturacionPadres.aspx.cs" Inherits="FacturacionPadres" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PrincipalPadres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Text=""></asp:Label><br />
                <asp:Label ID="lblDni" runat="server" Font-Bold="True"></asp:Label>
            </div>
        </div>


        <div class="row">
            <div class="col-sm-12">

                <div class="table-responsive">
                    <asp:GridView ID="GridConcepto" DataKeyNames="icoId,cntId,TipoConcepto,Concepto,NroCuota,Importe,FechaVto,Beca,InteresCuota,RecargoAbierto,InteresMensual,Dcto,InteresTotal"
                        runat="server" GridLines="None" CssClass="table table-striped" BackColor="#154F77"
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
                            <asp:TemplateField HeaderText="Intereses">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="InteresTotal" runat="server" Text='<%# Eval("InteresTotal","{0:n}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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



                <div class="row">
                    <div class="form-group col-sm-12 " align="right">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " style="font-weight: bold; font-size: x-large; color: #1f2548">Total a Pagar:</label>
                        <asp:Label ID="lblSubTotal" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#1f2548"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-sm-12 " align="right">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <label class="control-label " style="font-weight: bold; font-size: x-large; color: #FF0000;">Total Pagado:</label>
                        <asp:Label ID="lblTotal" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-sm-12 " align="right">
                        <asp:Label ID="EstadoPago" runat="server" Font-Size="Large" Font-Bold="True" ForeColor="Red" Text="" Visible="true"></asp:Label>
                    </div>
                </div>

                <asp:Label ID="LblMjeGridConcepto" runat="server" Text="" Style="font-size: large; color: #1f2548"></asp:Label>

            </div>
        </div>



        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-12 text-center mobile-buttons-stack">
                <asp:Button ID="btnPagar" class="btn btn-primary dim btn-lg" runat="server" Text="Pagar" OnClick="btnPagar_Click" />
                <asp:Button ID="btnVolver" class="btn btn-white dim btn-lg" runat="server" Text="Volver" OnClick="btnGestion_Click" />
                <asp:Button ID="btnImprimir" class="btn btn-info dim btn-lg" runat="server" Visible="false" Enabled="false" Text="Imprimir" OnClick="btnImprimir_Click" />
            </div>
        </div>

        <div class="div.form-row.form-row-transparent-bg">
            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
            <div id="alerInfo" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                <asp:Label ID="lblalerInfo" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
        </div>

        <%--    <div class="row">
        <div class="ibox-content">
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
            </div>
        </div>
    </div>--%>


        <div class="div.form-row.form-row-transparent-bg">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblicoId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblcpvId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblcocId" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblinst" runat="server" Visible="false" Text=""></asp:Label>
            <asp:DropDownList ID="CompTipoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" Visible="false"></asp:DropDownList>
            <asp:Label ID="lblCompTipo" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False"></asp:Label>
            <asp:Label ID="lblNroPtoVta" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False"></asp:Label>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False">-</asp:Label>
            <asp:Label ID="lblUltimoNro" runat="server" Font-Size="X-Large" Font-Bold="True" ForeColor="#006699" Visible="False"></asp:Label>
            <asp:DropDownList ID="DestinoId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true" Visible="false"></asp:DropDownList>

            <asp:Label ID="lab_inp_IdReferenciaOperacion" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="lblidReferenciaOperacion" Visible="false" runat="server" Font-Bold="True"></asp:Label>
            <asp:Label ID="lblaluid" Visible="false" runat="server" Font-Bold="True"></asp:Label>
            <asp:Label ID="txtFechaPago" runat="server" Visible="false" Font-Bold="True"></asp:Label>
        </div>


        <style type="text/css">
            /* Estilos específicos para pantallas pequeñas */

            div.form-row.form-row-transparent-bg {
                background-color: transparent !important;
            }

            @media (max-width: 767px) {
                /* ... Tus otras reglas de media query para filtros y grilla ... */

                /* Reglas para apilar los botones Pagar, Volver, Imprimir en móvil */
                .mobile-buttons-stack {
                    display: flex; /* Habilitar Flexbox */
                    flex-direction: column; /* Apilar los elementos verticalmente */
                    align-items: stretch; /* Estira los elementos para ocupar el ancho completo del contenedor */
                    gap: 10px; /* Espacio entre los botones (moderno, no todos los navegadores viejos lo soportan, si hay problemas usa margin-bottom) */
                    padding-left: 15px; /* Asegura que no estén pegados a los bordes */
                    padding-right: 15px;
                }

                    /* Asegura que los botones dentro del stack ocupen el 100% y tengan margen inferior si no usas gap */
                    .mobile-buttons-stack .btn {
                        width: 100% !important; /* Fuerza a cada botón a ocupar el 100% del ancho */
                        margin-bottom: 10px; /* Espacio entre los botones */
                    }

                        /* Eliminar margen inferior del último botón para evitar espacio extra al final */
                        .mobile-buttons-stack .btn:last-child {
                            margin-bottom: 0;
                        }

                /* Para botones que ya tienen clases de Bootstrap como .btn-block, este ajuste no sería estrictamente necesario
               ya que .btn-block ya da 100% de ancho, pero el flex-direction: column es el crucial para el apilamiento.
               Sin embargo, es buena práctica ser explícito.
            */
            }

            /* Opcional: Para escritorio, si quieres que los botones estén en línea, 
           asegúrate de que no haya reglas de flexbox que los apilen */
            @media (min-width: 768px) {
                .mobile-buttons-stack {
                    display: block; /* Vuelve al comportamiento normal de bloque para que los botones floten o se comporten según las reglas de .col-sm-X */
                    text-align: center; /* Centra los botones en desktop */
                }

                    .mobile-buttons-stack .btn {
                        width: auto; /* Permite que los botones tengan su ancho natural */
                        margin-left: 5px; /* Espacio entre ellos en desktop */
                        margin-right: 5px;
                        margin-bottom: 0; /* Asegura que no haya margen inferior */
                    }
            }
        </style>
</asp:Content>
