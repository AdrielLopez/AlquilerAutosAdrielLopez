using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioAutos
    {
        List<Auto> GetAuto();

        Auto GetAutoPorId(int id);
        void Guardar(Auto auto);
        void Borrar(Auto autoId);
        bool Existe(Auto auto);
        bool EstaRelacionado(Auto auto);
        List<Auto> GetAuto(Marca marca);
      //  void EditarStock(Auto alquilerAuto);
        List<Auto> GetAuto(Auto automovil);
        void EditarActivo(Auto alquilerAuto);
    }
}
