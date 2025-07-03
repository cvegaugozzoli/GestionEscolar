<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="PlanillaCalificacioneSec.aspx.cs" Inherits="PlanillaCalificacioneSec" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
 <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMensajeError2" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-12">
            <%-- <div class="ibox collapsed">
                <div class="ibox-title">
                    <h5><a class="collapse-link">Filtros</a></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>--%>

            <div class="ibox-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset class="form-horizontal">
                            <div class="form-group">
                                <label class="control-label col-md-1">Carrera</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <label class="control-label col-md-2">Plan Estudio</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <%-- <label class="control-label col-md-1">Campo</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="camId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true"></asp:DropDownList>
                                    </div>--%>
                                <label class="control-label col-md-1">Curso</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-2">
                                        Año de Cursado</label><div class="col-md-2">
                                            <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                                AutoPostBack="false" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                                        </div>
                                </div>
                                <div class="form-group">


                                    <label id="Label1" runat="server" class="control-label col-md-1">Periodo:</label>

                                    <div class="col-md-2">
                                        <asp:DropDownList ID="PeriodoId" requeried="" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" OnSelectedIndexChanged="PeriodoId_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Primer Cuat.</asp:ListItem>
                                            <asp:ListItem Value="1">Segundo Cuatr.</asp:ListItem>
                                            <asp:ListItem Value="2">Prom. Anual</asp:ListItem>
                                            <asp:ListItem Value="3">Nota Dic.</asp:ListItem>
                                            <asp:ListItem Value="4">Nota Mar.</asp:ListItem>
                                            <asp:ListItem Value="5">Calif. Definitiva</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="7" Enabled="False">Seleccionar..</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-4 col-md-offset-0">
                                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                                        </div>
                                    </div>

                                </div>
                                <hr class="hr-line-dashed" />
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <fieldset class="form-horizontal">
                </fieldset>
            </div>
        </div>   
    </div>


    <div class="row">
        <div class="col-sm-12">

            <div id="dvGrid" style="padding: 10px; width:550px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-striped" AutoGenerateColumns="true" OnRowDataBound="OnRowDataBound"
                           PageSize="50" AllowPaging="true" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating"
                             BorderColor="#3399FF" HorizontalAlign="Center">
<%--                            <Columns>

                                <asp:TemplateField HeaderText="Alumno" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlumno" runat="server" Text='<%# Eval("aluNombre") %>' Width="150"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Matemáticas" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMatematica" runat="server" Text='<%# Eval("Matemáticas") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMatematicas" runat="server" Text='<%# Eval("[Matemáticas]") %>' Width="100"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lengua" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLengua" runat="server" Text='<%# Eval("Lengua") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLengua" runat="server" Text='<%# Eval("Lengua") %>' Width="90"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cs.Sociales" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSociales" runat="server" Text='<%# Eval("CsSociales") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSociales" runat="server" Text='<%# Eval("CsSociales") %>' Width="150"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cs.Naturales" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="CsNaturales" runat="server" Text='<%# Eval("CsNaturales") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNaturales" runat="server" Text='<%# Eval("CsNaturales") %>' Width="90"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Conducta" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblConducta" runat="server" Text='<%# Eval("Conducta") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtConducta" runat="server" Text='<%# Eval("Conducta") %>' Width="90"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inasistencia" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInasistencia" runat="server" Text='<%# Eval("Inasistencia") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtInasistencia" runat="server" Text='<%# Eval("Inasistencia") %>' Width="90"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                </asp:TemplateField>
                                                             

                             
                            </Columns>--%>
                            <HeaderStyle BackColor="#ffcccc" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:GridView>
                        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <br />
            <br />
            <br />
        </div>
                 <div class="form-group">
<%--                    <asp:Button ID="btn_Imprimir" class="btn btn-w-m btn-warning" runat="server" Text="Imprimir" OnClick="btnImprimir"  />--%>
                </div>

        <div class="col-sm-12">
        </div>
    </div>
</asp:Content>
