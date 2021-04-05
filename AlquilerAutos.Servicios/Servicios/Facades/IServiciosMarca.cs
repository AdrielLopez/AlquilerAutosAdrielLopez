using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosMarca
    {
        List<Marca> GetMarcas();

        Marca GetMarcaPorId(int id);
        void Guardar(Marca marca);
        void Borrar(Marca marca);
        bool Existe(Marca marca);
        bool EstaRelacionado(Marca marca);
        void Editar(Marca marca);
    }
}
