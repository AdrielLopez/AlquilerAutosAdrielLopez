using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmLocalidades : Form
    {
        public FrmLocalidades()
        {
            InitializeComponent();
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosLocalidades _servicio;
        private List<LocalidadListDto> lista;

        private void FrmLocalidades_Load(object sender, EventArgs e)
        {

            try
            {
                _servicio = new ServiciosLocalidades();
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var LocalidadListDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, LocalidadListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, LocalidadListDto localidadListDto)
        {
            r.Cells[cmnLocalidades.Index].Value = localidadListDto.NombreLocalidad;
            r.Cells[cmnProvincia.Index].Value = localidadListDto.NombreProvincia;
            r.Tag = localidadListDto;
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto localidadEditDto = frm.GetLocalidad();


                    if (!_servicio.Existe(localidadEditDto))
                    {
                        _servicio.Guardar(localidadEditDto);
                        LocalidadListDto localidadListDto = new LocalidadListDto();

                        localidadListDto.LocalidadId = localidadEditDto.LocalidadId;
                        localidadListDto.NombreLocalidad = localidadEditDto.NombreLocalidad;
                        localidadListDto.NombreProvincia = localidadEditDto.Provincia.NombreProvincia;

                    
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, localidadListDto);
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
                LocalidadListDto localidad = (LocalidadListDto)r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista la localidad de  {localidad.NombreLocalidad}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(localidad))
                        {
                            _servicio.Borrar(localidad.LocalidadId);
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
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            LocalidadListDto localidadListDto = (LocalidadListDto) r.Tag;
            LocalidadListDto localidadDtoAuxilia= localidadListDto.Clone() as LocalidadListDto;
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            LocalidadEditDto localidadEditDto = _servicio.GetLocalidadPorId(localidadListDto.LocalidadId);
            frm.Text = "Editar Localidad";
            frm.SetLocalidad(localidadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            try
            {
                localidadEditDto = frm.GetLocalidad();


                if (!_servicio.Existe(localidadEditDto))
                {
                    _servicio.Guardar(localidadEditDto);
                    localidadListDto.LocalidadId = localidadEditDto.LocalidadId;
                    localidadListDto.NombreLocalidad = localidadEditDto.NombreLocalidad;
                    localidadListDto.NombreProvincia = localidadEditDto.Provincia.NombreProvincia;
                    SetearFila(r, localidadListDto);
                    MessageBox.Show("Registro agregado con exito", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                else
                {
                    SetearFila(r,localidadDtoAuxilia);
                    MessageBox.Show("Registro duplicado... Alta denegada", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
            catch (Exception exception)
            {
                SetearFila(r, localidadDtoAuxilia);
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}


