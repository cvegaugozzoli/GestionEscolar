<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InscripcionActualizar.aspx.cs" Inherits="InscripcionActualizar" %>

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
            width: 100%;
            display: block;
            font-family: Poppins-Regular;
            font-size: 30px;
            color: #333333;
            line-height: 1.2;
            text-align: center;
            padding-bottom: 33px;
            height: 1px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="aluId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblInstId" runat="server" Visible="false"></asp:Label>

        <asp:Label ID="lblicuId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblAfiliacion" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="#293955"></asp:Label>
        <div class="container">
            <nav class="navbar justify-content-end navbar-dark bg-dark">
                <a class="navbar-brand" href="../PaginasBasicas/Index1.aspx">Inicio</a>
                <%--<a class="navbar-brand" href="TurnoRegistracion.aspx">Registrar</a>--%>
            </nav>
        </div>
        <div class="container">
            <span class="contact100-form-title">
                <br />
                Inscripción </span>
            <asp:UpdatePanel ID="UpdatePanelPrinc" runat="server" Visible="true" ForeColor="#333333" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>


                </Triggers>
                <ContentTemplate>
                    <div class="row wrapper border-bottom white-bg page-heading">
                        <span class="auto-style1" style="font-size: small; font-weight: bold">Sr Tutor, para ingresar al link de Inscripción primero debe actualizar o confirmar los datos..</span>
                        <br />
                        <br />
                        <div class="container">
                            <div class="row">
                                <div class="wrap-input100 col-12" style="width: auto">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBuscar" placeholder="DNI DEL ALUMNO" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        &nbsp;      &nbsp; 
                                <div class="form-group ">
                                    <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" formnovalidate
                                        Text="Buscar" OnClick="btnBuscar_Click" />
                                </div>
                                        <div class="form-group ">
                                            &nbsp;&nbsp; &nbsp;                                          
                                          <a><i class="fa fa-user fa-3x"></i></a>&nbsp; 
                                          <asp:TextBox ID="txtNombre" type="text" class="form-control" runat="server" BorderColor="Silver" Enabled="false"></asp:TextBox>
                                            &nbsp; &nbsp;   
                                        </div>
                                        <div class="form-group ">
                                            <label>DNI</label>
                                            &nbsp;      
                                    <asp:TextBox ID="txtDni" type="text" class="form-control" runat="server" BorderColor="Silver" Enabled="false"></asp:TextBox>
                                        </div>
                                        &nbsp;  
                                          <%--  <div class="form-group ">
                                                <label>Nivel</label>
                                                &nbsp; 
                                <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                                            </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="wrap-input100 col-12" style="width: auto">
                            <br></br>
                            <div id="alerDNI" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <h6>"No se encontró DNI ingresado"</h6>
                            </div>
                            <div id="lblMensajeError1" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <h6>No se encuentra el concepto Matricula para ese Año..</h6>
                            </div>

                            <div id="lblMensajeError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <h6>No se registraron los pagos requeridos para realizar la inscripción...</h6>
                            </div>
                            <div id="lblMensajeError3" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <h6>No se registró para el cursado de ese año..</h6>
                            </div>
                            <div id="lblMensajeError5" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <h6>El alumno no se encuentra inscripto en el establecimiento seleccionado.. </h6>
                            </div>
                            <div id="lblMjeErrorCarrera" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <h6>El alumno no pertenece al Nivel Primario.. </h6>
                            </div>
                            <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="#293955"></asp:Label>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true" ForeColor="#333333" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DniPadre" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DniMadre" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DniOtro" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>

                    <asp:AsyncPostBackTrigger ControlID="btnPreincribir" EventName="Click"></asp:AsyncPostBackTrigger>


                </Triggers>
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Visible="false" ForeColor="#333333">
                        <%-- <div class="col-lg-12">
                        <h2>Curso y Turno</h2>
                    </div>--%>
                        <div id="alerInscribir" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <h6>"Sr tutor Ud podrá inscribir a su hijo.. "</h6>
                        </div>
                        <div id="alerInscribir2" visible="false" runat="server" class="alert alert-success   alert-dismissable">
                            <h6>"Sr tutor Ud ya inscribió a su hijo.. solo podrá imprimir comprobante "</h6>
                        </div>
                        <div id="alerSanVicente" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <h3>"Sr tutor Ud podrá pre-inscribir a su hijo en 1° Grado del Colegio San Vicente.."</h3>
                        </div>
                        <div id="alerMisericordia" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <h3>"Sr tutor Ud podrá pre-inscribir a su hijo en 1° Grado del Colegio Misericordia, seleccione el Turno.."</h3>
                        </div>
                        <div id="alerJardin" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                            <h3>"Sr tutor Ud podrá pre-inscribir a su hijo en esta institución, seleccione el Curso y Turno.."</h3>
                        </div>

                        <div id="alerCupo" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                            <h6>"Está cubierto el cupo para ese Curso.."</h6>
                        </div>
                        <div class="wrap-input100 col-12" style="width: auto">


                            <div class="col-lg-12" style="border-width: 1px; border-style: solid; background-color: #FFFFFF">
                                <div class="ibox-content" style="background-color: #FFFFFF">
                                    <div class="row" style="background-color: #FFFFFF">
                                        <div class="col-lg-12">
                                            <br />
                                            <h4>Datos del Alumno para actualizar:</h4>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <br />
                                            <label class="control-label">Domicilio</label>
                                            <asp:TextBox ID="aluDomicilio" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <br />
                                            <label class="control-label">Departamento</label>
                                            <asp:DropDownList ID="DepartamentoId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver"></asp:DropDownList>
                                        </div>

                                        <div class="form-group col-md-3">
                                            <br />
                                            <label class="control-label">Telefono </label>
                                            <asp:TextBox ID="txtTelFijo" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="background-color: #FFFFFF">
                                        <div class="ibox-content" style="background-color: #FFFFFF">
                                            <h4>Datos Familiares</h4>
                                            <p>Debe completar todos campos del Tutor, abajo seleccionado..</p>
                                        </div>

                                        <div class="ibox-content" style="background-color: #FFFFFF">
                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <br />
                                                <label class="control-label col-md-12" style="background-color: #99CCFF; color: #003366;">Papá</label>
                                                <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
                                            </div>
                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <div class="ibox-content" style="background-color: #FFFFFF">

                                                    <div class="form-row" style="background-color: #FFFFFF">
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label">DNI</label>
                                                            <asp:TextBox ID="DniPadre" placeholder="Sin punto" type="text" class="form-control" runat="server" MaxLength="8" ValidationGroup="[0-9]" AutoPostBack="true" BorderColor="Silver" OnTextChanged="DniPadre_TextChanged" onblur="Page_ClientValidate()"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" BackColor="Transparent"
                                                                BorderColor="Red" ControlToValidate="DniPadre" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                                                                Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label">Apellido</label>
                                                            <asp:TextBox ID="ApePadre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label">Nombre</label>
                                                            <asp:TextBox ID="NomPadre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>

                                                        <div class="form-group col-md-2">
                                                            <label class="control-label ">Celular</label>
                                                            <asp:TextBox ID="TelefP" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-row" style="background-color: #FFFFFF">
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label ">Telf. Fijo</label>
                                                            <asp:TextBox ID="txtFijoP" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-3">
                                                            <label class="control-label">CUIL</label>
                                                            <asp:TextBox ID="CuitP" placeholder="Sin espacio, ni guión" MaxLength="11" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" BackColor="Transparent"
                                                                BorderColor="Red" ControlToValidate="CuitP" Display="Dynamic" ErrorMessage="Datos Invalidos.. reingrese."
                                                                Font-Size="Small" ValidationExpression="^[0-9]*$" Width="90px"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="form-group col-md-3">
                                                            <label class="control-label">Ocupación</label>
                                                            <asp:TextBox ID="OcupPadre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label">Mail</label>
                                                            <asp:TextBox ID="MailP" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-3">
                                                            <label class="control-label col-md-1" runat="server" visible="false">Usuario</label>
                                                            <asp:TextBox ID="UsuarioP" type="text" class="form-control" Visible="false" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <br />
                                                <label class="control-label col-md-12" style="background-color: #99CCFF; color: #003366;">Mamá</label>
                                                <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
                                            </div>
                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <div class="ibox-content" style="background-color: #FFFFFF">
                                                    <div class="form-row" style="background-color: #FFFFFF">
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label">DNI</label>
                                                            <asp:TextBox ID="DniMadre" placeholder="Sin punto" MaxLength="8" ValidationGroup="[0-9]" AutoPostBack="true" type="text" class="form-control" runat="server" BorderColor="Silver" OnTextChanged="DniMadre_TextChanged" onblur="Page_ClientValidate()"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" BackColor="Transparent"
                                                                BorderColor="Red" ControlToValidate="DniMadre" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                                                                Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label">Apellido</label>
                                                            <asp:TextBox ID="ApeMadre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label">Nombre</label>
                                                            <asp:TextBox ID="NomMadre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label">Celular</label>
                                                            <asp:TextBox ID="TelefM" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>

                                                        <div class="form-row" style="background-color: #FFFFFF">
                                                            <div class="form-group col-md-2">
                                                                <label class="control-label ">Telf. Fijo</label>
                                                                <asp:TextBox ID="txtFijoM" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-3">

                                                                <label class="control-label">CUIL</label>
                                                                <asp:TextBox ID="CuitM" placeholder="Sin espacio, ni guión" MaxLength="11" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" BackColor="Transparent"
                                                                    BorderColor="Red" ControlToValidate="CuitM" Display="Dynamic" ErrorMessage="Datos Invalidos.. reingrese."
                                                                    Font-Size="Small" ValidationExpression="^[0-9]*$" Width="90px"></asp:RegularExpressionValidator>
                                                            </div>

                                                            <div class="form-group col-md-3">
                                                                <label class="control-label">Ocupación</label>
                                                                <asp:TextBox ID="OcupMadre" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <label class="control-label">Mail</label>
                                                                <asp:TextBox ID="MailM" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>

                                                            <div class="form-group col-md-3">
                                                                <label runat="server" class="control-label col-md-1" visible="false">Usuario</label>
                                                                <asp:TextBox ID="UsuarioM" type="text" Visible="false" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <br />
                                                <label class="control-label col-md-12" style="background-color: #99CCFF; color: #003366;">Otro</label>
                                                <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
                                            </div>
                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <div class="ibox-content" style="background-color: #FFFFFF">
                                                    <div class="form-row" style="background-color: #FFFFFF">
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label col-md-1">DNI</label>
                                                            <asp:TextBox ID="DniOtro" placeholder="Sin punto" AutoPostBack="true" MaxLength="8" ValidationGroup="[0-9]" type="text" class="form-control" runat="server" BorderColor="Silver" OnTextChanged="DniOtro_TextChanged" onblur="Page_ClientValidate()"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" BackColor="Transparent"
                                                                BorderColor="Red" ControlToValidate="DniOtro" Display="Dynamic" ErrorMessage="Dato Inválido.. reingrese."
                                                                Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label">Apellido</label>
                                                            <asp:TextBox ID="ApeOtro" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label class="control-label col-md-1">Nombre</label>
                                                            <asp:TextBox ID="NombOtro" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label ">Parentesco</label>
                                                            <asp:DropDownList ID="ParentescoId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" AutoPostBack="True" AppendDataBoundItems="true">
                                                            </asp:DropDownList>
                                                        </div>

                                                        <%--  <div class="form-group col-md-2">
                                                    <label class="control-label">Parentesco</label>
                                                    <asp:DropDownList BorderColor="Silver" AutoPostBack="true" ID="ParentescoId" runat="server" class="form-control m-b" Enabled="true">

                                                        <asp:ListItem Value="3">Abuelo</asp:ListItem>
                                                        <asp:ListItem Value="4">Abuela</asp:ListItem>
                                                        <asp:ListItem Value="5">Tío</asp:ListItem>
                                                        <asp:ListItem Value="6">Tía</asp:ListItem>
                                                        <asp:ListItem Value="7">Hermano/a</asp:ListItem>
                                                        <asp:ListItem Value="8">Otro</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>--%>
                                                    </div>
                                                    <div class="form-row" style="background-color: #FFFFFF">
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label">Ocupación</label>
                                                            <asp:TextBox ID="OcupOtro" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>

                                                        </div>
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label">Celular</label>
                                                            <asp:TextBox ID="TelefO" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label">Telf. Fijo</label>
                                                            <asp:TextBox ID="txtFijoO" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-3">
                                                            <label class="control-label">CUIL</label>
                                                            <asp:TextBox ID="CuitO" placeholder="Sin espacio, ni guión" MaxLength="11" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>

                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" BackColor="Transparent"
                                                                BorderColor="Red" ControlToValidate="CuitO" Display="Dynamic" ErrorMessage="Datos Invalidos.. reingrese."
                                                                Font-Size="Small" ValidationExpression="^[0-9]*$" Width="90px"></asp:RegularExpressionValidator>
                                                        </div>

                                                        <div class="form-group col-md-3">
                                                            <label class="control-label col-md-1">Mail</label>
                                                            <asp:TextBox ID="MailO" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-2">
                                                            <label class="control-label" runat="server" visible="false">Usuario</label>
                                                            <asp:TextBox ID="UsuarioO" type="text" Visible="false" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-12" style="background-color: #FFFFFF">
                                                <br />
                                                <label class="control-label col-md-12">Seleccionar Tutor:</label>
                                                <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
                                            </div>

                                            <asp:RadioButtonList ID="EsTutor" runat="server" CssClass="radio radio-info radio-inline">
                                                <asp:ListItem Selected="True" Value="0">&nbsp;&nbsp;Mamá</asp:ListItem>
                                                <asp:ListItem Value="1"> &nbsp;&nbsp;Papá</asp:ListItem>
                                                <asp:ListItem Value="2">&nbsp;&nbsp;Otro</asp:ListItem>
                                            </asp:RadioButtonList>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                    </asp:Panel>

                    <asp:Panel ID="PanelDeclaracion" runat="server" Visible="false" ForeColor="#333333">
                        <div class="wrap-input100 col-12" style="width: auto">
                            <div class="col-lg-12" style="border-width: 1px; border-style: solid; background-color: #FFFFFF">

                                <div class="row" style="background-color: #FFFFFF">
                                    <div class="col-lg-12">
                                        <br />
                                        <h4>DECLARACIÓN JURADA DE SALUD</h4>
                                    </div>
                                </div>
                                <br />
                                <div class="form-row">
                                    <div class="form-group col-md-3">
                                        <br />
                                        <label class="control-label">Grupo Sanguineo</label>
                                        <asp:DropDownList ID="GrupoSangId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <br />
                                        <label class="control-label">Telef. Urgencia</label>
                                        <asp:TextBox ID="txtTelefUrg" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <br />
                                        <label class="control-label">Domicilio Familiar </label>
                                        <asp:TextBox ID="txtDomFam" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row" style="background-color: #FFFFFF">
                                    <div class="col-lg-12">
                                        <h4>Observaciones Especiales</h4>
                                        <br />
                                    </div>
                                </div>

                                <div class="form-row">
                                    <label class="control-label">- Enfermedades y/o dolencias recientes (en los últimos 12 meses) Informar si continúa tratamiento </label>
                                    <asp:TextBox ID="TextPreg1" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    <label class="control-label">- Padece enfermedades y/o dolencias crónicas (informar si continúa tratamiento médico)</label>
                                    <asp:TextBox ID="TextPreg2" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    <label class="control-label">Alergias, sensibilidades y efectos contraproducentes por algún medicamento/alimento</label>
                                    <asp:TextBox ID="TextPreg3" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    <label class="control-label">- Alergias, sensibilidades y efectos contraproducentes por algún agente natural (insectos, luz solar, tierra/polvillo, polen, etc)</label>
                                    <asp:TextBox ID="TextPreg4" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    <label class="control-label">- Diagnósticos y/u observaciones de tipo neurológicas/psicológicas/psicomotrices (Informar si está bajo tratamiento y adjuntar certificado médico)</label>
                                    <asp:TextBox ID="TextPreg5" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    <label class="control-label">- Lesiones y/o traumatismos óseos que impidan realizar actividad física/deportiva/esparcimiento (informar si está bajo tratamiento y adjuntar certificado médico)</label>
                                    <asp:TextBox ID="TextPreg6" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    <label class="control-label">- En caso de existir alguna de las observaciones anteriores, informar quién es el profesional médico de cabecera.</label>
                                    <asp:TextBox ID="TextPreg7" required="" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <br />

                                <div class="form-row">
                                    <label class="control-label" style="font-weight: bold">
                                        Los padres o tutores DECLARAN BAJO JURAMENTO:<br />
                                    </label>
                                    <br />
                                </div>
                                <div class="form-row">
                                    <p>1.- Que la información de salud arriba consignada, es correcta y completa.</p>

                                    <p>
                                        2.- Que autoriza a su hijo a realizar actividad física en las asignaturas y proyectos que lo requieran, y a desplazarse en el
