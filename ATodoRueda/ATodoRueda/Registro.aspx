<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ATodoRueda.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Registro de Usuario</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="alert" Visible="false"></asp:Label> <!-- Para mensajes de validación -->
        
        <!-- Agrupación de Nombre -->
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
        </div>

        <!-- Agrupación de Apellido -->
        <div class="form-group">
            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
        </div>

        <!-- Agrupación de Correo Electrónico -->
        <div class="form-group">
            <label for="txtCorreoElectronico">Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreoElectronico" CssClass="form-control" runat="server" TextMode="Email" />
        </div>

        <!-- Agrupación de Contraseña -->
        <div class="form-group">
            <label for="txtContrasena">Contraseña:</label>
            <asp:TextBox ID="txtContrasena" CssClass="form-control" runat="server" TextMode="Password" />
        </div>

        <!-- Agrupación de Número Documneto -->
        <div class="form-group">
            <label for="txtNumeroDocumento">Número documento:</label>
            <asp:TextBox ID="txtNumeroDocumento" CssClass="form-control" runat="server" />
        </div>

        <!-- Agrupación de Fecha de Nacimiento -->
        <div class="form-group">
            <label for="txtFechaNacimiento">Fecha de nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server" />
        </div>

        <!-- Agrupación de Dirección -->
        <div class="form-group">
            <label for="txtDireccion">Dirección:</label>
            <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" />
        </div>

        <!-- Agrupación de Teléfono -->
        <div class="form-group">
            <label for="txtTelefono">Teléfono:</label>
            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" />
        </div>

        <!-- Botón de Registro -->
        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click" />
        
    </div>
</asp:Content>

