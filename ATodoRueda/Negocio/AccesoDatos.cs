using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace Negocio
{
    public class AccesoDatos
    {
        #region Variables
        private SqlConnection conexion; 
        private SqlCommand comando; 
        private SqlDataReader lector;
        #endregion
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos() 
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=ATodoRueda; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public bool ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                return true;

            }
            catch (Exception )
            {
                return false;
            }

        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        internal int ejecutarAccionReturn()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
        }
    }
}

