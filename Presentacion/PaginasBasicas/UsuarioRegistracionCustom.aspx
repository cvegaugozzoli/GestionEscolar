<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="UsuarioRegistracionCustom.aspx.cs" Inherits="UsuarioRegistracionCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">

                <div class="form-group">

                    <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar"
                        OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" formnovalidate="formnovalidate " class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
                        OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
        <hr class="hr-line-dashed" />
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="row">
                    <div class="form-group col-md-4">
                        <label class="control-label">DNI</label>
                        <asp:TextBox ID="usuDNI" required="" BorderColor="Silver" type="text" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="usuDNI_TextChanged"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" BackColor="Transparent"
                            BorderColor="Red" ControlToValidate="usuDNI" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                            Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Apellido</label>
                        <asp:TextBox ID="usuApellido" required="" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Nombre</label>
                        <asp:TextBox ID="usuNombre" required="" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="row">

                    <div class="form-group col-md-4">
                        <label class="control-label">Cuit</label>
                        <asp:TextBox ID="usuCuit" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" BackColor="Transparent"
                            BorderColor="Red" ControlToValidate="usuCuit" Display="Dynamic" ErrorMessage="Datos Invalidos.. reingrese."
                            Font-Size="Small" ValidationExpression="^[0-9]*$" Width="90px"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Domicilio</label>
                        <asp:TextBox ID="usuDireccion" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Teléfono</label>
                        <asp:TextBox ID="usuTelefono" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="row">

                    <div class="form-group col-md-4">
                        <label class="control-label">Mail</label>
                        <asp:TextBox ID="usuEmail" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4">
                        <label class="control-label">Acceso al Recibo de Sueldo Digital</label>
                        <asp:CheckBox ID="usuRecibo" runat="server" Checked="False"
                            Enabled="true" AutoPostBack="true"
                            OnCheckedChanged="usuRecibo_CheckedChanged" />
                    </div>

                    <div class="form-group col-md-4">
                        <label class="control-label">Perfil</label>
                        <asp:DropDownList BorderColor="Silver" ID="perId" runat="server" class="form-control m-b" Enabled="false">
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="row">
                    <div class="form-group">
                        <label class="control-label col-md-1">
                            Activo</label>
                        <asp:CheckBox ID="usuActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>
                    <div class="form-group">
                        <label runat="server" class="control-label col-md-2" visible="false">_id</label>
                        <asp:TextBox Visible="false" BorderColor="Silver" ID="usu_id" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />

                </div>

                <div class="row">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar"
                            OnClick="btnAceptar_Click" />
                        <asp:Button ID="btnCancelar1" formnovalidate="formnovalidate " class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
                            OnClick="btnCancelar_Click" />
                    </div>
                </div>

            </div>
        </div>
</asp:Content>
