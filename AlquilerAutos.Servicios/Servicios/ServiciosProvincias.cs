using System;
using System.Collections.Generic;
using AlquilerAutos.BL.DTOs.Provincia;
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
        public List<ProvinciaListDto> GetProvincias()
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

        public ProvinciaEditDto GetProvinciaPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var provincia = _repositorio.GetProvinciaPorId(id);
                _conexionBd.CerrarConexion();
                return provincia;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var provincia = new Provincia
                {
                    ProvinciaId = provinciaDto.ProvinciaId,
                    NombreProvincia = provinciaDto.NombreProvincia
                };
                _repositorio.Guardar(provincia);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorio.Borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProvinciaEditDto provinciaDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var provincia = new Provincia
                {
                    ProvinciaId = provinciaDto.ProvinciaId,
                    NombreProvincia = provinciaDto.NombreProvincia
                };

                var existe = _repositorio.Existe(provincia);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(ProvinciaListDto provinciaListDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(provinciaListDto);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
