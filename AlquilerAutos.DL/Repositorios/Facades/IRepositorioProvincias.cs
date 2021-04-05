using AlquilerAutos.BL.Entidades;
using System.Collections.Generic;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<Provincia> GetProvincias();

        Provincia GetProvinciaPorId(int id);
        void Guardar(Provincia provincia);
        void Borrar(Provincia provincia);
        bool Existe(Provincia provincia);

        bool EstaRelacionado(Provincia provincia);
        void Editar(Provincia provincia);
    }
}
