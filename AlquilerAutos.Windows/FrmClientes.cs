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
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosClientes _servicio;
        private List<ClienteListDto> _lista;
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioClientes();
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
            foreach (var ClienteListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ClienteListDto);
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
        private void SetearFila(DataGridViewRow r, ClienteListDto ClienteListDto)
        {
            var localidad = _serviciosLocalidades.GetLocalidadPorId(ClienteListDto.LocalidadId);
            var provincia = _serviciosProvincia.GetProvinciaPorId(ClienteListDto.ProvinciaId);
            r.Cells[cmnNombre.Index].Value = ClienteListDto.Nombre;
            r.Cells[cmnApellido.Index].Value = ClienteListDto.Apellido;
            r.Cells[cmnLocalidadId.Index].Value = localidad.NombreLocalidad;
            r.Cells[cmnProvinciaId.Index].Value = provincia.NombreProvincia;
            r.Tag = ClienteListDto;

        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmClientesAE frm = new FrmClientesAE();
            frm.Text = "Agregar Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                ClienteEditDto ClienteEditDto = frm.GetCliente();
                if (_servicio.Existe(ClienteEditDto))
                {
                    MessageBox.Show("Registro repetido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                _servicio.Guardar(ClienteEditDto);
                DataGridViewRow r = ConstruirFila();
                ClienteListDto ClienteListDto = new ClienteListDto
                {
                    ClienteId = ClienteEditDto.ClienteId,
                    Nombre = ClienteEditDto.Nombre,
                    Apellido = ClienteEditDto.Apellido,
                    LocalidadId = ClienteEditDto.Localidad.LocalidadId,
                    ProvinciaId = ClienteEditDto.Provincia.ProvinciaId


                };
                SetearFila(r, ClienteListDto);
                AgregarFila(r);
                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            ClienteListDto ClienteListDto = (ClienteListDto)r.Tag;
            ClienteListDto ClienteListDtoAuxiliar = (ClienteListDto)ClienteListDto.Clone();
            FrmClientesAE frm = new FrmClientesAE();
            ClienteEditDto ClienteEditDto = _servicio.GetClientePorId(ClienteListDto.ClienteId);
            frm.Text = "Editar Proveedor";
            frm.SetCliente(ClienteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                ClienteEditDto = frm.GetCliente();
                //Controlar repitencia

                if (!_servicio.Existe(ClienteEditDto))
                {
                    _servicio.Guardar(ClienteEditDto);
                    ClienteListDto.ClienteId = ClienteEditDto.ClienteId;
                    ClienteListDto.Nombre = ClienteEditDto.Nombre;
                    ClienteListDto.Apellido = ClienteEditDto.Apellido;
                    ClienteListDto.LocalidadId = ClienteEditDto.Localidad.LocalidadId;
                    ClienteListDto.ProvinciaId = ClienteEditDto.Provincia.ProvinciaId;

                    SetearFila(r, ClienteListDto);
                    MessageBox.Show("Registro Editado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, ClienteListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, ClienteListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                ClienteListDto Cliente = (ClienteListDto)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista al Cliente {Cliente.Nombre}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(Cliente))
                        {
                            _servicio.Borrar(Cliente.ClienteId);
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
