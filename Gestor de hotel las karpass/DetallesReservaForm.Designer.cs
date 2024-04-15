namespace Gestor_de_hotel_las_karpass
{
    partial class DetallesReservaForm
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
            this.labelCantPersonasMax = new System.Windows.Forms.Label();
            this.numericCantPersonas = new System.Windows.Forms.NumericUpDown();
            this.labelCantPersonas = new System.Windows.Forms.Label();
            this.labelPrecioTotal = new System.Windows.Forms.Label();
            this.checkedListHabitaciones = new System.Windows.Forms.CheckedListBox();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.datePickerFin = new System.Windows.Forms.DateTimePicker();
            this.datePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.labelFinReserva = new System.Windows.Forms.Label();
            this.labelInicioReserva = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.labelNumReserva = new System.Windows.Forms.Label();
            this.labelEncargado = new System.Windows.Forms.Label();
            this.labelPrecioDetalles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCantPersonasMax
            // 
            this.labelCantPersonasMax.AutoSize = true;
            this.labelCantPersonasMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.labelCantPersonasMax.Location = new System.Drawing.Point(272, 389);
            this.labelCantPersonasMax.Name = "labelCantPersonasMax";
            this.labelCantPersonasMax.Size = new System.Drawing.Size(114, 21);
            this.labelCantPersonasMax.TabIndex = 57;
            this.labelCantPersonasMax.Text = "MAX sin definir";
            // 
            // numericCantPersonas
            // 
            this.numericCantPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCantPersonas.Location = new System.Drawing.Point(216, 389);
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
            this.numericCantPersonas.TabIndex = 56;
            this.numericCantPersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericCantPersonas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCantPersonas.ValueChanged += new System.EventHandler(this.numericCantPersonas_ValueChanged);
            // 
            // labelCantPersonas
            // 
            this.labelCantPersonas.AutoSize = true;
            this.labelCantPersonas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCantPersonas.Location = new System.Drawing.Point(47, 389);
            this.labelCantPersonas.Name = "labelCantPersonas";
            this.labelCantPersonas.Size = new System.Drawing.Size(163, 21);
            this.labelCantPersonas.TabIndex = 55;
            this.labelCantPersonas.Text = "Cantidad de personas:";
            // 
            // labelPrecioTotal
            // 
            this.labelPrecioTotal.AutoSize = true;
            this.labelPrecioTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.labelPrecioTotal.Location = new System.Drawing.Point(47, 487);
            this.labelPrecioTotal.Name = "labelPrecioTotal";
            this.labelPrecioTotal.Size = new System.Drawing.Size(81, 25);
            this.labelPrecioTotal.TabIndex = 54;
            this.labelPrecioTotal.Text = "Total: $0";
            // 
            // checkedListHabitaciones
            // 
            this.checkedListHabitaciones.CheckOnClick = true;
            this.checkedListHabitaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListHabitaciones.FormattingEnabled = true;
            this.checkedListHabitaciones.Location = new System.Drawing.Point(52, 163);
            this.checkedListHabitaciones.Name = "checkedListHabitaciones";
            this.checkedListHabitaciones.Size = new System.Drawing.Size(353, 213);
            this.checkedListHabitaciones.TabIndex = 53;
            this.checkedListHabitaciones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListHabitaciones_ItemCheck);
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(114, 55);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(291, 21);
            this.comboBoxCliente.TabIndex = 52;
            // 
            // datePickerFin
            // 
            this.datePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerFin.Location = new System.Drawing.Point(309, 96);
            this.datePickerFin.MinDate = new System.DateTime(2024, 3, 25, 0, 0, 0, 0);
            this.datePickerFin.Name = "datePickerFin";
            this.datePickerFin.Size = new System.Drawing.Size(96, 20);
            this.datePickerFin.TabIndex = 51;
            this.datePickerFin.Value = new System.DateTime(2024, 4, 13, 0, 0, 0, 0);
            this.datePickerFin.ValueChanged += new System.EventHandler(this.datePickerFin_ValueChanged);
            // 
            // datePickerInicio
            // 
            this.datePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerInicio.Location = new System.Drawing.Point(115, 95);
            this.datePickerInicio.MinDate = new System.DateTime(2024, 3, 25, 0, 0, 0, 0);
            this.datePickerInicio.Name = "datePickerInicio";
            this.datePickerInicio.Size = new System.Drawing.Size(96, 20);
            this.datePickerInicio.TabIndex = 50;
            this.datePickerInicio.Value = new System.DateTime(2024, 4, 12, 0, 0, 0, 0);
            this.datePickerInicio.ValueChanged += new System.EventHandler(this.datePickerInicio_ValueChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label.Location = new System.Drawing.Point(48, 130);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(181, 21);
            this.label.TabIndex = 49;
            this.label.Text = "Habitaciones reservadas:";
            // 
            // labelFinReserva
            // 
            this.labelFinReserva.AutoSize = true;
            this.labelFinReserva.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelFinReserva.Location = new System.Drawing.Point(251, 95);
            this.labelFinReserva.Name = "labelFinReserva";
            this.labelFinReserva.Size = new System.Drawing.Size(52, 21);
            this.labelFinReserva.TabIndex = 48;
            this.labelFinReserva.Text = "Hasta:";
            // 
            // labelInicioReserva
            // 
            this.labelInicioReserva.AutoSize = true;
            this.labelInicioReserva.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelInicioReserva.Location = new System.Drawing.Point(48, 95);
            this.labelInicioReserva.Name = "labelInicioReserva";
            this.labelInicioReserva.Size = new System.Drawing.Size(56, 21);
            this.labelInicioReserva.TabIndex = 47;
            this.labelInicioReserva.Text = "Desde:";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCliente.Location = new System.Drawing.Point(48, 55);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(65, 21);
            this.labelCliente.TabIndex = 46;
            this.labelCliente.Text = "Cliente: ";
            // 
            // BtGuardar
            // 
            this.BtGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtGuardar.Location = new System.Drawing.Point(143, 527);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(160, 40);
            this.BtGuardar.TabIndex = 45;
            this.BtGuardar.Text = "GUARDAR";
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // labelNumReserva
            // 
            this.labelNumReserva.AutoSize = true;
            this.labelNumReserva.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelNumReserva.Location = new System.Drawing.Point(48, 19);
            this.labelNumReserva.Name = "labelNumReserva";
            this.labelNumReserva.Size = new System.Drawing.Size(117, 21);
            this.labelNumReserva.TabIndex = 58;
            this.labelNumReserva.Text = "N° reserva: 123\r\n";
            // 
            // labelEncargado
            // 
            this.labelEncargado.AutoSize = true;
            this.labelEncargado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelEncargado.Location = new System.Drawing.Point(235, 19);
            this.labelEncargado.Name = "labelEncargado";
            this.labelEncargado.Size = new System.Drawing.Size(117, 21);
            this.labelEncargado.TabIndex = 59;
            this.labelEncargado.Text = "Encargado: 123\r\n";
            // 
            // labelPrecioDetalles
            // 
            this.labelPrecioDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPrecioDetalles.AutoSize = true;
            this.labelPrecioDetalles.Location = new System.Drawing.Point(53, 435);
            this.labelPrecioDetalles.Name = "labelPrecioDetalles";
            this.labelPrecioDetalles.Size = new System.Drawing.Size(112, 52);
            this.labelPrecioDetalles.TabIndex = 60;
            this.labelPrecioDetalles.Text = "$0\r\n-0% (cliente frecuente)\r\n-0% (temporada)\r\n-0 noches gratis";
            this.labelPrecioDetalles.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // DetallesReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 588);
            this.Controls.Add(this.labelPrecioDetalles);
            this.Controls.Add(this.labelEncargado);
            this.Controls.Add(this.labelNumReserva);
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
            this.Name = "DetallesReservaForm";
            this.Text = "DetallesReservaForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericCantPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCantPersonasMax;
        private System.Windows.Forms.NumericUpDown numericCantPersonas;
        private System.Windows.Forms.Label labelCantPersonas;
        private System.Windows.Forms.Label labelPrecioTotal;
        private System.Windows.Forms.CheckedListBox checkedListHabitaciones;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.DateTimePicker datePickerFin;
        private System.Windows.Forms.DateTimePicker datePickerInicio;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelFinReserva;
        private System.Windows.Forms.Label labelInicioReserva;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Button BtGuardar;
        private System.Windows.Forms.Label labelNumReserva;
        private System.Windows.Forms.Label labelEncargado;
        private System.Windows.Forms.Label labelPrecioDetalles;
    }
}