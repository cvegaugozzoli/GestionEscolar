<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="EspacioCurricularRegistracion.aspx.cs" Inherits="EspacioCurricularRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-12">
            <div class="ibox-content">
                <fieldset class="form-horizontal">

                    <div class="form-group">
                        <label class="control-label col-md-2">Carrera</label><div class="col-md-6">
                            <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Plan Estudio</label><div class="col-md-6">
                            <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Curso</label><div class="col-md-6">
                            <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Campo</label><div class="col-md-6">
                            <asp:DropDownList ID="camId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Nombre</label><div class="col-md-6">
                            <asp:TextBox ID="escNombre" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Formato Dictado</label><div class="col-md-6">
                            <asp:DropDownList ID="fodId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Regimen</label><div class="col-md-6">
                            <asp:DropDownList ID="regId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Horas Semanales Reloj</label><div class="col-md-6">
                            <asp:TextBox ID="escHorasSemanalesReloj" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Horas Semanales Catedra</label><div class="col-md-6">
                            <asp:TextBox ID="escHorasSemanalesCatedra" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Condicion</label><div class="col-md-6">
                            <asp:DropDownList ID="cdnId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Cantidad Parciales</label><div class="col-md-6">
                            <asp:TextBox ID="escCantidadParciales" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Cantidad Recuperatorios</label><div class="col-md-6">
                            <asp:TextBox ID="escCantidadRecuperatorios" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Activo</label><div class="col-md-6">
                            <asp:CheckBox ID="escActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />
                </fieldset>
            </div>
        </div>

        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
