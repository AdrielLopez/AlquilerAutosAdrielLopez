using System.Collections.Generic;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosLocalidades
    {
        List<LocalidadListDto> GetLista(BL.DTOs.Provincia.ProvinciaListDto provinciaDto);

        void Guardar(LocalidadEditDto localidadEditDto);
        bool Existe(LocalidadEditDto localidad);
        void Borrar(int localidadDtoLocalidadId);

        LocalidadEditDto GetLocalidadPorId(int id);
        bool EstaRelacionado(LocalidadListDto localidadListDto);
    }
}
