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
                ConfigurarMenu();
            }
        }

        private void ConfigurarMenu()
        {
            bool sesionIniciada = Session["usuario"] != null;
            string rol = sesionIniciada ? Session["Rol"].ToString() : string.Empty;

            // Controla la visibilidad según si hay sesión y el rol
            liRegistro.Visible = !sesionIniciada;
            liInicioSesion.Visible = !sesionIniciada;
            liMisReservas.Visible = sesionIniciada && rol == "3"; // Rol cliente
            liGestionUsuarios.Visible = rol == "1"; // Rol administrador
            liGestionFlota.Visible = rol == "1"; // Rol administrador
        }

        public void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/InicioSesion.aspx");
        }
    }
}