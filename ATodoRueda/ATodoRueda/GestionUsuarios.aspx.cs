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
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
              if (Session["usuario"] != null && Session["Rol"] != null)
              {
                  var rolUsuario = (string)Session["Rol"];
             
                  if (rolUsuario == "1")
                  {
                      LlenarRoles();
                      CargarUsuarios();
                  }
                  else
                  {
                      Response.Redirect("~/NoAutorizado.aspx");
                  }
              }
              else
              {
                  Response.Redirect("~/InicioSesion.aspx");
              }
           }          
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            try
            {
                string _nombre = txtNombre.Text;
                string _apellido = txtApellido.Text;
                string _correoElectronico = txtCorreoElectronico.Text;
                string _contrasena = txtContrasena.Text;
                int _numeroDocumento = int.Parse(txtNumeroDocumento.Text);
                DateTime _fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                string _telefono = txtTelefono.Text;
                string _direccion = txtDireccion.Text;
                int _rol = Convert.ToInt32(ddlNuevoRol.SelectedValue);
                bool _estado = true;

                Usuario nuevoUsuario = new Usuario(_nombre, _apellido, _correoElectronico, _contrasena, _numeroDocumento, _telefono, _direccion, _fechaNacimiento, _rol, _estado);

                if (usuarioDAO.AgregarUsuario(nuevoUsuario))
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

        private void CargarUsuarios()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            var listaUsuarios = usuarioDAO.Listar();
            gvUsuarios.DataSource = listaUsuarios;
            gvUsuarios.DataBind();
        }
        private void LlenarRoles()
        {
            ddlNuevoRol.Items.Clear();

            ddlNuevoRol.Items.Add(new ListItem("Seleccione un rol", ""));
            ddlNuevoRol.Items.Add(new ListItem("Administrador", "1"));
            ddlNuevoRol.Items.Add(new ListItem("Gestor", "2"));
            ddlNuevoRol.Items.Add(new ListItem("Cliente", "3"));
        }

        protected string GetRolName(string rolId)
        {
            switch (rolId)
            {
                case "1":
                    return "Administrador";
                case "2":
                    return "Gestor";
                case "3":
                    return "Cliente";
                default:
                    return "Desconocido";
            }
        }
    }
}