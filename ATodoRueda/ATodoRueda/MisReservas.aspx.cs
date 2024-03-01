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
    public partial class MisReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReservas();
            }

        }

        private void CargarReservas()
        {
            if (Session["usuario"] != null)
            {
                var usuario = (Usuario)Session["usuario"];
                var reservas = new ReservaDAO().ObtenerReservasPorUsuarioId(usuario.Id);
                VehiculoDAO vehiculoDAO = new VehiculoDAO();
                rptMisReservas.DataSource = reservas;
                rptMisReservas.DataBind();
            }
            else
            {
                Response.Redirect("InicioSesion.aspx");
            }
        }

        protected void btnCancelarReserva_Command(object sender, CommandEventArgs e)
        {
            int reservaId = Convert.ToInt32(e.CommandArgument);
            var reservaDAO = new ReservaDAO();
            var reserva = reservaDAO.ObtenerReservaPorId(reservaId);

            if ((reserva.FechaInicio - DateTime.Now).TotalDays > 14)
            {
                bool resultado = reservaDAO.CancelarReserva(reservaId);
                if (resultado)
                {
                    lblSuccessMessage.Visible = true;
                    lblSuccessMessage.Text = "Reserva cancelada con éxito.";
                    lblErrorMessage.Visible = false;
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Ocurrió un error al cancelar la reserva. Por favor, inténtalo de nuevo.";
                    lblSuccessMessage.Visible = false;
                }
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Las reservas no pueden ser canceladas con menos de 15 días de anticipación.";
                lblSuccessMessage.Visible = false;
            }
            CargarReservas();
        }
    }
}