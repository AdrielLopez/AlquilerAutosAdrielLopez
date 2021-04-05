using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.BL.Entidades
{
    public class Combustible:ICloneable
    {
        public int CombustibleId { get; set; }
        public string NombreCombustible { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
