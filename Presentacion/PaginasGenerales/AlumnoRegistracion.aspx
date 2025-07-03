<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AlumnoRegistracion.aspx.cs" Inherits="AlumnoRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                 <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" 
    Text="Aceptar" OnClick="btnAceptar_Click" Width="100%"  />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelar" formnovalidate="formnovalidate " class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />

                </div>
            </div>
            <div class="form-group" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 20px; color: #000066">

                <asp:Label ID="LblMensaje2" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <br />
        <label class="control-label col-md-10">Datos Personales del Alumno</label>
        <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-2">

                    <label class="control-label">DNI</label>
                    <asp:TextBox ID="aluDoc" placeholder="Sin punto" MaxLength="8" ValidationGroup="[0-9]" AutoPostBack="true" required type="text" class="form-control" runat="server" BorderColor="Silver" Enabled="true" OnTextChanged="aluDoc_textChanged" onblur="Page_ClientValidate()"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" BackColor="Transparent"
                        BorderColor="Red" ControlToValidate="aluDoc" Display="Dynamic" ErrorMessage="Dato Inválido.."
                        Font-Size="Small" ValidationExpression="[0-9]{6,}" Width="90px"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-6">
                    <label class="control-label">Apellido y Nombre</label>

                    <asp:TextBox ID="aluNombre" type="text" class="form-control" runat="server" BorderColor="Silver" AutoPostBack="true" OnTextChanged="aluNombre_textChanged"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label class="control-label ">CUIT</label>
                    <asp:TextBox ID="aluCuit" type="text" placeholder="Sin espacio, ni guión" MaxLength="11" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" BackColor="Transparent"
                        BorderColor="Red" ControlToValidate="aluCuit" Display="Dynamic" ErrorMessage="Datos Invalidos.. reingrese."
                        Font-Size="Small" ValidationExpression="^[0-9]*$" Width="90px"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-2">
                    <label class="control-label">Legajo</label>
                    <asp:TextBox ID="aluLegajoNumero" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label class="control-label">Domicilio</label>
                    <asp:TextBox ID="aluDomicilio" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <label class="control-label">Departamento</label>
                    <asp:DropDownList ID="DepartamentoId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver"></asp:DropDownList>

                </div>

                <div class="form-group col-md-2">
                    <label class="control-label ">Fecha Nac.</label>
                    <tpDatePicker:cuFecha ID="aluFechaNacimiento" runat="server" Enabled="true" AllowType="False" BorderColor="Silver" />
                </div>
            </div>


            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-3">
                    <label class="control-label">País de Nac.</label>
                    <asp:DropDownList ID="paisId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" OnSelectedIndexChanged="paisId_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
                </div>


                <div class="form-group col-md-3">
                    <label class="control-label ">Provincia de Nac.</label>
                    <asp:DropDownList ID="provinciaId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" OnSelectedIndexChanged="provinciaId_SelectedIndexChanged1" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>

                </div>


                <div class="form-group col-md-3">
                    <label class="control-label ">Depto de Nac.</label>
                    <asp:DropDownList ID="DepartamentoNac" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" OnSelectedIndexChanged="DepartamentoNac_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Localidad de Nac.</label>
                    <asp:DropDownList ID="LocalidadId" runat="server" class="form-control m-b" BorderColor="Silver" Enabled="true"></asp:DropDownList>
                </div>
            </div>
            <div class="form-row" style="background-color: #FFFFFF">

                <div class="form-group col-md-2">
                    <label class="control-label">Sexo</label>
                    <asp:DropDownList ID="sexId" BorderColor="Silver" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>

                <div class="form-group col-md-4">
                    <label class="control-label">Mail</label>
                    <asp:TextBox ID="aluMail" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" BackColor="Transparent"
                        BorderColor="Red" ControlToValidate="aluMail" Display="Dynamic" ErrorMessage="Formato Incorrecto.. reingrese."
                        Font-Size="Small" ValidationExpression="^[a-zA-Z0-9_\-\.~]{2,}@[a-zA-Z0-9_\-\.~]{2,}\.[a-zA-Z]{2,4}$" Width="90px"></asp:RegularExpressionValidator>

                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Telefono Part.</label>
                    <asp:TextBox ID="aluTelefono" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label ">Celular</label>
                    <asp:TextBox ID="aluTelCel" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label ">Activo</label>
                    <asp:CheckBox ID="aluActivo" runat="server" Checked="True" Enabled="true" BorderColor="Silver"></asp:CheckBox>
                </div>

            </div>
        </div>
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <br />
        <label class="control-label col-md-12">Datos Familiares</label>
        <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <br />
        <label class="control-label col-md-12">Padre</label>
        <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">

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
                    <label class="control-label">Cuit</label>
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
        <label class="control-label col-md-12">Madre</label>
        <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-2">
                    <label class="control-label">DNI</label>
                    <asp:TextBox ID="DniMadre" MaxLength="8" ValidationGroup="[0-9]" AutoPostBack="true" type="text" class="form-control" runat="server" BorderColor="Silver" OnTextChanged="DniMadre_TextChanged" onblur="Page_ClientValidate()"></asp:TextBox>
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

                        <label class="control-label">Cuit</label>
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
        <label class="control-label col-md-12">Otro</label>
        <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-row" style="background-color: #FFFFFF">
                <div class="form-group col-md-2">
                    <label class="control-label col-md-1">DNI</label>
                    <asp:TextBox ID="DniOtro" MaxLength="8" ValidationGroup="[0-9]" type="text" AutoPostBack="true" class="form-control" runat="server" BorderColor="Silver" OnTextChanged="DniOtro_TextChanged" onblur="Page_ClientValidate()"></asp:TextBox>
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

