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
    public class RepositorioClientes:IRepositorioClientes
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioProvincias _repositorioProvincias;
        private readonly IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioTiposDeDocumentos _repositorioTiposDeDocumentos;

        public RepositorioClientes(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias,
            IRepositorioLocalidades repositorioLocalidades)
        {
            _sqlConnection = sqlConnection;
            _repositorioProvincias = repositorioProvincias;
            _repositorioLocalidades = repositorioLocalidades;

        }

        public RepositorioClientes(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<ClienteListDto> GetLista()
        {
            List<ClienteListDto> lista = new List<ClienteListDto>();
            try
            {
                string cadenaComando = "SELECT ClienteId,Nombre,Apellido,L.LocalidadId,P.ProvinciaId,NroDocumento" +
                                       " FROM Clientes E Inner Join Localidades L ON " +
                                       "E.LocalidadId = L.LocalidadId INNER JOIN Provincias P ON L.ProvinciaId = P.ProvinciaId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var ClienteListDto = ConstruirClienteListDto(reader);
                    lista.Add(ClienteListDto);
                }

                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        private ClienteListDto ConstruirClienteListDto(SqlDataReader reader)
        {

            return new ClienteListDto
            {
                ClienteId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                LocalidadId = reader.GetInt32(3),
                ProvinciaId = reader.GetInt32(4),
                NroDoc = reader.GetString(5)
                
            };

        }

        public void Guardar(Cliente Cliente)
        {
            if (Cliente.ClienteId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Clientes VALUES(@nombre, @apellido, @docId, @nrodoc," +
                                           "@direc, @localidadId, @provinciaId, @telfijo, @telmovil, @correo)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", Cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellido", Cliente.Apellido);
                    comando.Parameters.AddWithValue("@docId", Cliente.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nrodoc", Cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@direc", Cliente.Direccion);
                    comando.Parameters.AddWithValue("@localidadId", Cliente.LocalidadId);
                    comando.Parameters.AddWithValue("@provinciaId", Cliente.ProvinciaId);
                    if (Cliente.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telfijo", Cliente.TelefonoFijo);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telfijo", DBNull.Value);
                    }

                    if (Cliente.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telmovil", Cliente.TelefonoMovil);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telmovil", DBNull.Value);
                    }

                    if (Cliente.CorreoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@correo", Cliente.CorreoElectronico);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    }

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    Cliente.ClienteId = (int) (decimal) comando.ExecuteScalar();
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
                        "UPDATE Clientes SET Nombre=@nombre, Apellido =@apellido, TipoDeDocumentoId=@docId" +
                        ", NroDocumento=@nrodoc, Direccion=@direc, LocalidadId=@localidadId, ProvinciaId=@provinciaId," +
                        "TelefonoFijo=@telfijo, TelefonoMovil=@telmovil, CorreoElectronico=@correo WHERE ClienteId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", Cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellido", Cliente.Apellido);
                    comando.Parameters.AddWithValue("@docId", Cliente.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nrodoc", Cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@direc", Cliente.Direccion);
                    comando.Parameters.AddWithValue("@localidadId", Cliente.LocalidadId);
                    comando.Parameters.AddWithValue("@provinciaId", Cliente.ProvinciaId);
                    if (Cliente.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telfijo", Cliente.TelefonoFijo);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telfijo", DBNull.Value);
                    }

                    if (Cliente.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telmovil", Cliente.TelefonoMovil);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telmovil", DBNull.Value);
                    }

                    if (Cliente.CorreoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@correo", Cliente.CorreoElectronico);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@id", Cliente.ClienteId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }


        }

        public bool Existe(Cliente Cliente)
        {
            try
            {
                if (Cliente.ClienteId == 0)
                {
                    string cadenaComando = "SELECT * FROM Clientes WHERE TipoDeDocumentoId=@tipodoc AND NroDocumento=@nrodoc";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@tipodoc", Cliente.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nrodoc", Cliente.NroDocumento);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Clientes WHERE TipoDeDocumentoId=@tipodoc AND NroDocumento=@nrodoc AND ClienteId<>@ClienteId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@tipodoc", Cliente.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nrodoc", Cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@ClienteId", Cliente.ClienteId);
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

        public ClienteEditDto GetClientePorId(int ClienteId)
        {
            ClienteEditDto Cliente = null;
            try
            {
                string cadenaComando =
                    "SELECT ClienteId, Nombre, Apellido, TipoDeDocumentoId," +
                    " NroDocumento, Direccion, LocalidadId, ProvinciaId, TelefonoFijo," +
                    " TelefonoMovil, CorreoElectronico FROM Clientes WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", ClienteId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Cliente = ConstruirClienteEditDto(reader);
                }

                reader.Close();
                return Cliente;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el Cliente");
            }
        }

       

        public bool EstaRelacionado(ClienteListDto ClienteListDto)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Alquileres WHERE ClienteId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", ClienteListDto.ClienteId);
                int cantidadRegistros = (int) comando.ExecuteScalar();
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

        public void Borrar(int ClienteClienteId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Clientes WHERE ClienteId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", ClienteClienteId);
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

        private ClienteEditDto ConstruirClienteEditDto(SqlDataReader reader)
        {
            _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(_sqlConnection);
            var provinciaEditDto = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(7));
            var localidadEditDto = _repositorioLocalidades.GetLocalidadPorId(reader.GetInt32(6));
            return new ClienteEditDto()
            {
                ClienteId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                tipodocumento = _repositorioTiposDeDocumentos.GetTipoDeDocumentoPorId(reader.GetInt32(3)),
                NroDocumento = reader.GetString(4),
                Direccion = reader.GetString(5),
                Provincia = new ProvinciaListDto()
                    {ProvinciaId = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia},
                Localidad = new LocalidadListDto()
                {
                    LocalidadId = localidadEditDto.LocalidadId,
                    NombreLocalidad = localidadEditDto.NombreLocalidad,
                    NombreProvincia = localidadEditDto.Provincia.NombreProvincia
                },

                TelefonoFijo = reader[8] != DBNull.Value ? reader.GetString(8) : string.Empty,
                TelefonoMovil = reader[9] != DBNull.Value ? reader.GetString(9) : string.Empty,
                CorreoElectronico = reader[10] != DBNull.Value ? reader.GetString(10) : string.Empty,



            };
        }
    }
}
