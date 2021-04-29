
namespace AlquilerAutos.Windows
{
    partial class FrmDevolucionesAE
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ClienteComboBox = new System.Windows.Forms.ComboBox();
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCombustible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFechaAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(331, 212);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 57);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(154, 212);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 57);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar Devolucion";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cliente:";
            // 
            // ClienteComboBox
            // 
            this.ClienteComboBox.FormattingEnabled = true;
            this.ClienteComboBox.Location = new System.Drawing.Point(57, 11);
            this.ClienteComboBox.Name = "ClienteComboBox";
            this.ClienteComboBox.Size = new System.Drawing.Size(121, 21);
            this.ClienteComboBox.TabIndex = 14;
            this.ClienteComboBox.SelectedIndexChanged += new System.EventHandler(this.ClienteComboBox_SelectedIndexChanged);
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnMarca,
            this.cmnModelo,
            this.cmnCombustible,
            this.cmnFechaAlquiler});
            this.DatosDataGridView.Location = new System.Drawing.Point(12, 50);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(572, 140);
            this.DatosDataGridView.TabIndex = 15;
            // 
            // cmnMarca
            // 
            this.cmnMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnMarca.HeaderText = "Marca";
            this.cmnMarca.Name = "cmnMarca";
            // 
            // cmnModelo
            // 
            this.cmnModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnModelo.HeaderText = "Modelo";
            this.cmnModelo.Name = "cmnModelo";
            // 
            // cmnCombustible
            // 
            this.cmnCombustible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnCombustible.HeaderText = "Combustible";
            this.cmnCombustible.Name = "cmnCombustible";
            // 
            // cmnFechaAlquiler
            // 
            this.cmnFechaAlquiler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFechaAlquiler.HeaderText = "Fecha Alquiler";
            this.cmnFechaAlquiler.Name = "cmnFechaAlquiler";
            // 
            // NroDocTextBox
            // 
            this.NroDocTextBox.Enabled = false;
            this.NroDocTextBox.Location = new System.Drawing.Point(344, 11);
            this.NroDocTextBox.Name = "NroDocTextBox";
            this.NroDocTextBox.Size = new System.Drawing.Size(100, 20);
            this.NroDocTextBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Numero de Documento:";
            // 
            // FrmDevolucionesAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 281);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NroDocTextBox);
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.ClienteComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmDevolucionesAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDevolucionesAE";
            this.Load += new System.EventHandler(this.FrmDevolucionesAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.ComboBox ClienteComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCombustible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFechaAlquiler;
        private System.Windows.Forms.TextBox NroDocTextBox;
        private System.Windows.Forms.Label label2;
    }
}