<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ATodoRueda.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div id="registroStep1" class="card">
                    <div class="card-header">
                        Paso 1: Crea tu cuenta
                    </div>
                    <div class="card-body">
                        <form id="formStep1">
                            <div class="mb-3">
                                <label for="email" class="form-label">Correo electrónico</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required="required"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="password" class="form-label">Contraseña</label>
                                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" required="required"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="confirmPassword" class="form-label">Confirmar Contraseña</label>
                                <input type="password" class="form-control" id="confirmPassword" required>
                            </div>
                            <button type="button" class="btn btn-primary" onclick="validarYMostrarStep2()">Siguiente</button>
                        </form>
                    </div>
                </div>
                
                <div id="registroStep2" class="card" style="display:none;">
                    <div class="card-header">
                        Paso 2: Información Personal
                    </div>
                    <div class="card-body">
                        <form id="formStep2">
                            <div class="mb-3">
                                <label for="nombre" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="apellido" class="form-label">Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="fechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                                <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="direccion" class="form-label">Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="telefono" class="form-label">Teléfono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone" CssClass="form-control"></asp:TextBox>
                            </div>
                            <button type="button" class="btn btn-secondary" onclick="mostrarStep1()">Volver</button>
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />
                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

<script type="text/javascript">
    var passwordClientId = '<%= txtContrasena.ClientID %>';
    var confirmPasswordClientId = 'confirmPassword'; // ID estático, ya que es un input HTML puro

    function validarYMostrarStep2() {
        var password = document.getElementById(passwordClientId).value;
        var confirmPassword = document.getElementById(confirmPasswordClientId).value;

        // Expresión regular para validar la contraseña
        var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$/;

        // Verificar si las contraseñas coinciden
        if (password !== confirmPassword) {
            alert('Las contraseñas no coinciden. Por favor, inténtalo de nuevo.');
            return;
        }

        // Verificar la fortaleza de la contraseña
        if (!regex.test(password)) {
            alert('La contraseña debe tener al menos 6 caracteres, incluyendo al menos una letra mayúscula, una letra minúscula y un número.');
            return;
        }

        // Si todo está correcto, mostrar el segundo paso
        document.getElementById('registroStep1').style.display = 'none';
        document.getElementById('registroStep2').style.display = 'block';
    }

    function mostrarStep1() {
        document.getElementById('registroStep1').style.display = 'block';
        document.getElementById('registroStep2').style.display = 'none';
    }
</script>

</asp:Content>

