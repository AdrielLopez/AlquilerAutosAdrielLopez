using System;
using System.Windows.Forms;
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
                ProvinciasComboBox.SelectedValue = localidad.Provincia.ProvinciaId;
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

        private Localidad localidad;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad == null)
                {
                    localidad = new Localidad();
                }

                localidad.NombreLocalidad = txtboxLocalidad.Text;
                localidad.Provincia = (Provincia) ProvinciasComboBox.SelectedItem;
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

        public Localidad GetLocalidad()
        {
            return localidad;
        }

        public void SetLocalidad(Localidad localidad)
        {
            this.localidad = localidad;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
