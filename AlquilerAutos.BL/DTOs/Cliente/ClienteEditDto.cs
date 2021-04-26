using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;

namespace AlquilerAutos.BL.DTOs.Cliente
{
    public class ClienteEditDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Entidades.TipoDeDocumento tipodocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public LocalidadListDto Localidad { get; set; }
        public ProvinciaListDto Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
