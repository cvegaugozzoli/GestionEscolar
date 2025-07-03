<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sesion.aspx.cs" Inherits="PaginasBasicas_Sesion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Autogestion</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link runat="server" id="LinkPage" rel="shortcut icon" href="../images/LogoNuevoAso.jpg" />
    <style type="text/css">
        .nuevoEstilo1
        {
            color: #FFFFFF;
        }
    </style>
</head>
<body class="gray-bg" background="../Imagenes/FondoPrincipal.jpg">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="tim" runat="server" OnTick="tim_Tick" Interval="30000" Enabled="true" />
    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>
                <h1 class="logo-name">
                    <asp:Image ID="ima" runat="server" ImageUrl="../images/LogoNuevoAso.jpg" Height="175px" Width="179px" />
                </h1>
              
            </div>
            <br />
            <h3 class="nuevoEstilo1">
                Mientras utiliza la plataforma Web NO CERRAR esta pagina</h3>
            <br />
            <a href="Inicio.aspx" class="btn btn-primary" target="_blank">Ingresar</a>
            <a href="CerrarSesion.aspx" class="btn btn-primary">Cerrar Sesion</a>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script type="text/javascript" src="../js/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
