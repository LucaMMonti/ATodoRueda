<%@ Page Title="Inicio - ATodoRueda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATodoRueda._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="welcomeTitle">
            <h1 id="welcomeTitle" class="text-center">Bienvenido a ATodoRueda</h1>
            <p class="lead text-center">La forma más fácil y rápida de rentar autos en línea. Encuentra el vehículo perfecto para cada ocasión.</p>
            <div class="text-center">
                <a href="buscar-autos.aspx" class="btn btn-primary btn-lg">Reservar &raquo;</a>
            </div>
        </section>

      <section class="container-fluid p-0" class="pt-3 pb-3">
          <div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">
              <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
              </div>
              <div class="carousel-inner">
                <div class="carousel-item active" data-bs-interval="10000" style="max-height:600px">
                  <img src="https://resizer.iproimg.com/unsafe/1280x/filters:format(webp)/https://assets.iprofesional.com/assets/jpg/2020/07/499688.jpg" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>First slide label</h5>
                    <p>Some representative placeholder content for the first slide.</p>
                  </div>
                </div>
                <div class="carousel-item" data-bs-interval="2000" style="max-height:600px">
                  <img src="https://www.lanacion.com.ar/resizer/v2/nueva-toyota-hilux-S4LPOGMRMNEWXLBUZTJDM7R2A4.jpg?auth=e2f1157e76c81211c2b0065872017aa6219847b673e735c927d59487e1cda065&width=880&height=586&quality=70&smart=true" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>Second slide label</h5>
                    <p>Some representative placeholder content for the second slide.</p>
                  </div>
                </div>
                <div class="carousel-item" style="max-height:600px">
                  <img src="https://www.motor16.com/wp-content/uploads/2022/02/5225_w35FLUaq8Wt7E-p.jpg" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>Third slide label</h5>
                    <p>Some representative placeholder content for the third slide.</p>
                  </div>
                </div>
              </div>
              <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden"></span>
              </button>
              <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden"></span>
              </button>
            </div>

           
        </section>

        <section class="row mt-5">
            <div class="col-md-4">
                <h2>Autos Destacados</h2>
                <p>Explora nuestra selección de autos destacados, disponibles para renta inmediata.</p>
                <p><a class="btn btn-secondary" href="autos-destacados.aspx">Ver Autos &raquo;</a></p>
            </div>

            <div class="col-md-4">
                <h2>¿Cómo funciona?</h2>
                <p>Descubre lo fácil que es rentar tu próximo auto con nosotros. Solo elige, reserva, y disfruta tu viaje.</p>
                <p><a class="btn btn-secondary" href="como-funciona.aspx">Aprender más &raquo;</a></p>
            </div>
            <div class="col-md-4">
                <h2>Contacto</h2>
                <p>¿Tienes preguntas? Estamos aquí para ayudarte. Contacta con nuestro equipo de soporte.</p>
                <p><a class="btn btn-secondary" href="contacto.aspx">Contactar &raquo;</a></p>
            </div>
        </section>
    </main>
</asp:Content>
