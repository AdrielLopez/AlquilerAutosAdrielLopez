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
using AlquilerAutos.BL.DTOs.Localidad;
using AlquilerAutos.BL.DTOs.Provincia;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Windows.Helpers;

namespace AlquilerAutos.Windows
{
    public partial class FrmClientesAE : Form
    {
        public FrmClientesAE()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ClienteEditDto == null)
                {
                    ClienteEditDto = new ClienteEditDto();
                }

                ClienteEditDto.Nombre = NombreTextBox.Text;
                ClienteEditDto.Apellido = ApellidoTextBox.Text;
                ClienteEditDto.Provincia = (ProvinciaListDto)ProvinciaIdComboBox.SelectedItem;
                ClienteEditDto.Localidad = (LocalidadListDto)LocalidadIdComboBox.SelectedItem;
                ClienteEditDto.tipodocumento = (TipoDeDocumento)TipoDeDocumentoIdComboBox.SelectedItem;
                ClienteEditDto.NroDocumento = NroDocTextBox.Text;
                ClienteEditDto.Direccion = DireccionTextBox.Text;
                ClienteEditDto.TelefonoFijo = TelefonoFijoTextBox.Text;
                ClienteEditDto.TelefonoMovil = TelefonoMovilTextBox.Text;
                ClienteEditDto.CorreoElectronico = EmailTextBox.Text;

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
                errorProvider1.SetError(NombreTextBox, "El nombre del Cliente es requerido");
            }

            if (string.IsNullOrEmpty(ApellidoTextBox.Text) || string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ApellidoTextBox, "El apellido del Cliente es requerido");
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

        private ClienteEditDto ClienteEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboProvincias(ref ProvinciaIdComboBox);
            Helper.CargarDatosComboTiposDeDocumentos(ref TipoDeDocumentoIdComboBox);
            if (ClienteEditDto != null)
            {

                NombreTextBox.Text = ClienteEditDto.Nombre;
                ApellidoTextBox.Text = ClienteEditDto.Apellido;
                DireccionTextBox.Text = ClienteEditDto.Direccion;
                NroDocTextBox.Text = ClienteEditDto.NroDocumento;
                TelefonoFijoTextBox.Text = ClienteEditDto.TelefonoFijo;
                TelefonoMovilTextBox.Text = ClienteEditDto.TelefonoMovil;
                EmailTextBox.Text = ClienteEditDto.CorreoElectronico;
                ProvinciaIdComboBox.SelectedValue = ClienteEditDto.Provincia.ProvinciaId;
                Helper.CargarDatosComboLocalidades(ref LocalidadIdComboBox, ClienteEditDto.Provincia);
                LocalidadIdComboBox.SelectedValue = ClienteEditDto.Localidad.LocalidadId;
                TipoDeDocumentoIdComboBox.SelectedValue = ClienteEditDto.tipodocumento.TipoDeDocumentoId;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ProvinciaIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvinciaIdComboBox.SelectedIndex != 0)
            {
                ProvinciaListDto provinciaListDto = (ProvinciaListDto)ProvinciaIdComboBox.SelectedItem;
                Helper.CargarDatosComboLocalidades(ref LocalidadIdComboBox, provinciaListDto);
            }
            else
            {
                LocalidadIdComboBox.DataSource = null;
            }
        }

        public ClienteEditDto GetCliente()
        {
            return ClienteEditDto;
        }

        public void SetCliente(ClienteEditDto ClienteEditDto)
        {
            this.ClienteEditDto = ClienteEditDto;
        }

        private void FrmClientesAE_Load(object sender, EventArgs e)
        {

        }
    }
}
