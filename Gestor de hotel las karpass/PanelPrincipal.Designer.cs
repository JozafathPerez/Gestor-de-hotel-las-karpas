namespace Gestor_de_hotel_las_karpass
{
    partial class PanelPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelPrincipal));
            this.PanelAreaDeTrabajo = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.BtPersonal = new System.Windows.Forms.Button();
            this.BtReportería = new System.Windows.Forms.Button();
            this.BtReservas = new System.Windows.Forms.Button();
            this.BtCliente = new System.Windows.Forms.Button();
            this.ImagenMenu = new System.Windows.Forms.PictureBox();
            this.PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelAreaDeTrabajo
            // 
            this.PanelAreaDeTrabajo.Location = new System.Drawing.Point(234, 0);
            this.PanelAreaDeTrabajo.Name = "PanelAreaDeTrabajo";
            this.PanelAreaDeTrabajo.Size = new System.Drawing.Size(1012, 664);
            this.PanelAreaDeTrabajo.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.Controls.Add(this.BtPersonal);
            this.PanelMenu.Controls.Add(this.BtReportería);
            this.PanelMenu.Controls.Add(this.BtReservas);
            this.PanelMenu.Controls.Add(this.BtCliente);
            this.PanelMenu.Controls.Add(this.ImagenMenu);
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(235, 665);
            this.PanelMenu.TabIndex = 1;
            // 
            // BtPersonal
            // 
            this.BtPersonal.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtPersonal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtPersonal.Location = new System.Drawing.Point(28, 373);
            this.BtPersonal.Name = "BtPersonal";
            this.BtPersonal.Size = new System.Drawing.Size(178, 30);
            this.BtPersonal.TabIndex = 3;
            this.BtPersonal.Text = "Gestión de personal";
            this.BtPersonal.UseVisualStyleBackColor = false;
            this.BtPersonal.Click += new System.EventHandler(this.BtPersonal_Click);
            // 
            // BtReportería
            // 
            this.BtReportería.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtReportería.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtReportería.Location = new System.Drawing.Point(28, 316);
            this.BtReportería.Name = "BtReportería";
            this.BtReportería.Size = new System.Drawing.Size(178, 30);
            this.BtReportería.TabIndex = 2;
            this.BtReportería.Text = "Gestión de reportería";
            this.BtReportería.UseVisualStyleBackColor = false;
            this.BtReportería.Click += new System.EventHandler(this.BtReportería_Click);
            // 
            // BtReservas
            // 
            this.BtReservas.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtReservas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtReservas.Location = new System.Drawing.Point(28, 260);
            this.BtReservas.Name = "BtReservas";
            this.BtReservas.Size = new System.Drawing.Size(178, 30);
            this.BtReservas.TabIndex = 1;
            this.BtReservas.Text = "Gestión de reservas";
            this.BtReservas.UseVisualStyleBackColor = false;
            this.BtReservas.Click += new System.EventHandler(this.BtReservas_Click);
            // 
            // BtCliente
            // 
            this.BtCliente.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtCliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtCliente.Location = new System.Drawing.Point(28, 206);
            this.BtCliente.Name = "BtCliente";
            this.BtCliente.Size = new System.Drawing.Size(178, 30);
            this.BtCliente.TabIndex = 0;
            this.BtCliente.Text = "Gestión de clientes";
            this.BtCliente.UseVisualStyleBackColor = false;
            this.BtCliente.Click += new System.EventHandler(this.BtCliente_Click);
            // 
            // ImagenMenu
            // 
            this.ImagenMenu.Image = ((System.Drawing.Image)(resources.GetObject("ImagenMenu.Image")));
            this.ImagenMenu.Location = new System.Drawing.Point(0, 0);
            this.ImagenMenu.Name = "ImagenMenu";
            this.ImagenMenu.Size = new System.Drawing.Size(235, 665);
            this.ImagenMenu.TabIndex = 0;
            this.ImagenMenu.TabStop = false;
            // 
            // PanelPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 664);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.PanelAreaDeTrabajo);
            this.Name = "PanelPrincipal";
            this.Text = "PanelPrincipal";
            this.PanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelAreaDeTrabajo;
        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.PictureBox ImagenMenu;
        private System.Windows.Forms.Button BtPersonal;
        private System.Windows.Forms.Button BtReportería;
        private System.Windows.Forms.Button BtReservas;
        private System.Windows.Forms.Button BtCliente;
    }
}