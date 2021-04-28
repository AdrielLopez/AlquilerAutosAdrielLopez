namespace AlquilerAutos.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.btnProvincias = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnCombustibles = new System.Windows.Forms.Button();
            this.btnTiposDeVehiculos = new System.Windows.Forms.Button();
            this.btnTiposDeDocumento = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAutos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDevoluciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProvincias
            // 
            this.btnProvincias.Location = new System.Drawing.Point(41, 32);
            this.btnProvincias.Name = "btnProvincias";
            this.btnProvincias.Size = new System.Drawing.Size(117, 61);
            this.btnProvincias.TabIndex = 1;
            this.btnProvincias.Text = "Provincias";
            this.btnProvincias.UseVisualStyleBackColor = true;
            this.btnProvincias.Click += new System.EventHandler(this.btnProvincias_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Location = new System.Drawing.Point(222, 157);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(117, 61);
            this.btnMarcas.TabIndex = 2;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnCombustibles
            // 
            this.btnCombustibles.Location = new System.Drawing.Point(41, 262);
            this.btnCombustibles.Name = "btnCombustibles";
            this.btnCombustibles.Size = new System.Drawing.Size(117, 61);
            this.btnCombustibles.TabIndex = 3;
            this.btnCombustibles.Text = "Combustibles";
            this.btnCombustibles.UseVisualStyleBackColor = true;
            this.btnCombustibles.Click += new System.EventHandler(this.btnCombustibles_Click);
            // 
            // btnTiposDeVehiculos
            // 
            this.btnTiposDeVehiculos.Location = new System.Drawing.Point(222, 262);
            this.btnTiposDeVehiculos.Name = "btnTiposDeVehiculos";
            this.btnTiposDeVehiculos.Size = new System.Drawing.Size(117, 61);
            this.btnTiposDeVehiculos.TabIndex = 4;
            this.btnTiposDeVehiculos.Text = "Tipos de Vehiculos";
            this.btnTiposDeVehiculos.UseVisualStyleBackColor = true;
            this.btnTiposDeVehiculos.Click += new System.EventHandler(this.btnTiposDeVehiculos_Click);
            // 
            // btnTiposDeDocumento
            // 
            this.btnTiposDeDocumento.Location = new System.Drawing.Point(493, 157);
            this.btnTiposDeDocumento.Name = "btnTiposDeDocumento";
            this.btnTiposDeDocumento.Size = new System.Drawing.Size(117, 61);
            this.btnTiposDeDocumento.TabIndex = 5;
            this.btnTiposDeDocumento.Text = "Tipos de Documentos";
            this.btnTiposDeDocumento.UseVisualStyleBackColor = true;
            this.btnTiposDeDocumento.Click += new System.EventHandler(this.btnTiposDeDocumento_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.Location = new System.Drawing.Point(222, 32);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(117, 61);
            this.btnLocalidades.TabIndex = 6;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Location = new System.Drawing.Point(668, 32);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(117, 61);
            this.btnEmpleados.TabIndex = 7;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(493, 32);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(117, 61);
            this.btnClientes.TabIndex = 8;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(712, 376);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 44);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAutos
            // 
            this.btnAutos.Location = new System.Drawing.Point(41, 157);
            this.btnAutos.Name = "btnAutos";
            this.btnAutos.Size = new System.Drawing.Size(117, 61);
            this.btnAutos.TabIndex = 9;
            this.btnAutos.Text = "Autos";
            this.btnAutos.UseVisualStyleBackColor = true;
            this.btnAutos.Click += new System.EventHandler(this.btnAutos_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "Alquileres";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.Location = new System.Drawing.Point(668, 262);
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(117, 61);
            this.btnDevoluciones.TabIndex = 11;
            this.btnDevoluciones.Text = "Devoluciones";
            this.btnDevoluciones.UseVisualStyleBackColor = true;
            this.btnDevoluciones.Click += new System.EventHandler(this.btnDevoluciones_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 452);
            this.ControlBox = false;
            this.Controls.Add(this.btnDevoluciones);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAutos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnLocalidades);
            this.Controls.Add(this.btnTiposDeDocumento);
            this.Controls.Add(this.btnTiposDeVehiculos);
            this.Controls.Add(this.btnCombustibles);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.btnProvincias);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProvincias;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnCombustibles;
        private System.Windows.Forms.Button btnTiposDeVehiculos;
        private System.Windows.Forms.Button btnTiposDeDocumento;
        private System.Windows.Forms.Button btnLocalidades;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnAutos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDevoluciones;
    }
}

