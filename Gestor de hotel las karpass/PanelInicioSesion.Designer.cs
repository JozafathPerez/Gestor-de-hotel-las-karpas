namespace Gestor_de_hotel_las_karpass
{
    partial class PanelInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelInicioSesion));
            this.BtInicioSesion = new System.Windows.Forms.Button();
            this.Label_InicioSesion = new System.Windows.Forms.Label();
            this.TxCuenta = new System.Windows.Forms.TextBox();
            this.TxContrasena = new System.Windows.Forms.TextBox();
            this.LogoPrincipal = new System.Windows.Forms.PictureBox();
            this.LogoCuenta = new System.Windows.Forms.PictureBox();
            this.LogoContrasena = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoContrasena)).BeginInit();
            this.SuspendLayout();
            // 
            // BtInicioSesion
            // 
            this.BtInicioSesion.BackColor = System.Drawing.Color.Orange;
            this.BtInicioSesion.Location = new System.Drawing.Point(496, 494);
            this.BtInicioSesion.Name = "BtInicioSesion";
            this.BtInicioSesion.Size = new System.Drawing.Size(165, 42);
            this.BtInicioSesion.TabIndex = 0;
            this.BtInicioSesion.Text = "Iniciar Sesión";
            this.BtInicioSesion.UseVisualStyleBackColor = false;
            this.BtInicioSesion.Click += new System.EventHandler(this.BtInicioSesion_Click);
            // 
            // Label_InicioSesion
            // 
            this.Label_InicioSesion.AutoSize = true;
            this.Label_InicioSesion.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.Label_InicioSesion.Location = new System.Drawing.Point(391, 306);
            this.Label_InicioSesion.Name = "Label_InicioSesion";
            this.Label_InicioSesion.Size = new System.Drawing.Size(359, 65);
            this.Label_InicioSesion.TabIndex = 1;
            this.Label_InicioSesion.Text = "Inicio de Sesión";
            // 
            // TxCuenta
            // 
            this.TxCuenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TxCuenta.Location = new System.Drawing.Point(451, 383);
            this.TxCuenta.Name = "TxCuenta";
            this.TxCuenta.Size = new System.Drawing.Size(255, 29);
            this.TxCuenta.TabIndex = 2;
            this.TxCuenta.Enter += new System.EventHandler(this.TxCuenta_Enter);
            this.TxCuenta.Leave += new System.EventHandler(this.TxCuenta_Leave);
            // 
            // TxContrasena
            // 
            this.TxContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TxContrasena.Location = new System.Drawing.Point(451, 443);
            this.TxContrasena.Name = "TxContrasena";
            this.TxContrasena.Size = new System.Drawing.Size(255, 29);
            this.TxContrasena.TabIndex = 3;
            this.TxContrasena.Enter += new System.EventHandler(this.TxContrasena_Enter);
            this.TxContrasena.Leave += new System.EventHandler(this.TxContrasena_Leave);
            // 
            // LogoPrincipal
            // 
            this.LogoPrincipal.Image = ((System.Drawing.Image)(resources.GetObject("LogoPrincipal.Image")));
            this.LogoPrincipal.Location = new System.Drawing.Point(424, 0);
            this.LogoPrincipal.Name = "LogoPrincipal";
            this.LogoPrincipal.Size = new System.Drawing.Size(282, 303);
            this.LogoPrincipal.TabIndex = 4;
            this.LogoPrincipal.TabStop = false;
            // 
            // LogoCuenta
            // 
            this.LogoCuenta.Image = ((System.Drawing.Image)(resources.GetObject("LogoCuenta.Image")));
            this.LogoCuenta.Location = new System.Drawing.Point(401, 374);
            this.LogoCuenta.Name = "LogoCuenta";
            this.LogoCuenta.Size = new System.Drawing.Size(47, 48);
            this.LogoCuenta.TabIndex = 5;
            this.LogoCuenta.TabStop = false;
            // 
            // LogoContrasena
            // 
            this.LogoContrasena.Image = ((System.Drawing.Image)(resources.GetObject("LogoContrasena.Image")));
            this.LogoContrasena.Location = new System.Drawing.Point(398, 428);
            this.LogoContrasena.Name = "LogoContrasena";
            this.LogoContrasena.Size = new System.Drawing.Size(47, 48);
            this.LogoContrasena.TabIndex = 6;
            this.LogoContrasena.TabStop = false;
            // 
            // PanelInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 636);
            this.Controls.Add(this.LogoContrasena);
            this.Controls.Add(this.LogoCuenta);
            this.Controls.Add(this.LogoPrincipal);
            this.Controls.Add(this.TxContrasena);
            this.Controls.Add(this.TxCuenta);
            this.Controls.Add(this.Label_InicioSesion);
            this.Controls.Add(this.BtInicioSesion);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PanelInicioSesion";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoContrasena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtInicioSesion;
        private System.Windows.Forms.Label Label_InicioSesion;
        private System.Windows.Forms.TextBox TxCuenta;
        private System.Windows.Forms.TextBox TxContrasena;
        private System.Windows.Forms.PictureBox LogoPrincipal;
        private System.Windows.Forms.PictureBox LogoCuenta;
        private System.Windows.Forms.PictureBox LogoContrasena;
    }
}

