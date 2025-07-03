<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cuHoraMinuto.ascx.cs"
    Inherits="cuHoraMinuto" %>
<table>
    <tr>
        <td>
            HH Desde
        </td>
        <td>
            <asp:TextBox ID="txtHoraDesde" class="form-control" runat="server" Width="120px"
                placeholder="HH Desde" AutoPostBack="True" OnTextChanged="txtHoraDesde_TextChanged"
                onClick="this.select();"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            MM Desde
        </td>
        <td>
            <asp:TextBox ID="txtMinutoDesde" class="form-control" runat="server" Width="120px"
                placeholder="MM Desde" AutoPostBack="True" OnTextChanged="txtMinutoDesde_TextChanged"
                onClick="this.select();"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
            HH Hasta
        </td>
        <td>
            <asp:TextBox ID="txtHoraHasta" class="form-control" runat="server" Width="120px"
                placeholder="HH Hasta" AutoPostBack="True" OnTextChanged="txtHoraHasta_TextChanged"
                onClick="this.select();"></asp:TextBox>
        </td>
        <td>
        </td>
        <td>
            MM Hasta
        </td>
        <td>
            <asp:TextBox ID="txtMinutoHasta" class="form-control" runat="server" Width="120px"
                placeholder="MM Hasta" AutoPostBack="True" OnTextChanged="txtMinutoHasta_TextChanged"
                onClick="this.select();"></asp:TextBox>
        </td>
    </tr>
</table>
