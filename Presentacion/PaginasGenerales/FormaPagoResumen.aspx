<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormaPagoResumen.aspx.cs" Inherits="FormaPagoResumen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tribunal de Falta</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/animate.css" />
    <link rel="stylesheet" href="../css/bootstrap.css" />
    <noscript>
        <link rel="stylesheet" href="assets/css/noscript.css" />
    </noscript>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblMensajeError" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>

        <div class="row" style="align-content: center; padding-left: 15px; padding-right: 15px;">
            <div class="col-md-10">

                <div class="panel panel-primary">
                    <div class="panel-heading">Forma de Pago</div>
                    <div class="panel-body" style="color: black">

                        <div class="form-group col-md-5">
                            <label class="control-label">Nombre:</label>
                            <asp:Label ID="lblNombre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>
                        <div class="form-group col-md-5">
                            <label class="control-label">Fecha Pago:</label>
                            <asp:Label ID="lblFchPago" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Comprobante:</label>
                            <asp:Label ID="lblComprobante" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>

                        <div class="form-group">
                            <label class="control-label">Contado:</label>
                            <asp:Label ID="lblContado" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Tarjeta:</label>
                            <asp:Label ID="lblTarjeta" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Cheque:</label>
                            <asp:Label ID="lblCheque" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Tranferencia Electronica:</label>
                            <asp:Label ID="lblTranfElec" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:Label>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
