<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CursoConsulta.aspx.cs" Inherits="CursoConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <%--<div class="ibox-content">--%>

    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <%--      <div class="col-sm-12">
                <div class="ibox-content">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                        </div>

                    </div>
                </div>
            </div>--%>
    </div>
    <div class="ibox-content">

        <div class="row">
            <div class="form-group col-md-3">
                <label class="control-label ">Nivel</label>
                <asp:DropDownList ID="NivelID" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>

            </div>
            <div class="form-group col-md-3">
                <label class="control-label ">Carrera</label>
                <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>

            </div>
            <div class="form-group col-md-3">
                <label class="control-label ">Plan Estudio</label>
                <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True"></asp:DropDownList>

            </div>

            <%--  </div>
                            <div class="row" runat="server" visible="false">--%>


            <div class="form-group">
                <div class="col-md-4 col-md-offset-0">
                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar"
                        OnClick="btnAplicar_Click" />
                </div>
            </div>
        </div>
        <br />





        <div class="form-group col-md-2" runat="server" visible="false">
            <label class="control-label ">
                Curso a Buscar:</label>
            <asp:TextBox ID="Nombre" BorderColor="Silver" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"
                AutoPostBack="True" OnTextChanged="Nombre_TextChanged"></asp:TextBox>

        </div>



        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
             
                    <div class="ibox-title">
                        <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                            AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                            PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "CursoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "CursoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Nombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PlanEstudio">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" NavigateUrl='<%# "CursoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("PlanEstudio") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="plaiD" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="plaId" runat="server" NavigateUrl='<%# "CursoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("plaId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Activo">
                                    <ItemTemplate>
                                        <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "CursoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Listado" Visible="false">
                                    <%--    <ItemTemplate>

                                    <asp:HyperLink ForeColor="blue" ID="ListadoVer" runat="server" NavigateUrl='<%# "CursoListadoAlumnos.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='Ver' />
                                </ItemTemplate>--%>
                                </asp:TemplateField>
                             <%--   <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                        <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                            OnClick="btnEliminarAceptar_Click" />
                                        <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                            OnClick="btnEliminarCancelar_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <FooterStyle HorizontalAlign="Left" />

                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#CCCCFF" />
                        </asp:GridView>
                   <br /><br />
            </ContentTemplate>


        </asp:UpdatePanel>

      

        <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
            <ContentTemplate>  
                <div class="row">
                    <div class="ibox-title">
                        <h5><a class="collapse-link">Agregar Curso</a></h5>
                        <br />
                    </div>
                </div>
                <div class="row">  <br />
                    <div class="form-group col-md-3">
                        <label class="control-label col-md-2">Nombre</label>

                        <asp:TextBox ID="curNombre"  type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label col-md-2">Sección</label>
                        <asp:TextBox ID="txtSeccion" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label">Activo</label>
                        <asp:CheckBox ID="curActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-2">
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Agregar Curso" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                </div>
            </ContentTemplate>
              <Triggers>
                        <asp:PostBackTrigger ControlID="btnAceptar1"></asp:PostBackTrigger>
                   <asp:PostBackTrigger ControlID="Grilla"></asp:PostBackTrigger>
                    </Triggers>
        </asp:UpdatePanel>

    </div>

</asp:Content>
