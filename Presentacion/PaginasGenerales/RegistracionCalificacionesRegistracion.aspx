<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="RegistracionCalificacionesRegistracion.aspx.cs" Inherits="RegistracionCalificacionesRegistracion" %>

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

                    <%--<div class="form-group">
                        <%--<label class="control-label col-md-2">Inscripcion Cursado</label>--%>
                            <%--<div class="col-md-6">--%>
                            <asp:TextBox ID="icuId" Visible ="false" type ="number" runat="server" class="form-control m-b" Enabled="true"></asp:TextBox>
                        <%--</div>--%>
                    <%--</div>--%>
                    <div class="form-group">
                        <label class="control-label col-md-2">Trabajo Practico</label><div class="col-md-6">
                            <asp:TextBox ID="recTrabajoPractico" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Trabajo Practico Recuperatorio</label><div class="col-md-6">
                            <asp:TextBox ID="recTrabajoPracticoRecuperatorio" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Asistencia</label><div class="col-md-6">
                            <asp:TextBox ID="recAsistencia" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial 1</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcial1" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial 2</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcial2" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial 3</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcial3" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial 4</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcial4" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial Recuperatorio 1</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcialRecuperatorio1" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial Recuperatorio 2</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcialRecuperatorio2" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial Recuperatorio 3</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcialRecuperatorio3" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Calificacion Parcial Recuperatorio 4</label><div class="col-md-6">
                            <asp:TextBox ID="recCalificacionParcialRecuperatorio4" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Fecha Regulariza o Promociona</label><div class="col-md-6">
                            <tpDatePicker:cuFecha ID="recFechaRegularizaPromociona" runat="server" Enabled="true" AllowType="False" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Evaluación Final (Regulariza o Promociona)</label><div class="col-md-6">
                            <asp:TextBox ID="recEvaluacionFinal" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="control-label col-md-2">Condicion Final</label><div class="col-md-6">
                            <asp:DropDownList ID="conId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Observaciones</label><div class="col-md-6">
                            <asp:TextBox ID="recObservaciones" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Activo</label><div class="col-md-6">
                            <asp:CheckBox ID="recActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
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