<%--                <div class="form-group col-md-2">
                    <label class="control-label">Parentesco</label>
                    <asp:DropDownList BorderColor="Silver" ID="ParentescoId" runat="server" class="form-control m-b" Enabled="true">

                        <asp:ListItem Value="3">Abuelo</asp:ListItem>
                        <asp:ListItem Value="4">Abuela</asp:ListItem>
                        <asp:ListItem Value="5">Tío</asp:ListItem>
                        <asp:ListItem Value="6">Tía</asp:ListItem>
                        <asp:ListItem Value="7">Hermano/a</asp:ListItem>
                        <asp:ListItem Value="8">Otro</asp:ListItem>
                    </asp:DropDownList>
                </div>--%>


                <div class="form-group col-md-2">
                    <label class="control-label ">Parentesco</label>
                    <asp:DropDownList ID="ParentescoId" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" AutoPostBack="True" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </div>




                
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
                    <label class="control-label">Cuit</label>
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
        <label class="control-label col-md-12">Datos Tutor</label>
        <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX" />
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:RadioButtonList ID="EsTutor" runat="server" Height="25px" RepeatDirection="Horizontal" Width="398px">
                        <asp:ListItem Selected="True" Value="0">Madre</asp:ListItem>
                        <asp:ListItem Value="1"> Padre</asp:ListItem>
                        <asp:ListItem Value="2">Otro</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
    </div>
    <hr class="hr-line-dashed" />
    <br/>
         <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
            <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"   ></asp:Label>
        </div>
     <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"   ></asp:Label>
        </div>

    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" formnovalidate="formnovalidate " OnClick="btnCancelar_Click" Width="100%" />
                </div>
                   <div class="form-group">
                    <asp:Button ID="btnLimpiarAlumno" class="btn btn-w-m btn-info" runat="server" Text="Limpiar Datos" formnovalidate="formnovalidate " OnClick="btnLimpiarAlumno_Click" Width="100%" BackColor="#003366" />
                </div>

                <div class="form-group">
                    <asp:Button ID="BtnImprimir" class="btn btn-w-m btn-danger" runat="server" Text="Imprimir" formnovalidate="formnovalidate " OnClick="BtnImprimir_Click" Width="100%" />
                </div>
            </div>
            <div class="form-group" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 20px; color: #000066">
                <br />
                <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
            </div>

         
        </div>
    </div>
</asp:Content>

