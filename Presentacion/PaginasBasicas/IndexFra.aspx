<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexFra.aspx.cs" Inherits="IndexFra" %>
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
    <div class="container-fluid position-relative shadow">
        <nav class="navbar navbar-expand-lg bg-light navbar-light py-3 py-lg-0 px-0 px-lg-5">
            <a href="" class="navbar-brand font-weight-bold " style="font-size: 50px;">
                <!--<i class="flaticon-028-kindergarten"></i>-->
				<img src="../cssFranciscana/img/logo_francis_pagina.png" width="80" height="80" alt=""/> 
				<span style="font-size: 20px; color: ##3D001E; font-family:Constantia, 'Lucida Bright', 'DejaVu Serif', Georgia, 'serif'">Inst. Madre Mercedes Guerra</span>
            </a>
            <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
               
				<span class="navbar-toggler-icon"></span>
            </button>
			
            <div class="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                <div class="navbar-nav font-weight-bold mx-auto py-0">
                    <a href="indexFra.aspx" class="nav-item nav-link active" >Inicio</a>                  
                    <a href="#Niveles" class="nav-item nav-link">Niveles</a>               
                    <a href="#Nosotros" class="nav-item nav-link">Nosotros</a>
					 <%--<a href="#Proyectos" class="nav-item nav-link">Proyectos</a>--%>
					 <a href="#DondePagar" class="nav-item nav-link">Donde Pagar</a>
					<!--  /*<div class="nav-item dropdown">
                        <a href="#" class="nav-link dropdown-toggle" data-toggle="dropdown">Pages</a>
                        <div class="dropdown-menu rounded-0 m-0">
                            <a href="blog.html" class="dropdown-item">Blog Grid</a>
                            <a href="single.html" class="dropdown-item">Blog Detail</a>
                        </div>
                    </div>*/-->
                    <%--<a href="" class="nav-item nav-link">Contacto</a>--%>
                </div>
              <!--  <a href="" class="btn btn-primary px-4">Join Class</a>-->
            </div>
        </nav>
    </div>
    <!-- Navbar End -->


    <!-- Header Start -->
	 <div class="container-fluid position-relative shadow"  >
       <div style="background-color:#800040" >
        <div class="row align-items-center px-10">
			<div class="col-lg-2 text-center text-lg-left">
				</div>
            <div class="col-lg-5 text-center text-lg-left">
				<br/>
                <h4 class="text-white mb-4 mt-5 mt-lg-0">Acompañar y Compartir..</h4>
                <h1 class="display-4 font-weight-bold text-white">Aprender Juntos..</h1>
                <p class="text-white mb-4">El compromiso es ofrecer una educación cristiana, en un ambiente de familia y de trabajo en equipo y cooperación. La mayor pretensión es garantizar una educación de calidad para todos.</p>
                <a href="Historia1.aspx" class="btn btn-primary mt-1 py-2 px-5" style="background-color:white; color: black;font-weight:bold " >Historia</a>
				<br/><br/>
            </div>
            <div class="col-lg-4 text-center text-lg-right">
                <img src="../cssFranciscana/img/Mercedes Guerra.jpg" alt="" width="300" height="265" class="img-fluid mt-15">
            </div>
        </div>
      </div>
	</div>
    <!-- Header End -->


    <!-- Facilities Start -->
	  <div id="Niveles">
    <div class="container-fluid pt-5">
		 <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Niveles</span></p>
                <h1 class="mb-4">Información General </h1>
            </div>
		
        <div class="container pb-3">
            <div class="row">
                <div class="col-lg-4 col-md-6 pb-1">
                    <div class="d-flex bg-light shadow-sm border-top rounded mb-4" style="padding: 30px;">
                        <i class="flaticon-030-crayons h1 font-weight-normal text-primary mb-3 style="color:#800040" "></i>
                        <div class="pl-4">
							 <a href="NivelInicialFra.aspx" class=""><h4>Nivel Inicial</h4></a>
                            <p class="m-0">- Propuesta Educativa</p>
                            <p class="m-0">- Aranceles </p>   
                            <p class="m-0">- Uniforme </p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 pb-1">
                    <div class="d-flex bg-light shadow-sm border-top rounded mb-4" style="padding: 30px;">
                        <i class="flaticon-019-pencil h1 font-weight-normal text-primary mb-3"></i>
                        <div class="pl-4">
							<a href="" class="">  <h4>Nivel Primario</h4></a>
                           <p class="m-0">- Avisos Importantes.</p>
                            <p class="m-0">- Acceso al la plataforma. </p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 pb-1">
                    <div class="d-flex bg-light shadow-sm border-top rounded mb-4" style="padding: 30px;">
                        <i class="flaticon-035-table h1 font-weight-normal text-primary mb-3"></i>
                        <div class="pl-4">
							<a href="" class="">    <h4>Nivel Secundario</h4></a>
                          <p class="m-0">- Proyectos</p>
                            <p class="m-0">- Matriculación </p>
                        </div>
                    </div>
                </div>
                <!--<div class="col-lg-4 col-md-6 pb-1">
                    <div class="d-flex bg-light shadow-sm border-top rounded mb-4" style="padding: 30px;">
                        <i class="flaticon-017-toy-car h1 font-weight-normal text-primary mb-3"></i>
                        <div class="pl-4">
                            <h4>Safe Transportation</h4>
                            <p class="m-0">Kasd labore kasd et dolor est rebum dolor ut, clita dolor vero lorem amet elitr vero...</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 pb-1">
                    <div class="d-flex bg-light shadow-sm border-top rounded mb-4" style="padding: 30px;">
                        <i class="flaticon-025-sandwich h1 font-weight-normal text-primary mb-3"></i>
                        <div class="pl-4">
                            <h4>Healthy food</h4>
                            <p class="m-0">Kasd labore kasd et dolor est rebum dolor ut, clita dolor vero lorem amet elitr vero...</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 pb-1">
                    <div class="d-flex bg-light shadow-sm border-top rounded mb-4" style="padding: 30px;">
                        <i class="flaticon-047-backpack h1 font-weight-normal text-primary mb-3"></i>
                        <div class="pl-4">
                            <h4>Educational Tour</h4>
                            <p class="m-0">Kasd labore kasd et dolor est rebum dolor ut, clita dolor vero lorem amet elitr vero...</p>
                        </div>
                    </div>
                </div>-->
            </div>
        </div>
    </div>
	</div>
    <!-- Facilities Start -->


    <!-- About Start -->
	  <div id="Nosotros">
    <div class="container-fluid py-5">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-5">
                    <img class="img-fluid rounded mb-5 mb-lg-0" src="../cssFranciscana/img/FachadaCole.jpg" alt="">
                </div>
                <div class="col-lg-7">
                    <p class="section-title pr-5"><span class="pr-2">Nuestro Colegio</span></p>
                    <h1 class="mb-4">La mejor opción educativa</h1>
                    <p>Nuestra institucíon es un Colegio CATÓLICO , de Gestión
