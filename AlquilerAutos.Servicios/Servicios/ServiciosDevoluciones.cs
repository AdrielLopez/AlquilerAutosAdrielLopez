using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Servicios.Servicios
{
    public class ServiciosDevoluciones:IServiciosDevoluciones
    {
        private ConexionBd _conexionBd;
        private IRepositorioAlquileres _repositorioAlquileres;
        private IRepositorioDevoluciones _repositorio;
        private IRepositorioAutos _repositorioAutos;
        private IRepositorioClientes _repositorioClientes;
        private IRepositorioEmpleados _repositorioEmpleados;
        public List<Devolucion> GetDevolucion()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioDevoluciones(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetDevolucion();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Devolucion GetDevolucionPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioAlquileres = new RepositorioAlquileres(_conexionBd.AbrirConexion(),_repositorioAutos,_repositorioClientes,_repositorioEmpleados);
                _repositorio = new RepositorioDevoluciones(_conexionBd.AbrirConexion(),_repositorioAlquileres);
                var auto = _repositorio.GetDevolucionPorId(id);
                _conexionBd.CerrarConexion();
                return auto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Devolucion devolucion)
        {
            try
            {
             
                _conexionBd = new ConexionBd();
                _repositorioAlquileres = new RepositorioAlquileres(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioDevoluciones(_conexionBd.AbrirConexion());
                _repositorio.Guardar(devolucion);
                _repositorioAlquileres.EditarStock(devolucion.alquiler.auto);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
