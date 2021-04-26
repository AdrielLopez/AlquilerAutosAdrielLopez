using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface iServiciosProvincia
    {
        List<ProvinciaListDto> GetProvincias();
        ProvinciaEditDto GetProvinciaPorId(int id);

        void Guardar(ProvinciaEditDto provincia);

        void Borrar(int id);
        bool Existe(ProvinciaEditDto provincia);
        bool EstaRelacionado(ProvinciaListDto provinciaListDto);

    }
}
