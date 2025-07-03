<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Aclases.aspx.cs" Inherits="PaginasBasicas_Aclases" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Instituto Madre Mercedes Guerra</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="Free HTML Templates" name="keywords">
    <meta content="Free HTML Templates" name="description">

    <!-- Favicon -->
    <link href="../cssFranciscana/img/logo_francis_pagina.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Handlee&family=Nunito&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <!-- Flaticon Font -->
    <link href="../cssFranciscana/lib/flaticon/font/flaticon.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="../cssFranciscana/lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="../cssFranciscana/lib/lightbox/css/lightbox.min.css" rel="stylesheet">

    <!-- Customized Bootstrap Stylesheet -->
    <link href="../cssFranciscana/css/style.css" rel="stylesheet">
</head>

<body>
    <!-- Navbar Start -->
    <div class="container-fluid bg-light position-relative shadow">
        <nav class="navbar navbar-expand-lg bg-light navbar-light py-3 py-lg-0 px-0 px-lg-5">
            <a href="" class="navbar-brand font-weight-bold text-secondary" style="font-size: 50px;">
                <!--<i class="flaticon-028-kindergarten"></i>-->
                <img src="../cssFranciscana/img/logo_francis_pagina.png" width="80" height="80" alt="" />
                <span style="font-size: 20px; color: #3D001E; font-family: Constantia, 'Lucida Bright', 'DejaVu Serif', Georgia, 'serif'">Inst. Madre Mercedes Guerra</span>
            </a>
            <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                <div class="navbar-nav font-weight-bold mx-auto py-0">
                    <a href="indexFra.aspx" class="nav-item nav-link">Inicio</a>
                    <!--  <a href="about.html" class="nav-item nav-link">Nosotros</a>-->
                    <a href="NivelInicialFra.aspx" class="nav-item nav-link">Nivel</a>
                    <a href="ArancelesInicialFra.aspx" class="nav-item nav-link">Aranceles</a>
                    <a href="Aclases.aspx" class="nav-item nav-link active">A clases!</a>
                    <a href="GaleriaFra.aspx" class="nav-item nav-link">Galeria</a>
                    <!--  /*<div class="nav-item dropdown">
                        <a href="#" class="nav-link dropdown-toggle" data-toggle="dropdown">Pages</a>
                        <div class="dropdown-menu rounded-0 m-0">
                            <a href="blog.html" class="dropdown-item">Blog Grid</a>
                            <a href="single.html" class="dropdown-item">Blog Detail</a>
                        </div>
                    </div>*/-->
                    <%--<a href="" class="nav-item nav-link">Contacto</a>--%>
                </div>
            </div>
        </nav>
    </div>
    <!-- Navbar End -->


    <!-- Header Start -->
    <div style="background-color: #800040">
        <div class="d-flex flex-column align-items-center justify-content-center" style="min-height: 200px">
            <h3 class="display-3 font-weight-bold text-white">Nivel Inicial</h3>
            <div class="d-inline-flex text-white">
                <p class="m-0"><a class="text-white" href="indexFra.aspx">Inicio</a></p>
                <p class="m-0 px-2">/</p>
                <p class="m-0">¡A clases!</p>
            </div>
        </div>
    </div>
    <!-- Header End -->
     <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">¿Qué necesito?</span></p>
                <h3 class="mb-4">UNIFORMES</h3>
            </div>
            <div class="col-lg-12 mb-12" align="justify">
                <div>
                    <img src="../cssFranciscana/img/ScreenHunter_75%20Oct.%2017%2020.35.jpg" width="300" style="float: left; margin-right: 30px; margin-bottom: 20px" /></div>
                <p>
                    Pintor cuadrille bordo y blanco, cuello en punta niños y cuello
redondo en niñas. Bolsillo con el nombre del niño/a bordado o
pintado. Debajo, cualquier ropa cómoda y de fácil manipulación para
los niños, preferentemente pantalones con elástico o tipo joggings. El
calzado, zapatillas con abrojos.
                </p>
                <p>
                    Para educación física: Días fríos joggins bordo con
