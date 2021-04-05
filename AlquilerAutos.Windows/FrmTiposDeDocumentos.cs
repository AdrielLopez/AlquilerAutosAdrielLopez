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
    public partial class FrmTiposDeDocumentos : Form
    {
        public FrmTiposDeDocumentos()
        {
            InitializeComponent();
        }

        private IServiciosTIpoDeDocumento _servicio;
        private List<TipoDeDocumento> _lista;

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTiposDeDocumentos_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosTiposDeDocumentos();
            try
            {
                _lista = _servicio.GetTipoDeDeDocumentos();
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
            foreach (var tipodedocumento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipodedocumento);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeDocumento tipodedocumento)
        {
            r.Cells[cmnTiposDeDocumentos.Index].Value = tipodedocumento.Descripcion;
            r.Tag = tipodedocumento;
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoDeDocumentosAE frm = new FrmTipoDeDocumentosAE();
            frm.Text = "Agregar tipo de documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var documento = frm.GetDocumento();
                    if (!_servicio.Existe(documento))
                    {
                        _servicio.Guardar(documento);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, documento);
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
                TipoDeDocumento documento = (TipoDeDocumento)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista el tipo de documento {documento.Descripcion}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(documento))
                        {
                            _servicio.Borrar(documento);
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
                TipoDeDocumento d = (TipoDeDocumento)r.Tag;
                TipoDeDocumento dCopia = (TipoDeDocumento)d.Clone();
                FrmTipoDeDocumentosAE frm = new FrmTipoDeDocumentosAE();
                frm.Text = "Editar tipo de documento";
                frm.SetDocumento(d);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        d = frm.GetDocumento();
                        if (!_servicio.Existe(d))
                        {
                            _servicio.Editar(d);
                            SetearFila(r, d);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado...\nEdicion denegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            SetearFila(r, dCopia);
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
