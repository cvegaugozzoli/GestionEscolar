<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cuFechaHora.ascx.cs" Inherits="Controles_Particulares_cuFechaHora" %>
<asp:TextBox ID="txtFecha" runat="server" type="date" Width="136px" AutoPostBack="False"></asp:TextBox>
<asp:TextBox type="number" ID="txtHora" runat="server" Width="50px" AutoPostBack="False" 
    min="0" max="23" step="1" value="00" data-mask="99"></asp:TextBox>
<asp:TextBox type="number" ID="txtMinuto" runat="server" Width="50px" AutoPostBack="False" 
    min="0" max="59" step="1" value="00" data-mask="99"></asp:TextBox>
<asp:Label ID="lbl" runat="server" Text="" Visible="false"></asp:Label>
