using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public string Patente { get; set; }

        public double Precio { get; set; }

        private string modelocompleto;

    
        public string ModeloCompleto
        {
            get { return Modelo +" "+ combustible.NombreCombustible; }
            set { modelocompleto = value; }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
