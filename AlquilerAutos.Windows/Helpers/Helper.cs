using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows.Helpers
{
    public class Helper
    {
        public static void CargarDatosComboProvincias(ref ComboBox combo)
        {
            iServiciosProvincia serviciosProvincia = new ServiciosProvincias();
            var lista = serviciosProvincia.GetProvincias();
            var defaultProvincia = new ProvinciaListDto()
            {
                ProvinciaId = 0,
                NombreProvincia = "Seleccione Provincia"
            };
            lista.Insert(0, defaultProvincia);
            combo.DataSource = lista;
            combo.ValueMember = "ProvinciaId";
            combo.DisplayMember = "NombreProvincia";
            combo.SelectedIndex = 0;

        }


        internal static void CargarDatosComboLocalidades(ref ComboBox combo, ProvinciaListDto provinciaListDto)
        {
            IServiciosLocalidades serviciosLocalidades = new ServiciosLocalidades();
            var lista = serviciosLocalidades.GetLista(provinciaListDto);
            var defaultLocalidad = new LocalidadListDto()
            {
                LocalidadId = 0,
                NombreLocalidad = "Seleccione Ciudad"
            };
            lista.Insert(0, defaultLocalidad);
            combo.DataSource = lista;
            combo.ValueMember = "LocalidadId";
            combo.DisplayMember = "NombreLocalidad";
            combo.SelectedIndex = 0;

        }

        public static void CargarDatosComboTiposDeDocumentos(ref ComboBox combo)
        {
            IServiciosTIpoDeDocumento serviciosTIpoDeDocumento = new ServiciosTiposDeDocumentos();
            var lista = serviciosTIpoDeDocumento.GetTipoDeDeDocumentos();
            var defaultDocumento = new TipoDeDocumento()
            {
                TipoDeDocumentoId = 0,
                Descripcion = "Seleccione Documento"
            };
            lista.Insert(0, defaultDocumento);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeDocumentoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboMarcas(ref ComboBox combo)
        {
            IServiciosMarca serviciosMarca = new ServiciosMarcas();
            var lista = serviciosMarca.GetMarcas();
            var defaultMarca = new Marca()
            {
                MarcaId = 0,
                NombreMarca = "Seleccione Marca"
            };
            lista.Insert(0, defaultMarca);
            combo.DataSource = lista;
            combo.ValueMember = "MarcaId";
            combo.DisplayMember = "NombreMarca";
            combo.SelectedIndex = 0;
        }

        internal static EmpleadoEditDto ConvertirEmpleadoListDtoEnEditdto(EmpleadoListDto list)
        {
            return new EmpleadoEditDto
            {
                EmpleadoId=list.EmpleadoId,
                Nombre = list.Nombre,
                Apellido = list.Apellido
             
            };
        }

        public static void CargarDatosComboTiposDeVehiculos(ref ComboBox combo)
        {
            IServiciosTipoDeVehiculo serviciosTipoDeVehiculo = new ServiciosTiposDeVehiculos();
            var lista = serviciosTipoDeVehiculo.GetTipoDeVehiculos();
            var defaulTipoDeVehiculo = new TipoDeVehiculo()
            {
                TipoDeVehiculoId = 0,
                Descripcion = "Seleccione Vehiculo"
            };
            lista.Insert(0, defaulTipoDeVehiculo);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeVehiculoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboCombustibles(ref ComboBox combo)
        {
            IServiciosCombustible serviciosCombustible = new ServiciosCombustibles();
            var lista = serviciosCombustible.GetCombustibles();
            var defaultCombustible = new Combustible()
            {
                CombustibleId = 0,
                NombreCombustible = "Seleccione Combustible"
            };
            lista.Insert(0, defaultCombustible);
            combo.DataSource = lista;
            combo.ValueMember = "CombustibleId";
            combo.DisplayMember = "NombreCombustible";
            combo.SelectedIndex = 0;
        }


        public static void CargarDatosComboModelos(ref ComboBox combo, Marca marca)
        {
            IServiciosAutos serviciosAutos = new ServiciosAutos();
            var lista = serviciosAutos.GetAuto(marca);
            var defaultAuto = new Auto()
            {
                AutoId = 0,
                Modelo = "Seleccione Modelo"
            };
            lista.Insert(0, defaultAuto);
            combo.DataSource = lista;
            combo.ValueMember = "AutoId";
            combo.DisplayMember = "Modelo";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboEmpleados(ref ComboBox combo)
        {
            IServiciosEmpleados serviciosEmpleados = new ServicioEmpleados();
            var lista = serviciosEmpleados.GetLista();
            var defaultEmpleado = new EmpleadoListDto()
            {
                EmpleadoId = 0,
                Nombre = "Seleccione Empleado"
            };
            lista.Insert(0, defaultEmpleado);
            combo.DataSource = lista;
            combo.ValueMember = "EmpleadoId";
            combo.DisplayMember = "Nombre";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboClientes(ref ComboBox combo)
        {
            IServiciosClientes serviciosClientes = new ServicioClientes();
            var lista = serviciosClientes.GetLista();
            var defaultCliente = new ClienteListDto()
            {
                ClienteId = 0,
                Nombre = "Seleccione Cliente"
            };
            lista.Insert(0, defaultCliente);
            combo.DataSource = lista;
            combo.ValueMember = "ClienteId";
            combo.DisplayMember = "Nombre";
            combo.SelectedIndex = 0;

        }

        public static ClienteEditDto ConvertirClienteListDtoEnEditdto(ClienteListDto list)
        {
            return new ClienteEditDto
            {
                ClienteId = list.ClienteId,
                Nombre = list.Nombre,
                Apellido = list.Apellido
                

            };
        }

        public static void CargarDatosComboAlquileres(ref ComboBox combo)
        {
            IServiciosAlquileres serviciosAlquileres = new ServiciosAlquileres();
            var lista = serviciosAlquileres.GetAlquiler();
            combo.DataSource = lista;
            combo.ValueMember = "AlquilerId";
            combo.DisplayMember = "AlquilerId";
            combo.SelectedIndex = 0;
        }
    }
    }


