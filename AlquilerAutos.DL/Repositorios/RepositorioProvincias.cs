using System;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlquilerAutos.BL.DTOs.Provincia;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly SqlConnection _conexion;

        public RepositorioProvincias(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public void Borrar(int id)
        {
            try
            {
                var cadenaComando = "DELETE FROM Provincias WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
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

        public bool Existe(Provincia provincia)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (provincia.ProvinciaId == 0)
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

        public bool EstaRelacionado(ProvinciaListDto provinciaListDto)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Clientes WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", provinciaListDto.ProvinciaId);
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


        public List<ProvinciaListDto> GetProvincias()
        {
            List<ProvinciaListDto> lista = new List<ProvinciaListDto>();
            try
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia from Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProvinciaListDto provincia = ConstruirProvinciaListDto(reader);
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

        private ProvinciaListDto ConstruirProvinciaListDto(SqlDataReader reader)
        {
            return new ProvinciaListDto
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };

        }

        public ProvinciaEditDto GetProvinciaPorId(int id)
        {
            ProvinciaEditDto provincia = null;
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
                    provincia = ConstruirProvinciaEditDto(reader);
                }

                reader.Close();
                return provincia;

            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las provincias");
            }
        }

        private ProvinciaEditDto ConstruirProvinciaEditDto(SqlDataReader reader)
        {
            return new ProvinciaEditDto
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };
        }

        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Provincias VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    provincia.ProvinciaId = (int) (decimal) comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar un registro");
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Provincias SET NombreProvincia=@nombre WHERE ProvinciaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar modificar un registro");
                }

            }

           
        }
    }
}
