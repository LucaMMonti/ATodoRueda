using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using Negocio;
using System.Data;

namespace ATodoRueda
{
    public partial class GestionarReservas : System.Web.UI.Page
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
                        CargarReservas();
                        CargarDropDownListVehiculos();
                        CargarDropDownListUsuarios();
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

        private void CargarReservas()
        {
            ReservaDAO reservaDAO = new ReservaDAO();
            var listaReservas = reservaDAO.Listar();
            gvReservas.DataSource = listaReservas;
            gvReservas.DataBind();
        }


        protected void gvReservas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReservas.EditIndex = e.NewEditIndex;
            CargarReservas();
        }

        protected void gvReservas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvReservas.Rows[e.RowIndex];
            int reservaId = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Values["Id"]);

            int vehiculoId = int.Parse(ddlVehiculos.SelectedValue);
            int usuarioId = int.Parse(ddlUsuarios.SelectedValue);

            TextBox txtPromocionId = row.FindControl("txtPromocionId") as TextBox;
            int? promocionId = !string.IsNullOrEmpty(txtPromocionId.Text) ? Convert.ToInt32(txtPromocionId.Text) : (int?)null;


            DateTime fechaReserva = DateTime.Parse((row.FindControl("txtFechaReserva") as TextBox).Text);
            DateTime fechaInicio = DateTime.Parse((row.FindControl("txtFechaInicio") as TextBox).Text);
            DateTime fechaFin = DateTime.Parse((row.FindControl("txtFechaFin") as TextBox).Text);


            CheckBox chkPagado = (CheckBox)row.FindControl("chkPagadoEdit");
            bool pagado = chkPagado.Checked;
            CheckBox chkEstado = (CheckBox)row.FindControl("chkEstadoEdit");
            bool estado = chkEstado.Checked;


            Reserva reserva = new Reserva
            {
                Id = reservaId,
                VehiculoId = vehiculoId,
                UsuarioId = usuarioId,
                PromocionId = promocionId,
                FechaReserva = fechaReserva,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                Pagado = pagado,
                Estado = estado
            };

            ReservaDAO reservaDAO = new ReservaDAO();
            reservaDAO.ActualizarReserva(reserva);

            gvReservas.EditIndex = -1;
            CargarReservas();
        }

        private void CargarDropDownListVehiculos()
        {
            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            var listaVehiculos = vehiculoDAO.Listar();
            ddlVehiculos.DataSource = listaVehiculos.Select(v => new {
                Text = $"{v.Marca} {v.Modelo} - ID: {v.Id}",
                Value = v.Id.ToString()
            });
            ddlVehiculos.DataTextField = "Text";
            ddlVehiculos.DataValueField = "Value";
            ddlVehiculos.DataBind();
        }

        private void CargarDropDownListUsuarios()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            var listaUsuarios = usuarioDAO.Listar(); // Asegúrate de que este método exista y devuelva la lista de usuarios.
            ddlUsuarios.DataSource = listaUsuarios.Select(u => new {
                Text = $"{u.Nombre} {u.Apellido} - ID: {u.Id}",
                Value = u.Id.ToString()
            });
            ddlUsuarios.DataTextField = "Text";
            ddlUsuarios.DataValueField = "Value";
            ddlUsuarios.DataBind();
        }

        protected void gvReservas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReservas.EditIndex = -1;
            CargarReservas();
        }

        protected void gvReservas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int reservaId = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Values["Id"]);

            try
            {
                ReservaDAO reservaDAO = new ReservaDAO();
                reservaDAO.EliminarReserva(reservaId);

                lblSuccessMessage.Text = "Reserva eliminada con éxito.";
                lblSuccessMessage.Visible = true;

                CargarReservas();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Ocurrió un error al eliminar la reserva: " + ex.Message;
                lblErrorMessage.Visible = true;
            }
        }

        protected void btnGuardarReservas_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva nuevaReserva = new Reserva
                {
                    VehiculoId = int.Parse(ddlVehiculos.SelectedValue),
                    UsuarioId = int.Parse(ddlUsuarios.SelectedValue),
                    PromocionId = !string.IsNullOrEmpty(txtPromo.Text) ? Convert.ToInt32(txtPromo.Text) : (int?)null,
                    FechaReserva = DateTime.Parse(txtFechaR.Text),
                    FechaInicio = DateTime.Parse(txtFechaIni.Text),
                    FechaFin = DateTime.Parse(txtFechaF.Text),
                    Pagado = false,
                    Estado = true
                    };

                ReservaDAO reservaDAO = new ReservaDAO();
                bool resultado = reservaDAO.CrearReserva(nuevaReserva);

                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarModal", "$('#modalAgregarReserva').modal('hide');", true);
                    CargarReservas();
                    lblSuccessMessage.Text = "Vehículo agregado con éxito.";
                    lblSuccessMessage.Visible = true;
                }
                else
                {
                    lblErrorMessage.Text = "Ocurrió un error al agregar el vehículo.";
                    lblErrorMessage.Visible = true;
                }
            }

            catch (Exception ex)
            {

                lblErrorMessage.Text = "Ocurrió un error inesperado al agregar el vehículo.";
                lblErrorMessage.Visible = true;
            }
        }

    }
}