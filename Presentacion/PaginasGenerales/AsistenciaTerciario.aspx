<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AsistenciaTerciario.aspx.cs" Inherits="AsistenciaTerciario" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>
        </div>

        <%-- <div class="ibox collapsed">
                
                </div>--%>
        <div class="ibox-title">
            <h5><a class="collapse-link">Filtros</a></h5>
            <div class="ibox-tools">
                <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
            </div>
        </div>
        <div class="ibox-content">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <label class="control-label">Carrera</label>
                            <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4">
                            <label class="control-label">Plan Estudio</label>
                            <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4">
                            <label class="control-label">Curso</label>
                            <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <label class="control-label ">Espacio Curricular</label>

                            <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-2">
                            <label class="control-label">Año de Cursado</label>
                            <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                AutoPostBack="false"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label id="lblPeriodo" runat="server" class="control-label" visible="true">Cantidad de Clases</label>
                            <asp:TextBox ID="cantClases" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder=""></asp:TextBox>
                        </div>


                    </div>
                     <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <fieldset class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-4 col-md-offset-0">
                        <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                    </div>
                </div>
            </fieldset>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-7">

                            <div id="dvGrid">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" GridLines="None" AutoGenerateColumns="false"
                                                BorderColor="#3399FF" DataKeyNames="Id,cdnId,Alumno,Asistencia" HorizontalAlign="Center" CssClass="table table-responsive table-striped" runat="server">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="renId" Visible="false" ItemStyle-Width="150">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrenId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="cdnId" Visible="false" ItemStyle-Width="150">
                                                        <ItemTemplate>
                                                            <asp:Label ID="cdnId" runat="server" Text='<%# Eval("cdnId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Alumno" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAlumno" runat="server" Text='<%# Eval("Alumno") %>' Width="300"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="300px" />
                                                        <ItemStyle Font-Bold="True" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Total Ausencias">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTAsistencia" runat="server" Width="90px" MaxLength="3" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="120px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText=" Asistencia %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAsistencia" runat="server" Text='<%# Eval("Asistencia") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                                    </asp:TemplateField>
                                                    <%--  <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowCancelButton="false" />
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="100px" />
                                                        <EditItemTemplate>
                                                            <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                                                        </EditItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                                <HeaderStyle BackColor="#ffcccc" HorizontalAlign="Center" VerticalAlign="Middle" />

                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="gridview1" />
                </Triggers>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-2">

                            <asp:Button ID="BtnCAlcular" class="btn btn-w-m btn-primary" runat="server" Visible="false" Text="Calcular %" OnClick="BtnCAlcular_Click" />
                            &nbsp;&nbsp;
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
               

            <div class="col-md-3">
                <label id="LblRegistro" runat="server" class="control-label " visible="False">Registo a Modificar:</label>
                <asp:DropDownList ID="TipoReg" runat="server" class="form-control m-b" Enabled="true" BorderColor="Silver" AutoPostBack="true" OnSelectedIndexChanged="TipoReg_SelectedIndexChanged" Visible="False">

                    <%--<asp:ListItem Value="0">&lt;Seleccione un Item&gt;</asp:ListItem>--%>
                </asp:DropDownList>
            </div>

            <div class="col-md-1">
                <label id="lblNota" runat="server" class="control-label col-md-1" visible="False">Nota</label>

                <asp:TextBox ID="TextNotaAsignar" BorderColor="Silver" class="form-control" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <br />

                <asp:Button ID="ButtonAsignar" class="btn btn-w-m btn-primary" runat="server" Text="Asignar a Todos" OnClick="ButtonAsignar_Click" Visible="False" />
                &nbsp;&nbsp;
            </div>
            <div class="col-md-2">
                <br />

                <%--<asp:Button ID="ButtonImprimir" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir" OnClick="ButtonImprimir_Click" Visible="False" />--%>
            </div>
        </div>
    </div>        
    <asp:Label ID="LblMensajeErrorGrilla" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
</asp:Content>
