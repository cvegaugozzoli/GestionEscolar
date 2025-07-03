<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ConfiguracionAnual.aspx.cs" Inherits="ConfiguracionAnual" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="ibox-content">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-sm-12">

                <div class="form-group col-md-2">
                    <label class="control-label ">Año Cursado</label>
                    <asp:TextBox ID="cpfAnioCursado" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true"></asp:TextBox>
                </div>
                <br />
                <asp:CheckBox ID="CheckBox1" Text="Tomar Año" AutoPostBack="true" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
            </div>
        </div>


        <div class="row">
            <div class="col-sm-12">
                <asp:Panel ID="ElementosConfigurar" runat="server" Visible="false">
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Se agregaron los parámetros a Modifica en el año ingresado.. "></asp:Label>

                    </div>
                    <div class="form-group">

                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Elementos a Modificar</th>
                                    <th>Ir</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Modificar Números de Evaluaciones para Espacios Curriculares "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/descarga.png" Height="25px" Width="25px" OnClick="ImageButton1_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Modificar Parámetros para Condición Final"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/descarga.png" Height="25px" Width="25px" OnClick="ImageButton2_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <asp:Panel ID="ElementosNoActualizados" runat="server" Visible="false">
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Aún No se agregaron parámetros para Modifica en el año ingresado.. Ingrese Parámetros "></asp:Label>
                    </div>
                </asp:Panel>

            </div>
        </div>









        <div class="row">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnActualizar" class="btn btn-w-m btn-warning" runat="server" Text="Ingresar Parámetros" OnClick="btnActualizar_Click" Width="100%" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Salir" OnClick="btnCancelar_Click" Width="100%" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
