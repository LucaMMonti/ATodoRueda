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
    public partial class ReservarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int vehiculoId = int.Parse(Request.QueryString["IdVehiculo"]);
            CargarDetallesVehiculo(vehiculoId);
        }

        private void CargarDetallesVehiculo(int vehiculoId)
        {
            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            Vehiculo vehiculo = vehiculoDAO.ObtenerVehiculoPorId(vehiculoId);

            if (vehiculo != null)
            {
                imgVehiculo.Src = vehiculo.Imagen;
                lblMarcaModelo.InnerText = $"{vehiculo.Marca} {vehiculo.Modelo}";
                lblPrecioPorDia.InnerText = $"Precio por día: ${vehiculo.PrecioPorDia}";
                lblDescripcion.InnerText = vehiculo.Descripcion;
            }
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            int vehiculoId = int.Parse(Request.QueryString["IdVehiculo"]);
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);
            int usuarioId = (int)Session["usuarioId"];
            string codigoPromocion = txtCodigoPromocion.Text;

            PromocionDAO promocionDAO = new PromocionDAO();
            Promociones promocion = !string.IsNullOrWhiteSpace(codigoPromocion) ? promocionDAO.ObtenerPromocionPorCodigo(codigoPromocion) : null;

            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            Vehiculo vehiculo = vehiculoDAO.ObtenerVehiculoPorId(vehiculoId);

            ReservaDAO reservaDAO = new ReservaDAO();
            bool disponible = reservaDAO.VerificarDisponibilidadVehiculo(vehiculo.Id, fechaInicio, fechaFin);

            if (disponible)
            {

                decimal precioPorDia = vehiculo.PrecioPorDia;
                int cantidadDias = (fechaFin - fechaInicio).Days;
                decimal precioTotal = cantidadDias * precioPorDia;

                if (promocion != null && promocion.Estado)
                {
                    precioTotal -= precioTotal * promocion.Descuento / 100m;
                }
                // Crear la reserva
                Reserva reserva = new Reserva
                {
                    VehiculoId = vehiculo.Id,
                    UsuarioId = usuarioId,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    PromocionId = promocion?.Id,
                    FechaReserva = DateTime.Now,
                    PrecioTotal = (fechaFin - fechaInicio).Days * vehiculo.PrecioPorDia,
                    Pagado = false,
                    Estado = true
                };

                bool resultado = reservaDAO.CrearReserva(reserva);

                if (resultado)
                {
                    lblMensajeExito.Visible = true;
                    lblMensajeExito.Text = "Tu reserva ha sido confirmada con éxito.";

                    string script = "setTimeout(function () { window.location.href = 'Default.aspx'; }, 3000);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }
                else
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = "Ocurrió un error al intentar realizar la reserva. Por favor, inténtalo de nuevo.";
                }
            }
            else
            {
                 lblMensajeError.Visible = true;
                 lblMensajeError.Text = "El vehículo no está disponible para las fechas seleccionadas. Por favor, elige otras fechas.";            
            }
        }   
    }
}