camiseta/remera/polera blanca. Días cálidos short bordo con remera
blanca (no hace falta estar bordada con logo del colegio). Zapatillas
cómodas y preferentemente con abrojo. Camperas ETIQUETADAS con
el nombre y apellido del niño/a
                </p>
                <p>
                    Barbijo: Se solicitara el uso del barbijo a todos los niños, hasta tener
conocimiento de nuevas medidas sanitarias. En salas de 3 años y 4
años, se iniciara a los niños en la incorporación del habito y del
cuidado de la salud por medio de este elemento.
                </p>

            </div>
        </div>

    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
        <%--        <p class="section-title px-5"><span class="px-2">¿Qué necesito?</span></p>--%>
                <h3 class="mb-4">ELEMENTOS PARA CLASES</h3>
            </div>
            <p>
                Mochila a elección del Niño/a ( preferentemente sin carrito, mejor de
espalda) dentro se colocará vaso y plato irrompible, individual pequeño
de tela.
            </p>
            <p>
                Refrigerio o merienda comidita saludable. Los primeros días podrán
llevar cualquier colación (NO GOLOSINAS). Posteriormente las
docentes enviaran un "Menú Saludable" que todos deberán cumplir.
            </p>
            <p>Kit Sanitizante: pañuelos descartables y alcohol en gel o al %70</p>

        </div>
    </div>

    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Se Recomienda</span></p>
                <%--<h3 class="mb-4">ELEMENTOS PARA CLASES:</h3>--%>
            </div>

            <p>Colocar nombre del Niño/a en etiquetas de buzos y camperas.</p>
            <p>
                Colocar nombre en todos los elementos mencionados (mochila, plato,
individual)
            </p>

        </div>
    </div>


    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <%--<p class="section-title px-5"><span class="px-2">Comunicación</span></p>--%>
                <h3 class="mb-4">MATERIALES</h3>
            </div>

            <p>
                Clases Presenciales: A comienzos de clases las docentes enviaran a los
tutores una lista con los materiales de trabajo requeridos
            </p>
            <p>
                Clases Virtuales: Si en caso de que por medidas de índole sanitaria
ocurre , nuevamente, un aislamiento social preventivo o clases
modalidad por burbuja, se preverá de materiales para el hogar
            </p>

        </div>
    </div>

    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <%--<p class="section-title px-5"><span class="px-2">Comunicación</span></p>--%>
                <h3 class="mb-4">RECOMENDACIONES</h3>
            </div>
            <div>
                <img src="../cssFranciscana/img/ScreenHunter_76%20Oct.%2017%2020.35.jpg" width="300" style="float: left; margin-right: 30px; margin-bottom: 20px" />
            </div>

            <p>
                Sea amable y respetuoso en el trato con todo el personal de la
institución.
            </p>
            <p>
                Los alumnos deben asistir a clase de manera prolija, y respetando el
uniforme escolar.
            </p>
            <p>
                Participe de las propuestas institucionales y lea atentamente toda la
información que se envié por los medios de comunicación designados
ya que una vez publicada no podrá aducir desconocimiento de dichas
noticias, notificaciones y/o informaciones.
            </p>
            <p>
                Comunique a la docente o a la dirección si llega tarde a buscar a su
hijo.
            </p>
            <p>
                Comunique a la docente o a la dirección si autoriza a una persona , que
no concurre habitualmente, a retirar a su hija/o. De forma contraria,
esta persona, no podrá retirar al niño/a
            </p>
            <p>
                Este atento a los requerimientos o comunicación de la institución en el
horario que el niño/a asista a la institución.
            </p>
            <p>
                Los niños enfermos o con síntomas de COVID no podrán asistir a la
institución. A su regreso deberán contar con el alta medica emitida por
su pediatra.
            </p>
            <p>
                En caso de que el niño o un miembro de su familia posea síntomas de
COVID o sea contacto estrecho, deberá aislarse inmediatamente (10
días). No espere el resultado del hisopado para aislarse.
            </p>
            <p>
                Los niños con necesidades especiales y apoyo para la integración
escolar deberán ser acompañados por el profesional competente
            </p>
            <p>
                Utilice siempre los medios de comunicación indicados. La institución
