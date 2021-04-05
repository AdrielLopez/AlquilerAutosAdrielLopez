using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface iServiciosProvincia
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