Privada que promueve una educación centrada en los PILARES
FRANCISCANOS.</p>
                  <p>  La escuela franciscana promueve distintos momentos de
catequesis vivencial y misionera atravesados por actividades que
estimulan el desarrollo de la interioridad y la participación en
celebraciones según el calendario litúrgico. Escuchar, observar,
imaginar, recordar y favorecer el intercambio entre pares para
experimentar el amor a Dios y a la Virgen María en clave
franciscana.</p>
                   <%-- <div class="row pt-2 pb-4">
                        <div class="col-6 col-md-4">
                            <img class="img-fluid rounded" src="img/Mercedes Guerra.jpg" alt="">
                        </div>
                        <div class="col-6 col-md-8">
                            <ul class="list-inline m-0">
                                <li class="py-2 border-top border-bottom"><i class="fa fa-check text-primary mr-3"></i>Aprender</li>
                                <li class="py-2 border-bottom"><i class="fa fa-check text-primary mr-3"></i>Sociabilizar</li>
                                <li class="py-2 border-bottom"><i class="fa fa-check text-primary mr-3"></i>Jugar</li>
                            </ul>
                        </div>
                    </div>--%>
                    <a  href="Historia1.aspx" class="btn btn-primary mt-2 py-2 px-4"   >Leer Más</a>
                </div>
            </div>
        </div>
    </div>
	</div>
    <!-- About End -->


    <!-- Class Start -->
