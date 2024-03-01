using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATodoRueda
{
    public partial class InfoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDdlTipo();
                LlenarDdlMarca();
                CargarVehiculosSinFiltro();

            }
        }

        private void LlenarDdlTipo()
        {
            var tipos = new List<string> { "Automóvil", "SUV", "Camioneta" };

            ddlTipo.DataSource = tipos;
            ddlTipo.DataBind();

            ddlTipo.Items.Insert(0, new ListItem("-- Selecciona Tipo --", ""));
        }

        private void LlenarDdlMarca()
        {
            var marcas = new List<string> { "Toyota", "Ford", "Chevrolet", "Volskwagen", "Peugeuot" };

            ddlMarca.DataSource = marcas;
            ddlMarca.DataBind();

            ddlMarca.Items.Insert(0, new ListItem("-- Selecciona Marca --", ""));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string tipo = ddlTipo.SelectedValue;
            string marca = ddlMarca.SelectedValue;
            decimal? precioMax = !string.IsNullOrEmpty(txtPrecioMax.Text) ? decimal.Parse(txtPrecioMax.Text) : (decimal?)null;

            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            var vehiculosFiltrados = vehiculoDAO.ListarAutoReservado(tipo, marca, precioMax);

            rptVehiculos.DataSource = vehiculosFiltrados;
            rptVehiculos.DataBind();
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            ddlTipo.SelectedIndex = 0;
            ddlMarca.SelectedIndex = 0;
            txtPrecioMax.Text = string.Empty;
            txtFechaDesde.Value = string.Empty;

            CargarVehiculosSinFiltro();
        }

        private void CargarVehiculosSinFiltro()
        {
            var vehiculos = new VehiculoDAO().ListarConFiltro(); 
            rptVehiculos.DataSource = vehiculos; 
            rptVehiculos.DataBind();
        }

        protected void btnReservar_Command(object sender, CommandEventArgs e)
        {

            if (Session["usuario"] != null)
            {

                Response.Redirect($"ReservarVehiculo.aspx?IdVehiculo={e.CommandArgument}");
            }
            else
            {

                Response.Redirect($"InicioSesion.aspx?redirectUrl=ReservarVehiculo.aspx&IdVehiculo={e.CommandArgument}");
            }

        }





    }
}