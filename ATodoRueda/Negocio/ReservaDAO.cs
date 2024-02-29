using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReservaDAO
    {

        public bool VerificarDisponibilidadVehiculo(int vehiculoId, DateTime fechaInicio, DateTime fechaFin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Reservas WHERE VehiculoId = @VehiculoId AND ((FechaInicio <= @FechaFin AND FechaFin >= @FechaInicio) OR (FechaFin >= @FechaInicio AND FechaInicio <= @FechaFin)) AND Estado = 1");
                datos.agregarParametro("@VehiculoId", vehiculoId);
                datos.agregarParametro("@FechaInicio", fechaInicio);
                datos.agregarParametro("@FechaFin", fechaFin);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count == 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
