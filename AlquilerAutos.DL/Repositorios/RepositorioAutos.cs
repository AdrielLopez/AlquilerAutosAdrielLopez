using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioAutos:IRepositorioAutos
    {
        private SqlConnection _sqlConnection;
        private IRepositorioCombustibles repositorioCombustibles;
        private IRepositorioMarcas repositorioMarcas;
        private IRepositorioTiposDeVehiculos repositorioTiposDeVehiculos;

        public RepositorioAutos(SqlConnection sqlConnection, IRepositorioCombustibles repositorioCombustibles, IRepositorioMarcas repositorioMarcas, IRepositorioTiposDeVehiculos repositorioTiposDeVehiculos)
        {
            this._sqlConnection = sqlConnection;
            this.repositorioCombustibles = repositorioCombustibles;
            this.repositorioMarcas = repositorioMarcas;
            this.repositorioTiposDeVehiculos = repositorioTiposDeVehiculos;
        }

        public RepositorioAutos(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<Auto> GetAuto()
        {
            List<Auto> lista = new List<Auto>();
            try
            {
                string cadenaComando = "SELECT        A.AutoId, M.MarcaId, TV.TipoDeVehiculoId, C.CombustibleId, A.Modelo, A.Activo, A.Stock , A.Precio " +
                                       "FROM Autos AS A INNER JOIN Combustibles AS C ON A.CombustibleId = C.CombustibleId " +
                                       "INNER JOIN TiposDeVehiculos AS TV ON A.TipoDeVehiculoId = TV.TipoDeVehiculoId" +
                                       " INNER JOIN Marcas AS M ON A.MarcaId = M.MarcaId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var Auto = ConstruirAuto(reader);
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

        private Auto ConstruirAuto(SqlDataReader reader)
        {
            repositorioTiposDeVehiculos = new RepositorioTiposDeVehiculos(_sqlConnection);
            repositorioCombustibles = new RepositorioCombustibles(_sqlConnection);
            repositorioMarcas = new RepositorioMarcas(_sqlConnection);
            var auto = new Auto();
            auto.AutoId = reader.GetInt32(0);
            auto.marca = repositorioMarcas.GetMarcaPorId(reader.GetInt32(1));
            auto.tipodevehiculo = repositorioTiposDeVehiculos.GetTipoDeVehiculoPorId(reader.GetInt32(2));
            auto.combustible = repositorioCombustibles.GetCombustiblePorId(reader.GetInt32(3));
            auto.Modelo = reader.GetString(4);
            auto.Activo = reader.GetBoolean(5);
            auto.Stock = reader.GetInt32(6);
            auto.Precio =(double) reader.GetDecimal(7);
            return auto;

        }

        public void Guardar(Auto auto)
        {
            if (auto.AutoId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Autos VALUES(@marcaId, @tipovehiculoId, @modelo, @combustibleId," +
                                           "@activo, @stock, @precio)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@marcaId", auto.marca.MarcaId);
                    comando.Parameters.AddWithValue("@tipovehiculoId", auto.tipodevehiculo.TipoDeVehiculoId);
                    comando.Parameters.AddWithValue("@modelo", auto.Modelo);
                    comando.Parameters.AddWithValue("@combustibleId", auto.combustible.CombustibleId);
                    comando.Parameters.AddWithValue("@activo", auto.Activo);
                    comando.Parameters.AddWithValue("@stock", auto.Stock);
                    comando.Parameters.AddWithValue("@precio", auto.Precio);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    auto.AutoId = (int)(decimal)comando.ExecuteScalar();
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
                        "UPDATE Autos SET MarcaId=@marcaId, TipoDeVehiculoId =@tipovehiculoId, Modelo=@modelo" +
                        ", CombustibleId=@combustibleId, Activo=@activo, Stock=@stock, Precio=@precio WHERE AutoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@marcaId", auto.marca.MarcaId);
                    comando.Parameters.AddWithValue("@tipovehiculoId", auto.tipodevehiculo.TipoDeVehiculoId);
                    comando.Parameters.AddWithValue("@modelo", auto.Modelo);
                    comando.Parameters.AddWithValue("@combustibleId", auto.combustible.CombustibleId);
                    comando.Parameters.AddWithValue("@activo", auto.Activo);
                    comando.Parameters.AddWithValue("@stock", auto.Stock);
                    comando.Parameters.AddWithValue("@precio", auto.Precio);

                    comando.Parameters.AddWithValue("@id", auto.AutoId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }


        }

        public void Borrar(Auto autoId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Autos WHERE AutoId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", autoId.AutoId);
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

        public bool Existe(Auto auto)
        {
            try
            {
                if (auto.AutoId == 0)
                {
                    string cadenaComando = "SELECT * FROM Autos WHERE MarcaId=@marcaId AND Modelo=@modelo";
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

        }

        public Auto GetAutoPorId(int id)
        {
            Auto auto = null;
            try
            {
                string cadenaComando =
                    "SELECT        A.AutoId, M.MarcaId, TV.TipoDeVehiculoId, C.CombustibleId, A.Modelo, A.Activo, A.Stock, A.Precio " +
                    "FROM Autos AS A INNER JOIN Combustibles AS C ON A.CombustibleId = C.CombustibleId " +
                    "INNER JOIN TiposDeVehiculos AS TV ON A.TipoDeVehiculoId = TV.TipoDeVehiculoId" +
                    " INNER JOIN Marcas AS M ON A.MarcaId = M.MarcaId WHERE AutoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    auto = ConstruirAuto(reader);
                }

                reader.Close();
                return auto;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el Auto");
            }
        }



        public bool EstaRelacionado(Auto auto)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Alquileres WHERE AutoId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", auto.AutoId);
                int cantidadRegistros = (int)comando.ExecuteScalar();
                if (cantidadRegistros > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Auto> GetAuto(Marca marca)
        {
            List<Auto> lista = new List<Auto>();
            try
            {
                string cadenaComando = "SELECT        A.AutoId, M.MarcaId, TV.TipoDeVehiculoId, C.CombustibleId, A.Modelo, A.Activo, A.Stock, A.Precio " +
                                       "FROM Autos AS A INNER JOIN Combustibles AS C ON A.CombustibleId = C.CombustibleId " +
                                       "INNER JOIN TiposDeVehiculos AS TV ON A.TipoDeVehiculoId = TV.TipoDeVehiculoId" +
                                       " INNER JOIN Marcas AS M ON A.MarcaId = M.MarcaId WHERE M.MarcaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", marca.MarcaId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var Auto = ConstruirAuto(reader);
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
                string cadenaComando = "UPDATE Autos SET Stock=Stock -1 where AutoId=@id";
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
    }
}
