using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLocalidades();

        void Guardar(Localidad localidad);
        bool Existe(Localidad localidad);

        void Borrar(int id);

        Localidad GetLocalidadPorId(int id);
    }
}
