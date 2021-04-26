using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }

}
