<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="GenerarArchivoBanco.aspx.cs" Inherits="GenerarArchivoBanco" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblInsId" runat="server" Visible="false" Text=""></asp:Label>
        </div>
        <div class="col-sm-12" style="background-color: #FFFFFF">
            <div class="ibox-content" style="background-color: #FFFFFF">
                <div class="form-row" style="background-color: #FFFFFF">
                    <div class="form-group col-md-2">
                        <label class="control-label">Bancos Adheridos</label>
                        <asp:DropDownList ID="BcoAdhId" AutoPostBack="true" class="form-control m-b" runat="server" OnSelectedIndexChanged="BcoAdhId_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Caja Municipal</asp:ListItem>
                            <asp:ListItem Value="2">Patagonia</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-2">
                        <label class="control-label">Conceptos Tipos</label>
                        <asp:DropDownList ID="cntId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                    </div>
                </div>
            <div class="form-group col-md-2">
                <label class="control-label">Año Lectivo</label>
                <asp:TextBox ID="conAnioLectivo" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-2" runat="server" id="lblFchEmi" visible="true">
                <label class="control-label">Fecha Emisión:</label>
                <asp:TextBox ID="txtDesde" type="DateTimePicker" placeholder="dd/mm/aaaa" class="form-control" runat="server" AutoPostBack="true" BorderColor="Silver" OnTextChanged="txtDesde_TextChanged"></asp:TextBox>
            </div>

            <div class="form-group col-md-2" runat="server" id="lblFchAbi" visible="true">
                <label class="control-label">Fecha Vto Abierto:</label>
                <asp:TextBox ID="txtHasta" type="DateTimePicker" placeholder="dd/mm/aaaa" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <label class="control-label" runat="server" id="lblDesde" visible="false">Cuota</label>
                <asp:DropDownList ID="ddlDesde" Visible="false" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>

                </asp:DropDownList>
            </div>
        <div class="form-group col-md-1" runat="server" >
                <label class="control-label" runat="server" id="lblDisparo" visible="false">Disparo</label>
                &nbsp;<asp:DropDownList ID="ddlDisparo" Visible="false" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                   
                </asp:DropDownList>
            </div>

                  <div class="form-group col-md-2" runat="server" id="lblFchImputar" visible="false">
                <label class="control-label">Fecha Imputar:</label>
                <asp:TextBox ID="FchImputar" type="DateTimePicker" placeholder="dd/mm/aaaa" class="form-control" AutoPostBack="true" runat="server" BorderColor="Silver" ></asp:TextBox>
            </div>
            <div class="form-group col-md-2" >
                <label class="control-label" runat="server" id="lblhasta" visible="false">Cuota Hasta  </label>
                &nbsp;<asp:DropDownList ID="ddlHasta" Visible="false" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList>
            </div>

    
        </div>

    </div>
   <hr class="hr-line-dashed" />
  
        <div class="col-sm-12">  <div class="row" style="background-color: #FFFFFF">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" OnClientClick="javascript:ShowProgressBar()" Text="Generar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div id="dvProgressBar" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.5;">
                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/ajax-loader.gif" AlternateText="Cargando ..." ToolTip="Cargando ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Salir" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnDescargar" class="btn btn-w-m btn-primary" runat="server" OnClientClick="javascript:ShowProgressBar()" Text="Descargar" OnClick="btnDescargar_Click" Width="100%" Visible="false" />

                        <%--                            <a href="ftp://obramisericordista.com.ar/public_html/PaginasGenerales/ArchivosCaja/" target="_blank">                                
                            </a>--%>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div id="Mje" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <h5 style="font-weight: bold; font-size: medium">"Archivo Generado con exito!!.."</h5>
                    </div>
                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>

                </div>
            </div>

             <div id="LeyendaPatagonia" visible="false"  runat="server" class="alert alert-primary  alert-dismissable">
  <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium"> - La fecha a Imputar no debe coincidir con feriados ni con fines de semana (sábados o domingos)..</asp:Label>
                    </br>    </br>

                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium"> - Para el primer disparo: </br>
                            * La fecha de Emisión se debe realizar hasta 72 horas hábiles antes del mes anterior a debitar (entre los días 16 al 27), el importe será sin interés.</br>
                            * La fecha de Imputación será el 1 de cada mes o el primer dia hábil después del 1 de ese mes.. </asp:Label>
                    </br>       </br>  
                                      
<%--            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium">- Para el segundo disparo:</br>
                 *La fecha de Emisión se debe realizar hasta 72 horas hábiles antes del mes a debitar (entre los días 1 al 13), el importe será con interés.. </br>
                  * La fecha de Imputación será el 15 de cada mes o el primer dia hábil después del 15 de ese mes..                
               </asp:Label>
                   </br></br> --%>

            </div>
        </div>
    </div>



  



</asp:Content>
