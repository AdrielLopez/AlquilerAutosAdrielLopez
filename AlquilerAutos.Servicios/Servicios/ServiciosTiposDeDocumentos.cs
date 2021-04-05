using System;
using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosTiposDeDocumentos:IServiciosTIpoDeDocumento
    {
        private IRepositorioTiposDeDocumentos _repositorio;
        private ConexionBd _conexionBd;
        public List<TipoDeDocumento> GetTipoDeDeDocumentos()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetTipoDeDeDocumentos();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumento GetTipoDeDocumentoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Borrar(TipoDeDocumento documento)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexionBd.AbrirConexion());
                _repositorio.Borrar(documento);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumento documento)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(documento);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(TipoDeDocumento documento)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(documento);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(TipoDeDocumento documento)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexionBd.AbrirConexion());
                _repositorio.Editar(documento);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void Guardar(TipoDeDocumento documento)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexionBd.AbrirConexion());
                _repositorio.Guardar(documento);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
