<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InscripcionConceptoConsulta.aspx.cs" Inherits="InscripcionConceptoConsulta" %>

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
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    

    <div class="row">
	    <div class="col-sm-12">
            <div class="ibox-title"><h5>Listado | <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5></div>
		    <div class="ibox-content">
                <div class="table-responsive"><asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
	                AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
	                PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
	                <Columns>
		                
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="InscripcionCursado">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="InscripcionCursado" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("InscripcionCursado") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conceptos">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Conceptos" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Conceptos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Importe">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Importe" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Importe") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FechaInscripcion">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="FechaInscripcion" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("FechaInscripcion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NroCuota">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="NroCuota" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("NroCuota") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Becas">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Becas" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Becas") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "InscripcionConceptoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
		                <asp:TemplateField HeaderText="">
			                <ItemTemplate>
				                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
				                <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
					                OnClick="btnEliminarAceptar_Click" />
				                <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
					                OnClick="btnEliminarCancelar_Click" />
			                </ItemTemplate>
		                </asp:TemplateField>
	                </Columns>
	                <FooterStyle HorizontalAlign="Left" />
	                <HeaderStyle HorizontalAlign="Left" />
	                <PagerSettings Position="Top" />
	                <PagerStyle HorizontalAlign="Left" />
                </asp:GridView></div>
		    </div>
	    </div>
    </div>
</asp:Content>