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

        /* Estilos para el contenedor del campo de contraseña y el icono */
        .password-container {
            position: relative; /* Esencial para posicionar el icono absolutamente dentro de este div */
        }

        /* Estilos para el icono de mostrar/ocultar contraseña */
        .password-toggle {
            position: absolute; /* Posiciona el icono de forma absoluta */
            right: 15px; /* Ajusta la distancia desde el borde derecho */
            top: 50%; /* Centra verticalmente */
            transform: translateY(-50%); /* Ajuste fino para centrado vertical */
            cursor: pointer; /* Cambia el cursor a una manita para indicar que es clicable */
            color: #999; /* Color del icono */
            font-size: 1.2em; /* Tamaño del icono */
            z-index: 10; /* Asegura que esté por encima del input */
        }

        /* Opcional: Estilo para cuando el icono se cambia a ojo tachado (si quieres esa animación) */
        .password-toggle .fa-eye-slash {
            color: #555; /* Un color un poco más oscuro cuando está "escondiendo" */
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
            <div class="form-group password-container">
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control" placeholder="Clave"></asp:TextBox>
                <span class="password-toggle" id="togglePassword">
                    <i class="fa fa-eye"></i> </span>
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

        <script type="text/javascript">
            // Espera a que el DOM esté completamente cargado
            document.addEventListener('DOMContentLoaded', function () {
                const togglePassword = document.getElementById('togglePassword');
                const passwordInput = document.getElementById('<%= txtClave.ClientID %>'); // Usa ClientID para ASP.NET

                if (togglePassword && passwordInput) { // Asegura que los elementos existen
                    togglePassword.addEventListener('click', function () {
                        // Alterna el tipo de input entre 'password' y 'text'
                        const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
                        passwordInput.setAttribute('type', type);

                        // Alterna el icono de ojo visible/tachado
                        this.querySelector('i').classList.toggle('fa-eye');
                        this.querySelector('i').classList.toggle('fa-eye-slash');
                    });
                } else {
                    console.warn("Elementos para mostrar/ocultar contraseña no encontrados.");
                }
            });
        </script>

    </form>
</body>
</html>
