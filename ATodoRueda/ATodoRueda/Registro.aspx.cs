using Dominio;
using Negocio;
using System;

namespace ATodoRueda
{
    public partial class Registro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            try
            {
                string _nombre = txtNombre.Text;
                string _apellido = txtApellido.Text;
                string _correoElectronico = txtCorreoElectronico.Text;
                string _contrasena = txtContrasena.Text;
                string _telefono = txtTelefono.Text;
                string _direccion = txtDireccion.Text;
                DateTime _fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                int _rol = 3;
                bool _estado = true;
                    
            Usuario nuevoUsuario = new Usuario(_nombre, _apellido, _correoElectronico, _contrasena, _telefono, _direccion, _fechaNacimiento, _rol, _estado );


                if (usuarioDAO.Registrar(nuevoUsuario))
                {
                    lblMensaje.Text = "Usuario registrado exitosamente.";
                    lblMensaje.CssClass = "text-success";
                    Response.Redirect("Default.aspx");

                }
            }

            catch (Exception ex)
            {
                lblMensaje.Text = "Hubo un error al registrar el usuario.";
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}    
