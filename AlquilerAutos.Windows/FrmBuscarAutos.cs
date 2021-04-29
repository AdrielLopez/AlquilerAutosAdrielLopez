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
using AlquilerAutos.Windows.Helpers;

namespace AlquilerAutos.Windows
{
    public partial class FrmBuscarAutos : Form
    {
        public FrmBuscarAutos()
        {
            InitializeComponent();
        }

        private void FrmBuscarAutos_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                marca =(Marca) MarcaComboBox.SelectedItem;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (MarcaComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(MarcaComboBox,"Debe ingresar una marca");
            }

            return valido;
        }

        private Marca marca;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboMarcas(ref MarcaComboBox);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Marca GetMarca()
        {
            return marca;
        }
    }
}
