namespace Gestor_de_hotel_las_karpass
{
    partial class ActualizarClienteForm
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
            this.DataViewActualizar = new System.Windows.Forms.DataGridView();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textApellido1 = new System.Windows.Forms.TextBox();
            this.textApellido2 = new System.Windows.Forms.TextBox();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.textCorreo = new System.Windows.Forms.TextBox();
            this.textPais = new System.Windows.Forms.TextBox();
            this.BtActualizar = new System.Windows.Forms.Button();
            this.labelDataGridView = new System.Windows.Forms.Label();
            this.textIdentificacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewActualizar)).BeginInit();
            this.SuspendLayout();
            // 
            // DataViewActualizar
            // 
            this.DataViewActualizar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataViewActualizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewActualizar.Location = new System.Drawing.Point(12, 44);
            this.DataViewActualizar.Name = "DataViewActualizar";
            this.DataViewActualizar.Size = new System.Drawing.Size(345, 289);
            this.DataViewActualizar.TabIndex = 1;
            // 
            // textNombre
            // 
            this.textNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(613, 76);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(184, 23);
            this.textNombre.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 210);
            this.label1.TabIndex = 50;
            this.label1.Text = "Identificación:\r\nNombre:\r\nPrimer apellido:\r\nSegundo apellido:\r\nPaís de procedenci" +
    "a:\r\nTelefono:\r\nCorreo:";
            // 
            // textApellido1
            // 
            this.textApellido1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellido1.Location = new System.Drawing.Point(613, 105);
            this.textApellido1.Name = "textApellido1";
            this.textApellido1.Size = new System.Drawing.Size(184, 23);
            this.textApellido1.TabIndex = 51;
            // 
            // textApellido2
            // 
            this.textApellido2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellido2.Location = new System.Drawing.Point(613, 144);
            this.textApellido2.Name = "textApellido2";
            this.textApellido2.Size = new System.Drawing.Size(184, 23);
            this.textApellido2.TabIndex = 52;
            // 
            // textTelefono
            // 
            this.textTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTelefono.Location = new System.Drawing.Point(613, 202);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(184, 23);
            this.textTelefono.TabIndex = 53;
            // 
            // textCorreo
            // 
            this.textCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCorreo.Location = new System.Drawing.Point(613, 231);
            this.textCorreo.Name = "textCorreo";
            this.textCorreo.Size = new System.Drawing.Size(184, 23);
            this.textCorreo.TabIndex = 54;
            // 
            // textPais
            // 
            this.textPais.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPais.Location = new System.Drawing.Point(613, 173);
            this.textPais.Name = "textPais";
            this.textPais.Size = new System.Drawing.Size(184, 23);
            this.textPais.TabIndex = 55;
            // 
            // BtActualizar
            // 
            this.BtActualizar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtActualizar.Location = new System.Drawing.Point(518, 293);
            this.BtActualizar.Name = "BtActualizar";
            this.BtActualizar.Size = new System.Drawing.Size(160, 40);
            this.BtActualizar.TabIndex = 56;
            this.BtActualizar.Text = "ACTUALIZAR";
            this.BtActualizar.UseVisualStyleBackColor = true;
            this.BtActualizar.Click += new System.EventHandler(this.BtActualizar_Click);
            // 
            // labelDataGridView
            // 
            this.labelDataGridView.AutoSize = true;
            this.labelDataGridView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDataGridView.Location = new System.Drawing.Point(12, 20);
            this.labelDataGridView.Name = "labelDataGridView";
            this.labelDataGridView.Size = new System.Drawing.Size(177, 21);
            this.labelDataGridView.TabIndex = 57;
            this.labelDataGridView.Text = "Visualizador de registro:";
            // 
            // textIdentificacion
            // 
            this.textIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIdentificacion.Location = new System.Drawing.Point(613, 44);
            this.textIdentificacion.Name = "textIdentificacion";
            this.textIdentificacion.Size = new System.Drawing.Size(184, 23);
            this.textIdentificacion.TabIndex = 58;
            // 
            // ActualizarClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textIdentificacion);
            this.Controls.Add(this.labelDataGridView);
            this.Controls.Add(this.BtActualizar);
            this.Controls.Add(this.textPais);
            this.Controls.Add(this.textCorreo);
            this.Controls.Add(this.textTelefono);
            this.Controls.Add(this.textApellido2);
            this.Controls.Add(this.textApellido1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.DataViewActualizar);
            this.Name = "ActualizarClienteForm";
            this.Text = "ActualizarClienteForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataViewActualizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataViewActualizar;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textApellido1;
        private System.Windows.Forms.TextBox textApellido2;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.TextBox textCorreo;
        private System.Windows.Forms.TextBox textPais;
        private System.Windows.Forms.Button BtActualizar;
        private System.Windows.Forms.Label labelDataGridView;
        private System.Windows.Forms.TextBox textIdentificacion;
    }
}