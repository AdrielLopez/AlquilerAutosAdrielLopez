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
    public partial class FrmAlquileres : Form
    {
        private IServiciosAlquileres _servicio;
        private List<Alquiler> _lista;
        private IServiciosAutos _serviciosAutos = new ServiciosAutos();
        private IServiciosClientes _serviciosClientes = new ServicioClientes();
        private IServiciosEmpleados _serviciosEmpleados = new ServicioEmpleados();
        public FrmAlquileres()
        {
            InitializeComponent();
        }

        private void FrmAlquileres_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosAlquileres();
                _lista = _servicio.GetAlquiler();
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
            foreach (var alquiler in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, alquiler);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Alquiler alquiler)
        {
            var auto = _serviciosAutos.GetAutoPorId(alquiler.auto.AutoId);
            var cliente = _serviciosClientes.GetClientePorId(alquiler.cliente.ClienteId);
            var empleado = _serviciosEmpleados.GetEmpleadoPorId(alquiler.empleado.EmpleadoId);
            r.Cells[cmnMarcaAuto.Index].Value = alquiler.auto.marca.NombreMarca;
            r.Cells[cmnModeloAuto.Index].Value = alquiler.auto.Modelo;
            r.Cells[cmnCliente.Index].Value = alquiler.cliente.Nombre +" "+ alquiler.cliente.Apellido;
            r.Cells[cmnEmpleado.Index].Value = alquiler.empleado.Nombre +" "+ alquiler.empleado.Apellido;
            r.Cells[cmnFecha.Index].Value = alquiler.fecha;
            r.Cells[cmnFechaLimite.Index].Value = alquiler.fechaLimite;
            r.Cells[cmnPrecio.Index].Value = alquiler.Precio;
            r.Cells[cmnAlquilerId.Index].Value = alquiler.AlquilerId;
            r.Tag = alquiler;
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
            FrmAlquileresAE frm = new FrmAlquileresAE();
            frm.Text = "Agregar Alquiler";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Alquiler alquiler = frm.GetAlquiler();
                if (_servicio.Existe(alquiler))
                {
                    MessageBox.Show("Registro repetido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                _servicio.Guardar(alquiler);
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, alquiler);
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
