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
    public partial class FrmTiposDeVehiculos : Form
    {
        public FrmTiposDeVehiculos()
        {
            InitializeComponent();
        }

        private IServiciosTipoDeVehiculo _servicio;
        private List<TipoDeVehiculo> _lista;

        private void FrmTiposDeVehiculos_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosTiposDeVehiculos();
            try
            {
                _lista = _servicio.GetTipoDeVehiculos();
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
            foreach (var tipoDeVehiculo in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeVehiculo);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeVehiculo tipodevehiculo)
        {
            r.Cells[cmnTiposDeVehiculos.Index].Value = tipodevehiculo.Descripcion;
            r.Tag = tipodevehiculo;
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
            FrmTiposDeVehiculosAE frm = new FrmTiposDeVehiculosAE();
            frm.Text = "Agregar tipo de vehiculo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var vehiculo = frm.GetVehiculo();
                    if (!_servicio.Existe(vehiculo))
                    {
                        _servicio.Guardar(vehiculo);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, vehiculo);
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
                TipoDeVehiculo vehiculo = (TipoDeVehiculo)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista el tipo de vehiculo {vehiculo.Descripcion}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(vehiculo))
                        {
                            _servicio.Borrar(vehiculo);
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
                TipoDeVehiculo d = (TipoDeVehiculo)r.Tag;
                TipoDeVehiculo dCopia = (TipoDeVehiculo)d.Clone();
                FrmTiposDeVehiculosAE frm = new FrmTiposDeVehiculosAE();
                frm.Text = "Editar tipo de vehiculo";
                frm.SetVehiculo(d);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        d = frm.GetVehiculo();
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