<%--	<div id="Proyectos">
    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Ultimos Proyectos</span></p>
                <h1 class="mb-4">Asi trabajan nuestros alumnos</h1>
            </div>
            <div class="row">
                <div class="col-lg-4 mb-5">
                    <div class="card border-0 bg-light shadow-sm pb-2">
                        <img class="card-img-top mb-2" src="../cssFranciscana/img/class-1.jpg" alt="">
                        <div class="card-body text-center">
                            <h4 class="card-title">Proyecto Bimodal</h4>
                            <p class="card-text">Nuestra Institución se convierte en pionera en la implementación bimodal en las clases</p>
                        </div>
                        <div class="card-footer bg-transparent py-4 px-5">
                           
                        </div>
                        <a href="" class="btn btn-primary px-4 mx-auto mb-4"  >Leer Más..</a>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card border-0 bg-light shadow-sm pb-2">
                        <img class="card-img-top mb-2" src="../cssFranciscana/img/class-2.jpg" alt="">
                        <div class="card-body text-center">
                            <h4 class="card-title">Proyecto Lengua</h4>
                            <p class="card-text">Justo ea diam stet diam ipsum no sit, ipsum vero et et diam ipsum duo et no et, ipsum ipsum erat duo amet clita duo</p>
                        </div>
                        <div class="card-footer bg-transparent py-4 px-5">
                           
                            
                        </div>
                        <a href="" class="btn btn-primary px-4 mx-auto mb-4"  >Leer Más..</a>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card border-0 bg-light shadow-sm pb-2">
                        <img class="card-img-top mb-2" src="../cssFranciscana/img/class-3.jpg" alt="">
                        <div class="card-body text-center">
                            <h4 class="card-title">Proyecto de Ciencias</h4>
                            <p class="card-text">Justo ea diam stet diam ipsum no sit, ipsum vero et et diam ipsum duo et no et, ipsum ipsum erat duo amet clita duo</p>
                        </div>
                        <div class="card-footer bg-transparent py-4 px-5">
                          
                        </div>
                        <a href="" class="btn btn-primary px-4 mx-auto mb-4" >Leer Más..</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
	</div>--%>
    <!-- Class End -->


   <!--  Registration Start -->
 <!--  /*   <div class="container-fluid py-5">
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
    </div>*/-->
    <!-- Registration End -->


    <!-- Team Start -->
   <!--    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Our Teachers</span></p>
                <h1 class="mb-4">Meet Our Teachers</h1>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-3 text-center team mb-5">
                    <div class="position-relative overflow-hidden mb-4" style="border-radius: 100%;">
                        <img class="img-fluid w-100" src="img/team-1.jpg" alt="" >
                        <div
                            class="team-social d-flex align-items-center justify-content-center w-100 h-100 position-absolute">
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-twitter"></i></a>
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-facebook-f"></i></a>
                            <a class="btn btn-outline-light text-center px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-linkedin-in"></i></a>
                        </div>
                    </div>
                    <h4>Julia Smith</h4>
                    <i>Music Teacher</i>
                </div>
                <div class="col-md-6 col-lg-3 text-center team mb-5">
                    <div class="position-relative overflow-hidden mb-4" style="border-radius: 100%;">
                        <img class="img-fluid w-100" src="img/team-2.jpg" alt="" >
                        <div
                            class="team-social d-flex align-items-center justify-content-center w-100 h-100 position-absolute">
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-twitter"></i></a>
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-facebook-f"></i></a>
                            <a class="btn btn-outline-light text-center px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-linkedin-in"></i></a>
                        </div>
                    </div>
                    <h4>Jhon Doe</h4>
                    <i>Language Teacher</i>
                </div>
                <div class="col-md-6 col-lg-3 text-center team mb-5">
                    <div class="position-relative overflow-hidden mb-4" style="border-radius: 100%;">
                        <img class="img-fluid w-100" src="img/team-3.jpg" alt="" >
                        <div
                            class="team-social d-flex align-items-center justify-content-center w-100 h-100 position-absolute">
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-twitter"></i></a>
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-facebook-f"></i></a>
                            <a class="btn btn-outline-light text-center px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-linkedin-in"></i></a>
                        </div>
                    </div>
                    <h4>Mollie Ross</h4>
                    <i>Dance Teacher</i>
                </div>
                <div class="col-md-6 col-lg-3 text-center team mb-5">
                    <div class="position-relative overflow-hidden mb-4" style="border-radius: 100%;">
                        <img class="img-fluid w-100" src="img/team-4.jpg" alt="" >
                        <div
                            class="team-social d-flex align-items-center justify-content-center w-100 h-100 position-absolute">
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-twitter"></i></a>
                            <a class="btn btn-outline-light text-center mr-2 px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-facebook-f"></i></a>
                            <a class="btn btn-outline-light text-center px-0" style="width: 38px; height: 38px;"
                                href="#"><i class="fab fa-linkedin-in"></i></a>
                        </div>
                    </div>
                    <h4>Donald John</h4>
                    <i>Art Teacher</i>
                </div>
            </div>
        </div>
    </div>-->
    <!-- Team End -->


    <!-- Testimonial Start -->
