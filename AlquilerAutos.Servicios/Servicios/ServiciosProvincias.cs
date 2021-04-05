using System;
using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosProvincias:iServiciosProvincia

    {
        private IRepositorioProvincias _repositorio;
        private ConexionBd _conexionBd;

        public ServiciosProvincias()
        {
           
        }
        public List<Provincia> GetProvincias()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetProvincias();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorio.Guardar(provincia);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Provincia provincia)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorio.Borrar(provincia);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var existe =_repositorio.Existe(provincia);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(provincia);
                _conexionBd.CerrarConexion();
                return estaRelacionado; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Provincia provincia)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorio.Editar(provincia);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
