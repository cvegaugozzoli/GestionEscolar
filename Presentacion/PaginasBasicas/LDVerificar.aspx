<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LDVerificar.aspx.cs" Inherits="LDVerificar" %>

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

                <span class="contact100-form-title">Estado de Cuenta
                </span>
                <hr class="hr-line-dashed" />
                <br />
                <label class="label-input100" for="first-name">Nombre del Alumno</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtNombre" class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100">Curso</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtCurso" class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                  <label class="label-input100">Concepto</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtConcepto" class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100">Mes y Año</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtMes" class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
              
                <label class="label-input100"></label>
                <div class="wrap-input100">
                    <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="wrap-input100 ">
                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </div>

            </form>
            <div class="contact100-more flex-col-c-m" style="color: #FFFFFF">
                <img src="../images/LogoChico.jpg" />
                <br />
                <span class="contact100-form-title" style="color: #FFFFFF">Obra Misericordista</span>

                <div class="dis-flex size1 p-b-47">
                    <div class="txt1 p-r-25">

                        <%--<span class="lnr lnr-phone-handset"></span>--%>
                    </div>
                    <div class="flex-col size2">
                        <%--  <span class="txt1 p-b-20">Instituciones
                        </span>--%>
                        <br />
                        <span class="txt1">COLEGIO SAN JOSÉ</span>
                        <br />
                        <span class="txt1">COLEGIO MISERICORDIA</span>
                        <br />
                        <span class="txt1">JARDÍN MISERICORDIA</span>
                        <br />
                        <span class="txt1">JARDÍN PADRE VICTOR</span>
                        <br />
                        <span class="txt1">JESCUELA SAN VICENTE</span>
                        <br />
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
