<%@ Page Title="Inicio - ATodoRueda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATodoRueda._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="welcomeTitle">
            <h1 id="welcomeTitle" class="text-center">Bienvenido a ATodoRueda</h1>
            <p class="lead text-center">La forma más fácil y rápida de rentar autos en línea. Encuentra el vehículo perfecto para cada ocasión.</p>
            <div class="text-center">
                <a href="buscar-autos.aspx" class="btn btn-primary btn-lg">Buscar Autos &raquo;</a>
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
