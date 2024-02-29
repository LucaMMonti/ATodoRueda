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

        public Promociones ObtenerPromocionPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            Promociones promocion = new Promociones();
            try
            {
                datos.setearConsulta("SELECT Id, Codigo, Descuento, Estado FROM Promociones WHERE Codigo = '@Codigo'");
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
    }
}    
