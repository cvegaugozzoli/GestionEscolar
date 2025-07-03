<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InscripcionCursadoConsulta.aspx.cs" Inherits="InscripcionCursadoConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">

    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblInsId" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div class="ibox-content">
        <div class="form-inline">
            <div class="form-group">
                <asp:Button ID="Button1" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Salir" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>


    <div class="ibox collapsed">
        <div class="ibox-title">
            <h5><a class="collapse-link">Filtros</a></h5>
            <div class="ibox-tools">
                <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
            </div>
        </div>
        <div class="ibox-content">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="form-row" style="background-color: #FFFFFF">
                        <div class="form-group col-md-3">
                            <label class="control-label">Carrera</label>
                            <asp:DropDownList ID="carId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="control-label">Plan Estudio</label>
                            <asp:DropDownList ID="plaId" runat="server" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="control-label">Curso</label>
                            <asp:DropDownList ID="curId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList>

                        </div>

                        <div class="form-group col-md-3">
                            <label class="control-label">Nombre del alumno</label>
                            <asp:TextBox ID="Alumno" type="text" class="form-control" runat="server" placeholder="Buscar por Alumno"
                                AutoPostBack="True" OnTextChanged="Alumno_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="row">
                <div class="col-sm-12">
                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                </div>
            </div>

        </div>
    </div>


    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title" runat="server" id="CantReg" visible="false">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>

                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <%--NavigateUrl='<%# "InscripcionCursadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'--%>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alumno">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Alumno" runat="server" Text='<%# Eval("Alumno") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="250px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Carrera" ItemStyle-Width="200">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" Text='<%# Eval("Carrera") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TipoCarrera" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="TipoCarrera" runat="server" Text='<%# Eval("TipoCarrera") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PlanEstudio" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" Text='<%# Eval("PlanEstudio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Curso">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" Text='<%# Eval("Curso") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Campo" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Campo" runat="server" Text='<%# Eval("Campo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EspacioCurricular" ItemStyle-Width="200">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="EspacioCurricular" runat="server" Text='<%# Eval("EspacioCurricular") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Año Cursado">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="AnioCursado" runat="server" Text='<%# Eval("AnoCursado") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FechaInscripcion" Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="FechaInscripcion" runat="server" Text='<%# Eval("FechaInscripcion") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:ButtonField HeaderText="Calificación" Visible="false" ButtonType="Button" CommandName="Ver" Text="Ver" />

                            <%--<asp:HyperLink ForeColor="Red" ID="Calificaciones" runat="server" CommandName="Ver" NavigateUrl='<%# "RegistracionCalificacionesConsulta.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='Ver' />--%>
                            <asp:TemplateField HeaderText="" Visible="false">
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
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">


                        <asp:Button ID="Exportar" Style="background-color: firebrick" Visible="false" runat="server" Text="Exportar a Excel" CssClass="btn btn-w-m btn-info" formnovalidate="formnovalidate" OnClick="btnExportarAExcel_Click" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblMejeErrOR2" runat="server" Text="" Visible="False" Font-Size="Medium" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            </div>
        </div>
    </div>

    <div class="ibox-content">
        <div class="table-responsive">
            <asp:GridView ID="gridtemp" runat="server" GridLines="None" CssClass="table table-striped"
                AutoGenerateColumns="False">

                <Columns>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <%--NavigateUrl='<%# "InscripcionCursadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'--%>
                            <asp:HyperLink ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Alumno" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Alumno" runat="server" Text='<%# Eval("Alumno") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="250px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Carrera" ItemStyle-Width="200" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Carrera" runat="server" Text='<%# Eval("Carrera") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TipoCarrera" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="TipoCarrera" runat="server" Text='<%# Eval("TipoCarrera") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="PlanEstudio" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="PlanEstudio" runat="server" Text='<%# Eval("PlanEstudio") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Curso" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Curso" runat="server" Text='<%# Eval("Curso") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Campo" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Campo" runat="server" Text='<%# Eval("Campo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EspacioCurricular" ItemStyle-Width="200" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="EspacioCurricular" runat="server" Text='<%# Eval("EspacioCurricular") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Año Cursado" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="AnioCursado" runat="server" Text='<%# Eval("AnoCursado") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FechaInscripcion" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="FechaInscripcion" runat="server" Text='<%# Eval("FechaInscripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activo" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField HeaderText="Calificación" Visible="false" ButtonType="Button" CommandName="Ver" Text="Ver" />

                    <%--<asp:HyperLink ForeColor="Red" ID="Calificaciones" runat="server" CommandName="Ver" NavigateUrl='<%# "RegistracionCalificacionesConsulta.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='Ver' />--%>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                            <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                OnClick="btnEliminarAceptar_Click" />
                            <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                OnClick="btnEliminarCancelar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>


                <FooterStyle HorizontalAlign="NotSet" />


                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CCCCFF" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
