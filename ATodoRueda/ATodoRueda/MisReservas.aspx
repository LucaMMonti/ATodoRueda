<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisReservas.aspx.cs" Inherits="ATodoRueda.MisReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Mis Reservas</h2>
    <asp:Repeater ID="rptMisReservas" runat="server">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <th>Fecha de Reserva</th>
                        <th>Vehículo</th>
                        <th>Fecha Inicio</th>
                        <th>Fecha Fin</th>
                        <th>Precio Total</th>
                        <th>Estado</th>
                        <th>Cancelar</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("FechaReserva", "{0:d}") %></td>
                <td><%# Eval("Vehiculo.Marca") %> <%# Eval("Vehiculo.Modelo") %></td>
                <td><%# Eval("FechaInicio", "{0:d}") %></td>
                <td><%# Eval("FechaFin", "{0:d}") %></td>
                <td>$<%# Eval("PrecioTotal") %></td>
                <td><%# Convert.ToBoolean(Eval("Estado")) ? "Activa" : "Cancelada" %></td>
                <asp:Button ID="btnCancelarReserva" runat="server" Text="Cancelar Reserva" CommandArgument='<%# Eval("Id") %>' OnCommand="btnCancelarReserva_Command" />

            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
