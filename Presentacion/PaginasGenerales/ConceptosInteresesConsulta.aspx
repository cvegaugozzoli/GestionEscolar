<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ConceptosInteresesConsulta.aspx.cs" Inherits="ConceptosInteresesConsulta" %>

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
        <div class="ibox collapsed">
            <div class="ibox-title">
                <h5><a class="collapse-link">Filtros</a></h5>
                <div class="ibox-tools">
                    <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                </div>
            </div>
            <div class="col-sm-12" style="background-color: #FFFFFF">
                <div class="ibox-content">
                    <div class="form-row" style="background-color: #FFFFFF">
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" class="control-label ">Nombre:</asp:Label>
                            <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"
                               ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <asp:Label runat="server" class="control-label ">Año: </asp:Label>
                            <asp:TextBox ID="txtAnio" type="text" class="form-control" runat="server" placeholder="Buscar por Año"
                                ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 ">
                             <asp:Label runat="server" class="control-label "><br /> </asp:Label>
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                                OnClick="btnAplicar_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
	    <div class="col-sm-12">
            <%--<div class="ibox-title"><h5>Listado | <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5></div>--%>
		    <div class="ibox-content">
                <div class="table-responsive"><asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
	                AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
	                PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
	                 <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
		                
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conceptos">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Conceptos" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Conceptos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NroCuota">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="NroCuota" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("NroCuota") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FechaVto">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="FechaVto" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("FechaVto") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ValorInteres">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="ValorInteres" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("ValorInteres") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AplicaBeca">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="AplicaBeca" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("AplicaBeca") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "ConceptosInteresesRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
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
	                <PagerStyle HorizontalAlign="center" />
                </asp:GridView></div>
		    </div>
	    </div>
    </div>
</asp:Content>