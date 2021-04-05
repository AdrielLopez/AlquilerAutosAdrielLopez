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
    public partial class FrmMarcasAE : Form
    {
        public FrmMarcasAE()
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
            if (marca != null)
            {
                txtboxMarca.Text = marca.NombreMarca;
            }
        }

        private Marca marca;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.NombreMarca = txtboxMarca.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtboxMarca.Text))
            {
                valido = false;
                errorProvider1.SetError(txtboxMarca, "Debe ingresar una marca");
            }

            return valido;
        }

        public Marca GetMarca()
        {
            return marca;
        }

        

        public void SetMarca(Marca marca)
        {
            this.marca = marca;
        }

        private void FrmMarcasAE_Load(object sender, EventArgs e)
        {

        }
    }
}

