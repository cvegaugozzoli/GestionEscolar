<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="EvaluacionesEspCurricular.aspx.cs" Inherits="EvaluacionesEspCurricular" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="TextIC" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextTC" Visible="false" runat="server"></asp:TextBox>


            <%-- <div class="col-sm-12">
                <div class="ibox-content">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                        </div>
                       <div class="form-group" >
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                    </div>
                </div>
            </div>--%>
        </div>

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
                    <div class="row">
                        <div class="form-group col-md-3">
                            <label class="control-label">Carrera</label>
                            <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="control-label">Plan Estudio</label>
                            <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="control-label">Curso</label>
                            <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                        </div>


                        <div class="form-group col-md-3">
                            <label class="control-label ">Espacio Curricular</label>
                            <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                          <div class="form-group col-md-2">
                            <label class="control-label ">Año Cursado</label>
                            <asp:TextBox  ID="eceAnioCursado" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <%--                        <div class="form-group col-md-2">
                            <label class="control-label">Año de Cursado</label>
                            <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                AutoPostBack="false"></asp:TextBox>
                        </div>--%>
                        <div class="form-group col-md-3">
                            <label id="lblPeriodo" runat="server" class="control-label" visible="false">Tipo Evaluación</label>
                            <asp:DropDownList ID="ExamenTipoId" runat="server" BorderColor="Silver" class="form-control m-b" Visible="false" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="ExamenTipoId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <%--                        <asp:CheckBox ID="ChkVerTodo" runat="server" text="Ver Todo" AutoPostBack="true"/>--%>
                    </div>

                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

       
                <div class="ibox-content">
                    <div class="form-inline">
                        <div class="form-group col-3">
                            <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Listar" OnClick="btnAplicar_Click" />
                        </div>

                        <div class="form-group col-3">
                            <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Agregar Evaluación" OnClick="btnNuevo_Click" />
                        </div> 
                        
                  <%--      <div class="form-group col-3">
                            <asp:Button ID="btnAgregarTodas" Visible="false" class="btn btn-w-m btn-warning" runat="server" Text="Agregar Todas Evaluaciones" OnClick="btnAgregarTodas_Click" />
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
   
    <div class="row">   
           
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand" DataKeyNames="Id, escId"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <Columns>

                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "EvaluacionesEspCRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&escId="+ DataBinder.Eval(Container.DataItem,"escId").ToString()  %>' Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="escId" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="escId" runat="server" NavigateUrl='<%# "EvaluacionesEspCRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&escId="+ DataBinder.Eval(Container.DataItem,"escId").ToString()  %>' Text='<%# Eval("escId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "EvaluacionesEspCRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&escId="+ DataBinder.Eval(Container.DataItem,"escId").ToString()  %>' Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Tipo" runat="server" NavigateUrl='<%# "EvaluacionesEspCRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&escId="+ DataBinder.Eval(Container.DataItem,"escId").ToString()  %>' Text='<%# Eval("TipoRegistro") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
 <asp:TemplateField HeaderText="Orden">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="eceDescripcion" runat="server" NavigateUrl='<%# "EvaluacionesEspCRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString()+ "&escId="+ DataBinder.Eval(Container.DataItem,"escId").ToString()  %>' Text='<%# Eval("eceDescripcion") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "EvaluacionesEspCRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() + "&escId="+ DataBinder.Eval(Container.DataItem,"escId").ToString() %>' Text='<%# Eval("Activo") %>' />
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
                          <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#CCCCFF" />
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
       
    </div>



  
    <asp:Label ID="LblMensajeErrorGrilla" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
</asp:Content>
