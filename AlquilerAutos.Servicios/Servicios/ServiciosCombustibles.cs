using System;
using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosCombustibles:IServiciosCombustible
    {
        private IRepositorioCombustibles _repositorio;
        private ConexionBd _conexionBd;
        public List<Combustible> GetCombustibles()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetCombustibles();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Combustible GetCombustiblePorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Combustible combustible)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                _repositorio.Guardar(combustible);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Combustible combustible)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                _repositorio.Borrar(combustible);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Combustible combustible)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(combustible);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(Combustible combustible)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(combustible);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Combustible combustible)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCombustibles(_conexionBd.AbrirConexion());
                _repositorio.Editar(combustible);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
