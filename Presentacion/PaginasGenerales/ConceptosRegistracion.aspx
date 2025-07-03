<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ConceptosRegistracion.aspx.cs" Inherits="ConceptosRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-sm-12">
        <div class="ibox-content">
            <div class="row">
                <div class="form-group col-md-2">
                    <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <div class="ibox-content">

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label class="control-label ">Instituciones</label>
                    <asp:DropDownList ID="insId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="insId_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label class="control-label">Nivel</label>
                    <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group col-md-4">
                    <label class="control-label ">Conceptos Tipos</label>
                    <asp:DropDownList ID="cntId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label ">Nombre</label>
                        <asp:TextBox ID="conNombre" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label ">Anio Lectivo</label>
                        <asp:TextBox ID="conAnioLectivo" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label ">Importe</label>
                        <asp:TextBox ID="conImporte" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label ">Cant Cuotas</label>
                        <asp:TextBox ID="conCantCuotas" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4">
                        <label class="control-label ">Cant Vtos</label>
                        <asp:TextBox ID="conCantVtos" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label ">Mes Inicio</label>
                        <asp:TextBox ID="conMesInicio" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label">Recargo e Interes será:</label>
                        <asp:RadioButtonList AutoPostBack="true" Enabled="true" runat="server" CssClass="radio radio-info radio-inline" RepeatLayout="Flow" ID="rblValor" Font-Bold="True" Font-Italic="False">
                            <asp:ListItem Text="Monto Fijo" Value="0" />
                            <asp:ListItem Text="Porcentaje" Value="1" />
                        </asp:RadioButtonList>

                    </div>

                    <div class="form-group col-md-4">
                        <label class="control-label ">Recargo Vto Abierto</label>
                        <asp:TextBox ID="conRecargoVtoAbierto" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4">
                        <label class="control-label">Tiene Vto Abierto</label>
                        <asp:CheckBox ID="conTieneVtoAbierto" runat="server" Checked="False" Enabled="true"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label class="control-label ">Notas</label>
                        <asp:TextBox ID="conNotas" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label">Interes Mensual</label>
                        <asp:TextBox ID="conInteresMensual" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label">Activo</label>
                        <asp:CheckBox ID="conActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>
                </div>
                <hr class="hr-line-dashed" />


            </div>
        </div>


        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group col-md-2">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
