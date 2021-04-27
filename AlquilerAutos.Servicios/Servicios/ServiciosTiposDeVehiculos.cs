using System;
using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosTiposDeVehiculos:IServiciosTipoDeVehiculo

    {
        private IRepositorioTiposDeVehiculos _repositorio;
        private ConexionBd _conexionBd;
        public List<TipoDeVehiculo> GetTipoDeVehiculos()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetTipoDeVehiculos();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeVehiculo GetTipoDeVehiculoPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                var tipovehiculo = _repositorio.GetTipoDeVehiculoPorId(id);
                _conexionBd.CerrarConexion();
                return tipovehiculo;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(TipoDeVehiculo vehiculo)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                _repositorio.Borrar(vehiculo);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeVehiculo vehiculo)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(vehiculo);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(TipoDeVehiculo vehiculo)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(vehiculo);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(TipoDeVehiculo vehiculo)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                _repositorio.Editar(vehiculo);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void Guardar(TipoDeVehiculo vehiculo)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeVehiculos(_conexionBd.AbrirConexion());
                _repositorio.Guardar(vehiculo);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
