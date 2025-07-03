<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="EvaluacionesEspCRegistracion.aspx.cs" Inherits="EvaluacionesEspCRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <%--        <div class="col-sm-12">
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
        </div>--%>

        <div class="col-sm-12">
            <div class="ibox-content">

                <div class="row">
                    <div class="form-group col-md-3">
                        <label class="control-label ">Espacio Curricular</label>
                        <asp:DropDownList ID="escId"  runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="FALSE" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label">Tipo Evaluacion</label>
                        <asp:DropDownList BorderColor="Silver" ID="TipoEvalId" runat="server" class="form-control m-b" Enabled="true">
                        </asp:DropDownList>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label ">Nombre</label>
                        <asp:TextBox ID="eceNombre" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label ">Orden</label>
                        <asp:TextBox ID="eceDescripcion" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">

                    <div class="form-group col-md-3">
                        <label class="control-label">Activo</label><div class="col-md-6">
                            <asp:CheckBox ID="eceActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />
                </div>
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
