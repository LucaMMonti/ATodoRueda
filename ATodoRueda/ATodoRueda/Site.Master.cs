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

            liRegistro.Visible = !sesionIniciada;
            liInicioSesion.Visible = !sesionIniciada;
            liCerrarSesion.Visible = sesionIniciada;
            liMisReservas.Visible = sesionIniciada && rol == "3";
            liGestionUsuarios.Visible = rol == "1";
            liGestionFlota.Visible = rol == "1";
            liGestionPromociones.Visible = rol == "1";
            liGestionReservas.Visible = rol == "1" || rol == "2";
        }

        public void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}