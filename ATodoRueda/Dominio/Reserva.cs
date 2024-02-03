using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Pagado { get; set; }
        public bool Estado { get; set; }
    }
}
