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
    public partial class FrmMarcas : Form
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosMarca _servicio;
        private List<Marca> _lista;

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosMarcas();
            try
            {
                _lista = _servicio.GetMarcas();
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
            foreach (var marca in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, marca);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Marca marca)
        {
            r.Cells[cmnMarcas.Index].Value = marca.NombreMarca;
            r.Tag = marca;
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmMarcasAE frm = new FrmMarcasAE();
            frm.Text = "Agregar Marca";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var marca = frm.GetMarca();
                    if (!_servicio.Existe(marca))
                    {
                        _servicio.Guardar(marca);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, marca);
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
                Marca marca = (Marca)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista la marca de {marca.NombreMarca}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(marca))
                        {
                            _servicio.Borrar(marca);
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
                Marca m = (Marca)r.Tag;
                Marca mCopia = (Marca)m.Clone();
                FrmMarcasAE frm = new FrmMarcasAE();
                frm.Text = "Editar Marca";
                frm.SetMarca(m);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        m = frm.GetMarca();
                        if (!_servicio.Existe(m))
                        {
                            _servicio.Editar(m);
                            SetearFila(r, m);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado...\nEdicion denegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            SetearFila(r, mCopia);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
