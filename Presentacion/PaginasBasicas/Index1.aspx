<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index1.aspx.cs" Inherits="PaginasBasicas_Index1" %>

<!DOCTYPE html>
<html lang="en" class=" js no-touch">
<head runat="server">
    <title>Hermanos de la Misericordia</title>
    <link rel="stylesheet" href="../assets/css/noscript.css" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="shortcut icon" href="../images/LogoNuevoAso.jpg" />
    <noscript>
    </noscript>
    <style type="text/css">
        .auto-style1 {
            width: 90%;
            height: 303px;
        }

        .auto-style4 {
            left: 0px;
            top: 34px;
            height: 0px;
        }

        /* Estilos por defecto para desktop (se comporta como un h1) */
        .brand-title {
            font-size: 20px; /* O el tamaño que tenga por defecto un h1 en tu diseño, o el que desees */
            text-align: left !important; /* Fuerza la alineación a la izquierda */
            /* Puedes inspeccionar tu h1 para ver su tamaño de fuente por defecto y usarlo aquí */
        }

        /* Estilos para móvil (para que se vea como un h2) */
        @media (max-width: 767px) { /* Este es el punto de quiebre común para móviles en Bootstrap */
            .brand-title {
                font-size: 22px; /* Tamaño de fuente típico para un h2 */
                text-align: left !important; /* Fuerza la alineación a la izquierda */
                /* Puedes ajustar este valor para que se parezca más a un h2 en tu diseño */
                line-height: 1.2; /* Ajusta la altura de línea si es necesario */

            }
        }

    </style>
</head>
<body class="landing is-preload">

    <!-- Page Wrapper -->
    <div id="page-wrapper">

        <!-- Header -->


           <!-- Header -->
        <header id="header" >

          <h1 class="brand-title"><a href="../PaginasBasicas/LoginPadres.aspx">Autogestión</a></h1>
         
            <nav id="nav">
                <ul>
                    <li class="special">
                        <a href="#menu" class="menuToggle"><span>Menu</span></a>
                        <div id="menu">
                            <ul>
                                <li><a href="Index1.aspx">Inicio</a></li>
                                <li><a href="#one">Misión</a></li>
                                <li><a href="#two">Instituciones</a></li>
                                <li><a href="../PaginasBasicas/LoginEmpleados.aspx">Empleados</a></li>
                            </ul>
                        </div>
                    </li>
                </ul>
            </nav>
        </header>
    
       <%-- <header id="header">

                  <h1 ><a href="../PaginasBasicas/LoginPadres.aspx">Autogestión</a></h1>--%>
            <%--       <li><a href="Index1.aspx">Inicio</a></li>--%>

         <%--   <nav class="nav">
                <ul>
                    <li><a href="Index1.aspx">Inicio</a></li>
                    <li><a href="#one">Misión</a></li>
                    <li><a href="#two">Instituciones</a></li>
                </ul>
            </nav>

            <br />
            <br />

        </header>--%>

        <%--   <header id="header" class="alt">
            <h1><a href="index1.html">Hermanos de la Misericordia</a></h1>
            <nav id="nav">
                <ul>
                    <li >
                    <a href="#menu" class="menuToggle"><span>Menu</span></a>
                        <div id="menu">
                            <ul>
                                <li><a href="Index1.aspx">Inicio</a></li>
                                <li><a href="#one">Misión</a></li>
                                <li><a href="#two">Instituciones</a></li>
                                <li><a href="#tree">Estado Cuenta</a></li>

                            </ul>
                        </div>
                    </li>
                </ul>
            </nav>
        </header>--%>

        <!-- Banner -->
        <section id="banner">
            <div class="inner">
                <h2>Asociación Civil de Hermanos Misericordistas</h2>
                <p>"EL HONOR A DIOS, EL TRABAJO PARA MI, EL PROVECHO PARA EL PRÓJIMO"</p>

            </div>
            <a href="#one" class="more scrolly">Leer Más</a>
        </section>

        <!-- One -->
        <section id="one" class="wrapper style2" style="text-align: center">
            <div class="inner">
                <header class="major">
                    <h2 aling="center">Nosotros</h2>
                    <p>
                        La Obra de los Hermanos de Nuestra Señora de la
