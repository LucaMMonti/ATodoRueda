using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public enum TipoUsuario
    {
        ADMIN = 1,
        GESTOR = 2,
        CLIENTE = 3
    }
    public class Usuario
    {
        public int Id { get; set; }
        public int NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Rol { get; set; }
        public bool Estado { get; set; }


        public Usuario(){ }

        public Usuario(string nombre, string apellido, string correoElectronico, string contrasena, int numeroDocumento, string telefono, string direccion, DateTime fechaNacimiento, int rol, bool estado)
        {
            Nombre = nombre;
            Apellido = apellido;
            CorreoElectronico = correoElectronico;
            Contrasena = contrasena;
            NumeroDocumento = numeroDocumento;
            Telefono = telefono;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Rol = rol;
            Estado = estado;
        }

    }
}
