<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GaleriaFra.aspx.cs" Inherits="PaginasBasicas_GaleriaFra" %>

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
                <span style="font-size: 20px; color: ##3D001E; font-family: Constantia, 'Lucida Bright', 'DejaVu Serif', Georgia, 'serif'">Inst. Madre Mercedes Guerra</span>
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
                    <a href="Aclases.aspx" class="nav-item nav-link">A clases!</a>
                    <a href="GaleriaFra.aspx" class="nav-item nav-link active">Galeria</a>
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
            <h3 class="display-3 font-weight-bold text-white">Galeria</h3>
            <div class="d-inline-flex text-white">
                <p class="m-0"><a class="text-white" href="indexFra.aspx">Inicio</a></p>
                <p class="m-0 px-2">/</p>
                <p class="m-0">Galeria</p>
            </div>
        </div>
    </div>
  
    <!-- Header End -->


    <!-- Gallery Start -->
    <div class="container-fluid pt-5 pb-3">
        <div class="container">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Nuestra Galeria</span></p>
                <h1 class="mb-4">Nivel Inicial</h1>
            </div>
            <div class="row">
                <div class="col-12 text-center mb-2">
                    <ul class="list-inline mb-4" id="portfolio-flters">
                        <li class="btn btn-outline-primary m-1 active" data-filter="*">Todo</li>
                        <li class="btn btn-outline-primary m-1" data-filter=".first">Salita 3</li>
                        <li class="btn btn-outline-primary m-1" data-filter=".second">Salita 4</li>
                        <li class="btn btn-outline-primary m-1" data-filter=".third">Salita 5</li>
                    </ul>
                </div>
            </div>
            <div class="row portfolio-container">
                <div class="col-lg-4 col-md-6 mb-4 portfolio-item first">
                    <div class="position-relative overflow-hidden mb-2">
                        <img class="img-fluid w-100" src="../cssFranciscana/img/ScreenHunter_75 Oct. 17 20.35.jpg" alt="">
                        <div class="portfolio-btn bg-primary d-flex align-items-center justify-content-center">
                            <a href="../cssFranciscana/img/ScreenHunter_75 Oct. 17 20.35.jpg" data-lightbox="portfolio">
                                <i class="fa fa-plus text-white" style="font-size: 60px;"></i>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4 portfolio-item second">
                    <div class="position-relative overflow-hidden mb-2">
                        <img class="img-fluid w-100" src="../cssFranciscana/img/ScreenHunter_76 Oct. 17 20.35.jpg" alt="">
                        <div class="portfolio-btn bg-primary d-flex align-items-center justify-content-center">
                            <a href="../cssFranciscana/img/ScreenHunter_76 Oct. 17 20.35.jpg" data-lightbox="portfolio">
                                <i class="fa fa-plus text-white" style="font-size: 40px;"></i>
                            </a>
                        </div>
                    </div>
                </div>
                <%-- <div class="col-lg-4 col-md-6 mb-4 portfolio-item third">
                    <div class="position-relative overflow-hidden mb-2">
                        <img class="img-fluid w-100" src="../cssFranciscana/img/portfolio-3.jpg" alt="">
                        <div class="portfolio-btn bg-primary d-flex align-items-center justify-content-center">
                            <a href="img/portfolio-3.jpg" data-lightbox="portfolio">
                                <i class="fa fa-plus text-white" style="font-size: 60px;"></i>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4 portfolio-item first">
                    <div class="position-relative overflow-hidden mb-2">
                        <img class="img-fluid w-100" src="../cssFranciscana/img/portfolio-4.jpg" alt="">
                        <div class="portfolio-btn bg-primary d-flex align-items-center justify-content-center">
                            <a href="img/portfolio-4.jpg" data-lightbox="portfolio">
                                <i class="fa fa-plus text-white" style="font-size: 60px;"></i>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4 portfolio-item second">
                    <div class="position-relative overflow-hidden mb-2">
                        <img class="img-fluid w-100" src="../cssFranciscana/img/portfolio-5.jpg" alt="">
                        <div class="portfolio-btn bg-primary d-flex align-items-center justify-content-center">
                            <a href="img/portfolio-5.jpg" data-lightbox="portfolio">
                                <i class="fa fa-plus text-white" style="font-size: 60px;"></i>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4 portfolio-item third">
                    <div class="position-relative overflow-hidden mb-2">
                        <img class="img-fluid w-100" src="../cssFranciscana/img/portfolio-6.jpg" alt="">
                        <div class="portfolio-btn bg-primary d-flex align-items-center justify-content-center">
                            <a href="img/portfolio-6.jpg" data-lightbox="portfolio">
                                <i class="fa fa-plus text-white" style="font-size: 60px;"></i>
                            </a>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>

        <!-- Gallery End -->


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
                    <div class="d-flex flex-column justify-content-start">
                        <a class="text-white mb-2" href="IndexFra.aspx"><i class="fa fa-angle-right mr-2"></i>Inicio</a>
                        <a class="text-white mb-2" href="Historia1.aspx"><i class="fa fa-angle-right mr-2"></i>Nosotros</a>
                        <%--<a class="text-white mb-2" href="#"><i class="fa fa-angle-right mr-2"></i>Niveles</a>--%>
                        <a class="text-white mb-2" href="GaleriaFra.aspx"><i class="fa fa-angle-right mr-2"></i>Galeria</a>
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
                    &copy; <a class="font-weight-bold" href="#" style="color: white">Franciscana 2021</a> Designed
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
