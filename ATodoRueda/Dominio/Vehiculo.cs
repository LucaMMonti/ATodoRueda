using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int IdUsuario { get; set; }
        public int Anio { get; set; }
        public decimal PrecioPorDia { get; set; }
        public bool Estado { get; set; }
    }
}
