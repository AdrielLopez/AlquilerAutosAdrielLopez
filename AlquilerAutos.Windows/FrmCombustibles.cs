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
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmCombustibles : Form
    {
        public FrmCombustibles()
        {
            InitializeComponent();
        }

        private IServiciosCombustible _servicio;
        private List<Combustible> _lista;

        private void FrmCombustibles_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosCombustibles();
            try
            {
                _lista = _servicio.GetCombustibles();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var combustible in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, combustible);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Combustible combustible)
        {
            r.Cells[cmnCombustibles.Index].Value = combustible.NombreCombustible;
            r.Tag = combustible;
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmCombustiblesAE frm = new FrmCombustiblesAE();
            frm.Text = "Agregar Combustible";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var combustible = frm.GetCombustible();
                    if (!_servicio.Existe(combustible))
                    {
                        _servicio.Guardar(combustible);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, combustible);
                        AgregarFila(r);
                        MessageBox.Show("Registro agregado con exito", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Registro duplicado... Alta denegada", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                Combustible combustible = (Combustible)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista el combustible {combustible.NombreCombustible}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(combustible))
                        {
                            _servicio.Borrar(combustible);
                            DatosDataGridView.Rows.Remove(r);
                            MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro relacionado... Baja denegada", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }

                    }
                    catch (Exception exception)
                    {

                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                Combustible c = (Combustible)r.Tag;
                Combustible cCopia = (Combustible) c.Clone();
                FrmCombustiblesAE frm = new FrmCombustiblesAE();
                frm.Text = "Editar Combustible";
                frm.SetCombustible(c);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        c = frm.GetCombustible();
                        if (!_servicio.Existe(c))
                        {
                            _servicio.Editar(c);
                            SetearFila(r, c);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado...\nEdicion denegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            SetearFila(r, cCopia);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
