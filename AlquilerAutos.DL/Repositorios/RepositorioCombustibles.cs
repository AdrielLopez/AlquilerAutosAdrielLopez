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
    public class RepositorioCombustibles: IRepositorioCombustibles
    {
        private readonly SqlConnection _conexion;

        public RepositorioCombustibles(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public List<Combustible> GetCombustibles()
        {
            List<Combustible> lista = new List<Combustible>();
            try
            {
                string cadenaComando = "SELECT CombustibleId, NombreCombustible FROM Combustibles";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Combustible combustible = ConstruirCombustible(reader);
                    lista.Add(combustible);

                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los combustibles");
            }
        }

        private Combustible ConstruirCombustible(SqlDataReader reader)
        {
            return new Combustible
            {
                CombustibleId = reader.GetInt32(0),
                NombreCombustible = reader.GetString(1)
            };
        }

        public Combustible GetCombustiblePorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Combustible combustible)
        {
            try
            {
                var cadenaComando = "DELETE FROM Combustibles WHERE CombustibleId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", combustible.CombustibleId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Combustible combustible)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (combustible.CombustibleId == 0)
                {
                    var cadenaComando =
                              "SELECT CombustibleId, NombreCombustible FROM Combustibles WHERE NombreCombustible=@nombrecombustible";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombrecombustible", combustible.NombreCombustible);
                }
                else
                {
                    var cadenaComando =
                        "SELECT CombustibleId, NombreCombustible FROM Combustibles WHERE NombreCombustible=@nombrecombustible AND CombustibleId<>@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombrecombustible", combustible.NombreCombustible);
                    comando.Parameters.AddWithValue("@id", combustible.CombustibleId);
                }
                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Combustible combustible)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Autos WHERE CombustibleId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", combustible.CombustibleId);
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

        public void Editar(Combustible combustible)
        {
            try
            {
                var cadenaComando = "UPDATE Combustibles SET NombreCombustible=@nombrecombustible WHERE CombustibleId =@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nombrecombustible", combustible.NombreCombustible);
                comando.Parameters.AddWithValue("@id", combustible.CombustibleId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Guardar(Combustible combustible)
        {
            try
            {
                var cadenaComando = "INSERT INTO Combustibles VALUES (@combustible)";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@combustible", combustible.NombreCombustible);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@Identity";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                combustible.CombustibleId = id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