edificio y predio escolar conforme a la estructura y exigencias edilicias y espaciales existentes.
                                    </p>
                                    <p>
                                        3.- Que autoriza, en caso de necesidad, a que su hijo/a sea atendido por el Servicio de Emergencia Médica contratado por la
Institución, dejando constancia de contraindicaciones a determinados medicamentos.
                                    </p>
                                    <p>
                                        4.- En caso de presentarse enfermedades, trastornos, intervenciones, incapacidades o tratamientos posteriores a la
presentación de esta D.D.J.J., comunicará inmediatamente a la institución dicha novedad, acompañando con certificados
médicos o historias clínicas que correspondan.
                                    </p>
                                </div>
                                <br />
                                <div class="form-row">
                                    <label class="control-label">- Aclaraciones respecto a los ítems 1, 2, 3 y 4</label>
                                    <asp:TextBox ID="txtAclara" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                                </div>
                                <br />
                            </div>
                            <br />
                        </div>
                    </asp:Panel>
                    <br />
                    <div class="row">
                        <div class="ibox-content" style="background-color: #FFFFFF">
                            <asp:Label ID="lblMje3" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="#293955"></asp:Label>
                        </div>
                    </div>

                    <div id="alertExito" visible="true" runat="server" class="alert alert-primary  alert-dismissable">
                        <h6>"Los Datos fueron grabados correctamente.."</h6>
                    </div>
                    <div id="alertExito3" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                        <h6>"Se actualizaron Datos.. "</h6>
                    </div>

                    <br />
                    <div class="ibox-content" style="background-color: #FFFFFF">
                        <div class="row">

                            <div class="form-group col-2">
                                <asp:Button ID="btnPreincribir" class="btn btn-w-m btn-primary" Visible="false" runat="server" Text="Confirmar Datos" OnClick="btnPreinscribir_Click" />
                            </div>
                            <div class="form-group col-2">
                                <asp:Button ID="btnImprimir" formnovalidate class="btn btn-w-m btn-primary" Visible="false" runat="server" Text="Constancia" OnClick="btnImprimir_Click" />
                            </div>
                            <div class="form-group">
                                <%--<asp:Button ID="btnVolver" formnovalidate Visible="false" class="btn btn-w-m btn-warning" runat="server" Text="Preincripción Nueva" OnClick="btnVolver_Click" />--%>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnFinalizar" formnovalidate Visible="false" class="btn btn-w-m btn-warning" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click" />
                            </div>

                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--   <asp:AsyncPostBackTrigger ControlID="btnPreincribir"
                        EventName="Click" />--%>

                    <asp:AsyncPostBackTrigger ControlID="DniPadre" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="DniMadre" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="DniOtro" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="btnPreincribir" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>

        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />



        <%--</asp:Content>--%>








        <!-- Footer -->
        <footer id="footer">
            <ul class="icons">
                <%-- <li><a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>
                <li><a href="#" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
                <li><a href="#" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
                <li><a href="#" class="icon brands fa-dribbble"><span class="label">Dribbble</span></a></li>
                <li><a href="#" class="icon solid fa-envelope"><span class="label">Email</span></a></li>--%>
            </ul>
            <ul class="copyright">

                <%--	<li> </li><li> <a href="Login.aspx" ">Intranet</a></li>--%>
            </ul>
        </footer>




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
    </form>
</body>

</html>
