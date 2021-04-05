using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDeVehiculo
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
