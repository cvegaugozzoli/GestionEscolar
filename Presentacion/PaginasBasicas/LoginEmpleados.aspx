<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginEmpleados.aspx.cs" Inherits="LoginEmpleados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sistema de Gestion</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <%--<img src="../images/LogoNuevoAso.jpg" />--%>
    <link runat="server" id="LinkPage" rel="shortcut icon" href="/images/LogoNuevoAso.jpg " />
    <style type="text/css">
        .nuevoEstilo1 {
            color: #FFFFFF;
        }

        .nuevoEstilo2 {
            color: #FFFFFF;
        }

        .nuevoEstilo3 {
            color: #FFFFFF;
            font-weight: 700;
        }

        .nuevoEstilo4 {
            color: #FFFFFF;
        }

        .nuevoEstilo5 {
            color: #FFFFFF;
        }

        .nuevoEstilo6 {
            color: #FFFFFF;
        }

        .style1 {
            color: #FFFFFF;
            font-size: 11pt;
            font-weight: 700;
        }
    </style>
</head>
<body class="gray-bg" background="../Imagenes/FondoPrincipalEmpleados.jpg">
    <form id="form1" runat="server">
        <div class="middle-box text-center loginscreen animated fadeInDown">
            <div>
                <div>
         
                    <h1 class="logo-name">
              
                        <asp:Image ID="ima" runat="server" ImageUrl="../images/LogoNuevoAso.jpg" Height="175px" Width="179px" />
                    </h1>

                    &nbsp;
                </div>
                <p class="style1">
                    
                <asp:Label ID="lblClienteNombre" runat="server" Text="RECIBOS DE SUELDO EN LINEA DE LA OBRA MISERICORDISTA"></asp:Label><br />
                    <%--Ingreso al sistema--%>
                </p>
             <%--   <div class="form-group" runat="server" visible="true">

                    <asp:DropDownList ID="ColegioId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="ColegioId_SelectedIndexChanged" AppendDataBoundItems="true"></asp:DropDownList>
                </div>--%>

            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario"
                    required=""></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtClave" runat="server" type="password" class="form-control" placeholder="Clave"
                    required=""></asp:TextBox>
            </div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-primary block full-width m-b"
                OnClick="btnIngresar_Click" />
            <div>
                <asp:Label ID="lblUsuarioNoValido" runat="server" Text="Usuario y/o Clave no validos"
                    Visible="False" CssClass="nuevoEstilo3"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblUsuarioNoAlumno" runat="server" Text="El Usuario no es Empleado!"
                    Visible="False" CssClass="nuevoEstilo3"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblInstitucion" runat="server" Text="Debe seleccionar una Institución"
                    Visible="False" CssClass="nuevoEstilo3"></asp:Label>
            </div>
 <div>
                <asp:Label ID="lblErrorInstitucion" runat="server" Text="Usuario no pertenece a esa Institución"
                    Visible="False" CssClass="nuevoEstilo3"></asp:Label>
            </div>

        </div>
     
        <!-- Mainly scripts -->
        <script type="text/javascript" src="../js/jquery-2.1.1.js"></script>
        <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