<!--   <div class="container-fluid py-5">
        <div class="container p-0">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Testimonios</span></p>
                <h1 class="mb-4">Que dicen los Papás..</h1>
            </div>
            <div class="owl-carousel testimonial-carousel">
                <div class="testimonial-item px-3">
                    <div class="bg-light shadow-sm rounded mb-4 p-4">
                        <h3 class="fas fa-quote-left text-primary mr-3"></h3>
                        Sed ea amet kasd elitr stet, stet rebum et ipsum est duo elitr eirmod clita lorem. Dolor tempor ipsum clita
                    </div>
                    <div class="d-flex align-items-center">
                        <img class="rounded-circle" src="img/testimonial-1.jpg" style="width: 70px; height: 70px;" alt="Image">
                        <div class="pl-3">
                            <h5>Parent Name</h5>
                            <i>Profession</i>
                        </div>
                    </div>
                </div>
                <div class="testimonial-item px-3">
                    <div class="bg-light shadow-sm rounded mb-4 p-4">
                        <h3 class="fas fa-quote-left text-primary mr-3"></h3>
                        Sed ea amet kasd elitr stet, stet rebum et ipsum est duo elitr eirmod clita lorem. Dolor tempor ipsum clita
                    </div>
                    <div class="d-flex align-items-center">
                        <img class="rounded-circle" src="img/testimonial-2.jpg" style="width: 70px; height: 70px;" alt="Image">
                        <div class="pl-3">
                            <h5>Parent Name</h5>
                            <i>Profession</i>
                        </div>
                    </div>
                </div>
                <div class="testimonial-item px-3">
                    <div class="bg-light shadow-sm rounded mb-4 p-4">
                        <h3 class="fas fa-quote-left text-primary mr-3"></h3>
                        Sed ea amet kasd elitr stet, stet rebum et ipsum est duo elitr eirmod clita lorem. Dolor tempor ipsum clita
                    </div>
                    <div class="d-flex align-items-center">
                        <img class="rounded-circle" src="img/testimonial-3.jpg" style="width: 70px; height: 70px;" alt="Image">
                        <div class="pl-3">
                            <h5>Parent Name</h5>
                            <i>Profession</i>
                        </div>
                    </div>
                </div>
                <div class="testimonial-item px-3">
                    <div class="bg-light shadow-sm rounded mb-4 p-4">
                        <h3 class="fas fa-quote-left text-primary mr-3"></h3>
                        Sed ea amet kasd elitr stet, stet rebum et ipsum est duo elitr eirmod clita lorem. Dolor tempor ipsum clita
                    </div>
                    <div class="d-flex align-items-center">
                        <img class="rounded-circle" src="img/testimonial-4.jpg" style="width: 70px; height: 70px;" alt="Image">
                        <div class="pl-3">
                            <h5>Parent Name</h5>
                            <i>Profession</i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>-->
    <!-- Testimonial End -->


    <!-- Blog Start -->
	<div id="DondePagar">
    <div class="container-fluid pt-5">
        <div class="container">
            <div class="text-center pb-2">
                <p class="section-title px-5"><span class="px-2">Donde Pagar</span></p>
                <h1 class="mb-4">Opciones </h1>
            </div>
            <div class="row pb-3">
                <div class="col-lg-4 mb-4">
                    <div class="card border-0 shadow-sm mb-2">
                      <!--  <img class="card-img-top mb-2" src="img/blog-1.jpg" alt="">-->
                        <div class="card-body bg-light text-center p-4">
                            <h4 class="">Caja Municipal</h4>
                          <!-- <div class="d-flex justify-content-center mb-3">
                                <small class="mr-3"><i class="fa fa-user text-primary"></i> Admin</small>
                                <small class="mr-3"><i class="fa fa-folder text-primary"></i> Web Design</small>
                                <small class="mr-3"><i class="fa fa-comments text-primary"></i> 15</small>
                            </div>-->
                           <!-- <p>Sed kasd sea sed at elitr sed ipsum justo, sit nonumy diam eirmod, duo et sed sit eirmod kasd clita tempor dolor stet lorem. Tempor ipsum justo amet stet...</p>
                            <a href="" class="btn btn-primary px-4 mx-auto my-2">Leer más..</a>-->
							 <p>Debe llevar la chequera entregada oportunamente al alumno</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-4">
                    <div class="card border-0 shadow-sm mb-2">
                     <!--   <img class="card-img-top mb-2" src="img/blog-2.jpg" alt="">-->
                        <div class="card-body bg-light text-center p-4">
                            <h4 class="">Transferencia Bancaria</h4>
                          <!-- <div class="d-flex justify-content-center mb-3">
                                <small class="mr-3"><i class="fa fa-user text-primary"></i> Admin</small>
                                <small class="mr-3"><i class="fa fa-folder text-primary"></i> Web Design</small>
                                <small class="mr-3"><i class="fa fa-comments text-primary"></i> 15</small>
                            </div>-->
                            <p>CTA CTE BSE:</p>
							<p>	CBU:321000113001200782195 </p>
							<p>ALIAS: LIMITE.LIRIO.ARROYO </p>
                            <!--<a href="" class="btn btn-primary px-4 mx-auto my-2">Leer más..</a>-->
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-4">
                    <div class="card border-0 shadow-sm mb-2">
                       <!-- <img class="card-img-top mb-2" src="img/blog-3.jpg" alt="">-->
                        <div class="card-body bg-light text-center p-4">
                            <h4 class="">Administración del Colegio</h4>
                           <!--/* <div class="d-flex justify-content-center mb-3">
                                <small class="mr-3"><i class="fa fa-user text-primary"></i> Admin</small>
                                <small class="mr-3"><i class="fa fa-folder text-primary"></i> Web Design</small>
                                <small class="mr-3"><i class="fa fa-comments text-primary"></i> 15</small>
                            </div>*/-->
                            <p>Solo debe traer el DNI del alumno</p>
                          <!--  <a href="" class="btn btn-primary px-4 mx-auto my-2">Leer más..</a>-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
	</div>
    <!-- Blog End -->


    <!-- Footer Start -->
		 <div class="container-fluid position-relative shadow"  >
   <div class="container-fluid   mt-5 py-5 px-sm-3 px-md-5" style="background-color:#800040">
        <div class="row pt-5" >
			   <div class="col-lg-1 col-md-6 mb-5">
               
            </div>
            <div class="col-lg-3 col-md-6 mb-5">
                <a href="" class="navbar-brand font-weight-bold text-primary m-0 mb-4 p-0" style="font-size: 40px; line-height: 40px; color: #FFFFFF">
                   <!--  <i class="flaticon-043-teddy-bear"></i>-->
                    <h3 style="color: white">Inst. Mercedes Guerra</h3>
                </a>
                <p style="color: white">Brindamos una educación integral, en todos sus niveles, procurando que la formación espiritual y académica acompañe a los principios de la filosofía franciscana</p>
                <div class="d-flex justify-content-start mt-4" style="color: white">
