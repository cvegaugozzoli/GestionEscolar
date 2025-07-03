<%@ Page Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="PreincripcionColegios.aspx.cs" Inherits="PreincripcionColegios" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>

<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:ScriptManagerProxy runat="server"></asp:ScriptManagerProxy>

    <div id="wrapper">
        <asp:Label ID="aluId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblicuId" runat="server" Visible="false"></asp:Label>

        <div class="alert alert-info  alert-dismissable" style="font-size: large; background-color: #006699; color: #FFFFFF; font-family: Georgia, 'Times New Roman', Times, serif;">

            <p>
                El formulario de preinscripción se habilitará para aquellos futuros alumnos que:<br />
            </p>
            <p>- Tengan hermano en algunas de las instituciones de la Obra Misericordista.</p>

            <p>- Sean hijos de Personas que trabajen en alguna de las Instituciones de la Obra Misericordista</p>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="row wrapper border-bottom white-bg page-heading">
                    <div class="col-lg-10">
                        <h2>Instituciones</h2>
                    </div>
                </div>
                <div class="ibox-content" style="background-color: #FFFFFF">


                    <div class="col-lg-10">
                        <div class="ibox float-e-margins">
                            <%-- <div class="ibox-title">

                            <%--    <h5>Seleccione una institución</h5>
                                <div class="ibox-tools">
                                    <span class="label label-warning-light pull-right"></span>
                                </div>
                            </div>--%>
                            <div class="ibox-content">

                                <div>
                                    <div class="feed-activity-list">

                                        <div class="feed-element">
                                            <a href="#.html" class="pull-left">
                                                <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="rbSelector_CheckedChanged"
                                                    AutoPostBack="true" />

                                                &nbsp;
                                                <img alt="image" class="img-circle" src="../images/sanjose.png">
                                            </a>
                                            <div class="media-body " style="font-size: medium">
                                                <strong>Colegio San José</strong>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="feed-element">
                                            <a href="#.html" class="pull-left">
                                                <asp:RadioButton ID="RadioButton2" runat="server" OnCheckedChanged="rbSelector2_CheckedChanged"
                                                    AutoPostBack="true" />
                                                &nbsp;   &nbsp;
                                                <img alt="image" class="img-circle" src="../images/misericordia.jpg">
                                            </a>
                                            <div class="media-body " style="font-size: medium">
                                                <strong>Colegio Misericordia</strong>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="feed-element">
                                            <a href="#.html" class="pull-left">
                                                <asp:RadioButton ID="RadioButton3" runat="server" OnCheckedChanged="rbSelector3_CheckedChanged"
                                                    AutoPostBack="true" />
                                                &nbsp;   &nbsp;
                                                <img alt="image" class="img-circle" src="../images/PadreVictor.jpg">
                                            </a>
                                            <div class="media-body " style="font-size: medium">
                                                <strong>Jardin Padre Victor</strong>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="feed-element">
                                            <a href="#.html" class="pull-left">
                                                <asp:RadioButton ID="RadioButton4" runat="server" OnCheckedChanged="rbSelector4_CheckedChanged"
                                                    AutoPostBack="true" />
                                                &nbsp;   &nbsp;
                                                <img alt="image" class="img-circle" src="../images/JardinMisericordia.jpg">
                                            </a>
                                            <div class="media-body " style="font-size: medium">
                                                <strong>Jardín Misericordia</strong>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="feed-element">
                                            <a href="#.html" class="pull-left">
                                                <asp:RadioButton ID="RadioButton5" runat="server" OnCheckedChanged="rbSelector5_CheckedChanged"
                                                    AutoPostBack="true" />
                                                &nbsp;   &nbsp;
                                                <img alt="image" class="img-circle" src="../images/SanVicente.jpg">
                                            </a>
                                            <div class="media-body " style="font-size: medium">
                                                <strong>Escuela San Vicente</strong>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                   <div id="aletColegio" visible="false" runat="server" class="alert alert-danger  alert-dismissable">
                    <h3>"Debe seleccionar una Institución"</h3>
                </div>
                                        <div class="form-group">
                                            <asp:Button ID="btnSiguiente" class="btn btn-w-m btn-primary" runat="server"
                                                aria-expanded="false" formnovalidate Text="Siguiente" OnClick="btnSiguiente_Click" />
                                        </div>

                                    </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>



    <div class="footer">

        <div>
            <strong>Asociación Civil de Hermanos Misericordistas</strong> ; 2021
        </div>

    </div>

</asp:Content>
