using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.DTOs.Empleado;

namespace AlquilerAutos.BL.Entidades
{
    public class Alquiler
    {
        public int AlquilerId { get; set; }
        public Auto auto { get; set; }
        public ClienteEditDto cliente { get; set; }
        public EmpleadoEditDto empleado { get; set; }

        public DateTime fecha { get; set; }
        public DateTime fechaLimite { get; set; }

        public int Precio { get; set; }
    }
}
