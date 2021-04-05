using System;

namespace AlquilerAutos.BL.Entidades
{
    public class TipoDeDocumento:ICloneable
    {
        public int TipoDeDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
