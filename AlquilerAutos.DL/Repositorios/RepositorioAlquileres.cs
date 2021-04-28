using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioAlquileres:IRepositorioAlquileres
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
        public RepositorioAlquileres(SqlConnection sqlConnection, IRepositorioAutos repositorioAutos, IRepositorioClientes repositorioClientes, IRepositorioEmpleados repositorioEmpleados)
        {
            _sqlConnection = sqlConnection;
            _repositorioAutos = repositorioAutos;
            _repositorioClientes = repositorioClientes;
            _repositorioEmpleados = repositorioEmpleados;
     }

        public RepositorioAlquileres(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
      

        public Alquiler GetAlquilerPorId(int id)
        {
            Alquiler alquiler = null;
            try
            {
                string cadenaComando =
                    "SELECT AlquilerId, AutoId, ClienteId, EmpleadoId," +
                    " Fecha, FechaLimite, Precio FROM Alquileres WHERE AlquilerId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    alquiler = ConstruirAlquiler(reader);
                }

                reader.Close();
                return alquiler;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el Alquiler");
            }
        }

        public void Guardar(Alquiler alquiler)
        {
            if (alquiler.AlquilerId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Alquileres VALUES(@autoId, @clienteId, @empleadoId, @fecha," +
                                           "@fechalimite, @precio)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@autoId", alquiler.auto.AutoId);
                    comando.Parameters.AddWithValue("@clienteId", alquiler.cliente.ClienteId);
                    comando.Parameters.AddWithValue("@empleadoId", alquiler.empleado.EmpleadoId);
                    comando.Parameters.AddWithValue("@fecha", alquiler.fecha);
                    comando.Parameters.AddWithValue("@fechalimite", alquiler.fechaLimite);
                    comando.Parameters.AddWithValue("@precio", alquiler.Precio);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    alquiler.AlquilerId = (int)(decimal)comando.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                try
                {
                    string cadenaComando =
                        "UPDATE Alquileres SET AutoId=@autoId, ClienteId =@clienteId, EmpleadoId=@empleadoId" +
                        ", Fecha=@fecha, FechaLimite=@fechalimite, Precio=@precio WHERE AlquilerId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@autoId", alquiler.auto.AutoId);
                    comando.Parameters.AddWithValue("@clienteId", alquiler.cliente.ClienteId);
                    comando.Parameters.AddWithValue("@empleadoId", alquiler.empleado.EmpleadoId);
                    comando.Parameters.AddWithValue("@fecha", alquiler.fecha);
                    comando.Parameters.AddWithValue("@fechalimite", alquiler.fechaLimite);
                    comando.Parameters.AddWithValue("@precio", alquiler.Precio);

                    comando.Parameters.AddWithValue("@id", alquiler.AlquilerId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void Borrar(Alquiler alquilerId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Alquileres WHERE AlquilerId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", alquilerId.AlquilerId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denegada");
                }

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Alquiler alquiler)
        {
           /* try
            {
                if (alquiler.AlquilerId == 0)
                {
                    string cadenaComando = "SELECT * FROM Alquileres WHERE MarcaId=@marcaId AND Modelo=@modelo";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@marcaId", auto.marca.MarcaId);
                    comando.Parameters.AddWithValue("@modelo", auto.Modelo);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Autos WHERE MarcaId=@marcaId AND Modelo=@modelo AND AutoId<>@AutoId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@marcaId", auto.marca.MarcaId);
                    comando.Parameters.AddWithValue("@modelo", auto.Modelo);
                    comando.Parameters.AddWithValue("@AutoId", auto.AutoId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           */
           return false;
        }

        public bool EstaRelacionado(Alquiler alquiler)
        {
            return false;
        }

        public List<Alquiler> GetAlquiler()
        {
            List<Alquiler> lista = new List<Alquiler>();
            try
            {
                string cadenaComando = "SELECT        AL.AlquilerId, a.AutoId, C.ClienteId, E.EmpleadoId, AL.Fecha, AL.FechaLimite, AL.Precio FROM Alquileres AS AL INNER JOIN " +
                                       "Autos AS a ON AL.AutoId = a.AutoId INNER JOIN Clientes AS C ON AL.ClienteId = C.ClienteId INNER JOIN Empleados AS E ON AL.EmpleadoId = E.EmpleadoId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var Auto = ConstruirAlquiler(reader);
                    lista.Add(Auto);
                }

                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditarStock(Auto alquilerAuto)
        {
            try
            {
                string cadenaComando = "UPDATE Autos SET Stock=Stock +1 where AutoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", alquilerAuto.AutoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Alquiler> GetAlquiler(ClienteListDto cliente)
        {
            List<Alquiler> lista = new List<Alquiler>();
            try
            {
                string cadenaComando = "SELECT        AL.AlquilerId, a.AutoId, C.ClienteId, E.EmpleadoId, AL.Fecha, AL.FechaLimite, AL.Precio FROM Alquileres AS AL INNER JOIN " +
                                       "Autos AS a ON AL.AutoId = a.AutoId INNER JOIN Clientes AS C ON AL.ClienteId = C.ClienteId INNER JOIN Empleados AS E ON AL.EmpleadoId = E.EmpleadoId WHERE C.ClienteId=@id AND AL.AlquilerId NOT IN (" +
                                       "SELECT AlquilerId FROM Devoluciones)";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var Auto = ConstruirAlquiler(reader);
                    lista.Add(Auto);
                }

                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private Alquiler ConstruirAlquiler(SqlDataReader reader)
        {
            _repositorioProvincias = new RepositorioProvincias(_sqlConnection);
            _repositorioLocalidades = new RepositorioLocalidades(_sqlConnection, _repositorioProvincias);
            _repositorioCombustibles = new RepositorioCombustibles(_sqlConnection);
            _repositorioTiposDeVehiculos = new RepositorioTiposDeVehiculos(_sqlConnection);
            _repositorioMarcas = new RepositorioMarcas(_sqlConnection);
            _repositorioAutos = new RepositorioAutos(_sqlConnection,_repositorioCombustibles,_repositorioMarcas,_repositorioTiposDeVehiculos);
            _repositorioClientes = new RepositorioClientes(_sqlConnection,_repositorioProvincias,_repositorioLocalidades);
            _repositorioEmpleados = new RepositorioEmpleados(_sqlConnection,_repositorioProvincias,_repositorioLocalidades);
            return new Alquiler()
            {
               AlquilerId = reader.GetInt32(0),
               auto = _repositorioAutos.GetAutoPorId(reader.GetInt32(1)),
               cliente = _repositorioClientes.GetClientePorId(reader.GetInt32(2)),
               empleado = _repositorioEmpleados.GetEmpleadoPorId(reader.GetInt32(3)),
               fecha = reader.GetDateTime(4),
               fechaLimite = reader.GetDateTime(5),
               Precio = reader.GetInt32(6)
            };
        }
    }
}
