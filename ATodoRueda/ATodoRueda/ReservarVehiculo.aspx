<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarVehiculo.aspx.cs" Inherits="ATodoRueda.ReservarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensajeExito" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
    <asp:Label ID="lblMensajeError" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

        <div class="vehiculo-detalle">
        <!-- Detalles del vehículo -->
        <h2>Reservar Vehículo</h2>
        <img src="" id="imgVehiculo" runat="server" alt="Imagen Vehículo" />
        <h3 id="lblMarcaModelo" runat="server"></h3>
        <p id="lblPrecioPorDia" runat="server"></p>
        <p id="lblDescripcion" runat="server"></p>
        
        <!-- Formulario de reserva -->
        <h4>Selecciona las fechas de reserva:</h4>
        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" placeholder="Fecha inicio"></asp:TextBox>
        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" placeholder="Fecha fin"></asp:TextBox>
        <asp:TextBox ID="txtCodigoPromocion" runat="server" CssClass="form-control" placeholder="Código de promoción"></asp:TextBox>
        <asp:Button ID="btnReservar" runat="server" Text="Reservar" OnClick="btnReservar_Click" CssClass="btn btn-primary" />
    </div>

</asp:Content>
