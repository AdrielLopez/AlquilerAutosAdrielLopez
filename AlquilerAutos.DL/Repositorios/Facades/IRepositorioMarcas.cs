using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioMarcas
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
