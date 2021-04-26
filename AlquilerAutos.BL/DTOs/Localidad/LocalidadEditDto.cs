using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Provincia;

namespace AlquilerAutos.BL.DTOs.Localidad
{
    public class LocalidadEditDto
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public ProvinciaListDto Provincia { get; set; }
        
    }

}
