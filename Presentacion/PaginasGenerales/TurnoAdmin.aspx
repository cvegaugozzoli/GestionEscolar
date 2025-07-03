<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TurnoAdmin.aspx.cs" Inherits="TurnoAdmin" %>

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
            position: relative;
            min-height: 1px;
            -ms-flex: 0 0 10%;
            flex: 0 0 100%;
            left: 1px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
            height: 47px;
        }

        .auto-style2 {
            position: relative;
            min-height: 1px;
            -ms-flex: 0 0 10%;
            flex: 0 0 100%;
            left: 1px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
            height: 58px;
        }
        .auto-style3 {
            display: block;
            width: 100%;
            overflow-x: auto;
            -ms-overflow-style: -ms-autohiding-scrollbar;
            margin-left: 93px;
        }
    </style>
</head>
<body>

    <form runat="server">
      

            <%-- <div class="wrap-contact100">--%>
            <div class="container">
                <nav class="navbar justify-content-end navbar-dark bg-dark">
                    <a class="navbar-brand" href="../PaginasBasicas/Index1.aspx">Inicio</a>
                 <%--   <a class="navbar-brand" href="TurnoRegistracion.aspx">Registrar</a>--%>
                </nav>
            </div>

            <div class="auto-style1">
                <div align="center" style="text-align: center">
                    <h4>&nbsp;</h4>
                    <h4><span class="text-navy">&nbsp;- Listado de Turnos por fecha -</span></h4>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                </div>
            </div>

         <br />
            <div class="auto-style2" style="text-align: center">
                <label for="">FECHA</label>&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:TextBox ID="Fecha" runat="server" BorderColor="Silver" BorderStyle="Solid"></asp:TextBox>

                &nbsp;&nbsp;&nbsp;

                <asp:Button ID="btnAplicar" Style="background-color: firebrick" class="btn btn-w-m btn-info m-b" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />

               

            </div>       
                     <div class="col-10" >

            <div class="ibox-content">
                <div class="auto-style3">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False">
                        <Columns>

                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Tutor">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="NombreTutor" runat="server" Text='<%# Eval("NombreTutor") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="DNI" runat="server" Text='<%# Eval("DNI") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Dia">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Dia" runat="server" Text='<%# Eval("Dia") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Horario">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Horario" runat="server" Text='<%# Eval("HorarioDesc") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />

                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
                <div class="form-group text-right" >
                  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <div class="hr-line-dashed"></div>
                </div>
            </div>
     </div>

    </form>
    <div class="container-contact100-form-btn">
        <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
    </div>



    <%-- </div>--%>



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