Misericordia en Santiago del Estero (Argentina) es la más
extensa en Latino América. Tuvo sus orígenes en el año 1933
cuando los primeros Hermanos provenientes de Europa
arribaron a estas tierras. Desde entonces unidos, hermanos y
laicos hemos desandado un largo camino encarnando el
carisma del Fundador Víctor Scheppers en el servicio a los
más pobres y necesitados desde la acción social y la
educación.
                    </p>
                </header>

                <%--                <header class="major">
                    <h2 aling="center">A  LA COMUNIDAD EDUCATIVA</h2>
                    <p>
                        LA ADMINISTRACION CENTRAL DE LA OBRA MISERICORDISTA INFORMA QUE A PARTIR DE LA FECHA SE MODIFICÓ  EL NUMERO DE CONTACTO CON EL CELULAR DE LA SECCION ARANCELES  POR RAZONES TECNICAS QUE ESCAPAN A NUESTRAS POSIBILIDADES.
                        SEPAN DISCULPAR LAS MOLESTIAS OCASIONADAS. 
                        EL NUEVO  WHASTAPP PARA INFORMAR SUS PAGOS REALIZADOS MEDIANTE TRANSFERENCIA BANCARIA ES +543855825454                        
                    </p>
                </header>--%>
            </div>
        </section>

        <article id="main" style="height: 10px; width: 100%">
            <header>
            </header>
        </article>





        <section id="tree" class="wrapper style2" style="text-align: center">
            <div class="inner">
                <header class="major">


                    <ul class="icons">
                        <li><a href="../Documento/Valores_Cuotas 2025.pdf" target="_blank" class="icon solid fa-edit">&nbsp;<h2> Aranceles 2025</h2></a></li>
                    </ul>


                    <h2>Débito Automático por CBU </h2>
                    <br />
                    <h5>Comunicado 07/05/2025</h5>
                    <p>El día 05 de mayo de 2025 se debería acreditar en las cuentas bancarias institucionales el débito automático de la cuota de mayo 2025. Hemos 
                        podido verificar que no han sido impactadas las cuotas de aquellos alumnos cuyos padres o tutores tienen cuenta en el B.S.E., debido a que 
                        siempre que se paga un Bono (o S.A.C.) 
                        coincidente con el pago de sueldo, nos informa el Banco que por instrucciones gubernamentales no pueden realizar débitos sobre esos montos.
                        Consecuencia de ello, y siendo una cuestión ajena a nuestra Obra, es que ofrecemos la posibilidad de pagar por Administración durante todo el mes de mayo y hasta el 31, 
                        en efectivo o por transferencia el valor de la cuota de mayo sin recargo.
                    <br />
                        <b>Consejo Administrativo</b>
                    </p>
                    <br />
                        <%--                    
                        <p>
                        Según lo informado en Flayer de fin de año 2023, desde el año 2024 implementaremos por primera vez el ‘DÉBITO AUTOMÁTICO POR CBU’ como medio de pago alternativo al de la Caja Municipal, que se habilitará únicamente para débito directo en cuenta bancaria (NO Tarjetas de Crédito, NO Billeteras Virtuales).
                        <br />
                        Desde aquí podrá descargar el “FORMULARIO DE ADHESIÓN AL DÉBITO DIRECTO” y el archivo ANEXO I de las “Normas Institucionales para la aplicación del Débito Automático en Cuentas Bancarias”, éste deberá ser leído atentamente. 
                        <br />
                        Tendrán que imprimir únicamente el “Formulario de Adhesión al Débito Directo, completarlo en su totalidad y presentarlo en Administración Central en el plazo establecido del 14 al 22 de febrero de 2024, sin excepción. Quienes no puedan adherirse en esta primera instancia, podrán hacerlo en cualquier mes del año a partir de la cuota siguiente; teniendo presente que los Aranceles Vencidos deberán ser abonados solamente en Caja Municipal. Se recuerda que las dos únicas formas de pago habilitadas son en Caja Municipal y por Débito Automático (NO TRANSFERENCIAS) en cuentas bancarias.
                        <br />
                        Lo descripto es aplicable a TODAS LAS INSTITUCIONES DE LA OBRA MISERICORIDSTA.
                        <br />
                        Consejo Administrativo
                    </p>--%>

                    <p>
                    Se comunica que está abierta la posibilidad de pago por Débito automático 2025.
                        <br />
                    Pasos a seguir:
                        <br />
                    1)	Descargar ficha y presentarla en Administración Central (Libertad 341) en el horario de 8:30 a 11:30, desde el 4/2/2025 hasta el 20/02/2025.
                    <br />
                    2)	En caso de haber completado el formulario 2024, el mismo seguirá en vigencia, salvo que:
                    <br />
                    •	Se haya dado de baja mediante el formulario correspondiente.
                        <br />
                    •	Desee dar de baja el Débito Automático
                        <br />
                    •	Se produzca una Modificación de Cuenta Bancaria/CBU
                        <br />
                    •	Desde agregar o sacar alumnos declarados
                        <br />
                    3)	Adjuntar comprobante de CBU
                        <br />
                    Importante:
                        <br />
                    - Los débitos se realizan una única vez, el primer día hábil de cada mes.
                        <br />
                    - Revise sus movimientos de cuenta desde su home banking para chequear del debito
                        <br />
                    - Pasadas las 48 hs del débito, ud. podrá entrar a la página institucional para verificar el pago realizado, en <a href="../PaginasBasicas/LoginPadres.aspx" target="_blank">AUTOGESTION</a>
                        <br />
                    - EL DEBITO NO ES APLICABLE PARA PAGO DE MATRICULAS
                        <br />
                    </p>

                    <ul class="icons">
                        <li><a href="../Documento/FORMULARIODEADHESIONALDEBITOPORCBU.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Formulario de adhesión al Débito Automático por CBU</a></li>
                    </ul>
