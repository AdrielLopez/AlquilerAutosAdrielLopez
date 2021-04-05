using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioTiposDeVehiculos
    {
        List<TipoDeVehiculo> GetTipoDeVehiculos();
        TipoDeVehiculo GetTipoDeVehiculoPorId(int id);
        void Guardar(TipoDeVehiculo vehiculo);
        void Borrar(TipoDeVehiculo vehiculo);
        bool Existe(TipoDeVehiculo vehiculo);

        bool EstaRelacionado(TipoDeVehiculo vehiculo);
        void Editar(TipoDeVehiculo vehiculo);
    }
}
