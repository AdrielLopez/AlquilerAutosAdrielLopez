using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServicioClientes:IServiciosClientes
    {
        private ConexionBd _conexionBd;
        private IRepositorioClientes _repositorio;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;

        public ServicioClientes(ConexionBd conexionBd, IRepositorioClientes repositorio,
            IRepositorioLocalidades repositorioLocalidades, IRepositorioProvincias repositorioProvincias)
        {
            _conexionBd = conexionBd;
            _repositorio = repositorio;
            _repositorioLocalidades = repositorioLocalidades;
            _repositorioProvincias = repositorioProvincias;
        }

        public ServicioClientes()
        {

        }

        public List<ClienteListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ClienteEditDto ClienteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                Cliente Cliente = new Cliente
                {
                    Nombre = ClienteEditDto.Nombre,
                    Apellido = ClienteEditDto.Apellido,
                    TipoDeDocumentoId = ClienteEditDto.tipodocumento.TipoDeDocumentoId,
                    NroDocumento = ClienteEditDto.NroDocumento,
                    LocalidadId = ClienteEditDto.Localidad.LocalidadId,
                    ProvinciaId = ClienteEditDto.Provincia.ProvinciaId,
                    CorreoElectronico = ClienteEditDto.CorreoElectronico,
                    Direccion = ClienteEditDto.Direccion,
                    TelefonoFijo = ClienteEditDto.TelefonoFijo,
                    TelefonoMovil = ClienteEditDto.TelefonoMovil,
                    ClienteId = ClienteEditDto.ClienteId


                };
                _repositorio.Guardar(Cliente);
                ClienteEditDto.ClienteId = Cliente.ClienteId;
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Existe(ClienteEditDto ClienteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                //_repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                Cliente Cliente = new Cliente
                {
                    Nombre = ClienteEditDto.Nombre,
                    Apellido = ClienteEditDto.Apellido,
                    TipoDeDocumentoId = ClienteEditDto.tipodocumento.TipoDeDocumentoId,
                    NroDocumento = ClienteEditDto.NroDocumento,
                    LocalidadId = ClienteEditDto.Localidad.LocalidadId,
                    ProvinciaId = ClienteEditDto.Provincia.ProvinciaId,
                    CorreoElectronico = ClienteEditDto.CorreoElectronico,
                    Direccion = ClienteEditDto.Direccion,
                    TelefonoFijo = ClienteEditDto.TelefonoFijo,
                    TelefonoMovil = ClienteEditDto.TelefonoMovil,
                    ClienteId = ClienteEditDto.ClienteId
                    

                };
                var existe = _repositorio.Existe(Cliente);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ClienteEditDto GetClientePorId(int ClienteId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorioLocalidades =
                    new RepositorioLocalidades(_conexionBd.AbrirConexion(), _repositorioProvincias);
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion(), _repositorioProvincias,
                    _repositorioLocalidades);
                var Cliente = _repositorio.GetClientePorId(ClienteId);
                _conexionBd.CerrarConexion();
                return Cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ClienteListDto ClienteListDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(ClienteListDto);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int ClienteClienteId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                _repositorio.Borrar(ClienteClienteId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
