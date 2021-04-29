using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Cliente;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmAutos : Form
    {
        private IServiciosAlquileres _serviciosAlquileres = new ServiciosAlquileres();

        public FrmAutos()
        {
            InitializeComponent();
        }

        private Alquiler alquiler;

        private void FrmAutos_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosAutos();
                _lista = _servicio.GetAuto();
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
            foreach (var auto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, auto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private IServiciosAutos _servicio;
        private List<Auto> _lista;
        private IServiciosTipoDeVehiculo _serviciosTipoDeVehiculo = new ServiciosTiposDeVehiculos();
        private IServiciosCombustible _serviciosCombustible = new ServiciosCombustibles();
        private IServiciosMarca _serviciosMarca = new ServiciosMarcas();

        private void SetearFila(DataGridViewRow r, Auto auto)
        {
            var marca = _serviciosMarca.GetMarcaPorId(auto.marca.MarcaId);
            var tipovehiculo = _serviciosTipoDeVehiculo.GetTipoDeVehiculoPorId(auto.tipodevehiculo.TipoDeVehiculoId);
            var combustible = _serviciosCombustible.GetCombustiblePorId(auto.combustible.CombustibleId);
            r.Cells[cmnMarca.Index].Value = auto.marca.NombreMarca;
            r.Cells[cmnTipoDeVehiculo.Index].Value = auto.tipodevehiculo.Descripcion;
            r.Cells[cmnModelo.Index].Value = auto.Modelo;
            r.Cells[cmnCombustible.Index].Value = auto.combustible.NombreCombustible;
            if (auto.Activo == false)
            {
                r.Cells[cmnActivo.Index].Value = "Disponible";
            }
            else
            {
                r.Cells[cmnActivo.Index].Value = "No Disponible";
            }

            r.Cells[cmnPrecio.Index].Value = auto.Precio;
            r.Cells[cmnPatente.Index].Value = auto.Patente;
            r.Tag = auto;
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
            FrmAutosAE frm = new FrmAutosAE();
            frm.Text = "Agregar Auto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Auto auto = frm.GetAuto();
                if (_servicio.Existe(auto))
                {
                    MessageBox.Show("Registro repetido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                _servicio.Guardar(auto);
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, auto);
                AgregarFila(r);
                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                Auto auto = (Auto) r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista el auto {auto.marca.NombreMarca} {auto.Modelo}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(auto))
                        {
                            _servicio.Borrar(auto);
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
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Auto auto = (Auto) r.Tag;
            Auto autoAuxiliar = (Auto) auto.Clone();
            FrmAutosAE frm = new FrmAutosAE();
            //auto = _servicio.GetAutoPorId(auto.AutoId);
            frm.Text = "Editar Auto";
            frm.SetAuto(auto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                auto = frm.GetAuto();
                //Controlar repitencia

                if (!_servicio.Existe(auto))
                {
                    _servicio.Guardar(auto);

                    SetearFila(r, auto);
                    MessageBox.Show("Registro Editado con exito", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, autoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, autoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarToolStripButton_Click(object sender, EventArgs e)
        {
            FrmBuscarAutos frm = new FrmBuscarAutos();
            frm.Text = "Seleccionar Auto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Marca marca = frm.GetMarca();
                _lista = _servicio.GetAuto(marca);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void ActualizarToolStripButton_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            _lista = _servicio.GetAuto();
            MostrarDatosEnGrilla();
        }

        private void AlquilarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Auto auto = (Auto) r.Tag;
            FrmAlquileresAE frm = new FrmAlquileresAE(auto);
            
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Alquiler alquiler = frm.GetAlquiler();
                if (_serviciosAlquileres.Existe(alquiler))
                {
                    MessageBox.Show("Registro repetido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                _serviciosAlquileres.Guardar(alquiler);
                ActualizarGrilla();
                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*auto = frm.GetAlquiler();
        //Controlar repitencia


        _servicio.Guardar(auto);
            SetearFila(r, auto);
            MessageBox.Show("Registro Editado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        */




    }

        
    }

