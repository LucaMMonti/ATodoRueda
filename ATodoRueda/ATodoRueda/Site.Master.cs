using Dominio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATodoRueda
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usuario = Session["usuario"] as Usuario; // Asumiendo que guardas el objeto Usuario en la sesión

                // Verifica si el usuario es administrador
                bool esAdministrador = usuario != null && usuario.Rol == 1;

                // Controla la visibilidad de las opciones de gestión
                liGestionUsuarios.Visible = esAdministrador;
                liGestionFlota.Visible = esAdministrador;

                // Ajusta la visibilidad de Registro e Inicio de Sesión según si hay un usuario en sesión
                liRegistro.Visible = usuario == null;
                liInicioSesion.Visible = usuario == null;
            }
        }

        public void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/InicioSesion.aspx");
        }
    }
}