<%--                    <ul class="icons">
                        <li><a href="../Documento/ANEXO I.NormasparaDébitoAutomático.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Anexo I - Normas Institucionales para la aplicación del Débito Automático en Cuentas Bancarias</a></li>
                    </ul>--%>

                </header>

<%--                <div class="item">
                    <a href="../Documento/FormasPago2024ObraMise.mp4" target="_blank" style="color: white; font-weight: bold; font-size: larger;">
                        <i class="fa fa-video-camera" aria-hidden="true"></i>&nbsp; Video instructivo de las formas de pago vigentes</a>
                </div>--%>
                <div class="item">
                    <a href="../Documento/EstadoCuentaAlumno.mp4" target="_blank" style="color: white; font-weight: bold; font-size: larger;">
                        <i class="fa fa-video-camera" aria-hidden="true"></i>&nbsp; Video instructivo Estado de Cuenta Alumnos</a>
                </div>
            </div>
        </section>

        <%--	<ul class="icons major">
								<li><span class="icon fa-gem major style1"><span class="label">Lorem</span></span></li>
								<li><span class="icon fa-heart major style2"><span class="label">Ipsum</span></span></li>
								<li><span class="icon solid fa-code major style3"><span class="label">Dolor</span></span></li>
							</ul>--%>


        <!-- Two -->
        <section id="two" class="wrapper alt style2 ">
            <section class="spotlight">
                <div class="image">
                    <img src="../images/whh01DTQ.jpg" alt="" class="auto-style1" />
                </div>
                <div class="content">
                    <h2>Colegio San José</h2>
                    <p>El Colegio San José, nació como Institución Educativa en 1933. En la actualidad ofrece las siguientes niveles educativos: <%-- Primario -  Secundario -  Superior--%>.</p>
                    <ul class="icons">
                        <li><a href="Primario.aspx" class="button">Primario</a>
                        <li><a href="Secundario.aspx" class="button">Secundario</a>
                        <li><a href="Profesorado.aspx" class="button">Superior</a>
                            <%--   <li><a href="InscripcionActualizar.aspx?Inst=1" class="button">Inscripción</a>--%>
                    </ul>

                    <%--                    <ul class="icons">
                        <li><a href="../PaginasBasicas/ContactoSanJose.aspx" class="icon solid fa-envelope">&nbsp;Contacto</a>
                        <li><a href="../PaginasBasicas/RequisitosSJ.aspx" class="icon solid fa-edit">&nbsp;Requisitos Pre-inscripción 1° Grado</a>
                        <li><a href="../Documento/FLAYERSJ.pdf" class="icon solid fa-edit">&nbsp;Requisitos Inscripción 2° a 7° Grado</a>
                        <li><a href="../Documento/REQUISITOSNIVELSUP.pdf" class="icon solid fa-university">&nbsp;Requisitos Inscripción Nivel Superior</a>

                        <li><a href="../PaginasBasicas/Profesorado.aspx" class="icon solid fa-university">&nbsp; Oferta Académica Nivel Superior</a>--%>

                    <%--   <li><a href="#" class="icon solid fa-phone">&nbsp;0385-4211579/4240161</a></li>--%>
                    <%--</ul>--%>
                    <a href="../PaginasBasicas/ContactoSanJose.aspx" class="icon solid fa-envelope">&nbsp;Contacto</a>
                </div>
            </section>
            <section class="spotlight">
                <div class="image">
                    <img src="../images/mwtwpuRA.jpeg" alt="" />
                </div>
                <div class="content">
                    <h2>Colegio Misericordia</h2>
                    <p>
                        En el colegio Misericordia, cada alumno mediante el trabajo colaborativo
