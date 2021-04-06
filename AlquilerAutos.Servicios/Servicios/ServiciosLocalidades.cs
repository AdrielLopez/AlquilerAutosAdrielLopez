using System;
using System.Collections.Generic;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosLocalidades:IServiciosLocalidades
    {
        private  ConexionBd _conexionBd;
        private  IRepositorioLocalidades _repositorio;
        private IRepositorioProvincias _repositorioProvincias;

        public List<LocalidadListDto> GetLocalidades()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidades(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLocalidades();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidades(_conexionBd.AbrirConexion());
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion()); 
                var localidad = new Localidad
                {
                    LocalidadId = localidadDto.LocalidadId,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    Provincia = _repositorioProvincias.GetProvinciaPorId(localidadDto.ProvinciaId)

                };
                _repositorio.Guardar(localidad);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(LocalidadEditDto localidadDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidades(_conexionBd.AbrirConexion());
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var localidad = new Localidad
                {
                    LocalidadId = localidadDto.LocalidadId,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    Provincia = _repositorioProvincias.GetProvinciaPorId(localidadDto.ProvinciaId)

                };
                var existe = _repositorio.Existe(localidad);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidades(_conexionBd.AbrirConexion());
                _repositorio.Borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioLocalidades(_conexionBd.AbrirConexion(),_repositorioProvincias);
                var localidad = _repositorio.GetLocalidadPorId(id);
                _conexionBd.CerrarConexion();
                return localidad;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
