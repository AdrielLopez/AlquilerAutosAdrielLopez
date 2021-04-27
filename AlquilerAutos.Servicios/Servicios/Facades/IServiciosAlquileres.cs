using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosAlquileres
    {
        List<Alquiler> GetAlquiler();

        Alquiler GetAlquilerPorId(int id);
        void Guardar(Alquiler alquiler);
        void Borrar(Alquiler alquilerId);
        bool Existe(Alquiler alquiler);
        bool EstaRelacionado(Alquiler alquiler);
    }
}
