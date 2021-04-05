using System.Collections.Generic;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosLocalidades
    {
        List<LocalidadListDto> GetLocalidades();

        void Guardar(Localidad localidad);
        bool Existe(Localidad localidad);
        void Borrar(int localidadDtoLocalidadId);

        Localidad GetLocalidadPorId(int id);
    }
}
