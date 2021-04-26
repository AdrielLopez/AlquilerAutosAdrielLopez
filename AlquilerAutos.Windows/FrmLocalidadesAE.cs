using System;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;
using AlquilerAutos.Windows.Helpers;

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
            Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
            if (localidad!=null)
            {
                txtboxLocalidad.Text = localidad.NombreLocalidad;
                ProvinciasComboBox.SelectedValue = localidad.Provincia.ProvinciaId;
            }
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
                localidad.Provincia = (ProvinciaListDto) ProvinciasComboBox.SelectedItem;
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
