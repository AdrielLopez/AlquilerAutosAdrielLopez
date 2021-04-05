using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL.Repositorios.Facades;

namespace AlquilerAutos.DL.Repositorios
{
    public class RepositorioTiposDeVehiculos:IRepositorioTiposDeVehiculos
    {
        private readonly SqlConnection _conexion;

        public RepositorioTiposDeVehiculos(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public List<TipoDeVehiculo> GetTipoDeVehiculos()
        {
            List<TipoDeVehiculo> lista = new List<TipoDeVehiculo>();
            try
            {
                string cadenaComando = "SELECT TipoDeVehiculoId, Descripcion from TiposDeVehiculos";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDeVehiculo vehiculo = ConstruirTipoDeVehiculo(reader);
                    lista.Add(vehiculo);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los vehiculos");
            }
        }

        private TipoDeVehiculo ConstruirTipoDeVehiculo(SqlDataReader reader)
        {
            return new TipoDeVehiculo
            {
                TipoDeVehiculoId  = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };

        }


        public TipoDeVehiculo GetTipoDeVehiculoPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Borrar(TipoDeVehiculo vehiculo)
        {
            try
            {
                var cadenaComando = "DELETE FROM TiposDeVehiculos WHERE TipoDeVehiculoId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", vehiculo.TipoDeVehiculoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeVehiculo vehiculo)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;
                if (vehiculo.TipoDeVehiculoId == 0)
                {
                    var cadenaComando =
                              "SELECT TipoDeVehiculoId, Descripcion FROM TiposDeVehiculos WHERE Descripcion=@descripcion";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@descripcion", vehiculo.Descripcion);
                }
                else
                {
                    var cadenaComando =
                        "SELECT TipoDeVehiculoId, Descripcion FROM TiposDeVehiculos WHERE Descripcion=@descripcion AND TipoDeVehiculoId<>@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@descripcion", vehiculo.Descripcion);
                    comando.Parameters.AddWithValue("@id", vehiculo.TipoDeVehiculoId);
                }
                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeVehiculo vehiculo)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Autos WHERE TipoDeVehiculoId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", vehiculo.TipoDeVehiculoId);
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

        public void Editar(TipoDeVehiculo vehiculo)
        {
            try
            {
                var cadenaComando = "UPDATE TiposDeVehiculos SET Descripcion=@descripcion WHERE TipoDeVehiculoId =@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@descripcion", vehiculo.Descripcion);
                comando.Parameters.AddWithValue("@id", vehiculo.TipoDeVehiculoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Guardar(TipoDeVehiculo vehiculo)
        {
            try
            {
                var cadenaComando = "INSERT INTO TiposDeVehiculos VALUES (@vehiculo)";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@vehiculo", vehiculo.Descripcion);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@Identity";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                vehiculo.TipoDeVehiculoId = id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
