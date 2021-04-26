using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlquilerAutos.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProvincias_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.ShowDialog(this);
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            FrmMarcas frm = new FrmMarcas();
            frm.ShowDialog(this);
        }

        private void btnCombustibles_Click(object sender, EventArgs e)
        {
            FrmCombustibles frm = new FrmCombustibles();
            frm.ShowDialog(this);
        }

        private void btnTiposDeVehiculos_Click(object sender, EventArgs e)
        {
            FrmTiposDeVehiculos frm = new FrmTiposDeVehiculos();
            frm.ShowDialog(this);
        }

        private void btnTiposDeDocumento_Click(object sender, EventArgs e)
        {
            FrmTiposDeDocumentos frm = new FrmTiposDeDocumentos();
            frm.ShowDialog(this);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = new FrmLocalidades();
            frm.ShowDialog(this);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados frm = new FrmEmpleados();
            frm.ShowDialog(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.ShowDialog(this);
        }
    }
}
