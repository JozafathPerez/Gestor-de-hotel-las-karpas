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
            this.buttonModificar = new System.Windows.Forms.Button();
            this.labelPrecioDetalles = new System.Windows.Forms.Label();
            this.buttonFiltroCancelaciones = new System.Windows.Forms.Button();
            this.buttonMostrarTodo = new System.Windows.Forms.Button();
            this.buttonConfirmarCancelacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtEliminar
            // 
            this.BtEliminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtEliminar.Location = new System.Drawing.Point(700, 542);
            this.BtEliminar.Name = "BtEliminar";
            this.BtEliminar.Size = new System.Drawing.Size(98, 38);
            this.BtEliminar.TabIndex = 4;
            this.BtEliminar.Text = "CANCELAR";
            this.BtEliminar.UseVisualStyleBackColor = true;
            this.BtEliminar.Click += new System.EventHandler(this.BtEliminar_Click);
            // 
            // DataViewReservas
            // 
            this.DataViewReservas.AllowUserToAddRows = false;
            this.DataViewReservas.AllowUserToDeleteRows = false;
            this.DataViewReservas.AllowUserToResizeRows = false;
            this.DataViewReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataViewReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataViewReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewReservas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataViewReservas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.DataViewReservas.Location = new System.Drawing.Point(492, 65);
            this.DataViewReservas.Name = "DataViewReservas";
            this.DataViewReservas.ReadOnly = true;
            this.DataViewReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataViewReservas.Size = new System.Drawing.Size(472, 462);
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
            this.BtGuardar.Location = new System.Drawing.Point(492, 542);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(93, 38);
            this.BtGuardar.TabIndex = 20;
            this.BtGuardar.Text = "GUARDAR";
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // datePickerInicio
            // 
            this.datePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerInicio.Location = new System.Drawing.Point(126, 80);
            this.datePickerInicio.MinDate = new System.DateTime(2024, 4, 12, 0, 0, 0, 0);
            this.datePickerInicio.Name = "datePickerInicio";
            this.datePickerInicio.Size = new System.Drawing.Size(96, 20);
            this.datePickerInicio.TabIndex = 37;
            this.datePickerInicio.Value = new System.DateTime(2024, 4, 12, 0, 0, 0, 0);
            this.datePickerInicio.ValueChanged += new System.EventHandler(this.datePickerInicio_ValueChanged);
            // 
            // datePickerFin
            // 
            this.datePickerFin.Checked = false;
            this.datePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerFin.Location = new System.Drawing.Point(321, 80);
            this.datePickerFin.MinDate = new System.DateTime(2024, 4, 13, 0, 0, 0, 0);
            this.datePickerFin.Name = "datePickerFin";
            this.datePickerFin.Size = new System.Drawing.Size(96, 20);
            this.datePickerFin.TabIndex = 38;
            this.datePickerFin.Value = new System.DateTime(2024, 4, 13, 0, 0, 0, 0);
            this.datePickerFin.ValueChanged += new System.EventHandler(this.datePickerFin_ValueChanged);
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
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCliente_SelectedIndexChanged);
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
            this.checkedListHabitaciones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListHabitaciones_ItemCheck);
            // 
            // labelPrecioTotal
            // 
            this.labelPrecioTotal.AutoSize = true;
            this.labelPrecioTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.labelPrecioTotal.Location = new System.Drawing.Point(59, 542);
            this.labelPrecioTotal.Name = "labelPrecioTotal";
            this.labelPrecioTotal.Size = new System.Drawing.Size(81, 25);
            this.labelPrecioTotal.TabIndex = 41;
            this.labelPrecioTotal.Text = "Total: $0";
            // 
            // labelCantPersonas
            // 
            this.labelCantPersonas.AutoSize = true;
            this.labelCantPersonas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCantPersonas.Location = new System.Drawing.Point(62, 421);
            this.labelCantPersonas.Name = "labelCantPersonas";
            this.labelCantPersonas.Size = new System.Drawing.Size(163, 21);
            this.labelCantPersonas.TabIndex = 42;
            this.labelCantPersonas.Text = "Cantidad de personas:";
            // 
            // numericCantPersonas
            // 
            this.numericCantPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCantPersonas.Location = new System.Drawing.Point(231, 421);
            this.numericCantPersonas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericCantPersonas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCantPersonas.Name = "numericCantPersonas";
            this.numericCantPersonas.Size = new System.Drawing.Size(50, 24);
            this.numericCantPersonas.TabIndex = 43;
            this.numericCantPersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericCantPersonas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCantPersonas.ValueChanged += new System.EventHandler(this.numericCantPersonas_ValueChanged);
            // 
            // labelCantPersonasMax
            // 
            this.labelCantPersonasMax.AutoSize = true;
            this.labelCantPersonasMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.labelCantPersonasMax.Location = new System.Drawing.Point(287, 421);
            this.labelCantPersonasMax.Name = "labelCantPersonasMax";
            this.labelCantPersonasMax.Size = new System.Drawing.Size(114, 21);
            this.labelCantPersonasMax.TabIndex = 44;
            this.labelCantPersonasMax.Text = "MAX sin definir";
            // 
            // buttonModificar
            // 
            this.buttonModificar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonModificar.Location = new System.Drawing.Point(591, 542);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(101, 38);
            this.buttonModificar.TabIndex = 45;
            this.buttonModificar.Text = "MODIFICAR";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // labelPrecioDetalles
            // 
            this.labelPrecioDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPrecioDetalles.AutoSize = true;
            this.labelPrecioDetalles.Location = new System.Drawing.Point(61, 490);
            this.labelPrecioDetalles.Name = "labelPrecioDetalles";
            this.labelPrecioDetalles.Size = new System.Drawing.Size(112, 52);
            this.labelPrecioDetalles.TabIndex = 46;
            this.labelPrecioDetalles.Text = "$0\r\n-0% (cliente frecuente)\r\n-0% (temporada)\r\n-0 noches gratis";
            this.labelPrecioDetalles.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonFiltroCancelaciones
            // 
            this.buttonFiltroCancelaciones.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonFiltroCancelaciones.Location = new System.Drawing.Point(835, 38);
            this.buttonFiltroCancelaciones.Name = "buttonFiltroCancelaciones";
            this.buttonFiltroCancelaciones.Size = new System.Drawing.Size(129, 21);
            this.buttonFiltroCancelaciones.TabIndex = 47;
            this.buttonFiltroCancelaciones.Text = "mostrar cancelaciones";
            this.buttonFiltroCancelaciones.UseVisualStyleBackColor = true;
            this.buttonFiltroCancelaciones.Click += new System.EventHandler(this.buttonFiltroCancelaciones_Click);
            // 
            // buttonMostrarTodo
            // 
            this.buttonMostrarTodo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonMostrarTodo.Location = new System.Drawing.Point(738, 38);
            this.buttonMostrarTodo.Name = "buttonMostrarTodo";
            this.buttonMostrarTodo.Size = new System.Drawing.Size(91, 21);
            this.buttonMostrarTodo.TabIndex = 48;
            this.buttonMostrarTodo.Text = "mostrar todo";
            this.buttonMostrarTodo.UseVisualStyleBackColor = true;
            this.buttonMostrarTodo.Click += new System.EventHandler(this.buttonMostrarTodo_Click);
            // 
            // buttonConfirmarCancelacion
            // 
            this.buttonConfirmarCancelacion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonConfirmarCancelacion.Location = new System.Drawing.Point(804, 542);
            this.buttonConfirmarCancelacion.Name = "buttonConfirmarCancelacion";
            this.buttonConfirmarCancelacion.Size = new System.Drawing.Size(160, 38);
            this.buttonConfirmarCancelacion.TabIndex = 49;
            this.buttonConfirmarCancelacion.Text = "CONFIRMAR CANCELACION";
            this.buttonConfirmarCancelacion.UseVisualStyleBackColor = true;
            this.buttonConfirmarCancelacion.Click += new System.EventHandler(this.buttonConfirmarCancelacion_Click);
            // 
            // ReservasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 664);
            this.Controls.Add(this.buttonConfirmarCancelacion);
            this.Controls.Add(this.buttonMostrarTodo);
            this.Controls.Add(this.buttonFiltroCancelaciones);
            this.Controls.Add(this.labelPrecioDetalles);
            this.Controls.Add(this.buttonModificar);
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
            this.Load += new System.EventHandler(this.ReservasForm_Load);
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
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Label labelPrecioDetalles;
        private System.Windows.Forms.Button buttonFiltroCancelaciones;
        private System.Windows.Forms.Button buttonMostrarTodo;
        private System.Windows.Forms.Button buttonConfirmarCancelacion;
    }
}