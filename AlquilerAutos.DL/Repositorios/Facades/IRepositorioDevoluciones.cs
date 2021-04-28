using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioDevoluciones
    {
        List<Devolucion> GetDevolucion();

        Devolucion GetDevolucionPorId(int id);
        void Guardar(Devolucion devolucion);
    }
}
