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
    public partial class FrmTipoDeDocumentosAE : Form
    {
        public FrmTipoDeDocumentosAE()
        {
            InitializeComponent();
        }

        private void FrmTipoDeDocumentosAE_Load(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (documento != null)
            {
                txtboxDocumento.Text = documento.Descripcion;
            }
        }

        private TipoDeDocumento documento;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (documento == null)
                {
                    documento = new TipoDeDocumento();
                }

                documento.Descripcion = txtboxDocumento.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtboxDocumento.Text))
            {
                valido = false;
                errorProvider1.SetError(txtboxDocumento, "Debe ingresar un tipo de documento");
            }

            return valido;
        }

        public TipoDeDocumento GetDocumento()
        {
            return documento;
        }



        public void SetDocumento(TipoDeDocumento documento)
        {
            this.documento = documento;
        }
    }
}
