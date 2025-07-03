<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contacto.aspx.cs" Inherits="Contacto" %>

<!DOCTYPE html>
<html lang="en" class=" js no-touch">
<head runat="server">
    <title>Asociación Civil Misericordia</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="../assets/css/main.css" />
      <link rel="shortcut icon" href="../images/LogoNuevoAso.jpg" />
    <link href="../css/animate.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"
        rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            top: 0px;
            left: 0px;
            float: left;
            width: 100%;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body class="is-preload">

    <!-- Page Wrapper -->
    <div id="page-wrapper">

        <!-- Header -->
        <header id="header">
            <%--        <h1><a href="index1.html">Congregación de los hermanos de la Misericordia</a></h1>--%>
            <nav id="nav">
                <ul>
                    <li class="special">
                        <a href="#menu" class="menuToggle"><span>Menu</span></a>
                        <div id="menu">
                            <ul>
                                <li><a href="Index1.aspx">Inicio</a></li>
                            </ul>
                        </div>
                    </li>
                </ul>
            </nav>
        </header>
        <!-- Main -->
        <article id="main">
            <header style="color: #FFFFFF; font-weight: bold; font-family: 'Times New Roman', Times, serif;">
                <h2>Contacto</h2>
                <p>Sr Tutor, por consultas, complete el siguiente formulario</p>
            </header>
            <div class="ibox-content" style="color: #000000; background-color: #FFFFFF">
                <div align="Center">
                    <h3>&nbsp;</h3>
                    <h3>Formulario de Contacto para el Colegio san José</h3>
                    <p>Si deseas realizar algún tipo de consulta, comentario u obtener algún tipo de información, por favor completa el siguiente formulario y envialo. Te responderemos a la brevedad.</p>
                    <p>&nbsp;</p>
                    <div class="hr">
                    </div>
                </div>
                <form method="post" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 ">
                                <div align="left">
                                    <div class="box-container bbr">
                                        <div class="form-row">
                                            <div class="form-group col-md-3" style="background-color: #FFFFFF">
                                                <label style="color: #000000">Nombre Completo</label>
                                                <asp:TextBox ID="txtNombre" Style="background-color: #FFFFFF" required class="form-control m-b" runat="server" BorderColor="Silver" BorderStyle="Solid"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3" style="background-color: #FFFFFF">
                                                <label style="color: #000000">Mail</label>
                                                <asp:TextBox ID="txtMail" Style="background-color: #FFFFFF" required class="form-control m-b" runat="server" BorderColor="Silver" BorderStyle="Solid"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3" style="background-color: #FFFFFF">
                                                <label style="color: #000000">Asunto</label>
                                                <asp:TextBox ID="txtAsunto" Style="background-color: #FFFFFF" required class="form-control m-b" runat="server" BorderColor="Silver" BorderStyle="Solid"></asp:TextBox>
                                            </div>
                                         
                                          <div class="form-group col-md-3" style="background-color: #FFFFFF">
                                            <label style="color: #000000" class="control-label">Nivel</label>
                                            <asp:DropDownList ID="ddlNivel" runat="server" BorderColor="Silver" BorderStyle="Solid" Enabled="true" style="background-color: #FFFFFF">
                                                <asp:ListItem Value="1" Selected="True">Primario</asp:ListItem>
                                                <asp:ListItem Value="2">Secundario</asp:ListItem>
                                                <asp:ListItem Value="3">Terciario</asp:ListItem>                                               

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-md-12">
                                            <label style="color: #000000">Mensaje</label>
                                            <asp:TextBox ID="txtMje" TextMode="MultiLine" class="form-control" runat="server" required BorderColor="Silver" BorderStyle="Solid"></asp:TextBox>
                                            <br />
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <br />
                                        <div class="form-group col-md-12">
                                            <asp:Button ID="btnEnviar" Style="background-color: #ed4933" class="btn btn-w-m btn-primary" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True"></asp:Label>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <div class="form-row">
                        <div id="alerMail" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <p>"La Consulta se ha enviado Correctamente al e-mail del Colegio, Listo!!"</p>
                        </div>
                    </div>
                    </div>

                </form>
            </div>
        </article>

        <%--  <article id="main">
            <header style="color: #FFFFFF; font-weight: bold; font-family: 'Times New Roman', Times, serif;">
                <h2>Contacto</h2>
                <p>Sr Tutor, por consultas, complete el siguiente formulario</p>
            </header>
            <form method="post" runat="server">

                <section class="wrapper style5">
                    <div class="inner" style="height: 596px; margin-right: auto; margin-left: auto;">
                        <h3>Formulario</h3>
                        <p>Si querés realizar algún tipo de consulta, comentario u obtener algún tipo de información, por favor completa el siguiente formulario y envialo. Te responderemos a la brevedad.</p>
                        <p>&nbsp;</p>
                        <div class="col-sm-12">
                            <div class="ibox-content">
                                <fieldset class="form-horizontal">
                                    <div class="form-row" style="background-color: #FFFFFF">
                                        <div class="form-group col-md-4" style="background-color: #FFFFFF">
                                            <label class="control-label">Nombre</label>
                                            <asp:TextBox ID="txtNombre" type="text" class="form-control" runat="server" BorderColor="Silver" BorderStyle="Solid" Width="310px" BorderWidth="1px"></asp:TextBox>
                                            &nbsp;  &nbsp;
                                        </div>

                                        <div class="form-group col-md-4" style="background-color: #FFFFFF">
                                            <label class="control-label ">Mail</label>
                                            <asp:TextBox ID="txtMail" type="text" class="form-control" runat="server" BorderColor="Silver" Width="310px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                            &nbsp;
                                        </div>

                                        <div class="form-group col-md-4" style="background-color: #FFFFFF">
                                            <label class="control-label">Institución</label>
                                            <asp:DropDownList ID="ddlColegio" runat="server" class="form-control" BorderColor="Silver" Width="310px" BorderStyle="Solid" Enabled="true">

                                                <asp:ListItem Value="1">Colegio San Jose</asp:ListItem>
                                                <asp:ListItem Value="2">Colegio Misericordia</asp:ListItem>
                                                <asp:ListItem Value="4">Jardín Misericordia</asp:ListItem>
                                                <asp:ListItem Value="3">Escuela San Vicente</asp:ListItem>
                                                <asp:ListItem Value="5">Jardín Padre Victor</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </fieldset>
                                <div class="row">
                                    <div class="form-group col-lg-12" style="background-color: #FFFFFF">
                                        <label class="control-label">Mensaje</label>
                                        <asp:TextBox ID="txtMje" Height="100px" type="text" class="form-control" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <hr class="hr-line-dashed" />

                            </div>
                        </div>

                        <div class="auto-style1">
                            <div class="ibox-content">
                                <div class="form-inline">
                                    <div class="form-group">
                                        <asp:Button ID="btnEnviar" class="btn btn-w-m btn-primary" runat="server" Text="Enviar" Width="100%" OnClick="btnEnviar_Click" />

                                    </div>
                                  
                                </div>
                                <br />

                                <div id="alerMail" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                                    <p>"La Consulta se ha enviado Correctamente al e-mail del Colegio, Listo!!"</p>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </form>
        </article>--%>

        <!-- Footer -->
        <footer id="footer">
            <ul class="icons">
                <%-- <li><a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>--%>
                <li><a href="#" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
                <li><a href="#" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
                <%--     <li><a href="#" class="icon brands fa-dribbble"><span class="label">Dribbble</span></a></li>--%>
                <li><a href="../PaginasBasicas/Contacto.aspx" class="icon solid fa-envelope"><span class="label">Email</span></a></li>

            </ul>
            <div class="copyright">

                <br />

                <a href="Login.aspx">Intranet</a>
            </div>
        </footer>


        <!-- Scripts -->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.scrollex.min.js"></script>
        <script src="../assets/js/jquery.scrolly.min.js"></script>
        <script src="../assets/js/browser.min.js"></script>
        <script src="../assets/js/breakpoints.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <script src="../assets/js/main.js"></script>
    </div>
</body>
</html>
