using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Servicios.Servicios;
using AlquilerAutos.Servicios.Servicios.Facades;

namespace AlquilerAutos.Windows
{
    public partial class FrmProvincias : Form
    {
        public FrmProvincias()
        {
            InitializeComponent();
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private iServiciosProvincia _servicio;
        private List<ProvinciaListDto> _lista;

        private void FrmProvincias_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosProvincias();
            try
            {
                _lista = _servicio.GetProvincias();
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
            foreach (var provincia in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ProvinciaListDto provincia)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;
            r.Tag = provincia;
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciasAE frm = new FrmProvinciasAE();
            frm.Text = "Agregar Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto  = frm.GetProvincia();
                    if (!_servicio.Existe(provinciaEditDto))
                    {
                        _servicio.Guardar(provinciaEditDto);
                        DataGridViewRow r = ConstruirFila();
                        ProvinciaListDto provinciaListDto = new ProvinciaListDto
                        {
                            ProvinciaId = provinciaEditDto.ProvinciaId,
                            NombreProvincia = provinciaEditDto.NombreProvincia
                        };
                        SetearFila(r, provinciaListDto);
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
            if (DatosDataGridView.SelectedRows.Count>0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                ProvinciaListDto provincia =(ProvinciaListDto) r.Tag;
                DialogResult dr =
                    MessageBox.Show($"¿Desea borrar de la lista la provincia de {provincia.NombreProvincia}?",
                        "Confirmar baja", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (dr==DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(provincia))
                        {
                            _servicio.Borrar(provincia.ProvinciaId);
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
            if (DatosDataGridView.SelectedRows.Count>0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                ProvinciaListDto p = (ProvinciaListDto) r.Tag;
                ProvinciaListDto pCopia =(ProvinciaListDto) p.Clone();
                ProvinciaEditDto provinciaEditDto = new ProvinciaEditDto
                {
                    ProvinciaId = p.ProvinciaId,
                    NombreProvincia = p.NombreProvincia
                };
                FrmProvinciasAE frm = new FrmProvinciasAE();
                frm.Text = "Editar Provincia";
                frm.SetProvincia(provinciaEditDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    try
                    {
                        provinciaEditDto = frm.GetProvincia();
                        if (!_servicio.Existe(provinciaEditDto))
                        {
                            _servicio.Guardar(provinciaEditDto);

                            p.NombreProvincia = provinciaEditDto.NombreProvincia;

                            SetearFila(r, p);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado...\nEdicion denegada", "Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            SetearFila(r,pCopia);
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
