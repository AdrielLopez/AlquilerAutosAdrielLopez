using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioTiposDeDocumentos:IRepositorioTiposDeDocumentos
    {
        private readonly SqlConnection _conexion;

        public RepositorioTiposDeDocumentos(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public List<TipoDeDocumento> GetTipoDeDeDocumentos()
        {
            List<TipoDeDocumento> lista = new List<TipoDeDocumento>();
            try
            {
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion from TiposDeDocumentos";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDeDocumento documento= ConstruirTipoDeDocumento(reader);
                    lista.Add(documento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los documentos");
            }
        }

        private TipoDeDocumento ConstruirTipoDeDocumento(SqlDataReader reader)
        {
            return new TipoDeDocumento
            {
                TipoDeDocumentoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };

        }


        public TipoDeDocumento GetTipoDeDocumentoPorId(int id)
        {
            TipoDeDocumento tipodocumento = new TipoDeDocumento();
            try
            {
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion from TiposDeDocumentos WHERE TipoDeDocumentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    tipodocumento = ConstruirTipoDeDocumento(reader);
                    
                }
                reader.Close();
                return tipodocumento;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los documentos");
            }
        }

        public void Borrar(TipoDeDocumento documento)
        {
            try
            {
                var cadenaComando = "DELETE FROM TiposDeDocumentos WHERE TipoDeDocumentoId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumento documento)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (documento.TipoDeDocumentoId == 0)
                {
                    var cadenaComando =
                              "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE Descripcion=@descripcion";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@descripcion", documento.Descripcion);
                }
                else
                {
                    var cadenaComando =
                        "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE Descripcion=@descripcion AND TipoDeDocumentoId<>@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@descripcion", documento.Descripcion);
                    comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                }
                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento documento)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Clientes WHERE TipoDeDocumentoId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
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

        public void Editar(TipoDeDocumento documento)
        {
            try
            {
                var cadenaComando = "UPDATE TiposDeDocumentos SET Descripcion=@descripcion WHERE TipoDeDocumentoId =@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@descripcion", documento.Descripcion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Guardar(TipoDeDocumento documento)
        {
            try
            {
                var cadenaComando = "INSERT INTO TiposDeDocumentos VALUES (@documento)";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@documento", documento.Descripcion);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@Identity";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                documento.TipoDeDocumentoId = id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
