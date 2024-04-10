namespace Gestor_de_hotel_las_karpass
{
    partial class ReservasForm
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
            this.BtEliminar = new System.Windows.Forms.Button();
            this.DataViewReservas = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.labelFinReserva = new System.Windows.Forms.Label();
            this.labelInicioReserva = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.datePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.datePickerFin = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtEliminar
            // 
            this.BtEliminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtEliminar.Location = new System.Drawing.Point(777, 536);
            this.BtEliminar.Name = "BtEliminar";
            this.BtEliminar.Size = new System.Drawing.Size(160, 40);
            this.BtEliminar.TabIndex = 4;
            this.BtEliminar.Text = "ELIMINAR";
            this.BtEliminar.UseVisualStyleBackColor = true;
            // 
            // DataViewReservas
            // 
            this.DataViewReservas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataViewReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewReservas.Location = new System.Drawing.Point(492, 39);
            this.DataViewReservas.Name = "DataViewReservas";
            this.DataViewReservas.Size = new System.Drawing.Size(472, 477);
            this.DataViewReservas.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label.Location = new System.Drawing.Point(60, 117);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(179, 21);
            this.label.TabIndex = 24;
            this.label.Text = "Habitaciones a Reservar:";
            // 
            // labelFinReserva
            // 
            this.labelFinReserva.AutoSize = true;
            this.labelFinReserva.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelFinReserva.Location = new System.Drawing.Point(263, 78);
            this.labelFinReserva.Name = "labelFinReserva";
            this.labelFinReserva.Size = new System.Drawing.Size(52, 21);
            this.labelFinReserva.TabIndex = 23;
            this.labelFinReserva.Text = "Hasta:";
            // 
            // labelInicioReserva
            // 
            this.labelInicioReserva.AutoSize = true;
            this.labelInicioReserva.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelInicioReserva.Location = new System.Drawing.Point(60, 78);
            this.labelInicioReserva.Name = "labelInicioReserva";
            this.labelInicioReserva.Size = new System.Drawing.Size(60, 21);
            this.labelInicioReserva.TabIndex = 22;
            this.labelInicioReserva.Text = "Desde: ";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCliente.Location = new System.Drawing.Point(60, 38);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(65, 21);
            this.labelCliente.TabIndex = 21;
            this.labelCliente.Text = "Cliente: ";
            // 
            // BtGuardar
            // 
            this.BtGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtGuardar.Location = new System.Drawing.Point(155, 476);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(160, 40);
            this.BtGuardar.TabIndex = 20;
            this.BtGuardar.Text = "GUARDAR";
            this.BtGuardar.UseVisualStyleBackColor = true;
            // 
            // datePickerInicio
            // 
            this.datePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerInicio.Location = new System.Drawing.Point(126, 80);
            this.datePickerInicio.Name = "datePickerInicio";
            this.datePickerInicio.Size = new System.Drawing.Size(96, 20);
            this.datePickerInicio.TabIndex = 37;
            // 
            // datePickerFin
            // 
            this.datePickerFin.Checked = false;
            this.datePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerFin.Location = new System.Drawing.Point(321, 80);
            this.datePickerFin.Name = "datePickerFin";
            this.datePickerFin.Size = new System.Drawing.Size(96, 20);
            this.datePickerFin.TabIndex = 38;
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(126, 38);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(291, 21);
            this.comboBoxCliente.TabIndex = 39;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(64, 154);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(353, 139);
            this.checkedListBox1.TabIndex = 40;
            // 
            // ReservasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 664);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.datePickerFin);
            this.Controls.Add(this.datePickerInicio);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelFinReserva);
            this.Controls.Add(this.labelInicioReserva);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.BtGuardar);
            this.Controls.Add(this.BtEliminar);
            this.Controls.Add(this.DataViewReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReservasForm";
            this.Text = "ReservasForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataViewReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtEliminar;
        private System.Windows.Forms.DataGridView DataViewReservas;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelFinReserva;
        private System.Windows.Forms.Label labelInicioReserva;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Button BtGuardar;
        private System.Windows.Forms.DateTimePicker datePickerInicio;
        private System.Windows.Forms.DateTimePicker datePickerFin;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}