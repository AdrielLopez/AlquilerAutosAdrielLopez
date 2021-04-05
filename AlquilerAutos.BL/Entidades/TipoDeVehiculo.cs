using System;
using System.Security.AccessControl;

namespace AlquilerAutos.BL.Entidades
{
    public class TipoDeVehiculo:ICloneable
    {
        public int TipoDeVehiculoId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