<%--                    <a class="btn btn-outline-primary rounded-circle text-center mr-2 px-0"
                        style="width: 38px; border-color: : #FFFFFF; height: 38px;" href="#"><i class="fab fa-twitter" style="color: #FFFFFF"></i></a>
                    <a class="btn btn-outline-primary rounded-circle text-center mr-2 px-0"
                        style="width: 38px; height: 38px;" href="#"><i class="fab fa-facebook-f" style="color: #FFFFFF"></i></a>
                 
                    <a class="btn btn-outline-primary rounded-circle text-center mr-2 px-0"
                        style="width: 38px; height: 38px;" href="#"><i class="fab fa-instagram" style="color: #FFFFFF"></i></a>--%>
                </div>
            </div> <div class="col-lg-1 col-md-6 mb-5">
               
            </div>
          <div class="col-lg-4 col-md-6 mb-5">
                <h3 style="color: white">Contacto</h3>
                <br />  <div class="d-flex">
                    <h4 class="fa fa-map-marker-alt " style="color: white"></h4>
                    <div class="pl-3">
                        <h5 class="text-white">Dirección</h5>
                        <p style="color: white">Av. Belgrano Sur 291, Santiago del Estero</p>
                    </div>
                </div>
               <%-- <div class="d-flex">
                    <h4 class="fa fa-envelope" style="color: white"></h4>
                    <div class="pl-3">
                        <h5 class="text-white">Email</h5>
                        <p style="color: white">info@example.com</p>
                    </div>
                </div>--%>
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
                <br />  <div class="d-flex flex-column justify-content-start">
                    <a class="text-white mb-2" href="IndexFra.aspx"><i class="fa fa-angle-right mr-2"></i>Inicio</a>
                    <a class="text-white mb-2" href="#Nosotros"><i class="fa fa-angle-right mr-2"></i>Nosotros</a>
                    <a class="text-white mb-2" href="#Niveles"><i class="fa fa-angle-right mr-2"></i>Niveles</a>
