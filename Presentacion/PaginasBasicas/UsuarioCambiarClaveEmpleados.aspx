<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/PrincipalEmpleados.master"
    AutoEventWireup="true" CodeFile="UsuarioCambiarClaveEmpleados.aspx.cs" Inherits="UsuarioCambiarClaveEmpleados" %>

<%--<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>--%>
<%@ MasterType TypeName="PrincipalEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">
                <fieldset class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Cambiar Clave"
                                OnClick="btnAceptar_Click" ValidationGroup="Aceptar" />
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />
                    <div class="form-group">
                        <label class="control-label col-md-2">
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="ClaveActual" type="text" class="form-control" runat="server" TextMode="Password"
                                placeholder="Clave Actual"></asp:TextBox></div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="ClaveNueva" type="text" class="form-control" runat="server" TextMode="Password"
                                placeholder="Clave Nueva"></asp:TextBox></div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="RepitaClave" type="text" class="form-control" runat="server" TextMode="Password"
                                placeholder="Repita Clave"></asp:TextBox></div>
                    </div>
                    <div class="alert alert-info alert-dismissable">
                        La contraseña debe cumplir los siguientes requisitos:<br />
                        <br />
                        * contener letras tanto en mayusculas y minusculas<br />
                        * contener al menos 1 caracter numerico<br />
                        * el tamaño de la contraseña debe ser de 6 a 15 caracteres</div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                        </label>
                        <div class="col-md-6">
                            <asp:RegularExpressionValidator ID="revClaveNueva" runat="server" ErrorMessage="Clave Nueva. No cumple requisitos"
                                ControlToValidate="ClaveNueva" SetFocusOnError="True" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$"
                                ValidationGroup="Aceptar"></asp:RegularExpressionValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvClaveActual" runat="server" ControlToValidate="ClaveActual"
                                ErrorMessage="Clave Actual. Requerido" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvClaveNueva" runat="server" ControlToValidate="ClaveNueva"
                                ErrorMessage="Clave Nueva. Requerido" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvRepitaClave" runat="server" ControlToValidate="RepitaClave"
                                ErrorMessage="Repita Clave. Requerido" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="cvaClaves" runat="server" ControlToCompare="ClaveNueva"
                                ControlToValidate="RepitaClave" ErrorMessage="Clave Nueva y Repita Clave deben ser iguales"
                                SetFocusOnError="True" ValidationGroup="Aceptar"></asp:CompareValidator>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
