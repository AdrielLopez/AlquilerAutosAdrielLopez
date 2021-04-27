using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosAutos:IServiciosAutos
    {
        private ConexionBd _conexionBd;
        private IRepositorioAutos _repositorio;
        private IRepositorioMarcas _repositorioMarcas;
        private IRepositorioTiposDeVehiculos _repositorioTiposDeVehiculos;
        private IRepositorioCombustibles _repositorioCombustibles;

        public ServiciosAutos(ConexionBd conexionBd, IRepositorioAutos repositorio, IRepositorioMarcas repositorioMarcas, IRepositorioTiposDeVehiculos repositorioTiposDeVehiculos, IRepositorioCombustibles repositorioCombustibles)
        {
            _conexionBd = conexionBd;
            _repositorio = repositorio;
            _repositorioMarcas = repositorioMarcas;
            _repositorioTiposDeVehiculos = repositorioTiposDeVehiculos;
            _repositorioCombustibles = repositorioCombustibles;
        }

        public ServiciosAutos()
        {
            
        }
        public List<Auto> GetAuto()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetAuto();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Auto auto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion());
                _repositorio.Guardar(auto);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Borrar(Auto autoId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion());
                _repositorio.Borrar(autoId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Auto auto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(auto);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Auto GetAutoPorId(int autoId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioCombustibles = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                _repositorioTiposDeVehiculos = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                _repositorioMarcas= new RepositorioMarcas(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion(), _repositorioCombustibles, _repositorioMarcas,_repositorioTiposDeVehiculos);
                var auto = _repositorio.GetAutoPorId(autoId);
                _conexionBd.CerrarConexion();
                return auto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Auto auto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(auto);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Auto> GetAuto(Marca marca)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAutos(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetAuto(marca);
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
