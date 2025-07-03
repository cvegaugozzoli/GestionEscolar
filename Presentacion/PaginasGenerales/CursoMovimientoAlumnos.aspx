<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CursoMovimientoAlumnos.aspx.cs" Inherits="CursoMovimientoAlumnos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">


    <div class="row">
        <asp:Label runat="server" Text="Sr Usuario: Para corregir un movimiento en esta seccion solo se permite seleccionar un registro por corrección.." Font-Bold="True"></asp:Label>

    </div>
  <br />

    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>


        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-md-6">
            <asp:Label runat="server" Text="Curso Origen" Font-Bold="True" Font-Size="Medium"> </asp:Label>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" Visible="False" Text="Curso Destino" ID="lblCursoD" Font-Bold="True" Font-Size="Medium"> </asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <label class="control-label col-md-2">Nivel</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <label class="control-label col-md-2">Plan</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <label class="control-label col-md-2">Curso</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <label class="control-label col-md-2">Año </label>
                    <div class="col-md-4">
                        <asp:TextBox ID="AnioCursado" type="text" class="form-control" BorderColor="Silver" runat="server" placeholder=""
                            AutoPostBack="false"></asp:TextBox>
                    </div>
                    <hr class="hr-line-dashed" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-sm-1" style="vertical-align: middle" align="center">
        </div>

        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <label runat="server" id="lblCarrera2" class="control-label col-md-2">Carrera/Nivel</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="carId2" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId2_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <label runat="server" id="lblPlanId2" class="control-label col-md-2">Plan</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="plaId2" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId2_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <label runat="server" id="lblcurso2" class="control-label col-md-2">Curso</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="curId2" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <label runat="server" id="lblanio2" class="control-label col-md-2">
                        Año</label><div class="col-md-4">
                            <asp:TextBox ID="AnioCursado2" type="text" class="form-control" BorderColor="Silver" runat="server" placeholder=""
                                AutoPostBack="false"></asp:TextBox>
                        </div>
                    <hr class="hr-line-dashed" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">

        <div class="col-md-6">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAplicar" class="btn btn-w-m btn-warning" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="lblListado" runat="server" Visible="False" Text="Listado | "></asp:Label>
            <asp:Label ID="lblCantidadRegistros" runat="server" Text="" Visible="False"></asp:Label>
        </div>

        <div class="col-sm-1" style="vertical-align: middle" align="center">
        </div>
        <div class="col-md-6">
            <asp:Label ID="lblListado2" runat="server" Visible="False" Text="Listado | "></asp:Label>
            <asp:Label ID="lblCantidadRegistros2" Visible="False" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5">
            <asp:GridView ID="GrillaAlumnos" runat="server" GridLines="None" CssClass="table table-striped"
                AutoGenerateColumns="False" DataKeyNames="Id,Alumno,Dni,aluId,Estado">
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <Columns>

                    <asp:TemplateField HeaderText="Seleccionar" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:RadioButton ID="rbSelector" runat="server" Width="50" OnCheckedChanged="rbSelector_CheckedChanged"
                                AutoPostBack="true" />
                        </ItemTemplate>

                        <FooterStyle HorizontalAlign="Center"></FooterStyle>

                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IC">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" Text='<%# Eval("Alumno") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" Text='<%# Eval("Dni") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="aluId" runat="server" Visible="false" Text='<%# Eval("aluId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="EstadoId" runat="server" Visible="false" Text='<%# Eval("Estado") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Estado" runat="server" Visible="true" Text='<%# Eval("EstadoDesc") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <FooterStyle HorizontalAlign="NotSet" />

                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CCCCFF" />
            </asp:GridView>
            &nbsp;                  
        </div>


        <div class="col-sm-1" style="vertical-align: middle" align="center">
            <br />
            <br />
            <asp:Button ID="btnSeleccionar" runat="server" Text=">>"
                OnClick="btnSeleccionar_Click" />
            <br />
            <br />
        </div>
        <div class="col-md-5">

            <asp:GridView ID="GrillaAlumnos2" runat="server" DataKeyNames="IC,Nombre,DNI,aluId,Estado" GridLines="None" CssClass="table table-striped"
                AutoGenerateColumns="False">
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <Columns>
                    <asp:BoundField DataField="IC" HeaderText="IC" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI" />

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                            <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                OnClick="btnEliminarAceptar_Click" />
                            <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                OnClick="btnEliminarCancelar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="aluId" runat="server" Visible="false" Text='<%# Eval("aluId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Estado" Visible="false" HeaderText="Estado" />
                </Columns>
                <FooterStyle HorizontalAlign="NotSet" />

                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CCCCFF" />
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <%--                <asp:Button ID="btnSeleccionarTodo" class="btn btn-w-m btn-warning" runat="server" Text="Seleccionar Todo" OnClick="btnSeleccionarTodo_Click" />--%>
                <asp:Label ID="lblMensajeError2" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></asp:Label>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Label ID="lblmovimiento" runat="server" Text="" ForeColor="Black" Font-Bold="True">Movimiento:</asp:Label>
                    &nbsp;&nbsp;                 
                        <asp:DropDownList ID="MovimientoId" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="MovimientoId_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccionar..</asp:ListItem>
                            <asp:ListItem Value="2">Promociona</asp:ListItem>
                            <asp:ListItem Value="3">Repite</asp:ListItem>
                            <asp:ListItem Value="5">Cambio de Colegio</asp:ListItem>
                            <asp:ListItem Value="4">Cambio de Curso</asp:ListItem>
                            <asp:ListItem Value="1">Cursando</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="BtnGrabar" class="btn btn-w-m btn-warning" runat="server" Text="Grabar" OnClick="btnGrabar_Click" UseSubmitBehavior="False" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkRadioBtn(id) {
            var gv = document.getElementById('<%=GrillaAlumnos.ClientID %>');

        for (var i = 1; i < gv.rows.length; i++) {
            var radioBtn = gv.rows[i].cells[0].getElementsByTagName("input");

            // Check if the id not same
            if (radioBtn[0].id != id.id) {
                radioBtn[0].checked = false;
            }
        }
    }
    </script>
</asp:Content>
