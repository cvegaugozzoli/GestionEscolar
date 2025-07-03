<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RequisitosSV.aspx.cs" Inherits="RequisitosSJ" %>

<!DOCTYPE html>
<html lang="en" class=" js no-touch">
<head runat="server">
    <title>Asociación Civil Misericordia</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="shortcut icon" href="../images/LogoNuevoAso.jpg" />
</head>
<body class="is-preload">

    <!-- Page Wrapper -->
    <div id="page-wrapper">

        <!-- Header -->
        <header id="header">
            <h1><a href="index1.html">Congregación de los hermanos de la Misericordia</a></h1>
            <nav id="nav">
                <ul>
                    <li class="special">
                        <a href="#menu" class="menuToggle"><span>Menu</span></a>
                        <div id="menu">
                            <ul>
                                <li><a href="Index1.aspx">Inicio</a></li>
                            </ul>
                        </div>
                    </li>
                </ul>
            </nav>
        </header>

        <!-- Main -->
        <article id="main">
            <header>
                <h2>Preinscripción </h2>
                <p>Colegio San Vicente</p>
            </header>
            <section class="wrapper style5">
                <div class="inner" style="padding-left: 30px;">
                    <%--     <h3>REQUISITOS PARA LA PREINSCRIPCION</h3>--%>
                    <p style="font-weight: bold">
                        Sr Padre y/o Tutor se le informa que los pasos para la preinscripción a 1° grado en esta etapa donde se prioriza: Alumnos provenientes del Jardín Padre Víctor -Hermanos de alumnos de la Escuela San Vicente - Hijos del Personal de la Obra Misericordista son los siguientes:
                    </p>
                    <h3>PRIMER PASO </h3>
                    <h4>Requisitos para preinscripción: </h4>

                    <p style="font-weight: bold">Alumnos provenientes del Jardín Padre Víctor:</p>
                    <p> *Datos completos del alumno ingresante: Apellido y Nombre, DNI, Fecha de Nacimiento, CUIL, Domicilio y Teléfonos.</p>
                    <p>*Datos del Padre y/o Tutor: Apellido y Nombre, DNI, CUIL, Ocupación y Teléfonos.  </p>

                    <p style="font-weight: bold">Hermanos de alumnos de la Escuela San Vicente: </p>
                    <p>*Datos completos del alumno ingresante: Apellido y Nombre, DNI, Fecha de Nacimiento, CUIL, Domicilio y Teléfonos.</p>
                    <p>*Datos del hermano que concurre a la escuela:  Apellido y Nombre, DNI y Grado.</p>
                    <p>*Datos del Padre y/o Tutor: Apellido y Nombre, DNI, Ocupación y Teléfonos.</p>

                    <p style="font-weight: bold"> Hijos del Personal de la Obra Misericordista:</p>
                    <p>*Datos completos del alumno ingresante: Apellido y Nombre, DNI, Fecha de Nacimiento, CUIL, Domicilio y Teléfonos. </p>
                    <p>*Datos del Padre y/o Madre: Apellido y Nombre, DNI, CUIL, Teléfonos, Ocupación y Colegio de la Obra donde trabaja.</p>
                    <p>*DNI del personal que trabaja en la Institución Misericordista</p>


                    <br />
                    <p style="font-weight: bold">USTED DISPONE DE DOS ALTERNATIVAS PARA INICIAR LA PRESCRIPCIÓN: </p>
                    <p>
                        1) Enviar un correo electrónico a la Secretaría de la escuela <a href="mailto:secretaria@sanvicente.edu.ar">secretaria@sanvicente.edu.ar</a>
                        mencionando los requisitos. 
                    </p>
                    <p>
                        2) En esta misma página ir a pantalla principal ASOCIACION CIVIL DE HERMANOS MISERICORDISTAS, colocar ver mas y buscar al final de la misma ESCUELA SAN VICENTE y en el icono Contacto completar el formulario y en mensaje escribir los requisitos solicitados y enviar. 
