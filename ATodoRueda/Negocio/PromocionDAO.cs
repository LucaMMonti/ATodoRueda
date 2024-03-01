using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PromocionDAO
    {
        public List<Promociones> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Promociones> listaPromociones = new List<Promociones>();

            try
            {
                datos.setearConsulta("SELECT Id, Codigo, Descuento, Estado FROM Promociones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Promociones promocion = new Promociones
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Descuento = (int)datos.Lector["Descuento"],
                        Estado = (bool)datos.Lector["Estado"]
                    };

                    listaPromociones.Add(promocion);
                }
                return listaPromociones;
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
        public bool CrearPromocion(Promociones promocion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Promociones (Codigo, Descuento, Estado) VALUES (@Codigo, @Descuento, @Estado)");
                datos.agregarParametro("@Codigo", promocion.Codigo);
                datos.agregarParametro("@Descuento", promocion.Descuento);
                datos.agregarParametro("@Estado", promocion.Estado);

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

        public Promociones ObtenerPromocionPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            Promociones promocion = new Promociones();
            try
            {
                datos.setearConsulta("SELECT Id, Codigo, Descuento, Estado FROM Promociones WHERE Codigo = @Codigo");
                datos.agregarParametro("@Codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    promocion = new Promociones
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Descuento = (int)datos.Lector["Descuento"],
                        Estado = (bool)datos.Lector["Estado"],
                    };
                }
                return promocion;
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

        public bool ModificarPromocion(Promociones promocion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Promociones SET Codigo = @Codigo, Descuento = @Descuento, Estado = @Estado WHERE Id = @Id");
                datos.agregarParametro("@Id", promocion.Id);
                datos.agregarParametro("@Codigo", promocion.Codigo);
                datos.agregarParametro("@Descuento", promocion.Descuento);
                datos.agregarParametro("@Estado", promocion.Estado);

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

        public bool EliminarPromocion(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Promociones WHERE Id = @Id");
                datos.agregarParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}    
