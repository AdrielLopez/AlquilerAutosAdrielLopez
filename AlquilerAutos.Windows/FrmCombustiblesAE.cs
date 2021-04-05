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
    public partial class FrmCombustiblesAE : Form
    {
        public FrmCombustiblesAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (combustible != null)
            {
                txtboxCombustibles.Text = combustible.NombreCombustible;
            }
        }

        private Combustible combustible;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (combustible == null)
                {
                    combustible = new Combustible();
                }

                combustible.NombreCombustible= txtboxCombustibles.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtboxCombustibles.Text))
            {
                valido = false;
                errorProvider1.SetError(txtboxCombustibles, "Debe ingresar un combustible");
            }

            return valido;
        }

        public Combustible GetCombustible()
        {
            return combustible;
        }

       
        public void SetCombustible(Combustible combustible)
        {
            this.combustible = combustible;
        }
    }
}