y el acompañamiento del docente, va construyendo su trayectoria
escolar. La propuesta educativa se materializa en proyectos y
secuencias didácticas destinadas a desarrollar un pensamiento
crítico, reflexivo y creativo, haciendo hincapié sobre todo en la
formación de valores inspirados en el carisma misericordista. Ofrece a la sociedad el nivel Primario.
                    </p>

                    <ul class="icons">
                        <li><a href="InscripcionActualizar.aspx?Inst=2" class="button">Actualizacion de Datos 2025</a>
                    </ul>

                    <ul class="icons">
                        <li><a href="../Documento/FlyerMATRICULA 2° A 6° 2025 MISERICORDIA.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Flayer Inscripción 2025</a></li>
                    </ul>
<%--                    <ul class="icons">
                        <li><a href="../Documento/FLAYERPREINSCRIPCION2025ColegioMisericordiaOtrosJardines.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Flayer Pre-inscripción 2025 - Otros Jardines</a></li>
                    </ul>--%>

                    <ul class="icons">
                        <li><a href="../Documento/CM_SOLICITUD DE MATRÍCULA 2025.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Solicitud Matricula 2025</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/CM_FICHA DE SALUD INDIVIDUAL 2025.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Ficha de Salud</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/CM_ANEXO FICHA ESCOLAR 2025.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Anexo Ficha Escolar</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/CM_HISTORIA PERSONAL DEL NIÑO 2025.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Historia Personal Niño</a></li>
                    </ul>

                    <ul class="icons">
                        <li><a href="../PaginasBasicas/ContactoMisericordia.aspx" class="icon solid fa-envelope">&nbsp;Contacto</a>
                    </ul>

                </div>

            </section>
            <section class="spotlight">
                <div class="image">
                    <img src="../images/JardinMisericordiaF.jpg" alt="" />
                </div>
                <div class="content">
                    <h2>Jardín Misericordia</h2>
                    <p>En el Jardín Misericordia llevamos a cabo actividades educativa respetando las necesidades lúdicas de experimentación y expresión, asegurando una enseñanza de conocimientos significativos que amplíen y profundicen los aprendizajes. A disposición de la sociedad el nivel Inicial.</p>
                                        <ul class="icons">
                        <li><a href="../Documento/FlyerPREINSCRIPCION2026JARDINMISERICORDIA.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Pre-inscripción 2026</a></li>
                    </ul>
                    <%--                    <ul class="icons">
                        <li><a href="../Documento/Flayer2023MatriculaIngresantesJM.pdf" class="icon solid fa-edit">&nbsp;Información Matricula 2023</a></li>
                    </ul>--%>

                    <ul class="icons">
                        <li><a href="jardinMisericordia.aspx?Inst=4" class="button">Información Inscripción 2025</a>
                    </ul>

