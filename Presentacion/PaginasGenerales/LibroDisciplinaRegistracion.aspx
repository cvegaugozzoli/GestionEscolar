
<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="LibroDisciplinaRegistracion.aspx.cs" Inherits="LibroDisciplinaRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                                        <asp:TextBox ID="CurId" runat="server" Visible="false" BorderColor="Silver" class="form-control" Enabled="true" ></asp:TextBox>

        </div>


        <div class="col-sm-12">
            <br />
            <label class="control-label col-sm-12">Alumno Seleccionado</label>
            <hr class="pg2-titl-bdr-btm" />
        </div>

        <div class="col-sm-12">
            <div class="ibox-content">
                <fieldset class="form-horizontal">
                    <div class="form-group">
                        <asp:Label class="control-label col-md-1" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="aluNombre" BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label class="control-label col-md-1" ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="aludni" BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label class="control-label col-md-1" ID="lblAnioLectivo" runat="server" Text="Año Lectivo:" Font-Bold="true"></asp:Label>
                        <div class="col-md-1">
                            <asp:TextBox ID="AnioLectivo" BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>                 

                   
                        <label class="control-label col-md-1">Curso</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="curNombre" runat="server" BorderColor="Silver" class="form-control" Enabled="true" ></asp:TextBox>
                        </div>
                   </div>

                    <div class="form-group">

                        <label class="control-label col-md-1">Sanción:</label>
                        <div class="col-md-2">
                            <asp:DropDownList ID="TipoSancionId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                        <asp:Label class="control-label col-md-1" ID="lblCant" runat="server" Text="Cantidad:" Font-Bold="true"></asp:Label>
                        <div class="col-md-1">
                            <asp:TextBox ID="Cantidad" BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label class="control-label col-md-1" ID="LblSolicitante" runat="server" Text="Solicitante:" Font-Bold="true"></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="Solicitante" required=""  BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>

                         <asp:Label class="control-label col-md-1" ID="LblCargo" runat="server" Text="Cargo:" Font-Bold="true"></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtCargo" BorderColor="Silver" required=""  type="string" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="control-label col-md-1" ID="LblObservacion" runat="server" Text="Observación:" Font-Bold="true"></asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox ID="Observacion" BorderColor="Silver" type="string" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <asp:Label class="control-label col-md-1" ID="LblFecha" runat="server" Text="Fecha:" Font-Bold="true"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFecha" required="" BorderColor="Silver" type="string" class="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                </fieldset>
            </div>

        </div>

    </div>

    <div class="col-sm-12">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnGrabar" class="btn btn-w-m btn-primary" runat="server" Text="Grabar" OnClick="btnGrabar_Click" Width="100%" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelar" formnovalidate="formnovalidate" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                </div>
            </div>
        </div>
    </div>

    
   
</asp:Content>

