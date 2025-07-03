<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TurnoConsulta.aspx.cs" Inherits="TurnoConsulta" %>

<!DOCTYPE html>
<html lang="en" class=" js no-touch">
<head runat="server">
    <title>Asociación Civil Misericordia</title>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="shortcut icon" href="../images/LogoNuevoAso.jpg" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/Contacto/css/util.css">
    <link rel="stylesheet" type="text/css" href="../css/Contacto/css/main.css">

    <!--===============================================================================================-->
</head>
<body>
    <asp:Label ID="lblDiaSeleccionado" runat="server" Text=""></asp:Label>
 <asp:Label ID="LblTurno" runat="server" Visible="false" Text=""></asp:Label>
    <div class="container-contact100">
        <div class="wrap-contact100">
  <form runat="server" class="contact100-form validate-form">
            <div class="container">
                <nav class="navbar justify-content-end navbar-dark bg-dark">
                    <a class="navbar-brand" href="../PaginasBasicas/Index1.aspx">Inicio</a>
                    <a class="navbar-brand" href="TurnoRegistracion.aspx">Registrar</a>
                </nav>
            </div>


          
              
                <span class="contact100-form-title">
                <br />
                Consultar Turno
                </span>

                <label class="label-input100" for="email">DNI *</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtDni" Style="background-color: #FFFFFF" required class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>


                <%--   <div class="wrap-input100">
                    <label class="label-input100" for=""></label>
                </div>--%>
                <div class="wrap-input100 rs1-wrap-input100">
                    <asp:LinkButton ID="btnConsultar" Style="background-color: #ed4933" class="contact100-form-btn" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                    <span class="focus-input100"></span>
                </div>
              

                <label class="label-input100">Nombre</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtNombre" Style="background-color: #FFFFFF" required class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
                    <label class="label-input100" for="">Dia y Horario</label>
                </div>

                <div class="wrap-input100 rs1-wrap-input100">
                    <asp:TextBox ID="txtDia" Style="background-color: #FFFFFF" required class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <div class="wrap-input100 rs2-wrap-input100 ">
                    <asp:TextBox ID="txtHorario" Style="background-color: #FFFFFF" required class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>

                <div class="container-contact100-form-btn">
                    <div id="alerTurno" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <p>"Se asignó Turno. Gracias!"</p>
                    </div>
                </div>

        <div class="wrap-input100 rs2-wrap-input100 ">
                    <asp:LinkButton ID="btnImprimir" runat="server" Enabled="false" class="contact100-form-btn" OnClick="btnImprimir_Click">&nbsp;Imprimir</asp:LinkButton>
                    <span class="focus-input100"></span>
                </div>
                <div class="container-contact100-form-btn">
                    <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>

                </div>
            </form>

            <div class="contact100-more flex-col-c-m" style="background-image: url('images/bg-01.jpg');">
                <span class="contact100-form-title" style="color: #FFFFFF">Colegio San José: Secundario</span>
                <span class="contact100-form-title" style="color: #FFFFFF">Consultas de Turno</span>
                <div class="flex-w size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <span class="lnr lnr-edit-marker"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">Sr Tutor
                        </span>

                        <span class="txt2" style="color: #FFFFFF">Ingrese su DNI para saber dia y horario en el que solicitó Turno </span>



                    </div>
                </div>


            </div>
        </div>
    </div>



    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <script>
        $(".selection-2").select2({
            minimumResultsForSearch: 20,
            dropdownParent: $('#dropDownSelect1')
        });
    </script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-23581568-13');
    </script>

</body>

</html>
