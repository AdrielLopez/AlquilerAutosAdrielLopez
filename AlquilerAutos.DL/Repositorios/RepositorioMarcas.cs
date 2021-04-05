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
    public class RepositorioMarcas:IRepositorioMarcas

    {
        private readonly SqlConnection _conexion;

        public RepositorioMarcas(SqlConnection conexion)
        {
            _conexion = conexion;   
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                string cadenaComando = "SELECT MarcaId, NombreMarca FROM Marcas";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Marca marca = ConstruirMarca(reader);
                    lista.Add(marca);

                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las marcas");
            }
        }

        private Marca ConstruirMarca(SqlDataReader reader)
        {
            return new Marca
            {
                MarcaId = reader.GetInt32(0),
                NombreMarca = reader.GetString(1)
            };
        }

        public Marca GetMarcaPorId(int id)
        {
            throw new NotImplementedException();
        }


        public void Borrar(Marca marca)
        {
            try
            {
                var cadenaComando = "DELETE FROM Marcas WHERE MarcaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", marca.MarcaId);
                comando.ExecuteNonQuery();
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
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (marca.MarcaId == 0)
                {
                    var cadenaComando =
                              "SELECT MarcaId, NombreMarca FROM Marcas WHERE NombreMarca=@nombremarca";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombremarca", marca.NombreMarca);
                }
                else
                {
                    var cadenaComando =
                        "SELECT MarcaId, NombreMarca FROM Marcas WHERE NombreMarca=@nombremarca AND MarcaId<>@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombremarca", marca.NombreMarca);
                    comando.Parameters.AddWithValue("@id", marca.MarcaId);
                }
                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Marca marca)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Autos WHERE MarcaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", marca.MarcaId);
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

        public void Editar(Marca marca)
        {
            try
            {
                var cadenaComando = "UPDATE Marcas SET NombreMarca=@nombremarca WHERE MarcaId =@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nombremarca", marca.NombreMarca);
                comando.Parameters.AddWithValue("@id", marca.MarcaId);
                comando.ExecuteNonQuery();
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
                var cadenaComando = "INSERT INTO Marcas VALUES (@marca)";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@marca", marca.NombreMarca);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@Identity";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                marca.MarcaId = id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
