using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioLocalidades:IRepositorioLocalidades
    {
        private readonly SqlConnection _conexion;
        private readonly IRepositorioProvincias _repositorioProvincias;

        public RepositorioLocalidades(SqlConnection conexion, IRepositorioProvincias repositorioProvincias)
        {
            _conexion = conexion;
            _repositorioProvincias = repositorioProvincias;
        }

        public RepositorioLocalidades(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public List<LocalidadListDto> GetLista(ProvinciaListDto provinciaDto)
        {
            List<LocalidadListDto> lista = new List<LocalidadListDto>();
            try
            {
                string cadenaComando;
                SqlCommand comando;
                SqlDataReader reader;
                if (provinciaDto == null)
                {
                    cadenaComando =
                        "SELECT LocalidadId, NombreLocalidad, NombreProvincia FROM Localidades " +
                        "INNER JOIN Provincias ON Localidades.ProvinciaId=Provincias.ProvinciaId";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    reader = comando.ExecuteReader();

                }
                else
                {
                    cadenaComando =
                        "SELECT LocalidadId, NombreLocalidad, NombreProvincia FROM Localidades " +
                        "INNER JOIN Provincias ON Localidades.ProvinciaId=Provincias.ProvinciaId WHERE Localidades.ProvinciaId=@provinciaId";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@provinciaId", provinciaDto.ProvinciaId);
                    reader = comando.ExecuteReader();

                }
                while (reader.Read())
                {
                    var localidadDto = ConstruirLocalidadDto(reader);
                    lista.Add(localidadDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

       

        private LocalidadListDto ConstruirLocalidadDto(SqlDataReader reader)
        {
            LocalidadListDto localidadDto = new LocalidadListDto();
            localidadDto.LocalidadId = reader.GetInt32(0);
            localidadDto.NombreLocalidad = reader.GetString(1);
            localidadDto.NombreProvincia = reader.GetString(2);
            return localidadDto;
        }

        public void Guardar(Localidad localidad)
        {

            if (localidad.LocalidadId==0)
            {
                try
                {
                    var cadenaComando = "INSERT INTO Localidades VALUES (@localidad, @provinciaId)";
                    var comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@localidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provinciaId", localidad.Provincia.ProvinciaId);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@Identity";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    localidad.LocalidadId = (int)(decimal)comando.ExecuteScalar();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                } 
            }
            else
            {
                try
                {
                    var cadenaComando =
                        "UPDATE Localidades SET NombreLocalidad=@localidad, ProvinciaId=@provinciaId WHERE LocalidadId=@id";
                    var comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@localidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provinciaId", localidad.Provincia.ProvinciaId);

                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (localidad.LocalidadId == 0)
                {
                    var cadenaComando =
                        "SELECT * FROM Localidades WHERE NombreLocalidad=@nombrelocalidad AND ProvinciaId=@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombrelocalidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.Provincia.ProvinciaId);
                }
                else
                {
                    var cadenaComando =
                        "SELECT * FROM Localidades WHERE NombreLocalidad=@nombrelocalidad AND ProvinciaId=@id AND LocalidadId<>@localidadId";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombrelocalidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@localidadId", localidad.LocalidadId);
                }
                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            try
            {
                var cadenaComando = "DELETE FROM Localidades WHERE LocalidadId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int id)
        {
            LocalidadEditDto localidad = null;
            try
            {
                string cadenaComando =
                    "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    localidad = ConstruirLocalidad(reader);
                }
                
                reader.Close();
                return localidad;

            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las localidades");
            }
        }

        public bool EstaRelacionado(LocalidadListDto localidadListDto)
        {
            try
            {
                bool estarelacionado = false;
                var cadenaComando = "SELECT COUNT(*) FROM Empleados WHERE LocalidadId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", localidadListDto.LocalidadId);
                int cantidadRegistros = (int)comando.ExecuteScalar();
                if (cantidadRegistros > 0)
                {
                    estarelacionado = true;

                    return estarelacionado;
                }
                else
                {  cadenaComando = "SELECT COUNT(*) FROM Clientes WHERE LocalidadId=@id";
                     comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@id", localidadListDto.LocalidadId);
                     cantidadRegistros = (int)comando.ExecuteScalar();
                    if (cantidadRegistros > 0)
                    {
                        estarelacionado = true;

                        return estarelacionado;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private LocalidadEditDto ConstruirLocalidad(SqlDataReader reader)
        {

            var localidad = new LocalidadEditDto();
            localidad.LocalidadId = reader.GetInt32(0);
            localidad.NombreLocalidad = reader.GetString(1);
            var provinciaEditDto = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(2));
            localidad.Provincia = new ProvinciaListDto()
            {
                ProvinciaId = provinciaEditDto.ProvinciaId,
                NombreProvincia = provinciaEditDto.NombreProvincia
            };
            return localidad;
        }
    }
}
