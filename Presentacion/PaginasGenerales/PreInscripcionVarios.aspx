<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="PreInscripcionVarios.aspx.cs" Inherits="PresInscripcionVarios" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">


    <asp:TextBox ID="TextIdAlu" BorderColor="Silver" type="string" class="form-control" runat="server" Visible="false"></asp:TextBox>
    <div class="form-group">
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblInsId" Visible="false" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblicuId" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblicoId" runat="server" Visible="false" Text=""></asp:Label>
    </div>
    <div class="ibox-content">
        <%--<label class="control-label col-md-12">Sección Busqueda</label>--%>


        <label>Buscar por:&nbsp;&nbsp;&nbsp; </label>
        <asp:RadioButtonList AutoPostBack="true" CssClass="form-check form-check-inline" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
            <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
            <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
        </asp:RadioButtonList>

        <%--<hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />--%>




        <%--<br />--%>
        <%--        <div class="form-row" style="background-color: #FFFFFF">
            <div class="form-group col-md-12" style="background-color: #FFFFFF">
                <label>Buscar por:&nbsp;&nbsp;&nbsp; </label>
                <asp:RadioButtonList AutoPostBack="true" CssClass="form-check form-check-inline" RepeatLayout="Flow" ID="RbtBuscar" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbtBuscar_SelectedIndexChanged" Font-Bold="True" Font-Italic="False">
                    <asp:ListItem style="margin-left: 0px; font-weight: bold" Selected="True" Value="0">Nombre </asp:ListItem>
                    <asp:ListItem style="margin-left: 30px; font-weight: bold" Value="1"> DNI </asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>--%>
        <div class="form-row">
            <div class="form-group col-md-4" style="background-color: #FFFFFF">
                <asp:TextBox ID="TextBuscar" BorderColor="Silver" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-md-8" style="background-color: #FFFFFF">
                <asp:Button ID="Button1" class="btn btn-w-m btn-primary" runat="server" data-toggle="collapse" data-target="#collapseExample"
                    aria-expanded="false" aria-controls="collapseExample" Text="Buscar" OnClick="btnBuscar_Click" />
                &nbsp;<asp:Button ID="btnNuevoAlumno" class="btn btn-w-m btn-primary" runat="server" Visible="false" Text="Nuevo" OnClick="btnNuevoAlumno_Click" />
                &nbsp;<asp:Button ID="btnCancelarAlumno" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelar2_Click" />
            </div>
        </div>


        <div class="form-row">
            <div class="ibox collapsed">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno" />
                    </Triggers>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                    <ContentTemplate>
                        <div class="ibox-title" runat="server" id="CanReg" visible="false">
                            <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros2" runat="server" Text=""></asp:Label></h5>
                        </div>

                        <div class="table-responsive">
                            <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                                AutoGenerateColumns="False" DataKeyName="Id" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                PageSize="5" OnPageIndexChanging="Grilla_PageIndexChanging" AllowPaging="True" Width="100%">
                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                <Columns>

                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/img/select.png" CommandName="Ver" />
                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" OnClick="redirectToFB()" Text='<%# Eval("Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DNI">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Doc" runat="server" Text='<%# Eval("Doc") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Legajo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" CommandName="Select" ID="Legajo" runat="server" Text='<%# Eval("LegajoNumero") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Activo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" Text='<%# Eval("Activo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="FechaNac">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" ID="FechaNac" runat="server" Text='<%# Eval("FechaNacimiento") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#CCCCFF" />
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />

                                <%--	                <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Underline="True" Height="12" />--%>
                            </asp:GridView>

                        </div>

                    </ContentTemplate>

                    <Triggers>
                        <asp:PostBackTrigger ControlID="Grilla" />
                        <asp:PostBackTrigger ControlID="btnCancelarAlumno"></asp:PostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%--    </div>--%>


    <div class="ibox-content">
        <%--        <div class="form-group col-md-4">
            <label>Alumno Seleccionado</label>
        </div>--%>
        <div class="form-group col-md-3">
            <asp:Label class="col-form-label" ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aludni" BorderColor="Silver" type="string" class="form-control" BackColor="#006699" ForeColor="White" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <asp:Label class="col-form-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aluNombre" BorderColor="Silver" BackColor="#006699" ForeColor="White" type="string" class="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <asp:Label class="col-form-label" ID="lblFechaNac" runat="server" Text="Fecha Nac. " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="aluFechaNacimiento" BorderColor="Silver" BackColor="#006699" ForeColor="White" type="string" class="form-control" runat="server" Enabled="false"></asp:TextBox>
        </div>
        <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>


        <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
        <%--<br />--%>

        <%--        <div class="form-inline">
            <div class="form-group col-md-4">
                <asp:Label class="col-form-label" ID="lblDNI" runat="server" Text="DNI:" Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aludni" BorderColor="Silver" type="string" class="form-control" BackColor="#006699" ForeColor="White" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label class="col-form-label" ID="LblApe" runat="server" Text="Nombre: " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="aluNombre" BorderColor="Silver" BackColor="#006699" ForeColor="White" type="string" class="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:TextBox ID="aluId" BorderColor="Silver" type="int" Visible="false" class="form-control" runat="server"></asp:TextBox>
        </div>--%>


        <%--<br />--%>
    </div>

    <div class="ibox-content">

        <label class="control-label">PreInscripción del Alumno</label>
        <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />

    </div>
    <div class="col-sm-12" style="background-color: #FFFFFF">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <div class="form-row" style="background-color: #FFFFFF">
                    <div class="form-group col-md-4">
                        <label class="control-label">Nivel</label>
                        <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="NivelID_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="form-group col-md-4">
                        <label class="control-label">Carrera</label>
                        <asp:DropDownList ID="carId" runat="server" BorderColor="Silver" class="form-control" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="carId_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Plan Estudio</label>
                        <asp:DropDownList ID="plaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="plaId_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-row" style="background-color: #FFFFFF">
                    <div class="form-group col-md-4">
                        <label class="control-label">Curso</label>
                        <asp:DropDownList ID="curId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="curId_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-md-4">
                        <label class="control-label">Año Cursado</label>
                        <asp:TextBox ID="icuAnioCursado" type="number" BorderColor="Silver" step="1" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="icuAnioCursado_TextChanged"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label ">Fecha Inscripcion</label>
                        <tpDatePicker:cuFecha ID="icuFechaInscripcion" bordercolor="Silver" runat="server" Enabled="true" allowtype="False" />
                    </div>
                </div>

                <div class="form-group">
                    <%--<label class="control-label col-md-2">Activo</label>--%>
                    <div class="col-md-1">
                        <asp:CheckBox ID="icuActivo" Visible="false" BorderColor="Silver" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>
                </div>
                <div class="col-sm-12" style="background-color: #FFFFFF">
                    <br />
                    <label class="control-label ">Concepto a PreInscribir</label>
                    <%--  <hr class="pg2-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />--%>
                    <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />

                    <br />
                    <div class="form-row" style="background-color: #FFFFFF">
                        <div class="form-group col-md-3">
                            <label class="control-label">Tipo de Conceptos</label>
                            <asp:DropDownList ID="ConTipoId" runat="server" BorderColor="Silver" class="form-control m-b" AutoPostBack="True" OnSelectedIndexChanged="ConTipoId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="control-label">Conceptos</label>
                            <asp:DropDownList ID="ConceptoId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ConceptoId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">
                            <%--<label class="control-label">Beca</label>--%>
                            <asp:DropDownList ID="BecaId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="True" Visible="false"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">


                            <label class="control-label" runat="server" id="lblCuota" visible="false">Cuota</label>
                            <asp:DropDownList BorderColor="Silver" ID="CuotaId" Visible="false" runat="server" class="form-control m-b" Enabled="false">
                                <asp:ListItem Value="0">Todas</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="ibox-content">
        <asp:Button ID="btnAgregar" class="btn btn-w-m btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    </div>
    <div id="alerEdad" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <h3>"La edad del Alumno no coincide con el curso seleccionado.. Ver Fecha de Nacimiento o seleccionar curso correcto."</h3>
    </div>

    <div class="row">
        <div class="col-sm-12">

            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="GrillaConcepto" runat="server" DataKeyNames="Id,conId,cntId,TipoConcepto,Concepto,Importe,Beca,BecId,NroCuota,FchInscripcion" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar" Visible="false" ItemStyle-Width="50" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccion" runat="server" Width="50" />
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                            <asp:BoundField DataField="conId" HeaderText="conId" Visible="false" />
                            <asp:BoundField DataField="cntId" HeaderText="cntId" Visible="false" />
                            <asp:BoundField DataField="TipoConcepto" HeaderText="Tipo Concepto" />
                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                            <asp:BoundField DataField="NroCuota" HeaderText="Nro Cuota" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                            <asp:BoundField DataField="AnioLectivo" HeaderText="AnioLectivo" />
                            <%--                            <asp:BoundField DataField="Beca" HeaderText="Beca" />
                            <asp:BoundField DataField="BecId" HeaderText="BecaId" Visible="false" />--%>
                            <asp:BoundField DataField="FchInscripcion" HeaderText="FchInscripcion" Visible="false" />

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                        OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                        OnClick="btnEliminarCancelar_Click" />
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
        </div>
    </div>

    <%--<div class="col-sm-12">
        <div class="form-raw">
            <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Inscribir" OnClick="btnAceptar_Click" />
        </div>
    </div>--%>
          <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
    <div class="form-row">
        <asp:Label ID="LblMjeGridConcepto" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#CC0000"></asp:Label>

    </div>
    <hr class="pg-titl-bdr-btm" style="padding-bottom: 0px; margin-bottom: 0px; margin-left: 0PX; padding-top: 0px; margin-top: 0px;" />
    <div class="form-group">
        <div id="alerConcepto" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Debe ingresar al menos un Conceto.."</h5>
        </div>
        <div id="alerCarrera" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar una carrera"</h5>
        </div>

        <div id="alerCurso" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un curso.."</h5>
        </div>
        <div id="alerAlumno" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"No ingresó ningún alumno"</h5>
        </div>
        <div id="alerNivel" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un nivel"</h5>
        </div>
        <div id="alerPlan" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Debe seleccionar un Plan"</h5>
        </div>
        <div id="alerAnio" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Debe ingresar Año Lectivo"</h5>

        </div>
        <div id="alerInscripción2" visible="false" runat="server" class="alert alert-info  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Se Preinscribió con exito al alumno en ese curso.."</h5>
        </div>
        <div id="alerInscripción" visible="false" runat="server" class="alert alert-primary  alert-dismissable">
            <%--<h6 style="font-weight: bold; font-size: small">"Se ingresaron los conceptos de la tabla"</h6>--%>
        </div>
        <div id="alerErrorConcepto" visible="false" runat="server" class="alert alert-info  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"No existe Concepto para ese Año Lectivo.."</h5>
        </div>

        <div id="alerErrorInsc" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"El Alumno ya estaba inscripto en ese curso.."</h5>
        </div>
        <div id="alerRepetido" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Concepto ya existente.. Solo se realizó la inscripción de los conceptos que no existían"</h5>
        </div>
        <div id="alerConceptoyaIngresado" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Concepto ya ingresado a la tabla.."</h5>
        </div>
        <div id="alerConceptoyaRegistrado" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Concepto existente para ese Alumno.."</h5>
        </div>
        <div id="alerConceptoyaRegistrado2" visible="false" runat="server" class="alert alert-info  alert-dismissable">
            <h5 style="font-weight: bold; font-size: medium">"Solo se incorporaron cuotas no cargadas.."</h5>
        </div>
    </div>



    <div class="form-row">
        <div class="col-sm-12">
            <asp:Button ID="btnInscribir" class="btn btn-w-m btn-primary" runat="server" Text="PreInscribir" OnClick="btnInscribir_Click" />
            <asp:Button ID="btnNuevaPresinscripcion" class="btn btn-w-m btn-primary" runat="server" Text="Nueva" OnClick="btnNuevaPreInscripcion_Click" />
            <asp:Button ID="btnCompbte" class="btn btn-w-m btn-primary" runat="server" Text="Imprimir Compbte." OnClick="btnCompbtePreInscripcion_Click" />
        </div>
    </div>


    <br />
    <br />
</asp:Content>
