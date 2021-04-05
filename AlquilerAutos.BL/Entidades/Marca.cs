using System;

namespace AlquilerAutos.BL.Entidades
{
    public class Marca:ICloneable
    {
        public int MarcaId { get; set; }
        public string NombreMarca { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
