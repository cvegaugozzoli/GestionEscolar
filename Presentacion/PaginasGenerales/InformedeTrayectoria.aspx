<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformedeTrayectoria.aspx.cs" Inherits="InformedeTrayectoria" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>


        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <asp:CheckBox ID="ixaActivo" visible ="false" runat="server" Checked="True" Enabled="true"></asp:CheckBox>

                    <label class="control-label col-md-2">Buscar alumno por DNI:</label>
                    <asp:TextBox ID="aludni" type="string" step="1" class="form-control" runat="server" Width="20%" onClick="this.select();"></asp:TextBox>
                    <asp:Button ID="btnBuscar" class="btn btn-w-m btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" Width="10%" />
                    <asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-primary" runat="server" Text="Cancelar" OnClick="btnCancelarAlumno_Click" Width="10%" />
                </div>
                <br />
                <table width="100%">
                    <tr>
                        <td width="10%" align="left">
                            <label class="control-label col-md-1">Nombre</label>
                        </td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="aluNombre" type="string" class="form-control" runat="server" Enabled ="false"></asp:TextBox>
                        </td>
                        <td width="2%" align="left"></td>
                        <td width="6%" align="left">
                            <label>Legajo Nro</label>
                        </td>
                        <td width="15%" align="left">
                            <asp:TextBox ID="aluLegajoNumero" type="string" class="form-control" runat="server" Enabled ="false"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="aluId" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="icuId" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
                        </td>                       
                    </tr>
                </table>
            </div>
        </div>


        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Listar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
