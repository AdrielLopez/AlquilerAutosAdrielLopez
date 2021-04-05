using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Windows
{
    public partial class FrmProvinciasAE : Form
    {
        public FrmProvinciasAE()
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
            if (provincia!=null)
            {
                txtboxProvincia.Text = provincia.NombreProvincia;
            }
        }

        private Provincia provincia;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provincia==null)
                {
                    provincia = new Provincia();
                }

                provincia.NombreProvincia = txtboxProvincia.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true; 
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtboxProvincia.Text))
            {
                valido = false;
                errorProvider1.SetError(txtboxProvincia, "Debe ingresar una provincia");
            }

            return valido;
        }

        public Provincia GetProvincia()
        {
            return provincia;
        }

        private void FrmProvinciasAE_Load(object sender, EventArgs e)
        {

        }

        public void SetProvincia(Provincia provincia)
        {
            this.provincia = provincia;
        }
    }
}