no podrá intervenir en conflictos entre padres que se ocasionen fuera
de la institución escolar
            </p>

        </div>
    </div>

    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <%--<p class="section-title px-5"><span class="px-2">Comunicación</span></p>--%>
                <h3 class="mb-4">RECORDEMOS</h3>
            </div>

            <p>
                Acompañar con FE la educación de los mas pequeños imitando el
ejemplo de Madre Mercedes y San Francisco
            </p>
            <p>
                Cumplir con las normas de buen trato para la sana convivencia
escolar
            </p>
            <p>Estar al dÍa con el contrato administrativo (pago de cuotas)</p>

        </div>
    </div>
    <!-- Class End -->


    <!-- Registration Start -->
    <!--  <div class="container-fluid py-5">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-7 mb-5 mb-lg-0">
                    <p class="section-title pr-5"><span class="pr-2">Book A Seat</span></p>
                    <h1 class="mb-4">Book A Seat For Your Kid</h1>
                    <p>Invidunt lorem justo sanctus clita. Erat lorem labore ea, justo dolor lorem ipsum ut sed eos,
                        ipsum et dolor kasd sit ea justo. Erat justo sed sed diam. Ea et erat ut sed diam sea ipsum est
                        dolor</p>
                    <ul class="list-inline m-0">
                        <li class="py-2"><i class="fa fa-check text-success mr-3"></i>Labore eos amet dolor amet diam</li>
                        <li class="py-2"><i class="fa fa-check text-success mr-3"></i>Etsea et sit dolor amet ipsum</li>
                        <li class="py-2"><i class="fa fa-check text-success mr-3"></i>Diam dolor diam elitripsum vero.</li>
                    </ul>
                    <a href="" class="btn btn-primary mt-4 py-2 px-4">Book Now</a>
                </div>
                <div class="col-lg-5">
                    <div class="card border-0">
                        <div class="card-header bg-secondary text-center p-4">
                            <h1 class="text-white m-0">Book A Seat</h1>
                        </div>
                        <div class="card-body rounded-bottom bg-primary p-5">
                            <form>
                                <div class="form-group">
                                    <input type="text" class="form-control border-0 p-4" placeholder="Your Name" required="required" />
                                </div>
                                <div class="form-group">
                                    <input type="email" class="form-control border-0 p-4" placeholder="Your Email" required="required" />
                                </div>
                                <div class="form-group">
                                    <select class="custom-select border-0 px-4" style="height: 47px;">
                                        <option selected>Select A Class</option>
                                        <option value="1">Class 1</option>
                                        <option value="2">Class 1</option>
                                        <option value="3">Class 1</option>
                                    </select>
                                </div>
                                <div>
                                    <button class="btn btn-secondary btn-block border-0 py-3" type="submit">Book Now</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>-->
    <!-- Footer Start -->

    <div class="container-fluid   mt-5 py-5 px-sm-3 px-md-5" style="background-color: #800040">
        <div class="row pt-5">
            <div class="col-lg-1 col-md-6 mb-5">
            </div>
            <div class="col-lg-3 col-md-6 mb-5">
                <a href="" class="navbar-brand font-weight-bold text-primary m-0 mb-4 p-0" style="font-size: 40px; line-height: 40px; color: #FFFFFF">
                    <!--  <i class="flaticon-043-teddy-bear"></i>-->
                    <h3 style="color: white">Inst. Mercedes Guerra</h3>
                </a>
                <p style="color: white">Brindamos una educación integral, en todos sus niveles, procurando que la formación espiritual y académica acompañe a los principios de la filosofía franciscana</p>
                <div class="d-flex justify-content-start mt-4" style="color: white">
                    <a class="btn btn-outline-primary rounded-circle text-center mr-2 px-0"
                        style="width: 38px; border-color: : #FFFFFF; height: 38px;" href="#"><i class="fab fa-twitter" style="color: #FFFFFF"></i></a>
                    <a class="btn btn-outline-primary rounded-circle text-center mr-2 px-0"
                        style="width: 38px; height: 38px;" href="#"><i class="fab fa-facebook-f" style="color: #FFFFFF"></i></a>

                    <a class="btn btn-outline-primary rounded-circle text-center mr-2 px-0"
                        style="width: 38px; height: 38px;" href="#"><i class="fab fa-instagram" style="color: #FFFFFF"></i></a>
                </div>
            </div>
            <div class="col-lg-1 col-md-6 mb-5">
            </div>
            <div class="col-lg-4 col-md-6 mb-5">
                <h3 style="color: white">Contacto</h3>
                <br />
                <div class="d-flex">
                    <h4 class="fa fa-map-marker-alt " style="color: white"></h4>
                    <div class="pl-3">
                        <h5 class="text-white">Dirección</h5>
                        <p style="color: white">Saenz Peña 43, Capital, Santiago del Estero</p>
                    </div>
                </div>
                <div class="d-flex">
                    <h4 class="fa fa-envelope" style="color: white"></h4>
                    <div class="pl-3">
                        <h5 class="text-white">Email</h5>
                        <p style="color: white">secretariainicialmmguerra@gmail.com</p>
                    </div>
                </div>
                <div class="d-flex">
                    <h4 class="fa fa-phone-alt " style="color: white"></h4>
                    <div class="pl-3">
                        <h5 class="text-white">Teléfono</h5>
                        <p style="color: white">0385 421-1187</p>
                    </div>
                </div>
            </div>
            <div class="col-lg-2 col-md-6 mb-5">
                <h3 style="color: white">Web</h3>
                <br />
                <div class="d-flex flex-column justify-content-start">
                    <a class="text-white mb-2" href="IndexFra.aspx"><i class="fa fa-angle-right mr-2"></i>Inicio</a>
                    <a class="text-white mb-2" href="Historia1.aspx"><i class="fa fa-angle-right mr-2"></i>Nosotros</a>
                    <%--<a class="text-white mb-2" href="#"><i class="fa fa-angle-right mr-2"></i>Niveles</a>--%>
                    <%--<a class="text-white mb-2" href="GaleriaFra.aspx"><i class="fa fa-angle-right mr-2"></i>Galeria</a>--%>
                    <%--<a class="text-white mb-2" href="#"><i class="fa fa-angle-right mr-2"></i>Contacto</a>--%>
                </div>
            </div>
            <!-- <div class="col-lg-4 col-md-6 mb-5">
                <h3 class="text-primary mb-4">Mail</h3>
                <form action="">
                    <div class="form-group">
                        <input type="text" class="form-control border-0 py-4" placeholder="Tu Nombre" required="required" />
                    </div>
                    <div class="form-group">
                        <input type="email" class="form-control border-0 py-4" placeholder="Tu Mail"
                            required="required" />
                    </div>
					  <div class="form-group">
                        <input type="email" class="form-control border-0 py-4" placeholder="Mensaje"
                            required="required" />
                    </div>
                    <div>
                        <button class="btn btn-primary btn-block border-0 py-3" type="submit">Enviar</button>
                    </div>
                </form>
            </div>-->
        </div>
        <div class="container-fluid pt-5" style="border-top: 1px solid rgba(23, 162, 184, .2);">
            <p class="m-0 text-center text-white">
                &copy; <a class="font-weight-bold" href="#" style="color: white">Franciscana 2021</a>
                <%--    Designed--%>
                <%-- by
                <a class="font-weight-bold" href="" style="color: white">xxxxxx</a>--%>
            </p>
        </div>
    </div>
    </div>
    <!-- Footer End -->


    <!-- Back to Top -->
    <a href="#" class="btn btn-primary p-3 back-to-top"><i class="fa fa-angle-double-up"></i></a>


    <!-- JavaScript Libraries -->
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="../cssFranciscana/lib/easing/easing.min.js"></script>
    <script src="../cssFranciscana/lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="../cssFranciscana/lib/isotope/isotope.pkgd.min.js"></script>
    <script src="../cssFranciscana/lib/lightbox/js/lightbox.min.js"></script>

    <!-- Contact Javascript File -->
    <script src="../cssFranciscana/mail/jqBootstrapValidation.min.js"></script>
    <script src="../cssFranciscana/mail/contact.js"></script>

    <!-- Template Javascript -->
    <script src="../cssFranciscana/js/main.js"></script>
</body>

</html>
