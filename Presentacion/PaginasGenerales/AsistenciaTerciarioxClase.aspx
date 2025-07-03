<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AsistenciaTerciarioxClase.aspx.cs" Inherits="AsistenciaTerciarioxClase" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row" style="background-color: #f0f0f0;">
        <div class="ibox-content">
            <div class="form-group">
                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="lblamtId" Visible="false" runat="server"></asp:TextBox>
            </div>

            <%-- <div class="ibox collapsed">
                
                </div>--%>
            <div class="panel panel-success">
                <div class="panel-heading" style="font-size: medium; font-weight: bold">
                    Filtro
                </div>
                <div class="panel-body">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="form-group col-md-2">
                                    <label class="control-label">Carrera</label>
                                    <asp:DropDownList ID="carId" runat="server" required="" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-2">
                                    <label class="control-label">Plan Estudio</label>
                                    <asp:DropDownList ID="plaId" runat="server" required="" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-2">
                                    <label class="control-label">Curso</label>
                                    <asp:DropDownList ID="curId" runat="server" required="" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                                </div>


                                <div class="form-group col-md-2">
                                    <label class="control-label ">Espacio Curricular</label>

                                    <asp:DropDownList ID="escId" required="" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-2">
                                    <label class="control-label">Año de Cursado</label>
                                    <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                        AutoPostBack="false"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-2">
                                    <label id="lblFecha" runat="server" class="control-label" visible="true">Fecha:</label>
                                    <asp:TextBox ID="txtFecha" type="text" class="form-control" BorderColor="Silver" runat="server" placeholder=""></asp:TextBox>
                                    <asp:CheckBox ID="ckEliminarFecha" AutoPostBack="true" Text="Eliminar Fecha" runat="server" OnCheckedChanged="ckEliminarFecha_CheckedChanged" />
                                </div>
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <fieldset class="form-horizontal">
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-0">
                                <asp:Button ID="btnAplicar" class="btn btn-w-m btn-primary" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                                <asp:CheckBox ID="ckTodo" AutoPostBack="true" runat="server" Text="Ver todo" OnCheckedChanged="ckTodo_CheckedChanged" />

                            </div>
                        </div>
                    </fieldset>
                      <p style="color: red; font-weight: bold; margin: 10px 0;">
    ⚠️ <u>Importante</u>:  Una vez cargadas la asistencia debe confirmar las mismas con el botón Guardar al final de la planilla<br /> </p>
                </div>
            </div>
 </div>
            </div>
     <div class="row" style="background-color: #f0f0f0;">
        <div class="ibox-content">

            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="row">

                       
                        <div id="alerMje" visible="false" runat="server" class="alert alert-dismissible  alert-dismissable" style="color: red; font-weight: bold; margin: 10px 0;">
                            <asp:Label ID="lblMje" runat="server" Font-Bold="True" Font-Size="Medium" Text="Atención: Una vez cargadas las nota debe confirmar las mismas con el botón Guardar Notas"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvAlumnos" AutoGenerateColumns="False" OnRowDataBound="gvAlumnos_RowDataBound"
                                            BorderColor="#CCCCCC" DataKeyNames="ictId,amtId,recId" HorizontalAlign="Center" CssClass="table table-responsive table-striped" runat="server" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField DataField="ictId" HeaderText="ictId" Visible="false" />
                                                <asp:BoundField DataField="amtId" HeaderText="amtId" Visible="false" />
                                                     <asp:BoundField DataField="recId" HeaderText="recId" Visible="false" />

                                                <asp:BoundField DataField="Alumno" HeaderText="Alumno" />


                                                <asp:TemplateField HeaderText="Asistió" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkAsistio" runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observaciones">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtObsev" runat="server" Text="" Width="300" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />

                                        </asp:GridView>


                                        <asp:Button ID="btnToggleCheckAll" Visible="false" runat="server" Text="(Des)Seleccionar Todos" 
    OnClick="btnToggleCheckAll_Click" CssClass="btn btn-secondary" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>
                    <br />
 <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>

                    <asp:Button ID="btnGuardar" class="btn btn-w-m btn-info" runat="server" Text="Guardar" Visible="false" OnClick="btnGuardar_Click" />

                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
                    <br />
                   
                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>


                </ContentTemplate>
                <%-- <Triggers>
                    <asp:PostBackTrigger ControlID="gridview1" />
                </Triggers>--%>
            </asp:UpdatePanel>
              <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
            <asp:Panel ID="pnlContents" runat="server">
                <div class="col-sm-12">
                    <div id="divImprimir">
                        <div class="table-responsive">

                            <%--<div style="overflow-x: auto; max-width: 100%;">--%>
                            <asp:GridView ID="gvAsistencia" runat="server" OnRowDataBound="gvAsistencia_RowDataBound"
                                CssClass="table table-bordered table-sm " AutoGenerateColumns="true"
                                CellPadding="4" ForeColor="#333333" GridLines="None">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="x-Small" CssClass="wrap-header" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="11px" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <%-- </div>--%>
                        </div>
                    </div>
                </div>
            </asp:Panel>
                    
                </ContentTemplate>
                 <Triggers>
                    <asp:PostBackTrigger ControlID="ckEliminarFecha" />
                </Triggers>
            </asp:UpdatePanel>

            <br />


        </div>
    </div>

</asp:Content>
