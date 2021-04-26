using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServicioEmpleados : IServiciosEmpleados
    {
        private ConexionBd _conexionBd;
        private IRepositorioEmpleados _repositorio;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;

        public ServicioEmpleados(ConexionBd conexionBd, IRepositorioEmpleados repositorio, IRepositorioLocalidades repositorioLocalidades, IRepositorioProvincias repositorioProvincias)
        {
            _conexionBd = conexionBd;
            _repositorio = repositorio;
            _repositorioLocalidades = repositorioLocalidades;
            _repositorioProvincias = repositorioProvincias;
        }

        public ServicioEmpleados()
        {
            
        }
        public List<EmpleadoListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioEmpleados(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(EmpleadoEditDto empleadoEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioEmpleados(_conexionBd.AbrirConexion());
                Empleado empleado = new Empleado
                {
                    Nombre = empleadoEditDto.Nombre,
                    Apellido = empleadoEditDto.Apellido,
                    TipoDeDocumentoId = empleadoEditDto.tipodocumento.TipoDeDocumentoId,
                    NroDocumento = empleadoEditDto.NroDocumento,
                    LocalidadId = empleadoEditDto.Localidad.LocalidadId,
                    ProvinciaId = empleadoEditDto.Provincia.ProvinciaId,
                    CorreoElectronico = empleadoEditDto.CorreoElectronico,
                    Direccion = empleadoEditDto.Direccion,
                    TelefonoFijo = empleadoEditDto.TelefonoFijo,
                    TelefonoMovil = empleadoEditDto.TelefonoMovil,
                    EmpleadoId = empleadoEditDto.EmpleadoId
                    

                };
                _repositorio.Guardar(empleado);
                empleadoEditDto.EmpleadoId = empleado.EmpleadoId;
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Existe(EmpleadoEditDto empleadoEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioEmpleados(_conexionBd.AbrirConexion());
                //_repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                Empleado empleado = new Empleado
                {
                   Nombre = empleadoEditDto.Nombre,
                   Apellido = empleadoEditDto.Apellido,
                   TipoDeDocumentoId = empleadoEditDto.tipodocumento.TipoDeDocumentoId,
                   NroDocumento = empleadoEditDto.NroDocumento,
                   LocalidadId = empleadoEditDto.Localidad.LocalidadId,
                   ProvinciaId = empleadoEditDto.Provincia.ProvinciaId,
                   CorreoElectronico = empleadoEditDto.CorreoElectronico,
                   Direccion = empleadoEditDto.Direccion,
                   TelefonoFijo = empleadoEditDto.TelefonoFijo,
                   TelefonoMovil = empleadoEditDto.TelefonoMovil,
                   EmpleadoId = empleadoEditDto.EmpleadoId


                };
                var existe = _repositorio.Existe(empleado);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmpleadoEditDto GetEmpleadoPorId(int empleadoId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidades(_conexionBd.AbrirConexion(), _repositorioProvincias);
                _repositorio = new RepositorioEmpleados(_conexionBd.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades);
                var empleado = _repositorio.GetEmpleadoPorId(empleadoId);
                _conexionBd.CerrarConexion();
                return empleado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(EmpleadoListDto empleadoListDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioEmpleados(_conexionBd.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(empleadoListDto);
                _conexionBd.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int empleadoEmpleadoId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioEmpleados(_conexionBd.AbrirConexion());
                _repositorio.Borrar(empleadoEmpleadoId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
