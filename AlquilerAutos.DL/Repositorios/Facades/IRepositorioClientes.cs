using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetLista();

        void Guardar(Cliente cliente);
        bool Existe(Cliente cliente);
        ClienteEditDto GetClientePorId(int clienteId);
        bool EstaRelacionado(ClienteListDto clienteListDto);
        void Borrar(int clienteClienteId);
    }
}
