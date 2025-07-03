<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TurnoRegistracion.aspx.cs" Inherits="TurnoRegistracion" %>

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
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
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
                        <a class="navbar-brand" href="TurnoConsulta.aspx">Consultar</a>
                    </nav>
                </div>

                <br />



                <%--                <div class="form-row" style="text-align: right">
                    <a href="../PaginasBasicas/Index1.aspx" style="font-weight: 500; text-align: right; float: left;"><i class="fa fa-home fa-2x"></i>Inicio</a>
                    <br />
                </div>--%>
                <span class="contact100-form-title">
                    <br />
                    Solicitar Turno
                </span>
                <label class="label-input100" for="first-name">Ingrese su Nombre Completo *</label>
                <div class="wrap-input100  validate-input" data-validate="Type first name">
                    <asp:TextBox ID="txtNombre" placeholder="Apellido y Nombre" required class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100" for="email">DNI *</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="txtDni" Style="background-color: #FFFFFF" required class="input100" runat="server"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100" for="email">Trámite *</label>
                <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                    <asp:DropDownList ID="ddlTramite" runat="server" BorderColor="Silver" BorderStyle="Solid" Enabled="true" CssClass="dropdown-item">
                    </asp:DropDownList>
                    <span class="focus-input100"></span>
                </div>
                <br />
                <br />

                <label class="label-input100" for="message">Seleccione Día *</label>

                <div class="wrap-input100 validate-input" data-validate="Message is required">
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" OnDayRender="Calendar_DayRender" BorderWidth="1px" CellPadding="1" DayNameFormat="Short" Font-Names="Verdana" Font-Size="10pt" ForeColor="#003399" Height="290px" Width="425px" OnSelectionChanged="Calendar2_SelectionChanged">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="12pt" ForeColor="#CCCCFF" Height="30px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>

                </div>
                <label class="label-input100" for="phone">Horario</label>
                <div class="wrap-input100">
                    <div class="input100">

                        <asp:DropDownList ID="ddlHorario" runat="server" BorderColor="Silver" BorderStyle="Solid" Enabled="true" CssClass="dropdown-item">
                        </asp:DropDownList>
                        <span class="focus-input100"></span>
                    </div>
                </div>

                       <br />

                       <label class="label-input100" for="email">Archivo *</label>
                <div class="wrap-input100 validate-input" >
                  
                        <asp:FileUpload ID="FileUpload2" runat="server"/>
                         <p class="cta-sub-title"></p>                                       
                    <span class="focus-input100"></span>
                </div>
                        
                    

                <div class="wrap-input100">
 <br />
                </div>
                <div class="wrap-input100 rs1-wrap-input100">
                    <asp:LinkButton ID="btnSolicitar" Style="background-color: #ed4933" class="contact100-form-btn" runat="server" Text="Solicitar" OnClick="btnSolicitar_Click" />
                    <span class="focus-input100"></span>
                </div>
                <div class="wrap-input100 rs2-wrap-input100 ">
                    <asp:LinkButton ID="btnImprimir" runat="server" Enabled="false" OnClick="btnImprimir_Click" class="contact100-form-btn">Imprimir</asp:LinkButton>
                    <span class="focus-input100"></span>
                </div>


                <div class="container-contact100-form-btn">
                    <div id="alerTurno" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <p>"Se asignó Turno. Gracias!"</p>
                    </div>
                </div>
                <div class="container-contact100-form-btn">
                    <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>

                </div>
            </form>

            <div class="contact100-more flex-col-c-m" style="background-image: url('images/bg-01.jpg');">
                <span class="contact100-form-title" style="color: #FFFFFF">Colegio San José: Secundario</span>
                <span class="contact100-form-title" style="color: #FFFFFF">Requisitos</span>
                <div class="flex-w size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <span class="lnr lnr-edit-marker"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">7° Grado
                        </span>

                        <span class="txt2" style="color: #FFFFFF">- FOTOCOPIA del DNI actualizado del alumno postulante (frente y atrás) </span>

                        <span class="txt2" style="color: #FFFFFF">- FOTOCOPIA del DNI del padre/madre si es hijo del personal  </span>

                        <span class="txt2" style="color: #FFFFFF">- FOTOCOPIA de dos cuotas pagadas (como mínimo)  </span>

                    </div>
                </div>

                <div class="dis-flex size1 p-b-47">
                    <div class="txt2 p-r-25">
                        <span class="lnr lnr-edith-handset"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">1° Año
                        </span>
                        <span class="txt3" style="color: #FFFFFF">- FOTOCOPIA del DNI actualizado del alumno postulante (frente y atrás) </span>

                        <span class="txt3" style="color: #FFFFFF">- FOTOCOPIA del DNI del padre/madre si es hijo del personal  </span>

                        <span class="txt2" style="color: #FFFFFF">- FOTOCOPIA de dos cuotas pagadas (como mínimo)  </span>
                    </div>
                </div>

                <div class="dis-flex size1 p-b-47">
                    <div class="txt3 p-r-25">
                        <span class="lnr lnr-edith-handset"></span>
                    </div>

                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">3° Año
                        </span>
                        <span class="txt3" style="color: #FFFFFF">- FOTOCOPIA del DNI actualizado del alumno postulante (frente y atrás) </span>

                        <span class="txt3" style="color: #FFFFFF">- FOTOCOPIA del DNI del padre/madre si es hijo del personal  </span>

                        <span class="txt2" style="color: #FFFFFF">- FOTOCOPIA de dos cuotas pagadas (como mínimo) </span>
                    </div>
                </div>


            </div>
        </div>
    </div>
    <footer id="footer" aria-orientation="vertical" style="text-align: center; color: #333333;" class="auto-style1">

        

            <a href="TurnoAdmin.aspx"> INTRANET</a>
       
    </footer>


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
