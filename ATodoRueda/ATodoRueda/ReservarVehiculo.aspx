<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarVehiculo.aspx.cs" Inherits="ATodoRueda.ReservarVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensajeExito" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
    <asp:Label ID="lblMensajeError" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

    <div class="container mt-4">
        <h2>Reservar Vehículo</h2>
        <div class="row">
            <div class="col-md-6">
                <img src="" id="imgVehiculo" runat="server" alt="Imagen Vehículo" class="img-fluid" />
                <h3 id="lblMarcaModelo" runat="server"></h3>
                <p id="lblPrecioPorDia" runat="server"></p>
                <p id="lblDescripcion" runat="server"></p>
            </div>
            <div class="col-md-6">
                <div class="formulario-reserva">
                    <h4>Selecciona las fechas de reserva:</h4>
                    <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control mb-2" placeholder="Fecha inicio" TextMode="Date"></asp:TextBox>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control mb-2" placeholder="Fecha fin" TextMode="Date"></asp:TextBox>
                    <asp:TextBox ID="txtCodigoPromocion" runat="server" CssClass="form-control mb-2" placeholder="Código de promoción"></asp:TextBox>
                    <asp:Button ID="btnReservar" runat="server" Text="Reservar" OnClick="btnReservar_Click" CssClass="btn btn-primary mt-2" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
