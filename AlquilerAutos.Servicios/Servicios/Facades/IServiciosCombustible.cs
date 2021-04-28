using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosCombustible
    {
        List<Combustible> GetCombustibles();
        Combustible GetCombustiblePorId(int id);
        void Guardar(Combustible combustible);
        void Borrar(Combustible combustible);
        bool Existe(Combustible combustible);
        bool EstaRelacionado(Combustible combustible);
        void Editar(Combustible combustible);
        List<Combustible> GetCombustibles(Auto auto);
    }
}
