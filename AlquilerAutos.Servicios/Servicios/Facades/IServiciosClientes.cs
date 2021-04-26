using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Cliente;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosClientes
    {
        List<ClienteListDto> GetLista();
        void Guardar(ClienteEditDto clienteEditDto);
        bool Existe(ClienteEditDto clienteEditDto);
        ClienteEditDto GetClientePorId(int clienteId);
        bool EstaRelacionado(ClienteListDto clienteListDto);
        void Borrar(int clienteClienteId);
    }
}
