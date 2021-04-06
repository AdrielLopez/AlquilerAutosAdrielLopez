using System;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmLocalidadesAE : Form
    {
        public FrmLocalidadesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboLocalidades();
            if (localidad!=null)
            {
                txtboxLocalidad.Text = localidad.NombreLocalidad;
                ProvinciasComboBox.SelectedValue = localidad.ProvinciaId;
            }
        }

        private void CargarDatosComboLocalidades()
        {
            iServiciosProvincia _serviciosProvincia = new ServiciosProvincias();
            var lista = _serviciosProvincia.GetProvincias();
            var defaultProvincia = new Provincia
            {
                ProvinciaId = 0,
                NombreProvincia = "Seleccione Provincia"
            };
            lista.Insert(0, defaultProvincia);
            ProvinciasComboBox.DataSource = lista;
            ProvinciasComboBox.ValueMember = "ProvinciaId";
            ProvinciasComboBox.DisplayMember = "NombreProvincia";
            ProvinciasComboBox.SelectedIndex = 0;
        }

        private LocalidadEditDto localidad;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad == null)
                {
                    localidad = new LocalidadEditDto();
                }

                localidad.NombreLocalidad = txtboxLocalidad.Text;
                localidad.ProvinciaId = ((Provincia) ProvinciasComboBox.SelectedItem).ProvinciaId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtboxLocalidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtboxLocalidad, "Debe ingresar una localidad");
            }

            if (ProvinciasComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciasComboBox,"Debe seleccionar un pais");
            }

            return valido;
        }

        public LocalidadEditDto GetLocalidad()
        {
            return localidad;
        }

        public void SetLocalidad(LocalidadEditDto localidad)
        {
            this.localidad = localidad;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
