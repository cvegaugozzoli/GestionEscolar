<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactoSanVicente.aspx.cs" Inherits="ContactoSanVicente" %>


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

    <div class="container-contact100">
        <div class="wrap-contact100">
            <form runat="server" class="contact100-form validate-form">
                <span class="contact100-form-title">Formulario de Contacto
                </span>

                <label class="label-input100" for="first-name">Ingrese su Nombre Completo *</label>
                <div class="wrap-input100  validate-input" data-validate="Type first name">

                    <asp:TextBox ID="txtNombre" placeholder="Apellido y Nombre" required class="input100" runat="server"></asp:TextBox>

                    <span class="focus-input100"></span>
                </div>

                <label class="label-input100" for="email">Ingrese su Mail *</label>
                <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">

                    <asp:TextBox ID="txtMail" Style="background-color: #FFFFFF" required class="input100" runat="server" placeholder="Eg. example@email.com"></asp:TextBox>

                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100" for="email">Asunto *</label>
                <div class="wrap-input100" >

                    <asp:TextBox ID="txtAsunto" Style="background-color: #FFFFFF" required class="input100" runat="server" ></asp:TextBox>

                    <span class="focus-input100"></span>
                </div>
               
                <label class="label-input100" for="message">Mensaje *</label>
                <div class="wrap-input100 validate-input" data-validate="Message is required">
                    <asp:TextBox ID="txtMje" TextMode="MultiLine" class="input100" runat="server" required placeholder="Escribe su mensaje"></asp:TextBox>
                    <%--  <textarea id="txtMje" class="input100" runat="server"  required name="message" ></textarea>--%>
                    <span class="focus-input100"></span>
                </div>            

                <div class="wrap-input100 rs1-wrap-input100" >
                    <asp:LinkButton ID="btnEnviar" Style="background-color: #ed4933" class="contact100-form-btn" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    <span class="focus-input100"></span>
                </div>
                <div class="wrap-input100 rs2-wrap-input100 " >
                    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" class="contact100-form-btn"><i class="fa fa-home fa-2x"></i>&nbsp;Inicio</asp:LinkButton>
                    <span class="focus-input100"></span>
                </div>
                <div class="container-contact100-form-btn">
                    <div id="alerMail" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <p>"La Consulta se ha enviado Correctamente al e-mail del Colegio, Listo!!"</p>
                    </div>

                </div>
                <div class="container-contact100-form-btn">
                    <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>

                </div>
            </form>

            <div class="contact100-more flex-col-c-m" style="background-image: url('images/bg-01.jpg');">
                <span class="contact100-form-title" style="color: #FFFFFF">Colegio San Vicente</span>
                <div class="flex-w size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <span class="lnr lnr-map-marker"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">Dirección
                        </span>

                        <span class="txt2"> Absalon Ibarra 545. santiago del Estero.
                        </span>
                    </div>
                </div>

                <div class="dis-flex size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <span class="lnr lnr-phone-handset"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">Telefono
                        </span>

                        <span class="txt3">0385-4218003
                        </span>
                    </div>
                </div>

                <div class="dis-flex size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <span class="lnr lnr-envelope"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">Contactos
                        </span>

                        <span class="txt3">secretaria@sanvicente.edu.ar
                     
                        </span>
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