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
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Windows.Helpers;

namespace AlquilerAutos.Windows
{
    public partial class FrmEmpleadosAE : Form
    {
        public FrmEmpleadosAE()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           if (ValidarDatos())
            {
                if (empleadoEditDto==null)
                {
                    empleadoEditDto = new EmpleadoEditDto();
                }

                empleadoEditDto.Nombre = NombreTextBox.Text;
                empleadoEditDto.Apellido = ApellidoTextBox.Text;
                empleadoEditDto.Provincia = (ProvinciaListDto) ProvinciaIdComboBox.SelectedItem;
                empleadoEditDto.Localidad = (LocalidadListDto) LocalidadIdComboBox.SelectedItem;
                empleadoEditDto.tipodocumento = (TipoDeDocumento)TipoDeDocumentoIdComboBox.SelectedItem;
                empleadoEditDto.NroDocumento = NroDocTextBox.Text;
                empleadoEditDto.Direccion = DireccionTextBox.Text;
                empleadoEditDto.TelefonoFijo = TelefonoFijoTextBox.Text;
                empleadoEditDto.TelefonoMovil = TelefonoMovilTextBox.Text;
                empleadoEditDto.CorreoElectronico = EmailTextBox.Text;

                DialogResult = DialogResult.OK;

            }
           
        }
        
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(NombreTextBox.Text) || string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(NombreTextBox,"El nombre del empleado es requerido");
            }

            if (string.IsNullOrEmpty(ApellidoTextBox.Text) || string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ApellidoTextBox, "El apellido del empleado es requerido");
            }
            if (ProvinciaIdComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciaIdComboBox, "Debe seleccionar una provincia");
            }

            if (LocalidadIdComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(LocalidadIdComboBox, "Debe seleccionar una localidad");
            }
            if (TipoDeDocumentoIdComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(TipoDeDocumentoIdComboBox, "Debe seleccionar un tipo de documento");
            }
            if (string.IsNullOrEmpty(NroDocTextBox.Text) || string.IsNullOrWhiteSpace(NroDocTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(NroDocTextBox, "El numero de documento es requerido");
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text) || string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(DireccionTextBox, "La direccion es requerida");
            }

            return valido;


        }
        
        private EmpleadoEditDto empleadoEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboProvincias(ref ProvinciaIdComboBox);
            Helper.CargarDatosComboTiposDeDocumentos(ref TipoDeDocumentoIdComboBox);
            if (empleadoEditDto != null)
            {
                
                NombreTextBox.Text = empleadoEditDto.Nombre;
                ApellidoTextBox.Text = empleadoEditDto.Apellido;
                DireccionTextBox.Text = empleadoEditDto.Direccion;
                NroDocTextBox.Text = empleadoEditDto.NroDocumento;
                TelefonoFijoTextBox.Text = empleadoEditDto.TelefonoFijo;
                TelefonoMovilTextBox.Text = empleadoEditDto.TelefonoMovil;
                EmailTextBox.Text = empleadoEditDto.CorreoElectronico;
                ProvinciaIdComboBox.SelectedValue = empleadoEditDto.Provincia.ProvinciaId;
                Helper.CargarDatosComboLocalidades(ref LocalidadIdComboBox, empleadoEditDto.Provincia);
                LocalidadIdComboBox.SelectedValue = empleadoEditDto.Localidad.LocalidadId;
                TipoDeDocumentoIdComboBox.SelectedValue = empleadoEditDto.tipodocumento.TipoDeDocumentoId;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ProvinciaIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvinciaIdComboBox.SelectedIndex!=0)
            {
                ProvinciaListDto provinciaListDto = (ProvinciaListDto) ProvinciaIdComboBox.SelectedItem;
                Helper.CargarDatosComboLocalidades(ref LocalidadIdComboBox, provinciaListDto);
            }
            else
            {
                LocalidadIdComboBox.DataSource = null;
            }
        }

        public EmpleadoEditDto GetEmpleado()
        {
            return empleadoEditDto;
        }

        public void SetEmpleado(EmpleadoEditDto empleadoEditDto)
        {
            this.empleadoEditDto = empleadoEditDto;
        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ApellidoTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
