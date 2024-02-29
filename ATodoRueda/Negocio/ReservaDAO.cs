using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReservaDAO
    {
        public bool CrearReserva(Dominio.Reserva reserva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Reservas (VehiculoId, UsuarioId, PromocionId, FechaReserva, FechaInicio, FechaFin, PrecioTotal, Pagado, Estado) VALUES (@VehiculoId, @UsuarioId, @PromocionId,GETDATE(), @FechaInicio, @FechaFin, @PrecioTotal, @Pagado, @Estado)");
                datos.agregarParametro("@VehiculoId", reserva.VehiculoId);
                datos.agregarParametro("@UsuarioId", reserva.UsuarioId);
                datos.agregarParametro("@PromocionId", reserva.PromocionId.HasValue ? (object)reserva.PromocionId : DBNull.Value);
                datos.agregarParametro("@FechaInicio", reserva.FechaInicio);
                datos.agregarParametro("@FechaFin", reserva.FechaFin);
                datos.agregarParametro("@PrecioTotal", reserva.PrecioTotal);
                datos.agregarParametro("@Pagado", reserva.Pagado);
                datos.agregarParametro("@Estado", reserva.Estado);

                datos.ejecutarAccion();
                return true;
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

        public List<Reserva> ObtenerReservasPorUsuarioId(int usuarioId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                List<Reserva> reservas = new List<Reserva>();
                datos.setearConsulta("SELECT R.Id, R.VehiculoId, R.UsuarioId, R.PromocionId, R.FechaReserva, R.FechaInicio, R.FechaFin, R.PrecioTotal, R.Pagado, R.Estado, V.Marca, V.Modelo, V.Imagen FROM Reservas R INNER JOIN Vehiculos V ON R.VehiculoId = V.Id WHERE R.UsuarioId = @UsuarioId");
                datos.agregarParametro("@UsuarioId", usuarioId);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Reserva reserva = new Reserva
                    {
                        Id = (int)datos.Lector["Id"],
                        VehiculoId = (int)datos.Lector["VehiculoId"],
                        UsuarioId = (int)datos.Lector["UsuarioId"],
                        FechaReserva = (DateTime)datos.Lector["FechaReserva"],
                        FechaInicio = (DateTime)datos.Lector["FechaInicio"],
                        FechaFin = (DateTime)datos.Lector["FechaFin"],
                        PromocionId = datos.Lector["PromocionId"] == DBNull.Value ? null : (int?)datos.Lector["PromocionId"],
                        PrecioTotal = (decimal)datos.Lector["PrecioTotal"],
                        Pagado = (bool)datos.Lector["Pagado"],
                        Estado = (bool)datos.Lector["Estado"],
                        Vehiculo = new Vehiculo
                        {
                            Id = (int)datos.Lector["VehiculoId"],
                            Marca = datos.Lector["Marca"].ToString(),
                            Modelo = datos.Lector["Modelo"].ToString(),
                            Imagen = datos.Lector["Imagen"].ToString()
                        }
                    };
                    reservas.Add(reserva);
                }
                return reservas;
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

        public Reserva ObtenerReservaPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Reserva reserva = new Reserva();
            try
            {
                datos.setearConsulta("SELECT R.Id, R.VehiculoId, R.UsuarioId, R.PromocionId, R.FechaReserva, R.FechaInicio, R.FechaFin, R.PrecioTotal, R.Pagado, R.Estado, V.Marca, V.Modelo, V.Imagen FROM Reservas R INNER JOIN Vehiculos V ON R.VehiculoId = V.Id WHERE R.Id = @Id");
                datos.agregarParametro("@Id", Id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    reserva = new Reserva
                    {
                        Id = (int)datos.Lector["Id"],
                        VehiculoId = (int)datos.Lector["VehiculoId"],
                        UsuarioId = (int)datos.Lector["UsuarioId"],
                        FechaReserva = (DateTime)datos.Lector["FechaReserva"],
                        FechaInicio = (DateTime)datos.Lector["FechaInicio"],
                        FechaFin = (DateTime)datos.Lector["FechaFin"],
                        PromocionId = datos.Lector["PromocionId"] == DBNull.Value ? (int?)null : (int)datos.Lector["PromocionId"],
                        PrecioTotal = (decimal)datos.Lector["PrecioTotal"],
                        Pagado = (bool)datos.Lector["Pagado"],
                        Estado = (bool)datos.Lector["Estado"],
                        Vehiculo = new Vehiculo
                        {
                            Id = (int)datos.Lector["VehiculoId"],
                            Marca = datos.Lector["Marca"].ToString(),
                            Modelo = datos.Lector["Modelo"].ToString(),
                            Imagen = datos.Lector["Imagen"].ToString()
                        }
                    };
                }
                return reserva;
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

        public bool CancelarReserva(int reservaId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Reservas SET Estado = 0 WHERE Id = @Id AND (FechaInicio - GETDATE()) > 15");
                datos.agregarParametro("@Id", reservaId);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
