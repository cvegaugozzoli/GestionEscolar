<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="PerfilMenuRegistracion.aspx.cs" Inherits="PerfilMenuRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

	    <div class="col-sm-12">
		    <div class="ibox-content">
			    <fieldset class="form-horizontal">				   
                    
                        <div class="form-group"><label class="control-label col-md-2"> Perfil</label><div class="col-md-6">
                        <asp:DropDownList ID="perId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Menu</label><div class="col-md-6">
                        <asp:DropDownList ID="menId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Activo</label><div class="col-md-6">
                        <asp:CheckBox ID="pmeActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox></div></div>
                    <hr class="hr-line-dashed" />
                </fieldset>
            </div>
        </div>

        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>