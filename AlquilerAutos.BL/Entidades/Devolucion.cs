using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.BL.Entidades
{
    public class Devolucion
    {
        public int DevolucionId { get; set; }
        public Alquiler alquiler { get; set; }

        public DateTime FechaDevolucion { get; set; }
    }
}
