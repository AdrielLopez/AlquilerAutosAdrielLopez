using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.DL.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioEmpleados : IRepositorioEmpleados
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioProvincias _repositorioProvincias;
        private readonly IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioTiposDeDocumentos _repositorioTiposDeDocumentos;

        public RepositorioEmpleados(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias, IRepositorioLocalidades repositorioLocalidades)
        {
            _sqlConnection = sqlConnection;
            _repositorioProvincias = repositorioProvincias;
            _repositorioLocalidades = repositorioLocalidades;
               
        }

        public RepositorioEmpleados(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<EmpleadoListDto> GetLista()
        {
            List<EmpleadoListDto> lista = new List<EmpleadoListDto>();
            try
            {
                string cadenaComando = "SELECT EmpleadoId,Nombre,Apellido,L.LocalidadId,P.ProvinciaId" +
                                       " FROM Empleados E Inner Join Localidades L ON " +
                                       "E.LocalidadId = L.LocalidadId INNER JOIN Provincias P ON L.ProvinciaId = P.ProvinciaId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var empleadoListDto = ConstruirEmpleadoListDto(reader);
                    lista.Add(empleadoListDto);
                }

                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        private EmpleadoListDto ConstruirEmpleadoListDto(SqlDataReader reader)
        {

            return new EmpleadoListDto
            {
                EmpleadoId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                LocalidadId = reader.GetInt32(3),
                ProvinciaId = reader.GetInt32(4)
            };

        }

        public void Guardar(Empleado empleado)
        {
            if (empleado.EmpleadoId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Empleados VALUES(@nombre, @apellido, @docId, @nrodoc," +
                                           "@direc, @localidadId, @provinciaId, @telfijo, @telmovil, @correo)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    comando.Parameters.AddWithValue("@apellido", empleado.Apellido);
                    comando.Parameters.AddWithValue("@docId", empleado.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nrodoc", empleado.NroDocumento);
                    comando.Parameters.AddWithValue("@direc", empleado.Direccion);
                    comando.Parameters.AddWithValue("@localidadId", empleado.LocalidadId);
                    comando.Parameters.AddWithValue("@provinciaId", empleado.ProvinciaId);
                    if (empleado.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telfijo", empleado.TelefonoFijo);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telfijo", DBNull.Value);
                    }

                    if (empleado.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telmovil", empleado.TelefonoMovil);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telmovil", DBNull.Value);
                    }

                    if (empleado.CorreoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@correo", empleado.CorreoElectronico);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    }

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    empleado.EmpleadoId = (int) (decimal) comando.ExecuteScalar();
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
                        "UPDATE Empleados SET Nombre=@nombre, Apellido =@apellido, TipoDeDocumentoId=@docId" +
                        ", NroDocumento=@nrodoc, Direccion=@direc, LocalidadId=@localidadId, ProvinciaId=@provinciaId," +
                        "TelefonoFijo=@telfijo, TelefonoMovil=@telmovil, CorreoElectronico=@correo WHERE EmpleadoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    comando.Parameters.AddWithValue("@apellido", empleado.Apellido);
                    comando.Parameters.AddWithValue("@docId", empleado.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nrodoc", empleado.NroDocumento);
                    comando.Parameters.AddWithValue("@direc", empleado.Direccion);
                    comando.Parameters.AddWithValue("@localidadId", empleado.LocalidadId);
                    comando.Parameters.AddWithValue("@provinciaId", empleado.ProvinciaId);
                    if (empleado.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telfijo", empleado.TelefonoFijo);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telfijo", DBNull.Value);
                    }

                    if (empleado.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telmovil", empleado.TelefonoMovil);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telmovil", DBNull.Value);
                    }

                    if (empleado.CorreoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@correo", empleado.CorreoElectronico);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@id", empleado.EmpleadoId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }


        }

        public bool Existe(Empleado empleado)
        {
            try
            {
                if (empleado.EmpleadoId == 0)
                {
                    string cadenaComando = "SELECT * FROM Empleados WHERE Nombre=@nomb";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", empleado.Nombre);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Empleados WHERE Nombre=@nomb AND EmpleadoId<>@empleadoId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", empleado.Nombre);
                    comando.Parameters.AddWithValue("@empleadoId", empleado.EmpleadoId);
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

        public EmpleadoEditDto GetEmpleadoPorId(int empleadoId)
        {
            EmpleadoEditDto empleado = null;
            try
            {
                string cadenaComando =
                    "SELECT EmpleadoId, Nombre, Apellido, TipoDeDocumentoId," +
                    " NroDocumento, Direccion, LocalidadId, ProvinciaId, TelefonoFijo," +
                    " TelefonoMovil, CorreoElectronico FROM Empleados WHERE EmpleadoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", empleadoId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    empleado = ConstruirEmpleadoEditDto(reader);
                }
                reader.Close();
                return empleado;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el empleado");
            }
        }

        public bool EstaRelacionado(EmpleadoListDto empleadoListDto)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Alquileres WHERE EmpleadoId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", empleadoListDto.EmpleadoId);
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

        public void Borrar(int empleadoEmpleadoId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Empleados WHERE EmpleadoId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", empleadoEmpleadoId);
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

        private EmpleadoEditDto ConstruirEmpleadoEditDto(SqlDataReader reader)
        {
            _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(_sqlConnection);
            var provinciaEditDto = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(7));
            var localidadEditDto = _repositorioLocalidades.GetLocalidadPorId(reader.GetInt32(6));
            return new EmpleadoEditDto()
            {
                EmpleadoId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                tipodocumento = _repositorioTiposDeDocumentos.GetTipoDeDocumentoPorId(reader.GetInt32(3)),
                NroDocumento = reader.GetString(4),
                Direccion = reader.GetString(5),
                Provincia = new ProvinciaListDto() { ProvinciaId = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia },
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
