using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATodoRueda
{
    public partial class Registro : System.Web.UI.Page
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string correoElectronico = txtEmail.Text;
            bool existeCorreo = usuarioDAO.ExisteCorreoElectronico(correoElectronico);

            if (existeCorreo)
            {
                lblMensaje.Text = "El correo electrónico ya está registrado.";
            }
            else
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Contrasena = txtContrasena.Text,
                    CorreoElectronico = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    FechaRegistro = DateTime.Now,
                    Rol = 3,
                    Estado = true
                };

                bool registrado = usuarioDAO.Registrar(nuevoUsuario);
                if (registrado)
                {
                    lblMensaje.Text = "Usuario registrado exitosamente.";
                    lblMensaje.CssClass = "text-success";
                    Response.Redirect("InicioSesion.aspx");
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al registrar el usuario.";
                    lblMensaje.CssClass = "text-danger";
                }
            }
        }
    }
}