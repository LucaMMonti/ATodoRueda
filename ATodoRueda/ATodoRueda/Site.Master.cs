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
            var rol = Session["Rol"] as string;
            // Asegúrate de tener referencias a tus controles de menú aquí
            liGestionUsuarios.Visible = rol == "1"; 
            liGestionFlota.Visible = rol == "1";  

            liInicioSesion.Visible = Session["usuario"] == null;
            liRegistro.Visible = Session["usuario"] == null;

            //liCerrarSesion.Visible = Session["usuario"] != null;
        }

        public void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/InicioSesion.aspx");
        }
    }
}