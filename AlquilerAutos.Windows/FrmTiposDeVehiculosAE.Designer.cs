
namespace AlquilerAutos.Windows
{
    partial class FrmTiposDeVehiculosAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtboxVehiculo = new System.Windows.Forms.TextBox();
            this.labelVehiculo = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(218, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 41);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(63, 89);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 41);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtboxVehiculo
            // 
            this.txtboxVehiculo.Location = new System.Drawing.Point(63, 38);
            this.txtboxVehiculo.Name = "txtboxVehiculo";
            this.txtboxVehiculo.Size = new System.Drawing.Size(230, 20);
            this.txtboxVehiculo.TabIndex = 9;
            // 
            // labelVehiculo
            // 
            this.labelVehiculo.AutoSize = true;
            this.labelVehiculo.Location = new System.Drawing.Point(6, 41);
            this.labelVehiculo.Name = "labelVehiculo";
            this.labelVehiculo.Size = new System.Drawing.Size(51, 13);
            this.labelVehiculo.TabIndex = 8;
            this.labelVehiculo.Text = "Vehiculo:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmTiposDeVehiculosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 142);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtboxVehiculo);
            this.Controls.Add(this.labelVehiculo);
            this.Name = "FrmTiposDeVehiculosAE";
            this.Text = "FrmTipoDeVehiculosAE";
            this.Load += new System.EventHandler(this.FrmTiposDeVehiculosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtboxVehiculo;
        private System.Windows.Forms.Label labelVehiculo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}