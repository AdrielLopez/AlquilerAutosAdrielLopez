using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosDevoluciones
    {
        List<Devolucion> GetDevolucion();

        Devolucion GetDevolucionPorId(int id);
        void Guardar(Devolucion devolucion);
       
       
    }
}
