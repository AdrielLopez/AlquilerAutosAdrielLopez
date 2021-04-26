using AlquilerAutos.BL.DTOs.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosEmpleados
    {
        List<EmpleadoListDto> GetLista();
        void Guardar(EmpleadoEditDto empleadoEditDto);
        bool Existe(EmpleadoEditDto empleadoEditDto);
        EmpleadoEditDto GetEmpleadoPorId(int empleadoId);
        bool EstaRelacionado(EmpleadoListDto empleadoListDto);
        void Borrar(int empleadoEmpleadoId);
    }
}
