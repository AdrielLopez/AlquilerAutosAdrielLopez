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
    public partial class FrmDevoluciones : Form
    {
        private List<Devolucion> _lista;
        private IServiciosDevoluciones _servicio;
        private IServiciosAlquileres _servicioAlquileres = new ServiciosAlquileres();
        public FrmDevoluciones()
        {
            InitializeComponent();
        }

        private void FrmDevoluciones_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosDevoluciones();
                _lista = _servicio.GetDevolucion();
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
            foreach (var devolucion in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, devolucion);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Devolucion devolucion)
        {
            var alquiler = _servicioAlquileres.GetAlquilerPorId(devolucion.alquiler.AlquilerId);
            r.Cells[cmnAlquilerId.Index].Value = devolucion.alquiler.AlquilerId;
            r.Cells[cmnAuto.Index].Value = devolucion.alquiler.auto.marca.NombreMarca + " " + devolucion.alquiler.auto.Modelo;
            r.Cells[cmnCliente.Index].Value = devolucion.alquiler.cliente.Nombre + " " + devolucion.alquiler.cliente.Apellido;
            r.Cells[cmnFechaDevolucion.Index].Value = devolucion.FechaDevolucion;
            r.Tag = devolucion;
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
            FrmDevolucionesAE frm = new FrmDevolucionesAE();
            frm.Text = "Agregar Devolucion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Devolucion devolucion = frm.GetDevolucion();
             


                _servicio.Guardar(devolucion);
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, devolucion);
                AgregarFila(r);
                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
