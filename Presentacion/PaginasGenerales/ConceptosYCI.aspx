<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="ConceptosYCI.aspx.cs" Inherits="ConceptosYCI" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblConId" Visible="false" runat="server" Text=""></asp:Label>
        </div>
    </div>
     <div class="form-row">
        <div class="form-group col-md-3">
            <label class="control-label ">Instituciones</label>
            <asp:DropDownList ID="insId" Enabled="false"  runat="server" class="form-control m-b" ></asp:DropDownList>
        </div>
    </div>


    <div class="form-row">
        <div class="form-group col-md-3">
            <label class="control-label">Nivel</label>
            <asp:DropDownList ID="NivelID" runat="server" BorderColor="Silver" class="form-control" Enabled="false"></asp:DropDownList>

        </div>
    </div>

    <div class="form-row">
        <div class="form-group col-md-3">
            <label class="control-label ">Anio Lectivo</label>
            <asp:TextBox ID="conAnioLectivo" Enabled="false" type="number" step="1" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group col-md-3">
        <label class="control-label ">Conceptos Tipos</label>
        <asp:DropDownList ID="cntId" runat="server" Enabled="false" class="form-control m-b" ></asp:DropDownList>
    </div>
    <div class="form-row">
        <div class="form-group col-md-3">
            <label class="control-label">Nombre</label>
            <asp:TextBox ID="conNombre" type="text" Enabled="false" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
   


    <div class="row">
        <div class="col-md-6">
            <div class="form-group col-md-5">
                <asp:Label runat="server" Text="Concepto" Font-Bold="True" Font-Size="Medium"> </asp:Label>
            </div>

        </div>
        <div class="col-md-6">
            <div class="form-group col-md-7">
                <asp:Label runat="server" ID="ConceptoI" Visible="true" Text="Concepto - Interés " Font-Bold="True" Font-Size="Medium"> </asp:Label>
            </div>

        </div>
    </div>
    <div class="ibox-content">
        <div class="row">
            <div class="col-sm-5">
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label class="control-label ">Importe</label>
                        <asp:TextBox ID="conImporte" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">

                    <div class="form-group col-md-12">
                        <label class="control-label ">Recargo e Interes será:&nbsp; </label>
                        &nbsp;<asp:RadioButtonList AutoPostBack="true" Enabled="true" runat="server" CssClass="radio radio-info radio-inline" ID="rblValor" Font-Bold="True" Font-Italic="False">
                            <asp:ListItem Text="Monto Fijo" Value="0" />
                            <asp:ListItem Text="Porcentaje" Value="1" />
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label class="control-label ">Notas</label>
                        <asp:TextBox ID="conNotas" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">

                    <div class="form-group col-md-6">
                        <label class="control-label ">Interes Mensual</label>
                        <asp:TextBox ID="conInteresMensual" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label class="control-label ">Activo</label>
                        <asp:CheckBox ID="conActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox>
                    </div>
                </div>
            </div>


            <div class="col-sm-7">
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label class="control-label ">Cant Cuotas</label>
                        <asp:TextBox ID="conCantCuotas" Enabled="false" type="number" step="1" AutoPostBack="true" class="form-control"   runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label ">Cant Vtos</label>
                        <asp:TextBox ID="conCantVtos" Enabled="false" type="number" AutoPostBack="true" step="1" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">Mes Inicio</label>
                        <asp:TextBox ID="conMesInicio"  type="number" step="1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:GridView ID="GrillaCI" runat="server" GridLines="None" CssClass="table table-striped"
                                AutoGenerateColumns="False" OnRowEditing="OnRowEditing" OnRowDataBound="OnRowDataBound"
                                OnPageIndexChanging="Grilla_PageIndexChanging" OnRowUpdating="OnRowUpdating"
                                DataKeyNames="Id,NroCuota,FechaVto,ValorInteres,coiAplicaInteresAbierto,coiAplicaBeca">

                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ForeColor="Black" ID="Id" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cuota" ItemStyle-Width="20" ControlStyle-ForeColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCuota" runat="server" Text='<%# Eval("NroCuota") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="NroCuota" runat="server" Text='<%# Eval("NroCuota") %>' Width="50" />
                                        </EditItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Vto" ItemStyle-Width="20">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaVto" runat="server" Text='<%# Eval("FechaVto") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="FechaVto" runat="server" Text='<%# Eval("FechaVto") %>' Width="90" />
                                        </EditItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interes" ItemStyle-Width="20">
                                        <ItemTemplate>
                                            <asp:Label ID="lblValorInteres" runat="server" Text='<%# Eval("ValorInteres") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ValorInteres" Text='<%# Eval("ValorInteres") %>' runat="server" Width="90" />
                                        </EditItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Aplica Beca" ItemStyle-Width="20" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAplicaB" runat="server" Text='<%# Bind("AplicaBeca") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="coiAplicaBeca" Checked='<%# Convert.ToBoolean(Eval("[coiAplicaBeca]")) %>' runat="server" Width="50" />
                                        </EditItemTemplate>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Aplica Interés" ItemStyle-Width="20" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAplicaI" runat="server" Text='<%# Bind("AplicaInteres") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="coiAplicaInteresAbierto" Checked='<%# Convert.ToBoolean(Eval("[coiAplicaInteresAbierto]")) %>' runat="server" Width="50" />
                                        </EditItemTemplate>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowCancelButton="false" />

                                    <asp:TemplateField Visible="false">
                                        <EditItemTemplate>
                                            <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                                        </EditItemTemplate>

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
                                <PagerStyle HorizontalAlign="center" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label class="control-label "></label>
                        <asp:CheckBox ID="conTieneVtoAbierto" Text="Tiene Vto Abierto" runat="server" Checked="False" Enabled="true"></asp:CheckBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label class="control-label ">Recargo Vto Abierto</label>
                        <asp:TextBox ID="conRecargoVtoAbierto" type="number" step="0.1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
        <asp:Label ID="lblExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>
    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </div>

    <div class="col-sm-12">
        <div class="ibox-content">
            <div class="form-inline">
                <div class="form-group">
                    <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
