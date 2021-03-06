using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Windows.Helpers;

namespace AlquilerAutos.Windows
{
    public partial class FrmAutosAE : Form
    {
        public FrmAutosAE()
        {
            InitializeComponent();
        }

        private Auto auto;
        public Auto GetAuto()
        {
            return auto;
        }
        public void SetAuto(Auto auto)
        {
            this.auto = auto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (auto == null)
                {
                    auto = new Auto();
                }

                auto.marca = (Marca) MarcaComboBox.SelectedItem;
                auto.tipodevehiculo = (TipoDeVehiculo)TipoDeVehiculoComboBox.SelectedItem;
                auto.Modelo = ModeloTextBox.Text;
                auto.combustible = (Combustible) CombustibleComboBox.SelectedItem;
                auto.Precio = Double.Parse(PrecioTextBox.Text);
                auto.Patente = PatenteTextBox.Text;


                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ModeloTextBox.Text) || string.IsNullOrWhiteSpace(ModeloTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ModeloTextBox, "El modelo es requerido");
            }

            if (MarcaComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(MarcaComboBox, "Debe seleccionar una marca");
            }

            if (TipoDeVehiculoComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(TipoDeVehiculoComboBox, "Debe seleccionar un tipo de vehiculo");
            }
            if (CombustibleComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CombustibleComboBox, "Debe seleccionar un tipo de combustible");
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(PatenteTextBox.Text) || string.IsNullOrWhiteSpace(PatenteTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(PatenteTextBox, "La patente es requerida");
            }

            double precio = 0;
          

            if (!double.TryParse(PrecioTextBox.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(PrecioTextBox,"El precio debe ser un numero");
            }

            if (precio<=0)
            {
                valido = false;
                errorProvider1.SetError(PrecioTextBox,"El precio debe ser mayor a 0");
            }

            return valido;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboMarcas(ref MarcaComboBox);
            Helper.CargarDatosComboTiposDeVehiculos(ref TipoDeVehiculoComboBox);
            Helper.CargarDatosComboCombustibles(ref CombustibleComboBox);
            if (auto != null)
            {
                MarcaComboBox.SelectedValue = auto.marca.MarcaId;
                TipoDeVehiculoComboBox.SelectedValue = auto.tipodevehiculo.TipoDeVehiculoId;
                ModeloTextBox.Text = auto.Modelo;
                CombustibleComboBox.SelectedValue = auto.combustible.CombustibleId;
                PrecioTextBox.Text = auto.Precio.ToString();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
