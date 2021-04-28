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
    public class ServiciosAlquileres:IServiciosAlquileres
    {
        private ConexionBd _conexionBd;
        private IRepositorioAlquileres _repositorio;
        private IRepositorioAutos _repositorioAutos;
        private IRepositorioClientes _repositorioClientes;
        private IRepositorioEmpleados _repositorioEmpleados;

        public ServiciosAlquileres(ConexionBd conexionBd, IRepositorioAlquileres repositorio, IRepositorioAutos repositorioAutos, IRepositorioClientes repositorioClientes, IRepositorioEmpleados repositorioEmpleados)
        {
            _conexionBd = conexionBd;
            _repositorio = repositorio;
            _repositorioAutos = repositorioAutos;
            _repositorioClientes = repositorioClientes;
            _repositorioEmpleados = repositorioEmpleados;
        }

        public ServiciosAlquileres()
        {
            
        }
        public List<Alquiler> GetAlquiler()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetAlquiler();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Alquiler GetAlquilerPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioAutos = new RepositorioAutos(_conexionBd.AbrirConexion());
                _repositorioClientes = new RepositorioClientes(_conexionBd.AbrirConexion());
                _repositorioEmpleados = new RepositorioEmpleados(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion(), _repositorioAutos,
                    _repositorioClientes, _repositorioEmpleados);
                var alquiler = _repositorio.GetAlquilerPorId(id);
                _conexionBd.CerrarConexion();
                return alquiler;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Alquiler alquiler)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioAutos = new RepositorioAutos(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                _repositorio.Guardar(alquiler);
                _repositorioAutos.EditarActivo(alquiler.auto);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Borrar(Alquiler alquilerId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                _repositorio.Borrar(alquilerId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Alquiler alquiler)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(alquiler);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Alquiler alquiler)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(alquiler);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Alquiler> GetAlquiler(ClienteListDto cliente)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetAlquiler(cliente);
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
