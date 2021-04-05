using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Windows
{
    public partial class FrmTiposDeVehiculosAE : Form
    {
        public FrmTiposDeVehiculosAE()
        {
            InitializeComponent();
        }

        private void FrmTiposDeVehiculosAE_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (vehiculo != null)
            {
                txtboxVehiculo.Text = vehiculo.Descripcion;
            }
        }

        private TipoDeVehiculo vehiculo;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (vehiculo == null)
                {
                    vehiculo = new TipoDeVehiculo();
                }

                vehiculo.Descripcion = txtboxVehiculo.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtboxVehiculo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtboxVehiculo, "Debe ingresar un tipo de vehiculo");
            }

            return valido;
        }

        public TipoDeVehiculo GetVehiculo()
        {
            return vehiculo;
        }



        public void SetVehiculo(TipoDeVehiculo vehiculo)
        {
            this.vehiculo = vehiculo;
        }
    }
}
