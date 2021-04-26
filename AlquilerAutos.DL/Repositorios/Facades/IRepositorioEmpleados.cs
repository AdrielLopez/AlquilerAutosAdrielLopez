using AlquilerAutos.BL.DTOs.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioEmpleados
    {
        List<EmpleadoListDto> GetLista();

        void Guardar(Empleado empleado);
        bool Existe(Empleado empleado);
        EmpleadoEditDto GetEmpleadoPorId(int empleadoId);
        bool EstaRelacionado(EmpleadoListDto empleadoListDto);
        void Borrar(int empleadoEmpleadoId);
    }
}
