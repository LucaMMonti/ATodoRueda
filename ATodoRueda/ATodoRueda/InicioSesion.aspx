<%@ Page Title="Inicio de Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="ATodoRueda.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        Inicio de Sesión
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMensaje" runat="server" CssClass="alert" Visible="false"></asp:Label>
                        <div class="mb-3">
                            <label for="txtCorreoElectronico" class="form-label">Correo electrónico</label>
                            <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" TextMode="Email" placeholder="Introduce tu correo" AutoCompleteType="Email"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtContrasena" class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="Introduce tu contraseña" Type="Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnIniciarSesion" runat="server" CssClass="btn btn-primary" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
