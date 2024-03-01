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
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, "^[a-zA-Z\\s]+$"))
                {
                    throw new Exception("El nombre solo puede contener letras.");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtApellido.Text, "^[a-zA-Z\\s]+$"))
                {
                    throw new Exception("El apellido solo puede contener letras.");
                }

                int numeroDocumento;
                if (!int.TryParse(txtNumeroDocumento.Text, out numeroDocumento))
                {
                    throw new Exception("El número de documento solo puede contener números.");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, "^[0-9]+$"))
                {
                    throw new Exception("El teléfono solo puede contener números.");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreoElectronico.Text, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$"))
                {
                    throw new Exception("El correo electrónico no es válido.");
                }

                if (txtContrasena.Text.Length < 6)
                {
                    throw new Exception("La contraseña debe tener al menos 6 caracteres.");
                }

                

                string _nombre = txtNombre.Text;
                string _apellido = txtApellido.Text;
                string _correoElectronico = txtCorreoElectronico.Text;
                string _contrasena = txtContrasena.Text;
                int _numeroDocumento = int.Parse(txtNumeroDocumento.Text);
                string _telefono = txtTelefono.Text;
                string _direccion = txtDireccion.Text;
                DateTime _fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                int _rol = 3;
                bool _estado = true;
                    
            Usuario nuevoUsuario = new Usuario(_nombre, _apellido, _correoElectronico, _contrasena, _numeroDocumento, _telefono, _direccion, _fechaNacimiento, _rol, _estado );


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
