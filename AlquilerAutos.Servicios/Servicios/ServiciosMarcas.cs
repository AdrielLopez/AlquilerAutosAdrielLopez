using System;
using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosMarcas: IServiciosMarca

    {
        private IRepositorioMarcas _repositorio;
        private ConexionBd _conexionBd;

        public ServiciosMarcas()
        {
          
        }
        public List<Marca> GetMarcas()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetMarcas();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Marca GetMarcaPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                var marca = _repositorio.GetMarcaPorId(id);
                _conexionBd.CerrarConexion();
                return marca;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(Marca marca)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                _repositorio.Borrar(marca);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Marca marca)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(marca);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(Marca marca)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(marca);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Marca marca)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                _repositorio.Editar(marca);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void Guardar(Marca marca)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexionBd.AbrirConexion());
                _repositorio.Guardar(marca);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
