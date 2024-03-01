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
                  var rolUsuario = (int)Session["Rol"];
             
                  if (rolUsuario == 1)
                  {
                      LlenarRoles();
                      CargarUsuarios();
                  }
                  else
                  {
                      Response.Redirect("~/Default.aspx");
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

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsuarios.EditIndex = e.NewEditIndex;
            CargarUsuarios();
        }

        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUsuarios.Rows[e.RowIndex];

            int userId = Convert.ToInt32(gvUsuarios.DataKeys[e.RowIndex].Values["Id"]);
            string nombre = (row.FindControl("txtNombre") as TextBox).Text;
            string apellido = (row.FindControl("txtApellido") as TextBox).Text;
            string correoElectronico = (row.FindControl("txtCorreoElectronico") as TextBox).Text;
            string contrasena = (row.FindControl("txtContrasena") as TextBox).Text;
            int numeroDocumento = Convert.ToInt32((row.FindControl("txtNumeroDocumento") as TextBox).Text);
            DateTime fechaNacimiento = Convert.ToDateTime((row.FindControl("txtFechaNacimiento") as TextBox).Text);
            string telefono = (row.FindControl("txtTelefono") as TextBox).Text;
            string direccion = (row.FindControl("txtDireccion") as TextBox).Text;

            var ddlRol = row.FindControl("ddlRol") as DropDownList;
            var chkEstadoControl = row.FindControl("chkEstado") as CheckBox;

            int rol = ddlRol != null ? Convert.ToInt32(ddlRol.SelectedValue) : 0;
            bool estado = chkEstadoControl != null && chkEstadoControl.Checked;

            Usuario usuario = new Usuario
            {
                Id = userId,
                Nombre = nombre,
                Apellido = apellido,
                CorreoElectronico = correoElectronico,
                Contrasena = contrasena,
                NumeroDocumento = numeroDocumento,
                FechaNacimiento = fechaNacimiento,
                Telefono = telefono,
                Direccion = direccion,
                Rol = rol,
                Estado = estado
            };

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.ActualizarUsuario(usuario);

            gvUsuarios.EditIndex = -1;
            CargarUsuarios();
        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsuarios.EditIndex = -1;
            CargarUsuarios();
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Verifica si la fila está en modo de edición
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    // Encuentra el CheckBox en la fila de edición
                    CheckBox chkEstadoEdit = (CheckBox)e.Row.FindControl("chkEstadoEdit");
                    if (chkEstadoEdit != null)
                    {
                        // Obtiene el valor de 'Estado' y lo asigna al CheckBox
                        var estadoDataValue = DataBinder.Eval(e.Row.DataItem, "Estado");
                        chkEstadoEdit.Checked = estadoDataValue != DBNull.Value && Convert.ToBoolean(estadoDataValue);
                    }
                }
            }
        }



    }
}