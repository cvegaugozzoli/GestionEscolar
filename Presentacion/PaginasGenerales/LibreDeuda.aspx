<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="LibreDeuda.aspx.cs" Inherits="LibreDeuda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblaluId" runat="server" Visible="false" Text=""></asp:Label>
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <label class="control-label col-md-12">Sección Busqueda</label>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-inline">
                <label>Buscar por: </label>
                <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                    <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                    <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                </asp:RadioButtonList>
                <br />
            </div>
        </div>
    </div>


    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="form-inline">
            <div class="form-group col-md-2">
                <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" />
            </div>
            <div class="form-group col-md-6">
                <label class="control-label">Año Lectivo:</label>
                <asp:TextBox ID="txtAnioLectivo" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true" OnTextChanged="txtAnioLectivo_TextChanged"></asp:TextBox>
            </div>

        </div>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox collapsed">
            <%--   <div class="collapse" id="collapseExample">--%>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <br />
                    <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="ibox-title" runat="server" visible="false" id="canRg">
                        <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros2" runat="server" Text=""></asp:Label></h5>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="GrillaBuscar" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="GrillaBuscar_RowDataBound" OnRowCommand="GrillaBuscar_RowCommand"
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

                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="GrillaBuscar" />
                </Triggers>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                </Triggers>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <%--  </div>--%>

    <div class="col-sm-12">
        <label class="control-label col-md-12">Alumno Seleccionado</label>
        <hr class="pg2-titl-bdr-btm" width="100%" />
    </div>
    <div class="ibox-content">
        <div class="row" style="background-color: #FFFFFF">

            <div class="form-group col-md-3">
                <asp:Label ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aludni" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <asp:Label class="control-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aluNombre" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            </div>

         <%--   <div class="form-group col-md-3">
                <asp:Label class="control-label" ID="lblColegio" runat="server" Text="Colegio: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aluColegio" BackColor="#006699" ForeColor="White" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            </div>--%>
        </div>
    </div>
    <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
    
    <div class="row">
        <div class="col-sm-12">           
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="GrillaHistorial" Visible="false" runat="server" DataKeyNames="icoId,RA,cntId,conId,TipoConcepto,Concepto,Importe,ImporteInteres,AnioLectivo,Beca,BecId,NroCuota,FchInscripcion,insId,FechaVto,ImpPagado,FechaPago,NroCompbte,Curso" GridLines="None" CssClass="table table-striped"
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
                               
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                            <asp:BoundField DataField="FechaVto" HeaderText="FechaVto" />
                            <asp:BoundField DataField="ImporteInteres" HeaderText="Int. Mensual" Visible="true" />
                             <asp:BoundField DataField="RA" HeaderText="RA" />
                            <asp:BoundField DataField="AnioLectivo" HeaderText="AnioLectivo" Visible="false" />
                            <asp:BoundField DataField="Beca" HeaderText="Beca" />
                            <asp:BoundField DataField="BecId" HeaderText="BecId" Visible="false" />
                            <asp:BoundField DataField="NroCuota" HeaderText="NroCuota" />
                            <asp:BoundField DataField="FchInscripcion" HeaderText="FchInscripcion" Visible="false" />
                        
                            <asp:BoundField DataField="ValorInteres" HeaderText="ValorInteres" Visible="false" />
                            <asp:BoundField DataField="ImpPagado" HeaderText="ImpPagado" />
                            <asp:BoundField DataField="Colegio" HeaderText="Colegio" />
                            <asp:BoundField DataField="insId" HeaderText="insId" Visible="false" />
                            <asp:BoundField DataField="FechaPago" HeaderText="FechaPago" ItemStyle-CssClass="FechaPago" Visible="false" />
                            <asp:BoundField DataField="NroCompbte" Visible="false" ItemStyle-CssClass="NroCompbte" HeaderText="NroCompbte" />
                            <asp:BoundField DataField="Curso" ItemStyle-CssClass="Curso" HeaderText="Curso" />

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
            </div>
            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
            <asp:Label ID="lblMjerror2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
       


              <div id="alerExito2" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <asp:Label ID="lblExito2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                    <div id="alerError3" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError3" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
            
             </div>
    </div>
    <div class="row">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnImprimir" class="btn btn-w-m btn-warning" runat="server" Text="Imprimir" Visible="false" OnClick="btnImprimirClick" Width="100%" />
                </div>

            </div>
        </div>
    </div>


   
</asp:Content>

