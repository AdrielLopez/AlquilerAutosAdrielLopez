using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosEmpleados _servicio;
        private List<EmpleadoListDto> _lista;
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioEmpleados();
                _lista = _servicio.GetLista();
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
            foreach (var empleadoListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, empleadoListDto);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private IServiciosLocalidades _serviciosLocalidades = new ServiciosLocalidades();
        private iServiciosProvincia _serviciosProvincia = new ServiciosProvincias();
        private void SetearFila(DataGridViewRow r, EmpleadoListDto empleadoListDto)
        {
            var localidad = _serviciosLocalidades.GetLocalidadPorId(empleadoListDto.LocalidadId);
            var provincia = _serviciosProvincia.GetProvinciaPorId(empleadoListDto.ProvinciaId);
            r.Cells[cmnNombre.Index].Value = empleadoListDto.Nombre;
            r.Cells[cmnApellido.Index].Value = empleadoListDto.Apellido;
            r.Cells[cmnLocalidadId.Index].Value = localidad.NombreLocalidad;
            r.Cells[cmnProvinciaId.Index].Value = provincia.NombreProvincia;
            r.Tag = empleadoListDto;

        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmEmpleadosAE frm = new FrmEmpleadosAE();
            frm.Text = "Agregar Empleado";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            try
            {
                EmpleadoEditDto empleadoEditDto = frm.GetEmpleado();
                if (_servicio.Existe(empleadoEditDto))
                {
                    MessageBox.Show("Registro repetido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    
                }


                _servicio.Guardar(empleadoEditDto);
                DataGridViewRow r = ConstruirFila();
                EmpleadoListDto empleadoListDto = new EmpleadoListDto
                {
                    EmpleadoId = empleadoEditDto.EmpleadoId,
                    Nombre = empleadoEditDto.Nombre,
                    Apellido = empleadoEditDto.Apellido,
                    LocalidadId = empleadoEditDto.Localidad.LocalidadId,
                    ProvinciaId = empleadoEditDto.Provincia.ProvinciaId


                };
                SetearFila(r, empleadoListDto);
                AgregarFila(r);
                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show( exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            EmpleadoListDto empleadoListDto = (EmpleadoListDto)r.Tag;
            EmpleadoListDto empleadoListDtoAuxiliar = (EmpleadoListDto)empleadoListDto.Clone();
            FrmEmpleadosAE frm = new FrmEmpleadosAE();
            EmpleadoEditDto empleadoEditDto = _servicio.GetEmpleadoPorId(empleadoListDto.EmpleadoId);
            frm.Text = "Editar Proveedor";
            frm.SetEmpleado(empleadoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                empleadoEditDto = frm.GetEmpleado();
                //Controlar repitencia

                if (!_servicio.Existe(empleadoEditDto))
                {
                    _servicio.Guardar(empleadoEditDto);
                    empleadoListDto.EmpleadoId = empleadoEditDto.EmpleadoId;
                    empleadoListDto.Nombre = empleadoEditDto.Nombre;
                    empleadoListDto.Apellido = empleadoEditDto.Apellido;
                    empleadoListDto.LocalidadId = empleadoEditDto.Localidad.LocalidadId;
                    empleadoListDto.ProvinciaId = empleadoEditDto.Provincia.ProvinciaId;

                    SetearFila(r, empleadoListDto);
                    MessageBox.Show("Registro Editado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, empleadoListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, empleadoListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                EmpleadoListDto empleado = (EmpleadoListDto)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista al empleado {empleado.Nombre}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(empleado))
                        {
                            _servicio.Borrar(empleado.EmpleadoId);
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
    }
}
