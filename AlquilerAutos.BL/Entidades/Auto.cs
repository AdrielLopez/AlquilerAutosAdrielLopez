using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.BL.Entidades
{
    public class Auto:ICloneable
    {
        public int AutoId { get; set; }
        public Marca marca { get; set; }
        public TipoDeVehiculo tipodevehiculo { get; set; }
        public string Modelo { get; set; }
        public Combustible combustible { get; set; }
        public bool Activo { get; set; }
        public int Stock { get; set; }

        public double Precio { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
