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
                datos.setearConsulta("SELECT Id, Nombre, Apellido, Contrasena, NumeroDocumento, CorreoElectronico, Telefono, Direccion, FechaNacimiento, FechaRegistro, Rol, Estado FROM Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Contrasena = datos.Lector["Contrasena"].ToString(),
                        NumeroDocumento = (int)datos.Lector["NumeroDocumento"],
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

        public Usuario ObtenerUsuarioPorId(string userId)
        {
            Usuario usuario = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Apellido, Contrasena, NumeroDocumento, CorreoElectronico, Telefono, Direccion, FechaNacimiento, Rol FROM Usuarios WHERE Id = @Id");
                datos.agregarParametro("@Id", userId);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Contrasena = datos.Lector["Contrasena"].ToString(),
                        NumeroDocumento = (int)datos.Lector["NumeroDocumento"],
                        CorreoElectronico = datos.Lector["CorreoElectronico"].ToString(),
                        Telefono = datos.Lector["Telefono"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        FechaNacimiento = datos.Lector["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(datos.Lector["FechaNacimiento"]) : DateTime.MinValue, // Asegúrate de manejar nulls correctamente
                        Rol = (int)datos.Lector["Rol"],
                    };
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

            return null;
        }

        public bool Registrar(Usuario usuario)
        {
               AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("INSERT INTO Usuarios (Nombre, Apellido, Contrasena, NumeroDocumento, CorreoElectronico, Telefono, Direccion, FechaNacimiento, FechaRegistro, Rol, Estado) VALUES (@Nombre, @Apellido, @Contrasena, @CorreoElectronico, @Telefono, @Direccion, @FechaNacimiento, GETDATE(), @Rol, @Estado)");

                    datos.agregarParametro("@Nombre", usuario.Nombre);
                    datos.agregarParametro("@Apellido", usuario.Apellido);
                    datos.agregarParametro("@Contrasena", usuario.Contrasena);
                    datos.agregarParametro("@NumeroDocumento", usuario.NumeroDocumento);
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
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
        }

        public Usuario IniciarSesion(string correo, string contraseña)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SELECT Id, Nombre, Apellido, Rol, Estado FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico AND Contrasena = @Contrasena AND Estado = 1");
                    datos.agregarParametro("@CorreoElectronico", correo);
                    datos.agregarParametro("@Contrasena", contraseña);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new Usuario
                        {
                            Id = (int)datos.Lector["Id"],
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Apellido = datos.Lector["Apellido"].ToString(),
                            Rol = (int)datos.Lector["Rol"],
                            Estado = (bool)datos.Lector["Estado"]
                            // Puedes agregar más campos si son necesarios
                        };
                    }
                    else
                    {
                        return null;
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
            }

        public bool AgregarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Usuarios (Nombre, Apellido, Contrasena, NumeroDocumento, CorreoElectronico, Telefono, Direccion, FechaNacimiento, FechaRegistro, Rol, Estado) " +
                                                  "VALUES (@Nombre, @Apellido, @Contrasena, @NumeroDocumento, @CorreoElectronico, @Telefono, @Direccion, @FechaNacimiento, GETDATE(), @Rol, @Estado)");
               
                datos.agregarParametro("@Nombre", usuario.Nombre);
                datos.agregarParametro("@Apellido", usuario.Apellido);
                datos.agregarParametro("@Contrasena", usuario.Contrasena); //hashear la contraseña
                datos.agregarParametro("@NumeroDocumento", usuario.NumeroDocumento);
                datos.agregarParametro("@CorreoElectronico", usuario.CorreoElectronico);
                datos.agregarParametro("@Telefono", usuario.Telefono);
                datos.agregarParametro("@Direccion", usuario.Direccion);
                datos.agregarParametro("@FechaNacimiento", usuario.FechaNacimiento);
                datos.agregarParametro("@Rol", usuario.Rol);
                datos.agregarParametro("@Estado", usuario.Estado);

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

        public bool ActualizarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, NumeroDocumento = @NumeroDocumento, Contrasena = @Contrasena, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, Rol = @Rol WHERE Id = @Id");
                datos.agregarParametro("@Id", usuario.Id);
                datos.agregarParametro("@Nombre", usuario.Nombre);
                datos.agregarParametro("@Apellido", usuario.Apellido);
                datos.agregarParametro("@Contrasena", usuario.Contrasena); //hashear la contraseña
                datos.agregarParametro("@NumeroDocumento", usuario.NumeroDocumento);
                datos.agregarParametro("@CorreoElectronico", usuario.CorreoElectronico);
                datos.agregarParametro("@Telefono", usuario.Telefono);
                datos.agregarParametro("@Direccion", usuario.Direccion);
                datos.agregarParametro("@FechaNacimiento", usuario.FechaNacimiento);
                datos.agregarParametro("@Rol", usuario.Rol);


                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
