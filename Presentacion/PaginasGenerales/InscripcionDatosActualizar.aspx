<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InscripcionDatosActualizar.aspx.cs" Inherits="InscripcionDatosActualizar" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>      

        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-row" style="background-color: #FFFFFF">
                    <div class="form-group col-md-3">
                        <label class="control-label">Año de Inscripción</label>
                        <asp:TextBox ID="txtAnio" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Cuotas del Año Anterior</label>
                        <asp:TextBox ID="txtCantCuotas" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Cuota del antepenúltimo Año</label>
                        <asp:TextBox ID="txtCantAnteriores" type="text" class="form-control" runat="server" BorderColor="Silver"></asp:TextBox>
                    </div>
                    <hr class="hr-line-dashed" />

                </div>
            </div>
            <div class="col-sm-12">
                <div class="ibox-content">
                    <div class="form-inline">
                        <div class="form-group">
                            <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                                <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </div>
                            <div id="alerExito" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
                                <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </div>
                        </div>
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
