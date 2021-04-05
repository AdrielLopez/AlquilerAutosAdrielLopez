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
                lista = _servicio.GetLocalidades();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Localidad localidad = frm.GetLocalidad();
                    if (!_servicio.Existe(localidad))
                    {
                        _servicio.Guardar(localidad);
                        DataGridViewRow r = ConstruirFila();
                        LocalidadListDto localidadDto = new LocalidadListDto
                        {
                            LocalidadId = localidad.LocalidadId,
                            NombreLocalidad = localidad.NombreLocalidad,
                            NombreProvincia = localidad.Provincia.NombreProvincia
                        };
                        SetearFila(r, localidadDto);
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
                LocalidadListDto localidadDto = (LocalidadListDto) r.Tag;
                DialogResult dr =
                    MessageBox.Show(
                        $@"¿Desea borrar el registro seleccionado de la localidad {localidadDto.NombreLocalidad}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                   return;
                }

                try
                {
                    _servicio.Borrar(localidadDto.LocalidadId);
                    DatosDataGridView.Rows.Remove(r);
                    MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LocalidadListDto localidadDto = (LocalidadListDto) r.Tag;
            LocalidadListDto localidadDtoAuxilia=localidadDto.Clone() as LocalidadListDto;
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            Localidad localidad = _servicio.GetLocalidadPorId(localidadDto.LocalidadId);
            frm.Text = "Editar Localidad";
            frm.SetLocalidad(localidad);
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            try
            {
                localidad = frm.GetLocalidad();


                if (!_servicio.Existe(localidad))
                {
                    _servicio.Guardar(localidad);
                    localidadDto = new LocalidadListDto
                    {
                        LocalidadId = localidad.LocalidadId,
                        NombreLocalidad = localidad.NombreLocalidad,
                        NombreProvincia = localidad.Provincia.NombreProvincia
                    };
                    SetearFila(r, localidadDto);
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