<%--                    <a class="text-white mb-2" href="#"><i class="fa fa-angle-right mr-2"></i>Galeria</a>
                    <a class="text-white mb-2" href="#"><i class="fa fa-angle-right mr-2"></i>Contacto</a>--%>
               
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
        <div class="container-fluid pt-5" style="border-top: 1px solid rgba(23, 162, 184, .2);;">
            <p class="m-0 text-center text-white">
                &copy; <a class="font-weight-bold" href="#" style="color: white">Franciscana 2021</a> 
            <%--    Designed
                by
                <a class="font-weight-bold" href="https://htmlcodex.com" style="color: white">xxxxxx</a>--%>
            </p>
        </div>
    </div>
		 </div> </div>
    <!-- Footer End -->


    <!-- Back to Top -->
    <a href="#" class="btn btn-primary p-3 back-to-top" style="background-color:#800040"><i class="fa fa-angle-double-up"></i></a>


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
	 <script >
	$(document).ready(function() {
  $('a[href^="#"]').click(function() {
    var destino = $(this.hash);
    if (destino.length == 0) {
      destino = $('a[name="' + this.hash.substr(1) + '"]');
    }
    if (destino.length == 0) {
      destino = $('html');
    }
    $('html, body').animate({ scrollTop: destino.offset().top }, 500);
    return false;
  });
});
	</script>
	
</body>

</html>