Donde dice asunto: escribir preinscripción. Donde dice mensaje: escribir los datos solicitados.
                    </p>

                      <h3>FECHA DE PREINSCRIPCION</h3>
                    <p>
                        Se debe recalcar que si no se realiza la preinscripción dentro de los plazos, se perderá la posibilidad de una vacante dentro de la institución. 
                        Se brindara ese lugar para aquellos solicitantes externos a la Obra.
                    </p>
                    <h5>
                        <p>
                            Desde el 1 de septiembre al miércoles 10 para enviar mail o mensaje a la pagina 
                        </p>
                    </h5>

                    <p >
                        Solo se preinscribirá a los ingresantes que envíen completos los requisitos solicitados y en la fecha mencionada sin excepción, caso contario perderá la vacante y la misma será ocupada con postulantes provenientes de otros jardines. Una vez completa esta instancia recibirá el instructivo para el SEGUNDO PASO que consiste en la presentación de documentación. Muchas gracias 
                    </p>

                    <br />
                    <hr class="pg2-titl-bdr-btm" />

                        <h3>SEGUNDO PASO </h3>
                    <p style="font-weight: bold">
                        Una vez recibido el mail en la Secretaria de la Escuela o bien el mensaje enviado en la pagina,
                         se le asignará un turno con fecha y hora para entregar por calle Absalón Ibarra 545 en forma presencial la siguiente documentación 
                        o en su defecto puede enviar la misma al correo  <a href="mailto:secretaria@sanvicente.edu.ar">secretaria@sanvicente.edu.ar</a>  con fotos legibles y claras de ambas caras.:
                    </p>
                    <p>-Fotocopia del DNI actualizado del alumno ingresante (frente y atrás).</p>
                    <p>-Fotocopia del DNI actualizado del hermano que asiste a la escuela (frente y atrás).</p>
                    <p>-Fotocopia del DNI del padre y/o madre si es hijo del personal de la Obra</p>
                    <p>-Fotocopia del Acta de Nacimiento.</p>
                    <p>-Fotocopia del Carnet de Vacunación con las vacunas completas. Inclusive la de ingreso escolar.</p>
               
                    <p>-Ficha de Inscripción y Médica (<a href="../Documento/FichaInscripcion.pdf"  class="icon solid fa-edit">&nbsp;Ficha de Inscripción)</a></p>
                    <p>-Ficha de salud individual. (<a href="../Documento/FichaSalud.pdf"  class="icon solid fa-edit">&nbsp;Ficha de Salud</a>)</p>
                    <p>-Carpeta colgante con visor. (Solo para matriculas presenciales)</p>
                    <p>-Folio tamaño oficio. (Solo para matriculas presenciales)</p>
                    <p>-Recibo de 2 cuotas pagadas (como mínimo) del jardín o del hermano del ingresante. </p>
                    <p>-Pago de cuotas al día de hijos del personal con hermanos en la Institución.</p>
                    <%-- <p>- En el caso que el postulante no tenga el mismo apellido del hermano que concurre al colegio se
deberá presentar foto del acta de nacimiento. Además es requerimiento indispensable que en elDNI de ambos figure el mismo domicilio.</p>--%>
                    <p></p>
                    <p style="font-weight: bold"> Se emitirá constancia de preinscripción una vez que se reciba y se controle la carpeta con toda la documentación solicitada en formato papel presentada en la Escuela o bien la de formato digital enviada al correo de Secretaria.              
                    </p>
                    <p style="font-weight: bold"> Una vez concretada la preinscripción en tiempo y forma se le comunicará la fecha para hacer efectivo el pago de la matrícula.
Luego de abonada la misma enviar la foto del comprobante al correo de la Secretaria de la Escuela para dar por concluido el tramite.                   
                    </p>

                  
                </div>
            </section>
        </article>

        <!-- Footer -->
        <footer id="footer">
            <ul class="icons">
                <li><a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>
                <li><a href="#" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
                <li><a href="#" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
                <li><a href="#" class="icon brands fa-dribbble"><span class="label">Dribbble</span></a></li>
                <li><a href="#" class="icon solid fa-envelope"><span class="label">Email</span></a></li>
            </ul>
            <ul class="copyright">

                <%--	<li> </li><li> <a href="Login.aspx" ">Intranet</a></li>--%>
            </ul>
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
