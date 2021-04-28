using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosAutos
    {
        List<Auto> GetAuto();

        Auto GetAutoPorId(int id);
        void Guardar(Auto auto);
        void Borrar(Auto autoId);
        bool Existe(Auto auto);
        bool EstaRelacionado(Auto auto);
        List<Auto> GetAuto(Marca marca);
        List<Auto> GetAuto(Auto auto);
    }
}
