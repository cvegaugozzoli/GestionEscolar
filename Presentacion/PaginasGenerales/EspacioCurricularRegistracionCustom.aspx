<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="EspacioCurricularRegistracionCustom.aspx.cs" Inherits="EspacioCurricularRegistracionCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

     <%--   <div class="col-sm-12">
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

        <div class="ibox-content">
            <div class="row">

                <div class="form-group col-md-3">
                    <label class="control-label ">Nivel</label>
                    <asp:DropDownList ID="NivelID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label class="control-label">Carrera</label>
                    <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group col-md-3">
                    <label class="control-label">Plan Estudio</label>
                    <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group col-md-3">
                    <label class="control-label ">Curso</label>
                    <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                </div>

            </div>
            <div class="row">

                <div class="form-group col-md-3">
                    <label class="control-label col-md-2">Campo</label>
                    <asp:DropDownList ID="camId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label class="control-label">Nombre</label>
                    <asp:TextBox ID="escNombre" type="text" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label ">Formato Dictado</label>
                    <asp:DropDownList ID="fodId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="true"  OnSelectedIndexChanged="fodId_SelectedIndexChanged1"></asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label">Regimen</label>
                    <asp:DropDownList ID="regId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>
                </div>

                <div class="form-group col-md-2">
                    <label class="control-label ">Horas Semanales Reloj</label>
                    <asp:TextBox ID="escHorasSemanalesReloj" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label class="control-label ">Horas Semanales Cat.</label>
                    <asp:TextBox ID="escHorasSemanalesCatedra" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                </div>

              <%--  <div class="form-group col-md-2">
                    <label class="control-label">Taller Inicial</label>
                    <asp:CheckBox ID="TInicial" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                </div>
           --%>

           
                <div class="form-group col-md-2">
                    <label class="control-label">Promociona</label>
                    <asp:CheckBox ID="escPromociona" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                </div>

                <div class="form-group col-md-2">
                    <label class="control-label">Activo</label>
                    <asp:CheckBox ID="escActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                </div>
          

            <hr class="hr-line-dashed" />

        </div>
    </div>
           <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
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
