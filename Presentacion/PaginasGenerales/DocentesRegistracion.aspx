<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="DocentesRegistracion.aspx.cs" Inherits="DocentesRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
   <div class="ibox-content">  <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-12">
           
                <div class="row">
                    <div class="form-group col-md-3">
                        <label class="control-label">DNI</label>
                        <asp:TextBox ID="doc_doc" required="" BorderColor="Silver" type="text" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="doc_doc_TextChanged"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" BackColor="Transparent"
                            BorderColor="Red" ControlToValidate="doc_doc" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                            Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                    </div>    
                     <div class="form-group col-md-3">
                        <label class="control-label">Apellido</label>
                        <asp:TextBox ID="doc_apellido" required="" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label">Nombre</label>
                        <asp:TextBox ID="doc_nombre" required="" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
               
                    <div class="form-group col-md-3">
                        <label class="control-label">Cuit</label>
                        <asp:TextBox ID="doc_cuit" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" BackColor="Transparent"
                            BorderColor="Red" ControlToValidate="doc_cuit" Display="Dynamic" ErrorMessage="Datos Invalidos.. reingrese."
                            Font-Size="Small" ValidationExpression="^[0-9]*$" Width="90px"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">

                    <div class="form-group col-md-3">
                        <label class="control-label">Domicilio</label>
                        <asp:TextBox ID="doc_domicilio" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>

                    </div>
                    <div class="form-row" style="background-color: #FFFFFF">
                        <div class="form-group col-md-3">
                            <label class="control-label">Teléfono</label>
                            <asp:TextBox ID="doc_telef" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="control-label">Mail</label>
                            <asp:TextBox ID="doc_mail" required="" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-3">

                            <label class="control-label">Perfil</label>
                            <asp:DropDownList BorderColor="Silver" ID="perId" runat="server" class="form-control m-b" Enabled="true">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label runat="server" class="control-label col-md-2" visible="false">_id</label><div class="col-md-6">
                            <asp:TextBox Visible="false" BorderColor="Silver" ID="usu_id" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />

                </div>
             <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>
                <div class="col-sm-12">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnCancelar1" formnovalidate="formnovalidate " class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
