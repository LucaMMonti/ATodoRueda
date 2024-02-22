using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATodoRueda
{
    public partial class GestionFlota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVehiculos();
            }
        }

        private void CargarVehiculos()
        {
            gvVehiculos.DataSource = ObtenerVehiculos();
            gvVehiculos.DataBind();
        }

        private DataTable ObtenerVehiculos()
        {
            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            List<Vehiculo> listaVehiculos = vehiculoDAO.Listar();
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Marca", typeof(string));
            dt.Columns.Add("Modelo", typeof(string));
            dt.Columns.Add("Color", typeof(string));
            dt.Columns.Add("Anio", typeof(int));
            dt.Columns.Add("Placa", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("IdUsuario", typeof(int));
            dt.Columns.Add("Disponibilidad", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Imagen", typeof(string));

            foreach (Vehiculo vehiculo in listaVehiculos)
            {
                DataRow row = dt.NewRow();
                row["Id"] = vehiculo.Id;
                row["Tipo"] = vehiculo.Tipo;
                row["Marca"] = vehiculo.Marca;
                row["Modelo"] = vehiculo.Modelo;
                row["Color"] = vehiculo.Color;
                row["Anio"] = vehiculo.Anio;
                row["Placa"] = vehiculo.Placa;
                row["Precio"] = vehiculo.PrecioPorDia;
                row["Descripcion"] = vehiculo.Descripcion;
                row["IdUsuario"] = vehiculo.IdUsuario;
                row["Disponibilidad"] = vehiculo.IdUsuario == 1 ? "DISPONIBLE" : "RESERVADO";
                row["Estado"] = vehiculo.Estado ? "Activo" : "Inactivo";
                dt.Rows.Add(row);
            }

            return dt;
        }


        protected void gvVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvVehiculos.EditIndex = e.NewEditIndex;
            CargarVehiculos();
        }

        protected void gvVehiculos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvVehiculos.Rows[e.RowIndex];

            int vehiculoId = Convert.ToInt32(gvVehiculos.DataKeys[e.RowIndex].Values["Id"]);
            string marca = ((TextBox)row.FindControl("txtMarca")).Text;
            string modelo = ((TextBox)row.FindControl("txtModelo")).Text;
            string color = ((TextBox)row.FindControl("txtColor")).Text;
            string tipo = ((TextBox)row.FindControl("txtTipo")).Text;
            int anio = Convert.ToInt32(((TextBox)row.FindControl("txtAnio")).Text);
            string placa = ((TextBox)row.FindControl("txtPlaca")).Text;
            decimal precioPorDia = Convert.ToDecimal(((TextBox)row.FindControl("txtPrecio")).Text);
            string descripcion = ((TextBox)row.FindControl("txtDescripcion")).Text;
            DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
            //bool estado = ddlEstado.SelectedValue == "True";

            Vehiculo vehiculo = new Vehiculo
            {
                Id = vehiculoId, // El Id no cambia
                Marca = marca,
                Modelo = modelo,
                Color = color,
                Anio = anio,
                Tipo = tipo,
                Placa = placa,
                PrecioPorDia = precioPorDia,
                Descripcion = descripcion,
                //Estado = estado
            };

            VehiculoDAO vehiculoDAO = new VehiculoDAO();
            vehiculoDAO.ActualizarVehiculo(vehiculo);

            gvVehiculos.EditIndex = -1;
            CargarVehiculos();
        }


        protected void gvVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int vehiculoId = Convert.ToInt32(gvVehiculos.DataKeys[e.RowIndex].Value);
            CargarVehiculos();
        }

        protected void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                Vehiculo nuevoVehiculo = new Vehiculo
                {
                    Marca = txtMarca.Text,
                    Modelo = txtModelo.Text,
                    Color = txtColor.Text,
                    Placa = txtPlaca.Text,
                    Tipo = ddlTipo.SelectedValue,
                    Anio = Convert.ToInt32(txtAnio.Text),
                    PrecioPorDia = Convert.ToDecimal(txtPrecio.Text),
                    Descripcion = txtDescripcion.Text,
                    Imagen = txtImagen.Text,
                    Estado = true,
                    IdUsuario = 1
                };

                VehiculoDAO vehiculoDAO = new VehiculoDAO();
                vehiculoDAO.AgregarVehiculo(nuevoVehiculo);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarModal", "$('#modalAgregarVehiculo').modal('hide');", true);
                CargarVehiculos();

                // Opcional: Mostrar un mensaje de éxito o recargar la lista de vehículos
                // Recuerda cerrar el modal si es necesario, esto puede requerir un poco de JavaScript adicional        }
            }
            
            catch (Exception ex) { }
        }
    }
}