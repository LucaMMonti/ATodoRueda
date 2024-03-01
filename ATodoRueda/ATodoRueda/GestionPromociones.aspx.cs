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
    public partial class GestionPromociones : System.Web.UI.Page
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
                        CargarPromociones();
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

        protected void gvPromociones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPromociones.EditIndex = e.NewEditIndex;
            CargarPromociones();
        }

        protected void gvPromociones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPromociones.Rows[e.RowIndex];

            int promocionId = Convert.ToInt32(gvPromociones.DataKeys[e.RowIndex].Values["Id"]);
            string codigo = (row.FindControl("txtCodigo") as TextBox).Text;
            int descuento = Convert.ToInt32((row.FindControl("txtDescuento") as TextBox).Text);
            CheckBox chkEstado = (CheckBox)row.FindControl("chkEstadoEdit");
            bool estado = chkEstado.Checked;

            Promociones promociones = new Promociones
            {
            Id = promocionId,
               Codigo = codigo,
               Descuento = descuento,
               Estado = estado
            };

            PromocionDAO promocionDAO   = new PromocionDAO();
            promocionDAO.ModificarPromocion(promociones);


            gvPromociones.EditIndex = -1;
            CargarPromociones();
        }

        private void CargarPromociones()
        {
            PromocionDAO promocionDAO = new PromocionDAO();
            var listaUsuarios = promocionDAO.Listar();
            gvPromociones.DataSource = listaUsuarios;
            gvPromociones.DataBind();
        }

        protected void gvPromociones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPromociones.EditIndex = -1;
            CargarPromociones(); 
        }

        protected void gvPromociones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int promocionId = Convert.ToInt32(gvPromociones.DataKeys[e.RowIndex].Value);
            PromocionDAO promocionDAO = new PromocionDAO();
            bool resultado = promocionDAO.EliminarPromocion(promocionId);

            if (resultado)
            {
                lblSuccessMessage.Text = "Operación realizada con éxito.";
                lblSuccessMessage.Visible = true;
                CargarPromociones();
            }
            else
            {
                lblErrorMessage.Text = "Ocurrió un error: ";
                lblErrorMessage.Visible = true;

                lblSuccessMessage.Visible = false;
            }


        }

        protected void gvPromociones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Verifica si la fila está en modo de edición
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    // Encuentra el CheckBox en la fila de edición
                    CheckBox chkEstadoEdit = (CheckBox)e.Row.FindControl("chkEstadoEdit");
                    if (chkEstadoEdit != null)
                    {
                        // Obtiene el valor de 'Estado' y lo asigna al CheckBox
                        var estadoDataValue = DataBinder.Eval(e.Row.DataItem, "Estado");
                        chkEstadoEdit.Checked = estadoDataValue != DBNull.Value && Convert.ToBoolean(estadoDataValue);
                    }
                }
            }
        }

        protected void btnGuardarPromocion_Click(object sender, EventArgs e)
        {
            try
            {
                Promociones nuevaPromocion = new Promociones
                {
                    Codigo = txtCodigo.Text,
                    Descuento = Convert.ToInt32(txtDescuento.Text),
                    Estado = true
                };

                PromocionDAO promocionDAO = new PromocionDAO();
                bool resultado = promocionDAO.CrearPromocion(nuevaPromocion);

                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarModal", "$('#modalAgregarPromocion').modal('hide');", true);
                    CargarPromociones();
                    lblSuccessMessage.Text = "Promoción agregada con éxito.";
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