<%--                    <ul class="icons">
                        <li><a href="InscripcionActualizar.aspx?Inst=4" class="button">Inscripción 2025</a>
                    </ul>--%>
<%--                    <ul class="icons">
                        <li><a href="../Documento/JM_FLAYER DE REQUISITOS DE MATRICULA 2024.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Flayer Inscripción 2024</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/JM_ANEXO I- FICHA MÉDICA PARA INGRESO ESCOLAR ANUAL.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Ficha Médica</a></li>
                    </ul>--%>



                    <%--                    <ul class="icons">
                         <li><a href="InicialJMisericordia.aspx" class="button">Ingresar</a>
                        <li><a href="InscripcionActualizar.aspx?Inst=4" class="button">Inscripción 2023</a>
                        </ul>--%>
                    <ul class="icons">
                        <li><a href="../PaginasBasicas/ContactoJardinMisericordia.aspx" class="icon solid fa-envelope">&nbsp;Contacto</a></li>
                    </ul>
                    <%--                      <ul class="icons">
                        <li><a href="../PaginasBasicas/RequisitosJM.aspx" class="icon solid fa-edit">&nbsp;Requisitos Pre-inscripción</a>   </li>
                        <li><a href="../Documento/Flayer.pdf" class="icon solid fa-edit">&nbsp;pdf</a></li>
                    </ul>--%>
                </div>
            </section>
            <section class="spotlight">
                <div class="image">
                    <img src="../images/PadreVICTOR.jpeg" alt="" />
                </div>
                <div class="content">
                    <h2>Jardín Padre Victor</h2>
                    <p>El Jardín Padre Victor en su nivel Inicial busca promover el juego como contenido de alto valor cultural para el desarrollo cognitivo, afectivo, ético, motor y social. Fomentar la socialización, a partir de los valores.</p>
