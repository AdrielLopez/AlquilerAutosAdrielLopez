using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioDevoluciones:IRepositorioDevoluciones
    {
        private SqlConnection _sqlConnection;
        private IRepositorioAutos _repositorioAutos;
        private IRepositorioClientes _repositorioClientes;
        private IRepositorioEmpleados _repositorioEmpleados;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;
        private IRepositorioMarcas _repositorioMarcas;
        private IRepositorioCombustibles _repositorioCombustibles;
        private IRepositorioTiposDeVehiculos _repositorioTiposDeVehiculos;
        private IRepositorioAlquileres _repositorioAlquileres;

        public RepositorioDevoluciones(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public RepositorioDevoluciones(SqlConnection sqlConnection, IRepositorioAlquileres repositorioAlquileres)
        {
            _sqlConnection = sqlConnection;
            _repositorioAlquileres = repositorioAlquileres;
        }
        public List<Devolucion> GetDevolucion()
        {
            List<Devolucion> lista = new List<Devolucion>();
            try
            {
                string cadenaComando =
                    "SELECT        D.DevolucionId, A.AlquilerId, D.FechaDevolucion FROM Devoluciones AS D " +
                    "INNER JOIN Alquileres AS A ON D.AlquilerId = A.AlquilerId ";
                                       
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var devolucion = ConstruirDevolucion(reader);
                    lista.Add(devolucion);
                }

                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private Devolucion ConstruirDevolucion(SqlDataReader reader)
        {
            _repositorioAlquileres = new RepositorioAlquileres(_sqlConnection, _repositorioAutos, _repositorioClientes,
                _repositorioEmpleados);
            _repositorioProvincias = new RepositorioProvincias(_sqlConnection);
            _repositorioLocalidades = new RepositorioLocalidades(_sqlConnection, _repositorioProvincias);
            _repositorioCombustibles = new RepositorioCombustibles(_sqlConnection);
            _repositorioTiposDeVehiculos = new RepositorioTiposDeVehiculos(_sqlConnection);
            _repositorioMarcas = new RepositorioMarcas(_sqlConnection);
            _repositorioAutos = new RepositorioAutos(_sqlConnection, _repositorioCombustibles, _repositorioMarcas, _repositorioTiposDeVehiculos);
            _repositorioClientes = new RepositorioClientes(_sqlConnection, _repositorioProvincias, _repositorioLocalidades);
            _repositorioEmpleados = new RepositorioEmpleados(_sqlConnection, _repositorioProvincias, _repositorioLocalidades);
            return new Devolucion()
            {
                DevolucionId = reader.GetInt32(0),
                alquiler = _repositorioAlquileres.GetAlquilerPorId(reader.GetInt32(1)),
                FechaDevolucion = reader.GetDateTime(2)
            };
        }

        public Devolucion GetDevolucionPorId(int id)
        {
            Devolucion devolucion = null;
            try
            {
                string cadenaComando =
                    "SELECT DevolucionId, AlquilerId, FechaDevolucion  FROM Devoluciones WHERE DevolucionId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    devolucion = ConstruirDevolucion(reader);
                }

                reader.Close();
                return devolucion;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer la devolucion");
            }
        }

        public void Guardar(Devolucion devolucion)
        {
            try
            {
                string cadenaComando = "INSERT INTO Devoluciones VALUES(@alquilerId, @fechadevolucion)";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@alquilerId", devolucion.alquiler.AlquilerId);
                comando.Parameters.AddWithValue("@fechadevolucion", devolucion.FechaDevolucion);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _sqlConnection);
                devolucion.DevolucionId = (int)(decimal)comando.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
