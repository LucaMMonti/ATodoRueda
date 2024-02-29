<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoVehiculos.aspx.cs" Inherits="ATodoRueda.InfoVehiculos" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container mt-3">
                <!-- Filtros -->
                <div class="row">
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtPrecioMax" runat="server" CssClass="form-control mb-2" Placeholder="Precio Máximo"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <input type="date" id="txtFechaDesde" runat="server" class="form-control mb-2" placeholder="Desde" />
                    </div>
                    <!-- Botón de búsqueda -->
                    <div class="col-md-6 text-center">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    </div>
                    <div class="col-md-6 text-center mt-2">
                         <asp:Button ID="btnQuitarFiltros" runat="server" Text="Quitar Filtros" CssClass="btn btn-secondary" OnClick="btnQuitarFiltros_Click" />
                    </div>
                </div>
        

                <div class="container">
                <div class="row">
                    <asp:Repeater ID="rptVehiculos" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card h-100">
                                    <img src='<%# Eval("Imagen") %>' class="card-img-top" alt="Imagen del Vehículo">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Marca") %> <%# Eval("Modelo") %></h5>
                                        <p class="card-text">Tipo: <%# Eval("Tipo") %></p>
                                        <p class="card-text">Precio: $<%# Eval("PrecioPorDia") %>/día</p>
                                    </div>
                                    <div class="card-footer">
<%--                                        <small class="text-muted">Disponible desde: <%# Eval("FechaReservaFin", "{0:d}") %></small>--%>
                                        <asp:Button ID="btnReservar" runat="server" CommandArgument='<%# Eval("Id") %>' Text="Reservar" CssClass="btn btn-primary" OnCommand="btnReservar_Command" />
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
        </div>
    </div>
</asp:Content>
