using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioDAO
    {
        public List<Usuario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Apellido, Contrasena, CorreoElectronico, Telefono, Direccion, FechaNacimiento, FechaRegistro, Rol, Estado FROM Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Contrasena = datos.Lector["Contrasena"].ToString(),
                        CorreoElectronico = datos.Lector["CorreoElectronico"].ToString(),
                        Telefono = datos.Lector["Telefono"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"],
                        FechaRegistro = (DateTime)datos.Lector["FechaRegistro"],
                        Rol = (int)datos.Lector["Rol"],
                        Estado = (bool)datos.Lector["Estado"]
                    };

                    listaUsuarios.Add(usuario);
                }
                return listaUsuarios;
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

        public bool Registrar(Usuario usuario)
        {

            // Primero verifica si el correo electrónico ya existe
            if (ExisteCorreoElectronico(usuario.CorreoElectronico))
            {
                return false;
            }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Usuario (Nombre, Apellido, Contrasena, CorreoElectronico, Telefono, Direccion, FechaNacimiento, FechaRegistro, Rol, Estado) VALUES (@Nombre, @Apellido, @Contrasena, @CorreoElectronico, @Telefono, @Direccion, @FechaNacimiento, GETDATE(), @Rol, @Estado)");

                datos.agregarParametro("@Nombre", usuario.Nombre);
                datos.agregarParametro("@Apellido", usuario.Apellido);
                datos.agregarParametro("@Contrasena", usuario.Contrasena);
                datos.agregarParametro("@CorreoElectronico", usuario.CorreoElectronico);
                datos.agregarParametro("@Telefono", usuario.Telefono);
                datos.agregarParametro("@Direccion", usuario.Direccion);
                datos.agregarParametro("@FechaNacimiento", usuario.FechaNacimiento);
                datos.agregarParametro("@Rol", 3);
                datos.agregarParametro("@Estado", 1);

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

        public bool ExisteCorreoElectronico(string correoElectronico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT CorreoElectronico FROM Usuario WHERE CorreoElectronico = @CorreoElectronico");
                datos.agregarParametro("@CorreoElectronico", correoElectronico);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
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
