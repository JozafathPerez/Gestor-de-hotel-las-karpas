using System;

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
            this.checkedListHabitaciones = new System.Windows.Forms.CheckedListBox();
            this.labelPrecioTotal = new System.Windows.Forms.Label();
            this.labelCantPersonas = new System.Windows.Forms.Label();
            this.numericCantPersonas = new System.Windows.Forms.NumericUpDown();
            this.labelCantPersonasMax = new System.Windows.Forms.Label();
            this.btnConfirmarHabitaciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtEliminar
            // 
            this.BtEliminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtEliminar.Location = new System.Drawing.Point(804, 536);
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
            this.label.Location = new System.Drawing.Point(60, 119);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(258, 21);
            this.label.TabIndex = 24;
            this.label.Text = "Habitaciones disponibles a reservar:";
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
            this.BtGuardar.Location = new System.Drawing.Point(64, 536);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(160, 40);
            this.BtGuardar.TabIndex = 20;
            this.BtGuardar.Text = "GUARDAR";
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // datePickerInicio
            // 
            this.datePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerInicio.Location = new System.Drawing.Point(126, 80);
            this.datePickerInicio.Name = "datePickerInicio";
            this.datePickerInicio.Size = new System.Drawing.Size(96, 20);
            this.datePickerInicio.TabIndex = 37;
            this.datePickerInicio.MinDate = System.DateTime.Today;
            this.datePickerInicio.Value = System.DateTime.Today;
            // 
            // datePickerFin
            // 
            this.datePickerFin.Checked = false;
            this.datePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerFin.Location = new System.Drawing.Point(321, 80);
            this.datePickerFin.Name = "datePickerFin";
            this.datePickerFin.Size = new System.Drawing.Size(96, 20);
            this.datePickerFin.TabIndex = 38;
            this.datePickerFin.MinDate = System.DateTime.Today.AddDays(1);
            this.datePickerFin.Value = System.DateTime.Today.AddDays(1);
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(126, 38);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(291, 21);
            this.comboBoxCliente.TabIndex = 39;
            // 
            // checkedListHabitaciones
            // 
            this.checkedListHabitaciones.CheckOnClick = true;
            this.checkedListHabitaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListHabitaciones.FormattingEnabled = true;
            this.checkedListHabitaciones.Location = new System.Drawing.Point(64, 154);
            this.checkedListHabitaciones.Name = "checkedListHabitaciones";
            this.checkedListHabitaciones.Size = new System.Drawing.Size(353, 251);
            this.checkedListHabitaciones.TabIndex = 40;
            // 
            // labelPrecioTotal
            // 
            this.labelPrecioTotal.AutoSize = true;
            this.labelPrecioTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.labelPrecioTotal.Location = new System.Drawing.Point(59, 491);
            this.labelPrecioTotal.Name = "labelPrecioTotal";
            this.labelPrecioTotal.Size = new System.Drawing.Size(81, 25);
            this.labelPrecioTotal.TabIndex = 41;
            this.labelPrecioTotal.Text = "Total: $0";
            // 
            // labelCantPersonas
            // 
            this.labelCantPersonas.AutoSize = true;
            this.labelCantPersonas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCantPersonas.Location = new System.Drawing.Point(60, 456);
            this.labelCantPersonas.Name = "labelCantPersonas";
            this.labelCantPersonas.Size = new System.Drawing.Size(163, 21);
            this.labelCantPersonas.TabIndex = 42;
            this.labelCantPersonas.Text = "Cantidad de personas:";
            // 
            // numericCantPersonas
            // 
            this.numericCantPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCantPersonas.Location = new System.Drawing.Point(229, 456);
            this.numericCantPersonas.Name = "numericCantPersonas";
            this.numericCantPersonas.Size = new System.Drawing.Size(50, 24);
            this.numericCantPersonas.TabIndex = 43;
            this.numericCantPersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCantPersonasMax
            // 
            this.labelCantPersonasMax.AutoSize = true;
            this.labelCantPersonasMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.labelCantPersonasMax.Location = new System.Drawing.Point(285, 456);
            this.labelCantPersonasMax.Name = "labelCantPersonasMax";
            this.labelCantPersonasMax.Size = new System.Drawing.Size(114, 21);
            this.labelCantPersonasMax.TabIndex = 44;
            this.labelCantPersonasMax.Text = "MAX sin definir";
            // 
            // btnConfirmarHabitaciones
            // 
            this.btnConfirmarHabitaciones.Location = new System.Drawing.Point(160, 411);
            this.btnConfirmarHabitaciones.Name = "btnConfirmarHabitaciones";
            this.btnConfirmarHabitaciones.Size = new System.Drawing.Size(158, 23);
            this.btnConfirmarHabitaciones.TabIndex = 45;
            this.btnConfirmarHabitaciones.Text = "Confirmar selección";
            this.btnConfirmarHabitaciones.UseVisualStyleBackColor = true;
            this.btnConfirmarHabitaciones.Click += new System.EventHandler(this.btnConfirmarHabitaciones_Click);
            // 
            // ReservasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 664);
            this.Controls.Add(this.btnConfirmarHabitaciones);
            this.Controls.Add(this.labelCantPersonasMax);
            this.Controls.Add(this.numericCantPersonas);
            this.Controls.Add(this.labelCantPersonas);
            this.Controls.Add(this.labelPrecioTotal);
            this.Controls.Add(this.checkedListHabitaciones);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericCantPersonas)).EndInit();
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
        private System.Windows.Forms.CheckedListBox checkedListHabitaciones;
        private System.Windows.Forms.Label labelPrecioTotal;
        private System.Windows.Forms.Label labelCantPersonas;
        private System.Windows.Forms.NumericUpDown numericCantPersonas;
        private System.Windows.Forms.Label labelCantPersonasMax;
        private System.Windows.Forms.Button btnConfirmarHabitaciones;
    }
}