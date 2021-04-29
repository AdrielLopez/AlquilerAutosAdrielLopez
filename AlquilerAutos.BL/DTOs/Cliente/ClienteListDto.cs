using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.BL.DTOs.Cliente
{
    public class ClienteListDto:ICloneable
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string NroDoc { get; set; }

        private string nombrecompleto;

        public string NombreCompleto
        {
            get { return Nombre +" " + Apellido; }
            set { nombrecompleto = value; }
        }



        public string FullName
        {
            get
            {
                return Nombre + ", " + Apellido;
            }
        }

        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

