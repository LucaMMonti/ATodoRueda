﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VehiculoDAO
    {
        public List<Vehiculo> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            try
            {
                datos.setearConsulta("SELECT Id, Placa, Marca, Modelo, Color, Tipo, Estado, Descripcion, Imagen, IdUsuario, Anio, PrecioPorDia FROM Vehiculos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo
                    {
                        Id = (int)datos.Lector["Id"],
                        Placa = datos.Lector["Placa"].ToString(),
                        Marca = datos.Lector["Marca"].ToString(),
                        Modelo = datos.Lector["Modelo"].ToString(),
                        Color = datos.Lector["Color"].ToString(),
                        Tipo = datos.Lector["Tipo"].ToString(),
                        Estado = (bool)datos.Lector["Estado"],
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Imagen = datos.Lector["Imagen"].ToString(),
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        Anio = (int)datos.Lector["Anio"],
                        PrecioPorDia = (decimal)datos.Lector["PrecioPorDia"],
                    };

                    listaVehiculos.Add(vehiculo);
                }
                return listaVehiculos;
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

        public Vehiculo ObtenerVehiculoPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Vehiculo vehiculo = null;

            try
            {
                datos.setearConsulta("SELECT Id, Placa, Marca, Modelo, Color, Tipo, Estado, Descripcion, Imagen, IdUsuario, Anio, PrecioPorDia FROM Vehiculos WHERE Id = @Id");
                datos.agregarParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    vehiculo = new Vehiculo
                    {
                        Id = (int)datos.Lector["Id"],
                        Placa = datos.Lector["Placa"].ToString(),
                        Marca = datos.Lector["Marca"].ToString(),
                        Modelo = datos.Lector["Modelo"].ToString(),
                        Color = datos.Lector["Color"].ToString(),
                        Tipo = datos.Lector["Tipo"].ToString(),
                        Estado = (bool)datos.Lector["Estado"],
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Imagen = datos.Lector["Imagen"].ToString(),
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        Anio = (int)datos.Lector["Anio"],
                        PrecioPorDia = (decimal)datos.Lector["PrecioPorDia"]
                    };
                }
                return vehiculo;
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

        public bool AgregarVehiculo(Vehiculo vehiculo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Vehiculos (Placa, Marca, Modelo, Color, Tipo, Descripcion, Imagen, IdUsuario, Anio, PrecioPorDia, Estado) VALUES (@Placa, @Marca, @Modelo, @Color, @Tipo, @Descripcion, @Imagen, @IdUsuario, @Anio, @PrecioPorDia, @Estado)");

                datos.agregarParametro("@Tipo", vehiculo.Tipo);
                datos.agregarParametro("@Placa", vehiculo.Placa);
                datos.agregarParametro("@Marca", vehiculo.Marca);
                datos.agregarParametro("@Modelo", vehiculo.Modelo);
                datos.agregarParametro("@Color", vehiculo.Color);
                datos.agregarParametro("@Descripcion", vehiculo.Descripcion);
                datos.agregarParametro("@Imagen", vehiculo.Imagen);
                datos.agregarParametro("@IdUsuario", 1);
                datos.agregarParametro("@Anio", vehiculo.Anio);
                datos.agregarParametro("@PrecioPorDia", vehiculo.PrecioPorDia);
                datos.agregarParametro("@Estado", vehiculo.Estado);


                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ActualizarVehiculo(Vehiculo vehiculo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Vehiculos SET Placa = @Placa, Marca = @Marca, Modelo = @Modelo, Color = @Color, Tipo = @Tipo, Estado = @Estado, Descripcion = @Descripcion, Anio = @Anio, PrecioPorDia = @PrecioPorDia WHERE Id = @Id");

                datos.agregarParametro("@Id", vehiculo.Id);
                datos.agregarParametro("@Placa", vehiculo.Placa);
                datos.agregarParametro("@Marca", vehiculo.Marca);
                datos.agregarParametro("@Modelo", vehiculo.Modelo);
                datos.agregarParametro("@Color", vehiculo.Color);
                datos.agregarParametro("@Tipo", vehiculo.Tipo);
                datos.agregarParametro("@Estado", vehiculo.Estado);
                datos.agregarParametro("@Descripcion", vehiculo.Descripcion);
                datos.agregarParametro("@Anio", vehiculo.Anio);
                datos.agregarParametro("@PrecioPorDia", vehiculo.PrecioPorDia);
                
                datos.ejecutarAccion();
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

        public void EliminarVehiculo(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Vehiculos WHERE Id = @Id");
                datos.agregarParametro("@Id", id);
                datos.ejecutarAccion();
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


        public List<Vehiculo> Listar(string tipo = null, string marca = null, DateTime? fechaDesde = null, decimal? precioMax = null)
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                StringBuilder consulta = new StringBuilder("SELECT Id, Placa, Marca, Modelo, Color, Tipo, Estado, Descripcion, Imagen, IdUsuario, Anio, PrecioPorDia, FechaReservaInicio, FechaReservaFin FROM Vehiculos WHERE 1=1");

                if (!string.IsNullOrEmpty(tipo))
                {
                    consulta.Append(" AND Tipo = @Tipo");
                    datos.agregarParametro("@Tipo", tipo);
                }
                if (!string.IsNullOrEmpty(marca))
                {
                    consulta.Append(" AND Marca = @Marca");
                    datos.agregarParametro("@Marca", marca);
                }
                if (fechaDesde.HasValue)
                {
                    consulta.Append(" AND (FechaReservaFin IS NULL OR FechaReservaFin < @FechaDesde)");
                    datos.agregarParametro("@FechaDesde", fechaDesde.Value);
                }
                if (precioMax.HasValue)
                {
                    consulta.Append(" AND PrecioPorDia <= @PrecioMax");
                    datos.agregarParametro("@PrecioMax", precioMax.Value);
                }

                datos.setearConsulta(consulta.ToString());
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo
                    {
                        // Asigna los valores leídos a las propiedades del objeto Vehiculo
                    };
                    listaVehiculos.Add(vehiculo);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaVehiculos;
        }

        public List<Vehiculo> ListarConFiltro(string tipo = null, string marca = null, decimal? precio = null, DateTime? desde = null)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT Id, Placa, Marca, Modelo, Color, Tipo, Estado, Descripcion, Imagen, IdUsuario, Anio, PrecioPorDia FROM Vehiculos WHERE 1=1");

                if (!string.IsNullOrEmpty(tipo) && tipo != "-- Selecciona Tipo --")
                    consulta.Append(" AND Tipo LIKE @Tipo");
                if (!string.IsNullOrEmpty(marca) && marca != "-- Selecciona Marca --")
                    consulta.Append(" AND Marca LIKE @Marca");
                if (precio.HasValue)
                    consulta.Append(" AND PrecioPorDia <= @PrecioPorDia");
                if (desde.HasValue)
                {
                    consulta.Append(" AND (FechaReservaFin IS NULL OR FechaReservaFin < @fechaDesde)");
                    datos.agregarParametro("@fechaDesde", desde.Value);
                }

                datos.setearConsulta(consulta.ToString());

                if (!string.IsNullOrEmpty(tipo) && tipo != "-- Selecciona Tipo --")
                    datos.agregarParametro("@Tipo", $"%{tipo}%");
                if (!string.IsNullOrEmpty(marca) && marca != "-- Selecciona Marca --")
                    datos.agregarParametro("@Marca", $"%{marca}%");
                if (precio.HasValue)
                    datos.agregarParametro("@PrecioPorDia", precio);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo
                    {
                        Id = (int)datos.Lector["Id"],
                        Placa = datos.Lector["Placa"].ToString(),
                        Marca = datos.Lector["Marca"].ToString(),
                        Modelo = datos.Lector["Modelo"].ToString(),
                        Color = datos.Lector["Color"].ToString(),
                        Tipo = datos.Lector["Tipo"].ToString(),
                        Estado = (bool)datos.Lector["Estado"],
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Imagen = datos.Lector["Imagen"].ToString(),
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        Anio = (int)datos.Lector["Anio"],
                        PrecioPorDia = (decimal)datos.Lector["PrecioPorDia"],

                    };

                    lista.Add(vehiculo);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }


        public List<Vehiculo> ListarAutoReservado(string tipo = null, string marca = null, decimal? precio = null, DateTime? desde = null, DateTime? hasta = null)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT V.Id, V.Placa, V.Marca, V.Modelo, V.Color, V.Tipo, V.Estado, V.Descripcion, V.Imagen, V.IdUsuario, V.Anio, V.PrecioPorDia ");
                consulta.Append("FROM Vehiculos V LEFT JOIN Reservas R ON V.Id = R.VehiculoId ");
                consulta.Append("WHERE V.Estado = 1 ");

                if (!string.IsNullOrEmpty(tipo) && tipo != "-- Selecciona Tipo --")
                    consulta.Append("AND V.Tipo LIKE @Tipo ");
                if (!string.IsNullOrEmpty(marca) && marca != "-- Selecciona Marca --")
                    consulta.Append("AND V.Marca LIKE @Marca ");
                if (precio.HasValue)
                    consulta.Append("AND V.PrecioPorDia <= @PrecioPorDia ");

                if (desde.HasValue && hasta.HasValue)
                {
                    consulta.Append("AND (R.Id IS NULL OR R.FechaFin < @Desde OR R.FechaInicio > @Hasta) ");
                    datos.agregarParametro("@Desde", desde.Value);
                    datos.agregarParametro("@Hasta", hasta.Value);
                }

                datos.setearConsulta(consulta.ToString());

                if (!string.IsNullOrEmpty(tipo) && tipo != "-- Selecciona Tipo --")
                    datos.agregarParametro("@Tipo", $"%{tipo}%");
                if (!string.IsNullOrEmpty(marca) && marca != "-- Selecciona Marca --")
                    datos.agregarParametro("@Marca", $"%{marca}%");
                if (precio.HasValue)
                    datos.agregarParametro("@PrecioPorDia", precio);

                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo
                    {
                        Id = (int)datos.Lector["Id"],
                        Placa = datos.Lector["Placa"].ToString(),
                        Marca = datos.Lector["Marca"].ToString(),
                        Modelo = datos.Lector["Modelo"].ToString(),
                        Color = datos.Lector["Color"].ToString(),
                        Tipo = datos.Lector["Tipo"].ToString(),
                        Estado = (bool)datos.Lector["Estado"],
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Imagen = datos.Lector["Imagen"].ToString(),
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        Anio = (int)datos.Lector["Anio"],
                        PrecioPorDia = (decimal)datos.Lector["PrecioPorDia"],

                    };

                    lista.Add(vehiculo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }





    }
}
