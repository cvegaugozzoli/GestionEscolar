<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="RegistracionCalificacionesConsulta.aspx.cs" Inherits="RegistracionCalificacionesConsulta" %>

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

                    <div class="form-group">
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    

    <div class="row">
	    <div class="col-sm-12">
            <div class="ibox-title"><h5>Listado | <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5></div>
            <asp:TextBox ID="icuId" Visible ="false" type ="number" runat="server" class="form-control m-b" Enabled="true"></asp:TextBox>
		    <div class="ibox-content">
                <div class="table-responsive"><asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
	                AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
	                PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
	                <Columns>
		                
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdIC">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="InscripcionCursado" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("InscripcionCursado") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TrabajoPractico">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="TrabajoPractico" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("TrabajoPractico") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TrabajoPracticoRecuperatorio">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="TrabajoPracticoRecuperatorio" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("TrabajoPracticoRecuperatorio") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asistencia">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Asistencia" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Asistencia") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcial1">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcial1" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcial1") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcial2">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcial2" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcial2") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcial3">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcial3" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcial3") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcial4">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcial4" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcial4") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcialRecuperatorio1">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcialRecuperatorio1" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcialRecuperatorio1") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcialRecuperatorio2">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcialRecuperatorio2" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcialRecuperatorio2") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcialRecuperatorio3">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcialRecuperatorio3" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcialRecuperatorio3") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CalificacionParcialRecuperatorio4">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="CalificacionParcialRecuperatorio4" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("CalificacionParcialRecuperatorio4") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Condicion">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Condicion" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Condicion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observaciones">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Observaciones" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Observaciones") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "RegistracionCalificacionesRegistracion.aspx?IdIC="+icuId.Text+"&Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
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