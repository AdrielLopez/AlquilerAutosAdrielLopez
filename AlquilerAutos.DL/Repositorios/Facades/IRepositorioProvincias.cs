using AlquilerAutos.BL.Entidades;
using System.Collections.Generic;
using AlquilerAutos.BL.DTOs.Provincia;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetProvincias();

        ProvinciaEditDto GetProvinciaPorId(int id);
        void Guardar(Provincia provincia);
        void Borrar(int id);
        bool Existe(Provincia provincia);
        bool EstaRelacionado(ProvinciaListDto provinciaListDto);
    }
}
