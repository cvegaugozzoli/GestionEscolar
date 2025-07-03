<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="CargaNotasEvalTerc.aspx.cs" Inherits="CargaNotasEvalTerc" %>

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
                            <label class="control-label">Año de Cursado</label>
                            <asp:TextBox ID="AnioCursado" type="text" required="" class="form-control" BorderColor="Silver" runat="server" placeholder="Buscar por Año"
                                AutoPostBack="true" OnTextChanged="AnioCursado_TextChanged"></asp:TextBox>
                        </div>
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
                    </div>
                    <div class="row">
                        <div class="form-group col-md-3">
                            <label class="control-label ">Espacio Curricular</label>
                            <asp:DropDownList ID="escId" runat="server" BorderColor="Silver" AutoPostBack="true" class="form-control m-b" Enabled="true" OnSelectedIndexChanged="escId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-3">
                            <label id="lblPeriodo" runat="server" class="control-label">Tipo Evaluación</label>
                            <asp:DropDownList ID="ExamenTipoId" runat="server" BorderColor="Silver" class="form-control m-b" Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="ExamenTipoId_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-2">
                            <br />
                            <asp:CheckBox ID="ChkVerTodo" runat="server" Text="Ver Todo" AutoPostBack="true" OnCheckedChanged="ChkVerTodo_CheckedChanged" />
                        </div>

                    </div>

                    <div id="alerError" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <%-- <asp:Label ID="lblMateria" runat="server" Visible="true"></asp:Label>--%>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-0">
                    <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />

                </div>
            </div>

            <asp:UpdatePanel ID="PanelActNotas" runat="server" UpdateMode="Conditional" Visible="false">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-8">
                            <div class="table-responsive">
                                <br />
                                <asp:GridView ID="GrillaNota" GridLines="None" AutoGenerateColumns="false"
                                    BorderColor="#3399FF" DataKeyNames="Id,recId,Alumno,aluId,cdnId" HorizontalAlign="Center" CssClass="table table-responsive table-striped" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" ItemStyle-Width="250" Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="recId" Visible="false" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="recId" runat="server" Text='<%# Eval("recId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alumno" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAlumno" runat="server" Text='<%# Eval("Alumno") %>' Width="350"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="aluId" ItemStyle-Width="250" Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="aluId" runat="server" Text='<%# Eval("aluId") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Evaluación" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="Instancia" runat="server" Text='<%# Eval("Instancia") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Nota">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNota" Enabled="false" Text='<%# Eval("Nota") %>' runat="server" Width="90px" />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Condición" Visible="false" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="Condicion" runat="server" Text='<%# Eval("cdnNombre") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="cdnId" Visible="false" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="cdnId" runat="server" Text='<%# Eval("cdnId") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
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

                    <div class="row">
                        <div class="col-sm-8">
                            <div class="table-responsive">
                                <asp:GridView ID="GrillaRecAsist" GridLines="None" AutoGenerateColumns="false"
                                    BorderColor="#3399FF" HorizontalAlign="Center" DataKeyNames="Asistencia,Rec Asist,Condicion2,cdnId" CssClass="table table-responsive table-striped" runat="server">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Alumno" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAlumno2" runat="server" Text='<%# Eval("Alumno2") %>' Width="250"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asistencia">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAsis" Enabled="false" Text='<%# Eval("Asistencia") %>' runat="server" Width="90px" MaxLength="3" />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rec Asist.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="RecAsist1" Enabled="false" Text='<%# Eval("Rec Asist") %>' runat="server" Width="90px" MaxLength="3" />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Condición" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="Condicion2" runat="server" Text='<%# Eval("Condicion2") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="cdnId" ItemStyle-Width="250 " Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="cdnId" runat="server" Text='<%# Eval("cdnId") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#CCCCFF" />
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />

                                </asp:GridView>
                            </div>
                        </div>


                        <div class="col-sm-1">
                        </div>
                        <div class="col-sm-3">
                            <div class="table-responsive">
                                <asp:GridView ID="GrillaRecAsist2" GridLines="None" AutoGenerateColumns="false"
                                    BorderColor="#3399FF" HorizontalAlign="Center" DataKeyNames="Id,recId,aluId,cdnId" CssClass="table table-responsive table-striped" runat="server">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Id" ItemStyle-Width="250" Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="recId" Visible="false" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="recId" runat="server" Text='<%# Eval("recId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="aluId" ItemStyle-Width="250" Visible="false" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="aluId" runat="server" Text='<%# Eval("aluId") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Nueva Nota Rec. Asist">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNota" Enabled="false" runat="server" Width="90px" MaxLength="3" />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="cdnId" Visible="false" ItemStyle-Width="250" ItemStyle-VerticalAlign="Bottom">
                                            <ItemTemplate>
                                                <asp:Label ID="cdnId" runat="server" Text='<%# Eval("cdnId") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" />
                                            <ItemStyle Font-Bold="True" />
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



                    <div class="row">
                        <div class="col-md-2">
                            <asp:Button ID="BtnNota" class="btn btn-w-m btn-primary" runat="server" Text="Actualizar Nota" Visible="false" OnClick="BtnNota_Click" />
                        </div>
                        <div class="col-md-2 ">
                            <asp:Button ID="btnCondicion" class="btn btn-w-m btn-primary" runat="server" Text="Actualizar Condición" Visible="false" OnClick="btnCondicion_Click" />
                        </div>
                    </div>


                    <div class="row">
                        <div class="ibox-content">
                            <div class="form-inline col-md-10">
                                <div class="form-group col-md-5">
                                    <asp:Label class="control-label" ID="lblAsistRoja" runat="server" Font-Bold="true" Visible="false">No Cumple con el Porcentaje de Asistencia</asp:Label>
                                    <asp:TextBox ID="txtRojo" BackColor="red" ForeColor="red" Visible="false" BorderColor="Silver" type="string" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />

                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div id="alerExito" visible="false" runat="server" class="alert alert-info  alert-dismissable">
                                    <asp:Label ID="lblalerExito" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>



                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="carId" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="plaId" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="curId" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="escId" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ExamenTipoId" EventName="SelectedIndexChanged" />
                    <asp:PostBackTrigger ControlID="ChkVerTodo" />
                    <asp:AsyncPostBackTrigger ControlID="BtnNota" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:PostBackTrigger ControlID="btnCondicion"></asp:PostBackTrigger>

                </Triggers>

            </asp:UpdatePanel>
            <div class="row">
                <div id="alerError2" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </div>
            </div>

            <div class="ibox-content">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <asp:Panel ID="pnlContents" runat="server" Visible="false">
                            <asp:Label runat="server" Text="Colegio:" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblColegio" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Label runat="server" Text="Carrera:" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblCarrera" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
               <asp:Label runat="server" Text="Curso:" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblCurso" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" Text="Espacio Curricular:" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblMateria" runat="server"></asp:Label>
                            <br />
                            <br />
                            <br />

                            <div class="table-responsive">
                                <asp:GridView ID="GridView3" DataKeyNames="Alumno"
                                    HorizontalAlign="Center" CssClass="table table-responsive table-striped " runat="server" Width="100%" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                    </Columns>
                                    <EditRowStyle BorderStyle="Solid" BorderWidth="1" />
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="center" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1" Font-Bold="True" ForeColor="#333333" />
                                    <%-- <FooterStyle HorizontalAlign="Left" />--%>

                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="left" BorderStyle="Solid" BorderWidth="1" ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />


                                </asp:GridView>
                            </div>

                            <div class="ibox-title" runat="server" id="TituloCondición" visible="false">
                                <h4><a class="collapse-link">Observaciones de Alumnos en la que no se modificó Condición</a></h4>
                            </div>

                            <div class="table-responsive">
                                <asp:GridView ID="GridCorrelativas" HorizontalAlign="Center" AutoGenerateColumns="false" DataKeyNames="lblAlumno3,lblObservaciones" Width="100%" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="table table-responsive table-striped " runat="server">
                                    <Columns>

                                        <asp:BoundField DataField="lblAlumno3" HeaderText="Alumno" />
                                        <asp:BoundField DataField="lblObservaciones" HeaderText=" Observaciones o Correlativas que no cumple para actualizar condición " />


                                    </Columns>
                                    <EditRowStyle BorderStyle="Solid" BorderWidth="1" />
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="center" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1" Font-Bold="True" ForeColor="#333333" />
                                    <%-- <FooterStyle HorizontalAlign="Left" />--%>

                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="left" BorderStyle="Solid" BorderWidth="1" ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />


                                </asp:GridView>
                            </div>


                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="col-md-2 col-md-offset-0">
                            <asp:Button ID="btnPrint" class="btn btn-w-m btn-info" runat="server" Text="Imprimir" Visible="false" OnClientClick="PrintGridData()" />
                        </div>
                        <div class="col-md-2 ">
                            <asp:Button ID="btnActa" class="btn btn-w-m btn-primary" runat="server" Text="Acta de Promoción" Visible="false" OnClick="btnActa_clik" />
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <br />
                <br />
                <%--<asp:Button type="button" id="btnPrint"  runat="server" class="btn btn-w-m btn-primary" value="Print" OnClientClick="PrintGridData()" />--%>
            </div>
            <asp:Label ID="LblMensajeErrorGrilla" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>

        </div>
    </div>
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=GridView3.ClientID %>');
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var prtwin = window.open('', 'panel', 'left=50,top=300,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');

            prtwin.document.write('<style>@page{size:landscape;}</style><html><head><title ></title></head><body height="100%" width="100%" > <p style="font-size: large; font-weight: bold; text-align: center; text-decoration: underline">Libreta de Calificación</p> </body></html>');
            //prtwin.document.write(Materia.outerHTML);
            prtwin.document.write(panel.outerHTML);
            //prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
</asp:Content>
