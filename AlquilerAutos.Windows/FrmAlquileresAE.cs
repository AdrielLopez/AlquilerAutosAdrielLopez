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
using AlquilerAutos.BL.DTOs.Empleado;
using AlquilerAutos.BL.Entidades;
using AlquilerAutos.Windows.Helpers;

namespace AlquilerAutos.Windows
{
    public partial class FrmAlquileresAE : Form
    {
        public FrmAlquileresAE()
        {
            InitializeComponent();
        }

        public  FrmAlquileresAE(Auto _auto)
        {
            InitializeComponent();
            this.auto = _auto;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private Auto auto;

        private Alquiler alquiler;
        public Alquiler GetAlquiler()
        {
            return alquiler;
        }
        public void SetAlquiler(Alquiler alquiler)
        {
            this.alquiler = alquiler;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboMarcas(ref MarcaComboBox);
            FechaLimiteDateTime.Enabled = false;
            CombustibleComboBox.Enabled = false;

            Helper.CargarDatosComboEmpleados(ref EmpleadoComboBox);
            Helper.CargarDatosComboClientes(ref ClienteComboBox);
            //Disculpa es mi linea de internet la que tiene el problema de voz
            if (alquiler != null)
            {
                MarcaComboBox.SelectedValue = alquiler.auto.marca.MarcaId;
                ModeloComboBox.SelectedValue = alquiler.auto.Modelo;
                CombustibleComboBox.SelectedValue = alquiler.auto.combustible.NombreCombustible;
                EmpleadoComboBox.SelectedValue = alquiler.empleado.EmpleadoId;
                ClienteComboBox.SelectedValue = alquiler.cliente.ClienteId;


            }
            if (auto != null)
            {
                MarcaComboBox.SelectedValue = auto.marca.MarcaId;
            }
        }

        private void MarcaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MarcaComboBox.SelectedIndex!=0)
            {
                Marca marca = (Marca) MarcaComboBox.SelectedItem;
                Helper.CargarDatosComboModelos(ref ModeloComboBox, marca);
                ModeloComboBox.Enabled = true;
                if (auto != null)
                {
                    ModeloComboBox.SelectedValue = auto.AutoId;
                    ModeloComboBox.Enabled = false;
                    CombustibleComboBox.Enabled = false;
                    MarcaComboBox.Enabled = false;
                }
            }
            else
            {
                ModeloComboBox.Enabled = false;
                FechaLimiteDateTime.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (alquiler == null)
                {
                    alquiler = new Alquiler();
                }
                alquiler.auto = (Auto)ModeloComboBox.SelectedItem;
               // alquiler.auto.marca =MarcaComboBox.SelectedItem;
                alquiler.empleado = Helper.ConvertirEmpleadoListDtoEnEditdto((EmpleadoListDto)EmpleadoComboBox.SelectedItem);
                alquiler.cliente = Helper.ConvertirClienteListDtoEnEditdto((ClienteListDto) ClienteComboBox.SelectedItem);
                alquiler.fecha=DateTime.Now;
                alquiler.fechaLimite = FechaLimiteDateTime.Value;
                alquiler.Precio = int.Parse(PrecioTextBox.Text);



                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
         
            if (MarcaComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(MarcaComboBox, "Debe seleccionar una marca");
            }

            if (ModeloComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ModeloComboBox, "Debe seleccionar un modelo");
            }
            if (EmpleadoComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(EmpleadoComboBox, "Debe seleccionar un empleado");
            }
            if (ClienteComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ClienteComboBox, "Debe seleccionar un cliente");
            }

            if (FechaLimiteDateTime.Value<DateTime.Now)
            {
                valido = false;
                errorProvider1.SetError(FechaLimiteDateTime, "La fecha no puede ser menor a la actual");
            }


            return valido;
        }

        private void FechaLimiteDateTime_ValueChanged(object sender, EventArgs e)
        {
            Auto auto = (Auto) ModeloComboBox.SelectedItem;
            TimeSpan diferencia = FechaLimiteDateTime.Value.Date.Subtract(DateTime.Now.Date);
            double precio = diferencia.Days * auto.Precio;
            if (precio < 0)
            {
                precio = 0;
            }


            PrecioTextBox.Text = precio.ToString();
           
        }

        private void ModeloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModeloComboBox.SelectedIndex != 0)
            {
                Auto _auto = (Auto)ModeloComboBox.SelectedItem;
                Helper.CargarDatosComboCombustibles(ref CombustibleComboBox, _auto);
                CombustibleComboBox.Enabled = true;
                FechaLimiteDateTime.Enabled = true;
                if (auto != null)
                {
                    CombustibleComboBox.SelectedValue = auto.combustible.CombustibleId;
                }

            }
            else
            {
                CombustibleComboBox.Enabled = false;
                FechaLimiteDateTime.Enabled = false;
            }
        }

        private void FrmAlquileresAE_Load(object sender, EventArgs e)
        {
            
        }

        public void SetAlquiler(Auto auto)
        {
            alquiler.auto = this.auto;
        }
    }
}
