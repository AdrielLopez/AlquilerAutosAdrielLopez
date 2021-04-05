using System;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly SqlConnection _conexion;

        public RepositorioProvincias(SqlConnection conexion)
        {
            _conexion = conexion;   
        }
        
        public void Borrar(Provincia provincia)
        {
            try
            {
                var cadenaComando = "DELETE FROM Provincias WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (provincia.ProvinciaId==0)
                {
                    var cadenaComando =
                              "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombreprovincia";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombreprovincia", provincia.NombreProvincia); 
                }
                else
                {
                    var cadenaComando =
                        "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombreprovincia AND ProvinciaId<>@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombreprovincia", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                }
                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Clientes WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                int cantidadRegistros =(int) comando.ExecuteScalar();
                if (cantidadRegistros>0)
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

        public void Editar(Provincia provincia)
        {
            try
            {
                var cadenaComando = "UPDATE Provincias SET NombreProvincia=@nombreprovincia WHERE ProvinciaId =@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nombreprovincia", provincia.NombreProvincia);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Provincia> GetProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia from Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las provincias"); 
            }
        }

        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };

        }

        public Provincia GetProvinciaPorId(int id)
        {
            Provincia provincia = null;
            try
            {
                string cadenaComando =
                    "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    provincia = ConstruirProvincia(reader);
                }

                reader.Close();
                return provincia;

            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las localidades");
            }
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                var cadenaComando = "INSERT INTO Provincias VALUES (@provincia)";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@provincia", provincia.NombreProvincia);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@Identity";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id =(int)(decimal) comando.ExecuteScalar();
                provincia.ProvinciaId = id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
