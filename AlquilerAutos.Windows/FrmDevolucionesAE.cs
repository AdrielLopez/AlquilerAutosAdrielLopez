using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.DL;
using AlquilerAutos.DL.Repositorios.Facades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;
using AlquilerAutos.Windows.Helpers;

namespace AlquilerAutos.Windows
{
    public partial class FrmDevolucionesAE : Form
    {
        private IServiciosAlquileres _serviciosAlquileres;
        private List<Alquiler> _lista;
        private IRepositorioAutos _repositorioAutos;
        private IRepositorioClientes _repositorioClientes;
        private IRepositorioEmpleados _repositorioEmpleados;
        private IRepositorioAlquileres _repositorioAlquileres;
        private ConexionBd _conexionBd;

        public FrmDevolucionesAE()
        {
            InitializeComponent();
        }

        private Devolucion devolucion;

        public Devolucion GetDevolucion()
        {
            return devolucion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboClientes(ref ClienteComboBox);
        
            if (devolucion != null)
            {
                ClienteComboBox.SelectedValue = devolucion.alquiler.cliente.ClienteId;



            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (devolucion == null)
                {
                    devolucion = new Devolucion();
                }
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Alquiler alquiler = (Alquiler)r.Tag;

                devolucion.alquiler = alquiler;
                
                devolucion.FechaDevolucion = DateTime.Now;
                



                DialogResult = DialogResult.OK;
            }
           
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (ClienteComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ClienteComboBox,"Debe seleccionar un cliente");
            }


            return valido;
        }

        private void ClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _serviciosAlquileres = new ServiciosAlquileres();
                
                if (ClienteComboBox.SelectedIndex!=0)
                {
                    ClienteListDto cliente =(ClienteListDto) ClienteComboBox.SelectedItem;
                    _lista = _serviciosAlquileres.GetAlquiler(cliente);
                    MostrarDatosEnGrilla();
                }
                else
                {
                    DatosDataGridView.Rows.Clear();
                }
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
       
            r.Cells[cmnMarca.Index].Value =alquiler.auto.marca.NombreMarca;
            r.Cells[cmnModelo.Index].Value = alquiler.auto.Modelo;
            r.Cells[cmnCombustible.Index].Value = alquiler.auto.combustible.NombreCombustible;
            r.Cells[cmnFechaAlquiler.Index].Value = alquiler.fecha;
            r.Tag = alquiler;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void FrmDevolucionesAE_Load(object sender, EventArgs e)
        {

        }
    }
}
