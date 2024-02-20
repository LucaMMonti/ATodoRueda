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
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                lblMensaje.Visible = false;
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreoElectronico.Text;
            string contraseña = txtContrasena.Text;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = usuarioDAO.IniciarSesion(correo, contraseña);

            if (usuario != null)
            {

                Session["usuario"] = usuario;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Text = "Correo electrónico o contraseña incorrectos.";
            }
        }

    }
}