<%--                    <ul class="icons">
                        <li><a href="InicialJPadreVictor.aspx" class="button">Ingresar</a>
                            <%--<li><a href="InscripcionActualizar.aspx?Inst=5" class="button">Inscripción</a>
                    </ul>--%>
                    

                    <ul class="icons">
                        <li><a href="../Documento/JardinPadreVictorFlyerMatricula2025.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Flyer Inscripción 2025</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../PaginasBasicas/ContactoPadreVictor.aspx" class="icon solid fa-envelope">&nbsp;Contacto</a>
                    </ul>


                    <%--  <ul class="icons">
                        <li><a href="../PaginasBasicas/RequisitosJPV.aspx" class="icon solid fa-edit">&nbsp;Requisitos Pre-inscripción</a>
                        <li><a href="../Documento/PLANILLAPEINSCRIPCION.pdf" class="icon solid fa-edit">&nbsp;Formulario</a></li>
                    </ul>--%>
                </div>
            </section>
            <section class="spotlight">
                <div class="image">
                    <img src="../images/SanVicenteF.jpeg" alt="" />
                </div>
                <div class="content">
                    <h2>Escuela San Vicente</h2>
                    <p>La finalidad de la Escuela San Vicente es facilitar a los alumnos y las alumnas los aprendizajes de la expresión y comprensión oral, la lectura, la escritura, el cálculo y el hábito de estudio y trabajo, con el fin de garantizar una formación integral que contribuya al pleno desarrollo de la personalidad de los alumnos y las alumnas y de prepararlos para cursar con aprovechamiento la Educación Secundaria Obligatoria.</p>
                    <%-- <img src="../images/whatsapp.png"  width="5%" />&nbsp; 3854666777  --%>
                    <ul class="icons">
                        <li><a href="../Documento/PreinscripciónyMatriculaa1°grado2025HermanoseHijosSanVicente.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Requisitos Pre-Inscripción 2025 (Ingresantes Hermanos de Alumnos- Hijos del Personal de la Obra Misericordista) </a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/PreinscripciónyMatriculaa1°grado2025SanVicente.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Requisitos Pre-Inscripción 2025 (Ingresantes del Jardín Padre Víctor)</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/FICHA DE INSCRIPCION 2025 SAN VICENTE.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Ficha Inscripción 2025</a></li>
                    </ul>
                    <ul class="icons">
                        <li><a href="../Documento/FICHA DE SALUD INDIVIDUAL CICLO LECTIVO 2025 SANVICENTE.pdf" target="_blank" class="icon solid fa-edit">&nbsp;Ficha de Salud</a></li>
                    </ul>


                    

                    <%--                    <ul class="icons">
                        <li><a href="PrimarioSanVicente.aspx" class="button">Ingresar</a>
                        <li>--%>
                    <%--<a href="InscripcionActualizar.aspx?Inst=3" class="button">Inscripción</a>--%>
                    <%--                    </ul>--%>
                    <ul class="icons">
                        <li><a href="../PaginasBasicas/ContactoSanVicente.aspx" class="icon solid fa-envelope">&nbsp;Contacto</a></li>
                    </ul>

                    <%-- <ul class="icons">
                        <li><a href="../PaginasBasicas/RequisitosSV.aspx" class="icon solid fa-edit">&nbsp;Requisitos Pre-inscripción</a>
                    </ul>--%>
                </div>
            </section>
            <br />
        </section>



        <!-- CTA -->
        <article id="main" style="height: 80px">
            <header>

                <%--   <section id="tree" style="text-align: center;" class="auto-style4">
                    <h3>Consulta Estado de Cuenta / Imprimir Libre Deuda </h3>
                    <ul class="icons">
                        <li><a href="../PaginasBasicas/LoginPadres.aspx" class="icon solid fa-edit">&nbsp;Ingresar</a></li>
                    </ul>
                    <p>&nbsp;</p>

                </section>--%>
            </header>
        </article>

        <!-- Footer -->
        <footer id="footer">
            <ul class="icons">
                <%-- <li><a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>--%>

                <%--   <li><a href="#" class="icon brands fa-facebook"><span class="label">Facebook</span></a></li>--%>
                <%--     <li><a href="#" class="icon brands fa-dribbble"><span class="label">Dribbble</span></a></li>--%>
                <%--  <li><a href="#" class="icon solid fa-envelope"><span class="label">Email</span></a></li>--%>
            </ul>
            <div class="copyright">

                <a href="Login.aspx?IdPage=1">Intranet</a>
            </div>
        </footer>


    </div>

    <!-- Scripts -->
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/jquery.scrollex.min.js"></script>
    <script src="../assets/js/jquery.scrolly.min.js"></script>
    <script src="../assets/js/browser.min.js"></script>
    <script src="../assets/js/breakpoints.min.js"></script>
    <script src="../assets/js/util.js"></script>
    <script src="../assets/js/main.js"></script>

</body>
</html>
