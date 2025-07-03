<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cuHora.ascx.cs" Inherits="Controles_Particulares_cuHora" %>
<asp:TextBox type="number" ID="txtHora" runat="server" Width="60px" AutoPostBack="False"
    placeholder="hh" ToolTip="Hora (HH)"></asp:TextBox>
<asp:TextBox type="number" ID="txtMinuto" runat="server" Width="60px" AutoPostBack="False"
    placeholder="mm" ToolTip="Minuto (MM)"></asp:TextBox>

<asp:RangeValidator ID="rvaHora" runat="server" ControlToValidate="txtHora" MaximumValue="23"
    MinimumValue="0" SetFocusOnError="True" Type="Integer" ValidationGroup="Aceptar"></asp:RangeValidator>

<asp:RegularExpressionValidator ID="revHora" runat="server" ControlToValidate="txtHora"
    ErrorMessage="" SetFocusOnError="True" ValidationExpression="^[0-9]*$" ValidationGroup="Aceptar"></asp:RegularExpressionValidator>

<asp:RangeValidator ID="rvaMinuto" runat="server" ControlToValidate="txtMinuto" MaximumValue="59"
    MinimumValue="0" SetFocusOnError="True" Type="Integer" ValidationGroup="Aceptar"></asp:RangeValidator>

<asp:RegularExpressionValidator ID="revMinuto" runat="server" ControlToValidate="txtMinuto"
    ErrorMessage="" SetFocusOnError="True" ValidationExpression="^[0-9]*$" ValidationGroup="Aceptar"></asp:RegularExpressionValidator>
