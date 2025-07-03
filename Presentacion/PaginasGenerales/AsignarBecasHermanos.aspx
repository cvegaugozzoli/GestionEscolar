<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="AsignarBecasHermanos.aspx.cs" Inherits="AsignarBecasHermanos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    </div>

    <div class="form-row">
        <div class="form-group col-md-2">
            <label class="control-label">Año Lectivo:</label>
            <asp:TextBox ID="txtAñioLectivo" type="text" class="form-control"
                runat="server"></asp:TextBox>
        </div>

        <div class="form-group col-md-2">
            <label class="control-label">
                Tipo Concepto</label>
            <asp:DropDownList ID="ConTipoId" runat="server" class="form-control m-b">
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-2">
            <label class="control-label">
                Cant. Hermanos</label>
            <asp:DropDownList ID="ddlCantHermanos" runat="server" class="form-control m-b" OnSelectedIndexChanged="ddlCantHermanos_SelectedIndexChanged" AutoPostBack="true">
                  <asp:ListItem>0</asp:ListItem>
                 <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>


    <div class="row">
        <div class="col-sm-10">
            <div class="ibox-title">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" DataKeyNames="aluId, aluNombre, curId" AllowSorting ="true" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False">
                        <Columns>
                            <%--OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging"--%>

                            <asp:TemplateField HeaderText="Seleccionar" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="aluId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="aluId" runat="server" NavigateUrl='<% %>' Text='<%# Eval("aluId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hijo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Hijo" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Hijo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Dni" runat="server" NavigateUrl='<% %>' Text='<%# Eval("aluDni") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre" >
                                <ItemTemplate >
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<% %>' Text='<%# Eval("aluNombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="curId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="curId" runat="server" NavigateUrl='<% %>' Text='<%# Eval("curId") %>' />
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Curso">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" NavigateUrl='<% %>' Text='<%# Eval("Curso") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        &nbsp;<asp:Button ID="btnSeleccionarTodo" class="btn btn-w-m btn-danger" runat="server" Text="Seleccionar Todo"
            OnClick="btnSeleccionarTodo_Click" Visible="false" />
        <br />
        <br />
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label ID="lblBecas" runat="server" class="control-label" Visible="false">
                Becas:<br />
            </asp:Label>
            <asp:RadioButtonList AutoPostBack="true" CssClass="radio radio-info radio-inline" Visible="false" RepeatLayout="Flow" ID="rbtAgregarQuitar" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Font-Italic="False">
                <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="1">Asignar </asp:ListItem>
                <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="0"> Quitar </asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group col-md-3">
            <asp:Label ID="lblPorcentaje" class="control-label" runat="server" Visible="false">
                Porcentaje </asp:Label>
            <asp:DropDownList ID="ddlPorcentaje" Visible="false" runat="server" class="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <br />

    <div class="row">
        <div class="form-group">
            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar"
                OnClick="btnAplicar_Click" Visible="false" />
            &nbsp;<asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
                OnClick="btnCancelar_Click" Visible="false" />

        </div>
    </div>
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMej" runat="server" Text="" Font-Bold="True" ForeColor="#3333CC" Font-Size="Medium"></asp:Label>
            &nbsp;
        </div>
    </div>
</asp:Content>
