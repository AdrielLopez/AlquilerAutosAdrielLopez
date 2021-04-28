﻿
namespace AlquilerAutos.Windows
{
    partial class FrmDevoluciones
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
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnAlquilerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnAuto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.EditarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BuscarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ActualizarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImprimirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CerrarToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnAlquilerId,
            this.cmnAuto,
            this.cmnCliente,
            this.cmnFechaDevolucion});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 54);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(800, 396);
            this.DatosDataGridView.TabIndex = 13;
            // 
            // cmnAlquilerId
            // 
            this.cmnAlquilerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnAlquilerId.HeaderText = "AlquilerId";
            this.cmnAlquilerId.Name = "cmnAlquilerId";
            this.cmnAlquilerId.ReadOnly = true;
            // 
            // cmnAuto
            // 
            this.cmnAuto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnAuto.HeaderText = "Auto";
            this.cmnAuto.Name = "cmnAuto";
            this.cmnAuto.ReadOnly = true;
            // 
            // cmnCliente
            // 
            this.cmnCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnCliente.HeaderText = "Cliente";
            this.cmnCliente.Name = "cmnCliente";
            this.cmnCliente.ReadOnly = true;
            // 
            // cmnFechaDevolucion
            // 
            this.cmnFechaDevolucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFechaDevolucion.HeaderText = "Fecha Devolucion";
            this.cmnFechaDevolucion.Name = "cmnFechaDevolucion";
            this.cmnFechaDevolucion.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNuevo,
            this.EditarToolStripButton,
            this.toolStripSeparator1,
            this.BuscarToolStripButton,
            this.ActualizarToolStripButton,
            this.toolStripSeparator2,
            this.ImprimirToolStripButton,
            this.toolStripSeparator3,
            this.CerrarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 54);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsNuevo
            // 
            this.tsNuevo.Image = global::AlquilerAutos.Windows.Properties.Resources.icons8_new_copy_32;
            this.tsNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(46, 51);
            this.tsNuevo.Text = "Nuevo";
            this.tsNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click);
            // 
            // EditarToolStripButton
            // 
            this.EditarToolStripButton.Image = global::AlquilerAutos.Windows.Properties.Resources.icons8_edit_file_32;
            this.EditarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditarToolStripButton.Name = "EditarToolStripButton";
            this.EditarToolStripButton.Size = new System.Drawing.Size(41, 51);
            this.EditarToolStripButton.Text = "Editar";
            this.EditarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // BuscarToolStripButton
            // 
            this.BuscarToolStripButton.Image = global::AlquilerAutos.Windows.Properties.Resources.icons8_search_property_32;
            this.BuscarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BuscarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BuscarToolStripButton.Name = "BuscarToolStripButton";
            this.BuscarToolStripButton.Size = new System.Drawing.Size(46, 51);
            this.BuscarToolStripButton.Text = "Buscar";
            this.BuscarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ActualizarToolStripButton
            // 
            this.ActualizarToolStripButton.Image = global::AlquilerAutos.Windows.Properties.Resources.icons8_restart_32;
            this.ActualizarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ActualizarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActualizarToolStripButton.Name = "ActualizarToolStripButton";
            this.ActualizarToolStripButton.Size = new System.Drawing.Size(63, 51);
            this.ActualizarToolStripButton.Text = "Actualizar";
            this.ActualizarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // ImprimirToolStripButton
            // 
            this.ImprimirToolStripButton.Image = global::AlquilerAutos.Windows.Properties.Resources.icons8_print_32;
            this.ImprimirToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImprimirToolStripButton.Name = "ImprimirToolStripButton";
            this.ImprimirToolStripButton.Size = new System.Drawing.Size(57, 51);
            this.ImprimirToolStripButton.Text = "Imprimir";
            this.ImprimirToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // CerrarToolStripButton
            // 
            this.CerrarToolStripButton.Image = global::AlquilerAutos.Windows.Properties.Resources.icons8_close_pane_32;
            this.CerrarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CerrarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CerrarToolStripButton.Name = "CerrarToolStripButton";
            this.CerrarToolStripButton.Size = new System.Drawing.Size(43, 51);
            this.CerrarToolStripButton.Text = "Cerrar";
            this.CerrarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CerrarToolStripButton.Click += new System.EventHandler(this.CerrarToolStripButton_Click);
            // 
            // FrmDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmDevoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDevoluciones";
            this.Load += new System.EventHandler(this.FrmDevoluciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNuevo;
        private System.Windows.Forms.ToolStripButton EditarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BuscarToolStripButton;
        private System.Windows.Forms.ToolStripButton ActualizarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ImprimirToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton CerrarToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnAlquilerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFechaDevolucion;
    }
}