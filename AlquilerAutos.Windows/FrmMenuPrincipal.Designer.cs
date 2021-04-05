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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProvincias
            // 
            this.btnProvincias.Location = new System.Drawing.Point(41, 59);
            this.btnProvincias.Name = "btnProvincias";
            this.btnProvincias.Size = new System.Drawing.Size(117, 61);
            this.btnProvincias.TabIndex = 1;
            this.btnProvincias.Text = "Provincias";
            this.btnProvincias.UseVisualStyleBackColor = true;
            this.btnProvincias.Click += new System.EventHandler(this.btnProvincias_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Location = new System.Drawing.Point(191, 59);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(117, 61);
            this.btnMarcas.TabIndex = 2;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnCombustibles
            // 
            this.btnCombustibles.Location = new System.Drawing.Point(341, 59);
            this.btnCombustibles.Name = "btnCombustibles";
            this.btnCombustibles.Size = new System.Drawing.Size(117, 61);
            this.btnCombustibles.TabIndex = 3;
            this.btnCombustibles.Text = "Combustibles";
            this.btnCombustibles.UseVisualStyleBackColor = true;
            this.btnCombustibles.Click += new System.EventHandler(this.btnCombustibles_Click);
            // 
            // btnTiposDeVehiculos
            // 
            this.btnTiposDeVehiculos.Location = new System.Drawing.Point(41, 156);
            this.btnTiposDeVehiculos.Name = "btnTiposDeVehiculos";
            this.btnTiposDeVehiculos.Size = new System.Drawing.Size(117, 61);
            this.btnTiposDeVehiculos.TabIndex = 4;
            this.btnTiposDeVehiculos.Text = "Tipos de Vehiculos";
            this.btnTiposDeVehiculos.UseVisualStyleBackColor = true;
            this.btnTiposDeVehiculos.Click += new System.EventHandler(this.btnTiposDeVehiculos_Click);
            // 
            // btnTiposDeDocumento
            // 
            this.btnTiposDeDocumento.Location = new System.Drawing.Point(191, 156);
            this.btnTiposDeDocumento.Name = "btnTiposDeDocumento";
            this.btnTiposDeDocumento.Size = new System.Drawing.Size(117, 61);
            this.btnTiposDeDocumento.TabIndex = 5;
            this.btnTiposDeDocumento.Text = "Tipos de Documentos";
            this.btnTiposDeDocumento.UseVisualStyleBackColor = true;
            this.btnTiposDeDocumento.Click += new System.EventHandler(this.btnTiposDeDocumento_Click);
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
            // btnLocalidades
            // 
            this.btnLocalidades.Location = new System.Drawing.Point(341, 156);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(117, 61);
            this.btnLocalidades.TabIndex = 6;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnLocalidades);
            this.Controls.Add(this.btnTiposDeDocumento);
            this.Controls.Add(this.btnTiposDeVehiculos);
            this.Controls.Add(this.btnCombustibles);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.btnProvincias);
            this.Controls.Add(this.btnClose);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
    }
}

